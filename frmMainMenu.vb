Public Class frmMainMenu
    Private Sub frmMenu_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        CustomerFilePath = CurDir() & "\CustomerFile.dat"
        FileOpen(1, CustomerFilePath, OpenMode.Random, , , Len(CustomerRecord))

        FoodMenuFilePath = CurDir() & "\FoodMenuFile.dat"
        FileOpen(2, FoodMenuFilePath, OpenMode.Random, , , Len(FoodMenuRecord))

        FoodOrderFilePath = CurDir() & "\FoodOrderFile.dat"
        FileOpen(3, FoodOrderFilePath, OpenMode.Random, , , Len(FoodOrderRecord))

        OrderFilePath = CurDir() & "\OrderFile.dat"
        FileOpen(4, OrderFilePath, OpenMode.Random, , , Len(OrderRecord))


    End Sub
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles btnCustomers.Click
        Me.Hide()
        frmCustomers.Show()
    End Sub

    Private Sub btnOrders_Click(sender As Object, e As EventArgs) Handles btnOrders.Click
        Me.Hide()
        frmFoodOrders.Show()
    End Sub

    Private Sub btnFood_Click(sender As Object, e As EventArgs) Handles btnFood.Click
        Me.Hide()
        frmFoodMenu.Show()
    End Sub

    Private Sub btnNewOrders_Click(sender As Object, e As EventArgs) Handles btnNewOrders.Click
        Me.Hide()
        frmOrders.Show()
    End Sub
End Class