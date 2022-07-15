using Arvato.Core.DTOs;
using Arvato.Repository;
using FluentValidation;

namespace Arvato.Service.Validations
{
    public class GenreDtoValidator : AbstractValidator<GenreDto>
    {
        public GenreDtoValidator()
        {
            RuleFor(x => x.Name).NotNull().WithMessage("{PropertyName} is required")
                .NotEmpty().WithMessage("{PropertyName} is required")   
                .Length(3, 25).WithMessage("{PropertyName} must be between 3 and 20 characters.");
        }
    }
}
