<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="frmIntranet.aspx.cs" Inherits="CapaPresentacion.Intranet.frmIntranet" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <asp:HiddenField ID="hdnActiveTabIndex" runat="server" />
    
 <ul class="nav nav-tabs" role="tablist">
  <li class="nav-item" role="presentation">
    <a class="nav-link active" id="simple-tab-0" data-bs-toggle="tab" href="#simple-tabpanel-0" role="tab" aria-controls="simple-tabpanel-0" aria-selected="true">Alumno</a>
  </li>
  <li class="nav-item" role="presentation">
    <a class="nav-link" id="simple-tab-1" data-bs-toggle="tab" href="#simple-tabpanel-1" role="tab" aria-controls="simple-tabpanel-1" aria-selected="false">Docente</a>
  </li>
  <li class="nav-item" role="presentation">
    <a class="nav-link" id="simple-tab-2" data-bs-toggle="tab" href="#simple-tabpanel-2" role="tab" aria-controls="simple-tabpanel-2" aria-selected="false">Asignatura</a>
  </li>
</ul>
    
<div class="tab-content pt-5" id="tab-content">
  <div class="tab-pane fade active" id="simple-tabpanel-0" role="tabpanel" aria-labelledby="simple-tab-0"><h3>Mantimiento de la tabla Alumno</h3>
<p>
    CodAlumno : <asp:TextBox runat="server" ID="txtCodAlumno" />
</p>
<p>
    APaterno : <asp:TextBox runat="server" ID="txtAPaternoAlumno" />
</p>
<p>
    AMaterno : <asp:TextBox runat="server" ID="txtAMaternoAlumno" />
</p>
<p>
    Nombres : <asp:TextBox runat="server" ID="txtNombresAlumno" />
</p>
<p>
    Usuario : <asp:TextBox runat="server" ID="txtUsuarioAlumno" />
</p>
<p>
    CodCarera: <asp:TextBox runat="server" ID="txtCodCarrera" />
</p>
<p>
    <asp:Button Text="Agregar" runat="server" ID="btnAgregarAlumno" OnClick="btnAgregarAlumno_Click" />
    <asp:Button Text="Eliminar" runat="server" ID="btnEliminarAlumno" OnClick="btnEliminarAlumno_Click" />
    <asp:Button Text="Actualizar" runat="server" ID="btnActualizarAlumno" OnClick="btnActualizarAlumno_Click" />
</p>
<p>
    Buscar : <asp:TextBox runat="server" ID="txtBuscarAlumno" />
    <asp:Button Text="Buscar" runat="server" ID="btnBuscarAlumno" OnClick="btnBuscarAlumno_Click" />
</p>
<p>
    <asp:GridView runat="server" ID="gvAlumno"></asp:GridView>
</p></div>
  <div class="tab-pane fade" id="simple-tabpanel-1" role="tabpanel" aria-labelledby="simple-tab-1"><h3>Mantimiento de la tabla Docente</h3>
<p>
    CodDocen : <asp:TextBox runat="server" ID="txtCodDocente" />
</p>
<p>
    APaterno : <asp:TextBox runat="server" ID="txtAPaternoDocente" />
</p>
<p>
    AMaterno : <asp:TextBox runat="server" ID="txtAMaternoDocente" />
</p>
<p>
    Nombres : <asp:TextBox runat="server" ID="txtNombresDocente" />
</p>
<p>
    Usuario: <asp:TextBox runat="server" ID="txtUsuarioDocente" />
</p>   
<p>
    <asp:Button Text="Agregar" runat="server" ID="btnAgregarDocente" OnClick="btnAgregarDocente_Click"/>
    <asp:Button Text="Eliminar" runat="server" ID="btnEliminarDocente" OnClick="btnEliminarDocente_Click"/>
    <asp:Button Text="Actualizar" runat="server" ID="btnActualizarDocente" OnClick="btnActualizarDocente_Click"/>
</p>
<p>
    Buscar : <asp:TextBox runat="server" ID="txtBuscarDocente" />
    <asp:Button Text="Buscar" runat="server" ID="btnBuscarDocente" OnClick="btnBuscarDocente_Click"/>
</p>
<p>
    <asp:GridView runat="server" ID="gvDocente"></asp:GridView>
</p></div>
  <div class="tab-pane fade" id="simple-tabpanel-2" role="tabpanel" aria-labelledby="simple-tab-2"><h3>Mantimiento de la tabla Asignatura</h3>
<p>
    CodAsignatura : <asp:TextBox runat="server" ID="txtCodAsignatura" />
</p>
<p>
    Asignatura : <asp:TextBox runat="server" ID="txtNombreAsignatura" />
</p>
<p>
    CodRequisito : <asp:TextBox runat="server" ID="txtCodRequisito" />
</p>
<p>
    <asp:Button Text="Agregar" runat="server" ID="btnAgregarAsignatura" OnClick="btnAgregarAsignatura_Click"/>
    <asp:Button Text="Eliminar" runat="server" ID="btnEliminarAsignatura" OnClick="btnEliminarAsignatura_Click"/>
    <asp:Button Text="Actualizar" runat="server" ID="btnActualizarAsignatura" OnClick="btnActualizarAsignatura_Click"/>
</p>
<p>
    Buscar : <asp:TextBox runat="server" ID="txtBuscarAsignatura" />
    <asp:Button Text="Buscar" runat="server" ID="btnBuscarAsignatura" OnClick="btnBuscarAsignatura_Click"/>
</p>
<p>
    <asp:GridView runat="server" ID="gvAsignatura"></asp:GridView>
</p></div>
</div>
    <script type="text/javascript">
        document.addEventListener('DOMContentLoaded', function () {
            // Obtener el valor guardado del campo oculto
            var activeTabIndex = document.getElementById('<%= hdnActiveTabIndex.ClientID %>').value;

            // Si hay un valor, activar esa pestaña
            if (activeTabIndex) {
                setActiveTab(activeTabIndex);
            }

            // Al cambiar de pestaña, guardar el índice y cambiar las clases
            var tabLinks = document.querySelectorAll('.nav-tabs a');
            tabLinks.forEach(function (tab, index) {
                tab.addEventListener('click', function () {
                    document.getElementById('<%= hdnActiveTabIndex.ClientID %>').value = index;
                    setActiveTab(index); // Cambiar la pestaña activa
                });
            });
        });

        function setActiveTab(index) {
            // Eliminar 'active' y 'show' de todas las pestañas y contenido
            document.querySelectorAll('.nav-tabs a').forEach(function (tab) {
                tab.classList.remove('active');
            });
            document.querySelectorAll('.tab-pane').forEach(function (pane) {
                pane.classList.remove('active', 'show');
            });

            // Añadir 'active' y 'show' solo a la pestaña y contenido seleccionados
            document.querySelectorAll('.nav-tabs a')[index].classList.add('active');
            document.querySelectorAll('.tab-pane')[index].classList.add('active', 'show');
        }
    </script>
</asp:Content>

