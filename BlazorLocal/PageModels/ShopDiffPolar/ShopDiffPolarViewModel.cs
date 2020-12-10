using System;
using System.ComponentModel.DataAnnotations;
using DbConnector.ModelsDB;

namespace BlazorLocal.PageModels
{
    public class ShopDiffPolarItemViewModel : ICloneable
    {
        private ShopDiffPolar _item;

        public ShopDiffPolarItemViewModel()
        {
            _item = new ShopDiffPolar();
        }

        public ShopDiffPolarItemViewModel(ShopDiffPolar model)
        {
            _item = model;
        }

        public ShopDiffPolar Item => _item;

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
        public int sworders
        {
            get
            {
                return _item.sworders;
            }
            set
            {
                _item.sworders = value;
            }
        }
        public int allorders
        {
            get
            {
                return _item.allorders;
            }
            set
            {
                _item.allorders = value;
            }
        }
        public int soldproducts
        {
            get
            {
                return _item.soldproducts;
            }
            set
            {
                _item.soldproducts = value;
            }
        }
        public int soldproductssw
        {
            get
            {
                return _item.soldproductssw;
            }
            set
            {
                _item.soldproductssw = value;
            }
        }
        public int mangalisterorders
        {
            get
            {
                return _item.mangalisterorders;
            }
            set
            {
                _item.mangalisterorders = value;
            }
        }
        public int soldproductsmangalister
        {
            get
            {
                return _item.soldproductsmangalister;
            }
            set
            {
                _item.soldproductsmangalister = value;
            }
        }
        public object Clone()
        {
            ShopDiffPolarItemViewModel tempObject = (ShopDiffPolarItemViewModel)this.MemberwiseClone();
            tempObject._item = (ShopDiffPolar)_item.Clone();
            return tempObject;
        }
    }
}