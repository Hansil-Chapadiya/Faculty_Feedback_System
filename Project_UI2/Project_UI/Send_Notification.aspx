<%@ Page Title="" Language="C#" MasterPageFile="~/Navigation.Master" AutoEventWireup="true" CodeBehind="Send_Notification.aspx.cs" Inherits="Project_UI.Send_Notification" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
     <div class="container text-center w-25 m-auto" runat="server">
        <div class="row align-items-center m-3 mt-5">
            <div class="col mt-5">
                <h1>Choose Details for Assign Feedback</h1>
                <p class="lead">The purpose of feedback in the assessment and learning process is to improve a student's performance - not put a damper on it. It is essential that the process of providing feedback is a positive, or at least a neutral, learning experience for the student.</p>
                <div class="d-flex justify-content-center m-2">
                    <div>
                        <div class="d-flex align-items-center btn-group m-2 dropdown">
                            <asp:DropDownList ID="DropDownList1" runat="server" class="btn btn-secondary dropdown-toggle lin" AutoPostBack="True">
                                <asp:ListItem Value="1">SEM-1</asp:ListItem>
                                <asp:ListItem Value="2">SEM-2</asp:ListItem>
                                <asp:ListItem Value="3">SEM-3</asp:ListItem>
                                <asp:ListItem Value="4">SEM-4</asp:ListItem>
                                <asp:ListItem Value="5">SEM-5</asp:ListItem>
                                <asp:ListItem Value="6">SEM-6</asp:ListItem>
                            </asp:DropDownList>
                        </div>
                    </div>
                    <div>
                        <div class="btn-group m-2">
                            <asp:DropDownList ID="DropDownList2" runat="server" class="btn btn-secondary dropdown-toggle lin "></asp:DropDownList>
                        </div>
                    </div>
                    <div>
                        <div class="btn-group m-2">
                            <asp:DropDownList ID="DropDownList3" runat="server" class="btn btn-secondary dropdown-toggle lin "></asp:DropDownList>
                        </div>
                    </div>
                </div>
            </div>
        </div>
        <p class="lead">
            <asp:Button ID="Button1" runat="server" CssClass="btn btn-lg btn-outline-light lin" Text="Submit" OnClick="Button1_Click" />
        </p>
    </div>
</asp:Content>
