using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalXML
{
   public class ClsDatosReportes
    {
        public string IdDocumento { get; set; }

        public string FechaEmision { get; set; }
        public decimal Gravadas { get; set; }
        public decimal Gratuitas { get; set; }
        public decimal Inafectas { get; set; }
        public decimal Exoneradas { get; set; }
        public decimal TotalVenta { get; set; }
        public decimal TotalIgv { get; set; }
        public decimal SubTotalVentas { get; set; }
        public string MontoEnLetras { get; set; }
        public string Moneda { get; set; }
        public string MonedaLetra { get; set; }
        public string MonedaLetraDolar { get; set; }
        public string TextoMoneda { get; set; }
        public string Logos { get; set; }
        public DateTime FechaVencimiento { get; set; }

    }
}
