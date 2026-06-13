Imports System
Imports System.Data
Imports System.Globalization
Imports System.Data.SqlClient
Imports e_management.emanagement.globalinfo
Imports e_management.emanagement.EMSapplications
Imports e_management.emanagement.[Global]
Imports e_management.emanagement.NetGlobal
Imports System.Web.Security
Partial Public Class frmMRRSM
    Inherits System.Web.UI.Page
    Dim mynet As New emanagement.netglobal
    Dim MyGlobal As New emanagement.globalinfo

    Dim SlNo
    Dim Product
    Dim MouldNo
    Dim MouldName
    Dim Renew
    Dim Service
    Dim Shedderbreak
    Dim Sheddermark
    Dim SlitlineNampakShallow
    Dim SlitlineShallow
    Dim SlitlineDeep
    Dim PinBreak
    Dim SlitlineShifted
    Dim TholeShifted
    Dim OutlineProblem
    Dim SendMouldToJapan
    Dim TholeBurr
    Dim EdgeChip
    Dim PumpingBar
    Dim Washing
    Dim Additional1
    Dim Additional2
    Dim Additional3
    Dim Additional4
    Dim DefectivePoint
    Dim Reason
    Dim PressShotOutline
    Dim PressShotGreenSheet
    Dim WDupper
    Dim WDlower
    Dim LDupper
    Dim LDlower
    Dim Afterwashing
    Dim AfterpinShaving
    Dim AfterRenew
    Dim RprMalaysia
    Dim RprJapan
    Dim RprStandBy
    Dim RepairingRecommendation
    Dim RepairingMethod
    Dim MouldCheckedBy
    Dim MouldCheckedDate
    Dim QCAcknowledgedBy
    Dim QCackDate
    Dim PressIncharge
    Dim PressDate
    Dim MMincharge
    Dim MMdate
    Dim MMOK
    Dim MMNG
    Dim QCOK
    Dim QCNG
    Dim Status
    Dim FinalStatus
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        ''' get maximum serial number from tbl MRRS '''''
        mynet.db_cn()
        mynet.dbM_open()

        Dim Ds As DataSet
        Dim Dr As DataRow
        Ds = mynet.Update_EMPmaster_status(dbConnWeb, daConnWeb, 2, "select max(slno) as maxslno from MRRS")
        If Ds.Tables(0).Rows.Count <> 0 Then
            Dr = Ds.Tables(0).Rows(0)
            SlNo = Val(Dr("maxslno") & "")
            If SlNo = 0 Then
                SlNo = 1
            Else
                SlNo = SlNo + 1
            End If
        Else
            SlNo = 1
        End If
        mynet.dbM_close()
        '''''''''
        LblSlNo.Text = SlNo
        TextBox13.Text = CDate(Now)
        TextBox17.Text = CDate(Now)
        TextBox15.Text = CDate(Now)
        TextBox19.Text = CDate(Now)
    End Sub

    Protected Sub BtnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnSave.Click

        ''' get maximum serial number from tbl MRRS '''''
        mynet.db_cn()
        mynet.dbM_open()

        Dim Ds As DataSet
        Dim Dr As DataRow
        Ds = mynet.Update_EMPmaster_status(dbConnWeb, daConnWeb, 2, "select max(slno) as maxslno from MRRS")
        If Ds.Tables(0).Rows.Count <> 0 Then
            Dr = Ds.Tables(0).Rows(0)
            SlNo = Val(Dr("maxslno") & "")
            If SlNo = 0 Then
                SlNo = 1
            Else
                SlNo = SlNo + 1
            End If
        Else
            SlNo = 1
        End If
        mynet.dbM_close()
        '''''''''
        LblSlNo.Text = SlNo

        Product = DrpdwnProduct.SelectedItem.Text
        MouldNo = DrpDwnMould.SelectedItem.Text
        MouldName = TxtBoxMName.Text & ""
        If ChkBoxRenew.Checked = True Then
            Renew = 1
        Else
            Renew = 0
        End If
        If CheckBox1.Checked = True Then
            SlitlineShallow = 1
        Else
            SlitlineShallow = 0
        End If
        If CheckBox12.Checked = True Then
            OutlineProblem = 1
        Else
            OutlineProblem = 0
        End If
        If CheckBox3.Checked = True Then
            Washing = 1
        Else
            Washing = 0
        End If
        If CheckBox4.Checked = True Then
            Service = 1
        Else
            Service = 0
        End If
        If CheckBox5.Checked = True Then
            SlitlineDeep = 1
        Else
            SlitlineDeep = 0
        End If
        If CheckBox6.Checked = True Then
            SendMouldToJapan = 1
        Else
            SendMouldToJapan = 0
        End If
        Additional1 = TextBox20.Text & ""

        If CheckBox8.Checked = True Then
            Sheddermark = 1
        Else
            Sheddermark = 0
        End If
        If CheckBox9.Checked = True Then
            PinBreak = 1
        Else
            PinBreak = 0
        End If
        If CheckBox10.Checked = True Then
            TholeBurr = 1
        Else
            TholeBurr = 0
        End If
        Additional2 = TextBox21.Text & ""

        If CheckBox12.Checked = True Then
            Shedderbreak = 1
        Else
            Shedderbreak = 0
        End If
        If CheckBox13.Checked = True Then
            SlitlineShifted = 1
        Else
            SlitlineShifted = 0
        End If
        If CheckBox14.Checked = True Then
            EdgeChip = 1
        Else
            EdgeChip = 0
        End If
        Additional3 = TextBox22.Text & ""

        If CheckBox16.Checked = True Then
            SlitlineNampakShallow = 1
        Else
            SlitlineNampakShallow = 0
        End If
        If CheckBox17.Checked = True Then
            TholeShifted = 1
        Else
            TholeShifted = 0
        End If
        If CheckBox18.Checked = True Then
            PumpingBar = 1
        Else
            PumpingBar = 0
        End If
        Additional4 = TextBox23.Text & ""
        DefectivePoint = TextBox1.Text & ""
        Reason = TextBox2.Text & ""

        If CheckBox20.Checked = True Then
            PressShotOutline = 1
        Else
            PressShotOutline = 0
        End If
        If CheckBox21.Checked = True Then
            PressShotGreenSheet = 1
        Else
            PressShotGreenSheet = 0
        End If
        WDupper = TextBox3.Text & ""
        WDlower = TextBox4.Text & ""
        LDupper = TextBox5.Text & ""
        LDlower = TextBox6.Text & ""
        Afterwashing = TextBox7.Text & ""
        AfterpinShaving = TextBox8.Text & ""
        AfterRenew = TextBox9.Text & ""
        PressIncharge = TextBox16.Text & ""
        PressDate = CDate(TextBox17.Text & "")

        If CheckBox22.Checked = True Then
            RprMalaysia = 1
        Else
            RprMalaysia = 0
        End If
        If CheckBox23.Checked = True Then
            RprJapan = 1
        Else
            RprJapan = 0
        End If
        If CheckBox24.Checked = True Then
            RprStandBy = 1
        Else
            RprStandBy = 0
        End If

        RepairingRecommendation = TextBox10.Text & ""
        RepairingMethod = TextBox11.Text & ""

        MouldCheckedBy = TextBox12.Text & ""
        MouldCheckedDate = CDate(TextBox13.Text & "")
        If CheckBox28.Checked = True Then
            MMOK = 1
        Else
            MMOK = 0
        End If
        If CheckBox29.Checked = True Then
            MMNG = 1
        Else
            MMNG = 0
        End If
        QCAcknowledgedBy = TextBox14.Text & ""
        QCackDate = CDate(TextBox15.Text & "")
        If CheckBox30.Checked = True Then
            QCOK = 1
        Else
            QCOK = 0
        End If
        If CheckBox31.Checked = True Then
            QCNG = 1
        Else
            QCNG = 0
        End If

        MMincharge = TextBox18.Text & ""
        MMdate = CDate(TextBox19.Text & "")
        If Session("sectioncode") <> "2120A" Then
            If RprMalaysia = 1 Then
                Status = "M"
            ElseIf RprJapan = 1 Then
                Status = "J"
            ElseIf RprStandBy = 1 Then
                Status = "S"
            Else
                Status = "W"
            End If
            FinalStatus = "P"
        Else
            If RprMalaysia = 1 Then
                Status = "M"
            ElseIf RprJapan = 1 Then
                Status = "J"
            ElseIf RprStandBy = 1 Then
                Status = "S"
            Else
                Status = "W"
            End If
            FinalStatus = "F"
        End If

        Try
            mynet.db_cn()
            mynet.dbM_open()
            Call mynet.dbSpM_open("insert_MRRS_1")
            command.Parameters.AddWithValue("@SlNo_1", SlNo)
            command.Parameters.AddWithValue("@mrdate_2", Now)
            command.Parameters.AddWithValue("@product_3", Product)
            command.Parameters.AddWithValue("@mouldno_4", MouldNo)
            command.Parameters.AddWithValue("@mouldname_5", MouldName)
            command.Parameters.AddWithValue("@renew_6", Renew)
            command.Parameters.AddWithValue("@service_7", Service)
            command.Parameters.AddWithValue("@Sheddermark_8", Sheddermark)
            command.Parameters.AddWithValue("@Shedderbreak_9", Shedderbreak)
            command.Parameters.AddWithValue("@slitlinenampakshallow_10", SlitlineNampakShallow)
            command.Parameters.AddWithValue("@slitlineshallow_11", SlitlineShallow)
            command.Parameters.AddWithValue("@slitlinedeep_12", SlitlineDeep)
            command.Parameters.AddWithValue("@pinbreak_13", PinBreak)
            command.Parameters.AddWithValue("@slitlineshifted_14", SlitlineShifted)
            command.Parameters.AddWithValue("@tholeshifted_15", TholeShifted)
            command.Parameters.AddWithValue("@outlineproblem_16", OutlineProblem)
            command.Parameters.AddWithValue("@sendmouldtojapan_17", SendMouldToJapan)
            command.Parameters.AddWithValue("@tholeburr_18", TholeBurr)
            command.Parameters.AddWithValue("@edgechip_19", EdgeChip)
            command.Parameters.AddWithValue("@pumpingbar_20", PumpingBar)
            command.Parameters.AddWithValue("@washing_21", Washing)
            command.Parameters.AddWithValue("@Add1_22", Additional1)
            command.Parameters.AddWithValue("@Add2_23", Additional2)
            command.Parameters.AddWithValue("@Add3_24", Additional3)
            command.Parameters.AddWithValue("@Add4_25", Additional4)
            command.Parameters.AddWithValue("@remarks_26", "")
            command.Parameters.AddWithValue("@defectivepoint_27", DefectivePoint)
            command.Parameters.AddWithValue("@reason_28", Reason)
            command.Parameters.AddWithValue("@WDupper_29", WDupper)
            command.Parameters.AddWithValue("@WDlower_30", WDlower)
            command.Parameters.AddWithValue("@LDupper_31", LDupper)
            command.Parameters.AddWithValue("@LDlower_32", LDlower)
            command.Parameters.AddWithValue("@outline_33", PressShotOutline)
            command.Parameters.AddWithValue("@greensheet_34", PressShotGreenSheet)
            command.Parameters.AddWithValue("@afterwashing_35", Afterwashing)
            command.Parameters.AddWithValue("@afterpinshaving_36", AfterpinShaving)
            command.Parameters.AddWithValue("@afterrenew_37", AfterRenew)
            command.Parameters.AddWithValue("@rprMalaysia_38", RprMalaysia)
            command.Parameters.AddWithValue("@rprJapan_39", RprJapan)
            command.Parameters.AddWithValue("@rprstandby_40", RprStandBy)
            command.Parameters.AddWithValue("@rprremarks_41", RepairingRecommendation)
            command.Parameters.AddWithValue("@rprmMalaysia_42", "")
            command.Parameters.AddWithValue("@rprmJapan_43", "")
            command.Parameters.AddWithValue("@rprmstandby_44", "")
            command.Parameters.AddWithValue("@rprmremarks_45", RepairingMethod)
            command.Parameters.AddWithValue("@mouldcheckedby_46", MouldCheckedBy)
            command.Parameters.AddWithValue("@mouldcheckeddate_47", MouldCheckedDate)
            command.Parameters.AddWithValue("@statusOK_48", MMOK)
            command.Parameters.AddWithValue("@statusNG_49", MMNG)
            command.Parameters.AddWithValue("@QCacknowledgedby_50", QCAcknowledgedBy)
            command.Parameters.AddWithValue("@QCstatusOK_51", QCOK)
            command.Parameters.AddWithValue("@QCstatusNG_52", QCNG)
            command.Parameters.AddWithValue("@pressincharge_53", PressIncharge)
            command.Parameters.AddWithValue("@pcdate_54", PressDate)
            command.Parameters.AddWithValue("@finalremarks_55", "")
            command.Parameters.AddWithValue("@mmcheckedby_56", MMincharge)
            command.Parameters.AddWithValue("@mmdate_57", MMdate)
            command.Parameters.AddWithValue("@status_58", Status)
            command.Parameters.AddWithValue("@appstatus_59", FinalStatus)
            command.Parameters.AddWithValue("@expdate_60", MMdate)
            command.ExecuteNonQuery()
            mynet.dbM_close()
            LblMsg.Text = "Congratulations! You have Saved successfully. "
            LblMsg.ForeColor = Drawing.Color.DarkGreen
        Catch ex As Exception
            LblMsg.Text = ex.Message
            LblMsg.ForeColor = Drawing.Color.Red
        End Try



    End Sub

    Protected Sub ImageButton3_Click(ByVal sender As System.Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles ImageButton3.Click
        Calendar3.Visible = True
    End Sub

    Protected Sub Calendar3_SelectionChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Calendar3.SelectionChanged
        TextBox17.Text = ""
        TextBox17.Text = Calendar3.SelectedDate
        Calendar3.Visible = False
    End Sub

    Protected Sub ImageButton1_Click(ByVal sender As System.Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles ImageButton1.Click
        Calendar1.Visible = True
    End Sub

    Protected Sub Calendar1_SelectionChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Calendar1.SelectionChanged
        TextBox13.Text = ""
        TextBox13.Text = Calendar1.SelectedDate
        Calendar1.Visible = False
    End Sub

    Protected Sub ImageButton2_Click(ByVal sender As System.Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles ImageButton2.Click
        Calendar2.Visible = True
    End Sub

    Protected Sub Calendar2_SelectionChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Calendar2.SelectionChanged
        TextBox15.Text = ""
        TextBox15.Text = Calendar2.SelectedDate
        Calendar2.Visible = False
    End Sub

    Protected Sub ImageButton4_Click(ByVal sender As System.Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles ImageButton4.Click
        Calendar4.Visible = True
    End Sub

    Protected Sub Calendar4_SelectionChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Calendar4.SelectionChanged
        TextBox19.Text = ""
        TextBox19.Text = Calendar4.SelectedDate
        Calendar4.Visible = False
    End Sub

    Protected Sub CheckBox22_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CheckBox22.CheckedChanged
        If CheckBox22.Checked = True Then
            CheckBox23.Checked = False
            CheckBox24.Checked = False
        End If
    End Sub

    Protected Sub CheckBox23_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CheckBox23.CheckedChanged
        If CheckBox23.Checked = True Then
            CheckBox22.Checked = False
            CheckBox24.Checked = False
        End If
    End Sub

    Protected Sub CheckBox24_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CheckBox24.CheckedChanged
        If CheckBox24.Checked = True Then
            CheckBox23.Checked = False
            CheckBox22.Checked = False
        End If
    End Sub

    Protected Sub CheckBox28_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CheckBox28.CheckedChanged
        If CheckBox28.Checked = True Then
            CheckBox29.Checked = False
        End If
    End Sub

    Protected Sub CheckBox29_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CheckBox29.CheckedChanged
        If CheckBox29.Checked = True Then
            CheckBox28.Checked = False
        End If
    End Sub

    Protected Sub CheckBox30_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CheckBox30.CheckedChanged
        If CheckBox30.Checked = True Then
            CheckBox31.Checked = False
        End If
    End Sub

    Protected Sub CheckBox31_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CheckBox31.CheckedChanged
        If CheckBox31.Checked = True Then
            CheckBox30.Checked = False
        End If
    End Sub
End Class