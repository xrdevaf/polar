using System;
using System.ComponentModel.DataAnnotations;
using DbConnector.ModelsDB;

namespace BlazorLocal.PageModels
{
	public class DataSheetItemViewModel : ICloneable
	{
		private DataSheet _item;

		public DataSheetItemViewModel()
		{
			_item = new DataSheet();
		}

		public DataSheetItemViewModel(DataSheet model)
		{
			_item = model;
		}

		public DataSheet Item => _item;

		/*public List<ChangeLog> ChangeLog
        {
            get
            {
                return string.IsNullOrEmpty(_item.ChangeLogJson) ? new List<ChangeLog>() : JsonConvert.DeserializeObject<List<ChangeLog>>(_item.ChangeLogJson);
            }
        }
		*/
		public int id
		{
			get
			{
				return _item.id;
			}
			set
			{
				_item.id = value;
			}
		}
		public int ordernumber
		{
			get
			{
				return _item.ordernumber;
			}
			set
			{
				_item.ordernumber = value;
			}
		}
		public DateTime ordertime
		{
			get
			{
				return _item.ordertime;
			}
			set
			{
				_item.ordertime = value;
			}
		}
		public int articleid
		{
			get
			{
				return _item.articleid;
			}
			set
			{
				_item.articleid = value;
			}
		}
		public string articleordernumber
		{
			get
			{
				return _item.articleordernumber;
			}
			set
			{
				_item.articleordernumber = value;
			}
		}
		public object Clone()
		{
			DataSheetItemViewModel tempObject = (DataSheetItemViewModel)this.MemberwiseClone();
			tempObject._item = (DataSheet)_item.Clone();
			return tempObject;
		}
	}
}