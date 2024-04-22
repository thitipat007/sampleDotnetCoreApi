using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using sampleDotnetCoreApi.Api.Infrastructure.DbContext.Models;

namespace sampleDotnetCoreApi.Api.Repositories.IRepositories
{
    public interface IProductRepository
    {
        List<Product> GetProduct(List<int> id);
    }
}