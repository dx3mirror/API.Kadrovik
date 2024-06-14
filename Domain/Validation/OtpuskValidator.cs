using Domain.Entity;
using FluentValidation;

public class OtpuskValidator : AbstractValidator<Otpusk>
{
    public OtpuskValidator()
    {
        RuleFor(x => x.Id)
            .GreaterThan(0)
            .WithMessage("Недопустимое значение Id");

        RuleFor(x => x.VidOtpuska)
            .NotNull()
            .WithMessage("VidOtpuska не может быть null")
            .SetValidator(new VidOtpuskaValueObjectValidator());

        RuleFor(x => x.PeriodS)
            .LessThanOrEqualTo(x => x.PeriodPo)
            .When(x => x.PeriodS.HasValue && x.PeriodPo.HasValue)
            .WithMessage("Дата 'С' не может быть позже даты 'По'");

        RuleFor(x => x.PeriodPo)
            .GreaterThanOrEqualTo(x => x.PeriodS)
            .When(x => x.PeriodS.HasValue && x.PeriodPo.HasValue)
            .WithMessage("Дата 'По' не может быть раньше даты 'С'");

        RuleFor(x => x.SKakogo)
            .LessThanOrEqualTo(x => x.PoKakoe)
            .When(x => x.SKakogo.HasValue && x.PoKakoe.HasValue)
            .WithMessage("Дата 'С какого' не может быть позже даты 'По какое'");

        RuleFor(x => x.PoKakoe)
            .GreaterThanOrEqualTo(x => x.SKakogo)
            .When(x => x.SKakogo.HasValue && x.PoKakoe.HasValue)
            .WithMessage("Дата 'По какое' не может быть раньше даты 'С какого'");

        RuleFor(x => x.Day)
            .Must(IsValidDay)
            .WithMessage("Недопустимое значение дня");
    }

    private bool IsValidDay(string day)
    {
        if (int.TryParse(day, out int dayValue))
        {
            return dayValue >= 1 && dayValue <= 31;
        }
        return false;
    }
}
