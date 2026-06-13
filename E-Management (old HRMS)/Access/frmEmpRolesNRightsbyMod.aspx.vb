Imports System.Data
Imports System
Imports System.Globalization
Imports System.Data.SqlClient
Imports E_Management.emanagement.globalinfo
Imports E_Management.emanagement.EMSapplications
Imports e_management.emanagement.NetGlobal
Imports System.Web.Security
Partial Public Class frmEmpRolesNRightsbyMod
    Inherits System.Web.UI.Page
    Dim mynet As New Emanagement.netglobal
    Dim MyGlobal As New Emanagement.globalinfo
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
     
    End Sub
    Function GetScreensData() As DataSet
        'MyGlobal.Open_Con()
        MyGlobal.Con_Str()
        Dim con As New SqlConnection(constr)
        Dim dadCats As New _
        SqlDataAdapter("SELECT * FROM tbl_Screens where systemid = '" & Session("systemid") & "' and moduleid = '" & Session("moduleid") & "' and scrtypeid='" & Session("scrtypeid") & "'", con)
        Dim dst As New DataSet()
        dadCats.Fill(dst, "tbl_Screens")
        Return dst
    End Function
    Protected Sub BtnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnSave.Click
        If Len(Trim(TxtBoxEmpCode.Text)) <> 0 Then
            Dim empcode = Trim(TxtBoxEmpCode.Text)
            Dim row2 As GridViewRow
            Dim SystemId, ModuleId
            For Each row2 In GridView2.Rows
                Dim chkboxCell2 As CheckBox = row2.FindControl("checkbox1")
                If chkboxCell2.Checked Then
                    SystemId = CType(row2.Cells(0).Text, String)
                    ModuleId = CType(row2.Cells(2).Text, String)
                    Session("systemid") = SystemId
                    Session("moduleid") = ModuleId


                    Dim i
                    Dim ScrTypeId
                    Dim status
                    For i = 0 To CheckBoxList1.Items.Count - 1
                        ScrTypeId = CheckBoxList1.Items(i).Value
                        Session("scrtypeid") = ScrTypeId
                        If CheckBoxList1.Items(i).Selected Then
                            status = "1"
                        Else
                            status = "0"
                        End If
                        'insert / update code
                        '''''''''''''''''''''''''''' get screens in that system/module/scrtype ''''''''''''
                        Dim dsds As DataSet
                        Dim drdr As DataRow
                        Dim ijk
                        Dim ScrId
                        dsds = GetScreensData()
                        If dsds.Tables(0).Rows.Count <> 0 Then
                            For ijk = 0 To dsds.Tables(0).Rows.Count - 1
                                drdr = dsds.Tables(0).Rows(ijk)
                                ScrId = drdr("scrid") & ""
                                If Len(Trim(ScrId)) <> 0 Then
                                    '''''''''''''''''''''

                                    Try
                                        mynet.db_cn()
                                        mynet.db_open()
                                        Call mynet.dbSp_open("Sp_InsUpdEmpRights")
                                        command.Parameters.AddWithValue("@empcode", empcode)
                                        command.Parameters.AddWithValue("@Systemid", SystemId)
                                        command.Parameters.AddWithValue("@moduleid", ModuleId)
                                        command.Parameters.AddWithValue("@scrtypeid", ScrTypeId)
                                        command.Parameters.AddWithValue("@scrid", ScrId)
                                        command.Parameters.AddWithValue("@scrstatus", status)
                                        command.ExecuteNonQuery()
                                        mynet.db_close()
                                        LblMsg.Text = "Congratulations! You have Saved successfully. "
                                        LblMsg.ForeColor = Drawing.Color.DarkGreen
                                        TxtBoxEmpCode.Text = ""
                                    Catch ex As Exception
                                        LblMsg.Text = ex.Message
                                        LblMsg.ForeColor = Drawing.Color.Red
                                    End Try
                                End If
                            Next

                        End If
                    Next
                Else
                    LblMsg.Text = "There are no screens to save in this system and in this module. try selecting different system and module."
                    LblMsg.ForeColor = Drawing.Color.Red
                End If
            Next

        Else
            LblMsg.Text = "Please select or type employee code. "
            LblMsg.ForeColor = Drawing.Color.DarkGreen
        End If
    End Sub

    Protected Sub DropDownList2_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DropDownList2.SelectedIndexChanged
        TxtBoxEmpCode.Text = ""
        TxtBoxEmpCode.Text = DropDownList2.SelectedValue
    End Sub
End Class