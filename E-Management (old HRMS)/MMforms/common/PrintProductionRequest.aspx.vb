Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.Web
Imports CrystalDecisions.Shared
Imports E_Management.[Global]
Imports System.IO
Imports System
Imports System.Data.SqlClient
Imports System.Data
Imports System.Net.Mail
Imports System.Net.Security

Partial Public Class PrintProductionRequest
    Inherits System.Web.UI.Page

    Dim crReportDocument
    Dim crDatabase As Database
    Dim crTables As Tables
    Dim crTable As Table
    Dim crTableLogOnInfo As TableLogOnInfo
    Dim crConnectionInfo As ConnectionInfo
    Dim TmpDs As New DataSet
    Dim Cr As New ReportDocument
    Dim crDiskFileDestinationOptions As DiskFileDestinationOptions
    Dim crExportOptions As ExportOptions

    Dim SaveRptname, saverptname1 As String
    Dim ExportPath, ExportPath1 As String

    Dim crParameterValues As ParameterValues
    Dim crParameterDiscreteValue As ParameterDiscreteValue
    Dim crParameterFieldDefinitions As ParameterFieldDefinitions
    Dim crParameterFieldDefinition As ParameterFieldDefinition


#Region " Web Form Designer Generated Code "

    'This call is required by the Web Form Designer.
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()

    End Sub

    'NOTE: The following placeholder declaration is required by the Web Form Designer.
    'Do not delete or move it.
    Private designerPlaceholderDeclaration As System.Object

    Private Sub Page_Init(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Init

        CallReport()

    End Sub

    Public Sub DoCRLogin(ByRef oRpt As CrystalDecisions.CrystalReports.Engine.ReportDocument)
        Dim _applyLogin As New ApplyCRLogin_Fwd

        _applyLogin._dbName = "MMaintenance"
        _applyLogin._ServerName = "192.168.0.248"
        _applyLogin._UserId = "sa"
        _applyLogin._PassWord = ""
        _applyLogin.ApplyInfo(oRpt)

    End Sub

#End Region

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

    End Sub


    Private Sub Loadreport1()
        Dim Str As String

        If Session("options").ToString = "production" Then
            crReportDocument = New PrintMouldRepairRequest
            Str = Server.MapPath("PrintMouldRepairRequest.rpt")
        ElseIf Session("options").ToString = "mould" Then
            crReportDocument = New PrintMouldRepairData
            Str = Server.MapPath("PrintMouldRepairData.rpt")
        End If



        Cr.Load(Str)

        Cr.SetDataSource(TmpDs.Tables(0))

        CrystalReportViewer1.ReportSource = Cr

        CrystalReportViewer1.RefreshReport()

        CrystalReportViewer1.Visible = True

    End Sub

    Private Sub CallReport()


        'CODEGEN: This method call is required by the Web Form Designer
        'Do not modify it using the code editor.

        If Session("options").ToString = "production" Then
            crReportDocument = New PrintMouldRepairRequest

        ElseIf Session("options").ToString = "mould" Then
            crReportDocument = New PrintMouldRepairData

        End If

        crConnectionInfo = New ConnectionInfo

        With crConnectionInfo
            .ServerName = "192.168.0.248"
            .DatabaseName = "MMaintenance"
            .UserID = "SA"
            .Password = ""
        End With

        'Get the tables collection from the report object
        crDatabase = crReportDocument.Database
        crTables = crDatabase.Tables
        'Apply the logon information to each table in the collection
        For Each crTable In crTables
            crTableLogOnInfo = crTable.LogOnInfo
            crTableLogOnInfo.ConnectionInfo = crConnectionInfo
            crTable.ApplyLogOnInfo(crTableLogOnInfo)
        Next

        'Dim myTextObjectOnReport As CrystalDecisions.CrystalReports.Engine.TextObject
        'myTextObjectOnReport = CType(crReportDocument.ReportDefinition.ReportObjects.Item("Text10"), CrystalDecisions.CrystalReports.Engine.TextObject)
        'myTextObjectOnReport.Text = "From: " & Session("from1") & " To: " & Convert.ToDateTime(Session("to1").ToString).AddDays(-1).ToString("dd-MMM-yyyy")

        'Dim D1 As New DateTime
        'D1 = Convert.ToDateTime(Session("to1").ToString())
        'D1 = D1.AddDays(-1)

        'myTextObjectOnReport = CType(crReportDocument.ReportDefinition.ReportObjects.Item("Text7"), CrystalDecisions.CrystalReports.Engine.TextObject)
        'myTextObjectOnReport.Text = "From  " & Session("from1").ToString & "  To  " & D1.ToString("dd-MMM-yyyy")

        'myTextObjectOnReport = CType(crReportDocument.ReportDefinition.ReportObjects.Item("Text9"), CrystalDecisions.CrystalReports.Engine.TextObject)
        'myTextObjectOnReport.Text = Session("msg").ToString

        crParameterFieldDefinitions = crReportDocument.DataDefinition.ParameterFields
        crParameterFieldDefinition = crParameterFieldDefinitions.Item(0)
        crParameterValues = crParameterFieldDefinition.CurrentValues
        crParameterValues.Clear()

        crParameterDiscreteValue = New ParameterDiscreteValue()
        crParameterDiscreteValue.Value = Session("reqno").ToString
        crParameterValues.Add(crParameterDiscreteValue)
        crParameterFieldDefinition.ApplyCurrentValues(crParameterValues)

        crParameterFieldDefinition = crParameterFieldDefinitions.Item(1)
        crParameterDiscreteValue = New ParameterDiscreteValue()
        crParameterDiscreteValue.Value = "BySLNO"
        crParameterValues.Add(crParameterDiscreteValue)
        crParameterFieldDefinition.ApplyCurrentValues(crParameterValues)

        'crParameterFieldDefinition = crParameterFieldDefinitions.Item(2)
        'crParameterDiscreteValue = New ParameterDiscreteValue()
        'crParameterDiscreteValue.Value = Session("MachineNo").ToString
        'crParameterValues.Add(crParameterDiscreteValue)
        'crParameterFieldDefinition.ApplyCurrentValues(crParameterValues)


        CrystalReportViewer1.ReportSource = crReportDocument

    End Sub


    Protected Sub LinkButton1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles LinkButton1.Click
        Response.Redirect(Session("purl").ToString)
    End Sub
End Class