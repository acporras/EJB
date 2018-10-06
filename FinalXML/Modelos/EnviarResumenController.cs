using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalXML
{
    public class EnviarResumenController
    {
        public EnviarDocumentoResponse EnviarResumenResponse(EnviarDocumentoRequest request)
        {
            var response = new EnviarDocumentoResponse();
            var serializador = new Serializador();
            //var nombreArchivo = $"{request.Ruc}-{request.TipoDocumento}-{request.IdDocumento}";
            var nombreArchivo = $"{request.Ruc}-{request.IdDocumento}"; // Ver si se reemplza luego

            try
            {
                var tramaZip = serializador.GenerarZip(request.TramaXmlFirmado, nombreArchivo);

                var conexionSunat = new ConexionSunat(new ConexionSunat.Parametros
                {
                    Ruc = request.Ruc,
                    UserName = request.UsuarioSol,
                    Password = request.ClaveSol,
                    EndPointUrl = request.EndPointUrl
                });

                var resultado = conexionSunat.EnviarResumenBaja(tramaZip, $"{nombreArchivo}.zip");

                if (resultado.Item2)
                {
                    response.NroTicket = resultado.Item1;
                    response.Exito = true;
                    response.NombreArchivo = nombreArchivo;
                }
                else
                {
                    response.MensajeError = resultado.Item1;
                    response.Exito = false;
                }
            }
            catch (Exception ex)
            {
                response.MensajeError = ex.Message;
                response.Pila = ex.StackTrace;
                response.Exito = false;
            }

            return response;
        }
    }
}
