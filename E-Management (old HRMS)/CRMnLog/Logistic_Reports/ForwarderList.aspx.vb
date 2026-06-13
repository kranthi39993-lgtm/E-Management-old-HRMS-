Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.Shared
Imports E_Management.[Global]

Partial Class ForwarderList
    Inherits System.Web.UI.Page
    Dim crReportDocument As forwarderslistrpt
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
        InitializeComponent()

        crReportDocument = New forwarderslistrpt

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
        If IsPostBack = False Then
            CrystalReportViewer1.ReportSource = crReportDocument
        End If


    End Sub

    Public Sub DoCRLogin(ByRef oRpt As CrystalDecisions.CrystalReports.Engine.ReportDocument)
        Dim _applyLogin As New ApplyCRLogin_Fwd

        _applyLogin._dbName = "mmcrm"
        _applyLogin._ServerName = "192.168.0.241"
        _applyLogin._userID = "sa"
        _applyLogin._PassWord = ""
        _applyLogin.ApplyInfo(oRpt)

        'clean up
        ' _applyLogin = Nothing

    End Sub

#End Region

    Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load, Me.Load
        'Put user code to initialize the page here
        If IsPostBack = False Then
            LoadForwarderType()
        End If

    End Sub


    Private Sub LoadForwarderType()
        Try
            Dim mynet As New CRMlognetglobal
            mynet.db_cn()
            mynet.db_open()
            TmpDs = New DataSet()

            TmpDs = mynet.ForwarderType(mynet.dbConnWeb, mynet.daConnWeb)

            CmbForwarderType.Items.Clear()

            For TmpI As Integer = 0 To TmpDs.Tables(0).Rows.Count - 1
                CmbForwarderType.Items.Add(TmpDs.Tables(0).Rows(TmpI).Item(0))
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
            TmpDs = mynet.ForwarderDetailsBasedOnType(mynet.dbConnWeb, mynet.daConnWeb, CmbForwarderType.Text)

            Dim Str As String = Server.MapPath("ForwardersListRpt.rpt")
            Cr.Load(Str)

            Cr.SetDataSource(TmpDs.Tables(0))

            CrystalReportViewer1.ReportSource = Cr

            CrystalReportViewer1.RefreshReport()

            CrystalReportViewer1.Visible = True

        Catch ex As Exception

        End Try
    End Sub


    Protected Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        Try
            LoadReport1()
            Cr.PrintToPrinter(1, True, 1, TmpDs.Tables(0).Rows.Count)
        Catch ex As Exception

        End Try
        
    End Sub

    Protected Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
        Try
            LoadReport1()
            Cr.ExportToDisk(ExportFormatType.Excel, "\\192.168.0.242\\temp\\Logistic_Report\\ForwarderList.xls")
            Label1.Text = "Successfully Exported, Please Check Given Location F:\\Temp\\Logistic_Report\\ForwarderList.xls"
        Catch ex As Exception
            Label1.Text = "Please Provide Criteria Value"
        End Try
    End Sub
End Class

Public Class ApplyCRLogin_Fwd
    Public _dbName As String
    Public _ServerName As String
    Public _UserId As String
    Public _PassWord As String


    Public Sub ApplyInfo(ByRef _oRpt As CrystalDecisions.CrystalReports.Engine.ReportDocument)

        Dim oCRDb As CrystalDecisions.CrystalReports.Engine.Database = _oRpt.Database
        Dim oCRTables As CrystalDecisions.CrystalReports.Engine.Tables = oCRDb.Tables
        Dim oCRTable As CrystalDecisions.CrystalReports.Engine.Table
        Dim oCRTableLogOnInfo As CrystalDecisions.Shared.TableLogOnInfo
        Dim oCRConnectionInfo As New CrystalDecisions.Shared.ConnectionInfo
        oCRConnectionInfo.DatabaseName = _dbName
        oCRConnectionInfo.ServerName = _ServerName
        oCRConnectionInfo.UserID = _UserId
        oCRConnectionInfo.Password = _PassWord
        For Each oCRTable In oCRTables
            oCRTableLogOnInfo = oCRTable.LogOnInfo
            oCRTableLogOnInfo.ConnectionInfo = oCRConnectionInfo
            oCRTable.ApplyLogOnInfo(oCRTableLogOnInfo)
        Next

    End Sub
End Class

