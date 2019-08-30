Imports System.Threading
Imports System.Threading.Tasks
Imports System.Security.Cryptography

Public Class CheckDupes

    Private root As SortDirectory
    Private GiantDict As Dictionary(Of String, Dictionary(Of String, String)) = New Dictionary(Of String, Dictionary(Of String, String))
    Private FileDict As Dictionary(Of String, String) = New Dictionary(Of String, String)

    Public Sub New(ByVal rootIn As SortDirectory)

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        root = rootIn
    End Sub

    Private Async Sub FindDupesButton_Click(sender As Object, e As EventArgs) Handles FindDupesButton.Click
        FindDupeNames.Enabled = False
        FindDupesButton.Enabled = False
        StatusLabel.Text = "Working..."
        If RegexFilterInput.Text IsNot Nothing Then
            Dim tasks As New List(Of Task)()
            Dim files As List(Of String) = New List(Of String)(IO.Directory.GetFiles(root.fullName))
            Dim i As Integer = 0

            Dim totalAmnt As UInteger = 0
            Dim doneAmnt As UInteger = 0

            For Each l As String In files
                tasks.Add(New Task(Sub()
                                       'Dim fs As IO.FileStream = New IO.FileStream(l, IO.FileMode.Open)
                                       Dim _md5 As MD5 = MD5.Create
                                       Dim inBytes As Byte()
                                       Try
                                           inBytes = IO.File.ReadAllBytes(l)
                                           FileDict.Add(l, BitConverter.ToString(_md5.ComputeHash(inBytes)))
                                           _md5 = Nothing
                                           inBytes = Nothing
                                       Catch ex As Exception

                                       Finally
                                           doneAmnt += CUInt(1)
                                           Dim updateDelegate As New updateBar(AddressOf doUpdateBar)

                                           getUpdateDel(updateDelegate, totalAmnt, doneAmnt)
                                       End Try

                                   End Sub)
                            )
            Next

            totalAmnt = CUInt(tasks.Count)

            For Each t As Task In tasks
                t.Start()
            Next

            Await Task.WhenAll(tasks)

            For Each kvp As KeyValuePair(Of String, String) In FileDict
                Dim lvi As ListViewItem = New ListViewItem(New String() {IO.Path.GetFileName(kvp.Key), kvp.Value})
                lvi.Tag = kvp
                KeepFilesView.Items.Add(lvi)
            Next

        End If
        FindDupeNames.Enabled = True
        FindDupesButton.Enabled = True
        StatusLabel.Text = "Done"
        ToolStripProgressBar.Value = 0
    End Sub

    Private Sub doUpdateBar(ByVal total As UInteger, ByVal done As UInteger)
        If done <> 0 AndAlso total <> 0 Then
            ToolStripProgressBar.Value = CInt(100 * (CDbl(done) / CDbl(total)))
        End If
    End Sub
    Private Sub getUpdateDel(ByVal del As updateBar, ByVal tot As UInteger, ByVal done As UInteger)
        StatusStrip1.Invoke(New updateBar(AddressOf doUpdateBar), New Object() {tot, done})
    End Sub

    Private Delegate Sub updateBar(ByVal tot As UInteger, ByVal done As UInteger)

    'Private Sub KeepFilesView_SelectedIndexChanged(sender As Object, e As EventArgs) Handles KeepFilesView.SelectedIndexChanged
    '    DelFilesView.Items.Clear()

    '    For Each kvp As KeyValuePair(Of String, String) In FileDict
    '        Try
    '            Dim bool1 As Boolean = KeepFilesView.SelectedItems.Item(0).SubItems(0).Equals(kvp.Value)
    '            Dim bool2 As Boolean = Not DirectCast(KeepFilesView.SelectedItems.Item(0).Tag, KeyValuePair(Of String, String)).Equals(kvp)
    '            If bool1 AndAlso bool2 Then
    '                Dim lvi As ListViewItem = New ListViewItem(New String() {IO.Path.GetFileName(kvp.Key), kvp.Value})
    '                lvi.Tag = kvp
    '                DelFilesView.Items.Add(lvi)
    '            End If
    '        Catch ex As Exception

    '        End Try
    '    Next

    '    If DelFilesView.Items.Count = 0 Then
    '        StatusLabel.Text = "No Dupes Found"
    '    End If
    'End Sub

    Private Sub MarkFilesWithDupes_Click(sender As Object, e As EventArgs) Handles MarkFilesWithDupes.Click
        Dim curFile As String = ""
        Dim curHash As String = ""
        Dim k As KeyValuePair(Of String, String) = Nothing
        Dim l As ListViewItem = Nothing
        For Each lvi As ListViewItem In KeepFilesView.Items
            l = lvi

            For Each kvp As KeyValuePair(Of String, String) In FileDict
                Try
                    k = kvp
                    curFile = DirectCast(lvi.Tag, KeyValuePair(Of String, String)).Key
                    curHash = FileDict.Item(curFile)
                    If kvp.Value.Equals(curHash) AndAlso Not kvp.Key.Equals(curFile) Then
                        lvi.BackColor = Color.Red
                    End If

                Catch ex As Exception
                    StatusLabel.Text = "ERROR: " + curFile + " || " + curHash + " || " + lvi.ToString + " || " + k.ToString
                End Try
            Next
        Next
    End Sub
End Class