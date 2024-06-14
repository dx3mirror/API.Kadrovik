using Domain.Entity;
using FluentValidation;

public class FamilyValidator : AbstractValidator<Family>
{
    public FamilyValidator()
    {
        RuleFor(x => x.Id)
            .GreaterThan(0)
            .WithMessage("Недопустимое значение Id");

        RuleFor(x => x.Fio)
            .NotEmpty()
            .MaximumLength(200)
            .WithMessage("Недопустимое значение ФИО");

        RuleFor(x => x.StepenRodstva)
            .NotNull()
            .WithMessage("Степень родства должна быть указана");

        RuleFor(x => x.DataRojdeniya)
            .InclusiveBetween(new DateTime(1960, 1, 1), DateTime.Today)
            .WithMessage("Дата рождения должна быть не меньше 1960 и не больше сегодняшней");
    }
}
