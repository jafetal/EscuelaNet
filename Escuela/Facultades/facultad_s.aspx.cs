using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Escuela_BLL;


namespace Escuela.Facultades
{
    public partial class facultad_s : TemaEscuela, IAcceso
    {
        #region Eventos
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (sessionIniciada())
                {
                    grd_facultades.DataSource = (cargarFacultades());
                    grd_facultades.DataBind();
                }
                else
                {
                    Response.Redirect("~/Login.aspx");
                }
            }
        }

        protected void grd_facultades_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "Editar")
            {
                Response.Redirect("~/Facultades/facultad_u.aspx?pId=" + e.CommandArgument);
            }
            else
            {
                Response.Redirect("~/Facultades/facultad_d.aspx?pId=" + e.CommandArgument);
            }
        }

        #endregion

        #region Métodos
        public List<object> cargarFacultades()
        {
            FacultadBLL facuBLL = new FacultadBLL();
            List<object> listFacultades = new List<object>();

            listFacultades = facuBLL.cargarFacultades();

            return listFacultades;
        }

        public bool sessionIniciada()
        {
            if (Session["Usuario"] != null)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        #endregion
    }
}