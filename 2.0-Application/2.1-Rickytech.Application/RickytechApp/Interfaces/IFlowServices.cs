using Rickytech.Application.RickytechApp.Input;
using Rickytech.Application.RickytechApp.Result;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rickytech.Application.RickytechApp.Interfaces
{
    public interface IFlowServices
    {
        Task<int> DeleteAsync(int flowId);
        Task<List<FlowResult>> GetAllAsync();
        Task<int> InsertAsync(FlowInput flowInput);
    }
}
