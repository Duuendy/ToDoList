<%@ Page Title="" Language="C#" MasterPageFile="~/PaginaPrincipal.Master" AutoEventWireup="true" CodeBehind="index.aspx.cs" Inherits="ToDoList.WebForm1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:GridView ID="grdTarefas" runat="server" AutoGenerateColumns="false">
        <Columns>
            <asp:TemplateField HeaderText="Select">
                <ItemTemplate>
                    <asp:CheckBox ID="chkDel" runat="server"  />
                </ItemTemplate>
            </asp:TemplateField>
            <asp:BoundField DataField="id" HeaderText="ID" />
            <asp:BoundField DataField="tarefa" HeaderText="TAREFA" />
            <%--<asp:TemplateField HeaderText="FINALIZADO">--%>
                <%--<ItemTemplate>
                    <asp:hiddenfield runat="server" id="TarefaHiddenField" Value='<%# Eval("id") %>' />
                    <asp:CheckBox runat="server" DataField="finalizado"
                        Checked='<%# Convert.ToBoolean(Eval("finalizado")) %>' AutoPostBack="true"
                        OnCheckedChanged="Finalizado_CheckedChanged"
                        />
                </ItemTemplate>   --%>
            <%--</asp:TemplateField>--%>   
        </Columns>
    </asp:GridView>
    <br />
    <asp:Button ID="btnDeletar" runat="server" OnClick="Button_Deletar" Text="DELETAR" />
    <br />

    <br />
    <asp:Label ID="lblAlterTarefa" runat="server">Altera Tarefa</asp:Label>
    <br />
    <asp:TextBox ID="txtAlterTarefa" runat="server"></asp:TextBox>
    <br />
    <asp:Button ID="btnUpdate" runat="server" Text="Update" OnClick="Button_Editar" />
    
</asp:Content>
