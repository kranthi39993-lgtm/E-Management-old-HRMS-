Imports System.Data
Imports System
Imports System.Globalization
Imports System.Data.SqlClient
Imports e_management.emanagement.globalinfo
Imports e_management.emanagement.EMSapplications
Imports e_management.emanagement.NetGlobal
Imports System.Web.Security

Partial Public Class EditMouldDetails
    Inherits System.Web.UI.Page
    Dim mynet As New emanagement.netglobal

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If IsPostBack = False Then
            With CmbDepartment.Items
                .Add("-Select-")
                .Add("Substrate")
                .Add("TPH")
                .Add("CV")
                .Add("Ferrite Magnet")
            End With
            Session("fgid") = "21"
        End If

    End Sub

    Protected Sub CmbDepartment_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CmbDepartment.SelectedIndexChanged
      
    End Sub

    Protected Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        If CmbDepartment.Text = "-Select-" Then
            LblMsg.Text = "Please Select Department"
            LblMsg.ForeColor = Drawing.Color.Red
            Exit Sub
        Else
            LblMsg.Text = ""
            LblMsg.ForeColor = Drawing.Color.Green
        End If

        If CmbDepartment.Text = "Substrate" Then
            Session("fgid") = "21"
        ElseIf CmbDepartment.Text = "TPH" Then
            Session("fgid") = "71"
        ElseIf CmbDepartment.Text = "CV" Then
            Session("fgid") = "31"
        ElseIf CmbDepartment.Text = "Ferrite Magnet" Then
            Session("fgid") = "42"
        ElseIf CmbDepartment.Text = "Ferrite Sheet" Then
            Session("fgid") = "43"
        End If

        Session("product") = CmbProduct.Text

    End Sub

    Protected Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        If CmbDepartment.Text = "-Select-" Then
            LblMsg.Text = "Please Select Department"
            LblMsg.ForeColor = Drawing.Color.Red
            Exit Sub
        Else
            LblMsg.Text = ""
            LblMsg.ForeColor = Drawing.Color.Green
        End If

        If CmbDepartment.Text = "Substrate" Then
            Session("fgid") = "21"
        ElseIf CmbDepartment.Text = "TPH" Then
            Session("fgid") = "71"
        ElseIf CmbDepartment.Text = "CV" Then
            Session("fgid") = "31"
        ElseIf CmbDepartment.Text = "Ferrite Magnet" Then
            Session("fgid") = "42"
        ElseIf CmbDepartment.Text = "Ferrite Sheet" Then
            Session("fgid") = "43"
        End If

        Session("product") = "null"

    End Sub

    Protected Sub CmbProduct_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CmbProduct.SelectedIndexChanged

    End Sub

    Protected Sub ImageButton1_Click(ByVal sender As System.Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles ImageButton1.Click
        Response.Redirect("frmRegMould.aspx")
    End Sub
End Class