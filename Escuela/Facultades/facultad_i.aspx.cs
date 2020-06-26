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
    public partial class facultad_i : System.Web.UI.Page, IAcceso
    {
        #region evento
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (sessionIniciada())
                {
                    cargarUniversidades();
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
            agregarFacultad();
            Page.ClientScript.RegisterStartupScript(this.GetType(), "Alta", "alert('FAcultad agregada exitosamente')", true);
        }

        #endregion

        #region Métodos
        public void agregarFacultad()
        {
            FacultadBLL facuBLL = new FacultadBLL();

            string codigo = txtcodigo.Text;
            string nombre = txtNombre.Text;
            DateTime fechaCreacion = Convert.ToDateTime(txtFecha.Text);
            int universidad = int.Parse(ddlUniversidad.SelectedValue);

            try
            {
                facuBLL.agregarFacultad(codigo, nombre, fechaCreacion, universidad);
                limpiarCampos();

                DataTable dtFacultades = new DataTable();
                dtFacultades = (DataTable)ViewState["tablaFacultades"];
                dtFacultades.Rows.Add(codigo, nombre);

                grd_alumnos.DataSource = dtFacultades;
                grd_alumnos.DataBind();
            }
            catch (Exception ex)
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), "Alta", "alert('" + ex.Message + "')", true);

            }
        }

        public void cargarUniversidades()
        {
            UniversidadBLL uniBLL = new UniversidadBLL();
            DataTable dtUniversidades = new DataTable();

            dtUniversidades = uniBLL.cargarUniversidades();

            ddlUniversidad.DataSource = dtUniversidades;
            ddlUniversidad.DataTextField = "nombre";
            ddlUniversidad.DataValueField = "ID_Universidad";
            ddlUniversidad.DataBind();

            ddlUniversidad.Items.Insert(0, new ListItem("---- Seleccione Universidad ----", "0"));

        }

        public void cargarTable()
        {
            DataTable dt = new DataTable();

            dt.Columns.Add("codigo");
            dt.Columns.Add("nombre");

            ViewState["tablaFacultades"] = dt;
        }

        public void limpiarCampos()
        {
            txtcodigo.Text = "";
            txtFecha.Text = "";
            txtNombre.Text = "";
            ddlUniversidad.SelectedIndex = 0;
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