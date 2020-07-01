using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Escuela_DAL;
using System.Transactions;

namespace Escuela_BLL
{
    public class FacultadBLL
    {
        public List<object> cargarFacultades()
        {
            FacultadDAL facultad = new FacultadDAL();
            return facultad.cargarFacultades();
        }
        public void agregarFacultad(Facultad paramFacultad, List<MateriaFacultad> listMaterias)
        {
            FacultadDAL facultad = new FacultadDAL();
            Facultad facu = new Facultad();
            MateriaFacultadBLL matFacuBLL = new MateriaFacultadBLL();

            facu = facultad.cargarFacultadcod(paramFacultad.codigo);

            if (facu!=null)
            {
                throw new Exception("El código ya existe en la base de datos.");
            }
            else
            {

                    if (paramFacultad.fechaCreacion.Year < 1900)
                    {
                        throw new Exception("Fecha no permitida, introduce una fecha mayor a 1900.");
                    }
                    else if (paramFacultad.fechaCreacion.Year > 2010)
                    {
                        throw new Exception("Fecha no permitida, introduce una fecha menor que 2010.");
                    }
                    else
                    {
                        using (TransactionScope ts = new TransactionScope())
                        {
                            facultad.agregarfacultad(paramFacultad);
                            foreach (MateriaFacultad materia in listMaterias)
                            {
                                materia.facultad = paramFacultad.ID_Facultad;
                                matFacuBLL.agregarMateriaFacultad(materia);
                                Console.WriteLine("YEI");
                            }

                            ts.Complete();
                        }
                    }
            }
        }

        public Facultad cargarFacultad(int matricula)
        {
            FacultadDAL facultad = new FacultadDAL();
            return facultad.cargarFacultad(matricula);
        }

        public void modificarFacultad(Facultad paramFacultad, List<MateriaFacultad> listMaterias)
        {
            FacultadDAL facultad = new FacultadDAL();


            Facultad facu = new Facultad();
            MateriaFacultadBLL matFacuBLL = new MateriaFacultadBLL();

            facu = facultad.cargarFacultadcod(paramFacultad.codigo);

            if (facu == null || facu.codigo == paramFacultad.codigo)
            {
                if (paramFacultad.fechaCreacion.Year < 1900)
                {
                    throw new Exception("Fecha no permitida, introduce una fecha mayor a 1900.");
                }
                else if (paramFacultad.fechaCreacion.Year > 2010)
                {
                    throw new Exception("Fecha no permitida, introduce una fecha menor que 2010.");
                }
                else
                {
                    using (TransactionScope ts = new TransactionScope())
                    {
                        facultad.modificarFacultad(paramFacultad);
                        matFacuBLL.eliminarMaterias(paramFacultad.ID_Facultad);


                        foreach (MateriaFacultad materia in listMaterias)
                        {
                            matFacuBLL.agregarMateriaFacultad(materia);
                        }

                        ts.Complete();
                    }
                    
                }
            }
            else
            {
                throw new Exception("Código no vàlido.");
            }
        }

        public void eliminarFacultad(int matricula)
        {
            FacultadDAL facultad = new FacultadDAL();
            MateriaFacultadBLL matFacultad = new MateriaFacultadBLL();

            using(TransactionScope ts = new TransactionScope())
            {
                matFacultad.eliminarMaterias(matricula);
                facultad.eliminarFacultad(matricula);

                ts.Complete();
            }

            
        }

        /*public Facultad cargarFacultadCod(string codigo)
        {
            FacultadDAL facultad = new FacultadDAL();
            return facultad.cargarFacultadcod(codigo);
        }*/
    }
}
