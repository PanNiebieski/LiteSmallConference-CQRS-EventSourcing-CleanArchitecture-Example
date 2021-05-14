using AutoMapper;
using LiteSmallConference.Domain.Entity;
using LiteSmallConference.Domain.ValueObject;
using LiteSmallConference.Domain.ValueObjects;
using System;

namespace LiteSmallConference.Persitence.Dapper.SQLite.Map
{
    internal class DevloperTypeConverter : ITypeConverter<DevloperTemp, Developer>
    {
        public Developer Convert(DevloperTemp source, Developer destination,
            ResolutionContext context)
        {
            Developer d = new Developer();

            d.Id = new DeveloperId(source.Id);
            d.Name = source.Name;
            var g = Guid.Parse(source.UniqueId);

            d.UniqueId = new DeveloperUniqueId(g);

            d.Status = (DeveloperStatus)source.Status;

            return d;
        }
    }
}
