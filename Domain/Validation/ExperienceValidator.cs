using Domain.Entity;
using FluentValidation;

public class ExperienceValidator : AbstractValidator<Experience>
{
    public ExperienceValidator()
    {
        RuleFor(x => x.Id)
            .GreaterThan(0)
            .WithMessage("Недопустимое значение Id");

        RuleFor(x => x.ObchyiDay)
            .Must(IsValidDay)
            .WithMessage("Недопустимое значение дня");

        RuleFor(x => x.ObchyiMonth)
            .Must(IsValidMonth)
            .WithMessage("Недопустимое значение месяца");

        RuleFor(x => x.ObchyiYear)
            .Must(IsValidYear)
            .WithMessage("Недопустимое значение года");

        RuleFor(x => x.NepreryvniyDay)
            .Must(IsValidDay)
            .WithMessage("Недопустимое значение дня");

        RuleFor(x => x.NepreryvniyMonth)
            .Must(IsValidMonth)
            .WithMessage("Недопустимое значение месяца");

        RuleFor(x => x.NepreryvniyYear)
            .Must(IsValidYear)
            .WithMessage("Недопустимое значение года");

        RuleFor(x => x.VislugaletDay)
            .Must(IsValidDay)
            .WithMessage("Недопустимое значение дня");

        RuleFor(x => x.VislugaletMonth)
            .Must(IsValidMonth)
            .WithMessage("Недопустимое значение месяца");

        RuleFor(x => x.VislugaletYear)
            .Must(IsValidYear)
            .WithMessage("Недопустимое значение года");
    }

    private bool IsValidDay(string day)
    {
        if (int.TryParse(day, out int dayValue))
        {
            return dayValue >= 1 && dayValue <= 31;
        }
        return false;
    }

    private bool IsValidMonth(string month)
    {
        if (int.TryParse(month, out int monthValue))
        {
            return monthValue >= 1 && monthValue <= 12;
        }
        return false;
    }

    private bool IsValidYear(string year)
    {
        if (int.TryParse(year, out int yearValue))
        {
            return yearValue >= 1 && yearValue <= 9999;
        }
        return false;
    }
}
