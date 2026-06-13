Imports System.Data
Imports System
Imports System.Globalization
Imports System.Data.SqlClient
Imports E_Management.emanagement.globalinfo
Imports E_Management.emanagement.EMSapplications
Imports System.Web.Security
Imports System.Net.Mail
Partial Public Class AbnormalityReports
    Inherits System.Web.UI.Page
    Dim MyGlobal As New Emanagement.globalinfo
    Dim MyApp As New Emanagement.EMSapplications
    Dim thisdate As Date
    Dim appno As String
    Dim Stat As Boolean

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        MyGlobal.Open_Con_FMD()
        MyGlobal.Con_Str()
        'Session("empcode") = "014543"
    End Sub

    Protected Sub showrepZFR_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles showrepZFR.Click

        Dim fd1 As String
        fd1 = txtfrom.Text.Trim
        Dim strdate() As String = fd1.Split("/"c)
        fd1 = strdate(1) & "/" & strdate(0) & "/" & strdate(2)

        Dim fd As Date
        fd = CDate(fd1)
        Session("allfromd") = fd

        Dim td1 As String
        td1 = txtto.Text.Trim
        Dim strdate2() As String = td1.Split("/"c)
        td1 = strdate2(1) & "/" & strdate2(0) & "/" & strdate2(2)

        Dim td As Date
        td = CDate(td1)
        Session("alltod") = td
       
        Dim dept = ddldeptr.SelectedValue
        Session("dept") = dept


        If rbvalue.SelectedValue = "mcno" Then
            Dim mcno = mcnoddl.SelectedValue
            Session("mcno") = mcnoddl.SelectedValue
            Response.Redirect("Abnormalityrpt.aspx")
        Else
            Session("mcno") = "all"
            Response.Redirect("Abnormalityrptall.aspx")
        End If

    End Sub

    Protected Sub rbvalue_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rbvalue.SelectedIndexChanged

        If rbvalue.SelectedValue = "mcno" Then
            mcnoddl.Enabled = True

        ElseIf rbvalue.SelectedValue = "all" Then
            mcnoddl.Enabled = False

        End If

    End Sub

    Protected Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Dim dept = ddldeptr.SelectedValue

        Dim fd1 As String
        fd1 = txtfrom.Text.Trim
        Dim strdate() As String = fd1.Split("/"c)
        fd1 = strdate(1) & "/" & strdate(0) & "/" & strdate(2)

        Dim fd As Date
        fd = CDate(fd1)
        Session("allfromd") = fd.ToString("dd-MMM-yyyy")

        Dim td1 As String
        td1 = txtto.Text.Trim
        Dim strdate2() As String = td1.Split("/"c)
        td1 = strdate2(1) & "/" & strdate2(0) & "/" & strdate2(2)

        Dim td As Date
        td = CDate(td1)
        Session("alltod") = td.AddDays(1).ToString("dd-MMM-yyyy")

        Session("mcno") = mcnoddl.SelectedValue
        Session("dept") = dept

        Response.Redirect("FMTempReportDesign.aspx")
    End Sub
End Class