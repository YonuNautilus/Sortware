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


    'https://stackoverflow.com/questions/27367190/how-to-return-kb-mb-and-gb-from-bytes-using-a-public-function
    Public Shared Function GetFileSize(ByVal TheFile As String) As String
        Dim DoubleBytes As Double
        If TheFile.Length = 0 Then Return ""
        If Not System.IO.File.Exists(TheFile) Then Return ""
        '---
        Dim TheSize As ULong = My.Computer.FileSystem.GetFileInfo(TheFile).Length
        Dim SizeType As String = ""
        '---

        Try
            Select Case TheSize
                Case Is >= 1099511627776
                    DoubleBytes = CDbl(TheSize / 1099511627776) 'TB
                    Return FormatNumber(DoubleBytes, 2) & " TB"
                Case 1073741824 To 1099511627775
                    DoubleBytes = CDbl(TheSize / 1073741824) 'GB
                    Return FormatNumber(DoubleBytes, 2) & " GB"
                Case 1048576 To 1073741823
                    DoubleBytes = CDbl(TheSize / 1048576) 'MB
                    Return FormatNumber(DoubleBytes, 2) & " MB"
                Case 1024 To 1048575
                    DoubleBytes = CDbl(TheSize / 1024) 'KB
                    Return FormatNumber(DoubleBytes, 2) & " KB"
                Case 0 To 1023
                    DoubleBytes = TheSize ' bytes
                    Return FormatNumber(DoubleBytes, 2) & " bytes"
                Case Else
                    Return ""
            End Select
        Catch
            Return ""
        End Try
    End Function
End Class
