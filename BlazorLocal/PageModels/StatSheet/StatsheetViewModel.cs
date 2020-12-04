﻿using System;
using System.ComponentModel.DataAnnotations;
using DbConnector.ModelsDB;

namespace BlazorLocal.PageModels
{
	public class StatSheetItemViewModel : ICloneable
	{
		private StatSheet _item;

		public StatSheetItemViewModel()
		{
			_item = new StatSheet();
		}

		public StatSheetItemViewModel(StatSheet model)
		{
			_item = model;
		}

		public StatSheet Item => _item;

		/*public List<ChangeLog> ChangeLog
        {
            get
            {
                return string.IsNullOrEmpty(_item.ChangeLogJson) ? new List<ChangeLog>() : JsonConvert.DeserializeObject<List<ChangeLog>>(_item.ChangeLogJson);
            }
        }
		*/
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
			StatSheetItemViewModel tempObject = (StatSheetItemViewModel)this.MemberwiseClone();
			tempObject._item = (StatSheet)_item.Clone();
			return tempObject;
		}
	}
}