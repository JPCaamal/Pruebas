using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Servicios.Class
{
    public static class MensajesEstados
    {
        public static String ErrorFatal = "Error Fatal: ";
        public static String ErrorPeticionPost = "La petición HTTP por POST no está definida.";
        public static String ErrorParametrosIndefinidos = "Uno o más de los siguientes parámetros tienen problemas con la definición: ";
        public static String ErrorParametroIndefinido = "El siguiente parámetro tiene problemas con la definición.";
        public static String ErrorParametrosInvalido = "El valor del siguiente parámetro es inválido: ";
        public static String ErrorSentenciaSQLInexistente = "No existe ninguna sentencia SQL.";
        public static String ErrorNombreModeloIndefinido = "Nombre del modelo indefinido.";
        public static String ErrorIndicesIncorrectosConsulta = "Los índices necesarios para esta petición no existen";
        public static String ErrorAcceso = "No cuenta con permisos para realizar esta petición";
        public static String ErrorCuenta = "La cuenta ingresada es incorrecta";
        public static String ErrorTransaccionSQL = "La transacción tuvo errores de ejecución";
        public static String OK = "OK";
        public static String ERROR = "ERROR";
        public static String ERROR_POST_REQUEST = "La petición HTTP no fue hecha por POST";
        public static String ERROR_PARAMETROS = "Uno o más parámetros son incorrectos";
        public static String ERROR_PERIODO = "El periodo de consulta es mayor a 7 días";
        public static String SIN_RESULTADOS = "SIN RESULTADOS";
    }
}