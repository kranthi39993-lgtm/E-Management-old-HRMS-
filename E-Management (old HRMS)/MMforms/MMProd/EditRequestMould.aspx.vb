Imports System.Data
Imports System
Imports System.Globalization
Imports System.Data.SqlClient
Imports e_management.emanagement.globalinfo
Imports e_management.emanagement.EMSapplications
Imports e_management.emanagement.NetGlobal
Imports System.Web.Security

Partial Public Class EditRequestMould
    Inherits System.Web.UI.Page

    Dim mynet As New emanagement.netglobal

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If IsPostBack = False Then
            With CMBDepartment.Items
                .Add("-Select-")
                .Add("Substrate")
                .Add("TPH")
                .Add("CV")
                .Add("Ferrite Magnet")
            End With
        End If
    End Sub

    Protected Sub CMBDepartment_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CMBDepartment.SelectedIndexChanged
        If CMBDepartment.Text = "Substrate" Then
            Session("fgid") = "21"
        ElseIf CMBDepartment.Text = "TPH" Then
            Session("fgid") = "71"
        ElseIf CMBDepartment.Text = "CV" Then
            Session("fgid") = "31"
        ElseIf CMBDepartment.Text = "Ferrite Magnet" Then
            Session("fgid") = "42"
        ElseIf CMBDepartment.Text = "Ferrite Sheet" Then
            Session("fgid") = "43"
        End If
    End Sub

    Public Sub SelectEvent(ByVal sender As Object, ByVal e As EventArgs)

        If (GridView1.SelectedIndex >= 0) Then
            Session("recno") = GridView1.SelectedValue
        Else
            Exit Sub
        End If

        Dim Ad1 As New SqlDataAdapter
        Dim TmpDs As New DataSet

        Try


            mynet.db_cn()
            mynet.dbM_open()

            Call mynet.dbSpM_open("Select_RequestMould")
            command.Parameters.AddWithValue("@RecNo", GridView1.SelectedValue)
            
            Ad1 = New SqlDataAdapter()
            Ad1.SelectCommand = command
            TmpDs = New DataSet
            Ad1.Fill(TmpDs, "Mld")

            If TmpDs.Tables(0).Rows.Count >= 1 Then
                Session("mname") = TmpDs.Tables(0).Rows(0).Item(1)
                Session("product") = TmpDs.Tables(0).Rows(0).Item(0)
                Session("pressingmc") = TmpDs.Tables(0).Rows(0).Item(2)
                Session("dept") = CMBDepartment.Text
                Response.Redirect("IssueMould.aspx")
            End If

            mynet.dbM_close()

            
        Catch ex As Exception
            
        End Try

    End Sub



    Protected Sub ImageButton1_Click(ByVal sender As System.Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles ImageButton1.Click
        Response.Redirect("frmReqMould.aspx")
    End Sub
End Class