Public Class frmFoodOrders
    'WHEN CODING FOR THE TOTAL PRICE, USE THE PRICES FROM frmFood THEN PROGRAM FOR THE TXTBOX TO SUB TOGETHER

    Private Sub frmOrders_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        DisplayDataInListBox()
        lblNumberofRecords.Text = LOF(3) / Len(FoodOrderRecord)
        If lblNumberofRecords.Text > 0 Then ReadRecord()

        'taing the data from orders form
        cmbOrderID.Items.Clear()

        For i = 1 To LOF(4) / Len(OrderRecord)
            FileGet(4, OrderRecord, i)
            cmbOrderID.Items.Add(OrderRecord.OrderID)
        Next i

        'taking data from customers form
        cmbCustomerID.Items.Clear()

        For i = 1 To LOF(1) / Len(CustomerRecord)
            FileGet(1, CustomerRecord, i)
            cmbCustomerID.Items.Add(CustomerRecord.CustomerID)
        Next i

    End Sub

    Private Sub btnMenu_Click_1(sender As Object, e As EventArgs) Handles btnMenu.Click
        Me.Hide()
        frmMainMenu.Show()
    End Sub
    Private Sub CalculatingTotals()
        '   Dim Total As Single = 0


    End Sub
    Private Sub SaveRecord()
        'A SUB PROGRAM FOR WHENEVER A BUTTON IS PRESSED - MAINLY SAVE RECORD

        FoodOrderRecord.OrderID = cmbOrderID.Text
        FoodOrderRecord.CustomerID = cmbCustomerID.Text
        FoodOrderRecord.DateofOrder = txtDateOfOrder.Text
        FoodOrderRecord.TotalCost = txtTotalCost.Text
        FoodOrderRecord.Status = cmbStatus.Text

        FilePut(3, FoodOrderRecord, CInt(lblRecordNumber.Text))
        lblNumberofRecords.Text = LOF(3) / Len(CustomerRecord)
    End Sub

    Public Sub ReadRecord()
        FileGet(3, FoodOrderRecord, CInt(lblRecordNumber.Text))

        cmbOrderID.Text = FoodOrderRecord.OrderID
        cmbCustomerID.Text = FoodOrderRecord.CustomerID
        txtDateOfOrder.Text = FoodOrderRecord.DateOfOrder
        txtTotalCost.Text = Format(FoodOrderRecord.TotalCost, "0.00")
        cmbStatus.Text = FoodOrderRecord.Status
    End Sub
    Public Sub DisplayDataInListBox()
        Dim i As Integer

        lstFoodOrders.Items.Clear()
        lstFoodOrders.Items.Add(" Cheerful Dragon :  Food Orders")
        lstFoodOrders.Items.Add("--------------------------------")
        lstFoodOrders.Items.Add("#  Order ID    Customer ID   Date Of Order   Total Cost   Status")
        lstFoodOrders.Items.Add("- ----------  ------------- --------------- ------------ ---------")


        For i = 1 To (LOF(3) / Len(FoodOrderRecord))
            lblPlaceValue.Text = i
            FileGet(1, CustomerRecord, i)
            lstFoodOrders.Items.Add(lblPlaceValue.Text & "    " & FoodOrderRecord.OrderID & "        " & FoodOrderRecord.DateOfOrder & "      " & FoodOrderRecord.CustomerID & "       " & FoodOrderRecord.TotalCost & "   " & FoodOrderRecord.Status)
        Next i
    End Sub
    'CODE FOR BUTTONS
    Private Sub btnSaveRecord_Click(sender As Object, e As EventArgs) Handles btnSaveRecord.Click
        If txtTotalCost.Text = "" Or txtStatus.Text = "" Then
            MsgBox("Some fields are empty D:
Try again.")
        ElseIf IsNumeric(txtCustomerID.Text) = False Or IsNumeric(txtOrderID.Text) = False Then
            MsgBox("Enter numeric values for ID pls")
        ElseIf Not IsDate(txtDateOfOrder.Text) Then
            MsgBox("Date must be in format DD/MM/YYYY")
        ElseIf txtDateOfOrder.Text > Today Then
            MsgBox("Invalid date: cannot be in the future")
        Else
            SaveRecord()
            DisplayDataInListBox()
        End If
    End Sub

    Private Sub btnAddNewRec_Click(sender As Object, e As EventArgs) Handles btnAddNewRec.Click
        lblRecordNumber.Text = lblNumberofRecords.Text + 1

        txtOrderID.Text = ""
        txtCustomerID.Text = ""
        txtDateOfOrder.Text = ""
        txtTotalCost.Text = ""
        txtStatus.Text = ""

        txtOrderID.Focus()
    End Sub

    Private Sub btnNextRec_Click(sender As Object, e As EventArgs) Handles btnNextRec.Click
        SaveRecord()
        lblRecordNumber.Text = lblRecordNumber.Text + 1
        If Val(lblRecordNumber.Text) > Val(lblNumberofRecords.Text) Then
            lblRecordNumber.Text = lblNumberofRecords.Text
        End If
        ReadRecord()
    End Sub
    Private Sub btnPreviousRec_Click(sender As Object, e As EventArgs) Handles btnPreviousRec.Click
        SaveRecord()
        lblRecordNumber.Text = lblRecordNumber.Text - 1
        If lblRecordNumber.Text < 1 Then
            lblRecordNumber.Text = 1
        End If
        ReadRecord()
    End Sub

    Private Sub btnEditRec_Click(sender As Object, e As EventArgs) Handles btnEditRecord.Click
        'is meant to be "btnEditRecord" not "btnDelRec"
        'allows user to select a saved record on lst rather than sifting through "next record" "previous record"

        If lstFoodOrders.SelectedItems.Count = 0 Then
            MsgBox("Select A Value Beforehand!")

        Else

            Dim NumberOfSelect As String

            Dim Splitter As String
            Dim x As String

            NumberOfSelect = lstFoodOrders.SelectedItem.ToString()
            Splitter = NumberOfSelect
            x = Mid(Splitter, 1, 2)

            DisplayDataInListBox()
            If IsNumeric(x) = True Then
                lblRecordNumber.Text = x
                ReadRecord()
            Else
                MsgBox("Error")

            End If

        End If
        DisplayDataInListBox()
    End Sub

    Private Sub cmbOrderID_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbOrderID.SelectedIndexChanged

        For i = 1 To LOF(4) / Len(OrderRecord)
            FileGet(4, OrderRecord, i)
            If OrderRecord.OrderID = Mid(cmbOrderID.Text, 1, 3) Then
                txtTotalCost.Text = OrderRecord.FinalCost
                'total = total + txttotalcost.text
                'OrderRecord.FinalCost = OrderRecord.FinalCost + txtTotalCost.Text


                'txtSellingPrice.Text = FoodMenuRecord.SellingPrice * Val(cmbQuantity.Text)
                'Format(OrderRecord.SellingPrice, "0.00")
            End If


        Next i
    End Sub
End Class