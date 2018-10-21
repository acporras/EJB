using System;

namespace FinalXML.BD
{
    class BaseDatosException : ApplicationException
    {
        public BaseDatosException(string mensaje,Exception original) : base(mensaje, original) { }

        public BaseDatosException(string mensaje) : base(mensaje) { }

    }
}
