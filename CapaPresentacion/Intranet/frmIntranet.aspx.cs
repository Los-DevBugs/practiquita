using CapaNegocio;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CapaPresentacion.Intranet
{
    public partial class frmIntranet : System.Web.UI.Page
    {
        private void Listar()
        {
            Alumno alumno = new Alumno();
            gvAlumno.DataSource = alumno.Listar();
            gvAlumno.DataBind();

            Docente docente = new Docente();
            gvDocente.DataSource = docente.Listar();
            gvDocente.DataBind();

            Asignatura asignatura = new Asignatura();
            gvAsignatura.DataSource = asignatura.Listar();
            gvAsignatura.DataBind();
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                Listar();
            }
            else
            {
                // Recuperar la pestaña activa del campo oculto
                string activeTabIndex = hdnActiveTabIndex.Value;
                ScriptManager.RegisterStartupScript(this, this.GetType(), "SetActiveTab", $"document.querySelectorAll('.nav-tabs a')[{activeTabIndex}].click();", true);
            }
        }

        protected void btnAgregarAlumno_Click(object sender, EventArgs e)
        {
            Alumno alumno = new Alumno();
            alumno.CodAlumno = txtCodAlumno.Text.Trim();
            alumno.APaterno = txtAPaternoAlumno.Text.Trim();
            alumno.AMaterno = txtAMaternoAlumno.Text.Trim();
            alumno.Nombres = txtNombresAlumno.Text.Trim();
            alumno.Usuario = txtUsuarioAlumno.Text.Trim();
            alumno.CodCarrera = txtCodCarrera.Text.Trim();
            if (alumno.Agregar())
                Listar();
            else
            {
                Response.Write("Error: No se agregó correctamente");
            }
        }

        protected void btnEliminarAlumno_Click(object sender, EventArgs e)
        {
            Alumno alumno = new Alumno();
            alumno.CodAlumno = txtCodAlumno.Text.Trim();
            alumno.APaterno = txtAPaternoAlumno.Text.Trim();
            alumno.AMaterno = txtAMaternoAlumno.Text.Trim();
            alumno.Nombres = txtNombresAlumno.Text.Trim();
            alumno.Usuario = txtUsuarioAlumno.Text.Trim();
            alumno.CodCarrera = txtCodCarrera.Text.Trim();
            if (alumno.Eliminar())
                Listar();
            else
            {
                Response.Write("Error: No se eliminó correctamente");
            }
        }

        protected void btnActualizarAlumno_Click(object sender, EventArgs e)
        {
            Alumno alumno = new Alumno();
            alumno.CodAlumno = txtCodAlumno.Text.Trim();
            alumno.APaterno = txtAPaternoAlumno.Text.Trim();
            alumno.AMaterno = txtAMaternoAlumno.Text.Trim();
            alumno.Nombres = txtNombresAlumno.Text.Trim();
            alumno.Usuario = txtUsuarioAlumno.Text.Trim();
            alumno.CodCarrera = txtCodCarrera.Text.Trim();
            if (alumno.Actualizar())
                Listar();
            else
            {
                Response.Write("Error: No se actualizó correctamente");
            }
        }

        protected void btnBuscarAlumno_Click(object sender, EventArgs e)
        {
            string criterio = txtBuscarAlumno.Text.Trim(); // Obtener el criterio de búsqueda

            DataTable resultado = new Alumno().Buscar(criterio);

            if (resultado.Rows.Count > 0)
            {
                gvAlumno.DataSource = resultado; // Asignar el DataTable al GridView
                gvAlumno.DataBind(); // Realizar el binding
            }
            else
            {
                Response.Write("No se encontraron resultados");
                gvAlumno.DataSource = null; // Limpiar el GridView si no hay resultados
                gvAlumno.DataBind(); // Realizar el binding para limpiar la vista
            }
        }

        protected void btnAgregarDocente_Click(object sender, EventArgs e)
        {
            Docente docente = new Docente();
            docente.CodDocente = txtCodDocente.Text.Trim();
            docente.APaterno = txtAPaternoDocente.Text.Trim();
            docente.AMaterno = txtAMaternoDocente.Text.Trim();
            docente.Nombres = txtNombresDocente.Text.Trim();
            docente.Usuario = txtUsuarioDocente.Text.Trim();
            if (docente.Agregar())
                Listar();
            else
            {
                Response.Write("Error: No se agregó correctamente");
            }
        }

        protected void btnEliminarDocente_Click(object sender, EventArgs e)
        {
            Docente docente = new Docente();
            docente.CodDocente = txtCodDocente.Text.Trim();
            docente.APaterno = txtAPaternoDocente.Text.Trim();
            docente.AMaterno = txtAMaternoDocente.Text.Trim();
            docente.Nombres = txtNombresDocente.Text.Trim();
            docente.Usuario = txtUsuarioDocente.Text.Trim();
            if (docente.Eliminar())
                Listar();
            else
            {
                Response.Write("Error: No se eliminó correctamente");
            }
        }

        protected void btnActualizarDocente_Click(object sender, EventArgs e)
        {
            Docente docente = new Docente();
            docente.CodDocente = txtCodDocente.Text.Trim();
            docente.APaterno = txtAPaternoDocente.Text.Trim();
            docente.AMaterno = txtAMaternoDocente.Text.Trim();
            docente.Nombres = txtNombresDocente.Text.Trim();
            docente.Usuario = txtUsuarioDocente.Text.Trim();
            if (docente.Actualizar())
                Listar();
            else
            {
                Response.Write("Error: No se actualizó correctamente");
            }
        }

        protected void btnBuscarDocente_Click(object sender, EventArgs e)
        {
            string criterio = txtBuscarDocente.Text.Trim(); // Obtener el criterio de búsqueda

            DataTable resultado = new Docente().Buscar(criterio);

            if (resultado.Rows.Count > 0)
            {
                gvDocente.DataSource = resultado; // Asignar el DataTable al GridView
                gvDocente.DataBind(); // Realizar el binding
            }
            else
            {
                Response.Write("No se encontraron resultados");
                gvDocente.DataSource = null; // Limpiar el GridView si no hay resultados
                gvDocente.DataBind(); // Realizar el binding para limpiar la vista
            }
        }

        protected void btnAgregarAsignatura_Click(object sender, EventArgs e)
        {
            Asignatura asignatura = new Asignatura();
            asignatura.CodAsignatura = txtCodAsignatura.Text.Trim();
            asignatura.NombreAsignatura = txtNombreAsignatura.Text.Trim();
            asignatura.CodRequisito = txtCodRequisito.Text.Trim();
            if (asignatura.Agregar())
                Listar();
            else
            {
                Response.Write("Error: No se agregó correctamente");
            }
        }

        protected void btnEliminarAsignatura_Click(object sender, EventArgs e)
        {
            Asignatura asignatura = new Asignatura();
            asignatura.CodAsignatura = txtCodAsignatura.Text.Trim();
            asignatura.NombreAsignatura = txtNombreAsignatura.Text.Trim();
            asignatura.CodRequisito = txtCodRequisito.Text.Trim();
            if (asignatura.Eliminar())
                Listar();
            else
            {
                Response.Write("Error: No se eliminó correctamente");
            }
        }

        protected void btnActualizarAsignatura_Click(object sender, EventArgs e)
        {
            Asignatura asignatura = new Asignatura();
            asignatura.CodAsignatura = txtCodAsignatura.Text.Trim();
            asignatura.NombreAsignatura = txtNombreAsignatura.Text.Trim();
            asignatura.CodRequisito = txtCodRequisito.Text.Trim();
            if (asignatura.Actualizar())
                Listar();
            else
            {
                Response.Write("Error: No se actualizó correctamente");
            }
        }

        protected void btnBuscarAsignatura_Click(object sender, EventArgs e)
        {
            string criterio = txtBuscarAsignatura.Text.Trim(); // Obtener el criterio de búsqueda

            DataTable resultado = new Asignatura().Buscar(criterio);

            if (resultado.Rows.Count > 0)
            {
                gvAsignatura.DataSource = resultado; // Asignar el DataTable al GridView
                gvAsignatura.DataBind(); // Realizar el binding
            }
            else
            {
                Response.Write("No se encontraron resultados");
                gvAsignatura.DataSource = null; // Limpiar el GridView si no hay resultados
                gvAsignatura.DataBind(); // Realizar el binding para limpiar la vista
            }
        }
    }
}