Public Class YesNoApplyToAll

    Public Property applyAll As Boolean = False

    Public Sub New(ByVal msg As String)
        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        MainLabel.Text = msg
    End Sub

    Private Sub YesButton_Click(sender As Object, e As EventArgs) Handles YesButton.Click
        Me.DialogResult = DialogResult.Yes
        applyAll = ApplyAllChkBx.Checked
    End Sub

    Private Sub NoButton_Click(sender As Object, e As EventArgs) Handles NoButton.Click
        Me.DialogResult = DialogResult.No
        applyAll = ApplyAllChkBx.Checked
    End Sub

    Private Sub CancelButton_Click(sender As Object, e As EventArgs) Handles CancelButton.Click
        Me.DialogResult = DialogResult.Cancel
        applyAll = ApplyAllChkBx.Checked
    End Sub
End Class