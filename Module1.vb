Module Module1

    'FILE(1)
    Public Structure Customer
        <VBFixedString(4)> Dim CustomerID As String
        <VBFixedString(20)> Dim CustomerName As String
        <VBFixedString(20)> Dim CustomerAddress As String
        <VBFixedString(11)> Dim CustomerPhone As String
        <VBFixedString(40)> Dim CustomerEmail As String
    End Structure

    Public CustomerRecord As Customer
    Public CustomerFilePath As String

    Public CustomerRecord2 As Customer

    'FILE(2)
    Public Structure FoodMenu
        <VBFixedString(4)> Dim DishID As String
        <VBFixedString(25)> Dim DishName As String
        <VBFixedString(5)> Dim SellingPrice As String 'NOT SURE HOW TO DIM IT AS CURRENCY
        '<VBFixedString(11)> Dim Availability As String || UNSURE IF IT SHOULD BE ADDED, WOULD BE A BOOLEAN
    End Structure

    Public FoodMenuRecord As FoodMenu
    Public FoodMenuFilePath As String

    Public FoodRecord2 As FoodMenu

    'FILE(3)
    Public Structure FoodOrders
        'LIST OF MULTIPLE FOOD ORDERS
        <VBFixedString(3)> Dim OrderID As String
        <VBFixedString(4)> Dim CustomerID As String
        <VBFixedString(20)> Dim DateOfOrder As Date
        <VBFixedString(5)> Dim TotalCost As String
        <VBFixedString(10)> Dim Status As String
    End Structure

    Public FoodOrderRecord As FoodOrders
    Public FoodOrderFilePath As String

    Public FoodOrderRecord2 As FoodOrders

    'FILE(4)
    Public Structure Orders
        'THE INDIVIDUAL ORDERS - QUANTITY
        <VBFixedString(3)> Dim OrderID As String
        <VBFixedString(4)> Dim DishID As String
        <VBFixedString(2)> Dim Quantity As String
        <VBFixedString(5)> Dim SellingPrice As String
        <VBFixedString(4)> Dim FinalCost As Single

    End Structure

    Public OrderRecord As Orders
    Public OrderFilePath As String

    Public OrderRecord2 As Orders

    'Public Edit As String

End Module
