using FluentValidation;
using XP.Business.Models;

namespace XP.Business.Util
{
    public static class ValidarDadosEntrada
    {
        public static bool ExecutarValidacao<TV, TE>(TV validacao, TE entidade) where TV : AbstractValidator<TE> where TE : Entity
        {
            var validator = validacao.Validate(entidade);

            if (validator.IsValid) return true;

            throw new InvalidDataException(validator.Errors.Select(x => x.ErrorMessage).Last());
        }
    }
}
