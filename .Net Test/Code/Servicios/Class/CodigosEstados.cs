using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Servicios.Class
{
    static class CodigosEstados
    {
        public enum codigo : int { 
            respuestaCorrecta = 3, 
            respuestaCorrectaConErroresValidacion = 2, 
            errorServidor = 1, 
            errorFatal = 0,
            errorCliente = 4,
        };

        public enum codidoWebService : int { 
            OK = 200,
            SOLICITUDINCORRECTA = 400,
            ACCESOINCORRECTO = 401,
            CUENTASINPERMISOS = 403,
            SINRESULTADOS = 404,
            ERRORGENERICO = 500
        }
    }
}