Imports System
Imports System.ComponentModel.DataAnnotations.Schema
Imports System.Data.Entity
Imports System.Linq

Partial Public Class OrdersModel
    Inherits DbContext

    Public Sub New()
        MyBase.New("name=OrdersModel")
    End Sub

    Public Overridable Property Orders As DbSet(Of Order)

    Protected Overrides Sub OnModelCreating(ByVal modelBuilder As DbModelBuilder)
        modelBuilder.Entity(Of Order)() _
            .Property(Function(e) e.orderId) _
            .IsUnicode(False)

        modelBuilder.Entity(Of Order)() _
            .Property(Function(e) e.shipTo) _
            .IsUnicode(False)
    End Sub
End Class
