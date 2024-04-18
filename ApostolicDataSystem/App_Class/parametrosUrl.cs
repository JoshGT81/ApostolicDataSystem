using ApostolicDataSystem.Models;
using System;

namespace ApostolicDataSystem.App_Class
{
    public class parametrosUrl
    {
        seguridad seg = new seguridad();
        public parametrosUrlInfo getParametrosUrl(System.Collections.Specialized.NameValueCollection parametrosUrl)
        {
            parametrosUrlInfo parametrosRespuesta = new parametrosUrlInfo();

            foreach (string parametro in parametrosUrl)
            {
                string valorParametro = parametrosUrl[parametro].Replace("[", "").Replace("]", "").Replace("%5b", "").Replace("%5d", "").Replace(" ", "+");

                switch (parametro.ToLower())
                {
                    case "e":
                        {
                            if (Int32.TryParse(valorParametro, out int valorDevuelto))
                            {
                                parametrosRespuesta.E = valorDevuelto;
                            }
                            else
                            {
                                parametrosRespuesta.E = 0;
                            }
                        }
                        break;
                    case "c":
                        {                           
                            valorParametro = seg.outEncrypt(valorParametro);

                            if (Int32.TryParse(valorParametro, out int valorDevuelto))
                            {
                                parametrosRespuesta.C = valorDevuelto;
                            }
                            else
                            {
                                parametrosRespuesta.C = 0;
                            }
                        }
                        break;
                    case "wc":
                        {
                            if (Int32.TryParse(valorParametro, out int valorDevuelto))
                            {
                                parametrosRespuesta.WC = valorDevuelto;
                            }
                            else
                            {
                                parametrosRespuesta.WC = 0;
                            }
                        }
                        break;
                    case "u":
                        {
                            try
                            {
                                parametrosRespuesta.U = seg.outEncrypt(valorParametro);
                            }
                            catch
                            {
                                parametrosRespuesta.U = string.Empty;
                            }
                        }
                        break;
                    case "p":
                        {
                            try
                            {
                                parametrosRespuesta.P = seg.outEncrypt(valorParametro);
                            }
                            catch
                            {
                                parametrosRespuesta.P = string.Empty;
                            }
                        }
                        break;
                    case "t":
                        {
                            try
                            {
                                parametrosRespuesta.T = valorParametro;
                            }
                            catch
                            {
                                parametrosRespuesta.T = string.Empty;
                            }
                        }
                        break;
                    case "m":
                        {
                            try
                            {
                                parametrosRespuesta.M = valorParametro;
                            }
                            catch
                            {
                                parametrosRespuesta.M = string.Empty;
                            }
                        }
                        break;
                }

            }

            return parametrosRespuesta;
        }
    }
}