using System;

namespace FE.InterfaceConsole
{
    class BaseDatosException : ApplicationException
    {
        public BaseDatosException(string mensaje,Exception original) : base(mensaje, original) { }

        public BaseDatosException(string mensaje) : base(mensaje) { }

    }
}
