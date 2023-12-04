using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Oracle.ManagedDataAccess.Client;
using System.Data;

namespace TrabajoFinalBD_EMedina_Jvasquez.accesoDatos
{
    class Datos
    {
        //Paso 1. Crear cadena de conexión.
        string cadenaConexion = @"Data Source=localhost:1521/xe; User Id=bases1; Password=oracle"; //contendrá la ip a la cual nos conectaremos, el user y su respectiva password.


        //Paso 2: Crear el método que ejecuta el comando DML.
        public int ejecutarDML(string consulta)
        {
            //Variable de apoyo que guardará la respuesta del comando nonQuery.
            int filasAfectadas = 0;
            //Paso 1. Se crea la conexión
            OracleConnection miConexion = new OracleConnection(cadenaConexion);
            //Paso 2. Se crea un objeto de tipo comando el cual establece la instrucción sql que se ejecutará en la BD.
            //Objeto de tipo OracleCommand, el cual recibe una consulta de tipo insert, update o delete y como segundo parametro recibe la conexión.
            OracleCommand miComando = new OracleCommand(consulta, miConexion);
            //Paso 3. Se abre la conexión.
            miConexion.Open();
            //Paso 4. Se ejecuta el comando. Al ejecutar dicho comando se retorna un valor entero que simboliza las filas afectadas en la operación DML(insert, update, delete).
            //ExecuteNonQuery se refiere a un comando de tipo SELECT.
            filasAfectadas = miComando.ExecuteNonQuery();
            //Paso 5. Se cierra la conexión.
            miConexion.Close();
            //Paso 6. Se retornan las filas afectadas.
            return filasAfectadas;
        }
        public DataSet ejecutarSelect(string consulta)
        {
            DataSet objDataSet = new DataSet();
            OracleDataAdapter miAdaptador = new OracleDataAdapter(consulta, cadenaConexion);
            miAdaptador.Fill(objDataSet, "ResultadoDatos");
            return objDataSet;
        }
    }
}
