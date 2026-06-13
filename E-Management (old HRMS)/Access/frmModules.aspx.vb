Imports System.Data
Imports System
Imports System.Globalization
Imports System.Data.SqlClient
Imports E_Management.emanagement.globalinfo
Imports E_Management.emanagement.EMSapplications
Imports e_management.emanagement.NetGlobal
Imports System.Web.Security
Partial Public Class frmModules
    Inherits System.Web.UI.Page
    Dim mynet As New Emanagement.netglobal
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

    End Sub

    Protected Sub BtnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnSave.Click
        '#Add New Modules
        If Len(Trim(DrpDwnSystem.SelectedItem.Text)) <> 0 Then
            If Len(Trim(TxtBoxModule.Text)) <> 0 Then
                Try
                    mynet.db_cn()
                    mynet.db_open()
                    Dim ModuleId As Integer
                    Call mynet.dbSp_open("Sp_GetMaxModuleId")
                    command.Parameters.AddWithValue("@SystemId", DrpDwnSystem.SelectedValue)
                    command.ExecuteNonQuery()
                    Dim dsModId As New DataSet
                    Dim daModId As New SqlDataAdapter(command)
                    daModId.Fill(dsModId, "tbl_modules")
                    If dsModId.Tables(0).Rows.Count <> 0 Then
                        Dim dr As DataRow
                        dr = dsModId.Tables(0).Rows(0)
                        If Not TypeOf (dr(0)) Is System.DBNull Then
                            If Val(dr(0)) > 0 Then
                                ModuleId = Val(dr(0)) + 1
                            Else
                                ModuleId = 1
                            End If
                        Else
                            ModuleId = 1
                        End If
                    End If
                    Call mynet.dbSp_open("sp_insupdmodules")
                    command.Parameters.AddWithValue("@SystemId", DrpDwnSystem.SelectedValue)
                    command.Parameters.AddWithValue("@ModuleId", ModuleId)
                    command.Parameters.AddWithValue("@SystemName", DrpDwnSystem.SelectedItem.Text)
                    command.Parameters.AddWithValue("@ModuleName", Trim(TxtBoxModule.Text))
                    command.Parameters.AddWithValue("@Moduledesc", Trim(TxtBoxModuleDesc.Text))
                    command.ExecuteNonQuery()
                    mynet.db_close()
                    TxtBoxModule.Text = ""
                    TxtBoxModuleDesc.Text = ""
                    GridView1.DataBind()
                    TxtBoxModule.Focus()
                    LblMsg.Text = "Congratulations! You have Saved successfully. "
                    LblMsg.ForeColor = Drawing.Color.DarkGreen
                Catch ex As Exception
                    LblMsg.Text = ex.Message
                    LblMsg.ForeColor = Drawing.Color.Red
                End Try
            Else
                LblMsg.Text = "Please Enter System Name "
                LblMsg.ForeColor = Drawing.Color.Red
                Exit Sub
            End If
        Else
            LblMsg.Text = "Please Select System Name "
            LblMsg.ForeColor = Drawing.Color.Red
        End If
        '##
    End Sub
End Class