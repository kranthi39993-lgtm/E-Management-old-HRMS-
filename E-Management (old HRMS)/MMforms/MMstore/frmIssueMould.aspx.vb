Imports System.Data
Imports System
Imports System.Globalization
Imports System.Data.SqlClient
Imports e_management.emanagement.globalinfo
Imports e_management.emanagement.EMSapplications
Imports e_management.emanagement.NetGlobal
Imports System.Web.Security
Partial Public Class frmIssueMould
    Inherits System.Web.UI.Page
    Dim mynet As New emanagement.netglobal
    Dim mywhoreq
    Dim myappno
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

    End Sub

    Protected Sub BtnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnSave.Click
        Dim i = 0
        For i = 0 To GridView1.Rows.Count - 1
            LblMsg.Text = ""
            Dim cbcell = DirectCast(GridView1.Rows(i).FindControl("checkbox1"), CheckBox)
            If cbcell.checked = True Then
                'Dim rd1cell = DirectCast(GridView1.Rows(i).FindControl("radiobutton1"), RadioButton)
                'If rd1cell.checked = True Then
                '    mywhoreq = "by Company"
                'End If
                'Dim rd2cell = DirectCast(GridView1.Rows(i).FindControl("radiobutton2"), RadioButton)
                'If rd2cell.checked = True Then
                '    mywhoreq = "by Employee"
                'End If

                myappno = GridView1.Rows(i).Cells(1).Text
                Try
                    mynet.db_cn()
                    mynet.dbM_open()
                    Call mynet.Update_MouldRequest_status(dbConnWeb, daConnWeb, 2, "update mouldrequest set status='I' , issueddate= '" & Now & "', issuedby='" & Session("empcode") & "' where product='" & GridView1.Rows(i).Cells(2).Text & "' and mouldno='" & GridView1.Rows(i).Cells(3).Text & "'")
                    Call mynet.Update_MMSmaster_status(dbConnWeb, daConnWeb, 2, "update mouldmaster set status='P' , pressMC = '" & GridView1.Rows(i).Cells(4).Text & "' where product='" & GridView1.Rows(i).Cells(2).Text & "' and mouldno='" & GridView1.Rows(i).Cells(3).Text & "'")
                    'Call mynet.dbSp_open("SP_InsUpdApLapplicationCA")
                    'Command.Parameters.AddWithValue("@requestid", myappno)
                    'Command.ExecuteNonQuery()
                    Call mynet.dbSp_close()
                    LblMsg.Text = "saved successfully"
                    LblMsg.ForeColor = Drawing.Color.Green
                    mynet.dbM_close()
                Catch ex As Exception
                    LblMsg.Text = ex.Message
                    LblMsg.ForeColor = Drawing.Color.Red
                    Exit Sub
                End Try
            End If
        Next
        GridView1.DataBind()
    End Sub
End Class