using FluentValidation;
using LojaGame.Model;

namespace LojaGame.validator
{
    public class CategoriaValidator : AbstractValidator<Categoria>
    {
        public CategoriaValidator()
        {
            RuleFor(c => c.Tipo)
                    .NotEmpty()
                    .MinimumLength(5)
                    .MaximumLength(100);
        }
    }
}
