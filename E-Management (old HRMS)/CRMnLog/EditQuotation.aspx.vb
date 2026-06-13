Imports System.Text.RegularExpressions
Imports System.Data.SqlClient
Imports System.Data.DataView
Imports System.Web.Security

Partial Class EditQuotation
    Inherits E_Management.CRMlognetglobal 'System.Web.UI.Page
    Dim mynet As New CRMlognetglobal
    Public PrevQuotNo
    Dim QueryString As String
    Dim com As New SqlClient.SqlCommand

    Dim MyGlobal As New emanagement.globalinfo
    Dim str As String = MyGlobal.ConCRMStr

    Dim con, con1, con2 As New SqlConnection(str)
    Dim datread As SqlClient.SqlDataReader
    Dim objtable As New DataTable
    Dim objtable1 As New DataTable
    Public recstatus As Boolean
    Public PrevAmt, PrevMin
    Public Shared fid As String
    Public Shared Exp, LAmt, LMin, Qty, UPrice
    Public transname, vno, dep, arr, m3, amt, mc, curr, rno, edt, revstatus
    Public Quoteno

#Region " Web Form Designer Generated Code "

    'This call is required by the Web Form Designer.
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()

    End Sub

    'NOTE: The following placeholder declaration is required by the Web Form Designer.
    'Do not delete or move it.
    Private designerPlaceholderDeclaration As System.Object

    Private Sub Page_Init(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Init
        'CODEGEN: This method call is required by the Web Form Designer
        'Do not modify it using the code editor.
        InitializeComponent()
    End Sub

#End Region

    Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load, Me.Load
        'Put user code to initialize the page here
        'Time out sequence..
        Response.AppendHeader("Refresh", (Session.Timeout * 40 + 60).ToString() + "; URL=../logout.aspx")
        Session("U_ID") = "first"
        Dim a As String
        If Not Page.IsPostBack Then
            Session("lo") = Now.Minute
        End If
        a = Session("lo") + 20
        Dim b As String
        If a = Now.Minute Or (Now.Minute - Session("lo")) > 20 Then
            Response.Redirect("../logout.aspx")
        End If

        PrevQuotNo = Request.QueryString("FQno")
        Session("PQT") = PrevQuotNo
        txtQuoteno.Text = Session("PQT")
        'Panel1.Visible = False
        'To select the quotation details...
        If con.State = ConnectionState.Closed Then
            con.Open()
        End If
        If Not IsPostBack Then
            If Session("Quotstatus") = "Rejected" Or Session("Quotstatus") = "Approved" Or Session("Quotstatus") = "On Hold" Then
                lblquote.Visible = True
                txtNewQuoteNo.Visible = True
            End If
            If con.State = ConnectionState.Closed Then con.Open()
            'QueryString = "select F_ID from Log_ForwardersMaster where u_id='" & Session("UName") & "'"
            QueryString = "select F_ID from Log_ForwardersMaster where F_Name='" & Session("CurrentFW") & "'"
            Dim cmd As New SqlClient.SqlCommand(QueryString, con)
            datread = cmd.ExecuteReader
            While datread.Read
                fid = datread(0)
            End While
            datread.Close()
            If con.State = ConnectionState.Open Then con.Close()


            QueryString = "select distinct a.otherfees,a.amount,a.MinimumAmount from log_forotherexpensedump a where QuoteNo='" & txtQuoteno.Text & "'"
            Dim objDataSet1 = New DataSet
            Dim objDataAdapter1 = New SqlClient.SqlDataAdapter(QueryString, con)
            Try
                objDataAdapter1.Fill(objDataSet1, "log_forotherexpensedump")
            Catch ex As Exception
                Response.Write("Exception " & ex.Message)
            End Try

            objtable1 = objDataSet1.Tables("log_forotherexpensedump")

            Session("ObjectTable") = objtable1

            Session("LCLTable") = objtable1
            LCL.DataSource = objtable1.DefaultView
            LCL.DataBind()
            LCL.Visible = True
        End If
        If IsPostBack Then
            If Session("Quotstatus") = "Rejected" Or Session("Quotstatus") = "Approved" Or Session("Quotstatus") = "On Hold" Then
                'msg("Sorry, If you want to edit, have to save as new Quotation only as the Quotation is " & Session("QuotStatus") & ", Thank You.")
                lblquote.Visible = True
                txtNewQuoteNo.Visible = True
            End If
            Try
                QueryString = "select * from Log_VehicleQuotation where FQno='" & PrevQuotNo & "'"
                Dim cmd As New SqlClient.SqlCommand(QueryString, con)
                datread = cmd.ExecuteReader
                While datread.Read
                    If datread("ApprovedStatus") = "No" Then
                        txtQuoteno.Text = PrevQuotNo
                        lblQno.Text = "Quotation No.:"
                        lblStatus.BackColor = Drawing.Color.Yellow
                        lblStatus.Text = "This Quotation is not yet Approved"
                        'EditSession = False
                        datread.Close()
                    ElseIf datread("ApprovedStatus") = "Approved" Then
                        lblStatus.BackColor = Drawing.Color.Green
                        lblStatus.Text = "This Quotation has been Approved"
                        'EditSession = True
                        lblQno.Text = "Old Quote No.:"
                        txtNewQuoteNo.Visible = True
                        lblquote.Visible = True
                        datread.Close()
                        'Call quotenogenerator()
                    ElseIf datread("ApprovedStatus") = "On Hold" Then
                        lblStatus.BackColor = Drawing.Color.Pink
                        lblStatus.Text = "This Quotation is on Hold"
                        'EditSession = True
                        txtNewQuoteNo.Visible = True
                        lblquote.Visible = True
                        lblQno.Text = "Old Quote No.:"
                        datread.Close()
                        'Call quotenogenerator()
                    ElseIf datread("ApprovedStatus") = "Rejected" Then
                        lblStatus.BackColor = Drawing.Color.Red
                        lblStatus.Text = "This Quotation is Rejected"
                        datread.Close()
                        txtNewQuoteNo.Visible = True
                        lblquote.Visible = True
                        lblQno.Text = "Old Quote No.:"
                        'Call quotenogenerator()
                        'EditSession = True
                    End If
                    Exit While
                End While
                If con.State = ConnectionState.Open Then
                    con.Close()
                End If
            Catch ex1 As Exception
                msg(ex1.Message)
            End Try
        End If
        'Fetching the Session Values
        Try
            If Not IsPostBack Then
                BindData()
                ' Session("LCLTable") = Nothing
                btnSave.Enabled = True
            End If

            objtable = Session("ObjectTable")
            objtable1 = Session("LCLTable")
        Catch ex As Exception
            msg(ex.Message & " load")
        End Try

    End Sub
    Private Sub grid_ItemCommand(ByVal source As Object, ByVal e As System.Web.UI.WebControls.DataGridCommandEventArgs) Handles Grid.ItemCommand
        Select Case (CType(e.CommandSource, LinkButton)).CommandName
            Case "Delete"
                'DeleteItem(e)
            Case "Edit"
                DoItemEdit(source, e)
            Case "Update"
                DoItemUpdate(source, e)
            Case "Cancel"
                DoItemCancel(source, e)
            Case "Select"
                selectitem2(e)
        End Select

    End Sub
    Private Sub BindData()
        If con.State = ConnectionState.Closed Then con.Open()
        Dim fQuoteNo
        If txtNewQuoteNo.Visible = True Then
            'fQuoteNo = txtNewQuoteNo.Text
            lblQno.Text = "Old Quote No.:"
        Else
            fQuoteNo = PrevQuotNo
            lblQno.Text = "Quotation No.:"
        End If

        'Changed on 09/03/07
        'QueryString = "Select * from log_VehicleQuotation where fqNo='" & fQuoteNo & "'"
        QueryString = "Select * from log_VehicleQuotation where fqNo='" & PrevQuotNo & "'"
        'Dim cmd As New SqlClient.SqlCommand(QueryString, con)
        'Dim dr2 As SqlClient.SqlDataReader
        'dr2 = cmd.ExecuteReader
        'Do While dr2.Read

        'Loop
        Dim DatSet = New DataSet

        Dim objDataAdapter = New SqlClient.SqlDataAdapter(QueryString, con)
        Try
            objDataAdapter.Fill(DatSet, "log_VehicleQuotation")
        Catch ex As Exception
            Response.Write("Exception " & ex.Message)
        End Try
        DatSet.AcceptChanges()
        objtable = DatSet.Tables("log_VehicleQuotation")
        Session("ObjectTable") = objtable
        If con.State = ConnectionState.Open Then con.Close()

        GetUpdateSession()

    End Sub

    Sub GetUpdateSession()
        Try
            Dim objTable As DataTable = Session("ObjectTable")
            Grid.DataSource = objTable.DefaultView
            Grid.DataBind()
        Catch ex As Exception
            msg(ex.Message)
        End Try
    End Sub
    Sub DoItemEdit(ByVal objSource As Object, ByVal e As DataGridCommandEventArgs)
        Grid.EditItemIndex = e.Item.ItemIndex
        GetUpdateSession()
    End Sub
    Sub DoItemUpdate(ByVal objSource As Object, ByVal e As DataGridCommandEventArgs)
        'Datagrid Update

        If Session("Quotstatus") = "Rejected" Or Session("Quotstatus") = "Approved" Or Session("Quotstatus") = "On Hold" Then
            rno = 1
            txtNewQuoteNo.Text = txtQuoteno.Text & "R"
            If txtNewQuoteNo.Text = "" Then
                msg("Please Enter New Quotation No.")
                Exit Sub
            End If
        End If

        Dim n As Integer = objtable.Columns.Count
        Dim objTextBox As TextBox

        objTextBox = e.Item.Cells(0).Controls(0)
        fid = objTextBox.Text

        objTextBox = e.Item.Cells(1).Controls(0)
        transname = objTextBox.Text

        objTextBox = e.Item.Cells(2).Controls(0)
        vno = objTextBox.Text

        objTextBox = e.Item.Cells(3).Controls(0)
        dep = objTextBox.Text
        Session("Dep") = dep

        objTextBox = e.Item.Cells(4).Controls(0)
        arr = objTextBox.Text
        Session("Arr") = arr

        objTextBox = e.Item.Cells(5).Controls(0)
        objtable.Rows(e.Item.ItemIndex)("Weight") = objTextBox.Text
        m3 = objTextBox.Text

        objTextBox = e.Item.Cells(6).Controls(0)
        'to check
        objtable.Rows(e.Item.ItemIndex)("Amount") = objTextBox.Text
        amt = objTextBox.Text

        objTextBox = e.Item.Cells(7).Controls(0)
        objtable.Rows(e.Item.ItemIndex)("MinimumCharge") = objTextBox.Text
        mc = objTextBox.Text

        objTextBox = e.Item.Cells(8).Controls(0)
        curr = objTextBox.Text

        objTextBox = e.Item.Cells(9).Controls(0)

        If Session("Quotstatus") = "Rejected" Or Session("Quotstatus") = "Approved" Or Session("Quotstatus") = "On Hold" Then
            rno = Val(objTextBox.Text) + 1
            objtable.Rows(e.Item.ItemIndex)("RevisionNo") = rno
        Else
            rno = objTextBox.Text
            objtable.Rows(e.Item.ItemIndex)("RevisionNo") = rno
        End If

        

        'objTextBox = e.Item.Cells(9).Controls(0)
        objTextBox = e.Item.Cells(10).Controls(0)
        objtable.Rows(e.Item.ItemIndex)("EffectiveDate") = objTextBox.Text
        edt = objTextBox.Text
        Session("EffDt") = edt

        objtable.GetChanges()

        objtable.AcceptChanges()
        Session("ObjectTable") = objtable
        Grid.EditItemIndex = -1
        GetUpdateSession()
    End Sub

    Sub InsertintoTable()
        Try
            'If txtNewQuoteNo.Visible = True Then
            '    Call quotenogenerator()
            'End If

            'Quotation Weightagewise Rate Inserting or Updating 
            Dim queryinsert
            Dim objTable As DataTable = Session("ObjectTable")
            Dim n As Integer
            n = objTable.Rows.Count
            Dim i As Integer
            For i = 0 To n - 1
                InsertTable(objTable.Rows(i)(0), objTable.Rows(i)(1), objTable.Rows(i)(2), objTable.Rows(i)(3), objTable.Rows(i)(4), objTable.Rows(i)(5), objTable.Rows(i)(6), objTable.Rows(i)(7), objTable.Rows(i)(8), objTable.Rows(i)(9), objTable.Rows(i)(10), objTable.Rows(i)(11), objTable.Rows(i)(12), objTable.Rows(i)(13), objTable.Rows(i)(14), objTable.Rows(i)(15), objTable.Rows(i)(17), objTable.Rows(i)(18), objTable.Rows(i)(19), objTable.Rows(i)(21), objTable.Rows(i)(22), objTable.Rows(i)(23), objTable.Rows(i)(24))
            Next i
            ''''''''''''''''
            If con.State = ConnectionState.Closed Then con.Open()
            Dim st6 As String = Session("UserId")
            Dim a As Integer = 0

            If Session("EffDt") = "" Then
                Session("EffDt") = Format(Convert.ToDateTime(Now.Date.ToString), "dd/MM/yy") 'Now.Date
            End If

            'Local Handling Charges Inserting or Updating 
            If Session("LCLTable") Is Nothing Then
                If Not txtNewQuoteNo.Visible Then
                    Exit Sub
                End If
                Dim Strsel = "Select F_ID, OtherFees, DeptPlace, ArrivalPlace, Amount, MinimumAmount from Log_forOtherExpenseDump where quoteno='" & txtQuoteno.Text & "'"
                Dim cmdSel As New SqlCommand(Strsel, con)
                Dim Dr As SqlDataReader
                Dr = cmdSel.ExecuteReader
                Dim OE, Dep, Arr, Amt, Min
                If con2.State = ConnectionState.Closed Then con2.Open()
                Do While Dr.Read
                    'FWId = Dr("F_ID")
                    OE = Dr("OtherFees")
                    Dep = Dr("DeptPlace")
                    Arr = Dr("ArrivalPlace")
                    Amt = Dr("Amount")
                    Min = Dr("MinimumAmount")
                    'FWId = fid
                    If txtNewQuoteNo.Visible Then
                        Dim StrIn = "Insert into Log_forOtherExpenseDump (f_id, OtherFees, DeptPlace, ArrivalPlace, Amount, MinimumAmount, CreatedBy, CreatedDate, EffectiveDate, QuoteNo) "
                        StrIn &= " values('" & fid & "','" & OE & "','" & Dep & "','" & Arr & "','" & Amt & "','" & Min & "','" & st6 & "','" & Now.Date.ToShortDateString & "','" & Session("EffDt") & "','" & txtNewQuoteNo.Text & "')"
                        Dim cmdin As New SqlCommand(StrIn, con2)
                        cmdin.ExecuteNonQuery()
                    Else
                        'No need to update the OtherExpenses Table since there is no modification done
                        Exit Do
                    End If
                Loop
                If con2.State = ConnectionState.Open Then con2.Close()

            Else
                '<<<<<<<<<<<<<<<<<<28/11/2006>>>>>>>>>>>>>
                Dim objTable1 As DataTable = Session("LCLTable")
                Dim L As Integer
                L = objTable1.Rows.Count
                'If L <> 0 Then
                Dim Strsel = "Select Distinct DeptPlace, ArrivalPlace from Log_forOtherExpenseDump where quoteno='" & txtQuoteno.Text & "'"
                Dim cmdSel As New SqlCommand(Strsel, con)
                Dim Dr As SqlDataReader
                Dr = cmdSel.ExecuteReader
                Dim Dep, Arr
                Do While Dr.Read
                    Dep = Dr(0)
                    Arr = Dr(1)
                    'Dim fWid = Dr(2)
                    'Dim Amt = Dr(3)
                    If con2.State = ConnectionState.Closed Then con2.Open()
                    If txtNewQuoteNo.Visible Then
                        For i = 0 To L - 1
                            Dim StrIn = "Insert into Log_forOtherExpenseDump (f_id, OtherFees, DeptPlace, ArrivalPlace, Amount, MinimumAmount, CreatedBy, CreatedDate, EffectiveDate, QuoteNo) "
                            StrIn &= " values('" & fid & "','" & objTable1.Rows(i)(0) & "','" & Dep & "','" & Arr & "','" & objTable1.Rows(i)(1) & "','" & objTable1.Rows(i)(2) & "','" & st6 & "','" & Now.Date.ToShortDateString & "','" & Session("EffDt") & "','" & txtNewQuoteNo.Text & "')"
                            Dim cmdin As New SqlCommand(StrIn, con2)
                            cmdin.ExecuteNonQuery()
                        Next
                    Else
                        For i = 0 To L - 1
                            Dim StrUP = "Update Log_forOtherExpenseDump set Amount='" & objTable1.Rows(i)(1) & "', MinimumAmount='" & objTable1.Rows(i)(2) & "', EffectiveDate='" & Session("EffDt") & "', ModifiedBy='" & st6 & "', ModifiedDate='" & Now.Date.ToShortDateString & "' where QuoteNo='" & txtQuoteno.Text & "' and OtherFees='" & objTable1.Rows(i)(0) & "'"   'DeptPlace='" & Dep & "', ArrivalPlace='" & Arr & "',
                            Dim cmdUp As New SqlCommand(StrUP, con2)
                            cmdUp.ExecuteNonQuery()
                        Next
                    End If
                    If con2.State = ConnectionState.Open Then con2.Close()
                Loop
                '<<<<<<<<<<<<<<<<<<28/11/2006>>>>>>>>>>>>>
            End If
            If con.State = ConnectionState.Open Then con.Close()
            '''''''''''''''

            GetUpdateSession()

            If recstatus = True Then
                msg("Quotation Successfully Registered")
                btnSave.Enabled = False
            End If
        Catch ex As Exception
            msg(ex.Message & "InsertintoTable,  Please check the values and Try again")
            btnSave.Enabled = True
        End Try
    End Sub

    Sub InsertTable(ByVal pfid, ByVal ptxtairnam, ByVal ptxtflino, ByVal ptxtfrom, ByVal ptxtarr, ByVal pweight, ByVal pamount, ByVal pcurrname, ByVal pothexpen, ByVal previsionno, ByVal papprovedstatus, ByVal puid, ByVal pcreatedby, ByVal pcreateddate, ByVal pmodifiedby, ByVal pmodifieddate, ByVal pedate, ByVal pquoteno, ByVal prevstat, ByVal pfqno, ByVal pmincharge, ByVal pvtype, ByVal pVesselMode)
        'Inserting records into Table
        Dim objTable As DataTable = Session("ObjectTable")
        Try
            Dim query As String
            Dim PrimaryQuery As String
            Dim a, b, c, st1, st2, st3, st4, st5 As String
            Dim ct1, ct2, ct3 As String
            Dim date1 As Date = Now.Date.ToShortDateString
            Dim st6 As String = Session("UserId")
            'pfid = txtfid.Text
            'ptxtairnam = LTrim(ddlname.SelectedItem.Text.Trim)
            puid = st6
            pcreatedby = st6
            pcreateddate = date1
            pmodifiedby = st6
            pmodifieddate = date1
            If con.State = ConnectionState.Closed Then
                con.Open()
            End If

            Dim newrevno
            newrevno = Val(previsionno) + 1

            Dim cmd2 As New SqlClient.SqlCommand("select * from Log_VehicleQuotation where vehicleno='" & ptxtflino & "' and DepartPlace='" & ptxtfrom & "' and ArrivalPlace='" & ptxtarr & "'  and Weight=" & pweight & " and QuoteNo = '" & pquoteno & "' and EffectiveDate='" & pedate & "'", con)
            Dim dr As SqlDataReader
            dr = cmd2.ExecuteReader
            'previsionstatus = 0
            Dim s1, s2, s3, s4, s5, s6 As String
            While dr.Read
                s1 = dr(0)
                s2 = dr(2)
                s3 = dr(3)
                s4 = dr(4)
                s5 = dr(5)
                s6 = dr(10)
            End While
            Dim qno
            qno = txtQuoteno.Text
            prevstat = "Yes"
            papprovedstatus = "No"
            pamount = Format(pamount, "#.00")

            If Session("Quotstatus") = "Rejected" Or Session("Quotstatus") = "Approved" Or Session("Quotstatus") = "On Hold" Then
                prevstat = "No"
                Dim oldQuoteno = txtQuoteno.Text
                papprovedstatus = "No" 'Session("Quotstatus")
                query = "insert into Log_VehicleQuotation (F_id, TransportName, VehicleNo, DepartPlace, ArrivalPlace, Weight, Amount, CurrName, OtherExpenses, RevisionNo, ApprovedStatus,U_Id,CreatedBy, CreatedDate, EffectiveDate, QuoteNo, OldQuoteNo, RevisedStatus,  FQNo, MinimumCharge, VehicleType, vesselmode) Values "
                query &= " (" & "'" & pfid & "','" & ptxtairnam & "','" & ptxtflino & "','" & ptxtfrom & "','" & ptxtarr & "'," & pweight & "," & pamount & ",'" & pcurrname & "'," & pothexpen & "," & previsionno & ",'" & papprovedstatus & "','" & st6 & "','" & st6 & "','" & date1 & "','" & pedate & "','" & Quoteno & "','" & oldQuoteno & "','" & prevstat & "','" & txtNewQuoteNo.Text & "','" & pmincharge & "','" & pvtype & "','" & pVesselMode & "')"
                'End If
            Else
                '''Added on 28.10
                If dr.HasRows Then
                    'If s1 = pfid And s2 = ptxtflino And s3 = ptxtfrom And s4 = ptxtarr And s5 = pweight And qno = pquoteno Then
                    'If s6 <> "Approved" Or s6 <> "On Hold" Or s6 <> "Rejected" Then
                    query = "update Log_VehicleQuotation set Weight = " & pweight & ",amount = " & pamount & ", MinimumCharge='" & pmincharge & "', RevisionNo= " & newrevno & ", modifieddate='" & pmodifieddate & "',modifiedby = '" & pmodifiedby & "', RevisedStatus='" & prevstat & "', EffectiveDate='" & pedate & "' where f_id = '" & pfid & "' and VehicleNo= '" & ptxtflino & "' and  DepartPlace = '" & ptxtfrom & "' and Weight=" & pweight & " and arrivalplace = '" & ptxtarr & "' and fqNo='" & txtQuoteno.Text & "' and EffectiveDate='" & pedate & "'"
                    Session("EffDt") = pedate
                    'Else
                    'query = "insert into Log_VehicleQuotation (F_id, TransportName, VehicleNo, DepartPlace, ArrivalPlace, Weight, Amount, CurrName, OtherExpenses, RevisionNo, ApprovedStatus,U_Id,CreatedBy, CreatedDate, EffectiveDate, QuoteNo, RevisedStatus) values (" & "'" & pfid & "','" & ptxtairnam & "','" & ptxtflino & "','" & ptxtfrom & "','" & ptxtarr & "'," & pweight & "," & pamount & ",'" & pcurrname & "'," & pothexpen & "," & previsionno & ",'" & papprovedstatus & "','" & st6 & "','" & st6 & "','" & date1 & "','" & pedate & "','" & Quoteno & "','" & prevstat & "')"
                    'End If
                    'End If
                End If
                ''''
                'commented 28/10
                'query = "insert into Log_VehicleQuotation (F_id, TransportName, VehicleNo, DepartPlace, ArrivalPlace, Weight, Amount, CurrName, OtherExpenses, RevisionNo, ApprovedStatus,U_Id,CreatedBy, CreatedDate, EffectiveDate, QuoteNo, RevisedStatus, FQNo, MinimumCharge) values (" & "'" & pfid & "','" & ptxtairnam & "','" & ptxtflino & "','" & ptxtfrom & "','" & ptxtarr & "'," & pweight & "," & pamount & ",'" & pcurrname & "'," & pothexpen & "," & previsionno & ",'" & papprovedstatus & "','" & st6 & "','" & st6 & "','" & date1 & "','" & pedate & "','" & Quoteno & "','" & prevstat & "','" & txtQuoteno.Text & "'," & mc & ")"

            End If
            dr.Close()
            Dim cmd5 As New SqlClient.SqlCommand(query, con)
            cmd5.ExecuteNonQuery()
            recstatus = True
        Catch ex As Exception
            recstatus = False
            msg(ex.Message & "InsertTable")
        End Try
        If con.State = ConnectionState.Open Then
            con.Close()
        End If
    End Sub
    Sub DoItemCancel(ByVal objSource As Object, ByVal objArgs As DataGridCommandEventArgs)
        'Datagrid Cancel
        Grid.EditItemIndex = -1
        GetUpdateSession()
    End Sub

    Private Sub Grid_CancelCommand(ByVal source As System.Object, ByVal e As System.Web.UI.WebControls.DataGridCommandEventArgs)
        'Datagrid Cancel
        Grid.EditItemIndex = -1
        'getdataset()
    End Sub

   

    Private Sub Grid_PageIndexChanged(ByVal source As Object, ByVal e As System.Web.UI.WebControls.DataGridPageChangedEventArgs) Handles Grid.PageIndexChanged
        Grid.CurrentPageIndex = e.NewPageIndex
        Try
            'getdataset()
        Catch ex As Exception
            msg(ex.Message & " dg_page")
        End Try
    End Sub

    Private Sub btnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSave.Click
        If Session("Quotstatus") = "Rejected" Or Session("Quotstatus") = "Approved" Then
            If txtNewQuoteNo.Text = "" Then
                msg("Please Enter New Quotation No.")
                Exit Sub
            ElseIf UCase(txtNewQuoteNo.Text.Trim) = UCase(txtQuoteno.Text.Trim) Then
                msg("Please Enter Valid Quotation Number!")
                Exit Sub
            End If
        End If

        If txtNewQuoteNo.Visible = True Then
            Call QuoteNoGenerator()
        End If
        InsertintoTable()
    End Sub

    Private Sub QuoteNoGenerator()
        If con.State = ConnectionState.Closed Then con.Open()
        Dim s
        s = fid

        Dim querys, quotenoold, query1
        Try
            Quoteno = s & "-" & 1
            query1 = "Select max(Rid) from log_VehicleQuotation"
            Dim cmd As New SqlClient.SqlCommand(query1, con)
            Dim rd As SqlClient.SqlDataReader
            rd = cmd.ExecuteReader
            Dim r_id
            While rd.Read
                r_id = rd.Item(0)
            End While
            If Not rd.HasRows Then
                Quoteno = s & "-" & 1
                rd.Close()
                Exit Sub
            End If
            rd.Close()
            querys = "Select QuoteNo from log_VehicleQuotation where rid=" & r_id & ""
            Dim command As New SqlClient.SqlCommand(querys, con)
            Dim reader As SqlDataReader
            reader = command.ExecuteReader()
            Dim x, y() As String
            While reader.Read
                x = reader.Item(0)
                y = Split(x, "-")
                quotenoold = Val(y(1)) + 1
                Quoteno = s & "-" & quotenoold
            End While
        Catch ex As Exception
            msg(ex.Message & " QuoteNo.Generator")
        End Try

        If con.State = ConnectionState.Open Then
            con.Close()
        End If
    End Sub

    Sub selectitem2(ByVal objArgs As DataGridCommandEventArgs)
        Dim k As Integer
        Dim objTable1 As DataTable = Session("LCLTable")
        Dim Fid = objArgs.Item.Cells(0).Text
        Dim Fno = objArgs.Item.Cells(1).Text
        Dim dplace = objArgs.Item.Cells(2).Text
        Dim aplace = objArgs.Item.Cells(3).Text
        QueryString = "select distinct a.otherfees,a.amount,a.MinimumAmount from log_forotherexpensedump a where QuoteNo='" & txtQuoteno.Text & "'"
        Dim objDataSet1 = New DataSet
        Dim objDataAdapter1 = New SqlClient.SqlDataAdapter(QueryString, con)
        Try
            objDataAdapter1.Fill(objDataSet1, "log_forotherexpensedump")
        Catch ex As Exception
            Response.Write("Exception " & ex.Message)
        End Try
        objTable1 = objDataSet1.Tables("log_forotherexpensedump")
        Session("LCLTable") = objTable1
        LCL.DataSource = objTable1.DefaultView
        LCL.DataBind()
        LCL.Visible = True
    End Sub

    Private Sub LCL_ItemCommand(ByVal source As Object, ByVal e As System.Web.UI.WebControls.DataGridCommandEventArgs) Handles LCL.ItemCommand
        Select Case (CType(e.CommandSource, LinkButton)).CommandName
            Case "Delete"
                'DeleteItem(e)
            Case "Edit"
                DoLCLEdit(source, e)
            Case "Update"
                DoLCLUpdate(source, e)
            Case "Cancel"
                DoLCLCancel(source, e)
            Case "Select"
                'selectitem2(e)
        End Select
    End Sub

    Sub DoLCLEdit(ByVal objSource As Object, ByVal e As DataGridCommandEventArgs)
        'If con1.State = ConnectionState.Closed Then con1.Open()
        'Dim str1
        'str1 = "select * from Pur_FWInvoice where InvoiceNo='" & txtInvNo.Text & "'"
        'Dim cmd1 As New SqlClient.SqlCommand(str1, con1)
        'Dim dr1 As SqlDataReader
        'dr1 = cmd1.ExecuteReader
        'dr1.Read()
        'If dr1.HasRows Then
        '    msg("Sorry this Invoice No. already exists, pls choose different number")
        '    Exit Sub
        'End If
        'dr1.Close()
        'If con1.State = ConnectionState.Open Then con1.Close()

        LCL.EditItemIndex = e.Item.ItemIndex
        PrevAmt = CType(e.Item.FindControl("lblamt"), Label).Text
        PrevMin = CType(e.Item.FindControl("lblmin"), Label).Text
        LCLUpdateSession()
    End Sub

    Sub DoLCLCancel(ByVal objSource As Object, ByVal objArgs As DataGridCommandEventArgs)
        'Datagrid Cancel
        LCL.EditItemIndex = -1
        LCLUpdateSession()
    End Sub
    Private Sub LCLUpdateSession()
        Dim objTable1 As DataTable = Session("LCLTable")
        LCL.DataSource = objTable1.DefaultView
        LCL.DataBind()
    End Sub
    Sub DoLCLUpdate(ByVal objSource As Object, ByVal e As DataGridCommandEventArgs)

        Dim objTextBox As TextBox
        'objTextBox = e.Item.Cells(0).Controls(0)
        'objtable1.Rows(e.Item.ItemIndex)("Description") = objTextBox.Text
        'Exp = objTextBox.Text

        Exp = CType(e.Item.FindControl("lblDesc"), Label).Text
        'LAmt = CType(e.Item.FindControl("lblAmt"), Label).Text
        LAmt = CType(e.Item.FindControl("TxtAmt"), TextBox).Text
        LAmt = Format(Convert.ToDecimal(Val(LAmt)), "0.00")

        LMin = CType(e.Item.FindControl("TxtMin"), TextBox).Text
        'LAmt = Format(Convert.ToDecimal(Val(LAmt)), "0.00")

        objtable1.Rows(e.Item.ItemIndex)("Amount") = LAmt
        objtable1.Rows(e.Item.ItemIndex)("MinimumAmount") = LMin

        objtable1.GetChanges()

        objtable1.AcceptChanges()
        Session("LCLTable") = objtable1
        LCL.EditItemIndex = -1
        LCLUpdateSession()
    End Sub

    Private Sub btnExit_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnExit.Click
        Response.Redirect("../HRMIS/Default.aspx")
    End Sub

    'Private Sub Grid_ItemDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.DataGridItemEventArgs) Handles Grid.ItemDataBound
    '    fid = CType(e.Item.FindControl("lblitmcode"), Label).Text
    '    fid = e.Item.Cells(0).Text
    'End Sub


End Class
