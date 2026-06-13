<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="RegisterMouldName.aspx.vb" Inherits="E_Management.RegisterMouldName" MasterPageFile="~/ems.Master" Title="Register Mould Name" %>

<asp:Content ID="Content1" ContentPlaceHolderID="CPHApplication" runat="server">
<table cellpadding="0" cellspacing="0" align="center">
	<tr>
					<td width="16"><IMG height="16" src="/images/top_lef.gif" width="16"></td>
					<td background="/images/top_mid.gif" height="16"><img  alt=""  height="16" src="/images/top_mid.gif" width="16" /></td>
					<td width="24"><img  alt=""  height="16" src="/images/top_rig.gif" width="24" /></td>
				</tr>
				<tr>
					<td width="16" background="/images/cen_lef.gif"><img  alt=""  height="11" src="/images/cen_lef.gif" width="16" /></td>
					<td valign="top" bgcolor="#ffffff">
					
					
					<table>
					<tr>
					    <td colspan="2" style="background-color: #5d7b9d; text-align: center">
                            <asp:Label ID="Label1" runat="server" Text="Register Mould Name" Font-Bold="True" ForeColor="White"></asp:Label>
                        </td>
                    </tr>
                        <tr>
                            <td style="background-color: beige">
                                <asp:Label ID="Label4" runat="server" Text="Department Name" /></td>
                            <td>
                                <asp:DropDownList ID="CMbDepartment" runat="server" AutoPostBack="True" Width="150px">
                                </asp:DropDownList></td>
                        </tr>
                    <tr>
                        <td style="background-color: beige">
                            <asp:Label ID="Label2" runat="server" Text="Mould Description" />
                        </td>
                        <td>
                            <asp:TextBox ID="TxtMName" runat="server" Width="150px"></asp:TextBox>
                        </td>
                    </tr>
                        
                    <tr>
                        <td style="background-color: beige">
                            <asp:Label ID="Label3" runat="server" Text="Mould Type" />
                        </td>
                        <td>
                            <asp:DropDownList ID="CmbMType" runat="server" DataSourceID="SqlDataSource1" DataTextField="MouldType" DataValueField="MouldType" Width="150px">
                            </asp:DropDownList>
                        </td>
                    </tr>
                    
                    <tr>
                        <td align="center" colspan="1" style="height: 26px; text-align: right;">
                            <asp:Button ID="Button1" runat="server" Text="View" Width="50px" CausesValidation="False" /></td>
                        <td colspan="2" align="center" style="height: 26px; text-align: left;">
                            &nbsp;<asp:Button ID="BtnSubmit" runat="server" Text="Save" Width="50px" />
                        </td>
                    </tr>
                        <tr>
                            <td align="center" colspan="2">
                                <asp:Label ID="LblMsg" runat="server" Font-Bold="True" Font-Size="Small"></asp:Label><br />
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="CMbDepartment"
                                    ErrorMessage="* Please Select Department" InitialValue="-Select-"></asp:RequiredFieldValidator>
                                <br />
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="TxtMName"
                                    ErrorMessage="* Please Enter Mould Name" SetFocusOnError="True"></asp:RequiredFieldValidator>&nbsp;<asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:MMaintenanceConnectionString2 %>"
                                    SelectCommand="Select MouldType From RegisterMouldTypes Where FGID=@FGID">
                                    <SelectParameters>
                                        <asp:SessionParameter DefaultValue="21" Name="FGID" SessionField="fgid" />
                                    </SelectParameters>
                                </asp:SqlDataSource>
                                </td>
                        </tr>
                    
                        
                         
                    </table>
					
					
					
					
					
					
					
					
					
					 </td>
					<td width="24" background="/images/cen_rig.gif">
					<img height="11" src="/images/cen_rig.gif" width="24" alt="" /></td>
				</tr>
				<tr>
					<td width="16" height="16"><img height="16"  alt="" src="/images/bot_lef.gif" width="16" /></td>
					<td background="/images/bot_mid.gif" height="16"><img  alt="" height="16" src="/images/bot_mid.gif" width="16" /></td>
					<td width="24" height="16"><img alt="" height="16" src="/images/bot_rig.gif" width="24" /></td>
				</tr>
			</table>
</asp:Content>