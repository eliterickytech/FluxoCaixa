using Rickytech.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rickytech.Domain.Interfaces
{
    public interface ICategoryRepository
    {
        Task<int> DeleteAsync(int categoryId);
        Task<IEnumerable<Category>> GetAllAsync();
        Task<Category> GetByIdAsync(int categoryId);
        Task<int> InsertAsync(Category category);
    }
}
