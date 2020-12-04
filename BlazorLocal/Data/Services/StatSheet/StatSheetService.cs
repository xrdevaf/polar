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
        public async Task<List<StatSheetItemViewModel>> GetAll()
        {
            var result = new DbConnector.DbContext("Server=192.168.8.102;Port=3306;Database=shopware;Uid=root;Pwd=root;").GetStats().Select(r => Convert(r)).ToList();
            return result;
        }
        private static StatSheetItemViewModel Convert(StatSheet r)
        {
            return new StatSheetItemViewModel(r);
        }
    }
}
