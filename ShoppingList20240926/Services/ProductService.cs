using Microsoft.EntityFrameworkCore;
using ShoppingList20240926.Contracts;
using ShoppingList20240926.Data;
using ShoppingList20240926.Data.Models;
using ShoppingList20240926.Models;

namespace ShoppingList20240926.Services
{
    public class ProductService : IProductService
    {
        private readonly ShoppingListDbContext _context;

        public ProductService(ShoppingListDbContext context)
        {
            _context = context;
        }

        public async Task AddProductAsync(ProductViewModel model)
        {
            Product productToAdd = new Product()
            {
                Id = model.Id,
                Name = model.Name,
            };

            await _context.Products.AddAsync(productToAdd);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteProductAsync(int id)
        {
            Product? productToDelete = await _context.Products.FindAsync(id);

            if (productToDelete == null)
            {
                throw new ArgumentException("Invalid product!");
            }

            _context.Products.Remove(productToDelete);
            await _context.SaveChangesAsync();
        }

        public async Task<IList<ProductViewModel>> GetAllProductsAsync()
        {
            return await _context.Products
                .AsNoTracking()
                .Select(p => new ProductViewModel()
                {
                    Id = p.Id,
                    Name = p.Name
                })
                .ToListAsync();
        }

        public async Task<ProductViewModel> GetProductByIdAsync(int id)
        {
            Product? product = await _context.Products.FindAsync(id);

            if (product == null)
            {
                throw new ArgumentException("Invalid product!");
            }

            return new ProductViewModel()
            {
                Id = product.Id,
                Name = product.Name
            };
        }

        public async Task UpdateProductAsync(ProductViewModel model)
        {
            Product? productToUpdate = await _context.Products.FindAsync(model.Id);

            if (productToUpdate == null)
            {
                throw new ArgumentException("Invalid product");
            }

            productToUpdate.Name = model.Name;

            await _context.SaveChangesAsync();
        }
    }
}
