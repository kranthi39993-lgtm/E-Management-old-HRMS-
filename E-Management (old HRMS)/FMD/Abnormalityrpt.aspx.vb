Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.Shared
Partial Public Class Abnormalityrpt
    Inherits System.Web.UI.Page
    Dim MyGlobal As New Emanagement.globalinfo
    Dim MyApp As New Emanagement.EMSapplications
    Dim rptby, rptby1, status, dept As String


    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        CrystalReportViewer1.DataBind()
        CrystalReportViewer1.RefreshReport()
        Dim fromd As String = Session("allfromd")
        Dim tod As String = Session("alltod")
        rptby = Session("mcno")
        fromdate.Text = Session("allfromd")
        Todate.Text = Session("alltod")


        'If rptby = "all" Then
        'CrystalReportSource1.ReportDocument.RecordSelectionFormula = "{Fir_smsoptimization.startdate} >= datetime('" & fromd & "')  And {Fir_smsoptimization.startdate} <= datetime('" & tod & "')"
        'Else
        CrystalReportSource1.ReportDocument.RecordSelectionFormula = "{Fir_smsoptimization.McNo} = '" & rptby & "' and {Fir_smsoptimization.startdate} >= datetime('" & fromd & "')  And {Fir_smsoptimization.startdate} <= datetime('" & tod & "')"
        'End If

    End Sub

End Class