using Domain.Entity;
using FluentValidation;

public class DoljnostValidator : AbstractValidator<Doljnost>
{
    public DoljnostValidator()
    {
        RuleFor(x => x.Id)
            .GreaterThan(0)
            .WithMessage("Недопустимое значение Id");

        RuleFor(x => x.NaimenoviyDoljnosti)
            .NotEmpty()
            .WithMessage("Наименование должности не может быть пустым")
            .Length(1, 100)
            .WithMessage("Длина наименования должности должна быть от 1 до 100 символов");

        RuleFor(x => x.SKogo)
            .Must(BeAValidDate)
            .WithMessage("Некорректная дата 'С какого'")
            .When(x => !string.IsNullOrEmpty(x.SKogo));

        RuleFor(x => x.PoKokoe)
            .Must(BeAValidDate)
            .WithMessage("Некорректная дата 'По какое'")
            .When(x => !string.IsNullOrEmpty(x.PoKokoe));

        RuleFor(x => x)
            .Must(HaveValidDateRange)
            .WithMessage("Дата 'По какое' не может быть раньше даты 'С какого'")
            .When(x => !string.IsNullOrEmpty(x.SKogo) && !string.IsNullOrEmpty(x.PoKokoe));

        RuleFor(x => x.Otvetstveniy)
            .Length(0, 200)
            .WithMessage("Длина поля 'Ответственный' должна быть от 0 до 200 символов");
    }

    private bool BeAValidDate(string dateStr)
    {
        DateTime date;
        return DateTime.TryParse(dateStr, out date);
    }

    private bool HaveValidDateRange(Doljnost instance)
    {
        DateTime startDate, endDate;
        if (DateTime.TryParse(instance.SKogo, out startDate) && DateTime.TryParse(instance.PoKokoe, out endDate))
        {
            return endDate >= startDate;
        }
        return true;
    }
}
