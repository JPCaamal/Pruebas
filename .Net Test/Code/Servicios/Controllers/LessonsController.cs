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
    public class LessonsController : Controller
    {
        public String AddLesson()
        {
            String JSON;
            try
            {
                Response.ContentType = "application/json; charset=UTF-8";
                String metodoDeEnvioHTTP = System.Web.HttpContext.Current.Request.HttpMethod;

                if (metodoDeEnvioHTTP != "POST")
                {

                    ResponseLessons Respuesta = new ResponseLessons();
                    Respuesta.code = CodigosRespuesta.codigo.INTERNAL_SERVER_ERROR;
                    Respuesta.estatus = MensajesEstados.ERROR_POST_REQUEST;

                    JSON = JsonConvert.SerializeObject(new ResponseAddLessons(Respuesta));
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
                        ResponseLessons Respuesta = new ResponseLessons();
                        Respuesta.code = CodigosRespuesta.codigo.INTERNAL_SERVER_ERROR;
                        Respuesta.estatus = MensajesEstados.ErrorFatal;
                        JSON = JsonConvert.SerializeObject(new ResponseAddLessons(Respuesta));
                    }
                    else
                    {
                        RequestLesson Parametros = JsonConvert.DeserializeObject<RequestLesson>(POST);
                        string Mensaje = "";
                        if (parametrosValidos(Parametros, ref Mensaje))
                        {
                            ADLessons coursesAD = new ADLessons();
                            ResponseLessons Respuesta = coursesAD.addLesson(Parametros);
                            JSON = JsonConvert.SerializeObject(new ResponseAddLessons(Respuesta));
                        }
                        else
                        {
                            ResponseLessons Respuesta = new ResponseLessons();
                            Respuesta.estatus = Mensaje;
                            Respuesta.code = CodigosRespuesta.codigo.BAD_REQUEST;
                            JSON = JsonConvert.SerializeObject(new ResponseAddLessons(Respuesta));
                        }
                    }
                }
            }
            catch (Exception e)
            {
                ResponseLessons Respuesta = new ResponseLessons();
                Respuesta.estatus = MensajesEstados.ErrorFatal + e.Message.ToString();
                Respuesta.code = CodigosRespuesta.codigo.INTERNAL_SERVER_ERROR;
                JSON = JsonConvert.SerializeObject(new ResponseAddLessons(Respuesta));
            }
            return JSON;
        }
        public String EditLesson()
        {
            String JSON;
            try
            {
                Response.ContentType = "application/json; charset=UTF-8";
                String metodoDeEnvioHTTP = System.Web.HttpContext.Current.Request.HttpMethod;

                if (metodoDeEnvioHTTP != "POST")
                {

                    ResponseLessons Respuesta = new ResponseLessons();
                    Respuesta.code = CodigosRespuesta.codigo.INTERNAL_SERVER_ERROR;
                    Respuesta.estatus = MensajesEstados.ERROR_POST_REQUEST;

                    JSON = JsonConvert.SerializeObject(new ResponseAddLessons(Respuesta));
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
                        ResponseLessons Respuesta = new ResponseLessons();
                        Respuesta.code = CodigosRespuesta.codigo.INTERNAL_SERVER_ERROR;
                        Respuesta.estatus = MensajesEstados.ErrorFatal;
                        JSON = JsonConvert.SerializeObject(new ResponseAddLessons(Respuesta));
                    }
                    else
                    {
                        RequestLesson Parametros = JsonConvert.DeserializeObject<RequestLesson>(POST);
                        string Mensaje = "";
                        if (parametrosValidosEdit(Parametros, ref Mensaje))
                        {
                            ADLessons coursesAD = new ADLessons();
                            ResponseLessons Respuesta = coursesAD.editLesson(Parametros);
                            JSON = JsonConvert.SerializeObject(new ResponseAddLessons(Respuesta));
                        }
                        else
                        {
                            ResponseLessons Respuesta = new ResponseLessons();
                            Respuesta.estatus = Mensaje;
                            Respuesta.code = CodigosRespuesta.codigo.BAD_REQUEST;
                            JSON = JsonConvert.SerializeObject(new ResponseAddLessons(Respuesta));
                        }
                    }
                }
            }
            catch (Exception e)
            {
                ResponseLessons Respuesta = new ResponseLessons();
                Respuesta.estatus = MensajesEstados.ErrorFatal + e.Message.ToString();
                Respuesta.code = CodigosRespuesta.codigo.INTERNAL_SERVER_ERROR;
                JSON = JsonConvert.SerializeObject(new ResponseAddLessons(Respuesta));
            }
            return JSON;
        }
        public String DeleteLesson()
        {
            String JSON;
            try
            {
                Response.ContentType = "application/json; charset=UTF-8";
                String metodoDeEnvioHTTP = System.Web.HttpContext.Current.Request.HttpMethod;

                if (metodoDeEnvioHTTP != "POST")
                {

                    ResponseLessons Respuesta = new ResponseLessons();
                    Respuesta.code = CodigosRespuesta.codigo.INTERNAL_SERVER_ERROR;
                    Respuesta.estatus = MensajesEstados.ERROR_POST_REQUEST;

                    JSON = JsonConvert.SerializeObject(new ResponseAddLessons(Respuesta));
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
                        ResponseLessons Respuesta = new ResponseLessons();
                        Respuesta.code = CodigosRespuesta.codigo.INTERNAL_SERVER_ERROR;
                        Respuesta.estatus = MensajesEstados.ErrorFatal;
                        JSON = JsonConvert.SerializeObject(new ResponseAddLessons(Respuesta));
                    }
                    else
                    {
                        RequestLesson Parametros = JsonConvert.DeserializeObject<RequestLesson>(POST);
                        string Mensaje = "";
                        if (parametrosValidosDelete(Parametros, ref Mensaje))
                        {
                            ADLessons coursesAD = new ADLessons();
                            ResponseLessons Respuesta = coursesAD.deleteLesson(Parametros);
                            JSON = JsonConvert.SerializeObject(new ResponseAddLessons(Respuesta));
                        }
                        else
                        {
                            ResponseLessons Respuesta = new ResponseLessons();
                            Respuesta.estatus = Mensaje;
                            Respuesta.code = CodigosRespuesta.codigo.BAD_REQUEST;
                            JSON = JsonConvert.SerializeObject(new ResponseAddLessons(Respuesta));
                        }
                    }
                }
            }
            catch (Exception e)
            {
                ResponseLessons Respuesta = new ResponseLessons();
                Respuesta.estatus = MensajesEstados.ErrorFatal + e.Message.ToString();
                Respuesta.code = CodigosRespuesta.codigo.INTERNAL_SERVER_ERROR;
                JSON = JsonConvert.SerializeObject(new ResponseAddLessons(Respuesta));
            }
            return JSON;
        }
        public String getListLesson()
        {
            String JSON;
            try
            {
                Response.ContentType = "application/json; charset=UTF-8";
                String metodoDeEnvioHTTP = System.Web.HttpContext.Current.Request.HttpMethod;

                if (metodoDeEnvioHTTP != "POST")
                {

                    ResponseLessons Respuesta = new ResponseLessons();
                    Respuesta.code = CodigosRespuesta.codigo.INTERNAL_SERVER_ERROR;
                    Respuesta.estatus = MensajesEstados.ERROR_POST_REQUEST;

                    JSON = JsonConvert.SerializeObject(new ResponseListLessons(Respuesta, null));
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
                        ResponseLessons Respuesta = new ResponseLessons();
                        Respuesta.code = CodigosRespuesta.codigo.INTERNAL_SERVER_ERROR;
                        Respuesta.estatus = MensajesEstados.ErrorFatal;
                        JSON = JsonConvert.SerializeObject(new ResponseListLessons(Respuesta, null));
                    }
                    else
                    {
                        RequestLesson Parametros = JsonConvert.DeserializeObject<RequestLesson>(POST);
                        string Mensaje = "";
                        if (parametrosValidosgetList(Parametros, ref Mensaje))
                        {
                            ADLessons coursesAD = new ADLessons();
                            ResponseListLesson Respuesta = coursesAD.getListLessons(Parametros);
                            JSON = JsonConvert.SerializeObject(new ResponseListLessons(Respuesta.Response, Respuesta.Lessons));
                        }
                        else
                        {
                            ResponseLessons Respuesta = new ResponseLessons();
                            Respuesta.estatus = Mensaje;
                            Respuesta.code = CodigosRespuesta.codigo.BAD_REQUEST;
                            JSON = JsonConvert.SerializeObject(new ResponseListLessons(Respuesta, null));
                        }
                    }
                }
            }
            catch (Exception e)
            {
                ResponseLessons Respuesta = new ResponseLessons();
                Respuesta.estatus = MensajesEstados.ErrorFatal + e.Message.ToString();
                Respuesta.code = CodigosRespuesta.codigo.INTERNAL_SERVER_ERROR;
                JSON = JsonConvert.SerializeObject(new ResponseListLessons(Respuesta, null));
            }
            return JSON;
        }

        #region Validar request
        protected bool parametrosValidos(RequestLesson Parametros, ref string mensaje)
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
            if (Parametros.RQ.ID_course == null)
            {
                mensajeParametros += "ID_course ";
                valido = false;
            }
            if (Parametros.RQ.lesson == null)
            {
                mensajeParametros += "lesson ";
                valido = false;
            }
            else
            {
                if (Parametros.RQ.lesson.lesson_name == null || Parametros.RQ.lesson.lesson_name.Trim() == "")
                {
                    mensajeParametros += "lesson_name ";
                    valido = false;                  
                }
                if (Parametros.RQ.lesson.lesson_minPoints == null)
                {
                    mensajeParametros += "lesson_minPoints ";
                    valido = false;              
                }
                if (Parametros.RQ.lesson.lesson_questions == null || Parametros.RQ.lesson.lesson_questions.Count == 0)
                {
                    mensajeParametros += "lesson_questions ";
                    valido = false;           
                }
                else
                {
                    foreach (Questions question in Parametros.RQ.lesson.lesson_questions)
                    {
                        if (question.question_description == null || question.question_description.Trim() == "")
                        {
                            mensajeParametros += "question_description ";
                            valido = false;
                            break;
                        }
                        if (question.question_points == null)
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
                        else
                        {
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
            mensaje = mensajeParametros;
            return valido;
        }
        protected bool parametrosValidosEdit(RequestLesson Parametros, ref string mensaje)
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
            if (Parametros.RQ.lesson == null)
            {
                mensajeParametros += "lesson ";
                valido = false;
            }
            else {
                if (Parametros.RQ.lesson.ID_lesson == null)
                {
                    mensajeParametros += "ID_lesson ";
                    valido = false;
                }
                if (Parametros.RQ.lesson.lesson_name == null || Parametros.RQ.lesson.lesson_name.Trim() == "")
                {
                    mensajeParametros += "lesson_name ";
                    valido = false;
                }
                if (Parametros.RQ.lesson.lesson_minPoints == null)
                {
                    mensajeParametros += "lesson_minPoints ";
                    valido = false;
                }

            }
          
            mensaje = mensajeParametros;
            return valido;
        }
        protected bool parametrosValidosDelete(RequestLesson Parametros, ref string mensaje)
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
            if (Parametros.RQ.lesson == null)
            {
                mensajeParametros += "lesson ";
                valido = false;
            }
            else {
                if (Parametros.RQ.lesson.ID_lesson == null)
                {
                    mensajeParametros += "ID_lesson ";
                    valido = false;
                }
            }
           
            mensaje = mensajeParametros;
            return valido;
        }
        protected bool parametrosValidosgetList(RequestLesson Parametros, ref string mensaje)
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
            if (Parametros.RQ.ID_course == null)
            {
                mensajeParametros += "ID_course ";
                valido = false;
            }
            mensaje = mensajeParametros;
            return valido;
        }
        #endregion
    }
}
