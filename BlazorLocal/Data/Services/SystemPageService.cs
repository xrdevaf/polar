using BlazorLocal.Data.ModelsDB;
using BlazorLocal.PageModels;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BlazorLocal.Data.Services
{
    public class SystemPageService
    {
        private EFRepository<LogApplicationError> appRepo { get; set; }
        public SystemPageService(ApplicationDbContext dbContext)
        {
            appRepo = new EFRepository<LogApplicationError>(dbContext);
        }

        public List<ErrorLogModel> GetModel(string userF = "", DateTime? dateF = null, string errorF = "")
        {
            var list = appRepo.Get(r =>
            (string.IsNullOrEmpty(userF) || r.UserData.ToLower().Contains(userF.ToLower()))
            && (string.IsNullOrEmpty(errorF) || r.ErrorMsg.ToLower().Contains(errorF.ToLower()))
            && (dateF == null || r.InsertDate.ToShortDateString() == dateF?.ToShortDateString()))
                .OrderByDescending(r => r.InsertDate);

            var result = list.Select(r => new ErrorLogModel()
            {
                Id = r.LogApplicationErrorId,
                UserData = r.UserData,
                ErrorLevel = r.ErrorLevel,
                ErrorMsg = r.ErrorMsg,
                ErrorContext = r.ErrorContext,
                InsertDate = r.InsertDate
            }).ToList();
            list = null;
            GC.SuppressFinalize(this);
            return result;
        }
    }
}
