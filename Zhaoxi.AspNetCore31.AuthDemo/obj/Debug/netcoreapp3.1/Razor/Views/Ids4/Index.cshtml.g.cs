#pragma checksum "D:\github\LC_IdentityServer4_Test\Zhaoxi.AspNetCore31.AuthDemo\Views\Ids4\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "2df54a6040e07eb8b25f353fdb2c12181b0fbcc0"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Ids4_Index), @"mvc.1.0.view", @"/Views/Ids4/Index.cshtml")]
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
#line 1 "D:\github\LC_IdentityServer4_Test\Zhaoxi.AspNetCore31.AuthDemo\Views\_ViewImports.cshtml"
using Zhaoxi.AspNetCore31.AuthDemo;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "D:\github\LC_IdentityServer4_Test\Zhaoxi.AspNetCore31.AuthDemo\Views\_ViewImports.cshtml"
using Zhaoxi.AspNetCore31.AuthDemo.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"2df54a6040e07eb8b25f353fdb2c12181b0fbcc0", @"/Views/Ids4/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"7c2d1545cf3eef9bec6959d728d8b3e4023bc784", @"/Views/_ViewImports.cshtml")]
    public class Views_Ids4_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n");
#nullable restore
#line 2 "D:\github\LC_IdentityServer4_Test\Zhaoxi.AspNetCore31.AuthDemo\Views\Ids4\Index.cshtml"
  
    ViewData["Title"] = "Index";

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n<h1>Index</h1>\r\n<h3>");
#nullable restore
#line 7 "D:\github\LC_IdentityServer4_Test\Zhaoxi.AspNetCore31.AuthDemo\Views\Ids4\Index.cshtml"
Write(base.Context.User.Identity.Name);

#line default
#line hidden
#nullable disable
            WriteLiteral("</h3>\r\n");
#nullable restore
#line 8 "D:\github\LC_IdentityServer4_Test\Zhaoxi.AspNetCore31.AuthDemo\Views\Ids4\Index.cshtml"
 foreach (var cliam in base.Context.User.Identities.First().Claims)
{

#line default
#line hidden
#nullable disable
            WriteLiteral("    <h3>**********************************************</h3>\r\n    <h4> ");
#nullable restore
#line 11 "D:\github\LC_IdentityServer4_Test\Zhaoxi.AspNetCore31.AuthDemo\Views\Ids4\Index.cshtml"
    Write(cliam.Type);

#line default
#line hidden
#nullable disable
            WriteLiteral(":");
#nullable restore
#line 11 "D:\github\LC_IdentityServer4_Test\Zhaoxi.AspNetCore31.AuthDemo\Views\Ids4\Index.cshtml"
                Write(cliam.Value);

#line default
#line hidden
#nullable disable
            WriteLiteral(" </h4>\r\n");
#nullable restore
#line 12 "D:\github\LC_IdentityServer4_Test\Zhaoxi.AspNetCore31.AuthDemo\Views\Ids4\Index.cshtml"
}

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n\r\n");
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
