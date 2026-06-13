Imports System.Data
Imports System
Imports System.Globalization
Imports System.Data.SqlClient
Imports e_management.emanagement.globalinfo
Imports e_management.emanagement.EMSapplications
Imports e_management.emanagement.NetGlobal
Imports System.Web.Security

Partial Public Class IssueMould
    Inherits System.Web.UI.Page
    Dim mynet As New Emanagement.netglobal
    Dim mywhoreq
    Dim myappno
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        LblMName.Text = Session("mname")
        LblProduct.Text = Session("product")
        LblPressingMachine.Text = Session("pressingmc")
        LblDepartment.Text = Session("dept")
        If IsPostBack = False Then
            RadioButtonList1.DataBind()
        End If

    End Sub

    Protected Sub ImageButton1_Click(ByVal sender As System.Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles ImageButton1.Click
        Response.Redirect("EditRequestMould.aspx")
    End Sub

    Protected Sub RadioButtonList1_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RadioButtonList1.SelectedIndexChanged
        Session("mno") = RadioButtonList1.SelectedValue
    End Sub

    Protected Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click

        If LblDepartment.Text = "-Select-" Then
            LblMsg.Text = "Please Select Department from Previous Screen"
            LblMsg.ForeColor = Drawing.Color.Red
            Exit Sub
        Else
            LblMsg.Text = ""
            LblMsg.ForeColor = Drawing.Color.Green
        End If

        Dim MNo As String = Session("mno")

        'Try
        '    Dim I As Integer
        '    For I = 0 To RadioButtonList1.Items.Count - 1
        '        If RadioButtonList1.SelectedIndex = I Then
        '            MNo = RadioButtonList1.Items(I).Text
        '        End If
        '    Next
        'Catch ex As Exception

        'End Try
        'Exit Sub
        Try
            mynet.db_cn()
            mynet.dbM_open()

            Call mynet.Update_MouldRequest_status(dbConnWeb, daConnWeb, 2, "update mouldrequest set status='I' , MouldNo='" & MNo & "', issueddate= '" & Now & "', issuedby='" & Session("empcode") & "' where RecNo='" & Session("recno") & "'")
            Call mynet.Update_MMSmaster_status(dbConnWeb, daConnWeb, 2, "update mouldmaster set status='I' Where product='" & LblProduct.Text & "' and mouldname='" & LblMName.Text & "' and FGID='" & Session("fgid") & "' and MouldNo='" & MNo & "'")


            Call mynet.dbSp_close()
            LblMsg.Text = "Mould Issued"
            LblMsg.ForeColor = Drawing.Color.Green
            mynet.dbM_close()
            RadioButtonList1.DataBind()
        Catch ex As Exception
            LblMsg.Text = ex.Message
            LblMsg.ForeColor = Drawing.Color.Red
            Exit Sub
        End Try
    End Sub
End Class