<%@ Page Title="" Language="C#" MasterPageFile="~/Navigation.Master" AutoEventWireup="true" CodeBehind="HOD_Faculty_Function.aspx.cs" Inherits="Project_UI.HOD_Faculty_Function" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container text-center d-flex justify-content-center mt-5">
            <div class="row m-5 d-flex justify-content-center">
                <div class="d-flex justify-content-center col m-4">
                    <div class="card" style="width: 18rem;">
                        <asp:ImageButton ID="HODRoleImg" runat="server" ImageUrl="~/Images/Add_Faculty.jpg" CssClass="card-img-top" PostBackUrl="~/Create_New_Faculty.aspx" />
                        <div class="card-body">
                            <h5 class="card-title">New Faculty</h5>
                            <p class="card-text">Some quick example text to build on the card title and make up the bulk of the card's content.</p>
                            <a href="Create_New_Faculty.aspx"" class="btn btn-lg btn-outline-light lin">Add</a>
                        </div>
                    </div>
                </div>
                <div class="d-flex justify-content-center col m-4">
                    <div class="card" style="width: 18rem;">
                        <asp:ImageButton ID="FacultyRoleImg" runat="server" ImageUrl="~/Images/Remove_Faculty.jpg" CssClass="card-img-top" PostBackUrl="~/Remove_Faculty.aspx" />
                        <div class="card-body">
                            <h5 class="card-title">Remove Faculty</h5>
                            <p class="card-text">Some quick example text to build on the card title and make up the bulk of the card's content.</p>
                            <a href="Remove_Faculty.aspx" class="btn btn-lg btn-outline-light lin">Remove</a>
                        </div>
                    </div>
                </div>
                <div class="d-flex justify-content-center col m-4">
                    <div class="card" style="width: 18rem;">
                        <asp:ImageButton ID="StudentRoleImg" runat="server" ImageUrl="~/Images/Edit_Faculty.jpg" CssClass="card-img-top" PostBackUrl="~/Edit_Faculty.aspx" />
                        <div class="card-body">
                            <h5 class="card-title">Edit Faculty</h5>
                            <p class="card-text">Some quick example text to build on the card title and make up the bulk of the card's content.</p>
                            <a href="Edit_Faculty.aspx" class="btn btn-lg btn-outline-light lin">Edit</a>
                        </div>
                    </div>
                </div>
            </div>
        </div>
</asp:Content>
