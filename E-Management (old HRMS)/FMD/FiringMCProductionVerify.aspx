<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="FiringMCProductionVerify.aspx.vb" Inherits="E_Management.FiringMCProductionVerify"   MasterPageFile="~/ems.Master"  Title="Temperature Change"%>
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
                                    <td colspan="2" style="background-color: #336699">
                                        <asp:Label ID="Label2" runat="server" Font-Bold="True" ForeColor="White" Text="Verify Status of Temperature Change - Production" Width="750px"></asp:Label></td>
                                </tr>
                            <tr>
                            <td style="text-align: right">  
                                <asp:Label ID="Label1" runat="server" Text="Department"></asp:Label>                        
                            </td>
                            <td style="text-align: left">
                                <asp:DropDownList ID="dept_ddl" runat="server" AppendDataBoundItems="True" AutoPostBack="True"
                                    DataSourceID="SqlDataSource1" DataTextField="dept" DataValueField="departmentcode"
                                    Width="200px">
                                    <asp:ListItem Value="-1">---Select---</asp:ListItem>
                                </asp:DropDownList>&nbsp;</td>                            
                        
                            </tr>
                                <tr>
                                    <td colspan="2" style="height: 21px">
                                        <asp:Label ID="LblStatus" runat="server" Font-Bold="True" ForeColor="Green"></asp:Label></td>
                                </tr>
                            <tr>
                            <td colspan=2>
                                <asp:GridView AutoGenerateColumns=false  ID="GridView1" runat="server" BackColor="LightGoldenrodYellow" BorderColor="Tan" BorderWidth="1px" CellPadding="5" ForeColor="Black" GridLines="None" CellSpacing="3">
                              <Columns>
                                 <asp:TemplateField HeaderText="">
            
                                <EditItemTemplate>
                                    <asp:CheckBox ID="ChkBxSelect" runat="server" />
                                    </EditItemTemplate>
                                    <ItemTemplate>                
                                  <asp:CheckBox ID="ChkBxSelect" runat="server" />
                                    </ItemTemplate>
                                     </asp:TemplateField>
                             
                 <asp:BoundField DataField="BatchNo" HeaderText="BatchNo" />
                  <asp:BoundField DataField="TempChangeOn" HeaderText="Date" />
                   <asp:BoundField DataField="SMSMessage" HeaderText=" Temperature_Change_Details_Verify "  />
                   <asp:BoundField DataField="Status" HeaderText="Status"  />
             
               <asp:TemplateField HeaderText="Verification On">
            <ItemTemplate>
                <asp:TextBox  Width=70 ID="ChangedOn" runat="server" />
                                            <cc1:calendarextender id="ccelt" runat="server" cssclass="cal_Theme1" format="dd-MMM-yy"
                                            popupbuttonid="ChangedOn" targetcontrolid="ChangedOn"></cc1:calendarextender>

            </ItemTemplate>
        </asp:TemplateField>
                                
                                 <asp:TemplateField HeaderText="Time" ItemStyle-Wrap=false>
            <ItemTemplate>
                    <asp:DropDownList Width=50 ID="CmbHours"  runat="server" AutoPostBack=False>
                    <asp:ListItem Text="01"></asp:ListItem>
                    <asp:ListItem Text="02"></asp:ListItem>
                    <asp:ListItem Text="03"></asp:ListItem>
                    <asp:ListItem Text="04"></asp:ListItem>
                    <asp:ListItem Text="05"></asp:ListItem>
                    <asp:ListItem Text="06"></asp:ListItem>
                    <asp:ListItem Text="07"></asp:ListItem>
                    <asp:ListItem Text="08"></asp:ListItem>
                    <asp:ListItem Text="09"></asp:ListItem>
                    <asp:ListItem Text="10"></asp:ListItem>
                    <asp:ListItem Text="11"></asp:ListItem>
                    <asp:ListItem Text="12"></asp:ListItem>
                    </asp:DropDownList>
                    
                      <asp:DropDownList Width=50 ID="CmbMins" runat="server" AutoPostBack=False>
                    <asp:ListItem Text="05"></asp:ListItem>
                    <asp:ListItem Text="10"></asp:ListItem>
                    <asp:ListItem Text="15"></asp:ListItem>
                    <asp:ListItem Text="20"></asp:ListItem>
                    <asp:ListItem Text="25"></asp:ListItem>
                    <asp:ListItem Text="30"></asp:ListItem>
                    <asp:ListItem Text="35"></asp:ListItem>
                    <asp:ListItem Text="40"></asp:ListItem>
                    <asp:ListItem Text="45"></asp:ListItem>
                    <asp:ListItem Text="50"></asp:ListItem>
                    <asp:ListItem Text="55"></asp:ListItem>
                    </asp:DropDownList>
                    
                    <asp:DropDownList Width=50 ID="CmbMedium" runat="server" AutoPostBack=False>
                    <asp:ListItem Text="AM"></asp:ListItem>
                    <asp:ListItem Text="PM"></asp:ListItem>
                    
                    </asp:DropDownList>
                    
            </ItemTemplate>
        </asp:TemplateField>      
                                
                                      <asp:TemplateField HeaderText="Remarks">
                                    <EditItemTemplate>
                                    <asp:TextBox ID="TxtRemarks" runat="server" TextMode=MultiLine MaxLength=250 Width=300 />
                                    </EditItemTemplate>
                                    <ItemTemplate>                
                                  <asp:TextBox ID="TxtRemarks" runat="server" TextMode=MultiLine MaxLength=250 Width=300 />
                                    </ItemTemplate>
                                    
                                </asp:TemplateField>
                                
                              </Columns>
                                    <FooterStyle BackColor="Tan" />
                                    <PagerStyle BackColor="PaleGoldenrod" ForeColor="DarkSlateBlue" HorizontalAlign="Center" />
                                    <SelectedRowStyle BackColor="DarkSlateBlue" ForeColor="GhostWhite" />
                                    <HeaderStyle BackColor="Tan" Font-Bold="True" />
                                    <AlternatingRowStyle BackColor="PaleGoldenrod" />
                                </asp:GridView>
                            </td></tr>
                                <tr>
                                    <td colspan="2" style="text-align: right">
                                        <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:Sqlcon1 %>"
                                            SelectCommand="SELECT ( [departmentcode] +'-'+ [departmentname]) as dept ,departmentcode FROM [department]  where office = 'P' ORDER BY [departmentcode], [departmentname]">
                                        </asp:SqlDataSource>
                                    <asp:Button ID="Btn_Update" runat="server" Text="Save" Width="109px" />
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
            <td width="16" style="height: 1px">
                <img height="16" src="../images/bot_lef.gif" width="16" alt="" /></td>
            <td background="../images/bot_mid.gif" style="height: 1px">
                <img height="16" src="../images/bot_mid.gif" width="16" alt="" /></td>
            <td style="width: 24px; height: 1px;">
                <img height="16" src="../images/bot_rig.gif" width="24" alt="" /></td>
        </tr>
    </table>
</asp:Content>