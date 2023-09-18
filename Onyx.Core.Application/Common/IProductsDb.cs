namespace Onyx.Core.Application.Common;

public interface IProductsDb
{
    Task<List<ProductDto>> GetAllProducts();
    Task<List<ProductDto>> GetProductsByColor(string color);
}
