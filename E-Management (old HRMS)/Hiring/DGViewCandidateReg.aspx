<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="DGViewCandidateReg.aspx.vb" Inherits="E_Management.DGViewCandidateReg" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="Head1" runat="server">
    <title>Candidate Registration</title>
      <meta charset="utf-8"/>
        <meta http-equiv="X-UA-Compatible" content="IE=edge"/>
        <meta name="viewport" content="width=device-width, initial-scale=1.0"/>
        <link rel="icon" href="~/images/icons/favicon.png"/>
        
        <!-- Bootstrap core CSS -->
       <%-- <link href="~Css/bootstrap.min.css" rel="stylesheet"/>--%>
    <link href="~/Css/bootstrap.min.css" rel="stylesheet" type="text/css" />
        <link href="/announcement/font-awesome/css/font-awesome.min.css" rel="stylesheet" type="text/css" />
        <!-- Custom styles for this template -->
        <link href="~/Css/style.css" rel="stylesheet"/>
        <link href="/announcement/fonts/antonio-exotic/stylesheet.css" rel="stylesheet"/>
        <link rel="stylesheet" href="~/Css/lightbox.min.css"/>
        <link href="~/Css/responsive.css" rel="stylesheet"/>
        <script src="~/js/jquery.min.js" type="text/javascript"></script>
        <script src="~/js/bootstrap.min.js" type="text/javascript"></script>
        <script src="~/js/lightbox-plus-jquery.min.js" type="text/javascript"></script>
        <script src="~/js/instafeed.min.js" type="text/javascript"></script>
        <script src="~/js/custom.js" type="text/javascript"></script>

</head>


<body>
    <form id="form1" runat="server">
    <div class="container">
     
   
   <table  align="center" width="60%"  class="table table-striped">
       <tr>
           <td style="text-align: center">
               <strong>&nbsp;</strong><span style="font-size: 12pt"><strong>Candidate Registration Details</strong></span></td>
       </tr>
       <tr>
           <td style="text-align: center">
           </td>
       </tr>
   <tr>
            <td style="text-align: left">
                <asp:GridView AutoGenerateColumns=False Width="100%" ID="DGCandidateReg" runat="server" CellPadding="4" CellSpacing="2" Font-Names="Arial" Font-Size="9pt" ForeColor="Black" BackColor="#CCCCCC" BorderColor="#999999" BorderStyle="Solid" BorderWidth="1px">
                    <FooterStyle BackColor="#CCCCCC" />
                    <PagerStyle BackColor="#CCCCCC" ForeColor="Black" HorizontalAlign="Left" />
                    <SelectedRowStyle BackColor="#000099" Font-Bold="True" ForeColor="White" />
                    <HeaderStyle BackColor="Black" Font-Bold="True" ForeColor="White" />
                      <Columns>
                
                 <asp:BoundField DataField="UID" HeaderText="UID" ReadOnly="True" SortExpression="UID" Visible=False />
                  <asp:BoundField DataField="CandidateName" HeaderText="CandidateName" ReadOnly="True" SortExpression="CandidateName" />
                   <asp:BoundField DataField="ICNumber" HeaderText="ICNumber" ReadOnly="True" SortExpression="ICNumber" />
                    <asp:BoundField DataField="ContactNumber" HeaderText="ContactNumber" ReadOnly="True" SortExpression="ContactNumber" />
                     <asp:BoundField DataField="Position" HeaderText="Position" ReadOnly="True" SortExpression="Position" />
                      <asp:BoundField DataField="AppliedOn" HeaderText="AppliedOn" ReadOnly="True" SortExpression="AppliedOn" />
                      <asp:BoundField DataField="Resume" HeaderText="Resume" ReadOnly="True" SortExpression="Resume" />
                      <asp:BoundField DataField="Certificate" HeaderText="Certificate" ReadOnly="True" SortExpression="Certificate" />
                   <asp:HyperLinkField DataNavigateUrlFields="UID" DataNavigateUrlFormatString="CandidateRegView.aspx?uid={0}"
                                                HeaderText="View"  Text="view">
                                                <ControlStyle Font-Underline="True" />
                                            </asp:HyperLinkField>
                </Columns>
                    <RowStyle BackColor="White" />
                </asp:GridView>
            </td>
        </tr>
       
        </table>
    </div>     

  
        
     
    </form>
</body>
</html>

