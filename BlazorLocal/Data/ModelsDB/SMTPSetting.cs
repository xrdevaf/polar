using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace BlazorLocal.Data.ModelsDB
{
    [Table("SMTPSetting")]
    public class SMTPSetting : ICloneable
    {

        [Key]
        [Column("SMTPSettingId")]
        public int SMTPSettingId { get; set; }

        public string SMTPUsername { get; set; }
        public string SMTPPassword { get; set; }
        public string SMTPServer { get; set; }
        public int SMTPPort { get; set; }
        public bool EnableSSL { get; set; }
        public bool IsActive { get; set; }


        public object Clone()
        {
            SMTPSetting tempObject = (SMTPSetting)this.MemberwiseClone();
            return tempObject;
        }
    }
}