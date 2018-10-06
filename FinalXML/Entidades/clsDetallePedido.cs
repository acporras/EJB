using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalXML.Entidades
{
    public class clsDetallePedido
    {
        public int Id { get; set; }
        public decimal Cantidad { get; set; }
        public string UnidadMedida { get; set; }
        public decimal Suma { get; set; }
        public decimal TotalVenta { get; set; }
        public decimal SubTotalVenta { get; set; }
        public decimal PrecioUnitario { get; set; }
        public string TipoPrecio { get; set; }
        public decimal Impuesto { get; set; }
        public string TipoImpuesto { get; set; }
        public decimal ImpuestoSelectivo { get; set; }
        public decimal OtroImpuesto { get; set; }
        public string Descripcion { get; set; }
        public string CodigoItem { get; set; }
        public decimal PrecioReferencial { get; set; }
        public string UnidadCliente { get; set; }
        public clsDetallePedido()
        {
            //Id = 1;
            UnidadMedida = "NIU";//Unidad por defecto - Ver tabla de unidades
            TipoPrecio = "01"; //Tipo de Precio de Venta Unitario - Ver tabla
            TipoImpuesto = "10"; //Ver tabla tipo de impuesto
        }
    }
}
