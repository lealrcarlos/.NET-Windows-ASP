Imports System.ComponentModel.DataAnnotations
Partial Public Class Order
    <StringLength(100)>
    Public Property orderId As String

    Public Property requiredShippedTime As Date

    <Required>
    <StringLength(250)>
    Public Property shipTo As String
End Class
