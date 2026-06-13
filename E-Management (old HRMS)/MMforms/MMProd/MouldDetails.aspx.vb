Public Partial Class MouldDetails
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If IsPostBack = False Then
            With CmbDepartment.Items
                .Add("-Select-")
                .Add("Substrate")
                .Add("TPH")
                .Add("CV")
                .Add("Ferrite Magnet")
            End With
        End If
    End Sub

    Protected Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
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

        GridView1.DataBind()
    End Sub
End Class