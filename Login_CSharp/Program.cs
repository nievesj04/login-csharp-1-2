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

        
        // Metodo para validar los datos del Login
        public bool Logear(string codUsuaIngresado, string contraIngresada)
        {
            string serverName = ""; // Nombre del servidor
            string dbName = ""; // Nombre de la Base de Datos
            string userId = ""; // Id del usuario DB
            string passwordConnection = ""; // Contraseña de conexión

            string decryptPassword = ""; // Contraseña para desencriptar la contraseña de la base de datos
            
            using (SqlConnection connection = new SqlConnection($"Data Source={serverName}; Initial Catalog={dbName}; Persist Security Info=True; User ID={userId}; Password={passwordConnection}"))
            {
                string query = $"SELECT DECRYPTBYPASSPHRASE('{decryptPassword}', Contra) AS Contra,\n" + 
                                "EsAdmin\n"+
                                "FROM Usuarios\n"+
                                "WHERE CodUsua = @codUsua\n";

                using (SqlCommand cmd = new SqlCommand(query, connection))
                {
                    cmd.Parameters.AddWithValue("@codUsua", codUsuaIngresado);

                    try
                    {
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            if (cmd.ExecuteNonQuery() == 1) 
                            {
                                if (reader.Read())
                                {
                                    string contraBaseDatos = reader["Contra"].ToString();
                                    string esAdmin = reader["EsAdmin"].ToString();

                                    if (contraIngresada == contraBaseDatos) { return true; } 
                                    else { return false; }
                                }
                                else { return false; }
                            }
                            else { return false; }
                        }
                    }   
                }
            } 
        }
    }
}



                    // // Manejo de errores
                    // try
                    // {
                    //     //Abrimos la conexion
                    //     con.Open(); 
                    //     // Consulta SQL para la peticion de los datos
                    //     SqlCommand cmd = new SqlCommand("SELECT Name, User_type FROM Ususarios WHERE CodUsua = @CodUsua AND Contra = @Contra", con);
                    //     // Agregando los parametros al comando SQL
                    //     cmd.Parameters.AddWithValue("@CodUsua", codUsuaIngresado);
                    //     cmd.Parameters.AddWithValue("@Contra", contraIngresada);
                    //     // Objeto DataAdapter
                    //     SqlDataAdapter sda = new SqlDataAdapter(cmd);
                    //     DataTable dt = new DataTable();
                    //     sda.Fill(dt);

                    //     // Verifica y cuenta que existan filas en la base de datos
                    //     if(dt.Rows.Count == 1)
                    //     {
                    //         this.Hide();
                    //         if (dt.Rows[0][1].ToString() == "Admin");  //Verifica si el usuasio que se esta autenticando es "Usuario o Admin"
                    //         {     
                    //             new Admin(dt.Rows[0][0].ToString()).Show(); //Muestra la ventana admin en caso de ser "Admin"
                    //         } 
                    //         else if (dt.Rows[0][1].ToString () == "Usuario") //Verifica si el usuasio que se esta autenticando es "Usuario o Admin"
                    //         {
                    //             new Usuario (dt.Rows[0][0].ToString()).Show(); //Muestra la ventana usuario en caso de ser "Usuario"
                    //         }          
                    //     }
                    //     else
                    //     {
                    //         MessageBox.Show("Usuario o Contraseña Incorrecta");
                    //     }
                    // }
                    // catch(Exception e)
                    // {
                    //     MessageBox.Show(e.Message);
                    // }
                    // finally
                    // {
                    //     // Cierra la conección a la Base de Datos
                    //     con.Close();
                    // }