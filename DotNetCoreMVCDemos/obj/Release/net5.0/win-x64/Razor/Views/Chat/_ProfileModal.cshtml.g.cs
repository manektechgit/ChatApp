#pragma checksum "D:\Gitlab Projects\dotnetdemomvc\DotNetCoreMVCDemos\Views\Chat\_ProfileModal.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "4b612f2a32d7f7e1eca9bf213dc9c7d97e645fc2"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Chat__ProfileModal), @"mvc.1.0.view", @"/Views/Chat/_ProfileModal.cshtml")]
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
#line 3 "D:\Gitlab Projects\dotnetdemomvc\DotNetCoreMVCDemos\Views\Chat\_ProfileModal.cshtml"
using Microsoft.AspNetCore.Http;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"4b612f2a32d7f7e1eca9bf213dc9c7d97e645fc2", @"/Views/Chat/_ProfileModal.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"c1126c24cc3b8f7e1baf88f1be61ab8a996b8766", @"/Views/_ViewImports.cshtml")]
    public class Views_Chat__ProfileModal : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<DotNetCoreMVCDemos.Models.ProfileInfo>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("img-fluid image"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("alt", new global::Microsoft.AspNetCore.Html.HtmlString(""), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("id", new global::Microsoft.AspNetCore.Html.HtmlString("imgUserProfileEdit"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_3 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("src", new global::Microsoft.AspNetCore.Html.HtmlString("~/lib/images/icon/icons8-camera-20.png"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_4 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("method", "post", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_5 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("enctype", new global::Microsoft.AspNetCore.Html.HtmlString("multipart/form-data"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_6 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-controller", "Chat", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_7 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "UpdateProfilePicture", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 14 "D:\Gitlab Projects\dotnetdemomvc\DotNetCoreMVCDemos\Views\Chat\_ProfileModal.cshtml"
  
    var UserId = @HttpContextAccessor.HttpContext.Session.GetString("UserId");

#line default
#line hidden
#nullable disable
            WriteLiteral(@"<div class=""modal profile-dialog show"" id=""viewProfileModal"" tabindex=""-1"" role=""dialog"" aria-labelledby=""viewProfileModal"" style=""display: block; padding-left: 17px;"" aria-modal=""true"">
    <div class=""modal-dialog modal-dialog-centered"" role=""document"">
        <div class=""modal-content"">
            <div class=""modal-header"">
                <div class=""back2homepage"" data-dismiss=""modal"">
                    <i class=""mdi mdi-arrow-left""></i>
                    <span>Back</span>
                </div>
                <div class=""profile-modal-close"" data-dismiss=""modal"">
                    <i class=""mdi mdi-close""></i>
                </div>
            </div>
            <div class=""modal-body p-0"">
                <div class=""ca-profile-thumb"" style=""background-image: url(Content/images/media/07.jpg); height:210px;"">
                    <div class=""ca-profile-info"">
                        <div class=""ca-profile-pic"">
");
            WriteLiteral("                            ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("img", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagOnly, "4b612f2a32d7f7e1eca9bf213dc9c7d97e645fc27650", async() => {
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
            BeginAddHtmlAttributeValues(__tagHelperExecutionContext, "src", 2, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            AddHtmlAttributeValue("", 1824, "~/lib/images/user/500/", 1824, 22, true);
#nullable restore
#line 34 "D:\Gitlab Projects\dotnetdemomvc\DotNetCoreMVCDemos\Views\Chat\_ProfileModal.cshtml"
AddHtmlAttributeValue("", 1846, Html.DisplayFor(modelitem=>modelitem.ProfileImage), 1846, 51, false);

#line default
#line hidden
#nullable disable
            EndAddHtmlAttributeValues(__tagHelperExecutionContext);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_1);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n");
            WriteLiteral("\r\n                        </div>\r\n                        <div class=\"ca-profile-title\">\r\n                            <h2 class=\"ca-profile-name\">");
#nullable restore
#line 39 "D:\Gitlab Projects\dotnetdemomvc\DotNetCoreMVCDemos\Views\Chat\_ProfileModal.cshtml"
                                                   Write(Html.DisplayFor(modelitem => modelitem.UserName));

#line default
#line hidden
#nullable disable
            WriteLiteral(@"</h2>
                        </div>
                    </div>
                    <div class=""ca-profile-actions"" style=""padding-right: 10px; padding-top: 3px;"">
                        <div class=""iconbox-group"">
                            <div class=""iconbox btn-hovered-light"">

                                ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("img", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagOnly, "4b612f2a32d7f7e1eca9bf213dc9c7d97e645fc210179", async() => {
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_2);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_3);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_1);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n");
            WriteLiteral("\r\n                            </div>\r\n                            ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("form", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "4b612f2a32d7f7e1eca9bf213dc9c7d97e645fc211561", async() => {
                WriteLiteral("\r\n                                ");
#nullable restore
#line 52 "D:\Gitlab Projects\dotnetdemomvc\DotNetCoreMVCDemos\Views\Chat\_ProfileModal.cshtml"
                           Write(Html.HiddenFor(m => m.UserId));

#line default
#line hidden
#nullable disable
                WriteLiteral(@"
                                <div class=""form-group"">
                                    <div class=""col-md-10"">                                        
                                        <input type=""file"" name=""files"" multiple id=""FUserProfile"" />
                                    </div>
                                </div>
                                <div class=""form-group"">
                                    <div class=""col-md-10"">
                                        <input class=""btn-Save-Cancel"" type=""submit"" value=""Upload"" id=""sbmtUserProfile""/>
                                    </div>
                                </div>
                            ");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Method = (string)__tagHelperAttribute_4.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_4);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_5);
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Controller = (string)__tagHelperAttribute_6.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_6);
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Action = (string)__tagHelperAttribute_7.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_7);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral(@"
                            <i class=""mdi mdi-close"" id=""icnCancelimgUpld""></i>
                            
                        </div>
                    </div>
                    <div class=""ca-overlay""></div>
                </div>

                <div class=""profile-settings-list"">
                    <div class=""setting-sunheading pl-2"">Personal & Contact Information</div>
                    <ul class=""list-unstyled"">
                        <li>
                            <div class=""ps-list"">
                                <div class=""ps-list__left"">
                                    <div class=""ps-list__left--icon""><i class=""mdi mdi-gender-male-female""></i></div>
                                    <div class=""ps-list__left--name"">Gender</div>
                                </div>
                                <div class=""ps-list__right"">
                                    <span>Female</span>
                                </div>
                            </div>");
            WriteLiteral(@"
                        </li>
                        <li>
                            <div class=""ps-list"">
                                <div class=""ps-list__left"">
                                    <div class=""ps-list__left--icon""><i class=""mdi mdi-cake""></i></div>
                                    <div class=""ps-list__left--name"">Birth date</div>
                                </div>
                                <div class=""ps-list__right"">20/12/2016</div>
                            </div>
                        </li>
                        <li>
                            <div class=""ps-list"">
                                <div class=""ps-list__left"">
                                    <div class=""ps-list__left--icon""><i class=""mdi mdi-cellphone-android""></i></div>
                                    <div class=""ps-list__left--name"">Mobile number</div>
                                </div>
                                <div class=""ps-list__right"">+");
#nullable restore
#line 100 "D:\Gitlab Projects\dotnetdemomvc\DotNetCoreMVCDemos\Views\Chat\_ProfileModal.cshtml"
                                                        Write(Html.DisplayFor(modelitem => modelitem.MobileNumber));

#line default
#line hidden
#nullable disable
            WriteLiteral(@"</div>
                            </div>
                        </li>
                        <li>
                            <div class=""ps-list"">
                                <div class=""ps-list__left"">
                                    <div class=""ps-list__left--icon""><i class=""mdi mdi-email-outline""></i></div>
                                    <div class=""ps-list__left--name"">Email</div>
                                </div>
                                <div class=""ps-list__right"">");
#nullable restore
#line 109 "D:\Gitlab Projects\dotnetdemomvc\DotNetCoreMVCDemos\Views\Chat\_ProfileModal.cshtml"
                                                       Write(Html.DisplayFor(modelitem => modelitem.Email));

#line default
#line hidden
#nullable disable
            WriteLiteral(@"</div>
                            </div>
                        </li>
                        <li>
                            <div class=""ps-list"">
                                <div class=""ps-list__left"">
                                    <div class=""ps-list__left--icon""><i class=""mdi mdi-at""></i></div>
                                    <div class=""ps-list__left--name"">Website</div>
                                </div>
                                <div class=""ps-list__right"">www.demo.com</div>
                            </div>
                        </li>
                    </ul>
");
#nullable restore
#line 122 "D:\Gitlab Projects\dotnetdemomvc\DotNetCoreMVCDemos\Views\Chat\_ProfileModal.cshtml"
                     using (Html.BeginForm("ChatHome", "Chat", FormMethod.Post))
                    {

#line default
#line hidden
#nullable disable
            WriteLiteral(@"                        <div class=""setting-sunheading pl-2 py-4"">
                            Social Network

                            <div class=""iconbox btn-hovered-light"">
                                <i class=""iconbox__icon mdi mdi-pencil-outline"" id=""iconEdit""></i>
                            </div>
                            <input type=""submit"" class=""btn-Save-Cancel"" value=""Save"" id=""btnSave"" />
                            <input type=""button"" class=""btn-Save-Cancel"" value=""Cancel"" id=""btnCancel"" />
                        </div>
");
#nullable restore
#line 133 "D:\Gitlab Projects\dotnetdemomvc\DotNetCoreMVCDemos\Views\Chat\_ProfileModal.cshtml"
                   Write(Html.HiddenFor(m => m.UserId));

#line default
#line hidden
#nullable disable
            WriteLiteral(@"                        <ul class=""list-unstyled"">
                            <li>
                                <div class=""ps-list"">
                                    <div class=""ps-list__left"">
                                        <div class=""ps-list__left--icon""><i class=""mdi mdi-facebook""></i></div>
                                        <div class=""ps-list__left--name"">Facebook</div>
                                    </div>
                                    <div class=""ps-list__right"">");
#nullable restore
#line 141 "D:\Gitlab Projects\dotnetdemomvc\DotNetCoreMVCDemos\Views\Chat\_ProfileModal.cshtml"
                                                           Write(Html.TextBoxFor(e => e.Facebook, new { @class = "form-control", id = "txtUserFB" }));

#line default
#line hidden
#nullable disable
            WriteLiteral("<span id=\"spnUserFB\">");
#nullable restore
#line 141 "D:\Gitlab Projects\dotnetdemomvc\DotNetCoreMVCDemos\Views\Chat\_ProfileModal.cshtml"
                                                                                                                                                                    Write(Html.DisplayFor(modelitem => modelitem.Facebook));

#line default
#line hidden
#nullable disable
            WriteLiteral(@"</span> </div>
                                </div>
                            </li>
                            <li>
                                <div class=""ps-list"">
                                    <div class=""ps-list__left"">
                                        <div class=""ps-list__left--icon""><i class=""mdi mdi-instagram""></i></div>
                                        <div class=""ps-list__left--name"">Instagram</div>
                                    </div>
                                    <div class=""ps-list__right"">");
#nullable restore
#line 150 "D:\Gitlab Projects\dotnetdemomvc\DotNetCoreMVCDemos\Views\Chat\_ProfileModal.cshtml"
                                                           Write(Html.TextBoxFor(e => e.Instagram, new { @class = "form-control", id = "txtUserIG" }));

#line default
#line hidden
#nullable disable
            WriteLiteral("<span id=\"spnUserIG\">");
#nullable restore
#line 150 "D:\Gitlab Projects\dotnetdemomvc\DotNetCoreMVCDemos\Views\Chat\_ProfileModal.cshtml"
                                                                                                                                                                     Write(Html.DisplayFor(modelitem => modelitem.Instagram));

#line default
#line hidden
#nullable disable
            WriteLiteral(@"</span></div>
                                </div>
                            </li>
                            <li>
                                <div class=""ps-list"">
                                    <div class=""ps-list__left"">
                                        <div class=""ps-list__left--icon""><i class=""mdi mdi-snapchat""></i></div>
                                        <div class=""ps-list__left--name"">Snapchat</div>
                                    </div>
                                    <div class=""ps-list__right"">");
#nullable restore
#line 159 "D:\Gitlab Projects\dotnetdemomvc\DotNetCoreMVCDemos\Views\Chat\_ProfileModal.cshtml"
                                                           Write(Html.TextBoxFor(e => e.Snapchat, new { @class = "form-control", id = "txtUserSC" }));

#line default
#line hidden
#nullable disable
            WriteLiteral("<span id=\"spnUserSC\">");
#nullable restore
#line 159 "D:\Gitlab Projects\dotnetdemomvc\DotNetCoreMVCDemos\Views\Chat\_ProfileModal.cshtml"
                                                                                                                                                                    Write(Html.DisplayFor(modelitem => modelitem.Snapchat));

#line default
#line hidden
#nullable disable
            WriteLiteral(@"</span></div>
                                </div>
                            </li>
                            <li>
                                <div class=""ps-list"">
                                    <div class=""ps-list__left"">
                                        <div class=""ps-list__left--icon""><i class=""mdi mdi-twitter""></i></div>
                                        <div class=""ps-list__left--name"">Twitter</div>
                                    </div>
                                    <div class=""ps-list__right"">");
#nullable restore
#line 168 "D:\Gitlab Projects\dotnetdemomvc\DotNetCoreMVCDemos\Views\Chat\_ProfileModal.cshtml"
                                                           Write(Html.TextBoxFor(e => e.Twitter, new { @class = "form-control", id = "txtUserTWR" }));

#line default
#line hidden
#nullable disable
            WriteLiteral("<span id=\"spnUserTWR\">");
#nullable restore
#line 168 "D:\Gitlab Projects\dotnetdemomvc\DotNetCoreMVCDemos\Views\Chat\_ProfileModal.cshtml"
                                                                                                                                                                     Write(Html.DisplayFor(modelitem => modelitem.Twitter));

#line default
#line hidden
#nullable disable
            WriteLiteral("</span></div>\r\n                                </div>\r\n                            </li>   \r\n\r\n                        </ul>\r\n");
#nullable restore
#line 173 "D:\Gitlab Projects\dotnetdemomvc\DotNetCoreMVCDemos\Views\Chat\_ProfileModal.cshtml"
                    }

#line default
#line hidden
#nullable disable
            WriteLiteral(@"                </div>
            </div>
        </div>
    </div>
</div>

<script>
    $(document).ready(function () {
        $(""#btnSave"").hide();
        $(""#btnCancel"").hide();

        $(""#txtUserFB"").hide();
        $(""#txtUserIG"").hide();
        $(""#txtUserSC"").hide();
        $(""#txtUserTWR"").hide();

        $(""#iconEdit"").click(function() {
            $(""#btnSave"").show();
            $(""#btnCancel"").show();
            $(""#iconEdit"").hide();

            $(""#spnUserFB"").hide();
            $(""#spnUserIG"").hide();
            $(""#spnUserSC"").hide();
            $(""#spnUserTWR"").hide();

            $(""#txtUserFB"").show();
            $(""#txtUserIG"").show();
            $(""#txtUserSC"").show();
            $(""#txtUserTWR"").show();
        });

        $(""#btnCancel"").click(function () {
            $(""#btnSave"").hide();
            $(""#btnCancel"").hide();            
            $(""#iconEdit"").show();

            $(""#spnUserFB"").show();
            $(""#spnUse");
            WriteLiteral(@"rIG"").show();
            $(""#spnUserSC"").show();
            $(""#spnUserTWR"").show();

            $(""#txtUserFB"").hide();
            $(""#txtUserIG"").hide();
            $(""#txtUserSC"").hide();
            $(""#txtUserTWR"").hide();
        });

        $(""#FUserProfile"").hide();
        $(""#icnCancelimgUpld"").hide();
        $(""#sbmtUserProfile"").hide();
        $(""#imgUserProfileEdit"").click(function () {
            $(""#imgUserProfileEdit"").hide();
            $(""#FUserProfile"").show();
            $(""#icnCancelimgUpld"").show();
            $(""#sbmtUserProfile"").show();
        });

        $(""#icnCancelimgUpld"").click(function () {
            $(""#imgUserProfileEdit"").show();
            $(""#FUserProfile"").hide();
            $(""#icnCancelimgUpld"").hide();
            $(""#sbmtUserProfile"").hide();
        });
    });
</script>

<style type=""text/css"">
    .btn-Save-Cancel {
        background: #007bff;
        border-radius: 5px;
        color: white;
        padding: 3px");
            WriteLiteral(@" 6px;
        border: 0px;
    }
        .btn-Save-Cancel:hover {
            background-color: #4cacff;
        }

    input {
        border-top-style: hidden;
        border-right-style: hidden;
        border-left-style: hidden;
        border-bottom-style: hidden;        
      }
</style>

");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<DotNetCoreMVCDemos.Models.ProfileInfo> Html { get; private set; }
    }
}
#pragma warning restore 1591
