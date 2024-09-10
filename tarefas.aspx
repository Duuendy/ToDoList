<%@ Page Title="" Language="C#" MasterPageFile="~/PaginaPrincipal.Master" AutoEventWireup="true" CodeBehind="tarefas.aspx.cs" Inherits="ToDoList.tarefas" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:Label ID="Label2" runat="server" Text="NOVA TAREFA" Font-Bold="True" Font-Size="X-Large"></asp:Label>
    <br />
<br />
    <asp:Label ID="LabelTarefa" runat="server" Font-Bold="True" Text="Tarefa"></asp:Label>
    <br />
    <asp:TextBox ID="textBoxTarefa" runat="server" Width="131px"></asp:TextBox>
    <br />
    <br />
    <asp:Button ID="btnInserir" runat="server" OnClick="Button_Cadastrar" Text="Cadastrar" />
    <br />
<br />
<asp:Label ID="Label1" runat="server" Text="LISTA DE TAREFAS" Font-Bold="True" Font-Size="X-Large"></asp:Label>
    <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="True">
    </asp:GridView>
    <asp:SqlDataSource ID="SqlDataSource1" runat="server"></asp:SqlDataSource>
<br />
<br />
<br />
<asp:Label ID="LabelMensage" runat="server" Font-Bold="True" Font-Size="Larger"></asp:Label>
</asp:Content>
