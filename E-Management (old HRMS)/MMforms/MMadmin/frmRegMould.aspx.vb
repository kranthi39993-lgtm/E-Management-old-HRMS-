Imports System.Data
Imports System
Imports System.Globalization
Imports System.Data.SqlClient
Imports e_management.emanagement.globalinfo
Imports e_management.emanagement.EMSapplications
Imports e_management.emanagement.NetGlobal
Imports System.Web.Security
Partial Public Class frmRegMould
    Inherits System.Web.UI.Page
    Dim mynet As New emanagement.netglobal
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If IsPostBack = False Then
            With CMBDepartment.Items
                .Add("-Select-")
                .Add("Substrate")
                .Add("TPH")
                .Add("CV")
                .Add("Ferrite Magnet")
            End With
        End If
    End Sub

    

 

    Protected Sub BtnSave_Click(ByVal sender As System.Object, ByVal ex As System.EventArgs) Handles BtnSave.Click
        '#Add New Company
        If LblMType.Text = "" Or LblMType.Text = "Please Select Mould Name" Then
            LblMsg.Text = "Please Select Mould Name"
            LblMsg.ForeColor = Drawing.Color.Red
            Exit Sub
        End If

        Dim Tmp As Integer = 0

        Try
            mynet.db_cn()
            mynet.dbM_open()
            Dim Cnt As Integer = 0

            For Tmp = 0 To 25
                Dim Flg As Boolean = False
                Dim MouldNo As String
                Dim PressingQty As Integer

                If Tmp = 0 And A.Enabled = True Then
                    If A.Checked = True Then
                        MouldNo = "A01"
                        PressingQty = Convert.ToInt32(A1.Text)
                        Cnt = Cnt + 1
                        Flg = True
                    End If
                End If


                If Tmp = 1 And B.Enabled = True Then
                    If B.Checked = True Then
                        MouldNo = "B01"
                        PressingQty = Convert.ToInt32(B1.Text)
                        Cnt = Cnt + 1
                        Flg = True
                    End If
                End If

                If Tmp = 2 And C.Enabled = True Then
                    If C.Checked = True Then
                        MouldNo = "C01"
                        PressingQty = Convert.ToInt32(C1.Text)
                        Cnt = Cnt + 1
                        Flg = True
                    End If
                End If

                If Tmp = 3 And D.Enabled = True Then
                    If D.Checked = True Then
                        MouldNo = "D01"
                        PressingQty = Convert.ToInt32(D1.Text)
                        Cnt = Cnt + 1
                        Flg = True
                    End If
                End If

                If Tmp = 4 And E.Enabled = True Then
                    If E.Checked = True Then
                        MouldNo = "E01"
                        PressingQty = Convert.ToInt32(E1.Text)
                        Cnt = Cnt + 1
                        Flg = True
                    End If
                End If

                If Tmp = 5 And F.Enabled = True Then
                    If F.Checked = True Then
                        MouldNo = "F01"
                        PressingQty = Convert.ToInt32(F1.Text)
                        Cnt = Cnt + 1
                        Flg = True
                    End If
                End If

                If Tmp = 6 And G.Enabled = True Then
                    If G.Checked = True Then
                        MouldNo = "G01"
                        PressingQty = Convert.ToInt32(G1.Text)
                        Cnt = Cnt + 1
                        Flg = True
                    End If
                End If

                If Tmp = 7 And H.Enabled = True Then
                    If H.Checked = True Then
                        MouldNo = "H01"
                        PressingQty = Convert.ToInt32(H1.Text)
                        Cnt = Cnt + 1
                        Flg = True
                    End If
                End If

                If Tmp = 8 And I.Enabled = True Then
                    If I.Checked = True Then
                        MouldNo = "I01"
                        PressingQty = Convert.ToInt32(I1.Text)
                        Cnt = Cnt + 1
                        Flg = True
                    End If
                End If

                If Tmp = 9 And J.Enabled = True Then
                    If J.Checked = True Then
                        MouldNo = "J01"
                        PressingQty = Convert.ToInt32(J1.Text)
                        Cnt = Cnt + 1
                        Flg = True
                    End If
                End If

                If Tmp = 10 And K.Enabled = True Then
                    If K.Checked = True Then
                        MouldNo = "K01"
                        PressingQty = Convert.ToInt32(K1.Text)
                        Cnt = Cnt + 1
                        Flg = True
                    End If
                End If

                If Tmp = 11 And L.Enabled = True Then
                    If L.Checked = True Then
                        MouldNo = "L01"
                        PressingQty = Convert.ToInt32(L1.Text)
                        Cnt = Cnt + 1
                        Flg = True
                    End If
                End If

                If Tmp = 12 And M.Enabled = True Then
                    If M.Checked = True Then
                        MouldNo = "M01"
                        PressingQty = Convert.ToInt32(M1.Text)
                        Cnt = Cnt + 1
                        Flg = True
                    End If
                End If

                If Tmp = 13 And N.Enabled = True Then
                    If N.Checked = True Then
                        MouldNo = "N01"
                        PressingQty = Convert.ToInt32(N1.Text)
                        Cnt = Cnt + 1
                        Flg = True
                    End If
                End If

                If Tmp = 14 And O.Enabled = True Then
                    If O.Checked = True Then
                        MouldNo = "O01"
                        PressingQty = Convert.ToInt32(O1.Text)
                        Cnt = Cnt + 1
                        Flg = True
                    End If
                End If

                If Tmp = 15 And P.Enabled = True Then
                    If P.Checked = True Then
                        MouldNo = "P01"
                        PressingQty = Convert.ToInt32(P1.Text)
                        Cnt = Cnt + 1
                        Flg = True
                    End If
                End If

                If Tmp = 16 And Q.Enabled = True Then
                    If Q.Checked = True Then
                        MouldNo = "Q01"
                        PressingQty = Convert.ToInt32(Q1.Text)
                        Cnt = Cnt + 1
                        Flg = True
                    End If
                End If

                If Tmp = 17 And R.Enabled = True Then
                    If R.Checked = True Then
                        MouldNo = "R01"
                        PressingQty = Convert.ToInt32(R1.Text)
                        Cnt = Cnt + 1
                        Flg = True
                    End If
                End If

                If Tmp = 18 And S.Enabled = True Then
                    If S.Checked = True Then
                        MouldNo = "S01"
                        PressingQty = Convert.ToInt32(S1.Text)
                        Cnt = Cnt + 1
                        Flg = True
                    End If
                End If

                If Tmp = 19 And T.Enabled = True Then
                    If T.Checked = True Then
                        MouldNo = "T01"
                        PressingQty = Convert.ToInt32(T1.Text)
                        Cnt = Cnt + 1
                        Flg = True
                    End If
                End If

                If Tmp = 20 And U.Enabled = True Then
                    If U.Checked = True Then
                        MouldNo = "U01"
                        PressingQty = Convert.ToInt32(U1.Text)
                        Cnt = Cnt + 1
                        Flg = True
                    End If
                End If

                If Tmp = 21 And V.Enabled = True Then
                    If V.Checked = True Then
                        MouldNo = "V01"
                        PressingQty = Convert.ToInt32(V1.Text)
                        Cnt = Cnt + 1
                        Flg = True
                    End If
                End If

                If Tmp = 22 And W.Enabled = True Then
                    If W.Checked = True Then
                        MouldNo = "W01"
                        PressingQty = Convert.ToInt32(W1.Text)
                        Cnt = Cnt + 1
                        Flg = True
                    End If
                End If

                If Tmp = 23 And X.Enabled = True Then
                    If X.Checked = True Then
                        MouldNo = "X01"
                        PressingQty = Convert.ToInt32(X1.Text)
                        Cnt = Cnt + 1
                        Flg = True
                    End If
                End If

                If Tmp = 24 And Y.Enabled = True Then
                    If Y.Checked = True Then
                        MouldNo = "Y01"
                        PressingQty = Convert.ToInt32(Y1.Text)
                        Cnt = Cnt + 1
                        Flg = True
                    End If
                End If

                If Tmp = 25 And Z.Enabled = True Then
                    If Z.Checked = True Then
                        MouldNo = "Z01"
                        PressingQty = Convert.ToInt32(Z1.Text)
                        Cnt = Cnt + 1
                        Flg = True
                    End If
                End If


                If Flg = True Then

                    Call mynet.dbSpM_open("insert_MouldMaster")
                    command.Parameters.AddWithValue("@fgid", Session("fgid"))
                    command.Parameters.AddWithValue("@Product", DrpdwnProduct.SelectedItem.Text)
                    command.Parameters.AddWithValue("@MouldName", DrpDwnMName.SelectedItem.Text)
                    command.Parameters.AddWithValue("@MouldNo", MouldNo)
                    command.Parameters.AddWithValue("@MouldType", LblMType.Text)
                    command.Parameters.AddWithValue("@PressLimit", PressingQty)
                    command.Parameters.AddWithValue("@CreatedBy", Session("empcode"))
                    command.Parameters.AddWithValue("@CDate", Now)
                    command.Parameters.AddWithValue("@StandByQty", TxtSQty.Text)
                    command.ExecuteNonQuery()
                End If

            Next

            mynet.dbM_close()

            If Cnt >= 1 Then
                LblMsg.Text = "Successfully Registered"
                LblMsg.ForeColor = Drawing.Color.DarkGreen
                ClearControl()
            Else
                LblMsg.Text = "Please Select Mould No and Enter Pressing Qty"
            End If
            
        Catch exs As Exception
            LblMsg.Text = exs.Message
            LblMsg.ForeColor = Drawing.Color.Red
        End Try

        
        '##
    End Sub

    Private Sub ClearControl()
        A.Checked = False
        A.Enabled = True
        B.Checked = False
        B.Enabled = True
        C.Checked = False
        C.Enabled = True
        D.Checked = False
        D.Enabled = True
        E.Checked = False
        E.Enabled = True
        F.Checked = False
        F.Enabled = True
        G.Checked = False
        G.Enabled = True
        H.Checked = False
        H.Enabled = True
        I.Checked = False
        I.Enabled = True
        J.Checked = False
        J.Enabled = True
        K.Checked = False
        K.Enabled = True
        L.Checked = False
        L.Enabled = True
        M.Checked = False
        M.Enabled = True
        N.Checked = False
        N.Enabled = True
        O.Checked = False
        O.Enabled = True
        P.Checked = False
        P.Enabled = True
        Q.Checked = False
        Q.Enabled = True
        R.Checked = False
        R.Enabled = True
        S.Checked = False
        S.Enabled = True
        T.Checked = False
        T.Enabled = True
        U.Checked = False
        U.Enabled = True
        V.Checked = False
        V.Enabled = True
        W.Checked = False
        W.Enabled = True
        X.Checked = False
        X.Enabled = True
        Y.Checked = False
        Y.Enabled = True
        Z.Checked = False
        Z.Enabled = True
        A1.Text = ""
        B1.Text = ""
        C1.Text = ""
        D1.Text = ""
        E1.Text = ""
        F1.Text = ""
        G1.Text = ""
        H1.Text = ""
        I1.Text = ""
        J1.Text = ""
        K1.Text = ""
        L1.Text = ""
        M1.Text = ""
        N1.Text = ""
        O1.Text = ""
        P1.Text = ""
        Q1.Text = ""
        R1.Text = ""
        S1.Text = ""
        T1.Text = ""
        U1.Text = ""
        V1.Text = ""
        W1.Text = ""
        X1.Text = ""
        Y1.Text = ""
        Z1.Text = ""


        TxtSQty.Enabled = True




        TxtSQty.Text = ""


    End Sub

    '-------04/03/2013--------
    Protected Sub CMBDepartment_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CMBDepartment.SelectedIndexChanged

        If CMBDepartment.Text = "Substrate" Then
            Session("fgid") = "21"
        ElseIf CMBDepartment.Text = "TPH" Then
            Session("fgid") = "71"
        ElseIf CMBDepartment.Text = "CV" Then
            Session("fgid") = "31"
        ElseIf CMBDepartment.Text = "Ferrite Magnet" Then
            Session("fgid") = "42"
        ElseIf CMBDepartment.Text = "Ferrite Sheet" Then
            Session("fgid") = "43"
        End If
        ClearControl()
    End Sub

    
    Protected Sub DrpdwnProduct_SelectedIndexChanged(ByVal sender As System.Object, ByVal eX As System.EventArgs) Handles DrpdwnProduct.SelectedIndexChanged

        
    End Sub

    
    Protected Sub DrpDwnMName_SelectedIndexChanged(ByVal sender As System.Object, ByVal ex1 As System.EventArgs) Handles DrpDwnMName.SelectedIndexChanged
        ClearControl()

        Dim Ad1 As New SqlDataAdapter
        Dim TmpDs As New DataSet
        mynet.db_cn()
        mynet.dbM_open()
        Call mynet.dbSpM_open("Select_RegisterMouldName")
        command.Parameters.AddWithValue("@FGID", Session("fgid").ToString)
        command.Parameters.AddWithValue("@MouldName", DrpDwnMName.Text)
        Ad1.SelectCommand = command
        TmpDs = New DataSet
        Ad1.Fill(TmpDs, "Mould")
        LblMType.Text = TmpDs.Tables(0).Rows(0).Item(3)



        '....


        Call mynet.dbSpM_open("Select_MouldMaster")
        command.Parameters.AddWithValue("@Product", DrpdwnProduct.Text)
        command.Parameters.AddWithValue("@FGID", Session("fgid").ToString)
        command.Parameters.AddWithValue("@MouldName", DrpDwnMName.Text)

        Ad1.SelectCommand = command
        TmpDs = New DataSet()
        Ad1.Fill(TmpDs, "Mould")

        For Tmpi As Int32 = 0 To TmpDs.Tables(0).Rows.Count - 1

            If Left(TmpDs.Tables(0).Rows(Tmpi).Item(0), 1) = "A" Then
                A.Text = TmpDs.Tables(0).Rows(Tmpi).Item(0)
                A.Checked = True
                A.Enabled = False
                A1.Text = TmpDs.Tables(0).Rows(Tmpi).Item(1)
                TxtSQty.Text = TmpDs.Tables(0).Rows(Tmpi).Item(2)
                TxtSQty.Enabled = False
            End If

            If Left(TmpDs.Tables(0).Rows(Tmpi).Item(0), 1) = "B" Then
                B.Text = TmpDs.Tables(0).Rows(Tmpi).Item(0)
                B.Checked = True
                B.Enabled = False
                B1.Text = TmpDs.Tables(0).Rows(Tmpi).Item(1)
                TxtSQty.Text = TmpDs.Tables(0).Rows(Tmpi).Item(2)
                TxtSQty.Enabled = False
            End If

            If Left(TmpDs.Tables(0).Rows(Tmpi).Item(0), 1) = "C" Then
                C.Text = TmpDs.Tables(0).Rows(Tmpi).Item(0)
                C.Checked = True
                C.Enabled = False
                C1.Text = TmpDs.Tables(0).Rows(Tmpi).Item(1)
                TxtSQty.Text = TmpDs.Tables(0).Rows(Tmpi).Item(2)
                TxtSQty.Enabled = False
            End If

            If Left(TmpDs.Tables(0).Rows(Tmpi).Item(0), 1) = "D" Then
                D.Text = TmpDs.Tables(0).Rows(Tmpi).Item(0)
                D.Checked = True
                D.Enabled = False
                D1.Text = TmpDs.Tables(0).Rows(Tmpi).Item(1)
                TxtSQty.Text = TmpDs.Tables(0).Rows(Tmpi).Item(2)
                TxtSQty.Enabled = False
            End If

            If Left(TmpDs.Tables(0).Rows(Tmpi).Item(0), 1) = "E" Then
                E.Text = TmpDs.Tables(0).Rows(Tmpi).Item(0)
                E.Checked = True
                E.Enabled = False
                E1.Text = TmpDs.Tables(0).Rows(Tmpi).Item(1)
                TxtSQty.Text = TmpDs.Tables(0).Rows(Tmpi).Item(2)
                TxtSQty.Enabled = False
            End If

            If Left(TmpDs.Tables(0).Rows(Tmpi).Item(0), 1) = "F" Then
                F.Text = TmpDs.Tables(0).Rows(Tmpi).Item(0)
                F.Checked = True
                F.Enabled = False
                F1.Text = TmpDs.Tables(0).Rows(Tmpi).Item(1)
                TxtSQty.Text = TmpDs.Tables(0).Rows(Tmpi).Item(2)
                TxtSQty.Enabled = False
            End If

            If Left(TmpDs.Tables(0).Rows(Tmpi).Item(0), 1) = "G" Then
                G.Text = TmpDs.Tables(0).Rows(Tmpi).Item(0)
                G.Checked = True
                G.Enabled = False
                G1.Text = TmpDs.Tables(0).Rows(Tmpi).Item(1)
                TxtSQty.Text = TmpDs.Tables(0).Rows(Tmpi).Item(2)
                TxtSQty.Enabled = False
            End If

            If Left(TmpDs.Tables(0).Rows(Tmpi).Item(0), 1) = "H" Then
                H.Text = TmpDs.Tables(0).Rows(Tmpi).Item(0)
                H.Checked = True
                H.Enabled = False
                H1.Text = TmpDs.Tables(0).Rows(Tmpi).Item(1)
                TxtSQty.Text = TmpDs.Tables(0).Rows(Tmpi).Item(2)
                TxtSQty.Enabled = False
            End If

            If Left(TmpDs.Tables(0).Rows(Tmpi).Item(0), 1) = "I" Then
                I.Text = TmpDs.Tables(0).Rows(Tmpi).Item(0)
                I.Checked = True
                I.Enabled = False
                I1.Text = TmpDs.Tables(0).Rows(Tmpi).Item(1)
                TxtSQty.Text = TmpDs.Tables(0).Rows(Tmpi).Item(2)
                TxtSQty.Enabled = False
            End If

            If Left(TmpDs.Tables(0).Rows(Tmpi).Item(0), 1) = "J" Then
                J.Checked = True
                J.Enabled = False
                J1.Text = TmpDs.Tables(0).Rows(Tmpi).Item(1)
                TxtSQty.Text = TmpDs.Tables(0).Rows(Tmpi).Item(2)
                TxtSQty.Enabled = False
            End If

            If Left(TmpDs.Tables(0).Rows(Tmpi).Item(0), 1) = "K" Then
                K.Text = TmpDs.Tables(0).Rows(Tmpi).Item(0)
                K.Checked = True
                K.Enabled = False
                K1.Text = TmpDs.Tables(0).Rows(Tmpi).Item(1)
                TxtSQty.Text = TmpDs.Tables(0).Rows(Tmpi).Item(2)
                TxtSQty.Enabled = False
            End If

            If Left(TmpDs.Tables(0).Rows(Tmpi).Item(0), 1) = "L" Then
                L.Text = TmpDs.Tables(0).Rows(Tmpi).Item(0)
                L.Checked = True
                L.Enabled = False
                L1.Text = TmpDs.Tables(0).Rows(Tmpi).Item(1)
                TxtSQty.Text = TmpDs.Tables(0).Rows(Tmpi).Item(2)
                TxtSQty.Enabled = False
            End If

            If Left(TmpDs.Tables(0).Rows(Tmpi).Item(0), 1) = "M" Then
                M.Text = TmpDs.Tables(0).Rows(Tmpi).Item(0)
                M.Checked = True
                M.Enabled = False
                M1.Text = TmpDs.Tables(0).Rows(Tmpi).Item(1)
                TxtSQty.Text = TmpDs.Tables(0).Rows(Tmpi).Item(2)
                TxtSQty.Enabled = False
            End If

            If Left(TmpDs.Tables(0).Rows(Tmpi).Item(0), 1) = "N" Then
                N.Text = TmpDs.Tables(0).Rows(Tmpi).Item(0)
                N.Checked = True
                N.Enabled = False
                N1.Text = TmpDs.Tables(0).Rows(Tmpi).Item(1)
                TxtSQty.Text = TmpDs.Tables(0).Rows(Tmpi).Item(2)
                TxtSQty.Enabled = False
            End If

            If Left(TmpDs.Tables(0).Rows(Tmpi).Item(0), 1) = "O" Then
                O.Text = TmpDs.Tables(0).Rows(Tmpi).Item(0)
                O.Checked = True
                O.Enabled = False
                O1.Text = TmpDs.Tables(0).Rows(Tmpi).Item(1)
                TxtSQty.Text = TmpDs.Tables(0).Rows(Tmpi).Item(2)
                TxtSQty.Enabled = False
            End If

            If Left(TmpDs.Tables(0).Rows(Tmpi).Item(0), 1) = "P" Then
                P.Text = TmpDs.Tables(0).Rows(Tmpi).Item(0)
                P.Checked = True
                P.Enabled = False
                P1.Text = TmpDs.Tables(0).Rows(Tmpi).Item(1)
                TxtSQty.Text = TmpDs.Tables(0).Rows(Tmpi).Item(2)
                TxtSQty.Enabled = False
            End If

            If Left(TmpDs.Tables(0).Rows(Tmpi).Item(0), 1) = "Q" Then
                Q.Text = TmpDs.Tables(0).Rows(Tmpi).Item(0)
                Q.Checked = True
                Q.Enabled = False
                Q1.Text = TmpDs.Tables(0).Rows(Tmpi).Item(1)
                TxtSQty.Text = TmpDs.Tables(0).Rows(Tmpi).Item(2)
                TxtSQty.Enabled = False
            End If

            If Left(TmpDs.Tables(0).Rows(Tmpi).Item(0), 1) = "R" Then
                R.Text = TmpDs.Tables(0).Rows(Tmpi).Item(0)
                R.Checked = True
                R.Enabled = False
                R1.Text = TmpDs.Tables(0).Rows(Tmpi).Item(1)
                TxtSQty.Text = TmpDs.Tables(0).Rows(Tmpi).Item(2)
                TxtSQty.Enabled = False
            End If

            If Left(TmpDs.Tables(0).Rows(Tmpi).Item(0), 1) = "S" Then
                S.Text = TmpDs.Tables(0).Rows(Tmpi).Item(0)
                S.Checked = True
                S.Enabled = False
                S1.Text = TmpDs.Tables(0).Rows(Tmpi).Item(1)
                TxtSQty.Text = TmpDs.Tables(0).Rows(Tmpi).Item(2)
                TxtSQty.Enabled = False
            End If

            If Left(TmpDs.Tables(0).Rows(Tmpi).Item(0), 1) = "T" Then
                T.Text = TmpDs.Tables(0).Rows(Tmpi).Item(0)
                T.Checked = True
                T.Enabled = False
                T1.Text = TmpDs.Tables(0).Rows(Tmpi).Item(1)
                TxtSQty.Text = TmpDs.Tables(0).Rows(Tmpi).Item(2)
                TxtSQty.Enabled = False
            End If

            If Left(TmpDs.Tables(0).Rows(Tmpi).Item(0), 1) = "U" Then
                U.Text = TmpDs.Tables(0).Rows(Tmpi).Item(0)
                U.Checked = True
                U.Enabled = False
                U1.Text = TmpDs.Tables(0).Rows(Tmpi).Item(1)
                TxtSQty.Text = TmpDs.Tables(0).Rows(Tmpi).Item(2)
                TxtSQty.Enabled = False
            End If

            If Left(TmpDs.Tables(0).Rows(Tmpi).Item(0), 1) = "V" Then
                V.Text = TmpDs.Tables(0).Rows(Tmpi).Item(0)
                V.Checked = True
                V.Enabled = True
                V1.Text = TmpDs.Tables(0).Rows(Tmpi).Item(1)
                TxtSQty.Text = TmpDs.Tables(0).Rows(Tmpi).Item(2)
                TxtSQty.Enabled = False
            End If

            If Left(TmpDs.Tables(0).Rows(Tmpi).Item(0), 1) = "W" Then
                W.Text = TmpDs.Tables(0).Rows(Tmpi).Item(0)
                W.Checked = True
                W.Enabled = False
                W1.Text = TmpDs.Tables(0).Rows(Tmpi).Item(1)
                TxtSQty.Text = TmpDs.Tables(0).Rows(Tmpi).Item(2)
                TxtSQty.Enabled = False
            End If

            If Left(TmpDs.Tables(0).Rows(Tmpi).Item(0), 1) = "X" Then
                X.Text = TmpDs.Tables(0).Rows(Tmpi).Item(0)
                X.Checked = True
                X.Enabled = False
                X1.Text = TmpDs.Tables(0).Rows(Tmpi).Item(1)
                TxtSQty.Text = TmpDs.Tables(0).Rows(Tmpi).Item(2)
                TxtSQty.Enabled = False
            End If

            If Left(TmpDs.Tables(0).Rows(Tmpi).Item(0), 1) = "Y" Then
                Y.Text = TmpDs.Tables(0).Rows(Tmpi).Item(0)
                Y.Checked = True
                Y.Enabled = False
                Y1.Text = TmpDs.Tables(0).Rows(Tmpi).Item(1)
                TxtSQty.Text = TmpDs.Tables(0).Rows(Tmpi).Item(2)
                TxtSQty.Enabled = False
            End If

            If Left(TmpDs.Tables(0).Rows(Tmpi).Item(0), 1) = "Z" Then
                Z.Text = TmpDs.Tables(0).Rows(Tmpi).Item(0)
                Z.Checked = True
                Z.Enabled = False
                Z1.Text = TmpDs.Tables(0).Rows(Tmpi).Item(1)
                TxtSQty.Text = TmpDs.Tables(0).Rows(Tmpi).Item(2)
                TxtSQty.Enabled = False
            End If

        Next
    End Sub

    Protected Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Response.Redirect("EditMouldDetails.aspx")
    End Sub

End Class