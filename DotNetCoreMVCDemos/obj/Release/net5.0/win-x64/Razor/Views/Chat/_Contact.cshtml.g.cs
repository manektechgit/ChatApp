#pragma checksum "D:\Gitlab Projects\dotnetdemomvc\DotNetCoreMVCDemos\Views\Chat\_Contact.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "abf0f1f9d6e37841a213c6323398a826a5d55980"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Chat__Contact), @"mvc.1.0.view", @"/Views/Chat/_Contact.cshtml")]
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
#line 3 "D:\Gitlab Projects\dotnetdemomvc\DotNetCoreMVCDemos\Views\Chat\_Contact.cshtml"
using Microsoft.AspNetCore.Http;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"abf0f1f9d6e37841a213c6323398a826a5d55980", @"/Views/Chat/_Contact.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"c1126c24cc3b8f7e1baf88f1be61ab8a996b8766", @"/Views/_ViewImports.cshtml")]
    public class Views_Chat__Contact : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<IEnumerable<DotNetCoreMVCDemos.Models.AllUsersModel>>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("rel", new global::Microsoft.AspNetCore.Html.HtmlString("stylesheet"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("href", new global::Microsoft.AspNetCore.Html.HtmlString("~/lib/fonts/MaterialDesign/css/materialdesignicons.min.css"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("href", new global::Microsoft.AspNetCore.Html.HtmlString("~/lib/vendors/perfect-scrollbar/perfect-scrollbar.css"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_3 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("href", new global::Microsoft.AspNetCore.Html.HtmlString("~/lib/vendors/OwlCarousel2/owl.carousel.css"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_4 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("href", new global::Microsoft.AspNetCore.Html.HtmlString("~/lib/bootstrap.min.css"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_5 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("href", new global::Microsoft.AspNetCore.Html.HtmlString("~/lib/css/app.css"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_6 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("href", new global::Microsoft.AspNetCore.Html.HtmlString("~/lib/css/theme/default.css"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_7 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("alt", new global::Microsoft.AspNetCore.Html.HtmlString(""), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        #line hidden
        #pragma warning disable 0649
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperExecutionContext __tagHelperExecutionContext;
        #pragma warning restore 0649
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner __tagHelperRunner = new global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner();
        #pragma warning disable 0169
        private string __tagHelperStringValueBuffer;
        #pragma warning restore 0169
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager __backed__tagHelperScopeManager = null;
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager __tagHelperScopeManager
        {
            get
            {
                if (__backed__tagHelperScopeManager == null)
                {
                    __backed__tagHelperScopeManager = new global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager(StartTagHelperWritingScope, EndTagHelperWritingScope);
                }
                return __backed__tagHelperScopeManager;
            }
        }
        private global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 6 "D:\Gitlab Projects\dotnetdemomvc\DotNetCoreMVCDemos\Views\Chat\_Contact.cshtml"
   var UserId = @HttpContextAccessor.HttpContext.Session.GetString("UserId");

#line default
#line hidden
#nullable disable
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("link", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagOnly, "abf0f1f9d6e37841a213c6323398a826a5d559806494", async() => {
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_1);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("link", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagOnly, "abf0f1f9d6e37841a213c6323398a826a5d559807609", async() => {
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_2);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("link", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagOnly, "abf0f1f9d6e37841a213c6323398a826a5d559808724", async() => {
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_3);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("link", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagOnly, "abf0f1f9d6e37841a213c6323398a826a5d559809839", async() => {
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_4);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("link", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagOnly, "abf0f1f9d6e37841a213c6323398a826a5d5598010954", async() => {
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_5);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("link", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagOnly, "abf0f1f9d6e37841a213c6323398a826a5d5598012070", async() => {
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_6);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n");
            WriteLiteral("<div class=\"sidebar-contactlist\">\r\n    <ul class=\"list-unstyled userSearchList\">\r\n        <li>\r\n            <div class=\"contactlist-heading\">\r\n                <span>All Contacts</span>\r\n            </div>\r\n        </li>\r\n");
#nullable restore
#line 22 "D:\Gitlab Projects\dotnetdemomvc\DotNetCoreMVCDemos\Views\Chat\_Contact.cshtml"
          int count = 0; 

#line default
#line hidden
#nullable disable
#nullable restore
#line 23 "D:\Gitlab Projects\dotnetdemomvc\DotNetCoreMVCDemos\Views\Chat\_Contact.cshtml"
         foreach (var contact in Model)
        {
            

#line default
#line hidden
#nullable disable
            WriteLiteral("            <!-- <li id=\"liConversationId_");
#nullable restore
#line 26 "D:\Gitlab Projects\dotnetdemomvc\DotNetCoreMVCDemos\Views\Chat\_Contact.cshtml"
                                     Write(count);

#line default
#line hidden
#nullable disable
            WriteLiteral("\" onclick=\"LoadConversationPanel(\'");
#nullable restore
#line 26 "D:\Gitlab Projects\dotnetdemomvc\DotNetCoreMVCDemos\Views\Chat\_Contact.cshtml"
                                                                             Write(contact.UserContactID);

#line default
#line hidden
#nullable disable
            WriteLiteral("\', \'");
#nullable restore
#line 26 "D:\Gitlab Projects\dotnetdemomvc\DotNetCoreMVCDemos\Views\Chat\_Contact.cshtml"
                                                                                                       Write(contact.UserName);

#line default
#line hidden
#nullable disable
            WriteLiteral("\')\"> -->\r\n            <li");
            BeginWriteAttribute("id", " id=\"", 1373, "\"", 1401, 2);
            WriteAttributeValue("", 1378, "liConversationId_", 1378, 17, true);
#nullable restore
#line 27 "D:\Gitlab Projects\dotnetdemomvc\DotNetCoreMVCDemos\Views\Chat\_Contact.cshtml"
WriteAttributeValue("", 1395, count, 1395, 6, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            BeginWriteAttribute("onclick", " onclick=\"", 1402, "\"", 1505, 9);
            WriteAttributeValue("", 1412, "LoadConversationPanel(\'", 1412, 23, true);
#nullable restore
#line 27 "D:\Gitlab Projects\dotnetdemomvc\DotNetCoreMVCDemos\Views\Chat\_Contact.cshtml"
WriteAttributeValue("", 1435, contact.UserContactID, 1435, 22, false);

#line default
#line hidden
#nullable disable
            WriteAttributeValue("", 1457, "\',", 1457, 2, true);
            WriteAttributeValue(" ", 1459, "\'", 1460, 2, true);
#nullable restore
#line 27 "D:\Gitlab Projects\dotnetdemomvc\DotNetCoreMVCDemos\Views\Chat\_Contact.cshtml"
WriteAttributeValue("", 1461, contact.UserName, 1461, 17, false);

#line default
#line hidden
#nullable disable
            WriteAttributeValue("", 1478, "\',", 1478, 2, true);
            WriteAttributeValue(" ", 1480, "\'", 1481, 2, true);
#nullable restore
#line 27 "D:\Gitlab Projects\dotnetdemomvc\DotNetCoreMVCDemos\Views\Chat\_Contact.cshtml"
WriteAttributeValue("", 1482, contact.ProfileImage, 1482, 21, false);

#line default
#line hidden
#nullable disable
            WriteAttributeValue("", 1503, "\')", 1503, 2, true);
            EndWriteAttribute();
            WriteLiteral(">\r\n");
            WriteLiteral("\r\n");
            WriteLiteral("                <input type=\"hidden\" id=\"hdnContactUserId\"");
            BeginWriteAttribute("value", " value=\"", 1952, "\"", 1982, 1);
#nullable restore
#line 34 "D:\Gitlab Projects\dotnetdemomvc\DotNetCoreMVCDemos\Views\Chat\_Contact.cshtml"
WriteAttributeValue("", 1960, contact.UserContactID, 1960, 22, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" />\r\n                <input type=\"hidden\" id=\"hdnUserId\"");
            BeginWriteAttribute("value", " value=\"", 2039, "\"", 2054, 1);
#nullable restore
#line 35 "D:\Gitlab Projects\dotnetdemomvc\DotNetCoreMVCDemos\Views\Chat\_Contact.cshtml"
WriteAttributeValue("", 2047, UserId, 2047, 7, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" />\r\n                <input type=\"hidden\" id=\"hdnChatUsername\"");
            BeginWriteAttribute("value", " value=\"", 2117, "\"", 2142, 1);
#nullable restore
#line 36 "D:\Gitlab Projects\dotnetdemomvc\DotNetCoreMVCDemos\Views\Chat\_Contact.cshtml"
WriteAttributeValue("", 2125, contact.UserName, 2125, 17, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" />\r\n                <div class=\"contactlist conversation\">\r\n                    <div class=\"user-avatar user-avatar-rounded\">\r\n                        <!-- <img src=\"~/lib/images/user/250/01.jpg\" alt=\"\"> -->\r\n                        ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("img", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagOnly, "abf0f1f9d6e37841a213c6323398a826a5d5598018148", async() => {
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
            BeginAddHtmlAttributeValues(__tagHelperExecutionContext, "src", 2, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            AddHtmlAttributeValue("", 2387, "~/lib/images/user/500/", 2387, 22, true);
#nullable restore
#line 40 "D:\Gitlab Projects\dotnetdemomvc\DotNetCoreMVCDemos\Views\Chat\_Contact.cshtml"
AddHtmlAttributeValue("", 2409, contact.ProfileImage, 2409, 21, false);

#line default
#line hidden
#nullable disable
            EndAddHtmlAttributeValues(__tagHelperExecutionContext);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_7);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n                    </div>\r\n                    <div class=\"contactlist__details\">\r\n                        <div class=\"contactlist__details--name\">");
#nullable restore
#line 43 "D:\Gitlab Projects\dotnetdemomvc\DotNetCoreMVCDemos\Views\Chat\_Contact.cshtml"
                                                           Write(contact.UserName);

#line default
#line hidden
#nullable disable
            WriteLiteral("</div>\r\n");
            WriteLiteral(@"                    </div>
                    <div class=""contactlist__actions"">
                        <div class=""iconbox btn-solid-primary"">
                            <i class=""iconbox__icon mdi mdi-message-text-outline"" data-dismiss=""modal""></i>
                        </div>
                    </div>
                </div>
            </li>
");
#nullable restore
#line 56 "D:\Gitlab Projects\dotnetdemomvc\DotNetCoreMVCDemos\Views\Chat\_Contact.cshtml"
            count++;
        }

#line default
#line hidden
#nullable disable
            WriteLiteral("        <input type=\"hidden\" id=\"hdnCount\"");
            BeginWriteAttribute("value", " value=\"", 3292, "\"", 3306, 1);
#nullable restore
#line 58 "D:\Gitlab Projects\dotnetdemomvc\DotNetCoreMVCDemos\Views\Chat\_Contact.cshtml"
WriteAttributeValue("", 3300, count, 3300, 6, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" />\r\n    </ul>\r\n</div>\r\n");
            WriteLiteral(@"<script>

    $(document).ready(function () {
        var count = $('#hdnCount').val();
        for (let i = 0; i < count; i++) {
            $('#liConversationId_' + i + '').click(function () {
                console.log('tst is :' + i);
                $('#ajaxConversationId_' + i + '')[0].click()
                //for (let j = 0; j < count; j++) {
                //    $('#activeChatId_' + j + '').removeClass(""active"");
                //}
                //$('#activeChatId_' + i + '').addClass(""active"");
            });
        }
    });

    function LoadContactsDetails(contactUserId) {
        var model = $('#rdrConversationId');
        $.ajax({
            /*url: ""../Chat/ConversationPanel?UserId="" + contactUserId + """",*/
            url: ""../Chat/GetContactDetails?UserId="" + contactUserId + """",
            //url: ""http://50.21.182.225/aspdontnetcoredemo/Chat/PersonalChat?UserId="" + userID + ""&UserName=''"",
            contentType: 'application/html ; charset:utf-8',
          ");
            WriteLiteral(@"  type: 'GET',
            dataType: 'html',
            success: function (result) {
                model.empty().append(result);
                console.log(result);
            }
        });
    }
</script>

<script>
    $(document).ready(function () {
    });
    function LoadConversationPanel(contactUserId, ChatUserName, UserProfilePic) {
        var chatUserID = $('#hdnContactUserId').val();
        var userID = $('#hdnUserId').val();
        var model = $('#rdrConversationId');
        $.ajax({
            //url: ""http://50.21.182.225/aspdontnetcoredemo/Chat/ConversationPanel?UserId="" + userID + ""&ChatUserId="" + chatUserID + ""&ChatUserName="" + chatUserName + ""&Lastseen="" + lastseen + ""&Message="" + message + ""&imageArr="" + imageArr + """",
            url: ""../Chat/ConversationPanel?UserId="" + userID + ""&ChatUserId="" + contactUserId + ""&ChatUserName="" + ChatUserName + ""&ProfileImage="" + UserProfilePic + """",
            contentType: 'application/html; charset=utf-8',
            type:");
            WriteLiteral(@" ""GET"",
            dataType: 'html',
            success: function (result) {
                model.empty().append(result);
                console.log(result);
            }
        });
    }
</script>

<!-- <script>
    $(document).ready(function () {
    });
    function LoadConversationPanel(contactUserId, ChatUserName) {
        var chatUserID = $('#hdnContactUserId').val();
        var userID = $('#hdnUserId').val();
        var chatUserName = $('#hdnChatUsername').val();
        var model = $('#rdrConversationId');
        $.ajax({
            //url: ""http://50.21.182.225/aspdontnetcoredemo/Chat/ConversationPanel?UserId="" + userID + ""&ChatUserId="" + chatUserID + ""&ChatUserName="" + chatUserName + ""&Lastseen="" + lastseen + ""&Message="" + message + ""&imageArr="" + imageArr + """",
            url: ""../Chat/ConversationPanel?UserId="" + userID + ""&ChatUserId="" + contactUserId + ""&ChatUserName="" + ChatUserName + """",
            contentType: 'application/html; charset=utf-8',
            ty");
            WriteLiteral("pe: \"GET\",\r\n            dataType: \'html\',\r\n            success: function (result) {\r\n                model.empty().append(result);\r\n                console.log(result);\r\n            }\r\n        });\r\n    }\r\n</script> -->\r\n\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<IEnumerable<DotNetCoreMVCDemos.Models.AllUsersModel>> Html { get; private set; }
    }
}
#pragma warning restore 1591
