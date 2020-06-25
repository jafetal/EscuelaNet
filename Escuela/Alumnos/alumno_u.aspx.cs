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
    public partial class alumno_u : System.Web.UI.Page
    {
 
    #region Eventos
    protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                int matricula = int.Parse(Request.QueryString["pMatricula"]);
                cargarFacultades();
                cargarAlumno(matricula);
            }
        }

    protected void btnEditar_Click(object sender, EventArgs e)
    {
        modificarAlumno();
        Page.ClientScript.RegisterStartupScript(this.GetType(), "Alta", "alert('Alumno modificado exitosamente')", true);
        }
        #endregion

        #region Métodos
    public void cargarAlumno(int matricula)
    {
        AlumnoBLL alumBLL = new AlumnoBLL();
        DataTable dtAlumno = new DataTable();

        dtAlumno = alumBLL.cargarAlumno(matricula);

        lblMatricula.Text = dtAlumno.Rows[0]["matricula"].ToString();
        txtNombre.Text = dtAlumno.Rows[0]["nombre"].ToString();
        txtFechaNacimiento.Text = dtAlumno.Rows[0]["fechaNacimiento"].ToString().Substring(0,10);
        txtSemestre.Text = dtAlumno.Rows[0]["semestre"].ToString();
        ddlFacultad.SelectedValue = dtAlumno.Rows[0]["facultad"].ToString();
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

    public void modificarAlumno()
    {
            AlumnoBLL alumBLL = new AlumnoBLL();

            int matricula = int.Parse(lblMatricula.Text);
            string nombre = txtNombre.Text;
            DateTime fechaNacimiento = Convert.ToDateTime(txtFechaNacimiento.Text);
            int semestre = int.Parse(txtSemestre.Text);
            int facultad = int.Parse(ddlFacultad.SelectedValue);

            alumBLL.modificarAlumno(matricula, nombre, fechaNacimiento, semestre, facultad);
        }
        #endregion

    }
}