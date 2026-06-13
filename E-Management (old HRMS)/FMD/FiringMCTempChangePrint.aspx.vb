Imports System.Data.SqlClient
Imports E_Management.emanagement.globalinfo

Partial Public Class FiringMCTempChangePrint
    Inherits System.Web.UI.Page

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
        MyGlobal.Con_Str()
        MyGlobal.Open_Con_FMD()
        SqlCon = New SqlConnection(conFMD)
        SqlCon.Open()

    End Sub


    Sub Fun1(ByVal sender As Object, ByVal e As EventArgs)

        Dim row As GridViewRow = GridView1.SelectedRow

        Session("Options") = ""
        Session("BatchNo") = ""
        Session("MachineNo") = ""

        Session("Options") = "PrintForm"
        Session("BatchNo") = row.Cells(0).Text
        Session("MachineNo") = row.Cells(1).Text

        Response.Redirect("FiringMCTempChangePrint_Design.aspx")

    End Sub


    Protected Sub dept_ddl_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles dept_ddl.SelectedIndexChanged

        'CmbBatchNo.Items.Clear()
        'SqlDs1 = New DataSet
        'SqlDs1 = SelectTempChange(SqlCon, "Approved", 0, dept_ddl.SelectedValue)
        'For Tmpi As Integer = 0 To SqlDs1.Tables(0).Rows.Count - 1
        '    CmbBatchNo.Items.Add(SqlDs1.Tables(0).Rows(Tmpi).Item(0))
        'Next

        'CmbBatchNo.Items.Insert(0, "-Select-")

        ViewData()

    End Sub

    Protected Sub ViewData()
        GridView1.DataSource = Nothing
        GridView1.DataBind()

        MyGlobal.Con_Str()
        MyGlobal.Open_Con_FMD()
        SqlCon = New SqlConnection(conFMD)
        SqlCon.Open()

        SqlDs1 = New DataSet
        SqlDs1 = SelectTempChange(SqlCon, "GrdView_Rev2", 0, dept_ddl.SelectedValue)
        GridView1.DataSource = SqlDs1
        GridView1.DataBind()

        SqlCon.Close()
    End Sub


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


     
 
End Class