<%@ Page Title="" Language="C#" MasterPageFile="~/Navigation.Master" AutoEventWireup="true" CodeBehind="HOD_HomePage.aspx.cs" Inherits="Project_UI.HOD_FacultyStudent" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div id="myCarousel" class="carousel slide" data-bs-ride="carousel">
        <div class="carousel-indicators">
            <button type="button" data-bs-target="#myCarousel" data-bs-slide-to="0" class="" aria-label="Slide 1"></button>
            <button type="button" data-bs-target="#myCarousel" data-bs-slide-to="1" aria-label="Slide 2" class="active" aria-current="true"></button>
            <button type="button" data-bs-target="#myCarousel" data-bs-slide-to="2" aria-label="Slide 3" class=""></button>
        </div>
        <div class="carousel-inner">
            <div class="carousel-item active carousel-item-start">
                <svg class="bd-placeholder-img" width="100%" height="100%" xmlns="http://www.w3.org/2000/svg" aria-hidden="true" preserveAspectRatio="xMidYMid slice" focusable="false">
                    <asp:Image ID="Image4" Width="100%" Height="100%" ImageUrl="~/Images/Details.jpg" runat="server" CssClass="opacity-75" />
                </svg>
                <div class="container">
                    <div class="carousel-caption text-end">
                        <h1 class="text-dark-emphasis">Details of Feedback</h1>
                        <p class="text-danger-emphasis"><b>Textual Representation of Details of Feedback Given by Students.</b></p>
                        <p><a class="btn btn-lg btn-outline-light lin" href="#">Watch Details</a></p>
                    </div>
                </div>
            </div>
            <div class="carousel-item carousel-item-next carousel-item-start">
                <svg class="bd-placeholder-img" width="100%" height="100%" xmlns="http://www.w3.org/2000/svg" aria-hidden="true" preserveAspectRatio="xMidYMid slice" focusable="false">
                    <asp:Image ID="Image5" Width="100%" Height="100%" ImageUrl="~/Images/SubjectEdit.jpeg" runat="server" CssClass="opacity-75" />
                </svg>
                <div class="container">
                    <div class="carousel-caption">
                        <h1 class="text-dark-emphasis">Want to Edit Subjects</h1>
                        <p class="text-danger-emphasis"><b>Can Direct Edit Faculty Without Further Process.</b></p>
                        <p><a class="btn btn-lg btn-outline-light lin" href="#">Edit</a></p>
                    </div>
                </div>
            </div>
            <div class="carousel-item">
                <svg class="bd-placeholder-img" width="100%" height="100%" xmlns="http://www.w3.org/2000/svg" aria-hidden="true" preserveAspectRatio="xMidYMid slice" focusable="false">
                    <asp:Image ID="Image6" Width="100%" Height="100%" ImageUrl="~/Images/Chart.jpeg" runat="server" CssClass="opacity-75" />
                </svg>
                <div class="container">
                    <div class="carousel-caption text-start">
                        <h1 class="text-body-emphasis">Report</h1>
                        <p class="text-danger"><b>Looking for graphical Representation of Performance of Faculty.</b></p>
                        <p><a class="btn btn-lg btn-outline-light lin" href="#">Watch Chart</a></p>
                    </div>
                </div>
            </div>
        </div>
        <button class="carousel-control-prev" type="button" data-bs-target="#myCarousel" data-bs-slide="prev">
            <span class="carousel-control-prev-icon" aria-hidden="true"></span>
            <span class="visually-hidden">Previous</span>
        </button>
        <button class="carousel-control-next" type="button" data-bs-target="#myCarousel" data-bs-slide="next">
            <span class="carousel-control-next-icon" aria-hidden="true"></span>
            <span class="visually-hidden">Next</span>
        </button>
    </div>

    <div class="row mt-3 m-0">
        <div class="col m-0 col-lg-4 col-sm-12">
            <div class="row g-0 border rounded overflow-hidden flex-md-row mb-4 shadow-sm h-md-250 position-relative">
                <div class="col p-4 d-flex flex-column position-static">
                    <strong class="d-inline-block mb-2 text-primary">Faculty</strong>
                    <h3 class="mb-0">Manipulate Faculty</h3>
                    <p class="card-text mb-auto">In this Head of Department can manipulate their faculty.</p>
                    <asp:Button ID="Button1" runat="server" Text="Go" CssClass="btn btn-outline-light lin stretched-link" PostBackUrl="~/HOD_Faculty_Function.aspx" />
                </div>
                <div class="col-auto d-none d-lg-block">
                    <asp:Image ID="Image1" ImageUrl="~/Images/Fac2.png" class="bd-placeholder-img" Width="200" Height="250" runat="server" />
                </div>
            </div>
        </div>
        <div class="col m-0 col-lg-4 col-sm-12">
            <div class="row g-0 border rounded overflow-hidden flex-md-row mb-4 shadow-sm h-md-250 position-relative">
                <div class="col p-4 d-flex flex-column position-static">
                    <strong class="d-inline-block mb-2 text-danger">Students</strong>
                    <h3 class="mb-0">Manipulate Students</h3>
                    <p class="card-text mb-auto">In this Head of Department can manipulate thier students.</p>
                    <asp:Button ID="Button2" runat="server" Text="Go" CssClass="btn btn-outline-light lin stretched-link" PostBackUrl="~/HOD_Student_Function.aspx" />
                </div>
                <div class="col-auto d-none d-lg-block">
                    <asp:Image ID="Image2" ImageUrl="~/Images/student.png" class="bd-placeholder-img" Width="200" Height="250" runat="server" />
                </div>
            </div>
        </div>
        <div class="col m-0 col-lg-4 col-sm-12">
            <div class="row g-0 border rounded overflow-hidden flex-md-row mb-4 shadow-sm h-md-250 position-relative">
                <div class="col p-4 d-flex flex-column position-static">
                    <strong class="d-inline-block mb-2 text-success">Subjects</strong>
                    <h3 class="mb-0">Mapping Subjects</h3>
                    <p class="card-text mb-auto">In this Head of Department can mapping the subject to their faculty.</p>
                    <asp:Button ID="Button3" runat="server" Text="Go" CssClass="btn btn-outline-light lin stretched-link" PostBackUrl="~/HOD_Subject_Function.aspx" />
                </div>
                <div class="col-auto d-none d-lg-block">
                    <asp:Image ID="Image3" ImageUrl="~/Images/Subjects.png" class="bd-placeholder-img" Width="200" Height="250" runat="server" />
                </div>
            </div>
        </div>
    </div>
</asp:Content>
