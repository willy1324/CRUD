using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace crud.Classes.delete
{
    class Delete
    {
        public void DeleteOrder(ListBox Order, MySqlConnection con)
        {
            MessageBoxResult deleteConfirm = MessageBox.Show($"¿Estas seguro de que deseas borrar este dato? \n{Order.SelectedValue.ToString()}",
                                             "Borrar datos en la tabla", MessageBoxButton.YesNo);

            if (deleteConfirm == MessageBoxResult.Yes)
            {
                string query = "DELETE FROM PEDIDO WHERE ID = @orderToDelete";
                MySqlCommand command = new MySqlCommand(query, con);

                command.Parameters.AddWithValue("@orderToDelete", Order.SelectedValue);
                command.ExecuteNonQuery();

                MessageBox.Show("Borrado con exito");
            }
            
        }

    }
}
