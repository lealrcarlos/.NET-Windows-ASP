Public Class Service1

    Dim timer As Timers.Timer
    Private db As New OrdersModel()

    Protected Overrides Sub OnStart(ByVal args() As String)
        timer = New Timers.Timer
        timer.Interval = 30000
        AddHandler timer.Elapsed, AddressOf GetOrdersHandler
        timer.Enabled = True
    End Sub

    Protected Overrides Sub OnStop()
        timer.Enabled = False
    End Sub

    Private Sub GetOrdersHandler(obj As Object, e As EventArgs)

        Dim ordersList = db.Orders.ToList()
        If ordersList.Count() > 0 Then
            OrdersFile.WriteToFile(ordersList)
        End If

    End Sub

End Class
