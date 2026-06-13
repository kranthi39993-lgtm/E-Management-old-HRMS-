'Importing the Namespaces
Imports System.Data.SqlClient
Imports System.Web.Security
Partial Class ExpensesRegistration
    'Variables
    Inherits Messagebox
    Dim MyGlobal As New emanagement.globalinfo
    Dim str As String = MyGlobal.ConCRMStr

    Dim con As New SqlConnection(str)
    Dim con1 As New SqlConnection(str)
    Dim ds As New DataSet
    Public flag As Boolean
    Dim mynet As New CRMlognetglobal
    Public dr1 As SqlDataReader
    Public dr3 As SqlDataReader
    Dim str3 As String
    Public str1, x, y, a() As String

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
        'Setting the Session Timeout
        Session("UserId") = Session("empcode")

        Response.AppendHeader("Refresh", (Session.Timeout * 40 + 60).ToString() + "; URL=../logout.aspx")
        If con.State = ConnectionState.Closed Then con.Open()
        If Not Page.IsPostBack Then
            'Loading the existing expenses
            Dim cmd1 As New SqlCommand("select * from log_expenses Order By ExpenseName", con)
            Dim dr1 As SqlDataReader
            dr1 = cmd1.ExecuteReader()
            ddloelist.Items.Insert(0, " - Select - ")
            While (dr1.Read())
                str3 = dr1(0) & "-" & dr1(1)
                ddloelist.Items.Add(str3)
            End While
            dr1.Close()
            lblcode.Visible = True
            lblname.Visible = True
            txtcode.Visible = True
            txtexname.Visible = True
            'txtminamt.Visible = True
            ExCodeGenerator()
        End If
        If con.State = ConnectionState.Open Then con.Close()

    End Sub

    Private Sub btnSubmit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSubmit.Click
        'Inserting into the table
        'If ddloelist.SelectedItem.Text = " - Select - " Then
        '    Exit Sub
        'End If
        If txtcode.Text = "" Or txtexname.Text = "" Then
            msg("Enter the Name And Try Again")
            Exit Sub
        End If
        'If txtminamt.Text = "" Then
        '    msg("Enter the Minimum Amount value and Try Again!")
        'End If
        If Len(txtexname.Text) > 25 Then
            msg("Expense Name Can not be Exceeded More than 25 Character")
            Exit Sub
        End If

        Try
            If con.State = ConnectionState.Closed Then
                con.Open()
            End If
            Dim s, y As String

            'Dim cmd2 As New SqlCommand("select * from log_expenses", con)
            'dr3 = cmd2.ExecuteReader()
            'While (dr3.Read())
            '    s = UCase(LTrim(dr3(1)))
            '    If UCase(LTrim(dr3(1))) = UCase(LTrim(txtexname.Text)) Then
            '        msg("This Expense already Registered")
            '        txtexname.Text = ""
            '        Exit Sub
            '    End If
            'End While
            'dr3.Close()

            Dim cmd3 As New SqlCommand("select * from log_expenses", con)
            dr3 = cmd3.ExecuteReader()
            While (dr3.Read())
                s = UCase(RTrim(LTrim(dr3(0))))
                y = UCase(txtcode.Text)

                If UCase(RTrim(LTrim(dr3(0)))) = UCase(txtcode.Text) Then
                    flag = True
                    GoTo V
                Else
                    flag = False
                End If
            End While
V:


            If flag = True Then
                Call up()
            Else
                Call ins()
            End If
            dr3.Close()
            ''''
            ddloelist.Items.Clear()
            Dim cmd1 As New SqlCommand("select * from log_expenses", con)
            Dim dr1 As SqlDataReader
            dr1 = cmd1.ExecuteReader()
            ddloelist.Items.Insert(0, " - Select - ")
            While (dr1.Read())
                str3 = dr1(0) & "-" & dr1(1)
                ddloelist.Items.Add(str3)
            End While
            dr1.Close()
            ''''
            Call clear()
            ExCodeGenerator()

            If con.State = ConnectionState.Open Then
                con.Close()
            End If
        Catch ex As Exception
            msg(ex.Message)
        End Try
    End Sub
    Public Sub ins()
        'Inserting
        dr3.Close()
        Dim cmd1 As New SqlCommand("insert into log_expenses values(ltrim('" & txtcode.Text.Trim & "'),ltrim('" & txtexname.Text & "'),'" & ddlType.SelectedItem.Text.Trim & "'," & Val(txtminamt.Text) & ")", con)
        cmd1.ExecuteNonQuery()
        msg("Expense Added")
        Call clear()
    End Sub
    Public Sub up()
        'Updating
        dr3.Close()
        Dim cmd4 As New SqlCommand("update log_expenses set expensename = ltrim('" & txtexname.Text & "'), ExpenseType='" & ddlType.SelectedItem.Text.Trim & "', MinimumAmount='" & txtminamt.Text & "' where expensecode=ltrim('" & txtcode.Text & "') ", con)
        cmd4.ExecuteNonQuery()
        msg("Expense Updated")
    End Sub
    Public Sub clear()
        txtcode.Text = ""
        txtexname.Text = ""
        ddloelist.ClearSelection()
    End Sub

    Private Sub btnExit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnExit.Click
        'Go Back to the Main
        Response.Redirect("../HRMIS/Default.aspx")

    End Sub


    Private Sub btnClear_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClear.Click
        'To Clear the Controls
        Call clear()
    End Sub

   
    Private Sub ExCodeGenerator()
        If con1.State = ConnectionState.Closed Then con1.Open()
        Dim cmd As New SqlCommand("select count(ExpenseCode) from log_expenses", con1)
        Dim dr As SqlDataReader
        dr = cmd.ExecuteReader()
        Do While dr.Read
            Dim s = dr(0)
            Dim max, length
            length = Len(s)
            Dim Num As Integer
            Num = Right(s, length - 1)
            Num = Num + 1
            txtcode.Text = "X" & Num
        Loop
        dr.Close()
        If con1.State = ConnectionState.Open Then con1.Close()
    End Sub
    Private Sub ddloelist_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ddloelist.SelectedIndexChanged
        Try
            If con.State = ConnectionState.Closed Then con.Open()
            If ddloelist.SelectedItem.Text = " - Select - " Then
                Call clear()
                ExCodeGenerator()
                Exit Sub
            End If
            Dim a1 As String
            a1 = LTrim(ddloelist.SelectedItem.Text.Trim)
            str1 = a1
            Dim i As Integer
            a = str1.Split("-")
            x = a(0)
            y = a(1)

            txtcode.Text = x
            txtexname.Text = y
            Dim cmd1 As New SqlCommand("select * from log_expenses where ExpenseName='" & y & "'", con)
            Dim dr1 As SqlDataReader
            dr1 = cmd1.ExecuteReader()
            Do While dr1.Read
                If dr1(2) = "Standard" Then
                    ddlType.SelectedIndex = 0
                Else
                    ddlType.SelectedIndex = 1
                End If
                txtminamt.Text = dr1(3)
            Loop
            dr1.Close()
            If con.State = ConnectionState.Open Then con.Close()
        Catch ex As Exception
            msg(ex.Message)
        End Try
    End Sub

End Class
