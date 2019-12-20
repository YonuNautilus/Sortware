Public Class SortDirectory

    Private dir As IO.DirectoryInfo
    Private dirString As String = ""
    Private indent As Integer
    Private tags As String()
    Private isSub As Boolean = False
    Private subDirs As List(Of SortDirectory)

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

    Public Sub New(ByVal _dir As String, ByVal _in As Integer, ByVal _type As SortSettings.dirType, ByVal Optional isSubDir As Boolean = False)
        type = _type
        dirString = _dir
        dir = New IO.DirectoryInfo(_dir)

        If _in > 0 Then
            indent = _in
        Else
            indent = 0
        End If

        isSub = isSubDir

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
        Dim sss As New SubSortSettings(Me.fullName)
        For Each d In sss.getList(SortSettings.dirType.MAINDIR)
            Me.addSubDir(New SortDirectory(d, indent + 1, SortSettings.dirType.MAINDIR, True))
        Next
    End Sub
    Public Sub saveSubs()
        If Me.hasSubs Then
            Using _sortSettingsWriter = New IO.StreamWriter(Me.fullName + "\.SubSortSettings.txt")
                _sortSettingsWriter.Write(New SubSortSettings(Me, subDirs).toString)
            End Using
        End If
    End Sub


    Public Function hasSubs() As Boolean
        Return subDirs IsNot Nothing Or (Me.exists AndAlso IO.File.Exists(Me.fullName + "\.subSortSettings.txt"))
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

    Public Function isSubDir() As Boolean
        Return isSub
    End Function

    Public Overrides Function ToString() As String
        Return dir.Name.PadLeft((indent * 3) + dir.Name.Length, Convert.ToChar(" "))
    End Function
End Class
