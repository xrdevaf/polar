using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using BlazorLocal.Data.Models;
using BlazorLocal.Data.ModelsDB;
using BlazorLocal.PageModels;
using Microsoft.EntityFrameworkCore;

namespace BlazorLocal.Data.Services
{
    public class AuftragService
    {
        private EFRepository<Auftrag> repo;
        private EFRepository<Kunde> repoKunde;

        public AuftragService(ApplicationDbContext _context)
        {
            repo = new EFRepository<Auftrag>(_context);
            repoKunde = new EFRepository<Kunde>(_context);
        }

        public async Task<List<AuftragItemViewModel>> GetAll(string selectedFahrzeugstatus = "")
        {
            var result = repo.Get(r => string.IsNullOrEmpty(selectedFahrzeugstatus) || r.Fahrzeugstatus == selectedFahrzeugstatus)
                .OrderByDescending(r => r.AuftragId).Take(100).Select(r => Convert(r)).ToList();

            foreach (var item in result)
            {
                item.KundeItem = repoKunde.FindById(item.KundeId);
                item.Configuration = string.IsNullOrEmpty(item.KundeItem?.ConfigurationJson) ? new ConfigurationModel() : JsonSerializer.Deserialize<ConfigurationModel>(item.KundeItem.ConfigurationJson);
            }

            return await Task.FromResult(result);
        }

        private static AuftragItemViewModel Convert(Auftrag r)
        {
            return new AuftragItemViewModel(r);
        }
        public void Delete(AuftragItemViewModel item)
        {
            var x = repo.FindById(item.AuftragId);
            repo.Remove(x);
        }
        public AuftragItemViewModel Update(AuftragItemViewModel item)
        {
            var x = repo.FindById(item.AuftragId);
            x.AuftragId = item.AuftragId;
            x.KundeId = item.KundeId;
            x.Laufnummer = item.Laufnummer;
            x.OrdernummerVINshort = item.OrdernummerVINshort;
            x.Haendlernummer = item.Haendlernummer;
            x.HaendlerName = item.HaendlerName;
            x.Lieferort = item.Lieferort;
            x.LieferortAnsprechpartner = item.LieferortAnsprechpartner;
            x.Baureihe = item.Baureihe;
            x.Fahrzeugtyp = item.Fahrzeugtyp;
            x.Fahrzeugstatus = item.Fahrzeugstatus;

            repo.Update(x);

            item.KundeItem = repoKunde.FindById(item.KundeId);
            item.Configuration = string.IsNullOrEmpty(item.KundeItem?.ConfigurationJson) ? new ConfigurationModel() : JsonSerializer.Deserialize<ConfigurationModel>(item.KundeItem.ConfigurationJson);
            return item;
        }

        public AuftragItemViewModel Create(AuftragItemViewModel item)
        {
            var id = repo.Get().Select(r => r.AuftragId).Max() + 1;
            item.AuftragId = id;

            var newItem = repo.Create(item.Item);
            return Convert(newItem);
        }
    }
}
