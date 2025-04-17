using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProductClientHub.Exceptions.ExceptionBase;
using ProductClientHubAPI.UseCases.Clients.Delete;
using ProductClientHubAPI.UseCases.Clients.GetAll;
using ProductClientHubAPI.UseCases.Clients.GetById;
using ProductClientHubAPI.UseCases.Clients.Register;
using ProductClientHubAPI.UseCases.Clients.Update;
using ProdutcClientHub.Communication.Requests;
using ProdutcClientHub.Communication.Responses;

namespace ProductClientHubAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClientsController : ControllerBase
    {
        [HttpPost]
        [ProducesResponseType(typeof(ResponseClientJson),StatusCodes.Status201Created)]
        [ProducesResponseType(typeof(ResponseErrorJson),StatusCodes.Status400BadRequest)]
        public IActionResult Register([FromBody] RequestClientJson request)
        {
            var useCase = new RegisterClientUseCase();
            var result = useCase.Execute(request);

            return Created(string.Empty, result);
        }

        [HttpPut]
        [Route("{id:guid}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(typeof(ResponseErrorJson),StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ResponseErrorJson),StatusCodes.Status404NotFound)]
        public IActionResult Update([FromRoute] Guid id, [FromBody] RequestClientJson request)
        {
            var useCase = new UpdateClientUseCase();
            useCase.Execute(id, request);

            return NoContent();
        }

        [HttpGet]
        [ProducesResponseType(typeof(ResponseListClientsJson),StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public IActionResult GetAll(Guid id)
        {
            var useCase = new GetAllClientsUseCase();
            var result = useCase.Execute();
            if(result.Clients.Count == 0) return NoContent();
            
            return Ok(result);
        }

        [HttpGet]
        [Route("{id:guid}")]
        [ProducesResponseType(typeof(ResponseClientJson),StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ResponseErrorJson),StatusCodes.Status404NotFound)]
        public IActionResult GetById([FromRoute] Guid id)
        {
            var useCase = new GetByIdClientUseCase();
            var result = useCase.Execute(id);
            return Ok(result);
        }

        [HttpDelete]
        [Route("{id:guid}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(typeof(ResponseErrorJson),StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ResponseErrorJson),StatusCodes.Status404NotFound)]
        public IActionResult DeleteById([FromRoute] Guid id)
        {
            var useCase = new DeleteClienteUseCase();
            useCase.Execute(id);
            return NoContent();
        }
    }
}
