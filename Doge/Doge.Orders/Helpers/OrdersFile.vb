Imports Newtonsoft.Json
Public Class OrdersFile
    Public Shared Sub WriteToFile(orders As List(Of Order))
        Dim stream As IO.StreamWriter = Nothing
        Dim strSerializedOrders As String = String.Empty

        Try

            stream = New IO.StreamWriter("C:\Orders.json", False)
            strSerializedOrders = JsonConvert.SerializeObject(orders)
            stream.Write(strSerializedOrders)

        Catch ex As Exception
            'TODO: Manage Log Exception 
        Finally
            stream.Flush()
            stream.Close()
        End Try

    End Sub
End Class
