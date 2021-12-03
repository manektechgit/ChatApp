#pragma checksum "D:\Gitlab Projects\dotnetdemomvc\DotNetCoreMVCDemos\Views\Chat\_GroupChat.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "ecb5ace71bf1dfa47b1e84bf25dcf4ccbb1a4241"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Chat__GroupChat), @"mvc.1.0.view", @"/Views/Chat/_GroupChat.cshtml")]
namespace AspNetCore
{
    #line hidden
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.Rendering;
    using Microsoft.AspNetCore.Mvc.ViewFeatures;
#nullable restore
#line 1 "D:\Gitlab Projects\dotnetdemomvc\DotNetCoreMVCDemos\Views\_ViewImports.cshtml"
using DotNetCoreMVCDemos;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "D:\Gitlab Projects\dotnetdemomvc\DotNetCoreMVCDemos\Views\_ViewImports.cshtml"
using DotNetCoreMVCDemos.Models;

#line default
#line hidden
#nullable disable
#nullable restore
#line 3 "D:\Gitlab Projects\dotnetdemomvc\DotNetCoreMVCDemos\Views\Chat\_GroupChat.cshtml"
using Microsoft.AspNetCore.Http;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"ecb5ace71bf1dfa47b1e84bf25dcf4ccbb1a4241", @"/Views/Chat/_GroupChat.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"c1126c24cc3b8f7e1baf88f1be61ab8a996b8766", @"/Views/_ViewImports.cshtml")]
    public class Views_Chat__GroupChat : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<IEnumerable<DotNetCoreMVCDemos.Models.GroupChatModel>>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 4 "D:\Gitlab Projects\dotnetdemomvc\DotNetCoreMVCDemos\Views\Chat\_GroupChat.cshtml"
  

    Layout = "~/Views/Shared/_Layout.cshtml";

#line default
#line hidden
#nullable disable
#nullable restore
#line 8 "D:\Gitlab Projects\dotnetdemomvc\DotNetCoreMVCDemos\Views\Chat\_GroupChat.cshtml"
  
    var UserId = @HttpContextAccessor.HttpContext.Session.GetString("UserId");

#line default
#line hidden
#nullable disable
            WriteLiteral("<div class=\"tab-pane fade show active\" id=\"groups-chat\" role=\"tabpanel\" aria-labelledby=\"groups-chat-tab\">\r\n    <div class=\"sidebar-userlist\">\r\n        <ul class=\"list-unstyled userSearchList\">\r\n");
#nullable restore
#line 14 "D:\Gitlab Projects\dotnetdemomvc\DotNetCoreMVCDemos\Views\Chat\_GroupChat.cshtml"
              int count = 0; 

#line default
#line hidden
#nullable disable
#nullable restore
#line 15 "D:\Gitlab Projects\dotnetdemomvc\DotNetCoreMVCDemos\Views\Chat\_GroupChat.cshtml"
             foreach (var chat in Model)
            {

#line default
#line hidden
#nullable disable
            WriteLiteral("                <li");
            BeginWriteAttribute("id", " id=\"", 593, "\"", 620, 2);
            WriteAttributeValue("", 598, "liGroupConverId_", 598, 16, true);
#nullable restore
#line 17 "D:\Gitlab Projects\dotnetdemomvc\DotNetCoreMVCDemos\Views\Chat\_GroupChat.cshtml"
WriteAttributeValue("", 614, count, 614, 6, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(">\r\n                    <a data-ajax=\"true\" data-ajax-method=\"GET\" data-ajax-mode=\"replace\"\r\n                       data-ajax-update=\"#rdrConversationId\"");
            BeginWriteAttribute("href", " href=\"", 773, "\"", 931, 1);
#nullable restore
#line 19 "D:\Gitlab Projects\dotnetdemomvc\DotNetCoreMVCDemos\Views\Chat\_GroupChat.cshtml"
WriteAttributeValue("", 780, Url.Action("GroupConversationPanel","Chat",new {GroupId=chat.GroupID, UserId = UserId, GroupName = chat.GroupName, TotalMembers = chat.TotalMembers }), 780, 151, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            BeginWriteAttribute("id", " id=\"", 932, "\"", 962, 2);
            WriteAttributeValue("", 937, "ajaxConversationId_", 937, 19, true);
#nullable restore
#line 19 "D:\Gitlab Projects\dotnetdemomvc\DotNetCoreMVCDemos\Views\Chat\_GroupChat.cshtml"
WriteAttributeValue("", 956, count, 956, 6, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" style=\"display:none\">\r\n                    </a>\r\n\r\n                    <div");
            BeginWriteAttribute("id", " id=\"", 1039, "\"", 1063, 2);
            WriteAttributeValue("", 1044, "activeChatId_", 1044, 13, true);
#nullable restore
#line 22 "D:\Gitlab Projects\dotnetdemomvc\DotNetCoreMVCDemos\Views\Chat\_GroupChat.cshtml"
WriteAttributeValue("", 1057, count, 1057, 6, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(@" class=""conversation status-hidden"">
                        <div class=""user-avatar user-avatar-rounded avatar-primary"">
                            <span><i class=""mdi mdi-account-group""></i></span>
                        </div>

                        <div class=""conversation__details"">
                            <div class=""conversation__name"">
                                <div class=""conversation__name--title"">");
#nullable restore
#line 29 "D:\Gitlab Projects\dotnetdemomvc\DotNetCoreMVCDemos\Views\Chat\_GroupChat.cshtml"
                                                                  Write(chat.GroupName);

#line default
#line hidden
#nullable disable
            WriteLiteral("</div>\r\n                                <div class=\"conversation__time\">");
#nullable restore
#line 30 "D:\Gitlab Projects\dotnetdemomvc\DotNetCoreMVCDemos\Views\Chat\_GroupChat.cshtml"
                                                           Write(chat.LastMessageTime);

#line default
#line hidden
#nullable disable
            WriteLiteral("</div>\r\n                            </div>\r\n                            <div class=\"conversation__message\">\r\n                                <div class=\"conversation__message-preview\">\r\n");
            WriteLiteral("                                    ");
#nullable restore
#line 37 "D:\Gitlab Projects\dotnetdemomvc\DotNetCoreMVCDemos\Views\Chat\_GroupChat.cshtml"
                               Write(chat.LastMessage);

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                                </div>\r\n");
#nullable restore
#line 40 "D:\Gitlab Projects\dotnetdemomvc\DotNetCoreMVCDemos\Views\Chat\_GroupChat.cshtml"
                                 if (@chat.MessageCount > 0)
                                {

#line default
#line hidden
#nullable disable
            WriteLiteral("                                    <span");
            BeginWriteAttribute("id", " id=\"", 2312, "\"", 2334, 2);
            WriteAttributeValue("", 2317, "msgCountId_", 2317, 11, true);
#nullable restore
#line 42 "D:\Gitlab Projects\dotnetdemomvc\DotNetCoreMVCDemos\Views\Chat\_GroupChat.cshtml"
WriteAttributeValue("", 2328, count, 2328, 6, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" class=\"badge badge-primary badge-rounded\">");
#nullable restore
#line 42 "D:\Gitlab Projects\dotnetdemomvc\DotNetCoreMVCDemos\Views\Chat\_GroupChat.cshtml"
                                                                                                      Write(chat.MessageCount);

#line default
#line hidden
#nullable disable
            WriteLiteral("</span>\r\n");
#nullable restore
#line 43 "D:\Gitlab Projects\dotnetdemomvc\DotNetCoreMVCDemos\Views\Chat\_GroupChat.cshtml"
                                }

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                            </div>\r\n                        </div>\r\n                    </div>\r\n                </li>\r\n");
#nullable restore
#line 49 "D:\Gitlab Projects\dotnetdemomvc\DotNetCoreMVCDemos\Views\Chat\_GroupChat.cshtml"
                count++;
            }

#line default
#line hidden
#nullable disable
            WriteLiteral("            <input type=\"hidden\" id=\"hdnCount\"");
            BeginWriteAttribute("value", " value=\"", 2648, "\"", 2662, 1);
#nullable restore
#line 51 "D:\Gitlab Projects\dotnetdemomvc\DotNetCoreMVCDemos\Views\Chat\_GroupChat.cshtml"
WriteAttributeValue("", 2656, count, 2656, 6, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(@" />
        </ul>
    </div>
</div>

<script>

    $(document).ready(function () {
        var count = $('#hdnCount').val();
        for (let i = 0; i < count; i++) {
            $('#liGroupConverId_' + i + '').click(function () {
                $('#ajaxConversationId_' + i + '')[0].click()
                if (parseInt($('#msgCountId_' + i + '').html()) > 0) {
                    console.log('calling getAll in group chat');
                    getGrpAll();
                }
                for (let j = 0; j < count; j++) {
                    $('#activeChatId_' + j + '').removeClass(""active"");
                }
                $('#activeChatId_' + i + '').addClass(""active"");
            });
        }
    });
</script>");
        }
        #pragma warning restore 1998
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public IHttpContextAccessor HttpContextAccessor { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.IModelExpressionProvider ModelExpressionProvider { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IUrlHelper Url { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IViewComponentHelper Component { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IJsonHelper Json { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<IEnumerable<DotNetCoreMVCDemos.Models.GroupChatModel>> Html { get; private set; }
    }
}
#pragma warning restore 1591
