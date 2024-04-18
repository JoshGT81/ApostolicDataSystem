using ApostolicDataSystem.Models;
using ApostolicDataSystem.App_Class;
using System;
using System.Data;
using System.Collections.Generic;

namespace ApostolicDataSystem.Mantenimiento.usuario
{
    public partial class usuario : System.Web.UI.Page
    {
        sweetAlertInfo _sweetAlertaInfo = new sweetAlertInfo();

        protected void Page_Load(object sender, EventArgs e)
        {
            parametrosUrlInfo parametros = new parametrosUrlInfo();
            parametrosUrl parametrosUrl = new parametrosUrl();

            parametros = parametrosUrl.getParametrosUrl(Request.QueryString);

            if (parametros.U == null)
                parametros.U = string.Empty;
            if (parametros.P == null)
                parametros.P = string.Empty;

            if (!IsPostBack)
            {
                if (parametros.U != string.Empty)
                    hdfProceso.Value = "UPDATE";
                else
                    hdfProceso.Value = "INSERT";

                cargarInformacionInicial(parametros.U, parametros.P);
            }
        }

        private void cargarInformacionInicial(string codigo, string procedencia)
        {
            procesosSQL sql = new procesosSQL();
            procesoHTML html = new procesoHTML();
            sweetAlert alert = new sweetAlert();

            try
            {
                DataSet dsUsuario = sql.getUsuario(codigo);

                if (dsUsuario.Tables.Count > 0)
                {
                    if (dsUsuario.Tables[0].Rows.Count > 0)
                    {
                        DataRow drRegistro = dsUsuario.Tables[0].Rows[0];

                        #region Resumen
                        string nombres = drRegistro["nombres"].ToString();
                        string apellidos = drRegistro["apellidos"].ToString();
                        string nombreCompleto = nombres + " " + apellidos;

                        lblNombreCompleto.Text = nombreCompleto;
                        lblNombreCompletoTitulo.Text = nombreCompleto;

                        lblPuesto.Text = drRegistro["puesto"].ToString();
                        lblPuestoTitulo.Text = drRegistro["puesto"].ToString();

                        lblRol.Text = drRegistro["descripcionRol"].ToString();

                        lblDireccion.Text = drRegistro["direccion"].ToString();
                        lblTelefono.Text = drRegistro["telefono"].ToString();
                        lblCorreo.Text = drRegistro["correo"].ToString();
                        #endregion

                        #region Edicion
                        txtNombres.Value = drRegistro["nombres"].ToString();
                        txtApellidos.Value = drRegistro["apellidos"].ToString();

                        txtPuesto.Value = drRegistro["puesto"].ToString();

                        ddlRol.Items.AddRange(html.getListadoCatalogo(dsUsuario.Tables[1]));
                        int item = 0;
                        for (int i = 0; i < ddlRol.Items.Count; i++)
                        {
                            ddlRol.SelectedIndex = item;

                            if (ddlRol.Value != drRegistro["codigoRol"].ToString())
                                item++;
                        }

                        txtDireccion.Value = drRegistro["direccion"].ToString();
                        txtCorreo.Value = drRegistro["correo"].ToString();
                        txtTelefono.Value = drRegistro["telefono"].ToString();
                        txtUsuario.Value = drRegistro["usuario"].ToString();
                        txtContraseña.Value = drRegistro["contraseña"].ToString();

                        string activo = drRegistro["estatus"].ToString();
                        chkUsuarioActivo.Checked = (activo.Equals("A") ? true : false);
                        #endregion
                    }

                    ddlRol.Items.AddRange(html.getListadoCatalogo(dsUsuario.Tables[1]));
                }

                if (!procedencia.Equals("master"))
                    objetosVisibles(true);
                else
                    objetosVisibles(false);
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

        private void objetosVisibles(bool visible)
        {
            tbCambioContraseña.Visible = (visible ? false : true);

            dvRol.Visible = visible;
            dvUsuario.Visible = (hdfProceso.Value.Equals("INSERT") ? true : false );
            dvContraseña.Visible = visible;
            dvUsuarioActivo.Visible = visible;
        }

        protected void btnGuardarInformacion_ServerClick(object sender, EventArgs e)
        {
            sweetAlert alert = new sweetAlert();
            procesosSQL sql = new procesosSQL();

            try
            {
                int _indexParametro = 0;
                List<parametrosEventosInfo> parametros = new List<parametrosEventosInfo>();

                if (hdfProceso.Value.Equals("UPDATE"))                
                    parametros.Add(new parametrosEventosInfo(_indexParametro++, _indexParametro, "tipo", "U", "U"));
                else
                    parametros.Add(new parametrosEventosInfo(_indexParametro++, _indexParametro, "tipo", "I", "I"));

                parametros.Add(new parametrosEventosInfo(_indexParametro++, _indexParametro, "usuario", txtUsuario.Value, txtUsuario.Value));
                parametros.Add(new parametrosEventosInfo(_indexParametro++, _indexParametro, "codigoRol", ddlRol.Value, ddlRol.Value));
                parametros.Add(new parametrosEventosInfo(_indexParametro++, _indexParametro, "contraseña", txtContraseña.Value, txtContraseña.Value));
                parametros.Add(new parametrosEventosInfo(_indexParametro++, _indexParametro, "fotoUsuario", "assets/fotosPerfil/admin.system.png", "assets/fotosPerfil/admin.system.png"));
                parametros.Add(new parametrosEventosInfo(_indexParametro++, _indexParametro, "nombres", txtNombres.Value, txtNombres.Value));
                parametros.Add(new parametrosEventosInfo(_indexParametro++, _indexParametro, "apellidos", txtApellidos.Value, txtApellidos.Value));
                parametros.Add(new parametrosEventosInfo(_indexParametro++, _indexParametro, "puesto", txtPuesto.Value, txtPuesto.Value));
                parametros.Add(new parametrosEventosInfo(_indexParametro++, _indexParametro, "direccion", txtDireccion.Value, txtDireccion.Value));
                parametros.Add(new parametrosEventosInfo(_indexParametro++, _indexParametro, "telefono", txtTelefono.Value, txtTelefono.Value));
                parametros.Add(new parametrosEventosInfo(_indexParametro++, _indexParametro, "correo", txtCorreo.Value, txtCorreo.Value));
                parametros.Add(new parametrosEventosInfo(_indexParametro++, _indexParametro, "estatus", (chkUsuarioActivo.Checked ? "A" : "I"), (chkUsuarioActivo.Checked ? "A" : "I")));

                parametros.Add(new parametrosEventosInfo(_indexParametro++, _indexParametro, "usuarioTransaccion", Session["usuario"].ToString(), Session["usuario"].ToString()));

                DataSet dsResultado = sql.guardarUsuario(parametros);

                DataRow drResultado = dsResultado.Tables[0].Rows[0];

                if (drResultado["codigo"].ToString().Equals("0"))
                {
                    _sweetAlertaInfo.TipoResultado = "success";
                    _sweetAlertaInfo.TituloResultado = "Registro Guardado";
                    _sweetAlertaInfo.CuerpoResultado = drResultado["mensaje"].ToString();
                    _sweetAlertaInfo.UrlRedirect = ("../../Mantenimiento/usuario/listaUsuarios.aspx");

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

        protected void btnGuardarNuevaContraseña_ServerClick(object sender, EventArgs e)
        {
            sweetAlert alert = new sweetAlert();

            _sweetAlertaInfo.TipoResultado = "success";
            _sweetAlertaInfo.TituloResultado = "Cambio de contraseña";
            _sweetAlertaInfo.CuerpoResultado = "Se cambio la contraseña correctamente.";

            alert.showSweetAlert(_sweetAlertaInfo);
        }
    }
}