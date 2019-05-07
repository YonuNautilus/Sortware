Imports System.Text.RegularExpressions
Public Class SortSettings
    'Protected _filePath As String
    Protected _fileStream As IO.FileStream

    Public Const rootHeader As String = "Root: "
    Public Const mainsHeader As String = "Mains:"
    Public Const presortHeader As String = "Presorts:"
    Public Const blockHeader As String = "Blocked:"

    Private Const rootRegex As String = rootHeader + "([A-z\:0-9]*)[^\#]+"
    Private Const mainsRegex As String = mainsHeader + "([A-z\:0-9]*)[^\#]+"
    Private Const presortRegex As String = presortHeader + "([A-z\:0-9]*)[^\#]+"
    Private Const blockRegex As String = blockHeader + "([A-z\:0-9]*)[^\#]+"

    Public Enum dirType
        MAINDIR
        PRESORTDIR
        BLOCKEDDIR
    End Enum

    Private mainDirs As List(Of String) = New List(Of String)
    Private preSortDirs As List(Of String) = New List(Of String)
    Private blockedDirs As List(Of String) = New List(Of String)
    Public Property rootDir As String

    Public Sub New()

    End Sub
    Public Sub New(ByVal filePath As String)
        If System.IO.File.Exists(filePath & "\.sortSettings.txt") Then
            '_fileStream = IO.File.Open(filePath & "\.sortSettings.txt", System.IO.FileMode.Open)
            rootDir = filePath.Trim
        End If
        ParseSettings()
    End Sub

    Public Sub setDir(ByVal filePath As String)
        If System.IO.File.Exists(filePath & "\.sortSettings.txt") Then
            '_fileStream = IO.File.Open(filePath & "\.sortSettings.txt", System.IO.FileMode.Open)
            rootDir = filePath.Trim
        End If
        ParseSettings()
    End Sub

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
        Dim fullString As String = ""
        If System.IO.File.Exists(rootDir & "\.sortSettings.txt") Then
            Dim reader As IO.TextReader = New IO.StreamReader(rootDir & "\.sortSettings.txt")
            fullString = reader.ReadToEnd
            reader.Dispose()
        End If

        If Not fullString = "" Then
            Dim temp As Match = Regex.Match(fullString, rootRegex)
            rootDir = temp.ToString.Remove(0, rootHeader.Length)

            temp = Regex.Match(fullString, mainsHeader)
            Dim mainsFull = temp.ToString.Remove(0, mainsHeader.Length)
            Dim mains = Split(mainsFull.Trim, vbNewLine)
            For Each line As String In mains
                If Not line.Equals("") Then
                    mainDirs.Add(line.Trim)
                End If
            Next

            temp = Regex.Match(fullString, presortHeader)
            Dim presortFull = temp.ToString.Remove(0, presortHeader.Length)
            Dim presorts = Split(presortFull.Trim, vbNewLine)
            For Each line As String In presorts
                If Not line.Equals("") Then
                    preSortDirs.Add(line.Trim)
                End If
            Next

            temp = Regex.Match(fullString, blockHeader)
            Dim blockFull = temp.ToString.Remove(0, blockHeader.Length)
            Dim blocks = Split(presortFull.Trim, vbNewLine)
            For Each line As String In blocks
                If Not line.Equals("") Then
                    blockedDirs.Add(line.Trim)
                End If
            Next

        End If
    End Function

    Public Function IsValidSettings(ByVal _in As String) As Boolean
        Dim tempRoot As String
        Dim tempMains As List(Of String) = New List(Of String)
        Dim tempPresort As List(Of String) = New List(Of String)
        Dim tempBlock As List(Of String) = New List(Of String)

        If Not _in = "" Then
            Dim temp As Match = Regex.Match(_in, rootRegex)
            tempRoot = temp.ToString.Remove(0, rootHeader.Length)

            If Not IO.Directory.Exists(rootDir) Then
                Return False
            End If

            temp = Regex.Match(_in, mainsHeader)
            Dim mainsFull = temp.ToString.Remove(0, mainsHeader.Length)
            Dim mains = Split(mainsFull, vbNewLine)
            For Each line As String In mains
                tempMains.Add(line)
            Next

            For Each main In tempMains
                If Not IO.Directory.Exists(main) Then
                    Return False
                End If
            Next


            temp = Regex.Match(_in, presortHeader)
            Dim presortFull = temp.ToString.Remove(0, presortHeader.Length)
            Dim presorts = Split(presortFull, vbNewLine)
            For Each line As String In presorts
                tempPresort.Add(line)
            Next

            For Each presort In tempPresort
                If Not IO.Directory.Exists(presort) Then
                    Return False
                End If
            Next

            temp = Regex.Match(_in, blockHeader)
            Dim blockFull = temp.ToString.Remove(0, blockHeader.Length)
            Dim blocks = Split(presortFull, vbNewLine)
            For Each line As String In blocks
                tempBlock.Add(line)
            Next

            For Each block In tempBlock
                If Not IO.Directory.Exists(block) Then
                    Return False
                End If
            Next

        End If
    End Function

    Public Overrides Function toString() As String
        Dim tempMain As String = mainsHeader + vbNewLine
        Dim tempPres As String = presortHeader + vbNewLine
        Dim tempBlock As String = blockHeader + vbNewLine
        For Each l In mainDirs
            tempMain += l + vbNewLine
        Next
        tempMain += "#" + vbNewLine

        For Each l In preSortDirs
            tempPres += l + vbNewLine
        Next
        tempPres += "#" + vbNewLine

        For Each l In blockedDirs
            tempBlock += l + vbNewLine
        Next
        tempBlock += "#" + vbNewLine

        Return rootHeader + vbNewLine + rootDir.Trim + vbNewLine + "#" + vbNewLine + tempMain + tempPres + tempBlock

    End Function

    Public Sub Close()
        Try
            _fileStream.Close()
        Catch ex As Exception
            Debug.WriteLine(ex.Message)
        End Try
    End Sub

End Class