using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System;
using System.Web.Services;
using System.Data.SqlClient;
using System.Configuration;

namespace GestionAlmacen
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        public class DatabaseHelper
        {
            private string connectionString;

            public DatabaseHelper()
            {
                // Obtener la cadena de conexión del Web.config
                connectionString = ConfigurationManager.ConnectionStrings["DB_GestionDeAlmacenConnectionString"].ConnectionString;
            }

            public bool RegistrarUsuario(string nombre, int edad, string telefono, string genero, string correo, string contrasena)
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    string query = "INSERT INTO tUsuarios (Nombre, Edad, Telefono, Genero, Correo, Contrasena) VALUES (@Nombre, @Edad, @Telefono, @Genero, @Correo, @Contrasena)";

                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@Nombre", nombre);
                    cmd.Parameters.AddWithValue("@Edad", edad);
                    cmd.Parameters.AddWithValue("@Telefono", telefono);
                    cmd.Parameters.AddWithValue("@Genero", genero);
                    cmd.Parameters.AddWithValue("@Correo", correo);
                    cmd.Parameters.AddWithValue("@Contrasena", contrasena); // Asegúrate de encriptar la contraseña en la BD

                    try
                    {
                        conn.Open();
                        int result = cmd.ExecuteNonQuery();
                        return result > 0;
                    }
                    catch (Exception ex)
                    {
                        // Manejar la excepción
                        Console.WriteLine(ex.Message);
                        return false;
                    }
                }
            }

            public bool IniciarSesion(string correo, string contrasena)
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    string query = "SELECT COUNT(1) FROM tUsuarios WHERE Correo = @Correo AND Contrasena = @Contrasena";

                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@Correo", correo);
                    cmd.Parameters.AddWithValue("@Contrasena", contrasena);

                    try
                    {
                        conn.Open();
                        int count = (int)cmd.ExecuteScalar();
                        return count > 0;
                    }
                    catch (Exception ex)
                    {
                        // Manejar la excepción
                        Console.WriteLine(ex.Message);
                        return false;
                    }
                }
            }
        }
    }
}