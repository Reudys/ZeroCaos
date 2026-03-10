using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ZeroCaos_BackEnd.Data;
using ZeroCaos_BackEnd.Interfaces;
using ZeroCaos_BackEnd.Models;

namespace ZeroCaos_BackEnd.Services
{
    public class ProductService : IProductService
    {
        private readonly DataContext _context;
        public ProductService(DataContext context) { _context = context; }

        #region Crud Methods
        public async Task<Product> CreateProductAsync(Product product)
        {
            await _context.Products.AddAsync(product);
            await _context.SaveChangesAsync();
            return product;
        }
        public async Task<IEnumerable<Product>> GetProductAsync()
        {
            return await _context.Products.ToListAsync();
        }
        public async Task<Product> UpdateProductAsync(int id, Product product)
        {
            var prod = await _context.Products.FindAsync(id);
            if (prod == null) return null;
            prod.Name = product.Name;
            prod.Description = product.Description;
            prod.stock = product.stock;
            prod.TypeStock = product.TypeStock;
            prod.Foto = product.Foto;
            prod.Code = product.Code;
            prod.ExpirationDate = product.ExpirationDate;
            await _context.SaveChangesAsync();
            return prod;
        }
        public async Task<bool> DeleteProductAsync(int id)
        {
            var product = await _context.Products.FindAsync(id);
            if (product == null) return false;
            _context.Products.Remove(product);
            await _context.SaveChangesAsync();
            return true;
        }
        #endregion

        #region Custom Methods
        public async Task<Product> GetProductByNameAsync(string name)
        {
            var prod = await _context.Products.FirstOrDefaultAsync(p => p.Name == name);
            if (prod == null) return null;
            return prod;
        }
        #endregion
    }
}
