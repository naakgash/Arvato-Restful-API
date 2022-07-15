using Arvato.Core;
using Arvato.Core.DTOs;
using FluentValidation;

namespace Arvato.Service.Validations
{
    public class MovieDtoValidator : AbstractValidator<Movie>
    {
        public MovieDtoValidator()
        {
            RuleFor(x => x.Id).NotNull().WithMessage("{PropertyName} is required")
                .NotEmpty().WithMessage("{PropertyName} is required")
                .ExclusiveBetween(53150,98613).WithMessage("{PropertyName} must be between 3 and 20 characters.");
        }
    }
}
