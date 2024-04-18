using ApostolicDataSystem.App_Class;
using System;
using System.Data;

namespace ApostolicDataSystem.Mantenimiento.usuario
{
    public partial class listaUsuarios : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            procesosSQL sql = new procesosSQL();
            procesoHTML html = new procesoHTML();

            DataSet dsEmpleados = dsEmpleados = sql.getListadoUsuariosActivos();

            if (dsEmpleados.Tables.Count > 0)
            {
                ltlTablaDinamica.Text = html.getDataGridView(dsEmpleados.Tables[0], "tblInformacion", false).HtmlDataTable;
            }
        }
    }
}