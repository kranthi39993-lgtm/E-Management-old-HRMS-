Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.Shared
Imports E_Management.[Global]

Partial Public Class ReportProductWeight
    Inherits System.Web.UI.Page

    Dim crReportDocument As Report_WeightRegistration
    Dim crDatabase As Database
    Dim crTables As Tables
    Dim crTable As Table
    Dim crTableLogOnInfo As TableLogOnInfo
    Dim crConnectionInfo As ConnectionInfo
    Dim TmpDs As New DataSet
    Dim Cr As New ReportDocument

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

            crReportDocument = New Report_WeightRegistration

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
            LoadDepartment()

        End If
    End Sub

    Private Sub LoadDepartment()
        Try
            Dim mynet As New CRMlognetglobal
            mynet.db_cn()
            mynet.db_open()

            TmpDs = New DataSet()
            TmpDs = mynet.DeptFromWeightReg(mynet.dbConnWeb, mynet.daConnWeb)

            CmbDept.Items.Clear()

            For TmpI As Integer = 0 To TmpDs.Tables(0).Rows.Count - 1
                CmbDept.Items.Add(TmpDs.Tables(0).Rows(TmpI).Item(0))
            Next

        Catch ex As Exception

        End Try
    End Sub

    Protected Sub ImageButton1_Click(ByVal sender As System.Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles ImageButton1.Click
        Response.Redirect("../../HRMIS/Default.aspx")
    End Sub

    Protected Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        LoadReport1()
    End Sub

    Private Sub LoadReport1()
        Try
            Dim mynet As New CRMlognetglobal
            mynet.db_cn()
            mynet.db_open()
            TmpDs = New DataSet()
            TmpDs = mynet.WeightInfoBasedDept(mynet.dbConnWeb, mynet.daConnWeb, CmbDept.Text)

            Dim Str As String = Server.MapPath("Report_WeightRegistration.rpt")
            Cr.Load(Str)

            Cr.SetDataSource(TmpDs.Tables(0))

            CrystalReportViewer1.ReportSource = Cr

            CrystalReportViewer1.RefreshReport()

            CrystalReportViewer1.Visible = True

        Catch ex As Exception

        End Try
    End Sub

    Protected Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        LoadReport1()
        Cr.PrintToPrinter(1, True, 1, TmpDs.Tables(0).Rows.Count)
    End Sub
End Class