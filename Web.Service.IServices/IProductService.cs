using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Web.Service.DataModel.Product;

namespace Web.Service.Services.Interfaces
{
    public interface IProductService
    {
        Task<List<ProductResponse>> GetProduct(ProductRequest request);
    }

}
