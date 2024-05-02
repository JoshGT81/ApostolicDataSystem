using ApostolicDataSystem.App_Class;
using ApostolicDataSystem.Models;
using System;
using System.Data;
using System.Net;

namespace ApostolicDataSystem
{
    public partial class Login : System.Web.UI.Page
    {
        sweetAlertInfo _sweetAlertaInfo = new sweetAlertInfo();

        protected void Page_Load(object sender, EventArgs e)
        {
            // Obtén el nombre del host
            string hostName = Dns.GetHostName();

            // Usa el nombre del host para obtener las direcciones IP del host
            IPAddress[] hostIPs = Dns.GetHostAddresses(hostName);

            // Elige una de las direcciones IP, por ejemplo, la primera
            string hostIP = hostIPs[3].ToString();

            if (hostIP.Equals("192.168.1.9"))
            {
                txtUsuario.Value = "elias.villatoro";
                txtContraseña.Value = "123";
            }
        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {
            sweetAlert alert = new sweetAlert();

            try
            {
                procesosSQL sql = new procesosSQL();
                DataSet dsUsuario = sql.getUsuario(txtUsuario.Value);

                if (dsUsuario.Tables.Count > 0)
                {
                    if (dsUsuario.Tables[0].Rows.Count > 0)
                    {
                        DataRow drUsuario = dsUsuario.Tables[0].Rows[0];

                        if (drUsuario["usuario"].ToString().Equals(txtUsuario.Value) && drUsuario["contraseña"].ToString().Equals(txtContraseña.Value))
                        {
                            Session.Add("usuario", drUsuario["usuario"].ToString());
                            Session.Add("codigoRol", drUsuario["codigoRol"].ToString());

                            Session.Add("fotoUsuario", drUsuario["fotoUsuario"].ToString());
                            Session.Add("nombres", drUsuario["nombres"].ToString());
                            Session.Add("apellidos", drUsuario["apellidos"].ToString());
                            Session.Add("puesto", drUsuario["puesto"].ToString());

                            Response.Redirect("Index.aspx", true);
                        }
                        else
                        {
                            _sweetAlertaInfo.TipoResultado = "warning";
                            _sweetAlertaInfo.TituloResultado = "Inicio de sesión erronea";
                            _sweetAlertaInfo.CuerpoResultado = "El usuario o la contraseña ingresada no son correctos.";

                            alert.showSweetAlert(_sweetAlertaInfo);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                _sweetAlertaInfo.TipoResultado = "error";
                _sweetAlertaInfo.TituloResultado = "Error";
                _sweetAlertaInfo.CuerpoResultado = "Ocurrio un error al buscar al usuario en la base de datos.";
                _sweetAlertaInfo.PieResultado = ex.Message + " " + ex.StackTrace;

                alert.showSweetAlert(_sweetAlertaInfo);
            }
        }
    }
}