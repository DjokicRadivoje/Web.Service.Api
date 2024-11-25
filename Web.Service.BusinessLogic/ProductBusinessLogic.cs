using AutoMapper;
using Microsoft.Extensions.Logging;
using Web.Service.BusinessModel.Product;
using Web.Service.IBusinessLogic;
using Web.Service.Services.Interfaces;

namespace Web.Service.BusinessLogic
{
    public class ProductBusinessLogic: IProductBusinessLogic
    {
        private readonly ILogger<ProductBusinessLogic> _logger;
        private readonly IProductService _productService;
        private readonly IMapper _mapper;

        public ProductBusinessLogic(IProductService productService, ILogger<ProductBusinessLogic> logger, IMapper mapper) 
        { 
            _productService = productService;
            _logger = logger;
            _mapper = mapper;
        }

        public async Task<List<ProductResponse>> GetProduct(ProductRequest request)
        {
            var response = new List<ProductResponse>();

            var serviceProductRequest = _mapper.Map<DataModel.Product.ProductRequest>(request);

            //var serviceProductRequest = new DataModel.Product.ProductRequest() { Id = request.Id };

            var result = await _productService.GetProduct(serviceProductRequest);
            if (result == null)
            {
                this._logger.LogError($"Došlo je do greške; Request: {request}, ID: {request.Id}" );
                return response;
            }

            var responseI = _mapper.Map<List<ProductResponse>>(result);
            response = responseI;

            //foreach (var item in result) {
            //ProductResponse responseItem = new ProductResponse() { Id = item.id, Name = item.name};
            //    response.Add(responseItem);
            //}
            return response;
        }
    }
}
