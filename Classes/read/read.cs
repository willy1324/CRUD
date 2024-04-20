using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using System.Data;
using System.Windows.Controls;

namespace crud.Classes.read
{

    class Read
    {
        public void ShowCostumers(ListBox costumerList, MySqlConnection con)
        {
            string query = "SELECT * FROM cliente";
            MySqlDataAdapter dataAdapter = new MySqlDataAdapter(query, con);

            using (dataAdapter)
            {
                DataTable costumerTable = new DataTable();

                //Rellenando tabla
                dataAdapter.Fill(costumerTable);
                costumerList.DisplayMemberPath = "nombre";
                costumerList.SelectedValuePath = "ID";
                costumerList.ItemsSource = costumerTable.DefaultView;
            }
        }

        public void ShowOrders(ListBox costumerList, ListBox orderList, MySqlConnection con)
        {

            string query = "SELECT * FROM pedido P INNER JOIN cliente C ON C.ID = P.cCliente WHERE C.ID = @ClienteID";

            MySqlCommand command = new MySqlCommand(query,con);
            MySqlDataAdapter dataAdapter = new MySqlDataAdapter(command);

            using (dataAdapter)
            {
                command.Parameters.AddWithValue("@ClienteID", costumerList.SelectedValue);
                DataTable ordersTable = new DataTable();
                            
                //Rellenando tabla
                dataAdapter.Fill(ordersTable);
                orderList.DisplayMemberPath = "fechaPedido";
                orderList.SelectedValuePath = "ID";
                orderList.ItemsSource = ordersTable.DefaultView;
            }
        }

        public void ShowAllCostumers(ListBox allOrdersList, MySqlConnection con)
        {
            string query = "SELECT CONCAT(cCliente,'   ', fechaPedido, '   ', formaPago) AS infoCompleta FROM pedido";
            MySqlDataAdapter dataAdapter = new MySqlDataAdapter(query, con);

            using (dataAdapter)
            {
                DataTable allOrdersTable = new DataTable();

                //Rellenando tabla
                dataAdapter.Fill(allOrdersTable);
                allOrdersList.DisplayMemberPath = "infoCompleta";
                allOrdersList.SelectedValuePath = "ID";
                allOrdersList.ItemsSource = allOrdersTable.DefaultView;
            }
        }

    }
}
