Imports System.Data
Imports System
Imports System.Globalization
Imports System.Data.SqlClient
Imports E_Management.emanagement.globalinfo
Imports E_Management.emanagement.EMSapplications
Imports e_management.emanagement.NetGlobal
Imports System.Web.Security
Partial Public Class FiringMcMaster
    Inherits System.Web.UI.Page
    Dim MyGlobal As New Emanagement.globalinfo
    Dim MyApp As New Emanagement.EMSapplications
    Dim thisdate As Date
    Dim appno As String

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        MyGlobal.Open_Con_FMD()
        MyGlobal.Con_Str()
        'Session("empcode") = "014543"
        LblMsg.Text = ""
    End Sub
    Private Sub MessageBox(ByVal msg As String)
        Dim lbl As New Label()
        lbl.Text = "<script language='javascript'> window.alert('" + msg + "')</script>"
        Page.Controls.Add(lbl)
    End Sub

    Protected Sub SAVEET_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SAVEET.Click
        If mcname.Text <> "" And mcdesc.Text <> "" Then
            Try
                MyGlobal.Open_Con_FMD()
                MyGlobal.Con_Str()

                Call MyGlobal.dbSp_open_FMD("FIR_McMaster")
                Cmd.Parameters.AddWithValue("@Department", dept_ddl.SelectedValue)
                Cmd.Parameters.AddWithValue("@McNo", mcno.Text)
                Cmd.Parameters.AddWithValue("@McName", mcname.Text)
                Cmd.Parameters.AddWithValue("@sms", smsrb.SelectedValue)
                Cmd.Parameters.AddWithValue("@McDesc", mcdesc.Text)
                Cmd.Parameters.AddWithValue("@cby", Session("empcode"))
                Cmd.Parameters.AddWithValue("@ctime", DateTime.Now)
                Cmd.ExecuteNonQuery()

                lblmsg.Text = "ENTRY SAVED SUCCESSFULLY"
                'mcname.Text = ""
                'mcno.Text = ""
                'dept_ddl.SelectedValue = "-1"
                'mcdesc.Text = ""


                Dim ZoneId
                Dim Temp
                Dim Spec
                Dim Max
                Dim Min
                Dim machineno
                Dim cby
                Dim ctime
                Dim rcount
                Dim i = 0
                Dim mcnum

                mcnum = mcno.Text
                MyGlobal.Open_Con_FMD()
                MyGlobal.Con_Str()

                dsdata = GetMcNo(mcnum)
                Dim dr As DataRow
                If dsdata.Tables(0).Rows.Count > 0 Then
                    rcount = dsdata.Tables(0).Rows.Count
                    Try
                        For i = 0 To rcount - 1
                            dr = dsdata.Tables(0).Rows(i)
                            ZoneId = dr("ZoneId").ToString
                            Temp = dr("fTemp").ToString
                            Spec = dr("Spec").ToString
                            Max = dr("fMax").ToString
                            Min = dr("fMin").ToString
                            machineno = dr("McNo").ToString

                            Dim con As New SqlConnection(conFMD)
                            con.Open()
                            Cmd = New SqlCommand("insert into Fir_McZoneinfo (ZoneId,fTemp,Spec,fMax,fMin,McNo,createdby,ctime) values('" & ZoneId & "','" & Temp & "', '" & Spec & "','" & Max & "','" & Min & "', '" & machineno & "', '" & Session("empcode") & "', getdate())", con)
                            Cmd.ExecuteNonQuery()
                        Next
                        DelMcNo(mcnum)
                    Catch ex As SqlException
                        lblmsg.Text = ex.Message
                        lblmsg.ForeColor = Drawing.Color.Red

                    End Try
                    MessageBox("Saved Successfully")

                ElseIf dsdata.Tables(0).Rows.Count = 0 Then
                    MessageBox("Please Key in atleast one Zone ID")
                    Exit Sub
                End If

            Catch ex As SqlException
                lblmsg.Text = ex.Message
                lblmsg.ForeColor = Drawing.Color.Red
                Exit Sub
            End Try

            'dept_ddl.Enabled = True
            'mcno.Enabled = True
            'mcname.Enabled = True
            'mcdesc.Enabled = True
            'zoneid.Enabled = True

            mcname.Text = ""
            mcno.Text = ""
            dept_ddl.SelectedValue = "-1"
            mcdesc.Text = ""
            zoneid.Text = ""
            temperature.Text = ""
            spec.Text = ""
            lblmsg.Text = ""

            MyGlobal.db_close()
            GridView1.DataBind()

        Else
            'mcname.Enabled = True
            'mcdesc.Enabled = True
            'dept_ddl.Enabled = True

            MessageBox("Please enter Machine Details marked with '!'")
            Exit Sub

        End If
    End Sub

    Protected Sub addtogrid_btn_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles addtogrid_btn.Click

        If mcno.Text <> "" Then
            ' dept_ddl.Enabled = False
            '  mcno.Enabled = False
            '  mcname.Enabled = False
            '  mcdesc.Enabled = False
            zoneid.Enabled = True

            Dim maxspec As Decimal
            Dim minspec As Decimal
            Dim specval As Decimal
            Dim tempval As Decimal

            tempval = temperature.Text
            specval = spec.Text
            maxspec = (tempval + specval)
            minspec = (tempval - specval)



            Try
                MyGlobal.Open_Con_FMD()
                MyGlobal.Con_Str()

                Call MyGlobal.dbSp_open_FMD("FIR_McMastergridtemp")
                Cmd.Parameters.AddWithValue("@ZoneId", zoneid.Text)
                Cmd.Parameters.AddWithValue("@Temp", temperature.Text)
                Cmd.Parameters.AddWithValue("@McNo", mcno.Text)
                Cmd.Parameters.AddWithValue("@Spec", spec.Text)
                Cmd.Parameters.AddWithValue("@Max", maxspec)
                Cmd.Parameters.AddWithValue("@Min", minspec)
                Cmd.Parameters.AddWithValue("@cby", Session("empcode"))
                Cmd.Parameters.AddWithValue("@ctime", DateTime.Now)

                Cmd.ExecuteNonQuery()

                lblmsg.Text = "ENTRY ADDED"
                zoneid.Text = ""
                temperature.Text = ""
                spec.Text = ""
            Catch ex As SqlException
                lblmsg.Text = ex.Message
                lblmsg.ForeColor = Drawing.Color.Red
            End Try

            MyGlobal.db_close()
            GridView1.DataBind()

        Else
            MessageBox("Please enter Machine Number")
            Exit Sub
        End If
    End Sub
    Function GetMcNo(ByVal mcnum As String) As DataSet
        MyGlobal.Con_Str()
        MyGlobal.Open_Con_FMD()

        Dim ds As New DataSet()
        Dim con As New SqlConnection(conFMD)
        con.Open()
        Dim Command As New SqlCommand
        Command = New SqlCommand("select * from Fir_McZoneinfoTemp where McNo='" & mcnum & "' order by sno", con)
        Command.CommandType = CommandType.Text
        Dim DataAdap = New SqlDataAdapter(Command)
        DataAdap.Fill(ds, "MN")
        con.Close()
        Return ds
    End Function
    Function DelMcNo(ByVal mcnum As String) As DataSet
        MyGlobal.Con_Str()
        MyGlobal.Open_Con_FMD()

        Dim ds As New DataSet()
        Dim con As New SqlConnection(conFMD)
        con.Open()
        Dim Command As New SqlCommand
        Command = New SqlCommand("Delete from Fir_McZoneinfoTemp where McNo='" & mcnum & "'", con)
        Command.CommandType = CommandType.Text
        Dim DataAdap = New SqlDataAdapter(Command)
        DataAdap.Fill(ds, "FD")
        con.Close()
        Return ds
    End Function
    Function GetMcdetails(ByVal mcnum As String) As DataSet
        MyGlobal.Con_Str()
        MyGlobal.Open_Con_FMD()

        Dim ds As New DataSet()
        Dim con As New SqlConnection(conFMD)
        con.Open()
        Dim Command As New SqlCommand
        Command = New SqlCommand("select * from Fir_McZoneinfoTemp where McNo='" & mcno.Text.Trim & "' and ZoneId = '" & mcnum & "'", con)
        Command.CommandType = CommandType.Text
        Dim DataAdap = New SqlDataAdapter(Command)
        DataAdap.Fill(ds, "FD")
        con.Close()
        Return ds
    End Function

    Public Sub mpop(ByVal sender As Object, ByVal e As CommandEventArgs)
        zoneid.Enabled = False
        Try
            dsdata = GetMcdetails(e.CommandArgument)
            Dim dr As DataRow
            If dsdata.Tables(0).Rows.Count > 0 Then
                dr = dsdata.Tables(0).Rows(0)
                zoneid.Text = dr("zoneid").ToString
                temperature.Text = dr("ftemp").ToString
                spec.Text = dr("spec").ToString
            End If

        Catch ex As Exception
            lblmsg.Text = ex.Message
        End Try

    End Sub
    Protected Sub mcno_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mcno.TextChanged
        chkmcexistence()
    End Sub
    Private Sub chkmcexistence()
        Dim dep
        Dim mno
        Dim Machineno

        dep = dept_ddl.SelectedValue
        mno = mcno.Text
        Dim ds As New DataSet
        Dim dr1 As DataRow
        ds = GetMNo(mno)
        If ds.Tables(0).Rows.Count <> 0 Then
            dr1 = ds.Tables(0).Rows(0)
            machineno = dr1("Mcno").ToString
        End If
        If Machineno = mno Then
            MessageBox("Machine Number already exists ! ")
            mcno.Text = ""
            mcno.Focus()
        Else
        End If
    End Sub
    Function GetMNo(ByVal mcnum As String) As DataSet
        MyGlobal.Con_Str()
        MyGlobal.Open_Con_FMD()

        Dim ds As New DataSet()
        Dim con As New SqlConnection(conFMD)
        con.Open()
        Dim Command As New SqlCommand
        Command = New SqlCommand("select * from Fir_FiringMcMaster where McNo='" & mcnum & "'", con)
        Command.CommandType = CommandType.Text
        Dim DataAdap = New SqlDataAdapter(Command)
        DataAdap.Fill(ds, "MN")
        con.Close()
        Return ds
    End Function
End Class