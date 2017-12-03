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
            if (!System.IO.File.Exists("bootchat-local.db"))
            {
                System.IO.File.WriteAllBytes("bootchat-local.db", BootChatClient.Properties.Resources.bootchat_local);
            }

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

        public List<String> getFriendsList(String username)
        {
            List<String> list = new List<String>();

            String query = String.Format("SELECT username FROM friends WHERE login_username = '{0}'", username);
            SQLiteCommand stmt = new SQLiteCommand(query, this.connection);
            SQLiteDataReader row = stmt.ExecuteReader();

            while (row.Read())
            {
                list.Add(row.GetString(0));
            }
            row.Close();
            return list;
        }

        public Boolean addFriendToList(String login_username, String username)
        {
            Boolean result = true;
            try
            {
                String query = String.Format("INSERT INTO friends(login_username, username) VALUES('{0}','{1}')", login_username, username);
                SQLiteCommand stmt = new SQLiteCommand(query, this.connection);
                return stmt.ExecuteNonQuery() > 0;
            }
            catch (Exception) { result = false; }
            return result;
        }

        public Boolean removeFriendFromList(String login_username, String username)
        {
            Boolean result = true;
            try
            {
                String query = String.Format("DELETE FROM friends WHERE login_username = '{0}' AND username = '{1}'", login_username, username);
                SQLiteCommand stmt = new SQLiteCommand(query, this.connection);
                return stmt.ExecuteNonQuery() > 0;
            }
            catch (Exception) { result = false; }
            return result;
        }

        public Boolean execute(String query)
        {
            Boolean result = true;
            try
            {
                SQLiteCommand stmt = new SQLiteCommand(query, this.connection);
                return stmt.ExecuteNonQuery() > 0;
            }
            catch (Exception) { result = false; }
            return result;
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
                if (!keyExists(key))
                {
                    return insertValue(key, value);
                }
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
