using AutoMapper;
using GeekLemonConference.Application.EventSourcing.Aggregates;
using LiteSmallConference.Domain.Entity;

namespace LiteSmallConference.Application.CQRS.Mapper
{
    public class MappingForEventStoreProfile : Profile
    {
        public MappingForEventStoreProfile()
        {
            CreateMap<DevloperAggregate, Developer>();
        }
    }
}
