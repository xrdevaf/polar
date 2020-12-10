using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BlazorLocal.PageModels;

namespace BlazorLocal.Pages.AspNetUsers
{
    public class EditDialogAspNetUsersViewModel
    {
        public bool DialogIsOpen { get; set; }       
        public AspNetUsersItemViewModel Model { get; set; }
    }
}
