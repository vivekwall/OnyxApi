using Onyx.Core.Application.Common;

namespace Onyx.Product.Database
{
    public class ProductsDb : IProductsDb
    {
        public async Task<List<ProductDto>> GetProductsByColor(string color)
        {
            return await Task.FromResult(_products.Where(p => p.Color.Equals(color, StringComparison.OrdinalIgnoreCase)).ToList());
        }

        public async Task<List<ProductDto>> GetAllProducts()
        {
            return await Task.FromResult(_products);
        }

        private readonly List<ProductDto> _products = new List<ProductDto>
        {
            new ProductDto { Id = 1, Name = "Product 1", Color = "Red" , Description ="20 X 10 X 10"  , Price = 20},
            new ProductDto { Id = 2, Name = "Product 2", Color = "Blue" , Description ="10 X 50 X 60", Price = 40 },
            new ProductDto { Id = 3, Name = "Product 3", Color = "Green" , Description ="100 X 100 X 100", Price = 50 },
            new ProductDto { Id = 4, Name = "Product 4", Color = "Blue" , Description ="200 X 100 X 100", Price = 200},
            new ProductDto { Id = 5, Name = "Product 5", Color = "Red" , Description ="200 X 100 X 300", Price = 300 },
        };
    }
}