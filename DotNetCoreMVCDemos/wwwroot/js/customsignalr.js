//Wowza WebRTC constants
const WEBRTC_CONSTRAINTS = { audio: true, video: false };
const ICE_SERVERS = [{ url: 'stun:numb.viagenie.ca' }, {
    url: 'turn:numb.viagenie.ca',
    username: 'shahzad@fms-tech.com',
    credential: 'P@ssw0rdfms'
}];
//const SERVER_URL = ""; //"wss://localhost.streamlock.net/webrtc-session.json"; set it from the hub connection
const WOWZA_APPLICATION_NAME = "webrtc";
//const WOWZA_STREAM_NAME = ""; //"myStream"; set it from the user name 
const WOWZA_SESSION_ID_EMPTY = "[empty]";

const STATUS_OK = 200;
const STATUS_APPLICATION_FAILURE = 500;
const STATUS_ERROR_STARTING_APPLICATION = 501;
const STATUS_ERROR_STREAM_NOT_RUNNING = 502;
const STATUS_STREAMNAME_INUSE = 503;
const STATUS_STREAM_NOT_READY = 504;
const STATUS_ERROR_CREATE_SDP_OFFER = 505;
const STATUS_ERROR_CREATING_RTP_STREAM = 506;
const STATUS_WEBRTC_SESSION_NOT_FOUND = 507;
const STATUS_ERROR_DECODING_SDP_DATA = 508;
const STATUS_ERROR_SESSIONID_NOT_SPECIFIED = 509;

const CODEC_AUDIO_UNKNOWN = -1;
const CODEC_AUDIO_PCM_BE = 0x00;
const CODEC_AUDIO_PCM_SWF = 0x01;
const CODEC_AUDIO_AC3 = 0x01; //TODO steal this slot
const CODEC_AUDIO_MP3 = 0x02;
const CODEC_AUDIO_PCM_LE = 0x03;
const CODEC_AUDIO_NELLYMOSER_16MONO = 0x04;
const CODEC_AUDIO_NELLYMOSER_8MONO = 0x05;
const CODEC_AUDIO_NELLYMOSER = 0x06;
const CODEC_AUDIO_G711_ALAW = 0x07;
const CODEC_AUDIO_G711_MULAW = 0x08;
const CODEC_AUDIO_RESERVED = 0x09;
const CODEC_AUDIO_VORBIS = 0x09; //TODO steal this slot
const CODEC_AUDIO_AAC = 0x0a;
const CODEC_AUDIO_SPEEX = 0x0b;
const CODEC_AUDIO_OPUS = 0x0c;
const CODEC_AUDIO_MP3_8 = 0x0f;

window.RTCPeerConnection = window.RTCPeerConnection || window.mozRTCPeerConnection || window.webkitRTCPeerConnection;
window.RTCIceCandidate = window.RTCIceCandidate || window.mozRTCIceCandidate || window.webkitRTCIceCandidate;
window.RTCSessionDescription = window.RTCSessionDescription || window.mozRTCSessionDescription || window.webkitRTCSessionDescription;

const isDebugging = true;

////var connection = new signalR.HubConnectionBuilder().withUrl("/aspdontnetcoredemo/chathub").build();
var wsconn = new signalR.HubConnectionBuilder().withUrl("/callhub", signalR.HttpTransportType.WebSockets).configureLogging(signalR.LogLevel.None).build();
var connection = new signalR.HubConnectionBuilder().withUrl("/chathub").build();
var peerConnectionConfig = { "iceServers": [{ "url": "stun:stun.l.google.com:19302" }] };
var webrtcConstraints = { audio: true, video: false };
var streamInfo = { applicationName: WOWZA_APPLICATION_NAME, streamName: WOWZA_STREAM_NAME, sessionId: WOWZA_SESSION_ID_EMPTY };
var Callinguserobj;
var WOWZA_STREAM_NAME = null, connections = {}, localStream = null;
$(document).ready(function () {
    //getAll();
    //connection.on("ActiveInactiveUser", function () {
    //    getAll();
    //});
    //connection.on("SendMessageToUser", function () {
    //    getAllMessage();
    //});
    connection.start();

    var userID=$('#hdnUserId').val();
    connection.on("UserConnected", function (connectionId, userID) {
        console.log('my id is :' + connection.connectionId);
        console.log($('#hdnUserId').val());
    });
    
  
    //connectioncall.on("UserConnected", function (connectionId, userID) {
    //    console.log('my id is :' + connectioncall.connectionId);
    //    console.log($('#hdnUserId').val());
    //});
    initializeSignalR();
   // wsconn.start();
    $('.call-hangup').click(function () {
        console.log('hangup....');
        // Only allow hangup if we are not idle
        //localStream.getTracks().forEach(track => track.stop());
        if ($('body').attr("data-mode") !== "idle") {
            wsconn.invoke('hangUp');
            closeAllConnections();
            $('body').attr('data-mode', 'idle');
            $("#callstatus").text('Idle');
        }
        $("#outGoingCall").modal("hide");
    });
    $('.call-pickup').click(function () {
        console.log('Pickup....');
        $("#callpickup").hide();
        // Only allow hangup if we are not idle
        //localStream.getTracks().forEach(track => track.stop());
        wsconn.invoke('AnswerCall', true, Callinguserobj).catch(err => console.log(err));

        // So lets go into call mode on the UI
        $('body').attr('data-mode', 'incall');
        $("#callstatus").text('In Call');
    });
    
});
attachMediaStream = (e) => {
    //console.log(e);
    console.log("OnPage: called attachMediaStream");
    var partnerAudio = document.querySelector('.audio.partner');
    if (partnerAudio.srcObject !== e.stream) {
        partnerAudio.srcObject = e.stream;
        console.log("OnPage: Attached remote stream");
    }
};

const receivedCandidateSignal = (connection, partnerClientId, candidate) => {
    //console.log('candidate', candidate);
    //if (candidate) {
    console.log('WebRTC: adding full candidate');
    connection.addIceCandidate(new RTCIceCandidate(candidate), () => console.log("WebRTC: added candidate successfully"), () => console.log("WebRTC: cannot add candidate"));
    //} else {
    //    console.log('WebRTC: adding null candidate');
    //   connection.addIceCandidate(null, () => console.log("WebRTC: added null candidate successfully"), () => console.log("WebRTC: cannot add null candidate"));
    //}
}

// Process a newly received SDP signal
const receivedSdpSignal = (connection, partnerClientId, sdp) => {
    console.log('connection: ', connection);
    console.log('sdp', sdp);
    console.log('WebRTC: called receivedSdpSignal');
    console.log('WebRTC: processing sdp signal');
    connection.setRemoteDescription(new RTCSessionDescription(sdp), () => {
        console.log('WebRTC: set Remote Description');
        if (connection.remoteDescription.type == "offer") {
            console.log('WebRTC: remote Description type offer');
            connection.addStream(localStream);
            console.log('WebRTC: added stream');
            connection.createAnswer().then((desc) => {
                console.log('WebRTC: create Answer...');
                connection.setLocalDescription(desc, () => {
                    console.log('WebRTC: set Local Description...');
                    console.log('connection.localDescription: ', connection.localDescription);
                    //setTimeout(() => {
                    sendHubSignal(JSON.stringify({ "sdp": connection.localDescription }), partnerClientId);
                    //}, 1000);
                }, errorHandler);
            }, errorHandler);
        } else if (connection.remoteDescription.type == "answer") {
            console.log('WebRTC: remote Description type answer');
        }
    }, errorHandler);
}

// Hand off a new signal from the signaler to the connection
const newSignal = (partnerClientId, data) => {
    console.log('WebRTC: called newSignal');
    //console.log('connections: ', connections);

    var signal = JSON.parse(data);
    var connection = getConnection(partnerClientId);
    //console.log("signal: ", signal);
    //console.log("signal: ", signal.sdp || signal.candidate);
    //console.log("partnerClientId: ", partnerClientId);
    console.log("connection: ", connection);

    // Route signal based on type
    if (signal.sdp) {
        console.log('WebRTC: sdp signal');
        receivedSdpSignal(connection, partnerClientId, signal.sdp);
    } else if (signal.candidate) {
        console.log('WebRTC: candidate signal');
        receivedCandidateSignal(connection, partnerClientId, signal.candidate);
    } else {
        console.log('WebRTC: adding null candidate');
        connection.addIceCandidate(null, () => console.log("WebRTC: added null candidate successfully"), () => console.log("WebRTC: cannot add null candidate"));
    }
}

const onReadyForStream = (connection) => {
    console.log("WebRTC: called onReadyForStream");
    // The connection manager needs our stream
    //console.log("onReadyForStream connection: ", connection);
    connection.addStream(localStream);
    console.log("WebRTC: added stream");
}

const onStreamRemoved = (connection, streamId) => {
    console.log("WebRTC: onStreamRemoved -> Removing stream: ");
    //console.log("Stream: ", streamId);
    //console.log("connection: ", connection);
}
// Close the connection between myself and the given partner
const closeConnection = (partnerClientId) => {
    console.log("WebRTC: called closeConnection ");
    var connection = connections[partnerClientId];

    if (connection) {
        // Let the user know which streams are leaving
        // todo: foreach connection.remoteStreams -> onStreamRemoved(stream.id)
        onStreamRemoved(null, null);

        // Close the connection
        connection.close();
        delete connections[partnerClientId]; // Remove the property
    }
}
// Close all of our connections
const closeAllConnections = () => {
    console.log("WebRTC: call closeAllConnections ");
    for (var connectionId in connections) {
        closeConnection(connectionId);
    }
}

const getConnection = (partnerClientId) => {
    console.log("WebRTC: called getConnection");
    if (connections[partnerClientId]) {
        console.log("WebRTC: connections partner client exist");
        return connections[partnerClientId];
    }
    else {
        console.log("WebRTC: initialize new connection");
        return initializeConnection(partnerClientId)
    }
}

const initiateOffer = (partnerClientId, stream) => {
    console.log('WebRTC: called initiateoffer: ');
    var connection = getConnection(partnerClientId); // // get a connection for the given partner
    //console.log('initiate Offer stream: ', stream);
    //console.log("offer connection: ", connection);
    connection.addStream(stream);// add our audio/video stream
    console.log("WebRTC: Added local stream");

    connection.createOffer().then(offer => {
        console.log('WebRTC: created Offer: ');
        console.log('WebRTC: Description after offer: ', offer);
        connection.setLocalDescription(offer).then(() => {
            console.log('WebRTC: set Local Description: ');
            console.log('connection before sending offer ', connection);
            setTimeout(() => {
                sendHubSignal(JSON.stringify({ "sdp": connection.localDescription }), partnerClientId);
            }, 1000);
        }).catch(err => console.error('WebRTC: Error while setting local description', err));
    }).catch(err => console.error('WebRTC: Error while creating offer', err));

    //connection.createOffer((desc) => { // send an offer for a connection
    //    console.log('WebRTC: created Offer: ');
    //    console.log('WebRTC: Description after offer: ', JSON.stringify(desc));
    //    connection.setLocalDescription(desc, () => {
    //        console.log('WebRTC: Description after setting locally: ', JSON.stringify(desc));
    //        console.log('WebRTC: set Local Description: ');
    //        console.log('connection.localDescription: ', JSON.stringify(connection.localDescription));
    //        sendHubSignal(JSON.stringify({ "sdp": connection.localDescription }), partnerClientId);
    //    });
    //}, errorHandler);
}

const callbackUserMediaSuccess = (stream) => {
    console.log("WebRTC: got media stream");
    localStream = stream;

    const audioTracks = localStream.getAudioTracks();
    if (audioTracks.length > 0) {
        console.log(`Using Audio device: ${audioTracks[0].label}`);
    }
};

const initializeUserMedia = () => {
    console.log('WebRTC: InitializeUserMedia: ');
    navigator.getUserMedia(webrtcConstraints, callbackUserMediaSuccess, errorHandler);
};
// stream removed
const callbackRemoveStream = (connection, evt) => {
    console.log('WebRTC: removing remote stream from partner window');
    // Clear out the partner window
    var otherAudio = document.querySelector('.audio.partner');
    otherAudio.src = '';
}

const callbackAddStream = (connection, evt) => {
    console.log('WebRTC: called callbackAddStream');

    // Bind the remote stream to the partner window
    //var otherVideo = document.querySelector('.video.partner');
    //attachMediaStream(otherVideo, evt.stream); // from adapter.js
    attachMediaStream(evt);
}

const callbackNegotiationNeeded = (connection, evt) => {
    console.log("WebRTC: Negotiation needed...");
    //console.log("Event: ", evt);
}

const callbackIceCandidate = (evt, connection, partnerClientId) => {
    console.log("WebRTC: Ice Candidate callback");
    //console.log("evt.candidate: ", evt.candidate);
    if (evt.candidate) {// Found a new candidate
        console.log('WebRTC: new ICE candidate');
        //console.log("evt.candidate: ", evt.candidate);
        sendHubSignal(JSON.stringify({ "candidate": evt.candidate }), partnerClientId);
    } else {
        // Null candidate means we are done collecting candidates.
        console.log('WebRTC: ICE candidate gathering complete');
        sendHubSignal(JSON.stringify({ "candidate": null }), partnerClientId);
    }
}

const initializeConnection = (partnerClientId) => {
    console.log('WebRTC: Initializing connection...');
    //console.log("Received Param for connection: ", partnerClientId);

    var connection = new RTCPeerConnection(peerConnectionConfig);

    //connection.iceConnectionState = evt => console.log("WebRTC: iceConnectionState", evt); //not triggering on edge
    //connection.iceGatheringState = evt => console.log("WebRTC: iceGatheringState", evt); //not triggering on edge
    //connection.ondatachannel = evt => console.log("WebRTC: ondatachannel", evt); //not triggering on edge
    //connection.oniceconnectionstatechange = evt => console.log("WebRTC: oniceconnectionstatechange", evt); //triggering on state change 
    //connection.onicegatheringstatechange = evt => console.log("WebRTC: onicegatheringstatechange", evt); //triggering on state change 
    //connection.onsignalingstatechange = evt => console.log("WebRTC: onsignalingstatechange", evt); //triggering on state change 
    //connection.ontrack = evt => console.log("WebRTC: ontrack", evt);
    connection.onicecandidate = evt => callbackIceCandidate(evt, connection, partnerClientId); // ICE Candidate Callback
    //connection.onnegotiationneeded = evt => callbackNegotiationNeeded(connection, evt); // Negotiation Needed Callback
    connection.onaddstream = evt => callbackAddStream(connection, evt); // Add stream handler callback
    connection.onremovestream = evt => callbackRemoveStream(connection, evt); // Remove stream handler callback

    connections[partnerClientId] = connection; // Store away the connection based on username
    //console.log(connection);
    return connection;
}

sendHubSignal = (candidate, partnerClientId) => {
    console.log('candidate', candidate);
    console.log('SignalR: called sendhubsignal ');
    wsconn.invoke('sendSignal', candidate, partnerClientId).catch(errorHandler);
};

wsconn.onclose(e => {
    if (e) {
        console.log("SignalR: closed with error.");
        console.log(e);
    }
    else {
        console.log("Disconnected");
    }
});

// Hub Callback: Update User List
wsconn.on('updateUserList', (userList) => {
    consoleLogger('SignalR: called updateUserList' + JSON.stringify(userList));
   // $("#usersLength").text(userList.length);
  //  $('#usersdata li.user').remove();

    
    setTimeout(function () {
             $.each(userList, function (indexu) {
             var userIcon = '', status = '';
             $(".conversation__details").each(function (index, value) {
                 if (userList[indexu].username == $(this).attr('data-username')) {
                     $(this).attr('data-cid', userList[indexu].connectionId)
                 }
             });
        }, 1000);
    });
});

// Hub Callback: Call Accepted
wsconn.on('callAccepted', (acceptingUser) => {
    console.log('SignalR: call accepted from: ' + JSON.stringify(acceptingUser) + '.  Initiating WebRTC call and offering my stream up...');
   
    // Callee accepted our call, let's send them an offer with our video stream
    initiateOffer(acceptingUser.connectionId, localStream); // Will use driver email in production
    // Set UI into call mode
    $('body').attr('data-mode', 'incall');
    $("#callstatus").text('In Call');
});

// Hub Callback: Call Declined
wsconn.on('callDeclined', (decliningUser, reason) => {
    console.log('SignalR: call declined from: ' + decliningUser.connectionId);

    // Let the user know that the callee declined to talk
    window.alert(reason);
    $("#outGoingCall").modal("hide");
    // Back to an idle UI
    $('body').attr('data-mode', 'idle');
});

// Hub Callback: Incoming Call
wsconn.on('incomingCall', (callingUser) => {
    console.log('SignalR: incoming call from: ' + JSON.stringify(callingUser));
    $("#outGoingCall").modal("show");
    var chatusername = '';
    Callinguserobj = callingUser;
    $(".conversation__details").each(function (index, value) {
        if (callingUser.username == $(this).attr('data-username')) {
            chatusername = $(this).find("div[class='conversation__name--title']").text();
        }
    });
    $("#callpesronname").text(chatusername);
});

// Hub Callback: WebRTC Signal Received
wsconn.on('receiveSignal', (signalingUser, signal) => {
    //console.log('WebRTC: receive signal ');
    //console.log(signalingUser);
    //console.log('NewSignal', signal);
    newSignal(signalingUser.connectionId, signal);
});

// Hub Callback: Call Ended
wsconn.on('callEnded', (signalingUser, signal) => {
    //console.log(signalingUser);
    //console.log(signal);
    
    console.log('SignalR: call with ' + signalingUser.connectionId + ' has ended: ' + signal);

    // Let the user know why the server says the call is over
    //window.alert(signal);
    $("#outGoingCall").modal("hide");
    // Close the WebRTC connection
    closeConnection(signalingUser.connectionId);

    // Set the UI back into idle mode
    $('body').attr('data-mode', 'idle');
    $("#callstatus").text('Idle');
});

const initializeSignalR = () => {
    wsconn.start();//.then(() => { console.log("SignalR: Connected"); askUsername(); }).catch(err => console.log(err));
    initializeUserMedia();
};

const setUsername = (username) => {
    consoleLogger('SingnalR: setting username...');
    wsconn.invoke("Join", username).catch((err) => {
        consoleLogger(err);
        window.alert('<h4>Failed SignalR Connection</h4> We were not able to connect you to the signaling server.<br/><br/>Error: ' + JSON.stringify(err));
        //viewModel.Loading(false);
    });
    //WOWZA_STREAM_NAME = username;
    $("#upperUsername").text(username);
    $('div.username').text(username);
    initializeUserMedia();
};

const askUsername = () => {
    consoleLogger('SignalR: Asking username...');
    window.prompt('Select a username', 'What is your name?', '', (evt, Username) => {
        if (Username !== '')
            setUsername(Username);
        else
            generateRandomUsername();

    }, () => {
        generateRandomUsername();
    });
};

const generateRandomUsername = () => {
    consoleLogger('SignalR: Generating random username...');
    let username = 'User ' + Math.floor((Math.random() * 10000) + 1);
    window.alert('You really need a username, so we will call you... ' + username);
    setUsername(username);
};

const errorHandler = (error) => {
    if (error.message)
        window.alert('<h4>Error Occurred</h4></br>Error Info: ' + JSON.stringify(error.message));
    else
        window.alert('<h4>Error Occurred</h4></br>Error Info: ' + JSON.stringify(error));

    consoleLogger(error);
};

const consoleLogger = (val) => {
    if (isDebugging) {
        console.log(val);
    }
};
//$(document).ready(function () {
//    var connection = new signalR.HubConnectionBuilder().withUrl("/chatHub").build();

//    connection.start().then(function () {
//        console.log('SignalR Started...')
//        //viewModel.roomList();
//        viewModel.userList();
//    }).catch(function (err) {
//        return console.error(err);
//    });

//    connection.on("newMessage", function (messageView) {
//        var isMine = messageView.from === viewModel.myName();
//        var message = new ChatMessage(messageView.content, messageView.timestamp, messageView.from, isMine, messageView.avatar);
//        viewModel.chatMessages.push(message);
//        $(".chat-body").animate({ scrollTop: $(".chat-body")[0].scrollHeight }, 1000);
//    });

//    connection.on("getProfileInfo", function (displayName, avatar) {
//        viewModel.myName(displayName);
//        viewModel.myAvatar(avatar);
//        viewModel.isLoading(false);
//    });

//    connection.on("addUser", function (user) {
//        viewModel.userAdded(new ChatUser(user.username, user.fullName, user.avatar, "CurrentRoom", user.device));
//    });

//    connection.on("removeUser", function (user) {
//        viewModel.userRemoved(user.username);
//    });

//    connection.on("addChatRoom", function (room) {
//        viewModel.roomAdded(new ChatRoom(1, "CurrentRoom"));
//    });

//    connection.on("updateChatRoom", function (room) {
//        viewModel.roomUpdated(new ChatRoom(1, "CurrentRoom"));
//    });

//    connection.on("removeChatRoom", function (id) {
//        viewModel.roomDeleted(1);
//    });

//    connection.on("onError", function (message) {
//        viewModel.serverInfoMessage(message);
//        $("#errorAlert").removeClass("d-none").show().delay(5000).fadeOut(500);
//    });

//    connection.on("onRoomDeleted", function (message) {
//        viewModel.serverInfoMessage(message);
//        $("#errorAlert").removeClass("d-none").show().delay(5000).fadeOut(500);

//        if (viewModel.chatRooms().length == 0) {
//            viewModel.joinedRoom("");
//        }
//        else {
//            // Join to the first room in list
//            setTimeout(function () {
//                $("ul#room-list li a")[0].click();
//            }, 50);
//        }
//    });

//    function AppViewModel() {
//        var self = this;

//        self.message = ko.observable("");
//        self.chatRooms = ko.observableArray([]);
//        self.chatUsers = ko.observableArray([]);
//        self.chatMessages = ko.observableArray([]);
//        self.joinedRoom = ko.observable("");
//        self.joinedRoomId = ko.observable("");
//        self.serverInfoMessage = ko.observable("");
//        self.myName = ko.observable("");
//        self.myAvatar = ko.observable("avatar1.png");
//        self.isLoading = ko.observable(true);

//        self.onEnter = function (d, e) {
//            if (e.keyCode === 13) {
//                self.sendNewMessage();
//            }
//            return true;
//        }
//        self.filter = ko.observable("");
//        self.filteredChatUsers = ko.computed(function () {
//            if (!self.filter()) {
//                return self.chatUsers();
//            } else {
//                return ko.utils.arrayFilter(self.chatUsers(), function (user) {
//                    var displayName = user.displayName().toLowerCase();
//                    return displayName.includes(self.filter().toLowerCase());
//                });
//            }
//        });

//        self.sendNewMessage = function () {
//            var text = self.message();
//            if (text.startsWith("/")) {
//                var receiver = text.substring(text.indexOf("(") + 1, text.indexOf(")"));
//                var message = text.substring(text.indexOf(")") + 1, text.length);
//                self.sendPrivate(receiver, message);
//            }
//            else {
//                self.sendToRoom("CurrentRoom", self.message());
//            }

//            self.message("");
//        }

//        self.sendToRoom = function (roomName, message) {
//            if (roomName.length > 0 && message.length > 0) {
//                fetch('/api/Messages', {
//                    method: 'POST',
//                    headers: { 'Content-Type': 'application/json' },
//                    body: JSON.stringify({ room: roomName, content: message })
//                });
//            }
//        }

//        self.sendPrivate = function (receiver, message) {
//            if (receiver.length > 0 && message.length > 0) {
//                connection.invoke("SendPrivate", receiver.trim(), message.trim());
//            }
//        }

//        self.joinRoom = function (room) {
//            connection.invoke("Join", room.name()).then(function () {
//                self.joinedRoom(room.name());
//                self.joinedRoomId(room.id());
//                self.userList();
//                self.messageHistory();
//            });
//        }

//        //self.roomList = function () {
//        //    fetch('/api/Rooms')
//        //        .then(response => response.json())
//        //        .then(data => {
//        //            self.chatRooms.removeAll();
//        //            for (var i = 0; i < data.length; i++) {
//        //                self.chatRooms.push(new ChatRoom(data[i].id, data[i].name));
//        //            }

//        //            if (self.chatRooms().length > 0)
//        //                self.joinRoom(self.chatRooms()[0]);
//        //        });
//        //}

//        self.userList = function () {
//            connection.invoke("GetUsers", self.joinedRoom()).then(function (result) {
//                self.chatUsers.removeAll();
//                for (var i = 0; i < result.length; i++) {
//                    self.chatUsers.push(new ChatUser(result[i].userName,
//                        "CurrentRoom",
//                        result[i].device))
//                }
//            });
//        }

//        //self.createRoom = function () {
//        //    var roomName = "CurrentRoom";//$("#roomName").val();
//        //    fetch('/api/Rooms', {
//        //        method: 'POST',
//        //        headers: { 'Content-Type': 'application/json' },
//        //        body: JSON.stringify({ name: roomName })
//        //    });
//        //}

//        //self.editRoom = function () {
//        //    var roomId = self.joinedRoomId();
//        //    var roomName = "CurrentRoom";//$("#newRoomName").val();
//        //    fetch('/api/Rooms/' + roomId, {
//        //        method: 'PUT',
//        //        headers: { 'Content-Type': 'application/json' },
//        //        body: JSON.stringify({ id: roomId, name: roomName })
//        //    });
//        //}

//        //self.deleteRoom = function () {
//        //    fetch('/api/Rooms/' + self.joinedRoomId(), {
//        //        method: 'DELETE',
//        //        headers: { 'Content-Type': 'application/json' },
//        //        body: JSON.stringify({ id: self.joinedRoomId() })
//        //    });
//        //}

//        self.messageHistory = function () {
//            fetch('/api/Messages/Room/' + viewModel.joinedRoom())
//                .then(response => response.json())
//                .then(data => {
//                    self.chatMessages.removeAll();
//                    for (var i = 0; i < data.length; i++) {
//                        var isMine = data[i].from == self.myName();
//                        self.chatMessages.push(new ChatMessage(data[i].content,
//                            data[i].timestamp,
//                            data[i].from,
//                            isMine,
//                            data[i].avatar))
//                    }

//                    $(".chat-body").animate({ scrollTop: $(".chat-body")[0].scrollHeight }, 1000);
//                });
//        }

//        self.roomAdded = function (room) {
//            self.chatRooms.push(room);
//        }

//        self.roomUpdated = function (updatedRoom) {
//            //var room = ko.utils.arrayFirst(self.chatRooms(), function (item) {
//            //    return updatedRoom.id() == item.id();
//            //});

//            //room.name(updatedRoom.name());

//            //if (self.joinedRoomId() == room.id()) {
//                self.joinRoom("CurrentRoom");
//            //}
//        }

//        //self.roomDeleted = function (id) {
//        //    var temp;
//        //    ko.utils.arrayForEach(self.chatRooms(), function (room) {
//        //        if (room.id() == id)
//        //            temp = room;
//        //    });
//        //    self.chatRooms.remove(temp);
//        //}

//        self.userAdded = function (user) {
//            self.chatUsers.push(user);
//        }

//        self.userRemoved = function (id) {
//            var temp;
//            ko.utils.arrayForEach(self.chatUsers(), function (user) {
//                if (user.userName() == id)
//                    temp = user;
//            });
//            self.chatUsers.remove(temp);
//        }

//        //self.uploadFiles = function () {
//        //    var form = document.getElementById("uploadForm");
//        //    $.ajax({
//        //        type: "POST",
//        //        url: '/api/Upload',
//        //        data: new FormData(form),
//        //        contentType: false,
//        //        processData: false,
//        //        success: function () {
//        //            $("#UploadedFile").val("");
//        //        },
//        //        error: function (error) {
//        //            alert('Error: ' + error.responseText);
//        //        }
//        //    });
//        //}
//    }

//    function ChatRoom(id, name) {
//        var self = this;
//        self.id = ko.observable(id);
//        self.name = ko.observable(name);
//    }

//    function ChatUser(userName, displayName, avatar, currentRoom, device) {
//        var self = this;
//        self.userName = ko.observable(userName);
//        self.displayName = ko.observable(displayName);
//        self.avatar = ko.observable(avatar);
//        self.currentRoom = ko.observable(currentRoom);
//        self.device = ko.observable(device);
//    }

//    function ChatMessage(content, timestamp, from, isMine, avatar) {
//        var self = this;
//        self.content = ko.observable(content);
//        self.timestamp = ko.observable(timestamp);
//        self.from = ko.observable(from);
//        self.isMine = ko.observable(isMine);
//        self.avatar = ko.observable(avatar);
//    }

//    var viewModel = new AppViewModel();
//    ko.applyBindings(viewModel);
//});
