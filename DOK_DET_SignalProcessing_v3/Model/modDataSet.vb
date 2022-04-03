Imports System.Runtime.CompilerServices
Imports DOK_DET_SignalProcessing_v3.Model

'LINQ extension to handle data set manipulation

Module modDataSet

    ''' <summary>
    ''' Convert an enumerable of x-y-data entries to a data set
    ''' </summary>
    ''' <param name="enumerable">Any enumerable of x-y-data entries to convert</param>
    ''' <returns>Returns a data set from the given list of x-y-data entries</returns>
    <Extension> Public Function AsDataSet(enumerable As IEnumerable(Of DataEntry)) As DataSet
        Return New DataSet(enumerable)
    End Function

    ''' <summary>
    ''' Creates an indexed data set from an enumerable of floating points
    ''' </summary>
    ''' <param name="enumerable">Any enumerable of floating points to create the data set from</param>
    ''' <returns>Returns an indexed data set containing the given floating point values</returns>
    <Extension> Public Function AsDataSet(enumerable As IEnumerable(Of Double)) As DataSet
        Return enumerable.Select(Function(d, i) New DataEntry(i, d)).AsDataSet
    End Function

    ''' <summary>
    ''' Prepend the given enerumeration by a value
    ''' </summary>
    ''' <param name="enumerable">The enerumerable to prepend</param>
    ''' <param name="value">The value to prepend the enumeration with</param>
    ''' <returns>Returns a new enerumeration with the given value prepended</returns>
    <Extension> Public Function Prepend(Of T)(enumerable As IEnumerable(Of T), value As T) As IEnumerable(Of T)
        Return {value}.Concat(enumerable)
    End Function

End Module
