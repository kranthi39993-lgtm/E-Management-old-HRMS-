Imports System.Data.SqlClient
Imports System.Data
Imports System.Drawing


Partial Public Class InvoiceView
    Inherits System.Web.UI.Page

    'Public strCon As String = "Data Source=PROGRAMMER3;Initial Catalog=mmCRM;uid=sa;pwd=123456"
    'Public strCon2 As String = "Data Source=PROGRAMMER3;Initial Catalog=mmCRM;uid=sa;pwd=123456"

    Public strCon As String = "Data Source=192.168.0.241;Initial Catalog=mmCRM;uid=sa;"
    Public strCon2 As String = "Data Source=192.168.0.241;Initial Catalog=mmCRM;uid=sa;"

    Dim sqlCon As SqlConnection()
    Dim sqlCmd As SqlCommand()
    Dim adapter As New SqlDataAdapter()
    Dim ds As New DataSet()
    Dim dsInvoiceDetails As New DataSet()
    Dim dsInvoiceInfo As New DataSet()
    Dim ds3 As New DataSet()
    Dim ds4 As New DataSet()
    Dim strINVNo As String
    Dim strcust_id As String
    Dim strCustomerName As String
    Dim strINVDate As String
    Dim strSoldTo As String
    Dim strAttn As String
    Dim strTel As String
    Dim strFax As String
    Dim stremail As String
    Dim strTpallets As String
    Dim strTCartons As String
    Dim strTGWeight As String
    Dim strTNWeight As String
    Dim strDimension As String
    Dim strTM3 As String
    Dim strShipTerms As String
    Dim strShipTo As String
    Dim strShipMode As String
    Dim strShippingMarks As String
    Dim strDestination As String
    Dim strRemarks As String



    Dim strOriginalINVNo As String
    Dim strOriginalcust_id As String
    Dim strOriginalCustomerName As String
    Dim strOriginalINVDate As String
    Dim strOriginalSoldTo As String
    Dim strOriginalAttn As String
    Dim strOriginalTel As String
    Dim strOriginalFax As String
    Dim strOriginalemail As String
    Dim strOriginalTpallets As String
    Dim strOriginalTCartons As String
    Dim strOriginalTGWeight As String
    Dim strOriginalTNWeight As String
    Dim strOriginalDimension As String
    Dim strOriginalTM3 As String
    Dim strOriginalShipTerms As String
    Dim strOriginalShipTo As String
    Dim strOriginalShipMode As String
    Dim strOriginalShippingMarks As String
    Dim strOriginalDestination As String
    Dim strOriginalRemarks As String

    Dim strStatus As String


    Dim dsApprovedInvoiceDetails As New DataSet()

    Dim dsapprovedView As New DataSet()


    Dim dsapprovalInvoiceInfo As New DataSet()



    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load



        lblEmployeeCode.Visible = False

        If (Session("EmpCode") = Nothing) Then
            Response.Redirect("Login.aspx")
        End If
        If (Not IsPostBack()) Then

            Dim InvoiceNumber As String = Request.QueryString("id")
            Dim statusinfo As String = Request.QueryString("sinfo")

            lblInvoiceNumberInfo.Text = InvoiceNumber.ToString()
            lblEmployeeCode.Text = Session("EmpCode")



            'ds3 = GetInvoiceChangesDetails(InvoiceNumber)
            If String.IsNullOrEmpty(statusinfo) Then
                statusinfo = ""
            End If

            ds3 = GetLoadInvoiceChangesDetails(InvoiceNumber, statusinfo)



            strINVNo = Convert.ToString(ds3.Tables(0).Rows(0).Item("INVNo"))
            strcust_id = Convert.ToString(ds3.Tables(0).Rows(0).Item("cust_id"))
            strCustomerName = Convert.ToString(ds3.Tables(0).Rows(0).Item("Customer"))
            strINVDate = Convert.ToString(ds3.Tables(0).Rows(0).Item("INVDate"))
            strSoldTo = Convert.ToString(ds3.Tables(0).Rows(0).Item("SoldTo"))
            strAttn = Convert.ToString(ds3.Tables(0).Rows(0).Item("Attn"))
            strTel = Convert.ToString(ds3.Tables(0).Rows(0).Item("Tel"))
            strFax = Convert.ToString(ds3.Tables(0).Rows(0).Item("Fax"))
            stremail = Convert.ToString(ds3.Tables(0).Rows(0).Item("email"))
            strTpallets = Convert.ToString(ds3.Tables(0).Rows(0).Item("Tpallets"))
            strTCartons = Convert.ToString(ds3.Tables(0).Rows(0).Item("TCartons"))
            strTGWeight = Convert.ToString(ds3.Tables(0).Rows(0).Item("TGWeight"))
            strTNWeight = Convert.ToString(ds3.Tables(0).Rows(0).Item("TNWeight"))
            strDimension = Convert.ToString(ds3.Tables(0).Rows(0).Item("Dimension"))
            strTM3 = Convert.ToString(ds3.Tables(0).Rows(0).Item("TM3"))
            strShipTerms = Convert.ToString(ds3.Tables(0).Rows(0).Item("ShipTerms"))
            strShipTo = Convert.ToString(ds3.Tables(0).Rows(0).Item("ShipTo"))
            strShipMode = Convert.ToString(ds3.Tables(0).Rows(0).Item("ShipMode"))
            strShippingMarks = Convert.ToString(ds3.Tables(0).Rows(0).Item("ShippingMarks"))
            strDestination = Convert.ToString(ds3.Tables(0).Rows(0).Item("Destination"))
            strRemarks = Convert.ToString(ds3.Tables(0).Rows(0).Item("Remarks"))
            strStatus = Convert.ToString(ds3.Tables(0).Rows(0).Item("Status"))
            lblAppInvoiceNo.Text = strINVNo.ToString()
            lblAppRequestedBy.Text = Convert.ToString(ds3.Tables(0).Rows(0).Item("RequestedBy"))
            lblAppRequestedOn.Text = Convert.ToString(ds3.Tables(0).Rows(0).Item("RequestedOn"))


            If strStatus = "Approved" Then
                BtnApprove.Visible = False
                BtnReject.Visible = False


                dsApprovedInvoiceDetails = GetApprovalInvoiceDetails(InvoiceNumber)
                If dsApprovedInvoiceDetails.Tables(0).Rows.Count > 0 Then

                    lblAppRequestedOn.Text = Convert.ToString(dsApprovedInvoiceDetails.Tables(0).Rows(0).Item("RequestedOn"))
                    lblAppInvoiceNo.Text = Convert.ToString(dsApprovedInvoiceDetails.Tables(0).Rows(0).Item("INVNo"))
                    lblApprovedOn.Text = Convert.ToString(dsApprovedInvoiceDetails.Tables(0).Rows(0).Item("approvedon"))
                    lblAppApprovedBy.Text = Convert.ToString(dsApprovedInvoiceDetails.Tables(0).Rows(0).Item("ApprovedBy"))

                Else
                    BtnReject.Visible = True
                    lblAppRequestedOn.Text = ""
                    lblAppInvoiceNo.Text = ""
                    lblApprovedOn.Text = ""
                    lblAppApprovedBy.Text = ""


                End If


            Else
                BtnApprove.Visible = True

            End If

            lblInv.Text = strINVNo.ToString()
            lblCustomerID.Text = strcust_id.ToString()
            lblCustomerName.Text = strCustomerName.ToString()
            lblINVDate.Text = strINVDate.ToString()
            lblSoldTo.Text = strSoldTo.ToString()
            lblAttn.Text = strAttn.ToString()
            lblTel.Text = strTel.ToString()
            lblemail.Text = stremail.ToString()
            lblTpallets.Text = strTpallets.ToString()
            lblTGWeight.Text = strTGWeight.ToString()
            lblTNWeight.Text = strTNWeight.ToString()
            lblTM3.Text = strTM3.ToString()
            lblDimension.Text = strDimension.ToString()
            lblDestination.Text = strDestination.ToString()
            lblRemarks.Text = strRemarks.ToString()

            lblShipTo.Text = strShipTo.ToString()
            lblShipMode.Text = strShipMode.ToString()
            lblShipTerms.Text = strShipTerms.ToString()
            lblstatusinfo.Text = strStatus.ToString()
            lblShippingMarks.Text = strShippingMarks.ToString()


            'Repeater1.DataSource = ds3.Tables(0)
            'Repeater1.DataBind()
            ds4 = GetOriginalInvoiceDetails(InvoiceNumber)
            strOriginalINVNo = Convert.ToString(ds4.Tables(0).Rows(0).Item("INVNo"))
            strOriginalcust_id = Convert.ToString(ds4.Tables(0).Rows(0).Item("cust_id"))
            strOriginalCustomerName = Convert.ToString(ds4.Tables(0).Rows(0).Item("Customer"))
            strOriginalINVDate = Convert.ToString(ds4.Tables(0).Rows(0).Item("INVDate"))
            strOriginalSoldTo = Convert.ToString(ds4.Tables(0).Rows(0).Item("SoldTo"))
            strOriginalAttn = Convert.ToString(ds4.Tables(0).Rows(0).Item("Attn"))
            strOriginalTel = Convert.ToString(ds4.Tables(0).Rows(0).Item("Tel"))
            strOriginalFax = Convert.ToString(ds4.Tables(0).Rows(0).Item("Fax"))
            strOriginalemail = Convert.ToString(ds4.Tables(0).Rows(0).Item("email"))
            strOriginalTpallets = Convert.ToString(ds4.Tables(0).Rows(0).Item("Tpallets"))
            strOriginalTCartons = Convert.ToString(ds4.Tables(0).Rows(0).Item("TCartons"))
            strOriginalTGWeight = Convert.ToString(ds4.Tables(0).Rows(0).Item("TGWeight"))
            strOriginalTNWeight = Convert.ToString(ds4.Tables(0).Rows(0).Item("TNWeight"))
            strOriginalDimension = Convert.ToString(ds4.Tables(0).Rows(0).Item("Dimension"))
            strOriginalTM3 = Convert.ToString(ds4.Tables(0).Rows(0).Item("TM3"))
            strOriginalShipTerms = Convert.ToString(ds4.Tables(0).Rows(0).Item("ShipTerms"))
            strOriginalShipTo = Convert.ToString(ds4.Tables(0).Rows(0).Item("ShipTo"))
            strOriginalShipMode = Convert.ToString(ds4.Tables(0).Rows(0).Item("ShipMode"))
            strOriginalShippingMarks = Convert.ToString(ds4.Tables(0).Rows(0).Item("ShippingMarks"))
            strOriginalDestination = Convert.ToString(ds4.Tables(0).Rows(0).Item("Destination"))
            strOriginalRemarks = Convert.ToString(ds4.Tables(0).Rows(0).Item("Remarks"))
            'rptDetails.DataSource = ds4.Tables(0)
            'rptDetails.DataBind()


            lblViewInv.Text = strOriginalINVNo.ToString()
            lblViewCustomerID.Text = strOriginalcust_id.ToString()
            lblViewCustomerName.Text = strOriginalCustomerName.ToString()
            lblINVDate.Text = strOriginalINVDate.ToString()
            lblViewSoldTo.Text = strOriginalSoldTo.ToString()
            lblViewAttn.Text = strOriginalAttn.ToString()
            lblViewTel.Text = strOriginalTel.ToString()
            lblViewemail.Text = strOriginalemail.ToString()
            lblViewTpallets.Text = strOriginalTpallets.ToString()
            lblViewTGWeight.Text = strOriginalTGWeight.ToString()
            lblViewTNWeight.Text = strOriginalTNWeight.ToString()
            lblViewTM3.Text = strOriginalTM3.ToString()
            lblViewDimension.Text = strOriginalDimension.ToString()
            lblViewDestination.Text = strOriginalDestination.ToString()
            lblViewRemarks.Text = strOriginalRemarks.ToString()

            lblViewShipTo.Text = strOriginalShipTo.ToString()
            lblViewShipMode.Text = strOriginalShipMode.ToString()
            lblViewShipTerms.Text = strOriginalShipTerms.ToString()
            lblViewShippingMarks.Text = strOriginalShippingMarks.ToString()


            If (strSoldTo.Trim().Equals(strOriginalSoldTo.Trim())) Then

            Else
                lblSoldTo.BackColor = Color.Orange
                rmSoldTo.Style.Add(HtmlTextWriterStyle.BackgroundColor, "Orange")
            End If
            If (strAttn.Equals(strOriginalAttn)) Then

            Else
                lblAttn.BackColor = Color.Orange
                rmAttn.Style.Add(HtmlTextWriterStyle.BackgroundColor, "Orange")
            End If
            If (strTel.Equals(strOriginalTel)) Then

            Else
                lblTel.BackColor = Color.Orange
                rmTel.Style.Add(HtmlTextWriterStyle.BackgroundColor, "Orange")
            End If
            If (strFax.Equals(strOriginalFax)) Then

            Else
                lblFax.BackColor = Color.Orange
                rmFax.Style.Add(HtmlTextWriterStyle.BackgroundColor, "Orange")
            End If

            If (stremail.Equals(strOriginalemail)) Then

            Else
                lblemail.BackColor = Color.Orange
                rmemail.Style.Add(HtmlTextWriterStyle.BackgroundColor, "Orange")
            End If
            If (strTpallets.Equals(strOriginalTpallets)) Then

            Else
                lblTpallets.BackColor = Color.Orange
                rmTpallets.Style.Add(HtmlTextWriterStyle.BackgroundColor, "Orange")
            End If

            If (strTCartons.Equals(strOriginalTCartons)) Then

            Else
                lblTCartons.BackColor = Color.Orange
                rmTCartons.Style.Add(HtmlTextWriterStyle.BackgroundColor, "Orange")
            End If
            If (strTGWeight.Equals(strOriginalTGWeight)) Then

            Else
                lblTGWeight.BackColor = Color.Orange
                rmTGWeight.Style.Add(HtmlTextWriterStyle.BackgroundColor, "Orange")
            End If
            If (strTNWeight.Equals(strTNWeight)) Then

            Else
                lblTNWeight.BackColor = Color.Orange
                rmTNWeight.Style.Add(HtmlTextWriterStyle.BackgroundColor, "Orange")
            End If
            If (strDimension.Equals(strOriginalDimension)) Then

            Else
                lblDimension.BackColor = Color.Orange
                rmDimension.Style.Add(HtmlTextWriterStyle.BackgroundColor, "Orange")
            End If
            If (strTM3.Equals(strOriginalTM3)) Then

            Else
                lblTM3.BackColor = Color.Orange
                rmTM3.Style.Add(HtmlTextWriterStyle.BackgroundColor, "Orange")
            End If
            If (strShipTerms.Equals(strOriginalShipTerms)) Then

            Else
                lblShipTerms.BackColor = Color.Orange
                rmShipTerms.Style.Add(HtmlTextWriterStyle.BackgroundColor, "Orange")
            End If
            If (strShipTo.Trim().Equals(strOriginalShipTo.Trim())) Then

            Else
                lblShipTo.BackColor = Color.Orange
                rmShipTo.Style.Add(HtmlTextWriterStyle.BackgroundColor, "Orange")
            End If
            If (strShipMode.Equals(strOriginalShipMode)) Then

            Else
                lblShipMode.BackColor = Color.Orange
                rmShipMode.Style.Add(HtmlTextWriterStyle.BackgroundColor, "Orange")
            End If

            If (strShippingMarks.Trim().Equals(strOriginalShippingMarks.Trim())) Then

            Else
                lblShippingMarks.BackColor = Color.Orange
                rmShippingMarks.Style.Add(HtmlTextWriterStyle.BackgroundColor, "Orange")
            End If
            If (strDestination.Equals(strOriginalDestination)) Then

            Else
                lblDestination.BackColor = Color.Orange
                rmDestination.Style.Add(HtmlTextWriterStyle.BackgroundColor, "Orange")
            End If
            If (strRemarks.Trim().Equals(strOriginalRemarks.Trim())) Then

            Else
                lblRemarks.BackColor = Color.Orange
                rmks.Style.Add(HtmlTextWriterStyle.BackgroundColor, "Orange")

            End If


        End If



    End Sub
    Public Function GetInvoiceChangesDetails(ByVal InvoiceNumber As String) As DataSet
        Using sqlCon As New SqlConnection(strCon2)
            sqlCon.Open()
            ' Using sqlCmd As New SqlCommand("spgetInvoiceView_sa", sqlCon)
            Using sqlCmd As New SqlCommand("spgetInvoiceViewCompar_sa", sqlCon)
                sqlCmd.CommandType = CommandType.StoredProcedure
                sqlCmd.Parameters.AddWithValue("@InvNo", InvoiceNumber)
                adapter = New SqlDataAdapter(sqlCmd)
                adapter.Fill(dsInvoiceDetails)
                Return dsInvoiceDetails
            End Using
        End Using

    End Function

    Public Function GetLoadInvoiceChangesDetails(ByVal InvoiceNumber As String, ByVal statusinfo As String) As DataSet
        Using sqlCon As New SqlConnection(strCon2)
            sqlCon.Open()
            ' Using sqlCmd As New SqlCommand("spgetInvoiceView_sa", sqlCon)
            Using sqlCmd As New SqlCommand("spgetInvoiceViewComparLoad_sa", sqlCon)
                sqlCmd.CommandType = CommandType.StoredProcedure
                sqlCmd.Parameters.AddWithValue("@InvNo", InvoiceNumber)
                sqlCmd.Parameters.AddWithValue("@statusinfo", statusinfo)
                adapter = New SqlDataAdapter(sqlCmd)
                adapter.Fill(dsInvoiceDetails)
                Return dsInvoiceDetails
            End Using
        End Using

    End Function

    Public Function GetOriginalInvoiceDetails(ByVal InvoiceNumber As String) As DataSet
        Using sqlCon As New SqlConnection(strCon2)
            sqlCon.Open()
            Using sqlCmd As New SqlCommand("spgetOriginalInvoiceDetails_sa", sqlCon)
                sqlCmd.CommandType = CommandType.StoredProcedure
                sqlCmd.Parameters.AddWithValue("@InvNo", InvoiceNumber)
                adapter = New SqlDataAdapter(sqlCmd)
                adapter.Fill(dsInvoiceInfo)
                Return dsInvoiceInfo
            End Using
        End Using

    End Function


    Public Function GetApprovalInvoiceDetails(ByVal InvoiceNumber As String) As DataSet
        Using sqlCon As New SqlConnection(strCon2)
            sqlCon.Open()
            Using sqlCmd As New SqlCommand("spgetInvoiceApprovedInfo_sa", sqlCon)
                sqlCmd.CommandType = CommandType.StoredProcedure
                sqlCmd.Parameters.AddWithValue("@InvNo", InvoiceNumber)
                adapter = New SqlDataAdapter(sqlCmd)
                adapter.Fill(dsapprovedView)
                Return dsapprovedView
            End Using
        End Using

    End Function

    Protected Sub BtnApprove_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnApprove.Click

        Dim CreatedBy As String

        CreatedBy = lblEmployeeCode.Text.ToString()

        Dim issucess As Integer

        Dim status As String
        status = "Approved"

        Dim InvoiceNumber As String

        InvoiceNumber = lblInvoiceNumberInfo.Text.ToString()

        dsapprovalInvoiceInfo = GetInvoiceChangesDetails(InvoiceNumber)

        strINVNo = Convert.ToString(dsapprovalInvoiceInfo.Tables(0).Rows(0).Item("INVNo"))
        strcust_id = Convert.ToString(dsapprovalInvoiceInfo.Tables(0).Rows(0).Item("cust_id"))
        strCustomerName = Convert.ToString(dsapprovalInvoiceInfo.Tables(0).Rows(0).Item("Customer"))
        strINVDate = Convert.ToString(dsapprovalInvoiceInfo.Tables(0).Rows(0).Item("INVDate"))
        strSoldTo = Convert.ToString(dsapprovalInvoiceInfo.Tables(0).Rows(0).Item("SoldTo"))
        strAttn = Convert.ToString(dsapprovalInvoiceInfo.Tables(0).Rows(0).Item("Attn"))
        strTel = Convert.ToString(dsapprovalInvoiceInfo.Tables(0).Rows(0).Item("Tel"))
        strFax = Convert.ToString(dsapprovalInvoiceInfo.Tables(0).Rows(0).Item("Fax"))
        stremail = Convert.ToString(dsapprovalInvoiceInfo.Tables(0).Rows(0).Item("email"))
        strTpallets = Convert.ToString(dsapprovalInvoiceInfo.Tables(0).Rows(0).Item("Tpallets"))
        strTCartons = Convert.ToString(dsapprovalInvoiceInfo.Tables(0).Rows(0).Item("TCartons"))
        strTGWeight = Convert.ToString(dsapprovalInvoiceInfo.Tables(0).Rows(0).Item("TGWeight"))
        strTNWeight = Convert.ToString(dsapprovalInvoiceInfo.Tables(0).Rows(0).Item("TNWeight"))
        strDimension = Convert.ToString(dsapprovalInvoiceInfo.Tables(0).Rows(0).Item("Dimension"))
        strTM3 = Convert.ToString(dsapprovalInvoiceInfo.Tables(0).Rows(0).Item("TM3"))
        strShipTerms = Convert.ToString(dsapprovalInvoiceInfo.Tables(0).Rows(0).Item("ShipTerms"))
        strShipTo = Convert.ToString(dsapprovalInvoiceInfo.Tables(0).Rows(0).Item("ShipTo"))
        strShipMode = Convert.ToString(dsapprovalInvoiceInfo.Tables(0).Rows(0).Item("ShipMode"))
        strShippingMarks = Convert.ToString(dsapprovalInvoiceInfo.Tables(0).Rows(0).Item("ShippingMarks"))
        strDestination = Convert.ToString(dsapprovalInvoiceInfo.Tables(0).Rows(0).Item("Destination"))
        strRemarks = Convert.ToString(dsapprovalInvoiceInfo.Tables(0).Rows(0).Item("Remarks"))

        Using sqlCon As New SqlConnection(strCon)
            sqlCon.Open()
            Using sqlCmd As New SqlCommand("spUpdateOriginalInvoiceMaster_sa", sqlCon)
                sqlCmd.CommandType = CommandType.StoredProcedure
                sqlCmd.Parameters.AddWithValue("@InvNo", strINVNo)
                sqlCmd.Parameters.AddWithValue("@Attn", strAttn.ToString())
                sqlCmd.Parameters.AddWithValue("@email", stremail.ToString())
                sqlCmd.Parameters.AddWithValue("@Destination", strDestination.ToString())
                sqlCmd.Parameters.AddWithValue("@Dimension", strDimension.ToString())
                sqlCmd.Parameters.AddWithValue("@Fax", strFax.ToString())
                sqlCmd.Parameters.AddWithValue("@Modifiedby", CreatedBy)
                sqlCmd.Parameters.AddWithValue("@Remarks", strRemarks.Trim().ToString())
                sqlCmd.Parameters.AddWithValue("@SoldTo", strSoldTo.ToString())
                sqlCmd.Parameters.AddWithValue("@ShippingMarks", strShippingMarks.Trim().ToString())
                sqlCmd.Parameters.AddWithValue("@ShipTo", strShipTo.ToString())
                sqlCmd.Parameters.AddWithValue("@ShipMode", strShipMode.ToString())
                sqlCmd.Parameters.AddWithValue("@ShipTerms", strShipTerms.ToString())
                sqlCmd.Parameters.AddWithValue("@Tel", strTel.ToString())
                sqlCmd.Parameters.AddWithValue("@Tpallets", strTpallets.ToString())
                sqlCmd.Parameters.AddWithValue("@TCartons", strTCartons.ToString())
                sqlCmd.Parameters.AddWithValue("@TGWeight", strTGWeight.ToString())
                sqlCmd.Parameters.AddWithValue("@TNWeight", strTNWeight.ToString())
                sqlCmd.Parameters.AddWithValue("@TM3", strTM3.ToString())
                issucess = Convert.ToInt32(sqlCmd.ExecuteNonQuery())
                UpdateStatus(strINVNo, status, CreatedBy)

                'Dim statuswaiting As String
                'statuswaiting = "Waiting for Approval"
                'GetChangesInvInfo(statuswaiting)
                'Dim statusApproved As String
                'statusApproved = "Approved"
                'GetApprovedInvoices(statusApproved)
                If issucess > 0 Then
                    MessageBox("Invoice Changes updated Sucessfully")
                    BtnApprove.Attributes.Add("onclick", "RefreshParent();")
                    BtnApprove.Visible = False
                    ClientScript.RegisterStartupScript(GetType(Page), "closepage", "window.close();", True)



                Else
                    Messagebox("Invoice Changes failed!Please Check")
                End If

                
            End Using
        End Using

       

    End Sub

    Private Sub MessageBox(ByVal msg As String)
        Dim lbl As New Label()
        lbl.Text = "<script language='javascript'> window.alert('" + msg + "')</script>"
        Page.Controls.Add(lbl)
    End Sub
    Public Function Updatestatus(ByVal InvoiceNumber As String, ByVal status As String, ByVal ModifiedBy As String)

        Using sqlCon As New SqlConnection(strCon2)
            sqlCon.Open()
            Using sqlCmd As New SqlCommand("spUpdateInvoiceChangesstatus_Sa", sqlCon)
                sqlCmd.CommandType = CommandType.StoredProcedure
                sqlCmd.Parameters.AddWithValue("@Invno", InvoiceNumber)
                sqlCmd.Parameters.AddWithValue("@status", status)
                sqlCmd.Parameters.AddWithValue("@ModifiedBy", ModifiedBy)
                sqlCmd.ExecuteNonQuery()
                '  MessageBox("Saved Sucessfully")
            End Using
        End Using

    End Function

    Protected Sub BtnReject_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnReject.Click
        Dim InvoiceNo As String = lblInv.Text.ToString()
        Dim CreatedBy As String
        CreatedBy = lblEmployeeCode.Text.ToString()
        Dim x As Integer

        x = UpdateRejectstatus(InvoiceNo, CreatedBy)

        If x > 0 Then
            MessageBox("Invoice Changes Rejected")
        Else
            MessageBox("Invoice Changes failed!Please Check")
        End If





    End Sub

    Public Function UpdateRejectstatus(ByVal InvoiceNumber As String, ByVal ModifiedBy As String)

        Using sqlCon As New SqlConnection(strCon2)
            sqlCon.Open()
            Using sqlCmd As New SqlCommand("spUpdateRejected_sa", sqlCon)
                sqlCmd.CommandType = CommandType.StoredProcedure
                sqlCmd.Parameters.AddWithValue("@InvNo", InvoiceNumber)
                sqlCmd.Parameters.AddWithValue("@ModifiedBy", ModifiedBy)
                sqlCmd.ExecuteNonQuery()
                '  MessageBox("Saved Sucessfully")
            End Using
        End Using

    End Function
End Class