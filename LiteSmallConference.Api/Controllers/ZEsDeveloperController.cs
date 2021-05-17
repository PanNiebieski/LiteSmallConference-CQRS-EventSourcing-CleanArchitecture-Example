using LiteSmallConference.Application.Common;
using LiteSmallConference.Application.Contracts.Persitence;
using LiteSmallConference.Application.CQRS;
using LiteSmallConference.Application.CQRS.Developers.CommandES.AcceptDeveloper;
using LiteSmallConference.Application.CQRS.Developers.CommandES.RejectDeveloper;
using LiteSmallConference.Application.CQRS.Developers.CommandES.SubmitDeveloper;
using LiteSmallConference.Application.CQRS.Developers.Queries.GetAllDevelopers;
using LiteSmallConference.Application.CQRS.Developers.Queries.GetDeveloper;
using LiteSmallConference.Domain.ValueObjects;
using LiteSmallConference.Domain.ValueObjects.Identities;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace LiteSmallConference.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ZEsDeveloperController : BaseLiteSmallConference
    {
        private readonly IMediator _mediator;

        public ZEsDeveloperController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost("submit", Name = "submitdeveloperEs")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(420)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<DeveloperIds>> Submit([FromBody] EsSubmitDeveloperCommand request)
        {
            var result = await _mediator.Send(request);

            if (result.Status == ResponseStatus.BussinesLogicError)
                return Forbid();
            if (result.Status == ResponseStatus.NotFoundInDataBase)
                return NotFound();
            if (result.Status == ResponseStatus.ValidationError)
                return BadRequest();
            if (result.Status == ResponseStatus.BadQuery)
                return BadRequest();
            if (!result.Success)
                return MethodFailure(result.Message);

            return Ok(result.DeveloperIds);
        }

        [HttpGet("all/{filter}", Name = "getallcallforspeechesES")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(420)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<DeveloperInListViewModel>> GetAllDevelopers(int filter)
        {
            GetAllDevelopersQuery getAllDevelopersQuery = new GetAllDevelopersQuery()
            {
                Filter = (FilterDeveloperStatus)filter,
                queryWitchDataBase = QueryWitchDataBase.WithEventSourcing
            };

            var result = await _mediator.Send(getAllDevelopersQuery);

            if (result.Status == ResponseStatus.BussinesLogicError)
                return Forbid();
            if (result.Status == ResponseStatus.NotFoundInDataBase)
                return NotFound();
            if (result.Status == ResponseStatus.ValidationError)
                return BadRequest();
            if (result.Status == ResponseStatus.BadQuery)
                return BadRequest();
            if (!result.Success)
                return MethodFailure(result.Message);

            return Ok(result.List);
        }



        [HttpGet("uniqueid/{uid}", Name = "GetDeveloperByUniqueIdEs")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(420)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult<DeveloperViewModel>> GetDeveloperByUniqueId(Guid uid)
        {
            var result = await _mediator.Send(
                (new GetDeveloperQuery()
                {
                    DeveloperUniqueId = new DeveloperUniqueId(uid),
                    queryWitchDataBase = QueryWitchDataBase.WithEventSourcing
                }));

            return Ok(result.Developer);
        }

        [HttpPost("reject", Name = "rejectcallforspeechEs")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(420)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<int>> Reject([FromBody] EsRejectDeveloperCommand rejectCallForSpeechCommand)
        {
            var result = await _mediator.Send(rejectCallForSpeechCommand);

            if (result.Status == ResponseStatus.BussinesLogicError)
                return Forbid();
            if (result.Status == ResponseStatus.NotFoundInDataBase)
                return NotFound();
            if (result.Status == ResponseStatus.ValidationError)
                return BadRequest();
            if (result.Status == ResponseStatus.BadQuery)
                return BadRequest();
            if (!result.Success)
                return MethodFailure(result.Message);


            return NoContent();

        }


        [HttpPost("accept", Name = "acceptcallforspeechEs")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(420)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<int>> Accept([FromBody] EsAcceptDeveloperCommand acceptDeveloperCommand)
        {
            var result = await _mediator.Send(acceptDeveloperCommand);

            if (result.Status == ResponseStatus.BussinesLogicError)
                return Forbid();
            if (result.Status == ResponseStatus.NotFoundInDataBase)
                return NotFound();
            if (result.Status == ResponseStatus.ValidationError)
                return BadRequest();
            if (result.Status == ResponseStatus.BadQuery)
                return BadRequest();
            if (!result.Success)
                return MethodFailure(result.Message);


            return NoContent();

        }
    }
}
