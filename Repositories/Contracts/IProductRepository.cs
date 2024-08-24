using BookzoneProjNituDaniel.Models;

namespace BookzoneProjNituDaniel.Repositories.Contracts
{
    public interface IProductRepository
    {
        IEnumerable<Product> GetAllProducts();
        Product GetProduct(int id);
        void CreateProduct(Product product);
        void UpdateProduct(Product product);  
        void DeleteProduct(int id);
        
    }
}
