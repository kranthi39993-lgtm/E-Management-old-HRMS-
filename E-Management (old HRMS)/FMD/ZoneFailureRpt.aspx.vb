Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.Shared
Partial Public Class ZoneFailureRpt
    Inherits System.Web.UI.Page
    Dim MyGlobal As New Emanagement.globalinfo
    Dim MyApp As New Emanagement.EMSapplications
    Dim rptby, status, dept As String

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        CrystalReportViewer1.DataBind()
        CrystalReportViewer1.RefreshReport()
        Dim fromd As String = Session("allfromd")
        Dim tod As String = Session("alltod")
        rptby = Session("mcno")
        CrystalReportSource1.ReportDocument.RecordSelectionFormula = "{Fir_temperaturecheck.McNo} = '" & rptby & "' and {Fir_temperaturecheck.entrydate} >= datetime('" & fromd & "')  And {Fir_temperaturecheck.entrydate} <= datetime('" & tod & "') And {Fir_temperaturecheck.status} = 'NG'"

    End Sub


End Class