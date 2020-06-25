using Escuela_BLL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Escuela.Facultades
{
    public partial class facultad_d : System.Web.UI.Page
    {
        #region Eventos
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                int id = int.Parse(Request.QueryString["pId"]);
                cargarUniversidades();
                cargarFacultad(id);
            }
        }

        protected void btnEliminar_Click(object sender, EventArgs e)
        {
            eliminarAlumno();
            Page.ClientScript.RegisterStartupScript(this.GetType(), "Alta", "alert('Se eliminó la facultad exitosamente')", true);

        }

        #endregion

        #region Métodos
        public void cargarFacultad(int id)
        {
            FacultadBLL facuBLL = new FacultadBLL();
            DataTable dtfacu = new DataTable();

            dtfacu = facuBLL.cargarFacultad(id);

            lblId.Text = dtfacu.Rows[0]["ID_Facultad"].ToString();
            lblcodigo.Text = dtfacu.Rows[0]["codigo"].ToString();
            lblNombre.Text = dtfacu.Rows[0]["nombre"].ToString();
            lblFecha.Text = dtfacu.Rows[0]["fechaCreacion"].ToString().Substring(0, 10);
            ddlUniversidad.SelectedValue = dtfacu.Rows[0]["universidad"].ToString();
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


        public void eliminarAlumno()
        {
            FacultadBLL facuBLL = new FacultadBLL();

            int id = int.Parse(lblId.Text);

            facuBLL.eliminarFacultad(id);
        }
        #endregion
    }
}