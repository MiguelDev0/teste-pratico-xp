using FluentValidation;

namespace XP.Business.Models.Validations
{
    public class EmailValidations : AbstractValidator<Email>
    {
        public EmailValidations() 
        {
            RuleFor(c => c.EmailCadastro)
                .NotEmpty().WithMessage("Informe um email")
                .EmailAddress().WithMessage("Digite um email valido");
        }
    }
}
