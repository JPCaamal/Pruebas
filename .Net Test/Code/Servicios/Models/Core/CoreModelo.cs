using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Collections;
using Servicios.Class;

namespace Servicios.Models.Core
{
    public class CoreModelo
    {
        protected string strConn;
        protected SqlConnection conexion;
        private String nombreModelo;
        private Boolean valido;
        private string mensaje;
        private int codEstado;

        public CoreModelo()
        {
            this.strConn = ConfigurationManager.ConnectionStrings["strConn"].ConnectionString;
            this.conexion = new SqlConnection(strConn);
        }

        public String NombreModelo
        {
            get { return nombreModelo; }
            set { nombreModelo = value; }
        }
        public Boolean Valido
        {
            get { return valido; }
            set { valido = value; }
        }
        public string Mensaje
        {
            get { return mensaje; }
            set { mensaje = value; }
        }
        public int CodEstado
        {
            get { return codEstado; }
            set { codEstado = value; }
        }

        protected void abrirConexion()
        {
            conexion.Open();
        }
        protected void cerrarConexion() 
        {
            if(conexion.State==ConnectionState.Open)
                conexion.Close();
        }
        protected SqlConnection getConexion()
        {
            return this.conexion;
        }
   
        protected DataTable ejecutarProcedimientoAlmacenado(String NombrePA, Hashtable parametros)
        {
            try
            {
                this.abrirConexion();
                SqlCommand comandoSql;
                SqlDataAdapter adaptador;
                DataTable respuesta;
                comandoSql = new SqlCommand(NombrePA, this.getConexion());
                comandoSql.CommandType = CommandType.StoredProcedure;
                foreach (DictionaryEntry parametro in parametros)
                {
                        comandoSql.Parameters.Add(new SqlParameter("@" + parametro.Key, parametro.Value));                                      
                }
                adaptador = new SqlDataAdapter(comandoSql);
                respuesta = new DataTable();
                adaptador.Fill(respuesta);

                this.cerrarConexion();
                return respuesta;
            }
            catch (Exception e) 
            {
                this.Mensaje = MensajesEstados.ErrorFatal + e.Message.ToString();
                this.Valido = false;
                this.CodEstado = (int)CodigosEstados.codigo.errorFatal;
                return null;
            }
        }

        protected DataTable obtenerRegistrosProcedimientoAlmacenadoDT(String NombrePA, Hashtable parametros)
        {
            try
            {
                DataTable registro = this.ejecutarProcedimientoAlmacenado(NombrePA, parametros);

                if (registro.Rows.Count > 0 )
                {
                    return registro;
                }
                else
                {
                    this.Mensaje = "La consulta no devolvió resultados.";
                    this.Valido = false;
                    this.CodEstado = (int)CodigosEstados.codigo.respuestaCorrectaConErroresValidacion;
                    return null;
                }
            }
            catch (Exception e)
            {
                this.Mensaje = MensajesEstados.ErrorFatal + e.Message.ToString();
                this.Valido = false;
                this.CodEstado = (int)CodigosEstados.codigo.errorFatal;
                return null;
            }
        }       
    }
}