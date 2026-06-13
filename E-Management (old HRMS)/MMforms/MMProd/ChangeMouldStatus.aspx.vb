Imports System.Data
Imports System
Imports System.Globalization
Imports System.Data.SqlClient
Imports e_management.emanagement.globalinfo
Imports e_management.emanagement.EMSapplications
Imports e_management.emanagement.NetGlobal
Imports System.Web.Security

Partial Public Class ChangeMouldStatus
    Inherits System.Web.UI.Page

    Dim mynet As New emanagement.netglobal
    Dim mywhoreq
    Dim myappno


    Protected Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Me.Load
        If IsPostBack = False Then
            With CmbDepartment.Items
                .Add("-Select-")
                .Add("Substrate")
                .Add("TPH")
                .Add("CV")
                .Add("Ferrite Magnet")
            End With
        End If

    End Sub

    Protected Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        If CmbDepartment.Text = "-Select-" Then
            LblMsg.Text = "Please Select Department"
            LblMsg.ForeColor = Drawing.Color.Red
            Exit Sub
        Else
            LblMsg.Text = ""
            LblMsg.ForeColor = Drawing.Color.Green
        End If

        If CmbDepartment.Text = "Substrate" Then
            Session("fgid") = "21"
        ElseIf CmbDepartment.Text = "TPH" Then
            Session("fgid") = "71"
        ElseIf CmbDepartment.Text = "CV" Then
            Session("fgid") = "31"
        ElseIf CmbDepartment.Text = "Ferrite Magnet" Then
            Session("fgid") = "42"
        ElseIf CmbDepartment.Text = "Ferrite Sheet" Then
            Session("fgid") = "43"
        End If

        GridView1.DataBind()
        Dim i As Integer

        For i = 0 To GridView1.Rows.Count - 1

            Dim ExpDt1 = DirectCast(GridView1.Rows(i).FindControl("TxtExpDate"), TextBox)
            ExpDt1.Text = DateTime.Today.ToString("dd/MM/yyyy")

            Dim MNo = DirectCast(GridView1.Rows(i).FindControl("TxtMouldNo"), TextBox)

            Dim MouldNo = GridView1.Rows(i).Cells(4).Text
            MNo.Text = MouldNo

            Dim PrsLmt = DirectCast(GridView1.Rows(i).FindControl("TxtPressLimit"), TextBox)
            PrsLmt.Text = GridView1.Rows(i).Cells(6).Text

        Next
    End Sub

    Protected Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
        Dim Product As String = ""
        Dim MouldName As String = ""
        Dim Uid As Integer


        Dim i = 0
        For i = 0 To GridView1.Rows.Count - 1
            LblMsg.Text = ""
            Dim cbcell = DirectCast(GridView1.Rows(i).FindControl("ChkBxSelect"), CheckBox)
            Dim MSts = DirectCast(GridView1.Rows(i).FindControl("CmbMouldStatus"), DropDownList)
            Dim ExDt = DirectCast(GridView1.Rows(i).FindControl("TxtExpDate"), TextBox)
            Dim MouldNo = DirectCast(GridView1.Rows(i).FindControl("TxtMouldNo"), TextBox)
            Dim PrsLmt1 = DirectCast(GridView1.Rows(i).FindControl("TxtPressLimit"), TextBox)

            If cbcell.checked = True Then
                Uid = GridView1.Rows(i).Cells(1).Text
                Product = GridView1.Rows(i).Cells(2).Text
                MouldName = GridView1.Rows(i).Cells(3).Text


                Try
                    mynet.db_cn()
                    mynet.dbM_open()

                    If MSts.Text = "A" Then

                        If MSts.Text = "-Select-" Then
                            LblMsg.Text = "Please Select Valid Status"
                            LblMsg.ForeColor = Drawing.Color.Red
                            Exit Sub
                        End If

                    Else

                        If MSts.Text = "-Select-" Or ExDt.Text = "" Then
                            LblMsg.Text = "Please Select Valid Status and Enter Valid Expected Date"
                            LblMsg.ForeColor = Drawing.Color.Red
                            Exit Sub
                        End If

                    End If
                    Call mynet.Update_MMSmaster_status(dbConnWeb, daConnWeb, 2, "update mouldmaster set PressLimit='" & PrsLmt1.Text & "', status='" & MSts.Text & "', MouldNo='" & MouldNo.Text & "', Modifiedby='" & Session("empcode") & "',MDate='" & DateTime.Now & "' where product='" & Product & "' and UID=" & Uid & " and MouldName='" & MouldName & "' and FGID='" & Session("fgid") & "'")
                    Call mynet.Update_MMSmaster_status(dbConnWeb, daConnWeb, 2, "Insert Into MouldStatusHistory(FGID, Product, MouldName, MouldNo, Status, ExpectedDate, CreatedBy, CreatedOn,PressLimit) Values('" & Session("fgid") & "','" & Product & "','" & MouldName & "','" & MouldNo.Text & "','" & MSts.Text & "','" & ExDt.Text & "','" & Session("empcode") & "','" & DateTime.Now & "'," & PrsLmt1.Text & ")")

                    Call mynet.dbSp_close()
                    LblMsg.Text = "Saved successfully"
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


        Dim MouldNo1 As String

        For i = 0 To GridView1.Rows.Count - 1

            Dim ExpDt1 = DirectCast(GridView1.Rows(i).FindControl("TxtExpDate"), TextBox)
            ExpDt1.Text = DateTime.Today.ToString("dd/MM/yyyy")

            Dim MNo = DirectCast(GridView1.Rows(i).FindControl("TxtMouldNo"), TextBox)
            MouldNo1 = GridView1.Rows(i).Cells(4).Text
            MNo.Text = MouldNo1

            Dim PrsLmt = DirectCast(GridView1.Rows(i).FindControl("TxtPressLimit"), TextBox)
            PrsLmt.Text = GridView1.Rows(i).Cells(6).Text

        Next
    End Sub

    Protected Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        If CmbDepartment.Text = "-Select-" Then
            LblMsg.Text = "Please Select Department"
            LblMsg.ForeColor = Drawing.Color.Red
            Exit Sub
        Else
            LblMsg.Text = ""
            LblMsg.ForeColor = Drawing.Color.Green
        End If

        GridView1.DataBind()

        Dim i As Integer

        For i = 0 To GridView1.Rows.Count - 1

            Dim ExpDt1 = DirectCast(GridView1.Rows(i).FindControl("TxtExpDate"), TextBox)
            ExpDt1.Text = DateTime.Today.ToString("dd/MM/yyyy")


            Dim MNo = DirectCast(GridView1.Rows(i).FindControl("TxtMouldNo"), TextBox)
            Dim MouldNo = GridView1.Rows(i).Cells(4).Text

            MNo.Text = MouldNo

            Dim PrsLmt = DirectCast(GridView1.Rows(i).FindControl("TxtPressLimit"), TextBox)
            PrsLmt.Text = GridView1.Rows(i).Cells(6).Text

        Next
    End Sub
End Class