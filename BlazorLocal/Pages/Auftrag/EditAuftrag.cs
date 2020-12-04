using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BlazorLocal.PageModels;

namespace BlazorLocal.Pages.Auftrag
{
    public class EditDialogAuftragViewModel
    {
        public bool DialogIsOpen { get; set; }       
        public AuftragItemViewModel Model { get; set; }
    }
}
