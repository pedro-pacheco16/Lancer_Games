using FluentValidation;
using LojaGame.Model;

namespace LojaGame.validator
{
    public class UserValidator : AbstractValidator<User>
    {
        public UserValidator()
        {

            RuleFor(u => u.Nome)
                .NotEmpty()
                .MaximumLength(255);

            RuleFor(u => u.Usuario)
               .NotEmpty()
               .MaximumLength(255)
               .EmailAddress();

            RuleFor(u => u.Senha)
               .NotEmpty()
               .MinimumLength(8);


            RuleFor(u => u.DataNascimento)
                .NotEmpty()
                .Must(MaiorDeIdade);

        }

        private bool MaiorDeIdade(DateOnly? dataNascimento)
        {
           
            if (!dataNascimento.HasValue)
            {
                return false;
            }

            
            var  AnosAtras = DateOnly.FromDateTime(DateTime.Today.AddYears(-18));

            
            return dataNascimento.Value <= AnosAtras;
        }
    }
}
