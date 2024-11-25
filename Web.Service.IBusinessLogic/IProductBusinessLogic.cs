using Web.Service.BusinessModel.Product;

namespace Web.Service.IBusinessLogic
{
    public interface IProductBusinessLogic
    {
        Task<List<ProductResponse>> GetProduct(ProductRequest request);
    }

}
