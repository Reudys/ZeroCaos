using ZeroCaos_BackEnd.Models;

namespace ZeroCaos_BackEnd.Interfaces
{
    public interface IProductService
    {
        #region Crud Methods
        Task<Product> CreateProductAsync(Product product);
        Task<IEnumerable<Product>> GetProductAsync();
        Task<Product> UpdateProductAsync(int id, Product product);
        Task<bool> DeleteProductAsync(int id);
        #endregion

        #region Custom Methods
        Task<Product> GetProductByNameAsync(string name);
        #endregion
    }
}
