#pragma checksum "C:\Users\Denguiros\source\repos\GameHeaven\Views\Home\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "37f1e2ed9dbd11f5d1dcd1a8acaacdc415e43114"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Home_Index), @"mvc.1.0.view", @"/Views/Home/Index.cshtml")]
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
#line 1 "C:\Users\Denguiros\source\repos\GameHeaven\Views\_ViewImports.cshtml"
using GameHeaven;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\Denguiros\source\repos\GameHeaven\Views\_ViewImports.cshtml"
using GameHeaven.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"37f1e2ed9dbd11f5d1dcd1a8acaacdc415e43114", @"/Views/Home/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"802e91f46399a2fe202713aa90ee0154047a8bb2", @"/Views/_ViewImports.cshtml")]
    public class Views_Home_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<GameHeaven.ViewModels.HomeViewModel>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("src", new global::Microsoft.AspNetCore.Html.HtmlString("~/images/BG.jpg"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("alt", new global::Microsoft.AspNetCore.Html.HtmlString(""), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("jarallax-img"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
#line 2 "C:\Users\Denguiros\source\repos\GameHeaven\Views\Home\Index.cshtml"
  
    ViewData["Title"] = "Home Page";

#line default
#line hidden
#nullable disable
            WriteLiteral(@"<!-- START: Header Title -->
<!--
    Additional Classes:
        .nk-header-title-sm
        .nk-header-title-md
        .nk-header-title-lg
        .nk-header-title-xl
        .nk-header-title-full
        .nk-header-title-parallax
        .nk-header-title-parallax-opacity
        .nk-header-title-boxed
-->

<div class=""nk-header-title nk-header-title-lg nk-header-title-parallax nk-header-title-parallax-opacity"">
    <div class=""bg-image"">
        ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("img", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagOnly, "37f1e2ed9dbd11f5d1dcd1a8acaacdc415e431144784", async() => {
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_1);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_2);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral(@"
    </div>
    <div class=""nk-header-table"">
        <div class=""nk-header-table-cell"">
            <div class=""container"">




                <div class=""nk-header-text"">

                    <h1 class=""nk-title display-3"">GameHeaven</h1>

                    <div class=""nk-gap-2""></div>
                    <a href=""https://themeforest.net/item/godlike-the-game-template/17166433?ref=_nK"" target=""_blank"" class=""nk-btn nk-btn-lg nk-btn-color-main-1 link-effect-4"">
                        <span>Download</span>
                    </a>
                    &nbsp;&nbsp;&nbsp;&nbsp;
                    <div class=""nk-gap-4""></div>

                </div>


            </div>
        </div>
    </div>

</div>
<!-- END: Header Title -->
<!-- START: Rev Slider -->
<div class=""mnt-80"">
    <div id=""rev_slider_50_1_wrapper"" class=""rev_slider_wrapper fullscreen-container"" data-alias=""photography-carousel48"" style=""padding:0px;"">
        <div id=""rev_slider_50_1"" class=""rev_slider fullscr");
            WriteLiteral("eenbanner\" style=\"display:none;\" data-version=\"5.0.7\">\r\n            <ul>\r\n");
#nullable restore
#line 54 "C:\Users\Denguiros\source\repos\GameHeaven\Views\Home\Index.cshtml"
                 foreach (var game in Model.Games)
                {

#line default
#line hidden
#nullable disable
            WriteLiteral(@"                    <!-- SLIDE  -->
                    <li data-index=""rs-185"" data-transition=""slideoverhorizontal"" data-slotamount=""7"" data-easein=""default"" data-easeout=""default"" data-masterspeed=""1500"" data-thumb=""~/images/gallery-3-thumb.jpg"" data-rotate=""0"" data-saveperformance=""off"">
                        <!-- MAIN IMAGE -->
                    <img");
            BeginWriteAttribute("src", " src=\"", 2146, "\"", 2167, 1);
#nullable restore
#line 59 "C:\Users\Denguiros\source\repos\GameHeaven\Views\Home\Index.cshtml"
WriteAttributeValue("", 2152, game.CoverPath, 2152, 15, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            BeginWriteAttribute("alt", " alt=\"", 2168, "\"", 2174, 0);
            EndWriteAttribute();
            WriteLiteral(" data-bgposition=\"center center\" data-bgfit=\"cover\" data-bgrepeat=\"no-repeat\" class=\"rev-slidebg\" data-no-retina>\r\n                    </li>\r\n");
#nullable restore
#line 61 "C:\Users\Denguiros\source\repos\GameHeaven\Views\Home\Index.cshtml"
                }

#line default
#line hidden
#nullable disable
            WriteLiteral(@"            </ul>
            <div class=""tp-bannertimer tp-bottom"" style=""visibility: hidden !important;""></div>
        </div>
    </div>
</div>
<!-- END: Rev Slider -->
<div class=""container"">
    <div class=""nk-gap-4""></div>

    <div class=""nk-store"">

        <!-- START: Products List -->
        <div class=""row no-gutters"">

");
#nullable restore
#line 76 "C:\Users\Denguiros\source\repos\GameHeaven\Views\Home\Index.cshtml"
             foreach (var game in Model.Games)
            {

#line default
#line hidden
#nullable disable
            WriteLiteral(@"                <div class=""col-sm-6 col-lg-4"">
                    <!-- START: Product -->
                <div class=""nk-product"" data-mouse-parallax-z=""2"">
                        <div>
                            <div class=""nk-carousel-3"" data-size=""1"" data-mouse-parallax-z=""3"">
                                <div class=""nk-carousel-inner nk-popup-gallery"">
");
#nullable restore
#line 84 "C:\Users\Denguiros\source\repos\GameHeaven\Views\Home\Index.cshtml"
                                     foreach (var image in game.ImagesPath.Split(","))
                                    {
                                        if (image != string.Empty)
                                        {


#line default
#line hidden
#nullable disable
            WriteLiteral("                                            <div>\r\n                                                <div>\r\n                                                    <img class=\"nk-img-stretch\"");
            BeginWriteAttribute("src", " src=\"", 3544, "\"", 3556, 1);
#nullable restore
#line 91 "C:\Users\Denguiros\source\repos\GameHeaven\Views\Home\Index.cshtml"
WriteAttributeValue("", 3550, image, 3550, 6, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            BeginWriteAttribute("alt", " alt=\"", 3557, "\"", 3563, 0);
            EndWriteAttribute();
            WriteLiteral(">\r\n                                                </div>\r\n                                            </div>\r\n");
#nullable restore
#line 94 "C:\Users\Denguiros\source\repos\GameHeaven\Views\Home\Index.cshtml"
                                        }
                                    }

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                                </div>\r\n                            </div>\r\n                            <h2 class=\"nk-product-title h5\" data-mouse-parallax-z=\"1\"><a href=\"store-product.html\">");
#nullable restore
#line 99 "C:\Users\Denguiros\source\repos\GameHeaven\Views\Home\Index.cshtml"
                                                                                                              Write(game.Name);

#line default
#line hidden
#nullable disable
            WriteLiteral(@"</a></h2>


                            <span class=""nk-product-rating"">
                                <span class=""nk-product-rating-front"" style=""width: 90%;"">
                                    <i class=""fa fa-star""></i>
                                    <i class=""fa fa-star""></i>
                                    <i class=""fa fa-star""></i>
                                    <i class=""fa fa-star""></i>
                                    <i class=""fa fa-star""></i>
                                </span>
                                <span class=""nk-product-rating-back"">
                                    <i class=""far fa-star""></i>
                                    <i class=""far fa-star""></i>
                                    <i class=""far fa-star""></i>
                                    <i class=""far fa-star""></i>
                                    <i class=""far fa-star""></i>
                                </span>
                            </span>


                ");
            WriteLiteral("            <div class=\"nk-product-bottom\">\r\n                                <div>\r\n                                    <div class=\"nk-product-price\">$");
#nullable restore
#line 122 "C:\Users\Denguiros\source\repos\GameHeaven\Views\Home\Index.cshtml"
                                                              Write(game.Price);

#line default
#line hidden
#nullable disable
            WriteLiteral(@"</div>
                                    <a href=""#"">Add to Cart</a>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
                <!-- END: Product -->
");
#nullable restore
#line 130 "C:\Users\Denguiros\source\repos\GameHeaven\Views\Home\Index.cshtml"
            }

#line default
#line hidden
#nullable disable
            WriteLiteral(@"        </div>
    </div>
    <!-- END: Products List -->
</div>

<div class=""nk-gap-3""></div>
</div>
<!-- START: Features -->
<div class=""container"">
    <div class=""nk-gap-6""></div>
    <div class=""nk-gap-2""></div>
    <div class=""row vertical-gap lg-gap"">
        <div class=""col-md-4"">
            <div class=""nk-ibox"">
                <div class=""nk-ibox-icon nk-ibox-icon-circle"">
                    <span class=""ion-ios-game-controller-b""></span>
                </div>
                <div class=""nk-ibox-cont"">
                    <h2 class=""nk-ibox-title"">Incredible Atmosphere</h2>
                    Second Made make spirit green divide lesser creeping void and night replenish cattle don't was female first their day open.
                </div>
            </div>
        </div>
        <div class=""col-md-4"">
            <div class=""nk-ibox"">
                <div class=""nk-ibox-icon nk-ibox-icon-circle"">
                    <span class=""ion-fireball""></span>
                </d");
            WriteLiteral(@"iv>
                <div class=""nk-ibox-cont"">
                    <h2 class=""nk-ibox-title"">Catchy Battles</h2>
                    Image their gathered. Every. Called together signs winged, unto midst sea life air them. Us sea them shall you saw.
                </div>
            </div>
        </div>
        <div class=""col-md-4"">
            <div class=""nk-ibox"">
                <div class=""nk-ibox-icon nk-ibox-icon-circle"">
                    <span class=""ion-ribbon-a""></span>
                </div>
                <div class=""nk-ibox-cont"">
                    <h2 class=""nk-ibox-title"">28 Awards</h2>
                    Moveth fruitful it appear wherein man don't firmament set blessed. Beast seas god itself. Made night image male. Own night.
                </div>
            </div>
        </div>
    </div>
    <div class=""nk-gap-2""></div>
    <div class=""nk-gap-6""></div>
</div>
<!-- END: Features -->
<!-- START: About -->
<div class=""nk-box bg-dark-1"">
    <div class=""contai");
            WriteLiteral(@"ner text-center"">
        <div class=""nk-gap-6""></div>
        <div class=""nk-gap-2""></div>
        <h2 class=""nk-title h1"">About The Site</h2>
        <div class=""nk-gap-3""></div>

        <p class=""lead"">Together face In. His called Two lesser given divide. From, cattle saying be was doesn't set. Creature bearing life wherein dominion in saying them moveth first have. Under set darkness over light beast face fill from in after isn't first own all fowl itself evening also, grass doesn't Sea. Created very likeness herb wherein from lesser was bring brought above. Bearing tree a grass very.</p>

        <div class=""nk-gap-2""></div>
        <div class=""row no-gutters"">
            <div class=""col-md-4"">
                <div class=""nk-box-2 nk-box-line"">
                    <!-- START: Counter -->
                    <div class=""nk-counter-3"">
                        <div class=""nk-count"">65</div>
                        <h3 class=""nk-counter-title h4"">Unique Classes</h3>
                        ");
            WriteLiteral(@"<div class=""nk-gap-1""></div>
                    </div>
                    <!-- END: Counter -->
                </div>
            </div>
            <div class=""col-md-4"">
                <div class=""nk-box-2 nk-box-line"">
                    <!-- START: Counter -->
                    <div class=""nk-counter-3"">
                        <div class=""nk-count"">145</div>
                        <h3 class=""nk-counter-title h4"">Epic Bosses</h3>
                        <div class=""nk-gap-1""></div>
                    </div>
                    <!-- END: Counter -->
                </div>
            </div>
            <div class=""col-md-4"">
                <div class=""nk-box-2 nk-box-line"">
                    <!-- START: Counter -->
                    <div class=""nk-counter-3"">
                        <div class=""nk-count"">35</div>
                        <h3 class=""nk-counter-title h4"">Castles</h3>
                        <div class=""nk-gap-1""></div>
                    </div>
         ");
            WriteLiteral(@"           <!-- END: Counter -->
                </div>
            </div>
        </div>
        <div class=""nk-gap-2""></div>
        <div class=""nk-gap-6""></div>
    </div>
</div>
<!-- END: About -->
<!-- START: Testimonials -->
<div class=""nk-gap-6""></div>
<div class=""nk-gap-2""></div>
<div class=""nk-carousel-2"" data-autoplay=""12000"" data-dots=""true"">
    <div class=""nk-carousel-inner"">
        <div>
            <div>
                <blockquote class=""nk-testimonial-2"">
                    <div class=""nk-testimonial-photo"" style=""background-image: url('images/avatar-1-sm.jpg');""></div>
                    <div class=""nk-testimonial-body"">
                        <em>""Bring. Isn't years gathered give made moved. Waters sea forth. It. Gathered own abundantly kind can't it, lesser behold, may.""</em>
                    </div>
                    <div class=""nk-testimonial-name h4"">Lesa Cruz</div>
                    <div class=""nk-testimonial-source"">Frontend Developer, Google</div>
   ");
            WriteLiteral(@"             </blockquote>
            </div>
        </div>
        <div>
            <div>
                <blockquote class=""nk-testimonial-2"">
                    <div class=""nk-testimonial-photo"" style=""background-image: url('images/avatar-2-sm.jpg');""></div>
                    <div class=""nk-testimonial-body"">
                        <em>""Years heaven. Dominion light and every appear that creeping all. Light gathering don't given made give open, cattle was light.""</em>
                    </div>
                    <div class=""nk-testimonial-name h4"">Kurt Tucker</div>
                    <div class=""nk-testimonial-source"">CEO, Envato</div>
                </blockquote>
            </div>
        </div>
        <div>
            <div>
                <blockquote class=""nk-testimonial-2"">
                    <div class=""nk-testimonial-photo"" style=""background-image: url('images/avatar-3-sm.jpg');""></div>
                    <div class=""nk-testimonial-body"">
                        <em");
            WriteLiteral(@">""Female good moving Very thing form earth, for above herb dominion for made fifth. One them. Seas. Appear fourth seas.""</em>
                    </div>
                    <div class=""nk-testimonial-name h4"">Katie Anderson</div>
                    <div class=""nk-testimonial-source"">Product Designer, Apple</div>
                </blockquote>
            </div>
        </div>
        <div>
            <div>
                <blockquote class=""nk-testimonial-2"">
                    <div class=""nk-testimonial-photo"" style=""background-image: url('images/avatar-4-sm.jpg');""></div>
                    <div class=""nk-testimonial-body"">
                        <em>""Yielding be was which heaven fill fruit. You'll shall doesn't green. His divided they're of won't you isn't void cattle.""</em>
                    </div>
                    <div class=""nk-testimonial-name h4"">Luke Fuller</div>
                    <div class=""nk-testimonial-source"">Copywriter, Dropbox</div>
                </blockquote>
  ");
            WriteLiteral(@"          </div>
        </div>
        <div>
            <div>
                <blockquote class=""nk-testimonial-2"">
                    <div class=""nk-testimonial-photo"" style=""background-image: url('images/avatar-5-sm.jpg');""></div>
                    <div class=""nk-testimonial-body"">
                        <em>""God, have rule living creature own the signs. Set herb open, seed wherein god appear shall give lights. Waters to.""</em>
                    </div>
                    <div class=""nk-testimonial-name h4"">Felicia Meyer</div>
                    <div class=""nk-testimonial-source"">Backend Developer, Twitter</div>
                </blockquote>
            </div>
        </div>
    </div>
</div>
<div class=""nk-gap-2""></div>
<div class=""nk-gap-6""></div>
<!-- END: Testimonials -->");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<GameHeaven.ViewModels.HomeViewModel> Html { get; private set; }
    }
}
#pragma warning restore 1591
