Imports System.Runtime.CompilerServices

Module modFormat

    <Extension> Public Function ToIString(v As Double) As String
        Return v.ToString(Globalization.CultureInfo.InvariantCulture)
    End Function

End Module
