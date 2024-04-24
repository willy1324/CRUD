using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Data;
using System.Data.SQLite;

namespace crud.Classes.update
{
    public class Update
    {

        public void UpdateCostumer(SQLiteConnection con, TextBox nameTb, TextBox directionTb, TextBox cityTb, TextBox phoneTb, insertCustomer EditWindow)
        {
            string query = "UPDATE cliente " +
                           "SET nombre = @Name, direccion = @Direction, poblacion = @City, telefono = @Phone " +
                           "WHERE id = @SelectedID";

            try
            {
                using (SQLiteCommand command = new SQLiteCommand(query, con))
                {
                    command.Parameters.AddWithValue("@Name",nameTb.Text);
                    command.Parameters.AddWithValue("@Direction", directionTb.Text);
                    command.Parameters.AddWithValue("@City", cityTb.Text);
                    command.Parameters.AddWithValue("@Phone", phoneTb.Text);
                    command.Parameters.AddWithValue("@SelectedID", EditWindow.IDSetter());

                    command.ExecuteNonQuery();
                }
             
            }
            catch (Exception ex) { MessageBox.Show(ex.ToString()); }

        }

        public void UpdateOrder(ListBox CustomerList, SQLiteConnection con)
        {
            try
            {
                
            }
            catch (Exception ex) { MessageBox.Show(ex.ToString()); }

        }

    }
}
