'Importing the Namespaces
Imports System.Data.SqlClient
Imports System.Web.Security
Partial Class CustomCode
    'Variables
    Inherits Messagebox

    Dim MyGlobal As New emanagement.globalinfo
    Dim str As String = MyGlobal.ConCRMStr

    Dim con As New SqlConnection(str)
    Dim ds As New DataSet
    Public flag As Boolean
    Dim mynet As New CRMlognetglobal
    Public dr1 As SqlDataReader
    Public dr3 As SqlDataReader
    Dim str3 As String
    Public Shared DCode As String
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
        Response.AppendHeader("Refresh", (Session.Timeout * 40 + 60).ToString() + "; URL=../logout.aspx")
        con.Open()
        If Not Page.IsPostBack Then
            'Loading the existing expenses
            Dim cmd1 As New SqlCommand("select * from HlpgDept Order By Dept_Desc", con)
            Dim dr1 As SqlDataReader
            dr1 = cmd1.ExecuteReader()
            ddlDept.Items.Insert(0, " - Select - ")
            While (dr1.Read())
                If Not IsDBNull(dr1("FG_Group")) Then
                    str3 = dr1("Dept_Desc") & "[" & dr1("FG_Group") & "]"
                    ddlDept.Items.Add(str3)
                End If
            End While
            dr1.Close()
            lblcode.Visible = True
            txtcode.Visible = True
            txtDesc.Visible = True
        End If
        con.Close()

        If IsPostBack = False Then
            CmbCustomCode.Items.Clear()
            CmbCustomCode.Items.Add("-Select-")
            CmbCustomCode.Items.Add("8546.90.000")
            CmbCustomCode.Items.Add("6914.90.000")
            CmbCustomCode.Items.Add("6914.90.0000")
        End If
    End Sub

    Public Sub setFocus(ByVal ctrl As System.Web.UI.Control)
        Dim strS As String
        strS = "<SCRIPT language='javascript'>document.getElementById('" + ctrl.ID + "').focus() </SCRIPT>"
        Page.RegisterStartupScript("focus", strS)
    End Sub

    Private Sub btnSubmit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSubmit.Click
        'Inserting into the table
        If txtcode.Text = "" Then
            msg("Enter the Customs Code And Try Again")
            setFocus(txtcode)
            Exit Sub
        End If
        If txtDesc.Text = "" Then
            msg("Enter the Description and Try Again!")
            setFocus(txtDesc)
            Exit Sub
        End If
        Try
            If con.State = ConnectionState.Closed Then
                con.Open()
            End If

            Dim cmd3 As New SqlCommand("select * from log_deptCustomCode where deptCode='" & DCode & "'", con)
            dr3 = cmd3.ExecuteReader()
            If dr3.HasRows Then
                dr3.Close()
                Dim cmd4 As New SqlCommand("update log_DeptCustomCode set CustomCode = ltrim('" & txtcode.Text.Trim & "'), Description='" & txtDesc.Text.Trim & "', ModifiedBy='" & Session("UserId") & "', ModifiedDate='" & Now & "' where Deptcode=ltrim('" & DCode & "') ", con)
                cmd4.ExecuteNonQuery()
                msg("Custom Code and Description Updated Successfully!")
            Else
                dr3.Close()
                Dim cmd1 As New SqlCommand("insert into log_DeptCustomCode (DeptCode, CustomCode, Description, CreatedBy, CreatedDate)values ('" & DCode & "','" & txtcode.Text.Trim & "','" & txtDesc.Text.Trim & "','" & Session("UserId") & "','" & Now & "')", con)
                cmd1.ExecuteNonQuery()
                msg("Custom Code Added Successfully!")
            End If
            dr3.Close()
            'Call clear()
            If con.State = ConnectionState.Open Then
                con.Close()
            End If
        Catch ex As Exception
            msg(ex.Message)
        End Try
    End Sub

    Public Sub ins()
        'Inserting
    End Sub

    Public Sub up()
        'Updating
    End Sub

    Public Sub clear()
        txtcode.Text = ""
        txtDesc.Text = ""
        'ddlDept.ClearSelection()
    End Sub

    Private Sub btnExit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnExit.Click
        'Go Back to the Main
        Response.Redirect("../HRMIS/Default.aspx")
    End Sub

    Private Sub btnClear_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClear.Click
        'To Clear the Controls
        Call clear()
    End Sub

 
    Private Sub ddlDept_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ddlDept.SelectedIndexChanged
        Try
            Call clear()
            If con.State = ConnectionState.Closed Then con.Open()
            If ddlDept.SelectedItem.Text = " - Select - " Then
                Exit Sub
            End If
            Dim a1 As String
            a1 = LTrim(ddlDept.SelectedItem.Text.Trim)
            str1 = a1
            a = str1.Split("[")
            x = a(0)
            y = a(1)
            DCode = y.Substring(0, 2)

            Dim cmd1 As New SqlCommand("select * from log_deptCustomCode where DeptCode='" & DCode & "'", con)
            Dim dr1 As SqlDataReader
            dr1 = cmd1.ExecuteReader()
            Do While dr1.Read
                txtcode.Text = dr1("CustomCode")
                txtDesc.Text = dr1("Description")
            Loop
            dr1.Close()
            If con.State = ConnectionState.Open Then con.Close()
        Catch ex As Exception
            msg(ex.Message)
        End Try
    End Sub

    Protected Sub CmbCustomCode_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CmbCustomCode.SelectedIndexChanged
        txtcode.Text = CmbCustomCode.Text
    End Sub
End Class
