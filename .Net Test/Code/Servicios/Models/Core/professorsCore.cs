using Servicios.Class.ObjPeticiones;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace Servicios.Models.Core
{
    public class professorsCore : CoreModelo
    {
        public int validateProfessor(string userNumber, string userPass, ref string mensaje)
        {
            Hashtable parametros = new Hashtable();            
            parametros.Add("professor_number", userNumber);
            parametros.Add("professor_password", userPass);

            DataTable dt = this.ejecutarProcedimientoAlmacenado("SP_PROFESSORS", parametros);
            if (dt.Rows.Count > 0)
            {
                mensaje = dt.Rows[0]["Result"].ToString();
                int idStudent = Convert.ToInt32(dt.Rows[0]["ID_professor"]);
                return idStudent;
            }
            else
            {
                mensaje = "Ocurrió un problema al insertar el registro";
                return -1;
            }
        }
    }
}