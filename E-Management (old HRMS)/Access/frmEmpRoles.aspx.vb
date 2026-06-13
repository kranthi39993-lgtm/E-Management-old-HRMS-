Imports System.Data
Imports System
Imports System.Globalization
Imports System.Data.SqlClient
Imports E_Management.emanagement.globalinfo
Imports E_Management.emanagement.EMSapplications
Imports e_management.emanagement.NetGlobal
Imports System.Web.Security
Partial Public Class frmEmpRoles
    Inherits System.Web.UI.Page
    Dim mynet As New Emanagement.netglobal
    Dim MyGlobal As New Emanagement.globalinfo
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            Session("DDS") = False
        End If
    End Sub
    Function GetEmpData() As DataSet
        'MyGlobal.Open_Con()
        MyGlobal.Con_Str()
        Dim con As New SqlConnection(constr)
        Dim dadCats As New _
        SqlDataAdapter("SELECT * FROM empmaster where designation = '" & DropDownList3.SelectedItem.Text & "' and resigned <> 'Y'", con)
        Dim dst As New DataSet()
        dadCats.Fill(dst, "empmaster")
        Return dst
    End Function
    Protected Sub BtnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnSave.Click
        If Session("DDS") <> True Then
            If Len(Trim(TxtBoxEmpCode.Text)) <> 0 Then
                Dim empcode = Trim(TxtBoxEmpCode.Text)
                Dim row2 As GridViewRow
                Dim RoleId
                For Each row2 In GridView1.Rows
                    Dim chkboxCell2 As CheckBox = row2.FindControl("checkbox1")
                    If chkboxCell2.Checked Then
                        RoleId = CType(row2.Cells(0).Text, String)
                        'insert / update code
                        Try
                            mynet.db_cn()
                            mynet.db_open()
                            Call mynet.dbSp_open("Sp_InsUpdEmpRoles")
                            command.Parameters.AddWithValue("@empcode", empcode)
                            command.Parameters.AddWithValue("@Roleid", RoleId)
                            command.ExecuteNonQuery()
                            mynet.db_close()
                            LblMsg.Text = "Congratulations! You have Saved successfully. "
                            LblMsg.ForeColor = Drawing.Color.DarkGreen
                            TxtBoxEmpCode.Text = ""
                        Catch ex As Exception
                            LblMsg.Text = ex.Message
                            LblMsg.ForeColor = Drawing.Color.Red
                        End Try

                    Else
                        'LblMsg.Text = "There are no screens to save in this system and in this module. try selecting different system and module."
                        'LblMsg.ForeColor = Drawing.Color.Red
                    End If
                Next

            Else
                LblMsg.Text = "Please select or type employee code. "
                LblMsg.ForeColor = Drawing.Color.DarkGreen
            End If
        Else
            Dim ds As DataSet
            Dim dr As DataRow
            Dim empcode
            ds = GetEmpData()
            If ds.Tables(0).Rows.Count <> 0 Then
                Dim i
                For i = 0 To ds.Tables(0).Rows.Count - 1
                    dr = ds.Tables(0).Rows(i)
                    empcode = dr("empcode") & ""
                    If Len(Trim(empcode)) <> 0 Then

                        Dim row2 As GridViewRow
                        Dim RoleId
                        For Each row2 In GridView1.Rows
                            Dim chkboxCell2 As CheckBox = row2.FindControl("checkbox1")
                            If chkboxCell2.Checked Then
                                RoleId = CType(row2.Cells(0).Text, String)
                                'insert / update code
                                Try
                                    mynet.db_cn()
                                    mynet.db_open()
                                    Call mynet.dbSp_open("Sp_InsUpdEmpRoles")
                                    command.Parameters.AddWithValue("@empcode", empcode)
                                    command.Parameters.AddWithValue("@Roleid", RoleId)
                                    command.ExecuteNonQuery()
                                    mynet.db_close()
                                    LblMsg.Text = "Congratulations! You have Saved successfully. "
                                    LblMsg.ForeColor = Drawing.Color.DarkGreen
                                    TxtBoxEmpCode.Text = ""
                                    Session("DDS") = False
                                Catch ex As Exception
                                    LblMsg.Text = ex.Message
                                    LblMsg.ForeColor = Drawing.Color.Red
                                End Try

                            Else
                                'LblMsg.Text = "There are no screens to save in this system and in this module. try selecting different system and module."
                                'LblMsg.ForeColor = Drawing.Color.Red
                            End If
                        Next

                    End If
                Next

            Else
                LblMsg.Text = "At present there are no employees under this designation. "
                LblMsg.ForeColor = Drawing.Color.Red
            End If

        End If
    End Sub

    Protected Sub DropDownList2_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DropDownList2.SelectedIndexChanged
        TxtBoxEmpCode.Text = ""
        Session("DDS") = True
        TxtBoxEmpCode.Text = DropDownList2.SelectedValue
    End Sub

    Protected Sub DropDownList3_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DropDownList3.SelectedIndexChanged
        If Len(Trim(DropDownList3.SelectedItem.Text)) <> 0 Then
            TxtBoxEmpCode.Text = ""
        End If
    End Sub
End Class