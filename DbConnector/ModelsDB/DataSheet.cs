using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DbConnector.ModelsDB
{
    public class DataSheet : ICloneable
    {
        public int id { get; set; }
        public int ordernumber { get; set; }
        public DateTime ordertime { get; set; }
        public int articleid { get; set; }
        public string articleordernumber { get; set; }
        public object Clone()
        {
            DataSheet tempObject = (DataSheet)this.MemberwiseClone();
            return tempObject;
        }
    }
}
