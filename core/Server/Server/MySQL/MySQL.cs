
using System;
using System.Data;
using GTANetworkAPI;
using MySql.Data.MySqlClient;

public class MySQL
{
    private static readonly string connStr = "server=localhost;user=root;database=GTA5;password=;Pooling=true;";

    public static void Test()
    {
        using (MySqlConnection conn = new MySqlConnection(connStr))
        {
            try
            {
                conn.Open();
                NAPI.Util.ConsoleOutput("[MySQL] Connect to MySQL succesfully.");
                conn.Close();
            }
            catch (Exception ex)
            {
                NAPI.Util.ConsoleOutput(ex.ToString());
            }
        }
    }

    public static void Query(MySqlCommand command)
    {
        if (command == null || command.CommandText.Length < 1) { NAPI.Util.ConsoleOutput("Wrong command argument: Null or Empty"); return; }
        using (MySqlConnection conn = new MySqlConnection(connStr))
        {
            try
            {
                conn.Open();
                command.Connection = conn;
                command.ExecuteNonQuery();
            }
            catch (Exception ex) 
            {
                NAPI.Util.ConsoleOutput(ex.ToString());
            }
            finally
            {
                conn.Close();
            }
        }
    }

    public static DataTable QueryRead(MySqlCommand command)
    {
        if (command == null || command.CommandText.Length < 1) { NAPI.Util.ConsoleOutput("Wrong command argument: Null or Empty"); return null; }
        using MySqlConnection conn = new MySqlConnection(connStr);
        try
        {
            conn.Open();
            command.Connection = conn;

            using MySqlDataReader reader = command.ExecuteReader();
            using DataTable dt = new DataTable();
            dt.Load(reader);
            return dt;
        }
        catch (Exception ex)
        {
            NAPI.Util.ConsoleOutput(ex.ToString());
            return null;
        }
        finally
        {
            conn.Close();
        }
    }
}