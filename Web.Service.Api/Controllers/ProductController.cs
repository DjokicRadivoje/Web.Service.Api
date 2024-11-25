using Microsoft.AspNetCore.Mvc;
using Web.Service.BusinessModel.Product;
using Web.Service.IBusinessLogic;

namespace Web.Service.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProductController : ControllerBase
    {
        private readonly ILogger<ProductController> _logger;
        private readonly IProductBusinessLogic _productBusinessLogic;

        public ProductController(ILogger<ProductController> logger, IProductBusinessLogic productBusinessLogic)
        {
            _logger = logger;
            _productBusinessLogic = productBusinessLogic;
        }

        [HttpPost(Name = "GetProduct")]
        public async Task<List<ProductResponse>> GetProduct(ProductRequest request)
        {
            return (await _productBusinessLogic.GetProduct(request));
        }
    }
}
