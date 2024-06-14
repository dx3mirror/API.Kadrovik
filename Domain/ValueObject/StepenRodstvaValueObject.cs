
using Domain.Enum;

namespace Domain.ValueObject
{
    public class StepenRodstvaValueObject
    {
        public StepenRodstvaEnum Value { get; private set; }

        public StepenRodstvaValueObject(StepenRodstvaEnum value)
        {
            Value = value;
        }

        public override string ToString()
        {
            return Value.ToString();
        }

        public override bool Equals(object obj)
        {
            if (obj is StepenRodstvaValueObject other)
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
