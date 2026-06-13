<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="Home.aspx.vb" Inherits="Mmaintenance.Home" 
    title="Mould Maintenace System Log in Page" %>

<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title> Mould Maintenance System </title>
		<meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
	     <link rel="stylesheet" type="text/css" href="/css/style.css" /> 
            <link rel="stylesheet" type="text/css" href="/css/stylesheet.css" />
      
	</HEAD>
	
	<body>
		
		<form id="Form1" name="Form1" runat=server>

			<!----------------------------------------------------------------------------------->
			<!--Header Bar #00659c -->
			<!----------------------------------------------------------------------------------->
			<table id="HeaderTable" cellspacing="0" cellpadding="0" width="100%" bgcolor="#006699" border="0">
	<tr height="17">
		<TD width="17" style="height: 4px"><IMG height="20" alt="" src="/images/topLeftCorner.gif" width="36" border="0"></TD>
		<TD width="100%" style="height: 4px"><FONT style="FONT-SIZE: 11px; FONT-FAMILY: Tahoma" color="white">&nbsp;</FONT></TD>
		<TD align="right" width="17" style="height: 4px"><IMG height="20" alt="" src="/images/topRightCorner.gif" width="36" border="0"></TD>
	</tr>
	<tr height="17">
		<TD width="17">&nbsp;</TD>
		<TD valign="middle" align="center" width="100%" nowrap="nowrap">
						<TABLE height="100" cellSpacing="0" cellPadding="0" border="0">
							<TR>
								<TD noWrap width="100%">
									<table border="0" width="100%" cellpadding="0" cellspacing="0">
										<tr>
											<td width="1" noWrap align="left" valign="center">
												<img src="Images/maruwa_a.JPG"></td>
											<td align="left" nowrap>
											<table id="tblHead" cellpadding="0" cellspacing="0" width="100%" border="0" height="1">
													<tr>
														<td valign="bottom" noWrap>
															<font style='LEFT: 10px; POSITION: relative; TOP: 14px' face=''><b>
																	<span id="CompanyName" class="CompanyTitle"><b>
																	<font face="Tahoma" color="Black">Maruwa </font></b></span></b></font>
															<table border="0" cellpadding="0" cellspacing="0" style="height: 4px">
																<tr>
																	<td valign="bottom" nowrap style="height: 19px">
																		<font style='LEFT: 8px; POSITION: relative; TOP: 10px' face=''>
																			<span id="CompanyTag" class="CompanyTag">Mould Maintenance System</span></font>
																	</td>
																</tr>
															</table>
															<font style='LEFT: 7px; POSITION: relative; TOP: -35px'><b>
																	<span id="CompanyNameShdw" class="CompanyTitle"><b><font face="Tahoma" color="White">Maruwa</font></b></span></b></font>
														</td>
													</tr>
												</table>
											</td>
										</tr>
									</table>
								</TD>
								<TD vAlign="top" noWrap align="center"><FONT style="FONT-SIZE: 11px; FONT-FAMILY: Tahoma">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<BR>
										<br>
										<br>
										<br>
										
										<center><SPAN id="clock"></SPAN></center>
									</FONT></TD>
								<TD>&nbsp;</TD>
								<TD>&nbsp;</TD>
							</TR>
						</TABLE>
					</TD>
		<TD width="17">&nbsp;</TD>
	</tr>
	<tr>
		<TD bgcolor="black" colspan="3"><IMG height="1" alt="" hspace="0" src="" width="1" border="0"></TD>
	</tr>
	<tr>
		<TD bgcolor="white" colspan="3"><IMG height="1" alt="" hspace="0" src="" width="1" border="0"></TD>
	</tr>
	<tr>
		<TD bgcolor="silver" colspan="3"><IMG height="1" alt="" hspace="0" src="" width="1" border="0"></TD>
	</tr>
	<tr>
		<TD width="100%" bgcolor="#c6c3c6" colspan="3"></TD>
		<TD width="17" bgcolor="#c6c3c6"></TD>
	</tr>
	<tr height="10">
		<TD><IMG height="27" alt="" src="/images/header_curve_low_left.gif" width="36" border="0"></TD>
		<TD valign="middle" width="100%" bgcolor="#efefde">&nbsp; 
						<!----------------------------------------------------------------------------------->
						<!--Views Command Menu-->
						<!-----------------------------------------------------------------------------------></TD>
		<TD width="17" bgcolor="#efefde"><IMG height="27" alt="" src="/images/header_curve_low_right.gif" width="36" border="0"></TD>
	</tr>
</table>


<table cellSpacing="0" cellPadding="0" align="left" border="0">
				<tr>
					<td style="width: 16px"><IMG height="16" src="../Images/top_lef.gif" width="16"></td>
					<td background="/images/top_mid.gif" height="16"><IMG height="16" src="../Images/top_mid.gif" width="16"></td>
					<td style="width: 24px"><IMG height="16" src="../images/top_rig.gif" width="24"></td>
				</tr>
				<tr>
					<td background="/images/cen_lef.gif" style="width: 16px"><IMG height="11" src="/images/cen_lef.gif" width="16"></td>
					<td vAlign="top" bgColor="#ffffff">
						<table width="100%">
							<TR>
								<TD style="BORDER-BOTTOM: 1px inset" colSpan="2"><FONT style="FONT-SIZE: 15px; COLOR: navy; FONT-FAMILY: tahoma"><b><IMG src="/images/sign_in2.gif"></FONT></TD>
							</TR>
							<TR>
								<TD colSpan="2"><FONT style="FONT-SIZE: 12px; COLOR: navy; FONT-FAMILY: verdana">&nbsp;</FONT></TD>
							</TR>
							<TR>
								<TD align="right" width="40%"><FONT style="FONT-SIZE: 12px; FONT-FAMILY: verdana">User 
										ID:</FONT></TD>
								<TD align="left">
                                    <asp:TextBox ID="TxtUserId" runat="server"></asp:TextBox></TD>
							</TR>
							<TR>
								<TD align="right" width="40%"><FONT style="FONT-SIZE: 12px; FONT-FAMILY: verdana">Password:</FONT></TD>
								<TD align="left">
                                    <asp:TextBox ID="TxtPwd" runat="server" TextMode="Password"></asp:TextBox></TD>
							</TR>
							<TR>
								<td></td>
								<TD vAlign="top" align="left">
                                    &nbsp;<asp:Button ID="BtnLogin" runat="server" Text="Log In" /></TD>
							</TR>
							<TR>
								<TD colSpan="2"><FONT style="FONT-SIZE: 12px; COLOR: navy; FONT-FAMILY: verdana">&nbsp;<asp:Label
                                        ID="LblMsg" runat="server" Font-Bold="True" Font-Size="Small"></asp:Label></FONT></TD>
							</TR>
							<TR>
								<TD align="center" colSpan="2"><FONT style="FONT-SIZE: 12px; COLOR: #6595c7; FONT-FAMILY: verdana">(if 
										you do not have an intranet account, contact your administrator)</FONT></TD>
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
					<td background="/images/bot_mid.gif" height="16"><IMG height="16" src="/images/bot_mid.gif" width="16"></td>
					<td height="16" style="width: 24px"><IMG height="16" src="/images/bot_rig.gif" width="24"></td>
				</tr>
			</table>
        
	</form>	
	</body>
	</HTML>
	


