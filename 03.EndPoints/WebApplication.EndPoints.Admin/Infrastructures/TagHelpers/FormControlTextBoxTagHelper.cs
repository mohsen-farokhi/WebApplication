using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Microsoft.AspNetCore.Razor.TagHelpers;
using System.IO;
using System.Threading.Tasks;

namespace Infrastructures.TagHelpers
{
    [HtmlTargetElement("form-control-textbox")]
    public class FormControlTextBoxTagHelper : TagHelper
    {
        public FormControlTextBoxTagHelper(IHtmlGenerator generator)
        {
            _generator = generator;
        }

        [HtmlAttributeName("asp-for")]
        public ModelExpression For { get; set; }

        private readonly IHtmlGenerator _generator;

        [ViewContext]
        public ViewContext ViewContext { get; set; }

        public int LableColumn { get; set; } = 3;
        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            using (var writer = new StringWriter())
            {
                writer.Write("<div class=\"form-group row\">");

                var label = _generator.GenerateLabel
                    (ViewContext,
                    For.ModelExplorer,
                    For.Name,
                    null,
                    new { @class = $"col-sm-{LableColumn} col-form-label" });

                label.WriteTo(writer, NullHtmlEncoder.Default);
                writer.Write($"<div class=\"col-sm-{12 - LableColumn}\">");

                var text = _generator.GenerateTextBox
                    (ViewContext,
                    For.ModelExplorer,
                    For.Name,
                    For.Model,
                    null,
                    new { @class = "form-control" });

                text.WriteTo(writer, NullHtmlEncoder.Default);

                var validationSpan = _generator.GenerateValidationMessage
                    (ViewContext,
                    For.ModelExplorer,
                    For.Name,
                    null,
                    "span",
                    new { @class = "error mt-2 text-danger" });

                validationSpan.WriteTo(writer, NullHtmlEncoder.Default);

                writer.Write("</div></div>");

                output.Content.SetHtmlContent(writer.ToString());
            }
        }
    }
}
