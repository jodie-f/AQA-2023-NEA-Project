Public Class frmOrders
    Private Sub frmOrders_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        DisplayDataInListBox()
        lblNumberofRecords.Text = LOF(4) / Len(OrderRecord)
        If lblNumberofRecords.Text > 0 Then ReadRecord()

        '----------------------------------------------------------------------------
        'taking data from food menu form
        cmbDishID.Items.Clear()

        For i = 1 To LOF(2) / Len(FoodMenuRecord)
            FileGet(2, FoodMenuRecord, i)
            cmbDishID.Items.Add(FoodMenuRecord.DishID & "   " & FoodMenuRecord.DishName)
        Next i
    End Sub

    Private Sub CalculatingTotal()
        Dim Total As Single = 0

        If txtOrderID.Text Then

        End If

        For i = 1 To LOF(4) / Len(OrderRecord)
            Total = Total + txtSellingPrice.Text
        Next i

        Total = OrderRecord.FinalCost
    End Sub

    Private Sub SaveRecord()
        'A SUB PROGRAM FOR WHENEVER A BUTTON IS PRESSED - MAINLY SAVE RECORD
        OrderRecord.OrderID = txtOrderID.Text
        OrderRecord.DishID = cmbDishID.Text
        OrderRecord.Quantity = txtQuantity.Text
        OrderRecord.SellingPrice = txtSellingPrice.Text

        'OrderRecord.SellingPrice = FoodMenuRecord.SellingPrice * OrderRecord.Quantity


        FilePut(4, OrderRecord, CInt(lblRecordNumber.Text))
        lblNumberofRecords.Text = LOF(4) / Len(OrderRecord)
    End Sub

    Public Sub ReadRecord()
        FileGet(4, OrderRecord, CInt(lblRecordNumber.Text))

        txtOrderID.Text = OrderRecord.OrderID
        cmbDishID.Text = OrderRecord.DishID
        txtQuantity.Text = OrderRecord.Quantity
        txtSellingPrice.Text = OrderRecord.SellingPrice
    End Sub


    Public Sub DisplayDataInListBox()
        Dim i As Integer

        lstOrderDetails.Items.Clear()
        lstOrderDetails.Items.Add(" Cheerful Dragon :  Order Details")
        lstOrderDetails.Items.Add("--------------------------------")
        lstOrderDetails.Items.Add("#  Order ID   Dish ID    Quantity    Selling Price")
        lstOrderDetails.Items.Add("- ---------- ---------  ----------  ---------------")

        'when next order is pressed, lst box changes to that order's details
        For i = 1 To (LOF(4) / Len(OrderRecord))
            lblPlaceValue.Text = i
            FileGet(4, OrderRecord, i)
            lstOrderDetails.Items.Add(lblPlaceValue.Text & "     " & OrderRecord.OrderID & "      " & OrderRecord.DishID & "         " & OrderRecord.Quantity & "            " & OrderRecord.SellingPrice)
            'selling price is not using the value from the txtSellingPrice
        Next i


    End Sub
    'CODE FOR BUTTONS

    Private Sub btnSaveOrder_Click(sender As Object, e As EventArgs) Handles btnSaveOrder.Click
        If cmbDishID.Text = "" Then
            MsgBox("Please select a dish")
        ElseIf IsNumeric(txtOrderID.Text) = False Or IsNumeric(txtQuantity.Text) = False Then
            MsgBox("Please enter numeric values for the ID or Quantity")
        Else
            SaveRecord()
            DisplayDataInListBox()
        End If

        'For i = 1 To (LOF(4) / Len(OrderRecord))
        'OrderRecord.FinalCost = (Val(txtQuantity.Text) * Val(txtSellingPrice.Text)) + OrderRecord.FinalCost
        'Next i

        'OrderRecord.FinalCost = (Val(txtQuantity.Text) * Val(txtSellingPrice.Text)) + OrderRecord.FinalCost

    End Sub

    Private Sub btnNextOrder_Click(sender As Object, e As EventArgs) Handles btnNextOrder.Click
        SaveRecord()
        lblRecordNumber.Text = lblRecordNumber.Text + 1
        If Val(lblRecordNumber.Text) > Val(lblNumberofRecords.Text) Then
            lblRecordNumber.Text = lblNumberofRecords.Text
        End If
        ReadRecord()
    End Sub

    Private Sub btnPreviousOrder_Click(sender As Object, e As EventArgs) Handles btnPreviousOrder.Click
        SaveRecord()
        lblRecordNumber.Text = lblRecordNumber.Text - 1
        If lblRecordNumber.Text < 1 Then
            lblRecordNumber.Text = 1
        End If
        ReadRecord()
    End Sub

    Private Sub btnAddToOrder_Click(sender As Object, e As EventArgs) Handles btnAddToOrder.Click
        'cmbDishID.Text = ""
        'txtQuantity.Text = ""
        'txtSellingPrice.Text = ""
        'DisplayDataInListBox()
    End Sub

    Private Sub btnNewOrder_Click(sender As Object, e As EventArgs) Handles btnNewOrder.Click
        lblRecordNumber.Text = lblNumberofRecords.Text + 1


        txtOrderID.Text = ""
        cmbDishID.Text = ""
        txtQuantity.Text = ""

        txtOrderID.Focus()


    End Sub

    Private Sub cmbDishID_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbDishID.SelectedIndexChanged

        For i = 1 To LOF(2) / Len(FoodMenuRecord)
            FileGet(2, FoodMenuRecord, i)
            If FoodMenuRecord.DishID = Mid(cmbDishID.Text, 1, 4) Then
                txtSellingPrice.Text = FoodMenuRecord.SellingPrice
                'txtSellingPrice.Text = FoodMenuRecord.SellingPrice * Val(cmbQuantity.Text)
                'Format(OrderRecord.SellingPrice, "0.00")
            End If


        Next i

    End Sub

    Private Sub btnMenu_Click(sender As Object, e As EventArgs) Handles btnMenu.Click
        Me.Hide()
        frmMainMenu.Show()
    End Sub
End Class