using Servicios.Class;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using Servicios.Class.ObjPeticiones;
using Servicios.Models.Core;
using Servicios.Class.ObjRespuestas;

namespace Servicios.Models.AccesoADatos
{
    public class ADQuestions
    {
        public ResponseQuestion addQuestion(RequestQuestion Parametros)
        {
            ResponseQuestion respuesta = new ResponseQuestion();
            questionsCore core = new questionsCore();
            string mensaje = "";
            int idProfessor = new professorsCore().validateProfessor(Parametros.RQ.professor_number, Parametros.RQ.professor_password, ref mensaje);
            if (idProfessor != -1)
            {
                bool Correcto = core.addQuestion(Parametros, ref mensaje);
                if (Correcto)
                {
                    ResponseQuestion Respuesta = new ResponseQuestion();
                    Respuesta.code = CodigosRespuesta.codigo.OK;
                    Respuesta.estatus = mensaje;
                    respuesta = Respuesta;
                }
                else
                {
                    ResponseQuestion Respuesta = new ResponseQuestion();
                    Respuesta.code = CodigosRespuesta.codigo.INTERNAL_SERVER_ERROR;
                    Respuesta.estatus = mensaje;
                    respuesta = Respuesta;
                }
            }
            else
            {
                ResponseQuestion Respuesta = new ResponseQuestion();
                Respuesta.code = CodigosRespuesta.codigo.FORBIDDEN;
                Respuesta.estatus = MensajesEstados.ErrorAcceso;
                respuesta = Respuesta;
               
            } 
           
            return respuesta;
        }

        public ResponseQuestion editQuestion(RequestQuestion Parametros)
        {
            ResponseQuestion respuesta = new ResponseQuestion();
            questionsCore core = new questionsCore();
            string mensaje = "";
            int idProfessor = new professorsCore().validateProfessor(Parametros.RQ.professor_number, Parametros.RQ.professor_password, ref mensaje);
            if (idProfessor != -1)
            {
                bool Correcto = core.editQuestion(Parametros, ref mensaje);
                if (Correcto)
                {
                    ResponseQuestion Respuesta = new ResponseQuestion();
                    Respuesta.code = CodigosRespuesta.codigo.OK;
                    Respuesta.estatus = mensaje;
                    respuesta = Respuesta;
                }
                else
                {
                    ResponseQuestion Respuesta = new ResponseQuestion();
                    Respuesta.code = CodigosRespuesta.codigo.INTERNAL_SERVER_ERROR;
                    Respuesta.estatus = mensaje;
                    respuesta = Respuesta;
                }
            }
            else
            {
                ResponseQuestion Respuesta = new ResponseQuestion();
                Respuesta.code = CodigosRespuesta.codigo.FORBIDDEN;
                Respuesta.estatus = MensajesEstados.ErrorAcceso;
                respuesta = Respuesta;

            }
            return respuesta;
        }

        public ResponseQuestion deleteQuestion(RequestQuestion Parametros)
        {
            ResponseQuestion respuesta = new ResponseQuestion();
            questionsCore core = new questionsCore();
            string mensaje = "";
            int idProfessor = new professorsCore().validateProfessor(Parametros.RQ.professor_number, Parametros.RQ.professor_password, ref mensaje);
            if (idProfessor != -1)
            {
                bool Correcto = core.deleteQuestion(Parametros, ref mensaje);
                if (Correcto)
                {
                    ResponseQuestion Respuesta = new ResponseQuestion();
                    Respuesta.code = CodigosRespuesta.codigo.OK;
                    Respuesta.estatus = mensaje;
                    respuesta = Respuesta;
                }
                else
                {
                    ResponseQuestion Respuesta = new ResponseQuestion();
                    Respuesta.code = CodigosRespuesta.codigo.INTERNAL_SERVER_ERROR;
                    Respuesta.estatus = mensaje;
                    respuesta = Respuesta;
                }
            }
            else
            {
                ResponseQuestion Respuesta = new ResponseQuestion();
                Respuesta.code = CodigosRespuesta.codigo.FORBIDDEN;
                Respuesta.estatus = MensajesEstados.ErrorAcceso;
                respuesta = Respuesta;

            }
           
            return respuesta;
        }

        public ResponseListQuestion getListQuestion(RequestQuestion Parametros)
        {
            ResponseListQuestion respuesta = new ResponseListQuestion();
            questionsCore core = new questionsCore();
            string mensaje = "";
            int idProfessor = new professorsCore().validateProfessor(Parametros.RQ.professor_number, Parametros.RQ.professor_password, ref mensaje);
            if (idProfessor != -1)
            {
                List<Questions> ListQuestions = core.getListQuestion(Parametros.RQ.ID_lesson, ref mensaje);
                if (ListQuestions.Count > 0)
                {
                    ResponseQuestion Respuesta = new ResponseQuestion();
                    Respuesta.code = CodigosRespuesta.codigo.OK;
                    Respuesta.estatus = mensaje;

                    respuesta.Response = Respuesta;
                    respuesta.Questions = ListQuestions;
                }
                else
                {
                    ResponseQuestion Respuesta = new ResponseQuestion();
                    Respuesta.code = CodigosRespuesta.codigo.NOT_FOUND;
                    Respuesta.estatus = MensajesEstados.SIN_RESULTADOS;

                    respuesta.Response = Respuesta;
                    respuesta.Questions = null;
                }
            }
            else
            {
                ResponseQuestion Respuesta = new ResponseQuestion();
                Respuesta.code = CodigosRespuesta.codigo.FORBIDDEN;
                Respuesta.estatus = MensajesEstados.ErrorAcceso;
                respuesta.Response = Respuesta;
                respuesta.Questions = null;

            }
            
            return respuesta;
        }
    }
}