#pragma checksum "D:\FileCopy\Blog\Blog\Blog\Views\ArticleModel\Patrial\HelperElements.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "b301deb5a5be4b79f533aa0035fe26b9c9405ee9"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_ArticleModel_Patrial_HelperElements), @"mvc.1.0.view", @"/Views/ArticleModel/Patrial/HelperElements.cshtml")]
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
#line 1 "D:\FileCopy\Blog\Blog\Blog\Views\_ViewImports.cshtml"
using Blog;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "D:\FileCopy\Blog\Blog\Blog\Views\_ViewImports.cshtml"
using Microsoft.AspNetCore.Html;

#line default
#line hidden
#nullable disable
#nullable restore
#line 3 "D:\FileCopy\Blog\Blog\Blog\Views\_ViewImports.cshtml"
using Blog.Models;

#line default
#line hidden
#nullable disable
#nullable restore
#line 4 "D:\FileCopy\Blog\Blog\Blog\Views\_ViewImports.cshtml"
using System.Web.Optimization;

#line default
#line hidden
#nullable disable
#nullable restore
#line 5 "D:\FileCopy\Blog\Blog\Blog\Views\_ViewImports.cshtml"
using System.Web;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"b301deb5a5be4b79f533aa0035fe26b9c9405ee9", @"/Views/ArticleModel/Patrial/HelperElements.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"9713a26c4f3f3e7bb722477aa97a2634cba05d49", @"/Views/_ViewImports.cshtml")]
    public class Views_ArticleModel_Patrial_HelperElements : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-area", "", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("btn input-group bg-white border-dark"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-controller", "Home", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_3 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Info", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
            WriteLiteral("<div class=\"bg-info text-white w-100\">\r\n    <div class=\"col-12 p_l_and_r_none\">\r\n        <h5 style=\"margin-top:40px\" class=\"input-group\">Вспомогательные элементы</h5>\r\n    </div>\r\n</div>\r\n<div class=\"col-12 mb-5 p_l_and_r_none\">\r\n    ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "b301deb5a5be4b79f533aa0035fe26b9c9405ee95100", async() => {
                WriteLiteral("Как использовать");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Area = (string)__tagHelperAttribute_0.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_1);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Controller = (string)__tagHelperAttribute_2.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_2);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_3.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_3);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral(@"
</div>

<!--Заголовки-->
<div class=""col-12 p_l_and_r_none"">
    <div class=""dropdown input-group"">
        <button class="" btn input-group text-white swap-s-btn"" style=""border-left:1px solid #0d8bf2"">
            Заголовки
        </button>
        <div class=""dropdown-content"">
            <button type=""submit"" class=""btn input-group"" onclick=""h2f()""><h2>Заголовок</h2></button>
            <button type=""submit"" class=""btn input-group"" onclick=""h3f();""><h3>Заголовок</h3></button>
            <button type=""submit"" class=""btn input-group"" onclick=""h4f()""><h4>Заголовок</h4></button>
            <button type=""submit"" class=""btn input-group"" onclick=""h5f()""><h5>Заголовок</h5></button>
            <button type=""submit"" class=""btn input-group"" onclick=""h6f()""><h6>Заголовок</h6></button>
        </div>
    </div>
</div>

<hr class=""mb-5 mt-5"" />
<!--Начертания-->
<div class=""col-12  p_l_and_r_none"">
    <div class=""dropdown input-group"">
        <button class="" w-100 btn input-group text-whit");
            WriteLiteral(@"e swap-s-btn"" style=""border-left:1px solid #0d8bf2"">
            Начертания
        </button>
        <div class=""dropdown-content"">
            <button type=""submit"" class=""btn input-group"" onclick=""document.getElementById('text').value+='<b>Ваш текст здесь </b>'; return false;""><b>Текст</b></button>
            <button type=""submit"" class=""btn input-group"" onclick=""document.getElementById('text').value += '<i>ваш текст здесь </i>'; return false""><i>Текст</i></button>
            <button type=""submit"" class=""btn input-group"" onclick=""document.getElementById('text').value += '<em>ваш текст здесь </em>'; return false""><em>Текст</em></button>
            <button type=""submit"" class=""btn input-group"" onclick=""document.getElementById('text').value += '<small>ваш текст здесь </small>'; return false""><small>Текст</small></button>
            <button type=""submit"" class=""btn input-group"" onclick=""document.getElementById('text').value += '<strong>ваш текст здесь </strong>'; return false""><strong>Текст</strong");
            WriteLiteral("></button>\r\n            <button type=\"submit\" class=\"btn input-group\" onclick=\"document.getElementById(\'text\').value += \'<sub>ваш текст здесь </sub>\'; return false\"><sub>Текст</sub></button>\r\n        </div>\r\n    </div>\r\n</div>\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<dynamic> Html { get; private set; }
    }
}
#pragma warning restore 1591