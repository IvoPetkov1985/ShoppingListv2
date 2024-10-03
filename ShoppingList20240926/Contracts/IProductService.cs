using ShoppingList20240926.Models;

namespace ShoppingList20240926.Contracts
{
    public interface IProductService
    {
        Task<IList<ProductViewModel>> GetAllProductsAsync();

        Task<ProductViewModel> GetProductByIdAsync(int id);

        Task AddProductAsync(ProductViewModel model);

        Task UpdateProductAsync(ProductViewModel model);

        Task DeleteProductAsync(int id);
    }
}
