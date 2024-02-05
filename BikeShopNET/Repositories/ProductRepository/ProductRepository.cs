using BikeShopNET.Models;
using Microsoft.EntityFrameworkCore;

namespace BikeShopNET.Repositories.ProductRepository
{
    public class ProductRepository : IProductRepository
    {
        private readonly BikeShopContext _context;

        public ProductRepository(BikeShopContext context)
        {
            _context = context;
        }

        public List<Product> GetAll()
        {
            return _context.Products.ToList();
        }

        public Product? GetById(string id)
        {
            return _context.Products.Find(id);
        }

        public void Create(Product entity)
        {
            _context.Products.Add(entity);
        }

        public void Update(Product entity)
        {
            _context.Products.Update(entity);
        }

        public void Delete(Product entity)
        {
            _context.Products.Remove(entity);
        }
    }
}
