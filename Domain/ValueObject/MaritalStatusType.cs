
using Domain.Enum;

namespace Domain.ValueObject
{
    public class MaritalStatusType
    {
        public MaritalStatus Value { get; }

        public MaritalStatusType(MaritalStatus value)
        {
            Value = value;
        }

        public override bool Equals(object obj)
        {
            if (obj is MaritalStatusType other)
            {
                return Value == other.Value;
            }
            return false;
        }

        public override int GetHashCode()
        {
            return Value.GetHashCode();
        }

        public override string ToString()
        {
            return Value.ToString();
        }
    }
}
