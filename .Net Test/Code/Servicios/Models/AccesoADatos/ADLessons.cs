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
    public class ADLessons
    {
        public ResponseLessons addLesson(RequestLesson Parametros)
        {
            ResponseLessons respuesta = new ResponseLessons();
            lessonsCore core = new lessonsCore();
            string mensaje = "";
            int idProfessor = new professorsCore().validateProfessor(Parametros.RQ.professor_number, Parametros.RQ.professor_password, ref mensaje);
            if (idProfessor != -1)
            {
                bool Correcto = core.addLesson(Parametros, ref mensaje);
                if (Correcto)
                {
                    ResponseLessons Respuesta = new ResponseLessons();
                    Respuesta.code = CodigosRespuesta.codigo.OK;
                    Respuesta.estatus = mensaje;
                    respuesta = Respuesta;
                }
                else
                {
                    ResponseLessons Respuesta = new ResponseLessons();
                    Respuesta.code = CodigosRespuesta.codigo.INTERNAL_SERVER_ERROR;
                    Respuesta.estatus = mensaje;
                    respuesta = Respuesta;
                }
            }
            else
            {
                ResponseLessons Respuesta = new ResponseLessons();
                Respuesta.code = CodigosRespuesta.codigo.FORBIDDEN;
                Respuesta.estatus = MensajesEstados.ErrorAcceso;
                respuesta = Respuesta;
            } 
           
            return respuesta;
        }

        public ResponseLessons editLesson(RequestLesson Parametros)
        {
            ResponseLessons respuesta = new ResponseLessons();
            lessonsCore core = new lessonsCore();
            string mensaje = "";
            int idProfessor = new professorsCore().validateProfessor(Parametros.RQ.professor_number, Parametros.RQ.professor_password, ref mensaje);
            if (idProfessor != -1)
            {
                bool Correcto = core.editLesson(Parametros, ref mensaje);
                if (Correcto)
                {
                    ResponseLessons Respuesta = new ResponseLessons();
                    Respuesta.code = CodigosRespuesta.codigo.OK;
                    Respuesta.estatus = mensaje;
                    respuesta = Respuesta;
                }
                else
                {
                    ResponseLessons Respuesta = new ResponseLessons();
                    Respuesta.code = CodigosRespuesta.codigo.INTERNAL_SERVER_ERROR;
                    Respuesta.estatus = mensaje;
                    respuesta = Respuesta;
                }
            }
            else
            {
                ResponseLessons Respuesta = new ResponseLessons();
                Respuesta.code = CodigosRespuesta.codigo.FORBIDDEN;
                Respuesta.estatus = MensajesEstados.ErrorAcceso;
                respuesta = Respuesta;
            } 
            return respuesta;
        }

        public ResponseLessons deleteLesson(RequestLesson Parametros)
        {
            ResponseLessons respuesta = new ResponseLessons();
            lessonsCore core = new lessonsCore();
            string mensaje = "";
            int idProfessor = new professorsCore().validateProfessor(Parametros.RQ.professor_number, Parametros.RQ.professor_password, ref mensaje);
            if (idProfessor != -1)
            {
                bool Correcto = core.deleteLesson(Parametros, ref mensaje);
                if (Correcto)
                {
                    ResponseLessons Respuesta = new ResponseLessons();
                    Respuesta.code = CodigosRespuesta.codigo.OK;
                    Respuesta.estatus = mensaje;
                    respuesta = Respuesta;
                }
                else
                {
                    ResponseLessons Respuesta = new ResponseLessons();
                    Respuesta.code = CodigosRespuesta.codigo.INTERNAL_SERVER_ERROR;
                    Respuesta.estatus = mensaje;
                    respuesta = Respuesta;
                }
            }
            else
            {
                ResponseLessons Respuesta = new ResponseLessons();
                Respuesta.code = CodigosRespuesta.codigo.FORBIDDEN;
                Respuesta.estatus = MensajesEstados.ErrorAcceso;
                respuesta = Respuesta;
            } 
           
            return respuesta;
        }

        public ResponseListLesson getListLessons(RequestLesson Parametros)
        {
            ResponseListLesson respuesta = new ResponseListLesson();
            lessonsCore core = new lessonsCore();
            string mensaje = "";
            int idProfessor = new professorsCore().validateProfessor(Parametros.RQ.professor_number, Parametros.RQ.professor_password, ref mensaje);
            if (idProfessor != -1)
            {
                List<Lesson> ListLessons = core.getListLesson(Parametros, ref mensaje);
                if (ListLessons != null && ListLessons.Count > 0)
                {
                    ResponseLessons Respuesta = new ResponseLessons();
                    Respuesta.code = CodigosRespuesta.codigo.OK;
                    Respuesta.estatus = mensaje;

                    respuesta.Response = Respuesta;
                    respuesta.Lessons = ListLessons;
                }
                else
                {
                    ResponseLessons Respuesta = new ResponseLessons();
                    Respuesta.code = CodigosRespuesta.codigo.NOT_FOUND;
                    Respuesta.estatus = MensajesEstados.SIN_RESULTADOS;

                    respuesta.Response = Respuesta;
                    respuesta.Lessons = null;
                }
            }
            else
            {
                ResponseLessons Respuesta = new ResponseLessons();
                Respuesta.code = CodigosRespuesta.codigo.FORBIDDEN;
                Respuesta.estatus = MensajesEstados.ErrorAcceso;
                respuesta.Response = Respuesta;
                respuesta.Lessons = null;
            } 
            
            return respuesta;
        }
    }
}