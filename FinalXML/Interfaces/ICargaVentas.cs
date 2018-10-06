using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using DevComponents.DotNetBar.Controls;
using System.Text;
using FinalXML.Entidades;

namespace FinalXML.Interfaces
{
    interface ICargaVentas
    {
        Boolean Update(clsCargaVentas ven);
        clsCargaVentas LeerVenta(String Sigla, String Serie, String Numeracion);
        clsCargaVentas LeerVenta(String NumRuc, String Sigla, String Serie, String Numeracion);
        List<DetalleDocumento> LeerVentaDetalle(String Sigla, String Serie, String Numeracion);
        DataTable CargaVentas(DateTime desde, DateTime hasta);
        DataTable CargaDocumentos(String RucEmi ,DateTime desde, DateTime hasta, String CTipoDoc);
        DataTable CargaDocumentos(String RucEmi, DateTime desde, DateTime hasta, String CTipoDoc, int Estado);
        DataTable LeerDetalle(String Sigla, String Serie, String Numeracion);
        DataTable LeerDetalle(String NumRuc ,String Sigla, String Serie, String Numeracion);
        Boolean ActualizarEstadoResumen(String NumRuc, String Ticket);
    }
}
