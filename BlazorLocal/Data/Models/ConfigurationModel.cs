using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;

namespace BlazorLocal.Data.Models
{
    public class ConfigurationModel
    {
        public bool IsOrdernummerVINshort { get; set; }
        public bool IsHaendlernummer { get; set; }
        public bool IsHaendlerName { get; set; }
        public bool IsLieferort { get; set; }
        public bool IsLieferortAnsprechpartner { get; set; }       
    }
}
