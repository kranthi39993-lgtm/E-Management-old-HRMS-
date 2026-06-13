Public Partial Class FiringReports
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

    End Sub
    Protected Sub rdoptions_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rdoptions.SelectedIndexChanged
        If rdoptions.SelectedValue = "Dept" Then
            ddldeptr.Enabled = True
        Else
            ddldeptr.Enabled = False
        End If

    End Sub
    Protected Sub showrepOT_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles showrepOT.Click
        Dim rdvalue As String
        rdvalue = rdoptions.SelectedValue
        If rdoptions.SelectedValue = "Dept" Then

            Session("dept") = ddldeptr.SelectedValue.Trim
            'Session("Otstatus") = rdstatus.SelectedValue.Trim
            Response.Redirect("FiringReportsbyDept.aspx")
        Else
            Response.Redirect("FirReportsByAllDept.aspx")
        End If
    End Sub

End Class