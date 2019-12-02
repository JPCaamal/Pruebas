using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Servicios.Models;

namespace Servicios.Class.ObjPeticiones
{
    public class RQQuestion
    {
        public int ID_lesson { get; set; }
        public string professor_number { get; set; }
        public string professor_password { get; set; }
        public Questions question { get; set; }
    }
}