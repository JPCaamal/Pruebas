using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Servicios.Class
{
    public class CodigosRespuesta
    {
        //Fuente: https://tools.ietf.org/html/rfc7231#section-6.6.1 02-05-18 PCAAMAL
        public enum codigo : int
        {
            OK = 200,
            BAD_REQUEST = 400,
            UNAUTHORIZED = 401,
            FORBIDDEN = 403,           
            NOT_FOUND = 404,
            INTERNAL_SERVER_ERROR = 500
        };
    }
}