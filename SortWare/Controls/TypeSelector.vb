Public Class TypeSelector

    Protected _allowedExtensions As String = ""

    Public Sub New()

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.

    End Sub
    Public Sub TypeSelect_Load() Handles Me.Load
        Dim itypes = Generics._imgExtensions.Split(" "c)
        Dim vtypes = Generics._vidExtensions.Split(" "c)
        Dim misctypes = Generics._miscExtensions.Split(" "c)
        For Each i In itypes
            TreeView1.Nodes.Item(0).Nodes.Add(i)
        Next
        For Each t In vtypes
            TreeView1.Nodes.Item(1).Nodes.Add(t)
        Next
        For Each m In misctypes
            TreeView1.Nodes.Item(2).Nodes.Add(m)
        Next
        'TreeView1.ExpandAll()
    End Sub

    Public Function isAllowed(ByVal Path As String) As Boolean
        Dim ext As String = IO.Path.GetExtension(Path).ToLower
        Return _allowedExtensions.ToLower.Contains(ext)
    End Function

    Private Sub TreeView1_AfterSelect(sender As Object, e As TreeViewEventArgs) Handles TreeView1.AfterCheck, TreeView1.AfterSelect
        RemoveHandler TreeView1.AfterCheck, AddressOf TreeView1_AfterSelect

        For Each node As TreeNode In e.Node.Nodes
            node.Checked = e.Node.Checked
        Next

        If e.Node.Checked Then
            If e.Node.Parent IsNot Nothing Then
                Dim allChecked As Boolean = True

                For Each node As TreeNode In e.Node.Parent.Nodes
                    If Not node.Checked Then
                        allChecked = False
                    End If
                Next

                If allChecked Then
                    e.Node.Parent.Checked = True
                End If
            End If
        Else
            If e.Node.Parent IsNot Nothing Then
                e.Node.Parent.Checked = False
            End If
        End If

        _allowedExtensions = ""
        For Each n As TreeNode In GetCheck(TreeView1.Nodes)
            _allowedExtensions &= n.Text.Replace("/", " ") & " "
        Next

        AddHandler TreeView1.AfterCheck, AddressOf TreeView1_AfterSelect
        RaiseEvent CheckChanged()
    End Sub

    Private Function GetCheck(ByVal node As TreeNodeCollection) As List(Of TreeNode)
        Dim lN As New List(Of TreeNode)
        For Each n As TreeNode In node
            If n.Checked AndAlso n.Tag Is Nothing Then
                lN.Add(n)
            End If
            lN.AddRange(GetCheck(n.Nodes))
        Next

        Return lN
    End Function

    Public Event CheckChanged()

End Class
