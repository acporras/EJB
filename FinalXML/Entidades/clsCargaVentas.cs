using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalXML.Entidades
{
    public class clsCargaVentas : EnviarDocumentoResponse
    {
        public String NumDocEmisor { get; set; }
        public String Sigla { get; set; }
        public String Serie { get; set; }
        public String Numeracion { get; set; }
        public DateTime FechaEmision { get; set; }
        public String NumDocCliente { get; set; }
        public String Cliente { get; set; }
        public String DirCliente { get; set; }
        public Decimal Total { get; set; }
        public Int32 EstadoDocSunat { get; set; }
        public String SiglaDocAfecta { get; set; }
        public String SerieDocAfecta { get; set; }
        public String NumDocAfecta { get; set; }
        public String Moneda { get; set; }
        public DateTime FechaVencimiento { get; set; }
    }
}
