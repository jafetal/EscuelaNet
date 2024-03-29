﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="facultad_i.aspx.cs" Inherits="Escuela.Facultades.facultad_i" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <table>
                 <tr>
                    <td>Código: </td>
                    <td>
                        <asp:TextBox ID="txtcodigo" runat="server"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="rfv_codigo" runat="server" ControlToValidate="txtcodigo" Display="Dynamic"
                            ErrorMessage="El codigo es requerido" ValidationGroup="vlg2"></asp:RequiredFieldValidator>
                        <asp:RegularExpressionValidator ID="rev_matricula" runat="server" ControlToValidate="txtcodigo" Display="Dynamic"
                            ValidationExpression="[A-Z][A-Z][A-Z][A-Z][0-9][0-9]" ValidationGroup="vlg2"
                            ErrorMessage="Debe tener la forma AAAA##"></asp:RegularExpressionValidator>
                    </td>
                </tr>
                 <tr>
                    <td>Nombre: </td>
                    <td>
                        <asp:TextBox ID="txtNombre" runat="server"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="rfv_nombre" runat="server" ControlToValidate="txtNombre" Display="Dynamic"
                            ErrorMessage="El nombre es requerido" ValidationGroup="vlg2"></asp:RequiredFieldValidator>
                    </td>
                </tr>
                 <tr>

                    <td>Fecha de Creación: </td>
                    <td>
                        <asp:TextBox ID="txtFecha" runat="server"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="rfv_fecha" runat="server" ControlToValidate="txtFecha" Display="Dynamic"
                            ErrorMessage="La fecha es requerida" ValidationGroup="vlg2"></asp:RequiredFieldValidator>
                        <asp:CompareValidator ID="cv_fecha" runat="server" ErrorMessage="El formato es incorrecto(dd/mm/yyyy) o (mm/dd/yyyy)"
                            Type="Date" Operator="DataTypeCheck" ValidationGroup="vlg2" Display="Dynamic"
                            ControlToValidate="txtFecha"></asp:CompareValidator>
                    </td>
                </tr>
                 <tr>
                    <td>Universidad: </td>
                    <td>
                        <asp:DropDownList ID="ddlUniversidad" CssClass="lista" runat="server"></asp:DropDownList>
                        <asp:RequiredFieldValidator ID="rfv_universidad" runat="server" ControlToValidate="ddlUniversidad"
                            ErrorMessage="La Universidad es requerida" ValidationGroup="vlg2" InitialValue="0" Display="Dynamic"></asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr>
                    <td>Estado:</td>
                    <td>
                        <asp:DropDownList ID="ddlEstados" CssClass="lista" runat="server" AutoPostBack="true" OnSelectedIndexChanged="ddlEstados_SelectedIndexChanged"></asp:DropDownList></td>
                </tr>
                <tr>
                    <td>Ciudad:</td>
                    <td>
                        <asp:DropDownList ID="ddlCiudad" CssClass="lista" runat="server"></asp:DropDownList></td>
                </tr>
                <tr>
                    <td>Materias:</td>
                    <td>
                        <asp:ListBox ID="listBoxMaterias" SelectionMode="Multiple" cssClass="lista" Width="150px" runat="server"></asp:ListBox>
                    </td>
                </tr>
                 <tr>
                    <td></td>
                    <td>
                        <asp:Button ID="btnAgregar" runat="server" Text="Agregar" OnClick="btnAgregar_Click" ValidationGroup="vlg2" style="height: 26px"/>
                    </td>
                </tr>
            </table>
        </ContentTemplate>
    </asp:UpdatePanel>

    <asp:GridView ID="grd_alumnos" runat="server" AutoGenerateColumns="false">
        <Columns>
            <asp:BoundField HeaderText="Código" DataField="codigo" />
            <asp:BoundField HeaderText="nombre" DataField="nombre" />
        </Columns>

    </asp:GridView>

    <script type="text/javascript">
        $(document).ready(function () {
            $("#MainContent_txtFecha").datepicker({
                changeMonth: true,
                changeYear: true,
                yerarRange: "1969:2008",
                dateFormat: "dd-mm-yy"
            });
            //$(".lista").chosen();
        });
        var manager = Sys.WebForms.PageRequestManager.getInstance();
        manager.add_endRequest(function () {
            $("#MainContent_txtFecha").datepicker({
                changeMonth: true,
                changeYear: true,
                yerarRange: "1969:2008",
                dateFormat: "dd-mm-yy"
            });
            //$(".lista").chosen();
        });
    </script>
</asp:Content>
