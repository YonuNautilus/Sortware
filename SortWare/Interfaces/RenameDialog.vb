Public Class RenameDialog
    Private _path As String
    Public Sub New(ByVal path As String)

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        Label1.Text = "Renaming File: " & path
        _path = path
    End Sub

    Private Sub TextBox1_TextChanged(sender As Object, e As EventArgs) Handles TextBox1.TextChanged

    End Sub

    Private Sub HandleKeys(ByVal sender As Object, ByVal e As KeyEventArgs) Handles MyBase.KeyDown
        If e.KeyCode = Keys.Enter Then
            Dim oldPath As String = IO.Path.GetFileNameWithoutExtension(_path)
            Dim newFileName As String = TextBox1.Text & IO.Path.GetExtension(_path)
            If Not oldPath.Equals(TextBox1.Text) Then
                Try
                    FileIO.FileSystem.RenameFile(_path, newFileName)
                Catch ex As Exception
                    Return
                End Try
                Me.Close()
            End If
        End If
    End Sub
End Class