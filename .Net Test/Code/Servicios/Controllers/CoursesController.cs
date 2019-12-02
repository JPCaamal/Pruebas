using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Servicios.Class.ObjRespuestas;
using Servicios.Class.ObjPeticiones;
using Servicios.Class;
using Newtonsoft.Json;
using System.IO;
using Servicios.Models.AccesoADatos;
using Servicios.Models;

namespace Servicios.Controllers
{
    public class CoursesController : Controller
    {
        public String AddCourse()
        {
            String JSON;
            try
            {
                Response.ContentType = "application/json; charset=UTF-8";
                String metodoDeEnvioHTTP = System.Web.HttpContext.Current.Request.HttpMethod;

                if (metodoDeEnvioHTTP != "POST")
                {

                    ResponseCourse Respuesta = new ResponseCourse();
                    Respuesta.code = CodigosRespuesta.codigo.INTERNAL_SERVER_ERROR;
                    Respuesta.estatus = MensajesEstados.ERROR_POST_REQUEST;

                    JSON = JsonConvert.SerializeObject(new ResponseAddCourses(Respuesta));
                }
                else
                {
                    string POST;
                    using (Stream receiveStream = Request.InputStream)
                    {
                        using (StreamReader readStream = new StreamReader(receiveStream, Request.ContentEncoding))
                        {
                            POST = readStream.ReadToEnd();
                        }
                    }
                    if (POST == null || POST == "")
                    {
                        ResponseCourse Respuesta = new ResponseCourse();
                        Respuesta.code = CodigosRespuesta.codigo.INTERNAL_SERVER_ERROR;
                        Respuesta.estatus = MensajesEstados.ErrorFatal;
                        JSON = JsonConvert.SerializeObject(new ResponseAddCourses(Respuesta));
                    }
                    else
                    {
                        RequestCourse Parametros = JsonConvert.DeserializeObject<RequestCourse>(POST);
                        string Mensaje = "";
                        if (parametrosValidos(Parametros, ref Mensaje))
                        {
                            ADCourses coursesAD = new ADCourses();
                            ResponseCourse Respuesta =  coursesAD.addCourse(Parametros);
                            JSON = JsonConvert.SerializeObject(new ResponseAddCourses(Respuesta));
                        }
                        else
                        {
                            ResponseCourse Respuesta = new ResponseCourse();
                            Respuesta.estatus = Mensaje;
                            Respuesta.code = CodigosRespuesta.codigo.BAD_REQUEST;
                            JSON = JsonConvert.SerializeObject(new ResponseAddCourses(Respuesta));
                        }
                    }
                }
            }
            catch (Exception e)
            {
                ResponseCourse Respuesta = new ResponseCourse();
                Respuesta.estatus = MensajesEstados.ErrorFatal + e.Message.ToString();
                Respuesta.code = CodigosRespuesta.codigo.INTERNAL_SERVER_ERROR;
                JSON = JsonConvert.SerializeObject(new ResponseAddCourses(Respuesta));
            }
            return JSON;
        }
        public String EditCourse()
        {
            String JSON;
            try
            {
                Response.ContentType = "application/json; charset=UTF-8";
                String metodoDeEnvioHTTP = System.Web.HttpContext.Current.Request.HttpMethod;

                if (metodoDeEnvioHTTP != "POST")
                {

                    ResponseCourse Respuesta = new ResponseCourse();
                    Respuesta.code = CodigosRespuesta.codigo.INTERNAL_SERVER_ERROR;
                    Respuesta.estatus = MensajesEstados.ERROR_POST_REQUEST;

                    JSON = JsonConvert.SerializeObject(new ResponseAddCourses(Respuesta));
                }
                else
                {
                    string POST;
                    using (Stream receiveStream = Request.InputStream)
                    {
                        using (StreamReader readStream = new StreamReader(receiveStream, Request.ContentEncoding))
                        {
                            POST = readStream.ReadToEnd();
                        }
                    }
                    if (POST == null || POST == "")
                    {
                        ResponseCourse Respuesta = new ResponseCourse();
                        Respuesta.code = CodigosRespuesta.codigo.INTERNAL_SERVER_ERROR;
                        Respuesta.estatus = MensajesEstados.ErrorFatal;
                        JSON = JsonConvert.SerializeObject(new ResponseAddCourses(Respuesta));
                    }
                    else
                    {
                        RequestCourse Parametros = JsonConvert.DeserializeObject<RequestCourse>(POST);
                        string Mensaje = "";
                        if (parametrosValidosEdit(Parametros, ref Mensaje))
                        {
                            ADCourses coursesAD = new ADCourses();
                            ResponseCourse Respuesta = coursesAD.editCourse(Parametros);
                            JSON = JsonConvert.SerializeObject(new ResponseAddCourses(Respuesta));
                        }
                        else
                        {
                            ResponseCourse Respuesta = new ResponseCourse();
                            Respuesta.estatus = Mensaje;
                            Respuesta.code = CodigosRespuesta.codigo.BAD_REQUEST;
                            JSON = JsonConvert.SerializeObject(new ResponseAddCourses(Respuesta));
                        }
                    }
                }
            }
            catch (Exception e)
            {
                ResponseCourse Respuesta = new ResponseCourse();
                Respuesta.estatus = MensajesEstados.ErrorFatal + e.Message.ToString();
                Respuesta.code = CodigosRespuesta.codigo.INTERNAL_SERVER_ERROR;
                JSON = JsonConvert.SerializeObject(new ResponseAddCourses(Respuesta));
            }
            return JSON;
        }
        public String DeleteCourse()
        {
            String JSON;
            try
            {
                Response.ContentType = "application/json; charset=UTF-8";
                String metodoDeEnvioHTTP = System.Web.HttpContext.Current.Request.HttpMethod;

                if (metodoDeEnvioHTTP != "POST")
                {

                    ResponseCourse Respuesta = new ResponseCourse();
                    Respuesta.code = CodigosRespuesta.codigo.INTERNAL_SERVER_ERROR;
                    Respuesta.estatus = MensajesEstados.ERROR_POST_REQUEST;

                    JSON = JsonConvert.SerializeObject(new ResponseAddCourses(Respuesta));
                }
                else
                {
                    string POST;
                    using (Stream receiveStream = Request.InputStream)
                    {
                        using (StreamReader readStream = new StreamReader(receiveStream, Request.ContentEncoding))
                        {
                            POST = readStream.ReadToEnd();
                        }
                    }
                    if (POST == null || POST == "")
                    {
                        ResponseCourse Respuesta = new ResponseCourse();
                        Respuesta.code = CodigosRespuesta.codigo.INTERNAL_SERVER_ERROR;
                        Respuesta.estatus = MensajesEstados.ErrorFatal;
                        JSON = JsonConvert.SerializeObject(new ResponseAddCourses(Respuesta));
                    }
                    else
                    {
                        RequestCourse Parametros = JsonConvert.DeserializeObject<RequestCourse>(POST);
                        string Mensaje = "";
                        if (parametrosValidosDelete(Parametros, ref Mensaje))
                        {
                            ADCourses coursesAD = new ADCourses();
                            ResponseCourse Respuesta = coursesAD.deleteCourse(Parametros);
                            JSON = JsonConvert.SerializeObject(new ResponseAddCourses(Respuesta));
                        }
                        else
                        {
                            ResponseCourse Respuesta = new ResponseCourse();
                            Respuesta.estatus = Mensaje;
                            Respuesta.code = CodigosRespuesta.codigo.BAD_REQUEST;
                            JSON = JsonConvert.SerializeObject(new ResponseAddCourses(Respuesta));
                        }
                    }
                }
            }
            catch (Exception e)
            {
                ResponseCourse Respuesta = new ResponseCourse();
                Respuesta.estatus = MensajesEstados.ErrorFatal + e.Message.ToString();
                Respuesta.code = CodigosRespuesta.codigo.INTERNAL_SERVER_ERROR;
                JSON = JsonConvert.SerializeObject(new ResponseAddCourses(Respuesta));
            }
            return JSON;
        }
        public String getListCourse()
        {
            String JSON;
            try
            {
                Response.ContentType = "application/json; charset=UTF-8";
                String metodoDeEnvioHTTP = System.Web.HttpContext.Current.Request.HttpMethod;

                if (metodoDeEnvioHTTP != "POST")
                {

                    ResponseCourse Respuesta = new ResponseCourse();
                    Respuesta.code = CodigosRespuesta.codigo.INTERNAL_SERVER_ERROR;
                    Respuesta.estatus = MensajesEstados.ERROR_POST_REQUEST;

                    JSON = JsonConvert.SerializeObject(new ResponseListCourses(Respuesta,null));
                }
                else
                {
                    string POST;
                    using (Stream receiveStream = Request.InputStream)
                    {
                        using (StreamReader readStream = new StreamReader(receiveStream, Request.ContentEncoding))
                        {
                            POST = readStream.ReadToEnd();
                        }
                    }
                    if (POST == null || POST == "")
                    {
                        ResponseCourse Respuesta = new ResponseCourse();
                        Respuesta.code = CodigosRespuesta.codigo.INTERNAL_SERVER_ERROR;
                        Respuesta.estatus = MensajesEstados.ErrorFatal;
                        JSON = JsonConvert.SerializeObject(new ResponseListCourses(Respuesta,null));
                    }
                    else
                    {
                        RequestCourse Parametros = JsonConvert.DeserializeObject<RequestCourse>(POST);
                        string Mensaje = "";
                        if (parametrosValidosgetList(Parametros, ref Mensaje))
                        {
                            ADCourses coursesAD = new ADCourses();
                            ResponseListCourse Respuesta = coursesAD.getListCourse(Parametros);
                            JSON = JsonConvert.SerializeObject(new ResponseListCourses(Respuesta.Response,Respuesta.Courses));
                        }
                        else
                        {
                            ResponseCourse Respuesta = new ResponseCourse();
                            Respuesta.estatus = Mensaje;
                            Respuesta.code = CodigosRespuesta.codigo.BAD_REQUEST;
                            JSON = JsonConvert.SerializeObject(new ResponseListCourses(Respuesta,null));
                        }
                    }
                }
            }
            catch (Exception e)
            {
                ResponseCourse Respuesta = new ResponseCourse();
                Respuesta.estatus = MensajesEstados.ErrorFatal + e.Message.ToString();
                Respuesta.code = CodigosRespuesta.codigo.INTERNAL_SERVER_ERROR;
                JSON = JsonConvert.SerializeObject(new ResponseListCourses(Respuesta,null));
            }
            return JSON;
        }


        #region Validar request
        protected bool parametrosValidos(RequestCourse Parametros, ref string mensaje)
        {
            bool valido = true;
            string mensajeParametros = "Parámetros incorrectos: ";
            if (Parametros.RQ.professor_number == null || Parametros.RQ.professor_number.Trim() == "")
            {
                mensajeParametros += "professor_number ";
                valido = false;
            }
            if (Parametros.RQ.professor_password == null || Parametros.RQ.professor_password.Trim() == "")
            {
                mensajeParametros += "professor_password ";
                valido = false;
            }
            if (Parametros.RQ.courses == null )
            {
                mensajeParametros += "courses ";
                valido = false;
            }
            if (Parametros.RQ.courses.course_name == null || Parametros.RQ.courses.course_name.Trim() == "")
            {
                mensajeParametros += "course_name ";
                valido = false;
            }
            if (Parametros.RQ.courses.course_lessons == null || Parametros.RQ.courses.course_lessons.Count == 0)
            {
                mensajeParametros += "course_lessons ";
                valido = false;
            }
            else
            {
                foreach (Lessons lesson in Parametros.RQ.courses.course_lessons)
                {
                    if (lesson.lesson_name == null || lesson.lesson_name.Trim() == "")
                    {
                        mensajeParametros += "lesson_name ";
                        valido = false;
                        break;
                    }
                    if (lesson.lesson_minPoints == null)
                    {
                        mensajeParametros += "lesson_minPoints ";
                        valido = false;
                        break;
                    }
                    if (lesson.lesson_questions == null || lesson.lesson_questions.Count == 0)
                    {
                        mensajeParametros += "lesson_questions ";
                        valido = false;
                        break;
                    }
                    else {
                        foreach (Questions question in lesson.lesson_questions)
                        {
                            if (question.question_description == null || question.question_description.Trim() == "")
                            {
                                mensajeParametros += "question_description ";
                                valido = false;
                                break;
                            }
                            if (question.question_points == null )
                            {
                                mensajeParametros += "question_points ";
                                valido = false;
                                break;
                            }
                            if (question.question_type == null || (question.question_type != 'A' && 
                                                                   question.question_type != 'B' && 
                                                                   question.question_type != 'C' && 
                                                                   question.question_type != 'D'))
                            {
                                mensajeParametros += "question_type ";
                                valido = false;
                                break;
                            }
                            if (question.question_options == null || question.question_options.Count == 0)
                            {
                                mensajeParametros += "question_options ";
                                valido = false;
                                break;
                            }
                            else {
                                foreach (Options options in question.question_options)
                                {
                                    if (options.option_description == null || options.option_description.Trim() == "")
                                    {
                                        mensajeParametros += "option_description ";
                                        valido = false;
                                        break;
                                    }
                                    if (options.option_value == null)
                                    {
                                        mensajeParametros += "option_value ";
                                        valido = false;
                                        break;
                                    }
                                }
                            }
 
                        }
                    }
                }
            }
            
            mensaje = mensajeParametros;
            return valido;
        }
        protected bool parametrosValidosEdit(RequestCourse Parametros, ref string mensaje)
        {
            bool valido = true;
            string mensajeParametros = "Parámetros incorrectos: ";
            if (Parametros.RQ.professor_number == null || Parametros.RQ.professor_number.Trim() == "")
            {
                mensajeParametros += "professor_number ";
                valido = false;
            }
            if (Parametros.RQ.professor_password == null || Parametros.RQ.professor_password.Trim() == "")
            {
                mensajeParametros += "professor_password ";
                valido = false;
            }
            if (Parametros.RQ.courses == null)
            {
                mensajeParametros += "courses ";
                valido = false;
            }
            else {
                if (Parametros.RQ.courses.ID_course == null)
                {
                    mensajeParametros += "ID_course ";
                    valido = false;
                }
                if (Parametros.RQ.courses.course_name == null || Parametros.RQ.courses.course_name.Trim() == "")
                {
                    mensajeParametros += "course_name ";
                    valido = false;
                }
            }
          
            mensaje = mensajeParametros;
            return valido;
        }
        protected bool parametrosValidosDelete(RequestCourse Parametros, ref string mensaje)
        {
            bool valido = true;
            string mensajeParametros = "Parámetros incorrectos: ";
            if (Parametros.RQ.professor_number == null || Parametros.RQ.professor_number.Trim() == "")
            {
                mensajeParametros += "professor_number ";
                valido = false;
            }
            if (Parametros.RQ.professor_password == null || Parametros.RQ.professor_password.Trim() == "")
            {
                mensajeParametros += "professor_password ";
                valido = false;
            }
            if (Parametros.RQ.courses == null)
            {
                mensajeParametros += "courses ";
                valido = false;
            }
            else
            {
                if (Parametros.RQ.courses.ID_course == null)
                {
                    mensajeParametros += "ID_course ";
                    valido = false;
                }  
            }
                   
            mensaje = mensajeParametros;
            return valido;
        }
        protected bool parametrosValidosgetList(RequestCourse Parametros, ref string mensaje)
        {
            bool valido = true;
            string mensajeParametros = "Parámetros incorrectos: ";
            if (Parametros.RQ.professor_number == null || Parametros.RQ.professor_number.Trim() == "")
            {
                mensajeParametros += "professor_number ";
                valido = false;
            }
            if (Parametros.RQ.professor_password == null || Parametros.RQ.professor_password.Trim() == "")
            {
                mensajeParametros += "professor_password ";
                valido = false;
            }          
            mensaje = mensajeParametros;
            return valido;
        }
        #endregion
    }
}
