<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="ApprovalForwarderInvoiceKeyIn.aspx.vb" Inherits="E_Management.ApprovalForwarderInvoiceKeyIn" MasterPageFile="~/ems.Master"  Title="Approval Screen"%>


<asp:Content ID="Content1" ContentPlaceHolderID="CPHApplication" runat="server">	
<table  cellpadding="0" cellspacing="0" align="center" width="500">
        <tr>
            <td width="16" style="height: 16px">
                <img height="16" src="../images/top_lef.gif" width="16"/></td>
            <td background="../images/top_mid.gif" style="height: 16px">
                <img height="16" src="../images/top_mid.gif" width="16" /></td>
            <td style="width: 24px; height: 16px;">
                <img height="16" src="../images/top_rig.gif" width="24" /></td>
        </tr>
        <tr>
            <td background="../images/cen_lef.gif"  width="16">
                <img height="11" src="../images/cen_lef.gif" width="16" /></td>
            <td bgcolor="#ffffff" valign="top">
                <table width="500" >
                    <tr>
                        <td colspan="2" align="center" style="width: 435px">
                            <asp:Panel ID="Panel1" runat="server">
                                <table>
                                    <tr>
                                        <td colspan="2" style="background-color: #336699; text-align: center">
                                            <span style="font-size: 14pt; color: #ffffff"><strong>Approve / Reject Forwarder Invoice</strong></span></td>
                                    </tr>
                                    <tr>
                                        <td style="width: 100px; text-align: left">
                                            Ref No</td>
                                        <td style="width: 100px; text-align: left">
                                            <asp:TextBox ID="TxtUID" runat="server" ReadOnly="True" Width="175px"></asp:TextBox></td>
                                    </tr>
                                    <tr>
                                        <td style="width: 100px; text-align: left">
                                            Invoice No</td>
                                        <td style="width: 100px; text-align: left">
                                            <asp:TextBox ID="TxtInvoiceNo" runat="server" ReadOnly="True" Width="175px"></asp:TextBox>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td style="width: 100px; text-align: left">
                                            Department</td>
                                        <td style="width: 100px; text-align: left">
                                            <asp:TextBox ID="TxtDepartment" runat="server" ReadOnly="True" Width="175px"></asp:TextBox></td>
                                    </tr>
                                    <tr>
                                        <td style="width: 100px; text-align: left">
                                            Forwarder Invoice Submission Date</td>
                                        <td style="width: 100px; text-align: left">
                                            <asp:TextBox ID="TxtFInvSubDate" runat="server" ReadOnly="True" Width="175px"></asp:TextBox></td>
                                    </tr>
                                    <tr>
                                        <td style="width: 100px; text-align: left">
                                            Forwarder Name</td>
                                        <td style="width: 100px; text-align: left">
                                            <asp:TextBox ID="TxtFName" runat="server" ReadOnly="True" Width="175px"></asp:TextBox></td>
                                    </tr>
                                    <tr>
                                        <td style="width: 100px; text-align: left">
                                            Departure Place
                                        </td>
                                        <td style="width: 100px; text-align: left">
                                            <asp:TextBox ID="TxtDepart" runat="server" ReadOnly="True" Width="175px"></asp:TextBox></td>
                                    </tr>
                                    <tr>
                                        <td style="width: 100px; text-align: left">
                                            Arrival Place</td>
                                        <td style="width: 100px; text-align: left">
                                            <asp:TextBox ID="TxtArrival" runat="server" ReadOnly="True" Width="175px"></asp:TextBox></td>
                                    </tr>
                                    <tr>
                                        <td style="width: 100px; text-align: left">
                                            Forwarder Invoice No</td>
                                        <td style="width: 100px; text-align: left">
                                            <asp:TextBox ID="TxtFInvNo" runat="server" ReadOnly="True" Width="175px"></asp:TextBox></td>
                                    </tr>
                                    <tr>
                                        <td style="width: 100px; text-align: left">
                                            Quoted Amount</td>
                                        <td style="width: 100px; text-align: left">
                                            <asp:TextBox ID="TxtQAmount" runat="server" ReadOnly="True" Width="175px"></asp:TextBox></td>
                                    </tr>
                                    <tr>
                                        <td style="width: 100px; text-align: left">
                                            Forwarder Invoice Value</td>
                                        <td style="width: 100px; text-align: left">
                                            <asp:TextBox ID="TxtFInvValue" runat="server" ReadOnly="True" Width="175px"></asp:TextBox></td>
                                    </tr>
                                    <tr>
                                        <td style="width: 100px; text-align: left">
                                            Difference</td>
                                        <td style="width: 100px; text-align: left">
                                            <asp:TextBox ID="TxtDiff" runat="server" ReadOnly="True" Width="175px"></asp:TextBox></td>
                                    </tr>
                                    <tr>
                                        <td style="width: 100px; text-align: left">
                                            Remarks</td>
                                        <td style="width: 100px; text-align: left">
                                            <asp:TextBox ID="TxtRemarks" runat="server" Height="55px" TextMode="MultiLine" Width="175px"></asp:TextBox></td>
                                    </tr>
                                    <tr>
                                        <td style="width: 100px; text-align: left">
                                            <asp:Label ID="Label1" runat="server" Height="16px" Width="300px"></asp:Label></td>
                                        <td style="width: 100px; text-align: left">
                                        </td>
                                    </tr>
                                    <tr>
                                        <td colspan="2">
                                            <asp:Button ID="Button1" runat="server" Text="Approve" Width="81px" />
                                            <asp:Button ID="Button2" runat="server" Text="Reject" Width="81px" />&nbsp;<asp:Button
                                                ID="Button3" runat="server" Text="Exit" Width="74px" /></td>
                                    </tr>
                                </table>
                            
                            
                            
                            
                            
                            
                            
	</asp:Panel>
                        </td>
                    </tr>
                </table>
</td>                
  <td background="../images/cen_rig.gif" style="width: 24px">
                <img height="11" src="../images/cen_rig.gif" width="24" /></td>
        </tr>
        <tr>
            <td height="16" width="16">
                <img height="16" src="../images/bot_lef.gif" width="16" /></td>
            <td background="../images/bot_mid.gif" height="16">
                <img height="16" src="../images/bot_mid.gif" width="16" /></td>
            <td height="16" style="width: 24px">
                <img height="16" src="../images/bot_rig.gif" width="24" /></td>
        </tr>
    </table>



</asp:Content>