using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using TrabajoFinalBD_EMedina_Jvasquez.accesoDatos;
namespace TrabajoFinalBD_EMedina_Jvasquez.logica
{
    class Abogado
    {
        Datos objDatos = new Datos();
        public int registrarAbogado(int nId, string nombre, string tipoAbogado, string numCasos)
        {
            string consulta = "insert into Abogado(abogNumId, abogNombre, abogTipoAbogado, abogNumCasosGanados) values ("
                + $"{nId}, '{nombre}', '{tipoAbogado}', '{numCasos}')";
            return objDatos.ejecutarDML(consulta);
        }
        internal DataSet consultarAbogXFechaInicio(string anio, string mes, string dia)
        {
            DataSet miDs = new DataSet();
            string consulta;
            consulta = "SELECT c.consnit NIT_CONSORCIO,consnombre NOMBRE_CONSORCIO,T2.abognumid ID_ABOGADO, abognombre NOMBRE_ABOGADO,abogtipoabogado TIPO_ABOGADO,trabfechafin FECHA_FIN_CONTRATO FROM(SELECT a.abognumid,abognombre,abogtipoabogado,consnit,trabfechafin FROM(SELECT * FROM trabaja T WHERE trabfechainicio = '" + dia + "/" + mes + "/" + anio + "')T1 INNER JOIN abogado A ON A.abognumid = T1.abognumid)T2 INNER JOIN consorcio C ON c.consnit = t2.consnit";

            miDs = objDatos.ejecutarSelect(consulta);
            return miDs;
        }
        internal DataSet consultaCantAbogPenalistas()
        {
            DataSet miDs = new DataSet();
            string consulta;
            consulta = "SELECT count(*) FROM abogado WHERE abogtipoabogado = 'Penalista' OR abogtipoabogado = 'penalista'";

            miDs = objDatos.ejecutarSelect(consulta);
            return miDs;
        }
    }
}
