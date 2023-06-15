using Rickytech.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rickytech.Domain.Interfaces
{
    public interface IFlowRepository
    {
        Task<int> DeleteAsync(int Id);
        Task<IEnumerable<Flow>> GetAllAsync();
        Task<int> InsertAsync(Flow flow);
    }
}
