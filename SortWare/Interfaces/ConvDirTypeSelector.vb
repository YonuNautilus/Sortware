Public Class ConvDirTypeSelector
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Me.Tag = DirectCast(ComboBox1.SelectedItem, String)
        Me.Close()
    End Sub
End Class