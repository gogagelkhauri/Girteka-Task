using API.Features.ElectricityData;
using Core.DTO;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ElectricityDatasController : ControllerBase
    {
        private readonly IMediator _mediator;

        public ElectricityDatasController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<AggregatedDataDTO>), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<IEnumerable<AggregatedDataDTO>>> GetElectricityDatasAsync()
        {
            var result = await _mediator.Send(new GetElectricityData("Butas"));
            return Ok(result);
        }
    }
}
