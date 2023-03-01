using Microsoft.AspNetCore.Mvc;
using ShopBridge.Models.ResponseModel;
using ShopBridgeBackEnd.Services;

namespace ShopBridgeBackEnd.Controllers
{
    public class ProductController:BaseApiController
    {
        private readonly ProductService _productServices;

        public ProductController(ProductService productServices)
        {
            _productServices= productServices;
        }

        [HttpGet]
        [Route("item/{page}/{cantity}")]
        public async Task<ActionResult> GetAll([FromRoute]  int page, int cantity)
        {
            try
            {
                var result = (await _productServices.Get(page, cantity).ConfigureAwait(false)) as GenericResponse;
                return Ok(result);
            }
            catch (Exception e)
            {
                return BadRequest(new GenericResponse
                {
                    ErrorMessage = $"{e.Message ?? string.Empty}",
                    OperationSucces = false
                });
            }
        }
    }
}
