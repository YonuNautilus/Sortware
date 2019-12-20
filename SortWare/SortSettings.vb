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
        ROOTDIR
        MAINDIR
        PRESORTDIR
        BLOCKEDDIR
        ERRORDIR
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

    Public Sub New(ByVal root As SortDirectory, ByVal _mains As List(Of SortDirectory), ByVal _presorts As List(Of SortDirectory), ByVal _blocks As List(Of SortDirectory))
        rootDir = root.fullName
        For Each d In _mains
            mainDirs.Add(d.fullName)
        Next
        For Each d In _presorts
            preSortDirs.Add(d.fullName)
        Next
        For Each d In _blocks
            blockedDirs.Add(d.fullName)
        Next
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

    Public Function removeFromDirList(ByVal _dir As String, ByVal _type As dirType) As Boolean
        Select Case (_type)
            Case dirType.MAINDIR
                Return removeFromDirList(_dir, mainDirs)
            Case dirType.PRESORTDIR
                Return removeFromDirList(_dir, preSortDirs)
            Case dirType.ROOTDIR
                Return False
            Case dirType.ERRORDIR
                Return False
            Case dirType.BLOCKEDDIR
                Return removeFromDirList(_dir, blockedDirs)
        End Select
    End Function

    Function removeFromDirList(ByVal _dir As String, ByRef _list As List(Of String)) As Boolean
        If Not _list.Contains(_dir) Then
            _list.Remove(_dir)
        End If
    End Function


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

            temp = Regex.Match(fullString, mainsRegex)
            Dim mainsFull = temp.ToString.Remove(0, mainsHeader.Length)
            Dim mains = Split(mainsFull.Trim, vbNewLine)
            For Each line As String In mains
                If Not line.Equals("") Then
                    mainDirs.Add(line.Trim)
                End If
            Next

            temp = Regex.Match(fullString, presortRegex)
            Dim presortFull = temp.ToString.Remove(0, presortHeader.Length)
            Dim presorts = Split(presortFull.Trim, vbNewLine)
            For Each line As String In presorts
                If Not line.Equals("") Then
                    preSortDirs.Add(line.Trim)
                End If
            Next

            temp = Regex.Match(fullString, blockRegex)
            Dim blockFull = temp.ToString.Remove(0, blockHeader.Length)
            Dim blocks = Split(blockFull.Trim, vbNewLine)
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

            temp = Regex.Match(_in, mainsRegex)
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


            temp = Regex.Match(_in, presortRegex)
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

            temp = Regex.Match(_in, blockRegex)
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

    Public Function IsValidSettings() As Boolean
        Dim ret As Boolean = True
        If Not IO.Directory.Exists(rootDir) Then
            ret = False
        End If

        For Each main In mainDirs
            If Not IO.Directory.Exists(main) Then
                ret = False
            End If
        Next

        For Each presort In preSortDirs
            If Not IO.Directory.Exists(presort) Then
                ret = False
            End If
        Next

        For Each block In blockedDirs
            If Not IO.Directory.Exists(block) Then
                ret = False
            End If
        Next
        Return ret
    End Function

    Public Function getList(ByVal which As dirType) As List(Of SortDirectory)
        Dim ret As New List(Of SortDirectory)
        Select Case which
            Case dirType.ROOTDIR
                ret.Add(New SortDirectory(rootDir, 3, dirType.ROOTDIR))
            Case dirType.MAINDIR
                For Each s In mainDirs
                    Dim tempSD = New SortDirectory(s, 3, dirType.MAINDIR)
                    tempSD.hasSubs()
                    ret.Add(tempSD)
                Next
            Case dirType.PRESORTDIR
                For Each s In preSortDirs
                    ret.Add(New SortDirectory(s, 3, dirType.PRESORTDIR))
                Next
            Case dirType.BLOCKEDDIR
                For Each s In blockedDirs
                    ret.Add(New SortDirectory(s, 3, dirType.BLOCKEDDIR))
                Next
        End Select
        Return ret
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