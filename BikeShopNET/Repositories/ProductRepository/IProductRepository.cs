using BikeShopNET.Models;
using Microsoft.EntityFrameworkCore;

namespace BikeShopNET.Repositories.ProductRepository
{
    public interface IProductRepository
    {
        List<Product> GetAll();
        Product? GetById(string id);
        void Create(Product entity);
        void Update(Product entity);
        void Delete(Product entity);
    }
}
