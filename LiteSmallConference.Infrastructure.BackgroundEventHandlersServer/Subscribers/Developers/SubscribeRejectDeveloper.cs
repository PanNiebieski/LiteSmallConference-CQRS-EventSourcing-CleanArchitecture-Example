using AutoMapper;
using LiteSmallConference.Application.Contracts.Persitence;
using LiteSmallConference.Domain.Entity;
using LiteSmallConference.DomainEvents;
using LiteSmallConference.DomainEvents.Developers;
using Newtonsoft.Json;
using System.Threading.Tasks;

namespace LiteSmallConference.Infrastructure.BackgroundEventHandlersServer.Subscribers.Developers
{
    public class SubscribeRejectDeveloper : SubscribeBase
    {
        private IZEsDeveloperRepository _ZEsDeveloperRepository;
        private IMapper _mapper;

        public SubscribeRejectDeveloper(IZEsDeveloperRepository zEsDeveloperRepository,
            IMapper mapper) :
            base()
        {
            _ZEsDeveloperRepository = zEsDeveloperRepository;
            _mapper = mapper;
        }

        public override string QUEUE_Name => Constants.QUEUE_DEVELOPER_REJECTCED;

        public override DomainEvent DeserializeObject(string json)
        {
            return JsonConvert.DeserializeObject<DeveloperRejectedEvent>(json);
        }

        public override async Task<ExecutionStatus> HandleEvent(DomainEvent @event)
        {
            DeveloperRejectedEvent developerEvent = @event as DeveloperRejectedEvent;

            var cfs = _mapper.Map<Developer>(developerEvent);

            _ZEsDeveloperRepository.SaveRejectionAsync(cfs.UniqueId);

            //if (execution == null)
            //    return new ExecutionStatus() { Succes = false };

            return new ExecutionStatus() { Success = true };
        }
    }
}
