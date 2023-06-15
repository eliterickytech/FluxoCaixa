using Dapper;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Rickytech.Application.RickytechApp.Input;
using Rickytech.Domain.Entities;
using Rickytech.Domain.Interfaces;
using Microsoft.AspNetCore.Mvc.ApplicationParts;

namespace Rickytech.Infrastructure.Repository
{
    public class CategoryRepository : BaseRepository, ICategoryRepository
    {
        public CategoryRepository(IConfiguration configuration) : base(configuration) { }

        public async Task<int> DeleteAsync(int categoryId)
        {
            var query = @"
                UPDATE Category SET Enabled = 0, ChangedDate = GETDATE() WHERE Id = @CategoryId
            ";

            var parameters = new DynamicParameters();
            parameters.Add("@CategoryId", categoryId, System.Data.DbType.Int32);

            var result = await ExecuteAsync<int>(query, parameters);

            return result;
        }

        public async Task<int> InsertAsync(Category category)
        {
            var query = @"
                INSERT INTO Category (Name, OperationId) VALUES (@Category, @OperationId)
            ";

            var parameters = new DynamicParameters();
            parameters.Add("@Category", category.Name, System.Data.DbType.String);
            parameters.Add("@OperationId", (int)category.Operation, System.Data.DbType.Int32);

            var result = await ExecuteAsync<int>(query, parameters);

            return result;
        }

        public async Task<IEnumerable<Category>> GetAllAsync()
        {
            var query = @"
                SELECT 
                    Id
                ,   Name
                ,   OperationId AS Operation
                ,   CreatedDate
                FROM
                    Category
                WHERE
                    Enabled = 1
            ";

            return await QueryAsync<Category>(query); 
        }

        public async Task<Category> GetByIdAsync(int categoryId)
        {
            var query = @"
                SELECT 
                    Id
                ,   Name
                ,   OperationId AS Operation
                ,   CreatedDate
                FROM
                    Category
                WHERE
                    Enabled = 1
                AND Id = @CategoryId
            ";
            var parameters = new DynamicParameters();
            parameters.Add("@CategoryId", categoryId, System.Data.DbType.Int32);
            return await QueryFirstOrDefaultAsync<Category>(query, parameters);
        }
    }
}
