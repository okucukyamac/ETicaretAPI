using ETicaretAPI.Application.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ETicaretAPI.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        readonly private IProductWriteRepository _productWriteRepository;
        readonly private IProductReadRepository _productReadRepository;

        public ProductsController(IProductWriteRepository productWriteRepository, IProductReadRepository productReadRepository)
        {
            _productWriteRepository = productWriteRepository;
            _productReadRepository = productReadRepository;
        }

        [HttpGet]
        public async void Get()
        {
            await _productWriteRepository.AddRangeAsync(new()
            {
                new() { Id = Guid.NewGuid(), Name = "Product 1", Stock = 10, Price = 100, CreatedDate = DateTime.UtcNow },
                new() { Id = Guid.NewGuid(), Name = "Product 2", Stock = 20, Price = 100, CreatedDate = DateTime.UtcNow },
                new() { Id = Guid.NewGuid(), Name = "Product 3", Stock = 130, Price = 100, CreatedDate = DateTime.UtcNow }
            });

            await _productWriteRepository.SaveAsync();

        }
    }
}
