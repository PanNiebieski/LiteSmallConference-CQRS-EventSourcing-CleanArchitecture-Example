namespace LiteSmallConference.Domain.ValueObjects
{
    public class DeveloperId
    {
        public int Value { get; set; }

        public DeveloperId(int value)
        {
            Value = value;
        }

        public DeveloperId()
        {
            Value = default;
        }
    }
}
