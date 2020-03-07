Public Class Generics

    Public Const _imgExtensions = ".png .jpg .jpeg .jfif .tif .tiff .gif .bmp"
    Public Const _vidExtensions = ".mov .webm .wmv .mp4 .avi .mkv .m4v .m2ts .mts .mpg .flv"
    Public Const _miscExtensions = ".zip .rar"

    Public Class ListViewItemComparer
        Implements IComparer
        Private colNum As Integer
        Private sOrd As SortOrder

        Public Sub New(ByVal _colNum As Integer, ByVal _sOrd As SortOrder)
            colNum = _colNum
            sOrd = _sOrd
        End Sub

        Public Function Compare(x As Object, y As Object) As Integer Implements IComparer.Compare
            'Throw New NotImplementedException()
            Dim itemX As ListViewItem = DirectCast(x, ListViewItem)
            Dim itemY As ListViewItem = DirectCast(y, ListViewItem)

            'get the subitem values
            Dim stringX As String
            If itemX.SubItems.Count <= colNum Then
                stringX = ""
            Else
                stringX = itemX.SubItems(colNum).Text
            End If

            Dim stringY As String
            If itemY.SubItems.Count <= colNum Then
                stringY = ""
            Else
                stringY = itemY.SubItems(colNum).Text
            End If

            'Compare them
            If sOrd = SortOrder.Ascending Then
                If IsNumeric(stringX) AndAlso IsNumeric(stringY) Then
                    Return Val(stringX).CompareTo(Val(stringY))
                ElseIf IsDate(stringX) AndAlso IsDate(stringY) Then
                    Return DateTime.Parse(stringX).CompareTo(DateTime.Parse(stringY))
                Else
                    Return String.Compare(stringX, stringY)
                End If
            Else
                If IsNumeric(stringY) AndAlso IsNumeric(stringX) Then
                    Return Val(stringY).CompareTo(Val(stringX))
                ElseIf IsDate(stringY) AndAlso IsDate(stringX) Then
                    Return DateTime.Parse(stringY).CompareTo(DateTime.Parse(stringX))
                Else
                    Return String.Compare(stringY, stringX)
                End If
            End If

        End Function
    End Class

    Public Shared Function GetCheck(ByVal node As TreeNodeCollection) As List(Of TreeNode)
        Dim lN As New List(Of TreeNode)
        For Each n As TreeNode In node
            If n.Checked AndAlso n.Tag Is Nothing Then
                lN.Add(n)
            End If
            lN.AddRange(GetCheck(n.Nodes))
        Next

        Return lN
    End Function
End Class
