Imports System.Data.SqlClient
Imports E_Management.emanagement.globalinfo
Imports System.IO
Imports System.Drawing
Imports System.Drawing.Image
Imports System.IO.Stream
Imports System.Collections
Imports System.ComponentModel
Imports System.Web
Imports System.Web.SessionState
Imports System.Web.UI
Imports System.Web.UI.WebControls
Imports System.Web.UI.HtmlControls
Imports E_Management.crmlognetglobal
Imports System.Web.Security

Partial Public Class FiringMCTempChangeForm
    Inherits Messagebox



    Dim SqlCon As New SqlConnection
    Dim SqlCmd As New SqlCommand
    Dim SqlDs As New DataSet
    Dim SqlAd As New SqlDataAdapter

    Dim D1 As New DateTime
    Dim D2 As New DateTime

    Dim SqlDs1 As New DataSet
    Dim SqlDs2 As New DataSet

    Dim MyGlobal As New Emanagement.globalinfo

    

    Protected Sub mcno_ddl_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mcno_ddl.SelectedIndexChanged
        ''MyGlobal.Con_Str()
        ''MyGlobal.Open_Con_FMD()
        ''SqlCon = New SqlConnection(conFMD)
        ''SqlCon.Open()
        'SqlDs1 = SelectMCName(SqlCon, dept_ddl.SelectedValue, mcno_ddl.SelectedValue)

        'If SqlDs1.Tables(0).Rows.Count >= 1 Then
        '    mcname.Text = SqlDs1.Tables(0).Rows(0).Item(2)
        '    mcdesc.Text = SqlDs1.Tables(0).Rows(0).Item(3)
        'End If

        ''SqlDs1 = SelectMCMasterDetails(SqlCon, mcno_ddl.SelectedValue)
        ''CmbZoneID.Items.Clear()

        ''For Tmpi As Integer = 0 To SqlDs1.Tables(0).Rows.Count - 1
        ''    CmbZoneID.Items.Add(SqlDs1.Tables(0).Rows(Tmpi).Item(0))
        ''Next
        CmbZoneID.Items.Clear()

        For Tmpi As Integer = 1 To 30

            CmbZoneID.Items.Add(Tmpi)

        Next

        

    End Sub

 


   
    Protected Sub BtnSubmit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnSubmit.Click

        Dim D1 As New DateTime
        D1 = TxtDate.Text

        If GridView1.Rows.Count < 1 Then

        End If

        If D1 < DateTime.Today Then
            LblMsg.Text = "Can not be less than today date!"
            Exit Sub
        End If

        If DateDiff(DateInterval.Day, DateTime.Today, D1) > 2 Then
            LblMsg.Text = "Can not plan before 3 days!"
            Exit Sub
        End If

        If TxtCfrom.Text.Trim.Equals("") Or TxtCto.Text.Trim.Equals("") Then
            LblMsg.Text = "Please Enter Cycle Time!"
            Exit Sub
        End If

        If TxtFirstSerialNumber.Text.Trim.Equals("") Then
            LblMsg.Text = "Please Enter First Serial Number!"
            Exit Sub
        End If

        If TxtEmptyBlock.Text.Trim.Equals("") Then
            LblMsg.Text = "Please Enter Empty Block Details!"
            Exit Sub
        End If

        LblMsg.Text = ""
        Dim Msg1 As String = ""
        Dim rowIndex As Integer = 0
        Dim PMC As String = ""
        Dim Dpt As String

        If dept_ddl.Text = "7000" Or dept_ddl.Text = "7400" Or dept_ddl.Text = "7500" Then
            Dpt = "TPH"
        ElseIf dept_ddl.Text = "2000" Or dept_ddl.Text = "2200" Or dept_ddl.Text = "2400" Then
            Dpt = "Substrate"
        ElseIf dept_ddl.Text = "4201" Then
            Dpt = "Ferrite Magnet"
        ElseIf dept_ddl.Text = "3000" Then
            Dpt = "Ceramic Valve"
        Else
            Dpt = dept_ddl.Text
        End If
        MyGlobal.Con_Str()
        MyGlobal.Open_Con_FMD()
        SqlCon = New SqlConnection(conFMD)
        SqlCon.Open()
        SqlDs1 = SelectTempChange(SqlCon, "MaxBatchNo", 0, "-")

        Dim MaxNo As Long = SqlDs1.Tables(0).Rows(0).Item(0) + 1

        For rowIndex = 0 To GridView1.Rows.Count - 2

            Dim TempMachineNo As Label = GridView1.Rows(rowIndex).Cells(1).FindControl("TempMachineNo")
            Dim TempZoneNo As Label = GridView1.Rows(rowIndex).Cells(2).FindControl("TempZoneNo")
            Dim TempHours As Label = GridView1.Rows(rowIndex).Cells(3).FindControl("TempHours")
            Dim TempFrom As Label = GridView1.Rows(rowIndex).Cells(4).FindControl("TempFrom")
            Dim TempTo As Label = GridView1.Rows(rowIndex).Cells(5).FindControl("TempTo")
            Dim TempProductType As Label = GridView1.Rows(rowIndex).Cells(6).FindControl("TempProductType")
            Dim TempRFrom As Label = GridView1.Rows(rowIndex).Cells(7).FindControl("TempRFrom")
            Dim TempReason As Label = GridView1.Rows(rowIndex).Cells(8).FindControl("TempReason")

            D1 = TxtDate.Text + " " + TempHours.Text

            If rowIndex = 0 Then
                Msg1 = "Change Temp On : " & TxtDate.Text & " ; Time : " & TempHours.Text & " ; Dept : " & Dpt & " ; " & vbCrLf
            End If

            If PMC = TempMachineNo.Text Then
                Msg1 = Msg1 & "ZoneNo : " & TempZoneNo.Text & " ; Temp From : " & TempFrom.Text & " To " & TempTo.Text & " ; " & vbCrLf
            Else
                Msg1 = Msg1 & "Reason : " & TempReason.Text & " ; MachineNo : " & TempMachineNo.Text & " ; ZoneNo : " & TempZoneNo.Text & " ; Temp From : " & TempFrom.Text & " To " & TempTo.Text & " ( " & TempRFrom.Text & " ) ; " & vbCrLf
            End If

            If TxtRemarks.Text.Trim.Equals("-") Then
                TxtRemarks.Text = "-"
            End If

            PMC = TempMachineNo.Text
            InsertTempMaster(SqlCon, MaxNo, dept_ddl.Text, D1, TempMachineNo.Text, TempZoneNo.Text, TempHours.Text, TempFrom.Text, TempTo.Text, TempProductType.Text, TempRFrom.Text, TempReason.Text, DateTime.Now, Session("empcode").ToString(), "-", TxtRemarks.Text, TxtEmptyBlock.Text, TxtFirstSerialNumber.Text, CmbFirstProductType.Text, TxtCfrom.Text, TxtCto.Text)
        Next

        UpdateTempMaster(SqlCon, "UpdateSMS", MaxNo, Msg1, "-", DateTime.Now, Session("empcode").ToString())

        Dim mynet1 As New CRMlognetglobal
        mynet1.db_cn()
        mynet1.db_open()

        If Not (TimeOfDay() > "09:00:00 PM" Or TimeOfDay() < "06:00:00 AM") Then

            SqlDs1 = New DataSet

            If dept_ddl.Text = "7000" Or dept_ddl.Text = "7400" Or dept_ddl.Text = "7500" Then
                SqlDs1 = GetProductionGroup("7000")
            ElseIf dept_ddl.Text = "2000" Or dept_ddl.Text = "2200" Or dept_ddl.Text = "2400" Then
                SqlDs1 = GetProductionGroup("2000")
            Else
                SqlDs1 = GetProductionGroup(dept_ddl.Text)
            End If

            For Tmpi As Integer = 0 To SqlDs1.Tables(0).Rows.Count - 1
                If InsertOutGoing(SqlDs1.Tables(0).Rows(Tmpi).Item(0), "Please approve or reject the following request by system! Reference No: " & MaxNo & " ; " & Msg1, TimeOfDay(), TimeOfDay(), 0) Then
                End If
            Next

        End If
            msg("Your request successfully sent for approval!")
            TxtFrom.Text = ""
            TxtTo.Text = ""
            TxtReason.Text = ""
            TxtRemarks.Text = ""
            TxtDate.Text = ""

            CmbHours.Enabled = True
            CmbMinutes.Enabled = True
            CmbMedium.Enabled = True

            GridView1.DataSource = Nothing
            GridView1.DataBind()
            Response.Redirect("FiringMCTempChangeForm.aspx")

            LblFinalMsg.Text = "Request Successfully Sent for Aproval!"

            'mynet1.InsertSMSLINK(mynet1.sConnStringSMS, "MMSB", "FMTC", MaxNo, "S", Session("empcode").ToString, DateTime.Now)

            'Response.Write(Msg1)

            'MyGlobal.Con_Str()
            'MyGlobal.Open_Con_FMD()
            'SqlCon = New SqlConnection(conFMD)
            'SqlCon.Open()
            ''  SqlDs1 = InsertTempMaster(SqlCon, dept_ddl.SelectedValue, mcno_ddl.Text, CmbProductType.Text, CmbRTFrom.Text, CmbRTTo.Text, DateTime.Now, TxtEmpCode.Text = Session("empcode").ToString(), "-")

            ''If SqlDs1.Tables(0).Rows.Count >= 1 Then
            ''    'Max Rec
            ''Else
            ''    'Can not find Max Rec
            ''End If

            'For Tmpi As Integer = 0 To DGrd.Rows.Count - 1
            '    Dim TempDate As TextBox = DGrd.Rows(Tmpi).Cells(0).FindControl("TempDate")
            '    Dim TempHours As DropDownList = DGrd.Rows(Tmpi).Cells(0).FindControl("TempHours")
            '    Dim TempMinutes As DropDownList = DGrd.Rows(Tmpi).Cells(0).FindControl("TempMinutes")
            '    Dim TempMedium As DropDownList = DGrd.Rows(Tmpi).Cells(0).FindControl("TempMedium")
            '    Dim TempFrom As TextBox = DGrd.Rows(Tmpi).Cells(0).FindControl("TempFrom")
            '    Dim TempTo As TextBox = DGrd.Rows(Tmpi).Cells(0).FindControl("TempTo")

            '    If Not (TempDate.Text.Trim.Equals("") Or TempHours.Text.Equals("") Or TempMinutes.Text.Equals("") Or TempMedium.Text.Trim.Equals("") Or TempFrom.Text.Trim.Equals("") Or TempTo.Text.Trim.Equals("")) Then
            '        Msg1 = Msg1 & TempDate.Text & ","
            '        Msg1 = Msg1 & TempHours.Text & ":" & TempMinutes.Text & " " & TempMedium.Text & ","
            '        Msg1 = Msg1 & "Z" & DGrd.Rows(Tmpi).Cells(4).Text & ","
            '        Msg1 = Msg1 & TempFrom.Text & " To " & TempTo.Text
            '        Msg1 = Msg1 & ";"
            '    End If

            'Next

            'Response.Write(Msg1)
    End Sub


    Public Function InsertOutGoing(ByVal number_2 As String, ByVal message_3 As String, ByVal starttime_4 As String, ByVal endtime_5 As String, ByVal fkey_6 As Integer) As Boolean
        Dim Ds As New DataSet
        Ds = New DataSet

        Dim mynet1 As New CRMlognetglobal
        mynet1.db_cn()
        mynet1.db_open()

        SqlCon = New SqlConnection(mynet1.sConnStringSMS)
        SqlCon.Open()
        Cmd = New SqlCommand
        Cmd.CommandType = CommandType.StoredProcedure
        Cmd.CommandText = "insert_outgoing_1"
        Cmd.Connection = SqlCon
        Cmd.Parameters.Clear()
        Cmd.Parameters.AddWithValue("@number_2", number_2)
        Cmd.Parameters.AddWithValue("@message_3", message_3)
        Cmd.Parameters.AddWithValue("@starttime_4", starttime_4)
        Cmd.Parameters.AddWithValue("@endtime_5", endtime_5)
        Cmd.Parameters.AddWithValue("@fkey_6", fkey_6)
        Dim X As Integer = Cmd.ExecuteNonQuery()
        SqlCon.Close()
        If X = 0 Then

            Return False
        Else
            Return True
        End If
    End Function

    Public Function GetProductionGroup(ByVal Dept As String) As DataSet
        Dim Ds As New DataSet
        Ds = New DataSet

        Dim mynet1 As New CRMlognetglobal
        mynet1.db_cn()
        mynet1.db_open()

        SqlCon = New SqlConnection(mynet1.sConnStringSMS)
        SqlCon.Open()
        Cmd = New SqlCommand
        Cmd.CommandType = CommandType.StoredProcedure
        Cmd.CommandText = "SP_Select_Temperature_ProductionGroup"
        Cmd.Parameters.Clear()
        Cmd.Parameters.AddWithValue("@Department", Dept)
        Cmd.Connection = SqlCon

        SqlAd = New SqlDataAdapter(Cmd)
        SqlAd.Fill(Ds, "Details")
        Return Ds
    End Function



    
    Protected Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Me.Load

        If IsPostBack = False Then

            SetInitialRowToGrid()

            'With CmbRTFrom.Items
            '    .Add("H1")
            '    .Add("H2")
            '    .Add("H3")
            '    .Add("H4")
            '    .Add("L1")
            '    .Add("L2")
            '    .Add("L3")
            '    .Add("L4")
            '    .Add("L5")
            '    .Add("N")
            '    .Add("B1")
            '    .Add("B2")
            '    .Add("B3")
            '    .Add("B4")
            '    .Add("B5")
            '    .Add("B6")
            '    .Add("B7")
            '    .Add("B8")
            '    .Add("B9")
            '    .Add("B10")
            'End With

            'With CmbRTTo.Items
            '    .Add("H1")
            '    .Add("H2")
            '    .Add("H3")
            '    .Add("H4")
            '    .Add("L1")
            '    .Add("L2")
            '    .Add("L3")
            '    .Add("L4")
            '    .Add("L5")
            '    .Add("N")
            '    .Add("B1")
            '    .Add("B2")
            '    .Add("B3")
            '    .Add("B4")
            '    .Add("B5")
            '    .Add("B6")
            '    .Add("B7")
            '    .Add("B8")
            '    .Add("B9")
            '    .Add("B10")
            'End With


            For Tmpi As Integer = 1 To 12
                CmbHours.Items.Add(Tmpi)
            Next

            With CmbMinutes.Items
                .Add("05")
                .Add("10")
                .Add("15")
                .Add("20")
                .Add("25")
                .Add("30")
                .Add("35")
                .Add("40")
                .Add("45")
                .Add("50")
                .Add("55")
            End With

            With CmbMedium.Items
                .Add("AM")
                .Add("PM")
            End With

            With CmbProductType.Items
                .Add("HBS2")
                .Add("HRA Product")
                .Add("Normal")
                .Add("No Oily")
                .Add("Zirconia")
            End With

           
 

        End If

        If GridView1.Rows.Count >= 2 Then

            CmbHours.Enabled = False
            CmbMinutes.Enabled = False
            CmbMedium.Enabled = False

            TxtReason.Enabled = False

            CmbRTFrom.Enabled = False
            CmbRTTo.Enabled = False
        Else

            CmbHours.Enabled = True
            CmbMinutes.Enabled = True
            CmbMedium.Enabled = True

            TxtReason.Enabled = True

            CmbRTFrom.Enabled = True
            CmbRTTo.Enabled = True

        End If

    End Sub



    Private Sub SetInitialRowToGrid()
        'Initialize and Set initial row of Datatable
        Dim tempDataTable As New DataTable()
        tempDataTable.Columns.Add("RowNumber")
       tempDataTable.Columns.Add("TempMachineNo")
        tempDataTable.Columns.Add("TempZoneNo")
        tempDataTable.Columns.Add("TempHours")
        tempDataTable.Columns.Add("TempFrom")
        tempDataTable.Columns.Add("TempTo")
        tempDataTable.Columns.Add("TempProductType")
        tempDataTable.Columns.Add("TempRFrom")
        tempDataTable.Columns.Add("TempReason")
         
        tempDataTable.Rows.Add("1", "", "", "", "", "", "", "", "")
        'Store that datatable into viewstate
        ViewState("TempTable") = tempDataTable
        'Attach Gridview Datasource to datatable
        GridView1.DataSource = tempDataTable
        GridView1.DataBind()
    End Sub

    Private Sub SetPreviousData()
        Try
            Dim rowIndex As Integer = 0

            If Not ViewState("TempTable").Equals(Nothing) Then
                Dim tempTable As DataTable = ViewState("TempTable")
                If tempTable.Rows.Count > 0 Then
                    Dim I As Integer
                    For I = 0 To tempTable.Rows.Count
                        
                        Dim TempMachineNo As Label = GridView1.Rows(rowIndex).Cells(1).FindControl("TempMachineNo")
                        Dim TempZoneNo As Label = GridView1.Rows(rowIndex).Cells(2).FindControl("TempZoneNo")
                        Dim TempHours As Label = GridView1.Rows(rowIndex).Cells(3).FindControl("TempHours")
                        Dim TempFrom As Label = GridView1.Rows(rowIndex).Cells(4).FindControl("TempFrom")
                        Dim TempTo As Label = GridView1.Rows(rowIndex).Cells(5).FindControl("TempTo")
                        Dim TempProductType As Label = GridView1.Rows(rowIndex).Cells(6).FindControl("TempProductType")
                        Dim TempRFrom As Label = GridView1.Rows(rowIndex).Cells(7).FindControl("TempRFrom")
                        Dim TempReason As Label = GridView1.Rows(rowIndex).Cells(8).FindControl("TempReason")

                      
                        TempMachineNo.Text = tempTable.Rows(I)("TempMachineNo").ToString()
                        TempZoneNo.Text = tempTable.Rows(I)("TempZoneNo").ToString()
                        TempHours.Text = tempTable.Rows(I)("TempHours").ToString()
                        TempFrom.Text = tempTable.Rows(I)("TempFrom").ToString()
                        TempTo.Text = tempTable.Rows(I)("TempTo").ToString()
                        TempProductType.Text = tempTable.Rows(I)("TempProductType").ToString()
                        TempRFrom.Text = tempTable.Rows(I)("TempRFrom").ToString()
                        TempReason.Text = tempTable.Rows(I)("TempReason").ToString()

                        rowIndex = rowIndex + 1

                    Next
                End If
            End If


        Catch ex As Exception

        End Try


    End Sub


    Private Sub AddNewRowToGrid()
        Dim rowIndex As Integer = 0

        If Not ViewState("TempTable").Equals(Nothing) Then

            ' Get TempTable from viewstate
            Dim tempTable As DataTable = ViewState("TempTable")

            Dim tempRow As DataRow = Nothing

            If tempTable.Rows.Count > 0 Then
                Dim I As Integer

                For I = 1 To tempTable.Rows.Count
                    'Get Grid's TextBox values
                    Dim TempMachineNo As Label = GridView1.Rows(rowIndex).Cells(1).FindControl("TempMachineNo")
                    Dim TempZoneNo As Label = GridView1.Rows(rowIndex).Cells(2).FindControl("TempZoneNo")
                    Dim TempHours As Label = GridView1.Rows(rowIndex).Cells(3).FindControl("TempHours")
                    Dim TempFrom As Label = GridView1.Rows(rowIndex).Cells(4).FindControl("TempFrom")
                    Dim TempTo As Label = GridView1.Rows(rowIndex).Cells(5).FindControl("TempTo")
                    Dim TempProductType As Label = GridView1.Rows(rowIndex).Cells(6).FindControl("TempProductType")
                    Dim TempRFrom As Label = GridView1.Rows(rowIndex).Cells(7).FindControl("TempRFrom")
                    Dim TempReason As Label = GridView1.Rows(rowIndex).Cells(8).FindControl("TempReason")

                    'Create new row and update Row Number

                    If tempTable.Rows.Count = I Then

                        tempRow = tempTable.NewRow()
                        tempRow("RowNumber") = I + 1

                       
                        tempTable.Rows(I - 1)("TempMachineNo") = mcno_ddl.SelectedValue
                        tempTable.Rows(I - 1)("TempZoneNo") = CmbZoneID.Text
                        tempTable.Rows(I - 1)("TempHours") = CmbHours.Text & ":" & CmbMinutes.Text & " " & CmbMedium.Text
                        tempTable.Rows(I - 1)("TempFrom") = TxtFrom.Text
                        tempTable.Rows(I - 1)("TempTo") = TxtTo.Text
                        tempTable.Rows(I - 1)("TempProductType") = CmbProductType.Text
                        tempTable.Rows(I - 1)("TempRFrom") = CmbRTFrom.Text & " To " & CmbRTTo.Text
                        tempTable.Rows(I - 1)("TempReason") = TxtReason.Text


                    End If


                    rowIndex = rowIndex + 1
                Next

                'Add data to datatable and viewstate
                tempTable.Rows.Add(tempRow)
                ViewState("TempTable") = tempTable

                'Attach Gridview Datasource to datatable
                GridView1.DataSource = tempTable
                GridView1.DataBind()

            End If

        End If

        'Set Previous Data on Postbacks
        SetPreviousData()

        TxtFrom.Text = ""
        TxtTo.Text = ""

    End Sub


    Protected Sub Fun3(ByVal sender As Object, ByVal e As GridViewDeleteEventArgs)
        Dim rowIndex As Integer = 0

        If Not ViewState("TempTable").Equals(Nothing) Then

            ' Get TempTable from viewstate
            Dim tempTable As DataTable = ViewState("TempTable")

            Dim tempRow As DataRow = Nothing
            Dim Ind As Integer = e.RowIndex

            If tempTable.Rows.Count >= 1 And e.RowIndex <> GridView1.Rows.Count - 1 Then
                tempTable.Rows.RemoveAt(Ind)

                tempRow = tempTable.NewRow
                ViewState("TempTable") = tempTable
                GridView1.DataSource = tempTable
                GridView1.DataBind()

                For i As Integer = 0 To GridView1.Rows.Count - 1
                    GridView1.Rows(i).Cells(0).Text = Convert.ToString(i + 1)
                Next

                SetPreviousData()

            End If

        End If

        If GridView1.Rows.Count >= 2 Then

            CmbHours.Enabled = False
            CmbMinutes.Enabled = False
            CmbMedium.Enabled = False

            TxtReason.Enabled = False

            CmbRTFrom.Enabled = False
            CmbRTTo.Enabled = False
            mcno_ddl.Enabled = False

        Else

            CmbHours.Enabled = True
            CmbMinutes.Enabled = True
            CmbMedium.Enabled = True

            TxtReason.Enabled = True

            CmbRTFrom.Enabled = True
            CmbRTTo.Enabled = True
            mcno_ddl.Enabled = True

        End If

    End Sub


    Protected Sub dept_ddl_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles dept_ddl.SelectedIndexChanged
        MyGlobal.Con_Str()
        MyGlobal.Open_Con_FMD()
        SqlCon = New SqlConnection(conFMD)
        SqlCon.Open()


        If dept_ddl.SelectedValue = "2000" Or dept_ddl.SelectedValue = "2200" Or dept_ddl.SelectedValue = "2400" Then
            SqlDs1 = New DataSet
            SqlDs1 = LoadMcNo(SqlCon, "2000")
            mcno_ddl.DataSource = SqlDs1
            mcno_ddl.DataValueField = "mcno"
            mcno_ddl.DataTextField = "mcno"
            mcno_ddl.DataBind()
            mcno_ddl.Items.Insert(0, "--Select--")
        ElseIf dept_ddl.SelectedValue = "7000" Or dept_ddl.SelectedValue = "7400" Or dept_ddl.SelectedValue = "7500" Then
            SqlDs1 = New DataSet
            SqlDs1 = LoadMcNo(SqlCon, "7000")
            mcno_ddl.DataSource = SqlDs1
            mcno_ddl.DataValueField = "mcno"
            mcno_ddl.DataTextField = "mcno"
            mcno_ddl.DataBind()
            mcno_ddl.Items.Insert(0, "--Select--")
        Else
            SqlDs1 = New DataSet
            SqlDs1 = LoadMcNo(SqlCon, dept_ddl.SelectedValue)
            mcno_ddl.DataSource = SqlDs1
            mcno_ddl.DataValueField = "mcno"
            mcno_ddl.DataTextField = "mcno"
            mcno_ddl.DataBind()
            mcno_ddl.Items.Insert(0, "--Select--")
        End If
        

        If dept_ddl.SelectedValue = "2000" Or dept_ddl.SelectedValue = "2200" Or dept_ddl.SelectedValue = "2400" Then
            SqlDs1 = New DataSet
            SqlDs1 = LoadTemperature(SqlCon, "2000")
            CmbRTTo.DataSource = SqlDs1
            CmbRTTo.DataValueField = "Temperature"
            CmbRTTo.DataTextField = "Temperature"
            CmbRTTo.DataBind()
            'CmbRTTo.Items.Insert(0, "--Select--")

            CmbRTFrom.DataSource = SqlDs1
            CmbRTFrom.DataValueField = "Temperature"
            CmbRTFrom.DataTextField = "Temperature"
            CmbRTFrom.DataBind()
            'CmbRTFrom.Items.Insert(0, "--Select--")
        ElseIf dept_ddl.SelectedValue = "7000" Or dept_ddl.SelectedValue = "7400" Or dept_ddl.SelectedValue = "7500" Then
            SqlDs1 = New DataSet
            SqlDs1 = LoadTemperature(SqlCon, "7000")
            CmbRTTo.DataSource = SqlDs1
            CmbRTTo.DataValueField = "Temperature"
            CmbRTTo.DataTextField = "Temperature"
            CmbRTTo.DataBind()
            'CmbRTTo.Items.Insert(0, "--Select--")

            CmbRTFrom.DataSource = SqlDs1
            CmbRTFrom.DataValueField = "Temperature"
            CmbRTFrom.DataTextField = "Temperature"
            CmbRTFrom.DataBind()
            'CmbRTFrom.Items.Insert(0, "--Select--")
        Else
            SqlDs1 = New DataSet
            SqlDs1 = LoadTemperature(SqlCon, dept_ddl.SelectedValue)
            CmbRTTo.DataSource = SqlDs1
            CmbRTTo.DataValueField = "Temperature"
            CmbRTTo.DataTextField = "Temperature"
            CmbRTTo.DataBind()
            'CmbRTTo.Items.Insert(0, "--Select--")

            CmbRTFrom.DataSource = SqlDs1
            CmbRTFrom.DataValueField = "Temperature"
            CmbRTFrom.DataTextField = "Temperature"
            CmbRTFrom.DataBind()
            'CmbRTFrom.Items.Insert(0, "--Select--")
        End If
        



    End Sub
    Private Function LoadMcNo(ByVal Con1 As SqlConnection, ByVal Department As String) As DataSet
        SqlCmd.CommandType = CommandType.StoredProcedure
        SqlCmd.CommandText = "SP_FiringMcNo_ByDepartment_New1"
        SqlCmd.Parameters.Clear()
        SqlCmd.Parameters.AddWithValue("@Department", Department)
        SqlCmd.Connection = SqlCon
        SqlAd = New SqlDataAdapter(SqlCmd)
        SqlDs = New DataSet
        SqlAd.Fill(SqlDs, "Details")
        Return SqlDs
    End Function
    Private Function SelectMCName(ByVal Con1 As SqlConnection, ByVal Department As String, ByVal MCNO As String) As DataSet
        SqlCmd.CommandType = CommandType.StoredProcedure
        SqlCmd.CommandText = "SP_SelectFiringMcName"
        SqlCmd.Parameters.Clear()
        SqlCmd.Parameters.AddWithValue("@Department", Department)
        SqlCmd.Parameters.AddWithValue("@MCNO", MCNO)
        SqlCmd.Connection = SqlCon
        SqlAd = New SqlDataAdapter(SqlCmd)
        SqlDs = New DataSet
        SqlAd.Fill(SqlDs, "Details")
        Return SqlDs
    End Function
    Private Function SelectMCMasterDetails(ByVal Con1 As SqlConnection, ByVal MCNO As String) As DataSet
        SqlCmd.CommandType = CommandType.StoredProcedure
        SqlCmd.CommandText = "SP_FiringMc_MasterDetails"
        SqlCmd.Parameters.Clear()

        SqlCmd.Parameters.AddWithValue("@MCNO", MCNO)
        SqlCmd.Connection = SqlCon
        SqlAd = New SqlDataAdapter(SqlCmd)
        SqlDs = New DataSet
        SqlAd.Fill(SqlDs, "Details")
        Return SqlDs
    End Function
    Private Function InsertTempMaster(ByVal Con1 As SqlConnection, ByVal Batchno As Integer, ByVal Department As String, ByVal TempChangeOn As DateTime, ByVal MachineNo As String, ByVal ZoneNo As String, ByVal tempTime As String, ByVal TempFrom As Double, ByVal TempTo As Double, ByVal ProductType As String, ByVal ReferThermo As String, ByVal ReasonforChange As String, ByVal CrON As DateTime, ByVal CBY As String, ByVal SMSMessage As String, ByVal Remarks As String, ByVal EmptyBlock As String, ByVal FirstSerialNumber As String, ByVal FirstProductType As String, ByVal CycleTimeFrom As String, ByVal CycleTimeTo As String)
        SqlCmd.CommandType = CommandType.StoredProcedure
        SqlCmd.CommandText = "SP_InsertTempChange_Rev1"
        SqlCmd.Parameters.Clear()

        SqlCmd.Parameters.AddWithValue("@Batchno", Batchno)
        SqlCmd.Parameters.AddWithValue("@Department", Department)
        SqlCmd.Parameters.AddWithValue("@TempChangeOn", TempChangeOn)
        SqlCmd.Parameters.AddWithValue("@MachineNo", MachineNo)
        SqlCmd.Parameters.AddWithValue("@ZoneNo", ZoneNo)
        SqlCmd.Parameters.AddWithValue("@TempTime", tempTime)
        SqlCmd.Parameters.AddWithValue("@TempFrom", TempFrom)
        SqlCmd.Parameters.AddWithValue("@TempTo", TempTo)

        SqlCmd.Parameters.AddWithValue("@ProductType", ProductType)
        SqlCmd.Parameters.AddWithValue("@ReferThermo", ReferThermo)
        SqlCmd.Parameters.AddWithValue("@ReasonforChange", ReasonforChange)
        SqlCmd.Parameters.AddWithValue("@CreatedBy", CBY)
        SqlCmd.Parameters.AddWithValue("@CreatedOn", CrON)
        SqlCmd.Parameters.AddWithValue("@SMSMessage", SMSMessage)
        SqlCmd.Parameters.AddWithValue("@Remarks", Remarks)

        SqlCmd.Parameters.AddWithValue("@EmptyBlock", EmptyBlock)
        SqlCmd.Parameters.AddWithValue("@FirstSerialNumber", FirstSerialNumber)
        SqlCmd.Parameters.AddWithValue("@FirstProductType", FirstProductType)
        SqlCmd.Parameters.AddWithValue("@CycleTimeFrom", CycleTimeFrom)
        SqlCmd.Parameters.AddWithValue("@CycleTimeTo", CycleTimeTo)



        SqlCmd.Connection = SqlCon
        SqlCmd.ExecuteNonQuery()

    End Function

    Private Function UpdateTempMaster(ByVal Con1 As SqlConnection, ByVal Options As String, ByVal Batchno As Integer, ByVal SMSMessage As String, ByVal Status As String, ByVal CrON As DateTime, ByVal CBY As String)
        SqlCmd.CommandType = CommandType.StoredProcedure
        SqlCmd.CommandText = "SP_UpdateTempChange"
        SqlCmd.Parameters.Clear()
        SqlCmd.Parameters.AddWithValue("@Options", Options)
        SqlCmd.Parameters.AddWithValue("@Batchno", Batchno)
        SqlCmd.Parameters.AddWithValue("@SMSMessage", SMSMessage)
        SqlCmd.Parameters.AddWithValue("@Status", Status)
        SqlCmd.Parameters.AddWithValue("@CreatedBy", CBY)
        SqlCmd.Parameters.AddWithValue("@CreatedOn", CrON)


        SqlCmd.Connection = SqlCon
        SqlCmd.ExecuteNonQuery()

    End Function

    Private Function SelectTempChange(ByVal Con1 As SqlConnection, ByVal Options As String, ByVal BatchNo As Integer, ByVal Dept As String) As DataSet
        SqlCmd.CommandType = CommandType.StoredProcedure
        SqlCmd.CommandText = "SP_SelectTempChange"
        SqlCmd.Parameters.Clear()
        SqlCmd.Parameters.AddWithValue("@Options", Options)
        SqlCmd.Parameters.AddWithValue("@BatchNo", BatchNo)
        SqlCmd.Parameters.AddWithValue("@Department", Dept)
        SqlCmd.Connection = SqlCon
        SqlAd = New SqlDataAdapter(SqlCmd)
        SqlDs = New DataSet
        SqlAd.Fill(SqlDs, "Details")
        Return SqlDs
    End Function
 
    Protected Sub BtnAdd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnAdd.Click
        Dim D1 As New DateTime
        D1 = TxtDate.Text

        If D1 < DateTime.Today Then
            LblMsg.Text = "Can not be less than today date!"
            Exit Sub
        End If

        If DateDiff(DateInterval.Day, DateTime.Today, D1) > 2 Then
            LblMsg.Text = "Can not plan before 3 days!"
            Exit Sub
        End If

        If TxtReason.Text.Trim.Equals("-") Then
            TxtReason.Text = "-"
        End If

        LblMsg.Text = ""
        AddNewRowToGrid()

        CmbHours.Enabled = False
        CmbMinutes.Enabled = False
        CmbMedium.Enabled = False

        TxtReason.Enabled = False

        CmbRTFrom.Enabled = False
        CmbRTTo.Enabled = False
        mcno_ddl.Enabled = False

    End Sub

     
    Protected Sub TxtDate_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TxtDate.TextChanged
      



    End Sub


    Private Function LoadTemperature(ByVal Con1 As SqlConnection, ByVal Department As String) As DataSet
        SqlCmd.CommandType = CommandType.StoredProcedure
        SqlCmd.CommandText = "SP_FiringMc_ByDept"
        SqlCmd.Parameters.Clear()
        SqlCmd.Parameters.AddWithValue("@Department", Department)
        SqlCmd.Connection = SqlCon
        SqlAd = New SqlDataAdapter(SqlCmd)
        SqlDs = New DataSet
        SqlAd.Fill(SqlDs, "Details")
        Return SqlDs
    End Function

    Protected Sub CmbRTTo_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CmbRTTo.SelectedIndexChanged

    End Sub
End Class