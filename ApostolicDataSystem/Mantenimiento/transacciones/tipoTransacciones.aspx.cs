using ApostolicDataSystem.App_Class;
using ApostolicDataSystem.Models;
using System;
using System.Collections.Generic;
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
            string proceso = string.Empty;

            if (parametros.M == null)
                parametros.M = string.Empty;
            if (parametros.T == null)
                parametros.T = string.Empty;

            if (!IsPostBack)
            {
                if (parametros.C != 0)
                {
                    hdfProceso.Value = "UPDATE";
                    hdfCodigo.Value = parametros.C.ToString();
                    
                    proceso = "Edición ";

                    if (parametros.T.Equals("I"))
                    {
                        string descripcion = dsTransacciones.Tables[0].Compute("Max(Descripción)", "Código =" + parametros.C.ToString()).ToString();

                        txtCodigo.Value = parametros.C.ToString();
                        txtDescripcion.Value = descripcion;                        
                    }
                    else
                    {
                        string descripcion = dsTransacciones.Tables[1].Compute("Max(Descripción)", "Código =" + parametros.C.ToString()).ToString();

                        txtCodigo.Value = parametros.C.ToString();
                        txtDescripcion.Value = descripcion;
                    }
                }
                else
                {
                    hdfProceso.Value = "INSERT";
                    proceso = "Nuevo ";
                }
                if (parametros.T.Equals("I"))
                {
                    lblTituloModal.Text = proceso + "Tipo de Transacción Ingreso";
                    hdfTipoProceso.Value = "I";
                }
                else
                {
                    lblTituloModal.Text = proceso + "Tipo de Transacción Egreso";
                    hdfTipoProceso.Value = "E";
                }

                if (dsTransacciones.Tables.Count >= 2)
                {
                    ltlTablaIngresos.Text = html.getDataGridView(dsTransacciones.Tables[0], "tblIngresos", false).HtmlDataTable;

                    ltlTablaEgresos.Text = html.getDataGridView(dsTransacciones.Tables[1], "tblEgresos", false).HtmlDataTable;
                }

                if (parametros.M.Equals("T"))
                    muestraModal();
            }
        }

        private void muestraModal()
        {
            txtDescripcion.Focus();

            string javaScript = "$(document).ready(function() {" +
                                "    $('#mdEdicionData').modal('toggle')" +
                                "});";

            ScriptManager.RegisterStartupScript(this, this.GetType(), "script", javaScript, true);
        }

        protected void btnGuardar_ServerClick(object sender, EventArgs e)
        {
            sweetAlert alert = new sweetAlert();
            procesosSQL sql = new procesosSQL();

            if (!string.IsNullOrWhiteSpace(txtDescripcion.Value))
            {
                try
                {
                    int _indexParametro = 0;
                    List<parametrosEventosInfo> parametros = new List<parametrosEventosInfo>();

                    if (hdfProceso.Value.Equals("UPDATE"))
                        parametros.Add(new parametrosEventosInfo(_indexParametro++, _indexParametro, "tipo", "U", "U"));
                    else
                        parametros.Add(new parametrosEventosInfo(_indexParametro++, _indexParametro, "tipo", "I", "I"));

                    parametros.Add(new parametrosEventosInfo(_indexParametro++, _indexParametro, "tipoTransaccion", hdfTipoProceso.Value, hdfTipoProceso.Value));
                    parametros.Add(new parametrosEventosInfo(_indexParametro++, _indexParametro, "codigoTransaccion", (hdfCodigo.Value.Equals("") ? "0" : hdfCodigo.Value), (hdfCodigo.Value.Equals("") ? "0" : hdfCodigo.Value)));
                    parametros.Add(new parametrosEventosInfo(_indexParametro++, _indexParametro, "descripcionTransaccion", txtDescripcion.Value, txtDescripcion.Value));
                    parametros.Add(new parametrosEventosInfo(_indexParametro++, _indexParametro, "estatus", (chkEstatus.Checked ? "A" : "I"), (chkEstatus.Checked ? "A" : "I")));

                    DataSet dsResultado = sql.guardaTipoTransaccion(parametros);
                    DataRow drResultado = dsResultado.Tables[0].Rows[0];

                    if (drResultado["codigo"].ToString().Equals("0"))
                    {
                        _sweetAlertaInfo.TipoResultado = "success";
                        _sweetAlertaInfo.TituloResultado = "Registro Guardado";
                        _sweetAlertaInfo.CuerpoResultado = drResultado["mensaje"].ToString();
                        _sweetAlertaInfo.UrlRedirect = ("../../Mantenimiento/transacciones/tipoTransacciones.aspx");

                        alert.showSweetAlert(_sweetAlertaInfo);
                    }
                    else
                    {
                        _sweetAlertaInfo.TipoResultado = "error";
                        _sweetAlertaInfo.TituloResultado = "Error";
                        _sweetAlertaInfo.CuerpoResultado = drResultado["mensaje"].ToString();

                        alert.showSweetAlert(_sweetAlertaInfo);
                    }
                }
                catch (Exception ex)
                {
                    _sweetAlertaInfo.TipoResultado = "error";
                    _sweetAlertaInfo.TituloResultado = "Error";
                    _sweetAlertaInfo.CuerpoResultado = "Ocurrió un error a intentar guardar la información.";
                    _sweetAlertaInfo.PieResultado = ex.Message + " ------------> " + ex.StackTrace;
                    alert.showSweetAlert(_sweetAlertaInfo);
                }
            }
            else
            {
                _sweetAlertaInfo.TipoResultado = "warning";
                _sweetAlertaInfo.TituloResultado = "Inconveniente al guardar";
                _sweetAlertaInfo.CuerpoResultado = "La descripción no puede quedar en blanco";

                alert.showSweetAlert(_sweetAlertaInfo);
            }
        }

        private void validaControl(Control objeto, string funcion)
        {
            string javaScript = $"{funcion}({objeto.ClientID});";
            ScriptManager.RegisterStartupScript(this, this.GetType(), "script", javaScript, true);
        }

        protected void btnGuardarDato_Click(object sender, EventArgs e)
        {
            sweetAlert alert = new sweetAlert();
            procesosSQL sql = new procesosSQL();

            if (!string.IsNullOrWhiteSpace(txtDescripcion.Value))
            {
                try
                {
                    int _indexParametro = 0;
                    List<parametrosEventosInfo> parametros = new List<parametrosEventosInfo>();

                    if (hdfProceso.Value.Equals("UPDATE"))
                        parametros.Add(new parametrosEventosInfo(_indexParametro++, _indexParametro, "tipo", "U", "U"));
                    else
                        parametros.Add(new parametrosEventosInfo(_indexParametro++, _indexParametro, "tipo", "I", "I"));

                    parametros.Add(new parametrosEventosInfo(_indexParametro++, _indexParametro, "tipoTransaccion", hdfTipoProceso.Value, hdfTipoProceso.Value));
                    parametros.Add(new parametrosEventosInfo(_indexParametro++, _indexParametro, "codigoTransaccion", (hdfCodigo.Value.Equals("") ? "0" : hdfCodigo.Value), (hdfCodigo.Value.Equals("") ? "0" : hdfCodigo.Value)));
                    parametros.Add(new parametrosEventosInfo(_indexParametro++, _indexParametro, "descripcionTransaccion", txtDescripcion.Value, txtDescripcion.Value));
                    parametros.Add(new parametrosEventosInfo(_indexParametro++, _indexParametro, "estatus", (chkEstatus.Checked ? "A" : "I"), (chkEstatus.Checked ? "A" : "I")));

                    DataSet dsResultado = sql.guardaTipoTransaccion(parametros);
                    DataRow drResultado = dsResultado.Tables[0].Rows[0];

                    if (drResultado["codigo"].ToString().Equals("0"))
                    {
                        _sweetAlertaInfo.TipoResultado = "success";
                        _sweetAlertaInfo.TituloResultado = "Registro Guardado";
                        _sweetAlertaInfo.CuerpoResultado = drResultado["mensaje"].ToString();
                        _sweetAlertaInfo.UrlRedirect = ("../../Mantenimiento/transacciones/tipoTransacciones.aspx");

                        alert.showSweetAlert(_sweetAlertaInfo);
                    }
                    else
                    {
                        _sweetAlertaInfo.TipoResultado = "error";
                        _sweetAlertaInfo.TituloResultado = "Error";
                        _sweetAlertaInfo.CuerpoResultado = drResultado["mensaje"].ToString();

                        alert.showSweetAlert(_sweetAlertaInfo);
                    }
                }
                catch (Exception ex)
                {
                    _sweetAlertaInfo.TipoResultado = "error";
                    _sweetAlertaInfo.TituloResultado = "Error";
                    _sweetAlertaInfo.CuerpoResultado = "Ocurrió un error a intentar guardar la información.";
                    _sweetAlertaInfo.PieResultado = ex.Message + " ------------> " + ex.StackTrace;
                    alert.showSweetAlert(_sweetAlertaInfo);
                }
            }
            else
            {
                _sweetAlertaInfo.TipoResultado = "warning";
                _sweetAlertaInfo.TituloResultado = "Inconveniente al guardar";
                _sweetAlertaInfo.CuerpoResultado = "La descripción no puede quedar en blanco";

                alert.showSweetAlert(_sweetAlertaInfo);
            }
        }
    }
}