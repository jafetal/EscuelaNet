using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Escuela_DAL;
using System.Data;

namespace Escuela_BLL
{
    public class AlumnoBLL
    {
        public DataTable cargarAlumnos()
        {
            AlumnoDAL alumno = new AlumnoDAL();
            return alumno.cargarAlumnos(); 

        }

        public void agregarAlumno(int matricula, string nombre, DateTime fechaNacimiento, int semestre, int facultad)
        {
            AlumnoDAL alumno = new AlumnoDAL();
            DataTable dtAlumno = new DataTable();

            dtAlumno = cargarAlumno(matricula);

            if(dtAlumno.Rows.Count > 0)
            {
                throw new Exception("La matricula ya existe en la base de datos.");
            }
            else
            {
                int edad = DateTime.Now.Year - fechaNacimiento.Year;

                if(edad > 80)
                {
                    throw new Exception("El alumno es demasiado viejo, Ingrese otra edad.");
                }
                else
                {
                    alumno.agregarAlumno(matricula, nombre, fechaNacimiento, semestre, facultad);
                }
            }

        }

        public DataTable cargarAlumno(int matricula)
        {
            AlumnoDAL alumno = new AlumnoDAL();
            return alumno.cargarAlumno(matricula);
        }

        public void modificarAlumno(int matricula, string nombre, DateTime fechaNacimiento, int semestre, int facultad)
        {
            AlumnoDAL alumno = new AlumnoDAL();
            alumno.modificarAlumno(matricula, nombre, fechaNacimiento, semestre, facultad);
        }

        public void eliminarAlumno(int matricula)
        {
            AlumnoDAL alumno = new AlumnoDAL();
            alumno.eliminarAlumno(matricula);
        }

    }
}
