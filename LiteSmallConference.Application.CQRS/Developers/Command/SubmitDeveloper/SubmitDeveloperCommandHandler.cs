using AutoMapper;
using LiteSmallConference.Application.Contracts.Persitence;
using LiteSmallConference.Domain.Entity;
using LiteSmallConference.Domain.ValueObject;
using LiteSmallConference.Domain.ValueObjects;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace LiteSmallConference.Application.CQRS.Developers.Command.SubmitDeveloper
{
    public class SubmitDeveloperCommandHandler
        :
        IRequestHandler<SubmitDeveloperCommand,
            SubmitDeveloperCommandResponse>
    {
        private readonly IDeveloperRepository _repository;
        private readonly IMapper _mapper;

        public SubmitDeveloperCommandHandler(IDeveloperRepository Repository,
    IMapper mapper)
        {
            _mapper = mapper;
            _repository = Repository;
        }

        public async Task<SubmitDeveloperCommandResponse> Handle(SubmitDeveloperCommand request, CancellationToken cancellationToken)
        {
            var validator = new SubmitDeveloperCommandValidator();
            var validatorResult = await validator.ValidateAsync(request);

            if (!validatorResult.IsValid)
                return new SubmitDeveloperCommandResponse(validatorResult);

            var developer = _mapper.Map<Developer>(request);
            developer.Status = DeveloperStatus.New;
            developer.UniqueId = new DeveloperUniqueId(Guid.NewGuid());

            var ids = await _repository.SubmitAsync(developer);

            return new SubmitDeveloperCommandResponse(ids);
        }
    }
}
