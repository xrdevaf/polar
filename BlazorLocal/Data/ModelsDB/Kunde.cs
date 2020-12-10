using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace BlazorLocal.Data.ModelsDB
{
    [Table("Kunde")]
    public class Kunde : ICloneable
    {

        [Key]
        [Column("KundeId")]
        public int KundeId { get; set; }

        public string KundeName { get; set; }
        public string KundeNR { get; set; }

        public string ConfigurationJson { get; set; }

        public object Clone()
        {
            Kunde tempObject = (Kunde)this.MemberwiseClone();
            return tempObject;
        }
    }
}