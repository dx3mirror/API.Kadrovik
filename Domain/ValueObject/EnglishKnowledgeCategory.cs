using Domain.Enum;
namespace Domain.ValueObject
{
    public class EnglishKnowledgeCategory
    {
        public EnglishKnowledgeLevel Value { get; }

        public EnglishKnowledgeCategory(EnglishKnowledgeLevel value)
        {
            Value = value;
        }

        public override bool Equals(object obj)
        {
            if (obj is EnglishKnowledgeCategory other)
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
