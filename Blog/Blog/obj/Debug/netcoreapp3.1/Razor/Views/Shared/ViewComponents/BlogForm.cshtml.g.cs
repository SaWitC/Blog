#pragma checksum "C:\Users\USER\Downloads\Blog\Blog\Blog\Views\Shared\ViewComponents\BlogForm.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "fbb067693cc09678eeb47a332c6bf514dfbc7a83"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Shared_ViewComponents_BlogForm), @"mvc.1.0.view", @"/Views/Shared/ViewComponents/BlogForm.cshtml")]
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
#line 1 "C:\Users\USER\Downloads\Blog\Blog\Blog\Views\_ViewImports.cshtml"
using Blog;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\USER\Downloads\Blog\Blog\Blog\Views\_ViewImports.cshtml"
using Microsoft.AspNetCore.Html;

#line default
#line hidden
#nullable disable
#nullable restore
#line 3 "C:\Users\USER\Downloads\Blog\Blog\Blog\Views\_ViewImports.cshtml"
using Blog.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"fbb067693cc09678eeb47a332c6bf514dfbc7a83", @"/Views/Shared/ViewComponents/BlogForm.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"d5a7e505ca30c1491cf8ad5fdf35270d2c6e262f", @"/Views/_ViewImports.cshtml")]
    public class Views_Shared_ViewComponents_BlogForm : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<Blog.Models.ArticleModel>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\n\n<div class=\"col-8\">\n    <div class=\"card mb-3\">\n");
#nullable restore
#line 6 "C:\Users\USER\Downloads\Blog\Blog\Blog\Views\Shared\ViewComponents\BlogForm.cshtml"
         if (!string.IsNullOrEmpty(Model.HelloImage.ImageName))
        {

#line default
#line hidden
#nullable disable
            WriteLiteral("            <img class=\"card-img-top\"");
            BeginWriteAttribute("src", " src=\"", 193, "\"", 272, 1);
#nullable restore
#line 8 "C:\Users\USER\Downloads\Blog\Blog\Blog\Views\Shared\ViewComponents\BlogForm.cshtml"
WriteAttributeValue("", 199, $"/Image/{Model.Title}_{Model.AvtorName}/{Model.HelloImage.ImageName}", 199, 73, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" />\n");
#nullable restore
#line 9 "C:\Users\USER\Downloads\Blog\Blog\Blog\Views\Shared\ViewComponents\BlogForm.cshtml"
        }

#line default
#line hidden
#nullable disable
            WriteLiteral("        <div class=\"card-body\">\n            <h5 class=\"card-title\">");
#nullable restore
#line 11 "C:\Users\USER\Downloads\Blog\Blog\Blog\Views\Shared\ViewComponents\BlogForm.cshtml"
                              Write(Model.Title);

#line default
#line hidden
#nullable disable
            WriteLiteral("</h5>\n");
#nullable restore
#line 12 "C:\Users\USER\Downloads\Blog\Blog\Blog\Views\Shared\ViewComponents\BlogForm.cshtml"
             if (!string.IsNullOrEmpty(Model.ShortDesk))
            {

#line default
#line hidden
#nullable disable
            WriteLiteral("                <p class=\"card-text\">");
#nullable restore
#line 14 "C:\Users\USER\Downloads\Blog\Blog\Blog\Views\Shared\ViewComponents\BlogForm.cshtml"
                                Write(Model.ShortDesk);

#line default
#line hidden
#nullable disable
            WriteLiteral("</p>\n");
#nullable restore
#line 15 "C:\Users\USER\Downloads\Blog\Blog\Blog\Views\Shared\ViewComponents\BlogForm.cshtml"
            }

#line default
#line hidden
#nullable disable
            WriteLiteral("\n            <p class=\"card-text\"><small class=\"text-muted\">дата последнего обновления  ");
#nullable restore
#line 17 "C:\Users\USER\Downloads\Blog\Blog\Blog\Views\Shared\ViewComponents\BlogForm.cshtml"
                                                                                  Write(Model.ReleseDate);

#line default
#line hidden
#nullable disable
            WriteLiteral("</small></p>\n        </div>\n    </div>\n</div>");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<Blog.Models.ArticleModel> Html { get; private set; }
    }
}
#pragma warning restore 1591
