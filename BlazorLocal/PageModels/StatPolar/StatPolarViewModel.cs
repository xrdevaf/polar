using System;
using System.ComponentModel.DataAnnotations;
using DbConnector.ModelsDB;

namespace BlazorLocal.PageModels
{
    public class StatPolarItemViewModel : ICloneable
    {
        private StatPolar _item;

        public StatPolarItemViewModel()
        {
            _item = new StatPolar();
        }

        public StatPolarItemViewModel(StatPolar model)
        {
            _item = model;
        }

        public StatPolar Item => _item;

        /*public List<ChangeLog> ChangeLog
        {
            get
            {
                return string.IsNullOrEmpty(_item.ChangeLogJson) ? new List<ChangeLog>() : JsonConvert.DeserializeObject<List<ChangeLog>>(_item.ChangeLogJson);
            }
        }
		*/
        public int year
        {
            get
            {
                return _item.year;
            }
            set
            {
                _item.year = value;
            }
        }
        public int month
        {
            get
            {
                return _item.month;
            }
            set
            {
                _item.month = value;
            }
        }
        public int shopware
        {
            get
            {
                return _item.shopware;
            }
            set
            {
                _item.shopware = value;
            }
        }
        public float percentage
        {
            get
            {
                return _item.percentage;
            }
            set
            {
                _item.percentage = value;
            }
        }
        public object Clone()
        {
            StatPolarItemViewModel tempObject = (StatPolarItemViewModel)this.MemberwiseClone();
            tempObject._item = (StatPolar)_item.Clone();
            return tempObject;
        }
    }
}