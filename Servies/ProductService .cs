using Doiman.Contracts;
using Doiman.Entites;
using ServiesAbstractions;
using Sheared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Servies
{
    public class ProductService(IUnitOfWork unitOfWork) : iProductService
    {
        public async Task<ProductDto> CreateProductAsync(ProductDto dto)
        {
            var product = new Product
            {
                Name = dto.Name,
                Price = dto.Price,
                Stock = dto.Stock
            };

            await unitOfWork.GetRepo<Product, int>().AddAsync(product);
            await unitOfWork.SaveChangesAsync();

            return new ProductDto
            {
                Id = product.Id,
                Name = product.Name,
                Price = product.Price,
                Stock = product.Stock
            };
        }


        public async Task<IEnumerable<ProductDto>> GetAllProductsAsync()
        {
            var products = await unitOfWork.GetRepo<Product, int>().GetAllAsync();
            return products.Select(p => new ProductDto
            {
                Id = p.Id,
                Name = p.Name,
                Price = p.Price,
                Stock = p.Stock
            });
        }

        public async Task<ProductDto> GetProductByIdAsync(int id)
        {
            var product = await unitOfWork .GetRepo<Product ,int>().GetAsync(id);
            if (product == null) throw new Exception ("Product not found");

            return new ProductDto
            {
                Id = product.Id,
                Name = product.Name,
                Price = product.Price,
                Stock = product.Stock
            };
        }

        public async Task<ProductDto> UpdateProductAsync(int id, ProductDto dto)
        {
            var product = await unitOfWork.GetRepo<Product, int>().GetAsync(id);
            if (product == null) throw new Exception("Product not found");

            product.Name = dto.Name;
            product.Price = dto.Price;
            product.Stock = dto.Stock;

            await unitOfWork.SaveChangesAsync();

            return new ProductDto
            {
                Id = product.Id,
                Name = product.Name,
                Price = product.Price,
                Stock = product.Stock
            };
        }
    }
}
