using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Escuela_DAL;

namespace Escuela_BLL
{
    public class FacultadBLL
    {
        public DataTable cargarFacultades()
        {
            FacultadDAL facultad = new FacultadDAL();
            return facultad.cargarFacultades();
        }
        public void agregarFacultad(string codigo, string nombre, DateTime fechaCreacion, int universidad)
        {
            FacultadDAL facultad = new FacultadDAL();
            facultad.agregarfacultad(codigo, nombre, fechaCreacion, universidad);
        }

        public DataTable cargarFacultad(int matricula)
        {
            FacultadDAL facultad = new FacultadDAL();
            return facultad.cargarFacultad(matricula);
        }

        public void modificarFacultad(int id, string codigo, string nombre, DateTime fechaCreacion, int universidad)
        {
            FacultadDAL facultad = new FacultadDAL();
            facultad.modificarFacultad(id, codigo, nombre, fechaCreacion, universidad);
        }

        public void eliminarFacultad(int matricula)
        {
            FacultadDAL facultad = new FacultadDAL();
            facultad.eliminarFacultad(matricula);
        }
    }
}
