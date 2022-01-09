using System;
using System.Threading.Tasks;
using Domain;

namespace Persistence.ProductRepository
{
    public interface IProductRepository
    {
        Task<Product> GetProductByIdAsync(Guid id);
    }
}