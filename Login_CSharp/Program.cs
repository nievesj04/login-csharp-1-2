using System;
using System.Data.SqlClient; // Libreria para el manejo de la base de datos

namespace Login
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            // Inicializa los componentes graficos
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

                // Verifica y cuenta que existan filas en la base de datos
                if(dt.Rows.Count == 1)
                {
                    this.Hide();
                    if (dt.Rows[0][1].ToString() == "Admin");  //Verifica si el usuasio que se esta autenticando es "Usuario o Admin"
                    {     
                        new Admin(dt.Rows[0][0].ToString()).Show(); //Muestra la ventana admin en caso de ser "Admin"
                    } 
                    else if (dt.Rows[0][1].ToString () == "Usuario") //Verifica si el usuasio que se esta autenticando es "Usuario o Admin"
                    {
                        new Usuario (dt.Rows[0][0].ToString()).Show(); //Muestra la ventana usuario en caso de ser "Usuario"
                    }          
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
                // Cierra la conección a la Base de Datos
                con.Close();
            }
        }
    }
}