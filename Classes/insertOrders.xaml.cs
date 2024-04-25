using crud.Classes.create;
using crud.Classes.read;
using crud.Classes.update;
using System;
using System.Collections.Generic;
using System.Data;
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
        Update update = new Update();
        string customerID;
        string articleID;
        string orderID;
        const string customerTable = "cliente";
        const string articleTable = "articulo";
        const string customerDisplay = "nombre";
        const string articleDisplay = "nombreArticulo";

        bool editMode;

        public insertOrders(crudWindow parentWindow, bool editMode)
        {
            InitializeComponent();
            crudWindow = parentWindow;
            //Cargar clientes en combobox
            read.ReadOrderComboBox(customerCb,crudWindow.mainWindow.con,customerTable, customerDisplay);
            //Cargar articulos en combobox
            read.ReadOrderComboBox(articleCb, crudWindow.mainWindow.con, articleTable, articleDisplay);
            this.editMode = editMode;

            if (editMode) 
            { 
                EditModeTrue();
                customerCb.SelectedValue = customerID;
                articleCb.SelectedValue = articleID;
            }
        }

        void addOrder(object sender, RoutedEventArgs e)
        {
            switch (editMode)
            {
                case true:
                    modifyOrder();
                    break;

                case false:
                    newOrder();
                    break;
            }

        }

        void newOrder()
        {
            if (customerID == "" || articleID == "" || orderDateTb.Text == "" || methodOfPayTb.Text == "" || quantityTb.Text == "")
            {
                MessageBox.Show("Hay un Campo sin rellenar");
            }
            else
            {
                create.InsertOrder(crudWindow.mainWindow.con, customerID, articleID, orderDateTb, methodOfPayTb, quantityTb);
                read.ShowAllOrders(crudWindow.allOrdersList, crudWindow.mainWindow.con);
                this.Close();
            }
        }

        void modifyOrder()
        {
            if (customerID == "" || articleID == "" || orderDateTb.Text == "" || methodOfPayTb.Text == "" || quantityTb.Text == "")
            {
                MessageBox.Show("Hay un Campo sin rellenar");
            }
            else
            {
                update.UpdateOrder(crudWindow.mainWindow.con, customerID, articleID, orderDateTb, methodOfPayTb, quantityTb,this);
                read.ShowAllOrders(crudWindow.allOrdersList, crudWindow.mainWindow.con);
                this.Close();
            }
        }
        
        public void OrderIDGetter(string id) { orderID = id; }

        public string OrderIDSetter() { return orderID; }

        void cancelButton(object sender, RoutedEventArgs e) { this.Close(); }

        public void EditModeTrue()
        {
            this.Title = "Actualizar un pedido";
            addButton.Content = "Editar pedido";
        }

        void customerCb_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (customerCb.SelectedItem != null)
            {
                DataRowView row = (DataRowView)customerCb.SelectedItem;
                customerID = row["ID"].ToString();
                //MessageBox.Show(customerID);
            }
        }

        void articleCb_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (articleCb.SelectedItem != null)
            {
                DataRowView row = (DataRowView)articleCb.SelectedItem;
                articleID = row["ID"].ToString();
                //MessageBox.Show(articleID);
            }
        }

    }
}
