using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BlazorLocal.PageModels;
using Microsoft.EntityFrameworkCore;
using DbConnector.ModelsDB;


namespace BlazorLocal.Data.Services
{
    public class StatSheetService
    {
        private readonly string _connStr;

        public StatSheetService(string connStr)
        {
            _connStr = connStr;
        }
        public async Task<List<StatSheetItemViewModel>> GetAll()
        {
            List<StatSheetItemViewModel> result = new List<StatSheetItemViewModel>();
            for (int year = 2019; year < 2021; year++)
            {
                for (int month = 1; month < 13; month++)
                {
                   var point = new DbConnector.DbContext(_connStr).GetStats(year, month);
                   result.Add(Convert(point));
                }
            }
            return result;
        }
        private static StatSheetItemViewModel Convert(StatSheet r)
        {
            return new StatSheetItemViewModel(r);
        }
    }
}
