using Rickytech.Application.RickytechApp.Input;
using Rickytech.Application.RickytechApp.Result;
using Rickytech.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rickytech.Application.RickytechApp.Mapping
{
    public static class CategoryMapping
    {
        public static Category Map(this CategoryInput input)
        {
            if (input is null) return default;

            return new Category()
            {
                Name = input.Name,
                Operation = input.Operation,
            };
        }

        public static List<CategoryResult> Map(this IEnumerable<Category> inputs)
        {
            if (inputs is null) return default;

            List<CategoryResult> categoryResults = new List<CategoryResult>();

            foreach (var input in inputs)
            {
                categoryResults.Add(new CategoryResult()
                {
                    Id = input.Id,
                    Name = input.Name,
                    Operation = input.Operation,
                    CreatedDate = input.CreatedDate,
                });
            }

            return categoryResults;
        }
    }
}
