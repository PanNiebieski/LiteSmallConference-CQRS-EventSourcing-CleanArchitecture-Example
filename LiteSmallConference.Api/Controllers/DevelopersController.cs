using LiteSmallConference.Application.Common;
using LiteSmallConference.Application.Contracts.Persitence;
using LiteSmallConference.Application.CQRS;
using LiteSmallConference.Application.CQRS.Developers.Command.AcceptDeveloper;
using LiteSmallConference.Application.CQRS.Developers.Command.RejectDeveloper;
using LiteSmallConference.Application.CQRS.Developers.Command.SubmitDeveloper;
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
    public class DevelopersController : BaseLiteSmallConference
    {
        private readonly IMediator _mediator;

        public DevelopersController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost("submit", Name = "submitdeveloper")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(420)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<DeveloperIds>> Submit([FromBody] SubmitDeveloperCommand request)
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

        [HttpGet("all/{filter}", Name = "getalldevelopers")]
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
                queryWitchDataBase = QueryWitchDataBase.NormalCQRS
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

        [HttpGet("id/{id}", Name = "GetDeveloperId")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(420)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult<DeveloperViewModel>> GetDeveloperId(int id)
        {
            var result = await _mediator.Send(
                (new GetDeveloperQuery()
                {
                    DeveloperId = new DeveloperId(id),
                    queryWitchDataBase = QueryWitchDataBase.NormalCQRS
                }));

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

            return Ok(result.Developer);
        }

        [HttpGet("uniqueid/{uid}", Name = "GetDeveloperByUniqueId")]
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
                    queryWitchDataBase = QueryWitchDataBase.NormalCQRS
                }));

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

            return Ok(result.Developer);
        }

        [HttpPost("reject", Name = "rejectdevelopers")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(420)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<int>> Reject([FromBody] RejectDeveloperCommand rejectDeveloperCommand)
        {
            var result = await _mediator.Send(rejectDeveloperCommand);

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


        [HttpPost("accept", Name = "acceptdevelopers")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(420)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<int>> Accept([FromBody] AcceptDeveloperCommand acceptDeveloperCommand)
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
