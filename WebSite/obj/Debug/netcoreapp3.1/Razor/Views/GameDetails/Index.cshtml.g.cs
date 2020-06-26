#pragma checksum "C:\Users\la-jbergs\source\repos\GameRatings\WebSite\Views\GameDetails\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "1de6b2efd12d29f2c739b1aa84fc9823d28c617f"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_GameDetails_Index), @"mvc.1.0.view", @"/Views/GameDetails/Index.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"1de6b2efd12d29f2c739b1aa84fc9823d28c617f", @"/Views/GameDetails/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"546770ff9246d2b4986958786c45c43a7dfdf5c0", @"/Views/_ViewImports.cshtml")]
    public class Views_GameDetails_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<Data.Models.Games>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n<div class=\"wrapper\">\r\n    <div>\r\n        <h2>");
#nullable restore
#line 5 "C:\Users\la-jbergs\source\repos\GameRatings\WebSite\Views\GameDetails\Index.cshtml"
       Write(Model.Name);

#line default
#line hidden
#nullable disable
            WriteLiteral("</h2>\r\n    </div>\r\n    <div class=\"score\">\r\n        <b>");
#nullable restore
#line 8 "C:\Users\la-jbergs\source\repos\GameRatings\WebSite\Views\GameDetails\Index.cshtml"
      Write(Model.Rating.Score);

#line default
#line hidden
#nullable disable
            WriteLiteral("</b><br />\r\n    </div>\r\n    <div>\r\n        <b>Developer</b>\r\n        <hr />\r\n");
#nullable restore
#line 13 "C:\Users\la-jbergs\source\repos\GameRatings\WebSite\Views\GameDetails\Index.cshtml"
          
            int i = 0;
            foreach (var dev in Model.Developers)
            {
                

#line default
#line hidden
#nullable disable
#nullable restore
#line 17 "C:\Users\la-jbergs\source\repos\GameRatings\WebSite\Views\GameDetails\Index.cshtml"
           Write(dev.Name);

#line default
#line hidden
#nullable disable
#nullable restore
#line 17 "C:\Users\la-jbergs\source\repos\GameRatings\WebSite\Views\GameDetails\Index.cshtml"
                         
                if (i < Model.Developers.Count - 1)
                {
                    

#line default
#line hidden
#nullable disable
#nullable restore
#line 20 "C:\Users\la-jbergs\source\repos\GameRatings\WebSite\Views\GameDetails\Index.cshtml"
               Write(Html.Raw(", "));

#line default
#line hidden
#nullable disable
#nullable restore
#line 20 "C:\Users\la-jbergs\source\repos\GameRatings\WebSite\Views\GameDetails\Index.cshtml"
                                   ;
                }
                i++;
            }
        

#line default
#line hidden
#nullable disable
            WriteLiteral("        <br /><br />\r\n        <b>Publisher</b>\r\n        <hr />\r\n        ");
#nullable restore
#line 28 "C:\Users\la-jbergs\source\repos\GameRatings\WebSite\Views\GameDetails\Index.cshtml"
   Write(Model.Publisher.Name);

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        <br /><br />\r\n        <b>Genre</b>\r\n        <hr />\r\n");
#nullable restore
#line 32 "C:\Users\la-jbergs\source\repos\GameRatings\WebSite\Views\GameDetails\Index.cshtml"
           
            i = 0;
            foreach (var gen in Model.Genres)
            {
                

#line default
#line hidden
#nullable disable
#nullable restore
#line 36 "C:\Users\la-jbergs\source\repos\GameRatings\WebSite\Views\GameDetails\Index.cshtml"
           Write(gen.Name);

#line default
#line hidden
#nullable disable
#nullable restore
#line 36 "C:\Users\la-jbergs\source\repos\GameRatings\WebSite\Views\GameDetails\Index.cshtml"
                         
                if (i < Model.Genres.Count - 1)
                {
                    

#line default
#line hidden
#nullable disable
#nullable restore
#line 39 "C:\Users\la-jbergs\source\repos\GameRatings\WebSite\Views\GameDetails\Index.cshtml"
               Write(Html.Raw(", "));

#line default
#line hidden
#nullable disable
#nullable restore
#line 39 "C:\Users\la-jbergs\source\repos\GameRatings\WebSite\Views\GameDetails\Index.cshtml"
                                   
                }
                i++;
            }
        

#line default
#line hidden
#nullable disable
            WriteLiteral("        <br /><br />\r\n        <b>Beschreibung</b>\r\n        <hr />\r\n        ");
#nullable restore
#line 47 "C:\Users\la-jbergs\source\repos\GameRatings\WebSite\Views\GameDetails\Index.cshtml"
   Write(Model.Description);

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        <br />\r\n    </div>\r\n    <div>\r\n        <img");
            BeginWriteAttribute("src", " src=\"", 1137, "\"", 1183, 1);
#nullable restore
#line 51 "C:\Users\la-jbergs\source\repos\GameRatings\WebSite\Views\GameDetails\Index.cshtml"
WriteAttributeValue("", 1143, Url.Content(ViewData["img"].ToString()), 1143, 40, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" runat=\"server\" width=\"200\" height=\"300\"/>\r\n    </div>\r\n    <div>\r\n        <a");
            BeginWriteAttribute("href", " href=\"", 1261, "\"", 1284, 1);
#nullable restore
#line 54 "C:\Users\la-jbergs\source\repos\GameRatings\WebSite\Views\GameDetails\Index.cshtml"
WriteAttributeValue("", 1268, Model.Link.Link, 1268, 16, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(">Mehr Informationen</a>\r\n    </div>\r\n    <div>\r\n        <a");
            BeginWriteAttribute("href", " href=\"", 1343, "\"", 1383, 2);
            WriteAttributeValue("", 1350, "GameDetails/Edit?name=", 1350, 22, true);
#nullable restore
#line 57 "C:\Users\la-jbergs\source\repos\GameRatings\WebSite\Views\GameDetails\Index.cshtml"
WriteAttributeValue("", 1372, Model.Name, 1372, 11, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(">Edit</a>\r\n    </div>\r\n</div>");
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
