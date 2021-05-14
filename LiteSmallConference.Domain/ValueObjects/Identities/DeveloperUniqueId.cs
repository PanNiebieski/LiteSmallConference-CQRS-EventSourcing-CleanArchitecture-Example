using System;

namespace LiteSmallConference.Domain.ValueObjects
{
    public class DeveloperUniqueId : BaseUniqueId<Guid>
    {
        public Guid Value { get; set; }

        public override string ValueInString()
        {
            return Value.ToString();
        }

        public DeveloperUniqueId()
        {
            Value = Guid.NewGuid();
        }

        public DeveloperUniqueId(Guid value)
        {
            Value = value;
        }
    }
}
