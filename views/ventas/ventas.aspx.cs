using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace GestionAlmacen.views.ventas
{
    public partial class ventas : System.Web.UI.Page
    {
        public List<ModelProducto> products = new List<ModelProducto>();
        private const int pageSize = 10;

        protected void Page_Load(object sender, EventArgs e)
        {
            LoadProducts(); // Cargar todos los productos al inicio
            BindProducts(1); // Cargar la primera página de productos
        }

        public void LoadProducts()
        {
            products = new List<ModelProducto>();

            string connectionString = ConfigurationManager.ConnectionStrings["MiConexionLocal"].ConnectionString;

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    string query = "SELECT p.iIdProducto, p.sNombreProducto, p.sDescripcion, p.iPrecio, p.iCantExistencia, " +
                                   "p.sImagenUrl, p.sImagenHoverUrl FROM tProductos p";
                    SqlCommand command = new SqlCommand(query, connection);
                    connection.Open();

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            ModelProducto product = new ModelProducto
                            {
                                iIdProducto = reader.GetInt32(0),
                                sNombreProducto = reader.GetString(1),
                                sDescripcion = reader.GetString(2),
                                iPrecio = reader.GetInt32(3),
                                iCantExistencia = reader.GetInt32(4),
                                sImagenUrl = reader.GetString(5),
                                sImagenHover = reader.GetString(6)
                            };
                            products.Add(product);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                // Aquí puedes registrar el error o mostrar un mensaje
                Console.WriteLine($"Error al cargar productos: {ex.Message}");
                // O manejarlo de otra forma, como mostrando un mensaje en la interfaz
            }
        }


        public void BindProducts(int pageNumber)
        {
            // Calcular el índice de inicio
            int startIndex = (pageNumber - 1) * pageSize;

            // Verificar que startIndex esté dentro de los límites
            if (startIndex < 0 || startIndex >= products.Count)
            {
                // Si no hay productos o el índice está fuera de rango, no hacer nada
                ProductsRepeater.DataSource = null;
                ProductsRepeater.DataBind();
                return; // Salir del método
            }

            // Obtener el rango de productos
            var pagedProducts = products.GetRange(startIndex, Math.Min(pageSize, products.Count - startIndex));

            // Enlazar los productos al Repeater
            ProductsRepeater.DataSource = pagedProducts;
            ProductsRepeater.DataBind();

            // Configurar la paginación
            int totalPages = (int)Math.Ceiling((double)products.Count / pageSize);
            BindPagination(totalPages, pageNumber);
        }

        public void BindPagination(int totalPages, int currentPage)
        {
            // Si no hay productos, ocultar la paginación
            if (totalPages <= 0)
            {
                PaginationRepeater.Visible = false; // Ocultar el control de paginación
                return;
            }

            var pages = new List<dynamic>();
            for (int i = 1; i <= totalPages; i++)
            {
                pages.Add(new { PageNumber = i });
            }

            PaginationRepeater.DataSource = pages;
            PaginationRepeater.DataBind();

            // Asegúrate de mostrar la paginación
            PaginationRepeater.Visible = true; // Asegurarse de que el control sea visible si hay productos
        }

        // Método para manejar el cambio de página
        public void PageLink_Command(object sender, CommandEventArgs e)
        {
            int pageNumber = Convert.ToInt32(e.CommandArgument);
            BindProducts(pageNumber);
        }
    }
}
