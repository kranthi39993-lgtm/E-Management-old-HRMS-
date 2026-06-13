Public Partial Class MouldStatusAlert
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

    
    Protected Sub CmbDepartment_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CmbDepartment.SelectedIndexChanged
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

        Dim i As Integer
        For i = 0 To GridView1.Rows.Count - 1
            If GridView1.Rows(i).Cells(7).Text = "Insufficient" Then
                GridView1.Rows(i).Cells(7).BackColor = Drawing.Color.Red
                GridView1.Rows(i).Cells(7).ForeColor = Drawing.Color.White
            Else
                GridView1.Rows(i).Cells(7).BackColor = Drawing.Color.Green
                GridView1.Rows(i).Cells(7).ForeColor = Drawing.Color.White
            End If

        Next


    End Sub
End Class