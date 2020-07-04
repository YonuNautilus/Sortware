Public Class FileConversion

    Private conversionDirs As List(Of SortDirectory)
    Private finishedDir As SortDirectory
    Public Sub New(ByVal convDirs As List(Of SortDirectory), ByVal finDir As SortDirectory)
        ' This call is required by the designer.
        InitializeComponent()

        conversionDirs = convDirs
        finishedDir = finDir
        refreshDirs()
    End Sub

    Private Sub refreshDirs()
        ConversionFolders.Items.Clear()

        For Each e In conversionDirs
            Dim lvi As New ListViewItem({e.getName, e.fullName, e.getScriptPath})
            ConversionFolders.Items.Add(lvi)
        Next
    End Sub

    Private Sub refreshFiles()
        FilesToBeConverted.Items.Clear()

        If ConversionFolders.SelectedItems.Count = 1 Then
            Dim loc As String = ConversionFolders.SelectedItems.Item(0).SubItems(1).Text
            Dim fType As String = System.Text.RegularExpressions.Regex.Match(ConversionFolders.SelectedItems.Item(0).Text, "^\S{0,}").Value.ToLower
            For Each f In IO.Directory.GetFiles(loc)
                If fType.Contains(IO.Path.GetExtension(f).ToLower.Remove(0, 1)) Then
                    Dim newItem As ListViewItem = FilesToBeConverted.Items.Add(f)
                    Dim newName As String = IO.Path.GetFileNameWithoutExtension(f) & ".mp4"
                    If IO.File.Exists(finishedDir.fullName & "\" & newName) Then
                        newItem.BackColor = Color.DarkRed
                        newItem.ForeColor = Color.White
                    End If
                End If
            Next
        End If
    End Sub

    Private Sub ConversionFolders_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ConversionFolders.SelectedIndexChanged
        refreshFiles()
    End Sub

    Private Sub ConvSelected_Click(sender As Object, e As EventArgs) Handles ConvSelected.Click
        For Each f As ListViewItem In FilesToBeConverted.SelectedItems()
            Dim oldName As String = f.Text
            Dim fname As String = IO.Path.GetFileNameWithoutExtension(f.Text) & ".mp4"
            Dim newName As String = finishedDir.fullName & "\" & fname
            Dim scriptLoc As String = ConversionFolders.SelectedItems.Item(0).SubItems(1).Text
            Dim scriptName As String = IO.Path.GetFileName(ConversionFolders.SelectedItems.Item(0).SubItems(2).Text)
            Dim proc As New Process
            Try
                Dim batDir As String = String.Format("D:\")
                proc = New Process
                proc.StartInfo.WorkingDirectory = IO.Path.GetDirectoryName(ConversionFolders.SelectedItems.Item(0).SubItems(1).Text)
                proc.StartInfo.FileName = scriptLoc
                proc.StartInfo.Arguments = """" & oldName & """" & " " & """" & newName & """"
                proc.StartInfo.CreateNoWindow = False
                Dim newProc As Process = Process.Start(scriptLoc & "\" & scriptName, proc.StartInfo.Arguments)
                newProc.WaitForExit()
            Catch ex As Exception

            End Try
        Next
        refreshFiles()
    End Sub

    Private Sub ClearDone_Click(sender As Object, e As EventArgs) Handles ClearDone.Click
        If ConversionFolders.SelectedItems.Count = 1 Then
            Dim loc As String = ConversionFolders.SelectedItems.Item(0).SubItems(1).Text
            Dim fType As String = System.Text.RegularExpressions.Regex.Match(ConversionFolders.SelectedItems.Item(0).Text, "^\S{0,}").Value.ToLower
            For Each f In IO.Directory.GetFiles(loc)
                If fType.Contains(IO.Path.GetExtension(f).ToLower.Remove(0, 1)) Then
                    Dim newItem As ListViewItem = FilesToBeConverted.Items.Add(f)
                    Dim newName As String = IO.Path.GetFileNameWithoutExtension(f) & ".mp4"
                    If IO.File.Exists(finishedDir.fullName & "\" & newName) Then
                        IO.File.Delete(f)
                    End If
                End If
            Next
        End If
        refreshFiles()
    End Sub
End Class