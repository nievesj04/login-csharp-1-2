using System;
using System.Data.SqlClient;

namespace Login
{
    public partial class Form1 : Form1{
        public Form1()
        {
            InitializeComponent();
        }

        // Conección de C# con la base de datos de SQL Server  | Nombre del servidor| nombre de la BD | Seguridad |
        SqlConnection con = new SqlConnection(@"Data Source=(LocalDb)\v11.0;Initial Catalog=Login_csharp;Integrated Security=True");

        // Metodo para validar los datos del Login
        public void Logear(string user, string password)
        {
            // Manejo de errores
            try
            {
                //Abrimos la conexion
                con.Open(); 
                // Consulta SQL para la peticion de los datos
                SqlCommand cmd = new SqlCommand("SELECT Name, User_type FROM Ususarios WHERE User = @user AND Password = @pass", con);
                // Agregando los parametros al comando SQL
                cmd.Parameters.AddWithValue("user", user);
                cmd.Parameters.AddWithValue("pass", password);
                // Objeto DataAdapter
                SqlDataAdapter sda = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                sda.Fill(dt);

                if(dt.Rows.Count == 1)
                {

                }
                else
                {
                    MessageBox.Show("Usuario o Contraseña Incorrecta");
                }
            }
            catch(Exception e)
            {
                MessageBox.Show(e.Message);
            }
            finally
            {

            }
        }
    }
}