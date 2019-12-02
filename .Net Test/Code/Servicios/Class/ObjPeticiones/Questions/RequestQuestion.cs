using Servicios.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Servicios.Class.ObjPeticiones
{
    public class RequestQuestion
    {
        public RequestQuestion(string professor_number, string professor_password, int ID_lesson = 0, Questions question = null)
        {
            RQ = new RQQuestion();
            RQ.ID_lesson = ID_lesson;
            RQ.question = question;
            RQ.professor_number = professor_number;
            RQ.professor_password = professor_password;
        }
        private RQQuestion rq;
        public RQQuestion RQ
        {
            get { return rq; }
            set { rq = value; }
        }
    }
}