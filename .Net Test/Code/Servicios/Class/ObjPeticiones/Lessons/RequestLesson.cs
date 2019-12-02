using Servicios.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Servicios.Class.ObjPeticiones
{
    public class RequestLesson
    {
        public RequestLesson(string professor_number, string professor_password,int ID_course = 0, Lessons lesson = null)
        {
            RQ = new RQLesson();
            RQ.ID_course = ID_course;
            RQ.lesson = lesson;
            RQ.professor_number = professor_number;
            RQ.professor_password = professor_password;
        }
        private RQLesson rq;
        public RQLesson RQ
        {
            get { return rq; }
            set { rq = value; }
        }
    }
}