using FluentValidation;
using OnlineEdu.WebUI.DTOs.BlogCategoryDtos;

namespace OnlineEdu.WebUI.Validator
{
    public class BlogCategoryValidator : AbstractValidator<CreateBlogCategoryDto>
    {
        public BlogCategoryValidator()
        {
            RuleFor(x => x.Name).NotEmpty().WithMessage("Blog Kategori adı boş olamaz");
            RuleFor(x => x.Name).MaximumLength(30).WithMessage("Blog Kategori adı en fazla 30 karakter olabilir");
        }
        
    }
}
