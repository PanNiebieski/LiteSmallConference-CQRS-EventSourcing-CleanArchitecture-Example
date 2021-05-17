using AutoMapper;
using LiteSmallConference.Application.CQRS.Developers.Command.SubmitDeveloper;
using LiteSmallConference.Application.CQRS.Developers.CommandES.SubmitDeveloper;
using LiteSmallConference.Application.CQRS.Developers.Queries.GetAllDevelopers;
using LiteSmallConference.Application.CQRS.Developers.Queries.GetDeveloper;
using LiteSmallConference.Domain.Entity;
using LiteSmallConference.Domain.ValueObjects;
using System;

namespace LiteSmallConference.Application.CQRS.Mapper
{
    public class ProfileMap : Profile
    {
        public ProfileMap()
        {
            CreateMap<int, DeveloperId>().ConstructUsing
                (c => new DeveloperId(c));

            CreateMap<DeveloperId, int>().ConstructUsing(c => c.Value);

            CreateMap<Guid, DeveloperUniqueId>().ConstructUsing
                (c => new DeveloperUniqueId(c));

            CreateMap<DeveloperUniqueId, Guid>().ConstructUsing
                (c => c.Value);

            CreateMap<Developer, DeveloperViewModel>();
            CreateMap<Developer, DeveloperInListViewModel>();

            CreateMap<SubmitDeveloperCommand, Developer>();
            CreateMap<EsSubmitDeveloperCommand, Developer>();
        }
    }
}
