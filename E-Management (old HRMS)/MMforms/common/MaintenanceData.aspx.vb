Imports System
Imports System.Data
Imports System.Globalization
Imports System.Data.SqlClient
Imports e_management.emanagement.globalinfo
Imports e_management.emanagement.EMSapplications
Imports e_management.emanagement.[Global]
Imports e_management.emanagement.NetGlobal
Imports System.Web.Security

Partial Public Class MaintenanceData
    Inherits System.Web.UI.Page

    Dim mynet As New Emanagement.netglobal
    Dim MyGlobal As New Emanagement.globalinfo
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If IsPostBack = False Then
            Dim mynet As New Emanagement.netglobal
            Dim MyGlobal As New Emanagement.globalinfo

            Dim Ad As SqlDataAdapter
            Dim Ds As New DataSet

            mynet.db_cn()
            mynet.dbM_open()

            Call mynet.dbSpM_open("SP_Select_MouldRepairData")

            command.Parameters.AddWithValue("@SLNO", 0)
            command.Parameters.AddWithValue("@Options", "SSLNO")


            Ad = New SqlDataAdapter(Command)
            Ds = New DataSet
            Ad.Fill(Ds, "Details")

            CmbSLNO.Items.Add("-Select-")

            For Tmpi As Integer = 0 To Ds.Tables(0).Rows.Count - 1
                CmbSLNO.Items.Add(Ds.Tables(0).Rows(Tmpi).Item(0))
            Next

            mynet.db_close()

        End If
    End Sub

  
    Protected Sub CmbSLNO_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CmbSLNO.SelectedIndexChanged

        If CmbSLNO.Text = "-Select-" Then
            Exit Sub
        End If

        Dim mynet As New Emanagement.netglobal
        Dim MyGlobal As New Emanagement.globalinfo

        Dim Ad As SqlDataAdapter
        Dim Ds As New DataSet

        mynet.db_cn()
        mynet.dbM_open()

        Call mynet.dbSpM_open("SP_Select_MouldRepairData")

        command.Parameters.AddWithValue("@SLNO", CmbSLNO.Text)
        command.Parameters.AddWithValue("@Options", "BySLNO")


        Ad = New SqlDataAdapter(command)
        Ds = New DataSet
        Ad.Fill(Ds, "Details")

        If Ds.Tables(0).Rows.Count >= 1 Then
            TxtPressingMachine.Text = Ds.Tables(0).Rows(0).Item(19)
            TxtBoxMName.Text = Ds.Tables(0).Rows(0).Item(3)
            TxtBoxMould.Text = Ds.Tables(0).Rows(0).Item(2)
            TxtProduct.Text = Ds.Tables(0).Rows(0).Item(1)

            If Ds.Tables(0).Rows(0).Item(4) = "Japan" Then
                ChkBxJapan.Checked = True
                ChkBxInternal.Checked = False
            Else
                ChkBxInternal.Checked = True
                ChkBxJapan.Checked = False
            End If

            TxtOperatorID.Text = Ds.Tables(0).Rows(0).Item(7)
            TxtReason.Text = Ds.Tables(0).Rows(0).Item(6)
            TxtLastUsedOn.Text = Ds.Tables(0).Rows(0).Item(8)

            TxtPressIncharge.Text = Ds.Tables(0).Rows(0).Item(9)
            TxtMMIncharge.Text = Ds.Tables(0).Rows(0).Item(10)



            ChkRenew.Checked = False
            ChkService.Checked = False
            ChkShedderMark.Checked = False
            ChkShedderBreak.Checked = False
            ChkNampakShallow.Checked = False
            ChkShallow.Checked = False
            ChkDeep.Checked = False
            ChkPinBreak.Checked = False
            ChkShifted.Checked = False
            ChkTHoleShifted.Checked = False
            ChkEdgeChip.Checked = False
            ChkOP.Checked = False
            ChkBurr.Checked = False
            ChkBar.Checked = False
            ChkWashing.Checked = False


            Dim Str As String
            Dim Str1 As String()

            Str = Ds.Tables(0).Rows(0).Item(5)
            Str1 = Str.Split(",")

            For Tmpi As Integer = 0 To Str1.Length - 1
                If Str1(Tmpi) = "Renew" Then
                    ChkRenew.Checked = True

                ElseIf Str1(Tmpi) = "Service" Then
                    ChkService.Checked = True

                ElseIf Str1(Tmpi) = "Shedder Mark" Then
                    ChkShedderMark.Checked = True

                ElseIf Str1(Tmpi) = "Shedder Break" Then
                    ChkShedderBreak.Checked = True

                ElseIf Str1(Tmpi) = "Slit Line Nampak Shallow" Then
                    ChkNampakShallow.Checked = True

                ElseIf Str1(Tmpi) = "Slit Line Shallow" Then
                    ChkShallow.Checked = True


                ElseIf Str1(Tmpi) = "Slit Line Deep" Then
                    ChkDeep.Checked = True

                ElseIf Str1(Tmpi) = "Pin Break" Then
                    ChkPinBreak.Checked = True

                ElseIf Str1(Tmpi) = "Slit Line Shifted" Then
                    ChkShifted.Checked = True

                ElseIf Str1(Tmpi) = "Thruhole Shifted" Then
                    ChkTHoleShifted.Checked = True

                ElseIf Str1(Tmpi) = "Edge Chip" Then
                    ChkEdgeChip.Checked = True

                ElseIf Str1(Tmpi) = "Out Line Problem" Then
                    ChkOP.Checked = True

                ElseIf Str1(Tmpi) = "Thruhole Burr" Then
                    ChkBurr.Checked = True

                ElseIf Str1(Tmpi) = "Pumbing Bar" Then
                    ChkBar.Checked = True

                ElseIf Str1(Tmpi) = "Washing" Then
                    ChkWashing.Checked = True





                End If
            Next

        End If


        mynet.dbM_close()

    End Sub

    Protected Sub ImageButton1_Click(ByVal sender As System.Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles ImageButton1.Click
        Calendar1.Visible = True
    End Sub

    Protected Sub ImageButton2_Click(ByVal sender As System.Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles ImageButton2.Click
        Calendar2.Visible = True
    End Sub

    Protected Sub Calendar1_SelectionChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Calendar1.SelectionChanged
        TxtLastUsedOn.Text = ""
        TxtLastUsedOn.Text = Calendar1.SelectedDate
        Calendar1.Visible = False
    End Sub

    Protected Sub Calendar2_SelectionChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Calendar2.SelectionChanged
        TxtDeliveryDate.Text = ""
        TxtDeliveryDate.Text = Calendar2.SelectedDate
        Calendar2.Visible = False
    End Sub

    Protected Sub BtnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnSave.Click
        LblMsg.Text = ""

        LblMsg.ForeColor = Drawing.Color.Red

        If TxtMMIncharge.Text.Trim.Equals("") Then
            LblMsg.Text = "Please enter mould maintenance incharge!"
            Exit Sub
        End If

        If TxtPressIncharge.Text.Trim.Equals("") Then
            LblMsg.Text = "Please enter press incharge!"
            Exit Sub
        End If


        If TxtLastUsedOn.Text.Trim.Equals("") Then
            LblMsg.Text = "Please enter last used on date!"
            Exit Sub
        End If


        If TxtOperatorID.Text.Trim.Equals("") Then
            LblMsg.Text = "Please enter operator EMP ID!"
            Exit Sub
        End If

        If TxtReason.Text.Trim.Equals("") Then
            LblMsg.Text = "Please enter reason!"
            Exit Sub
        End If

        If TxtBoxMould.Text.Trim.Equals("") Then
            LblMsg.Text = "Select Mould Number"
            Exit Sub
        End If

        If TxtBoxMName.Text.Trim.Equals("") Then
            LblMsg.Text = "Select Mould Name"
            Exit Sub
        End If


        If TxtProduct.Text.Trim.Equals("") Then
            LblMsg.Text = "Select Mould Number"
            Exit Sub
        End If


        If TxtPressingMachine.Text.Trim.Equals("") Then
            LblMsg.Text = "Select Pressing Machine Name"
            Exit Sub
        End If


        If TxtDeliveryDate.Text.Trim.Equals("") Then
            LblMsg.Text = "Enter Delivery Date"
            Exit Sub
        End If



        mynet.db_cn()
        mynet.dbM_open()


        Dim product = TxtProduct.Text
        Dim MouldNo = TxtBoxMould.Text
        Dim MouldName = TxtBoxMName.Text

        Dim Str As String
        Str = ""


        If ChkRenew.Checked = True Then
            Str = Str + "Renew,"
        End If

        If ChkService.Checked = True Then
            Str = Str + "Service,"
        End If

        If ChkShedderBreak.Checked = True Then
            Str = Str + "Shedder Break,"
        End If

        If ChkShedderMark.Checked = True Then
            Str = Str + "Shedder Mark,"
        End If

        If ChkNampakShallow.Checked = True Then
            Str = Str + "Slit Line Nampak Shallow,"
        End If

        If ChkShallow.Checked = True Then
            Str = Str + "Slit Line Shallow,"
        End If

        If ChkDeep.Checked = True Then
            Str = Str + "Slit Line Deep,"
        End If

        If ChkPinBreak.Checked = True Then
            Str = Str + "Pin Break,"
        End If

        If ChkShifted.Checked = True Then
            Str = Str + "Slit Line Shifted,"
        End If

        If ChkTHoleShifted.Checked = True Then
            Str = Str + "Thruhole Shifted,"
        End If

        If ChkEdgeChip.Checked = True Then
            Str = Str + "Edge Chip,"
        End If

        If ChkOP.Checked = True Then
            Str = Str + "Out Line Problem,"
        End If

        If ChkBurr.Checked = True Then
            Str = Str + "Thruhole Burr,"
        End If


        If ChkBar.Checked = True Then
            Str = Str + "Pumbing Bar,"
        End If

        If ChkWashing.Checked = True Then
            Str = Str + "Washing,"
        End If

        Str = Str.TrimEnd(",")

        If Str.Length <= 1 Then
            LblMsg.Text = "Please Select Defect Details!"
            Exit Sub
        End If

        Dim PressIncharge = TxtPressIncharge.Text & ""
        Dim MMIncharge = TxtMMIncharge.Text & ""
        Dim RepairingMethod = ""


        If ChkBxInternal.Checked = True Then
            RepairingMethod = "Internal"
        ElseIf ChkBxJapan.Checked = True Then
            RepairingMethod = "Japan"
        End If

        If RepairingMethod.Length <= 1 Then
            LblMsg.Text = "Please Select Repairing Method!"
            Exit Sub
        End If

        LblMsg.ForeColor = Drawing.Color.Green

        Try
            mynet.db_cn()
            mynet.dbM_open()
            Call mynet.dbSpM_open("SP_Insert_MouldRepairData")


            command.Parameters.AddWithValue("@SLNO", CmbSLNO.Text)
            command.Parameters.AddWithValue("@Product", product)
            command.Parameters.AddWithValue("@MouldNo", MouldNo)
            command.Parameters.AddWithValue("@MouldName", MouldName)
            command.Parameters.AddWithValue("@RepairingMethod", RepairingMethod)
            command.Parameters.AddWithValue("@DefectDetails", Str)
            command.Parameters.AddWithValue("@Reason", TxtReason.Text)
            command.Parameters.AddWithValue("@OperatorID", TxtOperatorID.Text)
            command.Parameters.AddWithValue("@LastUsedOn", TxtLastUsedOn.Text)
            command.Parameters.AddWithValue("@PressIncharge", PressIncharge)
            command.Parameters.AddWithValue("@MMIncharge", MMincharge)
            command.Parameters.AddWithValue("@CreatedBy", Session("empcode").ToString)
            command.Parameters.AddWithValue("@M_DeliveryDate", TxtDeliveryDate.Text)
            command.Parameters.AddWithValue("@PressingMachine", TxtPressingMachine.Text)


            command.ExecuteNonQuery()
            Session("purl") = "MaintenanceData.aspx"



            LblMsg.Text = "Congratulations! You have Updated successfully. "
            LblMsg.ForeColor = Drawing.Color.DarkGreen

            Session("options") = "mould"
            Session("reqno") = CmbSLNO.Text
            Response.Redirect("PrintProductionRequest.aspx")
        Catch ex As Exception
            LblMsg.Text = ex.Message
            LblMsg.ForeColor = Drawing.Color.Red
        End Try

    End Sub
End Class