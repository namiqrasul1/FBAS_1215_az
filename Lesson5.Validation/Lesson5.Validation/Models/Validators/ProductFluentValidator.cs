using FluentValidation;

namespace Lesson5.Validation.Models.Validators
{
    public class ProductFluentValidator : AbstractValidator<Product>
    {
        public ProductFluentValidator()
        {
            RuleFor(product => product.Name).NotEmpty().WithMessage("Ad bosh ola bilmez");
            RuleFor(p => p.Name).MaximumLength(6).WithMessage("Max 6");

            RuleFor(p => p.Mail).EmailAddress().WithMessage("Emaili duzgun yaz!!!");
            RuleFor(p => p.Quantity).LessThan(10).WithMessage("Less than 10");
        }
    }
}
