using DbConnector.ModelsDB;
using MySql.Data.MySqlClient;
using NLog;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DbConnector
{
    public class DbContext
    {
        MySqlConnection connection;
        static Logger Logger = LogManager.GetCurrentClassLogger();
        public string ConnectionError { get; set; } = string.Empty;

        public DbContext(string ConnectionString)
        {
            try
            {
                connection = new MySqlConnection(ConnectionString);
                connection.Open();

            }
            catch (Exception ex)
            {
                ConnectionError = "Database:" + "Unable to open database connection.";
                Console.WriteLine(ConnectionError);
                Logger.Error("Database:" + ex.Message);
            }

        }

        //public async Task<List<DataSheet>> GetRuleForDeliveryList()
        public List<DataSheet> Get()
        {
            try
            {
                List<DataSheet> list = new List<DataSheet>();
                string sql = "SELECT " +
                "a.id, a.ordernumber, a.ordertime, b.articleID, b.articleordernumber " +
                "FROM s_order as a " +
                "join s_order_details as b on a.id = b.orderID " +
                "where b.articleID != 0 " +
                "and a.id not in (" +
                "SELECT distinct a.id FROM s_order as a " +
                "join s_order_details as b on a.id = b.orderID " +
                "join magnalister_orders as c on a.id = c.orders_id " +
                "where b.articleID != 0);";
                MySqlCommand command = new MySqlCommand(sql, connection);
                MySqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    list.Add(new DataSheet()
                    {
                        id = int.Parse(reader[0].ToString()),
                        ordernumber = int.Parse(reader[1].ToString()),
                        ordertime = DateTime.Parse(reader[2].ToString()),
                        articleid = int.Parse(reader[3].ToString()),
                        articleordernumber = reader[4].ToString(),
                    });
                }
                reader.Close();
                CloseConnection();
                return list;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Database: Unable to retrieve records () from the database.");
                Logger.Error("Database:" + ex.Message);
                CloseConnection();
                return null;
            }
        }
        public List<StatSheet> GetStats()
        {
            try
            {
                List<StatSheet> list = new List<StatSheet>();
                string sql = "SELECT " +
                "count(distinct a.ordernumber) " +
                "FROM s_order as a " +
                "join s_order_details as b on a.id = b.orderID " +
                "where b.articleID != 0 " +
                "and a.id not in (" +
                "SELECT distinct a.id FROM s_order as a " +
                "join s_order_details as b on a.id = b.orderID " +
                "join magnalister_orders as c on a.id = c.orders_id " +
                "where b.articleID != 0);";
                int sworders = 0;
                int allorders = 0;
                int soldproducts = 0;
                int soldproductssw = 0;
                int mangalisterorders = 0;
                int soldproductsmangalister = 0;
                MySqlCommand command = new MySqlCommand(sql, connection);
                MySqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    sworders = int.Parse(reader[0].ToString());
                }
                reader.Close();
                sql = "SELECT " +
               "count(distinct a.ordernumber) " +
               "FROM s_order as a " +
               "join s_order_details as b on a.id = b.orderID " +
               "where b.articleID != 0 ";
                command = new MySqlCommand(sql, connection);
                reader = command.ExecuteReader();
                while (reader.Read())
                {
                    allorders = int.Parse(reader[0].ToString());
                }
                reader.Close();
                sql = "SELECT " +
              "count(b.articleID) " +
              "FROM s_order as a " +
              "join s_order_details as b on a.id = b.orderID " +
              "where b.articleID != 0 ";
                command = new MySqlCommand(sql, connection);
                reader = command.ExecuteReader();
                while (reader.Read())
                {
                    soldproducts = int.Parse(reader[0].ToString());
                }
                reader.Close();
                     sql = "SELECT " +
              "count(b.articleID) " +
              "FROM s_order as a " +
              "join s_order_details as b on a.id = b.orderID " +
              "where b.articleID != 0 " +
              "and a.id not in (" +
                "SELECT distinct a.id FROM s_order as a " +
                "join s_order_details as b on a.id = b.orderID " +
                "join magnalister_orders as c on a.id = c.orders_id " +
                "where b.articleID != 0);";
                command = new MySqlCommand(sql, connection);
                reader = command.ExecuteReader();
                while (reader.Read())
                {
                    soldproductssw = int.Parse(reader[0].ToString());
                }
                reader.Close();
                sql = "SELECT " +
              "count(distinct a.ordernumber) " +
              "FROM s_order as a " +
              "join s_order_details as b on a.id = b.orderID " +
              "join magnalister_orders as c on a.id = c.orders_id " +
              "where b.articleID != 0";
                command = new MySqlCommand(sql, connection);
                reader = command.ExecuteReader();
                while (reader.Read())
                {
                    mangalisterorders = int.Parse(reader[0].ToString());
                }
                reader.Close();
                sql = "SELECT " +
              "count(b.articleID) " +
              "FROM s_order as a " +
              "join s_order_details as b on a.id = b.orderID " +
              "join magnalister_orders as c on a.id = c.orders_id " +
              "where b.articleID != 0";
                command = new MySqlCommand(sql, connection);
                reader = command.ExecuteReader();
                while (reader.Read())
                {
                    soldproductsmangalister = int.Parse(reader[0].ToString());
                }
                reader.Close();
                list.Add(new StatSheet()
                {
                    sworders = sworders,
                    allorders = allorders,
                    soldproducts = soldproducts,
                    soldproductssw = soldproductssw,
                    mangalisterorders = mangalisterorders,
                    soldproductsmangalister = soldproductsmangalister
                });
                CloseConnection();
                return list;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Database: Unable to retrieve records () from the database.");
                Logger.Error("Database:" + ex.Message);
                CloseConnection();
                return null;
            }
        }

        public void CloseConnection()
        {
            connection.Close();
        }

    }
}
