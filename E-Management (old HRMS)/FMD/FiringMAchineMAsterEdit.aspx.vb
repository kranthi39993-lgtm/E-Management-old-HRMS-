Imports System.Data
Imports System
Imports System.Globalization
Imports System.Data.SqlClient
Imports E_Management.emanagement.globalinfo
Imports E_Management.emanagement.EMSapplications
Imports e_management.emanagement.NetGlobal
Imports System.Web.Security
Partial Public Class FiringMAchineMAsterEdit
    Inherits System.Web.UI.Page
    Dim MyGlobal As New Emanagement.globalinfo
    Dim MyApp As New Emanagement.EMSapplications
    Dim thisdate As Date
    Dim appno As String

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        MyGlobal.Open_Con_FMD()
        MyGlobal.Con_Str()
        lblmsg.Text = ""
    End Sub
    Private Sub MessageBox(ByVal msg As String)
        Dim lbl As New Label()
        lbl.Text = "<script language='javascript'> window.alert('" + msg + "')</script>"
        Page.Controls.Add(lbl)
    End Sub


    Protected Sub addtogrid_btn_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles addtogrid_btn.Click

        If mcno_ddl.SelectedValue <> "-1" Then

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

                Call MyGlobal.dbSp_open_FMD("FIR_McMastergridedit")
                Cmd.Parameters.AddWithValue("@ZoneId", zoneid.Text)
                Cmd.Parameters.AddWithValue("@Temp", temperature.Text)
                Cmd.Parameters.AddWithValue("@McNo", mcno_ddl.SelectedValue)
                Cmd.Parameters.AddWithValue("@Spec", spec.Text)
                Cmd.Parameters.AddWithValue("@Max", maxspec)
                Cmd.Parameters.AddWithValue("@Min", minspec)
                Cmd.Parameters.AddWithValue("@mby", Session("empcode"))
                Cmd.Parameters.AddWithValue("@mtime", DateTime.Now)

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
   
    Function GetMcdetails(ByVal mcnum As String) As DataSet
        MyGlobal.Con_Str()
        MyGlobal.Open_Con_FMD()

        Dim ds As New DataSet()
        Dim con As New SqlConnection(conFMD)
        con.Open()
        Dim Command As New SqlCommand
        Command = New SqlCommand("select * from Fir_McZoneinfo where McNo='" & mcno_ddl.SelectedValue.Trim & "' and ZoneId = '" & mcnum & "'", con)
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

    Protected Sub dept_ddl_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles dept_ddl.SelectedIndexChanged
        mcname.Text = ""
        mcdesc.Text = ""
        mcreg.Text = ""
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
        con.Close()
        mcno_ddl.Items.Insert(0, "--Select--")

    End Sub

    Protected Sub mcno_ddl_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mcno_ddl.SelectedIndexChanged
        mcname.Text = ""
        mcdesc.Text = ""
        Appdetails()
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
            mcreg.Text = ""

            Exit Sub
        End If


        dsdata = GetFMStemp(machineno, dept)
        Dim dr As DataRow
        If dsdata.Tables(0).Rows.Count > 0 Then
            rcount = dsdata.Tables(0).Rows.Count
            Try
                For i = 0 To rcount - 1
                    dr = dsdata.Tables(0).Rows(i)
                    mcdesc.Text = dr("McDesc").ToString
                    mcname.Text = dr("McName").ToString
                    mcreg.Text = dr("createdby").ToString
                Next

            Catch ex As SqlException
                lblmsg.Text = ex.Message
                lblmsg.ForeColor = Drawing.Color.Red
            End Try

        Else
            lblmsg.Text = "Department/ Machine Number does not exist"
            lblmsg.ForeColor = Drawing.Color.Red

        End If
    End Sub
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
End Class