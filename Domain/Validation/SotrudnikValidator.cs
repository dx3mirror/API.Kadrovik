using Domain.Entity;
using FluentValidation;

public class SotrudnikValidator : AbstractValidator<Sotrudnik>
{
    public SotrudnikValidator()
    {
        RuleFor(x => x.Id)
            .GreaterThan(0)
            .WithMessage("Недопустимое значение Id");

        RuleFor(x => x.Lastname)
            .MaximumLength(50)
            .WithMessage("Длина строки 'Фамилия' не должна превышать 50 символов");

        RuleFor(x => x.Firstname)
            .MaximumLength(50)
            .WithMessage("Длина строки 'Имя' не должна превышать 50 символов");

        RuleFor(x => x.Patranomic)
            .MaximumLength(50)
            .WithMessage("Длина строки 'Отчество' не должна превышать 50 символов");

        RuleFor(x => x.Adress)
            .MaximumLength(100)
            .WithMessage("Длина строки 'Адрес' не должна превышать 100 символов");

        RuleFor(x => x.MestoRojd)
            .MaximumLength(100)
            .WithMessage("Длина строки 'Место рождения' не должна превышать 100 символов");

        RuleFor(x => x.Datarojdeniy)
            .InclusiveBetween(new DateTime(1960, 1, 1), DateTime.Today)
            .When(x => x.Datarojdeniy.HasValue)
            .WithMessage($"Дата рождения должна быть между 01.01.1960 и {DateTime.Today.ToShortDateString()}.");

        RuleFor(x => x.Del)
            .MaximumLength(3)
            .WithMessage("Длина строки 'Del' не должна превышать 3 символов");

        RuleFor(x => x.IdentityNomer)
            .MaximumLength(20)
            .WithMessage("Длина строки 'IdentityNomer' не должна превышать 20 символов");

        RuleFor(x => x.Okin)
            .MaximumLength(10)
            .WithMessage("Длина строки 'Okin' не должна превышать 10 символов");

    }
}
