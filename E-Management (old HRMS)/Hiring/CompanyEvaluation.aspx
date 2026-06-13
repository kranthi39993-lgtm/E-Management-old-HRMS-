<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="CompanyEvaluation.aspx.vb" Inherits="E_Management.CompanyEvaluation" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="Head1" runat="server">
    <title>FORM C</title>
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
     <table align="center" width="60%"  class="table table-striped">
    
    <thead>
        <tr>
            <th style="height: 16px; text-align: right">
                <asp:LinkButton ID="LinkButton2" runat="server" ForeColor="Blue">Report</asp:LinkButton>
                &nbsp; &nbsp; &nbsp;&nbsp;&nbsp;&nbsp;<asp:LinkButton ID="LinkButton1" runat="server" ForeColor="Blue">Logout</asp:LinkButton></th>
        </tr>
   <tr>
   <th style="text-align: center; width: 664px;"  colspan="6">   
       <span style="font-size: 14pt">
   MARUWA  </span><br/><span style="font-size: 8pt">
   MARUWA (M) SDN.BHD.</span><br/><br />
    <span style="font-size: 10pt">
   EVALUATION ON COMPANY BACKGROUND </span><br />
   <span style="font-size: 9pt">
   (Engineer and Officer above)</span>
   </th>               
   </tr>
   </thead>
   <tbody>
         
       <tr>
           <td>
           <asp:Label ID="Label8" runat="server" Font-Bold="True">Nama / Name : </asp:Label>
           <asp:TextBox class="form-control" ID="TxtName" readonly="False" runat="server" Width="60%"></asp:TextBox>&nbsp; 
           <asp:Label ID="Label5" runat="server" Font-Bold="True">New IC No.   : </asp:Label>
           <asp:TextBox class="form-control" ID="TxtIcNo" readonly="false" runat="server" Width="60%"></asp:TextBox>&nbsp; 
               <asp:Label ID="Label7" runat="server" Font-Bold="True">Date / Tarikh  : </asp:Label>
               <cc1:CalendarExtender
           id="Calendarextender2" runat="server" format="dd/MMM/yyyy"
           popupbuttonid="TxtDate" targetcontrolid="TxtDate">
       </cc1:CalendarExtender>
          <asp:ScriptManager ID="ScriptManager1" runat="server">
       </asp:ScriptManager>
               <asp:TextBox class="form-control" ID="TxtDate" readonly="false" runat="server" Width="60%"></asp:TextBox>&nbsp;                
       </td> 
       </tr>
          
          <tr>
   <td>
   <label  class="col-form-label" style="width: 60%"> Please write the answer on the place given.</label>&nbsp; &nbsp;<br />
   
       <label  class="col-form-label" style="width: 60%">1. Which of the following is Maruwa Product?</label>&nbsp; &nbsp;<br />
       <asp:CheckBox Text="a. Chip Resistor " ID="ChBx1a" runat="server" AutoPostBack="True" />&nbsp; &nbsp;<br />
       <asp:CheckBox Text="b. Amplifiers" ID="ChBx1b" runat="server" AutoPostBack="True" />&nbsp; &nbsp;<br />
       <asp:CheckBox Text="c. Transistors" ID="ChBx1c" runat="server" AutoPostBack="True" />&nbsp; &nbsp;<br />
       <asp:CheckBox Text="d. Fibre optic Components" ID="ChBx1d" runat="server" AutoPostBack="True" />&nbsp; &nbsp;<br />
       
       
   </td>
   </tr> 
   
    <tr>
           <td>
   <label  class="col-form-label" style="width: 60%"> 2. What is the name of this product.</label>&nbsp; &nbsp;<br />
          
       <asp:CheckBox Text="a. Rod resistor" ID="ChBx2a" runat="server" AutoPostBack="True" />&nbsp; &nbsp;<br />
       <asp:CheckBox Text="b. Amplifiers" ID="ChBx2b" runat="server" AutoPostBack="True" />&nbsp; &nbsp;<br />
       <asp:CheckBox Text="c. Ceramic rod" ID="ChBx2c" runat="server" AutoPostBack="True" />&nbsp; &nbsp;<br />
       <asp:CheckBox Text="d. Alumina Substrate" ID="ChBx2d" runat="server" AutoPostBack="True" />&nbsp; &nbsp;<br />      
       
           </td>           
   </tr>  
   
   <tr> 
   <td>
   <label  class="col-form-label" style="width: 60%"> PRODUCT NAME : CHEMICAL VALUE </label>&nbsp;<br />
   </td>  
   </tr>
   
   <tr>
           <td>
   <label  class="col-form-label" style="width: 60%"> 3.  The Ceramic Valves developed by Maruwa are manufactured with our unique material.Employing high tech pressing  and precision Ceramic are highly resistant to temperature changes , corrosion , and wear and tear. These excelent characteristic are making ceramic valve more attractive for wide range of excellent uses at: </label>&nbsp; &nbsp;<br />
          
       <asp:CheckBox Text="a. Public facilities, entertainment centres,wash basins,kitchen and bathroom in the home." ID="ChBx3a" runat="server" AutoPostBack="True" />&nbsp; &nbsp;<br />
       <asp:CheckBox Text="b. Telecomunication industries,information communication devices, car electronic and electronic application. " ID="ChBx3b" runat="server" AutoPostBack="True" />&nbsp; &nbsp;<br />
       <asp:CheckBox Text="c. Electric automobil,industrial equipment and communication devices." ID="ChBx3c" runat="server" AutoPostBack="True" />&nbsp; &nbsp;<br />
       <asp:CheckBox Text="d. Optical communications of fibre optical net works,optical media of CD's and DVD's radio and frequency of wireless    communication." ID="ChBx3d" runat="server" AutoPostBack="True" />&nbsp; &nbsp;<br />
       
       
           </td>
   </tr> 
   
   <tr>
           <td>
   <label  class="col-form-label" style="width: 60%"> 4. The President of Maruwa Is.</label>&nbsp; &nbsp;<br />
          
       <asp:CheckBox Text="a.Mr.Takashi Shigeoka " ID="ChBx4a" runat="server" AutoPostBack="True" />&nbsp; &nbsp;<br />
       <asp:CheckBox Text="b.Datuk Manimaran Anthony" ID="ChBx4b" runat="server" AutoPostBack="True" />&nbsp; &nbsp;<br />
       <asp:CheckBox Text="c.Mr.Sei Kanbei" ID="ChBx4c" runat="server" AutoPostBack="True" />&nbsp; &nbsp;<br />
       <asp:CheckBox Text="d.Mr.Anthony" ID="ChBx4d" runat="server" AutoPostBack="True" />&nbsp; &nbsp;<br />
       
       
           </td>
   </tr>  
   
    <tr>
           <td>
   <label  class="col-form-label" style="width: 60%">5.How Many factories does Maruwa have?</label>&nbsp; &nbsp;<br />
          
       <asp:CheckBox Text="a.7" ID="ChBx5a" runat="server" AutoPostBack="True" />&nbsp; &nbsp;<br />
       <asp:CheckBox Text="b.9" ID="ChBx5b" runat="server" AutoPostBack="True" />&nbsp; &nbsp;<br />
       <asp:CheckBox Text="c.10" ID="ChBx5c" runat="server" AutoPostBack="True" />&nbsp; &nbsp;<br />
       <asp:CheckBox Text="d.5" ID="ChBx5d" runat="server" AutoPostBack="True" />&nbsp; &nbsp;<br />
       
       
           </td>
   </tr> 
   
   
   <tr>
           <td style="height: 16px">
               <asp:Label ID="Label6" runat="server" Font-Bold="True"></asp:Label></td>
       </tr>
   
   <tr>
   <td> <asp:Button id="Button1" runat="server"  class="book-now-btn1"  text="Submit" ></asp:Button>
   
   </td>
   </tr>
    </tbody>
   </table>
     
    </div>
  
        
     
    </form>
</body>
</html>
