
using Rickytech.Domain.Interfaces;
using Microsoft.Extensions.Caching.Distributed;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Rickytech.Application.CBSProteusApp
{
    public class ImportFileService 
    {

        private readonly IDistributedCache _cache;

        //public ImportFileService(IImportFileRepository importFilesRepository, IDistributedCache cache)
        //{
        //    _importFileRepository = importFilesRepository;
        //    _cache = cache;
        //}

        //public async Task<int> InsertImportFileAsync(ImportFileInput importFileInput)
        //{
        //    var importFile = importFileInput?.Map();

        //    return await _importFileRepository.InsertImportFileAsync(importFile);
        //}

        //public async Task UpdateImportFileAsync(ImportFileInput importFileInput)
        //{
        //    var importFile = importFileInput?.Map();

        //    await _importFileRepository.UpdateImportFileAsync(importFile);
        //}

        //public async Task<IEnumerable<ImportFileResult>> GetImportFileAsync()
        //{

        //    var key = "importFiles"; // criar uma chave
        //    var importFiles = new List<Domain.Entities.ImportFile>();
            
        //    var json = await _cache.GetStringAsync(key); // buscar no redis o conteudo do cache de acordo com a chave que registramos no passo anterior

        //    if (json != null) // verifica se retornou o cache da chave que buscamos
        //        importFiles = JsonSerializer.Deserialize<IEnumerable<Domain.Entities.ImportFile>>(json).ToList(); // se retornou então mandamos deserializar no objeto que o método está pedindo de retorno
        //    else
        //    {
        //        var result = await _importFileRepository.GetImportFileAsync(); // pesquisa na base de dados 
        //        json = JsonSerializer.Serialize<List<Domain.Entities.ImportFile>>(result.ToList()); // serializa a entidade que retornamos no passo anterior
        //        await _cache.SetStringAsync(key, json); // gravamos no cache do redis.

        //        importFiles = result.ToList();
        //    }

        //    return importFiles?.Map();
        //}
    }
}
