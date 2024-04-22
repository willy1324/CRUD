using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Data;

namespace crud.Classes.update
{
    public class Update
    {

        public void UpdateCostumer(MySqlConnection con, TextBox nameTb, TextBox directionTb, TextBox cityTb, TextBox phoneTb)
        {
            try
            {
                
            }
            catch (Exception ex) { MessageBox.Show(ex.ToString()); }

        }

        public void UpdateOrder(ListBox CustomerList, MySqlConnection con)
        {
            try
            {
                
            }
            catch (Exception ex) { MessageBox.Show(ex.ToString()); }

        }

    }
}
