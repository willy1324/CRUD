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
using crud.Classes.read;

namespace crud
{
    
    public partial class crudWindow : Window
    {
        MainWindow mainWindow = Application.Current.MainWindow as MainWindow;
        Read read = new Read();
        private string constring;

        public crudWindow()
        {
            InitializeComponent();
            read.ShowCostumers(costumerList,mainWindow.con);
            read.ShowAllCostumers(allOrdersList,mainWindow.con);
        }


// ---------------------------Codigo de Los Botones-------------------------------------------
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
