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
        public StatSheet GetStats(int year, int month)
        {
            try
            {
                StatSheet list = new StatSheet();
                list = new StatSheet()
                {
                    year = year,
                    month = month,
                    sworders = GetStatsZero(year, month),
                    allorders = GetStatsOne(year, month),
                    soldproducts = GetStatsTwo(year, month),
                    soldproductssw = GetStatsThree(year, month),
                    mangalisterorders = GetStatsFour(year, month),
                    soldproductsmangalister = GetStatsFive(year, month)
                };
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
        int GetStatsZero(int year, int month)
        {
            string sql = @"SELECT count(distinct a.ordernumber)
                FROM s_order as a join s_order_details as b on a.id = b.orderID where b.articleID != 0 and a.id not in
                (SELECT distinct aa.id FROM s_order as aa join s_order_details as bb on aa.id = bb.orderID
                join magnalister_orders as cc on aa.id = cc.orders_id where bb.articleID != 0) " 
                + "and year(a.ordertime) = " + year.ToString() + " and month(a.ordertime) = " + month.ToString() +
                " group by year(a.ordertime),month(a.ordertime);";
            MySqlCommand command = new MySqlCommand(sql, connection);
            MySqlDataReader reader = command.ExecuteReader();
            int result = 0;
            while (reader.Read())
            {
                result = int.Parse(reader[0].ToString());
            }
            reader.Close();
            return result;
        }
        int GetStatsOne(int year, int month)
        { 
            string sql = "SELECT " +
                "count(distinct a.ordernumber) " +
                "FROM s_order as a " +
                "join s_order_details as b on a.id = b.orderID " +
                "where b.articleID != 0 " +
                "and year(a.ordertime) = " + year.ToString() + " and month(a.ordertime) = " + month.ToString() +
                " group by year(a.ordertime),month(a.ordertime);";
            MySqlCommand command = new MySqlCommand(sql, connection);
            MySqlDataReader reader = command.ExecuteReader();
            int result = 0;
            while (reader.Read())
            {
                result = int.Parse(reader[0].ToString());
            }
            reader.Close();
            return result;
        }
        int GetStatsTwo(int year, int month)
        {
            string sql = "SELECT " +
           "count(b.articleID) " +
           "FROM s_order as a " +
           "join s_order_details as b on a.id = b.orderID " +
           "where b.articleID != 0 " +
           "and year(a.ordertime) = " + year.ToString() + " and month(a.ordertime) = " + month.ToString() +
                " group by year(a.ordertime),month(a.ordertime);";
            MySqlCommand command = new MySqlCommand(sql, connection);
            MySqlDataReader reader = command.ExecuteReader();
            int result = 0;
            while (reader.Read())
            {
                result = int.Parse(reader[0].ToString());
            }
            reader.Close();
            return result;
        }
        int GetStatsThree(int year, int month)
        {
            string sql = "SELECT " +
         "count(b.articleID) " +
         "FROM s_order as a " +
         "join s_order_details as b on a.id = b.orderID " +
         "where b.articleID != 0 " +
         "and a.id not in (" +
           "SELECT distinct a.id FROM s_order as a " +
           "join s_order_details as b on a.id = b.orderID " +
           "join magnalister_orders as c on a.id = c.orders_id " +
           "where b.articleID != 0) " +
           "and year(a.ordertime) = " + year.ToString() + " and month(a.ordertime) = " + month.ToString() +
                " group by year(a.ordertime),month(a.ordertime);";
            MySqlCommand command = new MySqlCommand(sql, connection);
            MySqlDataReader reader = command.ExecuteReader();
            int result = 0;
            while (reader.Read())
                {
                result = int.Parse(reader[0].ToString());
                }
                reader.Close();
            return result;
        }
        int GetStatsFour(int year, int month)
        {
            string sql = "SELECT " +
            "count(distinct a.ordernumber) " +
            "FROM s_order as a " +
            "join s_order_details as b on a.id = b.orderID " +
            "join magnalister_orders as c on a.id = c.orders_id " +
            "where b.articleID != 0 " +
            "and year(a.ordertime) = " + year.ToString() + " and month(a.ordertime) = " + month.ToString() +
                " group by year(a.ordertime),month(a.ordertime);";
            MySqlCommand command = new MySqlCommand(sql, connection);
            MySqlDataReader reader = command.ExecuteReader();
            int result = 0;
            while (reader.Read())
            {
                result = int.Parse(reader[0].ToString());
            }
            reader.Close();
            return result;
        }
        int GetStatsFive(int year, int month)
        {
            string sql = "SELECT " +
             "count(b.articleID) " +
             "FROM s_order as a " +
             "join s_order_details as b on a.id = b.orderID " +
             "join magnalister_orders as c on a.id = c.orders_id " +
             "where b.articleID != 0 " +
             "and year(a.ordertime) = " + year.ToString() + " and month(a.ordertime) = " + month.ToString() +
                " group by year(a.ordertime),month(a.ordertime);";
            MySqlCommand command = new MySqlCommand(sql, connection);
            MySqlDataReader reader = command.ExecuteReader();
            int result = 0;
            while (reader.Read())
            {
                result = int.Parse(reader[0].ToString());
            }
            reader.Close();
            return result;
        }

        public void CloseConnection()
        {
            connection.Close();
        }

    }
}
