using Servicios.Class.ObjPeticiones;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace Servicios.Models.Core
{
    public class lessonsCore:CoreModelo
    {
        public bool addLesson(RequestLesson Lessons, ref string mensaje)
        {           
            int ID_LESSON = -1;
            int ID_QUESTION = -1;

            #region Parametros SP
            Hashtable parametros = new Hashtable();
            parametros.Add("Opcion", 1);
            parametros.Add("ID_course", Lessons.RQ.ID_course);
            parametros.Add("lesson_name", Lessons.RQ.lesson.lesson_name);
            parametros.Add("lesson_minPoints", Lessons.RQ.lesson.lesson_minPoints);

            DataTable dt = this.ejecutarProcedimientoAlmacenado("SP_LESSONS", parametros);
            if (dt.Rows.Count > 0)
            {
                mensaje = dt.Rows[0]["Result"].ToString();
                ID_LESSON = (dt.Rows[0]["ID_lesson"] != DBNull.Value) ? Convert.ToInt32(dt.Rows[0]["ID_lesson"]) : -1;
            }
            else
            {
                mensaje = "Ocurrió un problema al insertar el registro";
                return false;
            }

            if (ID_LESSON != -1)
            {
                foreach (Questions questions in Lessons.RQ.lesson.lesson_questions)
                {
                    parametros = new Hashtable();
                    parametros.Add("Opcion", 1);
                    parametros.Add("ID_lesson", ID_LESSON);
                    parametros.Add("question_description", questions.question_description);
                    parametros.Add("question_type", questions.question_type);
                    parametros.Add("question_points", questions.question_points);
                    dt = this.ejecutarProcedimientoAlmacenado("SP_QUESTIONS", parametros);
                    if (dt.Rows.Count > 0)
                    {
                        mensaje = dt.Rows[0]["Result"].ToString();
                        ID_QUESTION = (dt.Rows[0]["ID_Question"] != DBNull.Value) ? Convert.ToInt32(dt.Rows[0]["ID_Question"]) : -1;
                    }
                    else
                    {
                        mensaje = "Ocurrió un problema al insertar el registro";
                        return false;
                    }
                    if (ID_QUESTION != -1)
                    {
                        foreach (Options options in questions.question_options)
                        {
                            parametros = new Hashtable();
                            parametros.Add("Opcion", 5);
                            parametros.Add("ID_question", ID_QUESTION);
                            parametros.Add("option_description", options.option_description);
                            parametros.Add("option_value", options.option_value);

                            dt = this.ejecutarProcedimientoAlmacenado("SP_QUESTIONS", parametros);
                            if (dt.Rows.Count > 0)
                            {
                                mensaje = dt.Rows[0]["Result"].ToString();
                                //7ID = (dt.Rows[0]["ID_option"] != DBNull.Value) ? Convert.ToInt32(dt.Rows[0]["ID_option"]) : -1;
                            }
                            else
                            {
                                mensaje = "Ocurrió un problema al insertar el registro";
                                return false;
                            }

                        }
                    }

                }
            }
            return true;
            #endregion
        }
        public bool editLesson(RequestLesson Lessons, ref string mensaje)
        {
            #region Parametros SP
            Hashtable parametros = new Hashtable();
            parametros.Add("Opcion", 2);
            parametros.Add("ID_lesson", Lessons.RQ.lesson.ID_lesson);
            parametros.Add("lesson_name", Lessons.RQ.lesson.lesson_name);
            parametros.Add("lesson_minPoints", Lessons.RQ.lesson.lesson_minPoints);

            DataTable dt = this.ejecutarProcedimientoAlmacenado("SP_LESSONS", parametros);
            if (dt.Rows.Count > 0)
            {
                mensaje = dt.Rows[0]["Result"].ToString();
                //  ID_COURSE = (dt.Rows[0]["ID_course"] != DBNull.Value) ? Convert.ToInt32(dt.Rows[0]["ID_course"]) : -1;
            }
            else
            {
                mensaje = "Ocurrió un problema al insertar el registro";
                return false;
            }
            return true;
            #endregion
        }
        public bool deleteLesson(RequestLesson Lessons, ref string mensaje)
        {
            #region Parametros SP
            Hashtable parametros = new Hashtable();
            parametros.Add("Opcion", 3);
            parametros.Add("ID_lesson", Lessons.RQ.lesson.ID_lesson);
            DataTable dt = this.ejecutarProcedimientoAlmacenado("SP_LESSONS", parametros);
            if (dt.Rows.Count > 0)
            {
                mensaje = dt.Rows[0]["Result"].ToString();
                //  ID_COURSE = (dt.Rows[0]["ID_course"] != DBNull.Value) ? Convert.ToInt32(dt.Rows[0]["ID_course"]) : -1;
            }
            else
            {
                mensaje = "Ocurrió un problema al insertar el registro";
                return false;
            }
            return true;
            #endregion
        }
        public List<Lesson> getListLesson(RequestLesson LessonsRQ, ref string mensaje)
        {
            List<Lesson> Lessons = new List<Lesson>();
            Lesson lesson = new Lesson();
            #region Parametros SP
            Hashtable parametros = new Hashtable();
            parametros.Add("Opcion", 4);
            parametros.Add("ID_course", LessonsRQ.RQ.ID_course);
            DataTable dt = this.ejecutarProcedimientoAlmacenado("SP_LESSONS", parametros);
            if (dt.Rows.Count > 0)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    lesson = new Lesson();
                    lesson.ID_lesson = (dr["ID_lesson"] != DBNull.Value) ? Convert.ToInt32(dr["ID_lesson"]) : 0;
                    lesson.lesson_name = dr["lesson_name"].ToString();
                    lesson.lesson_minPoints = (dr["lesson_minPoints"] != DBNull.Value) ? Convert.ToInt32(dr["lesson_minPoints"]) : 0;
                    Lessons.Add(lesson);
                }
            }
            else
            {
                mensaje = "No se encontraron registros";
                return null;
            }
            return Lessons;
            #endregion
        }
        public Lesson getLesson(int ID_lesson, ref string mensaje)
        {
            

            Lesson lesson = new Lesson();                       
            Hashtable parametros = new Hashtable();
            parametros.Add("Opcion", 5);
            parametros.Add("ID_lesson",ID_lesson);
            DataTable dt = this.ejecutarProcedimientoAlmacenado("SP_LESSONS", parametros);
            if (dt.Rows.Count > 0)
            {
                lesson.ID_lesson = (dt.Rows[0]["ID_lesson"] != DBNull.Value) ? Convert.ToInt32(dt.Rows[0]["ID_lesson"]) : 0;
                lesson.lesson_name = dt.Rows[0]["lesson_name"].ToString();
                lesson.lesson_minPoints = (dt.Rows[0]["lesson_minPoints"] != DBNull.Value) ? Convert.ToInt32(dt.Rows[0]["lesson_minPoints"]) : 0;
                   
            }
            else
            {
                mensaje = "No se encontraron registros";
                return null;
            }
            return lesson;
        }
    }
}