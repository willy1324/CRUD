using System;
using System.Collections.Generic;
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

namespace crud
{
    /// <summary>
    /// Lógica de interacción para insertCustomer.xaml
    /// </summary>
    public partial class insertCustomer : Window
    {
        crudWindow crudWindow;
        Create create = new Create();
        Read read = new Read();
        public insertCustomer(crudWindow parentWindow)
        {
            InitializeComponent();
            crudWindow = parentWindow;
        }

        void addCustomer(object sender, RoutedEventArgs e)
        {
            create.InsertCustomer(crudWindow.mainWindow.con, nameTb, directionTb, cityTb, phoneTb);
            read.ShowCustomers(crudWindow.CustomerList, crudWindow.mainWindow.con);
            this.Close();
        }

        void cancelButton(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
