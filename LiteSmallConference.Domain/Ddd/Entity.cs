namespace LiteSmallConference.Domain.Ddd
{
    public abstract class Entity<T1, T2>
    {
        public T1 Id { get; set; }
        public T2 UniqueId { get; set; }

        public int Version { get; set; }
    }
}
