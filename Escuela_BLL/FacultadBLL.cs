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
        public void agregarFacultad(string codigo, string nombre, DateTime fechaCreacion, int universidad, int ciudad)
        {
            FacultadDAL facultad = new FacultadDAL();
            DataTable dtfacultad = new DataTable();

            dtfacultad = cargarFacultadCod(codigo);

            if (dtfacultad.Rows.Count > 0)
            {
                throw new Exception("El código ya existe en la base de datos.");
            }
            else
            {
                if (fechaCreacion.Year < 1900)
                {
                    throw new Exception("Fecha no permitida, introduce una fecha mayor a 1900.");
                }
                else if (fechaCreacion.Year > 2010)
                {
                    throw new Exception("Fecha no permitida, introduce una fecha menor que 2010.");
                }
                else
                {
                    facultad.agregarfacultad(codigo, nombre, fechaCreacion, universidad,ciudad);
                }
            }
        }

        public DataTable cargarFacultad(int matricula)
        {
            FacultadDAL facultad = new FacultadDAL();
            return facultad.cargarFacultad(matricula);
        }

        public void modificarFacultad(int id, string codigo, string nombre, DateTime fechaCreacion, int universidad, int ciudad)
        {
            FacultadDAL facultad = new FacultadDAL();


            DataTable dtfacultad = new DataTable();

            dtfacultad = cargarFacultadCod(codigo);

            if (dtfacultad.Rows.Count > 0)
            {
                throw new Exception("El código ya existe en la base de datos.");
            }
            else
            {
                if (fechaCreacion.Year < 1900)
                {
                    throw new Exception("Fecha no permitida, introduce una fecha mayor a 1900.");
                }
                else if (fechaCreacion.Year > 2010)
                {
                    throw new Exception("Fecha no permitida, introduce una fecha menor que 2010.");
                }
                else
                {
                    facultad.modificarFacultad(id, codigo, nombre, fechaCreacion, universidad, ciudad);
                }
            }
        }

        public void eliminarFacultad(int matricula)
        {
            FacultadDAL facultad = new FacultadDAL();
            facultad.eliminarFacultad(matricula);
        }

        public DataTable cargarFacultadCod(string codigo)
        {
            FacultadDAL facultad = new FacultadDAL();
            return facultad.cargarFacultadcod(codigo);
        }
    }
}
