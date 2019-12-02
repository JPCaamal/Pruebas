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
    public class QuestionsController : Controller
    {
        public String AddQuestion()
        {
            String JSON;
            try
            {
                Response.ContentType = "application/json; charset=UTF-8";
                String metodoDeEnvioHTTP = System.Web.HttpContext.Current.Request.HttpMethod;

                if (metodoDeEnvioHTTP != "POST")
                {

                    ResponseQuestion Respuesta = new ResponseQuestion();
                    Respuesta.code = CodigosRespuesta.codigo.INTERNAL_SERVER_ERROR;
                    Respuesta.estatus = MensajesEstados.ERROR_POST_REQUEST;

                    JSON = JsonConvert.SerializeObject(new ResponseAddQuestions(Respuesta));
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
                        ResponseQuestion Respuesta = new ResponseQuestion();
                        Respuesta.code = CodigosRespuesta.codigo.INTERNAL_SERVER_ERROR;
                        Respuesta.estatus = MensajesEstados.ErrorFatal;
                        JSON = JsonConvert.SerializeObject(new ResponseAddQuestions(Respuesta));
                    }
                    else
                    {
                        RequestQuestion Parametros = JsonConvert.DeserializeObject<RequestQuestion>(POST);
                        string Mensaje = "";
                        if (parametrosValidos(Parametros, ref Mensaje))
                        {
                            ADQuestions coursesAD = new ADQuestions();
                            ResponseQuestion Respuesta = coursesAD.addQuestion(Parametros);
                            JSON = JsonConvert.SerializeObject(new ResponseAddQuestions(Respuesta));
                        }
                        else
                        {
                            ResponseQuestion Respuesta = new ResponseQuestion();
                            Respuesta.estatus = Mensaje;
                            Respuesta.code = CodigosRespuesta.codigo.BAD_REQUEST;
                            JSON = JsonConvert.SerializeObject(new ResponseAddQuestions(Respuesta));
                        }
                    }
                }
            }
            catch (Exception e)
            {
                ResponseQuestion Respuesta = new ResponseQuestion();
                Respuesta.estatus = MensajesEstados.ErrorFatal + e.Message.ToString();
                Respuesta.code = CodigosRespuesta.codigo.INTERNAL_SERVER_ERROR;
                JSON = JsonConvert.SerializeObject(new ResponseAddQuestions(Respuesta));
            }
            return JSON;
        }
        public String EditQuestion()
        {
            String JSON;
            try
            {
                Response.ContentType = "application/json; charset=UTF-8";
                String metodoDeEnvioHTTP = System.Web.HttpContext.Current.Request.HttpMethod;

                if (metodoDeEnvioHTTP != "POST")
                {

                    ResponseQuestion Respuesta = new ResponseQuestion();
                    Respuesta.code = CodigosRespuesta.codigo.INTERNAL_SERVER_ERROR;
                    Respuesta.estatus = MensajesEstados.ERROR_POST_REQUEST;

                    JSON = JsonConvert.SerializeObject(new ResponseAddQuestions(Respuesta));
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
                        ResponseQuestion Respuesta = new ResponseQuestion();
                        Respuesta.code = CodigosRespuesta.codigo.INTERNAL_SERVER_ERROR;
                        Respuesta.estatus = MensajesEstados.ErrorFatal;
                        JSON = JsonConvert.SerializeObject(new ResponseAddQuestions(Respuesta));
                    }
                    else
                    {
                        RequestQuestion Parametros = JsonConvert.DeserializeObject<RequestQuestion>(POST);
                        string Mensaje = "";
                        if (parametrosValidosEdit(Parametros, ref Mensaje))
                        {
                            ADQuestions coursesAD = new ADQuestions();
                            ResponseQuestion Respuesta = coursesAD.editQuestion(Parametros);
                            JSON = JsonConvert.SerializeObject(new ResponseAddQuestions(Respuesta));
                        }
                        else
                        {
                            ResponseQuestion Respuesta = new ResponseQuestion();
                            Respuesta.estatus = Mensaje;
                            Respuesta.code = CodigosRespuesta.codigo.BAD_REQUEST;
                            JSON = JsonConvert.SerializeObject(new ResponseAddQuestions(Respuesta));
                        }
                    }
                }
            }
            catch (Exception e)
            {
                ResponseQuestion Respuesta = new ResponseQuestion();
                Respuesta.estatus = MensajesEstados.ErrorFatal + e.Message.ToString();
                Respuesta.code = CodigosRespuesta.codigo.INTERNAL_SERVER_ERROR;
                JSON = JsonConvert.SerializeObject(new ResponseAddQuestions(Respuesta));
            }
            return JSON;
        }
        public String DeleteQuestion()
        {
            String JSON;
            try
            {
                Response.ContentType = "application/json; charset=UTF-8";
                String metodoDeEnvioHTTP = System.Web.HttpContext.Current.Request.HttpMethod;

                if (metodoDeEnvioHTTP != "POST")
                {

                    ResponseQuestion Respuesta = new ResponseQuestion();
                    Respuesta.code = CodigosRespuesta.codigo.INTERNAL_SERVER_ERROR;
                    Respuesta.estatus = MensajesEstados.ERROR_POST_REQUEST;

                    JSON = JsonConvert.SerializeObject(new ResponseAddQuestions(Respuesta));
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
                        ResponseQuestion Respuesta = new ResponseQuestion();
                        Respuesta.code = CodigosRespuesta.codigo.INTERNAL_SERVER_ERROR;
                        Respuesta.estatus = MensajesEstados.ErrorFatal;
                        JSON = JsonConvert.SerializeObject(new ResponseAddQuestions(Respuesta));
                    }
                    else
                    {
                        RequestQuestion Parametros = JsonConvert.DeserializeObject<RequestQuestion>(POST);
                        string Mensaje = "";
                        if (parametrosValidosDelete(Parametros, ref Mensaje))
                        {
                            ADQuestions coursesAD = new ADQuestions();
                            ResponseQuestion Respuesta = coursesAD.deleteQuestion(Parametros);
                            JSON = JsonConvert.SerializeObject(new ResponseAddQuestions(Respuesta));
                        }
                        else
                        {
                            ResponseQuestion Respuesta = new ResponseQuestion();
                            Respuesta.estatus = Mensaje;
                            Respuesta.code = CodigosRespuesta.codigo.BAD_REQUEST;
                            JSON = JsonConvert.SerializeObject(new ResponseAddQuestions(Respuesta));
                        }
                    }
                }
            }
            catch (Exception e)
            {
                ResponseQuestion Respuesta = new ResponseQuestion();
                Respuesta.estatus = MensajesEstados.ErrorFatal + e.Message.ToString();
                Respuesta.code = CodigosRespuesta.codigo.INTERNAL_SERVER_ERROR;
                JSON = JsonConvert.SerializeObject(new ResponseAddQuestions(Respuesta));
            }
            return JSON;
        }
        public String getListQuestion()
        {
            String JSON;
            try
            {
                Response.ContentType = "application/json; charset=UTF-8";
                String metodoDeEnvioHTTP = System.Web.HttpContext.Current.Request.HttpMethod;

                if (metodoDeEnvioHTTP != "POST")
                {
                    ResponseQuestion Respuesta = new ResponseQuestion();
                    Respuesta.code = CodigosRespuesta.codigo.INTERNAL_SERVER_ERROR;
                    Respuesta.estatus = MensajesEstados.ERROR_POST_REQUEST;

                    JSON = JsonConvert.SerializeObject(new ResponseListQuestions(Respuesta, null));
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
                        ResponseQuestion Respuesta = new ResponseQuestion();
                        Respuesta.code = CodigosRespuesta.codigo.INTERNAL_SERVER_ERROR;
                        Respuesta.estatus = MensajesEstados.ErrorFatal;
                        JSON = JsonConvert.SerializeObject(new ResponseListQuestions(Respuesta, null));
                    }
                    else
                    {
                        RequestQuestion Parametros = JsonConvert.DeserializeObject<RequestQuestion>(POST);
                        string Mensaje = "";
                        if (true)//parametrosValidos(Parametros, ref Mensaje))
                        {
                            ADQuestions coursesAD = new ADQuestions();
                            ResponseListQuestion Respuesta = coursesAD.getListQuestion(Parametros);
                            JSON = JsonConvert.SerializeObject(new ResponseListQuestions(Respuesta.Response, Respuesta.Questions));
                        }
                        else
                        {
                            ResponseQuestion Respuesta = new ResponseQuestion();
                            Respuesta.estatus = Mensaje;
                            Respuesta.code = CodigosRespuesta.codigo.BAD_REQUEST;
                            JSON = JsonConvert.SerializeObject(new ResponseListQuestions(Respuesta, null));
                        }
                    }
                }
            }
            catch (Exception e)
            {
                ResponseQuestion Respuesta = new ResponseQuestion();
                Respuesta.estatus = MensajesEstados.ErrorFatal + e.Message.ToString();
                Respuesta.code = CodigosRespuesta.codigo.INTERNAL_SERVER_ERROR;
                JSON = JsonConvert.SerializeObject(new ResponseListQuestions(Respuesta, null));
            }
            return JSON;
        }

        #region Validar request
        protected bool parametrosValidos(RequestQuestion Parametros, ref string mensaje)
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
            if (Parametros.RQ.ID_lesson == null) 
            {
                mensajeParametros += "ID_lesson ";
                valido = false;
            }
            if (Parametros.RQ.question == null)
            {
                mensajeParametros += "question ";
                valido = false;
            }
            else
            {
                if (Parametros.RQ.question.question_description == null || Parametros.RQ.question.question_description.Trim() == "")
                {
                    mensajeParametros += "question_description ";
                    valido = false;
                }
                if (Parametros.RQ.question.question_points == null)
                {
                    mensajeParametros += "question_points ";
                    valido = false;
                }
                if (Parametros.RQ.question.question_type == null || (Parametros.RQ.question.question_type != 'A' &&
                                                                     Parametros.RQ.question.question_type != 'B' &&
                                                                     Parametros.RQ.question.question_type != 'C' &&
                                                                     Parametros.RQ.question.question_type != 'D'))
                {
                    mensajeParametros += "question_type ";
                    valido = false;
                }
                if (Parametros.RQ.question.question_options == null || Parametros.RQ.question.question_options.Count == 0)
                {
                    mensajeParametros += "question_options ";
                    valido = false;
                }
                else
                {
                    foreach (Options options in Parametros.RQ.question.question_options)
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
            mensaje = mensajeParametros;
            return valido;
        }
        protected bool parametrosValidosEdit(RequestQuestion Parametros, ref string mensaje)
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
            if (Parametros.RQ.question == null)
            {
                mensajeParametros += "question ";
                valido = false;
            }
            else
            {
                if (Parametros.RQ.question.ID_question == null)
                {
                    mensajeParametros += "ID_question ";
                    valido = false;
                }
                if (Parametros.RQ.question.question_description == null || Parametros.RQ.question.question_description.Trim() == "")
                {
                    mensajeParametros += "question_description ";
                    valido = false;
                }
                if (Parametros.RQ.question.question_points == null)
                {
                    mensajeParametros += "question_points ";
                    valido = false;
                }
                if (Parametros.RQ.question.question_type == null || (Parametros.RQ.question.question_type != 'A' &&
                                                                                    Parametros.RQ.question.question_type != 'B' &&
                                                                                    Parametros.RQ.question.question_type != 'C' &&
                                                                                    Parametros.RQ.question.question_type != 'D'))
                {
                    mensajeParametros += "question_type ";
                    valido = false;
                }
            }
           
            mensaje = mensajeParametros;
            return valido;
        }
        protected bool parametrosValidosDelete(RequestQuestion Parametros, ref string mensaje)
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
            if (Parametros.RQ.question == null)
            {
                mensajeParametros += "question ";
                valido = false;
            }
            else {
                if (Parametros.RQ.question.ID_question == null)
                {
                    mensajeParametros += "ID_question ";
                    valido = false;
                }
            }
           
            mensaje = mensajeParametros;
            return valido;
        }
        protected bool parametrosValidosgetList(RequestQuestion Parametros, ref string mensaje)
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
            if (Parametros.RQ.ID_lesson == null )
            {
                mensajeParametros += "ID_lesson ";
                valido = false;
            }
            mensaje = mensajeParametros;
            return valido;
        }
        #endregion
    }
}
