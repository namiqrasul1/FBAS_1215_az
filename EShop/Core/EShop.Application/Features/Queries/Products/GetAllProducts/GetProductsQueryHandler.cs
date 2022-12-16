using EShop.Application.RequestParams;
using EShop.Application.Repositories.ProductRepository;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EShop.Application.Features.Queries.Products.GetAllProducts
{
    public class GetProductsQueryHandler : IRequestHandler<GetProductsQueryRequest, GetProductsQueryResponse>
    {
        private readonly IProductReadRepository productReadRepository;

        public GetProductsQueryHandler(IProductReadRepository repository)
        {
            productReadRepository = repository;
        }

        public async Task<GetProductsQueryResponse> Handle(GetProductsQueryRequest request, CancellationToken cancellationToken)
        {
            var totalCount = productReadRepository.GetAll(tracking: false).Count();

            var products = productReadRepository.GetAll(tracking: false).OrderBy(product => product.CreatedTime).Skip(request.Size * request.Page).Take(request.Size).Select(p => new
            {
                p.Id,
                p.Name,
                p.Description,
                p.Stock,
                p.Price
            });

            return new()
            {
                Products = products,
                TotalCount = totalCount
            };
        }
    }
}
