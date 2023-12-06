using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using TrabajoFinalBD_EMedina_Jvasquez.accesoDatos;

namespace TrabajoFinalBD_EMedina_Jvasquez.logica
{
    class Trabajo
    {
        Datos objDatos = new Datos();
        public DataSet consultarConsorcio(int nit)
        {
            DataSet localDataSet = new DataSet();
            string consulta = $"SELECT * FROM Consorcio WHERE consNit ={nit}";
            localDataSet = objDatos.ejecutarSelect(consulta);
            return localDataSet;
        }
        public DataSet consultarAbogado(int nId)
        {
            DataSet localDataSet = new DataSet();
            string consulta = $"SELECT * FROM Abogado WHERE abogNumId = {nId}";
            localDataSet = objDatos.ejecutarSelect(consulta);
            return localDataSet;
        }
        public int registrarTrabajo(int Nit, int NumId, string trabFechaInicio, string trabFechaFin)
        {
            string consulta = "";
            if (trabFechaFin.Length > 0)
            {
                consulta = "INSERT INTO trabaja(consNit, abogNumId, trabFechaInicio, trabFechaFin) VALUES ( "
                + $"{Nit}, {NumId},TO_DATE('{trabFechaInicio}', 'DD/MM/YYYY'), TO_DATE('{trabFechaFin}', 'DD/MM/YYYY'))";
            } 
            else if (trabFechaFin.Length <= 0)
            {
                consulta = "INSERT INTO trabaja(consNit, abogNumId, trabFechaInicio, trabFechaFin) VALUES ( "
                + $"{Nit}, {NumId},TO_DATE('{trabFechaInicio}', 'DD/MM/YYYY'), null)";
            }
            return objDatos.ejecutarDML(consulta);
        }
    }
}
