using Servicios.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Servicios.Class.ObjRespuestas
{
    public class ResponseCourse
    {
        public string estatus { get; set; }
        public CodigosRespuesta.codigo code { get; set; }
    }

    public class ResponseAddCourse
    {
        public ResponseCourse Response { get; set; }
    }

    
    public class ResponseListCourse
    {
        public ResponseCourse Response { get; set; }
        public List<Course> Courses { get; set; }
    }
}