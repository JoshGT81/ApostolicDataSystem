using ApostolicDataSystem.App_Class;
using System;
using System.Data;

namespace ApostolicDataSystem.Mantenimiento.miembro
{
    public partial class listaMiembros : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            procesosSQL sql = new procesosSQL();
            procesoHTML html = new procesoHTML();

            DataSet dsEmpleados = dsEmpleados = sql.getListadoMiembrosActivos();

            if (dsEmpleados.Tables.Count > 0)
            {
                ltlTablaDinamica.Text = html.getDataGridView(dsEmpleados.Tables[0], "tblInformacion", false).HtmlDataTable;
            }
        }
    }
}