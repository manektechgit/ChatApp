@inject IHttpContextAccessor HttpContextAccessor
@model DotNetCoreMVCDemos.Models.GroupCreate
@using Microsoft.AspNetCore.Http;
@{
    ViewBag.Title = "ChatHome";
}
@{
    var UserId = @HttpContextAccessor.HttpContext.Session.GetString("UserId");
}
<link rel="stylesheet" href="~/lib/fonts/MaterialDesign/css/materialdesignicons.min.css">
<link rel="stylesheet" href="~/lib/vendors/perfect-scrollbar/perfect-scrollbar.css">
<link rel="stylesheet" href="~/lib/vendors/OwlCarousel2/owl.carousel.css">
<link rel="stylesheet" href="~/lib/bootstrap.min.css">
<link rel="stylesheet" href="~/lib/css/app.css">
<link rel="stylesheet" href="~/lib/css/theme/default.css">
<style>

    * {
        margin: 0px;
        padding: 0px
    }

    body {
        background: #2c3e50;
        font-family: 'Open Sans', sans-serif;
    }

    h1, button {
        color: #fff;
        text-align: center;
        padding: 20px;
    }

    p {
        color: #fff;
        text-align: center;
        padding-top: 500px;
        font-size: 10px;
    }

    a {
        text-decoration: none;
        color: #fff;
    }

        a:hover {
            color: #2ecc71;
        }

    .main {
        width: 70%;
    }

    .sub-main {
        width: 30%;
        margin: 22px;
        float: left;
    }

    .button-one, .button-two, .button-three {
        text-align: center;
        cursor: pointer;
        font-size: 15px;
        margin: 0 0 0 100px;
    }



    /*Button One*/
    .button-one {
        padding: 20px 60px;
        outline: none;
        background-color: #27ae60;
        border: none;
        border-radius: 5px;
        box-shadow: 0 9px #95a5a6;
    }

        .button-one:hover {
            background-color: #2ecc71;
        }

        .button-one:active {
            background-color: #2ecc71;
            box-shadow: 0 5px #95a5a6;
            transform: translateY(4px);
        }


    /*Button Two*/
    .button-two {
        border-radius: 4px;
        background-color: #007bff;
        border: none;
        padding: 10px;
        width: 80%;
        transition: all 0.5s;
        margin-left: 143px;
    }


        .button-two span {
            cursor: pointer;
            display: inline-block;
            position: relative;
            transition: 0.5s;
        }

            .button-two span:after {
                content: '»';
                position: absolute;
                opacity: 0;
                top: 0;
                right: -20px;
                transition: 0.5s;
            }

        .button-two:hover span {
            padding-right: 25px;
        }

            .button-two:hover span:after {
                opacity: 1;
                right: 0;
            }


    /*Button Three*/
    .button-three {
        position: relative;
        background-color: #f39c12;
        border: none;
        padding: 20px;
        width: 200px;
        text-align: center;
        -webkit-transition-duration: 0.4s; /* Safari */
        transition-duration: 0.4s;
        text-decoration: none;
        overflow: hidden;
    }

        .button-three:hover {
            background: #fff;
            box-shadow: 0px 2px 10px 5px #97B1BF;
            color: #000;
        }

        .button-three:after {
            content: "";
            background: #f1c40f;
            display: block;
            position: absolute;
            padding-top: 300%;
            padding-left: 350%;
            margin-left: -20px !important;
            margin-top: -120%;
            opacity: 0;
            transition: all 0.8s
        }

        .button-three:active:after {
            padding: 0;
            margin: 0;
            opacity: 1;
            transition: 0s
        }
</style>
<div class="ca-main-conatiner">
    <input type="hidden" id="hdnUserId" value="@UserId" />
    <div class="ca-main-wrapper">
        <div class="ca-sidebar-wrapper">
            <div class="ca-sidebar">
                <div class="ca-sidebar__header">
                    <div class="ca-userprofile" data-toggle="modal" data-target="#viewProfileModal">
                        <a href="javascript:;" target="_self" class="user-avatar user-avatar-rounded">
                            
                            <img src="~/lib/images/user/100/face-01.jpg" alt="">
                            @*<div class="user-avatar user-avatar-rounded avatar-info">
                                    <span>EH</span>
                                </div>*@
                        </a>
                    </div>
                    <div class="iconbox-group">

                        <div class="iconbox iconbox-search btn-hovered-light">
                            <i class="iconbox__icon mdi mdi-magnify"></i>
                        </div>

                        <div class="iconbox btn-hovered-light">
                            <i class="iconbox__icon mdi mdi-bell-outline"></i>
                        </div>

                        <div class="iconbox-dropdown dropdown">
                            <div class="iconbox btn-hovered-light" role="button" id="dropdownMenuLink" data-toggle="dropdown" aria-haspopup="true" aria-expanded="false">
                                <i class="iconbox__icon mdi mdi-dots-horizontal"></i>
                            </div>
                            <div class="dropdown-menu dropdown-menu-right" aria-labelledby="dropdownMenuLink">
                                <a class="dropdown-item" href="javascript:;">
                                    <span><i class="mdi mdi-star-outline"></i></span>
                                    <span>Starred Messages</span>
                                </a>
                                <a class="dropdown-item" href="javascript:;" data-toggle="modal" data-target="#invitePeopleModal">
                                    <span><i class="mdi mdi-account-multiple-plus-outline"></i></span>
                                    <span>Invite People</span>
                                </a>

                                <a class="dropdown-item" href="javascript:;" data-toggle="modal" data-target="#settingsModalCenter">
                                    <span><i class="mdi mdi-settings-outline"></i></span>
                                    <span>Settings</span>
                                </a>


                                <a class="dropdown-item" href="javascript:;">
                                    <span><i class="mdi mdi-help-circle-outline"></i></span>
                                    <span>Help</span>
                                </a>
                                <a class="dropdown-item" href="javascript:;">
                                    <span><i class="mdi mdi-comment-quote-outline"></i></span>
                                    <span>Feedback</span>
                                </a>
                                <a class="dropdown-item" href="javascript:;">
                                    <span><i class="mdi mdi-information-outline"></i></span>
                                    <span>About us</span>
                                </a>
                            </div>
                        </div>

                        <div>
                            @*<div class="iconbox btn-hovered-light" role="button" id="dropdownMenuLink" data-toggle="dropdown" aria-haspopup="true" aria-expanded="false">
                                    <i class="iconbox__icon mdi mdi-dots-horizontal"></i>
                                </div>*@
                            <a href="@Url.Action("Logout","Authentication")">
                                <i class="iconbox__icon mdi mdi-logout"></i>
                            </a>
                        </div>
                    </div>

                    <div class="iconbox-searchbar">
                        <form>
                            <input type="text" class="form-control" id="userSearch" placeholder="Search here..." autofocus>

                            <button class="search-submit" type="submit">
                                <i class="mdi mdi-magnify"></i>
                            </button>
                            <a href="javascript:void(0)" class="search-close">
                                <i class="mdi mdi-arrow-left"></i>
                            </a>
                        </form>
                    </div>

                </div>

                <div class="ca-sidebar__body">
                    <div class="ca-navigation-tabs">
                        <div class="nav-style-1">
                            <ul class="nav" id="caMainTab" role="tablist">
                                <li class="nav-item">
                                    <a class="nav-link active" id="caChatsTab" data-toggle="pill" href="#caChats" role="tab" aria-controls="caChats" aria-selected="true">
                                        <span class="mdi mdi-message-text"></span>
                                        <span>Chats</span>
                                    </a>
                                </li>
                                <li class="nav-item">
                                    <a class="nav-link" id="caCallsTab" data-toggle="pill" href="#caCalls" role="tab" aria-controls="caCalls" aria-selected="false">
                                        <span class="mdi mdi-phone"></span>
                                        <span>Calls</span>
                                    </a>
                                </li>
                                <li class="nav-item">
                                    <a class="nav-link" id="caContactsTab" data-toggle="pill" href="#caContacts" role="tab" aria-controls="caContacts" aria-selected="false">
                                        <span class="mdi mdi-account-box-outline"></span>
                                        <span>Contacts</span>
                                    </a>
                                </li>
                            </ul>

                            <div class="tab-content" id="caMainTabContent">

                                <div class="tab-pane fade show active" id="caChats" role="tabpanel" aria-labelledby="caChatsTab">
                                    <div class="nav-style-2">
                                        <ul class="nav nav-pills py-3" id="caChatsTabInside" role="tablist">
                                            <li class="nav-item">
                                                <a class="nav-link d-flex flex-row align-items-center active" id="personal-chat-tab" data-toggle="pill" href="@Url.Action("PersonalChat","Chat",new {UserId=@UserId })" role="tab" aria-controls="personal-chat" aria-selected="true">
                                                    @*<a class="nav-link d-flex flex-row align-items-center active" id="personal-chat-tab" data-toggle="pill" href="#personal-chat" role="tab" aria-controls="personal-chat" aria-selected="true">*@
                                                    <span>Personal</span>
                                                    @*<span class="badge badge-primary badge-rounded badge-font-size ml-2">2</span>*@
                                                </a>
                                                <a data-ajax="true" data-ajax-method="GET" data-ajax-mode="replace" data-ajax-update="#caChatsTabInsideContent" href="@Url.Action("PersonalChat","Chat",new {UserId=@UserId })" id="personal" style="display:none">Personal</a>

                                                @*@Html.ActionLink("Personal", "PersonalChat", "Chat", new { UserId = UserId }, new AjaxOptions { InsertionMode = InsertionMode.Replace, UpdateTargetId = "caChatsTabInsideContent", HttpMethod = "GET" }, new { @id = "personal", @style = "display:none" })*@
                                            </li>
                                            <li class="nav-item">
                                                <a class="nav-link  d-flex flex-row align-items-center" id="groups-chat-tab" data-toggle="pill" href="@Url.Action("GroupChat","Chat",new {UserId=@UserId })" role="tab" aria-controls="groups-chat" aria-selected="false">
                                                    <span>Groups</span>
                                                </a>
                                                <a data-ajax="true" data-ajax-method="GET" data-ajax-mode="replace" data-ajax-update="#caChatsTabInsideContent" href="@Url.Action("GroupChat","Chat",new {UserId=@UserId })" id="group" style="display:none">Personal</a>
                                            </li>
                                        </ul>

                                        <div id="caChatsTabInsideContent" class="tab-content">
                                            @*@Html.Partial("_PersonalChat")*@
                                            @Html.RenderAction("PersonalChat", "Chat", new { UserId = UserId, UserName = "" });
                                            @*@Html.RenderAction("GroupChat", "Chat", new { UserId = UserId, GroupName = "" });*@

                                            @*@Html.RenderPartial("_PersonalChat",new { UserId=UserId},"Chat")*@
                                            @*@await Component.InvokeAsync("_PersonalChat", new { UserId = UserId })*@
                                        </div>

                                    </div>
                                </div>

                                <div class="tab-pane fade" id="caCalls" role="tabpanel" aria-labelledby="caCallsTab">
                                    <div class="nav-style-2">
                                        <ul class="nav nav-pills my-3" id="caCallsTabInside" role="tablist">
                                            <li class="nav-item">
                                                <a class="nav-link active" id="all-calls-tab" data-toggle="pill" href="#all-calls" role="tab" aria-controls="all-calls" aria-selected="true">All</a>
                                            </li>
                                            <li class="nav-item">
                                                <a class="nav-link" id="missed-calls-tab" data-toggle="pill" href="#missed-calls" role="tab" aria-controls="missed-calls" aria-selected="false">Missed</a>
                                            </li>
                                        </ul>
                                        <div class="tab-content" id="caCallsTabInsideContent">
                                            <div class="tab-pane fade show active" id="all-calls" role="tabpanel" aria-labelledby="all-calls-tab">
                                                <div class="sidebar-userlist">
                                                    <ul class="list-unstyled userSearchList">
                                                        <li>
                                                            <div class="calllist">
                                                                <div class="user-avatar user-avatar-rounded online">
                                                                    <img src="~/lib/images/user/250/01.jpg" alt="">
                                                                </div>
                                                                <div class="calllist__details">
                                                                    <div class="calllist__details--name">Jack P. Angulo</div>
                                                                    <div class="calllist__details--info">
                                                                        <span><i class="mdi mdi-call-made"></i></span>
                                                                        <span>Today at 10:02AM</span>
                                                                    </div>
                                                                </div>

                                                                <div class="calllist__actions">
                                                                    <div class="iconbox btn-hovered-light">
                                                                        <i class="iconbox__icon mdi mdi-phone"></i>
                                                                    </div>
                                                                </div>
                                                            </div>
                                                        </li>
                                                        <li>
                                                            <div class="calllist active">
                                                                <div class="user-avatar user-avatar-rounded online">
                                                                    <img src="~/lib/images/user/250/02.jpg" alt="">
                                                                </div>
                                                                <div class="calllist__details">
                                                                    <div class="calllist__details--name">Earnest Clements</div>
                                                                    <div class="calllist__details--info">
                                                                        <span><i class="mdi mdi-call-received"></i></span>
                                                                        <span>Today at 07:25AM</span>
                                                                    </div>
                                                                </div>
                                                                <div class="calllist__actions">
                                                                    <div class="iconbox btn-hovered-light">
                                                                        <i class="iconbox__icon mdi mdi-video-outline"></i>
                                                                    </div>
                                                                </div>
                                                            </div>
                                                        </li>
                                                        <li>
                                                            <div class="calllist">
                                                                <div class="user-avatar user-avatar-rounded online">
                                                                    <img src="~/lib/images/user/250/03.jpg" alt="">
                                                                </div>
                                                                <div class="calllist__details">
                                                                    <div class="calllist__details--name">Willie McLaughlin</div>
                                                                    <div class="calllist__details--info text-danger">
                                                                        <span><i class="mdi mdi-call-missed"></i></span>
                                                                        <span>Today at 07:25AM</span>
                                                                    </div>
                                                                </div>
                                                                <div class="calllist__actions">
                                                                    <div class="iconbox btn-hovered-light">
                                                                        <i class="iconbox__icon mdi mdi-video-outline"></i>
                                                                    </div>
                                                                </div>
                                                            </div>
                                                        </li>
                                                        <li>
                                                            <div class="calllist">
                                                                <div class="user-avatar user-avatar-rounded online">
                                                                    <img src="~/lib/images/user/250/04.jpg" alt="">
                                                                </div>
                                                                <div class="calllist__details">
                                                                    <div class="calllist__details--name">Andrew Showalter</div>
                                                                    <div class="calllist__details--info text-danger">
                                                                        <span><i class="mdi mdi-call-missed"></i></span>
                                                                        <span>Today at 07:25AM</span>
                                                                    </div>
                                                                </div>
                                                                <div class="calllist__actions">
                                                                    <div class="iconbox btn-hovered-light">
                                                                        <i class="iconbox__icon mdi mdi-phone"></i>
                                                                    </div>
                                                                </div>
                                                            </div>
                                                        </li>
                                                        <li>
                                                            <div class="calllist">
                                                                <div class="user-avatar user-avatar-rounded online">
                                                                    <img src="~/lib/images/user/250/05.jpg" alt="">
                                                                </div>
                                                                <div class="calllist__details">
                                                                    <div class="calllist__details--name">Jack P. Angulo</div>
                                                                    <div class="calllist__details--info">
                                                                        <span><i class="mdi mdi-call-made"></i></span>
                                                                        <span>Today at 10:02AM</span>
                                                                    </div>
                                                                </div>

                                                                <div class="calllist__actions">
                                                                    <div class="iconbox btn-hovered-light">
                                                                        <i class="iconbox__icon mdi mdi-phone"></i>
                                                                    </div>
                                                                </div>
                                                            </div>
                                                        </li>
                                                        <li>
                                                            <div class="calllist">
                                                                <div class="user-avatar user-avatar-rounded online">
                                                                    <img src="~/lib/images/user/500/09.jpg" alt="">
                                                                </div>
                                                                <div class="calllist__details">
                                                                    <div class="calllist__details--name">Earnest Clements</div>
                                                                    <div class="calllist__details--info">
                                                                        <span><i class="mdi mdi-call-received"></i></span>
                                                                        <span>Today at 07:25AM</span>
                                                                    </div>
                                                                </div>
                                                                <div class="calllist__actions">
                                                                    <div class="iconbox btn-hovered-light">
                                                                        <i class="iconbox__icon mdi mdi-video-outline"></i>
                                                                    </div>
                                                                </div>
                                                            </div>
                                                        </li>
                                                    </ul>
                                                </div>
                                            </div>
                                            <div class="tab-pane fade" id="missed-calls" role="tabpanel" aria-labelledby="missed-calls-tab">
                                                <div class="sidebar-userlist">
                                                    <ul class="list-unstyled userSearchList">
                                                        <li>
                                                            <div class="calllist active">
                                                                <div class="user-avatar user-avatar-rounded online">
                                                                    <img src="~/lib/images/user/250/03.jpg" alt="">
                                                                </div>
                                                                <div class="calllist__details">
                                                                    <div class="calllist__details--name">Willie McLaughlin</div>
                                                                    <div class="calllist__details--info text-danger">
                                                                        <span><i class="mdi mdi-call-missed"></i></span>
                                                                        <span>Today at 07:25AM</span>
                                                                    </div>
                                                                </div>
                                                                <div class="calllist__actions">
                                                                    <div class="iconbox btn-hovered-light">
                                                                        <i class="iconbox__icon mdi mdi-phone"></i>
                                                                    </div>
                                                                </div>
                                                            </div>
                                                        </li>
                                                        <li>
                                                            <div class="calllist">
                                                                <div class="user-avatar user-avatar-rounded online">
                                                                    <img src="~/lib/images/user/250/04.jpg" alt="">
                                                                </div>
                                                                <div class="calllist__details">
                                                                    <div class="calllist__details--name">Andrew Showalter</div>
                                                                    <div class="calllist__details--info text-danger">
                                                                        <span><i class="mdi mdi-call-missed"></i></span>
                                                                        <span>Today at 07:25AM</span>
                                                                    </div>
                                                                </div>
                                                                <div class="calllist__actions">
                                                                    <div class="iconbox btn-hovered-light">
                                                                        <i class="iconbox__icon mdi mdi-video-outline"></i>
                                                                    </div>
                                                                </div>
                                                            </div>
                                                        </li>
                                                    </ul>
                                                </div>
                                            </div>
                                        </div>
                                    </div>
                                </div>

                                <div class="tab-pane fade position-relative" id="caContacts" role="tabpanel" aria-labelledby="caContactsTab">
                                    <div class="sidebar-contactlist">
                                        <ul class="list-unstyled userSearchList">
                                            <li>
                                                <div class="contactlist-heading">
                                                    <span>Favourite</span>
                                                </div>
                                            </li>
                                            <li>
                                                <div class="contactlist">
                                                    <div class="user-avatar user-avatar-rounded online">
                                                        <img src="~/lib/images/user/250/01.jpg" alt="">
                                                    </div>
                                                    <div class="contactlist__details">
                                                        <div class="contactlist__details--name">Jack P. Angulo</div>
                                                        <div class="calllist__details--info">
                                                            <span><i class="mdi mdi-tag-outline"></i></span>
                                                            <span>Co-Workers</span>
                                                        </div>
                                                    </div>
                                                </div>
                                            </li>
                                            <li>
                                                <div class="contactlist active">
                                                    <div class="user-avatar user-avatar-rounded online">
                                                        <img src="~/lib/images/user/500/09.jpg" alt="">
                                                    </div>
                                                    <div class="contactlist__details">
                                                        <div class="contactlist__details--name">Pearl Villarreal</div>
                                                        <div class="calllist__details--info">
                                                            <span><i class="mdi mdi-tag-outline"></i></span>
                                                            <span>Family members</span>
                                                        </div>
                                                    </div>
                                                </div>
                                            </li>
                                            <li>
                                                <div class="contactlist">
                                                    <div class="user-avatar user-avatar-rounded online">
                                                        <img src="~/lib/images/user/500/04.jpg" alt="">
                                                    </div>
                                                    <div class="contactlist__details">
                                                        <div class="contactlist__details--name">Marguerite E. Hutchings</div>
                                                        <div class="calllist__details--info">
                                                            <span><i class="mdi mdi-tag-outline"></i></span>
                                                            <span>Friends</span>
                                                        </div>
                                                    </div>
                                                </div>
                                            </li>
                                            <li>
                                                <div class="contactlist">
                                                    <div class="user-avatar user-avatar-rounded online">
                                                        <img src="~/lib/images/user/500/06.jpg" alt="">
                                                    </div>
                                                    <div class="contactlist__details">
                                                        <div class="contactlist__details--name">Chuck McCann</div>
                                                        <div class="calllist__details--info">
                                                            <span><i class="mdi mdi-tag-outline"></i></span>
                                                            <span>Friends</span>
                                                        </div>
                                                    </div>
                                                </div>
                                            </li>
                                            <li>
                                                <div class="contactlist-heading">
                                                    <span>A</span>
                                                </div>
                                            </li>
                                            <li>
                                                <div class="contactlist">
                                                    <div class="user-avatar user-avatar-rounded online">
                                                        <img src="~/lib/images/user/250/04.jpg" alt="">
                                                    </div>
                                                    <div class="contactlist__details">
                                                        <div class="contactlist__details--name">Andrew Showalter</div>
                                                        <div class="calllist__details--info">
                                                            <span><i class="mdi mdi-tag-outline"></i></span>
                                                            <span>Co-Workers</span>
                                                        </div>
                                                    </div>
                                                </div>
                                            </li>
                                            <li>
                                                <div class="contactlist">
                                                    <div class="user-avatar user-avatar-rounded online">
                                                        <img src="~/lib/images/user/250/05.jpg" alt="">
                                                    </div>
                                                    <div class="contactlist__details">
                                                        <div class="contactlist__details--name">Amanda Sinquefield</div>
                                                        <div class="calllist__details--info">
                                                            <span><i class="mdi mdi-tag-outline"></i></span>
                                                            <span>Co-Workers</span>
                                                        </div>
                                                    </div>
                                                </div>
                                            </li>
                                            <li>
                                                <div class="contactlist-heading">
                                                    <span>B</span>
                                                </div>
                                            </li>
                                            <li>
                                                <div class="contactlist">
                                                    <div class="user-avatar user-avatar-rounded online">
                                                        <img src="~/lib/images/user/250/04.jpg" alt="">
                                                    </div>
                                                    <div class="contactlist__details">
                                                        <div class="contactlist__details--name">Andrew Showalter</div>
                                                        <div class="calllist__details--info">
                                                            <span><i class="mdi mdi-tag-outline"></i></span>
                                                            <span>Co-Workers</span>
                                                        </div>
                                                    </div>
                                                </div>
                                            </li>
                                            <li>
                                                <div class="contactlist">
                                                    <div class="user-avatar user-avatar-rounded online">
                                                        <img src="~/lib/images/user/250/05.jpg" alt="">
                                                    </div>
                                                    <div class="contactlist__details">
                                                        <div class="contactlist__details--name">Amanda Sinquefield</div>
                                                        <div class="calllist__details--info">
                                                            <span><i class="mdi mdi-tag-outline"></i></span>
                                                            <span>Co-Workers</span>
                                                        </div>
                                                    </div>
                                                </div>
                                            </li>
                                            <li>
                                                <div class="contactlist-heading">
                                                    <span>C</span>
                                                </div>
                                            </li>
                                            <li>
                                                <div class="contactlist">
                                                    <div class="user-avatar user-avatar-rounded online">
                                                        <img src="~/lib/images/user/250/04.jpg" alt="">
                                                    </div>
                                                    <div class="contactlist__details">
                                                        <div class="contactlist__details--name">Andrew Showalter</div>
                                                        <div class="calllist__details--info">
                                                            <span><i class="mdi mdi-tag-outline"></i></span>
                                                            <span>Co-Workers</span>
                                                        </div>
                                                    </div>
                                                </div>
                                            </li>
                                            <li>
                                                <div class="contactlist">
                                                    <div class="user-avatar user-avatar-rounded online">
                                                        <img src="~/lib/images/user/250/05.jpg" alt="">
                                                    </div>
                                                    <div class="contactlist__details">
                                                        <div class="contactlist__details--name">Amanda Sinquefield</div>
                                                        <div class="calllist__details--info">
                                                            <span><i class="mdi mdi-tag-outline"></i></span>
                                                            <span>Co-Workers</span>
                                                        </div>
                                                    </div>
                                                </div>
                                            </li>
                                            <li>
                                                <div class="contactlist-heading">
                                                    <span>E</span>
                                                </div>
                                            </li>
                                            <li>
                                                <div class="contactlist">
                                                    <div class="user-avatar user-avatar-rounded online">
                                                        <img src="~/lib/images/user/250/04.jpg" alt="">
                                                    </div>
                                                    <div class="contactlist__details">
                                                        <div class="contactlist__details--name">Andrew Showalter</div>
                                                        <div class="calllist__details--info">
                                                            <span><i class="mdi mdi-tag-outline"></i></span>
                                                            <span>Co-Workers</span>
                                                        </div>
                                                    </div>
                                                </div>
                                            </li>
                                            <li>
                                                <div class="contactlist">
                                                    <div class="user-avatar user-avatar-rounded online">
                                                        <img src="~/lib/images/user/250/05.jpg" alt="">
                                                    </div>
                                                    <div class="contactlist__details">
                                                        <div class="contactlist__details--name">Amanda Sinquefield</div>
                                                        <div class="calllist__details--info">
                                                            <span><i class="mdi mdi-tag-outline"></i></span>
                                                            <span>Co-Workers</span>
                                                        </div>
                                                    </div>
                                                </div>
                                            </li>
                                            <li>
                                                <div class="contactlist-heading">
                                                    <span>M</span>
                                                </div>
                                            </li>
                                            <li>
                                                <div class="contactlist">
                                                    <div class="user-avatar user-avatar-rounded online">
                                                        <img src="~/lib/images/user/250/04.jpg" alt="">
                                                    </div>
                                                    <div class="contactlist__details">
                                                        <div class="contactlist__details--name">Andrew Showalter</div>
                                                        <div class="calllist__details--info">
                                                            <span><i class="mdi mdi-tag-outline"></i></span>
                                                            <span>Co-Workers</span>
                                                        </div>
                                                    </div>
                                                </div>
                                            </li>
                                            <li>
                                                <div class="contactlist">
                                                    <div class="user-avatar user-avatar-rounded online">
                                                        <img src="~/lib/images/user/250/05.jpg" alt="">
                                                    </div>
                                                    <div class="contactlist__details">
                                                        <div class="contactlist__details--name">Amanda Sinquefield</div>
                                                        <div class="calllist__details--info">
                                                            <span><i class="mdi mdi-tag-outline"></i></span>
                                                            <span>Co-Workers</span>
                                                        </div>
                                                    </div>
                                                </div>
                                            </li>
                                            <li>
                                                <div class="contactlist-heading">
                                                    <span>S</span>
                                                </div>
                                            </li>
                                            <li>
                                                <div class="contactlist">
                                                    <div class="user-avatar user-avatar-rounded online">
                                                        <img src="~/lib/images/user/250/04.jpg" alt="">
                                                    </div>
                                                    <div class="contactlist__details">
                                                        <div class="contactlist__details--name">Andrew Showalter</div>
                                                        <div class="calllist__details--info">
                                                            <span><i class="mdi mdi-tag-outline"></i></span>
                                                            <span>Co-Workers</span>
                                                        </div>
                                                    </div>
                                                </div>
                                            </li>
                                            <li>
                                                <div class="contactlist">
                                                    <div class="user-avatar user-avatar-rounded online">
                                                        <img src="~/lib/images/user/250/05.jpg" alt="">
                                                    </div>
                                                    <div class="contactlist__details">
                                                        <div class="contactlist__details--name">Amanda Sinquefield</div>
                                                        <div class="calllist__details--info">
                                                            <span><i class="mdi mdi-tag-outline"></i></span>
                                                            <span>Co-Workers</span>
                                                        </div>
                                                    </div>
                                                </div>
                                            </li>
                                            <li>
                                                <div class="contactlist-heading">
                                                    <span>#</span>
                                                </div>
                                            </li>
                                            <li>
                                                <div class="contactlist">
                                                    <div class="user-avatar user-avatar-rounded online">
                                                        <img src="~/lib/images/user/250/04.jpg" alt="">
                                                    </div>
                                                    <div class="contactlist__details">
                                                        <div class="contactlist__details--name">&#9829; My Love &#9829;</div>
                                                    </div>
                                                </div>
                                            </li>
                                            <li>
                                                <div class="contactlist">
                                                    <div class="user-avatar user-avatar-rounded online">
                                                        <img src="~/lib/images/user/250/05.jpg" alt="">
                                                    </div>
                                                    <div class="contactlist__details">
                                                        <div class="contactlist__details--name">&#126; Eva 	&#126;</div>
                                                        <div class="calllist__details--info">
                                                            <span><i class="mdi mdi-tag-outline"></i></span>
                                                            <span>Co-Workers</span>
                                                        </div>
                                                    </div>
                                                </div>
                                            </li>
                                        </ul>
                                    </div>
                                    <div class="alphabet-series">
                                        <span><i class="mdi mdi-star"></i></span>
                                        <span>A</span>
                                        <span>B</span>
                                        <span>D</span>
                                        <span>E</span>
                                        <span>F</span>
                                        <span>G</span>
                                        <span>H</span>
                                        <span>I</span>
                                        <span>J</span>
                                        <span>K</span>
                                        <span>L</span>
                                        <span>M</span>
                                        <span>N</span>
                                        <span>O</span>
                                        <span>P</span>
                                        <span>Q</span>
                                        <span>R</span>
                                        <span>S</span>
                                        <span>T</span>
                                        <span>U</span>
                                        <span>V</span>
                                        <span>W</span>
                                        <span>X</span>
                                        <span>Y</span>
                                        <span>Z</span>
                                        <span>#</span>
                                    </div>
                                </div>
                            </div>
                        </div>

                        <ul id="mfbMenu" class="mfb-component--br mfb-slidein" data-mfb-toggle="click">
                            <li class="mfb-component__wrap">
                                <a href="#" class="mfb-component__button--main">
                                    <i class="mfb-component__main-icon--resting mdi mdi-plus ion-plus-round"></i>
                                    <i class="mfb-component__main-icon--active mdi mdi-close ion-close-round"></i>
                                </a>
                                <ul class="mfb-component__list">
                                    <li>
                                        <a href="javascript:;" data-toggle="modal" data-target="#themeModal" data-mfb-label="Theme" class="mfb-component__button--child">
                                            <i class="mfb-component__child-icon mdi mdi-palette"></i>
                                        </a>
                                    </li>
                                    <li>
                                        <a href="javascript:;" data-toggle="modal" data-target="#newGroupModal" data-mfb-label="Create Group" class="mfb-component__button--child">
                                            <i class="mfb-component__child-icon mdi mdi-account-group"></i>
                                        </a>
                                    </li>

                                    <li>
                                        <a href="javascript:;" data-toggle="modal" data-target="#newCallModal" data-mfb-label="New Call" class="mfb-component__button--child">
                                            <i class="mfb-component__child-icon mdi mdi-phone"></i>
                                        </a>
                                    </li>

                                    <li>
                                        <a href="javascript:;" data-toggle="modal" data-target="#newMsgModal" data-mfb-label="New Chat" class="mfb-component__button--child">
                                            <i class="mfb-component__child-icon mdi mdi-android-messages"></i>
                                        </a>
                                    </li>
                                </ul>
                            </li>
                        </ul>
                    </div>
                </div>
            </div>
        </div>
        <div id="rdrConversationId" class="ca-content-wrapper">
            @*@{
                    Html.RenderAction("PersonalChat", "Chat", new { UserId = Session["UserId"], UserName = "" });
                }*@
        </div>

        <!-- Settings Modal -->
        <div class="modal settings-modal-dialog" id="settingsModalCenter" tabindex="-1" role="dialog" aria-labelledby="settingsModalCenterTitle" aria-hidden="true">
            <div class="modal-dialog modal-dialog-centered modal-lg" role="document">
                <div class="modal-content">
                    <div class="modal-header">
                        <h5 class="modal-title" id="settingsModalCenterTitle">Settings</h5>
                        <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                            <span aria-hidden="true">&times;</span>
                        </button>
                    </div>
                    <div class="modal-body p-0">
                        <div class="nav-style-vertical-1">
                            <div class="container-fluid p-0">
                                <div class="row">
                                    <div class="col-4 settings-nav-menu">
                                        <div class="nav flex-column nav-pills" id="v-pills-tab" role="tablist" aria-orientation="vertical">
                                            <a class="nav-link active" id="v-pills-privacy-tab" data-toggle="pill" href="#v-pills-privacy" role="tab" aria-controls="v-pills-privacy" aria-selected="true">
                                                <div class="settingmenu">
                                                    <div class="settingmenu__icon"><i class="mdi mdi-shield-lock-outline"></i></div>
                                                    <div class="settingmenu__name">Privacy & Security</div>
                                                </div>
                                            </a>
                                            <a class="nav-link" id="v-pills-notifications-tab" data-toggle="pill" href="#v-pills-notifications" role="tab" aria-controls="v-pills-notifications" aria-selected="false">
                                                <div class="settingmenu">
                                                    <div class="settingmenu__icon"><i class="mdi mdi-bell-ring-outline"></i></div>
                                                    <div class="settingmenu__name">Notifications</div>
                                                </div>
                                            </a>
                                            <a class="nav-link" id="v-pills-theme-tab" data-toggle="pill" href="#v-pills-theme" role="tab" aria-controls="v-pills-theme" aria-selected="false">
                                                <div class="settingmenu">
                                                    <div class="settingmenu__icon"><i class="mdi mdi-palette-outline"></i></div>
                                                    <div class="settingmenu__name">Theme</div>
                                                </div>
                                            </a>
                                            <a class="nav-link" id="v-pills-audiovideo-tab" data-toggle="pill" href="#v-pills-audiovideo" role="tab" aria-controls="v-pills-audiovideo" aria-selected="false">
                                                <div class="settingmenu">
                                                    <div class="settingmenu__icon"><i class="mdi mdi-video-wireless-outline"></i></div>
                                                    <div class="settingmenu__name">Audio & Video</div>
                                                </div>
                                            </a>
                                            <a class="nav-link" id="v-pills-media-tab" data-toggle="pill" href="#v-pills-media" role="tab" aria-controls="v-pills-media" aria-selected="false">
                                                <div class="settingmenu">
                                                    <div class="settingmenu__icon"><i class="mdi mdi-message-settings-variant-outline"></i></div>
                                                    <div class="settingmenu__name">Media</div>
                                                </div>
                                            </a>
                                        </div>
                                    </div>
                                    <div class="col-8 settings-nav-content">
                                        <div class="tab-content" id="v-pills-tabContent">
                                            <div class="tab-pane fade show active" id="v-pills-privacy" role="tabpanel" aria-labelledby="v-pills-privacy-tab">
                                                <div class="accordion settings-accordion accordion-arrow-toggler accordion-ungrouped" id="privacySecurity">
                                                    <div class="card">
                                                        <div class="card-header" id="privacySecurityHead1">
                                                            <div class="card-title" data-toggle="collapse" role="button" data-target="#privacySecurity1" aria-expanded="true" aria-controls="privacySecurity1">
                                                                Privacy
                                                            </div>
                                                        </div>

                                                        <div id="privacySecurity1" class="collapse show" aria-labelledby="headingOne" data-parent="#privacySecurity">
                                                            <div class="card-body">
                                                                <div class="setting-sunheading">who can see my personal details</div>

                                                                <ul class="list-unstyled ca-setting-list">
                                                                    <li>
                                                                        <div class="ca-setting-type">
                                                                            <div class="ca-setting-name">
                                                                                <div class="ca-setting-name-main">Profile Picture</div>
                                                                                <div class="ca-setting-name-sub">Select who can see your profile picture</div>
                                                                            </div>
                                                                            <div class="ca-setting-action">
                                                                                <div class="dropdown">
                                                                                    <a class="btn btn-link dropdown-toggle" href="#" role="button" id="SettingsDropdown1" data-toggle="dropdown" aria-haspopup="true" aria-expanded="false">
                                                                                        Public
                                                                                    </a>

                                                                                    <div class="dropdown-menu dropdown-menu-right" aria-labelledby="SettingsDropdown1">
                                                                                        <a class="dropdown-item" href="javascript:;">Public</a>
                                                                                        <a class="dropdown-item" href="javascript:;">My contacts</a>
                                                                                        <a class="dropdown-item" href="javascript:;">Selected group</a>
                                                                                    </div>
                                                                                </div>
                                                                            </div>
                                                                        </div>
                                                                    </li>
                                                                    <li>
                                                                        <div class="ca-setting-type">
                                                                            <div class="ca-setting-name">
                                                                                <div class="ca-setting-name-main">Last Seen</div>
                                                                                <div class="ca-setting-name-sub">Select who can see my last seen</div>
                                                                            </div>
                                                                            <div class="ca-setting-action">
                                                                                <div class="dropdown">
                                                                                    <a class="btn btn-link dropdown-toggle" href="#" role="button" id="SettingsDropdown2" data-toggle="dropdown" aria-haspopup="true" aria-expanded="false">
                                                                                        My contacts
                                                                                    </a>

                                                                                    <div class="dropdown-menu dropdown-menu-right" aria-labelledby="SettingsDropdown2">
                                                                                        <a class="dropdown-item" href="javascript:;">Public</a>
                                                                                        <a class="dropdown-item" href="javascript:;">My contacts</a>
                                                                                        <a class="dropdown-item" href="javascript:;">Selected group</a>
                                                                                    </div>
                                                                                </div>
                                                                            </div>
                                                                        </div>
                                                                    </li>
                                                                    <li>
                                                                        <div class="ca-setting-type">
                                                                            <div class="ca-setting-name">
                                                                                <div class="ca-setting-name-main">Online Status</div>
                                                                                <div class="ca-setting-name-sub">Select who can see my last seen</div>
                                                                            </div>
                                                                            <div class="ca-setting-action">
                                                                                <div class="dropdown">
                                                                                    <a class="btn btn-link dropdown-toggle" href="#" role="button" id="SettingsDropdown3" data-toggle="dropdown" aria-haspopup="true" aria-expanded="false">
                                                                                        Selected group
                                                                                    </a>

                                                                                    <div class="dropdown-menu dropdown-menu-right" aria-labelledby="SettingsDropdown3">
                                                                                        <a class="dropdown-item" href="javascript:;">Public</a>
                                                                                        <a class="dropdown-item" href="javascript:;">My contacts</a>
                                                                                        <a class="dropdown-item" href="javascript:;">Selected group</a>
                                                                                    </div>
                                                                                </div>
                                                                            </div>
                                                                        </div>
                                                                    </li>
                                                                </ul>
                                                            </div>
                                                        </div>
                                                    </div>
                                                    <div class="card">
                                                        <div class="card-header" id="privacySecurityHead2">
                                                            <div class="card-title collapsed" role="button" data-toggle="collapse" data-target="#privacySecurity2"
                                                                 aria-expanded="false" aria-controls="privacySecurity2">
                                                                Security
                                                            </div>
                                                        </div>
                                                        <div id="privacySecurity2" class="collapse" aria-labelledby="headingTwo" data-parent="#privacySecurity">
                                                            <div class="card-body">
                                                                <ul class="list-unstyled">
                                                                    <li>
                                                                        <div class="setting-list">
                                                                            <div class="setting-list-name">Lock chat screen</div>
                                                                            <div class="setting-list-switch">
                                                                                <label class="material-switch">
                                                                                    <input type="checkbox">
                                                                                    <span></span>
                                                                                </label>
                                                                            </div>
                                                                        </div>
                                                                    </li>
                                                                    <li>
                                                                        <div class="setting-list">
                                                                            <div class="setting-list-name">Unlock with Fingerprint</div>
                                                                            <div class="setting-list-switch">
                                                                                <label class="material-switch">
                                                                                    <input type="checkbox">
                                                                                    <span></span>
                                                                                </label>
                                                                            </div>
                                                                        </div>
                                                                    </li>
                                                                    <li>
                                                                        <div class="setting-list">
                                                                            <div class="setting-list-name">Desktop notification </div>
                                                                            <div class="setting-list-switch">
                                                                                <label class="material-switch">
                                                                                    <input type="checkbox">
                                                                                    <span></span>
                                                                                </label>
                                                                            </div>
                                                                        </div>
                                                                    </li>
                                                                </ul>
                                                            </div>
                                                        </div>
                                                    </div>
                                                    <div class="card">
                                                        <div class="card-header" id="privacySecurityHead3">
                                                            <div class="card-title collapsed" role="button" data-toggle="collapse" data-target="#privacySecurity3"
                                                                 aria-expanded="false" aria-controls="privacySecurity3">
                                                                Blocked Contacts
                                                            </div>
                                                        </div>
                                                        <div id="privacySecurity3" class="collapse" aria-labelledby="privacySecurity3" data-parent="#privacySecurity">
                                                            <div class="card-body">
                                                                <ul class="list-unstyled">
                                                                    <li>
                                                                        <div class="contactlist">
                                                                            <div class="user-avatar user-avatar-rounded online">
                                                                                <img src="~/lib/images/user/500/06.jpg" alt="">
                                                                            </div>
                                                                            <div class="contactlist__details">
                                                                                <div class="contactlist__details--name">Chuck McCann</div>
                                                                                <div class="calllist__details--info">
                                                                                    <span><i class="mdi mdi-tag-outline"></i></span>
                                                                                    <span>Friends</span>
                                                                                </div>
                                                                            </div>

                                                                            <div class="contactlist__actions">
                                                                                <div class="iconbox btn-solid-danger" data-toggle="tooltip" data-placement="top" title="Remove">
                                                                                    <i class="iconbox__icon mdi mdi-close"></i>
                                                                                </div>
                                                                            </div>
                                                                        </div>
                                                                    </li>
                                                                    <li>
                                                                        <div class="contactlist">
                                                                            <div class="user-avatar user-avatar-rounded online">
                                                                                <img src="~/lib/images/user/500/01.jpg" alt="">
                                                                            </div>
                                                                            <div class="contactlist__details">
                                                                                <div class="contactlist__details--name">Pearl Villarreal</div>
                                                                                <div class="calllist__details--info">
                                                                                    <span><i class="mdi mdi-tag-outline"></i></span>
                                                                                    <span>Friends</span>
                                                                                </div>
                                                                            </div>

                                                                            <div class="contactlist__actions">
                                                                                <div class="iconbox btn-solid-danger" data-toggle="tooltip" data-placement="top" title="Remove">
                                                                                    <i class="iconbox__icon mdi mdi-close"></i>
                                                                                </div>
                                                                            </div>
                                                                        </div>
                                                                    </li>
                                                                    <li>
                                                                        <div class="contactlist">
                                                                            <div class="user-avatar user-avatar-rounded online">
                                                                                <img src="~/lib/images/user/500/03.jpg" alt="">
                                                                            </div>
                                                                            <div class="contactlist__details">
                                                                                <div class="contactlist__details--name">Sheila Hawkins</div>
                                                                                <div class="calllist__details--info">
                                                                                    <span><i class="mdi mdi-tag-outline"></i></span>
                                                                                    <span>Friends</span>
                                                                                </div>
                                                                            </div>

                                                                            <div class="contactlist__actions">
                                                                                <div class="iconbox btn-solid-danger" data-toggle="tooltip" data-placement="top" title="Remove">
                                                                                    <i class="iconbox__icon mdi mdi-close"></i>
                                                                                </div>
                                                                            </div>
                                                                        </div>
                                                                    </li>
                                                                    <li>
                                                                        <div class="contactlist border-bottom-0">
                                                                            <div class="user-avatar user-avatar-rounded online">
                                                                                <img src="~/lib/images/user/500/04.jpg" alt="">
                                                                            </div>
                                                                            <div class="contactlist__details">
                                                                                <div class="contactlist__details--name">Amanda Sinquefield</div>
                                                                                <div class="calllist__details--info">
                                                                                    <span><i class="mdi mdi-tag-outline"></i></span>
                                                                                    <span>Friends</span>
                                                                                </div>
                                                                            </div>

                                                                            <div class="contactlist__actions">
                                                                                <div class="iconbox btn-solid-danger" data-toggle="tooltip" data-placement="top" title="Remove">
                                                                                    <i class="iconbox__icon mdi mdi-close"></i>
                                                                                </div>
                                                                            </div>
                                                                        </div>
                                                                    </li>
                                                                </ul>
                                                            </div>
                                                        </div>
                                                    </div>
                                                </div>
                                            </div>
                                            <div class="tab-pane fade" id="v-pills-notifications" role="tabpanel" aria-labelledby="v-pills-notifications-tab">
                                                <div class="settings-inside-wrapper">
                                                    <div class="card">
                                                        <div class="card-body">
                                                            <div class="setting-sunheading">notification configuration</div>
                                                            <ul class="list-unstyled ca-setting-list">
                                                                <li>
                                                                    <div class="ca-setting-type">
                                                                        <div class="ca-setting-name">
                                                                            <div class="ca-setting-name-main">View Notification for</div>
                                                                            <div class="ca-setting-name-sub">You will get notification for</div>
                                                                        </div>
                                                                        <div class="ca-setting-action">
                                                                            <div class="dropdown">
                                                                                <a class="btn btn-link dropdown-toggle" href="#" role="button" id="notiDropdownSettings1" data-toggle="dropdown" aria-haspopup="true" aria-expanded="false">
                                                                                    Both
                                                                                </a>

                                                                                <div class="dropdown-menu dropdown-menu-right" aria-labelledby="notiDropdownSettings1">
                                                                                    <a class="dropdown-item" href="javascript:;">Call only</a>
                                                                                    <a class="dropdown-item" href="javascript:;">Message only</a>
                                                                                    <a class="dropdown-item" href="javascript:;">Both</a>
                                                                                </div>
                                                                            </div>
                                                                        </div>
                                                                    </div>
                                                                </li>
                                                                <li>
                                                                    <div class="ca-setting-type">
                                                                        <div class="ca-setting-name">
                                                                            <div class="ca-setting-name-main">Notification sound for</div>
                                                                            <div class="ca-setting-name-sub">Notification sound play for</div>
                                                                        </div>
                                                                        <div class="ca-setting-action">
                                                                            <div class="dropdown">
                                                                                <a class="btn btn-link dropdown-toggle" href="#" role="button" id="notiDropdownSettings2" data-toggle="dropdown" aria-haspopup="true" aria-expanded="false">
                                                                                    Message only
                                                                                </a>

                                                                                <div class="dropdown-menu dropdown-menu-right" aria-labelledby="notiDropdownSettings2">
                                                                                    <a class="dropdown-item" href="javascript:;">Call only</a>
                                                                                    <a class="dropdown-item" href="javascript:;">Message only</a>
                                                                                    <a class="dropdown-item" href="javascript:;">Both</a>
                                                                                </div>
                                                                            </div>
                                                                        </div>
                                                                    </div>
                                                                </li>
                                                                <li>
                                                                    <div class="setting-list">
                                                                        <div class="setting-list-name">Desktop notifications</div>
                                                                        <div class="setting-list-switch">
                                                                            <label class="material-switch">
                                                                                <input type="checkbox">
                                                                                <span></span>
                                                                            </label>
                                                                        </div>
                                                                    </div>
                                                                </li>
                                                            </ul>
                                                        </div>
                                                    </div>
                                                </div>
                                            </div>
                                            <div class="tab-pane fade" id="v-pills-theme" role="tabpanel" aria-labelledby="v-pills-theme-tab">
                                                <div class="settings-inside-wrapper">
                                                    <div class="row">
                                                        <div class="col-12">
                                                            <h6 class="border-bottom pb-2">Light Theme</h6>
                                                            <a href="javascript:;" data-theme="light-default-theme" class="theme default-theme selected"></a>
                                                            <a href="javascript:;" data-theme="light-purple-theme" class="theme purple-theme"></a>
                                                            <a href="javascript:;" data-theme="light-pink-theme" class="theme pink-theme"></a>
                                                            <a href="javascript:;" data-theme="light-green-theme" class="theme green-theme"></a>
                                                            <a href="javascript:;" data-theme="light-red-theme" class="theme red-theme"></a>
                                                            <a href="javascript:;" data-theme="light-orange-theme" class="theme orange-theme"></a>
                                                            <a href="javascript:;" data-theme="light-blue-theme" class="theme blue-theme"></a>
                                                            <a href="javascript:;" data-theme="light-darkblue-theme" class="theme darkblue-theme"></a>
                                                            <a href="javascript:;" data-theme="light-lightpink-theme" class="theme lightpink-theme"></a>

                                                            <h6 class="border-bottom py-3">Dark Theme</h6>
                                                            <a href="javascript:;" data-theme="dark-default-theme" class="theme default-theme"></a>
                                                            <a href="javascript:;" data-theme="dark-purple-theme" class="theme purple-theme"></a>
                                                            <a href="javascript:;" data-theme="dark-pink-theme" class="theme pink-theme"></a>
                                                            <a href="javascript:;" data-theme="dark-green-theme" class="theme green-theme"></a>
                                                            <a href="javascript:;" data-theme="dark-red-theme" class="theme red-theme"></a>
                                                            <a href="javascript:;" data-theme="dark-orange-theme" class="theme orange-theme"></a>
                                                            <a href="javascript:;" data-theme="dark-blue-theme" class="theme blue-theme"></a>
                                                            <a href="javascript:;" data-theme="dark-darkblue-theme" class="theme darkblue-theme"></a>
                                                            <a href="javascript:;" data-theme="dark-lightpink-theme" class="theme lightpink-theme"></a>
                                                        </div>
                                                    </div>
                                                </div>
                                            </div>
                                            <div class="tab-pane fade" id="v-pills-audiovideo" role="tabpanel" aria-labelledby="v-pills-audiovideo-tab">
                                                <div class="accordion settings-accordion accordion-arrow-toggler accordion-ungrouped" id="audioVideoAcc">
                                                    <div class="card">
                                                        <div class="card-header" id="audioVideoAccHead1">
                                                            <div class="card-title" data-toggle="collapse" role="button" data-target="#audioVideoAcc1" aria-expanded="true" aria-controls="audioVideoAcc1">
                                                                Audio
                                                            </div>
                                                        </div>

                                                        <div id="audioVideoAcc1" class="collapse show" aria-labelledby="headingOne" data-parent="#audioVideoAcc">
                                                            <div class="card-body">
                                                                <div class="setting-sunheading">Audio configurations</div>

                                                                <ul class="list-unstyled ca-setting-list">
                                                                    <li>
                                                                        <div class="ca-setting-type">
                                                                            <div class="ca-setting-name">
                                                                                <div class="ca-setting-name-main">Input</div>
                                                                                <div class="ca-setting-name-sub">Select who can see your profile picture</div>
                                                                            </div>
                                                                            <div class="ca-setting-action">
                                                                                <div class="dropdown">
                                                                                    <a class="btn btn-link dropdown-toggle" href="#" role="button" id="audioDropdownSettings1" data-toggle="dropdown" aria-haspopup="true" aria-expanded="false">
                                                                                        Microphone
                                                                                    </a>

                                                                                    <div class="dropdown-menu dropdown-menu-right" aria-labelledby="audioDropdownSettings1">
                                                                                        <a class="dropdown-item" href="javascript:;">Default Device </a>
                                                                                        <a class="dropdown-item" href="javascript:;">Microphone</a>
                                                                                        <a class="dropdown-item" href="javascript:;">Stereo mix</a>
                                                                                    </div>
                                                                                </div>
                                                                            </div>
                                                                        </div>
                                                                    </li>
                                                                </ul>
                                                            </div>
                                                        </div>
                                                    </div>
                                                    <div class="card">
                                                        <div class="card-header" id="audioVideoAccHead2">
                                                            <div class="card-title collapsed" role="button" data-toggle="collapse" data-target="#audioVideoAcc2"
                                                                 aria-expanded="false" aria-controls="audioVideoAcc2">
                                                                Video
                                                            </div>
                                                        </div>
                                                        <div id="audioVideoAcc2" class="collapse" aria-labelledby="headingTwo" data-parent="#audioVideoAcc">
                                                            <div class="card-body">
                                                                <div class="setting-sunheading">Video configurations</div>

                                                                <ul class="list-unstyled ca-setting-list">
                                                                    <li>
                                                                        <div class="ca-setting-type">
                                                                            <div class="ca-setting-name">
                                                                                <div class="ca-setting-name-main">Input</div>
                                                                                <div class="ca-setting-name-sub">Select who can see your profile picture</div>
                                                                            </div>
                                                                            <div class="ca-setting-action">
                                                                                <div class="dropdown">
                                                                                    <a class="btn btn-link dropdown-toggle" href="#" role="button" id="audioDropdownSettings2" data-toggle="dropdown" aria-haspopup="true" aria-expanded="false">
                                                                                        UHD webcam
                                                                                    </a>

                                                                                    <div class="dropdown-menu dropdown-menu-right" aria-labelledby="audioDropdownSettings2">
                                                                                        <a class="dropdown-item" href="javascript:;">Default webcam </a>
                                                                                        <a class="dropdown-item" href="javascript:;">HD webcam </a>
                                                                                        <a class="dropdown-item" href="javascript:;">UHD webcam </a>
                                                                                    </div>
                                                                                </div>
                                                                            </div>
                                                                        </div>
                                                                    </li>
                                                                </ul>
                                                            </div>
                                                        </div>
                                                    </div>
                                                </div>
                                            </div>
                                            <div class="tab-pane fade" id="v-pills-media" role="tabpanel" aria-labelledby="v-pills-media-tab">
                                                <div class="accordion settings-accordion accordion-arrow-toggler accordion-ungrouped" id="mediaAcc">
                                                    <div class="card">
                                                        <div class="card-header" id="mediaAccHead1">
                                                            <div class="card-title" data-toggle="collapse" role="button" data-target="#mediaAcc1" aria-expanded="true" aria-controls="mediaAcc1">
                                                                Backups
                                                            </div>
                                                        </div>

                                                        <div id="mediaAcc1" class="collapse show" aria-labelledby="headingOne" data-parent="#mediaAcc">
                                                            <div class="card-body">
                                                                <div class="setting-sunheading">Backups configurations</div>

                                                                <ul class="list-unstyled ca-setting-list">
                                                                    <li>
                                                                        <div class="ca-setting-type">
                                                                            <div class="ca-setting-name">
                                                                                <div class="ca-setting-name-main">Backup Type</div>
                                                                                <div class="ca-setting-name-sub">Select that how you want to take backup</div>
                                                                            </div>
                                                                            <div class="ca-setting-action">
                                                                                <div class="dropdown">
                                                                                    <a class="btn btn-link dropdown-toggle" href="#" role="button" id="backupDropdownSettings1" data-toggle="dropdown" aria-haspopup="true" aria-expanded="false">
                                                                                        Auto
                                                                                    </a>

                                                                                    <div class="dropdown-menu dropdown-menu-right" aria-labelledby="backupDropdownSettings1">
                                                                                        <a class="dropdown-item" href="javascript:;">Auto</a>
                                                                                        <a class="dropdown-item" href="javascript:;">Manual</a>
                                                                                    </div>
                                                                                </div>
                                                                            </div>
                                                                        </div>
                                                                    </li>
                                                                    <li>
                                                                        <div class="ca-setting-type">
                                                                            <div class="ca-setting-name">
                                                                                <div class="ca-setting-name-main">Backup Schedule</div>
                                                                                <div class="ca-setting-name-sub">Select span of the backup time</div>
                                                                            </div>
                                                                            <div class="ca-setting-action">
                                                                                <div class="dropdown">
                                                                                    <a class="btn btn-link dropdown-toggle" href="#" role="button" id="backupDropdownSettings2" data-toggle="dropdown" aria-haspopup="true" aria-expanded="false">
                                                                                        Every Day
                                                                                    </a>

                                                                                    <div class="dropdown-menu dropdown-menu-right" aria-labelledby="backupDropdownSettings2">
                                                                                        <a class="dropdown-item" href="javascript:;">Every Day</a>
                                                                                        <a class="dropdown-item" href="javascript:;">Every Week</a>
                                                                                        <a class="dropdown-item" href="javascript:;">Every Month</a>
                                                                                    </div>
                                                                                </div>
                                                                            </div>
                                                                        </div>
                                                                    </li>
                                                                    <li>
                                                                        <div class="ca-setting-type">
                                                                            <div class="ca-setting-name">
                                                                                <div class="ca-setting-name-main">Delete Old Media</div>
                                                                                <div class="ca-setting-name-sub">Delete media automatically after period of time</div>
                                                                            </div>
                                                                            <div class="ca-setting-action">
                                                                                <div class="dropdown">
                                                                                    <a class="btn btn-link dropdown-toggle" href="#" role="button" id="backupDropdownSettings3" data-toggle="dropdown" aria-haspopup="true" aria-expanded="false">
                                                                                        Never
                                                                                    </a>

                                                                                    <div class="dropdown-menu dropdown-menu-right" aria-labelledby="backupDropdownSettings3">
                                                                                        <a class="dropdown-item" href="javascript:;">Never</a>
                                                                                        <a class="dropdown-item" href="javascript:;">Every Week</a>
                                                                                        <a class="dropdown-item" href="javascript:;">Every Month</a>
                                                                                        <a class="dropdown-item" href="javascript:;">Every Year</a>
                                                                                    </div>
                                                                                </div>
                                                                            </div>
                                                                        </div>
                                                                    </li>
                                                                </ul>

                                                                <div class="setting-sunheading mt-5 mb-3">Backups items</div>

                                                                <ul class="list-unstyled">
                                                                    <li>
                                                                        <div class="setting-list">
                                                                            <div class="setting-list-name">Chat</div>
                                                                            <div class="setting-list-switch">
                                                                                <label class="material-switch">
                                                                                    <input type="checkbox" checked="">
                                                                                    <span></span>
                                                                                </label>
                                                                            </div>
                                                                        </div>
                                                                    </li>
                                                                    <li>
                                                                        <div class="setting-list">
                                                                            <div class="setting-list-name">Images </div>
                                                                            <div class="setting-list-switch">
                                                                                <label class="material-switch">
                                                                                    <input type="checkbox" checked="">
                                                                                    <span></span>
                                                                                </label>
                                                                            </div>
                                                                        </div>
                                                                    </li>
                                                                    <li>
                                                                        <div class="setting-list">
                                                                            <div class="setting-list-name">Videos </div>
                                                                            <div class="setting-list-switch">
                                                                                <label class="material-switch">
                                                                                    <input type="checkbox">
                                                                                    <span></span>
                                                                                </label>
                                                                            </div>
                                                                        </div>
                                                                    </li>
                                                                    <li>
                                                                        <div class="setting-list">
                                                                            <div class="setting-list-name">Documents</div>
                                                                            <div class="setting-list-switch">
                                                                                <label class="material-switch">
                                                                                    <input type="checkbox" checked="">
                                                                                    <span></span>
                                                                                </label>
                                                                            </div>
                                                                        </div>
                                                                    </li>
                                                                </ul>
                                                            </div>
                                                        </div>
                                                    </div>
                                                    <div class="card">
                                                        <div class="card-header" id="mediaAccHead2">
                                                            <div class="card-title collapsed" role="button" data-toggle="collapse" data-target="#mediaAcc2"
                                                                 aria-expanded="false" aria-controls="mediaAcc2">
                                                                Media Settings
                                                            </div>
                                                        </div>
                                                        <div id="mediaAcc2" class="collapse" aria-labelledby="headingTwo" data-parent="#mediaAcc">
                                                            <div class="card-body">
                                                                <div class="setting-sunheading mb-3">Auto Download Media</div>

                                                                <ul class="list-unstyled">
                                                                    <li>
                                                                        <div class="setting-list">
                                                                            <div class="setting-list-name">Images </div>
                                                                            <div class="setting-list-switch">
                                                                                <label class="material-switch">
                                                                                    <input type="checkbox" checked="">
                                                                                    <span></span>
                                                                                </label>
                                                                            </div>
                                                                        </div>
                                                                    </li>
                                                                    <li>
                                                                        <div class="setting-list">
                                                                            <div class="setting-list-name">Videos </div>
                                                                            <div class="setting-list-switch">
                                                                                <label class="material-switch">
                                                                                    <input type="checkbox">
                                                                                    <span></span>
                                                                                </label>
                                                                            </div>
                                                                        </div>
                                                                    </li>
                                                                    <li>
                                                                        <div class="setting-list">
                                                                            <div class="setting-list-name">Documents</div>
                                                                            <div class="setting-list-switch">
                                                                                <label class="material-switch">
                                                                                    <input type="checkbox" checked="">
                                                                                    <span></span>
                                                                                </label>
                                                                            </div>
                                                                        </div>
                                                                    </li>
                                                                </ul>

                                                                <div class="setting-sunheading mt-5 mb-3">Media configuration</div>

                                                                <ul class="list-unstyled ca-setting-list">
                                                                    <li>
                                                                        <div class="ca-setting-type">
                                                                            <div class="ca-setting-name">
                                                                                <div class="ca-setting-name-main">Image Quality</div>
                                                                                <div class="ca-setting-name-sub">Choose media quality you want to send</div>
                                                                            </div>
                                                                            <div class="ca-setting-action">
                                                                                <div class="dropdown">
                                                                                    <a class="btn btn-link dropdown-toggle" href="#" role="button" id="mediaDropdownSettings1" data-toggle="dropdown" aria-haspopup="true" aria-expanded="false">
                                                                                        Original
                                                                                    </a>

                                                                                    <div class="dropdown-menu dropdown-menu-right" aria-labelledby="mediaDropdownSettings1">
                                                                                        <a class="dropdown-item" href="javascript:;">Good</a>
                                                                                        <a class="dropdown-item" href="javascript:;">Excellent</a>
                                                                                        <a class="dropdown-item" href="javascript:;">Original</a>
                                                                                    </div>
                                                                                </div>
                                                                            </div>
                                                                        </div>
                                                                    </li>
                                                                </ul>
                                                            </div>
                                                        </div>
                                                    </div>
                                                </div>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>

        <div class="calling-modal-data">

            <!-- VIDEO CALL START-->
            <div class="modal fade videocall-modal CallDialogFullscreen-sm" id="incomingVideoStart" tabindex="-1" role="dialog" aria-labelledby="incomingVideoStart" aria-hidden="true">
                <div class="modal-dialog modal-dialog-centered modal-xl " role="document">
                    <div class="modal-content">
                        <div class="modal-body">
                            <div class="icvideocallwrapper">
                                <div class="icvideo-contact">
                                    <img class="img-fluid icvideo-contact__inner" src="~/lib/images/media/call-01.jpg" alt="">
                                </div>
                                <div class="icvideo-user">
                                    <img class="" src="~/lib/images/media/call-02.jpg" alt="">
                                </div>
                                <div class="icvideo-actions">
                                    <div class="icvideo-actions__left">
                                        <div class="icvideo-actions__left--duration">00:36</div>
                                    </div>
                                    <div class="icvideo-actions__middle">
                                        <div class="">

                                            <div class="iconbox btn-hovered-light" data-toggle="tooltip" data-placement="top" title="Speaker">
                                                <i class="iconbox__icon mdi mdi-volume-high"></i>
                                            </div>
                                            <div class="iconbox btn-hovered-light" data-toggle="tooltip" data-placement="top" title="Hold">
                                                <i class="iconbox__icon mdi mdi-pause"></i>
                                            </div>
                                            <div class="iconbox btn-hovered-light" data-toggle="tooltip" data-placement="top" title="Add Call">
                                                <i class="iconbox__icon mdi mdi-phone-plus"></i>
                                            </div>
                                            <div class="iconbox btn-hovered-light" data-toggle="tooltip" data-placement="top" title="Disbale Video">
                                                <i class="iconbox__icon mdi mdi-video-off-outline"></i>
                                            </div>
                                            <div class="iconbox btn-hovered-light" data-toggle="tooltip" data-placement="top" title="Mute">
                                                <i class="iconbox__icon mdi mdi-microphone-off"></i>
                                            </div>

                                        </div>
                                    </div>
                                    <div class="icvideo-actions__right">
                                        <div class="iconbox btn-hovered-light bg-danger" data-dismiss="modal" data-toggle="tooltip" data-placement="top" title="Hangup">
                                            <i class="iconbox__icon text-white mdi mdi-phone-hangup"></i>
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>

            <!-- OUTGOING VOICE CALL -->
            <div class="modal CallDialogFullscreen-sm" id="outGoingCall" tabindex="-1" role="dialog" aria-labelledby="outGoingCall" aria-hidden="true">
                <div class="modal-dialog modal-dialog-centered" role="document">
                    <div class="modal-content">
                        <div class="modal-body">
                            <div class="text-center">
                                <div class="user-avatar user-avatar-rounded user-avatar-xl">
                                    <img src="~/lib/images/user/250/01.jpg" alt="">
                                </div>
                                <div class="userprofile-name">
                                    <span>Calling...</span>
                                    <h4>Jack P. Angulo</h4>
                                    <span>Product Manager</span>

                                    <div class="call-duration">00:36</div>
                                </div>

                                <div class="call-options">
                                    <div class="row">
                                        <div class="col-4">
                                            <div class="call-options__iconbox">
                                                <i class="mdi mdi-microphone-off"></i>
                                            </div>
                                            <h6>Mute</h6>
                                        </div>
                                        <div class="col-4">
                                            <div class="call-options__iconbox">
                                                <i class="mdi mdi-volume-high"></i>
                                            </div>
                                            <h6>Speaker</h6>
                                        </div>
                                        <div class="col-4">
                                            <div class="call-options__iconbox">
                                                <i class="mdi mdi-pause"></i>
                                            </div>
                                            <h6>Hold</h6>
                                        </div>
                                    </div>
                                </div>

                                <div class="call-actions">
                                    <div class="call-hangup" data-dismiss="modal"><i class="mdi mdi-phone-hangup"></i></div>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
        <div class="new-msgcall-data">
            <!-- NEW MESSAGE MODAL -->
            <div class="modal new-message-dialog" id="newMsgModal" tabindex="-1" role="dialog" aria-labelledby="newMsgModal" aria-hidden="true">
                <div class="modal-dialog modal-dialog-centered" role="document">
                    <div class="modal-content">
                        <div class="modal-header">
                            <h6 class="modal-title" id="newMsgModalLabel">Create New Message</h6>
                            <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                                <span aria-hidden="true">&times;</span>
                            </button>
                        </div>
                        <div class="modal-body">
                            <div class="searchbar">
                                <div class="input-group">
                                    <input type="text" class="form-control" placeholder="Search" aria-label="Search">
                                    <div class="input-group-append">
                                        <span class="input-group-text dialpad-opener"><i class="mdi mdi-dialpad"></i></span>
                                    </div>
                                </div>
                            </div>
                            <div class="modal-contact-list">
                                <ul class="list-unstyled">
                                    <li>
                                        <div class="contactlist">
                                            <div class="user-avatar user-avatar-rounded">
                                                <img src="~/lib/images/user/500/06.jpg" alt="">
                                            </div>
                                            <div class="contactlist__details">
                                                <div class="contactlist__details--name">Chuck McCann</div>
                                                <div class="calllist__details--info">
                                                    <span><i class="mdi mdi-tag-outline"></i></span>
                                                    <span>Friends</span>
                                                </div>
                                            </div>

                                            <div class="contactlist__actions">
                                                <div class="iconbox btn-solid-primary">
                                                    <i class="iconbox__icon mdi mdi-message-text-outline"></i>
                                                </div>
                                            </div>
                                        </div>
                                    </li>
                                    <li>
                                        <div class="contactlist">
                                            <div class="user-avatar user-avatar-rounded">
                                                <img src="~/lib/images/user/500/01.jpg" alt="">
                                            </div>
                                            <div class="contactlist__details">
                                                <div class="contactlist__details--name">Pearl Villarreal</div>
                                                <div class="calllist__details--info">
                                                    <span><i class="mdi mdi-tag-outline"></i></span>
                                                    <span>Friends</span>
                                                </div>
                                            </div>

                                            <div class="contactlist__actions">
                                                <div class="iconbox btn-solid-primary">
                                                    <i class="iconbox__icon mdi mdi-message-text-outline"></i>
                                                </div>
                                            </div>
                                        </div>
                                    </li>
                                    <li>
                                        <div class="contactlist">
                                            <div class="user-avatar user-avatar-rounded">
                                                <img src="~/lib/images/user/500/03.jpg" alt="">
                                            </div>
                                            <div class="contactlist__details">
                                                <div class="contactlist__details--name">Sheila Hawkins</div>
                                                <div class="calllist__details--info">
                                                    <span><i class="mdi mdi-tag-outline"></i></span>
                                                    <span>Friends</span>
                                                </div>
                                            </div>

                                            <div class="contactlist__actions">
                                                <div class="iconbox btn-solid-primary">
                                                    <i class="iconbox__icon mdi mdi-message-text-outline"></i>
                                                </div>
                                            </div>
                                        </div>
                                    </li>
                                    <li>
                                        <div class="contactlist">
                                            <div class="user-avatar user-avatar-rounded">
                                                <img src="~/lib/images/user/500/04.jpg" alt="">
                                            </div>
                                            <div class="contactlist__details">
                                                <div class="contactlist__details--name">Amanda Sinquefield</div>
                                                <div class="calllist__details--info">
                                                    <span><i class="mdi mdi-tag-outline"></i></span>
                                                    <span>Friends</span>
                                                </div>
                                            </div>

                                            <div class="contactlist__actions">
                                                <div class="iconbox btn-solid-primary">
                                                    <i class="iconbox__icon mdi mdi-message-text-outline"></i>
                                                </div>
                                            </div>
                                        </div>
                                    </li>
                                    <li>
                                        <div class="contactlist">
                                            <div class="user-avatar user-avatar-rounded">
                                                <img src="~/lib/images/user/500/04.jpg" alt="">
                                            </div>
                                            <div class="contactlist__details">
                                                <div class="contactlist__details--name">Amanda Sinquefield</div>
                                                <div class="calllist__details--info">
                                                    <span><i class="mdi mdi-tag-outline"></i></span>
                                                    <span>Friends</span>
                                                </div>
                                            </div>

                                            <div class="contactlist__actions">
                                                <div class="iconbox btn-solid-primary">
                                                    <i class="iconbox__icon mdi mdi-message-text-outline"></i>
                                                </div>
                                            </div>
                                        </div>
                                    </li>
                                    <li>
                                        <div class="contactlist">
                                            <div class="user-avatar user-avatar-rounded">
                                                <img src="~/lib/images/user/500/04.jpg" alt="">
                                            </div>
                                            <div class="contactlist__details">
                                                <div class="contactlist__details--name">Amanda Sinquefield</div>
                                                <div class="calllist__details--info">
                                                    <span><i class="mdi mdi-tag-outline"></i></span>
                                                    <span>Friends</span>
                                                </div>
                                            </div>

                                            <div class="contactlist__actions">
                                                <div class="iconbox btn-solid-primary">
                                                    <i class="iconbox__icon mdi mdi-message-text-outline"></i>
                                                </div>
                                            </div>
                                        </div>
                                    </li>
                                    <li>
                                        <div class="contactlist">
                                            <div class="user-avatar user-avatar-rounded">
                                                <img src="~/lib/images/user/500/04.jpg" alt="">
                                            </div>
                                            <div class="contactlist__details">
                                                <div class="contactlist__details--name">Amanda Sinquefield</div>
                                                <div class="calllist__details--info">
                                                    <span><i class="mdi mdi-tag-outline"></i></span>
                                                    <span>Friends</span>
                                                </div>
                                            </div>

                                            <div class="contactlist__actions">
                                                <div class="iconbox btn-solid-primary">
                                                    <i class="iconbox__icon mdi mdi-message-text-outline"></i>
                                                </div>
                                            </div>
                                        </div>
                                    </li>
                                    <li>
                                        <div class="contactlist">
                                            <div class="user-avatar user-avatar-rounded">
                                                <img src="~/lib/images/user/500/04.jpg" alt="">
                                            </div>
                                            <div class="contactlist__details">
                                                <div class="contactlist__details--name">Amanda Sinquefield</div>
                                                <div class="calllist__details--info">
                                                    <span><i class="mdi mdi-tag-outline"></i></span>
                                                    <span>Friends</span>
                                                </div>
                                            </div>

                                            <div class="contactlist__actions">
                                                <div class="iconbox btn-solid-primary">
                                                    <i class="iconbox__icon mdi mdi-message-text-outline"></i>
                                                </div>
                                            </div>
                                        </div>
                                    </li>
                                    <li>
                                        <div class="contactlist">
                                            <div class="user-avatar user-avatar-rounded">
                                                <img src="~/lib/images/user/500/04.jpg" alt="">
                                            </div>
                                            <div class="contactlist__details">
                                                <div class="contactlist__details--name">Amanda Sinquefield</div>
                                                <div class="calllist__details--info">
                                                    <span><i class="mdi mdi-tag-outline"></i></span>
                                                    <span>Friends</span>
                                                </div>
                                            </div>

                                            <div class="contactlist__actions">
                                                <div class="iconbox btn-solid-primary">
                                                    <i class="iconbox__icon mdi mdi-message-text-outline"></i>
                                                </div>
                                            </div>
                                        </div>
                                    </li>
                                    <li>
                                        <div class="contactlist">
                                            <div class="user-avatar user-avatar-rounded">
                                                <img src="~/lib/images/user/500/04.jpg" alt="">
                                            </div>
                                            <div class="contactlist__details">
                                                <div class="contactlist__details--name">Amanda Sinquefield</div>
                                                <div class="calllist__details--info">
                                                    <span><i class="mdi mdi-tag-outline"></i></span>
                                                    <span>Friends</span>
                                                </div>
                                            </div>

                                            <div class="contactlist__actions">
                                                <div class="iconbox btn-solid-primary">
                                                    <i class="iconbox__icon mdi mdi-message-text-outline"></i>
                                                </div>
                                            </div>
                                        </div>
                                    </li>
                                    <li>
                                        <div class="contactlist">
                                            <div class="user-avatar user-avatar-rounded">
                                                <img src="~/lib/images/user/500/04.jpg" alt="">
                                            </div>
                                            <div class="contactlist__details">
                                                <div class="contactlist__details--name">Amanda Sinquefield</div>
                                                <div class="calllist__details--info">
                                                    <span><i class="mdi mdi-tag-outline"></i></span>
                                                    <span>Friends</span>
                                                </div>
                                            </div>

                                            <div class="contactlist__actions">
                                                <div class="iconbox btn-solid-primary">
                                                    <i class="iconbox__icon mdi mdi-message-text-outline"></i>
                                                </div>
                                            </div>
                                        </div>
                                    </li>
                                    <li>
                                        <div class="contactlist">
                                            <div class="user-avatar user-avatar-rounded">
                                                <img src="~/lib/images/user/500/04.jpg" alt="">
                                            </div>
                                            <div class="contactlist__details">
                                                <div class="contactlist__details--name">Amanda Sinquefield</div>
                                                <div class="calllist__details--info">
                                                    <span><i class="mdi mdi-tag-outline"></i></span>
                                                    <span>Friends</span>
                                                </div>
                                            </div>

                                            <div class="contactlist__actions">
                                                <div class="iconbox btn-solid-primary">
                                                    <i class="iconbox__icon mdi mdi-message-text-outline"></i>
                                                </div>
                                            </div>
                                        </div>
                                    </li>
                                    <li>
                                        <div class="contactlist">
                                            <div class="user-avatar user-avatar-rounded">
                                                <img src="~/lib/images/user/500/04.jpg" alt="">
                                            </div>
                                            <div class="contactlist__details">
                                                <div class="contactlist__details--name">Amanda Sinquefield</div>
                                                <div class="calllist__details--info">
                                                    <span><i class="mdi mdi-tag-outline"></i></span>
                                                    <span>Friends</span>
                                                </div>
                                            </div>

                                            <div class="contactlist__actions">
                                                <div class="iconbox btn-solid-primary">
                                                    <i class="iconbox__icon mdi mdi-message-text-outline"></i>
                                                </div>
                                            </div>
                                        </div>
                                    </li>
                                    <li>
                                        <div class="contactlist">
                                            <div class="user-avatar user-avatar-rounded">
                                                <img src="~/lib/images/user/500/04.jpg" alt="">
                                            </div>
                                            <div class="contactlist__details">
                                                <div class="contactlist__details--name">Amanda Sinquefield</div>
                                                <div class="calllist__details--info">
                                                    <span><i class="mdi mdi-tag-outline"></i></span>
                                                    <span>Friends</span>
                                                </div>
                                            </div>

                                            <div class="contactlist__actions">
                                                <div class="iconbox btn-solid-primary">
                                                    <i class="iconbox__icon mdi mdi-message-text-outline"></i>
                                                </div>
                                            </div>
                                        </div>
                                    </li>
                                    <li>
                                        <div class="contactlist border-bottom-0">
                                            <div class="user-avatar user-avatar-rounded">
                                                <img src="~/lib/images/user/500/04.jpg" alt="">
                                            </div>
                                            <div class="contactlist__details">
                                                <div class="contactlist__details--name">Amanda Sinquefield</div>
                                                <div class="calllist__details--info">
                                                    <span><i class="mdi mdi-tag-outline"></i></span>
                                                    <span>Friends</span>
                                                </div>
                                            </div>

                                            <div class="contactlist__actions">
                                                <div class="iconbox btn-solid-primary">
                                                    <i class="iconbox__icon mdi mdi-message-text-outline"></i>
                                                </div>
                                            </div>
                                        </div>
                                    </li>
                                </ul>
                            </div>
                            <div class="modal-dialpad">
                                <div class="dial-pad-wrap">
                                    <div class="dial-pad">
                                        <div class="dial-screen">+01-(363)-2612</div>
                                        <div class="dial-table">
                                            <div class="dial-table-row">
                                                <div class="dial-table-col">
                                                    <div class="dial-key-wrap" data-key="1">
                                                        <div class="dial-key">1</div>
                                                        <div class="dial-sub-key">&nbsp;</div>
                                                    </div>
                                                </div>
                                                <div class="dial-table-col">
                                                    <div class="dial-key-wrap" data-key="2">
                                                        <div class="dial-key">2</div>
                                                        <div class="dial-sub-key">abc</div>
                                                    </div>
                                                </div>
                                                <div class="dial-table-col">
                                                    <div class="dial-key-wrap" data-key="3">
                                                        <div class="dial-key">3</div>
                                                        <div class="dial-sub-key">def</div>
                                                    </div>
                                                </div>
                                            </div>
                                            <div class="dial-table-row">
                                                <div class="dial-table-col">
                                                    <div class="dial-key-wrap" data-key="4">
                                                        <div class="dial-key">4</div>
                                                        <div class="dial-sub-key">ghi</div>
                                                    </div>
                                                </div>
                                                <div class="dial-table-col">
                                                    <div class="dial-key-wrap" data-key="5">
                                                        <div class="dial-key">5</div>
                                                        <div class="dial-sub-key">jkl</div>
                                                    </div>
                                                </div>
                                                <div class="dial-table-col">
                                                    <div class="dial-key-wrap" data-key="6">
                                                        <div class="dial-key">6</div>
                                                        <div class="dial-sub-key">mno</div>
                                                    </div>
                                                </div>
                                            </div>
                                            <div class="dial-table-row">
                                                <div class="dial-table-col">
                                                    <div class="dial-key-wrap" data-key="7">
                                                        <div class="dial-key">7</div>
                                                        <div class="dial-sub-key">pqrs</div>
                                                    </div>
                                                </div>
                                                <div class="dial-table-col">
                                                    <div class="dial-key-wrap" data-key="8">
                                                        <div class="dial-key">8</div>
                                                        <div class="dial-sub-key">tuv</div>
                                                    </div>
                                                </div>
                                                <div class="dial-table-col">
                                                    <div class="dial-key-wrap" data-key="9">
                                                        <div class="dial-key">9</div>
                                                        <div class="dial-sub-key">wxyz</div>
                                                    </div>
                                                </div>
                                            </div>
                                            <div class="dial-table-row">
                                                <div class="dial-table-col">
                                                    <div class="dial-key-wrap" data-key="*">
                                                        <div class="dial-key">*</div>
                                                        <div class="dial-sub-key">&nbsp;</div>
                                                    </div>
                                                </div>
                                                <div class="dial-table-col">
                                                    <div class="dial-key-wrap" data-key="0">
                                                        <div class="dial-key">0</div>
                                                        <div class="dial-sub-key">+</div>
                                                    </div>
                                                </div>
                                                <div class="dial-table-col">
                                                    <div class="dial-key-wrap" data-key="#">
                                                        <div class="dial-key">#</div>
                                                        <div class="dial-sub-key">&nbsp;</div>
                                                    </div>
                                                </div>
                                            </div>
                                            <div class="dial-table-row no-sub-key">
                                                <div class="dial-table-col">
                                                    <div class="dial-key-wrap" data-key="save-contact">
                                                        <div class="dial-key"><i class="mdi mdi-account-plus-outline"></i></div>
                                                        <div class="dial-sub-key">Call</div>
                                                    </div>
                                                </div>
                                                <div class="dial-table-col">
                                                    <div class="dial-key-wrap" data-key="call">
                                                        <div class="dial-key"><i class="mdi mdi-message-text-outline"></i></div>
                                                        <div class="dial-sub-key">Call</div>
                                                    </div>
                                                </div>
                                                <div class="dial-table-col">
                                                    <div class="dial-key-wrap" data-key="back">
                                                        <div class="dial-key"><i class="mdi mdi-arrow-left"></i></div>
                                                        <div class="dial-sub-key">Back</div>
                                                    </div>
                                                </div>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
            <!-- NEW CALL MODAL -->
            <div class="modal new-call-dialog" id="newCallModal" tabindex="-1" role="dialog" aria-labelledby="newCallModal" aria-hidden="true">
                <div class="modal-dialog modal-dialog-centered" role="document">
                    <div class="modal-content">
                        <div class="modal-header">
                            <h6 class="modal-title" id="newCallModalLabel">Create New Call</h6>
                            <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                                <span aria-hidden="true">&times;</span>
                            </button>
                        </div>
                        <div class="modal-body">
                            <div class="searchbar">
                                <div class="input-group">
                                    <input type="text" class="form-control" placeholder="Search" aria-label="Search">
                                    <div class="input-group-append">
                                        <span class="input-group-text dialpad-opener"><i class="mdi mdi-dialpad"></i></span>
                                    </div>
                                </div>
                            </div>
                            <div class="modal-contact-list">
                                <ul class="list-unstyled">
                                    <li>
                                        <div class="contactlist">
                                            <div class="user-avatar user-avatar-rounded">
                                                <img src="~/lib/images/user/500/06.jpg" alt="">
                                            </div>
                                            <div class="contactlist__details">
                                                <div class="contactlist__details--name">Chuck McCann</div>
                                                <div class="calllist__details--info">
                                                    <span><i class="mdi mdi-tag-outline"></i></span>
                                                    <span>Friends</span>
                                                </div>
                                            </div>

                                            <div class="contactlist__actions">
                                                <div class="iconbox btn-solid-success">
                                                    <i class="iconbox__icon mdi mdi-phone"></i>
                                                </div>
                                                <div class="iconbox btn-solid-info">
                                                    <i class="iconbox__icon mdi mdi-video-outline"></i>
                                                </div>
                                            </div>
                                        </div>
                                    </li>
                                    <li>
                                        <div class="contactlist">
                                            <div class="user-avatar user-avatar-rounded">
                                                <img src="~/lib/images/user/500/01.jpg" alt="">
                                            </div>
                                            <div class="contactlist__details">
                                                <div class="contactlist__details--name">Pearl Villarreal</div>
                                                <div class="calllist__details--info">
                                                    <span><i class="mdi mdi-tag-outline"></i></span>
                                                    <span>Friends</span>
                                                </div>
                                            </div>

                                            <div class="contactlist__actions">
                                                <div class="iconbox btn-solid-success">
                                                    <i class="iconbox__icon mdi mdi-phone"></i>
                                                </div>
                                                <div class="iconbox btn-solid-info">
                                                    <i class="iconbox__icon mdi mdi-video-outline"></i>
                                                </div>
                                            </div>
                                        </div>
                                    </li>
                                    <li>
                                        <div class="contactlist">
                                            <div class="user-avatar user-avatar-rounded">
                                                <img src="~/lib/images/user/500/03.jpg" alt="">
                                            </div>
                                            <div class="contactlist__details">
                                                <div class="contactlist__details--name">Sheila Hawkins</div>
                                                <div class="calllist__details--info">
                                                    <span><i class="mdi mdi-tag-outline"></i></span>
                                                    <span>Friends</span>
                                                </div>
                                            </div>

                                            <div class="contactlist__actions">
                                                <div class="iconbox btn-solid-success">
                                                    <i class="iconbox__icon mdi mdi-phone"></i>
                                                </div>
                                                <div class="iconbox btn-solid-info">
                                                    <i class="iconbox__icon mdi mdi-video-outline"></i>
                                                </div>
                                            </div>
                                        </div>
                                    </li>
                                    <li>
                                        <div class="contactlist">
                                            <div class="user-avatar user-avatar-rounded">
                                                <img src="~/lib/images/user/500/04.jpg" alt="">
                                            </div>
                                            <div class="contactlist__details">
                                                <div class="contactlist__details--name">Amanda Sinquefield</div>
                                                <div class="calllist__details--info">
                                                    <span><i class="mdi mdi-tag-outline"></i></span>
                                                    <span>Friends</span>
                                                </div>
                                            </div>

                                            <div class="contactlist__actions">
                                                <div class="iconbox btn-solid-success">
                                                    <i class="iconbox__icon mdi mdi-phone"></i>
                                                </div>
                                                <div class="iconbox btn-solid-info">
                                                    <i class="iconbox__icon mdi mdi-video-outline"></i>
                                                </div>
                                            </div>
                                        </div>
                                    </li>
                                    <li>
                                        <div class="contactlist">
                                            <div class="user-avatar user-avatar-rounded">
                                                <img src="~/lib/images/user/500/04.jpg" alt="">
                                            </div>
                                            <div class="contactlist__details">
                                                <div class="contactlist__details--name">Amanda Sinquefield</div>
                                                <div class="calllist__details--info">
                                                    <span><i class="mdi mdi-tag-outline"></i></span>
                                                    <span>Friends</span>
                                                </div>
                                            </div>

                                            <div class="contactlist__actions">
                                                <div class="iconbox btn-solid-success">
                                                    <i class="iconbox__icon mdi mdi-phone"></i>
                                                </div>
                                                <div class="iconbox btn-solid-info">
                                                    <i class="iconbox__icon mdi mdi-video-outline"></i>
                                                </div>
                                            </div>
                                        </div>
                                    </li>
                                    <li>
                                        <div class="contactlist">
                                            <div class="user-avatar user-avatar-rounded">
                                                <img src="~/lib/images/user/500/04.jpg" alt="">
                                            </div>
                                            <div class="contactlist__details">
                                                <div class="contactlist__details--name">Amanda Sinquefield</div>
                                                <div class="calllist__details--info">
                                                    <span><i class="mdi mdi-tag-outline"></i></span>
                                                    <span>Friends</span>
                                                </div>
                                            </div>

                                            <div class="contactlist__actions">
                                                <div class="iconbox btn-solid-success">
                                                    <i class="iconbox__icon mdi mdi-phone"></i>
                                                </div>
                                                <div class="iconbox btn-solid-info">
                                                    <i class="iconbox__icon mdi mdi-video-outline"></i>
                                                </div>
                                            </div>
                                        </div>
                                    </li>
                                    <li>
                                        <div class="contactlist">
                                            <div class="user-avatar user-avatar-rounded">
                                                <img src="~/lib/images/user/500/04.jpg" alt="">
                                            </div>
                                            <div class="contactlist__details">
                                                <div class="contactlist__details--name">Amanda Sinquefield</div>
                                                <div class="calllist__details--info">
                                                    <span><i class="mdi mdi-tag-outline"></i></span>
                                                    <span>Friends</span>
                                                </div>
                                            </div>

                                            <div class="contactlist__actions">
                                                <div class="iconbox btn-solid-success">
                                                    <i class="iconbox__icon mdi mdi-phone"></i>
                                                </div>
                                                <div class="iconbox btn-solid-info">
                                                    <i class="iconbox__icon mdi mdi-video-outline"></i>
                                                </div>
                                            </div>
                                        </div>
                                    </li>
                                    <li>
                                        <div class="contactlist">
                                            <div class="user-avatar user-avatar-rounded">
                                                <img src="~/lib/images/user/500/04.jpg" alt="">
                                            </div>
                                            <div class="contactlist__details">
                                                <div class="contactlist__details--name">Amanda Sinquefield</div>
                                                <div class="calllist__details--info">
                                                    <span><i class="mdi mdi-tag-outline"></i></span>
                                                    <span>Friends</span>
                                                </div>
                                            </div>

                                            <div class="contactlist__actions">
                                                <div class="iconbox btn-solid-success">
                                                    <i class="iconbox__icon mdi mdi-phone"></i>
                                                </div>
                                                <div class="iconbox btn-solid-info">
                                                    <i class="iconbox__icon mdi mdi-video-outline"></i>
                                                </div>
                                            </div>
                                        </div>
                                    </li>
                                    <li>
                                        <div class="contactlist">
                                            <div class="user-avatar user-avatar-rounded">
                                                <img src="~/lib/images/user/500/04.jpg" alt="">
                                            </div>
                                            <div class="contactlist__details">
                                                <div class="contactlist__details--name">Amanda Sinquefield</div>
                                                <div class="calllist__details--info">
                                                    <span><i class="mdi mdi-tag-outline"></i></span>
                                                    <span>Friends</span>
                                                </div>
                                            </div>

                                            <div class="contactlist__actions">
                                                <div class="iconbox btn-solid-success">
                                                    <i class="iconbox__icon mdi mdi-phone"></i>
                                                </div>
                                                <div class="iconbox btn-solid-info">
                                                    <i class="iconbox__icon mdi mdi-video-outline"></i>
                                                </div>
                                            </div>
                                        </div>
                                    </li>
                                    <li>
                                        <div class="contactlist">
                                            <div class="user-avatar user-avatar-rounded">
                                                <img src="~/lib/images/user/500/04.jpg" alt="">
                                            </div>
                                            <div class="contactlist__details">
                                                <div class="contactlist__details--name">Amanda Sinquefield</div>
                                                <div class="calllist__details--info">
                                                    <span><i class="mdi mdi-tag-outline"></i></span>
                                                    <span>Friends</span>
                                                </div>
                                            </div>

                                            <div class="contactlist__actions">
                                                <div class="iconbox btn-solid-success">
                                                    <i class="iconbox__icon mdi mdi-phone"></i>
                                                </div>
                                                <div class="iconbox btn-solid-info">
                                                    <i class="iconbox__icon mdi mdi-video-outline"></i>
                                                </div>
                                            </div>
                                        </div>
                                    </li>
                                    <li>
                                        <div class="contactlist">
                                            <div class="user-avatar user-avatar-rounded">
                                                <img src="~/lib/images/user/500/04.jpg" alt="">
                                            </div>
                                            <div class="contactlist__details">
                                                <div class="contactlist__details--name">Amanda Sinquefield</div>
                                                <div class="calllist__details--info">
                                                    <span><i class="mdi mdi-tag-outline"></i></span>
                                                    <span>Friends</span>
                                                </div>
                                            </div>

                                            <div class="contactlist__actions">
                                                <div class="iconbox btn-solid-success">
                                                    <i class="iconbox__icon mdi mdi-phone"></i>
                                                </div>
                                                <div class="iconbox btn-solid-info">
                                                    <i class="iconbox__icon mdi mdi-video-outline"></i>
                                                </div>
                                            </div>
                                        </div>
                                    </li>
                                    <li>
                                        <div class="contactlist">
                                            <div class="user-avatar user-avatar-rounded">
                                                <img src="~/lib/images/user/500/04.jpg" alt="">
                                            </div>
                                            <div class="contactlist__details">
                                                <div class="contactlist__details--name">Amanda Sinquefield</div>
                                                <div class="calllist__details--info">
                                                    <span><i class="mdi mdi-tag-outline"></i></span>
                                                    <span>Friends</span>
                                                </div>
                                            </div>

                                            <div class="contactlist__actions">
                                                <div class="iconbox btn-solid-success">
                                                    <i class="iconbox__icon mdi mdi-phone"></i>
                                                </div>
                                                <div class="iconbox btn-solid-info">
                                                    <i class="iconbox__icon mdi mdi-video-outline"></i>
                                                </div>
                                            </div>
                                        </div>
                                    </li>
                                    <li>
                                        <div class="contactlist">
                                            <div class="user-avatar user-avatar-rounded">
                                                <img src="~/lib/images/user/500/04.jpg" alt="">
                                            </div>
                                            <div class="contactlist__details">
                                                <div class="contactlist__details--name">Amanda Sinquefield</div>
                                                <div class="calllist__details--info">
                                                    <span><i class="mdi mdi-tag-outline"></i></span>
                                                    <span>Friends</span>
                                                </div>
                                            </div>

                                            <div class="contactlist__actions">
                                                <div class="iconbox btn-solid-success">
                                                    <i class="iconbox__icon mdi mdi-phone"></i>
                                                </div>
                                                <div class="iconbox btn-solid-info">
                                                    <i class="iconbox__icon mdi mdi-video-outline"></i>
                                                </div>
                                            </div>
                                        </div>
                                    </li>
                                    <li>
                                        <div class="contactlist">
                                            <div class="user-avatar user-avatar-rounded">
                                                <img src="~/lib/images/user/500/04.jpg" alt="">
                                            </div>
                                            <div class="contactlist__details">
                                                <div class="contactlist__details--name">Amanda Sinquefield</div>
                                                <div class="calllist__details--info">
                                                    <span><i class="mdi mdi-tag-outline"></i></span>
                                                    <span>Friends</span>
                                                </div>
                                            </div>

                                            <div class="contactlist__actions">
                                                <div class="iconbox btn-solid-success">
                                                    <i class="iconbox__icon mdi mdi-phone"></i>
                                                </div>
                                                <div class="iconbox btn-solid-info">
                                                    <i class="iconbox__icon mdi mdi-video-outline"></i>
                                                </div>
                                            </div>
                                        </div>
                                    </li>
                                    <li>
                                        <div class="contactlist border-bottom-0">
                                            <div class="user-avatar user-avatar-rounded">
                                                <img src="~/lib/images/user/500/04.jpg" alt="">
                                            </div>
                                            <div class="contactlist__details">
                                                <div class="contactlist__details--name">Amanda Sinquefield</div>
                                                <div class="calllist__details--info">
                                                    <span><i class="mdi mdi-tag-outline"></i></span>
                                                    <span>Friends</span>
                                                </div>
                                            </div>

                                            <div class="contactlist__actions">
                                                <div class="iconbox btn-solid-success">
                                                    <i class="iconbox__icon mdi mdi-phone"></i>
                                                </div>
                                                <div class="iconbox btn-solid-info">
                                                    <i class="iconbox__icon mdi mdi-video-outline"></i>
                                                </div>
                                            </div>
                                        </div>
                                    </li>
                                </ul>
                            </div>
                            <div class="modal-dialpad">
                                <div class="dial-pad-wrap">
                                    <div class="dial-pad">
                                        <div class="dial-screen">+01-(363)-2612</div>
                                        <div class="dial-table">
                                            <div class="dial-table-row">
                                                <div class="dial-table-col">
                                                    <div class="dial-key-wrap" data-key="1">
                                                        <div class="dial-key">1</div>
                                                        <div class="dial-sub-key">&nbsp;</div>
                                                    </div>
                                                </div>
                                                <div class="dial-table-col">
                                                    <div class="dial-key-wrap" data-key="2">
                                                        <div class="dial-key">2</div>
                                                        <div class="dial-sub-key">abc</div>
                                                    </div>
                                                </div>
                                                <div class="dial-table-col">
                                                    <div class="dial-key-wrap" data-key="3">
                                                        <div class="dial-key">3</div>
                                                        <div class="dial-sub-key">def</div>
                                                    </div>
                                                </div>
                                            </div>
                                            <div class="dial-table-row">
                                                <div class="dial-table-col">
                                                    <div class="dial-key-wrap" data-key="4">
                                                        <div class="dial-key">4</div>
                                                        <div class="dial-sub-key">ghi</div>
                                                    </div>
                                                </div>
                                                <div class="dial-table-col">
                                                    <div class="dial-key-wrap" data-key="5">
                                                        <div class="dial-key">5</div>
                                                        <div class="dial-sub-key">jkl</div>
                                                    </div>
                                                </div>
                                                <div class="dial-table-col">
                                                    <div class="dial-key-wrap" data-key="6">
                                                        <div class="dial-key">6</div>
                                                        <div class="dial-sub-key">mno</div>
                                                    </div>
                                                </div>
                                            </div>
                                            <div class="dial-table-row">
                                                <div class="dial-table-col">
                                                    <div class="dial-key-wrap" data-key="7">
                                                        <div class="dial-key">7</div>
                                                        <div class="dial-sub-key">pqrs</div>
                                                    </div>
                                                </div>
                                                <div class="dial-table-col">
                                                    <div class="dial-key-wrap" data-key="8">
                                                        <div class="dial-key">8</div>
                                                        <div class="dial-sub-key">tuv</div>
                                                    </div>
                                                </div>
                                                <div class="dial-table-col">
                                                    <div class="dial-key-wrap" data-key="9">
                                                        <div class="dial-key">9</div>
                                                        <div class="dial-sub-key">wxyz</div>
                                                    </div>
                                                </div>
                                            </div>
                                            <div class="dial-table-row">
                                                <div class="dial-table-col">
                                                    <div class="dial-key-wrap" data-key="*">
                                                        <div class="dial-key">*</div>
                                                        <div class="dial-sub-key">&nbsp;</div>
                                                    </div>
                                                </div>
                                                <div class="dial-table-col">
                                                    <div class="dial-key-wrap" data-key="0">
                                                        <div class="dial-key">0</div>
                                                        <div class="dial-sub-key">+</div>
                                                    </div>
                                                </div>
                                                <div class="dial-table-col">
                                                    <div class="dial-key-wrap" data-key="#">
                                                        <div class="dial-key">#</div>
                                                        <div class="dial-sub-key">&nbsp;</div>
                                                    </div>
                                                </div>
                                            </div>
                                            <div class="dial-table-row no-sub-key">
                                                <div class="dial-table-col">

                                                    <div class="dial-key-wrap" data-key="save-contact">
                                                        <div class="dial-key"><i class="mdi mdi-account-plus-outline"></i></div>
                                                        <div class="dial-sub-key">Call</div>
                                                    </div>
                                                </div>
                                                <div class="dial-table-col">
                                                    <div class="dial-key-wrap" data-key="call">
                                                        <div class="dial-key"><i class="mdi mdi-phone"></i></div>
                                                        <div class="dial-sub-key">Call</div>
                                                    </div>
                                                </div>
                                                <div class="dial-table-col">
                                                    <div class="dial-key-wrap" data-key="back">
                                                        <div class="dial-key"><i class="mdi mdi-arrow-left"></i></div>
                                                        <div class="dial-sub-key">Back</div>
                                                    </div>
                                                </div>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
            <!-- NEW GROUP MODAL -->
            <div class="modal new-group-dialog" id="newGroupModal" tabindex="-1" role="dialog" aria-labelledby="newGroupModal" aria-hidden="true">
                <div class="modal-dialog modal-dialog-centered" role="document">
                    <div class="modal-content">
                        <div class="modal-header">
                            <h6 class="modal-title" id="newGroupModalLabel">Create New Group</h6>
                            <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                                <span aria-hidden="true">&times;</span>
                            </button>
                        </div>
                        <div class="modal-body">
                            <form method="post" id="createGroupForm" enctype="multipart/form-data" asp-action="CreateGroup" asp-controller="Chat">
                                <div class="form-group">
                                    <label for="defaultBaseInput" asp-for="GroupName" class="font-weight-bold">Group Name</label>
                                    <input class="form-control" type="text" asp-for="GroupName" id="GroupName" name="GroupName" required />
                                    <input class="form-control" type="hidden" asp-for="UserId" id="UserId" name="UserId" value="@UserId" />
                                    <div class="sub-main">
                                        @*<button class="button-two"><span>Create</span></button>*@
                                        <button type="submit" class="button-two"><span>Create</span></button>
                                    </div>
                                </div>
                            </form>

                        </div>
                    </div>
                </div>
            </div>
            <!-- ADD MEMBER IN GROUP MODAL -->
            <div class="modal new-group-dialog" id="addMemberModal" tabindex="-1" role="dialog" aria-labelledby="addMemberModal" aria-hidden="true">
                <div class="modal-dialog modal-dialog-centered" role="document">
                    <div class="modal-content">
                        <div class="modal-header">
                            <h6 class="modal-title" id="addMemberModalLabel">Add Members</h6>
                            <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                                <span aria-hidden="true">&times;</span>
                            </button>
                        </div>
                        <div class="modal-body">

                            <div class="searchbar">
                                <div class="input-group">
                                    <input type="text" class="form-control" placeholder="Search" aria-label="Search">
                                    <div class="input-group-append">
                                        <span class="input-group-text dialpad-opener"><i class="mdi mdi-dialpad"></i></span>
                                    </div>
                                </div>
                            </div>
                            <div class="modal-contact-list">
                                <ul class="list-unstyled">
                                    <li>
                                        <div class="contactlist">
                                            <div class="user-avatar user-avatar-rounded">
                                                <img src="~/lib/images/user/500/06.jpg" alt="">
                                            </div>
                                            <div class="contactlist__details">
                                                <div class="contactlist__details--name">Chuck McCann</div>
                                                <div class="calllist__details--info">
                                                    <span><i class="mdi mdi-tag-outline"></i></span>
                                                    <span>Friends</span>
                                                </div>
                                            </div>

                                            <div class="contactlist__actions">
                                                <div class="iconbox btn-solid-info">
                                                    <i class="iconbox__icon mdi mdi-plus"></i>
                                                </div>
                                            </div>
                                        </div>
                                    </li>
                                    <li>
                                        <div class="contactlist">
                                            <div class="user-avatar user-avatar-rounded">
                                                <img src="~/lib/images/user/500/01.jpg" alt="">
                                            </div>
                                            <div class="contactlist__details">
                                                <div class="contactlist__details--name">Pearl Villarreal</div>
                                                <div class="calllist__details--info">
                                                    <span><i class="mdi mdi-tag-outline"></i></span>
                                                    <span>Friends</span>
                                                </div>
                                            </div>

                                            <div class="contactlist__actions">
                                                <div class="iconbox btn-solid-info">
                                                    <i class="iconbox__icon mdi mdi-plus"></i>
                                                </div>
                                            </div>
                                        </div>
                                    </li>
                                    <li>
                                        <div class="contactlist">
                                            <div class="user-avatar user-avatar-rounded">
                                                <img src="~/lib/images/user/500/03.jpg" alt="">
                                            </div>
                                            <div class="contactlist__details">
                                                <div class="contactlist__details--name">Sheila Hawkins</div>
                                                <div class="calllist__details--info">
                                                    <span><i class="mdi mdi-tag-outline"></i></span>
                                                    <span>Friends</span>
                                                </div>
                                            </div>

                                            <div class="contactlist__actions">
                                                <div class="iconbox btn-solid-info">
                                                    <i class="iconbox__icon mdi mdi-plus"></i>
                                                </div>
                                            </div>
                                        </div>
                                    </li>
                                    <li>
                                        <div class="contactlist">
                                            <div class="user-avatar user-avatar-rounded">
                                                <img src="~/lib/images/user/500/04.jpg" alt="">
                                            </div>
                                            <div class="contactlist__details">
                                                <div class="contactlist__details--name">Amanda Sinquefield</div>
                                                <div class="calllist__details--info">
                                                    <span><i class="mdi mdi-tag-outline"></i></span>
                                                    <span>Friends</span>
                                                </div>
                                            </div>

                                            <div class="contactlist__actions">
                                                <div class="iconbox btn-solid-info">
                                                    <i class="iconbox__icon mdi mdi-plus"></i>
                                                </div>
                                            </div>
                                        </div>
                                    </li>
                                    <li>
                                        <div class="contactlist">
                                            <div class="user-avatar user-avatar-rounded">
                                                <img src="~/lib/images/user/500/04.jpg" alt="">
                                            </div>
                                            <div class="contactlist__details">
                                                <div class="contactlist__details--name">Amanda Sinquefield</div>
                                                <div class="calllist__details--info">
                                                    <span><i class="mdi mdi-tag-outline"></i></span>
                                                    <span>Friends</span>
                                                </div>
                                            </div>

                                            <div class="contactlist__actions">
                                                <div class="iconbox btn-solid-info">
                                                    <i class="iconbox__icon mdi mdi-plus"></i>
                                                </div>
                                            </div>
                                        </div>
                                    </li>
                                    <li>
                                        <div class="contactlist">
                                            <div class="user-avatar user-avatar-rounded">
                                                <img src="~/lib/images/user/500/04.jpg" alt="">
                                            </div>
                                            <div class="contactlist__details">
                                                <div class="contactlist__details--name">Amanda Sinquefield</div>
                                                <div class="calllist__details--info">
                                                    <span><i class="mdi mdi-tag-outline"></i></span>
                                                    <span>Friends</span>
                                                </div>
                                            </div>

                                            <div class="contactlist__actions">
                                                <div class="iconbox btn-solid-info">
                                                    <i class="iconbox__icon mdi mdi-plus"></i>
                                                </div>
                                            </div>
                                        </div>
                                    </li>
                                    <li>
                                        <div class="contactlist">
                                            <div class="user-avatar user-avatar-rounded">
                                                <img src="~/lib/images/user/500/04.jpg" alt="">
                                            </div>
                                            <div class="contactlist__details">
                                                <div class="contactlist__details--name">Amanda Sinquefield</div>
                                                <div class="calllist__details--info">
                                                    <span><i class="mdi mdi-tag-outline"></i></span>
                                                    <span>Friends</span>
                                                </div>
                                            </div>

                                            <div class="contactlist__actions">
                                                <div class="iconbox btn-solid-info">
                                                    <i class="iconbox__icon mdi mdi-plus"></i>
                                                </div>
                                            </div>
                                        </div>
                                    </li>
                                    <li>
                                        <div class="contactlist">
                                            <div class="user-avatar user-avatar-rounded">
                                                <img src="~/lib/images/user/500/04.jpg" alt="">
                                            </div>
                                            <div class="contactlist__details">
                                                <div class="contactlist__details--name">Amanda Sinquefield</div>
                                                <div class="calllist__details--info">
                                                    <span><i class="mdi mdi-tag-outline"></i></span>
                                                    <span>Friends</span>
                                                </div>
                                            </div>

                                            <div class="contactlist__actions">
                                                <div class="iconbox btn-solid-info">
                                                    <i class="iconbox__icon mdi mdi-plus"></i>
                                                </div>
                                            </div>
                                        </div>
                                    </li>
                                    <li>
                                        <div class="contactlist">
                                            <div class="user-avatar user-avatar-rounded">
                                                <img src="~/lib/images/user/500/04.jpg" alt="">
                                            </div>
                                            <div class="contactlist__details">
                                                <div class="contactlist__details--name">Amanda Sinquefield</div>
                                                <div class="calllist__details--info">
                                                    <span><i class="mdi mdi-tag-outline"></i></span>
                                                    <span>Friends</span>
                                                </div>
                                            </div>

                                            <div class="contactlist__actions">
                                                <div class="iconbox btn-solid-info">
                                                    <i class="iconbox__icon mdi mdi-plus"></i>
                                                </div>
                                            </div>
                                        </div>
                                    </li>
                                    <li>
                                        <div class="contactlist">
                                            <div class="user-avatar user-avatar-rounded">
                                                <img src="~/lib/images/user/500/04.jpg" alt="">
                                            </div>
                                            <div class="contactlist__details">
                                                <div class="contactlist__details--name">Amanda Sinquefield</div>
                                                <div class="calllist__details--info">
                                                    <span><i class="mdi mdi-tag-outline"></i></span>
                                                    <span>Friends</span>
                                                </div>
                                            </div>

                                            <div class="contactlist__actions">
                                                <div class="iconbox btn-solid-info">
                                                    <i class="iconbox__icon mdi mdi-plus"></i>
                                                </div>
                                            </div>
                                        </div>
                                    </li>
                                    <li>
                                        <div class="contactlist">
                                            <div class="user-avatar user-avatar-rounded">
                                                <img src="~/lib/images/user/500/04.jpg" alt="">
                                            </div>
                                            <div class="contactlist__details">
                                                <div class="contactlist__details--name">Amanda Sinquefield</div>
                                                <div class="calllist__details--info">
                                                    <span><i class="mdi mdi-tag-outline"></i></span>
                                                    <span>Friends</span>
                                                </div>
                                            </div>

                                            <div class="contactlist__actions">
                                                <div class="iconbox btn-solid-info">
                                                    <i class="iconbox__icon mdi mdi-plus"></i>
                                                </div>
                                            </div>
                                        </div>
                                    </li>
                                    <li>
                                        <div class="contactlist">
                                            <div class="user-avatar user-avatar-rounded">
                                                <img src="~/lib/images/user/500/04.jpg" alt="">
                                            </div>
                                            <div class="contactlist__details">
                                                <div class="contactlist__details--name">Amanda Sinquefield</div>
                                                <div class="calllist__details--info">
                                                    <span><i class="mdi mdi-tag-outline"></i></span>
                                                    <span>Friends</span>
                                                </div>
                                            </div>

                                            <div class="contactlist__actions">
                                                <div class="iconbox btn-solid-info">
                                                    <i class="iconbox__icon mdi mdi-plus"></i>
                                                </div>
                                            </div>
                                        </div>
                                    </li>
                                    <li>
                                        <div class="contactlist">
                                            <div class="user-avatar user-avatar-rounded">
                                                <img src="~/lib/images/user/500/04.jpg" alt="">
                                            </div>
                                            <div class="contactlist__details">
                                                <div class="contactlist__details--name">Amanda Sinquefield</div>
                                                <div class="calllist__details--info">
                                                    <span><i class="mdi mdi-tag-outline"></i></span>
                                                    <span>Friends</span>
                                                </div>
                                            </div>

                                            <div class="contactlist__actions">
                                                <div class="iconbox btn-solid-info">
                                                    <i class="iconbox__icon mdi mdi-plus"></i>
                                                </div>
                                            </div>
                                        </div>
                                    </li>
                                    <li>
                                        <div class="contactlist">
                                            <div class="user-avatar user-avatar-rounded">
                                                <img src="~/lib/images/user/500/04.jpg" alt="">
                                            </div>
                                            <div class="contactlist__details">
                                                <div class="contactlist__details--name">Amanda Sinquefield</div>
                                                <div class="calllist__details--info">
                                                    <span><i class="mdi mdi-tag-outline"></i></span>
                                                    <span>Friends</span>
                                                </div>
                                            </div>

                                            <div class="contactlist__actions">
                                                <div class="iconbox btn-solid-info">
                                                    <i class="iconbox__icon mdi mdi-plus"></i>
                                                </div>
                                            </div>
                                        </div>
                                    </li>
                                    <li>
                                        <div class="contactlist border-bottom-0">
                                            <div class="user-avatar user-avatar-rounded">
                                                <img src="~/lib/images/user/500/04.jpg" alt="">
                                            </div>
                                            <div class="contactlist__details">
                                                <div class="contactlist__details--name">Amanda Sinquefield</div>
                                                <div class="calllist__details--info">
                                                    <span><i class="mdi mdi-tag-outline"></i></span>
                                                    <span>Friends</span>
                                                </div>
                                            </div>

                                            <div class="contactlist__actions">
                                                <div class="iconbox btn-solid-info">
                                                    <i class="iconbox__icon mdi mdi-plus"></i>
                                                </div>
                                            </div>
                                        </div>
                                    </li>
                                </ul>
                            </div>
                            <div class="modal-dialpad">
                                <div class="dial-pad-wrap">
                                    <div class="dial-pad">
                                        <div class="dial-screen">+01-(363)-2612</div>
                                        <div class="dial-table">
                                            <div class="dial-table-row">
                                                <div class="dial-table-col">
                                                    <div class="dial-key-wrap" data-key="1">
                                                        <div class="dial-key">1</div>
                                                        <div class="dial-sub-key">&nbsp;</div>
                                                    </div>
                                                </div>
                                                <div class="dial-table-col">
                                                    <div class="dial-key-wrap" data-key="2">
                                                        <div class="dial-key">2</div>
                                                        <div class="dial-sub-key">abc</div>
                                                    </div>
                                                </div>
                                                <div class="dial-table-col">
                                                    <div class="dial-key-wrap" data-key="3">
                                                        <div class="dial-key">3</div>
                                                        <div class="dial-sub-key">def</div>
                                                    </div>
                                                </div>
                                            </div>
                                            <div class="dial-table-row">
                                                <div class="dial-table-col">
                                                    <div class="dial-key-wrap" data-key="4">
                                                        <div class="dial-key">4</div>
                                                        <div class="dial-sub-key">ghi</div>
                                                    </div>
                                                </div>
                                                <div class="dial-table-col">
                                                    <div class="dial-key-wrap" data-key="5">
                                                        <div class="dial-key">5</div>
                                                        <div class="dial-sub-key">jkl</div>
                                                    </div>
                                                </div>
                                                <div class="dial-table-col">
                                                    <div class="dial-key-wrap" data-key="6">
                                                        <div class="dial-key">6</div>
                                                        <div class="dial-sub-key">mno</div>
                                                    </div>
                                                </div>
                                            </div>
                                            <div class="dial-table-row">
                                                <div class="dial-table-col">
                                                    <div class="dial-key-wrap" data-key="7">
                                                        <div class="dial-key">7</div>
                                                        <div class="dial-sub-key">pqrs</div>
                                                    </div>
                                                </div>
                                                <div class="dial-table-col">
                                                    <div class="dial-key-wrap" data-key="8">
                                                        <div class="dial-key">8</div>
                                                        <div class="dial-sub-key">tuv</div>
                                                    </div>
                                                </div>
                                                <div class="dial-table-col">
                                                    <div class="dial-key-wrap" data-key="9">
                                                        <div class="dial-key">9</div>
                                                        <div class="dial-sub-key">wxyz</div>
                                                    </div>
                                                </div>
                                            </div>
                                            <div class="dial-table-row">
                                                <div class="dial-table-col">
                                                    <div class="dial-key-wrap" data-key="*">
                                                        <div class="dial-key">*</div>
                                                        <div class="dial-sub-key">&nbsp;</div>
                                                    </div>
                                                </div>
                                                <div class="dial-table-col">
                                                    <div class="dial-key-wrap" data-key="0">
                                                        <div class="dial-key">0</div>
                                                        <div class="dial-sub-key">+</div>
                                                    </div>
                                                </div>
                                                <div class="dial-table-col">
                                                    <div class="dial-key-wrap" data-key="#">
                                                        <div class="dial-key">#</div>
                                                        <div class="dial-sub-key">&nbsp;</div>
                                                    </div>
                                                </div>
                                            </div>
                                            <div class="dial-table-row no-sub-key">
                                                <div class="dial-table-col">

                                                    <div class="dial-key-wrap" data-key="save-contact">
                                                        <div class="dial-key"><i class="mdi mdi-account-plus-outline"></i></div>
                                                        <div class="dial-sub-key">Call</div>
                                                    </div>
                                                </div>
                                                <div class="dial-table-col">
                                                    <div class="dial-key-wrap" data-key="call">
                                                        <div class="dial-key"><i class="mdi mdi-plus-circle-outline"></i></div>
                                                        <div class="dial-sub-key">Call</div>
                                                    </div>
                                                </div>
                                                <div class="dial-table-col">
                                                    <div class="dial-key-wrap" data-key="back">
                                                        <div class="dial-key"><i class="mdi mdi-arrow-left"></i></div>
                                                        <div class="dial-sub-key">Back</div>
                                                    </div>
                                                </div>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
            <!-- INVITE PEOPLE -->
            <div class="modal new-group-dialog" id="invitePeopleModal" tabindex="-1" role="dialog" aria-labelledby="invitePeopleModal" aria-hidden="true">
                <div class="modal-dialog modal-dialog-centered" role="document">
                    <div class="modal-content">
                        <div class="modal-header">
                            <h6 class="modal-title" id="invitePeopleModalLabel">Invite Members</h6>
                            <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                                <span aria-hidden="true">&times;</span>
                            </button>
                        </div>
                        <div class="modal-body">

                            <div class="searchbar">
                                <div class="input-group">
                                    <input type="text" class="form-control" placeholder="Search" aria-label="Search">
                                    <div class="input-group-append">
                                        <span class="input-group-text dialpad-opener"><i class="mdi mdi-dialpad"></i></span>
                                    </div>
                                </div>
                            </div>
                            <div class="modal-contact-list">
                                <ul class="list-unstyled">
                                    <li>
                                        <div class="contactlist">
                                            <div class="user-avatar user-avatar-rounded">
                                                <img src="~/lib/images/user/500/06.jpg" alt="">
                                            </div>
                                            <div class="contactlist__details">
                                                <div class="contactlist__details--name">Chuck McCann</div>
                                                <div class="calllist__details--info">
                                                    <span><i class="mdi mdi-tag-outline"></i></span>
                                                    <span>Friends</span>
                                                </div>
                                            </div>

                                            <div class="contactlist__actions">
                                                <div class="iconbox btn-solid-info">
                                                    <i class="iconbox__icon mdi mdi-plus"></i>
                                                </div>
                                            </div>
                                        </div>
                                    </li>
                                    <li>
                                        <div class="contactlist">
                                            <div class="user-avatar user-avatar-rounded">
                                                <img src="~/lib/images/user/500/01.jpg" alt="">
                                            </div>
                                            <div class="contactlist__details">
                                                <div class="contactlist__details--name">Pearl Villarreal</div>
                                                <div class="calllist__details--info">
                                                    <span><i class="mdi mdi-tag-outline"></i></span>
                                                    <span>Friends</span>
                                                </div>
                                            </div>

                                            <div class="contactlist__actions">
                                                <div class="iconbox btn-solid-info">
                                                    <i class="iconbox__icon mdi mdi-plus"></i>
                                                </div>
                                            </div>
                                        </div>
                                    </li>
                                    <li>
                                        <div class="contactlist">
                                            <div class="user-avatar user-avatar-rounded">
                                                <img src="~/lib/images/user/500/03.jpg" alt="">
                                            </div>
                                            <div class="contactlist__details">
                                                <div class="contactlist__details--name">Sheila Hawkins</div>
                                                <div class="calllist__details--info">
                                                    <span><i class="mdi mdi-tag-outline"></i></span>
                                                    <span>Friends</span>
                                                </div>
                                            </div>

                                            <div class="contactlist__actions">
                                                <div class="iconbox btn-solid-info">
                                                    <i class="iconbox__icon mdi mdi-plus"></i>
                                                </div>
                                            </div>
                                        </div>
                                    </li>
                                    <li>
                                        <div class="contactlist">
                                            <div class="user-avatar user-avatar-rounded">
                                                <img src="~/lib/images/user/500/04.jpg" alt="">
                                            </div>
                                            <div class="contactlist__details">
                                                <div class="contactlist__details--name">Amanda Sinquefield</div>
                                                <div class="calllist__details--info">
                                                    <span><i class="mdi mdi-tag-outline"></i></span>
                                                    <span>Friends</span>
                                                </div>
                                            </div>

                                            <div class="contactlist__actions">
                                                <div class="iconbox btn-solid-info">
                                                    <i class="iconbox__icon mdi mdi-plus"></i>
                                                </div>
                                            </div>
                                        </div>
                                    </li>
                                    <li>
                                        <div class="contactlist">
                                            <div class="user-avatar user-avatar-rounded">
                                                <img src="~/lib/images/user/500/04.jpg" alt="">
                                            </div>
                                            <div class="contactlist__details">
                                                <div class="contactlist__details--name">Amanda Sinquefield</div>
                                                <div class="calllist__details--info">
                                                    <span><i class="mdi mdi-tag-outline"></i></span>
                                                    <span>Friends</span>
                                                </div>
                                            </div>

                                            <div class="contactlist__actions">
                                                <div class="iconbox btn-solid-info">
                                                    <i class="iconbox__icon mdi mdi-plus"></i>
                                                </div>
                                            </div>
                                        </div>
                                    </li>
                                    <li>
                                        <div class="contactlist">
                                            <div class="user-avatar user-avatar-rounded">
                                                <img src="~/lib/images/user/500/04.jpg" alt="">
                                            </div>
                                            <div class="contactlist__details">
                                                <div class="contactlist__details--name">Amanda Sinquefield</div>
                                                <div class="calllist__details--info">
                                                    <span><i class="mdi mdi-tag-outline"></i></span>
                                                    <span>Friends</span>
                                                </div>
                                            </div>

                                            <div class="contactlist__actions">
                                                <div class="iconbox btn-solid-info">
                                                    <i class="iconbox__icon mdi mdi-plus"></i>
                                                </div>
                                            </div>
                                        </div>
                                    </li>
                                    <li>
                                        <div class="contactlist">
                                            <div class="user-avatar user-avatar-rounded">
                                                <img src="~/lib/images/user/500/04.jpg" alt="">
                                            </div>
                                            <div class="contactlist__details">
                                                <div class="contactlist__details--name">Amanda Sinquefield</div>
                                                <div class="calllist__details--info">
                                                    <span><i class="mdi mdi-tag-outline"></i></span>
                                                    <span>Friends</span>
                                                </div>
                                            </div>

                                            <div class="contactlist__actions">
                                                <div class="iconbox btn-solid-info">
                                                    <i class="iconbox__icon mdi mdi-plus"></i>
                                                </div>
                                            </div>
                                        </div>
                                    </li>
                                    <li>
                                        <div class="contactlist">
                                            <div class="user-avatar user-avatar-rounded">
                                                <img src="~/lib/images/user/500/04.jpg" alt="">
                                            </div>
                                            <div class="contactlist__details">
                                                <div class="contactlist__details--name">Amanda Sinquefield</div>
                                                <div class="calllist__details--info">
                                                    <span><i class="mdi mdi-tag-outline"></i></span>
                                                    <span>Friends</span>
                                                </div>
                                            </div>

                                            <div class="contactlist__actions">
                                                <div class="iconbox btn-solid-info">
                                                    <i class="iconbox__icon mdi mdi-plus"></i>
                                                </div>
                                            </div>
                                        </div>
                                    </li>
                                    <li>
                                        <div class="contactlist">
                                            <div class="user-avatar user-avatar-rounded">
                                                <img src="~/lib/images/user/500/04.jpg" alt="">
                                            </div>
                                            <div class="contactlist__details">
                                                <div class="contactlist__details--name">Amanda Sinquefield</div>
                                                <div class="calllist__details--info">
                                                    <span><i class="mdi mdi-tag-outline"></i></span>
                                                    <span>Friends</span>
                                                </div>
                                            </div>

                                            <div class="contactlist__actions">
                                                <div class="iconbox btn-solid-info">
                                                    <i class="iconbox__icon mdi mdi-plus"></i>
                                                </div>
                                            </div>
                                        </div>
                                    </li>
                                    <li>
                                        <div class="contactlist">
                                            <div class="user-avatar user-avatar-rounded">
                                                <img src="~/lib/images/user/500/04.jpg" alt="">
                                            </div>
                                            <div class="contactlist__details">
                                                <div class="contactlist__details--name">Amanda Sinquefield</div>
                                                <div class="calllist__details--info">
                                                    <span><i class="mdi mdi-tag-outline"></i></span>
                                                    <span>Friends</span>
                                                </div>
                                            </div>

                                            <div class="contactlist__actions">
                                                <div class="iconbox btn-solid-info">
                                                    <i class="iconbox__icon mdi mdi-plus"></i>
                                                </div>
                                            </div>
                                        </div>
                                    </li>
                                    <li>
                                        <div class="contactlist">
                                            <div class="user-avatar user-avatar-rounded">
                                                <img src="~/lib/images/user/500/04.jpg" alt="">
                                            </div>
                                            <div class="contactlist__details">
                                                <div class="contactlist__details--name">Amanda Sinquefield</div>
                                                <div class="calllist__details--info">
                                                    <span><i class="mdi mdi-tag-outline"></i></span>
                                                    <span>Friends</span>
                                                </div>
                                            </div>

                                            <div class="contactlist__actions">
                                                <div class="iconbox btn-solid-info">
                                                    <i class="iconbox__icon mdi mdi-plus"></i>
                                                </div>
                                            </div>
                                        </div>
                                    </li>
                                    <li>
                                        <div class="contactlist">
                                            <div class="user-avatar user-avatar-rounded">
                                                <img src="~/lib/images/user/500/04.jpg" alt="">
                                            </div>
                                            <div class="contactlist__details">
                                                <div class="contactlist__details--name">Amanda Sinquefield</div>
                                                <div class="calllist__details--info">
                                                    <span><i class="mdi mdi-tag-outline"></i></span>
                                                    <span>Friends</span>
                                                </div>
                                            </div>

                                            <div class="contactlist__actions">
                                                <div class="iconbox btn-solid-info">
                                                    <i class="iconbox__icon mdi mdi-plus"></i>
                                                </div>
                                            </div>
                                        </div>
                                    </li>
                                    <li>
                                        <div class="contactlist">
                                            <div class="user-avatar user-avatar-rounded">
                                                <img src="~/lib/images/user/500/04.jpg" alt="">
                                            </div>
                                            <div class="contactlist__details">
                                                <div class="contactlist__details--name">Amanda Sinquefield</div>
                                                <div class="calllist__details--info">
                                                    <span><i class="mdi mdi-tag-outline"></i></span>
                                                    <span>Friends</span>
                                                </div>
                                            </div>

                                            <div class="contactlist__actions">
                                                <div class="iconbox btn-solid-info">
                                                    <i class="iconbox__icon mdi mdi-plus"></i>
                                                </div>
                                            </div>
                                        </div>
                                    </li>
                                    <li>
                                        <div class="contactlist">
                                            <div class="user-avatar user-avatar-rounded">
                                                <img src="~/lib/images/user/500/04.jpg" alt="">
                                            </div>
                                            <div class="contactlist__details">
                                                <div class="contactlist__details--name">Amanda Sinquefield</div>
                                                <div class="calllist__details--info">
                                                    <span><i class="mdi mdi-tag-outline"></i></span>
                                                    <span>Friends</span>
                                                </div>
                                            </div>

                                            <div class="contactlist__actions">
                                                <div class="iconbox btn-solid-info">
                                                    <i class="iconbox__icon mdi mdi-plus"></i>
                                                </div>
                                            </div>
                                        </div>
                                    </li>
                                    <li>
                                        <div class="contactlist border-bottom-0">
                                            <div class="user-avatar user-avatar-rounded">
                                                <img src="~/lib/images/user/500/04.jpg" alt="">
                                            </div>
                                            <div class="contactlist__details">
                                                <div class="contactlist__details--name">Amanda Sinquefield</div>
                                                <div class="calllist__details--info">
                                                    <span><i class="mdi mdi-tag-outline"></i></span>
                                                    <span>Friends</span>
                                                </div>
                                            </div>

                                            <div class="contactlist__actions">
                                                <div class="iconbox btn-solid-info">
                                                    <i class="iconbox__icon mdi mdi-plus"></i>
                                                </div>
                                            </div>
                                        </div>
                                    </li>
                                </ul>
                            </div>
                            <div class="modal-dialpad">
                                <div class="dial-pad-wrap">
                                    <div class="dial-pad">
                                        <div class="dial-screen">+01-(363)-2612</div>
                                        <div class="dial-table">
                                            <div class="dial-table-row">
                                                <div class="dial-table-col">
                                                    <div class="dial-key-wrap" data-key="1">
                                                        <div class="dial-key">1</div>
                                                        <div class="dial-sub-key">&nbsp;</div>
                                                    </div>
                                                </div>
                                                <div class="dial-table-col">
                                                    <div class="dial-key-wrap" data-key="2">
                                                        <div class="dial-key">2</div>
                                                        <div class="dial-sub-key">abc</div>
                                                    </div>
                                                </div>
                                                <div class="dial-table-col">
                                                    <div class="dial-key-wrap" data-key="3">
                                                        <div class="dial-key">3</div>
                                                        <div class="dial-sub-key">def</div>
                                                    </div>
                                                </div>
                                            </div>
                                            <div class="dial-table-row">
                                                <div class="dial-table-col">
                                                    <div class="dial-key-wrap" data-key="4">
                                                        <div class="dial-key">4</div>
                                                        <div class="dial-sub-key">ghi</div>
                                                    </div>
                                                </div>
                                                <div class="dial-table-col">
                                                    <div class="dial-key-wrap" data-key="5">
                                                        <div class="dial-key">5</div>
                                                        <div class="dial-sub-key">jkl</div>
                                                    </div>
                                                </div>
                                                <div class="dial-table-col">
                                                    <div class="dial-key-wrap" data-key="6">
                                                        <div class="dial-key">6</div>
                                                        <div class="dial-sub-key">mno</div>
                                                    </div>
                                                </div>
                                            </div>
                                            <div class="dial-table-row">
                                                <div class="dial-table-col">
                                                    <div class="dial-key-wrap" data-key="7">
                                                        <div class="dial-key">7</div>
                                                        <div class="dial-sub-key">pqrs</div>
                                                    </div>
                                                </div>
                                                <div class="dial-table-col">
                                                    <div class="dial-key-wrap" data-key="8">
                                                        <div class="dial-key">8</div>
                                                        <div class="dial-sub-key">tuv</div>
                                                    </div>
                                                </div>
                                                <div class="dial-table-col">
                                                    <div class="dial-key-wrap" data-key="9">
                                                        <div class="dial-key">9</div>
                                                        <div class="dial-sub-key">wxyz</div>
                                                    </div>
                                                </div>
                                            </div>
                                            <div class="dial-table-row">
                                                <div class="dial-table-col">
                                                    <div class="dial-key-wrap" data-key="*">
                                                        <div class="dial-key">*</div>
                                                        <div class="dial-sub-key">&nbsp;</div>
                                                    </div>
                                                </div>
                                                <div class="dial-table-col">
                                                    <div class="dial-key-wrap" data-key="0">
                                                        <div class="dial-key">0</div>
                                                        <div class="dial-sub-key">+</div>
                                                    </div>
                                                </div>
                                                <div class="dial-table-col">
                                                    <div class="dial-key-wrap" data-key="#">
                                                        <div class="dial-key">#</div>
                                                        <div class="dial-sub-key">&nbsp;</div>
                                                    </div>
                                                </div>
                                            </div>
                                            <div class="dial-table-row no-sub-key">
                                                <div class="dial-table-col">

                                                    <div class="dial-key-wrap" data-key="save-contact">
                                                        <div class="dial-key"><i class="mdi mdi-account-plus-outline"></i></div>
                                                        <div class="dial-sub-key">Call</div>
                                                    </div>
                                                </div>
                                                <div class="dial-table-col">
                                                    <div class="dial-key-wrap" data-key="call">
                                                        <div class="dial-key"><i class="mdi mdi-plus-circle-outline"></i></div>
                                                        <div class="dial-sub-key">Call</div>
                                                    </div>
                                                </div>
                                                <div class="dial-table-col">
                                                    <div class="dial-key-wrap" data-key="back">
                                                        <div class="dial-key"><i class="mdi mdi-arrow-left"></i></div>
                                                        <div class="dial-sub-key">Back</div>
                                                    </div>
                                                </div>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>

        <!-- VIEW PROFILE MODAL -->
        <div class="modal profile-dialog" id="viewProfileModal" tabindex="-1" role="dialog" aria-labelledby="viewProfileModal" aria-hidden="true">
            @Html.RenderAction("ProfileView", "Chat", new { UserId = UserId });
        </div>

        <!-- THEME MODAL -->
        <div class="modal new-group-dialog" id="themeModal" tabindex="-1" role="dialog" aria-labelledby="themeModal" aria-hidden="true">
            <div class="modal-dialog modal-dialog-centered" role="document">
                <div class="modal-content">
                    <div class="modal-header">
                        <h6 class="modal-title" id="themeModalLabel">Theme</h6>
                        <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                            <span aria-hidden="true">&times;</span>
                        </button>
                    </div>
                    <div class="modal-body">
                        <h6 class="border-bottom pb-2">Light Theme</h6>
                        <div class="d-flex flex-wrap">
                            <a href="javascript:;" data-theme="light-default-theme" class="theme default-theme selected"></a>
                            <a href="javascript:;" data-theme="light-purple-theme" class="theme purple-theme"></a>
                            <a href="javascript:;" data-theme="light-pink-theme" class="theme pink-theme"></a>
                            <a href="javascript:;" data-theme="light-green-theme" class="theme green-theme"></a>
                            <a href="javascript:;" data-theme="light-red-theme" class="theme red-theme"></a>
                            <a href="javascript:;" data-theme="light-orange-theme" class="theme orange-theme"></a>
                            <a href="javascript:;" data-theme="light-blue-theme" class="theme blue-theme"></a>
                            <a href="javascript:;" data-theme="light-darkblue-theme" class="theme darkblue-theme"></a>
                            <a href="javascript:;" data-theme="light-lightpink-theme" class="theme lightpink-theme"></a>
                        </div>
                        <h6 class="border-bottom py-3">Dark Theme</h6>
                        <div class="d-flex flex-wrap">
                            <a href="javascript:;" data-theme="dark-default-theme" class="theme default-theme"></a>
                            <a href="javascript:;" data-theme="dark-purple-theme" class="theme purple-theme"></a>
                            <a href="javascript:;" data-theme="dark-pink-theme" class="theme pink-theme"></a>
                            <a href="javascript:;" data-theme="dark-green-theme" class="theme green-theme"></a>
                            <a href="javascript:;" data-theme="dark-red-theme" class="theme red-theme"></a>
                            <a href="javascript:;" data-theme="dark-orange-theme" class="theme orange-theme"></a>
                            <a href="javascript:;" data-theme="dark-blue-theme" class="theme blue-theme"></a>
                            <a href="javascript:;" data-theme="dark-darkblue-theme" class="theme darkblue-theme"></a>
                            <a href="javascript:;" data-theme="dark-lightpink-theme" class="theme lightpink-theme"></a>
                        </div>

                        <h6 class="border-bottom py-3">RTL Layout</h6>
                        <label class="material-switch">
                            <input type="checkbox" class="rtlSwitch">
                            <span></span>
                        </label>
                    </div>
                </div>
            </div>
        </div>

        <!-- THEME CUSTOMIZER -->
        <div class="theme-customizer">
            <div class="theme-customizer-opener">
                <i class="theme-customizer-icon mdi mdi-settings"></i>
            </div>

            <div class="theme-customizer-content">
                <h6 class="border-bottom pb-2">Light Theme</h6>
                <div class="d-flex flex-wrap">
                    <a href="javascript:;" data-theme="light-default-theme" class="theme default-theme selected"></a>
                    <a href="javascript:;" data-theme="light-purple-theme" class="theme purple-theme"></a>
                    <a href="javascript:;" data-theme="light-pink-theme" class="theme pink-theme"></a>
                    <a href="javascript:;" data-theme="light-green-theme" class="theme green-theme"></a>
                    <a href="javascript:;" data-theme="light-red-theme" class="theme red-theme"></a>
                    <a href="javascript:;" data-theme="light-orange-theme" class="theme orange-theme"></a>
                    <a href="javascript:;" data-theme="light-blue-theme" class="theme blue-theme"></a>
                    <a href="javascript:;" data-theme="light-darkblue-theme" class="theme darkblue-theme"></a>
                    <a href="javascript:;" data-theme="light-lightpink-theme" class="theme lightpink-theme"></a>
                </div>
                <h6 class="border-bottom py-3">Dark Theme</h6>
                <div class="d-flex flex-wrap">
                    <a href="javascript:;" data-theme="dark-default-theme" class="theme default-theme"></a>
                    <a href="javascript:;" data-theme="dark-purple-theme" class="theme purple-theme"></a>
                    <a href="javascript:;" data-theme="dark-pink-theme" class="theme pink-theme"></a>
                    <a href="javascript:;" data-theme="dark-green-theme" class="theme green-theme"></a>
                    <a href="javascript:;" data-theme="dark-red-theme" class="theme red-theme"></a>
                    <a href="javascript:;" data-theme="dark-orange-theme" class="theme orange-theme"></a>
                    <a href="javascript:;" data-theme="dark-blue-theme" class="theme blue-theme"></a>
                    <a href="javascript:;" data-theme="dark-darkblue-theme" class="theme darkblue-theme"></a>
                    <a href="javascript:;" data-theme="dark-lightpink-theme" class="theme lightpink-theme"></a>
                </div>

                <h6 class="border-bottom py-3">RTL Layout</h6>
                <label class="material-switch">
                    <input type="checkbox" class="rtlSwitch">
                    <span></span>
                </label>
            </div>
        </div>

        <div class="backdrop-overlay hidden"></div>
    </div>
</div>


@section scripts{
    <script src="~/js/customsignalr.js"></script>
    <script src="https://cdnjs.cloudflare.com/ajax/libs/jquery-ajax-unobtrusive/3.2.6/jquery.unobtrusive-ajax.js" integrity="sha512-f04GBpoqEZhbyjlRTuXeg8FIHDb+xfCJ0LVdqiN1fEl5B3jz3Z0SPe9IxDumOVdTeeXmKMcMJhb26VuGf1Laqw==" crossorigin="anonymous" referrerpolicy="no-referrer"></script>
    <script>
        $(document).ready(function () {
            $('#personal-chat-tab').click(function () {
                $('#personal')[0].click()
            });
        });

        $(document).ready(function () {
            $('#groups-chat-tab').click(function () {
                $('#group')[0].click()
            });
        });

    </script>

    @*<script src="~/Scripts/jquery-1.10.2.min.js"></script>*@
    @*<script src="~/lib/vendors/jquery/jquery-3.4.1.min.js"></script>*@
    @*<script src="~/Scripts/jquery-2.2.4.min.js"></script>*@

    <script>
        //$(document).ready(function () {
        //    getAll();
        //    //setInterval(getAllMessage, 5000);
        //    //setInterval(getAll, 9000);
        ////    connection.start().catch(err => console.error(err.toString()));
        ////    if (connection.state === signalR.HubConnectionState.Connected) {
        ////        console.log('connectedt to signalr custom');
        ////        connection.invoke("SendUserStatus").catch(function (err) {
        ////            return console.error(err.toString());
        ////        });
        ////    }
        //});

        //connection.start().then(function () {
        //    document.getElementById("sendButton").disabled = false;
        //}).catch(function (err) {
        //    return console.error(err.toString());
        //});
        //setInterval(getAllMessage(), 5000);


        $(document).ready(function () {

            getAll();
            connection.on("UserConnected", function (connectionId, userID) {
                console.log('from chathome my id is :' + connectionId);
                console.log('from chathome my user id is :' + userID);
                var count = $('#hdnCount').val();
                for (let i = 0; i < count; i++) {
                    var chatUserID = $('#hdnPersonalChatUserId_' + i + '').val();
                    console.log('chat user online:' + parseInt(chatUserID));
                    console.log('user online:' + parseInt(userID));
                    if (parseInt(userID) == parseInt(chatUserID)) {
                        console.log('final user online:' + parseInt(chatUserID));
                        $('#userStatusId_' + i + '').attr('class', 'user-avatar user-avatar-rounded online');
                    }
                }
            });

            connection.on("UserDisconnected", function (connectionId, userID) {
                var count = $('#hdnCount').val();
                for (let i = 0; i < count; i++) {
                    var chatUserID = $('#hdnPersonalChatUserId_' + i + '').val();
                    console.log('chat user offline:' + parseInt(chatUserID));
                    console.log('user offline:' + parseInt(userID));
                    if (parseInt(userID) == parseInt(chatUserID)) {
                        console.log('final user online:' + parseInt(chatUserID));
                        $('#userStatusId_' + i + '').attr('class', 'user-avatar user-avatar-rounded offline');
                    }
                }
            });

            //setTimeout(getAll, 4);
            //setInterval(getAll, 9000);
            connection.on("ActiveInactiveUser", function () {
                //getAll();
            });

            connection.on("SendMessageToUser", function (connectionId, ChatUserId, UserId, Message) {
                console.log('from chathome send message to user calling: ' + connectionId);
                console.log('from chathome send message to user calling chat userid : ' + ChatUserId);
                console.log('from chathome send message to user calling userid : ' + UserId);
                //if (UserId == parseInt($('#hdnChatUserId').val())) {
                //    var today = new Date();
                //    var h = today.getHours();
                //    var m = today.getMinutes();
                //    var messageTime = today.getHours() + ":" + today.getMinutes();
                //    var message = Message;
                //    var messageReceiveHtml = '<div class="ca-received">            <div class="user-avatar user-avatar-sm user-avatar-rounded online">                <img src="/lib/images/user/250/01.jpg" alt="">            </div>            <div class="ca-received__msg-group">                <div class="ca-received__msgwrapper">                    <div class="ca-received__msg">' + message + '</div>                    <div class="ca-msg-actions">                        <div class="iconbox-dropdown dropdown">                            <div class="iconbox btn-hovered-light" id="dropdownMenuButtonsr1" role="button" data-toggle="dropdown" aria-haspopup="true" aria-expanded="false">                                <i class="iconbox__icon mdi mdi-dots-horizontal"></i>                            </div>                            <div class="dropdown-menu" aria-labelledby="dropdownMenuButtonsr1">                                <a class="dropdown-item" href="javascript:;">                                    <span><i class="mdi mdi-share-outline"></i></span>                                    <span>Forward</span>                                </a>                                <a class="dropdown-item" href="javascript:;">                                    <span><i class="mdi mdi-content-copy"></i></span>                                    <span>Copy</span>                                </a>                                <a class="dropdown-item" href="javascript:;">                                    <span><i class="mdi mdi-star-outline"></i></span>                                    <span>Add Star</span>                                </a>                                <a class="dropdown-item" href="javascript:;">                                    <span><i class="mdi mdi-trash-can-outline"></i></span>                                    <span>Delete</span>                                </a>                            </div>                        </div>                    </div>                </div>                <div class="metadata">                    <span class="time">' + messageTime + '</span>                </div>            </div>        </div>';
                //    $("#htmlMessageId").append(messageReceiveHtml);
                //    $(document).ready(function () {
                //        $('.conversation-panel__body').animate({
                //            scrollTop: $('.conversation-panel__body')[0].scrollHeight
                //        }, 40);
                //    });
                //}
                getAll();
                getAllMessage();
            });

            // for group chat related signalr connection
            connection.on("SendMessageToGrp", function (GroupName) {
                console.log('home new grp name calling: ' + GroupName);
                console.log('home old grp name calling: ' + $('#hdnGrpName').val());
                if (GroupName == $('#hdnGrpName').val()) {
                    console.log('home i am called....');
                    getAllGrpMessage();
                }
                getGrpAll();
            });

            connection.on("AddIntoGroup", function (connectionId) {
                getGrpAll();
                getAllGrpMessage();
            });
        });

        function getAll() {
            var userID = $('#hdnUserId').val();
            var model = $('#caChatsTabInsideContent');
            $.ajax({
                url: "../Chat/PersonalChat?UserId=" + userID + "&UserName=''",
                //url: "http://50.21.182.225/aspdontnetcoredemo/Chat/PersonalChat?UserId=" + userID + "&UserName=''",
                contentType: 'application/html ; charset:utf-8',
                type: 'GET',
                dataType: 'html',
                success: function (result) { model.empty().append(result); }
            });
        }
        function getGrpAll() {
            var userID = $('#hdnUserId').val();
            var model = $('#caChatsTabInsideContent');
            $.ajax({
                url: "../Chat/GroupChat?UserId=" + userID + "&GroupName=''",
                //url: "http://50.21.182.225/aspdontnetcoredemo/Chat/PersonalChat?UserId=" + userID + "&UserName=''",
                contentType: 'application/html ; charset:utf-8',
                type: 'GET',
                dataType: 'html',
                success: function (result) { model.empty().append(result); }
            });
        }

//function getAllMessage() {
//    var userID = $('#hdnUserId').val();
//    var chatUserID = $('#hdnChatUserId').val();
//    var chatUserName = $('#hdnChatUserName').val();
//    var lastseen = $('#hdnLastseen').val();
//    $.ajax({
//        url: "/Chat/ConversationPanel?UserId=" + userID + "&ChatUserId=" + chatUserID + "&ChatUserName=" + chatUserName + "&Lastseen=" + lastseen + "&Message=" + "",
//        contentType: 'application/html ; charset:utf-8',
//        type: 'GET',
//        dataType: 'html',
//        success: function (result) { console.log("i am calling..") }
//    });
//}
    </script>
}

