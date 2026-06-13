<%@ Page Language="vb" AutoEventWireup="false" MasterPageFile="~/ems.Master" CodeBehind="frmMMchPw.aspx.vb" Inherits="E_Management.frmMMchPw" 
    title="Change Password" %>
<asp:Content ID="Content1" ContentPlaceHolderID="CPHApplication" runat="server">
<script language="javascript" type="text/javascript">
// <!CDATA[



// ]]>
</script>

<table cellSpacing="0" cellPadding="0" align="left" border="0">
				<tr>
					<td style="width: 16px"><IMG height="16" src="../Images/top_lef.gif" width="16"></td>
					<td background="/images/top_mid.gif" height="16" style="width: 356px"><IMG height="16" src="../Images/top_mid.gif" width="16"></td>
					<td style="width: 24px"><IMG height="16" src="../images/top_rig.gif" width="24"></td>
				</tr>
				<tr>
					<td background="/images/cen_lef.gif" style="width: 16px"><IMG height="11" src="/images/cen_lef.gif" width="16"></td>
					<td vAlign="top" bgColor="#ffffff" style="width: 356px">
						<table width="100%">
							<TR>
								<TD style="BORDER-BOTTOM: 1px inset" colSpan="2"><FONT style="FONT-SIZE: 15px; COLOR: navy; FONT-FAMILY: tahoma"><b></FONT></TD>
							</TR>
							<TR>
								<TD colSpan="2"><FONT style="FONT-SIZE: 12px; COLOR: navy; FONT-FAMILY: verdana">&nbsp;<strong>Change
                                        Password</strong></FONT></TD>
							</TR>
							<TR>
								<TD align="right" style="width: 421px"><FONT style="FONT-SIZE: 12px; FONT-FAMILY: verdana">enter new Password:</FONT></TD>
								<TD align="left" style="width: 199px">
                                    <asp:TextBox ID="TxtPwd" runat="server" TextMode="Password"></asp:TextBox></TD>
							</TR>
							<TR>
								<TD align="right" style="width: 421px"><FONT style="FONT-SIZE: 12px; FONT-FAMILY: verdana">Confirm Password:</FONT></TD>
								<TD align="left" style="width: 199px">
                                    <asp:TextBox ID="TxtCPwd" runat="server" TextMode="Password"></asp:TextBox></TD>
							</TR>
							<TR>
								<td style="width: 421px"></td>
								<TD vAlign="top" align="left" style="width: 199px">
                                    <asp:Button ID="BtnLogin" runat="server" Text="Save" /></TD>
							</TR>
							<TR>
								<TD colSpan="2"><FONT style="FONT-SIZE: 12px; COLOR: navy; FONT-FAMILY: verdana">&nbsp;<asp:Label
                                        ID="LblMsg" runat="server" Font-Bold="True" Font-Size="Small"></asp:Label></FONT></TD>
							</TR>
							<TR>
								<TD align="center" colSpan="2"><FONT style="FONT-SIZE: 12px; COLOR: #6595c7; FONT-FAMILY: verdana"></FONT></TD>
							</TR>
							<tr>
								<td colspan="2" align="center"></td>
							</tr>
							<tr>
								<td colspan="2" align="center"></td>
							</tr>
							<tr>
								<td colspan="2" align="center"></td>
							</tr>
							<tr>
								<td colspan="2" align="center"><div id="divPopupWarning"></div>
								</td>
							</tr>
							<tr>
								<td colspan="2" align="center"></td>
							</tr>
						</table>
					</td>
					<td background="/images/cen_rig.gif" style="width: 24px">
					<IMG height="11" src="../images/cen_rig.gif" width="24"></td>
				</tr>
				<tr>
					<td height="16" style="width: 16px"><IMG height="16" src="/images/bot_lef.gif" width="16"></td>
					<td background="/images/bot_mid.gif" height="16" style="width: 356px"><IMG height="16" src="/images/bot_mid.gif" width="16"></td>
					<td height="16" style="width: 24px"><IMG height="16" src="/images/bot_rig.gif" width="24"></td>
				</tr>
			</table>
</asp:Content>
