using WebApiAspNetCoreBRGAAP.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApiAspNetCoreBRGAAP.Repositories
{
    public interface Interface
    {
    
        Task<IEnumerable<Category>> Get();

        Task<Category> Get(int Id);

        Task<Category> Create(Category book);

        Task Update(Category book);

        Task Delete(int Id);
    }
}