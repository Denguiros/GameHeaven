#pragma checksum "C:\Users\Denguiros\source\repos\GameHeaven\Areas\Admin\Views\User\Delete.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "c1e9e911e1374fcafe74e0ae201c56c2a1095cb9"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Areas_Admin_Views_User_Delete), @"mvc.1.0.view", @"/Areas/Admin/Views/User/Delete.cshtml")]
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
#line 1 "C:\Users\Denguiros\source\repos\GameHeaven\Areas\Admin\Views\_ViewImports.cshtml"
using GameHeaven;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\Denguiros\source\repos\GameHeaven\Areas\Admin\Views\_ViewImports.cshtml"
using GameHeaven.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"c1e9e911e1374fcafe74e0ae201c56c2a1095cb9", @"/Areas/Admin/Views/User/Delete.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"802e91f46399a2fe202713aa90ee0154047a8bb2", @"/Areas/Admin/Views/_ViewImports.cshtml")]
    public class Areas_Admin_Views_User_Delete : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<GameHeaven.Entities.User>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Index", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n");
#nullable restore
#line 3 "C:\Users\Denguiros\source\repos\GameHeaven\Areas\Admin\Views\User\Delete.cshtml"
  
    ViewData["Title"] = "Details";
    Layout = "~/Areas/Admin/Views/Shared/_AdminLayout.cshtml";

#line default
#line hidden
#nullable disable
            WriteLiteral(@"
<!-- Begin Page Content -->
<div class=""container-fluid"">

    <!-- DataTales Example -->
    <div class=""card shadow mb-4"">
        <div class=""card-header py-3"">
            <h6 class=""m-0 font-weight-bold text-primary"">User Details</h6>
        </div>
        <div class=""card-body"">
            <div class=""row"">
                <div class=""col-md-4"">
                    <dl class=""row"">
                        <dt class=""col-sm-2"">
                            ");
#nullable restore
#line 21 "C:\Users\Denguiros\source\repos\GameHeaven\Areas\Admin\Views\User\Delete.cshtml"
                       Write(Html.DisplayNameFor(model => model.UserProperties.Id));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                        </dt>\r\n                        <dd class=\"col-sm-10\">\r\n                            ");
#nullable restore
#line 24 "C:\Users\Denguiros\source\repos\GameHeaven\Areas\Admin\Views\User\Delete.cshtml"
                       Write(Html.DisplayFor(model => model.UserProperties.Id));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                        </dd>\r\n                        <dt class=\"col-sm-2\">\r\n                            ");
#nullable restore
#line 27 "C:\Users\Denguiros\source\repos\GameHeaven\Areas\Admin\Views\User\Delete.cshtml"
                       Write(Html.DisplayNameFor(model => model.UserProperties.UserName));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                        </dt>\r\n                        <dd class=\"col-sm-10\">\r\n                            ");
#nullable restore
#line 30 "C:\Users\Denguiros\source\repos\GameHeaven\Areas\Admin\Views\User\Delete.cshtml"
                       Write(Html.DisplayFor(model => model.UserProperties.UserName));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                        </dd>\r\n                        <dt class=\"col-sm-2\">\r\n                            ");
#nullable restore
#line 33 "C:\Users\Denguiros\source\repos\GameHeaven\Areas\Admin\Views\User\Delete.cshtml"
                       Write(Html.DisplayNameFor(model => model.UserProperties.Email));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                        </dt>\r\n                        <dd class=\"col-sm-10\">\r\n                            ");
#nullable restore
#line 36 "C:\Users\Denguiros\source\repos\GameHeaven\Areas\Admin\Views\User\Delete.cshtml"
                       Write(Html.DisplayFor(model => model.UserProperties.Email));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                        </dd>\r\n                        <dt class=\"col-sm-2\">\r\n                            ");
#nullable restore
#line 39 "C:\Users\Denguiros\source\repos\GameHeaven\Areas\Admin\Views\User\Delete.cshtml"
                       Write(Html.DisplayNameFor(model => model.UserProperties.EmailConfirmed));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                        </dt>\r\n                        <dd class=\"col-sm-10\">\r\n                            ");
#nullable restore
#line 42 "C:\Users\Denguiros\source\repos\GameHeaven\Areas\Admin\Views\User\Delete.cshtml"
                       Write(Html.DisplayFor(model => model.UserProperties.EmailConfirmed));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                        </dd>\r\n                        <dt class=\"col-sm-2\">\r\n                            ");
#nullable restore
#line 45 "C:\Users\Denguiros\source\repos\GameHeaven\Areas\Admin\Views\User\Delete.cshtml"
                       Write(Html.DisplayNameFor(model => model.Publisher));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                        </dt>\r\n                        <dd class=\"col-sm-10\">\r\n                            ");
#nullable restore
#line 48 "C:\Users\Denguiros\source\repos\GameHeaven\Areas\Admin\Views\User\Delete.cshtml"
                       Write(Html.DisplayFor(model => model.Publisher.Name));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                        </dd>\r\n                        <dt class=\"col-sm-2\">\r\n                            ");
#nullable restore
#line 51 "C:\Users\Denguiros\source\repos\GameHeaven\Areas\Admin\Views\User\Delete.cshtml"
                       Write(Html.DisplayNameFor(model => model.Developer));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                        </dt>\r\n                        <dd class=\"col-sm-10\">\r\n                            ");
#nullable restore
#line 54 "C:\Users\Denguiros\source\repos\GameHeaven\Areas\Admin\Views\User\Delete.cshtml"
                       Write(Html.DisplayFor(model => model.Developer.Name));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                        </dd>\r\n                    </dl>\r\n                </div>\r\n                <div>\r\n                    ");
#nullable restore
#line 59 "C:\Users\Denguiros\source\repos\GameHeaven\Areas\Admin\Views\User\Delete.cshtml"
               Write(Html.ActionLink("Edit", "Edit", new {  id = Model.UserProperties.Id }));

#line default
#line hidden
#nullable disable
            WriteLiteral(" |\r\n                    ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "c1e9e911e1374fcafe74e0ae201c56c2a1095cb99306", async() => {
                WriteLiteral("Back to List");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_0.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n                </div>\r\n            </div>\r\n        </div>\r\n    </div>\r\n</div>\r\n\r\n");
        }
        #pragma warning restore 1998
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.IModelExpressionProvider ModelExpressionProvider { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IUrlHelper Url { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IViewComponentHelper Component { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IJsonHelper Json { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<GameHeaven.Entities.User> Html { get; private set; }
    }
}
#pragma warning restore 1591