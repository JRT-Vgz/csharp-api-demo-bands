using csharp_api_demo_bands.DTOs;
using FluentValidation;

namespace csharp_api_demo_bands.Validators
{
    public class StyleUpdateValidator : AbstractValidator<StyleUpdateDto>
    {
        public StyleUpdateValidator()
        {
            RuleFor(s => s.Name).NotEmpty()
                .WithMessage("El campo 'Name' no puede estar vacío.");

            RuleFor(s => s.Name).MaximumLength(25)
                .WithMessage("El campo 'Name' no debe superar los 25 caracteres.");

            RuleFor(s => s.Name.ToUpper()).Must(str => str.Contains("ROCK") || str.Contains("METAL"))
                .WithMessage("Si no contiene 'Rock' o 'Metal' en el nombre, no es música.");
        }
    }
}
