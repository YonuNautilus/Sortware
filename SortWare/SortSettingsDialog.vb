Public Class SortSettingsDialog
    Private _rootDir As String
    Private _sortSettings As IO.FileStream
    Public Sub New(ByVal path As String)
        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        _rootDir = path

        If IO.File.Exists(_rootDir & "\.sortSettings") Then
            InitializeSettings.Enabled = False
        Else
            InitializeSettings.Enabled = True
        End If

        For Each Dir As String In IO.Directory.GetDirectories(_rootDir)
            populateDirs(Dir)
        Next

    End Sub

    Private Sub populateDirs(ByVal _dir As String, Optional ByVal _indent As Integer = 0)
        RootDirView.Items.Add(_dir.PadLeft(_dir.Length + (_indent * 3), Convert.ToChar(" ")))
        For Each Dir As String In IO.Directory.GetDirectories(_dir)
            populateDirs(Dir, _indent + 1)
        Next

        'If IO.Directory.GetDirectories(_dir).Length = 0 Then

        'End If
    End Sub

    Private Sub RefreshButton()
        If IO.File.Exists(_rootDir & "\.sortSettings") Then
            InitializeSettings.Enabled = False
        Else
            InitializeSettings.Enabled = True
        End If
    End Sub

    Private Sub InitializeSettings_Click(sender As Object, e As EventArgs) Handles InitializeSettings.Click
        _sortSettings = New IO.FileStream(_rootDir & "\.sortSettings", IO.FileMode.CreateNew)
        IO.File.SetAttributes(_rootDir & "\.sortSettings", IO.FileAttributes.Hidden)
        RefreshButton()
    End Sub

    Private Sub SortSettingsDialog_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub
End Class