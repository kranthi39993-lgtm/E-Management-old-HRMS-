<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="EvaluationView.aspx.vb" Inherits="E_Management.EvaluationView" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="Head1" runat="server">
    <title>FORM B </title>
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
                <asp:LinkButton ID="LinkButton2" runat="server" ForeColor="Blue">View</asp:LinkButton>
                &nbsp; &nbsp; &nbsp;&nbsp;&nbsp;&nbsp;<asp:LinkButton ID="LinkButton1" runat="server" ForeColor="Blue">Logout</asp:LinkButton></th>
        </tr>
   <tr>
   <th style="text-align: center; width: 664px;"  colspan="6">   
       <span style="font-size: 14pt">
   MARUWA  </span><br/><span style="font-size: 8pt">
   MARUWA (M) SDN.BHD.</span><br/><br />
    <span style="font-size: 10pt">
   EVALUATION ON WORKING ENVIRONMENT </span><br />
   <span style="font-size: 9pt">
   (Engineer and Officer above)</span>
   </th>               
   </tr>
   </thead>
   <tbody>
         
       <tr>
           <td>
           <asp:Label ID="Label8" runat="server" Font-Bold="True">Nama / Name : </asp:Label>
           <asp:TextBox class="form-control" ID="TxtName" readonly="True" runat="server" Width="60%"></asp:TextBox>&nbsp; 
           <asp:Label ID="Label5" runat="server" Font-Bold="True">New IC No.   : </asp:Label>
           <asp:TextBox class="form-control" ID="TxtIcNo" readonly="True" runat="server" Width="60%"></asp:TextBox>&nbsp; 
               <asp:Label ID="Label7" runat="server" Font-Bold="True">Date / Tarikh  : </asp:Label>
               <cc1:CalendarExtender
           id="Calendarextender2" runat="server" format="dd/MMM/yyyy"
           popupbuttonid="TxtDate" targetcontrolid="TxtDate">
       </cc1:CalendarExtender>
          <asp:ScriptManager ID="ScriptManager1" runat="server">
       </asp:ScriptManager>
               <asp:TextBox class="form-control" ID="TxtDate" readonly="True" runat="server" Width="60%"></asp:TextBox>&nbsp;                
       
       </td>
       </tr>
          
          <tr>
   <td>
   <label  class="col-form-label" style="width: 60%">A) Sila beritahu pendapat sebenar anda mengenai soalan yg dinyatakan di bawah.</label>&nbsp; &nbsp;<br />
   <label  class="col-form-label" style="width: 60%">A) Please express your opinion on the question stated.<br /></label>&nbsp; &nbsp;<br />
       <label  class="col-form-label" style="width: 60%">1. In your opinion, what do you feel about working long hours, beyond your official working hours?</label>&nbsp; &nbsp;<br />
       <asp:CheckBox Text="a. Should be compensate (OT or any other form)irrespective of any position." ID="ChBx1a" runat="server" AutoPostBack="True" Enabled="False" />&nbsp; &nbsp;<br />
       <asp:CheckBox Text="b. I would complete my work in time and dont believe in long hours working." ID="ChBx1b" runat="server" AutoPostBack="True" Enabled="False" />&nbsp; &nbsp;<br />
       <asp:CheckBox Text="c. Whatever time is required of me I dont working long hours." ID="ChBx1c" runat="server" AutoPostBack="True" Enabled="False" />&nbsp; &nbsp;<br />
       <asp:CheckBox Text="d. If possible, I would prefer stipulated working hours only." ID="ChBx1d" runat="server" AutoPostBack="True" Enabled="False" />&nbsp; &nbsp;<br />
       
       <label  class="col-form-label" style="width: 60%"><b>Please explain the reason you choose the above answer or any other opinion you would like to share with us.</b></label>&nbsp; &nbsp;<br />
       <asp:TextBox  class="form-control" ID="TxtOne" runat="server" TextMode="MultiLine" ReadOnly="True" ></asp:TextBox>
   </td>
   </tr> 
   
    <tr>
   <td>
      <label  class="col-form-label" style="width: 60%">2. Can you work in any of the following working conditions? Please tick YES or NO.<br /></label>&nbsp; &nbsp;<br />
       <label  class="col-form-label" style="width: 60%">a. Air conditioned area</label>
       <asp:RadioButton Text="Yes" ID="RBtn2a" runat="server" class="form-control" GroupName="2a" Width="60%" Enabled="False" /><asp:RadioButton ID="RBtn2a1"  Text="No" 
           runat="server"  class="form-control" GroupName="2a" Width="60%" Enabled="False"/>
       <label  class="col-form-label" style="width: 60%">b.Dusty and noisy environment.</label>
       <asp:RadioButton Text="Yes" ID="RBtn2b" runat="server" class="form-control" GroupName="2b" Width="60%" Enabled="False" /><asp:RadioButton ID="RBtn2b1"  Text="No" 
           runat="server"  class="form-control" GroupName="2b" Width="60%" Enabled="False"/>
       <label  class="col-form-label" style="width: 60%">c. Extreme hot areas.</label>
       <asp:RadioButton Text="Yes" ID="Rbtn2c" runat="server" class="form-control" GroupName="2c" Width="60%" Enabled="False" /><asp:RadioButton ID="Rbtn2c1"  Text="No" 
           runat="server"  class="form-control" GroupName="2c" Width="60%" Enabled="False"/>
       <label  class="col-form-label" style="width: 60%">d. Very wet condition.</label>
       <asp:RadioButton Text="Yes" ID="Rbtn2d" runat="server" class="form-control" GroupName="2d" Width="60%" Enabled="False" /><asp:RadioButton ID="Rbtn2d1"  Text="No" 
           runat="server"  class="form-control" GroupName="2d" Width="60%" Enabled="False"/>
       <label  class="col-form-label" style="width: 60%">e. Area with strong chemical odour.</label><br />
       <asp:RadioButton Text="Yes" ID="Rbtn2e" runat="server" class="form-control" GroupName="2e" Width="60%" Enabled="False" /><asp:RadioButton ID="Rbtn2e1"  Text="No" 
           runat="server"  class="form-control" GroupName="2e" Width="60%" Enabled="False"/><br />&nbsp; &nbsp;<br />
       <label  class="col-form-label" style="width: 60%"><b>If no, please state the reason why.</b></label>&nbsp; &nbsp;<br />
       <asp:TextBox  class="form-control" ID="TxtTwo" runat="server" TextMode="MultiLine" ReadOnly="True" ></asp:TextBox>
   </td>
   </tr>
   
    <tr>
   <td>
   <label  class="col-form-label" style="width: 60%">3. When someone criticized you , how would you describe four feeling towards that person?</label>&nbsp; &nbsp;<br />
   <asp:CheckBox Text="a. Angry." ID="ChBx3a" runat="server" AutoPostBack="True" Enabled="False" />&nbsp; &nbsp;<br />
   <asp:CheckBox Text="b.Stupefied(Shocked)" ID="ChBx3b" runat="server" AutoPostBack="True" Enabled="False" />&nbsp; &nbsp;<br />
       <asp:CheckBox Text="c. Shamed" ID="ChBx3c" runat="server" AutoPostBack="True" Enabled="False" />&nbsp; &nbsp;<br />
       <asp:CheckBox Text="d. Sensitive" ID="ChBx3d" runat="server" AutoPostBack="True" Enabled="False" />&nbsp; &nbsp;<br />
       
       <label  class="col-form-label" style="width: 60%"><b> How would you react to the above? Describe in your own words</b></label>&nbsp; &nbsp;<br />
       <asp:TextBox  class="form-control" ID="TxtThree" runat="server" TextMode="MultiLine" ReadOnly="True" ></asp:TextBox>
   </td>
   </tr> 
   
   <tr>
   <td>
   <label  class="col-form-label" style="width: 60%">4. In a meeting,your superior admonishes you publicly about your weakness and shortcomings, what do think about your superiors behaviour and action?</label>&nbsp; &nbsp;<br />
   
   <asp:CheckBox Text="a. Very inappropriate behavior of a boss even if I am wrong." ID="ChBx4a" runat="server" AutoPostBack="True" Enabled="False" />&nbsp; &nbsp;<br />
   <asp:CheckBox Text="b. Agree about being scolded but not in public." ID="ChBx4b" runat="server" AutoPostBack="True" Enabled="False" />&nbsp; &nbsp;<br />
   <asp:CheckBox Text="c. I dont mind whether public or not if the mistake is mine. " ID="ChBx4c" runat="server" AutoPostBack="True" Enabled="False" />&nbsp; &nbsp;<br />    
   <asp:CheckBox Text="d. I dont care whether he scolded me,boss always right" ID="ChBx4d" runat="server" AutoPostBack="True" Enabled="False" />&nbsp; &nbsp;<br />    
       
       <label  class="col-form-label" style="width: 60%"><b> Please explain your opinion</b></label>&nbsp; &nbsp;<br />
       <asp:TextBox  class="form-control" ID="TxtFour" runat="server" TextMode="MultiLine" ReadOnly="True" ></asp:TextBox>
   </td>
   </tr>
   
   
   <tr>
   <td>
   <label  class="col-form-label" style="width: 60%">5. A situation arises when your section head ask you to complete a task by 5 PM. While half way through completion,Your department Head shows up and requires status reports,which have to be faxed to HQ by 7PM on the same day.You know it will take 1 hour to collect data,compile  and fax the report.You have also promised your wife that you will pick up her at 5:15 pm.Now you are jammed.What Priorities,plans and action to overcome this situation?Describe and explain briefly.</label>&nbsp; &nbsp;<br />
    <asp:TextBox  class="form-control" ID="TxtFive" runat="server" TextMode="MultiLine" ReadOnly="True" ></asp:TextBox>
   </td>
   </tr>
   
   <tr>
   <td>
   <label  class="col-form-label" style="width: 60%">6. Your job description does not require or specify that you need to be clean ,sweep  or mop your workplace or its surrounding area but you find workers in this company practicing it.What would you do?</label>&nbsp; &nbsp;<br />
   <asp:CheckBox Text="a. Ignore them and concentrate on descript task." ID="ChBx6a" runat="server" AutoPostBack="True" Enabled="False" />&nbsp; &nbsp;<br />    
   <asp:CheckBox Text="b. Advice the company to hire the cleaners." ID="ChBx6b" runat="server" AutoPostBack="True" Enabled="False" />&nbsp; &nbsp;<br />    
   <asp:CheckBox Text="c. I dont like menial work" ID="ChBx6c" runat="server" AutoPostBack="True" Enabled="False" />&nbsp; &nbsp;<br />    
   <asp:CheckBox Text="d. Join the workers maybe it is the culture" ID="ChBx6d" runat="server" AutoPostBack="True" Enabled="False" />&nbsp; &nbsp;<br />        
       
       <label  class="col-form-label" style="width: 60%"><b> Please Explain your choice.</b></label>&nbsp; &nbsp;<br />
       <asp:TextBox  class="form-control" ID="TxtSix" runat="server" TextMode="MultiLine" ReadOnly="True" ></asp:TextBox>
   </td>
   </tr>
   
   <tr>
   <td>
   <label  class="col-form-label" style="width: 60%">7. Innitially you were appointed as Production Supervisor due to knowledge, expertise and past experience and past experience in your former company A year later you were informed that you might be transfer to purchasing department as a purchaser. There are no changes in salary status and have neither knowledge nor experience in this field. What would you do or react? </label>&nbsp; &nbsp;<br />
   <asp:CheckBox Text="a) Immediately see you superior and try to stop this transfer." ID="ChBx7a" runat="server" AutoPostBack="True" Enabled="False" />&nbsp; &nbsp;<br />        
   <asp:CheckBox Text="b) Explain to your superior you were appointed as supervisor and not purchaser." ID="ChBx7b" runat="server" AutoPostBack="True" Enabled="False" />&nbsp; &nbsp;<br />        
   <asp:CheckBox Text="c) Accept the transfer as you dont have a choice" ID="ChBx7c" runat="server" AutoPostBack="True" Enabled="False" />&nbsp; &nbsp;<br />            
   <asp:CheckBox Text="d) Fearfull of not being able to perform the new task." ID="ChBx7d" runat="server" AutoPostBack="True" Enabled="False" />&nbsp; &nbsp;<br />                
   <asp:CheckBox Text="e) Accept the transfer and look forward for the new challange." ID="ChBx7e" runat="server" AutoPostBack="True" Enabled="False" />&nbsp; &nbsp;<br />                       
       
   </td>
   </tr>
   
   <tr>
   <td>
   <label  class="col-form-label" style="width: 60%"><b> 8. If given the opportunity to join our organization,explain how and what you can contribute for the growth of this company?</b></label>&nbsp; &nbsp;<br />
       <asp:TextBox class="form-control" ID="TxtEight" runat="server" TextMode="MultiLine" ReadOnly="True" ></asp:TextBox>
   </td>
   </tr> 
   
   <tr>
           <td style="height: 16px">
               <asp:Label ID="Label6" runat="server" Font-Bold="True"></asp:Label></td>
       </tr>
   
   <tr>
   <td> <asp:Button id="Button1" runat="server"  class="book-now-btn1"  text="Submit" Enabled="False" Visible="False" ></asp:Button>
   
   </td>
   </tr>
    </tbody>
   </table>
     
    </div>
  
        
     
    </form>
</body>
</html>

