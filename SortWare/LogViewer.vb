Public Class LogViewer

    Private MI As MainInterface
    Private Class LogItem
        Inherits ListViewItem

        Public Time As ListViewSubItem
        Public Original As ListViewSubItem
        Public Final As ListViewSubItem
        Public Tags As ListViewSubItem
        Public Sub New(ByVal _entry As String)
            Dim things = Split(_entry, vbTab)
            For i As Integer = 0 To things.Length - 1
                'take each line of the log file, split it up by tab, and set the LogItem's fields to the corresponding log file line's field
                Select Case i
                    Case 0
                        Time = New ListViewSubItem(Me, things(i))
                        Me.SubItems.Add(Time)
                    Case 1
                        Original = New ListViewSubItem(Me, things(i))
                        Me.SubItems.Add(Time)
                    Case 2
                        Final = New ListViewSubItem(Me, things(i))
                        Me.SubItems.Add(Time)
                    Case 3
                        Tags = New ListViewSubItem(Me, things(i))
                        Me.SubItems.Add(Time)
                End Select
            Next
            Me.Text = IO.Path.GetFileName(Final.Text)
        End Sub
    End Class
    Public Sub New(ByVal _logs As String(), ByRef mainInt As MainInterface)

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        LogsBox.MultiSelect = False
        MI = mainInt
        For Each l In _logs
            LogsBox.Items.Add(New LogItem(l))
        Next
    End Sub

    Private Sub UndoActionButton_Click(sender As Object, e As EventArgs) Handles UndoActionButton.Click
        Try
            If LogsBox.SelectedItems IsNot Nothing AndAlso TypeOf LogsBox.SelectedItems.Item(0) Is LogItem Then
                Dim final = DirectCast(LogsBox.SelectedItems.Item(0), LogItem).Final.Text
                Dim orig = DirectCast(LogsBox.SelectedItems.Item(0), LogItem).Original.Text
                Dim tags = DirectCast(LogsBox.SelectedItems.Item(0), LogItem).Tags.Text

                If Not IO.Directory.Exists(IO.Path.GetDirectoryName(orig)) Then
                    Throw New IO.IOException("Original File's Directory Doesn't Exist")
                End If
                If Not IO.File.Exists(final) Then
                    Throw New IO.IOException("Final File Doesn't Exist")
                End If

                IO.File.Move(final, orig)
                'Dim finalFile = IO.Path.GetFileName(final)
                'If finalFile.Length >= tags AndAlso finalFile.Substring(0, tags.Length) = tags Then 'If the tags can fit into the file name, and the first part of the file name is the tags, then
                MI.writeToLogFile(final, orig, tags)
                'End If
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try

    End Sub
End Class