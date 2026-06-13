Imports System.Data
Imports System
Imports System.Globalization
Imports System.Data.SqlClient
Imports E_Management.emanagement.globalinfo
Imports E_Management.emanagement.EMSapplications
Imports System.Web.Security
Imports System.Net.Mail
Partial Public Class ZoneFailureReportSelection
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
    Function GetZonefailuredetails(ByVal mcnum As String, ByVal frmdt As Date, ByVal todt As Date) As DataSet
        MyGlobal.Con_Str()
        MyGlobal.Open_Con_FMD()

        Dim ds As New DataSet()
        Dim con As New SqlConnection(conFMD)
        con.Open()
        Dim Command As New SqlCommand
        Command = New SqlCommand("select * from Fir_temperaturecheck where McNo = '" & mcnum & "' and entrydate >= '" & frmdt & "' and entrydate <= '" & todt & "'", con)
        Command.CommandType = CommandType.Text
        Dim DataAdap = New SqlDataAdapter(Command)
        DataAdap.Fill(ds, "MN")
        con.Close()
        Return ds
    End Function
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

        Dim mcno = mcnoddl.SelectedValue
        Session("mcno") = mcno

        Response.Redirect("ZoneFailureRpt.aspx")

       
        'Dim dsdata1 As New DataSet
        'dsdata1 = GetZonefailuredetails(mcno, fd, td)
        'Dim dt As DataRow
        'Dim mno, m
        'Dim zid
        'Dim seldate
        'Dim failure
        'Dim ampm
        'Dim ncount
        'If dsdata1.Tables(0).Rows.Count > 0 Then
        '    ncount = dsdata1.Tables(0).Rows.Count
        '    For m = 0 To ncount - 1
        '        dt = dsdata1.Tables(0).Rows(m)

        '        mno = dt("Mcno").ToString
        '        zid = dt("ZoneId").ToString
        '        seldate = dt("EntryDate").ToString
        '        failure = dt("status").ToString
        '        'ampm = dt("AMPM").ToString

        '        If failure = "OK" Then
        '            Dim stat = "0"
        '        ElseIf failure = "NG" Then
        '            Stat = "1"
        '        End If

        '        Dim calc = 0
        '        calc = calc + Stat

        '        Try
        '            MyGlobal.Con_Str()
        '            MyGlobal.Open_Con_FMD()
        '            Dim con As New SqlConnection(conFMD)
        '            con.Open()
        '            Cmd = New SqlCommand("insert into Fir_FailZoneRptTemp (mcno,zoneid,sdate,failure,keyinby,keyintime) values('" & mno & "','" & zid & "','" & seldate & "','" & calc & "','" & Session("empcode") & "',getdate())", con)
        '            Cmd.ExecuteNonQuery()
        '        Catch ex As Exception
        '            lblmsg.Text = ex.Message
        '            lblmsg.ForeColor = Drawing.Color.Red
        '        End Try
        '    Next
        'End If

    End Sub

















    'Dim rdvalue As String
    '    rdvalue = rdoptions.SelectedValue

    'Dim status As String
    ''status = rdstatus.SelectedValue.Trim

    '    Session("otdesig") = Trim(ddldesigr.SelectedValue)
    '    Session("otemp") = Trim(txtempidr.Text)
    '    Session("otsect") = Trim(ddlsectrpt.SelectedValue)
    '    Session("otdept") = ddldeptr.SelectedValue.Trim
    ''Session("Otstatus") = rdstatus.SelectedValue.Trim



    '    If rdvalue = "Dept" And ddldeptr.SelectedValue <> "" Then
    '        Session("otRptby") = "D"
    '    ElseIf rdvalue = "Sect" And ddlsectrpt.SelectedValue <> "" Then
    '        Session("otRptby") = "S"
    '    ElseIf rdvalue = "Desig" And ddldesigr.SelectedValue <> "" Then
    '        Session("otRptby") = "Desi"
    '    ElseIf rdvalue = "Emp" And txtempidr.Text <> "" Then
    '        Session("otRptby") = "E"
    '    Else
    '        Session("otRptby") = "O"
    '    End If


    '    If status = "all" Then
    '        Response.Redirect("OTreportsbyselection.aspx")
    '    ElseIf status = "A" Then
    '        Response.Redirect("OTreportApproved.aspx")
    '    ElseIf status = "S" Then
    '        Response.Redirect("OTreportScheduled.aspx")
    '    ElseIf status = "R" Then
    '        Response.Redirect("OTreportREjected.aspx")
    '    ElseIf status = "C" Then
    '        Response.Redirect("OTreportCanceled.aspx")
    '    End If

    'End Sub

End Class