using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Escuela_BLL;

namespace Escuela.Alumnos
{
    public partial class alumno_d : TemaEscuela, IAcceso
    {
        #region Eventos
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (sessionIniciada())
                {
                    int matricula = int.Parse(Request.QueryString["pMatricula"]);
                    cargarFacultades();
                    cargarAlumno(matricula);
                }
                else
                {
                    Response.Redirect("~/Login.aspx");
                }
            }
        }

        protected void btnEliminar_Click(object sender, EventArgs e)
        {
            eliminarAlumno();
            Page.ClientScript.RegisterStartupScript(this.GetType(), "Alta", "alert('Se eliminó el alumno exitosamente')", true);

        }

        #endregion

        #region Métodos
        public void cargarAlumno(int matricula)
        {
            AlumnoBLL alumBLL = new AlumnoBLL();
            DataTable dtAlumno = new DataTable();

            dtAlumno = alumBLL.cargarAlumno(matricula);

            lblMatricula.Text = dtAlumno.Rows[0]["matricula"].ToString();
            lblNombre.Text = dtAlumno.Rows[0]["nombre"].ToString();
            lblFecha.Text = dtAlumno.Rows[0]["fechaNacimiento"].ToString().Substring(0, 10);
            lblSemestre.Text = dtAlumno.Rows[0]["semestre"].ToString();
            ddlFacultad.SelectedValue = dtAlumno.Rows[0]["facultad"].ToString();
        }

        public void cargarFacultades()
        {
            FacultadBLL facuBLL = new FacultadBLL();
            List<object> dtFacultades = new List<object>();

            dtFacultades = facuBLL.cargarFacultades();

            ddlFacultad.DataSource = dtFacultades;
            ddlFacultad.DataTextField = "nombre";
            ddlFacultad.DataValueField = "ID_Facultad";
            ddlFacultad.DataBind();

            ddlFacultad.Items.Insert(0, new ListItem("---- Seleccione Facultad ----", "0"));
        }


        public void eliminarAlumno()
        {
            AlumnoBLL alumBLL = new AlumnoBLL();

            int matricula = int.Parse(lblMatricula.Text);

            alumBLL.eliminarAlumno(matricula);
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