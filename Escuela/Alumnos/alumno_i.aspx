<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="alumno_i.aspx.cs" Inherits="Escuela.Alumnos.alumno_i" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    
    <table>
        <tr>
            <td>Matricula: </td>
            <td>
                <asp:TextBox ID="txtMatricula" runat="server" MaxLength="8"></asp:TextBox>
                <asp:RequiredFieldValidator ID="rfv_matricula" runat="server" ControlToValidate="txtMatricula" Display="Dynamic"
                    ErrorMessage="La matrícula es requerida" ValidationGroup="vlg1"></asp:RequiredFieldValidator>
                <asp:RegularExpressionValidator ID="rev_matricula" runat="server" ControlToValidate="txtMatricula" Display="Dynamic"
                    ValidationExpression="^[0-9]+$" ValidationGroup="vlg1"
                    ErrorMessage="Sólo se aceptan números enteros"></asp:RegularExpressionValidator>

            </td>
        </tr>
         <tr>
            <td>Nombre: </td>
            <td>
                <asp:TextBox ID="txtNombre" MaxLength="100" runat="server"></asp:TextBox>
                <asp:RequiredFieldValidator ID="rfv_nombre" runat="server" ControlToValidate="txtNombre" Display="Dynamic"
                    ErrorMessage="El nombre es requerido" ValidationGroup="vlg1"></asp:RequiredFieldValidator>
            </td>
        </tr>
         <tr>
            <td>Fecha de Nacimiento: </td>
            <td>
                <asp:TextBox ID="txtFechaNacimiento" runat="server"></asp:TextBox>
                <asp:RequiredFieldValidator ID="rfv_fecha" runat="server" ControlToValidate="txtFechaNacimiento" Display="Dynamic"
                    ErrorMessage="La fecha es requerida" ValidationGroup="vlg1"></asp:RequiredFieldValidator>
                <asp:CompareValidator ID="cv_fecha" runat="server" ErrorMessage="El formato es incorrecto(dd/mm/yyyy) o (mm/dd/yyyy)"
                    Type="Date" Operator="DataTypeCheck" ValidationGroup="vlg1" Display="Dynamic"
                    ControlToValidate="txtFechaNacimiento"></asp:CompareValidator>
            </td>
        </tr>
         <tr>
            <td>Semestre: </td>
            <td>
                <asp:TextBox ID="txtSemestre" runat="server"></asp:TextBox>
                <asp:RequiredFieldValidator ID="rfv_semestre" runat="server" ControlToValidate="txtSemestre" Display="Dynamic"
                    ErrorMessage="El semestre es requerido" ValidationGroup="vlg1"></asp:RequiredFieldValidator>
                <asp:RangeValidator ID="rv_semestre" runat="server" Display="Dynamic"
                    ControlToValidate="txtSemestre" Type="Integer" MinimumValue="1" MaximumValue="12" ValidationGroup="vlg1"
                    ErrorMessage="El semestre debe ser un valor entero entre 1 y 12"></asp:RangeValidator>
            </td>
        </tr>
         <tr>
            <td>Facultad: </td>
            <td>
                <asp:DropDownList ID="ddlFacultad" runat="server"></asp:DropDownList>
                <asp:RequiredFieldValidator ID="rfv_facultad" runat="server" ControlToValidate="ddlFacultad"
                    ErrorMessage="La facultad es requerida" ValidationGroup="vlg1" InitialValue="0" Display="Dynamic"></asp:RequiredFieldValidator>

            </td>
        </tr>
         <tr>
            <td></td>
            <td>
                <asp:Button ID="btnAgregar" runat="server" Text="Agregar" OnClick="btnAgregar_Click" ValidationGroup="vlg1"/>
            </td>
        </tr>
    </table>

    <asp:GridView ID="grd_alumnos" runat="server" AutoGenerateColumns="false">
        <Columns>
            <asp:BoundField HeaderText="Matricula" DataField="matricula" />
            <asp:BoundField HeaderText="nombre" DataField="nombre" />
        </Columns>

    </asp:GridView>

</asp:Content>
