Imports System.Data.SqlClient
Imports System.Data
Imports System.IO
Imports System.Drawing
Imports System.Drawing.Image
Imports System.IO.Stream
Imports System.Collections
Imports System.ComponentModel
Imports System.Web
Imports System.Web.SessionState
Imports System.Web.UI
Imports System.Web.UI.WebControls
Imports System.Web.UI.HtmlControls
Imports E_Management.crmlognetglobal
'Imports TallComponents.PDF
Imports System.Web.Security

Partial Public Class ShippingDetails
    Inherits Messagebox







    Dim MyGlobal As New emanagement.globalinfo
    Dim str As String = MyGlobal.conCRMstr
    Dim mynet As New CRMlognetglobal
    Dim con As New SqlConnection(Str)
    Dim con1 As New SqlConnection(mynet.sConnString)
    Dim Query As String
    Dim datread As SqlClient.SqlDataReader

    Dim Ad1 As New SqlDataAdapter
    Dim TmpDs As New DataSet

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        Dim ob As New CRMlognetglobal
        Dim conStr1
        ob.db_cn()
        conStr1 = ob.sConnString

        Dim con1 As New SqlConnection(conStr1)
        con1.Open()



        If IsPostBack = False Then
            CmbInvoiceNo.Items.Clear()
            CmbInvoiceNo.Items.Add("-Select-")
            Query = "Select invno from InvMaster where INVDate>='11/30/2012' and InvNo Not in(Select InvoiceNo From Log_ShippingDetails) Order By InvDate Desc"
            Dim cmd As New SqlCommand(Query, con1)
            Dim dr As SqlDataReader
            dr = cmd.ExecuteReader
            While dr.Read
                CmbInvoiceNo.Items.Add(dr(0))
            End While
            dr.Close()

            CmbFrom1.Items.Clear()
            CmbFrom2.Items.Clear()
            CmbFrom3.Items.Clear()

            CmbTo1.Items.Clear()
            CmbTo2.Items.Clear()
            CmbTo3.Items.Clear()

            CmbFrom1.Items.Add("-Select-")
            CmbFrom2.Items.Add("-Select-")
            CmbFrom3.Items.Add("-Select-")

            CmbTo1.Items.Add("-Select-")
            CmbTo2.Items.Add("-Select-")
            CmbTo3.Items.Add("-Select-")


            Dim cmd6 As New SqlCommand()
            cmd6 = New SqlClient.SqlCommand("Select Distinct DepartPlace from Log_VehicleQuotation Where ApprovedStatus='Approved' Order By DepartPlace", con1)
            datread = cmd6.ExecuteReader
            Dim j, s, x, y, z
            While (datread.Read())
                s = datread(0)

                If datread(0) <> "" Then
                    CmbFrom1.Items.Add(datread(0))
                    CmbFrom2.Items.Add(datread(0))
                    CmbFrom3.Items.Add(datread(0))
                End If
            End While

            datread.Close()

            'cmd6 = New SqlClient.SqlCommand("Select Distinct ArrivalPlace from Log_VehicleQuotation", con1)
            'datread = cmd6.ExecuteReader

            'While (datread.Read())
            '    x = datread(0)

            '    If datread(0) <> "" Then
            '        CmbTo1.Items.Add(datread(0))
            '        CmbTo2.Items.Add(datread(0))
            '        CmbTo3.Items.Add(datread(0))
            '    End If

            'End While

            'datread.Close()

            

        End If






        con1.Close()




    End Sub

    Protected Sub CmbInvoiceNo_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CmbInvoiceNo.SelectedIndexChanged
        Try



            If CmbInvoiceNo.SelectedIndex = 0 Then
                Exit Sub
            End If
            Dim ob As New CRMlognetglobal
            Dim conStr1
            ob.db_cn()
            conStr1 = sConnString.ToString()

            Dim con1 As New SqlConnection(conStr1)
            con1.Open()
            con.Open()
            

            Dim cmd As New SqlCommand("Select b.invdate, b.TNWeight, TGWeight, Dimension from InvMaster b where b.InvNo= replace('" & CmbInvoiceNo.Text & "',' ','')", con)
            Dim dr As SqlDataReader
            dr = cmd.ExecuteReader
            Dim invdate As Date

            Dim Nw, Gw, Dm As String

            While dr.Read()
                invdate = dr(0)
                TxtInvoiceDate.Text = invdate

                Nw = dr(1)
                Gw = dr(2)
                Dm = dr(3)

                If Nw > Gw Then
                    Session("aweight") = Nw
                Else
                    Session("aweight") = Gw
                End If

            End While
            dr.Close()
            Dim x1, x2, x3, x4, x5, x6, x7 As String
            'Dim cmd2 As New SqlCommand("select a.customer,a.address1,a.address2,a.address3,a.address4,b.destination,b.deliverydate  from custmaster a,log_invoice b  where a.cust_id=b.cust_id and  b.invno=replace(' " & DropDownList1.SelectedItem.Text & " ',' ','') ", con)
            'Dim cmd2 As New SqlCommand("select a.customer,a.address1,a.address2,a.address3,a.address4,b.destination,b.Scdate from custmaster a, InvMaster b where a.cust_id=b.Cust_id and b.invno=replace('" & TxtInvNo.Text & "',' ','')", con)


            Dim cmd2 As New SqlCommand("select a.customer,a.address1,a.address2,a.address3,a.address4,b.destination, b.ShipTerms, b.shipmode from custmaster a, InvMaster b where a.cust_id=b.Cust_id and b.invno=replace('" & CmbInvoiceNo.Text & "',' ','')", con)
            Dim dr1 As SqlDataReader
            dr1 = cmd2.ExecuteReader()
            Do While dr1.Read



                TxtCustomerName.Text = dr1(0)
                Dim add1 As String = dr1(1)
                Dim add2 As String = dr1(2)
                Dim add3 As String = dr1(3)
                Dim add4 As String = dr1(4)
                TxtDestination.Text = dr1(5)
                TxtShippingTerms.Text = dr1(6)
                TxtTransitBy.Text = dr1(7)

                TxtCustomerAddress.Text = add1 & "," & add2 & "," & add3 & "," & add4
            Loop

            If TxtShippingTerms.Text.Substring(0, 3).Trim.Equals("CIF") Then

                LblDestination1.Visible = True

                DGrid1.Visible = True
                CmbForwarder1.Visible = True
                CmbFrom1.Visible = True
                CmbTo1.Visible = True

                LblForwarder1.Visible = True
                LblFrom1.Visible = True
                LblTo1.Visible = True

                LblDestination2.Visible = True


                DGrid2.Visible = True
                CmbForwarder2.Visible = True
                CmbFrom2.Visible = True
                CmbTo2.Visible = True

                LblForwarder2.Visible = True
                LblFrom2.Visible = True
                LblTo2.Visible = True

                LblDestination3.Visible = False

                DGrid3.Visible = False
                CmbForwarder3.Visible = False
                CmbFrom3.Visible = False
                CmbTo3.Visible = False

                LblForwarder3.Visible = False
                LblFrom3.Visible = False
                LblTo3.Visible = False

                LblAFee1.Visible = True
                TxtAFee1.Visible = True
                TxtAFee1.Text = "0"

                LblQFee1.Visible = False
                TxtQFee1.Visible = False
                TxtQFee1.Text = "0"

                LblAFee2.Visible = True
                TxtAFee2.Visible = True
                TxtAFee2.Text = "0"

                LblQFee2.Visible = False
                TxtQFee2.Visible = False
                TxtQFee2.Text = "0"

                LblAFee3.Visible = False
                TxtAFee3.Visible = False
                TxtAFee3.Text = "0"

                LblQFee3.Visible = False
                TxtQFee3.Visible = False
                TxtQFee3.Text = "0"

                LblTransport1.Visible = True
                LblTransport2.Visible = True
                LblTransport3.Visible = False

                CmbTransport1.Visible = True
                CmbTransport2.Visible = True
                CmbTransport3.Visible = False


            ElseIf TxtShippingTerms.Text.Substring(0, 3).Trim.Equals("FOB") Then

                LblDestination1.Visible = True

                DGrid1.Visible = True
                CmbForwarder1.Visible = True
                CmbFrom1.Visible = True
                CmbTo1.Visible = True

                LblDestination2.Visible = False

                DGrid2.Visible = False
                CmbForwarder2.Visible = False
                CmbFrom2.Visible = False
                CmbTo2.Visible = False

                LblDestination3.Visible = False

                DGrid3.Visible = False
                CmbForwarder3.Visible = False
                CmbFrom3.Visible = False
                CmbTo3.Visible = False

                LblForwarder1.Visible = True
                LblFrom1.Visible = True
                LblTo1.Visible = True

                LblForwarder2.Visible = False
                LblFrom2.Visible = False
                LblTo2.Visible = False

                LblForwarder3.Visible = False
                LblFrom3.Visible = False
                LblTo3.Visible = False


                LblAFee1.Visible = True
                TxtAFee1.Visible = True
                TxtAFee1.Text = "0"

                LblQFee1.Visible = False
                TxtQFee1.Visible = False
                TxtQFee1.Text = "0"

                LblAFee2.Visible = False
                TxtAFee2.Visible = False
                TxtAFee2.Text = "0"

                LblQFee2.Visible = False
                TxtQFee2.Visible = False
                TxtQFee2.Text = "0"

                LblAFee3.Visible = False
                TxtAFee3.Visible = False
                TxtAFee3.Text = "0"

                LblQFee3.Visible = False
                TxtQFee3.Visible = False
                TxtQFee3.Text = "0"

                LblTransport1.Visible = True
                LblTransport2.Visible = False
                LblTransport3.Visible = False

                CmbTransport1.Visible = True
                CmbTransport2.Visible = False
                CmbTransport3.Visible = False

            ElseIf TxtShippingTerms.Text.Substring(0, 3).Trim.Equals("DDU") Or TxtShippingTerms.Text.Substring(0, 3).Trim.Equals("DDP") Then

                LblDestination1.Visible = True

                DGrid1.Visible = True
                CmbForwarder1.Visible = True
                CmbFrom1.Visible = True
                CmbTo1.Visible = True

                LblForwarder1.Visible = True
                LblFrom1.Visible = True
                LblTo1.Visible = True

                LblDestination2.Visible = True

                DGrid2.Visible = True
                CmbForwarder2.Visible = True
                CmbFrom2.Visible = True
                CmbTo2.Visible = True

                LblForwarder2.Visible = True
                LblFrom2.Visible = True
                LblTo2.Visible = True

                LblDestination3.Visible = True

                DGrid3.Visible = True
                CmbForwarder3.Visible = True
                CmbFrom3.Visible = True
                CmbTo3.Visible = True

                LblForwarder3.Visible = True
                LblFrom3.Visible = True
                LblTo3.Visible = True


                LblAFee1.Visible = True
                TxtAFee1.Visible = True
                TxtAFee1.Text = "0"

                LblQFee1.Visible = False
                TxtQFee1.Visible = False
                TxtQFee1.Text = "0"

                LblAFee2.Visible = True
                TxtAFee2.Visible = True
                TxtAFee2.Text = "0"

                LblQFee2.Visible = False
                TxtQFee2.Visible = False
                TxtQFee2.Text = "0"

                LblAFee3.Visible = True
                TxtAFee3.Visible = True
                TxtAFee3.Text = "0"

                LblQFee3.Visible = False
                TxtQFee3.Visible = False
                TxtQFee3.Text = "0"

                LblTransport1.Visible = True
                LblTransport2.Visible = True
                LblTransport3.Visible = True

                CmbTransport1.Visible = True
                CmbTransport2.Visible = True
                CmbTransport3.Visible = True

            End If


            dr1.Close()
            con.Close()
            con1.Close()
        Catch ex As Exception
            msg(ex.Message)
        End Try
    End Sub

    Protected Sub CmbTo1_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CmbTo1.SelectedIndexChanged
        Dim ob As New CRMlognetglobal
        Dim conStr1
        ob.db_cn()
        conStr1 = ob.sConnString

        Dim con1 As New SqlConnection(conStr1)
        con1.Open()


        Dim cmd6 As New SqlCommand()
        Dim x
        cmd6 = New SqlClient.SqlCommand("select Distinct TransportName from log_VehicleQuotation A Where ApprovedStatus='Approved' and DepartPlace='" & CmbFrom1.Text & "' and ArrivalPlace='" & CmbTo1.Text & "' Order By TransportName", con1)
        datread = cmd6.ExecuteReader

        CmbTransport1.Items.Clear()
        CmbTransport1.Items.Add("-Select-")

        While (datread.Read())
            x = datread(0)

            If datread(0) <> "" Then
                CmbTransport1.Items.Add(datread(0))
            End If

        End While

        datread.Close()

        con.Close()
    End Sub

    Protected Sub CmbTo2_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CmbTo2.SelectedIndexChanged
        Dim ob As New CRMlognetglobal
        Dim conStr1
        ob.db_cn()
        conStr1 = ob.sConnString

        Dim con1 As New SqlConnection(conStr1)
        con1.Open()


        Dim cmd6 As New SqlCommand()
        Dim x
        cmd6 = New SqlClient.SqlCommand("select Distinct TransportName from log_VehicleQuotation A Where ApprovedStatus='Approved' and DepartPlace='" & CmbFrom2.Text & "' and ArrivalPlace='" & CmbTo2.Text & "'  Order By TransportName", con1)
        datread = cmd6.ExecuteReader

        CmbTransport2.Items.Clear()
        CmbTransport2.Items.Add("-Select-")

        While (datread.Read())
            x = datread(0)

            If datread(0) <> "" Then
                CmbTransport2.Items.Add(datread(0))
            End If

        End While

        datread.Close()

        con.Close()
    End Sub

    Protected Sub CmbTo3_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CmbTo3.SelectedIndexChanged
        Dim ob As New CRMlognetglobal
        Dim conStr1
        ob.db_cn()
        conStr1 = ob.sConnString

        Dim con1 As New SqlConnection(conStr1)
        con1.Open()


        Dim cmd6 As New SqlCommand()
        Dim x
        cmd6 = New SqlClient.SqlCommand("select Distinct TransportName from log_VehicleQuotation A Where ApprovedStatus='Approved' and DepartPlace='" & CmbFrom3.Text & "' and ArrivalPlace='" & CmbTo3.Text & "'  Order By TransportName", con1)
        datread = cmd6.ExecuteReader

        CmbTransport3.Items.Clear()
        CmbTransport3.Items.Add("-Select-")

        While (datread.Read())
            x = datread(0)

            If datread(0) <> "" Then
                CmbTransport3.Items.Add(datread(0))
            End If

        End While

        datread.Close()

        con.Close()
    End Sub

    Protected Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
        FormsAuthentication.RedirectFromLoginPage(Session("userID"), True)
        Response.Redirect("../HRMIS/Default.aspx")
    End Sub

    Protected Sub CmbFrom1_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CmbFrom1.SelectedIndexChanged

        Dim ob As New CRMlognetglobal
        Dim conStr1
        ob.db_cn()
        conStr1 = ob.sConnString

        Dim con1 As New SqlConnection(conStr1)
        con1.Open()

        Dim cmd6 As New SqlCommand()
        Dim x

        cmd6 = New SqlClient.SqlCommand("Select Distinct ArrivalPlace from Log_VehicleQuotation Where ApprovedStatus='Approved' and DepartPlace='" & CmbFrom1.Text & "' Order By ArrivalPlace", con1)
        datread = cmd6.ExecuteReader

        CmbTo1.Items.Clear()
        CmbTo1.Items.Add("-Select-")

        While (datread.Read())
            x = datread(0)

            If datread(0) <> "" Then
                CmbTo1.Items.Add(datread(0))
            End If

        End While

        datread.Close()
    End Sub

    Protected Sub CmbFrom2_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CmbFrom2.SelectedIndexChanged
        Dim ob As New CRMlognetglobal
        Dim conStr1
        ob.db_cn()
        conStr1 = ob.sConnString

        Dim con1 As New SqlConnection(conStr1)
        con1.Open()

        Dim cmd6 As New SqlCommand()
        Dim x

        cmd6 = New SqlClient.SqlCommand("Select Distinct ArrivalPlace from Log_VehicleQuotation Where ApprovedStatus='Approved' and DepartPlace='" & CmbFrom2.Text & "'  Order By ArrivalPlace", con1)
        datread = cmd6.ExecuteReader

        CmbTo2.Items.Clear()
        CmbTo2.Items.Add("-Select-")

        While (datread.Read())
            x = datread(0)

            If datread(0) <> "" Then
                CmbTo2.Items.Add(datread(0))
            End If

        End While

        datread.Close()
    End Sub

    Protected Sub CmbFrom3_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CmbFrom3.SelectedIndexChanged
        Dim ob As New CRMlognetglobal
        Dim conStr1
        ob.db_cn()
        conStr1 = ob.sConnString

        Dim con1 As New SqlConnection(conStr1)
        con1.Open()

        Dim cmd6 As New SqlCommand()
        Dim x

        cmd6 = New SqlClient.SqlCommand("Select Distinct ArrivalPlace from Log_VehicleQuotation Where ApprovedStatus='Approved' and DepartPlace='" & CmbFrom3.Text & "'  Order By ArrivalPlace", con1)
        datread = cmd6.ExecuteReader

        CmbTo3.Items.Clear()
        CmbTo3.Items.Add("-Select-")

        While (datread.Read())
            x = datread(0)

            If datread(0) <> "" Then
                CmbTo3.Items.Add(datread(0))
            End If

        End While

        datread.Close()
    End Sub

    Protected Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click

        Try

            If CmbInvoiceNo.Text = "-Select-" Or CmbInvoiceNo.Text = "" Then
                msg("Please Select Valid Invoice No")
                Exit Sub

            End If

            Dim From1 As String
            Dim To1 As String
            Dim Forwarder1 As String

            If CmbFrom1.Text = "-Select" Then
                From1 = ""
            Else
                From1 = CmbFrom1.Text
            End If


            If CmbTo1.Text = "-Select" Then
                To1 = ""
            Else
                To1 = CmbTo1.Text
            End If

            If CmbForwarder1.Text = "-Select" Or CmbForwarder1.Text = "" Then
                Forwarder1 = ""
            Else
                Forwarder1 = CmbForwarder1.Text
            End If


            Dim From2 As String
            Dim To2 As String
            Dim Forwarder2 As String

            If CmbFrom2.Text = "-Select" Then
                From2 = ""
            Else
                From2 = CmbFrom2.Text
            End If


            If CmbTo2.Text = "-Select" Then
                To2 = ""
            Else
                To2 = CmbTo2.Text
            End If

            If CmbForwarder2.Text = "-Select" Or CmbForwarder2.Text = "" Then
                Forwarder2 = ""
            Else
                Forwarder2 = CmbForwarder2.Text
            End If

            Dim From3 As String
            Dim To3 As String
            Dim Forwarder3 As String

            If CmbFrom3.Text = "-Select" Then
                From3 = ""
            Else
                From3 = CmbFrom3.Text
            End If


            If CmbTo3.Text = "-Select" Then
                To3 = ""
            Else
                To3 = CmbTo3.Text
            End If

            If CmbForwarder3.Text = "-Select" Or CmbForwarder1.Text = "" Then
                Forwarder3 = ""
            Else
                Forwarder3 = CmbForwarder3.Text
            End If


            Dim ob As New CRMlognetglobal
            Dim conStr1
            ob.db_cn()
            conStr1 = ob.sConnString

            Dim con1 As New SqlConnection(conStr1)
            con1.Open()

            Dim cmd6 As New SqlCommand()

            TxtCustomerName.Text = (TxtCustomerName.Text.Replace("'", " "))
            TxtCustomerAddress.Text = (TxtCustomerAddress.Text.Replace("'", " "))

            Dim Da1 As New SqlDataAdapter
            Dim TmpDs As New DataSet

            cmd6 = New SqlClient.SqlCommand("Select * From Log_ShippingDetails Where InvoiceNo='" & CmbInvoiceNo.Text & "'", con1)
            Da1 = New SqlDataAdapter(cmd6)
            Da1.Fill(TmpDs, "Grid1")

            If TmpDs.Tables(0).Rows.Count >= 1 Then
                con1.Close()
                msg("Shipping Details Already Updated")
                Exit Sub
            End If

            Dim x

            Dim TtlAmount As Double
            TtlAmount = (Val(TxtAFee1.Text) + Val(TxtAFee2.Text) + Val(TxtAFee3.Text))


            cmd6 = New SqlClient.SqlCommand("Insert Into Log_ShippingDetails (InvoiceNo,InvoiceDate,CustomerName,Address,ShippingTerms,Destination,TransitBy,From1,To1,Forwarder1,QAmount1,AAmount1,From2,To2,Forwarder2,QAmount2,AAmount2,From3,To3,Forwarder3,QAmount3,AAmount3,OverallAmount,CreatedBy,CreatedOn,Transport1, Transport2, Transport3, Remarks1, Remarks2, Remarks3 ) Values ('" & CmbInvoiceNo.Text & "','" & TxtInvoiceDate.Text & "','" & TxtCustomerName.Text & "','" & TxtCustomerAddress.Text & "','" & TxtShippingTerms.Text & "','" & TxtDestination.Text & "','" & TxtTransitBy.Text & "','" & From1 & "','" & To1 & "','" & Forwarder1 & "','" & TxtQFee1.Text & "','" & TxtAFee1.Text & "','" & From2 & "','" & To2 & "','" & Forwarder2 & "','" & TxtQFee2.Text & "','" & TxtAFee2.Text & "','" & From3 & "','" & To3 & "','" & Forwarder3 & "','" & TxtQFee3.Text & "','" & TxtAFee3.Text & "'," & TtlAmount & ",'" & Session("empcode").ToString & "','" & DateTime.Now() & "','" & CmbTransport1.Text & "','" & CmbTransport2.Text & "','" & CmbTransport3.Text & "','" & TxtRemarks1.Text & "','" & TxtRemarks2.Text & "','" & TxtRemarks3.Text & "')", con1)
            cmd6.ExecuteNonQuery()
            msg("Successfully Updated!")
            con1.Close()


        Catch ex As Exception
            con1.Close()
            msg("Invalid Data")
        End Try


        CmbInvoiceNo.SelectedItem.Text = "-Select-"
        TxtAFee1.Text = "0"
        TxtAFee2.Text = "0"
        TxtAFee3.Text = "0"
        TxtCustomerAddress.Text = ""
        TxtCustomerName.Text = ""
        TxtDestination.Text = ""
        TxtInvoiceDate.Text = ""
        TxtQFee1.Text = "0"
        TxtQFee2.Text = "0"
        TxtQFee3.Text = "0"
        TxtShippingTerms.Text = ""
        TxtTransitBy.Text = ""

        TxtRemarks1.Text = "-"
        TxtRemarks2.Text = "-"
        TxtRemarks3.Text = "-"

        DGrid1.DataSource = Nothing
        DGrid1.DataBind()

        DGrid2.DataSource = Nothing
        DGrid2.DataBind()

        DGrid3.DataSource = Nothing
        DGrid3.DataBind()

        CmbFrom1.Text = "-Select-"
        CmbFrom2.Text = "-Select-"
        CmbFrom3.Text = "-Select-"

        CmbTo1.Text = "-Select-"
        CmbTo2.Text = "-Select-"
        CmbTo3.Text = "-Select-"

        CmbTransport1.Text = "-Select-"
        CmbTransport2.Text = "-Select-"
        CmbTransport3.Text = "-Select-"

        CmbForwarder1.Text = "-Select-"
        CmbForwarder2.Text = "-Select-"
        CmbForwarder3.Text = "-Select-"


    End Sub

    Protected Sub Button4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button4.Click

        If Button4.Text = "On" Then

            Button4.Text = "Off"

            LblDestination1.Visible = True

            DGrid1.Visible = True
            CmbForwarder1.Visible = True
            CmbFrom1.Visible = True
            CmbTo1.Visible = True

            LblForwarder1.Visible = True
            LblFrom1.Visible = True
            LblTo1.Visible = True

            LblDestination2.Visible = True

            DGrid2.Visible = True
            CmbForwarder2.Visible = True
            CmbFrom2.Visible = True
            CmbTo2.Visible = True

            LblForwarder2.Visible = True
            LblFrom2.Visible = True
            LblTo2.Visible = True

            LblDestination3.Visible = True

            DGrid3.Visible = True
            CmbForwarder3.Visible = True
            CmbFrom3.Visible = True
            CmbTo3.Visible = True

            LblForwarder3.Visible = True
            LblFrom3.Visible = True
            LblTo3.Visible = True


            LblAFee1.Visible = True
            TxtAFee1.Visible = True
            TxtAFee1.Text = "0"

            LblQFee1.Visible = True
            TxtQFee1.Visible = True
            TxtQFee1.Text = "0"

            LblAFee2.Visible = True
            TxtAFee2.Visible = True
            TxtAFee2.Text = "0"

            LblQFee2.Visible = True
            TxtQFee2.Visible = True
            TxtQFee2.Text = "0"

            LblAFee3.Visible = True
            TxtAFee3.Visible = True
            TxtAFee3.Text = "0"

            LblQFee3.Visible = True
            TxtQFee3.Visible = True
            TxtQFee3.Text = "0"
        Else
            Button4.Text = "On"

            LblDestination1.Visible = False

            DGrid1.Visible = False
            CmbForwarder1.Visible = False
            CmbFrom1.Visible = False
            CmbTo1.Visible = False

            LblForwarder1.Visible = False
            LblFrom1.Visible = False
            LblTo1.Visible = False

            LblDestination2.Visible = False

            DGrid2.Visible = False
            CmbForwarder2.Visible = False
            CmbFrom2.Visible = False
            CmbTo2.Visible = False

            LblForwarder2.Visible = False
            LblFrom2.Visible = False
            LblTo2.Visible = False

            LblDestination3.Visible = False

            DGrid3.Visible = False
            CmbForwarder3.Visible = False
            CmbFrom3.Visible = False
            CmbTo3.Visible = False

            LblForwarder3.Visible = False
            LblFrom3.Visible = False
            LblTo3.Visible = False


            LblAFee1.Visible = False
            TxtAFee1.Visible = False
            TxtAFee1.Text = "0"

            LblQFee1.Visible = False
            TxtQFee1.Visible = False
            TxtQFee1.Text = "0"

            LblAFee2.Visible = False
            TxtAFee2.Visible = False
            TxtAFee2.Text = "0"

            LblQFee2.Visible = False
            TxtQFee2.Visible = False
            TxtQFee2.Text = "0"

            LblAFee3.Visible = False
            TxtAFee3.Visible = False
            TxtAFee3.Text = "0"

            LblQFee3.Visible = False
            TxtQFee3.Visible = False
            TxtQFee3.Text = "0"

        End If

    End Sub

    Protected Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        CmbInvoiceNo.SelectedItem.Text = "-Select-"
        TxtAFee1.Text = "0"
        TxtAFee2.Text = "0"
        TxtAFee3.Text = "0"
        TxtCustomerAddress.Text = ""
        TxtCustomerName.Text = ""
        TxtDestination.Text = ""
        TxtInvoiceDate.Text = ""
        TxtQFee1.Text = "0"
        TxtQFee2.Text = "0"
        TxtQFee3.Text = "0"
        TxtShippingTerms.Text = ""
        TxtTransitBy.Text = ""


    End Sub

    Protected Sub CmbForwarder1_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CmbForwarder1.SelectedIndexChanged

        Dim Aweight, weight, Amount, FId, OtherExp As String

        Dim S As String()
        S = CmbForwarder1.Text.Split("-")
        FId = S(0)

        Dim ob As New CRMlognetglobal
        Dim conStr1
        ob.db_cn()
        conStr1 = ob.sConnString

        Dim con1 As New SqlConnection(conStr1)
        con1.Open()

        Dim cmd6 As New SqlCommand()
        cmd6 = New SqlCommand("Select Top 1 * From Log_VehicleQuotation Where ApprovedStatus='Approved' and F_ID='" & FId & "' and DepartPlace='" & CmbFrom1.Text & "' and ArrivalPlace='" & CmbTo1.Text & "' and TransportName='" & CmbTransport1.Text & "' and EffectiveDate<='" & DateTime.Today & "' order by effectivedate desc ", con1)
        Ad1 = New SqlDataAdapter(cmd6)
        TmpDs = New DataSet
        Ad1.Fill(TmpDs, "Cal")

        If TmpDs.Tables(0).Rows.Count >= 1 Then
            weight = TmpDs.Tables(0).Rows(0).Item("Weight")
            Amount = TmpDs.Tables(0).Rows(0).Item("Amount")
            OtherExp = TmpDs.Tables(0).Rows(0).Item("Otherexpenses")

        Else
            msg("No Recrod Available for the Specify Forwarder")
            con1.Close()
            Exit Sub
        End If

        Dim cal As Double
        Dim FAmount As Double

        cal = Session("aweight").ToString() / weight
        If cal >= 1 Then
            cal = Math.Ceiling(cal)
            FAmount = cal * Amount
            FAmount = (Val(FAmount) + Val(TmpDs.Tables(0).Rows(0).Item("OtherExpenses")))
        Else
            FAmount = TmpDs.Tables(0).Rows(0).Item("Minimumcharge")
            FAmount = (Val(FAmount) + Val(TmpDs.Tables(0).Rows(0).Item("OtherExpenses")))

        End If

        TxtAFee1.Text = FAmount.ToString


        Dim Item As GridViewRow

        For Each Item In DGrid1.Rows
            Dim FrId As String

            FrId = Item.Cells(0).Text

            If FrId = FId Then
                Dim Deduct As String = Item.Cells(6).Text
                TxtAFee1.Text = Val(TxtAFee1.Text) - (Val(TxtAFee1.Text) * Deduct) / 100
            End If

        Next

        If Not Session("f1").Equals(Null) Then
            If Not Session("f1") = CmbForwarder1.Text Then
                msg("Please Enter Reason to Select this Forwarder")
                LblRemarks1.Visible = True
                TxtRemarks1.Visible = True
                TxtRemarks1.Focus()
            Else
                LblRemarks1.Visible = False
                TxtRemarks1.Visible = False
            End If
        Else
            LblRemarks1.Visible = False
            TxtRemarks1.Visible = False
        End If

    End Sub

    Protected Sub CmbForwarder2_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CmbForwarder2.SelectedIndexChanged
        Dim Aweight, weight, Amount, FId, OtherExp As String

        Dim S As String()
        S = CmbForwarder2.Text.Split("-")
        FId = S(0)

        Dim ob As New CRMlognetglobal
        Dim conStr1
        ob.db_cn()
        conStr1 = ob.sConnString

        Dim con1 As New SqlConnection(conStr1)
        con1.Open()

        Dim cmd6 As New SqlCommand()
        cmd6 = New SqlCommand("Select * From Log_VehicleQuotation Where ApprovedStatus='Approved' and F_ID='" & FId & "' and DepartPlace='" & CmbFrom2.Text & "' and ArrivalPlace='" & CmbTo2.Text & "' and TransportName='" & CmbTransport2.Text & "' and EffectiveDate<='" & DateTime.Today & "' order by effectivedate desc ", con1)
        Ad1 = New SqlDataAdapter(cmd6)
        TmpDs = New DataSet
        Ad1.Fill(TmpDs, "Cal")

        If TmpDs.Tables(0).Rows.Count >= 1 Then
            weight = TmpDs.Tables(0).Rows(0).Item("Weight")
            Amount = TmpDs.Tables(0).Rows(0).Item("Amount")
            OtherExp = TmpDs.Tables(0).Rows(0).Item("Otherexpenses")

        Else
            msg("No Recrod Available for the Specify Forwarder")
            con1.Close()
            Exit Sub
        End If

        Dim cal As Double
        Dim FAmount As Double

        cal = Session("aweight").ToString() / weight
        If cal >= 1 Then
            cal = Math.Ceiling(cal)
            FAmount = cal * Amount
            FAmount = (Val(FAmount) + Val(TmpDs.Tables(0).Rows(0).Item("OtherExpenses")))
        Else
            FAmount = TmpDs.Tables(0).Rows(0).Item("Minimumcharge")
            FAmount = (Val(FAmount) + Val(TmpDs.Tables(0).Rows(0).Item("OtherExpenses")))

        End If

        TxtAFee2.Text = FAmount.ToString


        Dim Item As GridViewRow

        For Each Item In DGrid2.Rows
            Dim FrId As String

            FrId = Item.Cells(0).Text

            If FrId = FId Then
                Dim Deduct As String = Item.Cells(6).Text
                TxtAFee2.Text = Val(TxtAFee2.Text) - (Val(TxtAFee2.Text) * Deduct) / 100
            End If


        Next

        If Not Session("f2").Equals(Null) Then
            If Not Session("f2") = CmbForwarder2.Text Then
                msg("Please Enter Reason to Select this Forwarder")
                LblRemarks2.Visible = True
                TxtRemarks2.Visible = True
                TxtRemarks2.Focus()
            Else
                LblRemarks2.Visible = False
                TxtRemarks2.Visible = False
            End If
        Else
            LblRemarks2.Visible = False
            TxtRemarks2.Visible = False
        End If



        con1.Close()
    End Sub

    Protected Sub CmbForwarder3_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CmbForwarder3.SelectedIndexChanged
        Dim Aweight, weight, Amount, FId, OtherExp As String

        Dim S As String()
        S = CmbForwarder3.Text.Split("-")
        FId = S(0)

        Dim ob As New CRMlognetglobal
        Dim conStr1
        ob.db_cn()
        conStr1 = ob.sConnString

        Dim con1 As New SqlConnection(conStr1)
        con1.Open()

        Dim cmd6 As New SqlCommand()
        cmd6 = New SqlCommand("Select * From Log_VehicleQuotation Where ApprovedStatus='Approved' and F_ID='" & FId & "' and DepartPlace='" & CmbFrom3.Text & "' and ArrivalPlace='" & CmbTo3.Text & "' and TransportName='" & CmbTransport2.Text & "' and EffectiveDate<='" & DateTime.Today & "' order by effectivedate desc ", con1)
        Ad1 = New SqlDataAdapter(cmd6)
        TmpDs = New DataSet
        Ad1.Fill(TmpDs, "Cal")

        If TmpDs.Tables(0).Rows.Count >= 1 Then
            weight = TmpDs.Tables(0).Rows(0).Item("Weight")
            Amount = TmpDs.Tables(0).Rows(0).Item("Amount")
            OtherExp = TmpDs.Tables(0).Rows(0).Item("Otherexpenses")

        Else
            msg("No Recrod Available for the Specify Forwarder")
            con1.Close()
            Exit Sub

        End If

        Dim cal As Double
        Dim FAmount As Double

        cal = Session("aweight").ToString() / weight
        If cal >= 1 Then
            cal = Math.Ceiling(cal)
            FAmount = cal * Amount
            FAmount = (Val(FAmount) + Val(TmpDs.Tables(0).Rows(0).Item("OtherExpenses")))
        Else
            FAmount = TmpDs.Tables(0).Rows(0).Item("Minimumcharge")
            FAmount = (Val(FAmount) + Val(TmpDs.Tables(0).Rows(0).Item("OtherExpenses")))

        End If

        TxtAFee3.Text = FAmount.ToString


        Dim Item As GridViewRow

        For Each Item In DGrid3.Rows
            Dim FrId As String

            FrId = Item.Cells(0).Text

            If FrId = FId Then
                Dim Deduct As String = Item.Cells(6).Text
                TxtAFee3.Text = Val(TxtAFee3.Text) - (Val(TxtAFee3.Text) * Deduct) / 100
            End If


        Next


        If Not Session("f3").Equals(Null) Then
            If Not Session("f3") = CmbForwarder3.Text Then
                msg("Please Enter Reason to Select this Forwarder")
                LblRemarks3.Visible = True
                TxtRemarks3.Visible = True
                TxtRemarks3.Focus()
            Else
                LblRemarks3.Visible = False
                TxtRemarks3.Visible = False
            End If
        Else
            LblRemarks3.Visible = False
            TxtRemarks3.Visible = False
        End If


        con1.Close()
    End Sub

    

    Protected Sub CmbTransport2_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CmbTransport2.SelectedIndexChanged

        Session("f2") = Null

        Dim ob As New CRMlognetglobal
        Dim conStr1
        ob.db_cn()
        conStr1 = ob.sConnString

        Dim con1 As New SqlConnection(conStr1)
        con1.Open()

        Dim cmd6 As New SqlCommand()
        Dim x
        cmd6 = New SqlClient.SqlCommand("select Distinct A.f_id,B.F_Name from log_VehicleQuotation A, Log_ForwardersMaster B where ApprovedStatus='Approved' and A.F_Id=B.F_Id and DepartPlace='" & CmbFrom2.Text & "' and ArrivalPlace='" & CmbTo2.Text & "' and TransportName='" & CmbTransport2.Text & "'  Order By B.F_Name", con1)
        datread = cmd6.ExecuteReader

        CmbForwarder2.Items.Clear()
        CmbForwarder2.Items.Add("-Select-")

        While (datread.Read())
            x = datread(0)

            If datread(0) <> "" Then
                CmbForwarder2.Items.Add(datread(0) & "-" & datread(1))
            End If

        End While

        datread.Close()



        Dim Da1 As New SqlDataAdapter
        Dim TmpDs As New DataSet

        cmd6 = New SqlClient.SqlCommand("select Distinct A.F_ID, C.F_Name, A.CurrName, A.Weight, A.Amount, A.OtherExpenses as OtherExpenses, C.Deduction as Deduction from log_VehicleQuotation A, Log_ForOtherExpenseDump B, Log_ForwardersMaster C where ApprovedStatus='Approved' and A.F_Id=B.F_Id and A.F_Id=C.F_Id and B.F_Id=C.F_Id and A.DepartPlace='" & CmbFrom2.Text & "' and A.ArrivalPlace='" & CmbTo2.Text & "' and TransportName='" & CmbTransport2.Text & "'  Order by C.F_Name", con1)
        Da1 = New SqlDataAdapter(cmd6)
        Da1.Fill(TmpDs, "Grid1")
        DGrid2.DataSource = TmpDs.Tables(0)
        DGrid2.DataBind()


        Dim Amt1 As Integer = 0
        Dim Amt2 As Integer = 0
        For Tmpi1 As Integer = 0 To TmpDs.Tables(0).Rows.Count - 1
            If Tmpi1 >= 1 Then
                Amt1 = ((Val(TmpDs.Tables(0).Rows(Tmpi1 - 1).Item(4)) / Val(TmpDs.Tables(0).Rows(Tmpi1 - 1).Item(3))) + Val(TmpDs.Tables(0).Rows(Tmpi1 - 1).Item(5)))
                Amt2 = ((Val(TmpDs.Tables(0).Rows(Tmpi1).Item(4)) / Val(TmpDs.Tables(0).Rows(Tmpi1).Item(3))) + Val(TmpDs.Tables(0).Rows(Tmpi1).Item(5)))


                Amt1 = Val(Amt1) + (Val(Amt1) * (Val(TmpDs.Tables(0).Rows(Tmpi1 - 1).Item(6)) / 100))
                Amt2 = Val(Amt2) + (Val(Amt2) * (Val(TmpDs.Tables(0).Rows(Tmpi1).Item(6)) / 100))


                If Amt1 = Amt2 Then
                    DGrid2.Rows(Tmpi1 - 1).BackColor = Color.Green
                    DGrid2.Rows(Tmpi1).BackColor = Color.Green
                ElseIf Amt1 < Amt2 Then
                    DGrid2.Rows(Tmpi1 - 1).BackColor = Color.Green
                    DGrid2.Rows(Tmpi1).BackColor = Color.Red

                    Session("f2") = TmpDs.Tables(0).Rows(Tmpi1 - 1).Item(0) & "-" & TmpDs.Tables(0).Rows(Tmpi1 - 1).Item(1)
                Else
                    DGrid2.Rows(Tmpi1 - 1).BackColor = Color.Red
                    DGrid2.Rows(Tmpi1).BackColor = Color.Green

                    Session("f2") = TmpDs.Tables(0).Rows(Tmpi1).Item(0) & "-" & TmpDs.Tables(0).Rows(Tmpi1).Item(1)
                End If

            End If
        Next

        con.Close()
    End Sub

   

    Protected Sub CmbTransport3_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CmbTransport3.SelectedIndexChanged

        Session("f3") = Null

        Dim ob As New CRMlognetglobal
        Dim conStr1
        ob.db_cn()
        conStr1 = ob.sConnString

        Dim con1 As New SqlConnection(conStr1)
        con1.Open()

        Dim cmd6 As New SqlCommand()
        Dim x
        cmd6 = New SqlClient.SqlCommand("select Distinct A.f_id,B.F_Name from log_VehicleQuotation A, Log_ForwardersMaster B where ApprovedStatus='Approved' and A.F_Id=B.F_Id and DepartPlace='" & CmbFrom3.Text & "' and ArrivalPlace='" & CmbTo3.Text & "' and TransportName='" & CmbTransport3.Text & "' Order By B.F_Name", con1)
        datread = cmd6.ExecuteReader

        CmbForwarder3.Items.Clear()
        CmbForwarder3.Items.Add("-Select-")

        While (datread.Read())
            x = datread(0)

            If datread(0) <> "" Then
                CmbForwarder3.Items.Add(datread(0) & "-" & datread(1))
            End If

        End While

        datread.Close()



        Dim Da1 As New SqlDataAdapter
        Dim TmpDs As New DataSet

        cmd6 = New SqlClient.SqlCommand("select Distinct A.F_ID, C.F_Name, A.CurrName, A.Weight, A.Amount, A.OtherExpenses as OtherExpenses , C.Deduction as Deduction from log_VehicleQuotation A, Log_ForOtherExpenseDump B, Log_ForwardersMaster C where ApprovedStatus='Approved' and A.F_Id=B.F_Id and A.F_Id=C.F_Id and B.F_Id=C.F_Id and A.DepartPlace='" & CmbFrom3.Text & "' and A.ArrivalPlace='" & CmbTo3.Text & "' and TransportName='" & CmbTransport3.Text & "'  Order by C.F_Name", con1)
        Da1 = New SqlDataAdapter(cmd6)
        Da1.Fill(TmpDs, "Grid1")
        DGrid3.DataSource = TmpDs.Tables(0)
        DGrid3.DataBind()

        Dim Amt1 As Integer = 0
        Dim Amt2 As Integer = 0
        For Tmpi1 As Integer = 0 To TmpDs.Tables(0).Rows.Count - 1
            If Tmpi1 >= 1 Then
                Amt1 = ((Val(TmpDs.Tables(0).Rows(Tmpi1 - 1).Item(4)) / Val(TmpDs.Tables(0).Rows(Tmpi1 - 1).Item(3))) + Val(TmpDs.Tables(0).Rows(Tmpi1 - 1).Item(5)))
                Amt2 = ((Val(TmpDs.Tables(0).Rows(Tmpi1).Item(4)) / Val(TmpDs.Tables(0).Rows(Tmpi1).Item(3))) + Val(TmpDs.Tables(0).Rows(Tmpi1).Item(5)))

                Amt1 = Val(Amt1) + (Val(Amt1) * (Val(TmpDs.Tables(0).Rows(Tmpi1 - 1).Item(6)) / 100))
                Amt2 = Val(Amt2) + (Val(Amt2) * (Val(TmpDs.Tables(0).Rows(Tmpi1).Item(6)) / 100))

                If Amt1 = Amt2 Then
                    DGrid3.Rows(Tmpi1 - 1).BackColor = Color.Green
                    DGrid3.Rows(Tmpi1).BackColor = Color.Green
                ElseIf Amt1 < Amt2 Then
                    DGrid3.Rows(Tmpi1 - 1).BackColor = Color.Green
                    DGrid3.Rows(Tmpi1).BackColor = Color.Red

                    Session("f3") = TmpDs.Tables(0).Rows(Tmpi1 - 1).Item(0) & "-" & TmpDs.Tables(0).Rows(Tmpi1 - 1).Item(1)

                Else
                    DGrid3.Rows(Tmpi1 - 1).BackColor = Color.Red
                    DGrid3.Rows(Tmpi1).BackColor = Color.Green

                    Session("f3") = TmpDs.Tables(0).Rows(Tmpi1).Item(0) & "-" & TmpDs.Tables(0).Rows(Tmpi1).Item(1)
                End If

            End If
        Next
        con.Close()
    End Sub

    Protected Sub CmbTransport1_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CmbTransport1.SelectedIndexChanged

        Session("f1") = Null

        Dim ob As New CRMlognetglobal
        Dim conStr1
        ob.db_cn()
        conStr1 = ob.sConnString

        Dim con1 As New SqlConnection(conStr1)
        con1.Open()

        Dim cmd6 As New SqlCommand()
        Dim x
        cmd6 = New SqlClient.SqlCommand("select Distinct A.f_id,B.F_Name from log_VehicleQuotation A, Log_ForwardersMaster B where ApprovedStatus='Approved' and A.F_Id=B.F_Id and DepartPlace='" & CmbFrom1.Text & "' and ArrivalPlace='" & CmbTo1.Text & "' and TransportName='" & CmbTransport1.Text & "'  Order By B.F_Name", con1)
        datread = cmd6.ExecuteReader

        CmbForwarder1.Items.Clear()
        CmbForwarder1.Items.Add("-Select-")

        While (datread.Read())
            x = datread(0)

            If datread(0) <> "" Then
                CmbForwarder1.Items.Add(datread(0) & "-" & datread(1))
            End If

        End While

        datread.Close()



        Dim Da1 As New SqlDataAdapter
        Dim TmpDs As New DataSet

        cmd6 = New SqlClient.SqlCommand("select Distinct A.F_ID, C.F_Name, A.CurrName, A.Weight, A.Amount, A.OtherExpenses as OtherExpenses, C.Deduction as Deduction from log_VehicleQuotation A, Log_ForOtherExpenseDump B, Log_ForwardersMaster C where ApprovedStatus='Approved' and A.F_Id=B.F_Id and A.F_Id=C.F_Id and B.F_Id=C.F_Id and A.DepartPlace='" & CmbFrom1.Text & "' and A.ArrivalPlace='" & CmbTo1.Text & "' and TransportName='" & CmbTransport1.Text & "' Order by C.F_Name", con1)
        Da1 = New SqlDataAdapter(cmd6)
        Da1.Fill(TmpDs, "Grid1")
        DGrid1.DataSource = TmpDs.Tables(0)
        DGrid1.DataBind()

        Dim Amt1 As Integer = 0
        Dim Amt2 As Integer = 0
        For Tmpi1 As Integer = 0 To TmpDs.Tables(0).Rows.Count - 1


            If Tmpi1 >= 1 Then
                Amt1 = ((Val(TmpDs.Tables(0).Rows(Tmpi1 - 1).Item(4)) / Val(TmpDs.Tables(0).Rows(Tmpi1 - 1).Item(3))) + Val(TmpDs.Tables(0).Rows(Tmpi1 - 1).Item(5)))
                Amt2 = ((Val(TmpDs.Tables(0).Rows(Tmpi1).Item(4)) / Val(TmpDs.Tables(0).Rows(Tmpi1).Item(3))) + Val(TmpDs.Tables(0).Rows(Tmpi1).Item(5)))

                Amt1 = Val(Amt1) + (Val(Amt1) * (Val(TmpDs.Tables(0).Rows(Tmpi1 - 1).Item(6)) / 100))
                Amt2 = Val(Amt2) + (Val(Amt2) * (Val(TmpDs.Tables(0).Rows(Tmpi1).Item(6)) / 100))

                If Amt1 = Amt2 Then
                    DGrid1.Rows(Tmpi1 - 1).BackColor = Color.Green
                    DGrid1.Rows(Tmpi1).BackColor = Color.Green

                ElseIf Amt1 < Amt2 Then
                    DGrid1.Rows(Tmpi1 - 1).BackColor = Color.Green
                    DGrid1.Rows(Tmpi1).BackColor = Color.Red
                    Session("f1") = TmpDs.Tables(0).Rows(Tmpi1 - 1).Item(0) & "-" & TmpDs.Tables(0).Rows(Tmpi1 - 1).Item(1)

                Else
                    DGrid1.Rows(Tmpi1 - 1).BackColor = Color.Red
                    DGrid1.Rows(Tmpi1).BackColor = Color.Green
                    Session("f1") = TmpDs.Tables(0).Rows(Tmpi1).Item(0) & "-" & TmpDs.Tables(0).Rows(Tmpi1).Item(1)

                End If

            End If
        Next

        con.Close()

    End Sub
End Class