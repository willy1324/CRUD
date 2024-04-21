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
using crud.Classes.create;
using crud.Classes.read;
using crud.Classes.delete;

namespace crud
{
    
    public partial class crudWindow : Window
    {
        public MainWindow mainWindow = Application.Current.MainWindow as MainWindow;
        public Read read = new Read();
        public Delete delete = new Delete();

        public crudWindow()
        {
            InitializeComponent();
            read.ShowCustomers(CustomerList,mainWindow.con);
            read.ShowAllCustomers(allOrdersList,mainWindow.con);
        }


// ---------------------------Codigo de Los Botones-------------------------------------------

        //--------------- Botones para manejar tablas-----------------------------------------

        void deleteButton(object sender, RoutedEventArgs e)
        {

            //Borrar desde la lista de todos los pedidos
            if (allOrdersList.SelectedValue != null)
            {
                delete.DeleteOrder(allOrdersList, mainWindow.con);               
            }

            //Borrar desde la lista filtrada por clientes
            else if (orderList.SelectedValue != null)
            {
                delete.DeleteOrder(orderList, mainWindow.con);            
            }

            //Borrar clientes
            else if (CustomerList.SelectedValue != null)
            {
                delete.DeleteCustomer(CustomerList, mainWindow.con);
            }

            //No seleccionar nada
            else
            {
                MessageBox.Show("Selecciona algun pedido o cliente");
            }

            //Refrescar las tablas
            read.ShowAllCustomers(allOrdersList, mainWindow.con);
            read.ShowOrders(CustomerList,orderList, mainWindow.con);
            read.ShowCustomers(CustomerList, mainWindow.con);
        }

        void createCustomerButton(object sender, RoutedEventArgs e)
        {
            insertCustomer CustomerWindow = new insertCustomer(this);
            CustomerWindow.Show();

        }

        void createOrderButton(object sender, RoutedEventArgs e)
        {

        }

        //------------------------------------------------------------------------------------
        void CustomerListMouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            read.ShowOrders(CustomerList,orderList,mainWindow.con);
        }


        private void windowClosing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            mainWindow.Show();
            mainWindow.con.Close();
            mainWindow.closedConnectionMessage();
        }
        
        void Disconnect(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

    }
}
