using MySql.Data.MySqlClient;
using System.Data.SQLite;
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
        public void DeleteOrder(ListBox Order, SQLiteConnection con)
        {

            try
            {
                MessageBoxResult deleteConfirm = MessageBox.Show($"¿Estas seguro de que deseas borrar este pedido? \n{Order.SelectedValue.ToString()}",
                                             "Borrar un pedido", MessageBoxButton.YesNo);

                if (deleteConfirm == MessageBoxResult.Yes)
                {
                    string query = "DELETE FROM pedido " +
                                   "WHERE ID = @orderToDelete";

                    SQLiteCommand command = new SQLiteCommand(query, con);

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

        public void DeleteCustomer(ListBox Customer, SQLiteConnection con)
        {
            try
            {
                MessageBoxResult deleteConfirm = MessageBox.Show($"¿Estas seguro de que deseas borrar este cliente? \n{Customer.SelectedValue.ToString()}",
                                             "Borrar un Cliente", MessageBoxButton.YesNo);

                if (deleteConfirm == MessageBoxResult.Yes)
                {
                    string query = "DELETE FROM cliente WHERE ID = @customerToDelete";
                    SQLiteCommand command = new SQLiteCommand(query, con);

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
