using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BlazorLocal.PageModels;
using Microsoft.EntityFrameworkCore;
using DbConnector.ModelsDB;


namespace BlazorLocal.Data.Services
{
    public class DataSheetService
    {
        private readonly string _connStr;
        public DataSheetService(string connStr)
        {
            _connStr = connStr;
        }

        public async Task<List<DataSheetItemViewModel>> GetAll()
        {
            var result = new DbConnector.DbContext(_connStr).Get().Select(r => Convert(r)).ToList();
            return result;
        }
        private static DataSheetItemViewModel Convert(DataSheet r)
        {
            return new DataSheetItemViewModel(r);
        }
    }
}
