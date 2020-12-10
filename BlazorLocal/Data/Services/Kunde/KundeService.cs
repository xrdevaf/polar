using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BlazorLocal.PageModels;
using BlazorLocal.Data.ModelsDB;
using System.Text.Json;

namespace BlazorLocal.Data.Services
{
    public class KundeService
    {
        private EFRepository<Kunde> repo;

        public KundeService(ApplicationDbContext _context)
        {
            repo = new EFRepository<Kunde>(_context);
        }

        public async Task<List<KundeItemViewModel>> GetAll()
        {
            var result = repo.Get().Select(r => Convert(r)).ToList();
            return await Task.FromResult(result);
        }

        private static KundeItemViewModel Convert(Kunde r)
        {
            return new KundeItemViewModel(r);
        }
        public void Delete(KundeItemViewModel item)
        {
            var x = repo.FindById(item.KundeId);
            repo.Remove(x);
        }
        public void Update(KundeItemViewModel item)
        {
            var x = repo.FindById(item.KundeId);
            x.KundeId = item.KundeId;
            x.KundeName = item.KundeName;
            x.KundeNR = item.KundeNR;
            x.ConfigurationJson = JsonSerializer.Serialize(item.ConfModel);

            repo.Update(x);
        }

        public KundeItemViewModel Create(KundeItemViewModel item)
        {
            item.ConfigurationJson = JsonSerializer.Serialize(item.ConfModel);
            var newItem = repo.Create(item.Item);
            return Convert(newItem);
        }
    }
}
