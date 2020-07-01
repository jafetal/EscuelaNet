using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Escuela_BLL;
using Escuela_DAL;

namespace Escuela.Facultades
{
    public partial class facultad_i : TemaEscuela, IAcceso
    {
        #region evento
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (sessionIniciada())
                {
                    cargarUniversidades();
                    cargarEstados();
                    cargarTable();
                    cargarMaterias();
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


        protected void ddlEstados_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddlEstados.SelectedIndex != 0)
            {
                ddlCiudad.Items.Clear();
                cargarCiudades();
            }
            else
            {
                ddlCiudad.Items.Clear();
            }
        }

        #endregion

        #region Métodos
        public void agregarFacultad()
        {
            FacultadBLL facuBLL = new FacultadBLL();

            Facultad facultad = new Facultad();
            facultad.codigo = txtcodigo.Text;
            facultad.nombre = txtNombre.Text;
            facultad.fechaCreacion = Convert.ToDateTime(txtFecha.Text);
            facultad.universidad = int.Parse(ddlUniversidad.SelectedValue);
            facultad.ciudad = int.Parse(ddlCiudad.SelectedValue);
            try
            {

                MateriaFacultad materiaFacu;
                List<MateriaFacultad> listMaterias = new List<MateriaFacultad>();

                foreach (ListItem item in listBoxMaterias.Items)
                {
                    if (item.Selected)
                    {
                        materiaFacu = new MateriaFacultad();
                        materiaFacu.materia = int.Parse(item.Value);
                        materiaFacu.facultad = facultad.ID_Facultad;
                        listMaterias.Add(materiaFacu);
                    }
                }

                facuBLL.agregarFacultad(facultad,listMaterias);
                limpiarCampos();
            }
            catch (Exception ex)
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), "Alta", "alert('" + ex.Message + "')", true);

            }
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

        public void cargarMaterias()
        {
            MateriaBLL materia = new MateriaBLL();
            List<Materia> listMaterias = new List<Materia>();

            listMaterias = materia.cargarMaterias();

            listBoxMaterias.DataSource = listMaterias;
            listBoxMaterias.DataTextField = "nombre";
            listBoxMaterias.DataValueField = "ID_Materia";
            listBoxMaterias.DataBind();
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
        public void cargarEstados()
        {
            EstadoBLL estado = new EstadoBLL();
            DataTable dtEstados = new DataTable();

            dtEstados = estado.cargarEstados();

            ddlEstados.DataSource = dtEstados;
            ddlEstados.DataTextField = "nombre";
            ddlEstados.DataValueField = "ID_Estado";
            ddlEstados.DataBind();

            ddlEstados.Items.Insert(0, new ListItem("---- Seleccione Estado ----", "0"));
        }

        public void cargarCiudades()
        {
            CiudadBLL estado = new CiudadBLL();
            DataTable dtCiudades = new DataTable();

            dtCiudades = estado.cargarCiudadesPorEstado(int.Parse(ddlEstados.SelectedValue));

            ddlCiudad.DataSource = dtCiudades;
            ddlCiudad.DataTextField = "nombre";
            ddlCiudad.DataValueField = "ID_Ciudad";
            ddlCiudad.DataBind();

            ddlCiudad.Items.Insert(0, new ListItem("---- Seleccione Ciudad ----", "0"));
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