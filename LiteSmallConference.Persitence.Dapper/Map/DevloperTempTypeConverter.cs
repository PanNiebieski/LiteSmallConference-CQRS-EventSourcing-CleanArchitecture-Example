using AutoMapper;
using LiteSmallConference.Domain.Entity;

namespace LiteSmallConference.Persitence.Dapper.SQLite.Map
{
    internal class DevloperTempTypeConverter : ITypeConverter<Developer, DevloperTemp>
    {
        public DevloperTemp Convert(Developer source, DevloperTemp destination,
            ResolutionContext context)
        {
            DevloperTemp d = new DevloperTemp();

            if (source.Id != null)
                d.Id = source.Id.Value;

            d.Name = source.Name;

            if (source.UniqueId != null)
                d.UniqueId = source.UniqueId.ValueInString();

            d.Status = (int)source.Status;

            return d;
        }
    }
}
