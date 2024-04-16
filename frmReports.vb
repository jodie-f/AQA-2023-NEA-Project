Public Class frmReports
    Private Sub frmReports_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        cmbDateOfOrder.Items.Clear()
        For i = 1 To LOF(3) / Len(FoodOrderRecord2)
            FileGet(3, FoodOrderRecord2.DateOfOrder)
            cmbDateOfOrder.Items.Add(FoodOrderRecord2.OrderID)
        Next i

        cmbOrderID.Items.Clear()
        For i = 1 To LOF(3) / Len(FoodOrderRecord2)
            FileGet(3, FoodOrderRecord2.OrderID)
            cmbOrderID.Items.Add(FoodOrderRecord2.OrderID)
        Next
    End Sub
End Class