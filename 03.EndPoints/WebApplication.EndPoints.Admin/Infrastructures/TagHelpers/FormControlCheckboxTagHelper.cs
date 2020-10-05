using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Microsoft.AspNetCore.Razor.TagHelpers;
using System.IO;

namespace Infrastructures.TagHelpers
{
    [HtmlTargetElement("form-control-checkbox")]
    public class FormControlCheckboxTagHelper : TagHelper
    {
        public FormControlCheckboxTagHelper(IHtmlGenerator generator)
        {
            _generator = generator;
        }

        [HtmlAttributeName("asp-for")]
        public ModelExpression For { get; set; }

        private readonly IHtmlGenerator _generator;

        [ViewContext]
        public ViewContext ViewContext { get; set; }

        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            using (var writer = new StringWriter())
            {
                writer.Write("<div class=\"form-group\">");
                writer.Write("<div class=\"form-check form-check-flat\">");
                writer.Write("<label class=\"form-check-label\">");

                var text = _generator.GenerateCheckBox
                    (ViewContext,
                    For.ModelExplorer,
                    For.Name,
                    (For.Model != null) ? (bool)For.Model : false,
                    new { @class = "form-control" });

                text.WriteTo(writer, NullHtmlEncoder.Default);
                writer.Write($"{For.Metadata.DisplayName}</label></div></div>");

                output.Content.SetHtmlContent(writer.ToString());
            }
        }
    }
}
