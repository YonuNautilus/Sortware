Imports System.Xml

Public Class SortDirectory

    Private dir As IO.DirectoryInfo
    Private dirString As String = ""
    Private indent As Integer
    Private tags As String()
    Private isSub As Boolean = False
    Private subDirs As List(Of SortDirectory)
    Private scriptPath As String = ""
    Private convTitle As String = ""

    Private _logReader As IO.StreamReader
    Private _logWriter As IO.StreamWriter

    Private Const TAGFILENAME = "\_tags.txt"
    Public ReadOnly Property type As SortSettings.dirType

    Public Sub New(ByVal _dir As String, Optional ByVal _in As Integer = 0)
        type = SortSettings.dirType.ERRORDIR
        dirString = _dir
        dir = New IO.DirectoryInfo(_dir)

        If _in > 0 Then
            indent = _in
        Else
            indent = 0
        End If
    End Sub

    Public Sub New(ByVal _dir As String, ByVal _in As Integer, ByVal _type As SortSettings.dirType, ByVal Optional isSubDir As Boolean = False, ByVal Optional name As String = "", ByVal Optional script As String = "", ByVal Optional convType As String = "")
        type = _type
        dirString = _dir
        dir = New IO.DirectoryInfo(_dir)

        If _in > 0 Then
            indent = _in
        Else
            indent = 0
        End If

        isSub = isSubDir

        scriptPath = script
        convTitle = name

        If Me.hasTags() Then
            tags = Me.getTagsFromFile()
        End If
        If Me.hasSubs() Then
            Me.loadSubs()
        End If

    End Sub

    Public Function exists() As Boolean
        Return dir.Exists And IO.Directory.Exists(dir.FullName)
    End Function

    Public Sub addSubDir(ByVal s As String)
        If type = SortSettings.dirType.MAINDIR Then
            If s.Contains(Me.fullName) Then
                If subDirs Is Nothing Then subDirs = New List(Of SortDirectory)
            End If
            subDirs.Add(New SortDirectory(s, Me.indent + 1, SortSettings.dirType.MAINDIR, True))
        End If
    End Sub

    Public Sub addSubDir(ByVal sd As SortDirectory)
        If type = SortSettings.dirType.MAINDIR Then
            If sd.fullName.Contains(Me.fullName) Then
                If subDirs Is Nothing Then subDirs = New List(Of SortDirectory)
            End If
            subDirs.Add(sd)
        End If
    End Sub

    Public Sub loadSubs()
        Dim xdoc As XmlDocument = New XmlDocument
        xdoc.Load(fullName() & "\subSortSettings.xml")

        Dim smain = xdoc.GetElementsByTagName(SortSettings.XMLNODESUBS)

        For Each s As XmlNode In smain
            For Each c As XmlNode In s.ChildNodes
                If c.Name = "dir" Then
                    Me.addSubDir(c.FirstChild.Value.Trim)
                End If
            Next
        Next

    End Sub
    Public Sub saveSubs()
        If Me.hasSubs Then

            Dim xws As XmlWriterSettings = New XmlWriterSettings
            xws.Indent = True

            Using writer As XmlWriter = XmlWriter.Create(fullName() + "\subSortSettings.xml", xws)
                writer.WriteStartDocument()
                writer.WriteStartElement("rootDir")
                writer.WriteAttributeString("dir", fullName)

                If subDirs Is Nothing Then
                    writer.WriteStartElement("subs")
                    For Each m In subDirs
                        writer.WriteStartElement("dir")
                        If m.hasSubs() Then
                            writer.WriteAttributeString("hasSub", "true")
                            m.saveSubs()
                        End If
                        writer.WriteString(m.fullName)
                        writer.WriteFullEndElement()
                    Next
                    writer.WriteFullEndElement()
                End If

                writer.WriteFullEndElement()
                writer.Close()
            End Using




            'Using _sortSettingsWriter = New IO.StreamWriter(Me.fullName + "\.SubSortSettings.txt")
            '    _sortSettingsWriter.Write(New SubSortSettings(Me, subDirs).toString)
            'End Using
            'For Each sd In getSubs()
            '    sd.saveSubs()
            'Next
        End If
    End Sub


    Public Function hasSubs() As Boolean
        Return subDirs IsNot Nothing Or (Me.exists AndAlso IO.File.Exists(Me.fullName + "\subSortSettings.xml"))
    End Function

    Public Function getSubs() As List(Of SortDirectory)
        Return subDirs
    End Function

    Public Function hasTags() As Boolean
        Return Me.exists AndAlso IO.File.Exists(Me.fullName & TAGFILENAME)
    End Function

    Public Function getTags() As String()
        Return tags
    End Function

    Private Function getTagsFromFile() As String()
        If Not Me.hasTags Then
            Return Nothing
        End If
        Dim ret As New List(Of String)
        Dim reader As IO.TextReader = New IO.StreamReader(fullName() & TAGFILENAME)
        Dim fullString = Split(reader.ReadToEnd.Trim, vbNewLine)
        reader.Close()
        Return fullString
    End Function

    Public Sub saveTags(ByVal _tags As String)
        'If Me.hasTags Then
        Dim writer = New System.IO.StreamWriter(fullName() & TAGFILENAME, False)
        writer.Write(_tags.Trim)
        writer.Close()
        'End If
        tags = Me.getTagsFromFile()
    End Sub

    Public Function fullName() As String
        Return dir.FullName
    End Function

    Public Function getParent() As SortDirectory
        Return New SortDirectory(IO.Directory.GetParent(dir.FullName).FullName, indent - 1)
    End Function

    Public Function getName() As String
        Return dir.Name
    End Function

    Public Function getConvTitle() As String
        Return If(type = SortSettings.dirType.CONVERTDIR, convTitle, "")
    End Function

    Public Function isSubDir() As Boolean
        Return isSub
    End Function

    Public Function getScriptPath() As String
        Return scriptPath
    End Function

    Public Function matchesFilter(ByVal filter As String) As Boolean
        Dim ret As Boolean = False

        If Not String.IsNullOrWhiteSpace(filter) Then
            If getName.ToLower.Contains(filter.ToLower) Then
                ret = True
            End If

            If hasSubs() Then
                For Each d In getSubs()
                    If d.matchesFilter(filter) Then
                        ret = True
                    End If
                Next
            End If
        End If

        Return ret
    End Function

    Public Sub SetDir(ByVal newDir As String)
        dir = New IO.DirectoryInfo(newDir)
    End Sub

    Public Function isValid() As Boolean
        Dim ret As Boolean = True

        If type = SortSettings.dirType.CONVERTDIR Then
            ret = ret And Not (scriptPath = Nothing OrElse Not IO.Directory.Exists(scriptPath))
        End If

        ret = ret And Me.exists

        Return ret
    End Function

    Public Overrides Function ToString() As String
        Return dir.Name.PadLeft((indent * 3) + dir.Name.Length, Convert.ToChar(" "))
    End Function

End Class
