using BookzoneProjNituDaniel.Controllers;
using BookzoneProjNituDaniel.Data;
using BookzoneProjNituDaniel.Models;
using BookzoneProjNituDaniel.Repositories.Contracts;
using Microsoft.EntityFrameworkCore;

namespace BookzoneProjNituDaniel.Repositories.Implementations
{
    public class ProductRepository : IProductRepository
    {
        private readonly DataContext _context;

        public ProductRepository(DataContext context)
        {
            _context = context;
        }

        public IEnumerable<Product> GetAllProducts()
        {
            return _context.Products;
        }

        public Product GetProduct(int id)
        {
            return _context.Products.Single(x => x.Id == id);
        }

        public void CreateProduct(Product product)
        {
            _context.Products.Add(product);
            SaveDatabaseChanges();
        }
        public void UpdateProduct(Product product)
        {
            _context.Products.Update(product);
            SaveDatabaseChanges();
        }

        public void DeleteProduct(int id)
        {
            var product= _context.Products.Include(x=>x.OrderProducts).ThenInclude(x=>x.Order).Single(x=>x.Id==id);

            //Removes the product form ordered products and orders with no ordered products 
            var orderedProductsOfThisType = _context.OrderProducts.Where(x => x.ProductId == id);
            foreach (var orderedProduct in orderedProductsOfThisType)
            {
                product.OrderProducts.Remove(orderedProduct);

                //Remove the order only if the product we are going to delete is the only product ordered
                var orderedProductsInOrder = _context.Orders.Where(x=>x.Id == orderedProduct.OrderId).Select(x=>x.OrderProducts);
                if(orderedProductsInOrder.Count() == 1)
                {
                    _context.Orders.Remove(orderedProduct.Order);
                }
               
            }

            _context.Products.Remove(product);
            SaveDatabaseChanges();
        }

        private void SaveDatabaseChanges()
        {
            _context.SaveChanges();
        }
    }
}
