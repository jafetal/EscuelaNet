﻿using Escuela_DAL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Escuela_BLL
{
    public class CiudadBLL
    {
        public DataTable cargarCiudadesPorEstado(int estado)
        {
            CiudadDAL ciudad = new CiudadDAL();
            return ciudad.cargarCiudadPorEstado(estado);
        }
    }
}
