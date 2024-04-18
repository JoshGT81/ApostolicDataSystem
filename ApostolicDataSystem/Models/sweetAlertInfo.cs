namespace ApostolicDataSystem.Models
{
    public class sweetAlertInfo
    {

        /// <summary>
        /// Indica el tipo de resultado del proceso: success|error|info|danger
        /// </summary>
        public string TipoResultado { get; set; }

        /// <summary>
        /// Indica el titulo que se obtuvo en el resultado
        /// </summary>
        public string TituloResultado { get; set; }

        /// <summary>
        /// Indica el contenido que se obtuvo en el resultado
        /// </summary>
        public string CuerpoResultado { get; set; }

        /// <summary>
        /// Indica el contenido del footer para la alerta
        /// </summary>
        public string PieResultado { get; set; }

        /// <summary>
        /// Indica el URL a donde se redireccionará. Dejar en null si no se utilizará
        /// </summary>
        public string UrlRedirect { get; set; }

        /// <summary>
        /// Indica el tipo de redirección a realizar: _blank|_self|_parent|_top|framename
        /// </summary>
        public string TipoRedirect { get; set; }

        /// <summary>
        /// Contiene el nombre de funciones a ejecutar tipo JQuery o JavaScript separados por ;
        /// </summary>
        public string EjecutarScript { get; set; }
    }
}