F<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="ApplicationForm.aspx.vb" Inherits="E_Management.ApplicationForm" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="Head1" runat="server">
    <title>APPLICATION FORM</title>
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
            <th style="height: 16px; text-align: right" colspan="4">
                <asp:LinkButton ID="LinkButton2" runat="server" ForeColor="Blue">Report</asp:LinkButton>
                &nbsp; &nbsp; &nbsp;&nbsp;&nbsp;&nbsp;<asp:LinkButton ID="LinkButton1" runat="server" ForeColor="Blue">Logout</asp:LinkButton></th>
        </tr>
   <tr>
   <th style="text-align: center" colspan="4">   
       <span style="font-size: 14pt">
       
   MARUWA (MALAYSIA) SDN BHD. (191424-X) </span><br />
   Lot 2,3,4,27,28,29,30 &31,<br />
   Free Trade Zone, Phase 3,<br />
   Batu Berendam ,75350 Melaka.<br />
   Tel: 06-2883302 Fax:06-2814194<br />
   
   </th>               
   </tr>
   
    <tr>
    <th colspan="4">
  
    </th></tr>
    
   </thead>
   <tbody>
   <tr>
   <td style="height: 16px; text-align: LEFT" colspan="4">   
       <span style="font-size: 12pt">
    
           <asp:Label ID="Label13" runat="server"   >JAWATAN YANG DIPOHON /
   POSITION APPLIED </asp:Label>
           <asp:TextBox ID="Txtpos" runat="server"   class="form-control"  ></asp:TextBox> </span>
   </td>               
   </tr>
       <tr>
           <td colspan="4">
               <asp:Label    ID="Label8" runat="server" >Nama /Name :</asp:Label>
               <asp:TextBox  class="form-control"  ID="Txtname" runat="server"></asp:TextBox></td>
       </tr>
       <tr>
           <td colspan="4">
               <asp:Label    ID="Label5" runat="server" Text="Alamat / Address :"  ></asp:Label> 
               <asp:TextBox  class="form-control"  ID="Txtadd" runat="server" TextMode="MultiLine"  ></asp:TextBox>
               <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="Txtadd"
                   ErrorMessage="* Please enter your Address" Font-Bold="True"></asp:RequiredFieldValidator>
               </td>
       </tr>
       
<tr><td colspan="4">

    <asp:Label    ID="Label7" runat="server" >I/C No. New :</asp:Label>
    <asp:TextBox  class="form-control"  ID="Txticno" runat="server"  ></asp:TextBox>

</td>
</tr>
 <tr><td colspan="4">
     <asp:Label   ID="Label14" runat="server" >No.Telefon :</asp:Label>
     <asp:TextBox class="form-control"  ID="Txttele" runat="server" ></asp:TextBox>
     <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="Txttele"
         ErrorMessage="Please enter Telefon" Font-Bold="True"></asp:RequiredFieldValidator>
 </td>
 </tr>
   <asp:Label ID="Label12" runat="server" >LATARBELAKANG /PERSONAL PARTICULAR :</asp:Label><tr><td colspan="4">
       <asp:Label  ID="Label15" runat="server" >Jantina /Sex :</asp:Label></td>
       </tr>
       <tr>
       <td><asp:RadioButton class="form-control" TEXT= "Perempuan /Female" ID="rbdfmale" GroupName="1" runat="server" /></td>
       <td><asp:RadioButton class="form-control" text= "Lelaki /Male" ID="rbdmale" GroupName="1" runat="server" /></td>
   <td></td>
   <td style="width: 154px"></td>
   </tr>    
      <tr>
    <td colspan="4">
        <asp:Label  ID="Label16" runat="server" >Umur /Age :</asp:Label>
        <asp:TextBox class="form-control" ID="Txtage" runat="server"></asp:TextBox>
        <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="Txtage"
            ErrorMessage="Please enter Age" Font-Bold="True"></asp:RequiredFieldValidator>
    </td>
    </tr>
    <tr><td colspan="4">
        <asp:Label  ID="Label17" runat="server" >Height , Weight & BMI :</asp:Label>
        <asp:TextBox class="form-control" ID="Txthwb" runat="server"></asp:TextBox>
        <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="Txthwb"
            ErrorMessage="Please enter Your Height, Weight & BMI" Font-Bold="True"></asp:RequiredFieldValidator>
    </td>
    </tr>
    <tr>
    <td colspan="4">
            <asp:Label  ID="Label18" runat="server" >Warganegara /Nationality :</asp:Label>            
            </td>
            </tr>
            
            <tr>
         <td><asp:RadioButton class="form-control" text= "Malasiya" ID="rbdmala" GroupName="2" runat="server" /></td>
        <td><asp:RadioButton class="form-control" Text="Lain-Lain" ID="rbdlain" GroupName="2" runat="server" /></td>
        <td></td>
        <td style="width: 154px"></td>
    </tr>
    <tr><td colspan="4">
        <asp:Label  ID="Label19" runat="server" >Agama /Religion :</asp:Label>
        <asp:DropDownList  class="form-control" ID="DropDownList1" runat="server">
            <asp:ListItem>Muslim</asp:ListItem>
            <asp:ListItem>Hindu</asp:ListItem>
            <asp:ListItem>Christian</asp:ListItem>
            <asp:ListItem>Buddhist</asp:ListItem>
             <asp:ListItem>Jainism</asp:ListItem>
            
       
        </asp:DropDownList>
    </td>
    </tr>   
      <tr><td colspan="4">
          <asp:Label  ID="Label20" runat="server" >No.Cukai Pendapatan /Income Tax No. :</asp:Label>
          <asp:TextBox class="form-control" ID="Txtintax" runat="server"></asp:TextBox>
      </td>
      </tr>
<tr><td colspan="4">
    <asp:Label ID="Label21" runat="server" >Bangsa /Race :</asp:Label></td>
    </tr>
    <tr>
    <td><asp:RadioButton class="form-control" text= "Malay" ID="chkmalay" runat="server" groupName="14"/></td>
    <td><asp:RadioButton class="form-control" text= "Indian" ID="chkindia" runat="server" groupName="14" /></td>
    <td><asp:RadioButton class="form-control" text= "Chinese" ID="chkchinese" runat="server" groupName="14"/> </td>
   <td style="width: 154px"> <asp:RadioButton class="form-control" text= "Others Nyatakan" ID="chkothers" runat="server" groupName="14" /> 
</td></tr>
<tr><td colspan="4">
    <asp:Label  ID="Label22" runat="server" >No. Perkeso /Socso No</asp:Label>
    <asp:TextBox class="form-control" ID="Txtsosco" runat="server"></asp:TextBox>
</td></tr>
   <tr><td colspan="4">
       <asp:Label  ID="Label23" runat="server" >No EPF :</asp:Label>
       <asp:TextBox class="form-control" ID="Txtepf" runat="server"></asp:TextBox>
   </td></tr>    
       
   <tr><td colspan="4">
       <asp:Label  ID="Label24" runat="server" >Jarak sehala dari alamat kediaman ke maruwa (KM & Minit) /Distance from residence to Maruwa for single trip (KM & Minutes)</asp:Label>
       <asp:TextBox class="form-control" ID="Txtdist" runat="server"></asp:TextBox>
       <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ControlToValidate="Txtdist"
           ErrorMessage="Please enter distance" Font-Bold="True"></asp:RequiredFieldValidator>
   </td></tr> 
    <tr><td colspan="4">
        <asp:Label  ID="Label25" runat="server" >Pengangkutan Pilihan /Prefered Transportation :</asp:Label></td></tr>
        <tr>
        <td><asp:CheckBox class="form-control" text ="Own Sendiri /Nyatakan Jenis:" ID="chksendiri" runat="server" /></td>
        <td><asp:CheckBox class="form-control" text ="Syarikat /Company" ID="chksyarikat" runat="server" /></td>
        <td><asp:CheckBox class="form-control" text ="Asrama /Hostel" ID="chkasrama" runat="server" /></td>
        <td style="width: 154px"></td>
    </tr>   
     <tr><td colspan="4">
     <asp:Label  ID="Label26" runat="server" >Bahasa Pertuturan /Language Spoken :</asp:Label></td>
     </tr>
     <tr>
        <td><asp:CheckBox class="form-control" text="B.Melayu /Malay" ID="chkmalayi" runat="server" /></td>
        <td> <asp:CheckBox class="form-control" text ="B.Inggeris /English" ID="chkenglish" runat="server" /></td>
        <td> <asp:CheckBox class="form-control" text ="Tamil /Tamil" ID="chktamil" runat="server" /></td>
         <td style="width: 154px"><asp:CheckBox class="form-control" text ="Cina /Chinese" ID="chkchines" runat="server" /></td>
         
         </tr>  
      <tr><td colspan="4">
          <asp:Label  ID="Label27" runat="server" >Tarikh lahir /Date of Birth :</asp:Label>
          <cc1:CalendarExtender
           id="Calendarextender3" runat="server" format="dd/MMM/yyyy"
           popupbuttonid="Txtdob" targetcontrolid="Txtdob">
       </cc1:CalendarExtender>          
          <asp:TextBox class="form-control" ID="Txtdob" runat="server"></asp:TextBox>
          <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ControlToValidate="Txtdob"
              ErrorMessage="Please enter DOB" Font-Bold="True"></asp:RequiredFieldValidator>
      </td></tr>
      <tr><td colspan="4">
          <asp:Label  ID="Label28" runat="server">Tempat Lahir /Place Of Birth :</asp:Label>
          <asp:TextBox class="form-control" ID="Txtpob" runat="server"></asp:TextBox>
          <asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" ControlToValidate="Txtpob"
              ErrorMessage="Please enter POB" Font-Bold="True"></asp:RequiredFieldValidator>
     </td></tr> 
       
       <tr><td colspan="4">
           <asp:Label  ID="Label29" runat="server" >Saiz Uniform (S-5XL) Uniform Size (S-5XL) /Saiz Kasut (4-12) Shoes size (4-12) :</asp:Label></td>
          </tr> <tr>
           <td><asp:CheckBox class="form-control" text=" Seluar /Trousers" ID="chktrousers" runat="server" /></td>
           <td><asp:CheckBox class="form-control" text="Baju /Shirt" ID="chkshirt" runat="server" /></td>
           <td><asp:CheckBox class="form-control" text="Kasut /Shoe" ID="chkshoe" runat="server" /></td>
           <td style="width: 154px"> </td>
       </tr>
       <tr><td colspan="4">
           <asp:Label  ID="Label30" runat="server" >Taraf Perkahwinan /Marital Status :</asp:Label></td>
           </tr>
           <tr>
           <td><asp:RadioButton class="form-control" text="Bujang /Single" ID="chksingle" GroupName="3"  runat="server"/></td>
           <td><asp:RadioButton class="form-control" text="Kahwin /Married" ID="chkmarried" GroupName="3" runat="server" /></td>
           <td><asp:RadioButton class="form-control" text="Cerai /Divorced" ID="chkdivourse" GroupName="3" runat="server" /></td>
           <td style="width: 154px"></td>
           </tr>
      <tr><td>
      
      
      </td></tr> </tbody>
        </table>
        
        
        
        
         <table align="center" width="60%"  class="table table-striped">    
    <thead>
    <tr>
    <th colspan="6">
    <asp:Label class="form-control" ID="Label11" runat="server" >PENDIDIKAN /EDUCATION</asp:Label>
    </th></tr>
        <tr>
        <th style="height: 16px; text-align: left"><asp:Label  ID="Label10" runat="server" >Peringkat /Level</asp:Label></th>
        <th style="height: 16px; text-align: left"><asp:Label  ID="Label1" runat="server" >Nama Sekolah / Institusi Name of School / Institution</asp:Label></th>
        <th style="height: 16px; text-align: left"><asp:Label  ID="Label2" runat="server" >Kelulusan Tertinggi /Highest Std.Passed</asp:Label></th>
        <th style="height: 16px; text-align: left"><asp:Label ID="Label3" runat="server" >Tahun Mula /Joined</asp:Label></th>
        <th style="height: 16px; text-align: left"><asp:Label  ID="Label4" runat="server" >Tahun Akhir /Left</asp:Label></th>
        <th style="height: 16px; text-align: left"><asp:Label  ID="Label6" runat="server" >Aktiviti Sukan /Sports Activities</asp:Label></th>                
        </tr>        
     </thead>
     <tbody>
     
     <tr>
     <td><asp:Label ID="Label9" runat="server" >Rendah /Primary</asp:Label></td>
     <td><asp:TextBox class="form-control" ID="Txtedur1" runat="server"></asp:TextBox></td>
     <td><asp:TextBox class="form-control" ID="Txtedur2" runat="server"></asp:TextBox></td>
     <td><asp:TextBox class="form-control" ID="Txtedur3" runat="server"></asp:TextBox></td>
     <td><asp:TextBox class="form-control" ID="Txtedur4" runat="server"></asp:TextBox></td>
     <td><asp:TextBox class="form-control" ID="Txtr5" runat="server"></asp:TextBox></td>
     </tr>
     
     </tbody> 
     <tbody>
     
     <tr>
     <td><asp:Label  ID="Label31" runat="server" >Menengah /Secondary</asp:Label></td>
     <td><asp:TextBox class="form-control" ID="Txtsec1" runat="server"></asp:TextBox></td>
     <td><asp:TextBox class="form-control" ID="Txtsec2" runat="server"></asp:TextBox></td>
     <td><asp:TextBox class="form-control" ID="Txtsec3" runat="server"></asp:TextBox></td>
     <td><asp:TextBox class="form-control" ID="Txtsec4" runat="server"></asp:TextBox></td>
     <td><asp:TextBox class="form-control" ID="Txtsec5" runat="server"></asp:TextBox></td>
     </tr>
     
     </tbody>  
     
     
         <tbody>
     
     <tr>
     <td><asp:Label  ID="Label32" runat="server" >Kolej / Universiti / Lain-lain College / University / Others</asp:Label></td>
     <td><asp:TextBox class="form-control" ID="Txtuni1" runat="server"></asp:TextBox></td>
     <td><asp:TextBox class="form-control" ID="Txtuni2" runat="server"></asp:TextBox></td>
     <td><asp:TextBox class="form-control" ID="Txtuni3" runat="server"></asp:TextBox></td>
     <td><asp:TextBox class="form-control" ID="Txtuni4" runat="server"></asp:TextBox></td>
     <td><asp:TextBox class="form-control" ID="Txtuni5" runat="server"></asp:TextBox></td>
     </tr>
     
     </tbody>  
     
        <tbody>
     
     <tr>
     <td><asp:Label  ID="Label33" runat="server" >Kelayakan Lain Other Additional Certificate</asp:Label></td>
     <td><asp:TextBox class="form-control" ID="Txtcer1" runat="server"></asp:TextBox></td>
     <td><asp:TextBox class="form-control" ID="Txtcer2" runat="server"></asp:TextBox></td>
     <td><asp:TextBox class="form-control" ID="Txtcer3" runat="server"></asp:TextBox></td>
     <td><asp:TextBox class="form-control" ID="Txtcer4" runat="server"></asp:TextBox></td>
     <td><asp:TextBox class="form-control" ID="Txtcer5" runat="server"></asp:TextBox></td>
     </tr>
     
     </tbody></table>
        
  







  <table align="center" width="60%"  class="table table-striped">    
    <thead>
    <tr>
    <th colspan="7">
    <asp:Label class="form-control" ID="Label34" runat="server" >PENGALAMAN /EXPERIENCE</asp:Label>
    </th></tr>
        <tr>
        <th style="height: 16px; text-align: left"><asp:Label  ID="Label35" runat="server" >Nama dan Alamat Majikan</asp:Label></th>
        <th style="height: 16px; text-align: left"><asp:Label  ID="Label36" runat="server" >No. Telefon Tel. No.</asp:Label></th>
        <th style="height: 16px; text-align: left"><asp:Label  ID="Label37" runat="server" >Tarikh /Date</asp:Label></th>
        <th style="height: 16px; text-align: left"><asp:Label  ID="Label38" runat="server" >Nama Jawatan /Job Title</asp:Label></th>
        <th style="height: 16px; text-align: left"><asp:Label  ID="Label39" runat="server" >Tugas Duties</asp:Label></th>
        <th style="height: 16px; text-align: left"><asp:Label  ID="Label40" runat="server" >Gaji Terakhir Diterima /Last Drawn Salary</asp:Label></th>    
         <th style="height: 16px; text-align: left"><asp:Label  ID="Label41" runat="server" >Sebab Berhenti /Reason For Leaving</asp:Label></th> 
                    
      
        </tr>        
     </thead>
     
     <tbody>
     <tr>
             <td><asp:TextBox class="form-control" ID="Txtnama1" runat="server"></asp:TextBox></td>
             <td><asp:TextBox class="form-control" ID="Txttel1" runat="server"></asp:TextBox></td>
             <td><asp:TextBox class="form-control" ID="Txtdat1" runat="server"></asp:TextBox></td>
             <td><asp:TextBox class="form-control" ID="Txtjob1" runat="server"></asp:TextBox></td>
             <td><asp:TextBox class="form-control" ID="Txtdut1" runat="server"></asp:TextBox></td>
             <td><asp:TextBox class="form-control" ID="Txtsal1" runat="server"></asp:TextBox></td>
             <td><asp:TextBox class="form-control" ID="Txtleav1" runat="server"></asp:TextBox></td>
            
                                           
     </tr>
          <tr>
             <td><asp:TextBox class="form-control" ID="Txtnama2" runat="server"></asp:TextBox></td>
             <td><asp:TextBox class="form-control" ID="Txttel2" runat="server"></asp:TextBox></td>
             <td><asp:TextBox class="form-control" ID="Txtdat2" runat="server"></asp:TextBox></td>
             <td><asp:TextBox class="form-control" ID="Txtjob2" runat="server"></asp:TextBox></td>
             <td><asp:TextBox class="form-control" ID="Txtdut2" runat="server"></asp:TextBox></td>
             <td><asp:TextBox class="form-control" ID="Txtsal2" runat="server"></asp:TextBox></td>
             <td><asp:TextBox class="form-control" ID="Txtleav2" runat="server"></asp:TextBox></td>
                                           
     </tr>
          <tr>
             <td><asp:TextBox class="form-control" ID="Txtnama3" runat="server"></asp:TextBox></td>
             <td><asp:TextBox class="form-control" ID="Txttel3" runat="server"></asp:TextBox></td>
             <td><asp:TextBox class="form-control" ID="Txtdat3" runat="server"></asp:TextBox></td>
             <td><asp:TextBox class="form-control" ID="Txtjob3" runat="server"></asp:TextBox></td>
             <td><asp:TextBox class="form-control" ID="Txtdut3" runat="server"></asp:TextBox></td>
             <td><asp:TextBox class="form-control" ID="Txtsal3" runat="server"></asp:TextBox></td>
             <td><asp:TextBox class="form-control" ID="Txtleav3" runat="server"></asp:TextBox></td>
                                           
     </tr>
     </tbody>
     </table>
    
      <table align="center" width="60%"  class="table table-striped"> 
<tr>
     <th style="height: 16px; text-align: left" colspan="6">
    <asp:Label ID="Label43" runat="server" >ADDITIONAL INFORMATION /MAKLUMAT TAMBAHAN:</asp:Label>
    </th></tr>
    <tbody><tr>
     <td style="height: 16px; text-align: left" colspan="6">
     
    
      <asp:Label ID="Label42" runat="server" Text="Label">Adakah anda seorang perokok? /Are you a smoker?</asp:Label></td></tr>
       <tr> <td><asp:RadioButton class="form-control" text="Ya /Yes" ID="rbdsmoke" GroupName="4" runat="server" /></td>
        <td>
            <asp:RadioButton class="form-control" Text="Tidak /No" ID="rbdsmokeno" GroupName="4" runat="server"  /> </td>
     
 
 </tr>
 
 
   <tr><td colspan="6">
     <asp:Label  ID="Label44" runat="server" > Jika Ya ,Jumlah batang rokok yang dihisap sehari? /Number of cigarrates you took per day? :</asp:Label></td>
     </tr>
     <tr>
        <td><asp:RadioButton class="form-control" text="Kurang Dari 10 /Less than 10" ID="Chkcigar10" runat="server" groupName="15" /></td>
        <td> <asp:RadioButton class="form-control" text ="Antara 10-20 /Within 10-20" ID="Chkcigar20" runat="server" groupName="15"/></td>
        <td> <asp:RadioButton class="form-control" text ="Lebih dari 20 /More than 20" ID="Chkcigar30" runat="server" groupName="15"/></td>
         </tr>
   
   
   <tr><td colspan="3">
     <asp:Label  ID="Label45" runat="server" >Merokok adalah tidak dibenarkan sama sekali di Maruwa Adakah anda bersedia untuk berhenti merokok sekiranya ingin bekerja di Maruwa? </asp:Label></td>
     </tr>
     <tr>
        <td><asp:RadioButton class="form-control" text="Kurang Dari 10 /Less than 10" ID="Chkless" runat="server" groupName="16"/></td>
        <td> <asp:RadioButton class="form-control" text ="Antara 10-20 /Within 10-20" ID="Chkwithin" runat="server" groupName="16"/></td>
        <td> </td>
         </tr>
  
  </tbody></table> 
  
<table align="center" width="60%"  class="table table-striped"> 
 <tr><td colspan="5">
        <asp:Label  ID="Label46" runat="server" >Pernahkah anda alami sakit yang teruk seperti berikut? /Any serious illness previously as follows ?</asp:Label></td></tr>
        <tr>
        <td><asp:CheckBox class="form-control" text =" Asma/Asthma" ID="Chkasma" runat="server" /></td>
        <td><asp:CheckBox class="form-control" text =" Sakit belakang/Back pain" ID="Chkback" runat="server" /></td>
        <td><asp:CheckBox class="form-control" text ="  Alahan/Allergy" ID="Chkallergy" runat="server" /></td>
        <td><asp:CheckBox class="form-control" text ="  Migrain/Migraine" ID="Chkmig" runat="server" /></td>
        <td><asp:CheckBox class="form-control" text ="  Rabun" ID="Chkrabun" runat="server" /></td>
  </tr>
 <tr><td colspan="5">
        <asp:Label  ID="Label47" runat="server" >Pernahkah anda mengalami atau terlibat dalam kemalangan? /Have you ever experienced or been involved in an accident ?</asp:Label></td></tr>
        <tr>
        <td><asp:RadioButton  class="form-control" Text="Ya /Yes" ID="Rbdexpyes" runat="server" GroupName="5" /></td>
        <td><asp:RadioButton class="form-control" Text="Tidak /No" ID="Rbdexpno" GroupName="5" runat="server" /></td>
        
        <td></td>
        <td></td>
        <td></td>
  </tr>
 <tr><td colspan="5">
        <asp:Label  ID="Label48" runat="server" >Adakah anda mengambil ubatan bagi apa-apa penyakit ? /Are you taking medication for any illness ?</asp:Label></td></tr>
        <tr>
        <td><asp:RadioButton  class="form-control" Text="Ya /Yes" ID="Rbdmedyes" runat="server" GroupName="6" /></td>
        <td><asp:RadioButton  class="form-control" Text="Tidak /No" ID="Rbdmedno" GroupName="6" runat="server" /></td>
        <td></td>
        <td></td>
        <td></td>
  </tr>
  </table>
  
<table align="center" width="60%"  class="table table-striped"> 
  <tr><td>
      <asp:Label ID="Label49" runat="server" Text="Jika Ya nyatakan jenis penyakit yang dihidapai /if Yes, state type of illness suffer"></asp:Label>
      <asp:TextBox class="form-control" ID="Txtilness" runat="server"></asp:TextBox>
  </td>
  </tr>
  
  </table>
 <table align="center" width="60%"  class="table table-striped"> 
  <tr><td>
      <asp:Label ID="Label50" runat="server" Text="Adakah anda bercermin mata? /Do you wear glasses?"></asp:Label>
  </td>
  </tr>
  <tr ><td colspan="4">
  <asp:RadioButton  class="form-control" Text="Ya /Yes" ID="Rbdglassyes" runat="server" GroupName="7"  /></td>
        <td><asp:RadioButton  class="form-control" Text="Tidak /No" ID="Rbdglassno" GroupName="7" runat="server" Checked="true" /></td>
        <td></td>
        <td></td>
  
  </tr>
  
  <tr><td>
      <asp:Label ID="Label51" runat="server" Text="Penglihatan /Vision:"></asp:Label>
  
  </td></tr>
  <tr><td colspan="4">

        <asp:RadioButton class="form-control" text ="Normal" ID="Chknor" runat="server" /></td>
        <td><asp:RadioButton class="form-control" text ="Rabun Dekat /Near Sighted" ID="Chknear" runat="server" groupName="7"/></td>
        <td><asp:RadioButton class="form-control" text ="Rabun Jauh /Far Sighted" ID="Chkfar" runat="server" groupName="7"/></td>
        <td><asp:RadioButton class="form-control" text ="Rabun Warna /Colour Blind" ID="Chkblind" runat="server" groupName="7"/></td>
  
 </tr>
  
  
  
 </table>
 <table align="center" width="60%"  class="table table-striped"> 
  <tr><td colspan="2">
      <asp:Label ID="Label52" runat="server" Text="Adakah anda bersetuju bekerja shift? /Do you agree to work shift?"></asp:Label>
  </td></tr>
  <tr>
  
  <td><asp:RadioButton  class="form-control" Text="Ya /Yes" ID="Rbdagreeyes" runat="server" GroupName="8"  /></td>
  <td><asp:RadioButton  class="form-control" Text="Tidak /No" ID="Rbdagreeno" GroupName="8" runat="server"  /></td>
 </tr>
 <tr><td>
     <asp:Label ID="Label53" runat="server" Text="Adakah anda hamil? /Are you pregnant?"></asp:Label>
 </td></tr> 
  <tr>
   <td><asp:RadioButton  class="form-control" Text="Ya /Yes" ID="Rbdpregyes" runat="server" GroupName="9"  /></td>
  <td><asp:RadioButton  class="form-control" Text="Tidak /No" ID="Rbdpregno" GroupName="9" runat="server"  /></td>
  </tr>
  
  
  
  </table>
<table align="center" width="60%"  class="table table-striped"> 
  <tr><td colspan="2">
      <asp:Label ID="Label54" runat="server" Text="Pernahkah anda memohon atau kerja di MARUWA sebelum ini? /Have you ever applied or worked for MARUWA before?"></asp:Label><br />
      
      
      <asp:Label ID="Label68" runat="server" Text="Nyatakan nama dan jabatan yang keluarga atau kawan bekerja di MARUWA, jika ada."></asp:Label>
  </td></tr>
  
  <tr>
    <td><asp:RadioButton  class="form-control" Text="Ya /Yes" ID="Rbdworkyes" runat="server" GroupName="13"/></td>
  <td><asp:RadioButton  class="form-control" Text="Tidak /No" ID="Rbdworkno" GroupName="13" runat="server"   /></td>
  
  </tr>
  <tr><td>
      <asp:Label ID="Label55" runat="server" Text="If you have relatives or friends employed in MARUWA, please state the name and department?"></asp:Label>
      
        <asp:TextBox class="form-control" ID="Txtfriends" runat="server"></asp:TextBox>
      
      
  </td></tr>
  
   <tr><td>
       <asp:Label ID="Label56" runat="server" Text="Bilakah anda boleh mula bertugas di MARUWA? /When would you be able to join MARUWA."></asp:Label>
    <cc1:CalendarExtender
           id="Calendarextender2" runat="server" format="dd/MMM/yyyy"
           popupbuttonid="Txtjoin" targetcontrolid="Txtjoin">
       </cc1:CalendarExtender>
          <asp:ScriptManager ID="ScriptManager1" runat="server">
       </asp:ScriptManager> <asp:TextBox class="form-control" ID="Txtjoin" runat="server"></asp:TextBox>
       <asp:RequiredFieldValidator ID="RequiredFieldValidator8" runat="server" ControlToValidate="Txtjoin"
           ErrorMessage="Please enter DOJ" Font-Bold="True"></asp:RequiredFieldValidator>
  </td></tr>
  
   <tr><td>
       
       <asp:Label ID="Label57" runat="server" Text="Gaji minimum yang diharapkan? /Minimum expected salary?"></asp:Label>
  <asp:TextBox class="form-control" ID="Txtsal" runat="server"></asp:TextBox>
       <asp:RequiredFieldValidator ID="RequiredFieldValidator9" runat="server" ControlToValidate="Txtsal"
           ErrorMessage="Please enter expected salary" Font-Bold="True"></asp:RequiredFieldValidator>
       
  </td></tr>
  
  
</table>
<table align="center" width="60%"  class="table table-striped"> 
 <tr><td colspan="7">
 <asp:Label ID="Label58" runat="server" Text="Bagaimanakah anda tahu mengenaikek os ongan di MARUWA? /How do you know vacancies in MARUWA?"></asp:Label>
 </td></tr>
<tr>
       <td><asp:CheckBox class="form-control" text ="Iklan /Advertisement " ID="Chkad" runat="server" /></td>
        <td><asp:CheckBox class="form-control" text ="Banner<br> /Banner" ID="Chkbanner" runat="server" /></td>
        <td><asp:CheckBox class="form-control" text ="Kawan /Friend " ID="Chkfriend" runat="server" /></td>
        <td><asp:CheckBox class="form-control" text ="SocialMedia /Poste" ID="Chkposte" runat="server" /></td>
        <td><asp:CheckBox class="form-control" text ="PemanduBas /BusDriver" ID="Chkemp" runat="server" /></td>  
        <td><asp:CheckBox class="form-control" text ="PekerjaMARUWA /MARUWAEmployee" ID="Chkemploy" runat="server" /></td>
        <td><asp:CheckBox class="form-control" text ="Lain-lain /Others" ID="Chkotherss" runat="server" /></td>
 
 </tr>
</table> 
<table align="center" width="60%"  class="table table-striped"> 
<tr><td>


 <asp:Label ID="Label59" runat="server" Text="Jika kecemasan, sila hubungi : /If emergency, please contact:"></asp:Label>
    &nbsp;

</td></tr>

<tr><td>
 <asp:Label ID="Label61" runat="server" Text="Nama/Name:"></asp:Label><br />
<asp:TextBox class="form-control" ID="Txtnames" runat="server"></asp:TextBox>
    <asp:RequiredFieldValidator ID="RequiredFieldValidator10" runat="server" ControlToValidate="Txtnames"
        ErrorMessage="Please enter Name" Font-Bold="True"></asp:RequiredFieldValidator>
</td></tr>


<tr><td>
 <asp:Label ID="Label62" runat="server" Text="Alamat/Address"></asp:Label>

<asp:TextBox class="form-control" ID="Txtaddr" runat="server"></asp:TextBox>
    <asp:RequiredFieldValidator ID="RequiredFieldValidator11" runat="server" ControlToValidate="Txtaddr"
        ErrorMessage="Please enter Address" Font-Bold="True"></asp:RequiredFieldValidator>
</td></tr>
<tr><td>
 <asp:Label ID="Label63" runat="server" Text="No.Telefon/TelephoneNo:"></asp:Label>

<asp:TextBox class="form-control" ID="Txttelno" runat="server"></asp:TextBox>
    <asp:RequiredFieldValidator ID="RequiredFieldValidator12" runat="server" ControlToValidate="Txttelno"
        ErrorMessage="Please enter Telefon No" Font-Bold="True"></asp:RequiredFieldValidator>
</td></tr>
<tr><td>
 <asp:Label ID="Label64" runat="server" Text="Hubungan/Relationship"></asp:Label>

<asp:TextBox class="form-control" ID="Txtrelation" runat="server"></asp:TextBox>
    <asp:RequiredFieldValidator ID="RequiredFieldValidator13" runat="server" ControlToValidate="Txtrelation"
        ErrorMessage="Please enter Relationship" Font-Bold="True"></asp:RequiredFieldValidator>
</td></tr>
</table>
<table align="center" width="60%"  class="table table-striped"> 

<tr>
<td>

   <asp:Label ID="Label71" runat="server" >PENGAKUAN /DECLARATION:</asp:Label>
</td></tr><tr><td>
<asp:Label ID="Label60" runat="server" Text="Saya akui maklumat yang diberi adalah benar dan sekiranya maklumat itu didapati palsu, perkhidmatan saya boleh ditamatkan dengan serta merta atas peraturan syarikat. "></asp:Label><br />
<asp:Label ID="Label69" runat="server" Text=" Sekiranya saya diterima bekerja, saya bersedia untuk melaporkan diri pada tarikh yang ditetapkan."></asp:Label><br />

<asp:Label ID="Label65" runat="server" Text="I here by declare that the information is true and correct and if any false declaration is made by me ,my contract of service shall be terminated without notice ."></asp:Label>
<asp:Label ID="Label70" runat="server" Text="If Iam appointed for the job,I will report for duty on the stipulated date."></asp:Label>





</td></tr>
<tr>
<td>

<asp:Label ID="Label66" runat="server" Text="Tarikh: /Date:"></asp:Label>
<cc1:CalendarExtender
           id="Calendarextender1" runat="server" format="dd/MMM/yyyy"
           popupbuttonid="Txtdate" targetcontrolid="Txtdate">
       </cc1:CalendarExtender>          
<asp:TextBox class="form-control" ID="Txtdate" runat="server"></asp:TextBox>
    <asp:RequiredFieldValidator ID="RequiredFieldValidator14" runat="server" ControlToValidate="Txtdate"
        ErrorMessage="Please enter Date" Font-Bold="True"></asp:RequiredFieldValidator>

</td></tr>
<tr>
<td>
<asp:Label ID="Label67" runat="server" Text="Tandatangan Pemohon: /Applicant's Signature:"></asp:Label>

<asp:TextBox class="form-control" ID="Txtsig" runat="server"></asp:TextBox>

</td></tr>

</table>
 <table align="center" width="60%"  class="table table-striped">  
  <tr><td colspan="4">
  <asp:Label ID="Label72" runat="server" Text="LASAN PENEMUDUGA /INTERVIEWER COMMENT"></asp:Label><br /><br />
  
  
<asp:Label ID="Label73" runat="server" Text="Pannel 1"></asp:Label>
<asp:TextBox class="form-control" ID="Txtpan1" runat="server"></asp:TextBox>
  
  
  
  
  </td></tr>
   <tr>
  <td>  
<asp:Label ID="Label74" runat="server" Text="EmpID :"></asp:Label></td> 
<td><asp:TextBox class="form-control" ID="Txtempid1" runat="server"></asp:TextBox></td>
  <td>
<asp:Label ID="Label75" runat="server" Text="Emp Name :"></asp:Label></td> 
   
<td><asp:TextBox class="form-control" ID="Txtempname1" runat="server"></asp:TextBox></td>
 
   </tr>
   <tr><td><asp:Label ID="Label76" runat="server" Text="Propose To Hire ?"></asp:Label></td>
   <td><asp:RadioButton  class="form-control" Text="Ya /Yes" ID="Rbdyes1" GroupName="10" runat="server"   /></td>
   <td><asp:RadioButton  class="form-control" Text="Tidak /No" ID="Rbno1" GroupName="10" runat="server"   /></td>
   
   </tr>
   
   </table>
   
   
    <table align="center" width="60%"  class="table table-striped">  
  <tr><td colspan="4">
  
<asp:Label ID="Label77" runat="server" Text="Pannel 2"></asp:Label>
<asp:TextBox class="form-control" ID="Txtpan2" runat="server"></asp:TextBox>

  
  </td></tr>
   <tr>
  <td>  
<asp:Label ID="Label78" runat="server" Text="EmpID :"></asp:Label></td> 
<td><asp:TextBox class="form-control" ID="Txtempid2" runat="server"></asp:TextBox></td>
  <td>
<asp:Label ID="Label79" runat="server" Text="Emp Name :"></asp:Label></td> 
   
<td><asp:TextBox class="form-control" ID="Txtempname2" runat="server"></asp:TextBox></td>
 
   </tr>
   <tr><td><asp:Label ID="Label80" runat="server" Text="Propose To Hire ?"></asp:Label></td>
   <td><asp:RadioButton  class="form-control" Text="Ya /Yes" ID="Rbdyes2" GroupName="11" runat="server"   /></td>
   <td><asp:RadioButton  class="form-control" Text="Tidak /No" ID="Rbdno2" GroupName="11" runat="server"   /></td>
   
   </tr>
   
   </table>
    <table align="center" width="60%"  class="table table-striped">  
  <tr><td colspan="4">
  
<asp:Label ID="Label81" runat="server" Text="Pannel 3"></asp:Label>
<asp:TextBox class="form-control" ID="Txtpan3" runat="server"></asp:TextBox>
  
  
  
  
  </td></tr>
   <tr>
  <td>  
<asp:Label ID="Label82" runat="server" Text="EmpID :"></asp:Label></td> 
<td><asp:TextBox class="form-control" ID="Txtempid3" runat="server"></asp:TextBox></td>
  <td>
<asp:Label ID="Label83" runat="server" Text="Emp Name :"></asp:Label></td> 
   
<td><asp:TextBox class="form-control" ID="Txtempname3" runat="server"></asp:TextBox></td>
 
   </tr>
   <tr><td><asp:Label ID="Label84" runat="server" Text="Propose To Hire ?"></asp:Label></td>
   <td><asp:RadioButton  class="form-control" Text="Ya /Yes" ID="Rbdyes3" GroupName="12" runat="server"   /></td>
   <td><asp:RadioButton  class="form-control" Text="Tidak /No" ID="Rbdno3" GroupName="12" runat="server"   /></td>
   
   </tr>
   <tr>
           <td style="height: 16px">
               <asp:Label ID="Label85" runat="server" Font-Bold="True"></asp:Label></td>
       </tr>
   
   <tr>
   <td> <asp:Button id="Button1" runat="server"  class="book-now-btn1"  text="Submit" ></asp:Button>
   
   </td> </tr> 
   </table>
   
   
   </div>

   
   
   
    </form>
</body>
</html>
