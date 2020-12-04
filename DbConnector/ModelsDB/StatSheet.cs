using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DbConnector.ModelsDB
{
    public class StatSheet : ICloneable
    {
        public int sworders { get; set; }
        public int allorders { get; set; }
        public int soldproducts { get; set; }
        public int soldproductssw { get; set; }
        public int mangalisterorders { get; set; }
        public int soldproductsmangalister { get; set; }
        public object Clone()
        {
            DataSheet tempObject = (DataSheet)this.MemberwiseClone();
            return tempObject;
        }
    }
}
