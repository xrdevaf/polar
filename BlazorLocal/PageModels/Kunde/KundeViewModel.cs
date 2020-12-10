using BlazorLocal.Data.Models;
using BlazorLocal.Data.ModelsDB;
using System;
using System.ComponentModel.DataAnnotations;
using System.Text.Json;

namespace BlazorLocal.PageModels
{
    public class KundeItemViewModel : ICloneable
    {
        private Kunde _item;

        public KundeItemViewModel()
        {
            _item = new Kunde();
            ConfModel =  new ConfigurationModel();
        }

        public KundeItemViewModel(Kunde model)
        {
            _item = model;
            ConfModel = string.IsNullOrEmpty(_item.ConfigurationJson) ? new ConfigurationModel() : JsonSerializer.Deserialize<ConfigurationModel>(_item.ConfigurationJson);
        }

        public Kunde Item => _item;

        public ConfigurationModel ConfModel { get; set; }     


        [Required]
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
        public string KundeName
        {
            get
            {
                return _item.KundeName;
            }
            set
            {
                _item.KundeName = value;
            }
        }

        [StringLength(500)]
        public string KundeNR
        {
            get
            {
                return _item.KundeNR;
            }
            set
            {
                _item.KundeNR = value;
            }
        }

        public string ConfigurationJson
        {
            get
            {
                return _item.ConfigurationJson;
            }
            set
            {
                _item.ConfigurationJson = value;
            }
        }

        public object Clone()
        {
            KundeItemViewModel tempObject = (KundeItemViewModel)this.MemberwiseClone();
            tempObject._item = (Kunde)_item.Clone();
            return tempObject;
        }
    }
}