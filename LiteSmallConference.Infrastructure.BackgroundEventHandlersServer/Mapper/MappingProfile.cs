using AutoMapper;
using LiteSmallConference.Domain.Entity;
using LiteSmallConference.DomainEvents.Developers;

namespace GeekLemonConference.Infrastructure.BackgroundEventHandlersServer.Mapper
{


    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<DeveloperAcceptedEvent, Developer>();
            CreateMap<DeveloperRejectedEvent, Developer>();
            CreateMap<DevloperSubmitedEvent, Developer>();
        }
    }
}
