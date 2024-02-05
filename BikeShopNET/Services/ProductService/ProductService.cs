using System.Collections.Generic;
using BikeShopNET.Models;
using BikeShopNET.Repositories.ProductRepository;


namespace BikeShopNET.Services.ProductService
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _productRepository;

        public ProductService(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public void AddProduct(Product product)
        {
            _productRepository.Create(product);
        }

        public void DeleteProduct(string productId)
        {
            var product = _productRepository.GetById(productId);
            if(product != null)
                _productRepository.Delete(product);
            return;
        }

        public void UpdateProduct(Product product, string productId)
        {
            var productToUpdate = _productRepository.GetById(productId);

            if (productToUpdate != null)
            {
                productToUpdate.Name = product.Name;
                productToUpdate.Price = product.Price;
                productToUpdate.Description = product.Description;
                productToUpdate.CategoryId = product.CategoryId;
                _productRepository.Update(productToUpdate);
            }
            return;
        }

        public List<Product> GetAllProducts()
        {
            return _productRepository.GetAll();
        }
    }
}
