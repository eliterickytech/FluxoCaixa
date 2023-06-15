using Microsoft.Extensions.Caching.Distributed;
using Rickytech.Application.RickytechApp.Input;
using Rickytech.Application.RickytechApp.Interfaces;
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
    public class FlowServices : IFlowServices
    {
        private readonly IDistributedCache _cache;
        private readonly IFlowRepository _flowRepository;

        public FlowServices(IDistributedCache cache, IFlowRepository flowRepository)
        {
            _cache = cache;
            _flowRepository = flowRepository;
        }

        public async Task<int> InsertAsync(FlowInput flowInput)
        {
            var map = flowInput.Map();

            return await _flowRepository.InsertAsync(map);
        }

        public async Task<int> DeleteAsync(int flowId)
        {

            return await _flowRepository.DeleteAsync(flowId);
        }

        public async Task<List<FlowResult>> GetAllAsync()
        {
            var result = await _flowRepository.GetAllAsync();

            return result.ToList().Map();
        }
    }
}
