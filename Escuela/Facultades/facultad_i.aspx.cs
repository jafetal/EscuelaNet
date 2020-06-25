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
    public partial class facultad_i : System.Web.UI.Page
    {
        #region evento
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                cargarUniversidades();
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

            facuBLL.agregarFacultad(codigo,nombre,fechaCreacion,universidad);
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

        #endregion
    }
}