<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="DGViewApplnForm.aspx.vb" Inherits="E_Management.DGViewApplnForm" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="Head1" runat="server">
    <title>Application Form</title>
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
               <strong>&nbsp;</strong><span style="font-size: 12pt"><strong>Application Form</strong></span></td>
       </tr>
       <tr>
           <td style="text-align: center">
           </td>
       </tr>
   <tr>
            <td style="text-align: left">
                <asp:GridView AutoGenerateColumns=False Width="100%" ID="DGApplnForm" runat="server" CellPadding="4" CellSpacing="2" Font-Names="Arial" Font-Size="9pt" ForeColor="Black" BackColor="#CCCCCC" BorderColor="#999999" BorderStyle="Solid" BorderWidth="1px">
                    <FooterStyle BackColor="#CCCCCC" />
                    <PagerStyle BackColor="#CCCCCC" ForeColor="Black" HorizontalAlign="Left" />
                    <SelectedRowStyle BackColor="#000099" Font-Bold="True" ForeColor="White" />
                    <HeaderStyle BackColor="Black" Font-Bold="True" ForeColor="White" />
                      <Columns>
                
                 <asp:BoundField DataField="UID" HeaderText="UID" ReadOnly="True" SortExpression="UID" Visible=False />
                 <asp:BoundField DataField="Post" HeaderText="Post" ReadOnly="True" SortExpression="Post" />
                  <asp:BoundField DataField="Name" HeaderText="Name" ReadOnly="True" SortExpression="Name" />
                   <asp:BoundField DataField="Ic" HeaderText="IC" ReadOnly="True" SortExpression="Ic" />
                    <asp:BoundField DataField="Telno" HeaderText="Telno" ReadOnly="True" SortExpression="Telno" />
                     <asp:BoundField DataField="Sex" HeaderText="Sex" ReadOnly="True" SortExpression="Sex" />
                      <asp:BoundField DataField="Age" HeaderText="Age" ReadOnly="True" SortExpression="Age" />
                      
                   <asp:HyperLinkField DataNavigateUrlFields="UID" DataNavigateUrlFormatString="ApplnFormView.aspx?uid={0}"
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
