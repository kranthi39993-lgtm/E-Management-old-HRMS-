Imports System.Text.RegularExpressions
Imports System.Data.SqlClient
Imports System.Data.DataView
Imports System.Web.Security
Imports Microsoft
Imports System.Web.Mail
Imports System.Web
Imports System.Globalization

Partial Class QuotationMaster
    Inherits CRMlognetglobal
    Dim com As New SqlClient.SqlCommand

    Dim MyGlobal As New emanagement.globalinfo
    Dim str As String = MyGlobal.ConCRMStr
    Dim con, con1, con2 As New SqlConnection(str)

    Dim datread As SqlClient.SqlDataReader
    Dim datread2 As SqlClient.SqlDataReader
    Dim objDataAdapter As SqlClient.SqlDataAdapter
    Dim objDataSet As DataSet
    Dim QueryString As String
    Dim objTable As DataTable
    Dim objTextBox As TextBox
    Public Shared TableRowCount As String
    Public NoOtherExpense As Boolean
    Public Shared vehicleType As String
    Public Shared Amount As Decimal
    Public Shared noth As Decimal
    Public Shared oth As Decimal
    Public Shared mal As Decimal
    Public otot As Decimal
    Public Shared Quoteno As String
    Public date1 As Date = Now.Date.ToShortDateString
    Public recstatus As Boolean

    Dim mynet As New CRMlognetglobal

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
        Try
            Session("UserId") = Session("empcode")

            If Page.IsPostBack = False Then
                'dynamicLabel.Visible = True
                'dynamicTextBox.Visible = True
                If Session("IsForwarder") = 1 Then
                    txtfid.Visible = True
                    ddlfid.Visible = False
                ElseIf Session("IsAgent") = 1 Then
                    txtfid.Visible = True
                    ddlfid.Visible = False
                ElseIf Session("CAdmin") <> True Then
                    txtfid.Visible = True
                    ddlfid.Visible = False
                ElseIf Session("IsEmployee") = 1 Then
                    txtfid.Visible = False
                    ddlfid.Visible = True
                ElseIf Session("CAdmin") = True Then
                    txtfid.Visible = False
                    ddlfid.Visible = True
                End If
                txtfid.Enabled = False
            End If
            Session("U_ID") = "first"

            'Response.AppendHeader("Refresh", (Session.Timeout * 40 + 60).ToString() + "; URL=../logout.aspx")
            'Dim a As String
            'If Not Page.IsPostBack Then
            '    Session("lo") = Now.Minute
            'End If
            'a = Session("lo") + 20
            'Dim b As String
            'If a = Now.Minute Or (Now.Minute - Session("lo")) > 20 Then
            '    Response.Redirect("../logout.aspx")
            'End If
            btnadd.Enabled = True
            'Fetching the Session Values
        Catch ex As Exception
            msg(ex.Message)
        End Try
        Try
            If Page.IsPostBack = False Then

                con.Open()
                'If lblexp.Visible = False Then
                '    msg("Please contact Maruwa to assign the Local Handling Charges to your Quotation")
                '    FormsAuthentication.RedirectFromLoginPage(Session("userID"), True)
                '    Response.Redirect("../logsticsMain.aspx")
                'End If
                Dim count, i As Integer
                count = dynamicTextBox.Controls.Count()
                For i = 0 To count - 1
                    dynamicTextBox.Controls.Clear()
                    dynamicLabel.Controls.Clear()
                    DTxtMinAmt.Controls.Clear()
                Next
                Session("UserId") = Session("empcode")
                Dim cmd10 As New SqlCommand("select EmpCustCode from users where userID='" & Session("UserId") & "'", con)
                Dim dr10 As SqlDataReader
                dr10 = cmd10.ExecuteReader
                Do While dr10.Read
                    Session("uname") = dr10(0)
                Loop
                dr10.Close()
                txtfid.Text = Session("uname")
                Dim firstword As String
                firstword = Mid(Session("uname"), 1, 1)

                'If firstword = "F" Or firstword = "f" Then
                '    ddlfid.Visible = False
                '    Dim com6 As New SqlCommand
                '    Dim dr6 As SqlDataReader
                '    com6 = New SqlClient.SqlCommand("select F_name from log_forwardersmaster where F_id='" & Session("uname") & "'", con)
                '    dr6 = com6.ExecuteReader
                '    Do While dr6.Read
                '        txtfname.Text = dr6("F_name")
                '    Loop
                '    dr6.Close()
                '    ''
                '    'To display the other Expenses
                '    ofees()
                '    txteffectivedate.Text = Format(Convert.ToDateTime(Now.ToShortDateString.Trim), "dd/MM/yy")
                '    'txteffectivedate.Text = Format(Now.ToShortDateString.Trim, "dd/mm/yyyy")
                'ElseIf firstword = "A" Or firstword = "a" Then
                '    ddlfid.Visible = False
                '    Dim com6 As New SqlCommand
                '    Dim dr6 As SqlDataReader
                '    com6 = New SqlClient.SqlCommand("select A_id from log_AgentsMaster where A_id='" & Session("uname") & "'", con)
                '    dr6 = com6.ExecuteReader
                '    Do While dr6.Read
                '        Session("frowid") = dr6("A_id")
                '        Dim c As String = Session("frowid")
                '    Loop
                '    dr6.Close()
                '    Dim com5 As New SqlCommand
                '    Dim dr5 As SqlDataReader
                '    com5 = New SqlClient.SqlCommand("select F_id from log_AgentsMaster where A_id='" & Session("frowid") & "'", con)
                '    dr5 = com5.ExecuteReader
                '    Do While dr5.Read
                '        txtfid.Text = (dr5("F_id"))
                '    Loop
                '    dr5.Close()
                '    Dim com7 As New SqlCommand
                '    Dim dr7 As SqlDataReader
                '    com7 = New SqlClient.SqlCommand("select F_name from log_forwardersmaster where F_id='" & txtfid.Text & "'", con)
                '    dr7 = com7.ExecuteReader
                '    Do While dr7.Read
                '        txtfname.Text = dr7("F_name")
                '    Loop
                '    dr7.Close()
                'Else
                '    ddlfid.Visible = True
                '    txtfid.Visible = False
                '    Dim com5 As New SqlCommand
                '    Dim dr5 As SqlDataReader
                '    com5 = New SqlClient.SqlCommand("FM_selid", con)
                '    com5.CommandType = CommandType.StoredProcedure
                '    dr5 = com5.ExecuteReader
                '    Do While dr5.Read
                '        ddlfid.Items.Add(dr5("F_id"))
                '    Loop
                '    dr5.Close()
                '    txtfid.Text = ""
                'End If



                ddlfid.Items.Clear()

                Dim TmpCmd1 As New SqlCommand
                Dim TmpAd1 As New SqlDataAdapter
                Dim TMpDs1 As New DataSet

                TmpCmd1 = New SqlCommand("Select Distinct F_ID, F_Name From Log_ForwardersMaster Order by F_Name", con)

                Dim UnStr As String = ""
                Dim FStr As String = ""

                TMpDs1 = New DataSet
                TmpAd1 = New SqlDataAdapter(TmpCmd1)
                TmpAd1.Fill(TMpDs1, "Frwrdr")

                For Tmpi As Integer = 0 To TMpDs1.Tables(0).Rows.Count - 1

                    FStr = TMpDs1.Tables(0).Rows(Tmpi).Item(0) & "-" & TMpDs1.Tables(0).Rows(Tmpi).Item(1)

                    ddlfid.Items.Add(FStr)

                Next

                ddlfid.Visible = True

            End If


            If con.State = ConnectionState.Open Then
                con.Close()
            End If
        Catch ex As Exception
            msg(ex.Message)
        End Try
        'Fetching the Transport Name

        If (Page.IsPostBack = False) Then
            ddlname.Items.Clear()
            ddlno.Items.Clear()
            ddlname.Items.Insert(0, "---Transport Name---")
            ddlno.Items.Insert(0, "---Vehicle No---")
        End If
        'Fetching the Currency Details
        Try
            If Page.IsPostBack = False Then
                Dim str6 As String
                Dim cmd4 As New SqlCommand
                If con2.State = ConnectionState.Closed Then
                    con2.Open()
                End If
                cmd4 = New SqlClient.SqlCommand("select distinct currencycode, currencyname from currencymaster order by CurrencyName", con2)
                datread = cmd4.ExecuteReader()
                ddlcur.Items.Insert(0, New ListItem("---Select---", ""))

                While (datread.Read())
                    str6 = datread(0) & "-" & datread(1)
                    ddlcur.Items.Add(str6)
                End While
                datread.Close()
                If con2.State = ConnectionState.Open Then
                    con2.Close()
                End If
                BindData()
                txtnetoe.Text = 0
            End If
        Catch ex1 As Exception
            msg(ex1.Message & " Load")
        End Try
        txtfname.Enabled = False
        txtdescriptname.Enabled = False

        Try
            LoadCollection()
        Catch ex As Exception
            msg(ex.Message & " - Error in Loading Other Expenses")
        End Try

        'VehicleGrid.Visible = True
        Try
            If Not IsPostBack Then
                Call quotenogenerator()
                setFocus(txtQuoteno)
            End If
        Catch ex As Exception
            msg(ex.Message & " - Error in Quotation No.")
        End Try

        'txtQuoteno.Text = Quoteno
        txtfid.Visible = False
    End Sub

    'Private Sub lbtnSignout_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lbtnSignout.Click
    '    Dim count, i As Integer
    '    count = dynamicTextBox.Controls.Count()
    '    For i = 0 To count - 1
    '        dynamicTextBox.Controls.Clear()
    '        dynamicLabel.Controls.Clear()
    '        DTxtMinAmt.Controls.Clear()
    '    Next
    '    'Logging out
    '    Call mynet.ChkLastLogin(Session("userID"))
    '    FormsAuthentication.RedirectFromLoginPage(Session("userID"), True)
    '    Response.Redirect("../logout.aspx")
    'End Sub

    'Private Sub lbtnBack_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lbtnBack.Click
    '    Dim count, i As Integer
    '    count = dynamicTextBox.Controls.Count()
    '    For i = 0 To count - 1
    '        dynamicTextBox.Controls.Clear()
    '        dynamicLabel.Controls.Clear()
    '        DTxtMinAmt.Controls.Clear()
    '    Next
    '    FormsAuthentication.RedirectFromLoginPage(Session("userID"), True)
    '    Response.Redirect("../logsticsMain.aspx")
    'End Sub

    Private Sub btnexit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnexit.Click
        Dim count, i As Integer
        count = dynamicTextBox.Controls.Count()
        For i = 0 To count - 1
            dynamicTextBox.Controls.Clear()
            dynamicLabel.Controls.Clear()
            DTxtMinAmt.Controls.Clear()
        Next
        FormsAuthentication.RedirectFromLoginPage(Session("userID"), True)
        Response.Redirect("../HRMIS/Default.aspx")
    End Sub
    Sub InsertintoTable()
        Try
            Dim queryinsert
            Dim objTable As DataTable = Session("ObjectTable")
            Dim n As Integer
            n = objTable.Rows.Count
            TableRowCount = objTable.Rows.Count
            For i As Integer = 0 To n - 1
                InsertTable(objTable.Rows(i)(0), objTable.Rows(i)(1), objTable.Rows(i)(2), objTable.Rows(i)(3), objTable.Rows(i)(4), objTable.Rows(i)(5), objTable.Rows(i)(6), objTable.Rows(i)(7), objTable.Rows(i)(8), objTable.Rows(i)(9), objTable.Rows(i)(10), objTable.Rows(i)(11), objTable.Rows(i)(12), objTable.Rows(i)(13), objTable.Rows(i)(14), objTable.Rows(i)(15), objTable.Rows(i)(17), objTable.Rows(i)(18), objTable.Rows(i)(19), objTable.Rows(i)(21), objTable.Rows(i)(22), objTable.Rows(i)(24))
            Next i
            ''''''''''''''''
            If con.State = ConnectionState.Closed Then
                con.Open()
            End If
            Dim st6 As String = Session("UserId")
            Dim a As Integer = 0

            If con.State = ConnectionState.Open Then
                con.Close()
            End If
            '''''''''''''''
            GetUpdateSession()
            If recstatus = True Then
                msg("Quotation Successfully Registered")
            End If
        Catch ex As Exception
            msg(ex.Message & "InsertintoTable")
        End Try
    End Sub

    Sub InsertTable(ByVal pfid, ByVal ptxtairnam, ByVal ptxtflino, ByVal ptxtfrom, ByVal ptxtarr, ByVal pweight, ByVal pamount, ByVal pcurrname, ByVal pothexpen, ByVal previsionno, ByVal papprovedstatus, ByVal puid, ByVal pcreatedby, ByVal pcreateddate, ByVal pmodifiedby, ByVal pmodifieddate, ByVal pedate, ByVal pquoteno, ByVal prevstat, ByVal pfqno, ByVal pmincharge, ByVal VesselMode)
        'Inserting records into Table
        Dim objTable As DataTable = Session("ObjectTable")
        Try
            'If objTable.Rows.Count > 0 Then
            '    Dim i
            '    Dim recexist As Boolean
            '    For i = 0 To objTable.Rows.Count - 1
            '        If objTable.Rows(i)(1) = ptxtairnam And objTable.Rows(i)(2) = ptxtflino And objTable.Rows(i)(3) = ptxtfrom And objTable.Rows(i)(4) = ptxtarr And objTable.Rows(i)(5) = pweight And objTable.Rows(i)(6) = pamount And objTable.Rows(i)(17) = pedate Then
            '            recexist = True
            '            Exit Sub
            '        Else
            '            recexist = False
            '        End If
            '    Next
            'End If

            Dim query As String
            Dim PrimaryQuery As String
            Dim a, b, c, st1, st2, st3, st4, st5 As String
            Dim ct1, ct2, ct3 As String
            Dim date1 As Date = Now.Date.ToShortDateString
            Dim st6 As String = Session("UserId")
            If ddlfid.Visible = True Then
                pfid = txtfid.Text
            Else
                pfid = txtfid.Text
            End If
            'ptxtairnam = LTrim(ddlname.SelectedItem.Text.Trim)
            puid = st6
            pcreatedby = st6
            pcreateddate = date1
            pmodifiedby = st6
            pmodifieddate = date1

            'If rblType.SelectedIndex = 1 Then
            '    If rblContainerType.SelectedIndex = 0 Then
            '        VesselMode = "LCL"
            '    ElseIf rblContainerType.SelectedIndex = 1 Then
            '        VesselMode = "FCL"
            '    End If
            'Else
            '    VesselMode = "NA"
            'End If


            If con.State = ConnectionState.Closed Then
                con.Open()
            End If

            Dim newrevno
            newrevno = Val(previsionno) + 1

            Dim cmd2 As New SqlClient.SqlCommand("select * from Log_VehicleQuotation where vehicleno='" & ptxtflino & "' and DepartPlace='" & ptxtfrom & "' and Weight=" & pweight & " and ArrivalPlace='" & ptxtarr & "' and QuoteNo = '" & pquoteno & "' and EffectiveDate='" & pedate & "'", con)
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
            pquoteno = Quoteno
            prevstat = "No"
            papprovedstatus = "No"
            If dr.HasRows Then
                'If s1 = pfid And s2 = ptxtflino And s3 = ptxtfrom And s4 = ptxtarr And s5 = pweight And qno = pquoteno Then
                '    If s6 <> "Approved" Or s6 <> "On Hold" Then
                '        query = "update Log_VehicleQuotation set TransportName='" & ptxtairnam & "',VehicleNo= '" & ptxtflino & "',DepartPlace = '" & ptxtfrom & "',arrivalplace = '" & ptxtarr & "',Weight = " & pweight & ",amount = " & pamount & ",CurrName = '" & pcurrname & "',OtherExpenses = " & pothexpen & ",RevisionNo= " & newrevno & ", modifieddate='" & pmodifieddate & "',modifiedby = '" & pmodifiedby & "', EffectiveDate='" & pedate & "' where f_id = '" & pfid & "' and VehicleNo= '" & ptxtflino & "' and  DepartPlace = '" & ptxtfrom & "' and Weight=" & pweight & " and arrivalplace = '" & ptxtarr & "' and QuoteNo='" & pquoteno & "' and EffectiveDate='" & pedate & "'"
                '    Else
                '       query = "insert into Log_VehicleQuotation (F_id, TransportName, VehicleNo, DepartPlace, ArrivalPlace, Weight, Amount, CurrName, OtherExpenses, RevisionNo, ApprovedStatus,U_Id,CreatedBy, CreatedDate, EffectiveDate, QuoteNo, RevisedStatus) values (" & "'" & pfid & "','" & ptxtairnam & "','" & ptxtflino & "','" & ptxtfrom & "','" & ptxtarr & "'," & pweight & "," & pamount & ",'" & pcurrname & "'," & pothexpen & "," & previsionno & ",'" & papprovedstatus & "','" & st6 & "','" & st6 & "','" & date1 & "','" & pedate & "','" & Quoteno & "','" & prevstat & "')"
                '    End If
                'Else

                query = "insert into Log_VehicleQuotation (F_id, TransportName, VehicleNo, DepartPlace, ArrivalPlace, Weight, Amount, CurrName, OtherExpenses, RevisionNo, ApprovedStatus,U_Id,CreatedBy, CreatedDate, EffectiveDate, QuoteNo, RevisedStatus, FQNo, MinimumCharge, VehicleType, VesselMode) values (" & "'" & pfid & "','" & ptxtairnam & "','" & ptxtflino & "','" & ptxtfrom & "','" & ptxtarr & "'," & pweight & "," & pamount & ",'" & pcurrname & "'," & pothexpen & "," & previsionno & ",'" & papprovedstatus & "','" & st6 & "','" & st6 & "','" & date1 & "','" & pedate & "','" & Quoteno & "','" & prevstat & "','" & txtQuoteno.Text & "'," & Val(TxtMinAmt.Text) & ",'" & vehicleType & "','" & VesselMode & "')"
                'End If
            Else
                query = "insert into Log_VehicleQuotation (F_id, TransportName, VehicleNo, DepartPlace, ArrivalPlace, Weight, Amount, CurrName, OtherExpenses, RevisionNo, ApprovedStatus,U_Id,CreatedBy, CreatedDate, EffectiveDate, QuoteNo, RevisedStatus, FQNo, MinimumCharge, VehicleType, VesselMode) values (" & "'" & pfid & "','" & ptxtairnam & "','" & ptxtflino & "','" & ptxtfrom & "','" & ptxtarr & "'," & pweight & "," & pamount & ",'" & pcurrname & "'," & pothexpen & "," & previsionno & ",'" & papprovedstatus & "','" & st6 & "','" & st6 & "','" & date1 & "','" & pedate & "','" & Quoteno & "','" & prevstat & "','" & txtQuoteno.Text & "'," & Val(TxtMinAmt.Text) & ",'" & vehicleType & "','" & VesselMode & "')"
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

    Sub DeleteItem(ByVal objArgs As DataGridCommandEventArgs)
        'Datagrid Delete
        Try
            Dim objTable As DataTable = Session("ObjectTable")
            objTable.Rows.RemoveAt(objArgs.Item.ItemIndex)
            Session("ObjectTable") = objTable
            GetUpdateSession()
        Catch ex As Exception

        End Try
    End Sub

    Public Sub LoadCollection()
        Try
            Dim conCollection As ControlCollection
            conCollection = Session("collectionObjects")
            If conCollection Is Nothing Then
                Exit Sub
            End If
            Dim conCollection1 As ControlCollection
            conCollection1 = Session("collectionObjects1")
            Dim cunt As Integer
            cunt = conCollection.Count
            Dim objTextBox As TextBox
            Dim objtxtbox1 As TextBox

            If dynamicTextBox.Visible = True Then
                dynamicLabel.Dispose()
                dynamicTextBox.Dispose()
            End If
            Dim i
            For i = 0 To cunt - 1
                objTextBox = conCollection(0)
                dynamicTextBox.Controls.Add(objTextBox)
                objtxtbox1 = conCollection1(0)
                DTxtMinAmt.Controls.Add(objtxtbox1)
            Next
            dynamicTextBox.DataBind()
            DTxtMinAmt.DataBind()
        Catch ex As Exception
            msg(ex.Message & " LoadCollection")
        End Try
    End Sub

    Private Sub BindData()
        'Binding the Grid
        If txtfid.Text <> Session("uname") Then
            QueryString = "Select * from log_VehicleQuotation where f_id= Ltrim('" & txtfid.Text.Trim & "') and vehicleno='" & LTrim(ddlno.SelectedItem.Text) & "'"
        Else
            QueryString = "Select * from log_VehicleQuotation where f_id= Ltrim('" & txtfid.Text.Trim & "') and vehicleno='" & LTrim(ddlno.SelectedItem.Text) & "'"
        End If
        objDataSet = New DataSet
        objDataAdapter = New SqlClient.SqlDataAdapter(QueryString, con)
        Try
            objDataAdapter.Fill(objDataSet, "log_VehicleQuotation")
        Catch ex As Exception
            Response.Write("Exception " & ex.Message)
        End Try
        objDataSet.AcceptChanges()
        Dim objTable As DataTable = objDataSet.Tables("log_VehicleQuotation")
        Session("ObjectTable") = objTable
        GetUpdateSession()
    End Sub

    Sub GetUpdateSession()
        Try
            Dim objTable As DataTable = Session("ObjectTable")
            Grid.DataSource = objTable.DefaultView
            Grid.DataBind()
        Catch ex As Exception
            msg(ex.Message & "GetUpdateSession")
        End Try
    End Sub
    Function IsAlreadyExists(ByVal f_id)
        Dim objTable As DataTable = Session("ObjectTable")
        Dim n As Integer
        n = objTable.Rows.Count
        For i As Integer = 0 To n - 1
            If objTable.Rows(i)(0) = f_id Then
                Return i
            End If
        Next
        Return -1
    End Function

    Sub AddDataIntoTable()
        'Adding the Records to the Grid
        Try
            If txtQuoteno.Text = "" Then
                msg("Please Enter Valid Quotation Number")
                setFocus(txtQuoteno)
                Exit Sub
            End If

            Dim st6 As String = Session("UserId")
            Dim a, b, c As String
            If ddlfid.Visible = True Then
                a = LTrim(txtfid.Text.Trim)
            Else
                a = LTrim(txtfid.Text.Trim)
            End If
            b = LTrim(ddlfrom.SelectedItem.Text.Trim)
            c = LTrim(ddlto.SelectedItem.Text.Trim)
            Grid.Visible = True
            Dim str1, str2 As String
            Dim qr As Integer = 1
            Dim qr1 As Integer = 1
            Dim ap As Integer = 0


            Dim VesselMode As String
            If rblType.SelectedIndex = 1 Then
                If rblContainerType.SelectedIndex = 0 Then
                    VesselMode = "LCL"
                ElseIf rblContainerType.SelectedIndex = 1 Then
                    VesselMode = "FCL"
                End If
            Else
                VesselMode = "NA"
            End If



            Dim noOfPosition = IsAlreadyExists(a)
            Dim objTable As DataTable = Session("ObjectTable")

            If noOfPosition = -1 Or noOfPosition = 0 Then
                Dim objValArray(24) As Object
                objValArray(0) = a
                objvalArray(1) = LTrim(ddlname.SelectedItem.Text.Trim)
                objvalArray(2) = LTrim(ddlno.SelectedItem.Text.Trim)
                objValArray(3) = LTrim(ddlfrom.SelectedItem.Text.Trim)
                objValArray(4) = LTrim(ddlto.SelectedItem.Text.Trim)
                objValArray(5) = Convert.ToDecimal((Val(txtQty.Text)))  'Format(Convert.ToDecimal(Val(txtQty)), "0.00") 'ExpenseAmt = Format(Convert.ToDecimal(Val(ExpenseAmt)), "0.00")
                objValArray(6) = Convert.ToDecimal((Val(txtamt.Text)))  'Format(Convert.ToDecimal(Val(txtamt)), "0.00") '
                objValArray(7) = LTrim(ddlcur.SelectedItem.Text.Trim)
                objValArray(8) = txtnetoe.Text
                objValArray(9) = qr

                objValArray(17) = txteffectivedate.Text.Trim

                objvalarray(18) = Quoteno
                objvalarray(21) = txtQuoteno.Text
                objvalarray(22) = Val(TxtMinAmt.Text)
                objvalarray(24) = VesselMode
                objTable.Rows.Add(objValArray)
            Else
                'this part will not execute
                'This part can be used when we dont want any repetion of same source and dest with diff wt and amt
                Dim i
                Dim recfound As Boolean
                For i = 0 To objTable.Rows.Count - 1
                    If b = objTable.Rows(i)(3) And c = objTable.Rows(i)(4) Then
                        recfound = True
                        Exit For
                    Else
                        recfound = False
                    End If
                Next
                'If b = objTable.Rows(noOfPosition)(3) And c = objTable.Rows(noOfPosition)(4) Then
                If recfound Then
                    qr1 = qr1 + 1
                    Dim date1 As Date = Now.Date.ToShortDateString
                    'If txtfid.Text <> "" Or ddlfid.Visible = True Then
                    Dim cmd9 As New SqlClient.SqlCommand("select F_id,Vehicleno,DepartPlace,arrivalplace,RevisionNo from log_VehicleQuotation where F_id='" & a & "' and VehicleNo=Ltrim(' " & ddlno.SelectedItem.Text.Trim & " ') and DepartPlace=Ltrim( ' " & ddlfrom.SelectedItem.Text.Trim & " ') and arrivalplace=Ltrim('" & ddlto.SelectedItem.Text.Trim & "')", con)
                    Dim dr5 As SqlDataReader
                    dr5 = cmd9.ExecuteReader
                    Dim v As Integer
                    While dr5.Read()
                        v = dr5(4)
                        v = v + 1
                    End While
                    dr5.Close()
                    Dim cmd4 As New SqlClient.SqlCommand("update log_VehicleQuotation set TransportName=Ltrim('" & ddlname.SelectedItem.Text.Trim & "') ,Weight=" & txtQty.Text & " ,Amount= " & txtamt.Text & " ,CurrName=Ltrim('" & ddlcur.SelectedItem.Text.Trim & "'), OtherExpenses= " & txtnetoe.Text & ",RevisionNo=" & v & ",Approvedstatus=" & ap & ",u_id='" & st6 & "',modifieddate='" & date1 & "',modifiedby=Ltrim('" & st6.Trim & "') where F_id='" & a & "' and VehicleNo=Ltrim('" & ddlno.SelectedItem.Text.Trim & "') and DepartPlace='" & b & "' and arrivalplace='" & c & "'", con)
                    cmd4.ExecuteNonQuery()
                    Dim Dat1 As Date
                    Dat1 = Convert.ToDateTime(txteffectivedate.Text.ToString("MM/dd/yyyy"))

                    Dim objValArray(10) As Object
                    objValArray(0) = a
                    objValArray(2) = LTrim(ddlno.SelectedItem.Text.Trim)
                    objValArray(3) = LTrim(ddlfrom.SelectedItem.Text.Trim)
                    objValArray(4) = LTrim(ddlto.SelectedItem.Text.Trim)
                    objValArray(5) = txtQty.Text
                    objValArray(6) = txtamt.Text
                    objValArray(7) = LTrim(ddlcur.SelectedItem.Text.Trim)
                    objValArray(8) = txtnetoe.Text
                    objValArray(9) = v
                    objvalArray(10) = CONVERT.ToString(txteffectivedate.Text)

                    objTable.Rows(noOfPosition)(5) = txtQty.Text
                    objTable.Rows(noOfPosition)(6) = txtamt.Text
                    objTable.Rows(noOfPosition)(7) = ddlcur.SelectedItem.Text
                    objTable.Rows(noOfPosition)(8) = txtnetoe.Text
                    objTable.Rows(noOfPosition)(9) = v
                    objTable.Rows(noOfPosition)(17) = Convert.ToString(txteffectivedate.Text)
                    objTable.Rows(noOfPosition)(18) = Quoteno

                Else
                    Dim objValArray(10) As Object
                    objValArray(0) = a
                    objValArray(2) = LTrim(ddlno.SelectedItem.Text.Trim)
                    objValArray(3) = LTrim(ddlfrom.SelectedItem.Text.Trim)
                    objValArray(4) = LTrim(ddlto.SelectedItem.Text.Trim)
                    objValArray(5) = txtQty.Text
                    objValArray(6) = txtamt.Text
                    objValArray(7) = LTrim(ddlcur.SelectedItem.Text.Trim)
                    objValArray(8) = txtnetoe.Text
                    objValArray(9) = qr
                    objValArray(17) = txteffectivedate.Text.Trim
                    objTable.Rows(noOfPosition)(18) = Quoteno
                    objTable.Rows.Add(objValArray)
                End If
            End If
            Session("ObjectTable") = objTable
            Grid.EditItemIndex = -1
            GetUpdateSession()
        Catch ex As Exception
            msg(ex.Message & " AddDataIntoTable")
        End Try
    End Sub

    Public Sub setFocus(ByVal ctrl As System.Web.UI.Control)
        Dim strS As String
        strS = "<SCRIPT language='javascript'>document.getElementById('" + ctrl.ID + "').focus() </SCRIPT>"
        Page.RegisterStartupScript("focus", strS)
    End Sub

    Private Sub btnadd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnadd.Click
        Try
            Dim Dat1 As Date
            Dat1 = Convert.ToDateTime(txteffectivedate.Text)

            If txtQuoteno.Text = "" Then
                msg("Please Enter Valid Quotation No!")
                setFocus(txtQuoteno)
                Exit Sub
            Else
                Dim strss = "select * from log_VehicleQuotation where FQno='" & txtQuoteno.Text.Trim & "'"
                If con1.State = ConnectionState.Closed Then con1.Open()
                Dim cmdss As New SqlCommand(strss, con1)
                Dim drss As SqlDataReader = cmdss.ExecuteReader
                Dim Irukku As Boolean = False
                Do While drss.Read()
                    Irukku = True
                Loop
                If Irukku Then
                    msg("This Quotation No." & txtQuoteno.Text & " Already Exist!")
                    'txtQuoteno.Text = ""
                    setFocus(txtQuoteno)
                    Exit Sub
                End If
                drss.Close()
                If con1.State = ConnectionState.Open Then con1.Close()
            End If
            'Adding Record into the Grid
            updateAmountValue()

            'dynamicLabel.Visible = True
            dynamicTextBox.Visible = True
            lblexp.Visible = True
            Dim vr As Decimal
            If ddlcur.SelectedIndex = 0 Then
                msg("Please Select Valid Currency.")
                btnadd.Enabled = False
                Exit Sub
            End If
            If ddlfrom.SelectedItem.Text = "---Select---" Or ddlto.SelectedItem.Text = "---Select---" Then
                msg("Select the Departure and Arrival Place and Try Again")
                Exit Sub
            End If
            If ddlfrom.SelectedItem.Text = ddlto.SelectedItem.Text Then
                msg("Sorry Arrival and Departure should not be same, Try Again")
                Exit Sub
            End If
            If txtQty.Text = "" Or txtQty.Text = 0 Then
                msg("Enter the Weight or Volume and Try Again")
                Exit Sub
            End If
            If txtamt.Text = "" Or txtamt.Text = 0 Then
                msg("Enter the Amount and Try Again")
                Exit Sub
            End If

            If con.State = ConnectionState.Closed Then
                con.Open()
            End If
            '''''''''''''''''
            'Checking Whether the Forwarder Registered the Other Expenses
            'Dim dr5 As SqlDataReader
            'If txtfid.Text = "" Or ddlfid.Visible = True Then
            '    Dim cmd5 As New SqlClient.SqlCommand("select sum(amount) from log_forotherexpensedump where F_id=Ltrim('" & ddlfid.SelectedItem.Text.Trim & "') group by F_id", con)
            '    dr5 = cmd5.ExecuteReader
            'Else
            '    Dim cmds As New SqlClient.SqlCommand("select sum(amount) from log_forotherexpensedump where F_id=Ltrim('" & txtfid.Text.Trim & "') group by F_id", con)
            '    dr5 = cmds.ExecuteReader
            'End If
            'While dr5.Read()
            '    'If IsDBNull(dr5(0)) = True Then
            '    '    msg("You are not Registered any Other Expenses for this forwarder..Register  it... ")
            '    '    btnadd.Enabled = False
            '    '    Exit Sub
            '    'Else
            '    '    oth = dr5(0)
            '    'End If
            'End While
            'dr5.Close()
            ''''''''''''''''

            'Dim dr6 As SqlDataReader
            'If txtfid.Text = "" Or ddlfid.Visible = True Then
            '    Dim cmd5 As New SqlClient.SqlCommand("select * from log_forotherexpensedump where F_id=Ltrim('" & ddlfid.SelectedItem.Text.Trim & "')", con)
            '    dr6 = cmd5.ExecuteReader
            'Else
            '    Dim cmds As New SqlClient.SqlCommand("select * from log_forotherexpensedump where F_id=Ltrim('" & txtfid.Text.Trim & "') group by F_id", con)
            '    dr6 = cmds.ExecuteReader
            'End If
            'While dr6.Read()
            '    'If IsDBNull(dr5(0)) = True Then
            '    '    msg("You are not Registered any Other Expenses for this forwarder..Register  it... ")
            '    '    btnadd.Enabled = False
            '    '    Exit Sub
            '    'Else
            '    '    oth = dr5(0)
            '    'End If
            'End While
            'dr6.Close()
            Dim b, a1, x, str9, a() As String
            a1 = ddlcur.SelectedItem.Text
            str9 = a1
            a = str9.Split("-")
            x = a(0)
            Dim cmd6 As New SqlClient.SqlCommand("select exchangeprice from currencymaster where currencycode= Ltrim(' " & x.Trim & " ') and month1=datename(month,getdate()) and year1=datename(yy,getdate())", con)
            Dim dr6 As SqlDataReader
            dr6 = cmd6.ExecuteReader()
            Dim vv As Double

            Do While dr6.Read()
                If IsDBNull(dr6(0)) = True Then
                    msg("Please Update the Exchangeprice for this Currency")
                    Exit Sub
                Else
                    vv = dr6(0)
                End If
            Loop
            dr6.Close()

            Dim cmd7 As New SqlClient.SqlCommand("- ExpenseName, Type, MinimumAmount from log_Expenses", con)

            'Calculation part to be coded after discussing with Mr.ravi
            'Coded
            txtnetoe.Text = 0
            Dim m, n
            Dim totothexp As Integer
            totothexp = 0

            For m = 0 To lstamt.Items.Count - 1
                totothexp = totothexp + Val(lstamt.Items(m).Text)
            Next


            'If lstmin.Items(m).Text = 0 And lsttype.Items(m).Text = "Standard" Then 'To check the Fixed cost without minimum
            '    totothexp = totothexp + Val(lstamt.Items(m).Text)
            'ElseIf lstmin.Items(m).Text <> 0 And lsttype.Items(m).Text = "Standard" Then 'To check the Fixed cost with minimum, this is same as first
            '    totothexp = totothexp + Val(lstamt.Items(m).Text)
            'ElseIf lstmin.Items(m).Text = 0 And lsttype.Items(m).Text = "PerUnit" Then 'To check the Variable per unit cost without minimum
            '    totothexp = totothexp + (Val(lstamt.Items(m).Text) * Val(txtQty.Text))
            'ElseIf lstmin.Items(m).Text <> 0 And lsttype.Items(m).Text = "PerUnit" Then 'To check the Variable per unit cost with minimum
            '    If lstmin.Items(m).Text > (Val(lstamt.Items(m).Text) * Val(txtQty.Text)) Then 'To check the min unit cost is greater than the by wt cost
            '        totothexp = totothexp + Val(lstmin.Items(m).Text)
            '    Else
            '        totothexp = totothexp + (Val(lstmin.Items(m).Text) * Val(txtQty.Text))
            '    End If
            'End If


            ' Frieght Calculations
            ' Important confirm this 

            Dim frcharge
            'If Val(txtQty.Text) * Val(txtamt.Text) < Val(TxtMinAmt.Text) Then
            '    frcharge = frcharge + Val(TxtMinAmt.Text)
            'Else
            '    frcharge = frcharge + Val(txtQty.Text) * Val(txtamt.Text)
            'End If

            'or  this one right check

            frcharge = Convert.ToDecimal(Val(txtamt.Text))

            'comment on 29/09

            'Dim li5 As ListItem
            'For Each li5 In lstamt.Items
            '    noth = noth + Val(li5.Text)
            'Next

            'txtnetoe.Text = Convert.ToDecimal((Val(txtQty.Text) * Val(txtamt.Text)) + noth)
            txtnetoe.Text = 0
            txtnetoe.Text = Convert.ToDecimal(Val(totothexp))

            mal = Val(txtnetoe.Text) * vv

            AddDataIntoTable()

            'dynamicLabel.Visible = True
            If con.State = ConnectionState.Open Then
                con.Close()
            End If
            btnSubmit.Enabled = True

            '''''''19/09/2006
            '''''''''''''''<<<<<<<<<<<>>>>>>>>>>>>>>>>>'''''''''''''''''''
            Try
                If NoOtherExpense = True Then
                    Exit Sub
                End If
            Catch ex1 As Exception

            End Try

            Dim Query As String
            Dim fid As String
            If txtfid.Text = Session("uname") Then
                fid = LTrim(RTrim(txtfid.Text.Trim))
            Else
                fid = LTrim(RTrim(txtfid.Text.Trim))
            End If
            If con.State = ConnectionState.Closed Then
                con.Open()
            End If

            Dim usr As String = Session("UserId")
            Dim date1 = Now.Date.ToShortDateString
            Query = "Select * from log_forotherexpensedump where f_id='" & fid & "' and Deptplace='" & ddlfrom.SelectedItem.Text & "' and ArrivalPlace ='" & ddlto.SelectedItem.Text & "' and EffectiveDate='" & Dat1 & "'"
            Dim cmd As New SqlClient.SqlCommand(Query, con)
            Dim dr1 As SqlClient.SqlDataReader
            dr1 = cmd.ExecuteReader
            If dr1.HasRows Then
                GoTo updt
            Else
                GoTo fresh
            End If

updt:
            dr1.Close()
            Dim i
            Dim ExpenseName1 As String
            Dim ExpenseAmt1 As Integer
            Dim MinAmt1 As Integer
            For i = 0 To lstlabel.Items.Count - 1
                ExpenseName1 = lstlabel.Items(i).Text
                ExpenseAmt1 = Val(lstamt.Items(i).Text)
                ExpenseAmt1 = Format(Convert.ToDecimal(Val(ExpenseAmt1)), "0.00")
                MinAmt1 = Val(lstmin.Items(i).Text)
                MinAmt1 = Format(Convert.ToDecimal(Val(MinAmt1)), "0.00")
                Query = "update log_forotherexpensedump set Amount='" & ExpenseAmt1 & "',MinimumAmount=" & MinAmt1 & ", Modifiedby='" & usr & "', ModifiedDate='" & date1 & "' where f_id='" & fid & "' and OtherFees='" & ExpenseName1 & "' and DeptPlace='" & ddlfrom.SelectedItem.Text & "' and ArrivalPlace='" & ddlto.SelectedItem.Text & "' and EffectiveDate='" & txteffectivedate.Text & "' and QuoteNo='" & txtQuoteno.Text & "'"
                Dim cmd1 As New SqlClient.SqlCommand(Query, con)
                cmd1.ExecuteNonQuery()
            Next
            GoTo X
fresh:
            dr1.Close()
            Dim j
            Dim ExpenseName As String
            Dim ExpenseAmt As Integer
            Dim MinAmt As Integer
            For j = 0 To lstlabel.Items.Count - 1
                ExpenseName = lstlabel.Items(j).Text
                ExpenseAmt = Val(lstamt.Items(j).Text)
                ExpenseAmt = Format(Convert.ToDecimal(Val(ExpenseAmt)), "0.00")
                MinAmt = Val(lstmin.Items(j).Text)
                MinAmt = Format(Convert.ToDecimal(Val(MinAmt)), "0.00")

                Query = "insert into log_forotherexpensedump (f_id, OtherFees, DeptPlace, ArrivalPlace, Amount,MinimumAmount, CreatedBy, CreatedDate, EffectiveDate, QuoteNo)values ('" & fid & "','" & ExpenseName & "','" & ddlfrom.SelectedItem.Text & "','" & ddlto.SelectedItem.Text & "','" & ExpenseAmt & "'," & MinAmt & ",'" & usr & "','" & date1 & "','" & Dat1 & "','" & txtQuoteno.Text & "')"
                Dim com As New SqlClient.SqlCommand(Query, con)
                com.ExecuteNonQuery()
            Next
X:
            If con.State = ConnectionState.Open Then
                con.Close()
            End If
            '''''''''''''''<<<<<<<<<<<>>>>>>>>>>>>>>>>>'''''''''''''''''''

        Catch ex As Exception
            msg(ex.Message)
        End Try
        btnSubmit.Enabled = True
    End Sub

    Public Sub updateAmountValue()
        Try
            Dim count As Integer
        count = dynamicTextBox.Controls.Count()
        Dim objTextBox As TextBox
        Dim objTxtBox1 As TextBox
        'Dim objTxtBox2 As TextBox
        Dim i As Integer
        lstamt.Items.Clear()
        lstmin.Items.Clear()
        For i = 0 To count - 1
            objTextBox = dynamicTextBox.Controls(i)
            lstamt.Items.Add(objTextBox.Text)
            objTxtBox1 = DTxtMinAmt.Controls(i)
            lstmin.Items.Add(objTxtBox1.Text)
            'lsttype.Items.Add(objTxtBox2.Text)
        Next
            'Dim s
            's = lstmin.Items(3).Text
        Catch ex As Exception
            msg(ex.Message)
        End Try

    End Sub

    Public Function getAmount(ByVal fe_id, ByVal from, ByVal toval)
        Dim query As String
        Dim conTemp As New SqlConnection(str)
        conTemp.Open()
        query = "select * from log_Forotherexpensedump where feid = " & fe_id & "  and DepartPlace = '" & from & "' and arrivalplace = '" & toval & "'"
        Try
            Dim command As New SqlClient.SqlCommand(query, conTemp)
            Dim reader As SqlDataReader
            reader = command.ExecuteReader()
            Dim amount As Integer
            Do While reader.Read()
                amount = reader(5)
                reader.Close()
                conTemp.Close()
                Return amount
            Loop
            reader.Close()
            conTemp.Close()
            Return 0
        Catch ex As Exception

        End Try
    End Function

    Public Sub ofees()
        Dim a5 As String
        Dim dp, ap
        If txtfid.Text = Session("uname") Then
            a5 = LTrim(RTrim(txtfid.Text.Trim))
        Else
            a5 = LTrim(RTrim(txtfid.Text.Trim))
        End If

        Dim objTextBox As New TextBox
        Dim objtxtbox1 As New TextBox
        Dim objLabel As New Label
        Dim objLabel2 As New Label
        Dim intLoop As Integer
        Dim query As String
        'query = "select fe.id,le.expensename from Log_forward_expense fe,log_expenses le where fe.f_id = Replace('" & a5 & "',' ','')  and fe.Expensename = le.Expensename"
        'query = "select f_id,expensename from Log_forward_expense where f_id ='" & a5 & "'"  'Replace('" & a5 & "',' ','')"
        query = "select a.f_id, a.expensename, b.expenseType from Log_forward_expense a, log_expenses b where a.expensename=b.expensename and f_id ='" & a5 & "'"
        Try
            'If dynamicTextBox.Visible = True Then
            '    dynamicLabel.Dispose()
            '    dynamicTextBox.Dispose()
            'End If
            Dim count, i As Integer
            count = dynamicTextBox.Controls.Count()
            For i = 0 To count - 1
                dynamicTextBox.Controls.Clear()
                dynamicLabel.Controls.Clear()
                DTxtMinAmt.Controls.Clear()
            Next
            If con.State = ConnectionState.Closed Then con.Open()
            Dim command As New SqlClient.SqlCommand(query, con)
            Dim reader As SqlDataReader
            reader = command.ExecuteReader()
            lbltype.Text = ""
            lblMin.Text = ""
            lblexp.Text = ""
            Do While reader.Read()
                objTextBox = New TextBox
                'objTextBox.Text = getAmount(reader(0), dp, ap)
                objTextBox.Text = 0
                dynamicTextBox.Controls.Add(objTextBox)
                objtxtbox1 = New TextBox
                objtxtbox1.Text = 0
                objtxtbox1.Width = Unit.Pixel(165)

                DTxtMinAmt.Controls.Add(objtxtbox1)
                objLabel = New Label
                objLabel.Text = reader(1) '& "<BR>" '& Microsoft.VisualBasic.vbCrLf '& "-----"
                lstlabel.Items.Add(reader(1))
                dynamicLabel.Controls.Add(objLabel)
                lblexp.Text = lblexp.Text & objLabel.Text & "<BR>" ''<BR>+ Microsoft.VisualBasic.vbNewLine
                'txtexp.Text = txtexp.Text & objLabel.Text '& "<BR>"
                objLabel2 = New Label
                objLabel2.Text = Microsoft.VisualBasic.vbCrLf & "(" & reader(2) & ")"
                lbltype.Text = lbltype.Text & objLabel2.Text & "<BR>" 'Microsoft.VisualBasic.vbNewLine
                lblMin.Text = lblMin.Text & "Min Amt" & "<BR>" 'Microsoft.VisualBasic.vbNewLine
                lsttype.Items.Add(reader(2))
            Loop
            dynamicTextBox.DataBind()
            objTextBox = dynamicTextBox.Controls(1)
            DTxtMinAmt.DataBind()
            objtxtbox1 = DTxtMinAmt.Controls(1)
            'Response.Write(objTextBox.Text)
            reader.Close()
            lblexp.Visible = True
            'txtexp.Visible = True
            dynamicLabel.Visible = False
            'lblexp.Text = lblexp.Text & objLabel.Text
        Catch ex As Exception
            msg("Plese Register Other Expense")
            NoOtherExpense = True
        End Try
    End Sub

    Private Sub btnSubmit_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnSubmit.Click
        If txtfname.Text = "" Then
            msg("Please Select Forwarders")
            Exit Sub
        End If
        If ddlname.SelectedItem.Text = "---Transport Name---" Or ddlname.SelectedItem.Text = "---Airways Name---" Or ddlname.SelectedItem.Text = "---Marine Name---" Then
            msg("Please Select Valid Transport Name ")
            Exit Sub
        End If
        If ddlno.SelectedItem.Text = "---Vehicle No---" Or ddlno.SelectedItem.Text = "---Flight No---" Or ddlno.SelectedItem.Text = "---Vessel No---" Or ddlno.SelectedItem.Text = "---Truck No---" Then
            msg("Please Select Valid Vehicle No")
            Exit Sub
        End If
        If ddlfrom.SelectedItem.Text = ddlto.SelectedItem.Text Then
            msg("Departure and Arrival Cannot be Same")
            Exit Sub
        End If
        If txtQty.Text = "" Or txtamt.Text = "" Or txtQty.Text = 0 Or txtamt.Text = 0 Then
            msg("Please Enter Valid Qty & Amount ")
            Exit Sub
        End If
        If ddlcur.SelectedItem.Text = "---Select---" Then
            msg("Please Select Valid Currency")
            Exit Sub
        End If
        InsertintoTable()
        If recstatus = True Then
            btnadd.Enabled = False
            btnSubmit.Enabled = False
            'Ve to send AutoMail to Mr.Anthony for Alerting of New Quotation
            Try
                

                Dim conm As New SqlConnection(MyGlobal.constr)
                Dim Str1 As String
                Dim mgrid
                If conm.State = ConnectionState.Closed Then conm.Open()
                Str1 = "Select email from empmaster where Designation='EA'"
                Dim cmd As New SqlClient.SqlCommand(Str1, conm)
                Dim Drm As SqlClient.SqlDataReader
                Drm = cmd.ExecuteReader
                Do While Drm.Read
                    mgrid = Drm(0)
                Loop
                Drm.Close()
                If conm.State = ConnectionState.Open Then conm.Close()

                Dim FW
                If Not txtfname.Text = "" Then
                    FW = txtfname.Text
                Else
                    FW = txtfname.Text 'ddlfid.SelectedItem.Text
                End If
                Dim QNo = txtQuoteno.Text
                Dim EfDt = txteffectivedate.Text
                'Dim str
                'str = "Dear Sir/Madam, " & Microsoft.VisualBasic.vbCrLf
                'str &= "New Quotation is given by the Forwarder:" & FW & ", which comes effective from  " & EfDt & "." & Microsoft.VisualBasic.vbCrLf
                'str &= "Please take check it and take necessary action!! " & Microsoft.VisualBasic.vbCrLf & " Pls follow up immediately." & Microsoft.VisualBasic.vbCrLf & Microsoft.VisualBasic.vbCrLf & Microsoft.VisualBasic.vbCrLf & Microsoft.VisualBasic.vbCrLf
                'str &= "MMCRM E-Logistics Autogenerated Mail."
                'Dim Mailer As MailMessage
                'Mailer = New MailMessage
                'Mailer.From = "it@maruwa.com.my"

                'Mailer.To = "logistics@maruwa.com.my;" & mgrid
                'Mailer.Subject = "Forwarders New Quotation Alert - " & "Quote No.:" & QNo & " - Forwarder:" & FW & " - Reg."
                'Mailer.Body = str
                'Mailer.BodyFormat = MailFormat.Text
                ''SmtpMail.SmtpServer = "mmsbpo1"
                'SmtpMail.SmtpServer.Insert(0, "172.16.0.11") '"mmsbpo1")
                'SmtpMail.SmtpServer = "172.16.0.11"
                'SmtpMail.Send(Mailer)
                'mynet.msg("Mail sent successfully")


            Catch ex As Exception
                msg(ex.Message)
            End Try

        End If
    End Sub

    Sub DoItemEdit(ByVal objSource As Object, ByVal objArgs As DataGridCommandEventArgs)
        'Datagrid Edit
        Response.Write("Edit")
        Grid.EditItemIndex = objArgs.Item.ItemIndex
        GetUpdateSession()
    End Sub

    Sub DoItemUpdate(ByVal objSource As Object, ByVal objArgs As DataGridCommandEventArgs)
        Try
            'Datagrid Update
            Response.Write("Update")
            Dim objTable As DataTable = Session("ObjectTable")
            Dim objTextBox As TextBox
            Dim objTextDec As Decimal
            Dim n As Integer = objTable.Columns.Count
            objTextBox = objArgs.Item.Cells(1).Controls(0)
            objTable.Rows(objArgs.Item.ItemIndex)("VehicleNo") = objTextBox.Text
            objTextBox = objArgs.Item.Cells(2).Controls(0)
            objTable.Rows(objArgs.Item.ItemIndex)("DepartPlace") = objTextBox.Text
            objTextBox = objArgs.Item.Cells(3).Controls(0)
            objTable.Rows(objArgs.Item.ItemIndex)("Arrivalplace") = objTextBox.Text
            objTextBox = objArgs.Item.Cells(4).Controls(0)
            objTable.Rows(objArgs.Item.ItemIndex)("Weight") = objTextBox.Text
            objTextBox = objArgs.Item.Cells(5).Controls(0)
            objTable.Rows(objArgs.Item.ItemIndex)("Amount") = objTextBox.Text
            objTextBox = objArgs.Item.Cells(6).Controls(0)
            objTable.Rows(objArgs.Item.ItemIndex)("CurrName") = objTextBox.Text
            objTextBox = objArgs.Item.Cells(7).Controls(0)
            objTable.Rows(objArgs.Item.ItemIndex)("OtherExpenses") = objTextBox.Text
            'objTextBox = objArgs.Item.Cells(8).Controls(0)
            'objTable.Rows(objArgs.Item.ItemIndex)("RevisionNo") = objTextBox.Text
            objTextBox = objArgs.Item.Cells(9).Controls(0)
            objTable.Rows(objArgs.Item.ItemIndex)("EffectiveDate") = objTextBox.Text
            Session("ObjectTable") = objTable
        Catch ex As Exception

        End Try

        GetUpdateSession()
    End Sub

    Sub DoItemCancel(ByVal objSource As Object, ByVal objArgs As DataGridCommandEventArgs)
        'Datagrid Cancel
        Response.Write("Cancel")
        Grid.EditItemIndex = -1
        GetUpdateSession()
    End Sub

    Private Sub ddlname_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ddlname.SelectedIndexChanged
        ddlno.Items.Clear()
        con.Open()
        If vehicleType = "Flight" Then
            ddlno.Items.Insert(0, "---Flight No---")
        ElseIf vehicleType = "Vessel" Then
            ddlno.Items.Insert(0, "---Vessel No---")
        ElseIf vehicleType = "Truck" Then
            ddlno.Items.Insert(0, "---Truck No---")
        ElseIf vehicleType = "Courier" Then
            ddlno.Items.Insert(0, "---Courier No---")
        End If
        If ddlname.SelectedItem.Text = "---Transport Name---" Or ddlname.SelectedItem.Text = "---Airways Name---" Or ddlname.SelectedItem.Text = "---Marine Name---" Or ddlname.SelectedItem.Text = "---Airways Name---" Or ddlname.SelectedItem.Text = "---Courier Name---" Then
            Grid.Visible = False
            'Call cleartext()
            Exit Sub
        End If
        If ddlno.SelectedItem.Text = "---Vehicle No---" Or ddlno.SelectedItem.Text = "---Flight No---" Or ddlno.SelectedItem.Text = "---Vessel No---" Or ddlno.SelectedItem.Text = "---Truck No---" Or ddlno.SelectedItem.Text = "---Courier No---" Then
            'Grid.Visible = False
        End If
        'cleartext()
        If con.State = ConnectionState.Closed Then
            con.Open()
        End If
        Dim a1, a2 As String
        a1 = LTrim(ddlname.SelectedItem.Text.Trim)
        Dim cmd As New SqlCommand("spSelectVehicleByTransport", con)
        cmd.CommandType = CommandType.StoredProcedure
        Dim f1 As New SqlParameter("@TransName", SqlDbType.VarChar, 50)
        f1.Value = a1
        cmd.Parameters.Add(f1)
        datread2 = cmd.ExecuteReader()
        While (datread2.Read())
            ddlno.Items.Add(datread2(0))
        End While
        datread2.Close()
        con.Close()

        ddlfrom.Items.Clear()
        ddlto.Items.Clear()
        ddlfrom.Items.Add("---Select---")
        ddlto.Items.Add("---Select---")

    End Sub

    Private Sub ddlno_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ddlno.SelectedIndexChanged
        ddlfrom.Items.Clear()
        ddlto.Items.Clear()
        If ddlno.SelectedItem.Text = "---Vehicle No---" Or ddlno.SelectedItem.Text = "---Flight No---" Or ddlno.SelectedItem.Text = "---Truck No---" Or ddlno.SelectedItem.Text = "---Vessel No---" Then
            ddlcur.SelectedIndex = 0
            ddlfrom.Items.Clear()
            ddlto.Items.Clear()
            txtamt.Text = ""
            txtQty.Text = ""
            txtnetoe.Text = ""
            'Call cleartext()
            Grid.Visible = False
            Exit Sub
        End If
        Try
            Dim arrtime, depttime
            Dim s() As String
            Dim a1 As String
            a1 = LTrim(ddlno.SelectedItem.Text.Trim)
            'cleartext()
            If con.State = ConnectionState.Closed Then
                con.Open()
            End If
            Dim cmd As New SqlCommand("SpSelectVehicleno", con)
            cmd.CommandType = CommandType.StoredProcedure
            Dim f2 As New SqlParameter("@fno", SqlDbType.VarChar, 20)
            f2.Value = a1
            cmd.Parameters.Add(f2)
            datread = cmd.ExecuteReader()
            While (datread.Read())
                txtdescriptname.Text = datread(2)
            End While
            txtdescriptname.Enabled = False
            datread.Close()

            Dim cmd4 As New SqlClient.SqlCommand("SpSelectFlightQuote", con)
            cmd4.CommandType = CommandType.StoredProcedure
            Dim q1 As New SqlParameter("@Vno", SqlDbType.VarChar, 15)
            q1.Value = a1
            cmd4.Parameters.Add(q1)
            datread = cmd4.ExecuteReader
            While (datread.Read())
                Session("t1") = datread(1)
                Session("t2") = datread(2)
                Session("t3") = datread(4)
                Session("t4") = datread(6)
                Session("t5") = datread(7)
                Session("t6") = datread(8)
                Session("t7") = datread(9)
                Session("t8") = datread(10)
                Session("t9") = datread(11)
            End While
            datread.Close()

            ddlfrom.Items.Insert(0, "---Select---")
            ddlto.Items.Insert(0, "---Select---")
            Dim cmd6 As New SqlCommand
            cmd6 = New SqlClient.SqlCommand("spSelectVehicleRoutes", con)
            cmd6.CommandType = CommandType.StoredProcedure
            Dim q2 As New SqlParameter("@Vno", SqlDbType.VarChar, 15)
            q2.Value = a1
            cmd6.Parameters.Add(q2)
            datread = cmd6.ExecuteReader()
            Dim ins As Boolean
            lstFrom.Items.Clear()
            lstTo.Items.Clear()
            While (datread.Read())
                If datread(0) <> " " Then

                    Dim lst As ListItem
                    Dim found As Boolean = False
                    For Each lst In lstFrom.Items
                        If UCase(lst.Text) = UCase(datread(0)) Then
                            found = True
                        End If
                    Next
                    If found = False Then
                        lstFrom.Items.Add(datread(0))
                    End If

                    'ddlfrom.Items.Add(datread(0))
                    'ddlfrom.Items.Add(datread(1)) ' Arrival place should not be departure
                End If
                If datread(1) <> " " Then
                    Dim lst As ListItem
                    Dim found As Boolean = False
                    For Each lst In lstTo.Items
                        If UCase(lst.Text) = UCase(datread(1)) Then
                            found = True
                        End If
                    Next
                    If found = False Then
                        lstTo.Items.Add(datread(1))
                    End If
                    'ddlto.Items.Add(datread(0))
                    'ddlto.Items.Add(datread(1))
                End If
            End While

            For Each lst As ListItem In lstTo.Items
                ddlto.Items.Add(lst.Text)
            Next

            For Each lst As ListItem In lstFrom.Items
                ddlfrom.Items.Add(lst.Text)
                ddlto.Items.Add(lst.Text)
            Next

            datread.Close()

            Dim cmd7 As New SqlCommand
            cmd7 = New SqlClient.SqlCommand("spSelectVehicleViaRoutes", con)
            cmd7.CommandType = CommandType.StoredProcedure
            Dim q3 As New SqlParameter("@Vno", SqlDbType.VarChar, 15)
            q3.Value = a1
            cmd7.Parameters.Add(q3)
            datread = cmd7.ExecuteReader()
            While (datread.Read())
                If datread(0) <> " " Then
                    ddlfrom.Items.Add(datread(0))
                    ddlto.Items.Add(datread(0))
                End If
            End While
            datread.Close()
            'BindData()
            '''
            'Dim cmd2 As New SqlClient.SqlCommand("select * from Log_VehicleQuotation where Vehicleno='" & a1 & "'", con)
            'Dim dr As SqlDataReader
            'dr = cmd2.ExecuteReader
            'If dr.HasRows Then
            '    Grid.Visible = True
            'End If
            'dr.Close()
            If con.State = ConnectionState.Open Then con.Close()

        Catch ex As Exception
            msg(ex.Message)
        End Try
    End Sub

    Private Sub ddlcur_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ddlcur.SelectedIndexChanged
        Dim b, a1, x, str9, a() As String
        a1 = ddlcur.SelectedItem.Text
        str9 = a1
        a = str9.Split("-")
        x = a(0)
        Try
            If con.State = ConnectionState.Closed Then
                con.Open()
            End If
            Dim cmd6 As New SqlClient.SqlCommand("select exchangeprice from currencymaster where currencycode= Ltrim('" & x.Trim & "') and month1=datename(month,getdate()) and year1=datename(yy,getdate())", con)
            Dim dr6 As SqlDataReader
            Dim dr7 As SqlDataReader
            dr6 = cmd6.ExecuteReader()
            Dim vv As Double
            While dr6.Read()
                vv = dr6(0)
            End While
            dr6.Close()
            If vv = 0 Then
                msg("Please Update Exchangeprice for this Currency")
                btnadd.Enabled = False
                btnSubmit.Enabled = False
            Else
                btnadd.Enabled = True
                btnSubmit.Enabled = True
            End If
            dr6.Close()
            '''
            'To display the other Expenses
            'ofees()
            curclick = 1
        Catch ex2 As Exception
            msg(ex2.Message & " ddlCur")
        End Try
        If con.State = ConnectionState.Open Then
            con.Close()
        End If
    End Sub

    Public Sub setSessionCollection()
        Dim conCollection As ControlCollection
        conCollection = dynamicTextBox.Controls
        Session("collectionObjects") = conCollection

        Dim conCollection1 As ControlCollection
        conCollection1 = DTxtMinAmt.Controls
        Session("collectionObjects1") = conCollection1
    End Sub

    Private Sub Page_Unload(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Unload
        setSessionCollection()
        'dynamicTextBox.Dispose()
        'dynamicLabel.Dispose()
    End Sub

    Private Sub ddlfrom_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ddlfrom.SelectedIndexChanged
        'To Check for Empty Place 
        If ddlfrom.SelectedItem.Text = " " Or ddlfrom.SelectedItem.Text = "" Then
            ddlfrom.SelectedIndex = 0
            Exit Sub
        End If
        'Checking Departure Vs Arrival
        If ddlfrom.SelectedItem.Text = ddlto.SelectedItem.Text Then
            msg("Departure Place and Arrival Place Can't be Same...")
            ddlfrom.SelectedIndex = 0
            'ddlto.SelectedIndex = 0
        End If
    End Sub

    Private Sub ddlto_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ddlto.SelectedIndexChanged
        'To Check for Empty Place 
        If ddlto.SelectedItem.Text = " " Or ddlto.SelectedItem.Text = "" Then
            ddlto.SelectedIndex = 0
            Exit Sub
        End If
        'Checking Departure Vs Arrival
        If ddlfrom.SelectedItem.Text = ddlto.SelectedItem.Text Then
            msg("Departure Place and Arrival Place Can't be Same...")
            'ddlfrom.SelectedIndex = 0
            ddlto.SelectedIndex = 0
        End If
    End Sub

    Sub selectitem2(ByVal objArgs As DataGridCommandEventArgs)
        Dim k As Integer
        Dim objTable As DataTable = Session("ObjectTable")
        Dim Fid = objArgs.Item.Cells(0).Text
        Dim Fno = objArgs.Item.Cells(1).Text
        Dim dplace = objArgs.Item.Cells(2).Text
        Dim aplace = objArgs.Item.Cells(3).Text
        QueryString = "select distinct a.otherfees,a.amount from log_forotherexpensedump a,log_flightquotation b where a.f_id=b.f_id  "
        objDataSet = New DataSet
        objDataAdapter = New SqlClient.SqlDataAdapter(QueryString, con)
        Try
            objDataAdapter.Fill(objDataSet, "log_forotherexpensedump")
        Catch ex As Exception
            Response.Write("Exception " & ex.Message)
        End Try
        objTable = objDataSet.Tables("log_forotherexpensedump")
        feesgrid.DataSource = objTable.DefaultView
        feesgrid.DataBind()
    End Sub

    Private Sub Imagebutton1_Click(ByVal sender As System.Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles Imagebutton1.Click
        If Calendar1.Visible = False Then
            Calendar1.Visible = True
        Else
            Calendar1.Visible = False
        End If
    End Sub

    Private Sub Calendar1_SelectionChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles Calendar1.SelectionChanged
        Dim s = Calendar1.SelectedDate
        's = Format(Calendar1.SelectedDate, "dd/mm/yyyy")
        s = Format(Convert.ToDateTime(Calendar1.SelectedDate), "MM/dd/yy")
        txteffectivedate.Text = s
        Calendar1.Visible = False
    End Sub

    Private Sub quotenogenerator()
        If con.State = ConnectionState.Closed Then
            con.Open()
        End If
        Dim s
        If ddlfid.Visible = True Then
            s = ddlfid.SelectedItem.Text.Trim
        Else
            s = txtfid.Text.Trim
        End If

        s = "QTN"


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
                txtQuoteno.Text = Quoteno

            End While



        Catch ex As Exception
            txtQuoteno.Text = Quoteno
        End Try

        If con.State = ConnectionState.Open Then
            con.Close()
        End If
    End Sub

    Private Sub Grid_ItemCommand(ByVal source As Object, ByVal e As System.Web.UI.WebControls.DataGridCommandEventArgs) Handles Grid.ItemCommand
        Select Case (CType(e.CommandSource, LinkButton)).CommandName
            Case "Delete"
                DeleteItem(e)
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

    Private Sub ddlfid_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ddlfid.SelectedIndexChanged
        If Not ddlfid.SelectedItem.Text = "---Select---" Then
            'To display the other Expenses
            Dim com6 As New SqlCommand
            Dim dr6 As SqlDataReader
            txtfid.Text = ddlfid.SelectedItem.Text.Substring(0, ddlfid.SelectedItem.Text.IndexOf("-"))

            If con.State = ConnectionState.Closed Then con.Open()
            com6 = New SqlClient.SqlCommand("select F_name from log_forwardersmaster where F_id='" & txtfid.Text.Trim & "'", con)
            dr6 = com6.ExecuteReader
            Do While dr6.Read
                txtfname.Text = dr6("F_name")
            Loop
            dr6.Close()
            'If con.State = ConnectionState.Open Then con.Close()
            ofees()
        End If
    End Sub

    Private Sub rblType_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rblType.SelectedIndexChanged
        If rblType.SelectedIndex = 0 Then
            'Call clearall()
            lblname.Text = "Airways Name"
            lblno.Text = "Flight Number"
            lbldescriptname.Text = "Flight Name"
            lblqty.Text = "Weight"
            vehicleType = "Flight"
            'If Not (Page.IsPostBack) Then
            ddlname.Items.Clear()
            ddlname.Items.Insert(0, "---Airways Name---")
            ddlno.Items.Clear()
            ddlno.Items.Insert(0, "---Flight No---")
            'End If
            lblunit.Text = "Kgs"
            rblContainerType.Visible = False
            Label3.Visible = True
            TxtMinAmt.Visible = True

        ElseIf rblType.SelectedIndex = 1 Then
            'clearall()
            lblname.Text = "Marine Name"
            lblno.Text = "Vessel Number"
            lbldescriptname.Text = "Vessel Name"
            lblqty.Text = "Revenue Tonne"
            vehicleType = "Vessel"
            'If (Page.IsPostBack = False) Then
            ddlname.Items.Clear()
            ddlname.Items.Insert(0, "---Marine Name---")
            ddlno.Items.Clear()
            ddlno.Items.Insert(0, "---Vessel No---")
            rblContainerType.Visible = True
            txtQty.Text = "1"
            Label3.Visible = False
            TxtMinAmt.Visible = False
            lblunit.Text = "(Minimum RT)"
        ElseIf rblType.SelectedIndex = 2 Then
            'clearall()
            lblunit.Text = "Tonnes"
            lblname.Text = "Transport Name"
            lblno.Text = "Truck Number"
            lbldescriptname.Text = "Truck Name"
            vehicleType = "Truck"
            lblqty.Text = "Weight"
            'If (Page.IsPostBack = False) Then
            ddlname.Items.Clear()
            ddlname.Items.Insert(0, "---Transport Name---")
            ddlno.Items.Clear()
            ddlno.Items.Insert(0, "---Truck No---")
            rblContainerType.Visible = False
            Label3.Visible = True
            TxtMinAmt.Visible = True
        ElseIf rblType.SelectedIndex = 3 Then
            'clearall()
            'lblunit.Text = ""
            lblname.Text = "Courier Name"
            lblno.Text = "Ref Number"
            lbldescriptname.Text = "Courier Name"
            vehicleType = "Courier"
            lblqty.Text = "Weight"
            'If (Page.IsPostBack = False) Then
            ddlname.Items.Clear()
            ddlname.Items.Insert(0, "---Courier Name---")
            ddlno.Items.Clear()
            ddlno.Items.Insert(0, "---Courier No---")
            rblContainerType.Visible = False
            Label3.Visible = True
            TxtMinAmt.Visible = True
        End If
        ddlfrom.Items.Clear()
        ddlto.Items.Clear()
        con.Open()
        Dim a1 As String
        a1 = rblType.SelectedValue
        Dim cmd As New SqlCommand("SpSelectTransName", con)
        cmd.CommandType = CommandType.StoredProcedure
        Dim f2 As New SqlParameter("@VType", SqlDbType.VarChar, 20)
        f2.Value = a1
        cmd.Parameters.Add(f2)
        datread = cmd.ExecuteReader
        Do While datread.Read
            ddlname.Items.Add(datread("Transportname"))
        Loop
        'BindDate()
        con.Close()
    End Sub

    Private Sub rblContainerType_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles rblContainerType.SelectedIndexChanged
        If rblContainerType.SelectedIndex = 0 Then
            lblqty.Text = "Revenue Tonne"
            txtQty.Text = "1"
            lblunit.Text = "(Minimum RT)"
        ElseIf rblContainerType.SelectedIndex = 1 Then
            lblqty.Text = "Container Size(20/40)"
            txtQty.Text = "20"
            lblunit.Text = "Feet"
        End If
        'txtQty.Text = ""
        txtamt.Text = ""
    End Sub
End Class
