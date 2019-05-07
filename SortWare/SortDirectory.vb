Public Class SortDirectory
    Private dir As IO.DirectoryInfo
    Private dirString As String = ""
    Private indent As Integer
    Public Sub New(ByVal _dir As String, ByVal _in As Integer)
        dirString = _dir
        dir = New IO.DirectoryInfo(_dir)
        indent = _in
    End Sub

    Public Function exists() As Boolean
        Return dir.Exists And IO.Directory.Exists(dir.FullName)
    End Function

    Public Function fullName() As String
        Return dir.FullName
    End Function

    Public Overrides Function ToString() As String
        Return dir.Name.PadLeft((indent * 3) + dir.Name.Length, Convert.ToChar(" "))
    End Function
End Class
