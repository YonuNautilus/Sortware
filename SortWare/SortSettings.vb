Imports System.Text.RegularExpressions
Imports System.Xml
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

    Public Const XMLNODEMAIN As String = "mains"
    Public Const XMLNODEPRESORTS As String = "presorts"
    Public Const XMLNODEBLOCKED As String = "blocked"
    Public Const XMLNODECONVERT As String = "convert"
    Public Const XMLNODEFINISHED As String = "finished"
    Public Const XMLNODESUBS As String = "subs"

    Public Enum dirType
        ROOTDIR
        MAINDIR
        PRESORTDIR
        BLOCKEDDIR
        CONVERTDIR
        FINISHEDDIR
        ERRORDIR
    End Enum

    'Private mainDirs As List(Of String) = New List(Of String)
    'Private preSortDirs As List(Of String) = New List(Of String)
    'Private blockedDirs As List(Of String) = New List(Of String)
    'Private ConvertDirs As List(Of Tuple(Of String, String, String)) = New List(Of Tuple(Of String, String, String))
    'Private FinishedDir As String
    Private mainDirs As List(Of SortDirectory) = New List(Of SortDirectory)
    Private presortDirs As List(Of SortDirectory) = New List(Of SortDirectory)
    Private blockedDirs As List(Of SortDirectory) = New List(Of SortDirectory)
    Private convertDirs As List(Of SortDirectory) = New List(Of SortDirectory)
    Private FinishedDir As SortDirectory
    Public Property rootDir As SortDirectory

    Public Sub New()

    End Sub
    Public Sub New(ByVal filePath As String)
        'If System.IO.File.Exists(filePath & "\.sortSettings.txt") Then
        '    '_fileStream = IO.File.Open(filePath & "\.sortSettings.txt", System.IO.FileMode.Open)
        '    rootDir = filePath.Trim
        '    ParseSettings()
        'ElseIf System.IO.File.Exists(filePath & "\sortSettings.xml") Then
        If System.IO.File.Exists(filePath & "\sortSettings.xml") Then
            rootDir = New SortDirectory(filePath.Trim, dirType.ROOTDIR)
            ParseSettingsXML()
        End If
    End Sub

    Public Sub New(ByVal root As SortDirectory, ByVal _mains As List(Of SortDirectory), ByVal _presorts As List(Of SortDirectory), ByVal _blocks As List(Of SortDirectory), ByVal _converts As List(Of SortDirectory), ByVal _finished As SortDirectory)
        rootDir = root
        For Each d In _mains
            mainDirs.Add(d)
        Next
        For Each d In _presorts
            preSortDirs.Add(d)
        Next
        For Each d In _blocks
            blockedDirs.Add(d)
        Next
        If _finished IsNot Nothing Then
            FinishedDir = _finished
        End If
    End Sub

    Public Sub setDir(ByVal filePath As String)
        If System.IO.File.Exists(filePath & "\sortSettings.xml") Then
            ParseSettingsXML()
            rootDir = New SortDirectory(filePath.Trim, dirType.ROOTDIR)
        End If
    End Sub

    Public Sub addToDirList(ByVal _dir As String, ByVal _type As dirType, Optional ByVal title As String = "", Optional ByVal scriptPath As String = "", Optional ByVal convType As String = "")
        Select Case (_type)
            Case dirType.MAINDIR
                addToDirList(New SortDirectory(_dir, 0, dirType.MAINDIR), mainDirs)
            Case dirType.PRESORTDIR
                addToDirList(New SortDirectory(_dir, 0, dirType.PRESORTDIR), presortDirs)
            Case dirType.CONVERTDIR
                'ConvertDirs.Add(New Tuple(Of String, String, String)(_dir, title, scriptPath))
                addToDirList(New SortDirectory(_dir, 0, dirType.CONVERTDIR, False, title, scriptPath, convType), convertDirs)
            Case dirType.FINISHEDDIR
                FinishedDir = New SortDirectory(_dir, 0, dirType.FINISHEDDIR)
        End Select
    End Sub

    Private Sub addToDirList(ByVal _dir As SortDirectory, ByRef _list As List(Of SortDirectory))
        If Not _list.Contains(_dir) Then
            _list.Add(_dir)
        End If
    End Sub

    Public Function removeFromDirList(ByVal _dir As String, ByVal _type As dirType) As Boolean
        Select Case (_type)
            Case dirType.MAINDIR
                Return removeFromDirList(_dir, mainDirs)
            Case dirType.PRESORTDIR
                Return removeFromDirList(_dir, presortDirs)
            Case dirType.ROOTDIR
                Return False
            Case dirType.FINISHEDDIR
                If FinishedDir IsNot Nothing OrElse Not FinishedDir.Equals("") Then
                    FinishedDir = Nothing
                    Return True
                Else
                    Return False
                End If
            Case dirType.CONVERTDIR
                For Each c As SortDirectory In convertDirs
                    If c.fullName.Equals(_dir) Then
                        Return convertDirs.Remove(c)
                    Else
                        'Return False
                    End If
                Next

            Case dirType.ERRORDIR
                Return False
            Case dirType.BLOCKEDDIR
                Return removeFromDirList(_dir, blockedDirs)
        End Select
    End Function

    Function removeFromDirList(ByVal _dir As String, ByRef _list As List(Of SortDirectory)) As Boolean
        If _list IsNot Nothing AndAlso _list.Count() > 0 Then
            For Each sd As SortDirectory In _list
                If sd.fullName.Equals(_dir) Then
                    Return _list.Remove(sd)
                End If
                'If it got here, then it did not run the return statement (i.e., it did not find a directory in the list that matched the target directory)
                'so there's a chance the target directory may exist in this SortDirectory sd's list of subdirectories
                If removeFromDirList(_dir, sd.getSubs) Then
                    Return True
                End If
            Next
        End If
    End Function

    Public Function ParseSettingsXML() As Boolean
        'Dim reader = XmlReader.Create(rootDir & "\sortSettings.xml")
        Dim xdoc As XmlDocument = New XmlDocument
        xdoc.Load(rootDir.fullName & "\sortSettings.xml")

        Dim emain = xdoc.GetElementsByTagName(XMLNODEMAIN)
        Dim pmain = xdoc.GetElementsByTagName(XMLNODEPRESORTS)
        Dim bmain = xdoc.GetElementsByTagName(XMLNODEBLOCKED)
        Dim cmain = xdoc.GetElementsByTagName(XMLNODECONVERT)
        Dim finish = xdoc.GetElementsByTagName(XMLNODEFINISHED)

        For Each e As XmlNode In emain
            For Each c As XmlNode In e.ChildNodes
                If c.Name = "dir" Then
                    addToDirList(c.FirstChild.Value.Trim, dirType.MAINDIR)
                End If
            Next
        Next

        For Each e As XmlNode In pmain
            For Each c As XmlNode In e.ChildNodes
                If c.Name = "dir" Then
                    addToDirList(c.FirstChild.Value.Trim, dirType.PRESORTDIR)
                End If
            Next
        Next

        For Each e As XmlNode In bmain
            For Each c As XmlNode In e.ChildNodes
                If c.Name = "dir" Then
                    addToDirList(c.FirstChild.Value.Trim, dirType.BLOCKEDDIR)
                End If
            Next
        Next

        For Each e As XmlNode In cmain
            For Each c As XmlNode In e.ChildNodes
                If c.Name = "dir" Then
                    Dim script As String = c.Attributes.GetNamedItem("script").Value
                    Dim name As String = c.Attributes.GetNamedItem("name").Value
                    addToDirList(c.FirstChild.Value.Trim, dirType.CONVERTDIR, name, script)
                End If
            Next
        Next

        For Each e As XmlNode In finish
            For Each c As XmlNode In e.ChildNodes
                If c.Name = "dir" Then
                    addToDirList(c.FirstChild.Value.Trim, dirType.FINISHEDDIR)
                End If
            Next
        Next
    End Function

    Public Function SaveSettingsXML() As Boolean
        Dim xws As XmlWriterSettings = New XmlWriterSettings
        xws.Indent = True

        Using writer As XmlWriter = XmlWriter.Create(_rootDir.fullName + "\sortSettings.xml", xws)
            writer.WriteStartDocument()
            writer.WriteStartElement("rootDir")
            writer.WriteAttributeString("dir", _rootDir.fullName)

            writer.WriteStartElement("mains")
            For Each m In mainDirs
                writer.WriteStartElement("dir")
                If m.hasSubs() Then
                    writer.WriteAttributeString("hasSub", "true")
                    m.saveSubs()
                End If
                writer.WriteString(m.fullName)
                writer.WriteFullEndElement()
            Next
            writer.WriteFullEndElement()

            writer.WriteStartElement("presorts")
            For Each p In presortDirs
                writer.WriteStartElement("dir")
                'If p.hasSubs() Then
                '    writer.WriteStartAttribute("hasSub", "true")
                '    p.saveSubs()
                'End If
                writer.WriteString(p.fullName)
                writer.WriteFullEndElement()
            Next
            writer.WriteFullEndElement()

            writer.WriteStartElement("convert")
            For Each c In convertDirs
                writer.WriteStartElement("dir")
                writer.WriteAttributeString("name", c.getConvTitle)
                writer.WriteAttributeString("script", c.getScriptPath)
                writer.WriteString(c.fullName)
                writer.WriteFullEndElement()
            Next
            writer.WriteFullEndElement()

            writer.WriteStartElement("finished")
            If FinishedDir IsNot Nothing Then
                writer.WriteStartElement("dir")
                writer.WriteString(FinishedDir.fullName)
                writer.WriteFullEndElement()
            End If
            writer.WriteFullEndElement()

            writer.WriteFullEndElement()
            writer.Close()
        End Using

    End Function


    Public Function IsValidSettings(ByVal _in As String) As Boolean
        Dim tempRoot As String
        Dim tempMains As List(Of String) = New List(Of String)
        Dim tempPresort As List(Of String) = New List(Of String)
        Dim tempBlock As List(Of String) = New List(Of String)

        If Not _in = "" Then
            Dim temp As Match = Regex.Match(_in, rootRegex)
            tempRoot = temp.ToString.Remove(0, rootHeader.Length)

            If Not IO.Directory.Exists(rootDir.fullName) Then
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
        If Not IO.Directory.Exists(rootDir.fullName) Then
            Throw New InvalidDirectoryException("Root Directory Does not exist!" & vbNewLine & rootDir.fullName)
            ret = False
        End If

        For Each main In mainDirs
            If Not IO.Directory.Exists(main.fullName) Then
                Throw New InvalidDirectoryException("Main Directory Does not exist!" & vbNewLine & main.fullName)
                ret = False
            End If
        Next

        For Each presort In preSortDirs
            If Not IO.Directory.Exists(presort.fullName) Then
                Throw New InvalidDirectoryException("Presorted Directory Does not exist!" & vbNewLine & presort.fullName)
                ret = False
            End If
        Next

        For Each block In blockedDirs
            If Not IO.Directory.Exists(block.fullName) Then
                Throw New InvalidDirectoryException("Blocked Directory Does not exist!" & vbNewLine & block.fullName)
                ret = False
            End If
        Next

        For Each conv In convertDirs
            If Not IO.Directory.Exists(conv.fullName) Then
                Throw New InvalidDirectoryException("Conversion Directory Does not exist!" & vbNewLine & conv.fullName)
                ret = False
            End If

            If conv.getScriptPath IsNot Nothing OrElse IO.File.Exists(conv.getScriptPath) Then
                Throw New InvalidDirectoryException("Conversion Directory Script Does not exist!" & vbNewLine & conv.fullName)
                ret = false
            End If
        Next


        Return ret
    End Function

    Public Function getList(ByVal which As dirType) As List(Of SortDirectory)
        Dim ret As New List(Of SortDirectory)
        Select Case which
            Case dirType.ROOTDIR
                ret.Add(rootDir)
            Case dirType.MAINDIR
                ret.AddRange(mainDirs)
            Case dirType.PRESORTDIR
                ret.AddRange(preSortDirs)
            Case dirType.BLOCKEDDIR
                ret.AddRange(blockedDirs)
            Case dirType.CONVERTDIR
                ret.AddRange(convertDirs)
        End Select
        Return ret
    End Function

    Public Function getFinished() As SortDirectory
        Return FinishedDir
    End Function

    Public Function getConvDirs() As List(Of SortDirectory)
        Return convertDirs
    End Function

    Public Overrides Function toString() As String
        Dim tempMain As String = mainsHeader + vbNewLine
        Dim tempPres As String = presortHeader + vbNewLine
        Dim tempBlock As String = blockHeader + vbNewLine
        For Each l In mainDirs
            tempMain += l.fullName + vbNewLine
        Next
        tempMain += "#" + vbNewLine

        For Each l In preSortDirs
            tempPres += l.fullName + vbNewLine
        Next
        tempPres += "#" + vbNewLine

        For Each l In blockedDirs
            tempBlock += l.fullName + vbNewLine
        Next
        tempBlock += "#" + vbNewLine

        Return rootHeader + vbNewLine + rootDir.fullName.Trim + vbNewLine + "#" + vbNewLine + tempMain + tempPres + tempBlock

    End Function

    Public Sub Close()
        Try
            _fileStream.Close()
        Catch ex As Exception
            Debug.WriteLine(ex.Message)
        End Try
    End Sub

End Class