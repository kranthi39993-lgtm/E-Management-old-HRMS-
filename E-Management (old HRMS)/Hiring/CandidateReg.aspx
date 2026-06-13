<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="CandidateReg.aspx.vb" Inherits="E_Management.CandidateReg" %>
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
     <table align="center" width="60%"  class="table table-striped">
    
    <thead>
       
   <tr>
   <th style="text-align: center" >   
       <span style="font-size: 14pt">
   MARUWA (MALAYSIA) SDN BHD </span>
   </th>               
   </tr>
   </thead>
   <tbody>
   <tr>
   <td style="height: 16px; text-align: center">   
       <span style="font-size: 12pt">
   Candidate Registration Form </span>
   </td>               
   </tr>
       <tr>
           <td>
               <asp:Label ID="Label8" runat="server" Font-Bold="True"></asp:Label></td>
       </tr>
       <tr>
           <td>
               <asp:Label ID="Label7" runat="server" Font-Bold="True">Date /Tarikh: </asp:Label>
               <asp:Label ID="Label5" runat="server" Font-Bold="True"></asp:Label></td>
       </tr>
       <tr>
           <td>
           </td>
       </tr>
     <tr>
   <td style="height: 32px; text-align: center">   
       <span style="font-size: 12pt">
Candidate Application
           <br />
           <em><span style="font-size: 11pt">Pengisthiyaran Mingguan (Isnin) oleh Pekerja /Kontraktor/ Pelawat</span></em></span><em><span style="font-size: 11pt"> </span>
           </em>
   </td>               
   </tr>
       <tr>
           <td>
               </td>
       </tr>
   
   <tr>
   <td>
   <label  class="col-form-label">Candidate Name:</label><br />
   <asp:TextBox class="form-control" ID="CandidateName" readonly="False" runat="server" Width="60%"></asp:TextBox>&nbsp;
   </td>
   </tr>
   
   <tr>
   <td>
   <label  class="col-form-label">IC Number:</label><br />
   <asp:TextBox class="form-control" ID="icno" runat="server" Width="60%"></asp:TextBox>
       <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="icno"
           ErrorMessage="* Please enter IC Number"></asp:RequiredFieldValidator></td>
   </tr> 
   
     <tr>
   <td>
   <label  class="col-form-label">Contact Number:</label><br />
   <asp:TextBox class="form-control" ID="ContactNo" runat="server" Width="60%"></asp:TextBox>
       <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="ContactNo"
           ErrorMessage="* Please enter Contact number"></asp:RequiredFieldValidator></td>
   </tr>   
   <tr>
   <td>
    <label  class="col-form-label">Position:</label><br />
       <asp:DropDownList class="form-control" ID="DropDownList1" runat="server" Width="60%">
       </asp:DropDownList>
       </td> 
   </tr>         
         
     <tr>
   <td>
       <label  class="col-form-label">Applied On:</label><br />
       <cc1:CalendarExtender
           id="CalendarExtender1" runat="server" format="dd/MMM/yyyy"
           popupbuttonid="AppliedOn" targetcontrolid="AppliedOn">
       </cc1:CalendarExtender>
       <asp:ScriptManager ID="ScriptManager1" runat="server">
       </asp:ScriptManager>
       <asp:TextBox class="form-control" ID="AppliedOn" runat="server" Width="60%" Visible="True"></asp:TextBox></td> 
       
   </tr> 
   
   <tr>
   <td>
       <label  class="col-form-label">Scheduled On:</label><br />
       <cc1:CalendarExtender
           id="CalendarExtender2" runat="server" format="dd/MMM/yyyy"
           popupbuttonid="ScheduledOn" targetcontrolid="ScheduledOn">
       </cc1:CalendarExtender>       
       <asp:TextBox class="form-control" ID="ScheduledOn" runat="server" Width="60%" Visible="True"></asp:TextBox>
       
       
      </td>       
   </tr>
             <tr>
   <td>
       <label  class="col-form-label">Upload Resume & Certificate :</label><br />
       <label  class="col-form-label">Resume :</label><br /><asp:FileUpload ID="FileUpload1" runat="server" Width="60%" />
       <label  class="col-form-label">Certificate :</label><br /><asp:FileUpload ID="FileUpload2" runat="server" Width="60%" />
       
   </td>
                 
   </tr> 
       <tr>
           <td style="height: 16px">
               <asp:Label ID="Label6" runat="server" Font-Bold="True"></asp:Label></td>
       </tr>
   <tr>
   <td> <asp:Button id="Button1" runat="server"  class="book-now-btn1"  text="Submit" ></asp:Button></td>
   
   </tr>
    </tbody>
           
        </table>
    </div>
  
        
     
    </form>
</body>
</html>
