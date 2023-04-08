<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Forget_Password1.aspx.cs" Inherits="Project.Forget_Password1" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <meta name="viewport" content="width=device-width, initial-scale=1.0" />
    <title>Login</title>
    <link rel="stylesheet" href="LoginCSS.css" />
    <script src="https://kit.fontawesome.com/a076d05399.js"></script>
</head>
<body>
    <div class="container">
        <div class="wrapper">
            <div class="title"><span>Forget Password</span></div>
            <form runat="server">
                <div id="d1" runat="server">
                    <div class="row">
                        <i>
                            <svg xmlns="http://www.w3.org/2000/svg" width="16" height="16" fill="currentColor" class="bi bi-people-fill" viewBox="0 0 16 16">
                                <path d="M7 14s-1 0-1-1 1-4 5-4 5 3 5 4-1 1-1 1H7Zm4-6a3 3 0 1 0 0-6 3 3 0 0 0 0 6Zm-5.784 6A2.238 2.238 0 0 1 5 13c0-1.355.68-2.75 1.936-3.72A6.325 6.325 0 0 0 5 9c-4 0-5 3-5 4s1 1 1 1h4.216ZM4.5 8a2.5 2.5 0 1 0 0-5 2.5 2.5 0 0 0 0 5Z" />
                            </svg></i>
                        <asp:TextBox ID="TextBox6" runat="server" placeholder="Team ID" required="true"></asp:TextBox>
                    </div>
                    <div class="row">
                        <i>
                            <svg xmlns="http://www.w3.org/2000/svg" width="16" height="16" fill="currentColor" class="bi bi-chat-square-text-fill" viewBox="0 0 16 16">
                                <path d="M0 2a2 2 0 0 1 2-2h12a2 2 0 0 1 2 2v8a2 2 0 0 1-2 2h-2.5a1 1 0 0 0-.8.4l-1.9 2.533a1 1 0 0 1-1.6 0L5.3 12.4a1 1 0 0 0-.8-.4H2a2 2 0 0 1-2-2V2zm3.5 1a.5.5 0 0 0 0 1h9a.5.5 0 0 0 0-1h-9zm0 2.5a.5.5 0 0 0 0 1h9a.5.5 0 0 0 0-1h-9zm0 2.5a.5.5 0 0 0 0 1h5a.5.5 0 0 0 0-1h-5z" />
                            </svg></i>
                        <asp:TextBox ID="TextBox1" runat="server" placeholder="Username" required="true"></asp:TextBox>
                    </div>
                    <div class="row">
                        <i>
                            <svg xmlns="http://www.w3.org/2000/svg" width="16" height="16" fill="currentColor" class="bi bi-envelope" viewBox="0 0 16 16">
                                <path d="M0 4a2 2 0 0 1 2-2h12a2 2 0 0 1 2 2v8a2 2 0 0 1-2 2H2a2 2 0 0 1-2-2V4Zm2-1a1 1 0 0 0-1 1v.217l7 4.2 7-4.2V4a1 1 0 0 0-1-1H2Zm13 2.383-4.708 2.825L15 11.105V5.383Zm-.034 6.876-5.64-3.471L8 9.583l-1.326-.795-5.64 3.47A1 1 0 0 0 2 13h12a1 1 0 0 0 .966-.741ZM1 11.105l4.708-2.897L1 5.383v5.722Z" />
                            </svg></i>
                        <asp:TextBox ID="TextBox2" runat="server" placeholder="E-Mail" required="true" TextMode="Email"></asp:TextBox>
                    </div>
                    <div class="row button">
                        <asp:Button ID="Button1" runat="server" Text="Send OTP" class="butt" OnClick="Button1_Click" />
                    </div>
                </div>
                <div id="d2" runat="server">
                    <div class="row">
                        <i>
                            <svg xmlns="http://www.w3.org/2000/svg" width="16" height="16" fill="currentColor" class="bi bi-0-circle-fill" viewBox="0 0 16 16">
                                <path d="M8 4.951c-1.008 0-1.629 1.09-1.629 2.895v.31c0 1.81.627 2.895 1.629 2.895s1.623-1.09 1.623-2.895v-.31c0-1.8-.621-2.895-1.623-2.895Z" />
                                <path d="M16 8A8 8 0 1 1 0 8a8 8 0 0 1 16 0Zm-8.012 4.158c1.858 0 2.96-1.582 2.96-3.99V7.84c0-2.426-1.079-3.996-2.936-3.996-1.864 0-2.965 1.588-2.965 3.996v.328c0 2.42 1.09 3.99 2.941 3.99Z" />
                            </svg></i>
                        <asp:TextBox ID="TextBox5" runat="server" placeholder="OTP" required="true" TextMode="Number"></asp:TextBox>
                    </div>
                    <div class="row button">
                        <asp:Button ID="Button3" runat="server" Text="Reset" class="butt" OnClick="Button3_Click" />
                    </div>
                </div>
                <div id="d3" runat="server">
                    <div class="row">
                        <i>
                            <svg xmlns="http://www.w3.org/2000/svg" width="16" height="16" fill="currentColor" class="bi bi-people-fill" viewBox="0 0 16 16">
                                <path d="M7 14s-1 0-1-1 1-4 5-4 5 3 5 4-1 1-1 1H7Zm4-6a3 3 0 1 0 0-6 3 3 0 0 0 0 6Zm-5.784 6A2.238 2.238 0 0 1 5 13c0-1.355.68-2.75 1.936-3.72A6.325 6.325 0 0 0 5 9c-4 0-5 3-5 4s1 1 1 1h4.216ZM4.5 8a2.5 2.5 0 1 0 0-5 2.5 2.5 0 0 0 0 5Z" />
                            </svg></i>
                        <asp:TextBox ID="TextBox3" runat="server" placeholder="New Password" required="true" TextMode="Password"></asp:TextBox>
                    </div>
                    <div class="row">
                        <i>
                            <svg xmlns="http://www.w3.org/2000/svg" width="16" height="16" fill="currentColor" class="bi bi-people-fill" viewBox="0 0 16 16">
                                <path d="M7 14s-1 0-1-1 1-4 5-4 5 3 5 4-1 1-1 1H7Zm4-6a3 3 0 1 0 0-6 3 3 0 0 0 0 6Zm-5.784 6A2.238 2.238 0 0 1 5 13c0-1.355.68-2.75 1.936-3.72A6.325 6.325 0 0 0 5 9c-4 0-5 3-5 4s1 1 1 1h4.216ZM4.5 8a2.5 2.5 0 1 0 0-5 2.5 2.5 0 0 0 0 5Z" />
                            </svg></i>
                        <asp:TextBox ID="TextBox4" runat="server" placeholder="Confirm Password" required="true" TextMode="Password"></asp:TextBox>
                    </div>
                    <div class="row button">
                        <asp:Button ID="Button2" runat="server" Text="Confirm" OnClick="Button2_Click" />
                    </div>
                </div>
                <asp:CompareValidator ID="CompareValidator1" runat="server" ErrorMessage="Password Not Match!" Display="None" Text="" ControlToCompare="TextBox4" ControlToValidate="TextBox3"></asp:CompareValidator>
                <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" ControlToValidate="TextBox3" ErrorMessage="Password Length should be Greater than or equal to 8 & include special characters!" Text="" Display="None" ValidationExpression="(?=^.{8,}$)((?=.*\d)|(?=.*\w+))(?![.\n])(?=.*[@$!%*#?&]).*$"></asp:RegularExpressionValidator>
                <asp:ValidationSummary ID="ValidationSummary1" runat="server" ShowMessageBox="True" ShowSummary="False" />
            </form>
        </div>
    </div>
</body>

</html>
