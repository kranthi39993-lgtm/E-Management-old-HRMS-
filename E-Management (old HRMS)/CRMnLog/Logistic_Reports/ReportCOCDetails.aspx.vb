Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.Shared
Imports E_Management.[Global]
Imports System.Text.RegularExpressions
Imports System.Data.SqlClient
Imports System.Data.DataView
Imports System.Web.Security

Partial Public Class ReportCOCDetails
    Inherits Messagebox
    Dim crReportDocument As Report_COCDetails
    Dim crDatabase As Database
    Dim crTables As Tables
    Dim crTable As Table
    Dim crTableLogOnInfo As TableLogOnInfo
    Dim crConnectionInfo As ConnectionInfo
    Dim Cr As New ReportDocument
    Dim TmpDs As New DataSet
#Region " Web Form Designer Generated Code "

    'This call is required by the Web Form Designer.
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()

    End Sub

    'NOTE: The following placeholder declaration is required by the Web Form Designer.
    'Do not delete or move it.
    Private designerPlaceholderDeclaration As System.Object

    Private Sub Page_Init(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Init
        'CODEGEN: This method call is required by the Web Form Designer
        'Do not modify it using the code editor.
        If IsPostBack = False Then
            InitializeComponent()

            crReportDocument = New Report_COCDetails

            crConnectionInfo = New ConnectionInfo

            With crConnectionInfo
                .ServerName = "192.168.0.241"
                .DatabaseName = "mmCRM"
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

            'crReportDocument.SetDatabaseLogon("sa", "Admin")
            'Once the connection to the database has been established for
            'each table in the report, the report object can be bound to the viewer
            'using the reportsource property of the viewer to display the report.

            'DoCRLogin(crReportDocument)

            CrystalReportViewer1.ReportSource = crReportDocument

        End If

    End Sub

    Public Sub DoCRLogin(ByRef oRpt As CrystalDecisions.CrystalReports.Engine.ReportDocument)
        Dim _applyLogin As New ApplyCRLogin_Fwd

        _applyLogin._dbName = "mmcrm"
        _applyLogin._ServerName = "192.168.0.241"
        _applyLogin._UserId = "sa"
        _applyLogin._PassWord = ""
        _applyLogin.ApplyInfo(oRpt)

        'clean up
        ' _applyLogin = Nothing

    End Sub

#End Region

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If IsPostBack = False Then

            Dim Ad1 As New SqlDataAdapter
            Dim Cmd As New SqlCommand
            Dim TmpDs As New DataSet

            Dim ob As New CRMlognetglobal()
            Dim conStr1 As String
            ob.db_cn()
            conStr1 = ob.sConnString

            Dim con1 As New SqlConnection(conStr1)
            con1.Open()

            Cmd = New SqlCommand("Select Distinct ApprovalStatus From Log_COCSubmission", con1)
            Ad1 = New SqlDataAdapter(Cmd)
            TmpDs = New DataSet
            Ad1.Fill(TmpDs, "Tmp")
            CmbApprovalStatus.Items.Clear()
            CmbApprovalStatus.Items.Add("-Select-")
            For Tmpi As Integer = 0 To TmpDs.Tables(0).Rows.Count - 1
                CmbApprovalStatus.Items.Add(TmpDs.Tables(0).Rows(Tmpi).Item(0))
            Next
        End If
    End Sub

    Protected Sub ImageButton1_Click(ByVal sender As System.Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles ImageButton1.Click
        If Calendar1.Visible = False Then
            Calendar1.Visible = True
        Else
            Calendar1.Visible = False
        End If
    End Sub

    Protected Sub ImageButton2_Click(ByVal sender As System.Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles ImageButton2.Click
        If Calendar2.Visible = False Then
            Calendar2.Visible = True
        Else
            Calendar2.Visible = False
        End If
    End Sub

    Protected Sub Calendar1_SelectionChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Calendar1.SelectionChanged
        Dim s = Calendar1.SelectedDate
        's = Format(Calendar1.SelectedDate, "dd/mm/yyyy")
        s = Format(Convert.ToDateTime(Calendar1.SelectedDate), "MM/dd/yyyy")
        TxtFrom.Text = s
        Calendar1.Visible = False

    End Sub

    Protected Sub Calendar2_SelectionChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Calendar2.SelectionChanged
        Dim s = Calendar2.SelectedDate
        's = Format(Calendar1.SelectedDate, "dd/mm/yyyy")
        s = Format(Convert.ToDateTime(Calendar2.SelectedDate), "MM/dd/yyyy")
        TxtTo.Text = s
        Calendar2.Visible = False
        Label1.Text = "COC Status From " & Format(Convert.ToDateTime(Calendar1.SelectedDate), "dd/MM/yyyy") & " To " & Format(Convert.ToDateTime(Calendar2.SelectedDate), "dd/MM/yyyy")

    End Sub

    Protected Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        If TxtFrom.Text.Trim.Equals("") Or TxtTo.Text.Trim.Equals("") Then
            Exit Sub
        End If

        LoadReport()

    End Sub

    Private Sub LoadReport()
        Try

            Dim Ad1 As New SqlDataAdapter
            Dim Cmd As New SqlCommand
            Dim TmpDs As New DataSet

            Dim ob As New CRMlognetglobal()
            Dim conStr1 As String
            ob.db_cn()
            conStr1 = ob.sConnString

            Dim con1 As New SqlConnection(conStr1)
            con1.Open()


            Dim Dt1 As Date = TxtFrom.Text
            Dim Dt2 As Date = TxtTo.Text

            TmpDs = New DataSet()
            Cmd = New SqlCommand("SELECT InvoiceNo, InvoiceDate, Department, SubmittedOn, SubmittedBy, SDocumentNo, ReSubmittedOn, RejectedOn, ApprovedOn, ApprovalStatus, ADocumentNo, Remarks FROM Log_COCSubmission WHERE Createdon BETWEEN '" & Dt1 & "' AND '" & Dt2 & "'", con1)
            Ad1 = New SqlDataAdapter(Cmd)
            Ad1.Fill(TmpDs, "Tmp")




            Dim Str As String = Server.MapPath("Report_COCDetails.rpt")
            Cr.Load(Str)

            Cr.SetDataSource(TmpDs.Tables(0))

            CrystalReportViewer1.ReportSource = Cr

            CrystalReportViewer1.RefreshReport()

            CrystalReportViewer1.Visible = True
            con1.Close()
        Catch ex As Exception

        End Try
    End Sub


    Private Sub LoadReport1()
        Try

            If TxtFrom.Text = "" Or TxtTo.Text = "" Or CmbApprovalStatus.Text = "-Select-" Then
                msg("Please Select Valid Date and Status")
                Exit Sub
            End If

            Dim Ad1 As New SqlDataAdapter
            Dim Cmd As New SqlCommand
            Dim TmpDs As New DataSet

            Dim ob As New CRMlognetglobal()
            Dim conStr1 As String
            ob.db_cn()
            conStr1 = ob.sConnString

            Dim con1 As New SqlConnection(conStr1)
            con1.Open()


            Dim Dt1 As Date = TxtFrom.Text
            Dim Dt2 As Date = TxtTo.Text

            TmpDs = New DataSet()
            Cmd = New SqlCommand("SELECT InvoiceNo, InvoiceDate, Department, SubmittedOn, SubmittedBy, SDocumentNo, ReSubmittedOn, RejectedOn, ApprovedOn, ApprovalStatus, ADocumentNo, Remarks FROM Log_COCSubmission WHERE Createdon BETWEEN '" & Dt1 & "' AND '" & Dt2 & "' AND ApprovalStatus='" & CmbApprovalStatus.Text & "'", con1)
            Ad1 = New SqlDataAdapter(Cmd)
            Ad1.Fill(TmpDs, "Tmp")

            Dim Str As String = Server.MapPath("Report_COCDetails.rpt")
            Cr.Load(Str)

            Cr.SetDataSource(TmpDs.Tables(0))

            CrystalReportViewer1.ReportSource = Cr

            CrystalReportViewer1.RefreshReport()

            CrystalReportViewer1.Visible = True
            con1.Close()
        Catch ex As Exception

        End Try
    End Sub

    Protected Sub ImageButton3_Click(ByVal sender As System.Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles ImageButton3.Click
        Response.Redirect("../../HRMIS/Default.aspx")
    End Sub

    Protected Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        LoadReport1()
    End Sub

    Protected Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
        Try
            LoadReport()
            Cr.ExportToDisk(ExportFormatType.Excel, "\\192.168.0.242\\temp\\Logistic_Report\\COCDetailsBydate.xls")
            Label2.Text = "Successfully Exported, Please Check Given Location F:\\Temp\\Logistic_Report\\COCDetailsBydate.xls"

        Catch ex As Exception
            Label2.Text = "Please Provide Criteria Value"
        End Try
    End Sub

    Protected Sub Button4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button4.Click
        Try
            LoadReport1()
            Cr.ExportToDisk(ExportFormatType.Excel, "\\192.168.0.242\\temp\\Logistic_Report\\COCDetailsByStatusandDate.xls")
            Label2.Text = "Successfully Exported, Please Check Given Location F:\\Temp\\Logistic_Report\\COCDetailsStatusandDate.xls"

        Catch ex As Exception
            Label2.Text = "Please Provide Criteria Value"
        End Try
    End Sub
End Class