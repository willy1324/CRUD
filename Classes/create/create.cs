using System;
using System.Windows;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using System.Data.SQLite;
using static Mysqlx.Crud.Order.Types;
using System.Windows.Controls;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace crud.Classes.create
{
    public class Create
    {
        public void InsertCustomer(SQLiteConnection con, TextBox nameTb, TextBox directionTb, TextBox cityTb, TextBox phoneTb)
        {
            string query = "INSERT INTO cliente(nombre, direccion, ciudad, telefono) " +
                           "VALUES (@nombre, @direccion, @ciudad, @telefono)";

            try
            {
                using (SQLiteCommand command = new SQLiteCommand(query, con))
                {
                    command.Parameters.AddWithValue("@nombre", nameTb.Text);
                    command.Parameters.AddWithValue("@direccion", directionTb.Text);
                    command.Parameters.AddWithValue("@ciudad", cityTb.Text);
                    command.Parameters.AddWithValue("@telefono", phoneTb.Text);

                    command.ExecuteNonQuery();
                }
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        public void InsertOrder(SQLiteConnection con, string customerID, string articleID, TextBox orderDateTb, TextBox methodOfPayTb, TextBox quantityTb)
        {
            string query = "INSERT INTO pedido(cCliente, cArticulo, fechaPedido, formaPago, cantidad) " +
                           "VALUES (@cCliente, @cArticulo, @fechaPedido, @formaPago, @cantidad)";
            try
            {
                using (SQLiteCommand command = new SQLiteCommand(query, con))
                {
                    command.Parameters.AddWithValue("@cCliente", customerID);
                    command.Parameters.AddWithValue("@cArticulo", articleID);
                    command.Parameters.AddWithValue("@fechaPedido", orderDateTb.Text);
                    command.Parameters.AddWithValue("@formaPago", methodOfPayTb.Text);
                    command.Parameters.AddWithValue("@cantidad", quantityTb.Text);

                    command.ExecuteNonQuery();
                }
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

    }
}
