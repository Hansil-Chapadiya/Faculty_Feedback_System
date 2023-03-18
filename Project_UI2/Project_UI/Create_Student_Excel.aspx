<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Create_Student_Excel.aspx.cs" Inherits="Project_UI.Create_Student_Excel" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <meta name="viewport" content="width=device-width, initial-scale=1.0" />
    <link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/4.0.0/css/bootstrap.min.css" integrity="sha384-Gn5384xqQ1aoWXA+058RXPxPg6fy4IWvTNh0E263XmFcJlSAwiGgFAW/dAiS6JXm" crossorigin="anonymous" />
    <link rel="stylesheet" href="https://cdnjs.cloudflare.com/ajax/libs/font-awesome/5.14.0/css/all.min.css" integrity="sha512-1PKOgIY59xJ8Co8+NE6FZ+LOAZKjy+KY8iq0G4B3CyeY6wYHN3yt9PW0XpSriVlkMXe40PTKnXrLnZ9+fkDaog==" crossorigin="anonymous" />
    <link rel="stylesheet" href="HODStyle.css" />
</head>
<body>
    <div class="container">
        <div class="myCard">
            <div class="row">
                <div class="col-md-6">
                    <form class="myForm text-center" runat="server">
                        <div class="myLeftCtn">
                            <header>Add Student Using ExcelSheet</header>
                            <div class="form-group">
                                <svg xmlns="http://www.w3.org/2000/svg" width="16" height="16" fill="currentColor" class="bi bi-chat-square-text-fill" viewBox="0 0 16 16">
                                    <path d="M0 2a2 2 0 0 1 2-2h12a2 2 0 0 1 2 2v8a2 2 0 0 1-2 2h-2.5a1 1 0 0 0-.8.4l-1.9 2.533a1 1 0 0 1-1.6 0L5.3 12.4a1 1 0 0 0-.8-.4H2a2 2 0 0 1-2-2V2zm3.5 1a.5.5 0 0 0 0 1h9a.5.5 0 0 0 0-1h-9zm0 2.5a.5.5 0 0 0 0 1h9a.5.5 0 0 0 0-1h-9zm0 2.5a.5.5 0 0 0 0 1h5a.5.5 0 0 0 0-1h-5z" />
                                </svg>
                                <asp:FileUpload runat="server" CssClass="myInput" ID="ExcelStudent"></asp:FileUpload>
                            </div>
                            <asp:Button ID="Button1" runat="server" class="butt" Text="ADD" OnClick="Button1_Click" />

                            <p style="font-size:20px; color:black">
                                <br />
                                <br />
                                Read Instructions First👉😀
                            </p>
                        </div>
                    </form>
                </div>
                <div class="col-md-6">
                    <div class="myRightCtn">
                        <div class="box">
                            <header>Faculty Feedback System</header>
                            <h3>Instructions</h3>
                            <p style="font-size:20px; color:black">
                                If You Upload .xlsx file second time with changes then your filename must be diffrent from previous filename.
                            </p>
                            <a href="HOD_HomePage.aspx" class="btn btn-info" role="button" title="Home">Home</a>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
</body>
</html>
