#pragma checksum "D:\Projeler\Calisma\BlogApp\BlogApp.WebUI\Views\PostImages\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "2b74fc43747dd211913da4898b030b69c67a8a6d"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(BlogApp.WebUI.PostImages.Views_PostImages_Index), @"mvc.1.0.view", @"/Views/PostImages/Index.cshtml")]
namespace BlogApp.WebUI.PostImages
{
    #line hidden
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.Rendering;
    using Microsoft.AspNetCore.Mvc.ViewFeatures;
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"2b74fc43747dd211913da4898b030b69c67a8a6d", @"/Views/PostImages/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"0ce7a9cb6b60aaabd9fdba95df2ddce3383b2e44", @"/Views/_ViewImports.cshtml")]
    public class Views_PostImages_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<Guid>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("<div  class=\"row row-col-4 mt-5\" id=\"card\"></div>\r\n\r\n");
            DefineSection("js", async() => {
                WriteLiteral("\r\n    <script>\r\n        $(document).ready(function(){\r\n            (function(){\r\n$.getJSON(\"/postimages/_index/");
#nullable restore
#line 8 "D:\Projeler\Calisma\BlogApp\BlogApp.WebUI\Views\PostImages\Index.cshtml"
                         Write(Model);

#line default
#line hidden
#nullable disable
                WriteLiteral(@""", function(data){
 $.each(data,function(key,value){
       $(""#card"").append(`<div class=""col-3 mb-3 border rounded p-2 shadow-sm""> 
                          <img src=""${value.imageUrl}"" alt=""bilgeadam"" class=""img-thumbnail mb-2"" />
                          <div class=""btn-group d-flex"">
        <a data-id=""${value.id}"" class=""btn btn-dark btn-sm main"" href=""#"" > 
             <i class=""fa fa-cogs text-${value.active ? 'success': 'warning'}""></i> <a>
        <a data-id=""${value.id}"" class=""btn btn-dark btn-sm delete"" href=""#"" >  <i class=""fa fa-trash text-danger""></i> <a> </div> </div>`);
 })
})
            })();
            $(document).on(""click"","".main"",function(){
                var button = $(this);
                var id = $(button).data(""id"");
                $.ajax({
                    url:""/postimages/_active/""+ id,
                    dataType:""json"",
                    type:""post"",
                    success:function(result){
if(result.code == 200){
    $(""#card svg"")
   ");
                WriteLiteral(@" .removeClass(""text-success"")
    .addClass(""text-warning"");
    $(button).children()
    .removeClass(""text-warning"")
    .addClass(""text-success"");
}
                    },
                    error:function(error){
                    }
                })
            })
$(document).on(""click"","".delete"",function(){
    var id = $(this).data(""id""); 
    var buton = $(this);
    $.ajax({
        url:""/postimages/_delete/""+id,
        dataType:""json"",
        type :""post"",
        success:function(result){
            if(result== 200){
                $(buton).closest("".col-3"").hide(""slow"")
            }
        },
        error: function(){}
    })
})
        })
    </script>
");
            }
            );
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<Guid> Html { get; private set; }
    }
}
#pragma warning restore 1591
