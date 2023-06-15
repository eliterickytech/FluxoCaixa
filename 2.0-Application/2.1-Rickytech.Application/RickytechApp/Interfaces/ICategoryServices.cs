using Rickytech.Application.RickytechApp.Input;
using Rickytech.Application.RickytechApp.Result;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rickytech.Domain.Interfaces.Services
{
    public interface ICategoryServices
    {
        Task<int> DeleteAsync(int categoryId);
        Task<List<CategoryResult>> GetAllAsync();
        Task<CategoryResult> GetByIdAsync(int categoryId);
        Task<int> InsertAsync(CategoryInput categoryInput);
    }
}
