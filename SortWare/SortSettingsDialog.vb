Public Class SortSettingsDialog
    Private _rootDir As String
    Public Sub New(ByVal path As String)
        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        _rootDir = path


    End Sub
End Class