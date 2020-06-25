<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="facultad_d.aspx.cs" Inherits="Escuela.Facultades.facultad_d" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <table>
        <tr>
            <td>ID Facultad: </td>
            <td>
                <asp:Label ID="lblId" runat="server" Text=""></asp:Label>
            </td>
        </tr>
         <tr>
            <td>Código: </td>
            <td>
                <asp:Label ID="lblcodigo" runat="server"></asp:Label>
            </td>
        </tr>
         <tr>
            <td>Nombre: </td>
            <td>
                <asp:Label ID="lblNombre" runat="server"></asp:Label>
            </td>
        </tr>
         <tr>
            <td>Fecha de Creación: </td>
            <td>
                <asp:Label ID="lblFecha" runat="server"></asp:Label>
            </td>
        </tr>
         <tr>
            <td>Universidad: </td>
            <td>
                <asp:DropDownList ID="ddlUniversidad" runat="server" Enabled="false"></asp:DropDownList>
            </td>
        </tr>
         <tr>
            <td></td>
            <td>
                <asp:Button ID="btnEliminar" runat="server" Text="Eliminar" OnClick="btnEliminar_Click" />
            </td>
        </tr>
    </table>

</asp:Content>
