using System;
using System.Windows;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using System.Data;
using System.Windows.Controls;

namespace crud.Classes.read
{

    public class Read
    {
        public void ShowCustomers(ListBox CustomerList, MySqlConnection con)
        {

            try
            {
                string query = "SELECT *, CONCAT(ID,'   ',nombre) AS infoCliente FROM cliente";
                MySqlDataAdapter dataAdapter = new MySqlDataAdapter(query, con);

                using (dataAdapter)
                {
                    DataTable CustomerTable = new DataTable();

                    //Rellenando tabla
                    dataAdapter.Fill(CustomerTable);
                    CustomerList.DisplayMemberPath = "infoCliente";
                    CustomerList.SelectedValuePath = "ID";
                    CustomerList.ItemsSource = CustomerTable.DefaultView;
                }
            }

            catch (Exception e)
            {
                MessageBox.Show("Error: " + e.ToString());
            }
            
        }

        public void ShowOrders(ListBox CustomerList, ListBox orderList, MySqlConnection con)
        {

            try
            {
                string query = "SELECT P.*, A.nombreArticulo, CONCAT(P.ID,'   ',A.nombreArticulo,'   ',P.fechaPedido, '   ', P.formaPago) AS datoPedido FROM pedido P " +
                               "INNER JOIN cliente C ON C.ID = P.cCliente " +
                               "LEFT JOIN articulo A ON P.cCliente = A.ID WHERE C.ID = @ClienteID";

                MySqlCommand command = new MySqlCommand(query, con);
                MySqlDataAdapter dataAdapter = new MySqlDataAdapter(command);

                using (dataAdapter)
                {
                    command.Parameters.AddWithValue("@ClienteID", CustomerList.SelectedValue);
                    DataTable ordersTable = new DataTable();

                    //Rellenando tabla
                    dataAdapter.Fill(ordersTable);
                    orderList.DisplayMemberPath = "datoPedido";
                    orderList.SelectedValuePath = "ID";
                    orderList.ItemsSource = ordersTable.DefaultView;
                }
            }

            catch (Exception e)
            {
                MessageBox.Show("Error: " + e.ToString());
            }
           
        }

        public void ShowAllCustomers(ListBox allOrdersList, MySqlConnection con)
        {
            try
            {
                string query = "SELECT P.*, A.nombreArticulo, CONCAT(P.ID,'   ',A.nombreArticulo,'  ',P.fechaPedido,'  ', P.formaPago) " +
                               "AS infoCompleta FROM pedido P LEFT JOIN articulo A ON P.cArticulo = A.ID";

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

            catch (Exception e)
            {
                MessageBox.Show("Error: " + e.ToString());
            }

        }


        public void ReadCustomerOnEditMode (ListBox CustomerList, MySqlConnection con, insertCustomer EditWindow)
        {
            string query = "SELECT id, nombre, direccion, poblacion, telefono FROM cliente " +
                           "WHERE ID = @ClienteID";

            MySqlCommand command = new MySqlCommand(query, con);
            MySqlDataAdapter dataAdapter = new MySqlDataAdapter(command);

            try
            {
                using (dataAdapter)
                {
                    //Crea el parametro ClienteID y lo rellena con la tabla de CustomerList
                    command.Parameters.AddWithValue("ClienteID", CustomerList.SelectedValue);
                    DataTable CustomerTable = new DataTable();

                    //Rellena la informacion del formulario de la ventana con la tabla
                    dataAdapter.Fill(CustomerTable);

                    EditWindow.IDGetter(CustomerTable.Rows[0]["id"].ToString());
                    EditWindow.nameTb.Text = CustomerTable.Rows[0]["nombre"].ToString();
                    EditWindow.directionTb.Text = CustomerTable.Rows[0]["direccion"].ToString();
                    EditWindow.cityTb.Text = CustomerTable.Rows[0]["poblacion"].ToString();
                    EditWindow.phoneTb.Text = CustomerTable.Rows[0]["telefono"].ToString();

                }
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }

        }
    }
    
}
