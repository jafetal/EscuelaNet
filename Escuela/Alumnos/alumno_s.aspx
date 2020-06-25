<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="alumno_s.aspx.cs" Inherits="Escuela.Alumnos.alumno_s" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <asp:GridView ID="grd_alumnos" runat="server" AutoGenerateColumns="false" OnRowCommand="grd_alumnos_RowCommand">
        <Columns>
            <asp:TemplateField>
                <ItemTemplate>
                    <asp:ImageButton ID="btnEditar" runat="server" ImageUrl="~/Imagenes/editar.png" Height="20px" Width="20px"
                        CommandName="Editar" CommandArgument='<%# Eval("matricula") %>'/>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField>
                <ItemTemplate>
                    <asp:ImageButton ID="btnEliminar" runat="server" ImageUrl="~/Imagenes/eliminar.png" Height="20px" Width="20px"
                        CommandName="Eliminar" CommandArgument='<%# Eval("matricula") %>'/>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:BoundField HeaderText="Matrícula" DataField="matricula" />
            <asp:BoundField HeaderText="Nombre" DataField="nombre" />
            <asp:BoundField HeaderText="Fecha de Nacimiento" DataField="fechaNacimiento" DataFormatString="{0:dd/MM/yyyy}"/>
            <asp:BoundField HeaderText="Semestre" DataField="semestre" />
            <asp:BoundField HeaderText="Facultad" DataField="nombreFacultad" />
        </Columns>
    </asp:GridView>

</asp:Content>
