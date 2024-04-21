using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Windows;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;
using Mysqlx.Crud;

namespace crud.Classes.delete
{
    public class Delete
    {
        public void DeleteOrder(ListBox Order, MySqlConnection con)
        {

            try
            {
                MessageBoxResult deleteConfirm = MessageBox.Show($"¿Estas seguro de que deseas borrar este pedido? \n{Order.SelectedValue.ToString()}",
                                             "Borrar un pedido", MessageBoxButton.YesNo);

                if (deleteConfirm == MessageBoxResult.Yes)
                {
                    string query = "DELETE FROM pedido WHERE ID = @orderToDelete";
                    MySqlCommand command = new MySqlCommand(query, con);

                    command.Parameters.AddWithValue("@orderToDelete", Order.SelectedValue);
                    command.ExecuteNonQuery();

                    MessageBox.Show("Pedido borrado con exito");
                }
            }

            catch (Exception e)
            {
                MessageBox.Show("Error: " + e.ToString());
            }
            
        }

        public void DeleteCustomer(ListBox Customer, MySqlConnection con)
        {
            try
            {
                MessageBoxResult deleteConfirm = MessageBox.Show($"¿Estas seguro de que deseas borrar este cliente? \n{Customer.SelectedValue.ToString()}",
                                             "Borrar un Cliente", MessageBoxButton.YesNo);

                if (deleteConfirm == MessageBoxResult.Yes)
                {
                    string query = "DELETE FROM cliente WHERE ID = @customerToDelete";
                    MySqlCommand command = new MySqlCommand(query, con);

                    command.Parameters.AddWithValue("@customerToDelete", Customer.SelectedValue);
                    command.ExecuteNonQuery();

                    MessageBox.Show("Cliente borrado con exito");
                }
            }

            catch (Exception e)
            {
                MessageBox.Show("Error: " + e.ToString());
            }
        }

    }
}
