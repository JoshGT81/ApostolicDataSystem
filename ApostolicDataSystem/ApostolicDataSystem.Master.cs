using ApostolicDataSystem.App_Class;
using System;
using System.Data;
using System.Text;

namespace ApostolicDataSystem
{
    public partial class ApostolicDataSystem : System.Web.UI.MasterPage
    {
        seguridad seg = new seguridad();
        protected void Page_Load(object sender, EventArgs e)
        {
            string imagen = Session["fotoUsuario"].ToString();

            ltlFotoPerfil.Text = "<img src=\"" + Page.ResolveClientUrl("~/" + imagen) + "\" alt=\"Profile\" class=\"rounded-circle\">";
            string nombres = Session["nombres"].ToString();
            string punto = (Session["nombres"].ToString().Length > 0 ? "." : "");
            string[] apellidos = Session["Apellidos"].ToString().Split(' ');
            string nombreAbreviado = (nombres.Length > 0 ? nombres.Substring(0, 1) : "") + punto + apellidos[0];
            lblNombreAbreviado.Text = nombreAbreviado;
            lblNombreUsuario.Text = Session["nombres"].ToString() + " " + Session["Apellidos"].ToString();
            lblPuestoUsuario.Text = Session["puesto"].ToString();

            string editaPerfil = string.Empty;
            string urlOpcion = "Mantenimiento/usuario/usuario.aspx?U=[" + seg.inEncrypt(Session["usuario"].ToString()) + "]&P=[" + seg.inEncrypt("master") + "]";

            editaPerfil = "<a class=\"dropdown-item d-flex align-items-center\" href=\"" + Page.ResolveClientUrl("~/" + urlOpcion) + "\">" +
                          "	<i class=\"bi bi-gear\"></i>" +
                          "	<span>Configuración de Perfil</span>" +
                          "</a>";

            ltlEdicionPerfil.Text = editaPerfil;

            string cerrarSesion = string.Empty;
            cerrarSesion = "<a class=\"dropdown-item d-flex align-items-center\" href=\"" + Page.ResolveClientUrl("~/login.aspx") + "\">" +
                            "    <i class=\"bi bi-box-arrow-right\"></i>" +
                            "    <span>Cerrar Sesión</span>" +
                            "</a>";

            ltlCerrarSesion.Text = cerrarSesion;

            string codigoRol = Session["codigoRol"].ToString();

            procesosSQL sql = new procesosSQL();
            DataSet dsMenu = sql.getMenu(codigoRol);

            if (dsMenu.Tables.Count > 0)
                ltlMenu.Text = creaMenu(dsMenu);

        }

        string creaMenu(DataSet dsDatosMenu)
        {
            string resultado = string.Empty;
            StringBuilder sbMenu = new StringBuilder();
            try
            {
                if (dsDatosMenu.Tables.Count > 0)
                {
                    foreach (DataRow drMenu in dsDatosMenu.Tables[0].Rows)
                    {
                        sbMenu.Append("<li class=\"nav-item\">");
                        sbMenu.Append("	<a class=\"nav-link collapsed\" data-bs-target=\"#").Append(drMenu["orden"].ToString()).Append("\" data-bs-toggle=\"collapse\" href=\"#\">");
                        sbMenu.Append("		<i class=\"").Append(drMenu["icono"].ToString()).Append("\"></i><span>").Append(drMenu["texto"].ToString()).Append("</span><i class=\"bi bi-chevron-down ms-auto\"></i>");
                        sbMenu.Append("	</a>");
                        sbMenu.Append("	<ul id=\"").Append(drMenu["orden"].ToString()).Append("\" class=\"nav-content collapse\" data-bs-parent=\"#sidebar-nav\">");
                        sbMenu.Append("		<li>");

                        DataRow[] dsSubMenu = dsDatosMenu.Tables[1].Select("codigoPadre = " + drMenu["codigoMenu"].ToString(), "orden");

                        foreach (DataRow drSubMenu in dsSubMenu)
                        {
                            sbMenu.Append("			<a href=\"").Append(Page.ResolveClientUrl("~/" + drSubMenu["href"].ToString())).Append("\">");
                            sbMenu.Append("				<i class=\"").Append(drSubMenu["icono"].ToString()).Append("\"></i><span>").Append(drSubMenu["texto"].ToString()).Append("</span>");
                            sbMenu.Append("			</a>");
                        }

                        sbMenu.Append("		</li>");
                        sbMenu.Append("	</ul>");
                        sbMenu.Append("</li>");
                    }
                }

                resultado = sbMenu.ToString();
            }
            catch { }

            return resultado;
        }
    }
}