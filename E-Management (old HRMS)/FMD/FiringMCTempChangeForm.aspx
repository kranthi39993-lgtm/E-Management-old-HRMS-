<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="FiringMCTempChangeForm.aspx.vb" Inherits="E_Management.FiringMCTempChangeForm"  MasterPageFile="~/ems.Master"  Title="Temperature Change"%>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="CPHApplication" runat="server">	

<table  cellpadding="0" cellspacing="0" align="center" width="500">
        <tr>
            <td width="16" style="height: 16px">
                <img height="16" src="../images/top_lef.gif" width="16" alt="" /></td>
            <td background="../images/top_mid.gif" style="height: 16px">
                <img height="16" src="../images/top_mid.gif" width="16" alt="" /></td>
            <td style="width: 24px; height: 16px;">
                <img height="16" src="../images/top_rig.gif" width="24" alt="" /></td>
        </tr>
        <tr>
            <td background="../images/cen_lef.gif"  width="16" style="height: 438px">
                <img height="11" src="../images/cen_lef.gif" width="16" alt="" /></td>
            <td bgcolor="#ffffff" valign="top" style="height: 438px">
                <table width="500" >
                    <tr>
                        <td colspan="2" align="center" style="width: 435px">
                            <asp:Panel ID="Panel1" runat="server">
                                
                                
                                <table>
                                    <tr>
                                        <td colspan="9" style="text-align: center; background-color: #336699;">
                                            <asp:Label ID="Label12" runat="server" Text="Firing Machine Temperature Change - Request Form" Font-Bold="True" ForeColor="White"></asp:Label></td>
                                    </tr>
                                    <tr>
                                        <td style="width: 177px; height: 21px; background-color: beige; text-align: left">
                                        <asp:Label ID="Label1" runat="server" Text="Department"></asp:Label></td>
                                        <td colspan="2">
                                        <asp:DropDownList ID="dept_ddl" runat="server" AppendDataBoundItems="True" AutoPostBack="True"
                                            DataSourceID="SqlDataSource1" DataTextField="dept" DataValueField="departmentcode"
                                            Width="174px">
                                            <asp:ListItem Value="-1">---Select---</asp:ListItem>
                                        </asp:DropDownList></td>
                                        <td style="width: 177px; height: 21px; background-color: beige; text-align: center">
                                        <asp:Label ID="Label5" runat="server" Text="Date of Change" Font-Bold="True" Width="125px"></asp:Label>
                                              <asp:TextBox  Width=70 ID="TxtDate" runat="server"/>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="TxtDate"
                                            ErrorMessage="*" ToolTip="Please Select Date"></asp:RequiredFieldValidator>
                                            <asp:Label ID="LblMsg" runat="server" Font-Bold="True" ForeColor="Red"></asp:Label>
                                            <cc1:calendarextender id="ccelt" runat="server" cssclass="cal_Theme1" format="dd-MMM-yy"
                                            popupbuttonid="TxtDate" targetcontrolid="TxtDate"></cc1:calendarextender>
                                        </td>
                                        <td>
                                            &nbsp;<asp:Label ID="Label9" runat="server" Text="Time of Change" Width="175px" Font-Bold="True"></asp:Label>
                                            &nbsp;
                                        <asp:DropDownList ID="CmbHours" runat="server" AutoPostBack="True" Width="50px">
                                        </asp:DropDownList>
                                            <asp:DropDownList ID="CmbMinutes" runat="server" AutoPostBack="True" Width="50px">
                                            </asp:DropDownList>
                                            <asp:DropDownList ID="CmbMedium" runat="server" AutoPostBack="True" Width="50px">
                                            </asp:DropDownList></td>
                                        <td style="width: 177px; height: 21px; background-color: beige; text-align: center">
                                            &nbsp;<asp:Label ID="Label2" runat="server" Text="Machine Number"></asp:Label><asp:DropDownList ID="mcno_ddl" runat="server" AutoPostBack="True" Width="120px">
                                            </asp:DropDownList></td>
                                        <td style="text-align: center">
                                            <asp:Label ID="Label4" runat="server" Font-Bold="False" Text="Temperature"
                                                Width="150px"></asp:Label>&nbsp;<br />
                                            <asp:DropDownList ID="CmbRTFrom" runat="server" Width="50px">
                                        </asp:DropDownList>
                                            <asp:Label ID="Label7" runat="server" Text=" To "></asp:Label>&nbsp;
                                            <asp:DropDownList ID="CmbRTTo" runat="server" Width="50px">
                                            </asp:DropDownList></td>
                                        <td style="width: 177px; height: 21px; background-color: beige; text-align: center">
                                            <asp:Label ID="Label6" runat="server" Font-Bold="False" Text="Reason for Change"
                                                Width="130px"></asp:Label>
                                            <asp:TextBox ID="TxtReason" runat="server" Width="150px"></asp:TextBox>&nbsp;</td>
                                    </tr>
                                    <tr>
                                        <td style="text-align: center; height: 21px; width: 177px; background-color: beige;">
                                            <asp:Label ID="Label8" runat="server" Text="Zone No" Width="60px"></asp:Label></td>
                                        <td style="text-align: center; width: 177px; height: 21px; background-color: beige;">
                                            <asp:Label ID="Label10" runat="server" Text="Temp From" Width="100px"></asp:Label></td>
                                        <td style="text-align: center; height: 21px; width: 177px; background-color: beige;">
                                            <asp:Label ID="Label11" runat="server" Text="Temp To" Width="100px"></asp:Label></td>
                                        <td colspan="5">
                                            <asp:Label ID="LblFinalMsg" runat="server" Font-Bold="True" ForeColor="Green"></asp:Label>
                                            <asp:Label ID="Label3" runat="server" Font-Bold="False" Text="Product Type"
                                                Width="150px" Visible="False"></asp:Label>
                                            <asp:DropDownList ID="CmbProductType" runat="server" Width="174px" Visible="False">
                                            </asp:DropDownList></td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <asp:DropDownList ID="CmbZoneID" runat="server" AutoPostBack="True" Width="50px">
                                            </asp:DropDownList></td>
                                        <td>
                                            <asp:TextBox ID="TxtFrom" runat="server" Width="70px"></asp:TextBox><asp:CompareValidator ID="validator1" runat="server" ControlToValidate="TxtFrom" Operator="DataTypeCheck" Type="Double" ErrorMessage="*" ToolTip="Value must be a number" /><asp:RequiredFieldValidator
                                                ID="RequiredFieldValidator2" runat="server" ControlToValidate="TxtFrom" ErrorMessage="*"
                                                ToolTip="Please Select Date" Width="1px"></asp:RequiredFieldValidator></td>
                                        <td>
                                            <asp:TextBox ID="TxtTo" runat="server" Width="70px"></asp:TextBox><asp:CompareValidator ID="Validator2" runat="server" ControlToValidate="TxtTO" Operator="DataTypeCheck" Type="Double" ErrorMessage="*" ToolTip="Value must be a number" /><asp:RequiredFieldValidator
                                                ID="RequiredFieldValidator3" runat="server" ControlToValidate="TxtTo" ErrorMessage="*"
                                                ToolTip="Please Select Date"></asp:RequiredFieldValidator></td>
                                        <td colspan="5" style="text-align: left">
                                            <asp:Button ID="BtnAdd" runat="server" Text="Add" Width="75px" />&nbsp; &nbsp;
                                        </td>
                                    </tr>
                                    <tr>
                                        <td colspan="9" style="height: 164px; text-align: center">
                                            <br />
                                          
                                          <asp:GridView ID="GridView1" runat="server" ShowFooter="True" AutoGenerateColumns="False" Height="164px" Font-Size="7pt" OnRowDeleting="Fun3" CellPadding="2" ForeColor="Black" GridLines="None" BackColor="LightGoldenrodYellow" BorderColor="Tan" BorderWidth="1px" >
    <Columns>
        <asp:BoundField DataField="RowNumber" HeaderText="SNO" />
        
        
             
        <asp:TemplateField HeaderText="Machine No">
            <ItemTemplate>
                <asp:Label  Width=100 ID="TempMachineNO" Text="" runat="server"/>
            </ItemTemplate>
        </asp:TemplateField>
        
        <asp:TemplateField HeaderText="Zone No">
            <ItemTemplate>
                <asp:Label  Width=100 ID="TempZoneNO" Text="" runat="server"/>
            </ItemTemplate>
        </asp:TemplateField>
        
        <asp:TemplateField HeaderText="Time">
            <ItemTemplate>
                <asp:Label  Width=100 ID="TempHours" Text="" runat="server"/>
            </ItemTemplate>
        </asp:TemplateField>        
                
       <asp:TemplateField HeaderText="From">
            <ItemTemplate>
                <asp:Label  Width=100 ID="TempFrom" Text="" runat="server"/>
            </ItemTemplate>
       </asp:TemplateField>
                
      <asp:TemplateField HeaderText="To">
            <ItemTemplate>
                <asp:Label  Width=100 ID="TempTo" Text="" runat="server"/>
            </ItemTemplate>
       </asp:TemplateField>
                
      <asp:TemplateField HeaderText="Product Type">
            <ItemTemplate>
                <asp:Label  Width=100 ID="TempProductType" Text="" runat="server"/>
            </ItemTemplate>
       </asp:TemplateField>
                
       
       <asp:TemplateField HeaderText="Refer Thermo Change">
            <ItemTemplate>
                <asp:Label  Width=100 ID="TempRFrom" Text="" runat="server"/> 
            </ItemTemplate>
        </asp:TemplateField>
        
        <asp:TemplateField HeaderText="Reason">
            <ItemTemplate>
                <asp:Label  Width=100 ID="TempReason" Text="" runat="server"/> 
            </ItemTemplate>
        </asp:TemplateField>
        
        
        <asp:CommandField ShowDeleteButton=True />
    </Columns>
     <FooterStyle BackColor="Tan" />
     <PagerStyle BackColor="PaleGoldenrod" ForeColor="DarkSlateBlue" HorizontalAlign="Center" />
     <SelectedRowStyle BackColor="DarkSlateBlue" ForeColor="GhostWhite" />
     <HeaderStyle BackColor="Tan" Font-Bold="True" />
     <AlternatingRowStyle BackColor="PaleGoldenrod" />
    
</asp:GridView>
                                            <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:Sqlcon1 %>"
                                                SelectCommand="SELECT ( [departmentcode] +'-'+ [departmentname]) as dept ,departmentcode FROM [department]  where office = 'P' ORDER BY [departmentcode], [departmentname]">
                                            </asp:SqlDataSource>
                                            &nbsp;&nbsp;</td>
                                    </tr>
                                    <tr>
                                        <td style="background-color: beige; text-align: left; height: 21px;">
                                            <asp:Label ID="Label13" runat="server" Text="Empty Block"></asp:Label></td>
                                        <td colspan="6" style="height: 21px; text-align: left">
                                            <asp:TextBox ID="TxtEmptyBlock" runat="server" Width="175px"></asp:TextBox></td>
                                        <td style="height: 21px; text-align: right">
                                        </td>
                                        <td style="height: 21px; text-align: center">
                                        </td>
                                    </tr>
                                    <tr>
                                        <td style="height: 23px; background-color: beige; text-align: left">
                                            <asp:Label ID="Label14" runat="server" Text="First Serial Number"></asp:Label></td>
                                        <td colspan="6" style="height: 23px; text-align: left">
                                            <asp:TextBox ID="TxtFirstSerialNumber" runat="server" Width="175px"></asp:TextBox></td>
                                        <td style="height: 23px; text-align: right">
                                        </td>
                                        <td style="height: 23px; text-align: center">
                                        </td>
                                    </tr>
                                    <tr>
                                        <td style="height: 24px; background-color: beige; text-align: left">
                                            <asp:Label ID="Label16" runat="server" Text="First Product Type" Width="120px"></asp:Label></td>
                                        <td colspan="6" style="height: 24px; text-align: left">
                                            &nbsp;<asp:TextBox ID="CmbFirstProductType" runat="server"></asp:TextBox></td>
                                        <td style="height: 24px; text-align: right">
                                        </td>
                                        <td style="height: 24px; text-align: center">
                                        </td>
                                    </tr>
                                    <tr>
                                        <td style="height: 24px; background-color: beige; text-align: left">
                                            <asp:Label ID="Label17" runat="server" Text="Cycle Time From"></asp:Label></td>
                                        <td colspan="6" style="height: 24px; text-align: left">
                                            <asp:TextBox ID="TxtCfrom" runat="server" Width="51px"></asp:TextBox>
                                            <asp:Label ID="Label18" runat="server" Text=" To "></asp:Label>&nbsp;
                                            <asp:TextBox ID="TxtCto" runat="server" Width="51px"></asp:TextBox></td>
                                        <td style="height: 24px; text-align: right">
                                        </td>
                                        <td style="height: 24px; text-align: center">
                                        </td>
                                    </tr>
                                    <tr>
                                        <td style="background-color: beige; text-align: left;">
                                            <asp:Label ID="Label15" runat="server" Text="Remarks"></asp:Label></td>
                                        <td style="text-align: left; height: 13px;" colspan="6">
                                            <asp:TextBox ID="TxtRemarks" runat="server" MaxLength="250" TextMode="MultiLine"
                                                Width="738px"></asp:TextBox>&nbsp;</td>
                                        <td style="height: 13px; text-align: right">
                                            <asp:Button ID="BtnSubmit" runat="server" Text="Submit" CausesValidation="False" /></td>
                                        <td style="height: 13px; text-align: center">
                                        </td>
                                    </tr>
                                
                                
                                </table>
                                
                                
                                
                                
                                
                                
            
	</asp:Panel>
                            &nbsp;
                        </td>
                    </tr>
                </table>
</td>                
  <td background="../images/cen_rig.gif" style="width: 24px; height: 438px;">
                <img height="11" src="../images/cen_rig.gif" width="24" alt="" /></td>
        </tr>
        <tr>
            <td width="16" style="height: 2px">
                <img height="16" src="../images/bot_lef.gif" width="16" alt="" /></td>
            <td background="../images/bot_mid.gif" style="height: 2px">
                <img height="16" src="../images/bot_mid.gif" width="16" alt="" /></td>
            <td style="width: 24px; height: 2px;">
                <img height="16" src="../images/bot_rig.gif" width="24" alt="" /></td>
        </tr>
    </table>
</asp:Content>
                            
