﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Escuela_DAL;

namespace Escuela_BLL
{
    public class UniversidadBLL
    { 
        public List<Universidad> cargarUniversidades()
        {
            UniversidadDAL facultad = new UniversidadDAL();
            return facultad.cargarUniversidades();
        }
    }
}
