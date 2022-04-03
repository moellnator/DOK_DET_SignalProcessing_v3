Imports System.Runtime.CompilerServices
Imports DOK_DET_SignalProcessing_v3.Model

Module modRange

    ''' <summary>
    ''' Creates a range centered around the value plus minus the deviation
    ''' </summary>
    ''' <param name="value">The center of the range</param>
    ''' <param name="deviation">The deviation around the center value</param>
    ''' <returns>Return a new range around the given values</returns>
    <Extension> Public Function PlusMinus(value As Double, deviation As Double) As Range
        Return New Range(value - deviation, value + deviation)
    End Function

    ''' <summary>
    ''' Test whether or not a given value lies withing a range
    ''' </summary>
    ''' <param name="value">The value to test</param>
    ''' <param name="range">A range representing the upper and lower limits of the test</param>
    ''' <returns>Returns true if the value is within the given limits, false otherwise</returns>
    <Extension> Public Function IsWithin(Of T As IComparable(Of T))(value As T, range As Range(Of T)) As Boolean
        Return value.CompareTo(range.Min) >= 0 And value.CompareTo(range.Max) <= 0
    End Function

    <Extension> Public Function IsWithin(value As Double, range As Range) As Boolean
        Return value >= range.Min And value <= range.Max
    End Function


End Module
