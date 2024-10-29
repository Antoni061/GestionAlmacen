using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace GestionAlmacen.views.almacen
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            fn_GenerarComboCliente();

        }
        private void fn_GenerarComboCliente()
        {
            Utilerias objUtilerias = new Utilerias();
            objUtilerias.sNombre = "hslcCliente";
            objUtilerias.sQuery = @"select es.iIdEstatus  AS sIdEstatus ,es.sEstatus as sEstatus from tEstatus as es";
            objUtilerias.fn_GeneraComboboxMultiple(objUtilerias);
            hdvComboCliente.InnerHtml = objUtilerias.sContenido;
        }
    }
}