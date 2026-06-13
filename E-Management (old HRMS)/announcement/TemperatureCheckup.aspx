<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="TemperatureCheckup.aspx.vb" Inherits="E_Management.TemperatureCheckup" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="Head1" runat="server">
    <title>Temperature Checkup</title>
      <meta charset="utf-8"/>
        <meta http-equiv="X-UA-Compatible" content="IE=edge"/>
        <meta name="viewport" content="width=device-width, initial-scale=1.0"/>
        <link rel="icon" href="images/icons/favicon.png"/>
        
        <!-- Bootstrap core CSS -->
       <%-- <link href="~Css/bootstrap.min.css" rel="stylesheet"/>--%>
    <link href="Css/bootstrap.min.css" rel="stylesheet" type="text/css" />
        <link href="font-awesome/css/font-awesome.min.css" rel="stylesheet" type="text/css" />
        <!-- Custom styles for this template -->
        <link href="Css/style.css" rel="stylesheet"/>
        <link href="fonts/antonio-exotic/stylesheet.css" rel="stylesheet"/>
        <link rel="stylesheet" href="Css/lightbox.min.css"/>
        <link href="Css/responsive.css" rel="stylesheet"/>
        <script src="js/jquery.min.js" type="text/javascript"></script>
        <script src="js/bootstrap.min.js" type="text/javascript"></script>
        <script src="js/lightbox-plus-jquery.min.js" type="text/javascript"></script>
        <script src="js/instafeed.min.js" type="text/javascript"></script>
        <script src="js/custom.js" type="text/javascript"></script>


</head>


<body>
    <form id="form1" runat="server">
    <div class="container">
     <table align="center"width="80%"  class="table table-striped">
    
    <thead>
   <tr>
   <th >   
       <span style="font-size: 14pt">
   MARUWA (MALAYSIA) SDN BHD </span>
   </th>               
   </tr>
   </thead>
   <tbody>
   
   <tr>
   <td>
   
   </td></tr>
   <tr>
   <td>   
       <span style="font-size: 12pt"><strong>
   Temperature Checkup</strong> :
           <asp:Label ID="Label5" runat="server" Font-Bold="True"></asp:Label></span></td>               
   </tr>
 <tr>
 <td>
 <label  class="col-form-label">Employee Code:</label><br />
   <asp:TextBox class="form-control" ID="empcode1" runat="server"  AutoPostBack="True" MaxLength=6></asp:TextBox>
 </td>
 </tr>
   
   
    <tr>
 <td>
 <label  class="col-form-label">Employee Name:</label><br />
   <asp:TextBox class="form-control" ID="empname1" runat="server"></asp:TextBox>
 </td>
 </tr>
   <tr>
   <td>
   <label  class="col-form-label">Created By : Employee Code:</label><br />
   <asp:TextBox class="form-control" ID="empcode" runat="server" ReadOnly="true"></asp:TextBox>&nbsp;
   </td>
   </tr>
   
   <tr>
   <td>
   <label  class="col-form-label">Created By : Employee Name:</label><br />
   <asp:TextBox class="form-control" ID="empname" runat="server" ReadOnly="true"></asp:TextBox>
   </td>
   </tr>
   
   <tr>
   <td>
    <label  class="col-form-label">Body Temperature</label><br />
       <asp:RadioButton ID="RadioButton1" runat="server" Text="Normal Temperature <37.5" Checked="true" GroupName="1"/>
       <asp:RadioButton ID="RadioButton2" runat="server" Text="Abnormal Temperature >37.5" GroupName="1"/><br />
       <asp:TextBox class="form-control" ID="TxtTemperature" runat="server"></asp:TextBox>
   </td>
   </tr>
       <tr>
           <td>
               <asp:Label ID="Label1" runat="server" Font-Bold="True"></asp:Label></td>
       </tr>
     
   
   <tr>
   <td> <asp:Button id="Button1" runat="server"  class="book-now-btn1"  text="Submit" ></asp:Button></td>
   </tr>
   <tr>
   <td style="text-align: center">
       <asp:GridView ID="GridView1" runat="server" CellPadding="4" ForeColor="#333333" GridLines="None">
           <RowStyle BackColor="#EFF3FB" />
           <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
           <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
           <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
           <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
           <EditRowStyle BackColor="#2461BF" />
           <AlternatingRowStyle BackColor="White" />
       </asp:GridView>
   </td></tr>
        </tbody>
        </table>
    </div>
  
        
     
    </form>
</body>
</html>
