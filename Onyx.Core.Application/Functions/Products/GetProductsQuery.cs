using MediatR;
using Onyx.Core.Application.Common;

namespace Onyx.Core.Application.Functions.Products;

public class GetProductsQuery : IRequest<IEnumerable<ProductDto>>
{
    public string? colour { get; set; }
}

public class GetProductsQueryHandler : IRequestHandler<GetProductsQuery, IEnumerable<ProductDto>>
{
    private readonly IProductsDb _productsDb;
    public GetProductsQueryHandler(IProductsDb productsDb)
    {
        _productsDb = productsDb;
    }
    public async Task<IEnumerable<ProductDto>> Handle(GetProductsQuery request, CancellationToken cancellationToken)
    {
        if (string.IsNullOrEmpty(request.colour))
        {
            return await _productsDb.GetAllProducts();
        }
        else
        {
            return await _productsDb.GetProductsByColor(request.colour);
        }
    }
}