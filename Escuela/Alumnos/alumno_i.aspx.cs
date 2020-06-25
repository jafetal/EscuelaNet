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
    public partial class alumno_i : System.Web.UI.Page
    {
        #region evento
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                cargarFacultades();
            }
        }

        protected void btnAgregar_Click(object sender, EventArgs e)
        {
            agregarAlumno();
            Page.ClientScript.RegisterStartupScript(this.GetType(), "Alta", "alert('Alumno agregado exitosamente')", true);
        }

        #endregion

        #region Métodos
        public void agregarAlumno()
        {
            AlumnoBLL alumBLL = new AlumnoBLL();

            int matricula = int.Parse(txtMatricula.Text);
            string nombre = txtNombre.Text;
            DateTime fechaNacimiento = Convert.ToDateTime(txtFechaNacimiento.Text);
            int semestre = int.Parse(txtSemestre.Text);
            int facultad = int.Parse(ddlFacultad.SelectedValue);

            alumBLL.agregarAlumno(matricula, nombre, fechaNacimiento, semestre, facultad);
        }

        public void cargarFacultades()
        {
            FacultadBLL facuBLL = new FacultadBLL();
            DataTable dtFacultades = new DataTable();

            dtFacultades = facuBLL.cargarFacultades();

            ddlFacultad.DataSource = dtFacultades;
            ddlFacultad.DataTextField = "nombre";
            ddlFacultad.DataValueField = "ID_Facultad";
            ddlFacultad.DataBind();

            ddlFacultad.Items.Insert(0, new ListItem("---- Seleccione Facultad ----", "0"));

        }

        #endregion


    }
}