using Servicios.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Servicios.Class.ObjPeticiones
{
    public class RQLesson
    {
        public string professor_number { get; set; }
        public string professor_password { get; set; }
        public int ID_course { get; set; }
        public Lessons lesson { get; set; }
    }
}