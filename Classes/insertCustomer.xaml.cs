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
using crud.Classes.update;
using static Mysqlx.Crud.Order.Types;

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
        Update update = new Update();
        string customerId;

        bool editMode;

        public insertCustomer(crudWindow parentWindow, bool editMode)
        {
            InitializeComponent();
            crudWindow = parentWindow;
            this.editMode = editMode;

            if (editMode) { EditModeTrue(); }
        }

        void addCustomer(object sender, RoutedEventArgs e)
        {
            switch (editMode)
            {
                case true:
                    modifyCustomer();
                    break;

                case false:
                    newCustomer();
                    break;
            }
       
        }

        void newCustomer()
        {
            if (nameTb.Text == "" || directionTb.Text == "" || cityTb.Text == "" || phoneTb.Text == "")
            {
                MessageBox.Show("Hay un Campo sin rellenar");
            }
            else
            {
                create.InsertCustomer(crudWindow.mainWindow.con, nameTb, directionTb, cityTb, phoneTb);
                read.ShowCustomers(crudWindow.CustomerList, crudWindow.mainWindow.con);
                MessageBox.Show("Nuevo cliente agregado");
                this.Close();
            }
        }

        void modifyCustomer()
        {
            if (nameTb.Text == "" || directionTb.Text == "" || cityTb.Text == "" || phoneTb.Text == "")
            {
                MessageBox.Show("Hay un Campo sin rellenar");
            }
            else
            {
                update.UpdateCostumer(crudWindow.mainWindow.con, nameTb, directionTb, cityTb, phoneTb, this);
                read.ShowCustomers(crudWindow.CustomerList, crudWindow.mainWindow.con);
                MessageBox.Show($"Cliente de ID {IDSetter()} modificado con exito");
                this.Close();
            }
        }

        public void EditModeTrue()
        {
            this.Title = "Actualizar un cliente";
            addButton.Content = "Editar cliente";
        }

        public void IDGetter(string id) { customerId = id;}
        public string IDSetter() { return customerId; }

        void cancelButton(object sender, RoutedEventArgs e) { this.Close(); }
    }
}
