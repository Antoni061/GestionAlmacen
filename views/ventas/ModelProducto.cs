using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GestionAlmacen.views.ventas
{
    public class ModelProducto
    {
        public int iIdProducto { get; set; }
        public string sNombreProducto { get; set; }
        public string sDescripcion { get; set; }
        public int iPrecio { get; set; }
        public int iCantExistencia { get; set; }
        public string sImagenUrl { get; set; }
        public string sImagenHover { get; set; }

    }
}