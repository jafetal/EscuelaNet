<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="facultad_s.aspx.cs" Inherits="Escuela.Facultades.facultad_s" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <asp:GridView ID="grd_facultades" runat="server" AutoGenerateColumns="false" OnRowCommand="grd_facultades_RowCommand">
        <Columns>
            <asp:TemplateField>
                <ItemTemplate>
                    <asp:ImageButton ID="btnEditar" runat="server" ImageUrl="~/Imagenes/editar.png" Height="20px" Width="20px"
                        CommandName="Editar" CommandArgument='<%# Eval("ID_Facultad") %>'/>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField>
                <ItemTemplate>
                    <asp:ImageButton ID="btnEliminar" runat="server" ImageUrl="~/Imagenes/eliminar.png" Height="20px" Width="20px"
                        CommandName="Eliminar" CommandArgument='<%# Eval("ID_Facultad") %>'/>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:BoundField HeaderText="Id facultad" DataField="ID_Facultad" />
            <asp:BoundField HeaderText="Código" DataField="codigo" />
            <asp:BoundField HeaderText="Nombre" DataField="nombre" />
            <asp:BoundField HeaderText="Fecha de Creacion" DataField="fechaCreacion" DataFormatString="{0:dd/MM/yyyy}"/>
            <asp:BoundField HeaderText="Universidad" DataField="nombreUniversidad" />
            <asp:BoundField HeaderText="Ciudad" DataField="nombreCiudad" />

        </Columns>
    </asp:GridView>

    <script type="text/javascript">

        $(document).ready(function () {
            $.ajax({
                type: "GET",
                url: '<%= ResolveUrl("~/ServicioWCFacultades.svc/ConsultaFacultadesJSON") %>',
                success: function (data) {
                    console.log("Llamada de ajax exitosa!");
                    console.log(data);
                },
                error: function (e) {
                    console.log("Llamada incorrecta o con error!");
                    console.log(e);
                }
            });
        });

    </script>

</asp:Content>
