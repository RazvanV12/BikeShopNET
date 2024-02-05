using BikeShopNET.Models;

namespace BikeShopNET.Services.ProductService
{
    public interface IProductService
    {
        void AddProduct(Product product);

        void UpdateProduct(Product product, string productId);

        void DeleteProduct(string productId);

        List<Product> GetAllProducts();

    }
}
