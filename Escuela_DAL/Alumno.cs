//------------------------------------------------------------------------------
// <auto-generated>
//    Este código se generó a partir de una plantilla.
//
//    Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//    Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Escuela_DAL
{
    using System;
    using System.Collections.Generic;
    
    public partial class Alumno
    {
        public int matricula { get; set; }
        public string nombre { get; set; }
        public System.DateTime fechaNacimiento { get; set; }
        public int semestre { get; set; }
        public int facultad { get; set; }
    
        public virtual Facultad Facultad1 { get; set; }
    }
}
