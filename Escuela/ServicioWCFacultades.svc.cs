using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Security;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Activation;
using System.ServiceModel.Web;
using System.Text;
using System.Web.Script.Serialization;
using Escuela_DAL;

namespace Escuela
{
    [ServiceContract(Namespace="")]
    [AspNetCompatibilityRequirements(RequirementsMode = AspNetCompatibilityRequirementsMode.Allowed)]
    public class ServicioWCFacultades
    {
        EscuelaEntities modelo;
        public ServicioWCFacultades()
        {
            modelo = new EscuelaEntities();
        }


        [WebGet]
        [OperationContract]
        public string ConsultaFacultadesJSON()
        {
            var facultades = from mFacultades in modelo.Facultad
                             select new
                             {
                                 ID_Facultad = mFacultades.ID_Facultad,
                                 codigo = mFacultades.codigo,
                                 nombre = mFacultades.nombre,
                                 fechaCreacion = mFacultades.fechaCreacion,
                                 nombreUniversidad = mFacultades.Universidad1.nombre,
                                 nombreCiudad = mFacultades.Ciudad1.nombre
                             };

            return (new JavaScriptSerializer().Serialize(facultades.AsEnumerable<object>().ToList()));
        }
    }
}
