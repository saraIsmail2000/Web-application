#pragma checksum "C:\Users\HP-PC\source\repos\Social$Form - Copy\Social$orm\Views\Report\FamilyReports.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "6e72051a6f8fdab13767cd0cf39ecc8b1d6f058e"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Report_FamilyReports), @"mvc.1.0.view", @"/Views/Report/FamilyReports.cshtml")]
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
#line 1 "C:\Users\HP-PC\source\repos\Social$Form - Copy\Social$orm\Views\_ViewImports.cshtml"
using Social_orm;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\HP-PC\source\repos\Social$Form - Copy\Social$orm\Views\_ViewImports.cshtml"
using Social_orm.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"6e72051a6f8fdab13767cd0cf39ecc8b1d6f058e", @"/Views/Report/FamilyReports.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"4aa14fcee2d4d03258b87223794c3822ef90de4b", @"/Views/_ViewImports.cshtml")]
    public class Views_Report_FamilyReports : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<IEnumerable<Social_orm.ViewModel.SpecialFormForAFamily>>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n");
#nullable restore
#line 3 "C:\Users\HP-PC\source\repos\Social$Form - Copy\Social$orm\Views\Report\FamilyReports.cshtml"
  
    ViewData["Title"] = "FamilyReports";

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n<h1 class=\"text-center\">Family Reports :<i class=\"fa fa-file-text-o\" aria-hidden=\"true\"></i></h1>\r\n\r\n<br>\r\n\r\n\r\n<table id=\"table_1\" class=\"container table table-bordered table-light\">\r\n    <thead >\r\n        <tr>\r\n            <th>\r\n                ");
#nullable restore
#line 16 "C:\Users\HP-PC\source\repos\Social$Form - Copy\Social$orm\Views\Report\FamilyReports.cshtml"
           Write(Html.DisplayNameFor(model => model.BeneficiarId));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </th>\r\n            <th>\r\n                ");
#nullable restore
#line 19 "C:\Users\HP-PC\source\repos\Social$Form - Copy\Social$orm\Views\Report\FamilyReports.cshtml"
           Write(Html.DisplayNameFor(model => model.BeneficiarName));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </th>\r\n            <th>\r\n                ");
#nullable restore
#line 22 "C:\Users\HP-PC\source\repos\Social$Form - Copy\Social$orm\Views\Report\FamilyReports.cshtml"
           Write(Html.DisplayNameFor(model => model.TotalNbOfFamily));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </th>\r\n            <th>\r\n                ");
#nullable restore
#line 25 "C:\Users\HP-PC\source\repos\Social$Form - Copy\Social$orm\Views\Report\FamilyReports.cshtml"
           Write(Html.DisplayNameFor(model => model.TotalFamilyWorkers));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </th>\r\n            <th>\r\n                ");
#nullable restore
#line 28 "C:\Users\HP-PC\source\repos\Social$Form - Copy\Social$orm\Views\Report\FamilyReports.cshtml"
           Write(Html.DisplayNameFor(model => model.TotalNbofRooms));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </th>\r\n            <th>\r\n                ");
#nullable restore
#line 31 "C:\Users\HP-PC\source\repos\Social$Form - Copy\Social$orm\Views\Report\FamilyReports.cshtml"
           Write(Html.DisplayNameFor(model => model.TotalMonthIncome));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </th>\r\n            <th>\r\n                ");
#nullable restore
#line 34 "C:\Users\HP-PC\source\repos\Social$Form - Copy\Social$orm\Views\Report\FamilyReports.cshtml"
           Write(Html.DisplayNameFor(model => model.TotalNbofStudents));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </th>\r\n            <th>\r\n                ");
#nullable restore
#line 37 "C:\Users\HP-PC\source\repos\Social$Form - Copy\Social$orm\Views\Report\FamilyReports.cshtml"
           Write(Html.DisplayNameFor(model => model.TotalNbOfstudInUni));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </th>\r\n            <th>\r\n                ");
#nullable restore
#line 40 "C:\Users\HP-PC\source\repos\Social$Form - Copy\Social$orm\Views\Report\FamilyReports.cshtml"
           Write(Html.DisplayNameFor(model => model.HomeRent));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </th>\r\n            <th>\r\n                ");
#nullable restore
#line 43 "C:\Users\HP-PC\source\repos\Social$Form - Copy\Social$orm\Views\Report\FamilyReports.cshtml"
           Write(Html.DisplayNameFor(model => model.JobType));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </th>\r\n            <th>\r\n                ");
#nullable restore
#line 46 "C:\Users\HP-PC\source\repos\Social$Form - Copy\Social$orm\Views\Report\FamilyReports.cshtml"
           Write(Html.DisplayNameFor(model => model.NbDiseaseAndHandicap));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </th>\r\n            <th>\r\n                ");
#nullable restore
#line 49 "C:\Users\HP-PC\source\repos\Social$Form - Copy\Social$orm\Views\Report\FamilyReports.cshtml"
           Write(Html.DisplayNameFor(model => model.totalRate));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </th>\r\n\r\n        </tr>\r\n    </thead>\r\n    <tbody>\r\n");
#nullable restore
#line 55 "C:\Users\HP-PC\source\repos\Social$Form - Copy\Social$orm\Views\Report\FamilyReports.cshtml"
         foreach (var item in Model)
        {

#line default
#line hidden
#nullable disable
            WriteLiteral("        <tr>\r\n            <td>\r\n                ");
#nullable restore
#line 59 "C:\Users\HP-PC\source\repos\Social$Form - Copy\Social$orm\Views\Report\FamilyReports.cshtml"
           Write(Html.DisplayFor(modelItem => item.BeneficiarId));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </td>\r\n            <td>\r\n                ");
#nullable restore
#line 62 "C:\Users\HP-PC\source\repos\Social$Form - Copy\Social$orm\Views\Report\FamilyReports.cshtml"
           Write(Html.DisplayFor(modelItem => item.BeneficiarName));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </td>\r\n            <td>\r\n                ");
#nullable restore
#line 65 "C:\Users\HP-PC\source\repos\Social$Form - Copy\Social$orm\Views\Report\FamilyReports.cshtml"
           Write(Html.DisplayFor(modelItem => item.TotalNbOfFamily));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </td>\r\n            <td>\r\n                ");
#nullable restore
#line 68 "C:\Users\HP-PC\source\repos\Social$Form - Copy\Social$orm\Views\Report\FamilyReports.cshtml"
           Write(Html.DisplayFor(modelItem => item.TotalFamilyWorkers));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </td>\r\n            <td>\r\n                ");
#nullable restore
#line 71 "C:\Users\HP-PC\source\repos\Social$Form - Copy\Social$orm\Views\Report\FamilyReports.cshtml"
           Write(Html.DisplayFor(modelItem => item.TotalNbofRooms));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </td>\r\n            <td>\r\n                ");
#nullable restore
#line 74 "C:\Users\HP-PC\source\repos\Social$Form - Copy\Social$orm\Views\Report\FamilyReports.cshtml"
           Write(Html.DisplayFor(modelItem => item.TotalMonthIncome));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </td>\r\n            <td>\r\n                ");
#nullable restore
#line 77 "C:\Users\HP-PC\source\repos\Social$Form - Copy\Social$orm\Views\Report\FamilyReports.cshtml"
           Write(Html.DisplayFor(modelItem => item.TotalNbofStudents));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </td>\r\n            <td>\r\n                ");
#nullable restore
#line 80 "C:\Users\HP-PC\source\repos\Social$Form - Copy\Social$orm\Views\Report\FamilyReports.cshtml"
           Write(Html.DisplayFor(modelItem => item.TotalNbOfstudInUni));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </td>\r\n            <td>\r\n                ");
#nullable restore
#line 83 "C:\Users\HP-PC\source\repos\Social$Form - Copy\Social$orm\Views\Report\FamilyReports.cshtml"
           Write(Html.DisplayFor(modelItem => item.HomeRent));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </td>\r\n            <td>\r\n                ");
#nullable restore
#line 86 "C:\Users\HP-PC\source\repos\Social$Form - Copy\Social$orm\Views\Report\FamilyReports.cshtml"
           Write(Html.DisplayFor(modelItem => item.JobType));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </td>\r\n            <td>\r\n                ");
#nullable restore
#line 89 "C:\Users\HP-PC\source\repos\Social$Form - Copy\Social$orm\Views\Report\FamilyReports.cshtml"
           Write(Html.DisplayFor(modelItem => item.NbDiseaseAndHandicap));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </td>\r\n            <td>\r\n                ");
#nullable restore
#line 92 "C:\Users\HP-PC\source\repos\Social$Form - Copy\Social$orm\Views\Report\FamilyReports.cshtml"
           Write(Html.DisplayFor(modelItem => item.totalRate));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </td>\r\n\r\n        </tr>\r\n");
#nullable restore
#line 96 "C:\Users\HP-PC\source\repos\Social$Form - Copy\Social$orm\Views\Report\FamilyReports.cshtml"
        }

#line default
#line hidden
#nullable disable
            WriteLiteral("    </tbody>\r\n</table>\r\n\r\n");
            DefineSection("Scripts", async() => {
                WriteLiteral("\r\n    <script>\r\n        $(document).ready(function () {\r\n            $(\'#table_1\').DataTable();\r\n        });\r\n    </script>\r\n");
            }
            );
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<IEnumerable<Social_orm.ViewModel.SpecialFormForAFamily>> Html { get; private set; }
    }
}
#pragma warning restore 1591
