using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BlazorLocal.PageModels;

namespace BlazorLocal.Pages.Kunde
{
    public class EditDialogKundeViewModel
    {
        public bool DialogIsOpen { get; set; }       
        public KundeItemViewModel Model { get; set; }
    }
}
