<%@Page Language="vb" AutoEventWireup="false" CodeBehind="ForwarderInvoiceSubmission.aspx.vb" Inherits="E_Management.ForwarderInvoiceSubmission" MasterPageFile="~/ems.Master" Title="Forwarder Invoice Submission" %>

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
                                        <td colspan="2" style="background-color: #336699">
                                            <strong><span style="font-size: 14pt; color: #ffffff">
                                                <br />
                                            Forwarder Invoice Submission<br />
                                            </span></strong>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td style="width: 105px; text-align: left">
                                            CRM Invoice Number
                                        </td>
                                        <td style="width: 100px">
                                            <asp:DropDownList ID="CmbInvNo" runat="server" AutoPostBack="True" Width="228px">
                                            </asp:DropDownList></td>
                                    </tr>
                                    <tr>
                                        <td style="width: 105px; height: 24px; text-align: left">
                                            Department Name</td>
                                        <td style="width: 100px; height: 24px">
                                            <asp:TextBox ID="TxtDepartment" runat="server" Width="228px"></asp:TextBox></td>
                                    </tr>
                                    <tr>
                                        <td style="width: 105px; height: 24px; text-align: left">
                                            Forwarder Name</td>
                                        <td style="width: 100px; height: 24px">
                                            <asp:DropDownList ID="CmbForwarder" runat="server" Width="228px" AutoPostBack="True">
                                            </asp:DropDownList><br />
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="CmbForwarder"
                                                ErrorMessage="Please Select Forwarder Type" InitialValue="-Select-" Height="8px" Width="228px"></asp:RequiredFieldValidator></td>
                                    </tr>
                                    <tr>
                                        <td style="width: 105px; text-align: left">
                                        </td>
                                        <td style="width: 100px">
                                            <asp:Label ID="LblForwarderName" runat="server" Width="232px"></asp:Label></td>
                                    </tr>
                                    <tr>
                                        <td style="width: 105px; text-align: left">
                                            From</td>
                                        <td style="width: 100px">
                                            <asp:TextBox ID="TxtFrom" runat="server" Width="228px"></asp:TextBox></td>
                                    </tr>
                                    <tr>
                                        <td style="width: 105px; text-align: left">
                                            To</td>
                                        <td style="width: 100px">
                                            <asp:TextBox ID="TxtTo" runat="server" Width="228px"></asp:TextBox></td>
                                    </tr>
                                    <tr>
                                        <td style="width: 105px; text-align: left">
                                            Quoted Amount</td>
                                        <td style="width: 100px">
                                            <asp:TextBox ID="TxtQuotedAmount" runat="server" Width="228px"></asp:TextBox>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td style="width: 105px; text-align: left">
                                            Forwarder Invoice Number</td>
                                        <td style="width: 100px">
                                            <asp:TextBox ID="TxtForwarderInvoiceNumber" runat="server" Width="228px"></asp:TextBox></td>
                                    </tr>
                                    <tr>
                                        <td style="width: 105px; text-align: left">
                                            Forwarder Invoice Value</td>
                                        <td style="width: 100px">
                                            <asp:TextBox ID="TxtForwarderInvoiceValue" runat="server" Width="228px" OnBlur=fun1()></asp:TextBox></td>
                                    </tr>
                                    <tr>
                                        <td style="width: 105px; text-align: left">
                                            </td>
                                        <td style="width: 100px">
                                            <asp:TextBox ID="TxtDifference" runat="server" Width="228px" Visible="False"></asp:TextBox></td>
                                    </tr>
                                    <tr>
                                        <td style="width: 105px; text-align: left">
                                            <asp:Label ID="LblRemarks" runat="server" Width="200px" Visible="False">Remarks</asp:Label></td>
                                        <td style="width: 100px">
                                            <asp:TextBox ID="TxtRemarks" runat="server" TextMode="MultiLine" Width="228px" Visible="False"></asp:TextBox></td>
                                    </tr>
                                    <tr>
                                        <td colspan="2">
                                            <asp:Button ID="Button1" runat="server" Text="Submit" Width="85px" />
                                            <asp:Button ID="Button2" runat="server" Text="Clear" Width="67px" />
                                            <asp:Button ID="Button3" runat="server" Text="Exit" Width="64px" /></td>
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