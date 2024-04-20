using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace crud.Classes.delete
{
    class Delete
    {
        public void DeleteOrder(ListBox allOrdersList, MySqlConnection con)
        {
            string query = "DELETE FROM PEDIDO WHERE ID = @orderToDelete";
            MySqlCommand command = new MySqlCommand(query, con);

            command.Parameters.AddWithValue("@orderToDelete", allOrdersList.SelectedValue);
            command.ExecuteNonQuery();
        }

    }
}
