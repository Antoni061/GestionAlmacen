using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Script.Serialization;
using System.Xml;

/// <summary>
/// Descripción breve de Utilerias
/// </summary>
public class Utilerias
{
    /// <summary>
    /// Se declaran los atributos que utilizará la clase
    /// </summary>

    /// GENERAL
    public string sNombre { get; set; }
    public string sQuery { get; set; }
    public string sQueryHijos { get; set; }
    public string sClases { get; set; }
    public string sContenido { get; set; }
    public string sAtributos { get; set; }

    /// TABLA
    public string[] arrColumnasFiltro { get; set; }
    public string[] arrColumnasSinFiltro { get; set; }

    public Utilerias()
    {
        //
        // TODO: Agregar aquí la lógica del constructor
        //
    }

    #region fn_GeneraEstructuraTabla
    ///<sumary>
    ///Método para crear estructura de tabla
    ///</sumary>
    ///<param name="objUtileria"></param>
    public void fn_GeneraEstructuraTabla(Utilerias objUtileria)
    {
        objUtileria.sContenido = "<button type=\"button\" onclick=\"fn_GeneraReporte('" + objUtileria.sNombre + "',true);\" class=\"btn btn_gray btn-sm input-md\"> <span class=\"fa fa-file-excel-o\"></span> Generar Reporte Listado</button><br>";
        //Se abre la tabla
        objUtileria.sContenido += "<table id='" + objUtileria.sNombre + "' class='" + objUtileria.sClases + "'>";
        //Se abre en encabezado
        objUtileria.sContenido += "<thead style='display:table-row-group;'></tr>";
        //Se verifica que el arreglo no este vacío
        if (objUtileria.arrColumnasFiltro != null)
        {
            ///Ciclo para agregar columna al header con filtro
            foreach (string sColumna in objUtileria.arrColumnasFiltro)
            {
                //Se agrega columna
                objUtileria.sContenido += "<th>" + sColumna + "</th>";
            }
        }
        //Se verifica que el arreglo no este vacío
        if (objUtileria.arrColumnasSinFiltro != null)
        {
            ///Ciclo para agregar columna al header sin filtro
            foreach (string sColumna in objUtileria.arrColumnasSinFiltro)
            {
                //Se agrega columna
                objUtileria.sContenido += "<th class=\"noExl\">" + sColumna + "</th>";
            }
        }
        //Se cierra en encabezado
        objUtileria.sContenido += "</tr></thead>";
        //se abre footer de la tabla
        objUtileria.sContenido += "<tfoot style='display: table-header-group;'><tr>";
        //Se verifica que el arreglo no este vacío
        if (objUtileria.arrColumnasFiltro != null)
        {
            ///Ciclo para agregar columna de busqueda a footer
            for (int i = 0; i < arrColumnasFiltro.Length; i++)
            {
                if (arrColumnasFiltro[i] == "Pagar" || arrColumnasFiltro[i] == "Grupo")
                {
                    //Se agrega filtro
                    objUtileria.sContenido += "<td><div class='col-lg-12 col-md-12 col-sm-12 col-xs-12 text-center'><b id='hbMessage' style='color: darkslategrey;font-size: 11px;'>Seleccionar todos</b><br /><input type='checkbox' name='hcbxSeleccionar' onclick='javascript:fn_SeleccionarTodo();' class='' /></div></td>";
                }
                else
                {
                    //Se agrega filtro
                    objUtileria.sContenido += "<td><input id='" + arrColumnasFiltro[i].Replace(".", "").Replace(" ", "") + "' type='text' style='width: 100%;' class='form-control input-sm' /></td>";
                }
            }
        }
        //Se verifica que el arreglo no este vacío
        if (objUtileria.arrColumnasSinFiltro != null)
        {
            for (int i = 0; i < arrColumnasSinFiltro.Length; i++)
            {
                //No se agrega filtro
                objUtileria.sContenido += "<td></td>";
            }
        }
        //se cierra la tabla
        objUtileria.sContenido += "</tr></tfoot><tbody></tbody></table>";
        //Se cierra la tabla
        objUtileria.sContenido += "</table>";
    }
    #endregion

    #region fn_GeneraTabla
    /// <summary>
    /// Método para generar una tabla html a partir de un datatable
    /// </summary>
    /// <param name="objUtileria"></param>
    /// <param name="dt_tabla"></param>
    [Obsolete("Para grandes cantidades de datos se vuelve lento, reemplazado por metodo con StringBuilder")]
    public void fn_GeneraTabla_(Utilerias objUtileria, DataTable dt_tabla)
    {
        //Se abre la tabla
        objUtileria.sContenido = "<table id='" + objUtileria.sNombre + "' class='" + objUtileria.sClases + " table-responsive'>";
        //Se abre en encabezado
        objUtileria.sContenido += "<thead style='display:table-row-group;'></tr>";
        //Se verifica que el arreglo no este vacío
        if (objUtileria.arrColumnasFiltro != null)
        {
            ///Ciclo para agregar columna al header con filtro
            foreach (string sColumna in objUtileria.arrColumnasFiltro)
            {
                //Se agrega columna
                objUtileria.sContenido += "<th>" + sColumna + "</th>";
            }
        }
        //Se verifica que el arreglo no este vacío
        if (objUtileria.arrColumnasSinFiltro != null)
        {
            ///Ciclo para agregar columna al header sin filtro
            foreach (string sColumna in objUtileria.arrColumnasSinFiltro)
            {
                //Se agrega columna
                objUtileria.sContenido += "<th>" + sColumna + "</th>";
            }
        }
        //Se cierra en encabezado
        objUtileria.sContenido += "</tr></thead>";
        //se abre footer de la tabla
        objUtileria.sContenido += "<tfoot style='display: table-header-group;'><tr>";
        //Se verifica que el arreglo no este vacío
        if (objUtileria.arrColumnasFiltro != null)
        {
            ///Ciclo para agregar columna de busqueda a footer
            for (int i = 0; i < arrColumnasFiltro.Length; i++)
            {
                //Se agrega filtro
                objUtileria.sContenido += "<td><input type='text' style='width: 100%;' class='form-control input-sm' /></td>";
            }
        }
        //Se verifica que el arreglo no este vacío
        if (objUtileria.arrColumnasSinFiltro != null)
        {
            for (int i = 0; i < arrColumnasSinFiltro.Length; i++)
            {
                //No se agrega filtro
                objUtileria.sContenido += "<td></td>";
            }
        }
        //se cierra la tabla
        objUtileria.sContenido += "</tr></tfoot><tbody>";

        foreach (DataRow row in dt_tabla.Rows)
        {
            objUtileria.sContenido += "<tr>";
            for (int i = 0; i < objUtileria.arrColumnasFiltro.Count() + objUtileria.arrColumnasSinFiltro.Count(); i++)
            {
                objUtileria.sContenido += "<td>";
                objUtileria.sContenido += row[i].ToString();
                objUtileria.sContenido += "</td>";
            }
            objUtileria.sContenido += "</tr>";
        }

        objUtileria.sContenido += "</tbody></table>";
        //Se cierra la tabla
        objUtileria.sContenido += "</table>";
    }

    /// <summary>
    /// Método para generar una tabla html a partir de un datatable
    /// </summary>
    /// <param name="objUtileria"></param>
    /// <param name="dt_tabla"></param>
    public void fn_GeneraTabla(Utilerias objUtileria, DataTable dt_tabla)
    {
        StringBuilder oStringBuilder = new StringBuilder();
        //Se abre la tabla
        oStringBuilder.Append("<table id='");
        oStringBuilder.Append(objUtileria.sNombre);
        oStringBuilder.Append("' class='");
        oStringBuilder.Append(objUtileria.sClases);
        oStringBuilder.Append(" table-responsive'>");
        //Se abre en encabezado
        oStringBuilder.Append("<thead style='display:table-row-group;'></tr>");
        //Se verifica que el arreglo no este vacío
        if (objUtileria.arrColumnasFiltro != null)
        {
            ///Ciclo para agregar columna al header con filtro
            foreach (string sColumna in objUtileria.arrColumnasFiltro)
            {
                //Se agrega columna
                oStringBuilder.Append("<th>");
                oStringBuilder.Append(sColumna);
                oStringBuilder.Append("</th>");
            }
        }
        //Se verifica que el arreglo no este vacío
        if (objUtileria.arrColumnasSinFiltro != null)
        {
            ///Ciclo para agregar columna al header sin filtro
            foreach (string sColumna in objUtileria.arrColumnasSinFiltro)
            {
                //Se agrega columna
                oStringBuilder.Append("<th>");
                oStringBuilder.Append(sColumna);
                oStringBuilder.Append("</th>");
            }
        }
        //Se cierra en encabezado
        oStringBuilder.Append("</tr></thead>");
        //se abre footer de la tabla
        oStringBuilder.Append("<tfoot style='display: table-header-group;'><tr>");
        //Se verifica que el arreglo no este vacío
        if (objUtileria.arrColumnasFiltro != null)
        {
            ///Ciclo para agregar columna de busqueda a footer
            for (int i = 0; i < arrColumnasFiltro.Length; i++)
            {
                //Se agrega filtro
                oStringBuilder.Append("<td><input type='text' style='width: 100%;' class='form-control input-sm' /></td>");
            }
        }
        //Se verifica que el arreglo no este vacío
        if (objUtileria.arrColumnasSinFiltro != null)
        {
            for (int i = 0; i < arrColumnasSinFiltro.Length; i++)
            {
                //No se agrega filtro
                oStringBuilder.Append("<td></td>");
            }
        }
        //se cierra la tabla
        oStringBuilder.Append("</tr></tfoot><tbody>");

        foreach (DataRow row in dt_tabla.Rows)
        {
            oStringBuilder.Append("<tr>");
            for (int i = 0; i < objUtileria.arrColumnasFiltro.Count() + objUtileria.arrColumnasSinFiltro.Count(); i++)
            {
                oStringBuilder.Append("<td>");
                oStringBuilder.Append(row[i].ToString());
                oStringBuilder.Append("</td>");
            }
            oStringBuilder.Append("</tr>");
        }
        oStringBuilder.Append("</tbody></table>");
        //Se cierra la tabla
        oStringBuilder.Append("</table>");
        objUtileria.sContenido = oStringBuilder.ToString();
    }

    #endregion

    #region fn_GeneraCombobox
    ///<sumary>
    ///Método para crear estructura de combobox
    ///</sumary>
    ///<param name="objUtileria"></param>
    public void fn_GeneraCombobox(Utilerias objUtileria)
    {
        //Se crea la variable para almacenar datos
        DataSet dsDatos;
        //Se instancia la clase conexión
        Conexion objConexion = new Conexion();
        //Se ejecuta la consulta para obtener los datos
        dsDatos = objConexion.ejecutarConsultaRegistroMultiplesDataSet(objUtileria.sQuery, objUtileria.sNombre);
        //Se crea select
        objUtileria.sContenido += "<select id='" + objUtileria.sNombre + "' name='" + objUtileria.sNombre + "' data-width='100%' data-live-search='true' title='' class='selectpicker " + objUtileria.sClases + "'>";
        //Se verifica que se tengan datos
        if (dsDatos.Tables[objUtileria.sNombre].Rows.Count > 0)
        {
            objUtileria.sContenido += "<option value='' aria-selected='false'></option>";
            foreach (DataRow drRegistro in dsDatos.Tables[objUtileria.sNombre].Rows)
            {
                //Se crea el registro
                objUtileria.sContenido += "<option value='" + drRegistro[0].ToString() + "'>" + drRegistro[1].ToString() + "</option>";
            }
        }
        else
        {
            //Se crea registro vacío
            objUtileria.sContenido += "";
        }
        //Se cierra select
        objUtileria.sContenido += "</select>";
    }
    #endregion

    #region fn_GeneraComboboxVacio
    /// <summary>
    /// Método para crear estructura de combobox vacío 
    /// </summary>
    /// <param name="objUtileria"></param>
    public void fn_GeneraComboboxVacio(Utilerias objUtileria)
    {
        //Se crea select
        objUtileria.sContenido += "<select id='" + objUtileria.sNombre + "' name='" + objUtileria.sNombre + "' data-width='100%' data-live-search='true' title='' class='selectpicker " + objUtileria.sClases + "'>";
        //se crea una opción por default
        objUtileria.sContenido += "<option value='' aria-selected='false'></option>";
        //Se cierra select
        objUtileria.sContenido += "</select>";
    }
    #endregion

    #region fn_GeneraOpcionesCombobox
    /// <summary>
    /// Método para generar opciones para un combobox
    /// </summary>
    /// <param name="objUtileria"></param>
    public void fn_GeneraOpcionesCombobox(Utilerias objUtileria)
    {
        //Se crea la variable para almacenar datos
        DataSet dsDatos;
        //Se instancia la clase conexión
        Conexion objConexion = new Conexion();
        //Se ejecuta la consulta para obtener los datos
        dsDatos = objConexion.ejecutarConsultaRegistroMultiplesDataSet(objUtileria.sQuery, objUtileria.sNombre);
        //Se verifica que se tengan datos
        if (dsDatos.Tables[objUtileria.sNombre].Rows.Count > 0)
        {
            foreach (DataRow drRegistro in dsDatos.Tables[objUtileria.sNombre].Rows)
            {
                //Se crea el registro
                objUtileria.sContenido += "<option value='" + drRegistro[0].ToString() + "'>" + drRegistro[1].ToString() + "</option>";
            }
        }
        else
        {
            //Se crea registro vacío
            objUtileria.sContenido += "";
        }
    }
    #endregion

    #region fn_GeneraComboboxMultiple
    ///<sumary>
    ///Método para crear estructura de combobox
    ///</sumary>
    ///<param name="objUtileria"></param>
    public void fn_GeneraComboboxMultiple(Utilerias objUtileria)
    {
        //Se crea la variable para almacenar datos
        DataSet dsDatos;
        //Se instancia la clase conexión
        Conexion objConexion = new Conexion();
        //Se ejecuta la consulta para obtener los datos
        dsDatos = objConexion.ejecutarConsultaRegistroMultiplesDataSet(objUtileria.sQuery, objUtileria.sNombre);
        //Se crea select
        objUtileria.sContenido += "<select id='" + objUtileria.sNombre + "' name='" + objUtileria.sNombre + "' data-width='100%' data-live-search='true' title='' multiple class='selectpicker " + objUtileria.sClases + "'>";
        //Se verifica que se tengan datos
        if (dsDatos.Tables[objUtileria.sNombre].Rows.Count > 0)
        {
            foreach (DataRow drRegistro in dsDatos.Tables[objUtileria.sNombre].Rows)
            {
                //Se crea el registro
                objUtileria.sContenido += "<option value='" + drRegistro[0].ToString() + "'>" + drRegistro[1].ToString() + "</option>";
            }
        }
        else
        {
            //Se crea registro vacío
            objUtileria.sContenido += "";
        }
        //Se cierra select
        objUtileria.sContenido += "</select>";
    }
    #endregion

    public void fn_GeneraCheckbox(Utilerias objUtileria)
    {
        //Se crea la variable para almacenar datos
        DataSet dsDatos;
        //Se instancia la clase conexión
        Conexion objConexion = new Conexion();
        //Se ejecuta la consulta para obtener los datos
        dsDatos = objConexion.ejecutarConsultaRegistroMultiplesDataSet(objUtileria.sQuery, objUtileria.sNombre);
        //se crea chec
        objUtileria.sContenido += "<div id='" + objUtileria.sNombre + "' class='checkbox checkbox-success col-lg-12 col-md-12 col-sm-12 col-xs-12'>";
        //Se verifica que se tengan datos
        if (dsDatos.Tables[objUtileria.sNombre].Rows.Count > 0)
        {
            foreach (DataRow drRegistro in dsDatos.Tables[objUtileria.sNombre].Rows)
            {
                //Se crea el registro
                objUtileria.sContenido += "<div class='col-lg-6 col-md-6 col-sm-6 col-xs-6'>" +
                                            "<input type='checkbox' id='" + objUtileria.sNombre + drRegistro[0].ToString() + "' name='" + objUtileria.sNombre + "' value='" + drRegistro[0].ToString() + "'>" +
                                            "<label for='" + objUtileria.sNombre + drRegistro[0].ToString() + "' class='form-label'>" + drRegistro[1].ToString() + "</label>" +
                                          "</div>";
            }
        }
        else
        {
            //Se crea registro vacío
            objUtileria.sContenido += "";
        }
        //Se cierra select
        objUtileria.sContenido += "</div>";
    }

    #region fn_GeneraComboboxGroups
    ///<sumary>
    ///Método para crear estructura de combobox groups
    ///</sumary>
    ///<param name="objUtileria"></param>
    public void fn_GeneraComboboxGroups(Utilerias objUtileria)
    {
        //Se crea la variable para almacenar datos
        DataSet dsDatos, dsDatos2;
        //Se instancia la clase conexión
        Conexion objConexion = new Conexion();
        //Se ejecuta la consulta para obtener los datos
        dsDatos = objConexion.ejecutarConsultaRegistroMultiplesDataSet(objUtileria.sQuery, objUtileria.sNombre);
        //Se crea select
        objUtileria.sContenido += "<select id='" + objUtileria.sNombre + "' name='" + objUtileria.sNombre + "' data-width='100%' data-live-search='true' title='' class='selectpicker " + objUtileria.sClases + "'>";
        //Se verifica que se tengan datos
        if (dsDatos.Tables[objUtileria.sNombre].Rows.Count > 0)
        {
            //Se crea option vacío
            objUtileria.sContenido += "<option value=''></option>";
            foreach (DataRow drRegistro in dsDatos.Tables[objUtileria.sNombre].Rows)
            {
                //Se abre option group
                objUtileria.sContenido += "<optgroup label='" + drRegistro[1].ToString() + "'>";

                //Se ejecuta la consulta para obtener los datos
                dsDatos2 = objConexion.ejecutarConsultaRegistroMultiplesDataSet(objUtileria.sQueryHijos.Replace("@IdPadre", drRegistro["idMenu"].ToString()), objUtileria.sNombre);
                //Se verifica que se tengan datos
                if (dsDatos2.Tables[objUtileria.sNombre].Rows.Count > 0)
                {
                    foreach (DataRow drRegistro2 in dsDatos2.Tables[objUtileria.sNombre].Rows)
                    {
                        //Se crea el registro
                        objUtileria.sContenido += "<option value='" + drRegistro2[0].ToString() + "'>" + drRegistro2[1].ToString() + "</option>";
                    }
                }

                //Se cierra option group
                objUtileria.sContenido += "</optgroup >";
            }
        }
        else
        {
            //Se crea registro vacío
            objUtileria.sContenido += "";
        }
        //Se cierra select
        objUtileria.sContenido += "</select>";
    }
    #endregion

    #region fn_GeneraRadiobuttons
    ///<sumary>
    ///Método para crear estructura de radiobuttons
    ///</sumary>
    ///<param name="objUtileria"></param>
    public void fn_GeneraRadiobuttons(Utilerias objUtileria)
    {
        //Se crea la variable para almacenar datos
        DataSet dsDatos;
        //Se declara variable para almacenar checked
        string sChecked = "";
        //Se instancia la clase conexión
        Conexion objConexion = new Conexion();
        //Se ejecuta la consulta para obtener los embalajes
        dsDatos = objConexion.ejecutarConsultaRegistroMultiplesDataSet(objUtileria.sQuery, objUtileria.sNombre);
        //Se verifica que se tengan embalajes asignados
        if (dsDatos.Tables[objUtileria.sNombre].Rows.Count > 0)
        {
            //Se crea contenedor radio
            objUtileria.sContenido += "<div class='container-fluid'><div class='row'>";
            foreach (DataRow registro in dsDatos.Tables[objUtileria.sNombre].Rows)
            {
                //Se verifica instancia actual
                sChecked = registro["iChecked"].ToString() == "1" ? "checked" : "";
                //Se abre div radio
                objUtileria.sContenido += "<div class='col-lg-6'><div class='checkboxAzul contenedorAzul'>";
                //Se crea el radio
                objUtileria.sContenido += "<input type='radio' class='estiloRadioAnimadoAzul' name='" + objUtileria.sNombre + "' id='hrbn-" + registro[0].ToString() + "' value='" + registro[0].ToString() + "' " + sChecked + " " + sAtributos + " />" +
                                            "<label for='hrbn-" + registro[0].ToString() + "'>" +
                                                registro[1].ToString() +
                                            "</label>";
                //Se cierra div radio
                objUtileria.sContenido += "</div></div>";
            }
            //Se cierra contenedor radio
            objUtileria.sContenido += "</div></div>";
        }
        else
        {
            objUtileria.sContenido = "<div></div>";
        }
    }
    #endregion

    #region fn_GeneraDataTable
    /// <summary>
    /// genera un datatable
    /// </summary>
    /// <param name="dt_table"></param>
    /// <param name="columnas"></param>
    public void fn_GeneraDataTable(DataTable dt_table, string[] columnas)
    {
        for (int i = 0; i < columnas.Length; i++)
        {
            dt_table.Columns.Add(columnas[i].ToString(), typeof(string));
        }
    }
    #endregion

    public T fn_ConvertirClase<T>(Object objConvertir)
    {

        var serializer = new JavaScriptSerializer();
        var serializedResult = serializer.Serialize(objConvertir);
        T oConvertido = serializer.Deserialize<T>(serializedResult);

        return oConvertido;
    }

    public string fn_ContenidoConboxMotivo(Utilerias objUtileria)
    {

        //Se crea la variable para almacenar datos
        DataSet dsDatos;
        //Se instancia la clase conexión
        Conexion objConexion = new Conexion();
        //Se ejecuta la consulta para obtener los datos
        dsDatos = objConexion.ejecutarConsultaRegistroMultiplesDataSet(objUtileria.sQuery, objUtileria.sNombre);
        //Se verifica que se tengan datos
        if (dsDatos.Tables[objUtileria.sNombre].Rows.Count > 0)
        {
            foreach (DataRow drRegistro in dsDatos.Tables[objUtileria.sNombre].Rows)
            {
                //Se crea el registro
                objUtileria.sContenido += "<option value='" + drRegistro[0].ToString() + "'>" + drRegistro[1].ToString() + "</option>";
            }
        }
        else
        {
            //Se crea registro vacío
            objUtileria.sContenido += "";
        }
        return objUtileria.sContenido;
    }
    public void fn_GeneraEstructuraTablaConData(Utilerias objUtileria)
    {
        //objUtileria.sContenido = "<button type=\"button\" onclick=\"fn_GeneraReporte('" + objUtileria.sNombre + "',true);\" class=\"btn btn_gray btn-sm input-md\"> <span class=\"fa fa-file-excel-o\"></span> Generar Reporte Listado</button><br>";
        //Se abre la tabla
        objUtileria.sContenido += "<table id='" + objUtileria.sNombre + "' class='dataTable'>";
        //Se abre en encabezado
        //objUtileria.sContenido += "<thead style='display:table-row-group;'></tr>";
        objUtileria.sContenido += "<thead style='display:table-header-group;'> <tr>";
        if (objUtileria.arrColumnasFiltro != null)
        {
            ///Ciclo para agregar columna de busqueda a footer
            for (int i = 0; i < arrColumnasFiltro.Length; i++)
            {
                //Se agrega filtro
                objUtileria.sContenido += "<th class='filterhead'>" + arrColumnasFiltro[i].Replace(".", "").Replace(" ", "") + "</th>";
            }
        }
        objUtileria.sContenido += "</tr><tr>";
        ////Se verifica que el arreglo no este vacío
        if (objUtileria.arrColumnasFiltro != null)
        {
            ///Ciclo para agregar columna al header con filtro
            foreach (string sColumna in objUtileria.arrColumnasFiltro)
            {
                //Se agrega columna
                objUtileria.sContenido += "<th>" + sColumna + "</th>";
            }
        }

        objUtileria.sContenido += "</tr></thead>";
        //se abre footer de la tabla
        objUtileria.sContenido += "<tfoot style='display: table-header-group;'><tr>";

        //se cierra la tabla
        objUtileria.sContenido += "</tr></tfoot><tbody></tbody></table>";
        //Se cierra la tabla
        objUtileria.sContenido += "</table>";
    }
    public void fn_GeneraComboboxProcedimiento(Utilerias objUtileria, string[][] aParametros = null)
    {
        //Se crea la variable para almacenar datos
        DataSet dsDatos = new DataSet();
        //Se instancia la clase conexión
        Conexion objConexion = new Conexion();
        aParametros = aParametros ?? new string[][] { };
        //se genera el procedimiento
        string sRes = objConexion.generarSP(objUtileria.sQuery, 0);
        //se valida que se creo
        if (sRes == "1")
        {
            foreach (string[] dtFila in aParametros)
            {
                //Se obtiene el tipo de dato SQL para el campo
                SqlDbType sDbTipo = fn_ObtenerTipoDato(dtFila[1].ToString());
                objConexion.agregarParametroSP(dtFila[0].ToString(), sDbTipo, dtFila[2].ToString());
            }
            //se optiene la tabla con la informacion
            dsDatos = objConexion.ejecutarProcRegistroMultiplesDataSet(objUtileria.sNombre);
        }

        //Se crea select
        objUtileria.sContenido += "<select id='" + objUtileria.sNombre + "' name='" + objUtileria.sNombre + "' data-width='100%' data-live-search='true' title='' class='selectpicker " + objUtileria.sClases + "'>";
        //Se verifica que se tengan datos
        if (dsDatos.Tables[objUtileria.sNombre].Rows.Count > 0)
        {
            objUtileria.sContenido += "<option value='' aria-selected='false'></option>";
            foreach (DataRow drRegistro in dsDatos.Tables[objUtileria.sNombre].Rows)
            {
                //Se crea el registro
                objUtileria.sContenido += "<option value='" + drRegistro[0].ToString() + "'>" + drRegistro[1].ToString() + "</option>";
            }
        }
        else
        {
            //Se crea registro vacío
            objUtileria.sContenido += "";
        }
        //Se cierra select
        objUtileria.sContenido += "</select>";
    }
    private SqlDbType fn_ObtenerTipoDato(string sNombreTipo)
    {
        SqlDbType dbTipo;
        //Se valida que tipo de dato es el que se va a enviar
        switch (sNombreTipo)
        {
            case "text":
                dbTipo = SqlDbType.Text;
                break;
            case "date":
                dbTipo = SqlDbType.Date;
                break;
            case "tinyint":
                dbTipo = SqlDbType.TinyInt;
                break;
            case "smallint":
                dbTipo = SqlDbType.SmallInt;
                break;
            case "int":
                dbTipo = SqlDbType.Int;
                break;
            case "smalldatetime":
                dbTipo = SqlDbType.SmallDateTime;
                break;
            case "datetime":
                dbTipo = SqlDbType.DateTime;
                break;
            case "float":
                dbTipo = SqlDbType.Float;
                break;
            case "varchar":
                dbTipo = SqlDbType.VarChar;
                break;
            case "nvarchar":
                dbTipo = SqlDbType.NVarChar;
                break;
            case "nchar":
                dbTipo = SqlDbType.NChar;
                break;
            case "decimal":
                dbTipo = SqlDbType.Decimal;
                break;
            case "bigint":
                dbTipo = SqlDbType.BigInt;
                break;
            case "money":
                dbTipo = SqlDbType.Money;
                break;
            default:
                dbTipo = SqlDbType.VarChar;
                break;
        }
        return dbTipo;
    }
}