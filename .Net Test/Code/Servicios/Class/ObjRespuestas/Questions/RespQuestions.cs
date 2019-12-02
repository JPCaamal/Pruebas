using Servicios.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Servicios.Class.ObjRespuestas
{
    public class ResponseQuestion
    {
        public string estatus { get; set; }
        public CodigosRespuesta.codigo code { get; set; }
    }

    public class ResponseAddQuestion
    {
        public ResponseQuestion Response { get; set; }
    }


    public class ResponseListQuestion
    {
        public ResponseQuestion Response { get; set; }
        public List<Questions> Questions { get; set; }
    }
}