<%@ Page Title="" Language="C#" MasterPageFile="~/PaginaPrincipal.Master" AutoEventWireup="true" CodeBehind="index.aspx.cs" Inherits="ToDoList.WebForm1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    
    
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:GridView ID="grdTarefas" runat="server" AutoGenerateColumns="false" class="table table-striped">
        <Columns>
            <asp:TemplateField HeaderText="SELECT">
                <ItemTemplate>
                    <asp:CheckBox ID="chkDel" runat="server" class="form-check-input" />
                </ItemTemplate>
            </asp:TemplateField>
            <asp:BoundField DataField="ID" HeaderText="ID" />
            <asp:BoundField DataField="TAREFA" HeaderText="TAREFA" />  
        </Columns>
    </asp:GridView>
    <br />
    <asp:Button ID="btnDeletar" runat="server" OnClick="Button_Deletar" Text="DELETAR" class="btn btn-dark"/>
    <br />

    <br />
    <asp:Label ID="lblAlterTarefa" runat="server" class="form-check-label">Altera Tarefa</asp:Label>
    <br />

    <br />
    <asp:TextBox ID="txtAlterTarefa" runat="server"></asp:TextBox>
    <br />

    <br />
    <asp:Button ID="btnUpdate" runat="server" Text="EDITAR" OnClick="Button_Editar" class="btn btn-dark" />
    <br />
    
    <p id="alerta" style="display: none;">Tarefa Realizada</p>

    <script>
         $(document).ready(function () {
             console.log("jQuery is ready!");
             $("#<%= btnDeletar.ClientID %>").click(function () {
                 alert("Texto: " + $("#alerta").text());
             });
         });
    </script>
</asp:Content>
