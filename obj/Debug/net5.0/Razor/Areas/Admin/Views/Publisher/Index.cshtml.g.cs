#pragma checksum "C:\Users\Denguiros\source\repos\GameHeaven\Areas\Admin\Views\Publisher\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "c2dc1e6ecc08bfe3d1c1ba42453a3a658a6ad246"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Areas_Admin_Views_Publisher_Index), @"mvc.1.0.view", @"/Areas/Admin/Views/Publisher/Index.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"c2dc1e6ecc08bfe3d1c1ba42453a3a658a6ad246", @"/Areas/Admin/Views/Publisher/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"802e91f46399a2fe202713aa90ee0154047a8bb2", @"/Areas/Admin/Views/_ViewImports.cshtml")]
    public class Areas_Admin_Views_Publisher_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<IEnumerable<GameHeaven.Dtos.PublisherDtos.PublisherDto>>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Create", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("btn btn-primary btn-icon-split"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
#line 3 "C:\Users\Denguiros\source\repos\GameHeaven\Areas\Admin\Views\Publisher\Index.cshtml"
  
    ViewData["Title"] = "Index";
    Layout = "~/Areas/Admin/Views/Shared/_AdminLayout.cshtml";

#line default
#line hidden
#nullable disable
            WriteLiteral(@"

<!-- Begin Page Content -->
<div class=""container-fluid"">

    <!-- DataTales Example -->
    <div class=""card shadow mb-4"">
        <div class=""card-header py-3 d-flex justify-content-between"">
            <h6 class=""m-0 font-weight-bold text-primary"">Publishers</h6>
            ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "c2dc1e6ecc08bfe3d1c1ba42453a3a658a6ad2464466", async() => {
                WriteLiteral("\r\n                <span class=\"icon text-white-50\">\r\n                    <i class=\"fas fa-plus\"></i>\r\n                </span>\r\n                <span class=\"text\">New Publisher</span>\r\n            ");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_0.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_1);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral(@"
        </div>
        <div class=""card-body"">
            <div class=""table-responsive"">
                <table class=""table table-bordered"" id=""dataTable"" width=""100%"" cellspacing=""0"">
                    <thead>
                        <tr>
                            <th>
                                ");
#nullable restore
#line 29 "C:\Users\Denguiros\source\repos\GameHeaven\Areas\Admin\Views\Publisher\Index.cshtml"
                           Write(Html.DisplayNameFor(model => model.Id));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                            </th>\r\n                            <th>\r\n                                ");
#nullable restore
#line 32 "C:\Users\Denguiros\source\repos\GameHeaven\Areas\Admin\Views\Publisher\Index.cshtml"
                           Write(Html.DisplayNameFor(model => model.Name));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                            </th>\r\n                            <th>\r\n                                ");
#nullable restore
#line 35 "C:\Users\Denguiros\source\repos\GameHeaven\Areas\Admin\Views\Publisher\Index.cshtml"
                           Write(Html.DisplayNameFor(model => model.CoverPath));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                            </th>\r\n                            <th>\r\n                                ");
#nullable restore
#line 38 "C:\Users\Denguiros\source\repos\GameHeaven\Areas\Admin\Views\Publisher\Index.cshtml"
                           Write(Html.DisplayNameFor(model => model.User));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                            </th>\r\n                            <th>\r\n                                ");
#nullable restore
#line 41 "C:\Users\Denguiros\source\repos\GameHeaven\Areas\Admin\Views\Publisher\Index.cshtml"
                           Write(Html.DisplayNameFor(model => model.Description));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                            </th>\r\n                            <th>\r\n                                ");
#nullable restore
#line 44 "C:\Users\Denguiros\source\repos\GameHeaven\Areas\Admin\Views\Publisher\Index.cshtml"
                           Write(Html.DisplayNameFor(model => model.WebsiteLink));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                            </th>\r\n                            <th>\r\n                                ");
#nullable restore
#line 47 "C:\Users\Denguiros\source\repos\GameHeaven\Areas\Admin\Views\Publisher\Index.cshtml"
                           Write(Html.DisplayNameFor(model => model.FacebookLink));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                            </th>\r\n                            <th>\r\n                                ");
#nullable restore
#line 50 "C:\Users\Denguiros\source\repos\GameHeaven\Areas\Admin\Views\Publisher\Index.cshtml"
                           Write(Html.DisplayNameFor(model => model.TwitterLink));

#line default
#line hidden
#nullable disable
            WriteLiteral(@"
                            </th>
                            <th>Actions</th>
                        </tr>
                    </thead>
                    <tfoot>
                        <tr>
                            <th>
                                ");
#nullable restore
#line 58 "C:\Users\Denguiros\source\repos\GameHeaven\Areas\Admin\Views\Publisher\Index.cshtml"
                           Write(Html.DisplayNameFor(model => model.Id));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                            </th>\r\n                            <th>\r\n                                ");
#nullable restore
#line 61 "C:\Users\Denguiros\source\repos\GameHeaven\Areas\Admin\Views\Publisher\Index.cshtml"
                           Write(Html.DisplayNameFor(model => model.Name));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                            </th>\r\n                            <th>\r\n                                ");
#nullable restore
#line 64 "C:\Users\Denguiros\source\repos\GameHeaven\Areas\Admin\Views\Publisher\Index.cshtml"
                           Write(Html.DisplayNameFor(model => model.CoverPath));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                            </th>\r\n                            <th>\r\n                                ");
#nullable restore
#line 67 "C:\Users\Denguiros\source\repos\GameHeaven\Areas\Admin\Views\Publisher\Index.cshtml"
                           Write(Html.DisplayNameFor(model => model.User));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                            </th>\r\n                            <th>\r\n                                ");
#nullable restore
#line 70 "C:\Users\Denguiros\source\repos\GameHeaven\Areas\Admin\Views\Publisher\Index.cshtml"
                           Write(Html.DisplayNameFor(model => model.Description));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                            </th>\r\n                            <th>\r\n                                ");
#nullable restore
#line 73 "C:\Users\Denguiros\source\repos\GameHeaven\Areas\Admin\Views\Publisher\Index.cshtml"
                           Write(Html.DisplayNameFor(model => model.WebsiteLink));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                            </th>\r\n                            <th>\r\n                                ");
#nullable restore
#line 76 "C:\Users\Denguiros\source\repos\GameHeaven\Areas\Admin\Views\Publisher\Index.cshtml"
                           Write(Html.DisplayNameFor(model => model.FacebookLink));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                            </th>\r\n                            <th>\r\n                                ");
#nullable restore
#line 79 "C:\Users\Denguiros\source\repos\GameHeaven\Areas\Admin\Views\Publisher\Index.cshtml"
                           Write(Html.DisplayNameFor(model => model.TwitterLink));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                            </th>\r\n                            <th>Actions</th>\r\n                        </tr>\r\n                    </tfoot>\r\n\r\n                    <tbody>\r\n");
#nullable restore
#line 86 "C:\Users\Denguiros\source\repos\GameHeaven\Areas\Admin\Views\Publisher\Index.cshtml"
                         foreach (var item in Model)
                        {


#line default
#line hidden
#nullable disable
            WriteLiteral("                            <tr>\r\n                                <td>\r\n                                    ");
#nullable restore
#line 91 "C:\Users\Denguiros\source\repos\GameHeaven\Areas\Admin\Views\Publisher\Index.cshtml"
                               Write(Html.DisplayFor(modelItem => item.Id));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                                </td>\r\n                                <td>\r\n                                    ");
#nullable restore
#line 94 "C:\Users\Denguiros\source\repos\GameHeaven\Areas\Admin\Views\Publisher\Index.cshtml"
                               Write(Html.DisplayFor(modelItem => item.Name));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                                </td>\r\n                                <td>\r\n                                    <img");
            BeginWriteAttribute("src", " src=\"", 4152, "\"", 4203, 1);
#nullable restore
#line 97 "C:\Users\Denguiros\source\repos\GameHeaven\Areas\Admin\Views\Publisher\Index.cshtml"
WriteAttributeValue("", 4158, Html.DisplayFor(modelItem => item.CoverPath), 4158, 45, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" width=\"100px\"><img>\r\n                                </td>\r\n                                <td>\r\n                                    ");
#nullable restore
#line 100 "C:\Users\Denguiros\source\repos\GameHeaven\Areas\Admin\Views\Publisher\Index.cshtml"
                               Write(Html.DisplayFor(modelItem => item.User.UserName));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                                </td>\r\n                                <td>\r\n                                    ");
#nullable restore
#line 103 "C:\Users\Denguiros\source\repos\GameHeaven\Areas\Admin\Views\Publisher\Index.cshtml"
                               Write(Html.DisplayFor(modelItem => item.Description));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                                </td>\r\n                                <td>\r\n                                    ");
#nullable restore
#line 106 "C:\Users\Denguiros\source\repos\GameHeaven\Areas\Admin\Views\Publisher\Index.cshtml"
                               Write(Html.DisplayFor(modelItem => item.WebsiteLink));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                                </td>\r\n                                <td>\r\n                                    ");
#nullable restore
#line 109 "C:\Users\Denguiros\source\repos\GameHeaven\Areas\Admin\Views\Publisher\Index.cshtml"
                               Write(Html.DisplayFor(modelItem => item.FacebookLink));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                                </td>\r\n                                <td>\r\n                                    ");
#nullable restore
#line 112 "C:\Users\Denguiros\source\repos\GameHeaven\Areas\Admin\Views\Publisher\Index.cshtml"
                               Write(Html.DisplayFor(modelItem => item.TwitterLink));

#line default
#line hidden
#nullable disable
            WriteLiteral(@"
                                </td>
                                <td>
                                    <div class=""btn-group"">
                                        <button type=""button"" class=""btn btn-sm dropdown-toggle"" id=""dropdownMenuButton"" data-toggle=""dropdown"" aria-haspopup=""true"" aria-expanded=""false"">
                                            <span class=""icon icon-sm"">
                                                <span class=""fas fa-ellipsis-h icon-dark""></span>
                                            </span>
                                            <span class=""sr-only"">Toggle Dropdown</span>
                                        </button>

                                        <ul class=""dropdown-menu"">
                                            <li>
                                                <a class=""dropdown-item text-black btn-labeled""");
            BeginWriteAttribute("href", " href=\"", 5947, "\"", 6007, 1);
#nullable restore
#line 125 "C:\Users\Denguiros\source\repos\GameHeaven\Areas\Admin\Views\Publisher\Index.cshtml"
WriteAttributeValue("", 5954, Url.Action("Details","Publisher",new {id = item.Id}), 5954, 53, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral("><span class=\"btn-label\"><i class=\"fa fa-eye\"></i></span> Show</a>\r\n                                            </li>\r\n                                            <li><a class=\"dropdown-item text-black\"");
            BeginWriteAttribute("href", " href=\"", 6210, "\"", 6267, 1);
#nullable restore
#line 127 "C:\Users\Denguiros\source\repos\GameHeaven\Areas\Admin\Views\Publisher\Index.cshtml"
WriteAttributeValue("", 6217, Url.Action("Edit","Publisher",new {id = item.Id}), 6217, 50, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral("><span class=\"btn-label\"><i class=\"fa fa-edit\"></i></span> Edit</a></li>\r\n                                            <li><hr class=\"dropdown-divider\"></li>\r\n                                            <li><a class=\"dropdown-item text-danger\"");
            BeginWriteAttribute("href", " href=\"", 6510, "\"", 6569, 1);
#nullable restore
#line 129 "C:\Users\Denguiros\source\repos\GameHeaven\Areas\Admin\Views\Publisher\Index.cshtml"
WriteAttributeValue("", 6517, Url.Action("Delete","Publisher",new {id = item.Id}), 6517, 52, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral("><span class=\"btn-label\"><i class=\"fa fa-trash\"></i></span> Delete</a></li>\r\n                                        </ul>\r\n                                    </div>\r\n                                </td>\r\n                            </tr>\r\n");
#nullable restore
#line 134 "C:\Users\Denguiros\source\repos\GameHeaven\Areas\Admin\Views\Publisher\Index.cshtml"
                        }

#line default
#line hidden
#nullable disable
            WriteLiteral("                    </tbody>\r\n                </table>\r\n            </div>\r\n        </div>\r\n    </div>\r\n\r\n</div>\r\n<!-- /.container-fluid -->\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<IEnumerable<GameHeaven.Dtos.PublisherDtos.PublisherDto>> Html { get; private set; }
    }
}
#pragma warning restore 1591
