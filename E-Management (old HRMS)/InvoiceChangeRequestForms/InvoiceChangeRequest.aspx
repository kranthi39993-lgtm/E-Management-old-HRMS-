<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="InvoiceChangeRequest.aspx.vb" MasterPageFile="~/ems.Master" Inherits="E_Management.InvoiceChangeRequest" %>
<%--<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>--%>

<asp:Content ID="Content1" ContentPlaceHolderID="CPHApplication" runat="server">
<asp:UpdatePanel ID="up" runat="server">
        <ContentTemplate>
    <table border="0" width="100%">
          <tr>
              <td align="left" style="background-color: #3366ff; text-align: center"> 
                  <span style="color: #ffffff"><strong>INVOICE CHANGE REQUEST</strong></span></td>
          </tr>
          <tr>
              <td align="center"><asp:Label ID="lblMsg" runat="server"></asp:Label>
                  <asp:Label ID="lblviewupdate" runat="server"></asp:Label></td>
          </tr>
          <tr>
              <td align="left" >
                  <table cellpadding="3" cellspacing="0">
                      
                      <tr>
                          <td style="text-align: left; height: 35px;">
                              Select Invoice No</td><td style="height: 35px">:</td><td style="text-align: left; width: 237px; height: 35px;"><asp:DropDownList CssClass="form-control" id="ddlInvoiceNo" runat="server" Width="300px" AutoPostBack="True"></asp:DropDownList></td>                   <td style="text-align: left; height: 35px;"></td><td style="width: 11px; height: 35px;"></td><td style="text-align: left; width: 237px; height: 35px;">
                                  <asp:Label ID="lblEmpCode" runat="server" Width="300px"></asp:Label></td>
       
                      </tr>
                      <tr>
                          <td style="text-align: left">
                              &nbsp;Invoice No</td><td>:</td><td style="text-align: left; width: 237px;">
                              <asp:Label ID="lblInvoiceNumber" runat="server" Height="21px" Width="300px"></asp:Label></td>                   <td style="text-align: left">
                                  E-Mail</td><td style="width: 11px">:</td><td style="text-align: left; width: 237px;">
                                  <asp:TextBox ID="txtemail" runat="server" Width="300px"></asp:TextBox></td>
       
                      </tr>
                      
                      <tr>
                          <td style="text-align: left">CustomerID</td><td>:</td><td style="text-align: left; width: 237px;">
                              <asp:Label ID="lblCustomerID" runat="server" Height="21px" Width="300px"></asp:Label></td>             <td style="text-align: left; width: 80px;">
                              Tpallets</td><td style="width: 11px">:</td><td style="text-align: left"><asp:TextBox ID="txtTPallets" runat="server"  MaxLength="15" Width="300px"></asp:TextBox></td>
            
                      </tr>
                      <tr>
                          <td style="text-align: left">Customer Name</td><td>:</td><td style="text-align: left; width: 237px;">
                              <asp:Label ID="lblCustomerName" runat="server" Height="21px" Width="300px"></asp:Label></td> <td style="text-align: left; width: 80px;">
                                   TCartons</td><td style="width: 11px">:</td><td style="text-align: left"><asp:TextBox ID="txtTCartons" runat="server"  MaxLength="15" Width="300px"></asp:TextBox></td>
            
                      </tr>
                      <tr>
                               <td style="text-align: left">InvoiceDate</td><td>:</td><td style="text-align: left; width: 237px;">
                                   <asp:Label ID="lblInvoiceDate" runat="server" Height="22px" Width="300px"></asp:Label></td>  <td style="text-align: left; width: 80px;">
                                   TGWeight</td><td style="width: 11px">:</td><td style="text-align: left"><asp:TextBox ID="txtTGWeight" runat="server" Width="300px"  ></asp:TextBox></td>
                     </tr>
                     
                       <tr>
                               <td style="text-align: left; height: 37px;">Atten</td><td style="height: 37px">:</td><td style="text-align: left; width: 237px; height: 37px;"><asp:TextBox ID="txtattento" runat="server" Width="300px"></asp:TextBox></td> <td style="text-align: left; width: 80px; height: 37px;">
                                   Dimension</td><td style="width: 11px; height: 37px;">:</td><td style="text-align: left; height: 37px;"><asp:TextBox ID="txtDimension" runat="server" Width="300px" ></asp:TextBox></td>
                     </tr>
                     
                       <tr>
                               <td style="text-align: left">Tel</td><td>:</td><td style="text-align: left; width: 237px;"><asp:TextBox ID="txttel" runat="server" CssClass= "form-control numberonly" Width="300px"></asp:TextBox></td> <td style="text-align: left; width: 80px;">
                                   TM3</td><td style="width: 11px">:</td><td style="text-align: left"><asp:TextBox ID="TxtTM3" runat="server"  MaxLength="15" Width="300px"></asp:TextBox></td>
                     </tr>
                     
                     
                        <tr>
                               <td style="text-align: left">Fax</td><td>:</td><td style="text-align: left; width: 237px;"><asp:TextBox ID="txtFaxno" runat="server" CssClass= "form-control numberonly" Width="300px"></asp:TextBox></td> <td style="text-align: left; width: 80px;">
                                   TNWeight</td><td style="width: 11px">:</td><td style="text-align: left"><asp:TextBox ID="txtTnWeight" runat="server" CssClass= "form-control numberonly" Width="300px" ></asp:TextBox></td>
                     </tr>
                       <tr>
                               <td style="text-align: left">
                                   ShipTerms</td><td>:</td><td style="text-align: left; width: 237px;"><asp:DropDownList id="ddpshipterms" runat="server" Width="300px" OnSelectedIndexChanged="ddpshipterms_SelectedIndexChanged" >
                               </asp:DropDownList>
                               </td>             <td style="text-align: left; width: 80px;">
                                   Destination</td><td style="width: 11px">:</td><td style="text-align: left">
                                   <asp:TextBox ID="txtDestination" runat="server"  Width="300px"></asp:TextBox></td>
                     </tr>
                     
                   
                      <tr>
                               <td style="text-align: left">ShipMode</td><td>:</td><td style="text-align: left; width: 237px;"><asp:DropDownList CssClass="form-control" id="ddpshipmode" runat="server" Width="300px">
                               </asp:DropDownList></td>             <td style="text-align: left; width: 80px;">
                                   Remarks</td><td style="width: 11px">:</td><td style="text-align: left">
                                   <asp:TextBox ID="TxtRemarks" runat="server" Width="300px" Height="75px" TextMode="MultiLine"></asp:TextBox></td>
                     </tr>
                       <tr>
                               <td style="text-align: left">SoldTo</td><td>:</td><td style="text-align: left; width: 237px;"><asp:TextBox ID="txtSoldto" runat="server"   Width="300px" TextMode="MultiLine" Height="75px"></asp:TextBox></td>             <td style="text-align: left; width: 80px;">
                                   Shipping Remarks</td><td style="width: 11px">:</td><td style="text-align: left">
                                   <asp:TextBox ID="TxtShippingRemarks" runat="server" Height="75px"  TextMode="MultiLine" Width="300px"></asp:TextBox></td>
                     </tr>
                        <tr>
                               <td style="text-align: left">ShipTo</td><td>:</td><td style="text-align: left; width: 237px;"><asp:TextBox ID="txtshipto" runat="server"   Width="300px" TextMode="MultiLine" Height="75px"></asp:TextBox></td>             <td style="text-align: left; width: 80px;">
                                   </td><td style="width: 11px"></td><td style="text-align: left">
                                   </td>
                     </tr>
                    
                      <tr>
                          <td align="center" colspan="3" style="text-align: right"><asp:Button runat="server" CssClass="btn btn-primary" Text="Update " OnClientClick="return validate();" id="BtnUpdate" />
                              &nbsp;<asp:Button runat="server" CssClass="btn btn-primary" Text="save" OnClientClick="return validate();" id="btnSubmit" />
                             <asp:Button runat="server" CssClass="btn btn-primary" Text="Cancel" id="btnCancel" />
                              <asp:HiddenField ID="HiddenField1" runat="server" /><asp:HiddenField ID="HiddenField2" runat="server" />
                          </td>
                      </tr>
                  </table>  
                  
              </td>
          </tr>
                   <tr style="border:1px;">
                               <td style="text-align:left;">
                                   </td>
                     </tr>
        <tr>
            <td align="left" style="background-color: #3366ff; text-align: center">
                <strong><span style="color: #ffffff">APPLIED REQUEST DETAILS</span></strong></td>
        </tr>
                  <tr>
                  <td align="left" style="height: 134px">                 
                      <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" Width="100%"  AllowPaging="True" PageSize="20" GridLines="None" CellPadding="4" ForeColor="#333333">
                      <Columns>
                      
                      
                    <asp:BoundField DataField="INVNo" HeaderText="InvoiceNo" />
                    <asp:BoundField DataField="cust_id" HeaderText="CustomerID" />
                    <asp:BoundField DataField="Customer" HeaderText="CustomerName" />
                    <asp:BoundField DataField="INVDate" DataFormatString="{0:d}" HeaderText="InvoiceDate" />
                    <asp:BoundField DataField="SoldTo" HeaderText="SoldTo"/>
                    <asp:BoundField DataField="ShipTo" HeaderText="ShipTo" />
                    <asp:BoundField DataField="Attn" HeaderText="Attn" />
                    <asp:BoundField DataField="Destination" HeaderText="Destination" />
                    <asp:BoundField DataField="CreatedBy" HeaderText="Created By" />
					<asp:BoundField DataField="Status" HeaderText="status" />
					 <asp:TemplateField HeaderText="Edit">
                        <ItemTemplate>
                            <asp:LinkButton ID="LinkButton2" runat="Server" CommandName="Change" Text="Edit" CommandArgument='<%# Eval("INVNo") %>'></asp:LinkButton>
                     </ItemTemplate>
                    </asp:TemplateField>   
                    
                      
                      </Columns>
                          <RowStyle BackColor="#EFF3FB" />
                          <FooterStyle BackColor="#507CD1" ForeColor="White" Font-Bold="True" />
                          <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
                          <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
                          <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                          <EditRowStyle BackColor="#2461BF" />
                          <AlternatingRowStyle BackColor="White" />
                  </asp:GridView>
                      
                  </td>
                  </tr>
          <tr>
             
          </tr>
          
      </table>
    
    <script src="../../js/jquery.min.js" type="text/javascript"></script>
    <script type="text/javascript"> 
       $(document).ready(function() {  
       $('.numberonly').keyup(function (e) {
           var rgx = /^[0-9]*\.?[0-9]*$/;
           this.value =  this.value.match(rgx);
       });      
   });  
    </script>
   <script type="text/javascript">
        function validate() {
         var email = document.getElementById("<%=txtEmail.ClientID%>");
        var filter = /^([a-zA-Z0-9_.-])+@(([a-zA-Z0-9-])+.)+([a-zA-Z0-9]{2,4})+$/;
//            if ($("#<%= ddpshipterms.ClientID%>").val() == "--Select--") {
//                alert("Please Specify The ShipTerms");
//                $("#<%= ddpshipterms.ClientID%>").focus();
//                return false;
//            }
            if ($("#<%= ddpshipmode.ClientID%>").val() == "--Select--") {
                alert("Please Specify The shipmode");
                $("#<%= ddpshipmode.ClientID%>").focus();
                return false;
            }
            else if ($("#<%= txtTPallets.ClientID%>").val() == "") {
                alert("Please Enter The TPallets");
                $("#<%= txtTPallets.ClientID%>").focus();
                return false;
            }
            else if ($("#<%= txtTCartons.ClientID%>").val() == "") {
                alert("Please Enter The TCartons");
                $("#<%= txtTCartons.ClientID%>").focus();
                return false;
            }
             else if ($("#<%= txtDimension.ClientID%>").val() == "") {
                alert("Please Enter The Dimension");
                $("#<%= txtDimension.ClientID%>").focus();
                return false;
            }
              else if ($("#<%= txtattento.ClientID%>").val() == "") {
                alert("Please Enter The AttenTo");
                $("#<%= txtattento.ClientID%>").focus();
                return false;
            }
              else if ($("#<%= txttel.ClientID%>").val() == "") {
                alert("Please Enter The Telephone");
                $("#<%= txttel.ClientID%>").focus();
                return false;
            }
              else if ($("#<%= txtFaxno.ClientID%>").val() == "") {
                alert("Please Enter The FaxNo");
                $("#<%= txtFaxno.ClientID%>").focus();
                return false;
            }
               else if ($("#<%= txtTnWeight.ClientID%>").val() == "") {
                alert("Please Enter The TNWeight");
                $("#<%= txtTnWeight.ClientID%>").focus();
                return false;
            }
            else if ($("#<%= txtTGWeight.ClientID%>").val() == "") {
                alert("Please Enter The TGWeight");
                $("#<%= txtTGWeight.ClientID%>").focus();
                return false;
            }
            else if ($("#<%= TxtShippingRemarks.ClientID%>").val() == "") {
                alert("Please Enter The ShippingRemarks");
                $("#<%= TxtShippingRemarks.ClientID%>").focus();
                return false;
            }            
//            else if (!filter.test(email.value)) {
//            alert('Please provide a valid email address');
//            email.focus;
//            return false;
//            }

        }
        //ChkAll Start
        $("#checkall").click(function () {
            if ($("#checkall").is(":checked")) {
                //Check/uncheck all checkboxes in list according to main checkbox
                $('#gv').find('tr').each(function () {
                    var row = $(this);
                    row.find('input[type="checkbox"]').prop('checked', true);
                });
            }
            else {
                $('#gv').find('tr').each(function () {
                    var row = $(this);
                    row.find('input[type="checkbox"]').prop('checked', false);
                });
            }
        });

        function changeChkAll(obj) {
            var chkDel = 0;
            if ($(obj).is(":checked")) {
                $('#gv').find('td').each(function () {
                    if (!$(this).find('input[type="checkbox"]').is(":checked"))
                        chkDel = 1;
                });
                if (chkDel == 0)
                    $("#checkall").prop('checked', true);
                else
                    $("#checkall").prop('checked', false);
            }
            else {
                $("#checkall").prop('checked', false);
            }
        }
        //ChkAll End 
        // delete details end
</script>

            




</ContentTemplate>
<Triggers>
    <asp:PostBackTrigger ControlID="btnSubmit" />
    <asp:AsyncPostBackTrigger ControlID="ddlInvoiceNo" EventName="SelectedIndexChanged" />
</Triggers>
    </asp:UpdatePanel>

</asp:Content>