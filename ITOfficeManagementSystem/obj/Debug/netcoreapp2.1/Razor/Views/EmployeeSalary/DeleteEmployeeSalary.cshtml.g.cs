#pragma checksum "D:\MY BOOKS\# IUBAT\Visual Projects\ITOfficeManagementSystem - Updated\ITOfficeManagementSystem\Views\EmployeeSalary\DeleteEmployeeSalary.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "e11a31cd1396348ce53ee0b783577cbfd75beef5"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_EmployeeSalary_DeleteEmployeeSalary), @"mvc.1.0.view", @"/Views/EmployeeSalary/DeleteEmployeeSalary.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/EmployeeSalary/DeleteEmployeeSalary.cshtml", typeof(AspNetCore.Views_EmployeeSalary_DeleteEmployeeSalary))]
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
#line 1 "D:\MY BOOKS\# IUBAT\Visual Projects\ITOfficeManagementSystem - Updated\ITOfficeManagementSystem\Views\_ViewImports.cshtml"
using ITOfficeManagementSystem;

#line default
#line hidden
#line 2 "D:\MY BOOKS\# IUBAT\Visual Projects\ITOfficeManagementSystem - Updated\ITOfficeManagementSystem\Views\_ViewImports.cshtml"
using ITOfficeManagementSystem.Models;

#line default
#line hidden
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"e11a31cd1396348ce53ee0b783577cbfd75beef5", @"/Views/EmployeeSalary/DeleteEmployeeSalary.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"7e9ed22bfe09eaf2dc609f444dceeff68f921123", @"/Views/_ViewImports.cshtml")]
    public class Views_EmployeeSalary_DeleteEmployeeSalary : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<ITOfficeManagementSystem.ViewModels.EmployeeSalaryVM>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("href", new global::Microsoft.AspNetCore.Html.HtmlString("~/vendor/fontawesome-free/css/all.min.css"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("rel", new global::Microsoft.AspNetCore.Html.HtmlString("stylesheet"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("type", new global::Microsoft.AspNetCore.Html.HtmlString("text/css"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_3 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("href", new global::Microsoft.AspNetCore.Html.HtmlString("~/css/sb-admin-2.min.css"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_4 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("type", "hidden", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_5 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-controller", "EmployeeSalary", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_6 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "EmployeeSalaryList", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_7 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("btn btn-outline-info"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_8 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "DeleteEmployeeSalary", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_9 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("src", new global::Microsoft.AspNetCore.Html.HtmlString("~/vendor/jquery/jquery.min.js"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_10 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("src", new global::Microsoft.AspNetCore.Html.HtmlString("~/vendor/bootstrap/js/bootstrap.bundle.min.js"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_11 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("src", new global::Microsoft.AspNetCore.Html.HtmlString("~/vendor/jquery-easing/jquery.easing.min.js"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_12 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("src", new global::Microsoft.AspNetCore.Html.HtmlString("~/js/sb-admin-2.min.js"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_13 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("style", new global::Microsoft.AspNetCore.Html.HtmlString("align-content: center; text-align: center;"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        #line hidden
        #pragma warning disable 0169
        private string __tagHelperStringValueBuffer;
        #pragma warning restore 0169
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperExecutionContext __tagHelperExecutionContext;
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner __tagHelperRunner = new global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner();
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
        private global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.HeadTagHelper __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_HeadTagHelper;
        private global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper;
        private global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.BodyTagHelper __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_BodyTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.InputTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            BeginContext(61, 27, true);
            WriteLiteral("\r\n<!DOCTYPE html>\r\n<html>\r\n");
            EndContext();
            BeginContext(88, 502, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("head", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "1a21675f32034e4ea76514beb6120c0e", async() => {
                BeginContext(94, 147, true);
                WriteLiteral("\r\n    <meta name=\"viewport\" content=\"width=device-width\" />\r\n    <title>Employee - IT_OMS</title>\r\n    <!-- Custom fonts for this template-->\r\n    ");
                EndContext();
                BeginContext(241, 88, false);
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("link", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagOnly, "52114ff2b0034306818a3ddcf2ad9968", async() => {
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
                EndContext();
                BeginContext(329, 197, true);
                WriteLiteral("\r\n    <link href=\"https://fonts.googleapis.com/css?family=Nunito:200,200i,300,300i,400,400i,600,600i,700,700i,800,800i,900,900i\" rel=\"stylesheet\">\r\n    <!-- Custom styles for this template-->\r\n    ");
                EndContext();
                BeginContext(526, 55, false);
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("link", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagOnly, "0502d08bd358423c8f30f9d45cf133b6", async() => {
                }
                );
                __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_3);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_1);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                EndContext();
                BeginContext(581, 2, true);
                WriteLiteral("\r\n");
                EndContext();
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_HeadTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.HeadTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_HeadTagHelper);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            EndContext();
            BeginContext(590, 4, true);
            WriteLiteral("\r\n\r\n");
            EndContext();
            BeginContext(594, 3046, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("body", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "656e658e2e0645b6bbed0c5ccce120af", async() => {
                BeginContext(651, 298, true);
                WriteLiteral(@"
    <div class=""container"" style=""width: 60%;"">
        <h3>Are you sure you want to delete this?</h3>
        <h4>Employee Salary Details</h4>
        <hr />
        <table class=""table-hover"" style=""width: 100%;"">
            <tr>
                <th>Salary Id:</th>
                <td>");
                EndContext();
                BeginContext(950, 14, false);
#line 23 "D:\MY BOOKS\# IUBAT\Visual Projects\ITOfficeManagementSystem - Updated\ITOfficeManagementSystem\Views\EmployeeSalary\DeleteEmployeeSalary.cshtml"
               Write(Model.SalaryId);

#line default
#line hidden
                EndContext();
                BeginContext(964, 107, true);
                WriteLiteral("</td>\r\n            </tr>    \r\n            <tr>\r\n                <th>Employee Id:</th>\r\n                <td>");
                EndContext();
                BeginContext(1072, 16, false);
#line 27 "D:\MY BOOKS\# IUBAT\Visual Projects\ITOfficeManagementSystem - Updated\ITOfficeManagementSystem\Views\EmployeeSalary\DeleteEmployeeSalary.cshtml"
               Write(Model.EmployeeId);

#line default
#line hidden
                EndContext();
                BeginContext(1088, 102, true);
                WriteLiteral("</td>\r\n            </tr>\r\n            <tr>\r\n                <th>First Name:</th>\r\n                <td>");
                EndContext();
                BeginContext(1191, 15, false);
#line 31 "D:\MY BOOKS\# IUBAT\Visual Projects\ITOfficeManagementSystem - Updated\ITOfficeManagementSystem\Views\EmployeeSalary\DeleteEmployeeSalary.cshtml"
               Write(Model.FirstName);

#line default
#line hidden
                EndContext();
                BeginContext(1206, 101, true);
                WriteLiteral("</td>\r\n            </tr>\r\n            <tr>\r\n                <th>Last Name:</th>\r\n                <td>");
                EndContext();
                BeginContext(1308, 14, false);
#line 35 "D:\MY BOOKS\# IUBAT\Visual Projects\ITOfficeManagementSystem - Updated\ITOfficeManagementSystem\Views\EmployeeSalary\DeleteEmployeeSalary.cshtml"
               Write(Model.LastName);

#line default
#line hidden
                EndContext();
                BeginContext(1322, 105, true);
                WriteLiteral("</td>\r\n            </tr>\r\n            <tr>\r\n                <th>Attendance Id:</th>\r\n                <td>");
                EndContext();
                BeginContext(1428, 18, false);
#line 39 "D:\MY BOOKS\# IUBAT\Visual Projects\ITOfficeManagementSystem - Updated\ITOfficeManagementSystem\Views\EmployeeSalary\DeleteEmployeeSalary.cshtml"
               Write(Model.AttendanceId);

#line default
#line hidden
                EndContext();
                BeginContext(1446, 106, true);
                WriteLiteral("</td>\r\n            </tr>\r\n            <tr>\r\n                <th>Login Duration:</th>\r\n                <td>");
                EndContext();
                BeginContext(1553, 19, false);
#line 43 "D:\MY BOOKS\# IUBAT\Visual Projects\ITOfficeManagementSystem - Updated\ITOfficeManagementSystem\Views\EmployeeSalary\DeleteEmployeeSalary.cshtml"
               Write(Model.LoginDuration);

#line default
#line hidden
                EndContext();
                BeginContext(1572, 104, true);
                WriteLiteral("</td>\r\n            </tr>\r\n            <tr>\r\n                <th>Basic Salary:</th>\r\n                <td>");
                EndContext();
                BeginContext(1677, 17, false);
#line 47 "D:\MY BOOKS\# IUBAT\Visual Projects\ITOfficeManagementSystem - Updated\ITOfficeManagementSystem\Views\EmployeeSalary\DeleteEmployeeSalary.cshtml"
               Write(Model.BasicSalary);

#line default
#line hidden
                EndContext();
                BeginContext(1694, 95, true);
                WriteLiteral("</td>\r\n            </tr>\r\n            <tr>\r\n                <th>Tax:</th>\r\n                <td>");
                EndContext();
                BeginContext(1790, 9, false);
#line 51 "D:\MY BOOKS\# IUBAT\Visual Projects\ITOfficeManagementSystem - Updated\ITOfficeManagementSystem\Views\EmployeeSalary\DeleteEmployeeSalary.cshtml"
               Write(Model.Tax);

#line default
#line hidden
                EndContext();
                BeginContext(1799, 100, true);
                WriteLiteral("</td>\r\n            </tr>\r\n            <tr>\r\n                <th>Benifits:</th>\r\n                <td>");
                EndContext();
                BeginContext(1900, 14, false);
#line 55 "D:\MY BOOKS\# IUBAT\Visual Projects\ITOfficeManagementSystem - Updated\ITOfficeManagementSystem\Views\EmployeeSalary\DeleteEmployeeSalary.cshtml"
               Write(Model.Benifits);

#line default
#line hidden
                EndContext();
                BeginContext(1914, 102, true);
                WriteLiteral("</td>\r\n            </tr>\r\n            <tr>\r\n                <th>Hour Price:</th>\r\n                <td>");
                EndContext();
                BeginContext(2017, 15, false);
#line 59 "D:\MY BOOKS\# IUBAT\Visual Projects\ITOfficeManagementSystem - Updated\ITOfficeManagementSystem\Views\EmployeeSalary\DeleteEmployeeSalary.cshtml"
               Write(Model.HourPrice);

#line default
#line hidden
                EndContext();
                BeginContext(2032, 108, true);
                WriteLiteral("</td>\r\n            </tr>\r\n            <tr>\r\n                <th>Total Hour Price:</th>\r\n                <td>");
                EndContext();
                BeginContext(2141, 20, false);
#line 63 "D:\MY BOOKS\# IUBAT\Visual Projects\ITOfficeManagementSystem - Updated\ITOfficeManagementSystem\Views\EmployeeSalary\DeleteEmployeeSalary.cshtml"
               Write(Model.TotalHourPrice);

#line default
#line hidden
                EndContext();
                BeginContext(2161, 102, true);
                WriteLiteral("</td>\r\n            </tr>\r\n            <tr>\r\n                <th>Net Salary:</th>\r\n                <td>");
                EndContext();
                BeginContext(2264, 15, false);
#line 67 "D:\MY BOOKS\# IUBAT\Visual Projects\ITOfficeManagementSystem - Updated\ITOfficeManagementSystem\Views\EmployeeSalary\DeleteEmployeeSalary.cshtml"
               Write(Model.NetSalary);

#line default
#line hidden
                EndContext();
                BeginContext(2279, 100, true);
                WriteLiteral("</td>\r\n            </tr>\r\n            <tr>\r\n                <th>Withdraw:</th>\r\n                <td>");
                EndContext();
                BeginContext(2380, 14, false);
#line 71 "D:\MY BOOKS\# IUBAT\Visual Projects\ITOfficeManagementSystem - Updated\ITOfficeManagementSystem\Views\EmployeeSalary\DeleteEmployeeSalary.cshtml"
               Write(Model.Withdraw);

#line default
#line hidden
                EndContext();
                BeginContext(2394, 107, true);
                WriteLiteral("</td>\r\n            </tr>\r\n            <tr>\r\n                <th>PaymentStatus:</th>\r\n                <td>\r\n");
                EndContext();
#line 76 "D:\MY BOOKS\# IUBAT\Visual Projects\ITOfficeManagementSystem - Updated\ITOfficeManagementSystem\Views\EmployeeSalary\DeleteEmployeeSalary.cshtml"
                     if (Model.PaymentStatus == 0)
                    {

#line default
#line hidden
                BeginContext(2576, 43, true);
                WriteLiteral("                        <span>Paid</span>\r\n");
                EndContext();
#line 79 "D:\MY BOOKS\# IUBAT\Visual Projects\ITOfficeManagementSystem - Updated\ITOfficeManagementSystem\Views\EmployeeSalary\DeleteEmployeeSalary.cshtml"
                    }
                    else
                    {

#line default
#line hidden
                BeginContext(2691, 42, true);
                WriteLiteral("                        <span>Due</span>\r\n");
                EndContext();
#line 83 "D:\MY BOOKS\# IUBAT\Visual Projects\ITOfficeManagementSystem - Updated\ITOfficeManagementSystem\Views\EmployeeSalary\DeleteEmployeeSalary.cshtml"
                    }

#line default
#line hidden
                BeginContext(2756, 23, true);
                WriteLiteral("                </td>\r\n");
                EndContext();
                BeginContext(2830, 51, true);
                WriteLiteral("            </tr>\r\n        </table><br />\r\n        ");
                EndContext();
                BeginContext(2881, 356, false);
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("form", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "96f9b32163e84793951317ade7554e21", async() => {
                    BeginContext(2953, 14, true);
                    WriteLiteral("\r\n            ");
                    EndContext();
                    BeginContext(2967, 42, false);
                    __tagHelperExecutionContext = __tagHelperScopeManager.Begin("input", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.SelfClosing, "9e336c4ec94444eab3ab6deefa639d1f", async() => {
                    }
                    );
                    __Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.InputTagHelper>();
                    __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper);
                    __Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper.InputTypeName = (string)__tagHelperAttribute_4.Value;
                    __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_4);
#line 89 "D:\MY BOOKS\# IUBAT\Visual Projects\ITOfficeManagementSystem - Updated\ITOfficeManagementSystem\Views\EmployeeSalary\DeleteEmployeeSalary.cshtml"
__Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper.For = ModelExpressionProvider.CreateModelExpression(ViewData, __model => __model.SalaryId);

#line default
#line hidden
                    __tagHelperExecutionContext.AddTagHelperAttribute("asp-for", __Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper.For, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
                    await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                    if (!__tagHelperExecutionContext.Output.IsContentModified)
                    {
                        await __tagHelperExecutionContext.SetOutputContentAsync();
                    }
                    Write(__tagHelperExecutionContext.Output);
                    __tagHelperExecutionContext = __tagHelperScopeManager.End();
                    EndContext();
                    BeginContext(3009, 99, true);
                    WriteLiteral("\r\n            <input type=\"submit\" value=\"Delete\" class=\"btn btn-outline-danger\" /> |\r\n            ");
                    EndContext();
                    BeginContext(3108, 112, false);
                    __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "3e8ac678fbe74b79b303d9dafd353046", async() => {
                        BeginContext(3204, 12, true);
                        WriteLiteral("Back to List");
                        EndContext();
                    }
                    );
                    __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
                    __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
                    __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Controller = (string)__tagHelperAttribute_5.Value;
                    __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_5);
                    __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_6.Value;
                    __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_6);
                    __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_7);
                    await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                    if (!__tagHelperExecutionContext.Output.IsContentModified)
                    {
                        await __tagHelperExecutionContext.SetOutputContentAsync();
                    }
                    Write(__tagHelperExecutionContext.Output);
                    __tagHelperExecutionContext = __tagHelperScopeManager.End();
                    EndContext();
                    BeginContext(3220, 10, true);
                    WriteLiteral("\r\n        ");
                    EndContext();
                }
                );
                __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper);
                __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper);
                __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Controller = (string)__tagHelperAttribute_5.Value;
                __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_5);
                __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Action = (string)__tagHelperAttribute_8.Value;
                __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_8);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                EndContext();
                BeginContext(3237, 63, true);
                WriteLiteral("\r\n    </div>\r\n    \r\n    <!-- Bootstrap core JavaScript-->\r\n    ");
                EndContext();
                BeginContext(3300, 53, false);
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("script", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "9ec557c176f5406f8af0537d7c87e89a", async() => {
                }
                );
                __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_9);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                EndContext();
                BeginContext(3353, 6, true);
                WriteLiteral("\r\n    ");
                EndContext();
                BeginContext(3359, 69, false);
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("script", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "2c872629c82f483c91088964d5067eb6", async() => {
                }
                );
                __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_10);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                EndContext();
                BeginContext(3428, 42, true);
                WriteLiteral("\r\n    <!-- Core plugin JavaScript-->\r\n    ");
                EndContext();
                BeginContext(3470, 67, false);
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("script", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "b907b29bbd99451cbfce57768cb4bc67", async() => {
                }
                );
                __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_11);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                EndContext();
                BeginContext(3537, 48, true);
                WriteLiteral("\r\n    <!-- Custom scripts for all pages-->\r\n    ");
                EndContext();
                BeginContext(3585, 46, false);
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("script", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "ad394e9ec8194f9181d7095644f857f1", async() => {
                }
                );
                __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_12);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                EndContext();
                BeginContext(3631, 2, true);
                WriteLiteral("\r\n");
                EndContext();
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_BodyTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.BodyTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_BodyTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_13);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            EndContext();
            BeginContext(3640, 9, true);
            WriteLiteral("\r\n</html>");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<ITOfficeManagementSystem.ViewModels.EmployeeSalaryVM> Html { get; private set; }
    }
}
#pragma warning restore 1591
