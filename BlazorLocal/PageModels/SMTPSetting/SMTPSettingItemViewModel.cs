using BlazorLocal.Data.ModelsDB;
using System;
using System.ComponentModel.DataAnnotations;

namespace BlazorLocal.PageModels
{
    public class SMTPSettingItemViewModel : ICloneable
    {
        private SMTPSetting _item;

        public SMTPSettingItemViewModel()
        {
            _item = new SMTPSetting();
        }

        public SMTPSettingItemViewModel(SMTPSetting model)
        {
            _item = model;
        }

        public SMTPSetting Item => _item;

        [Required]
        public int SMTPSettingId
        {
            get
            {
                return _item.SMTPSettingId;
            }
            set
            {
                _item.SMTPSettingId = value;
            }
        }

        [StringLength(100)]
        [Required]
        public string SMTPUsername
        {
            get
            {
                return _item.SMTPUsername;
            }
            set
            {
                _item.SMTPUsername = value;
            }
        }

        [StringLength(100)]
        [Required]
        public string SMTPPassword
        {
            get
            {
                return _item.SMTPPassword;
            }
            set
            {
                _item.SMTPPassword = value;
            }
        }

        [StringLength(100)]
        [Required]
        public string SMTPServer
        {
            get
            {
                return _item.SMTPServer;
            }
            set
            {
                _item.SMTPServer = value;
            }
        }

        [Required]
        public int SMTPPort
        {
            get
            {
                return _item.SMTPPort;
            }
            set
            {
                _item.SMTPPort = value;
            }
        }

        [Required]
        public bool EnableSSL
        {
            get
            {
                return _item.EnableSSL;
            }
            set
            {
                _item.EnableSSL = value;
            }
        }

        [Required]
        public bool IsActive
        {
            get
            {
                return _item.IsActive;
            }
            set
            {
                _item.IsActive = value;
            }
        }

        public object Clone()
        {
            SMTPSettingItemViewModel tempObject = (SMTPSettingItemViewModel)this.MemberwiseClone();
            tempObject._item = (SMTPSetting)_item.Clone();
            return tempObject;
        }
    }
}