using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
    }
}
