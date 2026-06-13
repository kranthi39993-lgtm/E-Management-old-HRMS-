<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="InvoiceView.aspx.vb" Inherits="E_Management.InvoiceView" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Untitled Page</title>
</head>
<body>
    <form id="form1" runat="server">
    <div>    
    <table>
        <tr>
            <td colspan="2" style="background-color: #0066cc; text-align: center">
                <strong><span style="color: #ffffff">Invoice Details </span></strong>
            </td>
        </tr>
    <tr>
                        <td colspan="2">Invoice No:<asp:Label ID="lblInvoiceNumberInfo" runat="server"/>
                            <asp:Label ID="lblEmployeeCode" runat="server"></asp:Label></td>
                    </tr>
    <tr><td>Invoice [Original]</td><td>Invoice Changes</td></tr>
    <tr>

   <td align="left">
                    <table align="center" border="1px">
                  
                       <tr>
                        <td>Invoice No:</td><td ><span><asp:Label ID="lblViewInv" runat="server"/></span></td>
                    </tr>
                    <tr>
                        <td>CustomerID</td><td ><span id="lblcusid"><asp:Label ID="lblViewCustomerID" runat="server"/></span></td>
                    </tr>
                    <tr>
                        <td>CustomerName</td><td ><span id="lblCus"><asp:Label ID="lblViewCustomerName" runat="server" /></span></td>
                    </tr>
                    <tr>
                        <td>INVDate</td><td ><span id="lblind"><asp:Label ID="lblViewINVDate" runat="server"/></span></td>
                    </tr>
                     <tr>
                        <td>SoldTo</td><td><span id="Span1"><asp:Label ID="lblViewSoldTo" runat="server"/></span></td>
                    </tr>
                     <tr>
                        <td>Attn</td><td><span id="Span2"><asp:Label ID="lblViewAttn" runat="server"/></span></td>
                    </tr>
                     <tr>
                        <td>Tel</td><td><span id="Span3"><asp:Label ID="lblViewTel" runat="server"/></span></td>
                    </tr>
                     <tr>
                        <td>Fax</td><td><span id="Span4"><asp:Label ID="lblViewFax" runat="server"/></span></td>
                    </tr>
                     <tr>
                        <td>email</td><td><span id="Span5"><asp:Label ID="lblViewemail" runat="server"/></span></td>
                    </tr>
                     <tr>
                        <td>Tpallets</td><td><span id="Span6"><asp:Label ID="lblViewTpallets" runat="server"/></span></td>
                    </tr>
                     <tr>
                        <td>TCartons</td><td><span id="Span7"><asp:Label ID="lblViewTCartons" runat="server"/></span></td>
                    </tr>
                     <tr>
                        <td>TGWeight</td><td><span id="Span8"><asp:Label ID="lblViewTGWeight" runat="server"/></span></td>
                    </tr>
                     <tr>
                        <td>TNWeight</td><td><span id="Span9"><asp:Label ID="lblViewTNWeight" runat="server"/></span></td>
                    </tr>
                     <tr>
                        <td>Dimension</td><td><span id="Span10"><asp:Label ID="lblViewDimension" runat="server"/></span></td>
                    </tr>
                     <tr>
                        <td>TM3</td><td><span id="Span11"><asp:Label ID="lblViewTM3" runat="server"/></span></td>
                    </tr>
                   
                     <tr>
                        <td>ShipTerms</td><td><span id="Span13"><asp:Label ID="lblViewShipTerms" runat="server"/></span></td>
                    </tr>
                     <tr>
                        <td>ShipTo</td><td><span id="Span14"><asp:Label ID="lblViewShipTo" runat="server"/></span></td>
                    </tr>
                     <tr>
                        <td>ShipMode</td><td><span id="Span15"><asp:Label ID="lblViewShipMode" runat="server"/></span></td>
                    </tr>
                     <tr>
                        <td>ShippingMarks</td><td><span id="Span16"><asp:Label ID="lblViewShippingMarks" runat="server"/></span></td>
                    </tr>
                    
                     <tr>
                        <td>Destination</td><td><span id="Span17"><asp:Label ID="lblViewDestination" runat="server"/></span></td>
                    </tr>
                     <tr>
                        <td>Remarks</td><td><span id="Span18"><asp:Label ID="lblViewRemarks" runat="server"/></span></td>
                    </tr>
                    </table>        </td>
					<td align="right"> 
                    <table align="center" border="1px">
                      <tr>
                        <td style="text-align: left">Invoice No:</td><td style="text-align: left"><span><asp:Label ID="lblInv" runat="server"/></span></td>
                    </tr>
                    <tr>
                        <td style="text-align: left">CustomerID</td><td style="text-align: left"><span id="lblcust_id"><asp:Label ID="lblCustomerID" runat="server"/></span></td>
                    </tr>
                    <tr>
                        <td style="text-align: left">CustomerName</td><td style="text-align: left"><span id="lblCustomer"><asp:Label ID="lblCustomerName" runat="server"/></span></td>
                    </tr>
                    <tr>
                        <td style="text-align: left">INVDate</td><td style="text-align: left"><span id="lblinedd"><asp:Label ID="lblINVDate" runat="server"/></span></td>
                    </tr>
                     <tr>
                        <td style="text-align: left">SoldTo</td><td id="rmSoldTo" runat="Server" style="text-align: left"><span id="Span12"><asp:Label ID="lblSoldTo" runat="server"/></span></td>
                    </tr>
                     <tr>
                        <td style="text-align: left">Attn</td><td id="rmAttn" runat="Server" style="text-align: left"><span id="Span19"><asp:Label ID="lblAttn" runat="server"/></span></td>
                    </tr>
                     <tr>
                        <td style="text-align: left">Tel</td><td id="rmTel" runat="Server" style="text-align: left"><span id="Span20"><asp:Label ID="lblTel" runat="server"/></span></td>
                    </tr>
                     <tr>
                        <td style="text-align: left">Fax</td><td id="rmFax" runat="Server" style="text-align: left"><span id="Span21"><asp:Label ID="lblFax" runat="server"/></span></td>
                    </tr>
                     <tr>
                        <td style="text-align: left">email</td><td id="rmemail" runat="Server" style="text-align: left"><span id="Span22"><asp:Label ID="lblemail" runat="server"/></span></td>
                    </tr>
                     <tr>
                        <td style="text-align: left">Tpallets</td><td id="rmTpallets" runat="Server" style="text-align: left"><span id="Span23"><asp:Label ID="lblTpallets" runat="server"/></span></td>
                    </tr>
                     <tr>
                        <td style="text-align: left">TCartons</td><td id="rmTCartons" runat="Server" style="text-align: left"><span id="Span24"><asp:Label ID="lblTCartons" runat="server"/></span></td>
                    </tr>
                     <tr>
                        <td style="text-align: left">TGWeight</td><td id="rmTGWeight" runat="Server" style="text-align: left"><span id="Span25"><asp:Label ID="lblTGWeight" runat="server"/></span></td>
                    </tr>
                     <tr>
                        <td style="text-align: left">TNWeight</td><td id="rmTNWeight" runat="Server" style="text-align: left"><span id="Span26"><asp:Label ID="lblTNWeight" runat="server"/></span></td>
                    </tr>
                     <tr>
                        <td style="text-align: left">Dimension</td><td id="rmDimension" runat="Server" style="text-align: left"><span id="Span27"><asp:Label ID="lblDimension" runat="server"/></span></td>
                    </tr>
                     <tr>
                        <td style="text-align: left">TM3</td><td id="rmTM3" runat="Server" style="text-align: left"><span id="Span28"><asp:Label ID="lblTM3" runat="server"/></span></td>
                    </tr>
                   
                     <tr>
                        <td style="text-align: left">ShipTerms</td><td id="rmShipTerms" runat="Server" style="text-align: left"><span id="Span29"><asp:Label ID="lblShipTerms" runat="server"/></span></td>
                    </tr>
                     <tr>
                        <td style="text-align: left">ShipTo</td><td id="rmShipTo" runat="Server" style="text-align: left"><span id="Span30"><asp:Label ID="lblShipTo" runat="server"/></span></td>
                    </tr>
                     <tr>
                        <td style="text-align: left">ShipMode</td><td id="rmShipMode" runat="Server" style="text-align: left"><span id="Span31"><asp:Label ID="lblShipMode" runat="server"/></span></td>
                    </tr>
                     <tr>
                        <td style="text-align: left">ShippingMarks</td><td id="rmShippingMarks" runat="Server" style="text-align: left"><span id="Span32"><asp:Label ID="lblShippingMarks" runat="server"/></span></td>
                    </tr>
                    
                     <tr>
                        <td style="text-align: left">Destination</td><td id="rmDestination" runat="Server" style="text-align: left"><span id="Span33"><asp:Label ID="lblDestination" runat="server"/></span></td>
                    </tr>
                     <tr>
                        <td style="text-align: left">Remarks</td><td id="rmks" runat="Server" style="text-align: left"><span id="Span34"><asp:Label ID="lblRemarks" runat="server"/></span></td>
                    </tr>
                
                    </table>
                   
             </td>
    </tr>
    <tr>
    
     <td colspan="2">
     
        <table align="left" border="1px">
                     <tr>
                        <td align="center">Approve Details</td>
                      </tr>
                       <tr>
                        <td>Invoice No:</td><td ><span><asp:Label ID="lblAppInvoiceNo" runat="server"/></span></td><td>Status</td><td><span id="Span35"><asp:Label ID="lblstatusinfo" runat="server"/></span></td>
 
                      </tr>
                        
                      <tr>
                        <td>RequestedOn:</td><td ><span><asp:Label ID="lblAppRequestedOn" runat="server"/></span></td><td>RequestedBy:</td><td ><span><asp:Label ID="lblAppRequestedBy" runat="server"/></span></td>
        
                     </tr>
                     
                     
                      <tr>
                        <td>ApprovedOn:</td><td><span><asp:Label ID="lblApprovedOn" runat="server"/></span></td><td>ApprovedBy:</td><td ><span><asp:Label ID="lblAppApprovedBy" runat="server"/></span></td>
               
                    </tr>
                     
                    </table>
     
     </td>
    
    </tr>

     <tr><td colspan="2" align="center" >
         <asp:Button ID="BtnApprove" runat="server" Text="Approve" BackColor="#E0E0E0" /><asp:Button ID="BtnReject" runat="server" Text="Reject" BackColor="#E0E0E0" /></td></tr>
        
    </table>
    
                
    </div>
    
    <script type="text/javascript">
        function RefreshParent() {
            if (window.opener != null && !window.opener.closed) {
                window.opener.location.reload();
            }
        }
    </script>

    
    </form>
</body>
</html>
 