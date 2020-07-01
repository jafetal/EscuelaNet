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
    public partial class alumno_i : TemaEscuela, IAcceso
    {
        #region evento
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (sessionIniciada())
                {
                    cargarFacultades();
                    cargarTable();
                }
                else
                {
                    Response.Redirect("~/Login.aspx");
                }
            }
        }

        protected void btnAgregar_Click(object sender, EventArgs e)
        {
            agregarAlumno();
            Page.ClientScript.RegisterStartupScript(this.GetType(), "Alta", "alert('Alumno agregado exitosamente')", true);
        }

        #endregion

        #region Métodos

        public void limpiarCampos()
        {
            txtFechaNacimiento.Text = "";
            txtMatricula.Text = "";
            txtNombre.Text = "";
            txtSemestre.Text = "";
            ddlFacultad.SelectedIndex = 0;
        }
        public void agregarAlumno()
        {
            AlumnoBLL alumBLL = new AlumnoBLL();

            int matricula = int.Parse(txtMatricula.Text);
            string nombre = txtNombre.Text;
            DateTime fechaNacimiento = Convert.ToDateTime(txtFechaNacimiento.Text);
            int semestre = int.Parse(txtSemestre.Text);
            int facultad = int.Parse(ddlFacultad.SelectedValue);

            try
            {
                alumBLL.agregarAlumno(matricula, nombre, fechaNacimiento, semestre, facultad);
                limpiarCampos();

                DataTable dtAlmunos = new DataTable();
                dtAlmunos = (DataTable)ViewState["tablaAlumnos"];
                dtAlmunos.Rows.Add(matricula,nombre);

                grd_alumnos.DataSource = dtAlmunos;
                grd_alumnos.DataBind();
            }
            catch(Exception ex)
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), "Alta", "alert('" + ex.Message + "')", true);

            }

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

        public void cargarTable()
        {
            DataTable dt = new DataTable();

            dt.Columns.Add("matricula");
            dt.Columns.Add("nombre");

            ViewState["tablaAlumnos"] = dt;
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