<%@ Page Title="" Language="C#" MasterPageFile="~/Navigation.Master" AutoEventWireup="true" CodeBehind="HomePageFinal.aspx.cs" Inherits="Project_UI.HomePageFinal" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
        <div class="container text-center mt-5">
            <div class="row">
                <div class="col-12 d-flex justify-content-center align-items-center">
                    <h2>FACULTY FEEDBACK SYSYTEM</h2>
                </div>
            </div>
        </div>

        <div class="container text-center d-flex justify-content-center mt-2">
            <div class="row m-5 d-flex justify-content-center">
                <div class="d-flex justify-content-center col m-4">
                    <div class="card" style="width: 18rem;">
                        <asp:ImageButton ID="HODRoleImg" runat="server" ImageUrl="~/Images/HOD.png" CssClass="card-img-top" />
                        <div class="card-body">
                            <h5 class="card-title">HOD Space</h5>
                            <p class="card-text">Some quick example text to build on the card title and make up the bulk of the card's content.</p>
                            <a href="Create_New_HOD.aspx" class="btn btn-lg btn-outline-light lin">New Account</a>
                        </div>
                    </div>
                </div>
                <div class="d-flex justify-content-center col m-4">
                    <div class="card" style="width: 18rem;">
                        <asp:ImageButton ID="FacultyRoleImg" runat="server" ImageUrl="~/Images/Fac2.png" CssClass="card-img-top" />
                        <div class="card-body">
                            <h5 class="card-title">Faculty Space</h5>
                            <p class="card-text">Some quick example text to build on the card title and make up the bulk of the card's content.</p>
                            <a href="login1.aspx" class="btn btn-lg btn-outline-light lin">Login</a>
                        </div>
                    </div>
                </div>
                <div class="d-flex justify-content-center col m-4">
                    <div class="card" style="width: 18rem;">
                        <asp:ImageButton ID="StudentRoleImg" runat="server" ImageUrl="~/Images/student.png" CssClass="card-img-top" />
                        <div class="card-body">
                            <h5 class="card-title">Students Space</h5>
                            <p class="card-text">Some quick example text to build on the card title and make up the bulk of the card's content.</p>
                            <a href="login1.aspx" class="btn btn-lg btn-outline-light lin">Login</a>
                        </div>
                    </div>
                </div>
            </div>
        </div>
        <div class="container d-flex justify-content-center">
            <a href="login1.aspx" class="btn btn-lg btn-outline-light lin">Already have an HOD account?</a>
        </div>
</asp:Content>
