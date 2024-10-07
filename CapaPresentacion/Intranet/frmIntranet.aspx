<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="frmIntranet.aspx.cs" Inherits="CapaPresentacion.Intranet.frmIntranet" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
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
  <div class="tab-pane active" id="simple-tabpanel-0" role="tabpanel" aria-labelledby="simple-tab-0"><h3>Mantimiento de la tabla Alumno</h3>
<p>
    CodAlumno : <asp:TextBox runat="server" ID="txtCodAlumno" />
</p>
<p>
    APaterno : <asp:TextBox runat="server" ID="txtAPaterno" />
</p>
<p>
    AMaterno : <asp:TextBox runat="server" ID="txtAMaterno" />
</p>
<p>
    Nombres : <asp:TextBox runat="server" ID="txtNombres" />
</p>
<p>
    Usuario : <asp:TextBox runat="server" ID="txtUsuario" />
</p>
<p>
    CodCarera: <asp:TextBox runat="server" ID="txtCodCarrera" />
</p>
<p>
    <asp:Button Text="Agregar" runat="server" ID="btnAgregar" />
    <asp:Button Text="Eliminar" runat="server" ID="btnEliminar" />
    <asp:Button Text="Actualizar" runat="server" ID="btnActualizar" />
</p>
<p>
    Buscar : <asp:TextBox runat="server" ID="txtBuscar" />
    <asp:Button Text="Buscar" runat="server" ID="btnBuscar" />
</p>
<p>
    <asp:GridView runat="server" ID="gvAlumno"></asp:GridView>
</p></div>
  <div class="tab-pane" id="simple-tabpanel-1" role="tabpanel" aria-labelledby="simple-tab-1"><h3>Mantimiento de la tabla Docente</h3>
<p>
    CodDocente : <asp:TextBox runat="server" ID="txtCodDocente" />
</p>
<p>
    APaterno : <asp:TextBox runat="server" ID="TextBox1" />
</p>
<p>
    AMaterno : <asp:TextBox runat="server" ID="TextBox2" />
</p>
<p>
    Nombres : <asp:TextBox runat="server" ID="txtNombresDocen" />
</p>
<p>
    Usuario: <asp:TextBox runat="server" ID="TextBox3" />
</p>   
<p>
    <asp:Button Text="Agregar" runat="server" ID="Button1" />
    <asp:Button Text="Eliminar" runat="server" ID="Button2" />
    <asp:Button Text="Actualizar" runat="server" ID="Button3" />
</p>
<p>
    Buscar : <asp:TextBox runat="server" ID="TextBox4" />
    <asp:Button Text="Buscar" runat="server" ID="Button4" />
</p>
<p>
    <asp:GridView runat="server" ID="gvDocente"></asp:GridView>
</p></div>
  <div class="tab-pane" id="simple-tabpanel-2" role="tabpanel" aria-labelledby="simple-tab-2"><h3>Mantimiento de la tabla Asignatura</h3>
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
    <asp:Button Text="Agregar" runat="server" ID="Button5" />
    <asp:Button Text="Eliminar" runat="server" ID="Button6" />
    <asp:Button Text="Actualizar" runat="server" ID="Button7" />
</p>
<p>
    Buscar : <asp:TextBox runat="server" ID="TextBox5" />
    <asp:Button Text="Buscar" runat="server" ID="Button8"  />
</p>
<p>
    <asp:GridView runat="server" ID="gvAsignatura"></asp:GridView>
</p></div>
</div>
</asp:Content>
