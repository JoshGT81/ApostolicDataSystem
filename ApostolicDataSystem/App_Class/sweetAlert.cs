using ApostolicDataSystem.Models;
using System.Web;
using System.Web.UI;

namespace ApostolicDataSystem.App_Class
{
    public class sweetAlert
    {
        public void showSweetAlert(sweetAlertInfo mensajeSweetAlert)
        {
            if (HttpContext.Current.CurrentHandler is Page)
            {
                Page p = (Page)HttpContext.Current.CurrentHandler;

                mensajeSweetAlert.CuerpoResultado = mensajeSweetAlert.CuerpoResultado;

                if (mensajeSweetAlert.PieResultado != null)
                {
                    mensajeSweetAlert.PieResultado = mensajeSweetAlert.PieResultado;
                }

                p.ClientScript.RegisterStartupScript(typeof(Page), "alert", "mostrarSweetAlert('" + mensajeSweetAlert.TipoResultado + "', '"
                    + mensajeSweetAlert.TituloResultado + "'," +
                    "'" + mensajeSweetAlert.CuerpoResultado + "', '" +
                    (mensajeSweetAlert.UrlRedirect != null ? mensajeSweetAlert.UrlRedirect : string.Empty) + "', '" +
                    (mensajeSweetAlert.PieResultado != null ? mensajeSweetAlert.PieResultado : string.Empty) + "', '" +
                    (mensajeSweetAlert.TipoRedirect != null ? mensajeSweetAlert.TipoRedirect : string.Empty) + "'); " +
                    mensajeSweetAlert.EjecutarScript, true);
            }
        }
    }
}