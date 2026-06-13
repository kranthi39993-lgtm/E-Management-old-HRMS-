<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="covid19dailydeclaration.aspx.vb" Inherits="E_Management.covid19dailydeclaration" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="Head1" runat="server">
    <title>Covid19 Declaration</title>
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
        &nbsp;<asp:ScriptManager ID="ScriptManager1" runat="server">
       </asp:ScriptManager>
    <div class="container">
     <table align="center" width="60%"  class="table table-striped">
    
    <thead>
        <tr>
            <th style="height: 16px; text-align: right">
                <asp:LinkButton ID="LinkButton3" runat="server" ForeColor="Blue">Daily Report</asp:LinkButton>&nbsp; 
                <asp:LinkButton ID="LinkButton2" runat="server" ForeColor="Blue">Weekly Report</asp:LinkButton>
                &nbsp; &nbsp;<asp:LinkButton ID="LinkButton1" runat="server" ForeColor="Blue">Logout</asp:LinkButton></th>
        </tr>
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
   COVID19 PREVENTION MEASURES </span>
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
   Daily Declaration by Employee / Contractor / Visitor 
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
   <label  class="col-form-label">Employee Code:</label><br />
   <asp:TextBox class="form-control" ID="empcode" readonly="true" runat="server" Width="60%"></asp:TextBox>&nbsp;
   </td>
   </tr>
   
   <tr>
   <td>
   <label  class="col-form-label">Employee Name:</label><br />
   <asp:TextBox class="form-control" ID="empname" ReadOnly="true" runat="server" Width="60%"></asp:TextBox>
   </td>
   </tr>
   
     <tr>
   <td>
   <label  class="col-form-label">Handphone Number:</label><br />
   <asp:TextBox class="form-control" ID="php" runat="server" Width="60%"></asp:TextBox>
       <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="php"
           ErrorMessage="* Please enter handphone number"></asp:RequiredFieldValidator></td>
   </tr>
       
        <tr>
   <td>
   <label  class="col-form-label">IC Number:</label><br />
   <asp:TextBox class="form-control" ID="icno" runat="server" Width="60%"></asp:TextBox>
       <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="icno"
           ErrorMessage="* Please enter IC Number"></asp:RequiredFieldValidator></td>
   </tr> 
   
        <%--  <tr>
   <td>
   <label  class="col-form-label" style="width: 60%">1. Have you been tested positive or presumptively with COVID-19<br />
       &nbsp; &nbsp; <span style="font-size: 9pt">Adakan anda diuji positif atau dianggap positif COVID-19</span></label><br />
       <asp:RadioButton Text="Yes" ID="RadioButton1" runat="server" class="form-control" GroupName="1" Width="60%" /><asp:RadioButton ID="RadioButton2"  Text="No"
           runat="server"  class="form-control" GroupName="1" Width="60%"/>
   </td>
   </tr> 
   <tr>
   <td>
   <label  class="col-form-label" style="width: 60%">2. Have you travelled abroad ( to any country outside Malaysia) in the past 14 days<br />
       &nbsp; &nbsp; <span style="font-size: 9pt; width: 60%;">Adakah anda pernah keluar negara ( kemana-mana negara diluar Malaysia) dalam tempoh 14 hari yang lepas.</span></label><br />
       <asp:RadioButton Text="Yes" ID="RadioButton3" runat="server" class="form-control" GroupName="2" Width="60%" /><asp:RadioButton ID="RadioButton4"  Text="No" 
           runat="server"  class="form-control" GroupName="2" Width="60%"/>
   </td>
   </tr> 
        
                  <tr>
   <td style="height: 149px">
   <label  class="col-form-label">3. Do you have flu-like symptoms (e.g. fever, cough etc.) <br />
       &nbsp; &nbsp; <span style="font-size: 9pt">Ada anda mempunyai simtom seperti selsema (contoh selesema, batuk dll)</span></label><br />
       <asp:RadioButton Text="Yes" ID="RadioButton5" runat="server" class="form-control" GroupName="3" Width="60%" /><asp:RadioButton ID="RadioButton6"  Text="No" 
           runat="server"  class="form-control" GroupName="3" Width="60%"/>
   </td>
   </tr> 
   --%>
                <tr>
   <td>
   <label  class="col-form-label">1. Did you, in the past 14 days, come in close contact with someone who <br />
       &nbsp; &nbsp; <span style="font-size: 9pt">Adakah anda, dalam tempoh 14 hari yang lepas berhubung rapat dengan seseorang<br />
       </span>
       <br />a) Is a confirmed COVID-19 case ; or 
       <br />
       &nbsp; &nbsp; <span style="font-size: 9pt">Yang sah positif COVID-19</span></label><br />
       <asp:RadioButton Text="Yes" ID="RadioButton7" runat="server" class="form-control" GroupName="4" Width="60%" /><asp:RadioButton ID="RadioButton8"  Text="No" 
           runat="server"  class="form-control" GroupName="4" Width="60%"/>
   </td>
   </tr> 
       <tr>
           <td style="height: 16px">
               <label  class="col-form-label">
                   b) Is a part of COVID-19 cluster<br />
                   &nbsp; &nbsp; <span style="font-size: 9pt">Terlibat dalam bahagian Kluster COVID-19</span></label></td>
       </tr>
       <tr>
           <td>
               <asp:RadioButton Text="Yes" ID="RadioButton13" runat="server" class="form-control" GroupName="4b" Width="60%" />
               <asp:RadioButton ID="RadioButton14"  Text="No" 
           runat="server"  class="form-control" GroupName="4b" Width="60%"/>
               
           </td>
       </tr>
      <%-- <tr>
           <td>
               <asp:RadioButton Text="Yes" ID="RadioButton15" runat="server" class="form-control" GroupName="5" Width="60%" /><asp:RadioButton ID="RadioButton16"  Text="No" 
           runat="server"  class="form-control" GroupName="5" Width="60%"/></td>
       </tr>
   
            <tr>
   <td>
   <label  class="col-form-label" style="width: 60%">6. Have you attended any gathering be it religious, family and other general gatherings at anytime during past 7 days, if yes <br />
       &nbsp; &nbsp; <span style="font-size: 9pt">Adakah anda pernah menghadiri apa-apa perjumpaan berunsur agama, antara keluarga terdekat dan sebagainya dalam tempoh 7 hari , kalau Ya</span></label><br />
       <asp:RadioButton Text="Yes" ID="RadioButton9" runat="server" class="form-control" GroupName="6" Width="60%" AutoPostBack="True" /><asp:RadioButton ID="RadioButton10"   Text="No" 
           runat="server"  class="form-control" GroupName="6" Width="60%" AutoPostBack="True"/>
           <br />
       <asp:Label ID="Label9" runat="server" Font-Bold="True" Font-Names="Arial" Text="IF Yes a) When attended / Tarikh Hadir" Visible="False"></asp:Label><br />
      
       <asp:TextBox class="form-control" ID="TextBox1" runat="server" Width="60%" Visible="False"></asp:TextBox>
       <asp:Label ID="Label1" runat="server" ForeColor="Red"></asp:Label><br />
       <asp:Label ID="Label10" runat="server" Font-Bold="True" Font-Names="Arial" Text="IF Yes b) Type of Gathering / Jeniis Perjumpaan" Visible="False"></asp:Label><br />
       <asp:TextBox class="form-control" ID="TextBox2" runat="server" Width="60%" Visible="False"></asp:TextBox><br />
       <asp:Label ID="Label2" runat="server" ForeColor="Red"></asp:Label></td>
   </tr> 
   --%>
             <tr>
   <td>
   <label  class="col-form-label" style="width: 60%">
       2. Did you make any movement beyond the NSC/MKN movement control radius of 10km </label><br />
          <asp:RadioButton Text="Yes" ID="RadioButton11" runat="server" class="form-control" GroupName="7" Width="60%" AutoPostBack="True" /><asp:RadioButton ID="RadioButton12"  Text="No" runat="server"  class="form-control" GroupName="7" Width="60%" AutoPostBack="True"/>
          <br />
       <asp:Label ID="Label11" runat="server" Font-Bold="True" Font-Names="Arial" Text="IF Yes a) When such movement was made" Visible="False"></asp:Label><br />
       <cc1:calendarextender
           id="Calendarextender2" runat="server" format="dd/MMM/yyyy"
           popupbuttonid="TextBox3" targetcontrolid="TextBox3">
       </cc1:CalendarExtender>
       <asp:TextBox class="form-control" ID="TextBox3" runat="server" Width="60%" Visible="False"></asp:TextBox><br />
       <asp:Label ID="Label3" runat="server" ForeColor="Red"></asp:Label><br />
       <asp:Label ID="Label12" runat="server" Font-Bold="True" Font-Names="Arial" Text="IF Yes b) Reason for such movement" Visible="False"></asp:Label><br />
       <asp:TextBox class="form-control" ID="TextBox4" runat="server" Width="60%" Visible="False"></asp:TextBox><br /><br />
       <asp:Label ID="Label4" runat="server" ForeColor="Red"></asp:Label></td>
   </tr> 
   
              <tr>
   <td>
   <label  class="col-form-label" style="width: 60%">
       <span style="font-size: 9pt">
           <asp:CheckBox ID="CheckBox1" runat="server" /><br />
           I declare that the above information is true and understand that diciplinary action can be taken against me for falsyfying or non declaration of essential information resulting in adverse impact to other employees and the organisation. I am aware and agreethat, if necessary, all or part of the above information will be shared with any enforcing government agencies related to this matter. 
           <br />
       </span>
       <br />
       <em><span style="font-size: 9pt">Dengan ini, saya mengaku bahawa maklumat di atas adalah benar, dan saya faham sepenuhnya bahawa tindakan disiplin akan diambil terhadap saya sekiranya terbukti memalsukan maklumat atau menyembunyikan maklumat yang berisiko memberi impak kepada pekerja lain dan juga syarikat. Saya sedia maklum dan bersetuju, maklumat ini akan dikongsi kepada pihak berkuasa / badan kerajaanberkaitan, sekiranya diperlukan.<br />
       </span></em>
   </label>
          
   </td>
   </tr> 
       <tr>
           <td style="height: 16px">
               <asp:Label ID="Label6" runat="server" Font-Bold="True"></asp:Label></td>
       </tr>
   
   <tr>
   <td> <asp:Button id="Button1" runat="server"  class="book-now-btn1"  text="Submit" ></asp:Button>
       <asp:Timer ID="Tmr" runat="server" Enabled="False" Interval="3000" OnTick="Tmr_Tick">
       </asp:Timer>
   </td>
   </tr>
    </tbody>
   </table>
   
   <table width="60%">
   <tr>
   <td style="text-align: center">
       <asp:GridView ID="GridView1" runat="server" CellPadding="4" ForeColor="Black" GridLines="Horizontal" Font-Names="Arial" Font-Size="8pt" BackColor="White" BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px">
           <FooterStyle BackColor="#CCCC99" ForeColor="Black" />
           <PagerStyle BackColor="White" ForeColor="Black" HorizontalAlign="Right" />
           <SelectedRowStyle BackColor="#CC3333" Font-Bold="True" ForeColor="White" />
           <HeaderStyle BackColor="#333333" Font-Bold="True" ForeColor="White" />
       </asp:GridView>
   </td></tr>
       
        </table>
    </div>
  
        
     
    </form>
</body>
</html>
