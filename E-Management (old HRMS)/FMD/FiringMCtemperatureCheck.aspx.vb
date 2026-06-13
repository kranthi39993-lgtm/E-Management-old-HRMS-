Imports System.Data
Imports System
Imports System.Globalization
Imports System.Data.SqlClient
Imports E_Management.emanagement.globalinfo
Imports E_Management.emanagement.EMSapplications
Imports System.Web.Security
Imports System.Net.Mail

Partial Public Class FiringMCtemperatureCheck
    Inherits System.Web.UI.Page
    Dim MyGlobal As New Emanagement.globalinfo
    Dim MyApp As New Emanagement.EMSapplications
    Dim thisdate As Date
    Dim appno As String
    Dim Stat As Boolean

    Private Sub Page_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Init
        Stat = False
        Session("emailalert") = "N"
    End Sub

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        MyGlobal.Open_Con_FMD()
        MyGlobal.Con_Str()
        'Session("empcode") = "014543"

        lblmsg.Text = ""
        datebox.Text = DateTime.Now
        timebox.Text = DateTime.Now

    End Sub
    Private Sub MessageBox(ByVal msg As String)
        Dim lbl As New Label()
        lbl.Text = "<script language='javascript'> window.alert('" + msg + "')</script>"
        Page.Controls.Add(lbl)
    End Sub

    Private Sub Appdetails()
        Dim machineno
        Dim dept
        Dim rcount
        Dim i

        machineno = mcno_ddl.SelectedValue
        dept = dept_ddl.SelectedValue
        If machineno = "--Select--" Then
            mcname.Text = ""
            mcdesc.Text = ""

            Exit Sub
        End If

        Dim ft As String
        ft = DateTime.Now.ToString("dd/MM/yyyy")
        Dim ft1 As String
        ft1 = DateTime.Now.ToString("MM/dd/yyyy")
        dttoday.Text = ft

        Dim tt As String
        tt = DateTime.Now.ToString("hh:mm tt")
        Dim tt1 As String
        tt1 = DateTime.Now.ToString("hh:mm tt")
        timetod.Text = tt

        dsdata = GetFMStemp(machineno, dept)
        Dim dr As DataRow
        If dsdata.Tables(0).Rows.Count > 0 Then
            rcount = dsdata.Tables(0).Rows.Count
            Try
                For i = 0 To rcount - 1
                    dr = dsdata.Tables(0).Rows(i)
                    mcdesc.Text = dr("McDesc").ToString
                    mcname.Text = dr("McName").ToString
                Next

            Catch ex As SqlException
                lblmsg.Text = ex.Message
                lblmsg.ForeColor = Drawing.Color.Red
            End Try

        Else
            lblmsg.Text = "Department/ Machine Number does not exist"
            lblmsg.ForeColor = Drawing.Color.Red

        End If
        GridView2.Visible = True
        GridView1.Visible = False



    End Sub
   
    Private Sub Gridview2_RowCreated(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles GridView2.RowCreated
        If e.Row.RowType = DataControlRowType.Header Then
            e.Row.Cells(1).Visible = False
            e.Row.Cells(2).Visible = False
            e.Row.Cells(3).Visible = False
            e.Row.Cells(4).Visible = False

        End If
        If e.Row.RowType = DataControlRowType.DataRow Then
            e.Row.Cells(1).Visible = False
            e.Row.Cells(2).Visible = False
            e.Row.Cells(3).Visible = False
            e.Row.Cells(4).Visible = False

        End If
        If e.Row.RowType = DataControlRowType.Footer Then
            e.Row.Cells(1).Visible = False
            e.Row.Cells(2).Visible = False
            e.Row.Cells(3).Visible = False
            e.Row.Cells(4).Visible = False

        End If

    End Sub
    Private Sub Gridview1_RowDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles GridView1.RowDataBound
        'Dim i As Integer
        'For i = 0 To GridView1.Rows.Count - 1
        If e.Row.RowType = DataControlRowType.DataRow Then
            Dim status As String = Convert.ToString(DataBinder.Eval(e.Row.DataItem, "status"))
            If status = "OK" Or status = "ok" Or status = "Ok" Then
                e.Row.Cells(6).ForeColor = Drawing.Color.Green
            ElseIf status = "NG" Or status = "Ng" Or status = "ng" Then
                e.Row.Cells(6).ForeColor = Drawing.Color.Red
            End If
        End If
    End Sub


    Protected Sub mcno_ddl_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mcno_ddl.SelectedIndexChanged
        mcname.Text = ""
        mcdesc.Text = ""
        Appdetails()
    End Sub

    Protected Sub SaveZoneFirst(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Dim act
        Dim macno
        Dim macdes
        Dim dev
        Dim finalmsg
        Dim zmsg = ""
        Dim addmsg
        Dim Status
        Dim groupcode
        Dim scount
        Dim lcount
        Dim i
        Dim j
        Dim k
        Dim phno
        Dim starttime
        Dim endtime

        macno = mcno_ddl.SelectedValue.Trim
        macdes = mcdesc.Text.Trim

        Dim ft As String
        ft = DateTime.Now

        Dim ft1 As String
        ft1 = DateTime.Now.ToString("dd/MM/yyyy")

        Dim at As String
        at = DateTime.Now
        Dim at1 As String
        at1 = DateTime.Now.ToString("MM/dd/yyyy")


        Dim dki
        dki = DateTime.Now

        Dim gt1 As String

        gt1 = dki
        Dim strdate3() As String = gt1.Split("/"c)
        gt1 = strdate3(0) & "/" & strdate3(1) & "/" & strdate3(2)


        Dim tt As String
        tt = DateTime.Now.ToString("tt")
        Dim tt1 As String
        tt1 = DateTime.Now.ToString("hh:mm:ss tt")


        ''''''''''//////////////////////INSERT VALUES INTO FIR_TEMPERATURECHECK TABLE/////////////////////////''''''''''

        Dim IND
        IND = at1 & " " & tt1

        Dim dsrno As DataSet
        dsrno = Getfiringrno()
        Dim rno

        Dim dprno As DataRow
        If dsrno.Tables(0).Rows.Count > 0 Then
            dprno = dsrno.Tables(0).Rows(j)
            rno = dprno("refno").ToString
        End If

        For i = 0 To GridView2.Rows.Count - 1
            Dim ZoneId As String = GridView2.Rows(i).Cells(0).Text
            Dim Max As Decimal = GridView2.Rows(i).Cells(3).Text
            Dim Min As Decimal = GridView2.Rows(i).Cells(4).Text
            Dim Spec As String = GridView2.Rows(i).Cells(2).Text
            Dim temp As Decimal = GridView2.Rows(i).Cells(1).Text
            Dim actval As Decimal = DirectCast(GridView2.Rows(i).FindControl("act"), TextBox).Text

            If (actval > Max) Then
                dev = "+" & (actval - Max)
            ElseIf (actval < Min) Then
                dev = "-" & (Min - actval)
            End If


            ' addmsg = (macno & " # " & ft1 & " " & tt1 & " # ")
            addmsg = (macno & " # " & ft1 & " " & tt1 & " # ") & (" : Zone ID - Set.Temp - Actual - Variance : ")

            If (actval <= Max) And (actval >= Min) Then
                Status = "OK"
            Else
                Session("Emailalert") = "Y"
                Status = "NG"
                ' zmsg = zmsg & (ZoneId & "-" & temp & "-" & Status & " ")
                zmsg = zmsg & (" " & ZoneId & "-" & temp & "-" & actval & "-" & dev & " ")
            End If

            finalmsg = (addmsg & zmsg)

            MyGlobal.Con_Str()
            MyGlobal.Open_Con_FMD()

            Try
                DS = Open_Fir_temperaturecheck(Con, DAP, 2, "insert into Fir_temperaturecheck (McNo,ZoneId,EntryDate,EntryTime,ActualVal,Status,KeyinBy,KeyinTime,Deviation,Refno,AmPM) values('" & macno & "','" & ZoneId & "','" & IND & "','" & IND & "','" & actval & "','" & Status & "','" & Session("empcode") & "',getdate(),'" & dev & "','" & rno & "','" & tt & "')")
                Stat = True
            Catch ex As SqlException
                Stat = False
                Delreconfailure(rno)
                lblmsg.Text = ex.Message
                lblmsg.ForeColor = Drawing.Color.Red
            End Try

        Next

        Dim fmsg = finalmsg
        
        GridView1.DataBind()
        GridView1.Visible = True
        GridView2.Visible = False

        If Session("emailalert") = "Y" Then



            If dept_ddl.SelectedValue = "2000" Then
                groupcode = "'SubstrateFiringGrp','FMDfiringGrp'"
            ElseIf dept_ddl.SelectedValue = "3000" Then
                groupcode = "'CVFiringGrp','FMDfiringGrp'"
            ElseIf dept_ddl.SelectedValue = "4201" Then
                groupcode = "'MagnetFiringGrp','FMDfiringGrp'"
            ElseIf dept_ddl.SelectedValue = "7000" Then
                groupcode = "'TPHFiringGrp','FMDfiringGrp'"
            ElseIf dept_ddl.SelectedValue = "4301" Then
                groupcode = "'FerriteFiringGrp','FMDfiringGrp'"
            End If



            ''''''''''//////////////////////INSERT RESPECTIVE VALUES INTO OUTGOING TABLE IN SMS/////////////////////////''''''''''

            If (TimeOfDay() <= "06:00:00 AM" Or TimeOfDay() >= "09:00:00 PM") Then
                'Don't Send SMS
            Else

                dsdata = smsyesno(macno)
                Dim dj As DataRow
                Dim msg
                Dim n
                Dim mcount
                If dsdata.Tables(0).Rows.Count > 0 Then
                    mcount = dsdata.Tables(0).Rows.Count
                    For n = 0 To mcount - 1
                        dj = dsdata.Tables(0).Rows(j)
                        msg = dj("sms").ToString.Trim
                        If msg = "Y" Then
                            dsdata = getsmsdet(groupcode)
                            Dim dp As DataRow
                            If dsdata.Tables(0).Rows.Count > 0 Then
                                scount = dsdata.Tables(0).Rows.Count
                                For j = 0 To scount - 1
                                    dp = dsdata.Tables(0).Rows(j)
                                    phno = dp("mobileno").ToString
                                    starttime = DateTime.Now
                                    endtime = DateTime.Now

                                    Try
                                        MyGlobal.Con_Str()
                                        MyGlobal.Open_Con_SMS()
                                        Dim con As New SqlConnection(conSMSstr)
                                        con.Open()
                                        Cmd = New SqlCommand("insert into outgoing (number,message,starttime,endtime) values('" & phno & "','" & finalmsg & "','" & starttime & "','" & endtime & "')", con)
                                        Cmd.ExecuteNonQuery()
                                    Catch ex As Exception
                                        lblmsg.Text = ex.Message
                                        lblmsg.ForeColor = Drawing.Color.Red
                                    End Try
                                Next
                            End If
                        Else
                        End If
                    Next
                End If

            End If

            ''''''''''//////////////////////SEND MAIL TO THE ALL RECIPIENTS IN Fir_Email TABLE/////////////////////////''''''''''
            Dim dsdata2 As New DataSet
            dsdata2 = mailrecipients()
            Dim dm As DataRow
            Dim mailrep
            If dsdata2.Tables(0).Rows.Count > 0 Then
                lcount = dsdata2.Tables(0).Rows.Count
                For k = 0 To lcount - 1
                    dm = dsdata2.Tables(0).Rows(k)
                    mailrep = dm("email").ToString

                    Dim MySMTPServer As String
                    MySMTPServer = "58.26.100.35"
                    Try

                        Dim mymessage As New MailMessage
                        mymessage.From = New MailAddress("dashboard@maruwa.com.my")
                        mymessage.To.Add(mailrep)


                        mymessage.Subject = "Firing Machine Temperature Check Details"
                        mymessage.Body = "Firing Machine Temperature Check Details :" & finalmsg

                        Dim emailClient As New SmtpClient(MySMTPServer)
                        emailClient.Send(mymessage)
                        lblmsg1.Text = "Email Sent"
                    Catch ex As Exception
                        MessageBox(ex.ToString())
                    End Try
                Next
            End If
        End If
        Session("emailalert") = "N"
        ''''''''''//////////////////////INSERT VALUES INTO A REFERENCE TABLE Fir_smsoptimization FOR MAKING REPORTS EASIER IF REQUIRED/////////////////////////''''''''''
        Dim dsdata1 As New DataSet
        dsdata1 = Getdetailsforsmsopt(macno, rno)
        Dim dt As DataRow
        Dim fdate
        Dim no
        Dim ap
        Dim m
        Dim mno
        Dim ncount
        If dsdata1.Tables(0).Rows.Count > 0 Then
            ncount = dsdata1.Tables(0).Rows.Count
            For m = 0 To ncount - 1
                dt = dsdata1.Tables(0).Rows(m)
                no = dt("sno").ToString
                fdate = dt("entrydate").ToString
                mno = dt("McNo").ToString
                ap = dt("AMPM").ToString
            Next
            Try
                MyGlobal.Con_Str()
                MyGlobal.Open_Con_FMD()
                Dim con As New SqlConnection(conFMD)
                con.Open()
                Cmd = New SqlCommand("insert into Fir_smsoptimization (ampm,message,McNo,startdate,enddate) values('" & ap & "','" & finalmsg & "','" & mno & "','" & fdate & "','" & fdate & "')", con)
                Cmd.ExecuteNonQuery()
            Catch ex As Exception
                lblmsg.Text = ex.Message
                lblmsg.ForeColor = Drawing.Color.Red
            End Try
        End If

    End Sub
    Function smsyesno(ByVal mcnum As String) As DataSet
        MyGlobal.Con_Str()
        MyGlobal.Open_Con_FMD()

        Dim ds As New DataSet()
        Dim con As New SqlConnection(conFMD)
        con.Open()
        Dim Command As New SqlCommand
        Command = New SqlCommand("select * from Fir_FiringMcMaster where Mcno = '" & mcnum & "' and sms = 'Y'", con)
        Command.CommandType = CommandType.Text
        Dim DataAdap = New SqlDataAdapter(Command)
        DataAdap.Fill(ds, "SM")
        con.Close()
        Return ds
    End Function
    Function getsmsdet(ByVal groupcode As String) As DataSet
        MyGlobal.Con_Str()
        MyGlobal.Open_Con_SMS()

        Dim ds As New DataSet()
        Dim con As New SqlConnection(conSMSstr)
        con.Open()
        Dim Command As New SqlCommand
        Command = New SqlCommand("select * from tbl_Group_SMS where groupname in (" & groupcode & ") ", con)
        Command.CommandType = CommandType.Text
        Dim DataAdap = New SqlDataAdapter(Command)
        DataAdap.Fill(ds, "SM")
        con.Close()
        Return ds
    End Function
    Function GetFMStemp(ByVal mcnum As String, ByVal dept As String) As DataSet
        MyGlobal.Con_Str()
        MyGlobal.Open_Con_FMD()

        Dim ds As New DataSet()
        Dim con As New SqlConnection(conFMD)
        con.Open()
        Dim Command As New SqlCommand
        Command = New SqlCommand("select * from Fir_FiringMcMaster where McNo = '" & mcnum & "' and Department = '" & dept & "'", con)
        Command.CommandType = CommandType.Text
        Dim DataAdap = New SqlDataAdapter(Command)
        DataAdap.Fill(ds, "MN")
        con.Close()
        Return ds
    End Function
    Function Getdetailsforsmsopt(ByVal mcnum As String, ByVal rno As String) As DataSet
        MyGlobal.Con_Str()
        MyGlobal.Open_Con_FMD()

        Dim ds As New DataSet()
        Dim con As New SqlConnection(conFMD)
        con.Open()
        Dim Command As New SqlCommand
        Command = New SqlCommand("select * from Fir_temperaturecheck where McNo = '" & mcnum & "' and refno = '" & rno & "' and status = 'NG' ", con)
        Command.CommandType = CommandType.Text
        Dim DataAdap = New SqlDataAdapter(Command)
        DataAdap.Fill(ds, "MN")
        con.Close()
        Return ds
    End Function
    Function Delreconfailure(ByVal refno As String) As DataSet
        MyGlobal.Con_Str()
        MyGlobal.Open_Con_FMD()

        Dim ds As New DataSet()
        Dim con As New SqlConnection(conFMD)
        con.Open()
        Dim Command As New SqlCommand
        Command = New SqlCommand("delete from Fir_temperaturecheck where Refno = '" & refno & "'", con)
        Command.CommandType = CommandType.Text
        Dim DataAdap = New SqlDataAdapter(Command)
        DataAdap.Fill(ds, "MN")
        con.Close()
        Return ds
    End Function
    Function Getfiringrno() As DataSet

        MyGlobal.Con_Str()
        MyGlobal.Open_Con_FMD()

        Dim ds As New DataSet()
        Dim con As New SqlConnection(conFMD)
        con.Open()
        Dim Command As New SqlCommand
        Command = New SqlCommand("SELECT isnull(max(refno),0)+1 AS refno FROM Fir_temperaturecheck", con)
        Command.CommandType = CommandType.Text
        Dim DataAdap = New SqlDataAdapter(Command)
        DataAdap.Fill(ds, "MN")
        con.Close()
        Return ds
    End Function
    Function mailrecipients() As DataSet

        MyGlobal.Con_Str()
        MyGlobal.Open_Con_FMD()

        Dim ds As New DataSet()
        Dim con As New SqlConnection(conFMD)
        con.Open()
        Dim Command As New SqlCommand
        Command = New SqlCommand("select * from Fir_email where status = '1'", con)
        Command.CommandType = CommandType.Text
        Dim DataAdap = New SqlDataAdapter(Command)
        DataAdap.Fill(ds, "MN")
        con.Close()
        Return ds
    End Function
    Protected Sub exitpage(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Response.Redirect("FiringMCtemperatureCheck.aspx")
    End Sub

    Protected Sub dept_ddl_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles dept_ddl.SelectedIndexChanged
        mcname.Text = ""
        mcdesc.Text = ""
        LoadMcNo()
    End Sub
    Private Sub LoadMcNo()
        MyGlobal.Con_Str()
        MyGlobal.Open_Con_FMD()

        Dim ds As New DataSet()
        Dim con As New SqlConnection(conFMD)
        con.Open()
        Dim Command As New SqlCommand
        '   Command = New SqlCommand("SELECT Distinct Fir_McZoneinfo.McNo as mcno FROM Fir_FiringMcMaster INNER JOIN Fir_McZoneinfo ON Fir_FiringMcMaster.McNo = Fir_McZoneinfo.McNo WHERE (Fir_FiringMcMaster.department = '" & dept_ddl.SelectedValue.Trim & "')", con)
        Command = New SqlCommand("SELECT Distinct Fir_FiringMcMaster.McNo as mcno FROM Fir_FiringMcMaster WHERE (Fir_FiringMcMaster.department = '" & dept_ddl.SelectedValue.Trim & "')", con)
        Command.CommandType = CommandType.Text
        Dim DataAdap = New SqlDataAdapter(Command)
        DataAdap.Fill(ds, "MN")
        mcno_ddl.DataSource = ds
        mcno_ddl.DataValueField = "mcno"
        mcno_ddl.DataTextField = "mcno"
        mcno_ddl.DataBind()
        con.Close()
        'Return ds
        mcno_ddl.Items.Insert(0, "--Select--")

        'ddlmonth.Items.Add(curmth)
        'ddlmonth.Items.Add(prevmth)
        'ddlmonth.DataBind()
    End Sub
End Class