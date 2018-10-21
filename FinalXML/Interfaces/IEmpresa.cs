using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using DevComponents.DotNetBar.Controls;
using System.Text;
using FinalXML.Entidades;

namespace FinalXML.Interfaces
{
    interface IEmpresa
    {
        DataTable CargaEmpresa();
        DataTable CargaEmpresa(String NumRuc);
        Contribuyente LeerEmpresa(String NumRuc);
        int GetCorrelativoMasivo(int codEmpresa, String TipoDoc);
        Boolean SetCorrelativoMasivo(int codEmpresa, String TipoDoc, int NeoCor);
        Boolean AnularDocumento(String NumRuc, String TipDoc, String Sersun, String NumSun);
        Boolean GuardarEmpresa(clsEmpresa empresa);
        Boolean ActualizarEmpresa(clsEmpresa empresa);
    }
}
