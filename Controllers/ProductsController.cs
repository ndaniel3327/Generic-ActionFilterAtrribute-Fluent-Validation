using BookzoneProjNituDaniel.CustomFilters;
using BookzoneProjNituDaniel.Models.DTO.Product;
using BookzoneProjNituDaniel.Models.Input.Product;
using BookzoneProjNituDaniel.Models.Validators.Product;
using BookzoneProjNituDaniel.Services.Contracts;
using Microsoft.AspNetCore.Mvc;

namespace BookzoneProjNituDaniel.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IProductService _productService;

        public ProductsController(IProductService productService)
        {
            _productService = productService;
        }

        [HttpGet]
        public ActionResult<List<ProductDTO>> GetAll()
        {
            var products = _productService.GetProducts();
            return Ok(products);
        }

        [HttpGet("{id}")]
        public ActionResult<ProductDetailsDTO> Get(int id)
        {
            var products = _productService.GetProductDetails(id);
            return Ok(products);
        }

        [HttpPost]
        [ValidatorFilter<CreateProductValidator, CreateProductInput>(InputVariableName = "input")]
        public IActionResult CreateProduct(CreateProductInput input)
        {
            _productService.CreateProduct(input);
            return NoContent();
        }

        [HttpPut("{id}")]
        [ValidatorFilter<UpdateProductValidator,UpdateProductInput>(InputVariableName = "input")]
        public IActionResult UpdateProduct(int id, [FromBody] UpdateProductInput input)
        {
            _productService.UpdateProduct(id, input);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteProduct(int id)
        {
            _productService.DeleteProduct(id);
            return NoContent();
        }

    }
}