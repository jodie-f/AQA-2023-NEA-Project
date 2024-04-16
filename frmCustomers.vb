Public Class frmCustomers
    Private Sub frmCustomers_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        DisplayDataInListBox()
        lblNumberofRecords.Text = LOF(1) / Len(CustomerRecord)
        If lblNumberOfRecords.Text > 0 Then ReadRecord()
    End Sub

    Private Sub btnMenu_Click(sender As Object, e As EventArgs) Handles btnMenu.Click
        Me.Hide()
        frmMainMenu.Show()
    End Sub

    Private Sub SaveRecord()
        'A SUB PROGRAM FOR WHENEVER A BUTTON IS PRESSED - MAINLY SAVE RECORD
        CustomerRecord.CustomerID = txtCustomerID.Text
        CustomerRecord.CustomerName = txtName.Text
        CustomerRecord.CustomerAddress = txtAddress.Text
        CustomerRecord.CustomerPhone = txtPhone.Text
        CustomerRecord.CustomerEmail = txtEmail.Text

        FilePut(1, CustomerRecord, CInt(lblRecordNumber.Text))
        lblNumberofRecords.Text = LOF(1) / Len(CustomerRecord)
    End Sub

    Public Sub ReadRecord()
        FileGet(1, CustomerRecord, CInt(lblRecordNumber.Text))

        txtCustomerID.Text = CustomerRecord.CustomerID
        txtName.Text = CustomerRecord.CustomerName
        txtAddress.Text = CustomerRecord.CustomerAddress
        txtPhone.Text = CustomerRecord.CustomerPhone
        txtEmail.Text = CustomerRecord.CustomerEmail
    End Sub


    Public Sub DisplayDataInListBox()
        Dim i As Integer

        lstCustomers.Items.Clear()
        lstCustomers.Items.Add(" Cheerful Dragon :  Customers")
        lstCustomers.Items.Add("--------------------------------")
        lstCustomers.Items.Add("#  ID      Name             Address                 Phone            Email")
        lstCustomers.Items.Add("- ----    ------           ---------               --------         --------")


        For i = 1 To (LOF(1) / Len(CustomerRecord))
            lblPlaceValue.Text = i
            FileGet(1, CustomerRecord, i)
            lstCustomers.Items.Add(lblPlaceValue.Text & " " & CustomerRecord.CustomerID & "  " & CustomerRecord.CustomerName & "" & CustomerRecord.CustomerAddress & "   " & CustomerRecord.CustomerPhone & "     " & CustomerRecord.CustomerEmail)
        Next i


    End Sub
    'CODE FOR BUTTONS
    Private Sub btnSaveRecord_Click(sender As Object, e As EventArgs) Handles btnSaveRecord.Click
        If txtName.Text = "" Or txtAddress.Text = "" Or txtEmail.Text = "" Then
            MsgBox("Some fields are empty D:
Try again.")
        ElseIf IsNumeric(txtCustomerID.Text) = False Or IsNumeric(txtPhone.Text) = False Then
            MsgBox("Enter numeric values for ID/Phone pls")
        Else
            SaveRecord()
            DisplayDataInListBox()
        End If
    End Sub

    Private Sub btnAddNewRec_Click(sender As Object, e As EventArgs) Handles btnAddNewRec.Click
        lblRecordNumber.Text = lblNumberofRecords.Text + 1

        txtCustomerID.Text = ""
        txtName.Text = ""
        txtAddress.Text = ""
        txtPhone.Text = ""
        txtEmail.Text = ""

        txtCustomerID.Focus()
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

    Private Sub btnDelRec_Click(sender As Object, e As EventArgs) Handles btnEditRecord.Click
        'is meant to be "btnEditRecord" not "btnDelRec"
        'allows user to select a saved record on lst rather than sifting through "next record" "previous record"

        If lstCustomers.SelectedItems.Count = 0 Then
            MsgBox("Select A Value Beforehand!")

        Else

            Dim NumberOfSelect As String

            Dim Splitter As String
            Dim x As String

            NumberOfSelect = lstCustomers.SelectedItem.ToString()
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

    Private Sub lstCustomers_SelectedIndexChanged(sender As Object, e As EventArgs) Handles lstCustomers.SelectedIndexChanged

    End Sub

    Private Sub btnDeleteRecord_Click(sender As Object, e As EventArgs) Handles btnDeleteRecord.Click
        'PREFERABLY CODE TO WHEN SELECTED ON LIST BOX, DISPLAY ONTO THE TEXTBOXES AND DELETE FROM THERE
    End Sub

    Private Sub btnSortFile_Click(sender As Object, e As EventArgs) Handles btnSortFile.Click
        'if i add a function, make so can sort through customer names alphabetically - not affecting
        'client id, press again to go back to default order (client id)
    End Sub
End Class