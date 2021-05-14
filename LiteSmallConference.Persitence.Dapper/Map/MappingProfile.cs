using AutoMapper;
using LiteSmallConference.Domain.Entity;

namespace LiteSmallConference.Persitence.Dapper.SQLite.Map
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Developer, DevloperTemp>().
                ConvertUsing(new DevloperTempTypeConverter());
            CreateMap<DevloperTemp, Developer>().
                ConvertUsing(new DevloperTypeConverter());

        }
    }
}
