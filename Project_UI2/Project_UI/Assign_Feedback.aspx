<%@ Page Title="" Language="C#" MasterPageFile="~/Navigation.Master" AutoEventWireup="true" CodeBehind="Assign_Feedback.aspx.cs" Inherits="Project_UI.Assign_Feedback" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
      <div class="container w-75 fs-3">
    <br />

          <%--Enter the Subject Code : <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>--%>
          <asp:DropDownList ID="DropDownList1" runat="server" OnSelectedIndexChanged="DropDownList1_SelectedIndexChanged"></asp:DropDownList>
          <asp:DropDownList ID="DropDownList2" runat="server" OnSelectedIndexChanged="DropDownList2_SelectedIndexChanged">
          </asp:DropDownList>
    <br />
    <br />

        <asp:Button ID="Button1" runat="server" Text="Assign to Students" CssClass="btn btn-dark btn-lg  mb-5 w-100" OnClick="Button1_Click"/>
    </div>
</asp:Content>
