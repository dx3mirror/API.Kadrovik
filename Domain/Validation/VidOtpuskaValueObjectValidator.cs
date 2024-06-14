using Domain.ValueObject;
using FluentValidation;

public class VidOtpuskaValueObjectValidator : AbstractValidator<VidOtpuskaValueObject>
{
    public VidOtpuskaValueObjectValidator()
    {
        RuleFor(x => x.Value)
            .IsInEnum()
            .WithMessage("Invalid value for VidOtpuskaEnum");
    }
}
