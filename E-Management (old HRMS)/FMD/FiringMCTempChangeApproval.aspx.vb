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

Partial Public Class FiringMCTempChangeApproval
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
        MyGlobal.Con_Str()
        MyGlobal.Open_Con_FMD()
        SqlCon = New SqlConnection(conFMD)
        SqlCon.Open()

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

   

    Protected Sub ViewData()
        GridView1.DataSource = Nothing
        GridView1.DataBind()

        MyGlobal.Con_Str()
        MyGlobal.Open_Con_FMD()
        SqlCon = New SqlConnection(conFMD)
        SqlCon.Open()

        SqlDs1 = New DataSet
        SqlDs1 = SelectTempChange(SqlCon, "GrdView_Rev1", 0, dept_ddl.SelectedValue)
        GridView1.DataSource = SqlDs1
        GridView1.DataBind()

        SqlCon.Close()
    End Sub

    Protected Sub dept_ddl_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles dept_ddl.SelectedIndexChanged
        'MyGlobal.Con_Str()
        'MyGlobal.Open_Con_FMD()
        'SqlCon = New SqlConnection(conFMD)
        'SqlCon.Open()

        'CmbBatchNo.Items.Clear()
        'SqlDs1 = New DataSet
        'SqlDs1 = SelectTempChange(SqlCon, "Distinct", 0, dept_ddl.SelectedValue)
        'For Tmpi As Integer = 0 To SqlDs1.Tables(0).Rows.Count - 1
        '    CmbBatchNo.Items.Add(SqlDs1.Tables(0).Rows(Tmpi).Item(0))
        'Next
        'CmbBatchNo.Items.Insert(0, "-Select-")

        ViewData()

    End Sub

    Protected Sub BtnApprove_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnApprove.Click

        Try
            Dim Msg1 As String

            Dim Flg As Boolean = False

            SqlDs1 = New DataSet
            SqlDs1 = GetFMDandFMDTechGroup()


            For i As Integer = 0 To GridView1.Rows.Count - 1
                Dim cbcell = DirectCast(GridView1.Rows(i).FindControl("ChkBxSelect"), CheckBox)

                If cbcell.checked = True Then
                    Flg = True
                    Msg1 = "Production Approved to Change Temperature: Reference No:" & GridView1.Rows(i).Cells(1).Text & " ; Details: " & GridView1.Rows(i).Cells(2).Text


                    Try
                        If Not (TimeOfDay() > "09:00:00 PM" Or TimeOfDay() < "06:00:00 AM") Then


                            For Tmpi As Integer = 0 To SqlDs1.Tables(0).Rows.Count - 1
                                If InsertOutGoing(SqlDs1.Tables(0).Rows(Tmpi).Item(0), Msg1, TimeOfDay(), TimeOfDay(), 0) Then
                                End If
                            Next
                        End If
                    Catch ex As Exception

                    End Try

                    MyGlobal.Con_Str()
                    MyGlobal.Open_Con_FMD()
                    SqlCon = New SqlConnection(conFMD)
                    SqlCon.Open()

                    UpdateTempMaster(SqlCon, "UpdateStatus", GridView1.Rows(i).Cells(1).Text, "-", "A", DateTime.Now, Session("empcode").ToString())
                    SqlCon.Close()

                End If
            Next
            If Flg = True Then
                msg("Temperature change request approved and sms sent to respective incharges!")
            Else
                msg("Please select item from the given list!")
            End If


            ViewData()
        Catch ex As Exception
            msg("Error in approval! Please try later!")
        End Try
    End Sub

    Public Function GetFMDandFMDTechGroup() As DataSet
        Dim Ds As New DataSet
        Ds = New DataSet

        Dim mynet1 As New CRMlognetglobal
        mynet1.db_cn()
        mynet1.db_open()

        SqlCon = New SqlConnection(mynet1.sConnStringSMS)
        SqlCon.Open()
        Cmd = New SqlCommand
        Cmd.CommandType = CommandType.StoredProcedure
        Cmd.CommandText = "SP_Select_FMDandFMDTech"
        Cmd.Connection = SqlCon
        Cmd.Parameters.Clear()
        SqlAd = New SqlDataAdapter(Cmd)
        SqlAd.Fill(Ds, "Details")
        Return Ds
    End Function


    Protected Sub BtnReject_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnReject.Click

        Dim Flg As Boolean = False

        MyGlobal.Con_Str()
        MyGlobal.Open_Con_FMD()
        SqlCon = New SqlConnection(conFMD)
        SqlCon.Open()
        For i As Integer = 0 To GridView1.Rows.Count - 1
            Dim cbcell = DirectCast(GridView1.Rows(i).FindControl("ChkBxSelect"), CheckBox)
            If cbcell.checked = True Then
                Flg = True
                UpdateTempMaster(SqlCon, "UpdateStatus", GridView1.Rows(i).Cells(1).Text, "-", "R", DateTime.Now, Session("empcode").ToString())
            End If
        Next


        If Flg = True Then
            ViewData()
            msg("Temperature change request rejected!")
        Else
            msg("Please select item from given list!")
        End If

        
        SqlCon.Close()
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

   
End Class