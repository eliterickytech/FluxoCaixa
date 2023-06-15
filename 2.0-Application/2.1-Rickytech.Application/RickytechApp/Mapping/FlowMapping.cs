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
    public static class FlowMapping
    {
        public static Flow Map(this FlowInput input)
        {
            if (input is null) return default;

            return new Flow()
            {
                Id = input.Id,
                Name = input.Name,
                CategoryId = input.CategoryId,
                OperationDate = input.OperationDate,
                OperationValue = input.OperationValue   
            };
        }

        public static List<FlowResult> Map(this IEnumerable<Flow> inputs)
        {
            if (inputs is null) return default;

            List<FlowResult> flowResults = new List<FlowResult>();

            foreach (var input in inputs)
            {
                flowResults.Add(new FlowResult()
                {
                    OperationValue = input.OperationValue,
                    OperationDate = input.OperationDate,
                    CategoryId = input.CategoryId,
                    Name = input.Name,
                    Id = input.Id   ,
                    CategoryName = input.CategoryName,
                    Operation = input.Operation

                });
            }

            return flowResults;
        }
    }
}
