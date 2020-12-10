using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BlazorLocal.PageModels;
using Microsoft.EntityFrameworkCore;
using DbConnector.ModelsDB;


namespace BlazorLocal.Data.Services
{
    public class StatPolarService
    {
        private readonly string _connStr;

        public StatPolarService(string connStr)
        {
            _connStr = connStr;
        }
        public async Task<List<StatPolarItemViewModel>> GetAll()
        {
            List<StatPolarItemViewModel> result = new List<StatPolarItemViewModel>();
            for (int year = 2019; year < 2021; year++)
            {
                for (int month = 1; month < 13; month++)
                {
                   var point = new DbConnector.DbContext(_connStr).GetStatPolar(year, month);
                   result.Add(Convert(point));
                }
            }
            return result;
        }
        private static StatPolarItemViewModel Convert(StatPolar r)
        {
            return new StatPolarItemViewModel(r);
        }
    }
}
