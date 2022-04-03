
Namespace Model
    Public Class Range(Of T As IComparable(Of T))

        Public ReadOnly Property Min As T
        Public ReadOnly Property Max As T

        Public Sub New(min As T, max As T)
            Me.Min = If(min.CompareTo(max) < 0, min, max)
            Me.Max = If(min.CompareTo(max) < 0, max, min)
        End Sub

    End Class

    Public Class Range : Inherits Range(Of Double)

        Public Sub New(min As Double, max As Double)
            MyBase.New(min, max)
        End Sub

        Public ReadOnly Property Width As Double
            Get
                Return Me.Max - Me.Min
            End Get
        End Property

        Public ReadOnly Property Center As Double
            Get
                Return (Me.Max + Me.Min) / 2
            End Get
        End Property

        Public ReadOnly Property Deviation As Double
            Get
                Return (Me.Max - Me.Min) / 2
            End Get
        End Property

    End Class

End Namespace
