using ApostolicDataSystem.Models;
using System;
using System.Data;
using System.Text;
using System.Web.UI.WebControls;

namespace ApostolicDataSystem.App_Class
{
    public class procesoHTML
    {
        public dataGridViewInfo getDataGridView(DataTable dtInformacion, string idTabla, bool generaFiltroIndividual)
        {
            dataGridViewInfo response = new dataGridViewInfo();
            StringBuilder stHtmlTabla = new StringBuilder();
            StringBuilder stHtmlHeader = new StringBuilder();
            StringBuilder stHtmlBody = new StringBuilder();
            seguridad seg = new seguridad();

            if (dtInformacion.Rows.Count > 0)
            {
                stHtmlHeader.Append("<thead>");
                stHtmlHeader.Append("<tr>");

                foreach (DataColumn columna in dtInformacion.Columns)
                {
                    stHtmlHeader.Append("<th>").Append(columna.ColumnName.Replace("Encript_", String.Empty).Replace("Link", "Seleccinar")).Append("</th>");
                }

                stHtmlHeader.Append("</tr>");
                stHtmlHeader.Append("</thead>");
                stHtmlBody.Append("<tbody>");

                foreach (DataRow fila in dtInformacion.Rows)
                {
                    stHtmlBody.Append("<tr>");

                    foreach (DataColumn columna in dtInformacion.Columns)
                    {
                        string contenidoColumna = string.Empty;

                        if (columna.ColumnName == "Link")
                        {
                            // TODO: AGREGAR TIPO DE ENCRIPCION
                            string iconoSeleccionar = "<button type='button' class='btn btn-icon btn-primary btn-sm waves-effect waves-float waves-light' style='--bs-btn-padding-y: .25rem; --bs-btn-padding-x: .5rem; --bs-btn-font-size: .75rem;'><i class='bi bi-check'></i></button>";
                            string redireccion = fila[columna].ToString();

                            if (redireccion.Contains("Encriptar"))
                            {
                                while (redireccion.Contains("Encriptar"))
                                {
                                    string codigoEncriptado = string.Empty;
                                    codigoEncriptado = redireccion;
                                    codigoEncriptado = redireccion.Substring(codigoEncriptado.IndexOf("Encriptar("));
                                    codigoEncriptado = codigoEncriptado.Split(')')[0];
                                    codigoEncriptado = codigoEncriptado.Replace("[", "").Replace("]", "").Replace("Encriptar(", "");
                                    string cadenaReemplazar = string.Empty;
                                    cadenaReemplazar = "Encriptar(" + codigoEncriptado.ToString() + ")";
                                    codigoEncriptado = seg.outEncrypt(codigoEncriptado);

                                    codigoEncriptado = seg.inEncrypt(codigoEncriptado);

                                    redireccion = redireccion.Replace(cadenaReemplazar, codigoEncriptado);
                                }
                            }

                            contenidoColumna = "<a href='" + redireccion + "'>" + iconoSeleccionar + "</a>";
                        }
                        else
                        {
                            contenidoColumna = fila[columna].ToString();
                        }

                        stHtmlBody.Append("<td>").Append(contenidoColumna).Append("</td>");
                    }

                    stHtmlBody.Append("</tr>");
                }

                stHtmlBody.Append("</tbody>");

                stHtmlTabla.Append(stHtmlHeader);
                stHtmlTabla.Append(stHtmlBody);

                response.HtmlDataTable = stHtmlTabla.ToString();
            }
            else
            {
                response.HtmlDataTable = "<div role='alert' aria-live='polite' aria-atomic='true' class='alert alert-info' data-v-aa799a9e='' style='margin: 10pt;'><div class='alert-body'><span><span style='font-weight:bold'><svg xmlns='http://www.w3.org/2000/svg' width='24' height='24' viewBox='0 0 24 24' fill='none' stroke='currentColor' stroke-width='2' stroke-linecap='round' stroke-linejoin='round' class='feather feather-search'><circle cx='11' cy='11' r='8'></circle><line x1='21' y1='21' x2='16.65' y2='16.65'></line></svg>&nbsp;No se encontraron registros para mostrar</span></span></div></div>";
            }

            return response;
        }

        public ListItem[] getListadoCatalogo(DataTable dtListadoRegistros)
        {
            ListItem[] items = new ListItem[1];

            if (dtListadoRegistros.Rows.Count > 0)
            {
                int index = 1;
                items = new ListItem[dtListadoRegistros.Rows.Count + 1];

                items[0] = new ListItem("SELECCIONAR...", "");
                foreach (DataRow row in dtListadoRegistros.Rows)
                {
                    items[index] = new ListItem(row[1].ToString(), row[0].ToString());
                    index++;
                }
            }
            else
            {
                items[0] = new ListItem("NO HAY DATOS", "");
            }

            return items;
        }
    }
}