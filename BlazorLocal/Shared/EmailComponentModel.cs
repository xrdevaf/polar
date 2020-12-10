using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorLocal.Shared
{
    public class EmailComponentModel
    {
        public bool IsOpen { get; set; }
        public string DefaultBodyText { get; set; }
        public string DefaultFrom { get; set; }
    }

    public class EmailModel
    {
        public string From { get; set; }
        public string To { get; set; }
        public string Subject { get; set; }
        public string Body { get; set; }
    }
}
