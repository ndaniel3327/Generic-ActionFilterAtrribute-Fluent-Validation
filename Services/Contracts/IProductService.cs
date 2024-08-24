using BookzoneProjNituDaniel.Models.DTO.Product;
using BookzoneProjNituDaniel.Models.Input.Product;

namespace BookzoneProjNituDaniel.Services.Contracts
{
    public interface IProductService
    {
        IEnumerable<ProductDTO> GetProducts();
        ProductDetailsDTO GetProductDetails(int id);
        void CreateProduct(CreateProductInput input);
        void UpdateProduct(int id,UpdateProductInput input);
        void DeleteProduct(int id);
    }
}
