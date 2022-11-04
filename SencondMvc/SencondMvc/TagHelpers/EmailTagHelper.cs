using Microsoft.AspNetCore.Razor.TagHelpers;

namespace SencondMvc.TagHelpers
{
    public class EmailTagHelper : TagHelper
    {
        public string Mail { get; set; }

        public string Content { get; set; }

        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            output.TagName = "a";
            output.Attributes.Add("href", $"mailto:{Mail}");
            output.Content.Append(Content);
        }
    }
}