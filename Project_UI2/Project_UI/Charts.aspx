<%@ Page Title="" Language="C#" MasterPageFile="~/Navigation.Master" AutoEventWireup="true" CodeBehind="Charts.aspx.cs" Inherits="Project_UI.Charts" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container">
        <asp:ScriptManager ID="ScriptManager1" runat="server">
        </asp:ScriptManager>
                    <h1>Choose Subject Code</h1>
        <div class="btn-group m-2">
            <asp:DropDownList ID="Subject" runat="server" AutoPostBack="True" CssClass="btn btn-secondary dropdown-toggle lin" required="true">
            </asp:DropDownList>
        </div>
        <br />
        <asp:Button ID="show" runat="server" Text="View Performance" CssClass="btn btn-link btn-lg" OnClick="show_Click"/>
        <br />
        <br />
        <ajaxToolkit:BarChart ID="BarChart1" runat="server" ChartHeight="600" ChartWidth="600"/>
    </div>
</asp:Content>
