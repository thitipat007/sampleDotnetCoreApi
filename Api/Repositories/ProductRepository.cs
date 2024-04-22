using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using sampleDotnetCoreApi.Api.Infrastructure.DbContext.Models;
using sampleDotnetCoreApi.Api.Repositories.IRepositories;

namespace sampleDotnetCoreApi.Api.Repositories
{
    public class ProductRepository : IProductRepository
    {
        public ApplicationDbContext _context { get; set; }

        public ProductRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public List<Product> GetProduct(List<int> id)
        {
            List<Product> product = new List<Product>();
            try
            {
                product = _context.products.Where(product => id.Contains(product.Id)).ToList();
            }
            catch (Exception ex)
            {
                // Exception
            }
            return product;
        }
    }
}