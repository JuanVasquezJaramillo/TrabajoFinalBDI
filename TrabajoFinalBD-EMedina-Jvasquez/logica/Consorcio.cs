using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrabajoFinalBD_EMedina_Jvasquez.accesoDatos;
using System.Data;

namespace TrabajoFinalBD_EMedina_Jvasquez.logica
{
    class Consorcio
    {
        Datos objDatos = new Datos();
       public int registrarConsorcio(int nit, int fecha, string nombre)
        {
            string consulta = "insert into Consorcio(consNit, consAnioFundacion, consNombre) values ("
                + $"{nit}, {fecha}, '{nombre}')";
            return objDatos.ejecutarDML(consulta);
        }
    }
}
