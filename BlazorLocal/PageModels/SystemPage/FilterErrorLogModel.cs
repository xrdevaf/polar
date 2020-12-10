using System;

namespace BlazorLocal.PageModels
{
    public class FilterErrorLogModel
    {
        public string UserFltr { get; set; }
        public DateTime? DateFltr { get; set; } = null;
        public string ErrorFltr { get; set; }
    }
}
