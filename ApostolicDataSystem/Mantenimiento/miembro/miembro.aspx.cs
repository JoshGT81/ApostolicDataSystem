using ApostolicDataSystem.Models;
using ApostolicDataSystem.App_Class;
using System;
using System.Configuration;
using System.Data;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace ApostolicDataSystem.Mantenimiento.miembro
{
    public partial class miembro : System.Web.UI.Page
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

                cargarInformacionInicial(parametros.C.ToString());
            }
        }

        private void cargarInformacionInicial(string codigo)
        {
            procesosSQL sql = new procesosSQL();
            sweetAlert alert = new sweetAlert();

            try
            {
                DataSet dsMiembro = sql.getMiembro(codigo);

                if (dsMiembro.Tables.Count > 0)
                {
                    if (dsMiembro.Tables[0].Rows.Count > 0)
                    {
                        DataRow drRegistro = dsMiembro.Tables[0].Rows[0];

                        hdfCodigo.Value = drRegistro["codigoMiembro"].ToString();
                        txtNombres.Value = drRegistro["nombres"].ToString();
                        txtApellidos.Value = drRegistro["apellidos"].ToString();
                        ddlBautizado.Value = drRegistro["bautizado"].ToString();

                        string fechaBautizo = drRegistro["fechaBautizo"].ToString();

                        if (fechaBautizo.Length > 0)
                        {
                            DateTime fechaBautizoDate;

                            if (DateTime.TryParse(fechaBautizo, out fechaBautizoDate))
                                txtFechaBautizo.Text = fechaBautizoDate.ToString("yyyy-MM-dd");                        
                        }

                        ddlEspirituSanto.Value = drRegistro["espirituSanto"].ToString();

                        string fechaES = drRegistro["fechaEspirituSanto"].ToString();

                        if (fechaES.Length > 0)
                        {
                            DateTime fechaESDate;

                            if (DateTime.TryParse(fechaES, out fechaESDate))
                                txtFechaEspirituSanto.Text = fechaESDate.ToString("yyyy-MM-dd");
                        }

                        txtFechaNacimiento.Text = Convert.ToDateTime(drRegistro["fechaNacimiento"].ToString()).ToString("yyyy-MM-dd");
                        ddlSexo.Value = drRegistro["sexo"].ToString();
                        ddlEstadoCivil.Value = drRegistro["estadoCivil"].ToString();
                        txtEstatura.Value = drRegistro["estatura"].ToString();
                        ddlTallaCamisa.Value = drRegistro["tallaCamisa"].ToString();
                        txtDireccion.Value = drRegistro["direccion"].ToString();
                        txtTelefono.Value = drRegistro["telefono"].ToString();

                        string foto = string.Empty;
                        string pathFoto = string.Empty;

                        if (!drRegistro["foto"].ToString().Equals(""))
                            pathFoto = "../../" + ConfigurationManager.AppSettings["pathFotosMembresia"] + codigo + drRegistro["foto"];
                        else
                            pathFoto = "../../" + ConfigurationManager.AppSettings["pathFotosMembresia"] + "noFoto.jpg";

                        ltlFoto.Text = "<label " +
                                        "	for=\"fuFoto\" " +
                                        "	class=\"form-label\"  " +
                                        "	data-bs-toggle=\"tooltip\" " +
                                        "   data-bs-custom-class='custom-tooltip'" +
                                        "	data-bs-placement=\"top\" " +
                                        "	data-bs-html=\"true\" " +
                                        "	data-bs-title=\"" +
                                        "<div class='card' style='width: 20rem;'> " +
                                            "<img " +
                                            "	alt='Profile' " +
                                            "	class='img-thumbnail rounded mx-auto d-block' " +
                                            "	src='" + pathFoto + "' " +
                                            "	style='height: 75px; width: 50%;' />" +
                                        "  <div class='card-body'> " +
                                        "    <p class='card-text'>Miembro: " + drRegistro["nombres"] + " " + drRegistro["apellidos"] + "</p> " +
                                        "  </div>" +
                                        "</div>" +
                                       "\">Foto Actual" +
                                        "</label>";

                        chkEstatus.Checked = (drRegistro["estatus"].ToString().Equals("A") ? true : false);

                    }
                    else
                    {
                        ltlFoto.Text = "<label " +
                                            "	for=\"fuFoto\" " +
                                            "	class=\"form-label\"  " +
                                           "\">Foto" +
                                            "</label>";
                    }
                }                
            }
            catch (Exception ex)
            {
                _sweetAlertaInfo.TipoResultado = "error";
                _sweetAlertaInfo.TituloResultado = "Error";
                _sweetAlertaInfo.CuerpoResultado = "Ocurrió un error al obtener la información del miembro.";
                _sweetAlertaInfo.PieResultado = ex.Message + " " + ex.StackTrace;

                alert.showSweetAlert(_sweetAlertaInfo);
            }
        }

        protected void btnGuardar_ServerClick(object sender, EventArgs e)
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

                parametros.Add(new parametrosEventosInfo(_indexParametro++, _indexParametro, "codigoMiembro", (hdfCodigo.Value.Equals("") ? "0" : hdfCodigo.Value), (hdfCodigo.Value.Equals("") ? "0" : hdfCodigo.Value)));
                parametros.Add(new parametrosEventosInfo(_indexParametro++, _indexParametro, "nombres", txtNombres.Value, txtNombres.Value));
                parametros.Add(new parametrosEventosInfo(_indexParametro++, _indexParametro, "apellidos", txtApellidos.Value, txtApellidos.Value));
                parametros.Add(new parametrosEventosInfo(_indexParametro++, _indexParametro, "bautizado", ddlBautizado.Value, ddlBautizado.Value));

                string fechaBautizo = txtFechaBautizo.Text;

                if (fechaBautizo.Length > 0)
                {
                    DateTime fechBautizoDate;

                    if (DateTime.TryParse(fechaBautizo, out fechBautizoDate))
                        parametros.Add(new parametrosEventosInfo(_indexParametro++, _indexParametro, "fechaBautizo", fechBautizoDate.ToString("dd/MM/yyyy"), fechBautizoDate.ToString("dd/MM/yyyy")));
                    else
                        parametros.Add(new parametrosEventosInfo(_indexParametro++, _indexParametro, "fechaBautizo", string.Empty, string.Empty));
                }
                else
                    parametros.Add(new parametrosEventosInfo(_indexParametro++, _indexParametro, "fechaBautizo", string.Empty, string.Empty));


                parametros.Add(new parametrosEventosInfo(_indexParametro++, _indexParametro, "espirituSanto", ddlEspirituSanto.Value, ddlEspirituSanto.Value));

                string fechaES = txtFechaEspirituSanto.Text;

                if (fechaES.Length > 0)
                {
                    DateTime fechaESDate;

                    if (DateTime.TryParse(fechaES, out fechaESDate))
                        parametros.Add(new parametrosEventosInfo(_indexParametro++, _indexParametro, "fechaEspirituSanto", fechaESDate.ToString("dd/MM/yyyy"), fechaESDate.ToString("dd/MM/yyyy")));
                    else
                        parametros.Add(new parametrosEventosInfo(_indexParametro++, _indexParametro, "fechaEspirituSanto", string.Empty, string.Empty));
                }
                else
                    parametros.Add(new parametrosEventosInfo(_indexParametro++, _indexParametro, "fechaEspirituSanto", string.Empty, string.Empty));


                string fechaNac = txtFechaNacimiento.Text;

                if (fechaNac.Length > 0)
                {
                    DateTime fechaNacDate;

                    if (DateTime.TryParse(fechaNac, out fechaNacDate))
                        parametros.Add(new parametrosEventosInfo(_indexParametro++, _indexParametro, "fechaNacimiento", fechaNacDate.ToString("dd/MM/yyyy"), fechaNacDate.ToString("dd/MM/yyyy")));
                    else
                        parametros.Add(new parametrosEventosInfo(_indexParametro++, _indexParametro, "fechaNacimiento", string.Empty, string.Empty));
                }

                parametros.Add(new parametrosEventosInfo(_indexParametro++, _indexParametro, "sexo", ddlSexo.Value, ddlSexo.Value));
                parametros.Add(new parametrosEventosInfo(_indexParametro++, _indexParametro, "estadoCivil", ddlEstadoCivil.Value, ddlEstadoCivil.Value));
                parametros.Add(new parametrosEventosInfo(_indexParametro++, _indexParametro, "estatura", txtEstatura.Value, txtEstatura.Value));
                parametros.Add(new parametrosEventosInfo(_indexParametro++, _indexParametro, "tallaCamisa", ddlTallaCamisa.Value, ddlTallaCamisa.Value));
                parametros.Add(new parametrosEventosInfo(_indexParametro++, _indexParametro, "direccion", txtDireccion.Value, txtDireccion.Value));
                parametros.Add(new parametrosEventosInfo(_indexParametro++, _indexParametro, "telefono", txtTelefono.Value, txtTelefono.Value));

                string fileExtension = string.Empty;

                if (fuFoto.HasFile)
                {
                    string fileName = fuFoto.FileName;
                    fileExtension = System.IO.Path.GetExtension(fileName);                    
                }


                parametros.Add(new parametrosEventosInfo(_indexParametro++, _indexParametro, "foto", fileExtension, fileExtension));

                parametros.Add(new parametrosEventosInfo(_indexParametro++, _indexParametro, "estatus", (chkEstatus.Checked ? "A" : "I"), (chkEstatus.Checked ? "A" : "I")));

                

                DataSet dsResultado = sql.guardaMiembro(parametros);

                DataRow drResultado = dsResultado.Tables[0].Rows[0];

                if (drResultado["codigo"].ToString().Equals("0"))
                {
                    guardarFoto( Convert.ToInt32(drResultado["codigoRegistro"].ToString()));

                    _sweetAlertaInfo.TipoResultado = "success";
                    _sweetAlertaInfo.TituloResultado = "Registro Guardado";
                    _sweetAlertaInfo.CuerpoResultado = drResultado["mensaje"].ToString();
                    _sweetAlertaInfo.UrlRedirect = ("../../Mantenimiento/miembro/listaMiembros.aspx");

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
                _sweetAlertaInfo.CuerpoResultado = "Ocurrió un error a intentar guardar la información.    ----->     " + ex.Message;

                alert.showSweetAlert(_sweetAlertaInfo);
            }
        }

        private bool guardarFoto(int codigoMiembro)
        {
            sweetAlert alert = new sweetAlert();
            StringBuilder sbMensaje = new StringBuilder();
            string pathFotos = AppDomain.CurrentDomain.BaseDirectory + ConfigurationManager.AppSettings["pathFotosMembresia"];
            bool resultado = true;

            try
            {
                if (fuFoto.HasFile)
                {
                    string contentType = fuFoto.PostedFile.ContentType;
                    if (contentType == "image/jpeg" || contentType == "image/png" || contentType == "image/jpg")
                    {
                        int fileSize = fuFoto.PostedFile.ContentLength;
                        if (fileSize <= 6 * 1024 * 1024)
                        {
                            string fileName = fuFoto.FileName;
                            string fileExtension = System.IO.Path.GetExtension(fileName);

                            string path = Path.Combine(pathFotos, codigoMiembro + fileExtension);

                            if (File.Exists(path))
                                File.Delete(path);

                            fuFoto.SaveAs(path);
                        }
                        else
                        {
                            resultado = false;
                            sbMensaje.Append("Por favor, sube una imagen que sea menor a 6MB.").Append("\n");
                        }
                    }
                    else
                    {
                        resultado = false;
                        sbMensaje.Append("Por favor, sube solo imágenes JPG, JPEG o PNG.").Append("\n");
                    }

                    if (!resultado)
                    {
                        _sweetAlertaInfo.TipoResultado = "warning";
                        _sweetAlertaInfo.TituloResultado = "Inconveniente";
                        _sweetAlertaInfo.CuerpoResultado = sbMensaje.ToString();

                        alert.showSweetAlert(_sweetAlertaInfo);
                    }
                }
            }
            catch (Exception ex)
            {
                _sweetAlertaInfo.TipoResultado = "error";
                _sweetAlertaInfo.TituloResultado = "Error";
                _sweetAlertaInfo.CuerpoResultado = "Ocurrió un error a intentar guardar la foto.";
                _sweetAlertaInfo.PieResultado = ex.Message;

                alert.showSweetAlert(_sweetAlertaInfo);
            }

            return resultado;
        }
    }
}