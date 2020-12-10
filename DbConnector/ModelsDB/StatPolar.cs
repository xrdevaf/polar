using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DbConnector.ModelsDB
{
    public class StatPolar
    {
        public int month { get; set; }
        public int year { get; set; }
        public int shopware { get; set; }
        public float percentage { get; set; } = 0;
        public object Clone()
        {
            DataSheet tempObject = (DataSheet)this.MemberwiseClone();
            return tempObject;
        }
    }
}
