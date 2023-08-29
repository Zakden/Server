using System.Data;
using GTANetworkAPI;
using MySql.Data.MySqlClient;

public class Events : Script
{
    [ServerEvent(Event.ResourceStart)]
    public void OnResourceStart()
    {
        NAPI.Util.ConsoleOutput("[LOAD] 'Events' loaded succesfully");
        MySQL.Test();

        //string insertQuery = "INSERT INTO accounts (name, password) VALUES (@name, @password)";
        //using MySqlCommand insertCommand = new MySqlCommand(insertQuery);
        //insertCommand.Parameters.AddWithValue("@name", "Zakden");
        //insertCommand.Parameters.AddWithValue("@password", "Zemas456");

        //MySQL.Query(insertCommand);

        //string query = "SELECT * FROM accounts";
        //using MySqlCommand getAccounts = new MySqlCommand(query);
        //DataTable dt = MySQL.QueryRead(getAccounts);
        //foreach (DataRow dr in dt.Rows)
        //{
        //    var cells = dr.ItemArray;
        //    foreach (var cell in cells) 
        //    {
        //        NAPI.Util.ConsoleOutput(cell.ToString());
        //    }
        //}
    }
}