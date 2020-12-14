using DbConnector.ModelsDB;
using MySql.Data.MySqlClient;
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
        public string ConnectionError { get; set; } = string.Empty;

        public DbContext(string ConnectionString)
        {
            connection = new MySqlConnection(ConnectionString);
            connection.Open();
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
                    list.Add(new DataSheet(reader));
                }
                reader.Close();
                CloseConnection();
                return list;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Database: Unable to retrieve records () from the database.");
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
                    sworders = GetSwOrders(year, month),
                    allorders = GetAllOrders(year, month),
                    soldproducts = GetSoldProducts(year, month),
                    soldproductssw = GetSoldProductsSw(year, month),
                    mangalisterorders = GetMangalisterOrders(year, month),
                    soldproductsmangalister = GetSoldProductsMangalister(year, month)
                };
                CloseConnection();
                return list;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Database: Unable to retrieve records () from the database.");
                CloseConnection();
                return null;
            }
        }
        public StatPolar GetStatPolar(int year, int month)
        {
            try
            {
                StatPolar list = new StatPolar()
                {
                    year = year,
                    month = month
                };
                string sql = "SELECT " +
                "count(distinct a.ordernumber) " +
                "FROM s_order as a " +
                "join s_order_details as b on a.id = b.orderID " +
                "where b.articleID != 0 " +
                "and a.id not in (" +
                "SELECT distinct a.id FROM s_order as a " +
                "join s_order_details as b on a.id = b.orderID " +
                "join magnalister_orders as c on a.id = c.orders_id " +
                "where b.articleID != 0 " + "and year(a.ordertime) = " + year.ToString() + " and month(a.ordertime) = " + month.ToString() +
                ")" + " and year(a.ordertime) = " + year.ToString() + " and month(a.ordertime) = " + month.ToString() +
                " group by year(a.ordertime),month(a.ordertime);";
                MySqlCommand command = new MySqlCommand(sql, connection);
                MySqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    list.shopware = int.Parse(reader[0].ToString());
                }
                reader.Close();
                CloseConnection();
                return list;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Database: Unable to retrieve records () from the database.");
                CloseConnection();
                return null;
            }
        }
        int GetSwOrders(int year, int month)
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

        int GetAllOrders(int year, int month)
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

        int GetSoldProducts(int year, int month)
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
        int GetSoldProductsSw(int year, int month)
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
        int GetMangalisterOrders(int year, int month)
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
        int GetSoldProductsMangalister(int year, int month)
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
