using crud.Classes.create;
using crud.Classes.read;
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

namespace crud
{
    /// <summary>
    /// Lógica de interacción para insertOrders.xaml
    /// </summary>
    public partial class insertOrders : Window
    {
        crudWindow crudWindow;
        Create create = new Create();
        Read read = new Read();

        bool editMode;

        public insertOrders(crudWindow parentWindow, bool editMode)
        {
            InitializeComponent();
            crudWindow = parentWindow;
        }

        void addOrder(object sender, RoutedEventArgs e)
        {
            if (orderDateTb.Text == "" || methodOfPayTb.Text == "" || quantityTb.Text == "")
            {
                MessageBox.Show("Hay un Campo sin rellenar");
            }
            else
            {
                MessageBox.Show("Implementando...");
                this.Close();
            }

        }

        void cancelButton(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
