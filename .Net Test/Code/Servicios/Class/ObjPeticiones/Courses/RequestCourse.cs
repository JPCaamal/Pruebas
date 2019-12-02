using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Servicios.Models;

namespace Servicios.Class.ObjPeticiones
{
    public class RequestCourse
    {
        public RequestCourse(Courses courses, string professor_number, string professor_password)
        {
            RQ = new RQCourse();
            RQ.courses = courses;
            RQ.professor_number = professor_number;
            RQ.professor_password = professor_password;
        }
        private RQCourse rq;
        public RQCourse RQ
        {
            get { return rq; }
            set { rq = value; }
        }           
    }
}