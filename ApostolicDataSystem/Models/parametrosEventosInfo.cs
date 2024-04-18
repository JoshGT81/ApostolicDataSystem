namespace ApostolicDataSystem.Models
{
    public class parametrosEventosInfo
    {
        public parametrosEventosInfo() { }

        public int Orden { get; set; }
        public int CodigoCampo { get; set; }
        public int TipoDato { get; set; }
        public string NombreCampo { get; set; }
        public string ValorCampo { get; set; }
        public string TextoCampo { get; set; }


        public parametrosEventosInfo(int orden, int codigoCampo, string nombreCampo, string valorCampo, string textoCampo, int tipoDato)
        {
            Orden = orden;
            CodigoCampo = codigoCampo;
            NombreCampo = nombreCampo;
            ValorCampo = valorCampo;
            TextoCampo = textoCampo;
            TipoDato = tipoDato;
        }

        public parametrosEventosInfo(int orden, int codigoCampo, string nombreCampo, string valorCampo, string textoCampo)
        {
            Orden = orden;
            CodigoCampo = codigoCampo;
            NombreCampo = nombreCampo;
            ValorCampo = valorCampo;
            TextoCampo = textoCampo;
        }
    }
}