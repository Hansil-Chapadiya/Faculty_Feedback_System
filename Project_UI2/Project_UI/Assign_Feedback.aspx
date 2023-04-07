<%@ Page Title="" Language="C#" MasterPageFile="~/Navigation.Master" AutoEventWireup="true" CodeBehind="Assign_Feedback.aspx.cs" Inherits="Project_UI.Assign_Feedback" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
       <div class="row mt-3 m-0">
        <div class="col m-0 col-lg-6 col-sm-12">
            <div class="row g-0 border rounded overflow-hidden flex-md-row mb-4 shadow-sm h-md-250 position-relative">
                <div class="col p-4 d-flex flex-column position-static">
                    <strong class="d-inline-block mb-2 text-primary">Feedback form</strong>
                    <h3 class="mb-0">Create Feedback</h3>
                    <p class="card-text mb-auto">In this section Faulty can create feedback form for students.</p>
                    <asp:Button ID="Button1" runat="server" Text="Go" CssClass="btn btn-outline-light lin stretched-link" OnClick="Button1_Click" />
                </div>
                <div class="col-auto d-none d-lg-block">
                    <asp:Image ID="Image1" ImageUrl="~/Images/Fac2.png" class="bd-placeholder-img" Width="200" Height="250" runat="server" />
                </div>
            </div>
        </div>
</asp:Content>
