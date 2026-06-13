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

Partial Public Class FiringMCTempChangeSelfStatus
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

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
       
    End Sub

    Protected Sub dept_ddl_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles dept_ddl.SelectedIndexChanged
        LblStatus.Text = ""
        GridView1.DataSource = Nothing
        GridView1.DataBind()

        MyGlobal.Con_Str()
        MyGlobal.Open_Con_FMD()
        SqlCon = New SqlConnection(conFMD)
        SqlCon.Open()
        'SqlDs1 = SelectTempChange(SqlCon, "SelfStatus", 0, dept_ddl.SelectedValue)
        SqlDs1 = SelectTempChange(SqlCon, "DetailsofApproved", 0, dept_ddl.SelectedValue)
        GridView1.DataSource = SqlDs1.Tables(0)
        GridView1.DataBind()
        Dim I As Integer = 0

        For Each Dr As GridViewRow In GridView1.Rows

            Dr.Cells(4).Font.Bold = True


            If GridView1.Rows(I).Cells(4).Text.Equals("R") Then
                Dr.Cells(4).ForeColor = Color.Brown
            ElseIf GridView1.Rows(I).Cells(4).Text.Equals("A") Then
                Dr.Cells(4).ForeColor = Color.Green
            ElseIf GridView1.Rows(I).Cells(4).Text.Equals("S") Then
                Dr.Cells(4).ForeColor = Color.Red
            End If

            I = I + 1

        Next
    End Sub

    Private Function SelectTempChange(ByVal Con1 As SqlConnection, ByVal Options As String, ByVal BatchNo As Integer, ByVal Dept As String) As DataSet
        SqlCmd.CommandType = CommandType.StoredProcedure
        SqlCmd.CommandText = "SP_SelectTempChange"
        SqlCmd.Parameters.Clear()
        SqlCmd.Parameters.AddWithValue("@Options", Options)
        SqlCmd.Parameters.AddWithValue("@BatchNo", BatchNo)
        SqlCmd.Parameters.AddWithValue("@Department", Dept)
        SqlCmd.Connection = Con1
        SqlAd = New SqlDataAdapter(SqlCmd)
        SqlDs = New DataSet
        SqlAd.Fill(SqlDs, "Details")
        Return SqlDs
    End Function

    Protected Sub Btn_Update_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_Update.Click
        Dim SqlCon_nw As New SqlConnection
        MyGlobal.Con_Str()
        MyGlobal.Open_Con_FMD()
        SqlCon_nw = New SqlConnection(conFMD)
        SqlCon_nw.Open()

        Dim Uid As Integer
        Dim Remarks As String

        Dim Flg As Boolean = False

        Dim i = 0
        For i = 0 To GridView1.Rows.Count - 1
            Dim cbcell = DirectCast(GridView1.Rows(i).FindControl("ChkBxSelect"), CheckBox)
            Dim txtchangedon = DirectCast(GridView1.Rows(i).FindControl("ChangedOn"), TextBox)

            If cbcell.checked = True Then
                If txtchangedon.Text = "" Then
                    msg("Please Enter Date!")
                    Exit Sub
                End If
            End If
            
        Next

        Dim Msg1 As String

        SqlDs1 = New DataSet

        SqlDs1 = New DataSet
        SqlDs1 = GetProductionGroup(dept_ddl.Text)


        For i = 0 To GridView1.Rows.Count - 1

          

            Dim cbcell = DirectCast(GridView1.Rows(i).FindControl("ChkBxSelect"), CheckBox)
            Dim txtrem = DirectCast(GridView1.Rows(i).FindControl("TxtRemarks"), TextBox)
            Dim txtchangedon = DirectCast(GridView1.Rows(i).FindControl("ChangedOn"), TextBox)
            Dim cmbhour1 = DirectCast(GridView1.Rows(i).FindControl("CmbHours"), DropDownList)
            Dim cmbminute1 = DirectCast(GridView1.Rows(i).FindControl("CmbMins"), DropDownList)
            Dim cmbmedium1 = DirectCast(GridView1.Rows(i).FindControl("CmbMedium"), DropDownList)

            If cbcell.checked = True Then
                Msg1 = ""
                Flg = True
                Remarks = txtrem.Text
                Uid = GridView1.Rows(i).Cells(1).Text
                Msg1 = "Maintenance Closed your temperature change request! Please check and verify it! Reference No:" & GridView1.Rows(i).Cells(1).Text & " ; Details: " & GridView1.Rows(i).Cells(3).Text
                If Remarks.Trim.Equals("") Then
                    Remarks = "-"
                End If
                UpdateTempMaster(SqlCon_nw, "FMD", Uid, "-", "C", DateTime.Now, Session("empcode").ToString(), Remarks, txtchangedon.Text, cmbhour1.Text & ":" & cmbminute1.Text & " " & cmbmedium1.Text)

                Try
                    If Not (TimeOfDay() > "09:00:00 PM" Or TimeOfDay() < "06:00:00 AM") Then
                        For Tmpi As Integer = 0 To SqlDs1.Tables(0).Rows.Count - 1
                            If InsertOutGoing(SqlDs1.Tables(0).Rows(Tmpi).Item(0), Msg1, TimeOfDay(), TimeOfDay(), 0) Then
                            End If
                        Next
                    End If
                Catch ex As Exception

                End Try

            End If
        Next

        If Flg = True Then
            MyGlobal.Con_Str()
            MyGlobal.Open_Con_FMD()
            SqlCon = New SqlConnection(conFMD)
            SqlCon.Open()
            GridView1.DataSource = Nothing
            GridView1.DataBind()
            SqlDs1 = SelectTempChange(SqlCon, "DetailsofApproved", 0, dept_ddl.SelectedValue)
            GridView1.DataSource = SqlDs1.Tables(0)
            GridView1.DataBind()
            LblStatus.Text = "Temperature change request status successfully closed!"
            LblStatus.ForeColor = Color.Green
        Else
            LblStatus.Text = "Please select items from the list!"
            LblStatus.ForeColor = Color.Red
        End If
        SqlCon_nw.Close()
    End Sub

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


    Private Function UpdateTempMaster(ByVal Con1 As SqlConnection, ByVal Options As String, ByVal Batchno As Integer, ByVal SMSMessage As String, ByVal Status As String, ByVal CrON As DateTime, ByVal CBY As String, ByVal Remarks As String, ByVal ChangedOn As DateTime, ByVal ChangeTime As String)
        SqlCmd.CommandType = CommandType.StoredProcedure
        SqlCmd.CommandText = "SP_UpdateTempChange_Rev1"
        SqlCmd.Parameters.Clear()
        SqlCmd.Parameters.AddWithValue("@Options", Options)
        SqlCmd.Parameters.AddWithValue("@Batchno", Batchno)
        SqlCmd.Parameters.AddWithValue("@SMSMessage", SMSMessage)
        SqlCmd.Parameters.AddWithValue("@Status", Status)
        SqlCmd.Parameters.AddWithValue("@CreatedBy", CBY)
        SqlCmd.Parameters.AddWithValue("@CreatedOn", CrON)
        SqlCmd.Parameters.AddWithValue("@Remarks", Remarks)
        SqlCmd.Parameters.AddWithValue("@ChangedOn", ChangedOn)
        SqlCmd.Parameters.AddWithValue("@ChangeTime", ChangeTime)


        SqlCmd.Connection = Con1
        SqlCmd.ExecuteNonQuery()

    End Function

 
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
End Class