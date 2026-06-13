'Importing the namespaces
Imports System.Data.SqlClient
Imports System.Web.UI.HtmlControls
Imports System.Web.Security
Partial Class Expensesbyforwarder
    'Variables
    Inherits Messagebox
    Dim MyGlobal As New emanagement.globalinfo
    Dim str As String = MyGlobal.ConCRMStr
    Dim con As New SqlConnection(str)
    Dim cond As New SqlConnection(str)
    Dim ds As New DataSet
    Public flag As Boolean
    Dim mynet As New CRMlognetglobal
    Public dr1 As SqlDataReader
    Public dr3 As SqlDataReader
    Dim str33 As String
    Public str3 As String
    Public str1, str2, a(), x, y, x1, y1, b() As String
    Public Shared fl As Integer = 0
    Public Mytrans As SqlClient.SqlTransaction

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
        'Setting the Session TimeOut
        Session("UserId") = Session("empcode")

        Response.AppendHeader("Refresh", (Session.Timeout * 40 + 60).ToString() + "; URL=../logout.aspx")

        con.Open()
        If Not Page.IsPostBack Then
            'Fetching Logged Forwarder Id & Name
            Dim cmd1 As New SqlCommand("select * from log_forwardersmaster Order By F_Name", con)
            Dim dr1 As SqlDataReader
            dr1 = cmd1.ExecuteReader()
            ddlfid.Items.Insert(0, " - Select - ")
            While (dr1.Read())
                str3 = dr1(0) & "-" & dr1(1)
                ddlfid.Items.Add(str3)
            End While
            dr1.Close()
            '''''
            lstb1.Items.Clear()
            lstb2.Items.Clear()
            Dim cmd3 As New SqlCommand("select expensename from log_expenses Order By ExpenseName", con)
            Dim dr3 As SqlDataReader
            dr3 = cmd3.ExecuteReader()
            While (dr3.Read())
                lstb1.Items.Add(dr3(0))
            End While
            dr3.Close()
            '''''
        End If
        con.Close()
    End Sub
    Private Sub btnExit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnExit.Click
        'Go Back to the Main
        Response.Redirect("../HRMIS/Default.aspx")
    End Sub
    Private Sub btnadd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnadd.Click
        'Selecting the Expenses from the Listbox
        Try
            Dim li As New ListItem
            Dim flag As Boolean
            For Each li In lstb2.Items
                If lstb1.SelectedItem.Text.Trim = li.Text Then
                    flag = True
                    GoTo x
                Else
                    flag = False
                End If
            Next
x:
            If flag = False Then
                lstb2.Items.Add(lstb1.SelectedItem.Text)
            End If
        Catch exadd As Exception

        End Try
    End Sub

    Private Sub btnSubmit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSubmit.Click
        'Inserting into the Table
        Dim existitem As Boolean = False
        If ddlfid.SelectedItem.Text = " - Select - " Then
            msg("Select the Forwarder First and Try Again")
            Exit Sub
        End If
        Try
            fl = fl + 1
            str2 = ""
            str33 = ""
            Dim li2 As New ListItem
            For Each li2 In lstb2.Items
                str2 = li2.Text & "," & str2
            Next

            con.Open()
            Call getfid()
            Dim li3 As ListItem
            For Each li3 In lstb2.Items
                Dim s, y
                s = x1.Trim
                y = li3.Text.Trim
                Dim cmd6 As New SqlCommand("Select * from log_forward_expense where f_id = '" & x1.Trim & "'", con)
                Dim dr6 As SqlDataReader
                dr6 = cmd6.ExecuteReader
                Dim itemadd As Boolean = False

                While dr6.Read
                    If dr6(2) = y Then
                        existitem = True
                        Exit While
                    Else
                        itemadd = True
                        existitem = False
                        'Exit While
                    End If
                End While
                dr6.Close()
                If existitem = False Then
                    Dim cmd7 As New SqlCommand("insert into log_forward_expense (f_id, expensename) values ('" & x1.Trim & "',ltrim('" & li3.Text.Trim & "'))", con)
                    cmd7.ExecuteNonQuery()
                End If
            Next
            ''''''''''''''''''''''''''''''''''''''''''''''''''''' 
            '            'Have to decide whether this part is needed or not
            '            Dim cmd2 As New SqlCommand("select * from log_forwardersotherexpense where f_id=ltrim('" & x1.Trim & "') ", con)
            '            dr3 = cmd2.ExecuteReader()
            '            While dr3.Read
            '                If dr3(0) = x1 Then
            '                    flag = True
            '                    GoTo V
            '                Else
            '                    flag = False
            '                End If
            '            End While
            'V:
            '            If flag = True Then
            '                Call up()
            '            Else
            '                Call ins()
            '            End If
            ''''''''''''''''''''''''''''''''''''''''''''''''''''''
            con.Close()

            If cond.State = ConnectionState.Open Then cond.Close()

            msg("Expenses Successfully Assigned")
            clearall()
        Catch ex As Exception
            msg(ex.Message)
        End Try
    End Sub

    Public Sub getfid()
        'Fetching the forwarderid
        Dim a2 As String
        Dim strtemp As String
        a2 = LTrim(ddlfid.SelectedItem.Text.Trim)
        strtemp = a2
        Dim i As Integer
        b = strtemp.Split("-")
        x1 = b(0)
        y1 = b(1)
    End Sub

    Public Sub ins()
        'Inserting the New Expenses
        dr3.Close()
        Call getfid()
        Dim s
        s = str2.Trim
        Dim cmd1 As New SqlCommand("insert into log_forwardersotherexpense values ('" & x1.Trim & "', '" & y1.Trim & "', ltrim('" & str2.Trim & "'))", con)
        cmd1.ExecuteNonQuery()
        'msg("Record Inserted")
        Call clearall()
    End Sub

    Public Sub up()
        'updating the existing forwarder expenses
        dr3.Close()
        Call getfid()
        Dim cmd4 As New SqlCommand("update log_forwardersotherexpense set f_name = ltrim('" & y1.Trim & "') , otherfees= ltrim(' " & str2.Trim & " ') where f_id=ltrim(' " & x1.Trim & " ') ", con)
        cmd4.ExecuteNonQuery()
        'msg("Record Updated")
        Call clearall()
    End Sub

    Private Sub ddlfid_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ddlfid.SelectedIndexChanged
        'Selecting the existing forwarder's Expenses
        ''''''''''''
        'lstb1.Items.Clear()
        lstb2.Items.Clear()
        Dim a1 As String
        a1 = LTrim(ddlfid.SelectedItem.Text.Trim)
        str1 = a1
        Dim i As Integer
        a = str1.Split("-")
        x = a(0)
        y = a(1)
        con.Open()
        'Dim cmd3 As New SqlCommand("select expensename from log_expenses ", con)
        'Dim dr3 As SqlDataReader
        'dr3 = cmd3.ExecuteReader()
        'While (dr3.Read())
        '    lstb1.Items.Add(dr3(0))
        'End While
        'dr3.Close()

        ''''''''''''''''''''''''''''''''''''''''''''''''''
        Try
            Dim cmd5 As New SqlCommand("select expensename from log_forward_expense where F_id= ltrim('" & x.Trim & "')", con)
            Dim dr5 As SqlDataReader

            Dim s As String
            dr5 = cmd5.ExecuteReader()
            Dim str As String = ""
            lstb2.Items.Clear()
            While (dr5.Read())
                str = dr5(0)
                lstb2.Items.Add(str)
            End While
            dr5.Close()
        Catch ex As Exception
            msg(ex.Message & "Please Register Expenses for this Forwarder")
        End Try

        '''''''''''''''''''''''''''''''''''''''''''''''''''

        'Hope its not necessary, So included the above segment and commented this..
        'Dim cmd2 As New SqlCommand("select Otherfees from log_forwardersotherexpense where F_id= ltrim('" & x.Trim & "')", con)
        'Dim dr2 As SqlDataReader
        'Try
        '    dr2 = cmd2.ExecuteReader()
        '    Dim v As String = ""
        '    While (dr2.Read())
        '        v = v & dr2(0)
        '    End While
        '    dr2.Close()
        '    Dim a3, str2, aaa(), x2, y2, v2 As String
        '    x2 = ""
        '    str2 = v
        '    i = 0
        '    Dim k As Integer
        '    While (str2.IndexOf(","))
        '        aaa = str2.Split(",")
        '        x2 = x2 & aaa(i)
        '        y2 = aaa(i)
        '        If y2 = "" Or y2 = " " Then
        '            GoTo L
        '        Else
        '            lstb2.Items.Add(y2)
        '            i = i + 1
        '        End If
        '    End While
        'Catch ex As Exception
        '    msg("No Fees Registered for this Forwarder, Pl select from the Expenses List")
        'End Try
        con.Close()
L:
    End Sub

    Sub clearall()
        ddlfid.ClearSelection()
        lstb2.Items.Clear()
    End Sub

    Private Sub btnClear_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClear.Click
        'To clear the controls
        Call clearall()
    End Sub

    Private Sub btndel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btndel.Click
        'Delete an Selected item from the list
        Try
            Dim FWID, Expense
            Dim S() = Split(ddlfid.SelectedItem.Text, "-")
            FWID = S(0)
            Expense = lstb2.SelectedItem.Text.Trim
            If cond.State = ConnectionState.Closed Then cond.Open()
            Mytrans = cond.BeginTransaction
            'Dim Query = "Delete from LOG_forward_expense where F_ID='" & & "' and ExpenseName='" & & "'"
            Dim cmd As New SqlClient.SqlCommand("SPdelete_FWOtherExpense", cond, Mytrans)
            cmd.CommandType = CommandType.StoredProcedure
            cmd.Parameters.Add("@FID", FWID)
            cmd.Parameters.Add("@Expense", Expense)
            cmd.ExecuteNonQuery()
            Mytrans.Commit()

            lstb2.Items.Remove(lstb2.SelectedItem.Text)
        Catch x As Exception
            Mytrans.Rollback()
        End Try
        If cond.State = ConnectionState.Open Then cond.Close()
    End Sub

    

    
End Class
