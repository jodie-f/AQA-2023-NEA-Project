Public Class frmFoodMenu
    'DISPLAYS THE FOOD AVAILABLE IN THE MENU TO BE USED IN A DROPDOWN MENU
    'FOR THE FOOD ORDERS FORM - MUST BE ADDED MANUALLY BY CLIENT

    'could add a sort button to sort through dish name, press again to get back to dish id order maybe
    Private Sub frmFoodMenu_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        DisplayDataInListBox()
        lblNumberofRecords.Text = LOF(2) / Len(FoodMenuRecord)
        If lblNumberofRecords.Text > 0 Then ReadRecord()
    End Sub
    Private Sub btnMenu_Click(sender As Object, e As EventArgs)
        Me.Hide()
        frmMainMenu.Show()
    End Sub

    Private Sub SaveRecord()
        'A SUB PROGRAM FOR WHENEVER A BUTTON IS PRESSED - MAINLY SAVE RECORD

        FoodMenuRecord.DishID = txtDishID.Text
        FoodMenuRecord.DishName = txtName.Text
        FoodMenuRecord.SellingPrice = txtSellingPrice.Text

        FilePut(2, FoodMenuRecord, CInt(lblRecordNumber.Text))
        lblNumberofRecords.Text = LOF(2) / Len(FoodMenuRecord)
    End Sub

    Public Sub ReadRecord()
        FileGet(2, FoodMenuRecord, CInt(lblRecordNumber.Text))

        txtDishID.Text = FoodMenuRecord.DishID
        txtName.Text = FoodMenuRecord.DishName
        txtSellingPrice.Text = FoodMenuRecord.SellingPrice
    End Sub

    Public Sub DisplayDataInListBox()
        Dim i As Integer

        lstFoodMenu.Items.Clear()
        lstFoodMenu.Items.Add(" Cheerful Dragon :  Food Menu")
        lstFoodMenu.Items.Add("--------------------------------")
        lstFoodMenu.Items.Add("#  ID      Name                 Selling Price")
        lstFoodMenu.Items.Add("- ----    ------               ---------------")

        For i = 1 To (LOF(2) / Len(FoodMenuRecord))
            lblPlaceValue.Text = i
            FileGet(2, FoodMenuRecord, i)
            lstFoodMenu.Items.Add(lblPlaceValue.Text & " " & FoodMenuRecord.DishID & "  " & FoodMenuRecord.DishName & "£" & FoodMenuRecord.SellingPrice)
        Next i
    End Sub

    'CODE FOR BUTTONS
    Private Sub btnSaveRecord_Click(sender As Object, e As EventArgs) Handles btnSaveRecord.Click
        If txtDishID.Text = "" Or txtName.Text = "" Or txtSellingPrice.Text = "" Then
            MsgBox("Some fields are empty D:
Try again.")
        Else
            SaveRecord()
            DisplayDataInListBox()
        End If
    End Sub

    Private Sub btnAddNewRec_Click(sender As Object, e As EventArgs) Handles btnAddNewRec.Click
        lblRecordNumber.Text = lblNumberofRecords.Text + 1

        txtDishID.Text = ""
        txtName.Text = ""
        txtSellingPrice.Text = ""

        txtDishID.Focus()
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

    Private Sub btnMenu_Click_1(sender As Object, e As EventArgs) Handles btnMenu.Click
        Me.Hide()
        frmMainMenu.Show()
    End Sub

    Private Sub btnDelRec_Click(sender As Object, e As EventArgs) Handles btnDelRec.Click
        'PREFERABLY CODE TO WHEN SELECTED ON LIST BOX, DISPLAY ONTO THE TEXTBOXES AND DELETE FROM THERE
    End Sub

    Private Sub btnEditRecord_Click(sender As Object, e As EventArgs) Handles btnEditRecord.Click
        'allows user to select a saved record on lst rather than sifting through "next record" "previous record"

        If lstFoodMenu.SelectedItems.Count = 0 Then
            MsgBox("Select A Value Beforehand!")

        Else

            Dim NumberOfSelect As String

            Dim Splitter As String
            Dim x As String

            NumberOfSelect = lstFoodMenu.SelectedItem.ToString()
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
End Class