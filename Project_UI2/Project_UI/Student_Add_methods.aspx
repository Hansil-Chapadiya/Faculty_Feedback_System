<%@ Page Title="" Language="C#" MasterPageFile="~/Navigation.Master" AutoEventWireup="true" CodeBehind="Student_Add_methods.aspx.cs" Inherits="Project_UI.Student_Add_methods" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container text-center d-flex justify-content-center mt-5">
            <div class="row m-5 d-flex justify-content-center">
                <div class="d-flex justify-content-center col m-4">
                    <div class="card" style="width: 18rem;">
                        <asp:ImageButton ID="HODRoleImg" runat="server" ImageUrl="~/Images/Add_Faculty.jpg" CssClass="card-img-top" PostBackUrl="~/Create_New_Student.aspx" />
                        <div class="card-body">
                            <h5 class="card-title">Add Manually</h5>
                            <p class="card-text">Some quick example text to build on the card title and make up the bulk of the card's content.</p>
                            <a href="Create_New_Faculty.aspx" class="btn btn-lg btn-outline-light lin">Add</a>
                        </div>
                    </div>
                </div>
                <div class="d-flex justify-content-center col m-4">
                    <div class="card" style="width: 18rem;">
                        <asp:ImageButton ID="FacultyRoleImg" runat="server" ImageUrl="~/Images/excel.png" CssClass="card-img-top" PostBackUrl="~/Create_Student_Excel.aspx" />
                        <div class="card-body">
                            <h5 class="card-title">Add Using Excel Sheet</h5>
                            <p class="card-text">Some quick example text to build on the card title and make up the bulk of the card's content.</p>
                            <a href="Create_Student_Excel.aspx" class="btn btn-lg btn-outline-light lin">Upload</a>
                        </div>
                    </div>
                </div>
            </div>
        </div>
</asp:Content>
