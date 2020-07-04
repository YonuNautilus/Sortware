Public Class DupeStruct

    Private Class FileNamePair
        Private Dir1Files As List(Of String)
        Private Dir2Files As List(Of String)

        Public Sub New()
            Dir1Files = New List(Of String)
            Dir2Files = New List(Of String)
        End Sub

        Public Sub New(ByVal d1f As String, ByVal d2f As String)
            Dir1Files = New List(Of String)
            Dir2Files = New List(Of String)

            If d1f IsNot Nothing Then
                Dir1Files.Add(d1f)
            End If

            If d2f IsNot Nothing Then
                Dir2Files.Add(d2f)
            End If
        End Sub

        Public Sub AddD1File(ByVal fname As String)
            Dir1Files.Add(fname)
        End Sub

        Public Sub AddD2File(ByVal fname As String)
            Dir2Files.Add(fname)
        End Sub

        Public Function Count() As Long
            Return Dir1Files.Count + Dir2Files.Count
        End Function

        Public Function isGoodCount() As Boolean
            Return (Count() > 1)
        End Function

        Public Function GetDir1Files() As List(Of String)
            Return New List(Of String)(Dir1Files)
        End Function

        Public Function GetDir2Files() As List(Of String)
            Return New List(Of String)(Dir2Files)
        End Function
    End Class

    Private dupeDict As Dictionary(Of Long, FileNamePair)

    Public Sub New()
        dupeDict = New Dictionary(Of Long, FileNamePair)
    End Sub

    Public Sub AddD1File(ByVal size As Long, ByVal fname As String)
        If Not dupeDict.ContainsKey(size) Then
            dupeDict.Add(size, New FileNamePair(fname, Nothing))
        Else
            dupeDict.Item(size).AddD1File(fname)
        End If
    End Sub

    Public Sub AddD2File(ByVal size As Long, ByVal fname As String)
        If Not dupeDict.ContainsKey(size) Then
            dupeDict.Add(size, New FileNamePair(Nothing, fname))
        Else
            dupeDict.Item(size).AddD2File(fname)
        End If
    End Sub

    Public Sub ClearLowCountSizes()
        For Each item In dupeDict.ToList
            If Not item.Value.isGoodCount Then
                dupeDict.Remove(item.Key)
            End If
        Next
    End Sub

    Public Function GetDir1Files() As List(Of String)
        Dim ret As List(Of String) = New List(Of String)
        For Each item In dupeDict
            ret.AddRange(item.Value.GetDir1Files)
        Next
        Return ret
    End Function

    Public Function GetDir2Files() As List(Of String)
        Dim ret As List(Of String) = New List(Of String)
        For Each item In dupeDict
            ret.AddRange(item.Value.GetDir2Files)
        Next
        Return ret
    End Function

    Public Sub Clear()
        dupeDict.Clear()
    End Sub
End Class
