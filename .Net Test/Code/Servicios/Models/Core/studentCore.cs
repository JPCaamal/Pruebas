using Servicios.Class.ObjPeticiones;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace Servicios.Models.Core
{
    public class studentCore : CoreModelo
    {
        public int validateStudent(string userNumber, string userPass, ref string mensaje)
        {
            Hashtable parametros = new Hashtable();
            parametros.Add("Opcion", 0);
            parametros.Add("student_number", userNumber);
            parametros.Add("student_password", userPass);

            DataTable dt = this.ejecutarProcedimientoAlmacenado("SP_STUDENTS", parametros);
            if (dt.Rows.Count > 0)
            {
                mensaje = dt.Rows[0]["Result"].ToString();
                int idStudent = Convert.ToInt32(dt.Rows[0]["ID_student"]);
                return idStudent;
            }
            else
            {
                mensaje = "Ocurrió un problema al insertar el registro";
                return -1;
            }
        }

        public bool addCourse(int ID_course, int ID_student, ref string mensaje)
        {         
            Hashtable parametros = new Hashtable();
            parametros.Add("Opcion", 2);
            parametros.Add("ID_course", ID_course);
            parametros.Add("ID_student", ID_student);
        
            DataTable dt = this.ejecutarProcedimientoAlmacenado("SP_STUDENTS", parametros);
            if (dt.Rows.Count > 0)           
                mensaje = dt.Rows[0]["Result"].ToString();                          
            else
            
                mensaje = "Ocurrió un problema al insertar el registro";

            if (mensaje == "OK") return true;
            return false;           
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

        public List<Lesson> getListLesson(int ID_student, int ID_course, ref string mensaje)
        {
            List<Lesson> Lessons = new List<Lesson>();
            Lesson lesson = new Lesson();
            #region Parametros SP
            Hashtable parametros = new Hashtable();
            parametros.Add("Opcion", 6);
            parametros.Add("ID_student", ID_student);
            parametros.Add("ID_course", ID_course);
            DataTable dt = this.ejecutarProcedimientoAlmacenado("SP_STUDENTS", parametros);
            if (dt.Rows.Count > 0)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    lesson = new Lesson();
                    lesson.ID_lesson = (dr["ID_lesson"] != DBNull.Value) ? Convert.ToInt32(dr["ID_lesson"]) : 0;
                    lesson.lesson_name = dr["lesson_name"].ToString();
                    lesson.lesson_minPoints = (dr["lesson_minPoints"] != DBNull.Value) ? Convert.ToInt32(dr["lesson_minPoints"]) : 0;
                    lesson.lesson_status = dr["lesson_status"].ToString();
                    Lessons.Add(lesson);
                }
            }
            else
            {
                mensaje = "No se encontraron lecciones";
                return null;
            }
            return Lessons;
            #endregion
        }
        public List<Course> getListCourse(int ID_student, ref string mensaje)
        {
            List<Course> Courses = new List<Course>();
            Course course = new Course();
            #region Parametros SP
            Hashtable parametros = new Hashtable();
            parametros.Add("Opcion", 5);
            parametros.Add("ID_student", ID_student);
            
            DataTable dt = this.ejecutarProcedimientoAlmacenado("SP_STUDENTS", parametros);
            if (dt.Rows.Count > 0)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    course = new Course();
                    course.ID_course = (dr["ID_course"] != DBNull.Value) ? Convert.ToInt32(dr["ID_course"]) : 0;
                    course.course_name = dr["course_name"].ToString();
                    course.course_status = dr["course_status"].ToString();
                    Courses.Add(course);
                }
            }
            else
            {
                mensaje = "no se encontraron cursos";
                return null;
            }
            return Courses;
            #endregion
        }


        public bool TakeLesson(int ID_lesson, int lessonPoints, int ID_student, ref string mensaje)
        {
            Hashtable parametros = new Hashtable();
            parametros.Add("Opcion", 3);
            parametros.Add("lesson_points", lessonPoints);
            parametros.Add("ID_student", ID_student);
            parametros.Add("ID_lesson", ID_lesson);
            DataTable dt = this.ejecutarProcedimientoAlmacenado("SP_STUDENTS", parametros);
            if (dt.Rows.Count > 0)
                mensaje = dt.Rows[0]["Result"].ToString();
            else

                mensaje = "Ocurrió un problema al insertar el registro";

            if (mensaje == "OK") return true;
            return false;
        }
    }
}