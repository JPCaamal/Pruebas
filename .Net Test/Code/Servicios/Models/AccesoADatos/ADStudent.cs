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
    public class ADStudent
    {
        public RespStudentCourse addCourse(RequestStudentCourse Parametros)
        {
            RespStudentCourse respuesta = new RespStudentCourse();
            studentCore core = new studentCore();
            string mensaje = "";
            int idStudent = core.validateStudent(Parametros.RQ.user_number, Parametros.RQ.user_password, ref mensaje);
            if(idStudent != -1)
            {
                bool Correcto = core.addCourse(Parametros.RQ.ID_Course, idStudent, ref mensaje);
                if (Correcto)
                {
                    RespStudent Respuesta = new RespStudent();
                    Respuesta.code = CodigosRespuesta.codigo.OK;
                    Respuesta.estatus = mensaje;
                    respuesta.Response = Respuesta;
                }
                else
                {
                    RespStudent Respuesta = new RespStudent();
                    Respuesta.code = CodigosRespuesta.codigo.INTERNAL_SERVER_ERROR;
                    Respuesta.estatus = mensaje;
                    respuesta.Response = Respuesta;
                }
            }
            else
            {
                RespStudent Respuesta = new RespStudent();
                Respuesta.code = CodigosRespuesta.codigo.FORBIDDEN;
                Respuesta.estatus = MensajesEstados.ErrorAcceso;
                respuesta.Response = Respuesta;
            }        
            return respuesta;
        }
        public RespStudentLessons getListLessons(RequestStudentLessons Parametros)
        {
            RespStudentLessons respuesta = new RespStudentLessons();
            studentCore core = new studentCore();
            string mensaje = "";
            int idStudent = core.validateStudent(Parametros.RQ.user_number, Parametros.RQ.user_password, ref mensaje);
            if (idStudent != -1)
            {
                List<Lesson> ListLessons = new List<Lesson>();
                ListLessons = core.getListLesson(idStudent, Parametros.RQ.ID_course, ref mensaje);
                if (ListLessons != null && ListLessons.Count > 0)
                {
                    RespStudent Respuesta = new RespStudent();
                    Respuesta.code = CodigosRespuesta.codigo.OK;
                    Respuesta.estatus = mensaje;

                    respuesta.Response = Respuesta;
                    respuesta.Lessons = ListLessons;
                }
                else
                {
                    RespStudent Respuesta = new RespStudent();
                    Respuesta.code = CodigosRespuesta.codigo.NOT_FOUND;
                    Respuesta.estatus = MensajesEstados.SIN_RESULTADOS;

                    respuesta.Response = Respuesta;
                    respuesta.Lessons = null;
                }
            }
            else
            {
                RespStudent Respuesta = new RespStudent();
                Respuesta.code = CodigosRespuesta.codigo.FORBIDDEN;
                Respuesta.estatus = MensajesEstados.ErrorAcceso;

                respuesta.Response = Respuesta;
                respuesta.Lessons = null;
            }
           
            return respuesta;
        }
        public RespStudentCourses getListCourses(RequestStudentCourses Parametros)
        {
            RespStudentCourses respuesta = new RespStudentCourses();
            studentCore core = new studentCore();
            string mensaje = "";
            int idStudent = core.validateStudent(Parametros.RQ.user_number, Parametros.RQ.user_password, ref mensaje);
            if (idStudent != -1)
            {
                List<Course> ListCourses = core.getListCourse(idStudent, ref mensaje);
                if (ListCourses != null && ListCourses.Count > 0)
                {
                    RespStudent Respuesta = new RespStudent();
                    Respuesta.code = CodigosRespuesta.codigo.OK;
                    Respuesta.estatus = mensaje;

                    respuesta.Response = Respuesta;
                    respuesta.Courses = ListCourses;
                }
                else
                {
                    RespStudent Respuesta = new RespStudent();
                    Respuesta.code = CodigosRespuesta.codigo.NOT_FOUND;
                    Respuesta.estatus = MensajesEstados.SIN_RESULTADOS;

                    respuesta.Response = Respuesta;
                    respuesta.Courses = null;
                }
            }
            else
            {
                RespStudent Respuesta = new RespStudent();
                Respuesta.code = CodigosRespuesta.codigo.FORBIDDEN;
                Respuesta.estatus = MensajesEstados.ErrorAcceso;

                respuesta.Response = Respuesta;
                respuesta.Courses = null;
            }

            return respuesta;
        }
        public RespStudentQuestions getListQuestions(RequestStudentQuestions Parametros)
        {
            RespStudentQuestions respuesta = new RespStudentQuestions();
            studentCore core = new studentCore();
            string mensaje = "";
            int idStudent = core.validateStudent(Parametros.RQ.user_number, Parametros.RQ.user_password, ref mensaje);
            if (idStudent != -1)
            {
                questionsCore qCore = new questionsCore();
                List<Questions> ListQuestions = qCore.getListQuestion(Parametros.RQ.ID_lesson, ref mensaje);
                if (ListQuestions != null && ListQuestions.Count > 0)
                {
                    RespStudent Respuesta = new RespStudent();
                    Respuesta.code = CodigosRespuesta.codigo.OK;
                    Respuesta.estatus = mensaje;

                    respuesta.Response = Respuesta;
                    respuesta.Questions = ListQuestions;
                }
                else
                {
                    RespStudent Respuesta = new RespStudent();
                    Respuesta.code = CodigosRespuesta.codigo.NOT_FOUND;
                    Respuesta.estatus = MensajesEstados.SIN_RESULTADOS;

                    respuesta.Response = Respuesta;
                    respuesta.Questions = null;
                }
            }
            else
            {
                RespStudent Respuesta = new RespStudent();
                Respuesta.code = CodigosRespuesta.codigo.FORBIDDEN;
                Respuesta.estatus = MensajesEstados.ErrorAcceso;

                respuesta.Response = Respuesta;
                respuesta.Questions = null;
            }

            return respuesta;
        }
        public RespStudentAnswers TakeLesson(RequestStudentAnswers Parametros)
        {
            RespStudentAnswers respuesta = new RespStudentAnswers();
            studentCore core = new studentCore();
            string mensaje = "";
            int idStudent = core.validateStudent(Parametros.RQ.user_number, Parametros.RQ.user_password, ref mensaje);
            if (idStudent != -1)
            {
                //get info lesson
                int lessonPoints = 0;
                Lesson lesson = new lessonsCore().getLesson(Parametros.RQ.ID_lesson, ref mensaje);
                List<Questions> questions_lesson = new questionsCore().getListQuestion(Parametros.RQ.ID_lesson, ref mensaje);
                List<Questions> questions_answer = Parametros.RQ.Questions;
                if (validateAnswers(questions_lesson, questions_answer, ref mensaje))
                {
                    if (lesson != null)
                    {
                        if (questions_lesson != null && questions_lesson.Count > 0)
                        {
                            foreach (Questions question in questions_lesson)
                            {
                                Questions answers = Parametros.RQ.Questions.Where(w => w.ID_question == question.ID_question).FirstOrDefault();
                                evaluateQuestion(question, answers, ref lessonPoints);
                            }
                        }
                    }

                    if (lessonPoints >= lesson.lesson_minPoints)
                    {
                        bool Correcto = core.TakeLesson(Parametros.RQ.ID_lesson, lessonPoints, idStudent, ref mensaje);
                        if (Correcto)
                        {
                            RespStudent Respuesta = new RespStudent();
                            Respuesta.code = CodigosRespuesta.codigo.OK;
                            Respuesta.estatus = mensaje;
                            respuesta.Response = Respuesta;
                        }
                        else
                        {
                            RespStudent Respuesta = new RespStudent();
                            Respuesta.code = CodigosRespuesta.codigo.INTERNAL_SERVER_ERROR;
                            Respuesta.estatus = mensaje;
                            respuesta.Response = Respuesta;
                        }
                    }
                    else
                    {
                        RespStudent Respuesta = new RespStudent();
                        Respuesta.code = CodigosRespuesta.codigo.OK;
                        Respuesta.estatus = "No cumple con el mínimo de puntos para pasar la lección.";
                        respuesta.Response = Respuesta;
                    }  
                }
                else 
                {
                    RespStudent Respuesta = new RespStudent();
                    Respuesta.code = CodigosRespuesta.codigo.INTERNAL_SERVER_ERROR;
                    Respuesta.estatus = mensaje;
                    respuesta.Response = Respuesta;
                }
                              
            }
            else
            {
                RespStudent Respuesta = new RespStudent();
                Respuesta.code = CodigosRespuesta.codigo.FORBIDDEN;
                Respuesta.estatus = MensajesEstados.ErrorAcceso;
                respuesta.Response = Respuesta;
            }
            return respuesta;
        }
        private void evaluateQuestion(Questions question, Questions answer, ref int lessonPoints)
        {
            bool value = false;
            
            switch (question.question_type)
            {
                case questionType.boolean:                   
                case questionType.onlyOneAnswer:
                    if (answer.question_options != null && answer.question_options.Count == 1)
                    {
                        value = question.question_options.Where(w => w.ID_option == answer.question_options[0].ID_option).Select(s => s.option_value).FirstOrDefault();
                        if (value)
                            lessonPoints += question.question_points; 
                    }
                    break;
                case questionType.moreThanOneAnswer:
                    foreach (Options options in answer.question_options)
                    {
                        value = question.question_options.Where(w => w.ID_option == options.ID_option).Select(s => s.option_value).FirstOrDefault();
                        if (value)
                        {
                            lessonPoints += question.question_points;
                            break;
                        }
                    }
                    break;
                case questionType.moreThanOneAnswerAll:
                    foreach (Options options in answer.question_options)
                    {
                        value = question.question_options.Where(w => w.ID_option == options.ID_option).
                            Select(s => s.option_value).FirstOrDefault();
                        
                    }
                    if (value)                    
                        lessonPoints += question.question_points;
                                            
                    break;
            }
        }
        private bool validateAnswers(List<Questions> questions, List<Questions> answers, ref string mensaje)
        {
            //Validar que se contestaron todas las preguntas
            List<int> answers_ID = answers.Select(s => s.ID_question).Distinct().ToList();          
            foreach (Questions question in questions)
            {
                if (!answers_ID.Contains(question.ID_question))
                {
                    mensaje = "Todas las preguntas son obligatorias";
                    return false;
                }
            }
            //validar que cada pregunta tiene respuesta
            foreach (Questions answer in answers)
            {
                if (answer.question_options == null || answer.question_options.Count == 0)
                {
                    mensaje = "Todas las preguntas son obligatorias";
                    return false;
                }
            }
            return true;
        }
    }
}