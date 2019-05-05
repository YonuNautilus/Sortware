Public Class SortSettings
    Protected _filePath As String
    Protected _fileStream As IO.FileStream

    Public Enum dirType
        MAINDIR
        PRESORTDIR
        BLOCKEDDIR
    End Enum

    Private mainDirs As List(Of String)
    Private preSortDirs As List(Of String)
    Private blockedDirs As List(Of String)

    Public Sub New()

    End Sub
    Public Sub New(ByVal filePath As String)
        If System.IO.File.Exists(filePath & "\.sortSettings") Then
            _fileStream = IO.File.Open(filePath & "\.sortSettings", System.IO.FileMode.Open)
        End If
    End Sub

    Public Property rootDir As String

    Public Sub addToDirList(ByVal _dir As String, ByVal _type As dirType)
        Select Case (_type)
            Case dirType.MAINDIR
                addToDirList(_dir, mainDirs)
            Case dirType.PRESORTDIR
                addToDirList(_dir, preSortDirs)
        End Select
    End Sub

    Private Sub addToDirList(ByVal _dir As String, ByRef _list As List(Of String))
        If Not _list.Contains(_dir) Then
            _list.Add(_dir)
        End If
    End Sub

    Public Function getDir(ByVal _type As dirType) As List(Of String)
        Select Case (_type)
            Case dirType.MAINDIR
                Return mainDirs
            Case dirType.PRESORTDIR
                Return preSortDirs
        End Select
    End Function

    Public Function ParseSettings() As Boolean

    End Function
End Class