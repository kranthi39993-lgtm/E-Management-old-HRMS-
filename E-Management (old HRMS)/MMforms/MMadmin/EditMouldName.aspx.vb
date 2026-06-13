Public Partial Class EditMouldName
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If IsPostBack = False Then
            With CMbDepartment.Items
                .Add("-Select-")
                .Add("Substrate")
                .Add("TPH")
                .Add("CV")
                .Add("Ferrite Magnet")
            End With
        End If
    End Sub

    Protected Sub CMbDepartment_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CMbDepartment.SelectedIndexChanged

        If CMbDepartment.Text = "Substrate" Then
            Session("fgid") = "21"
        ElseIf CMbDepartment.Text = "TPH" Then
            Session("fgid") = "71"
        ElseIf CMbDepartment.Text = "CV" Then
            Session("fgid") = "31"
        ElseIf CMbDepartment.Text = "Ferrite Magnet" Then
            Session("fgid") = "42"
        ElseIf CMbDepartment.Text = "Ferrite Sheet" Then
            Session("fgid") = "43"
        End If
    End Sub

    Protected Sub ImageButton1_Click(ByVal sender As System.Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles ImageButton1.Click
        Response.Redirect("RegisterMouldName.aspx")
    End Sub
End Class