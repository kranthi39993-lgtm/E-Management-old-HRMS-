Imports System.Data
Imports System
Imports System.Globalization
Imports System.Data.SqlClient
Imports E_Management.emanagement.globalinfo
Imports E_Management.emanagement.EMSapplications
Imports System.Web.Security
Imports System.Net.Mail
Partial Public Class TemperatureCheckrpt
    Inherits System.Web.UI.Page
    Dim MyGlobal As New emanagement.globalinfo
    Dim MyApp As New emanagement.EMSapplications
    Dim mcno, dept, mon

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        MyGlobal.Open_Con_FMD()
        MyGlobal.Con_Str()
        ' Session("empcode") = "014543"
    End Sub

    Protected Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        mcno = mcno_ddl.SelectedValue.Trim
        dept = dept_ddl.SelectedValue.Trim
        mon = Mon_ddl.SelectedValue.Trim

      
        Session("McNoR") = mcno
        Session("FDept") = dept
        Session("Fsmon") = mon

        If mon = "Jan" Then
            Session("FsDate") = "01/01/" & Year(Now)
            Session("FTdate") = "01/31/" & Year(Now)
        ElseIf mon = "Feb" Then
            Dim bLeapYear As Boolean
            bLeapYear = Date.IsLeapYear(Now.Year)
            If bLeapYear = True Then
                Session("FsDate") = "02/01/" & Year(Now)
                Session("FTdate") = "02/29/" & Year(Now)
            Else
                Session("FsDate") = "02/01/" & Year(Now)
                Session("FTdate") = "02/28/" & Year(Now)
            End If
        ElseIf mon = "March" Then
            Session("FsDate") = "03/01/" & Year(Now)
            Session("FTdate") = "03/31/" & Year(Now)
        ElseIf mon = "April" Then
            Session("FsDate") = "04/01/" & Year(Now)
            Session("FTdate") = "04/30/" & Year(Now)
        ElseIf mon = "May" Then
            Session("FsDate") = "05/01/" & Year(Now)
            Session("FTdate") = "05/31/" & Year(Now)
        ElseIf mon = "June" Then
            Session("FsDate") = "06/01/" & Year(Now)
            Session("FTdate") = "06/30/" & Year(Now)
        ElseIf mon = "July" Then
            Session("FsDate") = "07/01/" & Year(Now)
            Session("FTdate") = "07/30/" & Year(Now)
        ElseIf mon = "Aug" Then
            Session("FsDate") = "08/01/" & Year(Now)
            Session("FTdate") = "08/31/" & Year(Now)
        ElseIf mon = "Sep" Then
            Session("FsDate") = "09/01/" & Year(Now)
            Session("FTdate") = "09/30/" & Year(Now)
        ElseIf mon = "Oct" Then
            Session("FsDate") = "10/01/" & Year(Now)
            Session("FTdate") = "10/31/" & Year(Now)
        ElseIf mon = "Nov" Then
            Session("FsDate") = "11/01/" & Year(Now)
            Session("FTdate") = "11/30/" & Year(Now)
        ElseIf mon = "Dec" Then
            Session("FsDate") = "12/01/" & Year(Now) - 1
            Session("FTdate") = "12/31/" & Year(Now) - 1
        End If
        Response.Redirect("RptTemperatureCheck.aspx")
    End Sub
    Protected Sub dept_ddl_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles dept_ddl.SelectedIndexChanged
        LoadMcNo()
    End Sub
    Private Sub LoadMcNo()
        MyGlobal.Con_Str()
        MyGlobal.Open_Con_FMD()

        Dim ds As New DataSet()
        Dim con As New SqlConnection(conFMD)
        con.Open()
        Dim Command As New SqlCommand
        Command = New SqlCommand("SELECT Distinct Fir_FiringMcMaster.McNo as mcno FROM Fir_FiringMcMaster WHERE (Fir_FiringMcMaster.department = '" & dept_ddl.SelectedValue.Trim & "')", con)
        Command.CommandType = CommandType.Text
        Dim DataAdap = New SqlDataAdapter(Command)
        DataAdap.Fill(ds, "MN")
        mcno_ddl.DataSource = ds
        mcno_ddl.DataValueField = "mcno"
        mcno_ddl.DataTextField = "mcno"
        mcno_ddl.DataBind()
        mcno_ddl.Items.Insert(0, "--Select--")
    End Sub
End Class