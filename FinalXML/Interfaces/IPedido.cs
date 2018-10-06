using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using DevComponents.DotNetBar.Controls;
using System.Text;
using FinalXML.Entidades;


namespace FinalXML.Interfaces
{
    interface IPedido
    {
        clsPedido LeerPedido(String IdPedido);
        DataTable CargaPedidos(DateTime FInicio, DateTime FFin);
        DataTable LeerDetalle(String IDPedido);
    }
}
