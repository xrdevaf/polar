using BlazorLocal.Data.Models;
using BlazorLocal.Data.ModelsDB;
using System;
using System.ComponentModel.DataAnnotations;
using System.Text.Json;

namespace BlazorLocal.PageModels
{
    public class AuftragItemViewModel : ICloneable
    {
        private Auftrag _item;

        public AuftragItemViewModel()
        {
            _item = new Auftrag();
            InitDefaultConfiguration();
        }

        public AuftragItemViewModel(Auftrag model)
        {
            _item = model;
            InitDefaultConfiguration();
        }

        private void InitDefaultConfiguration()
        {
            Configuration = new ConfigurationModel()
            {
                IsHaendlerName = true,
                IsHaendlernummer = true,
                IsLieferort = true,
                IsLieferortAnsprechpartner = true,
                IsOrdernummerVINshort = true
            };
        }

        public Auftrag Item => _item;
        public Kunde KundeItem { get; set; }
        public string KundeName => KundeItem?.KundeName;

        public ConfigurationModel Configuration { get; set; }

        /*public List<ChangeLog> ChangeLog
        {
            get
            {
                return string.IsNullOrEmpty(_item.ChangeLogJson) ? new List<ChangeLog>() : JsonConvert.DeserializeObject<List<ChangeLog>>(_item.ChangeLogJson);
            }
        }
        */
        [Required]
        public int AuftragId
        {
            get
            {
                return _item.AuftragId;
            }
            set
            {
                _item.AuftragId = value;
            }
        }

        [Required]
        [Range(1, 1000)]
        public int KundeId
        {
            get
            {
                return _item.KundeId;
            }
            set
            {
                _item.KundeId = value;
            }
        }
        [StringLength(500)]
        public string Laufnummer
        {
            get
            {
                return _item.Laufnummer;
            }
            set
            {
                _item.Laufnummer = value;
            }
        }
        [StringLength(500)]
        public string OrdernummerVINshort
        {
            get
            {
                return _item.OrdernummerVINshort;
            }
            set
            {
                _item.OrdernummerVINshort = value;
            }
        }
        [StringLength(500)]
        public string Haendlernummer
        {
            get
            {
                return _item.Haendlernummer;
            }
            set
            {
                _item.Haendlernummer = value;
            }
        }
        [StringLength(500)]
        public string HaendlerName
        {
            get
            {
                return _item.HaendlerName;
            }
            set
            {
                _item.HaendlerName = value;
            }
        }
        [StringLength(500)]
        public string Lieferort
        {
            get
            {
                return _item.Lieferort;
            }
            set
            {
                _item.Lieferort = value;
            }
        }
        [StringLength(500)]
        public string LieferortAnsprechpartner
        {
            get
            {
                return _item.LieferortAnsprechpartner;
            }
            set
            {
                _item.LieferortAnsprechpartner = value;
            }
        }
        [StringLength(500)]
        public string Baureihe
        {
            get
            {
                return _item.Baureihe;
            }
            set
            {
                _item.Baureihe = value;
            }
        }
        [StringLength(500)]
        public string Fahrzeugtyp
        {
            get
            {
                return _item.Fahrzeugtyp;
            }
            set
            {
                _item.Fahrzeugtyp = value;
            }
        }

        [StringLength(500)]
        public string Fahrzeugstatus
        {
            get
            {
                return _item.Fahrzeugstatus;
            }
            set
            {
                _item.Fahrzeugstatus = value;
            }
        }


        public object Clone()
        {
            AuftragItemViewModel tempObject = (AuftragItemViewModel)this.MemberwiseClone();
            tempObject._item = (Auftrag)_item.Clone();
            return tempObject;
        }
    }
}