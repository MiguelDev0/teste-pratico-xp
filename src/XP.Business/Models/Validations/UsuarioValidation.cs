using FluentValidation;
using System.Text.RegularExpressions;

namespace XP.Business.Models.Validations
{
    public class UsuarioValidation : AbstractValidator<Usuario>
    {
        public UsuarioValidation()
        {
            RuleFor(c => c.Nome)
                .NotEmpty().WithMessage("Informe o nome do cliente")
                .Length(3, 50).WithMessage("O nome deverá ter entre 3 a 50 caracteres");
            RuleFor(c => c.Sobrenome)
                .NotEmpty().WithMessage("Informe o sobrenome do cliente")
                .Length(3, 200).WithMessage("O sobrenome deverá ter entre 3 a 200 caracteres");
            RuleFor(c => c.Telefone)
                .Phone().WithMessage("Informe um número de telefone válido.");
                
        }
        
    }

    
}
