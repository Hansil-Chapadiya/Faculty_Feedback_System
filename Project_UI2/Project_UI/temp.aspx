<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="temp.aspx.cs" Inherits="Project_UI.temp" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <meta name="viewport" content="width=device-width, initial-scale=1.0" />
     <link href="https://cdn.jsdelivr.net/npm/bootstrap@5.3.0-alpha1/dist/css/bootstrap.min.css" rel="stylesheet" integrity="sha384-GLhlTQ8iRABdZLl6O3oVMWSktQOp6b7In1Zl3/Jr59b6EGGoI1aFkw7cmDA6j6gD" crossorigin="anonymous" />
    <script defer="https://cdn.jsdelivr.net/npm/bootstrap@5.3.0-alpha1/dist/js/bootstrap.bundle.min.js" integrity="sha384-w76AqPfDkMBDXo30jS1Sgez6pr3x5MlQ1ZAGC+nuZB+EYdgRZgiwxhTBTkF7CXvN" crossorigin="anonymous"></script>
</head>
<body>
     <script src="https://cdn.jsdelivr.net/npm/bootstrap@5.3.0-alpha1/dist/js/bootstrap.bundle.min.js" integrity="sha384-w76AqPfDkMBDXo30jS1Sgez6pr3x5MlQ1ZAGC+nuZB+EYdgRZgiwxhTBTkF7CXvN" crossorigin="anonymous"></script>
    <form id="form1" runat="server">
        <div class="container text-center w-25 m-auto" id="div_sem_1">
        <div class="row align-items-center m-3 mt-5">
            <div class="col mt-5">
                <h1>Choose Sem for inserting Students</h1>
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
                </div>
                <p class="lead">
                    <asp:Button ID="Button1" runat="server" CssClass="btn btn-lg btn-outline-light lin" Text="Submit"  PostBackUrl="~/Create_New_Student.aspx" />
                </p>
            </div>
        </div>
    </div>
    </form>
</body>
</html>
