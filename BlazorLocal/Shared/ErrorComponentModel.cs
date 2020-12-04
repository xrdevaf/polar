using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorLocal.Shared
{
    public class ErrorComponentModel
    {
        public string ErrorMessage { get; set; }
        public string ErrorContext { get; set; }
        public string RedirectUrl { get; set; }
        public bool IsOpen { get; set; }
    }
}
