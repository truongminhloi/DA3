using DA3.Service.Dto;
using DA3.Service.Request;

namespace DA3.Service.Contract
{
    public interface IProductService
    {
        Task<List<ProductDto>> All();

        Task<bool> Create(CreateProductRequest request, CancellationToken cancellationToken = default);

        Task<bool> Update(UpdateProductRequest request, CancellationToken cancellationToken = default);

        Task<bool> Delete(int productId, CancellationToken cancellationToken = default);

        Task<ProductDto> FindById(int productId);
    }
}
