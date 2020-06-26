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
    public partial class facultad_u : System.Web.UI.Page, IAcceso
    {
        #region Eventos
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (sessionIniciada())
                {
                    int matricula = int.Parse(Request.QueryString["pId"]);
                    cargarUniversidades();
                    cargarFacultad(matricula);
                }
                else
                {
                    Response.Redirect("~/Login.aspx");
                }
            }
        }

        protected void btnEditar_Click(object sender, EventArgs e)
        {
            modificarFacultad();
            Page.ClientScript.RegisterStartupScript(this.GetType(), "Alta", "alert('Facultad modificada exitosamente')", true);
        }
        #endregion

        #region Métodos
        public void cargarFacultad(int id)
        {
            FacultadBLL facuBLL = new FacultadBLL();
            DataTable dtfacu = new DataTable();

            dtfacu = facuBLL.cargarFacultad(id);

            lblId.Text = dtfacu.Rows[0]["ID_Facultad"].ToString();
            txtcodigo.Text = dtfacu.Rows[0]["codigo"].ToString();
            txtNombre.Text = dtfacu.Rows[0]["nombre"].ToString();
            txtFecha.Text = dtfacu.Rows[0]["fechaCreacion"].ToString().Substring(0, 10);
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

        public void modificarFacultad()
        {
            FacultadBLL facuBLL = new FacultadBLL();

            int id = int.Parse(lblId.Text);
            string codigo = txtcodigo.Text;
            string nombre = txtNombre.Text;
            DateTime fechaCreacion = Convert.ToDateTime(txtFecha.Text);
            int universidad = int.Parse(ddlUniversidad.SelectedValue);

            try
            {
                facuBLL.modificarFacultad(id, codigo, nombre, fechaCreacion, universidad);

            }
            catch (Exception ex)
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), "Alta", "alert('" + ex.Message + "')", true);

            }

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