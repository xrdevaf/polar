using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BlazorLocal.PageModels;
using Microsoft.EntityFrameworkCore;
using DbConnector.ModelsDB;


namespace BlazorLocal.Data.Services
{
    public class ShopDiffPolarService
    {
        private readonly string _connStr;

        public ShopDiffPolarService(string connStr)
        {
            _connStr = connStr;
        }
        public async Task<List<ShopDiffPolarItemViewModel>> GetAll()
        {
            List<ShopDiffPolarItemViewModel> result = new List<ShopDiffPolarItemViewModel>();
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
        private static ShopDiffPolarItemViewModel Convert(ShopDiffPolar r)
        {
            return new ShopDiffPolarItemViewModel(r);
        }
    }
}
