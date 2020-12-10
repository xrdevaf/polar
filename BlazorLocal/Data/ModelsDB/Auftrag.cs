using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace BlazorLocal.Data.ModelsDB
{
    [Table("Auftrag")]
    public class Auftrag : ICloneable
    {

        [Key]
        [Column("AuftragId")]
        public int AuftragId { get; set; }
        public int KundeId { get; set; }
        public string Laufnummer { get; set; }
        public string OrdernummerVINshort { get; set; }
        public string Haendlernummer { get; set; }
        public string HaendlerName { get; set; }
        public string Lieferort { get; set; }
        public string LieferortAnsprechpartner { get; set; }
        public string Baureihe { get; set; }
        public string Fahrzeugtyp { get; set; }
        public string Fahrzeugstatus { get; set; }


        public object Clone()
        {
            Auftrag tempObject = (Auftrag)this.MemberwiseClone();
            return tempObject;
        }
    }
}