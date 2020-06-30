<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="facultad_u.aspx.cs" Inherits="Escuela.Facultades.facultad_u" %>
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
                <asp:TextBox ID="txtcodigo" runat="server"></asp:TextBox>
                <asp:RequiredFieldValidator ID="rfv_codigo" runat="server" ControlToValidate="txtcodigo" Display="Dynamic"
                    ErrorMessage="El codigo es requerido" ValidationGroup="vlg1"></asp:RequiredFieldValidator>
                <asp:RegularExpressionValidator ID="rev_matricula" runat="server" ControlToValidate="txtcodigo" Display="Dynamic"
                    ValidationExpression="[A-Z][A-Z][A-Z][A-Z][0-9][0-9]" ValidationGroup="vlg1"
                    ErrorMessage="Debe tener la forma AAAA##"></asp:RegularExpressionValidator>
            </td>
        </tr>
         <tr>
            <td>Nombre: </td>
            <td>
                <asp:TextBox ID="txtNombre" runat="server"></asp:TextBox>
                <asp:RequiredFieldValidator ID="rfv_nombre" runat="server" ControlToValidate="txtNombre" Display="Dynamic"
                    ErrorMessage="El nombre es requerido" ValidationGroup="vlg1"></asp:RequiredFieldValidator>
            </td>
        </tr>
         <tr>
            <td>Fecha de Creación: </td>
            <td>
                <asp:TextBox ID="txtFecha" runat="server"></asp:TextBox>
                <asp:RequiredFieldValidator ID="rfv_fecha" runat="server" ControlToValidate="txtFecha" Display="Dynamic"
                    ErrorMessage="La fecha es requerida" ValidationGroup="vlg1"></asp:RequiredFieldValidator>
                <asp:CompareValidator ID="cv_fecha" runat="server" ErrorMessage="El formato es incorrecto(dd/mm/yyyy) o (mm/dd/yyyy)"
                    Type="Date" Operator="DataTypeCheck" ValidationGroup="vlg1" Display="Dynamic"
                    ControlToValidate="txtFecha"></asp:CompareValidator>
            </td>
        </tr>
         <tr>
            <td style="height: 25px">Universidad: </td>
            <td style="height: 25px">
                <asp:DropDownList ID="ddlUniversidad" runat="server"></asp:DropDownList>
                <asp:RequiredFieldValidator ID="rfv_universidad" runat="server" ControlToValidate="ddlUniversidad"
                    ErrorMessage="La Universidad es requerida" ValidationGroup="vlg1" InitialValue="0" Display="Dynamic"></asp:RequiredFieldValidator>
            </td>
        </tr>

        <tr>
            <td>Estado:</td>
            <td>
                <asp:DropDownList ID="ddlEstados" runat="server" AutoPostBack="true" OnSelectedIndexChanged="ddlEstados_SelectedIndexChanged"></asp:DropDownList></td>
        </tr>
        <tr>
            <td>Ciudad:</td>
            <td>
                <asp:DropDownList ID="ddlCiudad" runat="server"></asp:DropDownList></td>
        </tr>
         <tr>
            <td></td>
            <td>
                <asp:Button ID="btnEditar" runat="server" Text="Editar" OnClick="btnEditar_Click" ValidationGroup="vlg1"/>
            </td>
        </tr>
    </table>

</asp:Content>
