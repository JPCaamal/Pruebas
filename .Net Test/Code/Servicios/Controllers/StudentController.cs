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
    public class StudentController : Controller
    {
        public String getListCourses()
        {
            String JSON;
            try
            {
                Response.ContentType = "application/json; charset=UTF-8";
                String metodoDeEnvioHTTP = System.Web.HttpContext.Current.Request.HttpMethod;

                if (metodoDeEnvioHTTP != "POST")
                {

                    RespStudent Respuesta = new RespStudent();
                    Respuesta.code = CodigosRespuesta.codigo.INTERNAL_SERVER_ERROR;
                    Respuesta.estatus = MensajesEstados.ERROR_POST_REQUEST;

                    JSON = JsonConvert.SerializeObject(new ResponseStudentCourses(Respuesta,null));
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
                        RespStudent Respuesta = new RespStudent();
                        Respuesta.code = CodigosRespuesta.codigo.INTERNAL_SERVER_ERROR;
                        Respuesta.estatus = MensajesEstados.ErrorFatal;
                        JSON = JsonConvert.SerializeObject(new ResponseStudentCourses(Respuesta,null));
                    }
                    else
                    {
                        RequestStudentCourses Parametros = JsonConvert.DeserializeObject<RequestStudentCourses>(POST);
                        string Mensaje = "";
                        if (parametrosValidos(Parametros, ref Mensaje))
                        {
                            ADStudent coursesAD = new ADStudent();
                            RespStudentCourses Respuesta = coursesAD.getListCourses(Parametros);
                            JSON = JsonConvert.SerializeObject(new ResponseStudentCourses(Respuesta.Response, Respuesta.Courses));
                        }
                        else
                        {
                            RespStudent Respuesta = new RespStudent();
                            Respuesta.estatus = Mensaje;
                            Respuesta.code = CodigosRespuesta.codigo.BAD_REQUEST;
                            JSON = JsonConvert.SerializeObject(new ResponseStudentCourses(Respuesta,null));
                        }
                    }
                }
            }
            catch (Exception e)
            {
                RespStudent Respuesta = new RespStudent();
                Respuesta.estatus = MensajesEstados.ErrorFatal + e.Message.ToString();
                Respuesta.code = CodigosRespuesta.codigo.INTERNAL_SERVER_ERROR;
                JSON = JsonConvert.SerializeObject(new ResponseStudentCourses(Respuesta,null));
            }
            return JSON;
        }
        public String getListLessons()
        {
            String JSON;
            try
            {
                Response.ContentType = "application/json; charset=UTF-8";
                String metodoDeEnvioHTTP = System.Web.HttpContext.Current.Request.HttpMethod;

                if (metodoDeEnvioHTTP != "POST")
                {

                    RespStudent Respuesta = new RespStudent();
                    Respuesta.code = CodigosRespuesta.codigo.INTERNAL_SERVER_ERROR;
                    Respuesta.estatus = MensajesEstados.ERROR_POST_REQUEST;

                    JSON = JsonConvert.SerializeObject(new ResponseStudentLessons(Respuesta, null));
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
                        RespStudent Respuesta = new RespStudent();
                        Respuesta.code = CodigosRespuesta.codigo.INTERNAL_SERVER_ERROR;
                        Respuesta.estatus = MensajesEstados.ErrorFatal;
                        JSON = JsonConvert.SerializeObject(new ResponseStudentLessons(Respuesta, null));
                    }
                    else
                    {
                        RequestStudentLessons Parametros = JsonConvert.DeserializeObject<RequestStudentLessons>(POST);
                        string Mensaje = "";
                        if (parametrosValidos(Parametros, ref Mensaje))
                        {
                            ADStudent coursesAD = new ADStudent();
                            RespStudentLessons Respuesta = coursesAD.getListLessons(Parametros);
                            JSON = JsonConvert.SerializeObject(new ResponseStudentLessons(Respuesta.Response, Respuesta.Lessons));
                        }
                        else
                        {
                            RespStudent Respuesta = new RespStudent();
                            Respuesta.estatus = Mensaje;
                            Respuesta.code = CodigosRespuesta.codigo.BAD_REQUEST;
                            JSON = JsonConvert.SerializeObject(new ResponseStudentLessons(Respuesta, null));
                        }
                    }
                }
            }
            catch (Exception e)
            {
                RespStudent Respuesta = new RespStudent();
                Respuesta.estatus = MensajesEstados.ErrorFatal + e.Message.ToString();
                Respuesta.code = CodigosRespuesta.codigo.INTERNAL_SERVER_ERROR;
                JSON = JsonConvert.SerializeObject(new ResponseStudentLessons(Respuesta, null));
            }
            return JSON;
        }
        public String getListQuestions()
        {
            String JSON;
            try
            {
                Response.ContentType = "application/json; charset=UTF-8";
                String metodoDeEnvioHTTP = System.Web.HttpContext.Current.Request.HttpMethod;

                if (metodoDeEnvioHTTP != "POST")
                {

                    RespStudent Respuesta = new RespStudent();
                    Respuesta.code = CodigosRespuesta.codigo.INTERNAL_SERVER_ERROR;
                    Respuesta.estatus = MensajesEstados.ERROR_POST_REQUEST;

                    JSON = JsonConvert.SerializeObject(new ResponseStudentQuestions(Respuesta, null));
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
                        RespStudent Respuesta = new RespStudent();
                        Respuesta.code = CodigosRespuesta.codigo.INTERNAL_SERVER_ERROR;
                        Respuesta.estatus = MensajesEstados.ErrorFatal;
                        JSON = JsonConvert.SerializeObject(new ResponseStudentQuestions(Respuesta, null));
                    }
                    else
                    {
                        RequestStudentQuestions Parametros = JsonConvert.DeserializeObject<RequestStudentQuestions>(POST);
                        string Mensaje = "";
                        if (parametrosValidos(Parametros, ref Mensaje))
                        {
                            ADStudent coursesAD = new ADStudent();
                            RespStudentQuestions Respuesta = coursesAD.getListQuestions(Parametros);
                            JSON = JsonConvert.SerializeObject(new ResponseStudentQuestions(Respuesta.Response, Respuesta.Questions));
                        }
                        else
                        {
                            RespStudent Respuesta = new RespStudent();
                            Respuesta.estatus = Mensaje;
                            Respuesta.code = CodigosRespuesta.codigo.BAD_REQUEST;
                            JSON = JsonConvert.SerializeObject(new ResponseStudentQuestions(Respuesta, null));
                        }
                    }
                }
            }
            catch (Exception e)
            {
                RespStudent Respuesta = new RespStudent();
                Respuesta.estatus = MensajesEstados.ErrorFatal + e.Message.ToString();
                Respuesta.code = CodigosRespuesta.codigo.INTERNAL_SERVER_ERROR;
                JSON = JsonConvert.SerializeObject(new ResponseStudentQuestions(Respuesta, null));
            }
            return JSON;
        }
        public String assignCourse()
        {
            String JSON;
            try
            {
                Response.ContentType = "application/json; charset=UTF-8";
                String metodoDeEnvioHTTP = System.Web.HttpContext.Current.Request.HttpMethod;

                if (metodoDeEnvioHTTP != "POST")
                {
                    RespStudent Respuesta = new RespStudent();
                    Respuesta.code = CodigosRespuesta.codigo.INTERNAL_SERVER_ERROR;
                    Respuesta.estatus = MensajesEstados.ERROR_POST_REQUEST;

                    JSON = JsonConvert.SerializeObject(new ResponseStudentCourse(Respuesta));
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
                        RespStudent Respuesta = new RespStudent();
                        Respuesta.code = CodigosRespuesta.codigo.INTERNAL_SERVER_ERROR;
                        Respuesta.estatus = MensajesEstados.ErrorFatal;
                        JSON = JsonConvert.SerializeObject(new ResponseStudentCourse(Respuesta));
                    }
                    else
                    {
                        RequestStudentCourse Parametros = JsonConvert.DeserializeObject<RequestStudentCourse>(POST);
                        string Mensaje = "";
                        if (parametrosValidos(Parametros, ref Mensaje))
                        {
                            ADStudent coursesAD = new ADStudent();
                            RespStudentCourse Respuesta = coursesAD.addCourse(Parametros);
                            JSON = JsonConvert.SerializeObject(new ResponseStudentCourse(Respuesta.Response));
                        }
                        else
                        {
                            RespStudent Respuesta = new RespStudent();
                            Respuesta.estatus = Mensaje;
                            Respuesta.code = CodigosRespuesta.codigo.BAD_REQUEST;
                            JSON = JsonConvert.SerializeObject(new ResponseStudentCourse(Respuesta));
                        }
                    }
                }
            }
            catch (Exception e)
            {
                RespStudent Respuesta = new RespStudent();
                Respuesta.estatus = MensajesEstados.ErrorFatal + e.Message.ToString();
                Respuesta.code = CodigosRespuesta.codigo.INTERNAL_SERVER_ERROR;
                JSON = JsonConvert.SerializeObject(new ResponseStudentCourse(Respuesta));
            }
            return JSON;
        }
        public String TakeLesson()
        {
            String JSON;
            try
            {
                Response.ContentType = "application/json; charset=UTF-8";
                String metodoDeEnvioHTTP = System.Web.HttpContext.Current.Request.HttpMethod;

                if (metodoDeEnvioHTTP != "POST")
                {
                    RespStudent Respuesta = new RespStudent();
                    Respuesta.code = CodigosRespuesta.codigo.INTERNAL_SERVER_ERROR;
                    Respuesta.estatus = MensajesEstados.ERROR_POST_REQUEST;

                    JSON = JsonConvert.SerializeObject(new ResponseStudentAnswers(Respuesta));
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
                        RespStudent Respuesta = new RespStudent();
                        Respuesta.code = CodigosRespuesta.codigo.INTERNAL_SERVER_ERROR;
                        Respuesta.estatus = MensajesEstados.ErrorFatal;
                        JSON = JsonConvert.SerializeObject(new ResponseStudentAnswers(Respuesta));
                    }
                    else
                    {
                        RequestStudentAnswers Parametros = JsonConvert.DeserializeObject<RequestStudentAnswers>(POST);
                        string Mensaje = "";
                        if (parametrosValidos(Parametros, ref Mensaje))
                        {
                            ADStudent coursesAD = new ADStudent();
                            RespStudentAnswers Respuesta = coursesAD.TakeLesson(Parametros);
                            JSON = JsonConvert.SerializeObject(new ResponseStudentAnswers(Respuesta.Response));
                        }
                        else
                        {
                            RespStudent Respuesta = new RespStudent();
                            Respuesta.estatus = Mensaje;
                            Respuesta.code = CodigosRespuesta.codigo.BAD_REQUEST;
                            JSON = JsonConvert.SerializeObject(new ResponseStudentAnswers(Respuesta));
                        }
                    }
                }
            }
            catch (Exception e)
            {
                RespStudent Respuesta = new RespStudent();
                Respuesta.estatus = MensajesEstados.ErrorFatal + e.Message.ToString();
                Respuesta.code = CodigosRespuesta.codigo.INTERNAL_SERVER_ERROR;
                JSON = JsonConvert.SerializeObject(new ResponseStudentAnswers(Respuesta));
            }
            return JSON;
        }


        #region Validar request
        protected bool parametrosValidos(RequestStudentCourses Parametros, ref string mensaje)
        {
            bool valido = true;
            string mensajeParametros = "Parámetros incorrectos: ";
            if (Parametros.RQ.user_number == null || Parametros.RQ.user_number.Trim() == "")
            {
                mensajeParametros += "user_number ";
                valido = false;
            }
            if (Parametros.RQ.user_password == null || Parametros.RQ.user_password.Trim() == "")
            {
                mensajeParametros += "user_password ";
                valido = false;
            }
            mensaje = mensajeParametros;
            return valido;
        }
        protected bool parametrosValidos(RequestStudentLessons Parametros, ref string mensaje)
        {
            bool valido = true;
            string mensajeParametros = "Parámetros incorrectos: ";
            if (Parametros.RQ.user_number == null || Parametros.RQ.user_number.Trim() == "")
            {
                mensajeParametros += "user_number ";
                valido = false;
            }
            if (Parametros.RQ.user_password == null || Parametros.RQ.user_password.Trim() == "")
            {
                mensajeParametros += "user_password ";
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
        protected bool parametrosValidos(RequestStudentQuestions Parametros, ref string mensaje)
        {
            bool valido = true;
            string mensajeParametros = "Parámetros incorrectos: ";
            if (Parametros.RQ.user_number == null || Parametros.RQ.user_number.Trim() == "")
            {
                mensajeParametros += "user_number ";
                valido = false;
            }
            if (Parametros.RQ.user_password == null || Parametros.RQ.user_password.Trim() == "")
            {
                mensajeParametros += "user_password ";
                valido = false;
            }
            if (Parametros.RQ.ID_lesson == null )
            {
                mensajeParametros += "ID_lesson ";
                valido = false;
            }
            mensaje = mensajeParametros;
            return valido;
        }
        protected bool parametrosValidos(RequestStudentCourse Parametros, ref string mensaje)
        {
            bool valido = true;
            string mensajeParametros = "Parámetros incorrectos: ";
            if (Parametros.RQ.user_number == null || Parametros.RQ.user_number.Trim() == "")
            {
                mensajeParametros += "user_number ";
                valido = false;
            }
            if (Parametros.RQ.user_password == null || Parametros.RQ.user_password.Trim() == "")
            {
                mensajeParametros += "user_password ";
                valido = false;
            }
            if (Parametros.RQ.ID_Course == null )
            {
                mensajeParametros += "ID_Course ";
                valido = false;
            }
            mensaje = mensajeParametros;
            return valido;
        }
        protected bool parametrosValidos(RequestStudentAnswers Parametros, ref string mensaje)
        {
            bool valido = true;
            string mensajeParametros = "Parámetros incorrectos: ";
            if (Parametros.RQ.user_number == null || Parametros.RQ.user_number.Trim() == "")
            {
                mensajeParametros += "user_number ";
                valido = false;
            }
            if (Parametros.RQ.user_password == null || Parametros.RQ.user_password.Trim() == "")
            {
                mensajeParametros += "user_password ";
                valido = false;
            }
            if (Parametros.RQ.ID_lesson == null || Parametros.RQ.ID_lesson > -1)
            {
                mensajeParametros += "ID_lesson ";
                valido = false;
            }
            if (Parametros.RQ.Questions == null || Parametros.RQ.Questions.Count == 0)
            {
                mensajeParametros += "Questions ";
                valido = false;
            }
            mensaje = mensajeParametros;
            return valido;
        }
        #endregion
    }
}
