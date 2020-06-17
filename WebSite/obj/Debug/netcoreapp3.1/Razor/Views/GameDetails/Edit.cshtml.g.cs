#pragma checksum "C:\Users\la-jbergs\source\repos\GameRatings\WebSite\Views\GameDetails\Edit.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "7c74d93d45646bc87a1c783f479118a08ddda562"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_GameDetails_Edit), @"mvc.1.0.view", @"/Views/GameDetails/Edit.cshtml")]
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
#line 1 "C:\Users\la-jbergs\source\repos\GameRatings\WebSite\Views\_ViewImports.cshtml"
using WebSite;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\la-jbergs\source\repos\GameRatings\WebSite\Views\_ViewImports.cshtml"
using WebSite.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"7c74d93d45646bc87a1c783f479118a08ddda562", @"/Views/GameDetails/Edit.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"546770ff9246d2b4986958786c45c43a7dfdf5c0", @"/Views/_ViewImports.cshtml")]
    public class Views_GameDetails_Edit : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<Data.Models.Games>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("name", new global::Microsoft.AspNetCore.Html.HtmlString("saveChanges"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-controller", "GameDetails", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "SaveChanges", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_3 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("method", "post", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.FormActionTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_FormActionTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("form", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "7c74d93d45646bc87a1c783f479118a08ddda5624640", async() => {
                WriteLiteral("\r\n    <div class=\"wrapper\">\r\n        <div>\r\n            <h2>");
#nullable restore
#line 6 "C:\Users\la-jbergs\source\repos\GameRatings\WebSite\Views\GameDetails\Edit.cshtml"
           Write(Model.Name);

#line default
#line hidden
#nullable disable
                WriteLiteral("</h2>\r\n        </div>\r\n        <div class=\"score\">\r\n            <b><input type=\"text\" size=\"1\" name=\"score\"");
                BeginWriteAttribute("value", " value=\"", 226, "\"", 253, 1);
#nullable restore
#line 9 "C:\Users\la-jbergs\source\repos\GameRatings\WebSite\Views\GameDetails\Edit.cshtml"
WriteAttributeValue("", 234, Model.Rating.Score, 234, 19, false);

#line default
#line hidden
#nullable disable
                EndWriteAttribute();
                WriteLiteral(" /></b><br />\r\n        </div>\r\n        <div>\r\n            Developer:\r\n");
#nullable restore
#line 13 "C:\Users\la-jbergs\source\repos\GameRatings\WebSite\Views\GameDetails\Edit.cshtml"
              
                string developers = "";
                int i = 0;
                foreach (var dev in Model.Developers)
                {
                    developers += dev.Name;
                    if (i < Model.Developers.Count - 1)
                    {
                        developers += ";";
                    }
                    i++;
                }
            

#line default
#line hidden
#nullable disable
                WriteLiteral("            <input type=\"text\" name=\"developers\"");
                BeginWriteAttribute("value", " value=\"", 783, "\"", 802, 1);
#nullable restore
#line 26 "C:\Users\la-jbergs\source\repos\GameRatings\WebSite\Views\GameDetails\Edit.cshtml"
WriteAttributeValue("", 791, developers, 791, 11, false);

#line default
#line hidden
#nullable disable
                EndWriteAttribute();
                WriteLiteral(" /> (Einträge durch \';\' trennen)\r\n            <br />\r\n            Publisher:\r\n            <input type=\"text\" name=\"publisher\"");
                BeginWriteAttribute("value", " value=\"", 928, "\"", 957, 1);
#nullable restore
#line 29 "C:\Users\la-jbergs\source\repos\GameRatings\WebSite\Views\GameDetails\Edit.cshtml"
WriteAttributeValue("", 936, Model.Publisher.Name, 936, 21, false);

#line default
#line hidden
#nullable disable
                EndWriteAttribute();
                WriteLiteral(" />\r\n            <br />\r\n");
#nullable restore
#line 31 "C:\Users\la-jbergs\source\repos\GameRatings\WebSite\Views\GameDetails\Edit.cshtml"
              
                string genres = "";
                i = 0;
                foreach (var gen in Model.Genres)
                {
                    genres += gen.Name;
                    if (i < Model.Genres.Count - 1)
                    {
                        genres += ";";
                    }
                    i++;
                }
            

#line default
#line hidden
#nullable disable
                WriteLiteral("            Genre: \r\n            <input type=\"text\" name=\"genres\"");
                BeginWriteAttribute("value", " value=\"", 1435, "\"", 1450, 1);
#nullable restore
#line 45 "C:\Users\la-jbergs\source\repos\GameRatings\WebSite\Views\GameDetails\Edit.cshtml"
WriteAttributeValue("", 1443, genres, 1443, 7, false);

#line default
#line hidden
#nullable disable
                EndWriteAttribute();
                WriteLiteral(" />\r\n            <br /><br />\r\n            <textarea name=\"description\" maxlength=\"800\" cols=\"80\" rows=\"8\">");
#nullable restore
#line 47 "C:\Users\la-jbergs\source\repos\GameRatings\WebSite\Views\GameDetails\Edit.cshtml"
                                                                       Write(Model.Description);

#line default
#line hidden
#nullable disable
                WriteLiteral("</textarea>\r\n        </div>\r\n        <div>\r\n            <img");
                BeginWriteAttribute("src", " src=\"", 1636, "\"", 1682, 1);
#nullable restore
#line 50 "C:\Users\la-jbergs\source\repos\GameRatings\WebSite\Views\GameDetails\Edit.cshtml"
WriteAttributeValue("", 1642, Url.Content(ViewData["img"].ToString()), 1642, 40, false);

#line default
#line hidden
#nullable disable
                EndWriteAttribute();
                WriteLiteral(" runat=\"server\" width=\"200\" height=\"300\" />\r\n        </div>\r\n        <div>\r\n            <a");
                BeginWriteAttribute("href", " href=\"", 1773, "\"", 1796, 1);
#nullable restore
#line 53 "C:\Users\la-jbergs\source\repos\GameRatings\WebSite\Views\GameDetails\Edit.cshtml"
WriteAttributeValue("", 1780, Model.Link.Link, 1780, 16, false);

#line default
#line hidden
#nullable disable
                EndWriteAttribute();
                WriteLiteral(">Mehr Informationen</a>\r\n        </div>\r\n        <div>\r\n            <input type=\"hidden\" name=\"name\"");
                BeginWriteAttribute("value", " value=\"", 1897, "\"", 1916, 1);
#nullable restore
#line 56 "C:\Users\la-jbergs\source\repos\GameRatings\WebSite\Views\GameDetails\Edit.cshtml"
WriteAttributeValue("", 1905, Model.Name, 1905, 11, false);

#line default
#line hidden
#nullable disable
                EndWriteAttribute();
                WriteLiteral(" />\r\n            ");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("Button", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "7c74d93d45646bc87a1c783f479118a08ddda56210256", async() => {
                    WriteLiteral("Änderungen speichern");
                }
                );
                __Microsoft_AspNetCore_Mvc_TagHelpers_FormActionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.FormActionTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_FormActionTagHelper);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
                __Microsoft_AspNetCore_Mvc_TagHelpers_FormActionTagHelper.Controller = (string)__tagHelperAttribute_1.Value;
                __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_1);
                __Microsoft_AspNetCore_Mvc_TagHelpers_FormActionTagHelper.Action = (string)__tagHelperAttribute_2.Value;
                __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_2);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                WriteLiteral(" \r\n        </div>\r\n    </div>\r\n");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Method = (string)__tagHelperAttribute_3.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_3);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<Data.Models.Games> Html { get; private set; }
    }
}
#pragma warning restore 1591
