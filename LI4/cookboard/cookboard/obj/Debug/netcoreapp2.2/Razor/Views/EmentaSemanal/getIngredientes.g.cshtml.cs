#pragma checksum "C:\Users\Operador\Desktop\LI4\cookboard\cookboard\Views\EmentaSemanal\getIngredientes.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "4563a910cb0434e07716cb4e0977b5a4ca78ca60"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_EmentaSemanal_getIngredientes), @"mvc.1.0.view", @"/Views/EmentaSemanal/getIngredientes.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/EmentaSemanal/getIngredientes.cshtml", typeof(AspNetCore.Views_EmentaSemanal_getIngredientes))]
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
#line 1 "C:\Users\Operador\Desktop\LI4\cookboard\cookboard\Views\_ViewImports.cshtml"
using cookboard;

#line default
#line hidden
#line 2 "C:\Users\Operador\Desktop\LI4\cookboard\cookboard\Views\_ViewImports.cshtml"
using cookboard.Models;

#line default
#line hidden
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"4563a910cb0434e07716cb4e0977b5a4ca78ca60", @"/Views/EmentaSemanal/getIngredientes.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"86a90c57a68cdbde153aed1e2defab61f9de9b49", @"/Views/_ViewImports.cshtml")]
    public class Views_EmentaSemanal_getIngredientes : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<IEnumerable<cookboard.Models.Ingrediente>>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#line 2 "C:\Users\Operador\Desktop\LI4\cookboard\cookboard\Views\EmentaSemanal\getIngredientes.cshtml"
  
    ViewBag.Title = "getIngredientes";
    string currentType = (string)@ViewData["Type"];

    switch (currentType)
    {
        case "Professor":
            Layout = "~/Views/Shared/_LayoutProfessor.cshtml";
            break;
        case "Aluno":
            Layout = "~/Views/Shared/_LayoutAluno.cshtml";
            break;
    }

#line default
#line hidden
            BeginContext(406, 264, true);
            WriteLiteral(@"
<div style=""display:flex; justify-content: space-between"">
    <h1 style=""margin-left: 24px;"">
        Lista Ingredientes
    </h1>
    <input style=""margin-right: 24px;"" type=""button"" class=""btn btn-light"" style=""float:right;"" value=""Localizar Ingredientes""");
            EndContext();
            BeginWriteAttribute("onclick", " onclick=\"", 670, "\"", 768, 3);
            WriteAttributeValue("", 680, "location.href=\'", 680, 15, true);
#line 21 "C:\Users\Operador\Desktop\LI4\cookboard\cookboard\Views\EmentaSemanal\getIngredientes.cshtml"
WriteAttributeValue("", 695, Url.Action("getLocalizacao","LocalIngrediente", new { idReceita = 1 }), 695, 71, false);

#line default
#line hidden
            WriteAttributeValue("", 766, "\';", 766, 2, true);
            EndWriteAttribute();
            BeginContext(769, 57, true);
            WriteLiteral(" />\r\n</div>\r\n\r\n<hr>\r\n\r\n<div style=\"margin-left: 24px;\">\r\n");
            EndContext();
#line 27 "C:\Users\Operador\Desktop\LI4\cookboard\cookboard\Views\EmentaSemanal\getIngredientes.cshtml"
     foreach (var item in Model)
    {

#line default
#line hidden
            BeginContext(867, 32, true);
            WriteLiteral("        <input type=\"checkbox\"> ");
            EndContext();
            BeginContext(900, 39, false);
#line 29 "C:\Users\Operador\Desktop\LI4\cookboard\cookboard\Views\EmentaSemanal\getIngredientes.cshtml"
                           Write(Html.DisplayFor(modelItem => item.Nome));

#line default
#line hidden
            EndContext();
            BeginContext(941, 14, true);
            WriteLiteral("        <hr>\r\n");
            EndContext();
#line 31 "C:\Users\Operador\Desktop\LI4\cookboard\cookboard\Views\EmentaSemanal\getIngredientes.cshtml"
    }

#line default
#line hidden
            BeginContext(962, 6, true);
            WriteLiteral("</div>");
            EndContext();
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<IEnumerable<cookboard.Models.Ingrediente>> Html { get; private set; }
    }
}
#pragma warning restore 1591
