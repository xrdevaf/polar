using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BlazorLocal.PageModels;
using Microsoft.EntityFrameworkCore;

namespace BlazorLocal.Data.Services
{
    public class AuftragService
    {
        private EFRepository<Auftrag> repo;

        public AuftragService(ApplicationDbContext _context)
        {
            repo = new EFRepository<Auftrag>(_context);
        }
        public async Task<List<AuftragItemViewModel>> GetAll()
        {
            var result = repo.Get().Select(r => Convert(r)).ToList();
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
        public void Update(AuftragItemViewModel item)
        {
            var x = repo.FindById(item.AuftragId);
            x.AuftragId = item.AuftragId;
            x.Kunde = item.Kunde;
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
        }

        public AuftragItemViewModel Create(AuftragItemViewModel item)
        {
            var newItem = repo.Create(item.Item);
            return Convert(newItem);
        }
    }
}
