
using Domain.Enum;

namespace Domain.ValueObject
{
    public class VidOtpuskaValueObject
    {
        public VidOtpuskaEnum Value { get; private set; }

        public VidOtpuskaValueObject(VidOtpuskaEnum value)
        {
            Value = value;
        }

        public override string ToString()
        {
            return Value.ToString();
        }

        public override bool Equals(object obj)
        {
            if (obj is VidOtpuskaValueObject other)
            {
                return Value == other.Value;
            }
            return false;
        }

        public override int GetHashCode()
        {
            return Value.GetHashCode();
        }
    }
}
