using DA3.Service.Contract;
using DA3.Service.Dto;
using DA3.Service.Request;
using Microsoft.AspNetCore.Mvc;

namespace DA3.Controler
{
    [Route("api/product")]
    public class ProductController
    {
        private readonly IProductService _productService;

        public ProductController(IProductService productService)
        {
            _productService = productService;
        }

        [HttpGet]
        [Route("all")]
        public async Task<List<ProductDto>> Create()
        {
            return await _productService.All();
        }

        [HttpPost]
        [Route("create")]
        public async Task<bool> Create([FromBody] CreateProductRequest request)
        {
            return await _productService.Create(request);
        }

        [HttpPost]
        [Route("update")]
        public async Task<bool> Update([FromBody] UpdateProductRequest request)
        {
            return await _productService.Update(request);
        }

        [HttpDelete]
        [Route("delete")]
        public async Task<bool> Delete([FromQuery] int productId)
        {
            return await _productService.Delete(productId);
        }

        [HttpGet]
        [Route("details")]
        public async Task<ProductDto> FindById([FromQuery] int productId)
        {
            return await _productService.FindById(productId);
        }
    }
}
