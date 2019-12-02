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
    public class ADCourses
    {
        public ResponseCourse addCourse(RequestCourse Parametros)
        {
            ResponseCourse respuesta = new ResponseCourse();
            coursesCore core = new coursesCore();
            string mensaje = "";
            int idProfessor = new professorsCore().validateProfessor(Parametros.RQ.professor_number, Parametros.RQ.professor_password, ref mensaje);
            if (idProfessor != -1)
            {
                bool Correcto = core.addCourse(Parametros.RQ.courses, ref mensaje);
                if (Correcto)
                {
                    ResponseCourse Respuesta = new ResponseCourse();
                    Respuesta.code = CodigosRespuesta.codigo.OK;
                    Respuesta.estatus = mensaje;
                    respuesta = Respuesta;
                }
                else
                {
                    ResponseCourse Respuesta = new ResponseCourse();
                    Respuesta.code = CodigosRespuesta.codigo.INTERNAL_SERVER_ERROR;
                    Respuesta.estatus = mensaje;
                    respuesta = Respuesta;
                }
            }
            else
            {
                ResponseCourse Respuesta = new ResponseCourse();
                Respuesta.code = CodigosRespuesta.codigo.FORBIDDEN;
                Respuesta.estatus = MensajesEstados.ErrorAcceso;
                respuesta = Respuesta;
            }         
            return respuesta;
        }

        public ResponseCourse editCourse(RequestCourse Parametros)
        {
            ResponseCourse respuesta = new ResponseCourse();
            coursesCore core = new coursesCore();
            string mensaje = "";
            int idProfessor = new professorsCore().validateProfessor(Parametros.RQ.professor_number, Parametros.RQ.professor_password, ref mensaje);
            if (idProfessor != -1)
            {
                bool Correcto = core.editCourse(Parametros.RQ.courses, ref mensaje);
                if (Correcto)
                {
                    ResponseCourse Respuesta = new ResponseCourse();
                    Respuesta.code = CodigosRespuesta.codigo.OK;
                    Respuesta.estatus = mensaje;
                    respuesta = Respuesta;
                }
                else
                {
                    ResponseCourse Respuesta = new ResponseCourse();
                    Respuesta.code = CodigosRespuesta.codigo.INTERNAL_SERVER_ERROR;
                    Respuesta.estatus = mensaje;
                    respuesta = Respuesta;
                }
            }
            else
            {
                ResponseCourse Respuesta = new ResponseCourse();
                Respuesta.code = CodigosRespuesta.codigo.FORBIDDEN;
                Respuesta.estatus = MensajesEstados.ErrorAcceso;
                respuesta = Respuesta;
            }
           
            return respuesta;
        }

        public ResponseCourse deleteCourse(RequestCourse Parametros)
        {
            ResponseCourse respuesta = new ResponseCourse();
            coursesCore core = new coursesCore();
            string mensaje = "";
            int idProfessor = new professorsCore().validateProfessor(Parametros.RQ.professor_number, Parametros.RQ.professor_password, ref mensaje);
            if (idProfessor != -1)
            {
                bool Correcto = core.deleteCourse(Parametros.RQ.courses, ref mensaje);
                if (Correcto)
                {
                    ResponseCourse Respuesta = new ResponseCourse();
                    Respuesta.code = CodigosRespuesta.codigo.OK;
                    Respuesta.estatus = mensaje;
                    respuesta = Respuesta;
                }
                else
                {
                    ResponseCourse Respuesta = new ResponseCourse();
                    Respuesta.code = CodigosRespuesta.codigo.INTERNAL_SERVER_ERROR;
                    Respuesta.estatus = mensaje;
                    respuesta = Respuesta;
                }
            }
            else
            {
                ResponseCourse Respuesta = new ResponseCourse();
                Respuesta.code = CodigosRespuesta.codigo.FORBIDDEN;
                Respuesta.estatus = MensajesEstados.ErrorAcceso;
                respuesta = Respuesta;
            }
            
            return respuesta;
        }

        public ResponseListCourse getListCourse(RequestCourse Parametros)
        {
            ResponseListCourse respuesta = new ResponseListCourse();
            coursesCore core = new coursesCore();
            string mensaje = "";
            int idProfessor = new professorsCore().validateProfessor(Parametros.RQ.professor_number, Parametros.RQ.professor_password, ref mensaje);
            if (idProfessor != -1)
            {
                List<Course> ListCourses = core.getListCourse(ref mensaje);
                if (ListCourses.Count > 0)
                {
                    ResponseCourse Respuesta = new ResponseCourse();
                    Respuesta.code = CodigosRespuesta.codigo.OK;
                    Respuesta.estatus = mensaje;
                    respuesta.Response = Respuesta;
                    respuesta.Courses = ListCourses;
                }
                else
                {
                    ResponseCourse Respuesta = new ResponseCourse();
                    Respuesta.code = CodigosRespuesta.codigo.NOT_FOUND;
                    Respuesta.estatus = MensajesEstados.SIN_RESULTADOS;
                    respuesta.Response = Respuesta;
                    respuesta.Courses = null;
                }
            }
            else {
                ResponseCourse Respuesta = new ResponseCourse();
                Respuesta.code = CodigosRespuesta.codigo.FORBIDDEN;
                Respuesta.estatus = MensajesEstados.ErrorAcceso;
                respuesta.Response = Respuesta;
                respuesta.Courses = null;
            }
          
            return respuesta;
        }
    }
}