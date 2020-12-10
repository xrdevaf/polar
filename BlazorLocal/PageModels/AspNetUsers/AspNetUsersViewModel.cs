using Microsoft.AspNetCore.Identity;
using System;
using System.ComponentModel.DataAnnotations;
using MatBlazor;

namespace BlazorLocal.PageModels
{
    public class AspNetUsersItemViewModel : ICloneable
    {
        private IdentityUser _item;

        public AspNetUsersItemViewModel()
        {
            _item = new IdentityUser();
        }

        public AspNetUsersItemViewModel(IdentityUser model)
        {
            _item = model;
        }

        public IdentityUser Item => _item;       

        public string RoleName { get; set; }       

        /*public List<ChangeLog> ChangeLog
        {
            get
            {
                return string.IsNullOrEmpty(_item.ChangeLogJson) ? new List<ChangeLog>() : JsonConvert.DeserializeObject<List<ChangeLog>>(_item.ChangeLogJson);
            }
        }
		*/
        [StringLength(450)]
        //[Required]
        public string AspNetUsersId
        {
            get
            {
                return _item.Id;
            }
            set
            {
                _item.Id = value;
            }
        }
        [StringLength(256)]
        public string UserName
        {
            get
            {
                return _item.UserName;
            }
            set
            {
                _item.UserName = value;
            }
        }
        [StringLength(256)]
        public string NormalizedUserName
        {
            get
            {
                return _item.NormalizedUserName;
            }
            set
            {
                _item.NormalizedUserName = value;
            }
        }
        [Required]
        [StringLength(256)]
        public string Email
        {
            get
            {
                return _item.Email;
            }
            set
            {
                _item.Email = value;
            }
        }
        [StringLength(256)]
        public string NormalizedEmail
        {
            get
            {
                return _item.NormalizedEmail;
            }
            set
            {
                _item.NormalizedEmail = value;
            }
        }
        [Required]
        public bool EmailConfirmed
        {
            get
            {
                return _item.EmailConfirmed;
            }
            set
            {
                _item.EmailConfirmed = value;
            }
        }
        public string PasswordHash
        {
            get
            {
                return _item.PasswordHash;
            }
            set
            {
                _item.PasswordHash = value;
            }
        }
        [Required]
        [StringLength(maximumLength: 255, MinimumLength = 6)]
        public string Password { get; set; }
        public string SecurityStamp
        {
            get
            {
                return _item.SecurityStamp;
            }
            set
            {
                _item.SecurityStamp = value;
            }
        }
        public string ConcurrencyStamp
        {
            get
            {
                return _item.ConcurrencyStamp;
            }
            set
            {
                _item.ConcurrencyStamp = value;
            }
        }
        public string PhoneNumber
        {
            get
            {
                return _item.PhoneNumber;
            }
            set
            {
                _item.PhoneNumber = value;
            }
        }
        [Required]
        public bool PhoneNumberConfirmed
        {
            get
            {
                return _item.PhoneNumberConfirmed;
            }
            set
            {
                _item.PhoneNumberConfirmed = value;
            }
        }
        [Required]
        public bool TwoFactorEnabled
        {
            get
            {
                return _item.TwoFactorEnabled;
            }
            set
            {
                _item.TwoFactorEnabled = value;
            }
        }
        public DateTimeOffset? LockoutEnd
        {
            get
            {
                return _item.LockoutEnd;
            }
            set
            {
                _item.LockoutEnd = value;
            }
        }
        [Required]
        public bool LockoutEnabled
        {
            get
            {
                return _item.LockoutEnabled;
            }
            set
            {
                _item.LockoutEnabled = value;
            }
        }
        [Required]
        public int AccessFailedCount
        {
            get
            {
                return _item.AccessFailedCount;
            }
            set
            {
                _item.AccessFailedCount = value;
            }
        }      

        public object Clone()
        {
            AspNetUsersItemViewModel tempObject = (AspNetUsersItemViewModel)this.MemberwiseClone();
            tempObject._item = _item;
            return tempObject;
        }
    }
}