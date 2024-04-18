using ApostolicDataSystem.App_Class;
using ApostolicDataSystem.Models;
using System;
using System.Data;
using System.Web.UI;

namespace ApostolicDataSystem.Mantenimiento.transacciones
{
    public partial class tipoTransacciones : System.Web.UI.Page
    {
        sweetAlertInfo _sweetAlertaInfo = new sweetAlertInfo();

        protected void Page_Load(object sender, EventArgs e)
        {
            parametrosUrlInfo parametros = new parametrosUrlInfo();
            parametrosUrl parametrosUrl = new parametrosUrl();
            procesosSQL sql = new procesosSQL();
            procesoHTML html = new procesoHTML();

            parametros = parametrosUrl.getParametrosUrl(Request.QueryString);
            DataSet dsTransacciones = sql.getListadoTipoTransacciones();

            if (parametros.M == null)
                parametros.M = string.Empty;
            if (parametros.T == null)
                parametros.T = string.Empty;
            
            if (parametros.C != 0)
            {
                hdfProceso.Value = "UPDATE";
                hdfCodigo.Value = parametros.C.ToString();

                if (parametros.T.Equals("I"))
                {
                    string descripcion = dsTransacciones.Tables[0].Compute("Max(descripcion)", "codigo=" + parametros.C.ToString()).ToString();

                    txtCodigo.Value = parametros.C.ToString();
                    txtDescripcion.Value = descripcion;
                }
                else
                {
                    string descripcion = dsTransacciones.Tables[1].Compute("Max(descripcion)", "codigo=" + parametros.C.ToString()).ToString();

                    txtCodigo.Value = parametros.C.ToString();
                    txtDescripcion.Value = descripcion;
                }
            }
            else
                hdfProceso.Value = "INSERT";

            if (parametros.T.Equals("I"))
                lblTituloModal.Text = "Tipo de Tansacción Ingreso";
            else
                lblTituloModal.Text = "Tipo de Tansacción Egreso";
            
            if (dsTransacciones.Tables.Count >= 2)
            {
                ltlTablaIngresos.Text = html.getDataGridView(dsTransacciones.Tables[0], "tblIngresos", false).HtmlDataTable;

                ltlTablaEgresos.Text = html.getDataGridView(dsTransacciones.Tables[1], "tblEgresos", false).HtmlDataTable;
            }

            if (parametros.M.Equals("T"))
                muestraModal();
        }

        private void muestraModal()
        {
            string javaScript = "$( document ).ready(function() {" +
                                "    $('#mdEdicionData').modal('toggle')" +
                                "});";

            ScriptManager.RegisterStartupScript(this, this.GetType(), "script", javaScript, true);
        }
    }
}