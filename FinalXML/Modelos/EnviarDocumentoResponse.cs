namespace FinalXML
{
    public class EnviarDocumentoResponse : RespuestaComun
    {
        public string CodigoRespuesta { get; set; }
        public string MensajeRespuesta { get; set; }
        public string TramaZipCdr { get; set; }
        public string NroTicket { get; set; } //prueba- ver si se quita o no :V

    }
}
