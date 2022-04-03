Namespace Model
    Public Class DataSet : Inherits List(Of DataEntry) : Implements IDisposable

        Private _is_disposed As Boolean = False

        Public Sub New(data As IEnumerable(Of DataEntry))
            MyBase.New(data)
        End Sub

        Public Sub New()
            MyBase.New()
        End Sub

        Public Overloads Sub Add(x As Double, y As Double)
            Me.Add(New DataEntry(x, y))
        End Sub

        Protected Overridable Sub Dispose(disposing As Boolean)
            If Not Me._is_disposed Then
                If disposing Then
                    Me.Clear()
                End If
            End If
            Me._is_disposed = True
        End Sub

        Public Sub Dispose() Implements IDisposable.Dispose
            Dispose(True)
        End Sub

    End Class

End Namespace
