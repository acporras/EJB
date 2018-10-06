using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FinalXML;
namespace FinalXML
{
   public class Exportacion
    {
        public String CondicionPago { get; set; }
        public String Nave { get; set; }
        public String CCredito { get; set; }
        public String BancoEmisor { get; set; }
        public String FechaEmbarque { get; set; }
        public String PuertoEmbarque { get; set; }
        public String PuertoDestino { get; set; }
        public String RegExportacion { get; set; }
        public String AWL { get; set; }
        public String NPedido { get; set; }
        public String FOB { get; set; }
        public String Flete { get; set; }
        public String NContenedor { get; set; }
        public String TotalCajas { get; set; }
        public String Incoterms { get; set; }
        public String Proformas { get; set; }
        public String PesoBruto { get; set; }
        public String PesoNeto { get; set; }
        public String DescripcionGeneral { get; set; }
        public Exportacion() { }
    }
}
