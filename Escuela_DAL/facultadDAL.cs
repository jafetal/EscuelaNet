using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Escuela_DAL
{
    public class FacultadDAL
    {
        EscuelaEntities modelo;

        public FacultadDAL()
        {
            modelo = new EscuelaEntities();
        }

        public List<object> cargarFacultades()
        {
            var facultades = from mFacultades in modelo.Facultad
                             select new
                             {
                                 ID_Facultad = mFacultades.ID_Facultad,
                                 codigo = mFacultades.codigo,
                                 nombre = mFacultades.nombre,
                                 fechaCreacion = mFacultades.fechaCreacion,
                                 nombreUniversidad = mFacultades.Universidad1.nombre,
                                 nombreCiudad = mFacultades.Ciudad1.nombre
                             };
            return facultades.AsEnumerable<object>().ToList();
        }

        public void agregarfacultad(Facultad facultad)
        {
            modelo.Facultad.Add(facultad);
            modelo.SaveChanges();
        }

        public Facultad cargarFacultad(int idFacultad)
        {
            var facultad = (from mFacultades in modelo.Facultad
                              where mFacultades.ID_Facultad == idFacultad
                              select mFacultades).FirstOrDefault();

            return facultad;
        }

        public Facultad cargarFacultadcod(string codigo)
         {
            var facultad = (from mFacultades in modelo.Facultad
                            where mFacultades.codigo == codigo
                            select mFacultades).FirstOrDefault();

            return facultad;
        }

        public void modificarFacultad(Facultad pFacultad)
        {
            var facultad = (from mFacultades in modelo.Facultad
                            where mFacultades.ID_Facultad == pFacultad.ID_Facultad
                            select mFacultades).FirstOrDefault();
            facultad.codigo = pFacultad.codigo;
            facultad.nombre = pFacultad.nombre;
            facultad.fechaCreacion = pFacultad.fechaCreacion;
            facultad.universidad = pFacultad.universidad;
            facultad.ciudad = pFacultad.ciudad;

            modelo.SaveChanges();
        }

        public void eliminarFacultad(int id)
        {
            var facultad = (from mFacultades in modelo.Facultad
                            where mFacultades.ID_Facultad == id
                            select mFacultades).FirstOrDefault();

            modelo.Facultad.Remove(facultad);
            modelo.SaveChanges();
        }
    }
}
