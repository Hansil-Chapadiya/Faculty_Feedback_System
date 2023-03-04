<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="login1.aspx.cs" Inherits="Project.login1" %>

<%@ Register Assembly="MSCaptcha" Namespace="MSCaptcha" TagPrefix="cap" %>
<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Login</title>
    <meta name="viewport" content="width=device-width, initial-scale=1.0" />
    <link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/4.0.0/css/bootstrap.min.css" integrity="sha384-Gn5384xqQ1aoWXA+058RXPxPg6fy4IWvTNh0E263XmFcJlSAwiGgFAW/dAiS6JXm" crossorigin="anonymous" />
    <link rel="stylesheet" href="https://cdnjs.cloudflare.com/ajax/libs/font-awesome/5.14.0/css/all.min.css" integrity="sha512-1PKOgIY59xJ8Co8+NE6FZ+LOAZKjy+KY8iq0G4B3CyeY6wYHN3yt9PW0XpSriVlkMXe40PTKnXrLnZ9+fkDaog==" crossorigin="anonymous" />
    <link rel="stylesheet" href="loginstyle.css" />
</head>
<body>
    <div class="container">
        <div class="myCard">
            <div class="row">
                <div class="col-md-6">
                    <div class="myLeftCtn">
                        <form class="myForm text-center" runat="server">
                            <header>Login</header>
                            <div class="form-group">
                                <svg xmlns="http://www.w3.org/2000/svg" width="16" height="16" fill="currentColor" class="bi bi-people-fill" viewBox="0 0 16 16">
                                    <path d="M7 14s-1 0-1-1 1-4 5-4 5 3 5 4-1 1-1 1H7Zm4-6a3 3 0 1 0 0-6 3 3 0 0 0 0 6Zm-5.784 6A2.238 2.238 0 0 1 5 13c0-1.355.68-2.75 1.936-3.72A6.325 6.325 0 0 0 5 9c-4 0-5 3-5 4s1 1 1 1h4.216ZM4.5 8a2.5 2.5 0 1 0 0-5 2.5 2.5 0 0 0 0 5Z" />
                                </svg>
                                <asp:TextBox ID="TextBox4" runat="server" placeholder="Team ID" class="myInput" required="true" TextMode="Number"></asp:TextBox>
                            </div>

                            <div class="form-group">
                                <i class="fas fa-user"></i>
                                <asp:TextBox ID="TextBox1" runat="server" placeholder="Username" class="myInput" required="true" TextMode="Number"></asp:TextBox>
                            </div>

                            <div class="form-group">
                                <i class="fas fa-lock"></i>
                                <asp:TextBox ID="TextBox2" runat="server" placeholder="Password" class="myInput" required="true" TextMode="Password"></asp:TextBox>
                            </div>
                            <div class="form-group">
                                <cap:CaptchaControl ID="captcha1" runat="server" CaptchaLength="5" CaptchaHeight="50" CaptchaWidth="200" CaptchaLineNoise="High" CaptchaMinTimeout="3" CaptchaMaxTimeout="240" ForeColor="White" CaptchaChars="ABCDEFGHIJKLMNOPQRSTUVWXYZ12345678990abcdefghijklmnopqrstuvwxyz" Height="47px" Width="200px" CssClass="ml-5" /><br />
                                <svg xmlns="http://www.w3.org/2000/svg" width="16" height="16" fill="currentColor" class="bi bi-clipboard2-fill" viewBox="0 0 16 16">
                                    <path d="M9.5 0a.5.5 0 0 1 .5.5.5.5 0 0 0 .5.5.5.5 0 0 1 .5.5V2a.5.5 0 0 1-.5.5h-5A.5.5 0 0 1 5 2v-.5a.5.5 0 0 1 .5-.5.5.5 0 0 0 .5-.5.5.5 0 0 1 .5-.5h3Z" />
                                    <path d="M3.5 1h.585A1.498 1.498 0 0 0 4 1.5V2a1.5 1.5 0 0 0 1.5 1.5h5A1.5 1.5 0 0 0 12 2v-.5c0-.175-.03-.344-.085-.5h.585A1.5 1.5 0 0 1 14 2.5v12a1.5 1.5 0 0 1-1.5 1.5h-9A1.5 1.5 0 0 1 2 14.5v-12A1.5 1.5 0 0 1 3.5 1Z" />
                                </svg>
                                <asp:TextBox ID="TextBox3" runat="server" placeholder="captcha" class="myInput" required="true"></asp:TextBox><br /><br />
                            </div>
                            <div class="form-group">
                                <asp:HyperLink ID="HyperLink2" runat="server" Font-Names="Mongolian Baiti" Font-Size="X-Large" NavigateUrl="~/Forget_Password1.aspx" Target="_blank">Forgot password</asp:HyperLink>
                                <br />
                                <br />
                                <asp:HyperLink ID="HyperLink1" runat="server" Font-Names="Mongolian Baiti" Font-Size="X-Large" NavigateUrl="~/Create_New_HOD.aspx">Create new account</asp:HyperLink>
                                <br />
                                <br />
                            </div>
                            <asp:Button ID="Button1" runat="server" Text="Login" class="butt" OnClick="Button1_Click" />
                        </form>
                    </div>
                </div>
                <div class="col-md-6">
                    <div class="myRightCtn">
                        <div class="box">
                            <header>Faculty Feedback System</header>

                            <p>
                               This System is for feedback purpose and system provide facilty to create your own system and data.
                            </p>
                            <%--<asp:Button ID="Button2" runat="server" Text="Button" class="butt_out" />--%>
                        </div>

                    </div>
                </div>
            </div>
        </div>
    </div>

    <script src="https://code.jquery.com/jquery-3.2.1.slim.min.js" integrity="sha384-KJ3o2DKtIkvYIK3UENzmM7KCkRr/rE9/Qpg6aAZGJwFDMVNA/GpGFF93hXpG5KkN" crossorigin="anonymous"></script>
    <script src="https://cdnjs.cloudflare.com/ajax/libs/popper.js/1.12.9/umd/popper.min.js" integrity="sha384-ApNbgh9B+Y1QKtv3Rn7W3mgPxhU9K/ScQsAP7hUibX39j7fakFPskvXusvfa0b4Q" crossorigin="anonymous"></script>
    <script src="https://maxcdn.bootstrapcdn.com/bootstrap/4.0.0/js/bootstrap.min.js" integrity="sha384-JZR6Spejh4U02d8jOt6vLEHfe/JQGiRRSQQxSfFWpi1MquVdAyjUar5+76PVCmYl" crossorigin="anonymous"></script>

</body>
</html>
