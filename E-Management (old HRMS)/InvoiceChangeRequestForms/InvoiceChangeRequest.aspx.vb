Imports System.Data.SqlClient
Imports System.Data
Partial Public Class InvoiceChangeRequest
    Inherits System.Web.UI.Page
    'Public strCon As String = "Data Source=192.168.0.241;Initial Catalog=hrmis;uid=sa;"
    ' Public strCon2 As String = "Data Source=192.168.0.241;Initial Catalog=hrmis;uid=sa;"

    'Public strCon As String = "Data Source=PROGRAMMER3;Initial Catalog=mmCRM;uid=sa;pwd=123456"
    'Public strCon2 As String = "Data Source=PROGRAMMER3;Initial Catalog=mmCRM;uid=sa;pwd=123456"

    Public strCon As String = "Data Source=192.168.0.241;Initial Catalog=mmCRM;uid=sa;"
    Public strCon2 As String = "Data Source=192.168.0.241;Initial Catalog=mmCRM;uid=sa;"

    Dim sqlCon As SqlConnection()
    Dim sqlCmd As SqlCommand()
    Dim adapter As New SqlDataAdapter()
    Dim ds As New DataSet()
    Dim dsshipMode As New DataSet()
    Dim dsshipterms As New DataSet()
    Dim dsgetRaisedRequest As New DataSet()


    Dim dsGetInvoiceDetails As New DataSet()
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
    Dim dsgetUserInvoices As New DataSet()
    Dim DsGetUserInvoiceRequest As New DataSet()
    Dim dsedit As New DataSet()
    Dim dsgetWaitingforapproval As New DataSet()

    Dim dsCheckingInvoiceNumber As New DataSet()
    Dim dscheck As New DataSet()

    Dim ds6MRule As New DataSet()
    Dim ds6pmrulecheck As New DataSet()

    Dim dsDeliverySchedule As New DataSet()
    Dim dsDeliveryScheduleCheck As New DataSet()

    Dim dsPackagingList As New DataSet()
    Dim dsPackingListCheck As New DataSet()




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

    Dim IsstrSoldTo As Boolean
    Dim IsstrAttn As Boolean
    Dim IsstrTel As Boolean
    Dim IsstrFax As Boolean
    Dim Isstremail As Boolean
    Dim IsstrTpallets As Boolean
    Dim IsstrTCartons As Boolean
    Dim IsstrTGWeight As Boolean
    Dim IsstrTNWeight As Boolean
    Dim IsstrDimension As Boolean
    Dim IsstrTM3 As Boolean
    Dim IsstrShipTerms As Boolean
    Dim IsstrShipTo As Boolean
    Dim IsstrShipMode As Boolean
    Dim IsstrShippingMarks As Boolean
    Dim IsstrDestination As Boolean
    Dim IsstrRemarks As Boolean



    Dim IsChkEmptyCurrentSoldTo As Boolean
    Dim IsChkEmptyCurrentAttn As Boolean
    Dim IsChkEmptyCurrentTel As Boolean
    Dim IsChkEmptyCurrentFax As Boolean
    Dim IsChkEmptyCurrentemail As Boolean
    Dim IsChkEmptyCurrentTpallets As Boolean
    Dim IsChkEmptyCurrentTCartons As Boolean
    Dim IsChkEmptyCurrentTGWeight As Boolean
    Dim IsChkEmptyCurrentTNWeight As Boolean
    Dim IsChkEmptyCurrentDimension As Boolean
    Dim IsChkEmptyCurrentTM3 As Boolean
    Dim IsChkEmptyCurrentShipTerms As Boolean
    Dim IsChkEmptyCurrentShipTo As Boolean
    Dim IsChkEmptyCurrentShipMode As Boolean
    Dim IsChkEmptyCurrentShippingMarks As Boolean
    Dim IsChkEmptyCurrentDestination As Boolean
    Dim IsChkEmptyCurrentRemarks As Boolean



    Dim IsChkEmptyOriginalSoldTo As Boolean
    Dim IsChkEmptyOriginalAttn As Boolean
    Dim IsChkEmptyOriginalTel As Boolean
    Dim IsChkEmptyOriginalFax As Boolean
    Dim IsChkEmptyOriginalemail As Boolean
    Dim IsChkEmptyOriginalTpallets As Boolean
    Dim IsChkEmptyOriginalTCartons As Boolean
    Dim IsChkEmptyOriginalTGWeight As Boolean
    Dim IsChkEmptyOriginalTNWeight As Boolean
    Dim IsChkEmptyOriginalDimension As Boolean
    Dim IsChkEmptyOriginalTM3 As Boolean
    Dim IsChkEmptyOriginalShipTerms As Boolean
    Dim IsChkEmptyOriginalShipTo As Boolean
    Dim IsChkEmptyOriginalShipMode As Boolean
    Dim IsChkEmptyOriginalShippingMarks As Boolean
    Dim IsChkEmptyOriginalDestination As Boolean
    Dim IsChkEmptyOriginalRemarks As Boolean

    Dim Check6pmRule As Integer
    Dim Checkdelivery As Integer
    Dim Checkpackinglist As Integer

    Dim dsOriginalInvoice As New DataSet()

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        lblEmpCode.Visible = False

        'TxtFinalShipTerms.Enabled = False

        'TxtFinalShipTerms.Visible = True
        'lblFinalShipterms.Visible = True

        lblviewupdate.Visible = False


        If (Session("EmpCode") = Nothing) Then
            Response.Redirect("Login.aspx")
        End If
        lblMsg.Text = ""
        If (Not IsPostBack()) Then
            BindInvoiceNos()
            ddpshipterms.Items.Clear()
            BindShipterms()
            DDL_RemoveDuplicateItems(ddpshipterms)
            ddpshipterms.SelectedIndex = -1


            BindShipMode()
            Dim CreatedBy As String
            CreatedBy = Session("EmpCode")

            lblEmpCode.Text = Session("EmpCode")
            HiddenField2.Value = lblEmpCode.Text.ToString()


            DsGetUserInvoiceRequest = GetUserChangeInvoiceRequestsAll(CreatedBy)

            If DsGetUserInvoiceRequest.Tables(0).Rows.Count > 0 Then

                GridView1.DataSource = DsGetUserInvoiceRequest.Tables(0)
                GridView1.DataBind()

            End If
            BtnUpdate.Visible = False


          


        End If
    End Sub
    Sub BindInvoiceNos()
        Using sqlCon As New SqlConnection(strCon2)
            sqlCon.Open()
            Using sqlCmd As New SqlCommand("spgetInvoice_sa", sqlCon)
                sqlCmd.CommandType = CommandType.StoredProcedure
                adapter = New SqlDataAdapter(sqlCmd)
                adapter.Fill(ds)
            End Using
        End Using

        ddlInvoiceNo.DataValueField = "INVNo"
        ddlInvoiceNo.DataTextField = "INVNo"
        ddlInvoiceNo.DataSource = ds
        ddlInvoiceNo.DataBind()
        ddlInvoiceNo.Items.Insert(0, "--Select--")
    End Sub


    'ShipTerms Binding 
    Sub BindShipterms()
        Using sqlCon As New SqlConnection(strCon2)
            sqlCon.Open()
            Using sqlCmd As New SqlCommand("spgetShipTerms_sa", sqlCon)
                sqlCmd.CommandType = CommandType.StoredProcedure
                adapter = New SqlDataAdapter(sqlCmd)
                adapter.Fill(dsshipterms)
            End Using
        End Using

        ddpshipterms.DataSource = dsshipterms
        ddpshipterms.DataValueField = "Shipterms"
        ddpshipterms.DataTextField = "Shipterms"
        ddpshipterms.DataBind()
        ddpshipterms.Items.Insert(0, "--Select--")
        'ddpshipterms.Items.Insert(0, New ListItem("--Select--", "0"))


    End Sub


    Sub BindShipMode()
        Using sqlCon As New SqlConnection(strCon2)
            sqlCon.Open()
            Using sqlCmd As New SqlCommand("spgetShipMode_sa", sqlCon)
                sqlCmd.CommandType = CommandType.StoredProcedure
                adapter = New SqlDataAdapter(sqlCmd)
                adapter.Fill(dsshipMode)
            End Using
        End Using

        ddpshipmode.DataValueField = "ShipMode"
        ddpshipmode.DataTextField = "ShipMode"
        ddpshipmode.DataSource = dsshipMode
        ddpshipmode.DataBind()
        ddpshipmode.Items.Insert(0, "--Select--")
    End Sub

    Protected Sub ddlInvoiceNo_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ddlInvoiceNo.SelectedIndexChanged


        Dim InvoiceNumber As String
        InvoiceNumber = ddlInvoiceNo.SelectedItem.ToString()
        HiddenField1.Value = InvoiceNumber.ToString()

        dsGetInvoiceDetails = GetInvoiceDetails(InvoiceNumber)

        Dim strInvoiceDate As Date
        'ddpshipterms.Items.Clear()
        'BindShipterms()
      

        If dsGetInvoiceDetails.Tables(0).Rows.Count > 0 Then

            strINVNo = Convert.ToString(dsGetInvoiceDetails.Tables(0).Rows(0).Item("INVNo"))
            strcust_id = Convert.ToString(dsGetInvoiceDetails.Tables(0).Rows(0).Item("cust_id"))
            strCustomerName = Convert.ToString(dsGetInvoiceDetails.Tables(0).Rows(0).Item("Customer"))
            ' strINVDate = Convert.ToString(dsGetInvoiceDetails.Tables(0).Rows(0).Item("INVDate"))
            strInvoiceDate = Convert.ToDateTime(dsGetInvoiceDetails.Tables(0).Rows(0).Item("INVDate"))
            strSoldTo = Convert.ToString(dsGetInvoiceDetails.Tables(0).Rows(0).Item("SoldTo"))
            strAttn = Convert.ToString(dsGetInvoiceDetails.Tables(0).Rows(0).Item("Attn"))
            strTel = Convert.ToString(dsGetInvoiceDetails.Tables(0).Rows(0).Item("Tel"))
            strFax = Convert.ToString(dsGetInvoiceDetails.Tables(0).Rows(0).Item("Fax"))
            stremail = Convert.ToString(dsGetInvoiceDetails.Tables(0).Rows(0).Item("email"))
            strTpallets = Convert.ToString(dsGetInvoiceDetails.Tables(0).Rows(0).Item("Tpallets"))
            strTCartons = Convert.ToString(dsGetInvoiceDetails.Tables(0).Rows(0).Item("TCartons"))
            strTGWeight = Convert.ToString(dsGetInvoiceDetails.Tables(0).Rows(0).Item("TGWeight"))
            strTNWeight = Convert.ToString(dsGetInvoiceDetails.Tables(0).Rows(0).Item("TNWeight"))
            strDimension = Convert.ToString(dsGetInvoiceDetails.Tables(0).Rows(0).Item("Dimension"))
            strTM3 = Convert.ToString(dsGetInvoiceDetails.Tables(0).Rows(0).Item("TM3"))
            strShipTerms = Convert.ToString(dsGetInvoiceDetails.Tables(0).Rows(0).Item("ShipTerms"))
            strShipTo = Convert.ToString(dsGetInvoiceDetails.Tables(0).Rows(0).Item("ShipTo"))
            strShipMode = Convert.ToString(dsGetInvoiceDetails.Tables(0).Rows(0).Item("ShipMode"))
            strShippingMarks = Convert.ToString(dsGetInvoiceDetails.Tables(0).Rows(0).Item("ShippingMarks"))
            strDestination = Convert.ToString(dsGetInvoiceDetails.Tables(0).Rows(0).Item("Destination"))
            strRemarks = Convert.ToString(dsGetInvoiceDetails.Tables(0).Rows(0).Item("Remarks"))
            lblInvoiceNumber.Text = strINVNo.ToString()
            lblCustomerID.Text = strcust_id.ToString()
            'lblInvoiceDate.Text = strINVDate.ToString()
            lblInvoiceDate.Text = strInvoiceDate.ToString("yyyy-MM-dd")
            lblCustomerName.Text = strCustomerName.ToString()
            txtSoldto.Text = strSoldTo.ToString()
            txtattento.Text = strAttn.ToString()
            txttel.Text = strTel.ToString()
            txtDimension.Text = strDimension.ToString()
            txtTCartons.Text = strTCartons.ToString()
            TxtTM3.Text = strTM3.ToString()
            txtTGWeight.Text = strTGWeight.ToString()
            txtTnWeight.Text = strTNWeight.ToString()
            'ddpshipmode.SelectedValue = Convert.ToString(dsGetInvoiceDetails.Tables(0).Rows(0).Item("ShipMode"))
            'ddpshipterms.SelectedValue = Convert.ToString(dsGetInvoiceDetails.Tables(0).Rows(0).Item("ShipTerms"))

            'ddpshipterms.SelectedValue = Convert.ToString(dsGetInvoiceDetails.Tables(0).Rows(0).Item("ShipTerms"))
            If dsGetInvoiceDetails.Tables(0).Rows(0).Item("ShipMode") = "-" And dsGetInvoiceDetails.Tables(0).Rows(0).Item("ShipMode") = "" Then

               
            Else

                ddpshipmode.SelectedValue = Convert.ToString(dsGetInvoiceDetails.Tables(0).Rows(0).Item("ShipMode"))

            End If


            If dsGetInvoiceDetails.Tables(0).Rows(0).Item("ShipTerms") = "-" And dsGetInvoiceDetails.Tables(0).Rows(0).Item("ShipTerms") = "" Then

            Else

                ''ddpshipterms.SelectedValue = Nothing
                'Using sqlCon As New SqlConnection(strCon2)
                '    sqlCon.Open()
                '    Using sqlCmd As New SqlCommand("spgetShipTerms_sa", sqlCon)
                '        sqlCmd.CommandType = CommandType.StoredProcedure
                '        adapter = New SqlDataAdapter(sqlCmd)
                '        adapter.Fill(dsshipterms)
                '    End Using
                'End Using
                'ddpshipterms.DataSource = dsshipterms
                'ddpshipterms.DataValueField = "Shipterms"
                'ddpshipterms.DataTextField = "Shipterms" 
                'ddpshipterms.DataBind()
                'ddpshipterms.Items.Insert(0, "--Select--")
                'BindShipterms()

                'ddpshipterms.SelectedIndex = -1
                'ddpshipterms.SelectedValue = Nothing
                'ddpshipterms.DataBind()
                'Dim varitem As ListItemCollection()

                'ddpshipterms.Items.FindByValue(strShipTerms).Selected = True


                'ddpshipterms.SelectedValue = strShipTerms
                ' TxtFinalShipTerms.Text = strShipTerms.ToString()


                'BindShipterms()
                'ddpshipterms.Items.Insert(0, "--Select--")
                'BindShipterms()
                ddpshipterms.SelectedItem.Text = Convert.ToString(dsGetInvoiceDetails.Tables(0).Rows(0).Item("ShipTerms"))


                'DDL_RemoveDuplicateItems(ddpshipterms)



            End If


            TxtShippingRemarks.Text = strShippingMarks.ToString()
            TxtRemarks.Text = strRemarks.ToString()
            txtemail.Text = stremail.ToString()
            txtshipto.Text = strShipTo.ToString()

            txtFaxno.Text = strFax.ToString()
            txtTPallets.Text = strTpallets.ToString()

            txtDestination.Text = strDestination.ToString()




        End If

        btnSubmit.Visible = True
        BtnUpdate.Visible = False




    End Sub


    Public Function GetInvoiceDetails(ByVal InvoiceNo As String) As DataSet
        Using sqlCon As New SqlConnection(strCon2)
            sqlCon.Open()
            Using sqlCmd As New SqlCommand("spgetInvoiceDetailsByInvoice_sa", sqlCon)
                sqlCmd.CommandType = CommandType.StoredProcedure
                sqlCmd.Parameters.AddWithValue("@InvoiceNo", InvoiceNo)
                adapter = New SqlDataAdapter(sqlCmd)
                adapter.Fill(ds)
                Return ds

            End Using
        End Using


    End Function

    Public Function GetUserChangeInvoiceRequestsAll(ByVal CreatedBy As String) As DataSet
        Using sqlCon As New SqlConnection(strCon2)
            sqlCon.Open()
            Using sqlCmd As New SqlCommand("spgetRequestedInvoicebyUserAll_sa", sqlCon)
                sqlCmd.CommandType = CommandType.StoredProcedure
                sqlCmd.Parameters.AddWithValue("@CreatedBy", CreatedBy)
                adapter = New SqlDataAdapter(sqlCmd)
                adapter.Fill(dsgetUserInvoices)
                Return dsgetUserInvoices

            End Using
        End Using


    End Function



    Public Function GetUserChangeInvoiceRequests(ByVal CreatedBy As String) As DataSet
        Using sqlCon As New SqlConnection(strCon2)
            sqlCon.Open()
            Using sqlCmd As New SqlCommand("spgetRequestedInvoicebyUser_sa", sqlCon)
                sqlCmd.CommandType = CommandType.StoredProcedure
                sqlCmd.Parameters.AddWithValue("@CreatedBy", CreatedBy)
                adapter = New SqlDataAdapter(sqlCmd)
                adapter.Fill(dsgetUserInvoices)
                Return dsgetUserInvoices

            End Using
        End Using


    End Function
    Private Sub MessageBox(ByVal msg As String)
        Dim lbl As New Label()
        lbl.Text = "<script language='javascript'> window.alert('" + msg + "')</script>"
        Page.Controls.Add(lbl)
    End Sub
    Public Function Clear()

        'Textboxes Clearing 

        lblInvoiceNumber.Text = ""
        lblCustomerID.Text = ""
        lblInvoiceDate.Text = ""
        lblCustomerName.Text = ""
        txtSoldto.Text = ""
        txtattento.Text = ""
        txttel.Text = ""
        txtDimension.Text = ""
        txtTCartons.Text = ""
        TxtTM3.Text = ""
        txtTGWeight.Text = ""
        txtTnWeight.Text = ""
        txtemail.Text = ""
        TxtShippingRemarks.Text = ""
        txtshipto.Text = ""
        txtTPallets.Text = ""
        TxtRemarks.Text = ""
        txtFaxno.Text = ""
        txtDestination.Text = ""
        'Dropdowns Clearing
        ddlInvoiceNo.SelectedIndex = -1
        ddpshipmode.SelectedIndex = -1
        ddpshipterms.SelectedIndex = -1
        BtnUpdate.Visible = False
        btnSubmit.Visible = True
        ' TxtFinalShipTerms.Text = ""




    End Function

    Protected Sub btnSubmit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSubmit.Click

        Try

       
            Dim strStatus As String
            strStatus = "Waiting for Approval"
            Dim CreatedBy As String
            CreatedBy = lblEmpCode.Text.ToString()
            Dim ModifiedBy As String
            ModifiedBy = ""
            strcust_id = lblCustomerID.Text.ToString()
            strINVDate = lblInvoiceDate.Text.ToString()
            strCustomerName = lblCustomerName.Text.ToString()
            strSoldTo = txtSoldto.Text.Trim().ToString()
            strAttn = txtattento.Text.ToString()
            strTel = txttel.Text.ToString()
            strDimension = txtDimension.Text.ToString()
            strTpallets = txtTPallets.Text.ToString()
            strTCartons = txtTCartons.Text.ToString()
            strTM3 = TxtTM3.Text.ToString()
            strTGWeight = txtTGWeight.Text.ToString()
            strTNWeight = txtTnWeight.Text.ToString()
            stremail = txtemail.Text.ToString()
            strShipTo = txtshipto.Text.Trim().ToString()
            strShippingMarks = TxtShippingRemarks.Text.Trim().ToString()
            strRemarks = TxtRemarks.Text.ToString()
            strFax = txtFaxno.Text.ToString()
            strDimension = txtDimension.Text.ToString()
            strDestination = txtDestination.Text.ToString()
            'OldCode 
            'strShipTerms = ddpshipterms.SelectedItem.ToString()
            'If strShipTerms.Contains("select") Then
            '    strShipTerms = ""
            'Else
            '    strShipTerms = ddpshipterms.SelectedItem.ToString()

            'End If


            strShipTerms = ddpshipterms.SelectedItem.ToString()
            If strShipTerms.Contains("select") Then
                strShipTerms = ""
            Else
                strShipTerms = ddpshipterms.SelectedItem.ToString()

            End If

            'strShipTerms = TxtFinalShipTerms.Text.ToString()

            'If strShipTerms.Contains("select") Then
            '    strShipTerms = ""
            'Else
            '    strShipTerms = TxtFinalShipTerms.Text.ToString()

            'End If


            strShipMode = ddpshipmode.SelectedItem.ToString()
            If strShipMode.Contains("select") Then
                strShipMode = ""
            Else
                strShipMode = ddpshipmode.SelectedItem.ToString()

            End If

            lblInvoiceNumber.Text = Convert.ToString(HiddenField1.Value)
            lblEmpCode.Text = Convert.ToString(HiddenField2.Value)

            dscheck = CheckingInvoiceNumber(lblInvoiceNumber.Text.ToString())


            'start 
            dsOriginalInvoice = GetOriginalInvoiceDetails(lblInvoiceNumber.Text.ToString())
            strOriginalINVNo = Convert.ToString(dsOriginalInvoice.Tables(0).Rows(0).Item("INVNo"))
            strOriginalcust_id = Convert.ToString(dsOriginalInvoice.Tables(0).Rows(0).Item("cust_id"))
            strOriginalCustomerName = Convert.ToString(dsOriginalInvoice.Tables(0).Rows(0).Item("Customer"))
            strOriginalINVDate = Convert.ToString(dsOriginalInvoice.Tables(0).Rows(0).Item("INVDate"))
            strOriginalSoldTo = Convert.ToString(dsOriginalInvoice.Tables(0).Rows(0).Item("SoldTo"))
            strOriginalAttn = Convert.ToString(dsOriginalInvoice.Tables(0).Rows(0).Item("Attn"))
            strOriginalTel = Convert.ToString(dsOriginalInvoice.Tables(0).Rows(0).Item("Tel"))
            strOriginalFax = Convert.ToString(dsOriginalInvoice.Tables(0).Rows(0).Item("Fax"))
            strOriginalemail = Convert.ToString(dsOriginalInvoice.Tables(0).Rows(0).Item("email"))
            strOriginalTpallets = Convert.ToString(dsOriginalInvoice.Tables(0).Rows(0).Item("Tpallets"))
            strOriginalTCartons = Convert.ToString(dsOriginalInvoice.Tables(0).Rows(0).Item("TCartons"))
            strOriginalTGWeight = Convert.ToString(dsOriginalInvoice.Tables(0).Rows(0).Item("TGWeight"))
            strOriginalTNWeight = Convert.ToString(dsOriginalInvoice.Tables(0).Rows(0).Item("TNWeight"))
            strOriginalDimension = Convert.ToString(dsOriginalInvoice.Tables(0).Rows(0).Item("Dimension"))
            strOriginalTM3 = Convert.ToString(dsOriginalInvoice.Tables(0).Rows(0).Item("TM3"))
            strOriginalShipTerms = Convert.ToString(dsOriginalInvoice.Tables(0).Rows(0).Item("ShipTerms"))
            strOriginalShipTo = Convert.ToString(dsOriginalInvoice.Tables(0).Rows(0).Item("ShipTo"))
            strOriginalShipMode = Convert.ToString(dsOriginalInvoice.Tables(0).Rows(0).Item("ShipMode"))
            strOriginalShippingMarks = Convert.ToString(dsOriginalInvoice.Tables(0).Rows(0).Item("ShippingMarks"))
            strOriginalDestination = Convert.ToString(dsOriginalInvoice.Tables(0).Rows(0).Item("Destination"))
            strOriginalRemarks = Convert.ToString(dsOriginalInvoice.Tables(0).Rows(0).Item("Remarks"))
            'End 


            'If strSoldTo.Trim().Equals(strOriginalSoldTo.Trim()) And strAttn.Trim().Equals(strOriginalAttn) And strTel.Trim().Equals(strOriginalTel.Trim()) And (strFax.Equals(strOriginalFax)) And (stremail.Equals(strOriginalemail)) And (strTpallets.Equals(strOriginalTpallets)) And (strTCartons.Equals(strOriginalTCartons)) And (strTGWeight.Equals(strOriginalTGWeight)) And (strTNWeight.Equals(strTNWeight)) And (strDimension.Equals(strOriginalDimension)) And (strTM3.Equals(strOriginalTM3)) Then
            'and  (strShipTerms.Equals(strOriginalShipTerms)) 
            'and  (strShipTo.Trim().Equals(strOriginalShipTo.Trim()))            
            'and  (strShipMode.Equals(strOriginalShipMode))          
            'and  (strShippingMarks.Equals(strOriginalShippingMarks))          
            'and  (strDestination.Equals(strOriginalDestination))            
            'and  (strRemarks.Equals(strOriginalRemarks))  Then

            'End If
            'If UCase(strSoldTo) = UCase() Then       '..Exactly the same
            '    IsstrSoldTo = True
            'Else
            '    IsstrSoldTo = False
            'End If
            If String.IsNullOrEmpty(strOriginalSoldTo) Then

                IsChkEmptyOriginalSoldTo = True

            Else

                IsChkEmptyOriginalSoldTo = False
            End If

            If String.IsNullOrEmpty(strOriginalTel) Then

                IsChkEmptyOriginalTel = True
            Else

                IsChkEmptyOriginalTel = False
            End If

            If String.IsNullOrEmpty(strOriginalFax) Then
                IsChkEmptyOriginalFax = True

            Else
                IsChkEmptyOriginalFax = False
            End If

            If String.IsNullOrEmpty(strOriginalemail) Then
                IsChkEmptyOriginalemail = True
            Else
                IsChkEmptyOriginalemail = False
            End If

            If String.IsNullOrEmpty(strOriginalTpallets) Then
                IsChkEmptyOriginalTpallets = True
            Else
                IsChkEmptyOriginalTpallets = False
            End If
            If String.IsNullOrEmpty(strOriginalTCartons) Then
                IsChkEmptyOriginalTCartons = True
            Else
                IsChkEmptyOriginalTCartons = False
            End If
            If String.IsNullOrEmpty(strOriginalTGWeight) Then
                IsChkEmptyOriginalTGWeight = True
            Else
                IsChkEmptyOriginalTGWeight = False
            End If
            If String.IsNullOrEmpty(strOriginalTNWeight) Then
                IsChkEmptyOriginalTGWeight = True
            Else
                IsChkEmptyOriginalTGWeight = False
            End If
            If String.IsNullOrEmpty(strOriginalDimension) Then
                IsChkEmptyOriginalDimension = True
            Else
                IsChkEmptyOriginalDimension = False
            End If
            If String.IsNullOrEmpty(strOriginalTM3) Then
                IsChkEmptyOriginalTM3 = True

            Else
                IsChkEmptyOriginalTM3 = False
            End If

            'Old 

            If String.IsNullOrEmpty(strOriginalShipTerms) Then

                IsChkEmptyOriginalShipTerms = True


            Else
                IsChkEmptyOriginalShipTerms = False
            End If


            'If String.IsNullOrEmpty(strOriginalShipTerms) Then
            '    If TxtFinalShipTerms.Text.Contains("Select") Then
            '        IsChkEmptyOriginalShipTerms = False
            '    Else
            '        IsChkEmptyOriginalShipTerms = True
            '    End If

            'Else
            '    IsChkEmptyOriginalShipTerms = False
            'End If



            
            If String.IsNullOrEmpty(strOriginalShipTo) Then
                IsChkEmptyOriginalShipTo = True
            Else
                IsChkEmptyOriginalShipTo = False
            End If
            If String.IsNullOrEmpty(strOriginalShipMode) Then
                IsChkEmptyOriginalShipMode = True
            Else
                IsChkEmptyOriginalShipMode = False
            End If
            If String.IsNullOrEmpty(strOriginalShippingMarks) Then
                IsChkEmptyOriginalShippingMarks = True
            Else
                IsChkEmptyOriginalShippingMarks = False
            End If
            If String.IsNullOrEmpty(strOriginalDestination) Then
                IsChkEmptyOriginalDestination = True
            Else

                IsChkEmptyOriginalDestination = False
            End If
            If String.IsNullOrEmpty(strOriginalRemarks) Then
                IsChkEmptyOriginalRemarks = True
            Else
                IsChkEmptyOriginalRemarks = False

            End If

            'Current 
            If String.IsNullOrEmpty(strSoldTo) Then

                IsChkEmptyCurrentSoldTo = True

            Else

                IsChkEmptyCurrentSoldTo = False
            End If

            If String.IsNullOrEmpty(strTel) Then

                IsChkEmptyCurrentTel = True
            Else

                IsChkEmptyCurrentTel = False
            End If

            If String.IsNullOrEmpty(strFax) Then
                IsChkEmptyCurrentFax = True

            Else
                IsChkEmptyCurrentFax = False
            End If

            If String.IsNullOrEmpty(stremail) Then
                IsChkEmptyCurrentemail = True
            Else
                IsChkEmptyCurrentemail = False
            End If

            If String.IsNullOrEmpty(strTpallets) Then
                IsChkEmptyCurrentTpallets = True
            Else
                IsChkEmptyCurrentTpallets = False
            End If
            If String.IsNullOrEmpty(strTCartons) Then
                IsChkEmptyCurrentTCartons = True
            Else
                IsChkEmptyCurrentTCartons = False
            End If
            If String.IsNullOrEmpty(strTGWeight) Then
                IsChkEmptyCurrentTGWeight = True
            Else
                IsChkEmptyCurrentTGWeight = False
            End If
            If String.IsNullOrEmpty(strTNWeight) Then
                IsChkEmptyCurrentTGWeight = True
            Else
                IsChkEmptyCurrentTGWeight = False
            End If
            If String.IsNullOrEmpty(strDimension) Then
                IsChkEmptyCurrentDimension = True
            Else
                IsChkEmptyCurrentDimension = False
            End If
            If String.IsNullOrEmpty(strTM3) Then
                IsChkEmptyCurrentTM3 = True

            Else
                IsChkEmptyCurrentTM3 = False
            End If
            'Old
            If String.IsNullOrEmpty(strShipTerms) Then

                IsChkEmptyCurrentShipTerms = True
            Else
                IsChkEmptyCurrentShipTerms = False
            End If


            'If String.IsNullOrEmpty(strShipTerms) Then
            '    If TxtFinalShipTerms.Text.Contains("Select") Then
            '        IsChkEmptyCurrentShipTerms = False
            '    Else
            '        IsChkEmptyCurrentShipTerms = True
            '    End If

            'Else
            '    If TxtFinalShipTerms.Text.Contains("Select") Then
            '        IsChkEmptyCurrentShipTerms = False
            '    Else
            '        IsChkEmptyCurrentShipTerms = True
            '    End If

            'End If


            If String.IsNullOrEmpty(strShipTo) Then
                IsChkEmptyCurrentShipTo = True
            Else
                IsChkEmptyCurrentShipTo = False
            End If
            If String.IsNullOrEmpty(strShipMode) Then
                IsChkEmptyCurrentShipMode = True
            Else
                IsChkEmptyCurrentShipMode = False
            End If
            If String.IsNullOrEmpty(strShippingMarks) Then
                IsChkEmptyCurrentShippingMarks = True
            Else
                IsChkEmptyCurrentShippingMarks = False
            End If
            If String.IsNullOrEmpty(strDestination) Then
                IsChkEmptyCurrentDestination = True
            Else

                IsChkEmptyCurrentDestination = False
            End If
            If String.IsNullOrEmpty(strRemarks) Then
                IsChkEmptyCurrentRemarks = True
            Else
                IsChkEmptyCurrentRemarks = False

            End If



            If (strSoldTo.Trim().Equals(strOriginalSoldTo.Trim())) Then
                IsstrSoldTo = True


            Else
                IsstrSoldTo = False


            End If


            'If String.Compare(strSoldTo, strOriginalShipTo, StringComparison.OrdinalIgnoreCase) = 0 Then
            '    IsstrSoldTo = True
            'Else
            '    IsstrSoldTo = False
            'End If





            If (strAttn.Equals(strOriginalAttn)) Then
                IsstrAttn = True
            Else
                IsstrAttn = False

            End If
            If (strTel.Equals(strOriginalTel)) Then
                IsstrTel = True
            Else
                IsstrTel = False

            End If
            If (strFax.Equals(strOriginalFax)) Then
                IsstrFax = True

            Else
                IsstrFax = False

            End If

            If (stremail.Equals(strOriginalemail)) Then
                Isstremail = True

            Else
                Isstremail = False

            End If
            If (strTpallets.Equals(strOriginalTpallets)) Then
                IsstrTpallets = True
            Else
                IsstrTpallets = False

            End If

            If (strTCartons.Equals(strOriginalTCartons)) Then
                IsstrTCartons = True
            Else
                IsstrTCartons = False

            End If
            If (strTGWeight.Equals(strOriginalTGWeight)) Then
                IsstrTGWeight = True

            Else
                IsstrTGWeight = False

            End If
            If (strTNWeight.Equals(strTNWeight)) Then
                IsstrTNWeight = True
            Else
                IsstrTNWeight = False

            End If
            If (strDimension.Equals(strOriginalDimension)) Then
                IsstrDimension = True

            Else
                IsstrDimension = False

            End If
            If (strTM3.Equals(strOriginalTM3)) Then
                IsstrTM3 = True

            Else
                IsstrTM3 = False

            End If
            If (strShipTerms.Equals(strOriginalShipTerms)) Then
                IsstrShipTerms = True
            Else
                IsstrShipTerms = False

            End If
            If (strShipTo.Trim().Equals(strOriginalShipTo.Trim())) Then
                IsstrShipTo = True
            Else
                IsstrShipTo = False
            End If
            If (strShipMode.Equals(strOriginalShipMode)) Then
                IsstrShipMode = True

            Else
                IsstrShipMode = False

            End If

            If (strShippingMarks.Trim().Equals(strOriginalShippingMarks.Trim())) Then
                IsstrShippingMarks = True

            Else
                IsstrShippingMarks = False

            End If
            If (strDestination.Equals(strOriginalDestination)) Then
                IsstrDestination = True
            Else
                IsstrDestination = False

            End If
            If (strRemarks.Trim().Equals(strOriginalRemarks.Trim())) Then
                IsstrRemarks = True
            Else
                IsstrRemarks = False


            End If


            If IsstrSoldTo = True And IsstrAttn = True And IsstrTel = True And IsstrFax = True And Isstremail = True And IsstrTpallets = True And IsstrTCartons = True And IsstrTGWeight = True And IsstrTNWeight = True And IsstrDimension = True And IsstrTM3 = True And IsstrShipTerms = True And IsstrShipTo = True And IsstrShipMode = True And IsstrShippingMarks = True And IsstrDestination = True And IsstrRemarks = True Then

                MessageBox("No Changes Noticed For this Request!Please check")


            Else
                'Original is not empty  and current is empty then show message 

                If IsChkEmptyOriginalAttn = False And IsChkEmptyCurrentAttn = True Then
                    MessageBox("Attention should not empty")

                ElseIf IsChkEmptyOriginalTel = False And IsChkEmptyCurrentTel = True Then
                    MessageBox("Telephone should not empty")

                ElseIf IsChkEmptyOriginalDestination = False And IsChkEmptyCurrentDestination = True Then
                    MessageBox("Destination should not empty")

                ElseIf IsChkEmptyOriginalDimension = False And IsChkEmptyCurrentDimension = True Then
                    MessageBox("Dimension should not empty")

                ElseIf IsChkEmptyOriginalemail = False And IsChkEmptyCurrentemail = True Then
                    MessageBox("InvoiceNumber already requested for Change.Please Check")

                ElseIf IsChkEmptyOriginalFax = False And IsChkEmptyCurrentFax = True Then
                    MessageBox("Fax should not empty")

                ElseIf IsChkEmptyOriginalRemarks = False And IsChkEmptyCurrentRemarks = True Then
                    MessageBox("Remarks should not empty")

                ElseIf IsChkEmptyOriginalShipMode = False And IsChkEmptyCurrentShipMode = True Then
                    MessageBox("ShipMode should not emtpy")

                ElseIf IsChkEmptyOriginalShipTerms = False And IsChkEmptyCurrentShipTerms = True Then
                    MessageBox("ShipTerms ShouldNot empty")

                    'Added 
                    'ElseIf IsChkEmptyOriginalShipTerms = False And IsChkEmptyCurrentShipTerms = False Then
                    '    MessageBox("ShipTerms ShouldNot empty")


                ElseIf IsChkEmptyOriginalShipTo = False And IsChkEmptyCurrentShipTo = True Then
                    MessageBox("ShipTo Should not empty")

                ElseIf IsChkEmptyOriginalSoldTo = False And IsChkEmptyCurrentSoldTo = True Then
                    MessageBox("SoldToShould not empty")


                ElseIf IsChkEmptyOriginalShippingMarks = False And IsChkEmptyCurrentShippingMarks = True Then
                    MessageBox("ShippingMarksshould not empty")

                ElseIf IsChkEmptyOriginalTCartons = False And IsChkEmptyCurrentTCartons = True Then
                    MessageBox("TCartons should not empty")


                ElseIf IsChkEmptyOriginalTGWeight = False And IsChkEmptyCurrentTGWeight = True Then

                    MessageBox("TGWeight should not empty")

                ElseIf IsChkEmptyOriginalTM3 = False And IsChkEmptyCurrentTM3 = True Then

                    MessageBox("TM3 should not empty")

                ElseIf IsChkEmptyOriginalTNWeight = False And IsChkEmptyCurrentTNWeight = True Then
                    MessageBox("TNWeight should not empty")


                ElseIf IsChkEmptyOriginalTpallets = False And IsChkEmptyCurrentTpallets = True Then

                    MessageBox("Total Pallets should not empty")

                Else

                    If dscheck.Tables(0).Rows.Count > 0 Then

                        MessageBox("InvoiceNumber already requested for Change.Please Check")


                    Else

                        Using sqlCon As New SqlConnection(strCon)
                            sqlCon.Open()
                            Using sqlCmd As New SqlCommand("spInsertInvoiceRequest_sa", sqlCon)
                                sqlCmd.CommandType = CommandType.StoredProcedure
                                sqlCmd.Parameters.AddWithValue("@InvoiceNo", ddlInvoiceNo.SelectedItem.ToString())
                                sqlCmd.Parameters.AddWithValue("@cust_id", strcust_id)
                                sqlCmd.Parameters.AddWithValue("@CustomerName ", strCustomerName)
                                sqlCmd.Parameters.AddWithValue("@INVDate", strINVDate)
                                sqlCmd.Parameters.AddWithValue("@SoldTo", strSoldTo.Trim().ToString())
                                sqlCmd.Parameters.AddWithValue("@Attn", strAttn)
                                sqlCmd.Parameters.AddWithValue("@Tel", strTel)
                                sqlCmd.Parameters.AddWithValue("@Fax", strFax)
                                sqlCmd.Parameters.AddWithValue("@email", stremail)
                                sqlCmd.Parameters.AddWithValue("@Tpallets", strTpallets)
                                sqlCmd.Parameters.AddWithValue("@TCartons", strTCartons)
                                sqlCmd.Parameters.AddWithValue("@TGWeight", strTGWeight)
                                sqlCmd.Parameters.AddWithValue("@TNWeight", strTNWeight)
                                sqlCmd.Parameters.AddWithValue("@Dimension", strDimension)
                                sqlCmd.Parameters.AddWithValue("@TM3", strTM3)
                                sqlCmd.Parameters.AddWithValue("@ShipTerms ", strShipTerms.ToString())
                                sqlCmd.Parameters.AddWithValue("@ShipTo", strShipTo.Trim().ToString())
                                sqlCmd.Parameters.AddWithValue("@ShipMode", ddpshipmode.SelectedItem.ToString())
                                sqlCmd.Parameters.AddWithValue("@ShippingMarks", strShippingMarks.ToString())
                                sqlCmd.Parameters.AddWithValue("@Destination", strDestination.ToString())
                                sqlCmd.Parameters.AddWithValue("@Remarks", strRemarks.ToString())
                                sqlCmd.Parameters.AddWithValue("@Status", strStatus)
                                sqlCmd.Parameters.AddWithValue("@Createdby", CreatedBy)
                                sqlCmd.Parameters.AddWithValue("@ModifiedBy", ModifiedBy)
                                sqlCmd.ExecuteNonQuery()
                                'sqlCmd.Parameters.AddWithValue("@returnval", 0).Direction = ParameterDirection.Output
                                MessageBox("Saved Sucessfully")
                                Clear()
                                GetChangesInvInfoAll(lblEmpCode.Text.ToString())

                                'If (returnval = "0") Then
                                '    lblMsg.Text = "Details Already Exists"
                                'Else
                                '    lblMsg.Text = "Details Updated Successfully"
                                '    ' clear()
                                '    BindGrid()
                                'End If
                            End Using
                        End Using

                    End If


                End If



            End If



        Catch ex As Exception
            MessageBox(ex.ToString())


        End Try

    End Sub


    Public Function GetChangesInvInfo(ByVal CreatedBy As String)
        Using sqlCon As New SqlConnection(strCon2)
            sqlCon.Open()
            Using sqlCmd As New SqlCommand("spgetRequestedInvoicebyUser_sa", sqlCon)
                sqlCmd.CommandType = CommandType.StoredProcedure
                sqlCmd.Parameters.AddWithValue("@CreatedBy", CreatedBy)
                adapter = New SqlDataAdapter(sqlCmd)
                adapter.Fill(dsgetRaisedRequest)

                If dsgetRaisedRequest.Tables(0).Rows.Count > 0 Then

                    GridView1.DataSource = dsgetRaisedRequest.Tables(0)
                    GridView1.DataBind()
                Else
                    GridView1.DataSource = Nothing

                End If


            End Using
        End Using

    End Function


    Public Function GetChangesInvInfoAll(ByVal CreatedBy As String)
        Using sqlCon As New SqlConnection(strCon2)
            sqlCon.Open()
            Using sqlCmd As New SqlCommand("spgetRequestedInvoicebyUserAll_sa", sqlCon)
                sqlCmd.CommandType = CommandType.StoredProcedure
                sqlCmd.Parameters.AddWithValue("@CreatedBy", CreatedBy)
                adapter = New SqlDataAdapter(sqlCmd)
                adapter.Fill(dsgetRaisedRequest)

                If dsgetRaisedRequest.Tables(0).Rows.Count > 0 Then

                    GridView1.DataSource = dsgetRaisedRequest.Tables(0)
                    GridView1.DataBind()
                Else
                    GridView1.DataSource = Nothing

                End If


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
                adapter.Fill(dsOriginalInvoice)
                Return dsOriginalInvoice
            End Using
        End Using

    End Function


    Protected Sub btnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancel.Click
        Clear()

    End Sub

    Protected Sub GridView1_PageIndexChanging(ByVal sender As System.Object, ByVal e As System.Web.UI.WebControls.GridViewPageEventArgs) Handles GridView1.PageIndexChanging
        GridView1.PageIndex = e.NewPageIndex
        DsGetUserInvoiceRequest = GetUserChangeInvoiceRequestsAll(lblEmpCode.Text.ToString())

        If DsGetUserInvoiceRequest.Tables(0).Rows.Count > 0 Then
            GridView1.DataSource = DsGetUserInvoiceRequest.Tables(0)
            GridView1.DataBind()
        End If

    End Sub

    Protected Sub GridView1_RowCommand(ByVal sender As System.Object, ByVal e As System.Web.UI.WebControls.GridViewCommandEventArgs) Handles GridView1.RowCommand
        If e.CommandName = "Change" Then

            ''Determine the RowIndex of the Row whose LinkButton was clicked.
            'Dim rowIndex As Integer = Convert.ToInt32(e.CommandArgument)
            'TxtFinalShipTerms.Visible = False
            'lblFinalShipterms.Visible = False

            lblviewupdate.Text = "Edit"

            ''Reference the GridView Row.
            'Dim row As GridViewRow = GridView1.Rows(rowIndex)
            'Fetch value of InvoiceNo.
            ' Dim InvoiceNumber As String = row.Cells(0).Text

            Dim InvoiceNumber As String

            InvoiceNumber = e.CommandArgument.ToString()
            dsedit = GetInvoiceChangesDetails(InvoiceNumber)
            Dim strInvoiceDate As Date
            If dsedit.Tables(0).Rows.Count > 0 Then

                strINVNo = Convert.ToString(dsedit.Tables(0).Rows(0).Item("INVNo"))
                strcust_id = Convert.ToString(dsedit.Tables(0).Rows(0).Item("cust_id"))
                strCustomerName = Convert.ToString(dsedit.Tables(0).Rows(0).Item("Customer"))
                ' strINVDate = Convert.ToString(dsedit.Tables(0).Rows(0).Item("INVDate"))
                strInvoiceDate = Convert.ToDateTime(dsedit.Tables(0).Rows(0).Item("INVDate"))
                strSoldTo = Convert.ToString(dsedit.Tables(0).Rows(0).Item("SoldTo"))
                strAttn = Convert.ToString(dsedit.Tables(0).Rows(0).Item("Attn"))
                strTel = Convert.ToString(dsedit.Tables(0).Rows(0).Item("Tel"))
                strFax = Convert.ToString(dsedit.Tables(0).Rows(0).Item("Fax"))
                stremail = Convert.ToString(dsedit.Tables(0).Rows(0).Item("email"))
                strTpallets = Convert.ToString(dsedit.Tables(0).Rows(0).Item("Tpallets"))
                strTCartons = Convert.ToString(dsedit.Tables(0).Rows(0).Item("TCartons"))
                strTGWeight = Convert.ToString(dsedit.Tables(0).Rows(0).Item("TGWeight"))
                strTNWeight = Convert.ToString(dsedit.Tables(0).Rows(0).Item("TNWeight"))
                strDimension = Convert.ToString(dsedit.Tables(0).Rows(0).Item("Dimension"))
                strTM3 = Convert.ToString(dsedit.Tables(0).Rows(0).Item("TM3"))
                strShipTerms = Convert.ToString(dsedit.Tables(0).Rows(0).Item("ShipTerms"))
                strShipTo = Convert.ToString(dsedit.Tables(0).Rows(0).Item("ShipTo"))
                strShipMode = Convert.ToString(dsedit.Tables(0).Rows(0).Item("ShipMode"))
                strShippingMarks = Convert.ToString(dsedit.Tables(0).Rows(0).Item("ShippingMarks"))
                strDestination = Convert.ToString(dsedit.Tables(0).Rows(0).Item("Destination"))
                strRemarks = Convert.ToString(dsedit.Tables(0).Rows(0).Item("Remarks"))
                lblInvoiceNumber.Text = strINVNo.ToString()
                lblCustomerID.Text = strcust_id.ToString()
                'lblInvoiceDate.Text = strINVDate.ToString()
                lblInvoiceDate.Text = strInvoiceDate.ToString("yyyy-MM-dd")
                lblCustomerName.Text = strCustomerName.ToString()
                txtSoldto.Text = strSoldTo.ToString()
                txtattento.Text = strAttn.ToString()
                txttel.Text = strTel.ToString()
                txtDimension.Text = strDimension.ToString()
                txtTCartons.Text = strTCartons.ToString()
                TxtTM3.Text = strTM3.ToString()
                txtTGWeight.Text = strTGWeight.ToString()
                txtTnWeight.Text = strTNWeight.ToString()


    


                ddpshipterms.SelectedItem.Text = Convert.ToString(dsedit.Tables(0).Rows(0).Item("ShipTerms"))
                If dsedit.Tables(0).Rows(0).Item("ShipMode") = "-" Then

                Else
                    ddpshipmode.SelectedValue = Convert.ToString(dsedit.Tables(0).Rows(0).Item("ShipMode"))

                End If
                TxtShippingRemarks.Text = strShippingMarks.ToString()
                TxtRemarks.Text = strRemarks.ToString()
                txtemail.Text = stremail.ToString()
                txtshipto.Text = strShipTo.ToString()

                txtFaxno.Text = strFax.ToString()
                txtTPallets.Text = strTpallets.ToString()

                txtDestination.Text = strDestination.ToString()




            End If

        End If
        BtnUpdate.Visible = True
        btnSubmit.Visible = False

        'If e.CommandName = "reject" Then

        '    Dim InvoiceNumber As String
        '    InvoiceNumber = e.CommandArgument.ToString()
        '    Dim CreatedBy As String
        '    CreatedBy = lblEmpCode.Text.ToString()

        '    Dim x As Integer

        '    x = UpdateRejectstatus(InvoiceNumber, CreatedBy)

        '    If x > 0 Then
        '        MessageBox("Invoice Changes Rejected")
        '    Else
        '        MessageBox("Invoice Changes failed!Please Check")
        '    End If


        'End If


    End Sub


    Public Function GetInvoiceChangesDetails(ByVal InvoiceNumber As String) As DataSet
        Using sqlCon As New SqlConnection(strCon2)
            sqlCon.Open()
            Using sqlCmd As New SqlCommand("spgetInvoiceView_sa", sqlCon)
                sqlCmd.CommandType = CommandType.StoredProcedure
                sqlCmd.Parameters.AddWithValue("@InvNo", InvoiceNumber)
                adapter = New SqlDataAdapter(sqlCmd)
                adapter.Fill(dsgetWaitingforapproval)
                Return dsgetWaitingforapproval
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

    Public Shared Function DDL_RemoveDuplicateItems(ByVal ddl As DropDownList) As DropDownList
        For i As Integer = 0 To ddl.Items.Count - 1
            ddl.SelectedIndex = i
            Dim str As String = ddl.SelectedItem.ToString()
            For counter As Integer = i + 1 To ddl.Items.Count - 1
                ddl.SelectedIndex = counter
                Dim compareStr As String = ddl.SelectedItem.ToString()
                If str = compareStr Then
                    ddl.Items.RemoveAt(counter)
                    counter = counter - 1
                End If
            Next
        Next
        Return ddl
    End Function

    Public Function CheckingInvoiceNumber(ByVal InvoiceNumber As String) As DataSet
        Using sqlCon As New SqlConnection(strCon2)
            sqlCon.Open()
            Using sqlCmd As New SqlCommand("spCheckingInvoiceForwaitingApproval", sqlCon)
                sqlCmd.CommandType = CommandType.StoredProcedure
                sqlCmd.Parameters.AddWithValue("@InvNo", InvoiceNumber)
                adapter = New SqlDataAdapter(sqlCmd)
                adapter.Fill(dsCheckingInvoiceNumber)
                Return dsCheckingInvoiceNumber
            End Using
        End Using

    End Function

    Protected Sub BtnUpdate_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnUpdate.Click
        Dim isSucess As Integer

        Dim CreatedBy As String
        strINVNo = lblInvoiceNumber.Text.ToString()

        strSoldTo = txtSoldto.Text.ToString()
        strAttn = txtattento.Text.ToString()
        strTel = txttel.Text.ToString()
        strDimension = txtDimension.Text.ToString()
        strTCartons = txtTCartons.Text.ToString()
        strTM3 = TxtTM3.Text.ToString()
        strTGWeight = txtTGWeight.Text.ToString()
        strTNWeight = txtTnWeight.Text.ToString()
        CreatedBy = lblEmpCode.Text.ToString()

        strShippingMarks = TxtShippingRemarks.Text.ToString()
        strRemarks = TxtRemarks.Text.ToString()
        stremail = txtemail.Text.ToString()
        strShipTo = txtshipto.Text.ToString()
        strFax = txtFaxno.Text.ToString()
        strTpallets = txtTPallets.Text.ToString()
        strDestination = txtDestination.Text.ToString()

        strShipMode = ddpshipmode.SelectedItem.ToString()

        If strShipMode.Contains("select") Then
            strShipMode = ""
        Else
            strShipMode = ddpshipmode.SelectedItem.ToString()
        End If

        strShipTerms = ddpshipterms.SelectedItem.ToString()
        If strShipTerms.Contains("select") Then
            strShipTerms = ""
        Else
            strShipTerms = ddpshipterms.SelectedItem.ToString()
        End If


        Using sqlCon As New SqlConnection(strCon)
            sqlCon.Open()
            Using sqlCmd As New SqlCommand("spUpdatetblInvoiceUpdates_sa", sqlCon)
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
                isSucess = Convert.ToInt32(sqlCmd.ExecuteNonQuery())
                Dim statuswaiting As String
                If isSucess > 0 Then
                    Clear()
                    MessageBox("Invoice Changes updated Sucessfully")
                    lblviewupdate.Text = ""


                Else
                    MessageBox("Invoice Changes failed!Please Check")
                End If

                btnSubmit.Visible = True
                BtnUpdate.Visible = False


            End Using
        End Using
    End Sub

    Protected Sub ddpshipterms_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
        'Dim Checkedit As String = lblviewupdate.Text.ToString()
        'If String.IsNullOrEmpty(Checkedit) Then
        '    TxtFinalShipTerms.Text = ddpshipterms.SelectedItem.ToString()
        '    TxtFinalShipTerms.Visible = True

        'Else
        '    TxtFinalShipTerms.Visible = False

        'End If
 
    End Sub


    Public Function UpdateRejectstatus(ByVal InvoiceNumber As String, ByVal ModifiedBy As String) As Integer

        Dim x As Integer

        Using sqlCon As New SqlConnection(strCon2)
            sqlCon.Open()
            Using sqlCmd As New SqlCommand("spUpdateRejected_sa", sqlCon)
                sqlCmd.CommandType = CommandType.StoredProcedure
                sqlCmd.Parameters.AddWithValue("@InvNo", InvoiceNumber)
                sqlCmd.Parameters.AddWithValue("@ModifiedBy", ModifiedBy)
                x = Convert.ToInt32(sqlCmd.ExecuteNonQuery())

                Return x


                '  MessageBox("Saved Sucessfully")
            End Using
        End Using

    End Function

    Protected Sub btn6pmrule_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub

    Protected Sub btndeliveryschedule_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub

    Protected Sub btnpackagingList_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub
End Class