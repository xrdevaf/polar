using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BlazorLocal.Data.ModelsDB;
using BlazorLocal.PageModels;

namespace BlazorLocal.Data.Services
{
    public class SMTPSettingService
    {
        private EFRepository<SMTPSetting> repo;

        public SMTPSettingService(ApplicationDbContext _context)
        {
            repo = new EFRepository<SMTPSetting>(_context);
        }
        public async Task<List<SMTPSettingItemViewModel>> GetAll()
        {
            var result = repo.Get().Select(r => Convert(r)).ToList();
            return await Task.FromResult(result);
        }


        private static SMTPSettingItemViewModel Convert(SMTPSetting r)
        {
            return new SMTPSettingItemViewModel(r);
        }
        public void Delete(SMTPSettingItemViewModel item)
        {
            var x = repo.FindById(item.SMTPSettingId);
            repo.Remove(x);
        }
        public void Update(SMTPSettingItemViewModel item)
        {
            var x = repo.FindById(item.SMTPSettingId);
            x.SMTPUsername = item.SMTPUsername;
            x.SMTPPassword = item.SMTPPassword;
            x.SMTPServer = item.SMTPServer;
            x.SMTPPort = item.SMTPPort;
            x.EnableSSL = item.EnableSSL;
            x.IsActive = item.IsActive;

            repo.Update(x);
        }

        public SMTPSettingItemViewModel Create(SMTPSettingItemViewModel item)
        {
            var newItem = repo.Create(item.Item);
            return Convert(newItem);
        }
    }
}
