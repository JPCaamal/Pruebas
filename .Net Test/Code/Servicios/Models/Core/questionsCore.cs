using Servicios.Class.ObjPeticiones;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace Servicios.Models.Core
{
    public class questionsCore:CoreModelo
    {
        public bool addQuestion(RequestQuestion Questions, ref string mensaje)
        {          
            int ID_QUESTION = -1;
            #region Parametros SP
            Hashtable parametros = new Hashtable();
            parametros.Add("Opcion", 1);
            parametros.Add("ID_lesson", Questions.RQ.ID_lesson);
            parametros.Add("question_description", Questions.RQ.question.question_description);
            parametros.Add("question_type", Questions.RQ.question.question_type);
            parametros.Add("question_points", Questions.RQ.question.question_points);
            DataTable dt = this.ejecutarProcedimientoAlmacenado("SP_QUESTIONS", parametros);
           
            if (dt.Rows.Count > 0)
            {
                mensaje = dt.Rows[0]["Result"].ToString();
                ID_QUESTION = (dt.Rows[0]["ID_question"] != DBNull.Value) ? Convert.ToInt32(dt.Rows[0]["ID_question"]) : -1;
            }
            else
            {
                mensaje = "Ocurrió un problema al insertar el registro";
                return false;
            }

            if (ID_QUESTION != -1)
            {
                foreach (Options options in Questions.RQ.question.question_options)
                {
                    parametros = new Hashtable();
                    parametros.Add("Opcion", 5);
                    parametros.Add("ID_question", ID_QUESTION);
                    parametros.Add("option_description", options.option_description);
                    parametros.Add("option_value", options.option_value);

                    dt = this.ejecutarProcedimientoAlmacenado("SP_QUESTIONS", parametros);
                    if (dt.Rows.Count > 0)                    
                        mensaje = dt.Rows[0]["Result"].ToString();                                          
                    else
                    {
                        mensaje = "Ocurrió un problema al insertar el registro";
                        return false;
                    }

                }
            }
            return true;
            #endregion
        }
        public bool editQuestion(RequestQuestion Questions, ref string mensaje)
        {
            #region Parametros SP
            Hashtable parametros = new Hashtable();
            parametros.Add("Opcion", 2);
            parametros.Add("ID_Question", Questions.RQ.question.ID_question);
            parametros.Add("question_description", Questions.RQ.question.question_description);
            parametros.Add("question_type", Questions.RQ.question.question_type);
            parametros.Add("question_points", Questions.RQ.question.question_points);

            DataTable dt = this.ejecutarProcedimientoAlmacenado("SP_QUESTIONS", parametros);
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
        public bool deleteQuestion(RequestQuestion Questions, ref string mensaje)
        {
            #region Parametros SP
            Hashtable parametros = new Hashtable();
            parametros.Add("Opcion", 3);
            parametros.Add("ID_Question", Questions.RQ.question.ID_question);
            DataTable dt = this.ejecutarProcedimientoAlmacenado("SP_QUESTIONS", parametros);
            if (dt.Rows.Count > 0)            
                mensaje = dt.Rows[0]["Result"].ToString();
            else
            {
                mensaje = "Ocurrió un problema al insertar el registro";
                return false;
            }
            return true;
            #endregion
        }
        public List<Questions> getListQuestion(int idLesson, ref string mensaje)
        {
            List<Questions> questions = new List<Questions>();
            Questions question = new Questions();
            #region Parametros SP
            Hashtable parametros = new Hashtable();
            parametros.Add("Opcion", 4);
            parametros.Add("ID_lesson", idLesson);

            DataTable dt = this.ejecutarProcedimientoAlmacenado("SP_QUESTIONS", parametros);
            if (dt.Rows.Count > 0)
            {
                List<int> listIDQuestion = dt.AsEnumerable().Select(s => Convert.ToInt32(s["ID_question"])).Distinct().ToList();
                foreach (int idQuestion in listIDQuestion)
                {
                    List<DataRow> options = dt.AsEnumerable().Where(w => Convert.ToInt32(w["ID_question"]) == idQuestion).ToList();
                    question = new Questions();
                    question.ID_question = Convert.ToInt32(options[0]["ID_question"]);
                    question.question_description = options[0]["question_description"].ToString();
                    question.question_type = Convert.ToChar(options[0]["question_type"]);
                    question.question_points = Convert.ToInt32(options[0]["question_points"]);

                    List<Options> opts = new List<Options>();
                    foreach (DataRow dr in options)
                    {
                        Options opciones = new Options();
                        opciones.ID_option = Convert.ToInt32(dr["ID_option"]);
                        opciones.option_description = dr["option_description"].ToString();
                        opciones.option_value = Convert.ToBoolean(dr["option_value"]);

                        opts.Add(opciones);
                    }
                    question.question_options = opts;
                    questions.Add(question);                    
                }
            }
            else
            {
                mensaje = "No se encontraron registros";
                return null;
            }
            return questions;
            #endregion
        }
    }
}