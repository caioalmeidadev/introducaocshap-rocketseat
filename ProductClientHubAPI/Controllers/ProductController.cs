using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProductClientHubAPI.UseCases.Products.Delete;
using ProductClientHubAPI.UseCases.Products.GetAll;
using ProductClientHubAPI.UseCases.Products.GetById;
using ProductClientHubAPI.UseCases.Products.Register;
using ProductClientHubAPI.UseCases.Products.Update;
using ProdutcClientHub.Communication.Requests;
using ProdutcClientHub.Communication.Responses;

namespace ProductClientHubAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        [HttpPost]
        [Route("{clientId:guid}")]
        [ProducesResponseType(typeof(ResponseShortProductJson),StatusCodes.Status201Created)]
        [ProducesResponseType(typeof(ResponseErrorJson),StatusCodes.Status400BadRequest)]
        public IActionResult Register([FromRoute] Guid clientId,[FromBody] RequestProductJson request)
        {
            var useCase = new RegisterProductUseCase();
            var result = useCase.Execute(clientId,request);

            return Created(string.Empty, result);
        }

        [HttpDelete]
        [Route("{id:guid}")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(typeof(ResponseErrorJson),StatusCodes.Status400BadRequest)]
        public IActionResult Delete([FromRoute] Guid id)
        {
            var useCase = new DeleteProductUseCase();
            useCase.Execute(id);
            return NoContent();
        }
        
        [HttpPut]
        [Route("{id:guid}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(typeof(ResponseErrorJson),StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ResponseErrorJson),StatusCodes.Status404NotFound)]
        public IActionResult Update([FromRoute] Guid id, [FromBody] RequestProductJson request)
        {
            var useCase = new UpdateProductUseCase();
            useCase.Execute(id, request);

            return NoContent();
        }

        [HttpGet]
        [ProducesResponseType(typeof(ResponseListProductsJson),StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public IActionResult GetAll(Guid id)
        {
            var useCase = new GetAllProductsUseCase();
            var result = useCase.Execute();
            if(result.Products.Count == 0) return NoContent();
            
            return Ok(result);
        }

        [HttpGet]
        [Route("{id:guid}")]
        [ProducesResponseType(typeof(ResponseClientJson),StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ResponseErrorJson),StatusCodes.Status404NotFound)]
        public IActionResult GetById([FromRoute] Guid id)
        {
            var useCase = new GetByIdProductUseCase();
            var result = useCase.Execute(id);
            return Ok(result);
        }

        
    }
}
