using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalXML.Entidades
{
    public class clsPedido
    {
        public string IdPedido { get; set; }
        public String Sigla { get; set; }
        public String Serie { get; set; }
        public String Numeracion { get; set; }
        public DateTime FechaEmision { get; set; }
        public String NumDocCliente { get; set; }
        public String Cliente { get; set; }
        public String DirCliente { get; set; }
        public Decimal Total { get; set; }
        public Decimal SubTotal { get; set; }
        public Decimal IGV { get; set; }

        public string MontoEnLetras { get; set; }
        public string MontoEnLetrasDolares { get; set; }
        public string Moneda { get; set; }
        public string MonedaLetra { get; set; }
        public List<clsDetallePedido> Items { get; set; }

        public clsPedido() {

            Items = new List<clsDetallePedido>();
        }
    }
}
