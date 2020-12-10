using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BlazorLocal.Data.ModelsDB
{
    [Table("LogApplicationError")]
    public class LogApplicationError:IDisposable
    {
        [Key]
        public int LogApplicationErrorId { get; set; }
        public string ErrorContext { get; set; }
        public  string ErrorMsg { get; set; }
        public DateTime InsertDate { get; set; }
        public string UserData { get; set; }
        public int? ErrorLevel { get; set; }

        public void Dispose()
        {
            this.Dispose();
        }
    }
}
