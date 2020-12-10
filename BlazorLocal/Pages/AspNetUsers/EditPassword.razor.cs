using System;
using System.ComponentModel.DataAnnotations;
using BlazorLocal.PageModels;

namespace BlazorLocal.Pages.AspNetUsers
{
    public class EditPasswordViewModel
    {
        public bool DialogIsOpen { get; set; } = false;
        public AspNetUsersItemViewModel User { get; set; }
        public PasswordModel Password { get; set; }
        public string ErrorMessage { get; set; }
    }
    public class PasswordModel : ICloneable
    {
        [Required]
        [StringLength(maximumLength: 40, MinimumLength = 6)]
        public string OldPassword { get; set; }
        [Required]
        [StringLength(maximumLength: 40, MinimumLength = 6)]
        public string NewPassword { get; set; }

        public object Clone()
        {
            PasswordModel tempObject = (PasswordModel)this.MemberwiseClone();
            return tempObject;
        }
    }
}
