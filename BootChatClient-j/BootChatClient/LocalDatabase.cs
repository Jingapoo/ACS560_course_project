using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SQLite;
using System.Diagnostics;

namespace BootChatClient
{
    public class LocalDatabase
    {
        private SQLiteConnection connection;

        public LocalDatabase()
        {
            connection = new SQLiteConnection("Data Source=bootchat-local.db;Version=3;");
            connection.Open();
        }

        public void close()
        {
            try
            {
                if (connection != null)
                {
                    connection.Close();
                }
            }
            catch (Exception e) { }
        }

        public String getValue(String key)
        {
            try{
                String sql = String.Format("SELECT value FROM preferences WHERE key = '{0}'", key);
                SQLiteCommand stmt = new SQLiteCommand(sql, this.connection);
                SQLiteDataReader row = stmt.ExecuteReader();

                row.Read();
                Object value = row["value"];
                row.Close();

                if(value == null){
                    return null;
                }

                return Convert.ToString(value);
            }catch(Exception e){
                Debug.WriteLine("GetValue: " + e.Message);
            }
            return null;
        }

        public Boolean insertValue(String key, String value)
        {
            try{
                String sql = String.Format("INSERT INTO preferences(key,value) VALUES('{0}','{1}');", key, value);
                SQLiteCommand stmt = new SQLiteCommand(sql, this.connection);
                return stmt.ExecuteNonQuery() > 0;
            }catch(Exception e){
                Debug.WriteLine("Insert Value: " + e.Message);
            }
            return false;
        }

        public Boolean updateValue(String key, String value)
        {
            try{
                String sql = String.Format("UPDATE preferences SET value = '{0}' WHERE key = '{1}';", value, key);
                SQLiteCommand stmt = new SQLiteCommand(sql, this.connection);
                return stmt.ExecuteNonQuery() > 0;
            }catch (Exception e){
                Debug.WriteLine("updateValue: " + e.Message);
            }
            return false;
        }

        public Boolean keyExists(String key)
        {
            try
            {
                String sql = String.Format("SELECT EXISTS(SELECT * FROM preferences WHERE key = '{0}') AS `exists`;", key);
                SQLiteCommand stmt = new SQLiteCommand(sql, this.connection);
                SQLiteDataReader row = stmt.ExecuteReader();

                row.Read();

                Boolean exists = Convert.ToBoolean(row["exists"]);
                row.Close();

                return exists;
            }
            catch (Exception e)
            {
                Debug.WriteLine("keyExists: " + e.Message);
            }
            return false;
        }

        public Boolean unsetValue(String key)
        {
            try
            {
                String sql = String.Format("DELETE FROM preferences WHERE key = '{0}';", key);
                SQLiteCommand stmt = new SQLiteCommand(sql, this.connection);
                int result = stmt.ExecuteNonQuery();       
                return  result > 0;
            }
            catch (Exception e)
            {
                Debug.WriteLine("unsetValue: " + e.Message);
            }
            return false;
        }

        public Boolean nullOutValue(String key)
        {
            try{
                String sql = String.Format("UPDATE preferences SET value = NULL WHERE key = '{0}';", key);
                SQLiteCommand stmt = new SQLiteCommand(sql, this.connection);
                return stmt.ExecuteNonQuery() > 0;
            }catch (Exception e){
                Debug.WriteLine("nullOutValue: " + e.Message);
            }
            return false;
        }
    }
}
