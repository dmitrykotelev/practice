using FluentValidation;
using task4Services.Mapper.DtoModdels;
namespace task4Services.Validator
{
    public class BookValidator : AbstractValidator<BookDto>
    {
        public BookValidator()
        {
            RuleFor(x => x.Title)
                .NotEmpty().WithMessage("Title cannot be empty");
        }
    }
}