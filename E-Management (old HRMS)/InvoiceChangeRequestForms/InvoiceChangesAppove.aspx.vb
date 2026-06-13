Imports System.Data.SqlClient
Imports System.Data
Partial Public Class InvoiceChangesAppove
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
    Dim dsapprovalInvoiceInfo As New DataSet()
    Dim ds6MRule As New DataSet()
    Dim ds6pmrulecheck As New DataSet()

    Dim dsDeliverySchedule As New DataSet()
    Dim dsDeliveryScheduleCheck As New DataSet()

    Dim dsPackagingList As New DataSet()
    Dim dsPackingListCheck As New DataSet()


    Dim Check6pmRule As Integer
    Dim Checkdelivery As Integer
    Dim Checkpackinglist As Integer


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
    Dim CreatedBy As String
    Dim dsgetApprovedinfo As New DataSet()




    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        'Dim scriptstring As String
        'scriptstring = "<script language=Javascript>" + "window.opener.document.forms(0).submit();</script>"
        'If (Not Page.ClientScript.IsClientScriptBlockRegistered(scriptstring)) Then
        '    Page.ClientScript.RegisterClientScriptBlock(Me.GetType(), "script", scriptstring)


        'End If

        If (Session("EmpCode") = Nothing) Then
            Response.Redirect("Login.aspx")
        End If
        If (Not IsPostBack()) Then


            CreatedBy = Session("EmpCode")

            'lblEmpCode.Text = Session("EmpCode")

            lblCreatedBy.Text = CreatedBy.ToString()
            lblCreatedBy.Visible = False

            Dim statusinfo As String
            statusinfo = "Waiting for Approval"
            GetChangesInvInfo(statusinfo)


            Dim statusApproved As String
            statusApproved = "Approved"
            GetApprovedInvoices(statusApproved)
            ds6pmrulecheck = Get6PMRule()
            dsDeliveryScheduleCheck = GetDeliverySchedule()
            dsPackingListCheck = GetPackagingList()




            If Get6PMRule.Tables(0).Rows.Count > 0 Then

                Check6pmRule = Convert.ToInt32(Get6PMRule.Tables(0).Rows(0).Item("enabled").ToString())

            End If

            If dsDeliveryScheduleCheck.Tables(0).Rows.Count > 0 Then

                Checkdelivery = Convert.ToInt32(dsDeliveryScheduleCheck.Tables(0).Rows(0).Item("DeliverySchedule").ToString())

            End If
            If dsPackingListCheck.Tables(0).Rows.Count > 0 Then

                Checkpackinglist = Convert.ToInt32(dsPackingListCheck.Tables(0).Rows(0).Item("PackingListVerification").ToString())

            End If

            If Check6pmRule = 1 Then

                btn6pmrule.Text = "Release 6PM Rule"

            Else
                btn6pmrule.Text = "Close 6PM Rule"
            End If

            If Checkdelivery = 1 Then

                btndeliveryschedule.Text = "Release Delivery Schedule"
            Else
                btndeliveryschedule.Text = "Close Delivery Schedule"
            End If
            If Checkpackinglist = 1 Then
                btnpackagingList.Text = "Release PackagingList"

            Else
                btnpackagingList.Text = "Close PackagingList"
            End If

        End If
    End Sub
 
    Public Function GetChangesInvInfo(ByVal Status As String)
        Using sqlCon As New SqlConnection(strCon2)
            sqlCon.Open()
            Using sqlCmd As New SqlCommand("spgetRequestedInvoice_sa", sqlCon)
                sqlCmd.CommandType = CommandType.StoredProcedure
                sqlCmd.Parameters.AddWithValue("@status", Status)
                adapter = New SqlDataAdapter(sqlCmd)
                adapter.Fill(dsInvoiceInfo)
                If dsInvoiceInfo.Tables(0).Rows.Count > 0 Then
                    GridView1.DataSource = dsInvoiceInfo.Tables(0)
                    GridView1.DataBind()
                Else
                    GridView1.DataSource = Nothing
                    GridView1.DataBind()

                End If

            End Using
        End Using

    End Function
    Public Function Get6PMRule() As DataSet
        Using sqlCon As New SqlConnection(strCon2)
            sqlCon.Open()
            Using sqlCmd As New SqlCommand("spget6pmRule_sa", sqlCon)
                sqlCmd.CommandType = CommandType.StoredProcedure
                adapter = New SqlDataAdapter(sqlCmd)
                adapter.Fill(ds6MRule)
                Return ds6MRule
            End Using
        End Using

    End Function


    Public Function CloseUpdate6pmrule_sa() As Integer

        Dim x As Integer

        Using sqlCon As New SqlConnection(strCon2)
            sqlCon.Open()
            Using sqlCmd As New SqlCommand("spudpatetoclose6pmrule_sa", sqlCon)
                sqlCmd.CommandType = CommandType.StoredProcedure
                x = Convert.ToInt32(sqlCmd.ExecuteNonQuery())

                Return x


                '  MessageBox("Saved Sucessfully")
            End Using
        End Using

    End Function


    Public Function CloseUpdateDeliverySchedule() As Integer

        Dim x As Integer

        Using sqlCon As New SqlConnection(strCon2)
            sqlCon.Open()
            Using sqlCmd As New SqlCommand("spudpatetocloseDeliverySchedule_sa", sqlCon)
                sqlCmd.CommandType = CommandType.StoredProcedure
                x = Convert.ToInt32(sqlCmd.ExecuteNonQuery())
                Return x
            End Using
        End Using

    End Function

    Public Function CloseUpdatePackingListVerification() As Integer

        Dim x As Integer

        Using sqlCon As New SqlConnection(strCon2)
            sqlCon.Open()
            Using sqlCmd As New SqlCommand("spudpatetoclosePackingListVerification_sa", sqlCon)
                sqlCmd.CommandType = CommandType.StoredProcedure
                x = Convert.ToInt32(sqlCmd.ExecuteNonQuery())
                Return x
            End Using
        End Using

    End Function

    Public Function ReleaseUpdate6pmrule_sa() As Integer

        Dim x As Integer

        Using sqlCon As New SqlConnection(strCon2)
            sqlCon.Open()
            Using sqlCmd As New SqlCommand("spudpatetorelease6pmrule_sa", sqlCon)
                sqlCmd.CommandType = CommandType.StoredProcedure
                x = Convert.ToInt32(sqlCmd.ExecuteNonQuery())

                Return x


                '  MessageBox("Saved Sucessfully")
            End Using
        End Using

    End Function


    Public Function ReleaseUpdateDeliverySchedule() As Integer

        Dim x As Integer

        Using sqlCon As New SqlConnection(strCon2)
            sqlCon.Open()
            Using sqlCmd As New SqlCommand("spudpatetoreleaseeDeliverySchedule_sa", sqlCon)
                sqlCmd.CommandType = CommandType.StoredProcedure
                x = Convert.ToInt32(sqlCmd.ExecuteNonQuery())
                Return x
            End Using
        End Using

    End Function

    Public Function ReleaseUpdatePackingListVerification() As Integer

        Dim x As Integer

        Using sqlCon As New SqlConnection(strCon2)
            sqlCon.Open()
            Using sqlCmd As New SqlCommand("spudpatetoreleasePackingListVerification_sa", sqlCon)
                sqlCmd.CommandType = CommandType.StoredProcedure
                x = Convert.ToInt32(sqlCmd.ExecuteNonQuery())
                Return x
            End Using
        End Using

    End Function

    Public Function GetDeliverySchedule() As DataSet
        Using sqlCon As New SqlConnection(strCon2)
            sqlCon.Open()
            Using sqlCmd As New SqlCommand("spgetDeliverySchedule_sa", sqlCon)
                sqlCmd.CommandType = CommandType.StoredProcedure
                adapter = New SqlDataAdapter(sqlCmd)
                adapter.Fill(dsDeliverySchedule)
                Return dsDeliverySchedule
            End Using
        End Using

    End Function
    Public Function GetPackagingList() As DataSet
        Using sqlCon As New SqlConnection(strCon2)
            sqlCon.Open()
            Using sqlCmd As New SqlCommand("spgetPackingListVerification_sa", sqlCon)
                sqlCmd.CommandType = CommandType.StoredProcedure
                adapter = New SqlDataAdapter(sqlCmd)
                adapter.Fill(dsPackagingList)
                Return dsPackagingList
            End Using
        End Using

    End Function


    Public Function GetApprovedInvoices(ByVal Status As String)
        Using sqlCon As New SqlConnection(strCon2)
            sqlCon.Open()
            Using sqlCmd As New SqlCommand("spgetRequestedInvoice_sa", sqlCon)
                sqlCmd.CommandType = CommandType.StoredProcedure
                sqlCmd.Parameters.AddWithValue("@status", Status)
                adapter = New SqlDataAdapter(sqlCmd)
                adapter.Fill(dsgetApprovedinfo)
                If dsgetApprovedinfo.Tables(0).Rows.Count > 0 Then
                    GridView2.DataSource = dsgetApprovedinfo.Tables(0)
                    GridView2.DataBind()
                Else
                    GridView2.DataSource = Nothing

                End If

            End Using
        End Using

    End Function

    Private Sub MessageBox(ByVal msg As String)
        Dim lbl As New Label()
        lbl.Text = "<script language='javascript'> window.alert('" + msg + "')</script>"
        Page.Controls.Add(lbl)
    End Sub
    Protected Sub GridView1_RowCommand(ByVal sender As System.Object, ByVal e As System.Web.UI.WebControls.GridViewCommandEventArgs) Handles GridView1.RowCommand
        If e.CommandName = "approve" Then

            CreatedBy = lblCreatedBy.Text.ToString()
            Dim issucess As Integer

            Dim status As String
            status = "Approved"

            'Determine the RowIndex of the Row whose LinkButton was clicked.
            Dim rowIndex As Integer = Convert.ToInt32(e.CommandArgument)

            'Reference the GridView Row.
            Dim row As GridViewRow = GridView1.Rows(rowIndex)
            'Fetch value of InvoiceNo.
            Dim InvoiceNumber As String = row.Cells(0).Text
            'ClientScript.RegisterStartupScript(Me.GetType(), "alert", "alert('Country: " & InvoiceNumber + "');", True)

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
                    Updatestatus(strINVNo, status, CreatedBy)

                    Dim statuswaiting As String
                    statuswaiting = "Waiting for Approval"
                    GetChangesInvInfo(statuswaiting)
                    Dim statusApproved As String
                    statusApproved = "Approved"
                    GetApprovedInvoices(statusApproved)
                    If issucess > 0 Then
                        MessageBox("Invoice Changes updated Sucessfully")

                    Else
                        MessageBox("Invoice Changes failed!Please Check")
                    End If


                End Using
            End Using

        End If


        If e.CommandName = "reject" Then
            Dim rowIndex As Integer = Convert.ToInt32(e.CommandArgument)

            Dim row As GridViewRow = GridView1.Rows(rowIndex)
            'Fetch value of InvoiceNo.
            Dim InvoiceNumber As String = row.Cells(0).Text


            Dim CreatedBy As String
            CreatedBy = lblCreatedBy.Text.ToString()

            Dim x As Integer

            x = UpdateRejectstatus(InvoiceNumber, CreatedBy)

            If x > 0 Then
                MessageBox("Invoice Changes Rejected")
            Else
                MessageBox("Invoice Changes failed!Please Check")
            End If
        End If

    End Sub
    Public Function GetInvoiceChangesDetails(ByVal InvoiceNumber As String) As DataSet
        Using sqlCon As New SqlConnection(strCon2)
            sqlCon.Open()
            '  Using sqlCmd As New SqlCommand("spgetInvoiceView_sa", sqlCon)
            Using sqlCmd As New SqlCommand("spgetInvoiceViewCompar_sa", sqlCon)
                sqlCmd.CommandType = CommandType.StoredProcedure
                sqlCmd.Parameters.AddWithValue("@InvNo", InvoiceNumber)
                adapter = New SqlDataAdapter(sqlCmd)
                adapter.Fill(dsInvoiceDetails)
                Return dsInvoiceDetails
            End Using
        End Using

    End Function


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

    Protected Sub GridView1_PageIndexChanging(ByVal sender As System.Object, ByVal e As System.Web.UI.WebControls.GridViewPageEventArgs) Handles GridView1.PageIndexChanging
        GridView1.PageIndex = e.NewPageIndex
        Dim statusinfo As String
        statusinfo = "Waiting for Approval"
        GetChangesInvInfo(statusinfo)

    End Sub

    Protected Sub GridView2_PageIndexChanging(ByVal sender As System.Object, ByVal e As System.Web.UI.WebControls.GridViewPageEventArgs) Handles GridView2.PageIndexChanging

        Dim statusApproved As String
        statusApproved = "Approved"
        GetApprovedInvoices(statusApproved)
    End Sub

    Protected Sub btn6pmrule_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn6pmrule.Click
        Dim Var6pmrule As String
        Var6pmrule = btn6pmrule.Text.ToString()
        Dim x As Integer

        If Var6pmrule.Contains("Release") = True Then

            x = CloseUpdate6pmrule_sa()
            If x > 0 Then
                'MessageBox("Changed to Close 6pm Rule")
                btn6pmrule.Text = "Close 6pm Rule"
            End If
        Else
            x = ReleaseUpdate6pmrule_sa()
            If x > 0 Then
                'MessageBox("Changed to Release 6pm Rule")
                btn6pmrule.Text = "Release 6pm Rule"
            End If
        End If

    End Sub

    Protected Sub btndeliveryschedule_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btndeliveryschedule.Click
        Dim Vardeliveryschedule As String
        Vardeliveryschedule = btndeliveryschedule.Text.ToString()
        Dim x As Integer

        If Vardeliveryschedule.Contains("Release") = True Then

            x = CloseUpdateDeliverySchedule()
            If x > 0 Then
                'MessageBox("Changed to Close DeliverySchedule")
                btndeliveryschedule.Text = "Close Delivery Schedule"
            End If
        Else
            x = ReleaseUpdateDeliverySchedule()
            If x > 0 Then
                'MessageBox("Changed to Release DeliverySchedule")
                btndeliveryschedule.Text = "Release Delivery Schedule"
            End If
        End If
    End Sub

    Protected Sub btnpackagingList_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnpackagingList.Click
        Dim VarPackingList As String
        VarPackingList = btnpackagingList.Text.ToString()
        Dim x As Integer

        If VarPackingList.Contains("Release") = True Then

            x = CloseUpdatePackingListVerification()
            If x > 0 Then
                'MessageBox("Changed to Close PackingListVerification")
                btnpackagingList.Text = "Close PackingList Verification"
            End If
        Else
            x = ReleaseUpdatePackingListVerification()
            If x > 0 Then
                'MessageBox("Changed to Release PackingListVerification")
                btnpackagingList.Text = "Release  PackingList Verification"
            End If
        End If
    End Sub
End Class