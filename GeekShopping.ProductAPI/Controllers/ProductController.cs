using GeekShopping.ProductAPI.Data.ValueObjects;
using GeekShopping.ProductAPI.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GeekShopping.ProductAPI.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private IProductRepository _repository;

        public ProductController(IProductRepository repository)
        {
            _repository = repository ?? throw new ArgumentNullException(nameof(repository));
        }

        [HttpPost]
        public async Task<ActionResult<ProductVO>> Create([FromBody] ProductVO productVo)
        {
            if (productVo == null) return BadRequest();

            var product = await _repository.Create(productVo);

            return Ok(product);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<ProductVO>> Update([FromBody] ProductVO productVo)
        {
            if (productVo == null) return BadRequest();

            var product = await _repository.Create(productVo);

            return Ok(product);
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<ProductVO>>> FindAll()
        {
            var products = await _repository.FindAll();

            if (products == null) return NotFound();

            return Ok(products);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ProductVO>> FindById(long id)
        {
            var product = await _repository.FindById(id);

            if (product == null) return NotFound();

            return Ok(product);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<ProductVO>> Delete(long id)
        {
            var status = await _repository.Delete(id);

            if (!status) return NotFound();

            return Ok(status);
        }

    }
}
