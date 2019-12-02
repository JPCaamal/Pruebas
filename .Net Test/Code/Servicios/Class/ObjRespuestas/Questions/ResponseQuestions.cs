using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Servicios.Models;

namespace Servicios.Class.ObjRespuestas
{
    public class ResponseAddQuestions
    {
        public ResponseAddQuestions(ResponseQuestion Respuesta)
        {
            Response = new ResponseAddQuestion();
            Response.Response = Respuesta;
        }
        private ResponseAddQuestion response;
        public ResponseAddQuestion Response
        {
            get { return response; }
            set { response = value; }
        }
    }

    public class ResponseListQuestions
    {
        public ResponseListQuestions(ResponseQuestion Respuesta, List<Questions> Questions)
        {
            Response = new ResponseListQuestion();
            Response.Response = Respuesta;
            Response.Questions = Questions;
        }
        private ResponseListQuestion response;
        public ResponseListQuestion Response
        {
            get { return response; }
            set { response = value; }
        }
    }
}