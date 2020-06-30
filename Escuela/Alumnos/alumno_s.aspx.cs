using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Escuela_BLL;

namespace Escuela.Alumnos
{
    public partial class alumno_s : TemaEscuela, IAcceso
    {
        #region Eventos
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (sessionIniciada())
                {
                    grd_alumnos.DataSource = cargarAlumnos();
                    grd_alumnos.DataBind();
                }
                else
                {
                    Response.Redirect("~/Login.aspx");
                }
                
            }
        }

        protected void grd_alumnos_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "Editar")
            {
                Response.Redirect("~/Alumnos/alumno_u.aspx?pMatricula=" + e.CommandArgument);
            }
            else
            {
                Response.Redirect("~/Alumnos/alumno_d.aspx?pMatricula=" + e.CommandArgument);
            }
        }

        #endregion

        #region Métodos
        public DataTable cargarAlumnos()
        {
            AlumnoBLL alumBLL = new AlumnoBLL();
            DataTable dtAlumnos = new DataTable();

            dtAlumnos = alumBLL.cargarAlumnos();

            return dtAlumnos;
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