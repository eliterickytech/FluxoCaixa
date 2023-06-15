using Microsoft.Extensions.Caching.Distributed;
using Rickytech.Application.RickytechApp.Input;
using Rickytech.Application.RickytechApp.Mapping;
using Rickytech.Application.RickytechApp.Result;
using Rickytech.Domain.Entities;
using Rickytech.Domain.Interfaces;
using Rickytech.Domain.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rickytech.Application.RickytechApp
{
    public class CategoryServices : ICategoryServices
    {
        private readonly IDistributedCache _cache;
        private readonly ICategoryRepository _categoryRepository;

        public CategoryServices(IDistributedCache cache, ICategoryRepository categoryRepository)
        {
            _cache = cache;
            _categoryRepository = categoryRepository;
        }

        public async Task<int> InsertAsync(CategoryInput categoryInput)
        {
            var map = categoryInput.Map();

            return await _categoryRepository.InsertAsync(map);
        }

        public async Task<int> DeleteAsync(int categoryId)
        {

            return await _categoryRepository.DeleteAsync(categoryId);
        }

        public async Task<List<CategoryResult>> GetAllAsync()
        {
            var result = await _categoryRepository.GetAllAsync();

            return result.ToList().Map();
        }

        public async Task<CategoryResult> GetByIdAsync(int categoryId)
        {
            var result = await _categoryRepository.GetByIdAsync(categoryId);

            List<Category> categories = new List<Category>();

            categories.Add(result);

            return categories.Map().FirstOrDefault();
        }

    }
}
