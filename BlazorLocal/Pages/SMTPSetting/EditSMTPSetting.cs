using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BlazorLocal.PageModels;

namespace BlazorLocal.Pages.SMTPSetting
{
    public class EditDialogSMTPSettingViewModel
    {
        public bool DialogIsOpen { get; set; }       
        public SMTPSettingItemViewModel Model { get; set; }
    }
}
