using AutoMapper;
using BookzoneProjNituDaniel.Models;
using BookzoneProjNituDaniel.Models.DTO.Product;
using BookzoneProjNituDaniel.Models.Input.Product;
using BookzoneProjNituDaniel.Repositories.Contracts;
using BookzoneProjNituDaniel.Services.Contracts;

namespace BookzoneProjNituDaniel.Services.Implementations
{
    public class ProductService : IProductService
    {
        private readonly IMapper _mapper;
        private readonly IProductRepository _productRepository;

        public ProductService(IMapper mapper, IProductRepository productRepository)
        {
            _mapper = mapper;
            _productRepository = productRepository;
        }

        public void CreateProduct(CreateProductInput input)
        {
            var product = _mapper.Map<Product>(input);
            _productRepository.CreateProduct(product);
        }

        public void UpdateProduct(int id, UpdateProductInput input)
        {

            var product = _mapper.Map<Product>(input);
            _productRepository.UpdateProduct(product);

        }

        public void DeleteProduct(int id)
        {
            _productRepository.DeleteProduct(id);
        }

        public ProductDetailsDTO GetProductDetails(int id)
        {
            var product = _productRepository.GetProduct(id);
            return _mapper.Map<ProductDetailsDTO>(product);
        }

        public IEnumerable<ProductDTO> GetProducts()
        {
            var products = _productRepository.GetAllProducts();
            return _mapper.Map<IEnumerable<ProductDTO>>(products);
        }

    }
}
