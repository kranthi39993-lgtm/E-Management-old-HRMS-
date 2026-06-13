Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.Shared
Partial Public Class FiringReportsbyDept1
    Inherits System.Web.UI.Page
    Dim MyGlobal As New Emanagement.globalinfo
    Dim MyApp As New Emanagement.EMSapplications
    Dim rptby, status, dept As String

    Private Sub Page_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Init
        CrystalReportSource1.Report.FileName = "FiringReportsBydept.rpt"
        CrystalReportViewer1.ReportSourceID = CrystalReportSource1.ID
        CrystalReportViewer1.DataBind()
    End Sub

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        ' CrystalReportViewer1.RefreshReport()
        dept = Session("dept")
        CrystalReportSource1.ReportDocument.RecordSelectionFormula = "{Fir_FiringMcMaster.Department} = '" & dept & "'"
    End Sub

    Protected Sub ImageButton1_Click(ByVal sender As System.Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles ImageButton1.Click
        Response.Redirect("firingreports.aspx")
    End Sub
End Class