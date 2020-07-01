using Escuela_BLL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Escuela_DAL;

namespace Escuela.Facultades
{
    public partial class facultad_d : TemaEscuela, IAcceso
    {
        #region Eventos
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (sessionIniciada())
                {
                    int id = int.Parse(Request.QueryString["pId"]);
                    cargarUniversidades();
                    cargarFacultad(id);
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
            Page.ClientScript.RegisterStartupScript(this.GetType(), "Alta", "alert('Se eliminó la facultad exitosamente')", true);

        }

        #endregion

        #region Métodos
        public void cargarFacultad(int id)
        {
            FacultadBLL facuBLL = new FacultadBLL();
            Facultad facu = new Facultad();

            facu = facuBLL.cargarFacultad(id);

            lblId.Text = facu.ID_Facultad.ToString();
            lblcodigo.Text = facu.codigo;
            lblNombre.Text = facu.nombre;
            lblFecha.Text = facu.fechaCreacion.ToString().Substring(0, 10);
            ddlUniversidad.SelectedValue = facu.universidad.ToString();
        }

        public void cargarUniversidades()
        {
            UniversidadBLL uniBLL = new UniversidadBLL();
            List<Universidad> listUniversidades = new List<Universidad>();

            listUniversidades = uniBLL.cargarUniversidades();

            ddlUniversidad.DataSource = listUniversidades;
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