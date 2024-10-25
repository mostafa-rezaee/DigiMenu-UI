using System.ComponentModel.DataAnnotations;

namespace DigiMenu.Razor.Models
{
    public class SeoDataViewModel
    {
        [DataType(DataType.MultilineText)]
        public string? MetaDescription { get; set; } = "";

        [Display(Name = "عنوان صفحه")]
        [Required(ErrorMessage = "{0} را وارد کنید")]
        public string? MetaTitle { get; set; }

        public string? MetaKeywords { get; set; } = "";
        public bool IsIndexed { get; set; }

        [DataType(DataType.Url)]
        public string? Canonicial { get; set; } = "";

        [DataType(DataType.MultilineText)]
        public string? Schema { get; set; }
    }
}
