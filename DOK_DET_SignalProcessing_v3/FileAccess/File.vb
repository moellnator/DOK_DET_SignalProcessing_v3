Namespace FileAccess

    ''' <summary>
    ''' CLass implementing file IO extension methods
    ''' </summary>
    Public Class File

        ''' <summary>
        ''' Iterator funtion yielding all lines in a given file
        ''' </summary>
        ''' <param name="fileName">Path and file name to the file to read</param>
        ''' <param name="encoding">Text encoding to use for reading the file</param>
        ''' <returns>Yield each indiviual line in the given file consecutivly</returns>
        Public Shared Iterator Function LineWise(fileName As String, encoding As Text.Encoding) As IEnumerable(Of String)
            Using f As New IO.FileStream(fileName, IO.FileMode.Open, IO.FileAccess.Read, IO.FileShare.Read)
                Using r As New IO.StreamReader(f, encoding, False, 1024, True)
                    While Not r.EndOfStream
                        Yield r.ReadLine
                    End While
                End Using
            End Using
        End Function

        ''' <summary>
        ''' Iterator funtion yielding all lines in a given file (default encoding UTF-8)
        ''' </summary>
        ''' <param name="fileName">Path and file name to the file to read</param>
        ''' <returns>Yield each indiviual line in the given file consecutivly</returns>
        Public Shared Function LineWise(fileName As String) As IEnumerable(Of String)
            Return LineWise(fileName, Text.Encoding.UTF8)
        End Function

        ''' <summary>
        ''' Finds the first drive that matches the given drive name.
        ''' </summary>
        ''' <param name="driveName">Name (system volume lable) of the drive to find</param>
        ''' <returns>Returns a IO.DriveInfo structure corresponding to the matching drive</returns>
        Public Shared Function FindDriveByName(driveName As String) As IO.DriveInfo
            Dim retval As IO.DriveInfo = Nothing
            For Each d As IO.DriveInfo In IO.DriveInfo.GetDrives()
                Try
                    If d.VolumeLabel.Equals(driveName) Then
                        retval = d
                        Exit For
                    End If
                Catch ioex As IO.IOException
                End Try
            Next
            Return retval
        End Function

        Public Shared Function GetAllFiles(rootPath As String) As IEnumerable(Of IO.FileInfo)
            Return _get_all_files_iter(New IO.DirectoryInfo(rootPath))
        End Function

        Private Shared Iterator Function _get_all_files_iter(rootpath As IO.DirectoryInfo) As IEnumerable(Of IO.FileInfo)
            For Each d As IO.DirectoryInfo In rootpath.GetDirectories
                For Each f As IO.FileInfo In _get_all_files_iter(d)
                    Yield f
                Next
            Next
            For Each f As IO.FileInfo In rootpath.GetFiles
                Yield f
            Next
        End Function

    End Class

End Namespace
