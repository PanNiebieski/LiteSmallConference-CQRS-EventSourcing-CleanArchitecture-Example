namespace LiteSmallConference.Domain.ValueObjects
{
    public class AggregateKey
    {
        public string Id { get; set; }

        public static readonly AggregateKey Empty = new AggregateKey();

        public override string ToString()
        {
            return Id;
        }
    }
}
