<%@ Page Title="" Language="C#" MasterPageFile="~/Navigation.Master" AutoEventWireup="true" CodeBehind="Leader_Board.aspx.cs" Inherits="Project_UI.WebForm2" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
     <div class="container text-center w-25 m-auto" runat="server">
        <div class="row align-items-center m-3 mt-5">
            <div class="col mt-5">
                <h1>Choose Sem for inserting Students</h1>
                 <div class="d-flex justify-content-center m-2">
                    <div>
                        <div class="d-flex align-items-center btn-group m-2 dropdown">
                            <asp:DropDownList ID="DropDownList1" runat="server" AutoPostBack="True" OnSelectedIndexChanged="DropDownList1_SelectedIndexChanged" CssClass="btn btn-secondary dropdown-toggle lin">
                            </asp:DropDownList>
                             </div>
                    </div>
                    <div>
                        <div class="btn-group m-2">
                             <asp:DropDownList ID="DropDownList2" runat="server" AutoPostBack="True" OnSelectedIndexChanged="DropDownList2_SelectedIndexChanged" CssClass="btn btn-secondary dropdown-toggle lin ">
    </asp:DropDownList>
                        </div>
                    </div>
                     <div>
                          <div class="d-flex align-items-center btn-group m-2 dropdown">
                            <asp:DropDownList ID="DropDownList3" runat="server" class="btn btn-secondary dropdown-toggle lin" AutoPostBack="True">
                            </asp:DropDownList>
                        </div>
                     </div>
                </div>
            </div>
             <div>
                         <asp:Button runat="server" Text="Submit" ID="Button1" CssClass="btn btn-lg btn-outline-light lin" OnClick="Button1_Click"/>
                     </div>
        </div>
        </div>
    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
   
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;

    

    

</asp:Content>
