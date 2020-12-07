using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace DbConnector.ModelsDB
{
    public class DataSheet : ICloneable
    {
        public DataSheet()
        {
            
        }

        public DataSheet(MySqlDataReader reader)
        {
            id = int.Parse(reader[0].ToString());
            ordernumber = int.Parse(reader[1].ToString());
            ordertime = DateTime.Parse(reader[2].ToString());
            articleid = int.Parse(reader[3].ToString());
            articleordernumber = reader[4].ToString();
        }
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
