using MySql.Data.MySqlClient;
using Mysqlx;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace crud
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        public MySqlConnection con = new MySqlConnection();
        private string constring;

        public MainWindow()
        {
            InitializeComponent();
        }
        
        private void ConnectToSql(object sender, RoutedEventArgs e)
        {
            constring = $"server=localhost;uid={tBuser.Text};pwd={tBpwD.Password};database=gestionpedidos";
            con.ConnectionString = constring;

            try 
            {
                con.Open(); 
                if (con.State == System.Data.ConnectionState.Open) 
                {
                    MessageBox.Show("¡Conexión realizada con exito!");
                    this.Hide();
                    crudWindow crudWindow = new crudWindow();
                    crudWindow.Show();
                }

            }
           
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message,"¡Error al conectar a la Base de Datos!",MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        public void closedConnectionMessage()
        {
            MessageBox.Show("¡Conexión cerrada con exito");
        }

    }
}