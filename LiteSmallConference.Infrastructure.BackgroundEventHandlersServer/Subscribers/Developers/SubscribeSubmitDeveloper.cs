using AutoMapper;
using LiteSmallConference.Application.Contracts.Persitence;
using LiteSmallConference.Domain.Entity;
using LiteSmallConference.DomainEvents;
using LiteSmallConference.DomainEvents.Developers;
using Newtonsoft.Json;
using System.Threading.Tasks;

namespace LiteSmallConference.Infrastructure.BackgroundEventHandlersServer.Subscribers.Developers
{
    public class SubscribeSubmitDeveloper : SubscribeBase
    {
        private IZEsDeveloperRepository _ZEsDeveloperRepository;
        private IMapper _mapper;

        public SubscribeSubmitDeveloper(IZEsDeveloperRepository zEsDeveloperRepository,
            IMapper mapper) :
            base()
        {
            _ZEsDeveloperRepository = zEsDeveloperRepository;
            _mapper = mapper;
        }


        public override string QUEUE_Name => Constants.QUEUE_DEVELOPER_SUBMITED;

        public override DomainEvent DeserializeObject(string json)
        {
            return JsonConvert.DeserializeObject<DevloperSubmitedEvent>(json);
        }

        public override async Task<ExecutionStatus> HandleEvent(DomainEvent @event)
        {
            DevloperSubmitedEvent developerSubmitEvent = @event as DevloperSubmitedEvent;

            var cfs = _mapper.Map<Developer>(developerSubmitEvent);

            var execution = await
                _ZEsDeveloperRepository.SubmitAsync(cfs);

            if (execution == null)
                return new ExecutionStatus() { Success = false };

            return new ExecutionStatus() { Success = true };
        }
    }
}
