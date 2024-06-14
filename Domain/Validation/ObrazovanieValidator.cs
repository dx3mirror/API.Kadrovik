using Domain.Entity;
using FluentValidation;

public class ObrazovanieValidator : AbstractValidator<Obrazovanie>
{
    public ObrazovanieValidator()
    {
        RuleFor(x => x.Id)
            .GreaterThan(0)
            .WithMessage("Недопустимое значение Id");

        RuleFor(x => x.Obrazovanie1)
            .MaximumLength(100)
            .WithMessage("Длина строки 'Образование1' не должна превышать 100 символов");

        RuleFor(x => x.Nazvanieuchrejdeniya)
            .MaximumLength(200)
            .WithMessage("Длина строки 'Название учреждения' не должна превышать 200 символов");

        RuleFor(x => x.KvalifikachiyapoObrazovaniyu)
            .MaximumLength(200)
            .WithMessage("Длина строки 'Квалификация по образованию' не должна превышать 200 символов");

        RuleFor(x => x.Nazvanieuchrejdeniya2)
            .MaximumLength(200)
            .WithMessage("Длина строки 'Название учреждения2' не должна превышать 200 символов");

        RuleFor(x => x.KvalifikachiyapoObrazovaniyu2)
            .MaximumLength(200)
            .WithMessage("Длина строки 'Квалификация по образованию2' не должна превышать 200 символов");

        RuleFor(x => x.Poslevuzovoe)
            .MaximumLength(200)
            .WithMessage("Длина строки 'Послевузовское' не должна превышать 200 символов");

        RuleFor(x => x.ProfessiaOsnova)
            .MaximumLength(100)
            .WithMessage("Длина строки 'Профессия основа' не должна превышать 100 символов");

        RuleFor(x => x.ProfessiaDopolnitel)
            .MaximumLength(100)
            .WithMessage("Длина строки 'Профессия дополнительная' не должна превышать 100 символов");
    }
}
