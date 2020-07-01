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
    public partial class facultad_u : TemaEscuela, IAcceso
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
                    cargarEstados();
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
        public void cargarFacultad(int id)
        {
            FacultadBLL facuBLL = new FacultadBLL();
            Facultad facu = new Facultad();

            facu = facuBLL.cargarFacultad(id);

            lblId.Text = facu.ID_Facultad.ToString();
            txtcodigo.Text = facu.codigo;
            txtNombre.Text = facu.nombre;
            txtFecha.Text = facu.fechaCreacion.ToString().Substring(0, 10);
            ddlUniversidad.SelectedValue = facu.universidad.ToString();

            cargarEstados();
            ddlEstados.SelectedValue = facu.Ciudad1.estado.ToString();
            cargarCiudades();
            ddlCiudad.SelectedValue = facu.ciudad.ToString();

            cargarMaterias();
            List<MateriaFacultad> listMaterias = new List<MateriaFacultad>();
            listMaterias = facu.MateriaFacultad.ToList();

            foreach(MateriaFacultad materiaFacu in listMaterias)
            {
                listBoxMaterias.Items.FindByValue(materiaFacu.materia.ToString()).Selected = true;
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

        public void modificarFacultad()
        {
            FacultadBLL facuBLL = new FacultadBLL();

            Facultad facu = new Facultad();

            facu.ID_Facultad = int.Parse(lblId.Text);
            facu.codigo = txtcodigo.Text;
            facu.nombre = txtNombre.Text;
            facu.fechaCreacion = Convert.ToDateTime(txtFecha.Text);
            facu.universidad = int.Parse(ddlUniversidad.SelectedValue);
            facu.ciudad = int.Parse(ddlCiudad.SelectedValue);

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
                        materiaFacu.facultad = facu.ID_Facultad;
                        listMaterias.Add(materiaFacu);
                    }
                }

                facuBLL.modificarFacultad(facu, listMaterias);
            }
            catch (Exception ex)
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), "Alta", "alert('" + ex.Message + "')", true);

            }

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