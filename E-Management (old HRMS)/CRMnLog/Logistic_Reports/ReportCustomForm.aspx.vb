Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.Shared
Imports E_Management.[Global]

Imports System.Text.RegularExpressions
Imports System.Data.SqlClient
Imports System.Data.DataView
Imports System.Web.Security

Partial Public Class ReportCustomForm
    Inherits Messagebox
    Dim crReportDocument As Report_CustomForm
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

            crReportDocument = New Report_CustomForm

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
    
        
    End Sub

    Protected Sub ImageButton1_Click(ByVal sender As System.Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles ImageButton1.Click
        Response.Redirect("../../HRMIS/Default.aspx")
    End Sub

    Protected Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        If TxtFrom.Text.Trim.Equals("") Or TxtTo.Text.Trim.Equals("") Then
            Exit Sub
        End If

        LoadReport()

    End Sub

    Private Sub LoadReport()
        Try
            Dim mynet As New CRMlognetglobal
            mynet.db_cn()
            mynet.db_open()

            Dim Dt1 As Date = TxtFrom.Text
            Dim Dt2 As Date = TxtTo.Text

            TmpDs = New DataSet()
            TmpDs = mynet.CustomReportFun(mynet.dbConnWeb, mynet.daConnWeb, Dt1, Dt2)

            Dim Str As String = Server.MapPath("Report_CustomForm.rpt")
            Cr.Load(Str)

            Cr.SetDataSource(TmpDs.Tables(0))

            CrystalReportViewer1.ReportSource = Cr

            CrystalReportViewer1.RefreshReport()

            CrystalReportViewer1.Visible = True

        Catch ex As Exception

        End Try
    End Sub




    'Protected Sub Calendar1_SelectionChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Calendar1.SelectionChanged
    '    Dim s = Calendar1.SelectedDate
    '    's = Format(Calendar1.SelectedDate, "dd/mm/yyyy")
    '    s = Format(Convert.ToDateTime(Calendar1.SelectedDate), "dd/MM/yy")
    '    TxtFrom.Text = s
    '    Calendar1.Visible = False
    'End Sub

    Protected Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
     
        Try
            LoadReport()

            Cr.PrintToPrinter(1, True, 1, TmpDs.Tables(0).Rows.Count)

        Catch ex As Exception

        End Try
    End Sub

    Protected Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
        Try
            LoadReport()
            Cr.ExportToDisk(ExportFormatType.Excel, "\\192.168.0.242\\temp\\Logistic_Report\\Custom.xls")
            Label3.Text = "Successfully Exported, Please Check Given Location  F:\\Temp\\Logistic_Report\\Custom.xls"

        Catch ex As Exception

        End Try
        

    End Sub

    Protected Sub ImageButton2_Click(ByVal sender As System.Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles ImageButton2.Click
        If Calendar1.Visible = False Then
            Calendar1.Visible = True
        Else
            Calendar1.Visible = False
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
    End Sub

    Protected Sub ImageButton3_Click(ByVal sender As System.Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles ImageButton3.Click
        If Calendar2.Visible = False Then
            Calendar2.Visible = True
        Else
            Calendar2.Visible = False
        End If
    End Sub
End Class