Imports System.Text.RegularExpressions
Imports System.Data.SqlClient
Imports System.Data.DataView
Imports System.Web.Security
Imports netglobal
Partial Class QuotationListing
    Inherits System.Web.UI.Page
    Dim mynet As New CRMlognetglobal
    Public Shared fid, fname, QuotStatus As String
    Dim com As New SqlClient.SqlCommand

    Dim MyGlobal As New emanagement.globalinfo
    Dim str As String = MyGlobal.ConCRMStr

    Dim QueryString As String
    Dim con, con1, con2 As New SqlConnection(Str)
    Dim datread As SqlClient.SqlDataReader
    Dim datread2 As SqlClient.SqlDataReader
    Dim objDataAdapter As SqlClient.SqlDataAdapter
    Dim DatSet As DataSet
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
        Try

            Session("UserId") = Session("empcode")

            If Page.IsPostBack = False Then
                con.Open()
                Dim cmd10 As New SqlCommand("select EmpCustCode from users where userID='" & Session("UserId") & " '", con)
                Dim dr10 As SqlDataReader
                dr10 = cmd10.ExecuteReader
                Do While dr10.Read
                    Session("uname") = dr10(0)
                Loop
                dr10.Close()
                ddlfid.Visible = True
                txtfid.Text = Session("uname")
                Dim firstword As String
                firstword = Mid(Session("uname"), 1, 1)

                If firstword = "F" Or firstword = "f" Then
                    ddlfid.Visible = False
                    txtfid.Visible = True
                    Dim com6 As New SqlCommand
                    Dim dr6 As SqlDataReader
                    com6 = New SqlClient.SqlCommand("select F_name from log_forwardersmaster where F_id='" & Session("uname") & "' Order By F_Name", con)
                    dr6 = com6.ExecuteReader
                    Do While dr6.Read
                        txtfid.Text = dr6("F_name")
                        fname = dr6("F_name")
                    Loop
                    dr6.Close()
                    '''
                ElseIf firstword = "A" Or firstword = "a" Then
                    ddlfid.Visible = False
                    txtfid.Visible = True
                    Dim com6 As New SqlCommand
                    Dim dr6 As SqlDataReader
                    com6 = New SqlClient.SqlCommand("select A_id from log_AgentsMaster where A_id='" & Session("uname") & "'", con)
                    dr6 = com6.ExecuteReader
                    Do While dr6.Read
                        Session("frowid") = dr6("A_id")
                        Dim c As String = Session("frowid")
                    Loop
                    dr6.Close()
                    Dim com5 As New SqlCommand
                    Dim dr5 As SqlDataReader
                    com5 = New SqlClient.SqlCommand("select F_id from log_AgentsMaster where A_id='" & Session("frowid") & "'", con)
                    dr5 = com5.ExecuteReader
                    Do While dr5.Read
                        fid = (dr5("F_id"))
                    Loop
                    dr5.Close()
                    Dim com7 As New SqlCommand
                    Dim dr7 As SqlDataReader
                    com7 = New SqlClient.SqlCommand("select F_name from log_forwardersmaster where F_id='" & fid & "' Order By F_Name", con)
                    dr7 = com7.ExecuteReader
                    Do While dr7.Read
                        txtfid.Text = dr7("F_name")
                        fname = dr7("F_name")
                    Loop
                    dr7.Close()
                Else
                    ddlfid.Visible = True
                    txtfid.Visible = False
                    Dim com5 As New SqlCommand
                    Dim dr5 As SqlDataReader
                    com5 = New SqlClient.SqlCommand("FM_selid", con)
                    com5.CommandType = CommandType.StoredProcedure
                    dr5 = com5.ExecuteReader
                    Do While dr5.Read
                        'ddlfid.Items.Add(dr5("F_id"))
                        ddlfid.Items.Add(dr5("F_Name"))
                    Loop
                    dr5.Close()
                    txtfid.Text = ""
                End If


                ddlfid.Items.Clear()

                Dim TmpCmd1 As New SqlCommand
                Dim TmpAd1 As New SqlDataAdapter
                Dim TMpDs1 As New DataSet

                TmpCmd1 = New SqlCommand("Select Distinct F_ID, F_Name From Log_ForwardersMaster WHere F_Id in ( Select Distinct F_ID From Log_VehicleQuotation) Order by F_Name", con)

                Dim UnStr As String = ""
                Dim FStr As String = ""

                TMpDs1 = New DataSet
                TmpAd1 = New SqlDataAdapter(TmpCmd1)
                TmpAd1.Fill(TMpDs1, "Frwrdr")
                For Tmpi As Integer = 0 To TMpDs1.Tables(0).Rows.Count - 1
                    FStr = TMpDs1.Tables(0).Rows(Tmpi).Item(1)
                    If UnStr <> FStr Then
                        ddlfid.Items.Add(FStr)
                    End If
                    UnStr = FStr


                Next

            End If


            




            If ddlfid.Visible = True Then
                Session("CurrentFW") = ddlfid.SelectedItem.Text
            Else
                Session("CurrentFW") = txtfid.Text
            End If
            If con.State = ConnectionState.Open Then
                con.Close()
            End If
        Catch ex As Exception

        End Try
        lblHead.Text = ""
        If Page.IsPostBack = False Then
            If Session("IsForwarder") = 1 Then
                txtfid.Visible = True
                ddlfid.Visible = False
            ElseIf Session("IsAgent") = 1 Then
                txtfid.Visible = True
                ddlfid.Visible = False
            ElseIf Session("CAdmin") <> True Then
                txtfid.Visible = False
                ddlfid.Visible = True
            ElseIf Session("IsEmployee") = 1 Then
                txtfid.Visible = False
                ddlfid.Visible = True
            ElseIf Session("CAdmin") = True Then
                txtfid.Visible = False
                ddlfid.Visible = True
            End If
            txtfid.Enabled = False

            RadBtnQuotLst.SelectedIndex = 0
            QuotStatus = "No"




            'BindData()
        End If
    End Sub



  

    Private Sub btnexit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnExit.Click
        Dim count, i As Integer
        FormsAuthentication.RedirectFromLoginPage(Session("userID"), True)
        Response.Redirect("../HRMIS/Default.aspx")
    End Sub

    Private Sub RadBtnQuotLst_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RadBtnQuotLst.SelectedIndexChanged
        'If RadBtnQuotLst.SelectedIndex = 0 Then
        '    lblHead.Text = "All Quotations"
        '    QueryString = "Select distinct FQNo, CreatedDate, ApprovedStatus  from log_VehicleQuotation where f_id= (Select F_id from log_ForwardersMaster where F_name='" & fname & "')"

        'Else
        If RadBtnQuotLst.SelectedIndex = 0 Then
            lblHead.Text = "Pending Quotations"
            'QueryString = "Select distinct FQNo, CreatedDate, ApprovedStatus  from log_VehicleQuotation where f_id= (Select F_id from log_ForwardersMaster where F_name='" & fname & "') and ApprovedStatus='No'"
            Session("Quotstatus") = "Pending"
            QuotStatus = "No"
        ElseIf RadBtnQuotLst.SelectedIndex = 1 Then
            lblHead.Text = "On Hold Quotations"
            'QueryString = "Select distinct FQNo, CreatedDate, ApprovedStatus  from log_VehicleQuotation where f_id= (Select F_id from log_ForwardersMaster where F_name='" & fname & "') and ApprovedStatus='On Hold'"
            Session("Quotstatus") = "On Hold"
            QuotStatus = "On Hold"
        ElseIf RadBtnQuotLst.SelectedIndex = 2 Then
            lblHead.Text = "Approved Quotations"
            'QueryString = "Select distinct FQNo, CreatedDate, ApprovedStatus from log_VehicleQuotation where f_id= (Select F_id from log_ForwardersMaster where F_name='" & fname & "') and ApprovedStatus='Approved'"
            Session("Quotstatus") = "Approved"
            QuotStatus = "Approved"
        ElseIf RadBtnQuotLst.SelectedIndex = 3 Then
            lblHead.Text = "Rejected Quotations"
            'QueryString = "Select distinct FQNo, CreatedDate, ApprovedStatus  from log_VehicleQuotation where f_id= (Select F_id from log_ForwardersMaster where F_name='" & fname & "') and ApprovedStatus='Rejected'"
            Session("Quotstatus") = "Rejected"
            QuotStatus = "Rejected"
        End If
        BindData()
    End Sub
    Sub BindData()
        If ddlfid.Visible = True Then
            If ddlfid.SelectedItem.Text <> " " Or ddlfid.SelectedItem.Text <> "---Select---" Then
                fname = ddlfid.SelectedItem.Text
            Else
                mynet.msg("Please Select Forwarder From the Given List!")
            End If
        Else
            fname = txtfid.Text
        End If
        QueryString = "Select distinct FQNo, convert(varchar(10),CreatedDate,103) as 'CreatedDate', ApprovedStatus  from log_VehicleQuotation where f_id in (Select F_id from log_ForwardersMaster where F_name='" & fname & "') and ApprovedStatus='" & QuotStatus & "'"

        DatSet = New DataSet
        objDataAdapter = New SqlClient.SqlDataAdapter(QueryString, con)
        Try
            objDataAdapter.Fill(DatSet, "log_VehicleQuotation")
        Catch ex As Exception
            Response.Write("Exception " & ex.Message)
        End Try
        DatSet.AcceptChanges()
        Dim objTable As DataTable = DatSet.Tables("log_VehicleQuotation")
        Session("ObjectTable") = objTable
        GetUpdateSession()
    End Sub

    Sub GetUpdateSession()
        Dim objTable As DataTable = Session("ObjectTable")
        Grid.DataSource = objTable.DefaultView
        Grid.DataBind()
        Grid.Visible = True
    End Sub

    Private Sub ddlfid_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ddlfid.SelectedIndexChanged
        '    If ddlfid.SelectedItem.Text <> " " Or ddlfid.SelectedItem.Text <> "---Select---" Then
        '        If con.State = ConnectionState.Closed Then
        '            con.Open()
        '        End If
        '        'Dim com7 As New SqlCommand
        '        'Dim dr7 As SqlDataReader
        '        ''com7 = New SqlClient.SqlCommand("select F_id from log_forwardersmaster where F_name='" & ddlfid.SelectedItem.Text & "'", con)
        '        'com7 = New SqlClient.SqlCommand("select F_Name from log_forwardersmaster where F_id='" & ddlfid.SelectedItem.Text & "'", con)
        '        'dr7 = com7.ExecuteReader
        '        'Do While dr7.Read
        '        '    fname = dr7("F_name")
        '        '    fid = ddlfid.SelectedItem.Text.Trim
        '        '    txtfid.Text = fname
        '        'Loop
        '        fname = ddlfid.SelectedItem.Text

        '        'dr7.Close()
        '        'If con.State = ConnectionState.Open Then
        '        '    con.Close()
        '        'End If
        '    End If
        RadBtnQuotLst.SelectedIndex = -1
    End Sub
End Class
