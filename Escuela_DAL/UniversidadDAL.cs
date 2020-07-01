using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Escuela_DAL
{
    public class UniversidadDAL
    {
        EscuelaEntities modelo;

        public UniversidadDAL()
        {
            modelo = new EscuelaEntities();
        }
        public List<Universidad> cargarUniversidades()
        {
            var universidades = from mUniversidades in modelo.Universidad
                                select mUniversidades;

            return universidades.ToList();
        }
    }
}
