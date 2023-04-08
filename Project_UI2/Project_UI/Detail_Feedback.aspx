<%@ Page Title="" Language="C#" MasterPageFile="~/Navigation.Master" AutoEventWireup="true" CodeBehind="Detail_Feedback.aspx.cs" Inherits="Project_UI.Detail_Feedback" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <link rel="stylesheet" href="LoginCSS.css" />
    <script src="https://kit.fontawesome.com/a076d05399.js"></script>
    <div class="container text-center w-25 m-auto">
        <div class="row align-items-center m-3 mt-5">
            <div class="col mt-5" >
                <h1>Search Details</h1>
                <p class="lead">The purpose of feedback in the assessment and learning process is to improve a student's performance - not put a damper on it. It is essential that the process of providing feedback is a positive, or at least a neutral, learning experience for the student.</p>
                <div class="d-flex justify-content-center m-2">
                    <div>
                        <div class="d-flex align-items-center btn-group m-2">
                            <%-- <button type="button" class="btn btn-secondary dropdown-toggle" data-bs-toggle="dropdown" data-bs-display="static" aria-expanded="false">
                                Left-aligned but right aligned when large screen
                            </button>--%>
                            <asp:TextBox ID="TextBox1" runat="server" placeholder="Subject Code" required="true" TextMode="Number"></asp:TextBox>
                        </div>
                    </div>
                    <div>
                        <div class="btn-group m-2">
                            <%-- <button type="button" class="btn btn-secondary dropdown-toggle" data-bs-toggle="dropdown" data-bs-display="static" aria-expanded="false">
                                Left-aligned but right aligned when large screen
                            </button>--%>
                            <asp:TextBox ID="TextBox2" runat="server" placeholder="Enrollment No" required="true" TextMode="Number"></asp:TextBox>
                        </div>
                    </div>
                </div>
                <p class="lead">
                     <asp:Button ID="search" runat="server" Text="Search" CssClass="btn btn-dark btn-lg  mb-5 w-100" OnClick="search_Click"/>
                </p>
            </div>
        </div>
    </div>
</asp:Content>
