namespace LiteSmallConference.Domain.ValueObjects
{
    public abstract class BaseUniqueId<T>
    {
        public abstract string ValueInString();

        public AggregateKey GetAggregateKey()
        {
            return new AggregateKey
            {
                Id = ValueInString(),
            };
        }

        public BaseUniqueId()
        {

        }
    }
}
