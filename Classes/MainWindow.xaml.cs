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
using System.Data.SQLite;
using System.Data;

namespace crud
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        public SQLiteConnection con = new SQLiteConnection();
        private string constring;
        bool succesfullLogin = false;

        public MainWindow()
        {
            InitializeComponent();
        }
        
        private void ConnectToSql(object sender, RoutedEventArgs e)
        {
            constring = $"Data Source=G:/Documents/Programación/C#/repos/crud/crud/db/gestionPedidos.db;Version=3;"; 
            con.ConnectionString = constring;
            con.Open();
            string query = "SELECT * FROM usuario WHERE usuario = @usuario AND contrasena = @contrasena";
            SQLiteCommand command = new SQLiteCommand(query,con);

            command.Parameters.AddWithValue("@usuario", userTb.Text);
            command.Parameters.AddWithValue("@contrasena", pwdTb.Password);

            using (SQLiteDataAdapter loginAdapter =  new SQLiteDataAdapter(command)) 
            {
                DataTable loginTable = new DataTable();
                loginAdapter.Fill(loginTable);
                if (loginTable.Rows.Count > 0) { succesfullLogin = true; }
                else
                {
                    succesfullLogin= false;
                    MessageBox.Show("Contraseña Incorrecta");
                    con.Close();
                }
            }

            try 
            {
                               

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

        void Persona3FESEasterEgg()
        {
            
        }

        public void closedConnectionMessage()
        {
            MessageBox.Show("¡Conexión cerrada con exito");
        }

    }
}