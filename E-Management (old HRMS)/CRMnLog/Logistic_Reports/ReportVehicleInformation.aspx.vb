Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.Shared
Imports E_Management.[Global]

Partial Public Class ReportVehicleInformation
    Inherits System.Web.UI.Page

 
    Dim crReportDocument As Report_VehicleInformation
    Dim crDatabase As Database
    Dim crTables As Tables
    Dim crTable As Table
    Dim crTableLogOnInfo As TableLogOnInfo
    Dim crConnectionInfo As ConnectionInfo
    Dim TmpDs As New DataSet
    Dim Cr As New ReportDocument
    Dim Stat As Integer

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

            crReportDocument = New Report_VehicleInformation

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
            LoadCombo()

        End If
    End Sub

    Private Sub LoadCombo()
        Try
            Dim mynet As New CRMlognetglobal
            mynet.db_cn()
            mynet.db_open()
            TmpDs = New DataSet()

            TmpDs = mynet.VehicleInfo(mynet.dbConnWeb, mynet.daConnWeb, 1)

            CmbVehicleType.Items.Clear()

            For TmpI As Integer = 0 To TmpDs.Tables(0).Rows.Count - 1
                CmbVehicleType.Items.Add(TmpDs.Tables(0).Rows(TmpI).Item(0))
            Next

            TmpDs = New DataSet()

            TmpDs = mynet.VehicleInfo(mynet.dbConnWeb, mynet.daConnWeb, 2)

            CmbTName.Items.Clear()

            For TmpI As Integer = 0 To TmpDs.Tables(0).Rows.Count - 1
                CmbTName.Items.Add(TmpDs.Tables(0).Rows(TmpI).Item(0))
            Next

          
            TmpDs = New DataSet()

            TmpDs = mynet.VehicleInfo(mynet.dbConnWeb, mynet.daConnWeb, 3)

            CmbAPlace.Items.Clear()

            For TmpI As Integer = 0 To TmpDs.Tables(0).Rows.Count - 1
                CmbAPlace.Items.Add(TmpDs.Tables(0).Rows(TmpI).Item(0))
            Next

        Catch ex As Exception

        End Try
    End Sub


    Protected Sub ImageButton1_Click(ByVal sender As System.Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles ImageButton1.Click
        Response.Redirect("../../HRMIS/Default.aspx")
    End Sub

    Protected Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Stat = 1
        LoadReport1()

    End Sub


    Private Sub LoadReport1()
        Try
            Dim Str1 As String

            If Stat = 1 Then
                Str1 = CmbVehicleType.Text
            ElseIf Stat = 2 Then
                Str1 = CmbTName.Text
            ElseIf Stat = 3 Then
                Str1 = CmbAPlace.Text
            End If

            Dim mynet As New CRMlognetglobal
            mynet.db_cn()
            mynet.db_open()
            TmpDs = New DataSet()
            TmpDs = mynet.VehicleInfoByVehicleType(mynet.dbConnWeb, mynet.daConnWeb, Str1, Stat)

            Dim Str As String = Server.MapPath("Report_VehicleInformation.rpt")
            Cr.Load(Str)

            Cr.SetDataSource(TmpDs.Tables(0))

            CrystalReportViewer1.ReportSource = Cr

            CrystalReportViewer1.RefreshReport()

            CrystalReportViewer1.Visible = True

        Catch ex As Exception

        End Try
    End Sub

    Protected Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
        Stat = 2
        LoadReport1()

    End Sub

    Protected Sub Button5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button5.Click
        Stat = 3
        LoadReport1()

    End Sub

    Protected Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        Stat = 1
        LoadReport1()
        Cr.PrintToPrinter(1, True, 1, TmpDs.Tables(0).Rows.Count)

    End Sub

    Protected Sub Button4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button4.Click
        Stat = 2
        LoadReport1()

        Cr.PrintToPrinter(1, True, 1, TmpDs.Tables(0).Rows.Count)

    End Sub

    Protected Sub Button6_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button6.Click
        Stat = 3
        LoadReport1()
        Cr.PrintToPrinter(1, True, 1, TmpDs.Tables(0).Rows.Count)

    End Sub

    Protected Sub Button7_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button7.Click
        Try
            Stat = 3
            LoadReport1()
            Cr.ExportToDisk(ExportFormatType.Excel, "\\192.168.0.242\\temp\\Logistic_Report\\VehicleInfo3.xls")
            Label1.Text = "Successfully Exported, Please Check Given Location F:\\Temp\\Logistic_Report\\VehicleInfo3.xls"

        Catch ex As Exception
            Label1.Text = "Please Provide Valid Criteria Value"
        End Try
    End Sub

    Protected Sub Button8_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button8.Click
        Try
            Stat = 2
            LoadReport1()
            Cr.ExportToDisk(ExportFormatType.Excel, "\\192.168.0.242\\temp\\Logistic_Report\\VehicleInfo2.xls")
            Label2.Text = "Successfully Exported, Please Check Given Location F:\\Temp\\Logistic_Report\\VehicleInfo2.xls"

        Catch ex As Exception
            Label2.Text = "Please Provide Criteria Value"
        End Try
    End Sub

    Protected Sub Button9_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button9.Click
        Try
            Stat = 1
            LoadReport1()
            Cr.ExportToDisk(ExportFormatType.Excel, "\\192.168.0.242\\temp\\Logistic_Report\\VehicleInfo1.xls")
            Label3.Text = "Successfully Exported, Please Check Given Location F:\\Temp\\Logistic_Report\\VehicleInfo1.xls"

        Catch ex As Exception
            Label3.Text = "Please Provide Criteria Value"
        End Try
    End Sub
End Class