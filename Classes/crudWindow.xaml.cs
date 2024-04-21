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
        MainWindow mainWindow = Application.Current.MainWindow as MainWindow;
        Read read = new Read();
        Delete delete = new Delete();

        public crudWindow()
        {
            InitializeComponent();
            read.ShowCostumers(costumerList,mainWindow.con);
            read.ShowAllCostumers(allOrdersList,mainWindow.con);
        }


// ---------------------------Codigo de Los Botones-------------------------------------------

        //--------------- Botones para manejar tablas-----------------------------------------

        void deleteButton(object sender, RoutedEventArgs e)
        {

            if (allOrdersList.SelectedValue != null)
            {
                delete.DeleteOrder(allOrdersList, mainWindow.con);               
            }

            else if (costumerList.SelectedValue != null)
            {
                delete.DeleteOrder(costumerList, mainWindow.con);            
            }

            else
            {
                MessageBox.Show("Selecciona algun pedido");
            }

            read.ShowAllCostumers(allOrdersList, mainWindow.con);
            read.ShowCostumers(costumerList, mainWindow.con);
        }

        void createCostumerButton(object sender, RoutedEventArgs e)
        {

        }

        void createOrderButton(object sender, RoutedEventArgs e)
        {

        }

        //------------------------------------------------------------------------------------
        void costumerListSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            read.ShowOrders(costumerList,orderList,mainWindow.con);
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
