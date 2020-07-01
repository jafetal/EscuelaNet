using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Escuela_DAL
{
    public class MateriaDAL
    {
        EscuelaEntities modelo;

        public MateriaDAL()
        {
            modelo = new EscuelaEntities();
        }

        public List<Materia> cargarMaterias()
        {
            var materias = from mMaterias in modelo.Materia
                           select mMaterias;

            return materias.ToList(); 
        }

        public void eliminarMaterias(int id)
        {
            var materias = from tMaterias in modelo.MateriaFacultad
                          where tMaterias.facultad == id
                          select tMaterias;

            foreach(MateriaFacultad materia in materias)
            {
                modelo.MateriaFacultad.Remove(materia);
                modelo.SaveChanges();
            }
        }
    }
}
