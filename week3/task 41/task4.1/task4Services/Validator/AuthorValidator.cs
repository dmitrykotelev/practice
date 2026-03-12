using FluentValidation;
using task4Services.Mapper;

namespace task4Services.Validator
{
    public class AuthorValidator : AbstractValidator<AuthorDto>
    {
        public AuthorValidator()
        {
            RuleFor(x => x.Name)
                .NotEmpty().WithMessage("Name cannot be empty");
        }
    }
}