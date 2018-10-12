using System;

namespace FE.InterfaceService
{
    class BaseDatosException : ApplicationException
    {
        public BaseDatosException(string mensaje,Exception original) : base(mensaje, original) { }

        public BaseDatosException(string mensaje) : base(mensaje) { }

    }
}
