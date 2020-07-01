using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Escuela_DAL;

namespace Escuela_BLL
{
    class MateriaFacultadBLL
    {
        public void agregarMateriaFacultad(MateriaFacultad materia)
        {
            MateriaFacultadDAL matFacultad = new MateriaFacultadDAL();
            matFacultad.AgregarMateriaFacultad(materia);
        }

        public void eliminarMaterias(int id)
        {
            MateriaFacultadDAL matFacu = new MateriaFacultadDAL();
            matFacu.eliminarMaterias(id);
        }
    }
}
