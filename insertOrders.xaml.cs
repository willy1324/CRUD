﻿using crud.Classes.create;
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

        public insertOrders(crudWindow parentWindow)
        {
            InitializeComponent();
            crudWindow = parentWindow;
        }

        void addCustomer(object sender, RoutedEventArgs e)
        {
            if (nameTb.Text == "" || directionTb.Text == "" || cityTb.Text == "" || phoneTb.Text == "")
            {
                MessageBox.Show("Hay un Campo sin rellenar");
            }
            else
            {
                create.InsertCustomer(crudWindow.mainWindow.con, nameTb, directionTb, cityTb, phoneTb);
                read.ShowCustomers(crudWindow.CustomerList, crudWindow.mainWindow.con);
                this.Close();
            }

        }

        void cancelButton(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
