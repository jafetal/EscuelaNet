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
            alumno.agregarAlumno(matricula,nombre,fechaNacimiento,semestre,facultad);
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
