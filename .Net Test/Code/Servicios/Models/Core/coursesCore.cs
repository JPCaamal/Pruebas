using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace Servicios.Models.Core
{
    public class coursesCore:CoreModelo
    {
        public bool addCourse(Courses courses, ref string mensaje)
        {
            int ID_COURSE = -1;
            int ID_LESSON = -1;
            int ID_QUESTION = -1;
          

            #region Parametros SP
            Hashtable parametros = new Hashtable();
            parametros.Add("Opcion", 1);
            parametros.Add("course_name", courses.course_name);
            parametros.Add("course_order", 0);
            DataTable dt = this.ejecutarProcedimientoAlmacenado("SP_COURSES", parametros);
            if (dt.Rows.Count > 0)
            {
                mensaje = dt.Rows[0]["Result"].ToString();
                ID_COURSE = (dt.Rows[0]["ID_course"] != DBNull.Value) ? Convert.ToInt32(dt.Rows[0]["ID_course"]) : -1;              
            }
            else
            {
                mensaje = "Ocurrió un problema al insertar el registro";
                return false;
            }

            if (ID_COURSE != -1)
            {
                foreach (Lessons lessons in courses.course_lessons)
                {
                    parametros = new Hashtable();
                    parametros.Add("Opcion", 1);
                    parametros.Add("ID_course", ID_COURSE);
                    parametros.Add("lesson_name", lessons.lesson_name);
                    parametros.Add("lesson_minPoints",lessons.lesson_minPoints);
                    dt = this.ejecutarProcedimientoAlmacenado("SP_LESSONS", parametros);
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
                        foreach (Questions questions in lessons.lesson_questions)
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
                }
            }
            return true;
            #endregion                        
        }
        public bool editCourse(Courses courses, ref string mensaje)
        {  
            #region Parametros SP
            Hashtable parametros = new Hashtable();
            parametros.Add("Opcion", 2);
            parametros.Add("ID_course", courses.ID_course); 
            parametros.Add("course_name", courses.course_name);     
            DataTable dt = this.ejecutarProcedimientoAlmacenado("SP_COURSES", parametros);
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
        public bool deleteCourse(Courses courses, ref string mensaje)
        {
            #region Parametros SP
            Hashtable parametros = new Hashtable();
            parametros.Add("Opcion", 3);
            parametros.Add("ID_course", courses.ID_course);       
            DataTable dt = this.ejecutarProcedimientoAlmacenado("SP_COURSES", parametros);
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
        public List<Course> getListCourse(ref string mensaje)
        {
            List<Course> Courses = new List<Course>();
            Course course = new Course();
            #region Parametros SP
            Hashtable parametros = new Hashtable();
            parametros.Add("Opcion", 4);
            DataTable dt = this.ejecutarProcedimientoAlmacenado("SP_COURSES", parametros);
            if (dt.Rows.Count > 0)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    course = new Course();
                    course.ID_course = (dr["ID_course"] != DBNull.Value) ? Convert.ToInt32(dr["ID_course"]) : 0;
                    course.course_name = dr["course_name"].ToString();
                    Courses.Add(course); 
                }
            }
            else
            {
                mensaje = "Ocurrió un problema al insertar el registro";
                return null;
            }
            return Courses;
            #endregion
        }
    }
}