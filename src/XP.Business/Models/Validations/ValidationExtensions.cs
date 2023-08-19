using FluentValidation;
using System.Text.RegularExpressions;

namespace XP.Business.Models.Validations
{
    public static class ValidationExtensions
    {
        public static IRuleBuilderOptions<T, TElement> Phone<T, TElement>(this IRuleBuilder<T, TElement> ruleBuilder) => ruleBuilder.Must((_, value, _) => value?.ToString().Length == 12 && Regex.IsMatch(value.ToString(), "^[0-9]*$"));
    }
}
