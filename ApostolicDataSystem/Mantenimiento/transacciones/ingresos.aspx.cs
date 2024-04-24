using ApostolicDataSystem.Models;
using ApostolicDataSystem.App_Class;
using System;
using System.Data;
using System.Collections.Generic;
using System.Web.UI;

namespace ApostolicDataSystem.Mantenimiento.transacciones
{
    public partial class ingresos : System.Web.UI.Page
    {
        sweetAlertInfo _sweetAlertaInfo = new sweetAlertInfo();

        protected void Page_Load(object sender, EventArgs e)
        {
            parametrosUrlInfo parametros = new parametrosUrlInfo();
            parametrosUrl parametrosUrl = new parametrosUrl();

            parametros = parametrosUrl.getParametrosUrl(Request.QueryString);

            if (!IsPostBack)
            {
                if (parametros.C != 0)
                    hdfProceso.Value = "UPDATE";
                else
                    hdfProceso.Value = "INSERT";

                DateTime fechaActual = DateTime.Now;

                txtFecha.Value = fechaActual.ToString("yyyy-MM-dd");

                cargarInformacionInicial(parametros.C.ToString());
            }
        }

        private void cargarInformacionInicial(string codigo)
        {
            procesosSQL sql = new procesosSQL();
            procesoHTML html = new procesoHTML();
            sweetAlert alert = new sweetAlert();

            try
            {
                int _indexParametro = 0;
                List<parametrosEventosInfo> parametros = new List<parametrosEventosInfo>();

                parametros.Add(new parametrosEventosInfo(_indexParametro++, _indexParametro, "tipoTransaccion", "I", "I"));
                parametros.Add(new parametrosEventosInfo(_indexParametro++, _indexParametro, "idTransaccion", codigo, codigo));

                DataSet dsTransaccion = sql.getCatalogosTransacciones(parametros);

                if (dsTransaccion.Tables.Count > 0)
                {
                    if (dsTransaccion.Tables[1].Rows.Count > 0)
                        ddlMiembro.Items.AddRange(html.getListadoCatalogo(dsTransaccion.Tables[1]));

                    if (dsTransaccion.Tables[2].Rows.Count > 0)
                        ddlTipoTransaccion.Items.AddRange(html.getListadoCatalogo(dsTransaccion.Tables[2]));

                    if (dsTransaccion.Tables[0].Rows.Count > 0)
                    {
                        DataRow drRegistro = dsTransaccion.Tables[0].Rows[0];

                        #region Resumen
                        int item = 0;
                        for (int i = 0; i < ddlMiembro.Items.Count; i++)
                        {
                            ddlMiembro.SelectedIndex = item;

                            if (ddlMiembro.Value != drRegistro["codigoMiembro"].ToString())
                                item++;
                        }

                        item = 0;
                        for (int i = 0; i < ddlTipoTransaccion.Items.Count; i++)
                        {
                            ddlTipoTransaccion.SelectedIndex = item;

                            if (ddlTipoTransaccion.Value != drRegistro["codigoTransaccion"].ToString())
                                item++;
                        }

                        string fecha = drRegistro["fecha"].ToString();

                        if (fecha.Length > 0)
                        {
                            DateTime fechaDate;

                            if (DateTime.TryParse(fecha, out fechaDate))
                                txtFecha.Value = fechaDate.ToString("yyyy-MM-dd");
                        }

                        txtConfirmación.Value = drRegistro["noConfirmacion"].ToString();
                        txtMonto.Value = drRegistro["monto"].ToString();

                        chkTransaccion.Checked = (drRegistro["estatus"].ToString().Equals("A") ? true : false);
                        #endregion
                    }                    
                }                                
            }
            catch (Exception ex)
            {
                _sweetAlertaInfo.TipoResultado = "error";
                _sweetAlertaInfo.TituloResultado = "Error";
                _sweetAlertaInfo.CuerpoResultado = "Ocurrió un error al obtener la información del usuario.";
                _sweetAlertaInfo.PieResultado = ex.Message + " " + ex.StackTrace;

                alert.showSweetAlert(_sweetAlertaInfo);
            }
        }

        protected void btnGuardar_ServerClick(object sender, EventArgs e)
        {
            sweetAlert alert = new sweetAlert();
            procesosSQL sql = new procesosSQL();

            if (validaInformacion())
            {
                try
                {
                    int _indexParametro = 0;
                    List<parametrosEventosInfo> parametros = new List<parametrosEventosInfo>();

                    if (hdfProceso.Value.Equals("UPDATE"))
                        parametros.Add(new parametrosEventosInfo(_indexParametro++, _indexParametro, "tipo", "U", "U"));
                    else
                        parametros.Add(new parametrosEventosInfo(_indexParametro++, _indexParametro, "tipo", "I", "I"));

                    parametros.Add(new parametrosEventosInfo(_indexParametro++, _indexParametro, "idTransaccion", (hdfCodigo.Value.Equals("") ? "0" : hdfCodigo.Value), (hdfCodigo.Value.Equals("") ? "0" : hdfCodigo.Value)));
                    parametros.Add(new parametrosEventosInfo(_indexParametro++, _indexParametro, "codigoMiembro", ddlMiembro.Value, ddlMiembro.Value));
                    
                    string fecha = txtFecha.Value;
                    DateTime fechaDate;

                    if (DateTime.TryParse(fecha, out fechaDate))
                        parametros.Add(new parametrosEventosInfo(_indexParametro++, _indexParametro, "fecha", fechaDate.ToString("dd/MM/yyyy"), fechaDate.ToString("dd/MM/yyyy")));
                    else
                        parametros.Add(new parametrosEventosInfo(_indexParametro++, _indexParametro, "fecha", string.Empty, string.Empty));
                    
                    parametros.Add(new parametrosEventosInfo(_indexParametro++, _indexParametro, "codigoTransaccion", ddlTipoTransaccion.Value, ddlTipoTransaccion.Value));
                    parametros.Add(new parametrosEventosInfo(_indexParametro++, _indexParametro, "formaPago", ddlFormaIngreso.Value, ddlFormaIngreso.Value));
                    parametros.Add(new parametrosEventosInfo(_indexParametro++, _indexParametro, "noConfirmacion", txtConfirmación.Value, txtConfirmación.Value));
                    parametros.Add(new parametrosEventosInfo(_indexParametro++, _indexParametro, "monto", txtMonto.Value, txtMonto.Value));

                    parametros.Add(new parametrosEventosInfo(_indexParametro++, _indexParametro, "estatus", (chkTransaccion.Checked ? "A" : "I"), (chkTransaccion.Checked ? "A" : "I")));

                    DataSet dsResultado = sql.guardaTransaccion(parametros, "I");
                    DataRow drResultado = dsResultado.Tables[0].Rows[0];

                    if (drResultado["codigo"].ToString().Equals("0"))
                    {
                        _sweetAlertaInfo.TipoResultado = "success";
                        _sweetAlertaInfo.TituloResultado = "Registro Guardado";
                        _sweetAlertaInfo.CuerpoResultado = drResultado["mensaje"].ToString();
                        _sweetAlertaInfo.UrlRedirect = ("../../Mantenimiento/transacciones/ingresos.aspx");

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
                    _sweetAlertaInfo.PieResultado = ex.Message;
                    alert.showSweetAlert(_sweetAlertaInfo);
                }
            }
        }

        private bool validaInformacion()
        {
            bool esValido = true;

            if (ddlMiembro.Value.Contains("SELECCIONAR"))
            {
                validaControl(ddlMiembro, "validaSeleccion");
                esValido = false;
            }

            if (ddlTipoTransaccion.Value.Contains("SELECCIONAR"))
            {
                validaControl(ddlTipoTransaccion, "validaSeleccion");
                esValido = false;
            }

            if (ddlFormaIngreso.Value.Contains("SELECCIONAR"))
            {
                validaControl(ddlFormaIngreso, "validaSeleccion");
                esValido = false;
            }

            if (txtFecha.Value.Length <= 0)
            {
                validaControl(txtFecha, "validaFecha");
                esValido = false;
            }

            if (txtMonto.Value.Length <= 0)
            {
                validaControl(txtMonto, "controlInvalido");
                esValido = false;
            }

            return esValido;
        }

        private void validaControl(Control objeto, string funcion)
        {
            string javaScript = $"{funcion}({objeto.ClientID});";
            ScriptManager.RegisterStartupScript(this, this.GetType(), "script", javaScript, true);
        }
    }
}