﻿using System;
using System.Windows;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using System.Data;
using System.Windows.Controls;
using System.Data.SQLite;
using MySqlX.XDevAPI;
using System.Windows.Controls.Primitives;

namespace crud.Classes.read
{

    public class Read
    {
        public void ShowCustomers(ListBox CustomerList, SQLiteConnection con)
        {

            try
            {
                string query = "SELECT *, ID || '   ' || nombre AS infoCliente FROM cliente";
                SQLiteDataAdapter dataAdapter = new SQLiteDataAdapter(query, con);

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

        public void ShowOrders(ListBox CustomerList, ListBox orderList, SQLiteConnection con)
        {

            try
            {
                string query = "SELECT P.*, P.ID || '   ' || A.nombreArticulo || '   ' || P.fechaPedido || '   ' || P.formaPago AS datoPedido " +
                               "FROM pedido P " +
                               "INNER JOIN cliente C ON C.ID = P.cCliente " +
                               "LEFT JOIN articulo A ON P.cCliente = A.ID " +
                               "WHERE C.ID = @ClienteID";

                SQLiteCommand command = new SQLiteCommand(query, con);
                SQLiteDataAdapter dataAdapter = new SQLiteDataAdapter(command);

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

        public void ShowAllOrders(ListBox allOrdersList, SQLiteConnection con)
        {
            try
            {
                string query = "SELECT *, p.ID || '  ' || c.nombre || '  ' || a.nombreArticulo || '  ' || p.fechaPedido || '  ' || formaPago || '  ' || cantidad AS pedidoCompleto " +
                                "FROM pedido p " +
                                "LEFT JOIN articulo a ON p.cArticulo = a.ID " +
                                "LEFT JOIN cliente c ON p.cCliente = c.ID";

                SQLiteDataAdapter dataAdapter = new SQLiteDataAdapter(query, con);

                using (dataAdapter)
                {
                    DataTable allOrdersTable = new DataTable();

                    //Rellenando tabla
                    dataAdapter.Fill(allOrdersTable);
                    allOrdersList.DisplayMemberPath = "pedidoCompleto";
                    allOrdersList.SelectedValuePath = "ID";
                    allOrdersList.ItemsSource = allOrdersTable.DefaultView;
                }
            }

            catch (Exception e)
            {
                MessageBox.Show("Error: " + e.ToString());
            }

        }


        public void ReadCustomerOnEditMode (ListBox CustomerList, SQLiteConnection con, insertCustomer EditWindow)
        {
            string query = "SELECT id, nombre, direccion, poblacion, telefono FROM cliente " +
                           "WHERE ID = @ClienteID";

            SQLiteCommand command = new SQLiteCommand(query, con);
            SQLiteDataAdapter dataAdapter = new SQLiteDataAdapter(command);

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


        public void ReadOrderComboBox(ComboBox combobox, SQLiteConnection con , string dbTable, string displayPath)
        {
            string query = $"SELECT ID, {displayPath} FROM {dbTable}";
            SQLiteDataAdapter dataAdapter = new SQLiteDataAdapter(query, con);

            try
            {
                using (dataAdapter)
                {
                    DataTable CustomerTable = new DataTable();

                    //Rellenando tabla
                    dataAdapter.Fill(CustomerTable);
                    combobox.DisplayMemberPath = displayPath;
                    combobox.SelectedValuePath = "ID";
                    combobox.ItemsSource = CustomerTable.DefaultView;
                }
            }

            catch (Exception e)
            {
                MessageBox.Show("Error: " + e.ToString());
            }
          
        }

    }
    
}
