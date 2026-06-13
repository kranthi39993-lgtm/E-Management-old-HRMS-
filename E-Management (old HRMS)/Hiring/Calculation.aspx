<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="Calculation.aspx.vb" Inherits="E_Management.Calculation" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="Head1" runat="server">
    <title>Form A</title>
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
            <th style="height: 16px; text-align: right; width: 664px;"  colspan="6">
                <asp:LinkButton ID="LinkButton2" runat="server" ForeColor="Blue">Report</asp:LinkButton>
                &nbsp; &nbsp; &nbsp;&nbsp;&nbsp;&nbsp;<asp:LinkButton ID="LinkButton1" runat="server" ForeColor="Blue">Logout</asp:LinkButton></th>
        </tr>
   <tr>
   <th style="text-align: center; width: 664px;"  colspan="6">   
       <span style="font-size: 14pt">
   MARUWA  </span><br/><span style="font-size: 8pt">
   MARUWA (M) SDN.BHD.</span><br/><br />
   CALCULATION TEST
   
   
   </th>               
   </tr>
   </thead>
   <tbody>
   
       <tr>
           <td style="width: 664px" colspan="6">
               <asp:Label ID="Label8" runat="server" Font-Bold="True"></asp:Label></td>
       </tr>
       <tr>
           <td style="width: 664px" colspan="6">
               <asp:Label ID="Label7" runat="server" Font-Bold="True">Date /Tarikh: </asp:Label>
               <asp:Label ID="Label5" runat="server" Font-Bold="True"></asp:Label></td>
       </tr>
       <tr>
           <td style="width: 664px"  colspan="6">
           </td>
       </tr>
     <tr>
   <td style="height: 32px; text-align: center; width: 664px;"  colspan="6">   
       <span style="font-size: 12pt">
   Weekly (Monday) Declaration by Employee / Contractor / Visitor 
           <br />
           <em><span style="font-size: 11pt">Pengisthiyaran Mingguan (Isnin) oleh Pekerja /Kontraktor/ Pelawat</span></em></span><em><span style="font-size: 11pt"> </span>
           </em>
   </td>               
   </tr>
       <tr>
           <td style="width: 664px" colspan="6">
               </td>
       </tr>
   
   <tr>
   <td style="width: 664px" colspan="6">
   <label  class="col-form-label">Nama/Name  :</label><br />
   <asp:TextBox class="form-control" ID="TxtName" runat="server" width="60%"></asp:TextBox>&nbsp;
   </td>
   </tr>
   
   <tr>
   <td style="width: 664px" colspan="6">
   <label  class="col-form-label">New I/C No. :</label><br />
   <asp:TextBox class="form-control" ID="TxtIcNo"  runat="server" Width="60%"></asp:TextBox>
   </td>
   </tr>
   
      <tr>
   <td style="width: 664px" colspan="6">   
     <label  class="col-form-label">Tarikh/Date :</label><br />
       <cc1:CalendarExtender
           id="Calendarextender2" runat="server" format="dd/MMM/yyyy"
           popupbuttonid="TxtDate" targetcontrolid="TxtDate">
       </cc1:CalendarExtender>
          <asp:ScriptManager ID="ScriptManager1" runat="server">
       </asp:ScriptManager>
       <asp:TextBox class="form-control" ID="TxtDate" runat="server" Width="60%" Visible="True"></asp:TextBox>
       </td>
   </tr>
   
    <tr>
   <td style="width: 664px" colspan="6">
   <label  class="col-form-label" >A ) Kira dan tuliskan jawapan yang betul di kotak yang disediakan.<br/>A ) Culculate and write the answer on the box given.
 </label>
   
   </td>
   </tr>
   
   <tr>
   <td> <label  class="col-form-label">1) 22+23 =</label></td>
   <td style="width: 125px">  <asp:TextBox class="form-control" ID="TxtQuest1" runat="server" Width="60%" Visible="True"></asp:TextBox>
       <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="TxtQuest1"
           ErrorMessage="Please answer for Question 1" Font-Bold="True"></asp:RequiredFieldValidator></td>
   <td> <label  class="col-form-label">2) 22+66 =</label></td>
   <td style="width: 119px"> <asp:TextBox class="form-control" ID="TxtQuest2" runat="server" Width="60%" Visible="True"></asp:TextBox>
       <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="TxtQuest2"
           ErrorMessage="Please answer for Question 2" Font-Bold="True"></asp:RequiredFieldValidator></td>
   <td> <label  class="col-form-label">3) 40-6 =</label></td>
   <td style="width: 132px"> <asp:TextBox class="form-control" ID="TxtQuest3" runat="server" Width="60%" Visible="True"></asp:TextBox>
       <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="TxtQuest3"
           ErrorMessage="Please answer for Question 3" Font-Bold="True"></asp:RequiredFieldValidator></td>
   </tr>
   
       <tr>
   <td> <label  class="col-form-label">4) 100-19 = </label></td>
   <td style="width: 125px">  <asp:TextBox class="form-control" ID="TxtQuest4" runat="server" Width="60%" Visible="True"></asp:TextBox>
       <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="TxtQuest4"
           ErrorMessage="Please answer for Question 4" Font-Bold="True"></asp:RequiredFieldValidator></td>
   <td> <label  class="col-form-label">5) 50/2 =</label></td>
   <td style="width: 119px"> <asp:TextBox class="form-control" ID="TxtQuest5" runat="server" Width="60%" Visible="True"></asp:TextBox>
       <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ControlToValidate="TxtQuest5"
           ErrorMessage="Please answer for Question 5" Font-Bold="True"></asp:RequiredFieldValidator></td>
   <td> <label  class="col-form-label">6) 25 / 5 =</label></td>
   <td style="width: 132px"> <asp:TextBox class="form-control" ID="TxtQuest6" runat="server" Width="60%" Visible="True"></asp:TextBox>
       <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ControlToValidate="TxtQuest6"
           ErrorMessage="Please answer for Question 6" Font-Bold="True"></asp:RequiredFieldValidator></td>
   </tr>
     <tr>
   <td> <label  class="col-form-label">7) 0 x 10 = </label></td>
   <td style="width: 125px">  <asp:TextBox class="form-control" ID="TxtQuest7" runat="server" Width="60%" Visible="True"></asp:TextBox>
       <asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" ControlToValidate="TxtQuest7"
           ErrorMessage="Please answer for Question 7" Font-Bold="True"></asp:RequiredFieldValidator></td>
   <td> <label  class="col-form-label">8) 8 x 4 =</label></td>
   <td style="width: 119px"> <asp:TextBox class="form-control" ID="TxtQuest8" runat="server" Width="60%" Visible="True"></asp:TextBox>
       <asp:RequiredFieldValidator ID="RequiredFieldValidator8" runat="server" ControlToValidate="TxtQuest8"
           ErrorMessage="Please answer for Question 8" Font-Bold="True"></asp:RequiredFieldValidator></td>
   <td> <label  class="col-form-label">9) 20 x 3 =</label></td>
   <td style="width: 132px"> <asp:TextBox class="form-control" ID="TxtQuest9" runat="server" Width="60%" Visible="True"></asp:TextBox>
       <asp:RequiredFieldValidator ID="RequiredFieldValidator9" runat="server" ControlToValidate="TxtQuest9"
           ErrorMessage="Please answer for Question 9" Font-Bold="True"></asp:RequiredFieldValidator></td>
   </tr>
    
    <tr>
   <td> <label  class="col-form-label">10) 2.3 + 1.9 = </label></td>
   <td style="width: 125px">  <asp:TextBox class="form-control" ID="TxtQuest10" runat="server" Width="60%" Visible="True"></asp:TextBox>
       <asp:RequiredFieldValidator ID="RequiredFieldValidator10" runat="server" ControlToValidate="TxtQuest10"
           ErrorMessage="Please answer for Question 10" Font-Bold="True"></asp:RequiredFieldValidator></td>
   <td> <label  class="col-form-label">11) 4.7 - 1.8 =</label></td>
   <td style="width: 119px"> <asp:TextBox class="form-control" ID="TxtQuest11" runat="server" Width="60%" Visible="True"></asp:TextBox>
       <asp:RequiredFieldValidator ID="RequiredFieldValidator11" runat="server" ControlToValidate="TxtQuest11"
           ErrorMessage="Please answer for Question 11" Font-Bold="True"></asp:RequiredFieldValidator></td>
   <td> <label  class="col-form-label">12) 9.3 / 3 =</label></td>
   <td style="width: 132px"> <asp:TextBox class="form-control" ID="TxtQuest12" runat="server" Width="60%" Visible="True"></asp:TextBox>
       <asp:RequiredFieldValidator ID="RequiredFieldValidator12" runat="server" ControlToValidate="TxtQuest12"
           ErrorMessage="Please answer for Question 12" Font-Bold="True"></asp:RequiredFieldValidator></td>
   </tr>
     <tr>
   <td> <label  class="col-form-label">13) 4.5 + 0.067 = </label></td>
   <td style="width: 125px">  <asp:TextBox class="form-control" ID="TxtQuest13" runat="server" Width="60%" Visible="True"></asp:TextBox>
       <asp:RequiredFieldValidator ID="RequiredFieldValidator13" runat="server" ControlToValidate="TxtQuest13"
           ErrorMessage="Please answer for Question 13" Font-Bold="True"></asp:RequiredFieldValidator></td>
   <td> <label  class="col-form-label">14) 88.42 / 2 =</label></td>
   <td style="width: 119px"> <asp:TextBox class="form-control" ID="TxtQuest14" runat="server" Width="60%" Visible="True"></asp:TextBox>
       <asp:RequiredFieldValidator ID="RequiredFieldValidator14" runat="server" ControlToValidate="TxtQuest14"
           ErrorMessage="Please answer for Question 14" Font-Bold="True"></asp:RequiredFieldValidator></td>
   <td> <label  class="col-form-label">15) 9 + 11 + 16 =</label></td>
   <td style="width: 132px"> <asp:TextBox class="form-control" ID="TxtQuest15" runat="server" Width="60%" Visible="True"></asp:TextBox>
       <asp:RequiredFieldValidator ID="RequiredFieldValidator15" runat="server" ControlToValidate="TxtQuest15"
           ErrorMessage="Please answer for Question 15" Font-Bold="True"></asp:RequiredFieldValidator></td>
   </tr>
   <tr>
   <td> <label  class="col-form-label">16) 132 - 18 - 14 =</label></td>
   <td style="width: 125px">  <asp:TextBox class="form-control" ID="TxtQuest16" runat="server" Width="60%" Visible="True"></asp:TextBox>
       <asp:RequiredFieldValidator ID="RequiredFieldValidator16" runat="server" ControlToValidate="TxtQuest16"
           ErrorMessage="Please answer for Question 16" Font-Bold="True"></asp:RequiredFieldValidator></td>
   <td> <label  class="col-form-label">17) 144 / 12 / 4 =</label></td>
   <td style="width: 119px"> <asp:TextBox class="form-control" ID="TxtQuest17" runat="server" Width="60%" Visible="True"></asp:TextBox>
       <asp:RequiredFieldValidator ID="RequiredFieldValidator17" runat="server" ControlToValidate="TxtQuest17"
           ErrorMessage="Please answer for Question 17" Font-Bold="True"></asp:RequiredFieldValidator></td>
   <td> <label  class="col-form-label">18) 18 + 9 / 3 =</label></td>
   <td style="width: 132px"> <asp:TextBox class="form-control" ID="TxtQuest18" runat="server" Width="60%" Visible="True"></asp:TextBox>
       <asp:RequiredFieldValidator ID="RequiredFieldValidator18" runat="server" ControlToValidate="TxtQuest18"
           ErrorMessage="Please answer for Question 18" Font-Bold="True"></asp:RequiredFieldValidator></td>
   </tr>
   <tr>
   <td> <label  class="col-form-label">19) 50 - 5 x 5 =</label></td>
   <td style="width: 125px">  <asp:TextBox class="form-control" ID="TxtQuest19" runat="server" Width="60%" Visible="True"></asp:TextBox>
       <asp:RequiredFieldValidator ID="RequiredFieldValidator19" runat="server" ControlToValidate="TxtQuest19"
           ErrorMessage="Please answer for Question 19" Font-Bold="True"></asp:RequiredFieldValidator></td>
   <td> <label  class="col-form-label">20) 27 / (3 + 6) =</label></td>
   <td style="width: 119px"> <asp:TextBox class="form-control" ID="TxtQuest20" runat="server" Width="60%" Visible="True"></asp:TextBox>
       <asp:RequiredFieldValidator ID="RequiredFieldValidator20" runat="server" ControlToValidate="TxtQuest20"
           ErrorMessage="Please answer for Question 20" Font-Bold="True"></asp:RequiredFieldValidator></td>
   
   </tr>
   
    <tr>
   <td style="width: 664px" colspan="6">
   <label  class="col-form-label">B ) Baca soalan dengan teliti dan tuliskan jawapan yang betul.<br/>B ) Read the question below and write the answer on the box given.
 </label>
   
   </td>
   </tr>
   
   <tr>
   <td style="width: 664px" colspan="6">
   <label  class="col-form-label">21 ) Apakah bacaan di atas? &nbsp /  &nbsp What is the Measurement stated above? </label><br />
     <asp:TextBox class="form-control" ID="TxtQuest21" runat="server"></asp:TextBox>
       <asp:RequiredFieldValidator ID="RequiredFieldValidator21" runat="server" ControlToValidate="TxtQuest21"
           ErrorMessage="Please answer for Question 21" Font-Bold="True"></asp:RequiredFieldValidator>&nbsp;

   
   </td>
   </tr>
 
  <tr>
   <td style="width: 664px" colspan="6">
   <label  class="col-form-label">22 ) Di antara 0.10 dan 0.040 yang manakah lebih besar jumlahnya ?  &nbsp /  &nbsp Between 0.10 and 0.040 , Which one is Bigger ? </label><br />
     <asp:TextBox class="form-control" ID="TxtQuest22" runat="server" ></asp:TextBox>
       <asp:RequiredFieldValidator ID="RequiredFieldValidator22" runat="server" ControlToValidate="TxtQuest22"
           ErrorMessage="Please answer for Question 22" Font-Bold="True"></asp:RequiredFieldValidator>&nbsp;

   
   </td>
   </tr>
   
   <tr>
   <td style="width: 664px" colspan="6">
   <label  class="col-form-label">23 ) Sejumlah wang iaitu sebanyak RM 1680 dibahagi sama rata antara 4 orang adik beradik.Berapa ringgit kah setiap seorang  akan dapat bahagian?    &nbsp /  &nbsp    An amount of money with a total of RM1680 is been devided equally between 4 siblings.How many each one of them will get? </label><br />
     <asp:TextBox class="form-control" ID="TxtQuest23" runat="server" ></asp:TextBox>
       <asp:RequiredFieldValidator ID="RequiredFieldValidator23" runat="server" ControlToValidate="TxtQuest23"
           ErrorMessage="Please answer for Question 23" Font-Bold="True"></asp:RequiredFieldValidator>&nbsp;

   
   </td>
   </tr>
   
  <tr>
   <td style="width: 664px" colspan="6">
   <label class="col-form-label">24 ) Ada 5 buah lori kontena masuk ke dalam kilang.Setiap sebuah kontena mengandungi 100 kotak produk.Jika lebih daripada 20 kotak produk rosak kontena tersebut akan dipulangkan dan kontena yang pertama mengandungi 23 kotak yang rosak. Tiada produk yang rosak di kontena yang lain.  &nbsp /  &nbsp There were 5 container get into a factory.Every each container contained 100 box of product.If more than 20 box of product is defect that container will be return back. The first container had a total defect of 23 box.No defect product inside other container.<br /> <br /> a) Berapakah kontena yang akan dipulangkan? <br /> a) How much container will be returned?
</label> 
     <asp:TextBox class="form-control" ID="TxtQuest24a" runat="server" ></asp:TextBox>
       <asp:RequiredFieldValidator ID="RequiredFieldValidator24" runat="server" ControlToValidate="TxtQuest24a"
           ErrorMessage="Please answer for Question 24a" Font-Bold="True"></asp:RequiredFieldValidator>&nbsp;
       <br />
     <label  class="col-form-label">b) Berapa kontena yang akan diterima? <br /> b)How many container will be accepted ? </label>


     <asp:TextBox class="form-control" ID="TxtQuest24b" runat="server" ></asp:TextBox>
       <asp:RequiredFieldValidator ID="RequiredFieldValidator25" runat="server" ControlToValidate="TxtQuest24b"
           ErrorMessage="Please answer for Question 24b" Font-Bold="True"></asp:RequiredFieldValidator>&nbsp;

   
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
