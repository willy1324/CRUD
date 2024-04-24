using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using MySql.Data.MySqlClient;
using System.Data.SQLite;
using crud.Classes.create;
using crud.Classes.read;
using crud.Classes.update;
using crud.Classes.delete;

namespace crud
{
    public partial class crudWindow : Window
    {
        public MainWindow mainWindow = Application.Current.MainWindow as MainWindow;
        public Read read = new Read();
        public Update update = new Update();
        public Delete delete = new Delete();

        public crudWindow()
        {
            InitializeComponent();
            read.ShowCustomers(CustomerList,mainWindow.con);
            read.ShowAllOrders(allOrdersList,mainWindow.con);
        }


// ---------------------------Codigo de Los Botones-------------------------------------------

        //--------------- Botones para manejar tablas-----------------------------------------

        void DeleteButton(object sender, RoutedEventArgs e)
        {
            //Borrar desde la lista de todos los pedidos
            if (allOrdersList.SelectedValue != null) { delete.DeleteOrder(allOrdersList, mainWindow.con); }

            //Borrar desde la lista filtrada por clientes
            else if (orderList.SelectedValue != null) { delete.DeleteOrder(orderList, mainWindow.con); }

            //Borrar clientes
            else if (CustomerList.SelectedValue != null) { delete.DeleteCustomer(CustomerList, mainWindow.con); }

            //No seleccionar nada
            else { MessageBox.Show("Selecciona algun pedido o cliente"); }
                       
            //Refrescar las tablas
            read.ShowAllOrders(allOrdersList, mainWindow.con);
            read.ShowOrders(CustomerList,orderList, mainWindow.con);
            read.ShowCustomers(CustomerList, mainWindow.con);
        }

        void CreateCustomerButton(object sender, RoutedEventArgs e)
        {
            insertCustomer CustomerWindow = new insertCustomer(this,false);
            CustomerWindow.ShowDialog();
        }

        void CreateOrderButton(object sender, RoutedEventArgs e)
        {
            insertOrders OrderWindow = new insertOrders(this,false);
            OrderWindow.ShowDialog();
        }

        void UpdateButton(object sender, RoutedEventArgs e)
        {
            //Actualizar desde la lista de todos los pedidos
            if (allOrdersList.SelectedValue != null)
            {
                MessageBoxResult result = MessageBox.Show("¿Estás seguro de que deseas hacer cambios en este pedido?", "Actualizar un pedido", MessageBoxButton.YesNo);
                if (result == MessageBoxResult.Yes)
                {
                    MessageBox.Show("Implementando...");
                }
            }

            //Actualizar desde la lista filtrada por clientes
            else if (orderList.SelectedValue != null)
            {
                MessageBoxResult result = MessageBox.Show("¿Estás seguro de que deseas hacer cambios en este pedido?", "Actualizar un pedido", MessageBoxButton.YesNo);
                if (result == MessageBoxResult.Yes)
                {
                    MessageBox.Show("Implementando...");
                }
            }

            //Actualizar clientes
            else if (CustomerList.SelectedValue != null)
            {
                MessageBoxResult result = MessageBox.Show("¿Estás seguro de que deseas hacer cambios en este cliente?", "Actualizar un cliente", MessageBoxButton.YesNo);
                if (result == MessageBoxResult.Yes)
                {
                    insertCustomer CustomerWindow = new insertCustomer(this,true);
                    read.ReadCustomerOnEditMode(CustomerList, mainWindow.con, CustomerWindow);
                    CustomerWindow.ShowDialog();
                }
            }

            //No seleccionar nada
            else { MessageBox.Show("Selecciona algun pedido o cliente"); }

            //Refrescar las tablas
            read.ShowAllOrders(allOrdersList, mainWindow.con);
            read.ShowOrders(CustomerList, orderList, mainWindow.con);
            read.ShowCustomers(CustomerList, mainWindow.con);
        }

        //------------------------------------------------------------------------------------
        void CustomerListMouseDoubleClick(object sender, MouseButtonEventArgs e) { read.ShowOrders(CustomerList, orderList, mainWindow.con); }

        private void windowClosing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            mainWindow.Show();
            mainWindow.con.Close();
            mainWindow.closedConnectionMessage();
        }
        
        void Disconnect(object sender, RoutedEventArgs e) { this.Close(); }
    }
}