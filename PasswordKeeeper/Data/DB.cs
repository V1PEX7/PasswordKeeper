using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.IO;
using System.Text;
using System.Windows;

namespace PasswordKeeeper.Data
{
    public static class DB
    {
        static string DBPath = "data.db";
        public static void Initialize()
        {
            if (!File.Exists(DBPath))
                SQLiteConnection.CreateFile(DBPath);
            try
            {
                SQLiteConnection con = new SQLiteConnection($"Data Source={DBPath};Version=3");
                con.Open();
                SQLiteCommand cmd = con.CreateCommand();
                cmd.Connection = con;
                cmd.CommandText = "CREATE TABLE IF NOT EXISTS users (id INTEGER PRIMARY KEY AUTOINCREMENT, resource TEXT, login TEXT, password TEXT)";
                cmd.ExecuteNonQuery();
            }
            catch (Exception err)
            {
                MessageBox.Show(err.ToString(), "Не удалось подключиться к базе данных!");
                View.MainWindow.Class.Close();
            }
        }

        public static void AddItem(string resource, string login, string password)
        {
            SQLiteConnection con = new SQLiteConnection($"Data Source={DBPath};Version=3");
            con.Open();
            SQLiteCommand cmd = con.CreateCommand();
            cmd.Connection = con;
            cmd.CommandText = "INSERT INTO users (resource, login, password) VALUES (@res, @login, @pass)";
            cmd.Parameters.AddWithValue("@res", resource);
            cmd.Parameters.AddWithValue("@login", login);
            cmd.Parameters.AddWithValue("@pass", password);
            cmd.ExecuteNonQuery();
        }

        public static void GetAllItems()
        {
            SQLiteConnection con = new SQLiteConnection($"Data Source={DBPath};Version=3");
            con.Open();
            SQLiteCommand readcmd = con.CreateCommand();
            readcmd.Connection = con;
            readcmd.CommandText = "SELECT * FROM users";
            SQLiteDataReader reader = readcmd.ExecuteReader();
            LogPassDescList.list.Clear();
            while (reader.Read())
            {
                LogPassDescList.list.Add(new LoginPassDesc 
                { 
                    id = Convert.ToInt32(reader["id"]),
                    Resource = reader["resource"].ToString(),
                    Login = reader["login"].ToString(),
                    Password = reader["password"].ToString()
                });
            }
        }

        public static void DeleteItem(int id)
        {
            SQLiteConnection con = new SQLiteConnection($"Data Source={DBPath};Version=3");
            con.Open();
            SQLiteCommand cmd = con.CreateCommand();
            cmd.Connection = con;
            cmd.CommandText = "DELETE FROM users WHERE id = @id";
            cmd.Parameters.AddWithValue("@id", id);
            cmd.ExecuteNonQuery();
        }

        public static void UpdateItem(int id, string resource, string login, string password)
        {
            SQLiteConnection con = new SQLiteConnection($"Data Source={DBPath};Version=3");
            con.Open();
            SQLiteCommand cmd = con.CreateCommand();
            cmd.Connection = con;
            cmd.CommandText = "UPDATE users SET resource = @res, login = @login, password = @pass WHERE id = @id";
            cmd.Parameters.AddWithValue("@id", id);
            cmd.Parameters.AddWithValue("@res", resource);
            cmd.Parameters.AddWithValue("@login", login);
            cmd.Parameters.AddWithValue("@pass", password);
            cmd.ExecuteNonQuery();
        }
    }
}
