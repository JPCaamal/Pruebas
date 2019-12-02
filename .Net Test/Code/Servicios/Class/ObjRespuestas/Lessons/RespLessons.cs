using Servicios.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Servicios.Class.ObjRespuestas
{
    public class ResponseLessons
    {
        public string estatus { get; set; }
        public CodigosRespuesta.codigo code { get; set; }
    }

    public class ResponseAddLesson
    {
        public ResponseLessons Response { get; set; }
    }


    public class ResponseListLesson
    {
        public ResponseLessons Response { get; set; }
        public List<Lesson> Lessons { get; set; }
    }
}