using System;
using System.Windows;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using static Mysqlx.Crud.Order.Types;
using System.Windows.Controls;

namespace crud.Classes.create
{
    public class Create
    {

        public void InsertCustomer(MySqlConnection con, TextBox nameTb, TextBox directionTb, TextBox cityTb, TextBox phoneTb)
        {
            string query = "INSERT INTO cliente(nombre, direccion, poblacion, telefono) " +
                           "VALUES (@nombre, @direccion, @poblacion, @telefono)";

            try
            {
                using (MySqlCommand command = new MySqlCommand(query, con))
                {
                    command.Parameters.AddWithValue("@nombre", nameTb.Text);
                    command.Parameters.AddWithValue("@direccion", directionTb.Text);
                    command.Parameters.AddWithValue("@poblacion", cityTb.Text);
                    command.Parameters.AddWithValue("@telefono", phoneTb.Text);

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
