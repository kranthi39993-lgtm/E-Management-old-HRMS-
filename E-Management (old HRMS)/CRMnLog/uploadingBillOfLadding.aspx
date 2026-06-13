<%@ Page Language="vb" AutoEventWireup="false" Codebehind="uploadingBillOfLadding.aspx.vb" Inherits="E_Management.uploadingBillOfLadding"  MasterPageFile="~/ems.Master" Title="Upload Bills"  %>

		


<asp:Content ID="Content1" ContentPlaceHolderID="CPHApplication" runat="server">	

	<script type="text/javascript">
  <asp:Literal id="ltlAlert" runat="server" EnableViewState="False">
    </asp:Literal>
			</script>
			
			<table cellpadding="0" cellspacing="0" align="center" width="500">
        <tr>
            <td width="16" style="height: 16px">
                <img height="16" src="../images/top_lef.gif" width="16"  alt=""/></td>
            <td background="../images/top_mid.gif" style="height: 16px">
                <img height="16" src="../images/top_mid.gif" width="16"  alt="" /></td>
            <td style="width: 24px; height: 16px;">
                <img height="16" src="../images/top_rig.gif" width="24"  alt="" /></td>
        </tr>
        <tr>
            <td background="../images/cen_lef.gif"  width="16">
                <img height="11" src=    "../images/cen_lef.gif" width="16"  alt="" /></td>
            <td bgcolor="#ffffff" valign="top">
            <table width="500" >
                    <tr>
                        <td colspan="2" align="center" style="width: 435px">
                            <asp:Panel ID="Panel11" runat="server">
                            
                            
                            
                            


		<%--<div id="copyright" onBeforePrint="this.style.visibility='visible'" onAfterPrint="this.style.visibility='hidden'">--%>

				
                                &nbsp;
				
				
				
				
					<table>
						<tr>
							<td style="WIDTH: 678px; HEIGHT: 25px; background-color: #336699;" colspan="3"><strong><span style="color: #ffffff"><font size="4">Upload - Bills of Lading</font><font size="2"><font face="Arial"></font></font></span></strong></td>
						</tr>
						<tr>
							<td style="WIDTH: 201px; HEIGHT: 39px; text-align: left; background-color: beige;"><asp:label id="lblinv" Width="74px" Height="17px" Runat="server">Invoice No</asp:label></td>
							<td style="WIDTH: 198px; HEIGHT: 35px"><asp:dropdownlist id="DropDownList1" runat="server" Width="184px" AutoPostBack="True"></asp:dropdownlist></td>
							<td style="WIDTH: 295px; HEIGHT: 35px"><asp:textbox id="TxtInvNo" runat="server" ReadOnly="True" Width="135px" Visible="False"></asp:textbox></td>
						</tr>
						<tr>
							<td style="WIDTH: 201px; HEIGHT: 39px; text-align: left; background-color: beige;"><asp:label id="invdate" Width="82px" Height="17px" Runat="server">Invoice Date</asp:label></td>
							<td style="WIDTH: 198px; HEIGHT: 27px"><asp:textbox id="txtInvDate" Width="184px" Runat="server" ReadOnly="True"></asp:textbox></td>
							<td style="WIDTH: 295px; HEIGHT: 27px"></td>
						</tr>
						<tr>
							<td style="WIDTH: 201px; HEIGHT: 39px; text-align: left; background-color: beige;"><asp:label id="lbl_custnam" Width="104px" Height="17px" Runat="server">Customer Name</asp:label></td>
							<td style="WIDTH: 198px; HEIGHT: 27px"><asp:textbox id="txt_custname" Width="184px" Runat="server" ReadOnly="True"></asp:textbox></td>
							<td style="WIDTH: 295px; text-align: left;" rowspan="4">
                                <asp:Label ID="Label1" runat="server" Text="* Invoice"></asp:Label><br />
                                <asp:Label ID="Label2" runat="server" Text="* K8 Custom Form"></asp:Label><br />
                                <asp:Label ID="Label3" runat="server" Text="* AWB and BL"></asp:Label><br />
                                <asp:Label ID="Label8" runat="server" Text="* Packing List"></asp:Label><br />
                                <asp:Label ID="Label9" runat="server" Text="* Fumigation Certificate and Wooden Declaration" Width="230px"></asp:Label><br />
                                <asp:Label ID="Label10" runat="server" Text="* Photos "></asp:Label><br />
                                <asp:Label ID="Label11" runat="server" Text="* Certificate of Origin(COC)"></asp:Label><br />
                                <asp:Label ID="Label12" runat="server" Text="* Forwarder Invoice"></asp:Label><br />
                                <br />
                                <asp:Label ID="Label16" runat="server"></asp:Label><asp:Label ID="Label17" runat="server"></asp:Label><br />
                                <asp:Label ID="Label18" runat="server"></asp:Label></td>
						</tr>
						<tr>
							<td style="WIDTH: 201px; HEIGHT: 39px; text-align: left; background-color: beige;"><asp:label id="lbl_des" Width="78px" Height="17px" Runat="server" DESIGNTIMEDRAGDROP="2137">Destination</asp:label></td>
							<td style="WIDTH: 198px; HEIGHT: 32px"><asp:textbox id="txt_des" Width="184px" Runat="server" ReadOnly="True"></asp:textbox></td>
						</tr>
						<tr>
							<td style="WIDTH: 201px; HEIGHT: 39px; text-align: left; background-color: beige;"><asp:label id="lbl_custadd" Width="124px" Height="17px" Runat="server">Customer Address</asp:label></td>
							<td style="WIDTH: 198px; HEIGHT: 36px"><asp:textbox id="txt_custadd" Width="184px" Runat="server" ReadOnly="True" TextMode="MultiLine"></asp:textbox></td>
						</tr>
						<tr>
							<td style="WIDTH: 201px; HEIGHT: 39px; text-align: left; background-color: beige;"><asp:label id="lbl_sdate" Width="90px" Height="17px" Runat="server">Delivery Date</asp:label></td>
							<td style="WIDTH: 198px; HEIGHT: 37px"><asp:textbox id="txt_sch" Width="184px" Runat="server"></asp:textbox></td>
						</tr>
                        <tr>
                            <td style="width: 201px; height: 39px; text-align: left; background-color: beige;">
                                Department Name</td>
                            <td style="width: 198px; height: 39px">
                                <asp:DropDownList ID="CmbDept" runat="server" AutoPostBack="True" Width="184px">
                                </asp:DropDownList></td>
                            <td style="width: 295px; height: 39px">
                                <asp:TextBox ID="TxtDept" runat="server"></asp:TextBox></td>
                        </tr>
						<tr>
							<td style="WIDTH: 201px; HEIGHT: 39px; text-align: left; background-color: beige;">
								<asp:label id="lbl" Height="17px" Width="170px" Runat="server">Enter the Custom Form No.</asp:label></td>
							<td style="WIDTH: 198px; HEIGHT: 39px">
								<asp:textbox id="txtCustomNo" Width="183px" BackColor="White" BorderColor="White" Runat="server"></asp:textbox></td>
							<td style="WIDTH: 295px; HEIGHT: 39px"></td>
						</tr>
                        <tr>
                            <td style="width: 201px; height: 39px; text-align: left; background-color: beige;">
                                Enter HS Code</td>
                            <td style="width: 198px; height: 39px">
                                <asp:DropDownList ID="CmbHSCode" runat="server" Width="183px" AutoPostBack="True">
                                </asp:DropDownList></td>
                            <td style="width: 295px; height: 39px">
                                <asp:TextBox ID="TxtHSCode" runat="server" BackColor="White" BorderColor="White" Width="183px"></asp:TextBox></td>
                        </tr>
						<tr>
							<td style="WIDTH: 474px; HEIGHT: 5px; background-color: beige;" colSpan="2">
                                <br />
                                <asp:DropDownList ID="DropDownList2" runat="server" Width="368px">
                                </asp:DropDownList><br />
                                <br />
                                <INPUT id="File5" style="WIDTH: 258px; HEIGHT: 22px;" type="file" name="File1" runat="server">&nbsp;<asp:button id="Button1" runat="server" Width="106px" BackColor="Control" Text="Upload"></asp:button><br />
									
										<asp:label id="lbl1" Height="17px" Width="202px" BackColor="Transparent" 
											Runat="server"></asp:label></td>
							<td style="WIDTH: 165px; HEIGHT: 5px; background-color: beige;" colSpan="1">
										<asp:label id="Labelnote" runat="server" Font-Size="X-Small" Width="168px" ForeColor="Blue">Note: * File Type : JPG / PDF</asp:label><br />
                                <asp:label id="Label7" runat="server" Font-Size="X-Small" Width="92px" ForeColor="Blue" Height="14px">* Size < 2 MBS</asp:label><br />
                                <br />
                                <asp:Button ID="Button10" runat="server" Text="Remove" />&nbsp;<asp:button id="btnExit" runat="server" Height="24px" Width="84px" BackColor="Control" Text="Exit"></asp:button></td>
						</tr>
                        <tr>
                            <td colspan="3" style="height: 3px; background-color: beige">
                                &nbsp; 
                                <asp:Panel ID="Panel4" runat="server">
                                    <asp:RadioButton ID="RadioButton1" runat="server" Text="Submit" GroupName="CocStatus" AutoPostBack="True" />&nbsp;
                                    <asp:RadioButton ID="RadioButton2" runat="server" Text="Approved" GroupName="CocStatus" AutoPostBack="True" />&nbsp;
                                    <asp:RadioButton ID="RadioButton3" runat="server" Text="Rejected" GroupName="CocStatus" AutoPostBack="True" />&nbsp;
                                    <asp:RadioButton ID="RadioButton4" runat="server" Text="Resubmit" GroupName="CocStatus" AutoPostBack="True" /><br />
                                    &nbsp;
                                    <table>
                                        <tr>
                                            <td style="width: 100px; text-align: left;">
                                    <asp:Label ID="Label14" runat="server" Text="Remarks"></asp:Label></td>
                                            <td style="width: 100px">
                                    <asp:TextBox ID="TxtRemarks" runat="server" Height="54px" TextMode="MultiLine"></asp:TextBox></td>
                                            <td style="width: 100px">
                                    <asp:Label ID="Label13" runat="server" Text="COC Date : " Width="90px"></asp:Label></td>
                                            <td style="width: 100px">
                                    <asp:TextBox ID="TxtCocDate" runat="server" Width="55px"></asp:TextBox><asp:ImageButton
                                        ID="ImageButton1" runat="server" ImageUrl="~/images/calender.png" />&nbsp;</td>
                                            <td style="width: 100px">
                                                </td>
                                        </tr>
                                        <tr>
                                            <td style="width: 100px; text-align: left;">
                                                <asp:Label ID="Label15" runat="server" Text="Document Number" Width="130px"></asp:Label></td>
                                            <td style="width: 100px">
                                                <asp:TextBox ID="TxtDocumentNo" runat="server" Width="175px"></asp:TextBox></td>
                                            <td style="text-align: right;" colspan="2">
                                    <asp:Button ID="Button11" runat="server" Text="COC" Width="154px" /></td>
                                            <td style="width: 100px">
                                            </td>
                                        </tr>
                                        <tr>
                                            <td style="width: 100px">
                                            </td>
                                            <td style="width: 100px">
                                            </td>
                                            <td style="width: 100px">
                                            </td>
                                            <td style="width: 100px">
                                            </td>
                                            <td style="width: 100px">
                                            </td>
                                        </tr>
                                    </table>
                                    <br />
                                    <br />
                                    &nbsp; &nbsp;
                                    <br />
                                    <asp:Calendar ID="Calendar1" runat="server" BackColor="#FFFFCC" BorderColor="#FFCC66"
                                        BorderWidth="1px" DayNameFormat="Shortest" Font-Names="Verdana" Font-Size="8pt"
                                        ForeColor="#663399" Height="7px" ShowGridLines="True" Style="z-index: 100; left: 778px;
                                        position: absolute; top: 651px" Width="24px" Visible="False">
                                        <SelectedDayStyle BackColor="#CCCCFF" Font-Bold="True" />
                                        <SelectorStyle BackColor="#FFCC66" />
                                        <TodayDayStyle BackColor="#FFCC66" ForeColor="White" />
                                        <OtherMonthDayStyle ForeColor="#CC9966" />
                                        <NextPrevStyle Font-Size="9pt" ForeColor="#FFFFCC" />
                                        <DayHeaderStyle BackColor="#FFCC66" Font-Bold="True" Height="1px" />
                                        <TitleStyle BackColor="#990000" Font-Bold="True" Font-Size="9pt" ForeColor="#FFFFCC" />
                                    </asp:Calendar>
                                    </asp:Panel>
                                &nbsp;
                            </td>
                        </tr>
					</table>
				
		<%--</div>--%>
                                &nbsp;&nbsp;
								<asp:panel id="Panel1" runat="server" Width="208px" Height="98px" Visible="False">
										
											<asp:Label id="Label5" runat="server" Width="232px" Font-Size="X-Small" Height="15px">Customer Supportive Documents</asp:Label>&nbsp;<br />
										
										<INPUT id="File6" style="WIDTH: 136px; HEIGHT: 22px; BACKGROUND-COLOR: #66ccff" type="file"
												size="3" name="File1" runat="server">
											<asp:button id="Button2" runat="server" Width="48px" BackColor="#66CCCC" Text="Attach"></asp:button>
										<INPUT id="File7" style="WIDTH: 136px; HEIGHT: 22px; BACKGROUND-COLOR: #66ccff" type="file"
												size="3" name="File1" runat="server">
											<asp:button id="Button7" runat="server" Width="48px" BackColor="#66CCCC" Text="Attach"></asp:button>
										<INPUT id="File8" style="WIDTH: 136px; HEIGHT: 22px; BACKGROUND-COLOR: #66ccff" type="file"
												size="3" name="File1" runat="server">
											<asp:button id="Button8" runat="server" Width="48px" BackColor="#66CCCC" Text="Attach"></asp:button>
										<INPUT id="File9" style="WIDTH: 136px; HEIGHT: 22px; BACKGROUND-COLOR: #66ccff" type="file"
												size="3" name="File1" runat="server">
											<asp:button id="Button9" runat="server" Width="48px" BackColor="#66CCCC" Text="Attach"></asp:button>
										
											<asp:label id="Label6" Height="17px" Width="152px"  Runat="server">&nbsp;&nbsp;Remove All Uploaded BL Files:</asp:label>
										
											<asp:button id="btnRemoveCustomer" runat="server" Width="88px" BackColor="#C0FFFF" Text="Remove All"></asp:button>
									</asp:panel>
							<asp:panel id="Panel2" runat="server" Width="272px" Height="167px" Visible="False">
									
										<asp:Label id="Label4" runat="server" Width="144px" Font-Size="X-Small">Bill of Lading</asp:Label>
									
										<asp:Label id="Form1" runat="server">Custom Form</asp:Label><INPUT id="File" style="WIDTH: 136px; HEIGHT: 22px; BACKGROUND-COLOR: #66ccff" type="file"
											size="3" name="File1" runat="server">
										<asp:button id="btn_attach" runat="server" Width="48px" BackColor="#66CCCC" Text="Attach"></asp:button>
									
										<asp:Label id="Form2" runat="server" Width="64px">Invoice</asp:Label><INPUT id="File1" style="WIDTH: 136px; HEIGHT: 22px; BACKGROUND-COLOR: #66ccff" type="file"
											size="3" name="File1" runat="server">
										<asp:button id="Button6" runat="server" Width="48px" BackColor="#66CCCC" Text="Attach"></asp:button>
									
										<asp:Label id="Form3" runat="server" Width="64px">Bill of Lading</asp:Label><INPUT id="File2" style="WIDTH: 136px; HEIGHT: 22px; BACKGROUND-COLOR: #66ccff" type="file"
											size="3" name="File1" runat="server">
										<asp:button id="Button3" runat="server" Width="48px" BackColor="#66CCCC" Text="Attach"></asp:button>
									
										<asp:Label id="Form4" runat="server" Width="64px">Clearance</asp:Label><INPUT id="File3" style="WIDTH: 136px; HEIGHT: 22px; BACKGROUND-COLOR: #66ccff" type="file"
											size="3" name="File1" runat="server">
										<asp:button id="Button4" runat="server" Width="48px" BackColor="#66CCCC" Text="Attach"></asp:button>
									
										<asp:Label id="Form5" runat="server" Width="64px">Other Docs</asp:Label><INPUT id="File4" style="WIDTH: 136px; HEIGHT: 22px; BACKGROUND-COLOR: #66ccff" type="file"
											size="3" name="File1" runat="server">
										<asp:button id="Button5" runat="server" Width="48px" BackColor="#66CCCC" Text="Attach"></asp:button>
									
										<asp:label id="lbldel" Height="17px" Width="152px"  Runat="server">&nbsp;&nbsp;Remove All Uploaded BL Files:</asp:label>
									
										<asp:button id="btn_remove1" runat="server" Width="88px" BackColor="#C0FFFF" Text="Remove All"></asp:button>
								</asp:panel>
								<asp:panel id="Panel3" runat="server" Height="220px" Visible="False">
									&nbsp;&nbsp;
									
										<asp:label id="lbl2" Height="17px" Width="170px" BackColor="Transparent" 
											Runat="server"></asp:label>
									
										<asp:label id="lbl3" Height="17px" Width="170px" BackColor="Transparent" 
											Runat="server"></asp:label>
									
										<asp:label id="lbl4" Height="17px" Width="170px" BackColor="Transparent" 
											Runat="server"></asp:label>
									
										<asp:label id="lbl5" Height="17px" Width="170px" BackColor="Transparent" 
											Runat="server"></asp:label>
									&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;
								</asp:panel>
		


	
				</asp:Panel>
                            &nbsp;
                        </td>
                    </tr>
                </table>
                </td>
				  <td background="../images/cen_rig.gif" style="width: 24px">
                <img height="11" src="../images/cen_rig.gif" width="24"  alt="" /></td>
        </tr>
        <tr>
            <td height="16" width="16">
                <img height="16" src="../images/bot_lef.gif" width="16"  alt="" /></td>
            <td background="../images/bot_mid.gif" height="16">
                <img height="16" src="../images/bot_mid.gif" width="16"  alt="" /></td>
            <td height="16" style="width: 24px">
                <img height="16" src="../images/bot_rig.gif" width="24" alt="" /></td>
        </tr>
        
        <tr>
        <td colspan="4">
            &nbsp;</td>
        </tr>
        
    </table>
		</asp:Content>