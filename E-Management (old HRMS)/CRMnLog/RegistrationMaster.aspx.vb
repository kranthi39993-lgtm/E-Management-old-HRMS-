Imports System.Text.RegularExpressions
Imports E_Management.crmlognetglobal
Imports System.Data.SqlClient
Imports System.Data.DataView
Imports System.Web.Security
Imports Microsoft

Partial Class RegistrationMaster
    Inherits CRMlognetglobal 'System.Web.UI.Page
    Dim com As New SqlClient.SqlCommand

    Dim MyGlobal As New Emanagement.globalinfo
    Dim str As String = MyGlobal.ConCRMStr

    Dim con, con1 As New SqlConnection(str)
    Dim datread As SqlClient.SqlDataReader
    Dim datread2 As SqlClient.SqlDataReader
    Dim objDataAdapter As SqlClient.SqlDataAdapter
    Dim objDataSet As DataSet
    Private viaclick As Boolean
    'Private dt As New DataTable
    Public Shared vehicleType As String
    Public Shared Routecount, routeincr As Integer
    Dim QueryString As String
    Public recinsertstatus As Boolean
    Public Shared startrouteno, newrouteno, newviarouteno As String
    Dim mynet As New CRMlognetglobal
    Dim routeno, oldrouteno, temp

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


        Session("UserId") = Session("empcode")
        'con = New SqlConnection(constr)
        'con.Open()

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
        VehicleGrid.Visible = True
        'Fetching the Names using Procedure
        'If (Page.IsPostBack = False) Then
        '    ddlname.Items.Insert(0, "---Vehicle Name---")
        '    ddlno.Items.Insert(0, "---Vehicle No---")
        'End If
    End Sub


    Private Sub btnexit_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnexit.Click
        'Go Back to Main Page
        Response.Redirect("../HRMIS/Default.aspx")
    End Sub

    Private Sub btnSubmit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSubmit.Click
        If rblType.SelectedIndex = -1 Then
            msg("Please Select Valid Vehicle Type!")
            Exit Sub
        ElseIf rblType.SelectedIndex = 0 Then
            If ddlname.SelectedItem.Text = "---Airways Name---" And txtnamenew.Text = "" Then
                msg("Please Select Valid Airways Name")
                Exit Sub
            End If
            If ddlno.SelectedItem.Text = "---Flight No---" And txtnonew.Text = "" Then
                msg("Please Select Valid Flight Number")
                Exit Sub
            End If
            startrouteno = "A"
            If LTrim(txtnonew.Text) <> "" Then
                If LTrim(txtnonew.Text) = "" And ddlno.SelectedItem.Text = "---Flight No---" Then
                    Exit Sub
                End If
                If (ddlname.SelectedItem.Text <> "---Airways Name---") Or (txtnamenew.Text <> "") Then
                    If txtvialoc.Text = "" Then
                        GoTo newsave
                    End If
                End If
            End If
            'insertintotable

        ElseIf rblType.SelectedIndex = 1 Then
            If ddlname.SelectedItem.Text = "---Marine Name---" And txtnamenew.Text = "" Then
                msg("Please Select Valid Marine Name")
                Exit Sub
            End If
            If ddlno.SelectedItem.Text = "---Vessel No---" And txtnonew.Text = "" Then
                msg("Please Select Valid Vessel Number")
                Exit Sub
            End If
            startrouteno = "V"
            If LTrim(txtnonew.Text) <> "" Then
                If LTrim(txtnonew.Text) = "" And ddlno.SelectedItem.Text = "---Vessel No---" Then
                    Exit Sub
                End If
                If (ddlname.SelectedItem.Text <> "---Marine Name---") Or (txtnamenew.Text <> "") Then
                    If txtvialoc.Text = "" Then
                        GoTo newsave
                    End If
                End If
            End If
            'If txtnonew.Text <> "" And ddlname.SelectedItem.Text <> "---Marine Name---" Then
            '    GoTo newsave
            'End If
            'If txtnonew.Text <> "" And txtnamenew.Text <> "" Then
            '    GoTo newsave
            'End If
            'insertintotable()
        ElseIf rblType.SelectedIndex = 2 Then
            If ddlname.SelectedItem.Text = "---Transport Name---" And txtnamenew.Text = "" Then
                msg("Please Select Valid Transport Name")
                Exit Sub
            End If
            If ddlno.SelectedItem.Text = "---Truck No---" And txtnonew.Text = "" Then
                msg("Please Select Valid Truck Number")
                Exit Sub
            End If
            startrouteno = "T"
            If LTrim(txtnonew.Text) <> "" Then
                If LTrim(txtnonew.Text) = "" And ddlno.SelectedItem.Text = "---Truck No---" Then
                    Exit Sub
                End If
                If (ddlname.SelectedItem.Text <> "---Transport Name---") Or (txtnamenew.Text <> "") Then
                    If txtvialoc.Text = "" Then
                        GoTo newsave
                    End If
                End If
            End If
            'If txtnonew.Text <> "" And ddlname.SelectedItem.Text <> "---Transport Name---" Then
            '    GoTo newsave
            'End If
            'If txtnonew.Text <> "" And txtnamenew.Text <> "" Then
            '    GoTo newsave
            'End If
            'insertintotable()
            'Ravi
        ElseIf rblType.SelectedIndex = 3 Then
            If ddlname.SelectedItem.Text = "---Courier Name---" And txtnamenew.Text = "" Then
                msg("Please Select Valid Courier Name")
                Exit Sub
            End If
            If ddlno.SelectedItem.Text = "---Ref No---" And txtnonew.Text = "" Then
                msg("Pleasae Select Valid Ref Number")
                Exit Sub
            End If
            startrouteno = "C"
            If LTrim(txtnonew.Text) <> "" Then
                If LTrim(txtnonew.Text) = "" And ddlno.SelectedItem.Text = "---Ref No---" Then
                    Exit Sub
                End If
                If (ddlname.SelectedItem.Text <> "---Courier Name---") Or (txtnamenew.Text <> "") Then
                    If txtvialoc.Text = "" Then
                        GoTo newsave
                    End If
                End If
            End If
        End If
        If txtnonew.Text = "" And txtnamenew.Text = "" Then
            If ddlname.SelectedIndex <> 0 And ddlname.SelectedIndex <> -1 And ddlno.SelectedIndex <> 0 And ddlno.SelectedIndex <> -1 Then
                Dim Str As String = "Select * from log_vehicleRegistration where TransportName = '" & ddlname.SelectedItem.Text.Trim & "' and vehicleno = '" & ddlno.SelectedItem.Text.Trim & "' and departPlace='" & txtfrom.Text.Trim & "' and ArrivalPlace='" & txtTo.Text.Trim & "'"
                If con.State = ConnectionState.Closed Then con.Open()
                Dim cmd As New SqlCommand(Str, con)
                Dim drcmd As SqlDataReader
                drcmd = cmd.ExecuteReader
                If drcmd.HasRows Then
                    drcmd.Close()
                    'Normal flow for Updating the row in the grid..
                Else
                    drcmd.Close()
                    GoTo newsave
                End If
            End If
        End If
        Try
            'To count the records
            Dim objTable As DataTable = Session("ObjectTable")
            Dim n, t As Integer
            n = objTable.Rows.Count
            Dim totCol As Integer
            Routecount = objTable.Rows.Count
        Catch ex As Exception
            'msg(ex.Message & " btnSubmit")
            Call routenogenerator()
            Call save()
            BindData()
            'AddDataIntoTable()
            Exit Sub
        End Try
        InsertintoTable()
        Exit Sub
newsave:
        'Call routenogenerator()
        'Call save()
        'BindData()
        Try
            AddDataIntoTable()
            InsertintoTable()
            msg(vehicleType.Trim & " Successfully Registered")
        Catch ex As Exception
            msg(ex.Message & "Please Provide Valid Informations")
        End Try
    End Sub

    Private Sub routenogenerator()
        If txtDescriptName.Text = "" Then
            msg("Enter the " & rblType.SelectedValue & " name")
        End If
        If txtfrom.Text = "" Or txtTo.Text = "" Then
            msg("Please Enter Valid Departure and Arrival Place")
            Exit Sub
        Else
            Dim ds1 As New DataSet

            Try
                ds1 = Getname("Select max(routeno) from log_VehicleRegistration where VehicleType='" & rblType.SelectedValue & "'")
                If Not ds1.Tables(0).Rows.Count = 0 Then
                    temp = ds1.Tables(0).Rows.Count
                    'oldrouteno = ds1.Tables(0).Rows(0).Item(0)
                    If IsDBNull(ds1.Tables(0).Rows(0).Item(0)) Then
                        oldrouteno = "A1001"
                    Else
                        oldrouteno = ds1.Tables(0).Rows(0).Item(0)
                    End If
                    temp = Val(Right(oldrouteno, 4)) + 1
                    newrouteno = startrouteno & temp
                End If
            Catch ex As Exception
                If ex.Message = "There is no row at position 0" Then
                    routeno = startrouteno & "1001"
                End If
            End Try
        End If
    End Sub
    Private Sub viarouteno()
        Dim ds1 As New DataSet
        Dim routeno, oldviarouteno, temp
        Try
            ds1 = Getname("Select max(Viarouteno) from log_ViaRouteMaster")
            If Not ds1.Tables(0).Rows.Count = 0 Then
                oldviarouteno = ds1.Tables(0).Rows(0).Item(0)
                newviarouteno = oldviarouteno + 1
            Else
                newviarouteno = 1
            End If
        Catch ex As Exception
            'If ex.Message = "There is no row at position 0" Then
            newviarouteno = 1
            'End If
        End Try
    End Sub
    Private Sub save()
        Call mynet.db_cn()
        Dim result
        Dim modifydate As DateTime
        Dim vehno, transname, vehname
        Dim departtime, arrivaltime
        If txtnonew.Text = "" Then
            vehno = ddlno.SelectedItem.Text
        Else
            vehno = txtnonew.Text
        End If
        If txtnamenew.Text = "" Then
            transname = ddlname.SelectedItem.Text
        Else
            transname = txtnamenew.Text
        End If
        Try
            If con.State = ConnectionState.Closed Then con.Open()
            departtime = ddlDepHour.SelectedItem.Text & ":" & ddlDepMin.SelectedItem.Text
            arrivaltime = ddlArrHour.SelectedItem.Text & ":" & ddlArrMin.SelectedItem.Text
            result = vehicleregistration("Insert" _
                                        , rblType.SelectedValue _
                                        , vehno _
                                        , transname _
                                        , txtDescriptName.Text _
                                        , txtfrom.Text _
                                        , departtime _
                                        , txtTo.Text _
                                        , arrivaltime _
                                        , newrouteno _
                                        , Session("empcode") _
                                        , Session("empcode") _
                                        , Now _
                                        , "" _
                                        , modifydate)
            'Call viarouteno()
            'If txtvialoc.Text = "" And viaclick = False Then

            QueryString = "insert into log_ViaRouteMaster (Routeno, ViaDepart,CreatedBy, CreatedDate) values ('" & newrouteno & "',' ', '" & LTrim(Session("empcode")) & "','" & Now & "')"
            com = New SqlClient.SqlCommand(QueryString, con)
            com.CommandText = QueryString
            com.ExecuteNonQuery()
            If con.State = ConnectionState.Open Then con.Close()
            'End If
        Catch ex As Exception
            msg(ex.Message & "Please Provide Valid Informations!")
        End Try
        mynet.db_close()
        If result Then
            msg("Registered Successfully. " & _
                       Microsoft.VisualBasic.vbNewLine & _
                       "Thank You.")
            cleartext()
        Else
            msg("Please Provide Valid Informations")
        End If
    End Sub

    Public Function vehicleregistration(ByVal lstrOperation As String _
                                            , ByVal lstrvehicletype As String _
                                            , ByVal lstrvehicleno As String _
                                            , ByVal lstrTransportName As String _
                                            , ByVal lstrVehicleName As String _
                                            , ByVal lstrDepartPlace As String _
                                            , ByVal lstrArrivalPlace As String _
                                            , ByVal ldtdeparttime As String _
                                            , ByVal ldtArrivalTime As String _
                                            , ByVal lstrRouteNo As String _
                                            , ByVal lstrU_id As String _
                                            , ByVal lstrCreatedby As String _
                                            , ByVal ldtCreatedDate As DateTime _
                                            , ByVal ldtModifiedBY As String _
                                            , ByVal ldtModifiedDate As DateTime _
                                            ) As Boolean


        'Set up Command Object along with Parameters
        Dim lCmdVehReg As New OleDb.OleDbCommand

        lCmdVehReg.Parameters.Clear()
        lCmdVehReg.CommandType = CommandType.StoredProcedure
        lCmdVehReg.CommandText = "SpVehicleRegistration"

        lCmdVehReg.Parameters.Add(MyBase.InputParaVarChar("@Operation", 50, lstrOperation))
        lCmdVehReg.Parameters.Add(MyBase.InputParaVarChar("@VehicleType", 15, lstrvehicletype))
        lCmdVehReg.Parameters.Add(MyBase.InputParaVarChar("@Vehicleno", 15, lstrvehicleno))
        lCmdVehReg.Parameters.Add(MyBase.InputParaVarChar("@TransportName", 50, lstrTransportName))
        lCmdVehReg.Parameters.Add(MyBase.InputParaVarChar("@VehicleName", 50, lstrVehicleName))
        lCmdVehReg.Parameters.Add(MyBase.InputParaVarChar("@DepartPlace", 50, lstrDepartPlace))
        lCmdVehReg.Parameters.Add(MyBase.InputParaVarChar("@ArrivalPlace", 50, lstrArrivalPlace))
        lCmdVehReg.Parameters.Add(MyBase.InputParaVarChar("@DepartTime", 15, ldtdeparttime))
        lCmdVehReg.Parameters.Add(MyBase.InputParaVarChar("@ArrivalTime", 15, ldtArrivalTime))
        lCmdVehReg.Parameters.Add(MyBase.InputParaVarChar("@Routeno", 15, lstrRouteNo))
        lCmdVehReg.Parameters.Add(MyBase.InputParaVarChar("@U_ID", 15, lstrU_id))
        lCmdVehReg.Parameters.Add(MyBase.InputParaVarChar("@CreatedBy", 50, lstrCreatedby))
        lCmdVehReg.Parameters.Add(MyBase.InputParaDateTime("@Createdtime", ldtCreatedDate))
        lCmdVehReg.Parameters.Add(MyBase.InputParaVarChar("@ModifiedBy", 50, ldtModifiedBY))
        lCmdVehReg.Parameters.Add(MyBase.InputParaDateTime("@ModifiedDate", ldtModifiedDate))
        'ServiceOrderType
        Dim lBoolenREc As Boolean = MyBase.SrsSingleTrans(lCmdVehReg)
        Return lBoolenREc
    End Function

    Private Sub ddlname_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ddlname.SelectedIndexChanged
        ddlno.Items.Clear()
        If con.State = ConnectionState.Closed Then con.Open()
        If vehicleType = "Flight" Then
            ddlno.Items.Insert(0, "---Flight No---")
        ElseIf vehicleType = "Vessel" Then
            ddlno.Items.Insert(0, "---Vessel No---")
        ElseIf vehicleType = "Truck" Then
            ddlno.Items.Insert(0, "---Truck No---")
        ElseIf vehicleType = "Courier" Then
            ddlno.Items.Insert(0, "---Ref No---")
        End If

        If ddlname.SelectedItem.Text = "---Courier No---" Or ddlname.SelectedItem.Text = "---Transport Name---" Or ddlname.SelectedItem.Text = "---Airways Name---" Or ddlname.SelectedItem.Text = "---Marine Name---" Or ddlname.SelectedItem.Text = "---Airways Name---" Then
            VehicleGrid.Visible = False
            Call cleartext()
            Exit Sub
        End If
        If ddlno.SelectedItem.Text = "---Ref No---" Or ddlno.SelectedItem.Text = "---Vehicle No---" Or ddlno.SelectedItem.Text = "---Flight No---" Or ddlno.SelectedItem.Text = "---Vessel No---" Or ddlno.SelectedItem.Text = "---Truck No---" Then
            VehicleGrid.Visible = False
        End If
        cleartext()
        If con.State = ConnectionState.Closed Then
            con.Open()
        End If
        Dim a1, a2 As String
        a1 = LTrim(ddlname.SelectedItem.Text.Trim)
        Dim cmd As New SqlCommand("spSelectVehicleByTransport", con)
        cmd.CommandType = CommandType.StoredProcedure
        Dim f1 As New SqlParameter("@TransName", SqlDbType.VarChar, 50)
        f1.Value = a1
        cmd.Parameters.Add(f1)
        datread2 = cmd.ExecuteReader()
        While (datread2.Read())
            ddlno.Items.Add(datread2(0))
        End While
        datread2.Close()
        If con.State = ConnectionState.Open Then con.Close()

        'ElseIf vehicleType = "Vessel" Then
        'ddlno.Items.Clear()
        'con.Open()
        'ddlno.Items.Insert(0, "---Vessel No---")
        'Dim a1, a2 As String
        'a1 = LTrim(ddlname.SelectedItem.Text.Trim)
        'Dim cmd As New SqlCommand("SM_vno", con)
        'cmd.CommandType = CommandType.StoredProcedure
        'Dim s1 As New SqlParameter("@mna", SqlDbType.VarChar, 50)
        's1.Value = a1
        'cmd.Parameters.Add(s1)
        'datread2 = cmd.ExecuteReader()
        'While (datread2.Read())
        '    ddlno.Items.Add(datread2(0))
        'End While
        'datread2.Close()
        'con.Close()

        'ElseIf vehicleType = "Truck" Then
        'ddlno.Items.Clear()
        'con.Open()
        'ddlno.Items.Insert(0, "---Truck No---")
        'Dim a1, a2 As String
        'a1 = LTrim(ddlname.SelectedItem.Text.Trim)
        'Dim cmd As New SqlCommand("Tm_tno ", con)
        'cmd.CommandType = CommandType.StoredProcedure
        'Dim f1 As New SqlParameter("@ana", SqlDbType.VarChar, 50)
        'f1.Value = a1
        'cmd.Parameters.Add(f1)
        'datread2 = cmd.ExecuteReader()
        'While (datread2.Read())
        '    ddlno.Items.Add(datread2(0))
        'End While
        'datread2.Close()
        'con.Close()
        'End If
    End Sub
    Private Sub cleartext()
        txtnamenew.Text = ""
        txtnonew.Text = ""
        txtDescriptName.Text = ""
        txtfrom.Text = ""
        txtTo.Text = ""
        Dim S As String
        Dim LenI As Integer
        Dim i As Integer
        ddlArrMin.Items.Clear()
        For i = 0 To 59
            Dim SS As String = i
            LenI = Len(ss)
            If LenI = 1 Then
                S = "0" & i
            ElseIf LenI = 2 Then
                S = i
            End If
            ddlArrMin.Items.Add(S)
        Next
        ddlArrHour.Items.Clear()
        For i = 0 To 23
            Dim SS As String = i
            LenI = Len(ss)
            If LenI = 1 Then
                S = "0" & i
            ElseIf LenI = 2 Then
                S = i
            End If
            ddlArrHour.Items.Add(S)
        Next
        ddlDepMin.Items.Clear()
        For i = 0 To 59
            Dim SS As String = i
            LenI = Len(ss)
            If LenI = 1 Then
                S = "0" & i
            ElseIf LenI = 2 Then
                S = i
            End If
            ddlDepMin.Items.Add(S)
        Next
        'Dep Hour
        ddlDepHour.Items.Clear()
        For i = 0 To 23
            Dim SS As String = i
            LenI = Len(ss)
            If LenI = 1 Then
                S = "0" & i
            ElseIf LenI = 2 Then
                S = i
            End If
            ddlDepHour.Items.Add(S)
        Next

        'Via Min
        ddlviaMin.Items.Clear()
        For i = 0 To 59
            Dim SS As String = i
            LenI = Len(ss)
            If LenI = 1 Then
                S = "0" & i
            ElseIf LenI = 2 Then
                S = i
            End If
            ddlviaMin.Items.Add(S)
        Next
        'Via Hour
        ddlviaHour.Items.Clear()
        For i = 0 To 23
            Dim SS As String = i
            LenI = Len(ss)
            If LenI = 1 Then
                S = "0" & i
            ElseIf LenI = 2 Then
                S = i
            End If
            ddlviaHour.Items.Add(S)
        Next
        'Via Dep Min
        ddlviaDMin.Items.Clear()
        For i = 0 To 59
            Dim SS As String = i
            LenI = Len(ss)
            If LenI = 1 Then
                S = "0" & i
            ElseIf LenI = 2 Then
                S = i
            End If
            ddlviaDMin.Items.Add(S)
        Next

        'Via Dep Hour
        ddlViaDHour.Items.Clear()
        For i = 0 To 23
            Dim SS As String = i
            LenI = Len(ss)
            If LenI = 1 Then
                S = "0" & i
            ElseIf LenI = 2 Then
                S = i
            End If
            ddlViaDHour.Items.Add(S)
        Next

        'ddlArrHour.SelectedItem.Text = "01"
        'ddlArrMin.SelectedItem.Text = "00"
        'ddlDepHour.SelectedItem.Text = "01"
        'ddlDepMin.SelectedItem.Text = "00"
        txtvialoc.Text = ""
        'ddlviaHour.SelectedItem.Text = "01"
        'ddlviaMin.SelectedItem.Text = "00"
        'ddlViaDHour.SelectedItem.Text = "01"
        'ddlviaDMin.SelectedItem.Text = "00"
        txtfrom.Enabled = True
        txtTo.Enabled = True
        VehicleGrid.Visible = False
        'If con.State = ConnectionState.Open Then con.Close()
    End Sub
    Public Sub clearall()
        'Clear the values of the Controls
        ddlname.Items.Clear()
        ddlno.Items.Clear()
        txtnamenew.Text = ""
        txtnonew.Text = ""
        txtDescriptName.Text = ""
        txtfrom.Text = ""
        txtTo.Text = ""

        Dim S As String
        Dim LenI As Integer
        Dim i As Integer
        ddlArrMin.Items.Clear()
        For i = 0 To 59
            Dim SS As String = i
            LenI = Len(ss)
            If LenI = 1 Then
                S = "0" & i
            ElseIf LenI = 2 Then
                S = i
            End If
            ddlArrMin.Items.Add(S)
        Next
        ddlArrHour.Items.Clear()
        For i = 0 To 23
            Dim SS As String = i
            LenI = Len(ss)
            If LenI = 1 Then
                S = "0" & i
            ElseIf LenI = 2 Then
                S = i
            End If
            ddlArrHour.Items.Add(S)
        Next
        ddlDepMin.Items.Clear()
        For i = 0 To 59
            Dim SS As String = i
            LenI = Len(ss)
            If LenI = 1 Then
                S = "0" & i
            ElseIf LenI = 2 Then
                S = i
            End If
            ddlDepMin.Items.Add(S)
        Next
        'Dep Hour
        ddlDepHour.Items.Clear()
        For i = 0 To 23
            Dim SS As String = i
            LenI = Len(ss)
            If LenI = 1 Then
                S = "0" & i
            ElseIf LenI = 2 Then
                S = i
            End If
            ddlDepHour.Items.Add(S)
        Next

        'Via Min
        ddlviaMin.Items.Clear()
        For i = 0 To 59
            Dim SS As String = i
            LenI = Len(ss)
            If LenI = 1 Then
                S = "0" & i
            ElseIf LenI = 2 Then
                S = i
            End If
            ddlviaMin.Items.Add(S)
        Next
        'Via Hour
        ddlviaHour.Items.Clear()
        For i = 0 To 23
            Dim SS As String = i
            LenI = Len(ss)
            If LenI = 1 Then
                S = "0" & i
            ElseIf LenI = 2 Then
                S = i
            End If
            ddlviaHour.Items.Add(S)
        Next
        'Via Dep Min
        ddlviaDMin.Items.Clear()
        For i = 0 To 59
            Dim SS As String = i
            LenI = Len(ss)
            If LenI = 1 Then
                S = "0" & i
            ElseIf LenI = 2 Then
                S = i
            End If
            ddlviaDMin.Items.Add(S)
        Next

        'Via Dep Hour
        ddlViaDHour.Items.Clear()
        For i = 0 To 23
            Dim SS As String = i
            LenI = Len(ss)
            If LenI = 1 Then
                S = "0" & i
            ElseIf LenI = 2 Then
                S = i
            End If
            ddlViaDHour.Items.Add(S)
        Next
        '------------

        'ddlArrHour.SelectedItem.Text = "01"
        'ddlArrMin.SelectedItem.Text = "00"
        'ddlDepHour.SelectedItem.Text = "01"
        'ddlDepMin.SelectedItem.Text = "00"
        txtvialoc.Text = ""
        'ddlviaHour.SelectedItem.Text = "01"
        'ddlviaMin.SelectedItem.Text = "00"
        'ddlViaDHour.SelectedItem.Text = "01"
        'ddlviaDMin.SelectedItem.Text = "00"
        txtfrom.Enabled = True
        txtTo.Enabled = True
        ddlname.Items.Clear()
        ddlname.Items.Insert(0, "---Transport Name---")
        ddlno.Items.Clear()
        ddlno.Items.Insert(0, "---Vehicle No---")
        VehicleGrid.Visible = False
        'If con.State = ConnectionState.Open Then con.Close()
        'rblType.SelectedIndex = -1
        'BindDate()
    End Sub


    Private Sub rblType_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles rblType.SelectedIndexChanged

        If rblType.SelectedIndex = 0 Then
            Call clearall()
            lblname.Text = "Airways Name"
            lblnamenew.Text = "New Airways Name"
            lblno.Text = "Flight Number"
            lblnonew.Text = "New Flight Number"
            lbldescriptname.Text = "Flight Name"
            vehicleType = "Flight"
            'If Not (Page.IsPostBack) Then
            ddlname.Items.Clear()
            ddlname.Items.Insert(0, "---Airways Name---")
            ddlno.Items.Clear()
            ddlno.Items.Insert(0, "---Flight No---")
            'End If

        ElseIf rblType.SelectedIndex = 1 Then
            clearall()
            lblname.Text = "Marine Name"
            lblnamenew.Text = "New Marine Name"
            lblno.Text = "Vessel Number"
            lblnonew.Text = "New Voyage Number"
            lbldescriptname.Text = "Vessel Name"
            vehicleType = "Vessel"
            'If (Page.IsPostBack = False) Then
            ddlname.Items.Clear()
            ddlname.Items.Insert(0, "---Marine Name---")
            ddlno.Items.Clear()
            ddlno.Items.Insert(0, "---Vessel No---")

        ElseIf rblType.SelectedIndex = 2 Then
            clearall()
            lblname.Text = "Transport Name"
            lblnamenew.Text = "New Transport Name"
            lblno.Text = "Truck Number"
            lblnonew.Text = "New Truck Number"
            lbldescriptname.Text = "Truck Name"
            vehicleType = "Truck"
            'If (Page.IsPostBack = False) Then
            ddlname.Items.Clear()
            ddlname.Items.Insert(0, "---Transport Name---")
            ddlno.Items.Clear()
            ddlno.Items.Insert(0, "---Truck No---")


        ElseIf rblType.SelectedIndex = 3 Then
            clearall()
            lblname.Text = "Courier Name"
            lblnamenew.Text = "New Courier Name"
            lblno.Text = "Courier Ref Number"
            lblnonew.Text = "New Courier Ref Number"
            lbldescriptname.Text = "Full Name"
            vehicleType = "Courier"
            'If (Page.IsPostBack = False) Then
            ddlname.Items.Clear()
            ddlname.Items.Insert(0, "---Courier Name---")
            ddlno.Items.Clear()
            ddlno.Items.Insert(0, "---Ref No---")

        End If
        If con.State = ConnectionState.Closed Then con.Open()
        Dim a1 As String
        a1 = rblType.SelectedValue
        Dim cmd As New SqlCommand("SpSelectTransName", con)
        cmd.CommandType = CommandType.StoredProcedure
        Dim f2 As New SqlParameter("@VType", SqlDbType.VarChar, 20)
        f2.Value = a1
        cmd.Parameters.Add(f2)
        datread = cmd.ExecuteReader
        Do While datread.Read
            ddlname.Items.Add(datread("Transportname"))
        Loop
        datread.Close()
        BindData()
        If con.State = ConnectionState.Open Then con.Close()

        '    con.Open()
        '    com = New SqlClient.SqlCommand("SM_mna", con)
        '    com.CommandType = CommandType.StoredProcedure
        '    datread = com.ExecuteReader
        '    Do While datread.Read
        '        ddlname.Items.Add(datread("marinename"))
        '    Loop
        '    con.Close()
        '    'BindDate()
        '    'End If

        'ElseIf rblType.SelectedIndex = 2 Then
        '    clearall()
        '    lblname.Text = "Truck Name"
        '    vehicleType = "Truck"
        '    'If (Page.IsPostBack = False) Then
        '    ddlname.Items.Clear()
        '    ddlname.Items.Insert(0, "---Transport Name---")
        '    ddlno.Items.Clear()
        '    ddlno.Items.Insert(0, "---Truck No---")
        '    con.Open()
        '    com = New SqlCommand("Tm_truckna", con)
        '    com.CommandType = CommandType.StoredProcedure
        '    datread = com.ExecuteReader
        '    Do While datread.Read
        '        ddlname.Items.Add(datread("Transportname"))
        '    Loop
        '    con.Close()
        '    'BindDate()
        '    'End If
        'End If
    End Sub

    Private Sub ddlno_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ddlno.SelectedIndexChanged
        viaclick = False
        If ddlno.SelectedItem.Text = "---Vehicle No---" Or ddlno.SelectedItem.Text = "---Flight No---" Or ddlno.SelectedItem.Text = "---Truck No---" Or ddlno.SelectedItem.Text = "---Vessel No---" Or ddlno.SelectedItem.Text = "---Ref No---" Then
            Call cleartext()
            VehicleGrid.Visible = False
            Exit Sub
        End If
        Dim arrtime, depttime
        Dim s() As String
        If con.State = ConnectionState.Closed Then con.Open()
        Dim a1 As String
        a1 = LTrim(ddlno.SelectedItem.Text.Trim)
        cleartext()
        Dim cmd As New SqlCommand("SpSelectVehicleno", con)
        cmd.CommandType = CommandType.StoredProcedure
        Dim f2 As New SqlParameter("@fno", SqlDbType.VarChar, 20)
        f2.Value = a1
        cmd.Parameters.Add(f2)
        datread = cmd.ExecuteReader()
        While (datread.Read())
            'txtnamenew.Text = datread(1)
            txtDescriptName.Text = datread(2)
            txtfrom.Text = datread(3)
            txtTo.Text = datread(4)
            depttime = datread(5)
            s = Split(depttime, ":")
            ddlDepHour.SelectedItem.Text = s(0)
            ddlDepMin.SelectedItem.Text = s(1)
            arrtime = datread(6)
            s = Split(arrtime, ":")
            ddlArrHour.SelectedItem.Text = s(0)
            ddlArrMin.SelectedItem.Text = s(1)
            'txtvialoc.Text = datread(7)
            VehicleGrid.Visible = True
        End While
        datread.Close()
        BindData()
        'AddDataIntoTable()


        'txtfrom.Enabled = False
        'txtTo.Enabled = False
        If con.State = ConnectionState.Open Then con.Close()
        'AddDataIntoTable()
    End Sub

    Private Sub btnAddVia_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAddVia.Click
        viaclick = True
        'BindData()
        Try
            AddDataIntoTable()
        Catch ex As Exception
            msg(ex.Message)
        End Try

    End Sub

    'Private Sub lbtnSignout_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lbtnSignout.Click
    '    'Logging out
    '    Call mynet.ChkLastLogin(Session("userID"))
    '    FormsAuthentication.RedirectFromLoginPage(Session("userID"), True)
    '    Response.Redirect("../logout.aspx")
    'End Sub

    'Private Sub lbtnBack_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lbtnBack.Click
    '    FormsAuthentication.RedirectFromLoginPage(Session("userID"), True)
    '    Response.Redirect("../logsticsMain.aspx")
    'End Sub

    Private Sub BindData()
        'Code for Binding the Grid
        If con.State = ConnectionState.Closed Then
            con.Open()
        End If
        If txtnonew.Text = "" Then
            QueryString = "select a.VehicleNo, a.TransportName, a.VehicleName, a.Departplace, a.Arrivalplace, a.DepartTime, a.ArrivalTime, b.ViaDepart as 'ViaRoute', b.ArrivalTime as 'ViaArrTime', b.DepartTime as 'ViaDeptTime' from log_VehicleRegistration a, Log_ViaRouteMaster b where a.vehicleno=ltrim('" & ddlno.SelectedItem.Text.Trim & "') and a.Routeno=b.RouteNo and a.DeletedStatus=0"
            objDataSet = New DataSet
            objDataAdapter = New SqlClient.SqlDataAdapter(QueryString, con)
        Else
            QueryString = "select a.VehicleNo, a.TransportName, a.VehicleName, a.Departplace, a.Arrivalplace, a.DepartTime, a.ArrivalTime, b.ViaDepart as 'ViaRoute', b.ArrivalTime as 'ViaArrTime', b.DepartTime as 'ViaDeptTime' from log_VehicleRegistration a, Log_ViaRouteMaster b where a.vehicleno=ltrim('" & txtnonew.Text.Trim & "') and a.Routeno=b.RouteNo and a.DeletedStatus=0"
            objDataSet = New DataSet
            objDataAdapter = New SqlClient.SqlDataAdapter(QueryString, con)
        End If
        Try
            objDataAdapter.Fill(objDataSet, "Log_VehicleRegistration")
        Catch ex As Exception
            Response.Write("Exception " & ex.Message)
        End Try
        objDataSet.AcceptChanges()
        'msg(objDataSet.Tables(0).Rows.Count)
        Dim objTable As DataTable = objDataSet.Tables("Log_VehicleRegistration")
        Session("ObjectTable") = objTable
        GetUpdateSession()
        If con.State = ConnectionState.Open Then con.Close()
    End Sub

    Sub AddDataIntoTable()
        'Insert the values into the grid dynamically
        Dim a, b, c As String
        If txtnonew.Text = "" Then
            a = LTrim(ddlno.SelectedItem.Text.Trim)
            txtfrom.Enabled = False
            txtTo.Enabled = False
        Else
            txtfrom.Enabled = True
            txtTo.Enabled = True
            a = LTrim(txtnonew.Text.Trim)
        End If
        If txtnamenew.Text = "" Then
            b = ddlname.SelectedItem.Text
        Else
            b = LTrim(txtnamenew.Text.Trim)
        End If
        c = LTrim(txtvialoc.Text.Trim)
        Try
            Dim sflag As Boolean
            If Not con.State = con.State.Open Then
                con.Open()
            End If

            'Checking the via location with Arrival and Departure Place
            If c = txtfrom.Text Or c = txtTo.Text Then
                msg("Please Enter Valid VIA ")
                txtvialoc.Text = ""
                Exit Sub
            End If


            'Checking the Record already exist in the grid or not
            Dim noOfPosition = IsAlreadyExists(a)
            Dim objTable As DataTable = Session("ObjectTable")

            If noOfPosition = -1 Then
                'Assigning the values to the cells dynamically
                Dim objValArray(9) As Object
                objValArray(0) = a    ' Vehicle No.
                objValArray(1) = b    ' Transport Name
                objValArray(2) = txtDescriptName.Text
                objValArray(3) = txtfrom.Text
                objValArray(4) = txtTo.Text
                objValArray(5) = ddlDepHour.SelectedItem.Text & ":" & ddlDepMin.SelectedItem.Text
                objValArray(6) = ddlArrHour.SelectedItem.Text & ":" & ddlArrMin.SelectedItem.Text
                objValArray(7) = txtvialoc.Text
                objValArray(8) = ddlviaHour.SelectedItem.Text & ":" & ddlviaMin.SelectedItem.Text
                objValArray(9) = ddlViaDHour.SelectedItem.Text & ":" & ddlviaDMin.SelectedItem.Text
                objTable.Rows.Add(objValArray)
            Else
                If objTable.Rows(0)(3) <> txtfrom.Text.Trim Or objTable.Rows(0)(4) <> txtTo.Text.Trim Then
                    GoTo NewRoute
                End If
                If objTable.Rows(0)(7) = "" Or objTable.Rows(0)(7) = " " Then
                    Dim objvalarray(9) As Object
                    objTable.Rows(noOfPosition)(7) = txtvialoc.Text
                    objTable.Rows(noOfPosition)(8) = ddlviaHour.SelectedItem.Text & ":" & ddlviaMin.SelectedItem.Text
                    objTable.Rows(noOfPosition)(9) = ddlViaDHour.SelectedItem.Text & ":" & ddlviaDMin.SelectedItem.Text
                Else
                    'Checking whether the vialocation is already exist or not
                    Dim i
                    For i = 0 To objTable.Rows.Count - 1
                        If objTable.Rows(i)(0) = a Then
                            If InStr(1, objTable.Rows(i)(7), c.Trim, CompareMethod.Text) <> 0 Then
                                msg("VIA Already Exists!")
                                txtvialoc.Text = ""
                                Exit Sub
                            End If
                        End If
                    Next
NewRoute:
                    'Assigning the values to the cells dynamically
                    Dim objValArray(9) As Object
                    objValArray(0) = a    ' Vehicle No.
                    objValArray(1) = b    ' Transport Name
                    objValArray(2) = txtDescriptName.Text
                    objValArray(3) = txtfrom.Text
                    objValArray(4) = txtTo.Text
                    objValArray(5) = ddlDepHour.SelectedItem.Text & ":" & ddlDepMin.SelectedItem.Text
                    objValArray(6) = ddlArrHour.SelectedItem.Text & ":" & ddlArrMin.SelectedItem.Text
                    objValArray(7) = txtvialoc.Text
                    objValArray(8) = ddlviaHour.SelectedItem.Text & ":" & ddlviaMin.SelectedItem.Text
                    objValArray(9) = ddlViaDHour.SelectedItem.Text & ":" & ddlviaDMin.SelectedItem.Text
                    objTable.Rows.Add(objValArray)
                End If
            End If
            Session("ObjectTable") = objTable
            VehicleGrid.EditItemIndex = -1
            GetUpdateSession()

            If con.State = ConnectionState.Open Then con.Close()
        Catch ex As Exception
            msg(ex.Message)
        End Try
    End Sub

    Function IsAlreadyExists(ByVal VehicleNo)
        Dim objTable As DataTable = Session("ObjectTable")
        Dim n As Integer
        n = objTable.Rows.Count
        Dim totCol As Integer
        For i As Integer = 0 To n - 1
            If objTable.Rows(i)(0) = VehicleNo Then
                Return i
            End If
        Next
        Return -1
    End Function

    Sub GetUpdateSession()
        Try
            Dim objTable As DataTable = Session("ObjectTable")
            VehicleGrid.DataSource = objTable.DefaultView
            VehicleGrid.DataBind()
        Catch ex As Exception

        End Try
    End Sub

    Sub DoItemEdit(ByVal objSource As Object, ByVal objArgs As DataGridCommandEventArgs)
        'Datagrid Edit
        Response.Write("Edit")
        VehicleGrid.EditItemIndex = objArgs.Item.ItemIndex
        'VehicleGrid.EditItemIndex = objArgs.Item.ItemIndex
        GetUpdateSession()
    End Sub

    Sub DeleteItem(ByVal objArgs As DataGridCommandEventArgs)
        'Datagrid delete
        Dim objTable As DataTable = Session("ObjectTable")
        Dim vno, dept, arr, via, viaroutedel, rno
        vno = objTable.Rows(objArgs.Item.ItemIndex)(0)
        dept = objTable.Rows(objArgs.Item.ItemIndex)(3)
        arr = objTable.Rows(objArgs.Item.ItemIndex)(4)
        via = objTable.Rows(objArgs.Item.ItemIndex)(7)

        ''''
        If con1.State = ConnectionState.Closed Then con1.Open()
        'QueryString = "select * from log_ViaRouteMaster where Routeno='" & routeno & "' and ViaDepart='" & pViaDepart & "'"
        QueryString = "select a.Routeno, b.Viarouteno, a.VehicleNo, a.TransportName, a.VehicleName, a.Departplace, a.Arrivalplace, a.DepartTime, a.ArrivalTime, b.ViaDepart as 'ViaRoute', b.ArrivalTime as 'ViaArrTime', b.DepartTime as 'ViaDeptTime' from log_VehicleRegistration a, Log_ViaRouteMaster b where a.Routeno=b.RouteNo and a.vehicleno='" & vno & "' and a.departplace='" & dept & "' and a.ArrivalPlace='" & arr & "' and a.DeletedStatus=0"
        objDataSet = New DataSet
        objDataAdapter = New SqlClient.SqlDataAdapter(QueryString, con1)
        objDataAdapter.Fill(objDataSet, "log_ViaRouteMaster")
        rno = objDataSet.Tables(0).Rows(0).Item(0)
        viaroutedel = objDataSet.Tables(0).Rows(0).Item(1)
        If objDataSet.Tables(0).Rows.Count = 1 Then
            GoTo y
        ElseIf objDataSet.Tables(0).Rows.Count > 1 Then
            GoTo x
        End If
        '''''
x:
        If con.State = ConnectionState.Closed Then con.Open()
        com = New SqlClient.SqlCommand(QueryString, con)
        'QueryString = "delete from log_viaRoutemaster where Viarouteno='" & viaroutedel & "'"
        QueryString = "Update log_viaRoutemaster set DeletedStatus=1 where Viarouteno='" & viaroutedel & "'"
        com.CommandText = QueryString
        com.ExecuteNonQuery()
        If con.State = ConnectionState.Open Then con.Close()
        GoTo last
y:
        If con.State = ConnectionState.Closed Then con.Open()
        com = New SqlClient.SqlCommand(QueryString, con)
        'QueryString = "delete from log_viaRoutemaster where Viarouteno='" & viaroutedel & "'"
        QueryString = "Update log_viaRoutemaster set DeletedStatus=1 where Viarouteno='" & viaroutedel & "'"
        com.CommandText = QueryString
        com.ExecuteNonQuery()
        'QueryString = "delete from log_VehicleRegistration where routeno='" & rno & "'"
        QueryString = "Update log_VehicleRegistration set DeletedStatus=1 where routeno='" & rno & "'"
        com.CommandText = QueryString
        com.ExecuteNonQuery()
        If con.State = ConnectionState.Open Then con.Close()
        Call clearall()
        rblType.SelectedIndex = -1
        msg("All the Routes for " & vehicleType & vno & " are deleted")
        ddlno.SelectedIndex = 0
        'ddlno.Items.Clear()
        'ddlno.Items.Add("---Vehicle No---")
        GoTo last
last:
        If con1.State = ConnectionState.Open Then con1.Close()
        objTable.Rows.RemoveAt(objArgs.Item.ItemIndex)
        Session("ObjectTable") = objTable
        GetUpdateSession()
    End Sub

    Sub DoItemUpdate(ByVal objSource As Object, ByVal objArgs As DataGridCommandEventArgs)
        'Datagrid Update
        Try
            Dim objTable As DataTable = Session("ObjectTable")
            Dim objTextBox As TextBox
            Dim n As Integer = objTable.Columns.Count
            'objTextBox = objArgs.Item.Cells(2).Controls(0) 'cell count starts from 0
            'objTable.Rows(objA     rgs.Item.ItemIndex)("VehicleNo") = objTextBox.Text
            'objTextBox = objArgs.Item.Cells(3).Controls(0)
            'objTable.Rows(objArgs.Item.ItemIndex)("TransportName") = objTextBox.Text
            objTextBox = objArgs.Item.Cells(4).Controls(0)
            objTable.Rows(objArgs.Item.ItemIndex)("VehicleName") = objTextBox.Text
            'objTextBox = objArgs.Item.Cells(5).Controls(0)
            'objTable.Rows(objArgs.Item.ItemIndex)("Departplace") = objTextBox.Text
            'objTextBox = objArgs.Item.Cells(6).Controls(0)
            'objTable.Rows(objArgs.Item.ItemIndex)("ArrivalPlace") = objTextBox.Text
            objTextBox = objArgs.Item.Cells(7).Controls(0)
            objTable.Rows(objArgs.Item.ItemIndex)("Departtime") = objTextBox.Text
            objTextBox = objArgs.Item.Cells(8).Controls(0)
            objTable.Rows(objArgs.Item.ItemIndex)("ArrivalTime") = objTextBox.Text
            'objTextBox = objArgs.Item.Cells(9).Controls(0)
            'objTable.Rows(objArgs.Item.ItemIndex)("ViaRoute") = objTextBox.Text
            objTextBox = objArgs.Item.Cells(10).Controls(0)
            objTable.Rows(objArgs.Item.ItemIndex)("ViaArrTime") = objTextBox.Text
            objTextBox = objArgs.Item.Cells(11).Controls(0)
            objTable.Rows(objArgs.Item.ItemIndex)("ViaDeptTime") = objTextBox.Text
            Session("ObjectTable") = objTable
            VehicleGrid.EditItemIndex = -1
        Catch ex As Exception

        End Try

        GetUpdateSession()
    End Sub
    Sub DoItemCancel(ByVal objSource As Object, ByVal objArgs As DataGridCommandEventArgs)
        'Datagrid Cancel
        Response.Write("Cancel")
        VehicleGrid.EditItemIndex = -1
        GetUpdateSession()
    End Sub
    Private Sub VehicleGrid_ItemCommand(ByVal source As Object, ByVal e As System.Web.UI.WebControls.DataGridCommandEventArgs) Handles VehicleGrid.ItemCommand
        Try
            Select Case (CType(e.CommandSource, LinkButton)).CommandName
                Case "Delete"
                    DeleteItem(e)
                Case "Edit"
                    DoItemEdit(source, e)
                Case "Update"
                    DoItemUpdate(source, e)
                Case "Cancel"
                    DoItemCancel(source, e)
            End Select
        Catch ex As Exception

        End Try
    End Sub

    Sub InsertintoTable()
        If con.State = ConnectionState.Closed Then con.Open()
        Try
            Dim objTable As DataTable = Session("ObjectTable")
            Dim recinsert As Boolean
            Dim n, i As Integer
            n = objTable.Rows.Count
            Dim totCol As Integer
            Routecount = objTable.Rows.Count

            For i = 0 To n - 1
                UpdateTable(objTable.Rows(i)(0), objTable.Rows(i)(1), objTable.Rows(i)(2), objTable.Rows(i)(3), objTable.Rows(i)(4), objTable.Rows(i)(5), objTable.Rows(i)(6), objTable.Rows(i)(7), objTable.Rows(i)(8), objTable.Rows(i)(9))
                'If objTable.Rows(i)(7) = txtvialoc.Text And objTable.Rows(i)(0) = ddlno.SelectedItem.Text Then
                '    recinsert = False
                '    GoTo update
                'Else
                '    recinsert = True
                'End If
            Next i
            'insert:
            '            If recinsert Then
            '                InsertTable(objTable.Rows(i)(0), objTable.Rows(i)(1), objTable.Rows(i)(2), objTable.Rows(i)(3), objTable.Rows(i)(4), objTable.Rows(i)(5), objTable.Rows(i)(6), objTable.Rows(i)(7), objTable.Rows(i)(8), objTable.Rows(i)(9))
            '                GoTo x
            '            End If

            'update:
            'UpdateTable(objTable.Rows(i)(0), objTable.Rows(i)(1), objTable.Rows(i)(2), objTable.Rows(i)(3), objTable.Rows(i)(4), objTable.Rows(i)(5), objTable.Rows(i)(6), objTable.Rows(i)(7), objTable.Rows(i)(8), objTable.Rows(i)(9))
x:
            If recinsertstatus Then

                'msg(vehicleType.Trim & " Registered Successfully")
            Else
                msg("Please Provide Valid Informations")
            End If
            If con.State = ConnectionState.Open Then con.Close()
            GetUpdateSession()
        Catch ex As Exception
            'InsertTable(objTable.Rows(i)(0), objTable.Rows(i)(1), objTable.Rows(i)(2), objTable.Rows(i)(3), objTable.Rows(i)(4), objTable.Rows(i)(5), objTable.Rows(i)(6), objTable.Rows(i)(7), objTable.Rows(i)(8), objTable.Rows(i)(9))
        End Try
    End Sub

    Sub InsertTable(ByVal pddlno, ByVal ptransname, ByVal pvehiclename, ByVal ptxtfrom, ByVal ptxtto, ByVal pdepttime, ByVal pArrTime, ByVal pViaDepart, ByVal pViaArrTime, ByVal pViaDeptTime)
        'Insert into the Table
        Dim query1, query2 As String
        Dim PrimaryQuery As String
        Dim vno, dep, arr, routeno As String
        Dim dr As SqlClient.SqlDataReader
        PrimaryQuery = "select a.VehicleNo, a.TransportName, a.VehicleName, a.Departplace, a.Arrivalplace, a.DepartTime, a.ArrivalTime, a.RouteNo from log_VehicleRegistration a where a.vehicleno='" & pddlno & "' and a.departplace='" & ptxtfrom & "' and a.ArrivalPlace='" & ptxtto & "' and a.DeletedStatus=0"
        com = New SqlClient.SqlCommand(PrimaryQuery, con)
        dr = com.ExecuteReader
        While dr.Read
            vno = LTrim(ddlno.SelectedItem.Text.Trim)
            dep = LTrim(txtfrom.Text.Trim)
            arr = LTrim(txtTo.Text.Trim)
            routeno = LTrim(dr.Item(7))
        End While
        If dr.HasRows Then
            If pddlno = vno Then
                If ptxtfrom = dep And ptxtto = arr Then
                    query1 = "Update Log_VehicleRegistration set TransportName='" & LTrim(ptransname) & "', VehicleName='" & LTrim(pvehiclename) & "', DepartPlace='" & LTrim(ptxtfrom) & "', Arrivalplace='" & LTrim(ptxtto) & "', DepartTime='" & LTrim(pdepttime) & "', ArrivalTime='" & LTrim(pArrTime) & "', u_id=ltrim('" & Session("empcode") & "'), modifiedby=ltrim('" & Session("empcode") & "'),modifieddate='" & Now & "'where VehicleNo='" & vno & " ' and DepartPlace='" & dep & "' and ArrivalPlace='" & arr & "'"
                    'dr.Close()
                    'Dim i
                    'For i = 0 To Routecount - 1
                    'If Routecount > 1 Then
                    'Call viarouteno()
                    query2 = "insert into Log_ViaRouteMaster values ('" & routeno & "','" & LTrim(pViaDepart) & "','" & LTrim(pViaArrTime) & "','" & LTrim(pViaDeptTime) & "','" & LTrim(Session("empcode")) & "','" & Now & "', 0)"
                    'com.CommandText = query2
                    'com.ExecuteNonQuery()

                    'ElseIf Routecount = 1 Then
                    'query2 = "Update Log_ViaRouteMaster set ViaRouteno='" & newrouteno & "', RouteNo='" & routeno & "', ViaDepart=ltrim('" & pViaDepart & "'), ArrivalTime=ltrim('" & pViaArrTime & "'), DepartTime=ltrim('" & pViaDeptTime & "'), CreatedBy=ltrim('" & Session("userid") & "'), createdDate='" & Now & "' where routeno='" & newrouteno & "' and viaDepart=ltrim('" & pViaDepart & "')"
                    'com.CommandText = query2
                    'com.ExecuteNonQuery()
                    'End If
                    'Next
                Else
                    GoTo newroute
                    'query1 = "insert into Log_fvesselschedule values (" & "ltrim('" & pddlf_id & "'),ltrim('" & pddlmana & "'),ltrim('" & pddlvno & "'),ltrim('" & pddlfrom & "'),ltrim('" & pddlto & "'),'" & date2 & "','" & date3 & "',ltrim('" & st6.Trim & "'),ltrim('" & st6.Trim & "'),'" & date1 & "',null,null)"
                    'msg("Ship Scheduled Successfully")
                End If
                GoTo newroute
            End If
        Else
newroute:
            Call routenogenerator()
            query1 = "insert into Log_VehicleRegistration (TransportNameVehicleName,DepartPlace,Arrivalplace,DepartTime, ArrivalTime,RouteNo, u_id, Createdby, CreatedDate ) values ('" & LTrim(ptransname) & "', '" & LTrim(pvehiclename) & "', '" & LTrim(ptxtfrom) & "', '" & LTrim(ptxtto) & "', '" & LTrim(pdepttime) & "', '" & LTrim(pArrTime) & "', newrouteno, ltrim('" & Session("empcode") & "'), ltrim('" & Session("empcode") & "'),'" & Now & "'"
            'Call viarouteno()
            query2 = "insert into Log_ViaRouteMaster values ('" & routeno & "','" & LTrim(pViaDepart) & "','" & LTrim(pViaArrTime) & "','" & LTrim(pViaDeptTime) & "','" & LTrim(Session("empcode")) & "','" & Now & "', 0)"
        End If
        dr.Close()
        Try
            recinsertstatus = True
            com.CommandText = query1
            com.ExecuteNonQuery()
            com.CommandText = query2
            com.ExecuteNonQuery()
        Catch ex As Exception
            recinsertstatus = False
            msg(ex.Message)
        End Try
        'dr.Close()
    End Sub

    Sub UpdateTable(ByVal pddlno, ByVal ptransname, ByVal pvehiclename, ByVal ptxtfrom, ByVal ptxtto, ByVal pdepttime, ByVal pArrTime, ByVal pViaDepart, ByVal pViaArrTime, ByVal pViaDeptTime)
        'Insert into the Table
        Dim query1, query2 As String
        Dim PrimaryQuery As String
        Dim vno, dep, arr, routeno As String
        Dim dr As SqlClient.SqlDataReader
        Try
            If con.State = ConnectionState.Closed Then con.Open()
            PrimaryQuery = "select a.VehicleNo, a.TransportName, a.VehicleName, a.Departplace, a.Arrivalplace, a.DepartTime, a.ArrivalTime, a.RouteNo from log_VehicleRegistration a where a.vehicleno='" & pddlno & "' and a.departplace='" & ptxtfrom & "' and a.ArrivalPlace='" & ptxtto & "' and a.DeletedStatus=0"
            com = New SqlClient.SqlCommand(PrimaryQuery, con)
            dr = com.ExecuteReader
            While dr.Read
                vno = pddlno 'LTrim(ddlno.SelectedItem.Text.Trim)
                dep = ptxtfrom 'LTrim(txtfrom.Text.Trim)
                arr = ptxtto 'LTrim(txtTo.Text.Trim)
                routeno = LTrim(dr.Item(7))
            End While
            If dr.HasRows Then
                If pddlno = vno Then
                    If ptxtfrom = dep And ptxtto = arr Then
                        query1 = "Update Log_VehicleRegistration set TransportName='" & LTrim(ptransname) & "', VehicleName='" & LTrim(pvehiclename) & "', DepartPlace='" & LTrim(ptxtfrom) & "', Arrivalplace='" & LTrim(ptxtto) & "', DepartTime='" & LTrim(pdepttime) & "', ArrivalTime='" & LTrim(pArrTime) & "', u_id=ltrim('" & Session("empcode") & "'), modifiedby=ltrim('" & Session("empcode") & "'),modifieddate='" & Now & "' where VehicleNo='" & vno & " ' and DepartPlace='" & dep & "' and ArrivalPlace='" & arr & "'"

                        '''''''''''''
                        con1.Open()

                        Dim querystr As String
                        querystr = "select * from log_ViaRouteMaster where Routeno='" & routeno & "' and ViaDepart=' ' and DeletedStatus=0"
                        objDataSet = New DataSet
                        objDataAdapter = New SqlClient.SqlDataAdapter(querystr, con1)
                        objDataAdapter.Fill(objDataSet, "log_ViaRouteMaster")
                        If objDataSet.Tables(0).Rows.Count = 1 Then
                            query2 = "Update Log_ViaRouteMaster set RouteNo='" & routeno & "', ViaDepart=ltrim('" & pViaDepart & "'), ArrivalTime=ltrim('" & pViaArrTime & "'), DepartTime=ltrim('" & pViaDeptTime & "'), CreatedBy=ltrim('" & Session("empcode") & "'), createdDate='" & Now & "' where routeno='" & routeno & "'"
                            GoTo out
                        End If

                        QueryString = "select * from log_ViaRouteMaster where Routeno='" & routeno & "' and ViaDepart='" & pViaDepart & "' and DeletedStatus=0"
                        objDataSet = New DataSet
                        objDataAdapter = New SqlClient.SqlDataAdapter(QueryString, con1)
                        objDataAdapter.Fill(objDataSet, "log_ViaRouteMaster")
                        If objDataSet.Tables(0).Rows.Count = 0 Then
                            'Call viarouteno()
                            query2 = "insert into Log_ViaRouteMaster (Routeno, ViaDepart, ArrivalTime, DepartTime, CreatedBy, CreatedDate) values ('" & routeno & "','" & LTrim(pViaDepart) & "','" & LTrim(pViaArrTime) & "','" & LTrim(pViaDeptTime) & "','" & LTrim(Session("empcode")) & "','" & Now & "')"
                        Else
                            query2 = "Update Log_ViaRouteMaster set RouteNo='" & routeno & "', ViaDepart=ltrim('" & pViaDepart & "'), ArrivalTime=ltrim('" & pViaArrTime & "'), DepartTime=ltrim('" & pViaDeptTime & "'), CreatedBy=ltrim('" & Session("empcode") & "'), createdDate='" & Now & "' where routeno='" & routeno & "' and viaDepart=ltrim('" & pViaDepart & "')"
                        End If
                        GoTo out
                        '''''''''''
                    Else
                        GoTo NewRoute
                    End If
                Else
                    GoTo NewRoute
                End If
            Else
                GoTo NewRoute
            End If

NewRoute:
            dr.Close()
            Call routenogenerator()
            query1 = "insert into Log_VehicleRegistration (VehicleType, VehicleNo, TransportName,VehicleName,DepartPlace,Arrivalplace,DepartTime, ArrivalTime,RouteNo, u_id, Createdby, CreatedDate ) values ('" & rblType.SelectedValue & "','" & pddlno & "', '" & LTrim(ptransname) & "', '" & LTrim(pvehiclename) & "', '" & LTrim(ptxtfrom) & "', '" & LTrim(ptxtto) & "', '" & LTrim(pdepttime) & "', '" & LTrim(pArrTime) & "','" & newrouteno & "', ltrim('" & Session("empcode") & "'), ltrim('" & Session("empcode") & "'),'" & Now & "')"
            com.CommandText = query1
            com.ExecuteNonQuery()

            'Call viarouteno()
            PrimaryQuery = "select a.VehicleNo, a.TransportName, a.VehicleName, a.Departplace, a.Arrivalplace, a.DepartTime, a.ArrivalTime, a.RouteNo from log_VehicleRegistration a where a.vehicleno='" & pddlno & "' and a.departplace='" & ptxtfrom & "' and a.ArrivalPlace='" & ptxtto & "' and a.DeletedStatus=0"
            com = New SqlClient.SqlCommand(PrimaryQuery, con)
            dr = com.ExecuteReader
            While dr.Read
                routeno = LTrim(dr.Item(7))
            End While
            If dr.IsClosed = False Then
                dr.Close()
            End If
            query2 = "insert into Log_ViaRouteMaster (Routeno, ViaDepart, ArrivalTime, DepartTime, CreatedBy, CreatedDate) values ('" & routeno & "','" & LTrim(pViaDepart) & "','" & LTrim(pViaArrTime) & "','" & LTrim(pViaDeptTime) & "','" & LTrim(Session("empcode")) & "','" & Now & "')"
            com.CommandText = query2
            com.ExecuteNonQuery()
            recinsertstatus = True
            Call cleartext()
            txtvialoc.Text = ""
            'ddlviaHour.SelectedItem.Text = "01"
            'ddlViaDHour.SelectedItem.Text = "01"
            'ddlviaDMin.SelectedItem.Text = "00"
            'ddlviaMin.SelectedItem.Text = "00"
            GoTo x

out:
            'If dr.IsClosed = False Then
            '    dr.Close()
            'End If
            dr.Close()
            recinsertstatus = True
            com.CommandText = query1
            com.ExecuteNonQuery()
            com.CommandText = query2
            com.ExecuteNonQuery()
        Catch ex As Exception
            recinsertstatus = False
            msg(ex.Message & " Update Table")
        End Try
x:
        con1.Close()
        'dr.Close()
    End Sub

    Private Sub btnclearall_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnclearall.Click
        clearall()
    End Sub

    Private Sub VehicleGrid_ItemDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.DataGridItemEventArgs) Handles VehicleGrid.ItemDataBound
        Dim s
        s = "javascript:return confirm('Are U Sure to delete this Route? Deleted Routes Cannot Retrieved')"
        e.Item.Cells(1).Attributes.Add("Onclick", s)
    End Sub

    Private Sub btnclear_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnclear.Click
        txtvialoc.Text = ""
        'ddlviaHour.SelectedItem.Text = "00"
        'ddlViaDHour.SelectedItem.Text = "00"
        'ddlviaDMin.SelectedItem.Text = "00"
        'ddlviaMin.SelectedItem.Text = "00"
        Dim S As String
        Dim LenI As Integer
        Dim i As Integer
        'Via Min
        ddlviaMin.Items.Clear()
        For i = 0 To 59
            Dim SS As String = i
            LenI = Len(ss)
            If LenI = 1 Then
                S = "0" & i
            ElseIf LenI = 2 Then
                S = i
            End If
            ddlviaMin.Items.Add(S)
        Next
        'Via Hour
        ddlviaHour.Items.Clear()
        For i = 0 To 23
            Dim SS As String = i
            LenI = Len(ss)
            If LenI = 1 Then
                S = "0" & i
            ElseIf LenI = 2 Then
                S = i
            End If
            ddlviaHour.Items.Add(S)
        Next
        'Via Dep Min
        ddlviaDMin.Items.Clear()
        For i = 0 To 59
            Dim SS As String = i
            LenI = Len(ss)
            If LenI = 1 Then
                S = "0" & i
            ElseIf LenI = 2 Then
                S = i
            End If
            ddlviaDMin.Items.Add(S)
        Next

        'Via Dep Hour
        ddlViaDHour.Items.Clear()
        For i = 0 To 23
            Dim SS As String = i
            LenI = Len(ss)
            If LenI = 1 Then
                S = "0" & i
            ElseIf LenI = 2 Then
                S = i
            End If
            ddlViaDHour.Items.Add(S)
        Next
    End Sub
End Class
