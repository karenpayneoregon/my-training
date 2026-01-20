using FluentValidation;

namespace IncludeRuleSetsApp.LanguageExtensions;


public static class RuleBuilderExtensions
{

    /// <summary>
    /// Defines a validation rule for a birthdate property.
    /// </summary>
    /// <typeparam name="T">The type of the object being validated.</typeparam>
    /// <param name="ruleBuilder">The rule builder for the <see cref="DateOnly"/> property.</param>
    /// <returns>
    /// A rule builder options object that enforces the birthdate to be greater than 120 years ago
    /// and less than or equal to the current year.
    /// </returns>
    /// <remarks>
    /// This method ensures that the birthdate is within a valid range:
    /// - The year must be greater than 120 years ago.
    /// - The year must be less than or equal to the current year.
    /// If the validation fails, a custom error message is provided.
    /// </remarks>
    public static IRuleBuilderOptions<T, DateOnly> BirthDateRule<T>(this IRuleBuilder<T, DateOnly> ruleBuilder)
    {

        var minYear = DateTime.Now.AddYears(-120).Year;

        return ruleBuilder
            .Must(x => x.Year > minYear && x.Year <= DateTime.Now.Year)
            .WithMessage("'{PropertyName}'" +
                         $" must be greater than {minYear} " +
                         $"year and less than or equal to {DateTime.Now.Year} ");
    }

}