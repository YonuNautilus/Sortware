Imports System.Text.RegularExpressions
Public Class SubSortSettings
    Public Const rootHeader As String = "Root: "
    Private Const rootRegex As String = rootHeader + "([A-z\:0-9]*)[^\#]+"

    Private Const subHeader As String = "Subdirectories: "
    Private Const subRegex As String = subHeader + "([A-z\:0-9]*)[^\#]+"

    Private subDirs As List(Of String) = New List(Of String)

    Protected _fileStream As IO.FileStream

    Public Property rootDir As String

    Public Sub New(ByVal filePath As String)
        If System.IO.File.Exists(filePath & "\.subSortSettings.txt") Then
            '_fileStream = IO.File.Open(filePath & "\.sortSettings.txt", System.IO.FileMode.Open)
            rootDir = filePath.Trim
        End If
        ParseSettings()
    End Sub

    Public Sub New(ByVal root As SortDirectory, ByVal _subs As List(Of SortDirectory))
        rootDir = root.fullName
        If _subs IsNot Nothing Then
            For Each d In _subs
                subDirs.Add(d.fullName)
            Next
        End If
    End Sub

    Public Sub setDir(ByVal filePath As String)
        If System.IO.File.Exists(filePath & "\.subSortSettings.txt") Then
            '_fileStream = IO.File.Open(filePath & "\.sortSettings.txt", System.IO.FileMode.Open)
            rootDir = filePath.Trim
        End If
        ParseSettings()
    End Sub

    Public Sub addToDirList(ByVal _dir As String, ByVal _type As SortSettings.dirType)
        If _type = SortSettings.dirType.MAINDIR Then
            addToDirList(_dir, subDirs)
        End If
    End Sub

    Private Sub addToDirList(ByVal _dir As String, ByRef _list As List(Of String))
        If Not _list.Contains(_dir) Then
            _list.Add(_dir)
        End If
    End Sub

    Public Function ParseSettings() As Boolean
        Dim fullString As String = ""
        If System.IO.File.Exists(rootDir & "\.subSortSettings.txt") Then
            Dim reader As IO.TextReader = New IO.StreamReader(rootDir & "\.subSortSettings.txt")
            fullString = reader.ReadToEnd
            reader.Dispose()
        End If

        If Not fullString = "" Then
            Dim temp As Match = Regex.Match(fullString, rootRegex)
            rootDir = temp.ToString.Remove(0, rootHeader.Length)

            temp = Regex.Match(fullString, subRegex)
            Dim mainsFull = temp.ToString.Remove(0, subHeader.Length)
            Dim mains = Split(mainsFull.Trim, vbNewLine)
            For Each line As String In mains
                If Not line.Equals("") Then
                    subDirs.Add(line.Trim)
                End If
            Next
        End If
    End Function

    Public Function IsValidSettings() As Boolean
        Dim ret As Boolean = True
        If Not IO.Directory.Exists(rootDir) Then
            ret = False
        End If

        For Each s In subDirs
            If Not IO.Directory.Exists(s) Then
                ret = False
            End If
        Next
        Return ret
    End Function

    Public Function getList(ByVal which As SortSettings.dirType) As List(Of String)
        Return subDirs
    End Function

    Public Sub Close()
        Try
            _fileStream.Close()
        Catch ex As Exception
            Debug.WriteLine(ex.Message)
        End Try
    End Sub

    Public Overrides Function toString() As String
        Dim tempSub As String = subHeader + vbNewLine
        For Each s In subDirs
            tempSub += s + vbNewLine
        Next
        tempSub += "#" + vbNewLine

        Return rootHeader + vbNewLine + rootDir.Trim + vbNewLine + "#" + vbNewLine + tempSub

    End Function
End Class
