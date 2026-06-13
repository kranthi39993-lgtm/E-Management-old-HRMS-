Imports System
Imports System.Data
Imports System.Globalization
Imports System.Data.SqlClient
Imports e_management.emanagement.globalinfo
Imports e_management.emanagement.EMSapplications
Imports e_management.emanagement.[Global]
Imports e_management.emanagement.NetGlobal
Imports System.Web.Security

Partial Public Class PrintMouldMaintenanceData
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If IsPostBack = False Then
            Dim mynet As New Emanagement.netglobal
            Dim MyGlobal As New Emanagement.globalinfo

            Dim Ad As SqlDataAdapter
            Dim Ds As New DataSet

            mynet.db_cn()
            mynet.dbM_open()



            Call mynet.dbSpM_open("SP_Select_MouldRepairData")


            Command.Parameters.AddWithValue("@SLNO", 0)
            command.Parameters.AddWithValue("@Options", "CSLNO")


            Ad = New SqlDataAdapter(Command)
            Ds = New DataSet
            Ad.Fill(Ds, "Details")

            GridView1.DataSource = Ds.Tables(0)
            GridView1.DataBind()

        End If

    End Sub


    Sub Fun1(ByVal sender As Object, ByVal e As EventArgs)

        Dim row As GridViewRow = GridView1.SelectedRow

        Session("reqno") = row.Cells(0).Text

        Session("purl") = "PrintMouldMaintenanceData.aspx"
        Session("options") = "mould"
        Response.Redirect("PrintProductionRequest.aspx")

    End Sub

End Class