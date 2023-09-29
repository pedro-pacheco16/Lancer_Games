using FluentValidation;
using LojaGame.Model;

namespace LojaGame.validator
{
    public class ProdutoValidator : AbstractValidator<Produto>
    {
        public ProdutoValidator()
        {
            RuleFor(p => p.Nome)
                    .NotEmpty()
                    .MinimumLength(5)
                    .MaximumLength(100);

            RuleFor(p => p.Descricao)
                    .NotEmpty()
                    .MinimumLength(5)
                    .MaximumLength(255);

            RuleFor(p => p.Console)
                .NotEmpty()
                .MinimumLength(1)
                .MaximumLength(255);

            RuleFor(p => p.Preco)
                 .NotEmpty();

            RuleFor(p => p.Foto)
                .NotEmpty()
                .MinimumLength(10)
                .MaximumLength(5000);

        }
    }
}
