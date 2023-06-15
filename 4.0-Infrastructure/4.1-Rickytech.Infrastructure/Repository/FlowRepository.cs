using Dapper;
using Microsoft.Extensions.Configuration;
using Rickytech.Application.RickytechApp.Input;
using Rickytech.Application.RickytechApp.Result;
using Rickytech.Domain.Entities;
using Rickytech.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rickytech.Infrastructure.Repository
{
    public class FlowRepository : BaseRepository, IFlowRepository
    {
        public FlowRepository(IConfiguration configuration) : base(configuration) { }

        public async Task<IEnumerable<Flow>> GetAllAsync()
        {
            var query = @"
                SELECT
                    Flow.Id
                ,   Flow.Name
                ,   Flow.CategoryId
                ,   Category.Name AS CategoryName
                ,   Category.OperationId AS Operation
                ,   Flow.OperationDate
                ,   Flow.OperationValue
                FROM
                    Flow
                    
                        INNER JOIN
                        Category
                        ON Category.Id = Flow.CategoryId

                WHERE
                    Flow.Enabled        = 1
                AND Category.Enabled    = 1
                ";

            return await QueryAsync<Flow>(query);
        } 

        public async Task<int> InsertAsync(Flow flow)
        {
            var query = @"
                INSERT INTO Flow
                (
                    Name
                ,   CategoryId
                ,   OperationDate
                ,   OperationValue
                )
                VALUES
                (
                    @Name
                ,   @CategoryId
                ,   @OperationDate
                ,   @OperationValue
                )
                ";

            var parameters = new DynamicParameters();
            parameters.Add("@Name", flow.Name, System.Data.DbType.String);
            parameters.Add("@CategoryId", flow.CategoryId, System.Data.DbType.Int32);
            parameters.Add("@OperationDate", flow.OperationDate, System.Data.DbType.DateTime);
            parameters.Add("@OperationValue", flow.OperationValue, System.Data.DbType.Decimal);

            return await ExecuteAsync<int>(query, parameters);
        }

        public async Task<int> DeleteAsync(int Id)
        {
            var query = @"
                UPDATE Flow SET Enabled = 0, ChangedDate = GETDATE() WHERE Id = @Id
                ";

            var parameters = new DynamicParameters();
            parameters.Add("@Id", Id, System.Data.DbType.Int32);
            return await ExecuteAsync<int>(query, parameters);
        }
    }
}
