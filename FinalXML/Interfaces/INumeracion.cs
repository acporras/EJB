using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FinalXML.Entidades;
namespace FinalXML.Interfaces
{
     interface INumeracion
    {
       // Boolean ActualizaNumeracion(clsNumeracion Numeracion);
       clsNumeracion BuscaNumeracion(String Numeracion);
       /* clsNumeracion BuscaNumeracionDocBaja(String Numeracion);
        clsNumeracion BuscaNumeracionFac();*/
       
    }
}
