

Imports System.Text.RegularExpressions

Public Class NEXUS判断合适的文件标题

    Public Shared Function 尝试判断(旧标题 As String, 新标题列表 As List(Of String)) As String
        Dim bestMatch As String = Nothing
        Dim smallestDifference As Integer = Integer.MaxValue

        For Each title In 新标题列表
            If title = 旧标题 Then
                ' 如果有完全匹配的标题，则直接选用
                Return title
            End If
            Dim diff As Integer = GetTitleDifference(旧标题, title)
            If diff < smallestDifference Then
                smallestDifference = diff
                bestMatch = title
            End If
        Next
        Return bestMatch
    End Function

    ' 比较两个标题的差异
    Private Shared Function GetTitleDifference(title1 As String, title2 As String) As Integer
        Dim version1 As String = ExtractVersion(title1)
        Dim version2 As String = ExtractVersion(title2)

        If String.IsNullOrEmpty(version1) OrElse String.IsNullOrEmpty(version2) Then
            ' 如果没有版本号则进行简单的文本比较
            Return LevenshteinDistance(title1, title2)
        Else
            ' 比较版本号
            Dim v1 As New Version(version1)
            Dim v2 As New Version(version2)
            If v1 > v2 Then
                Return 1
            ElseIf v1 < v2 Then
                Return -1
            Else
                Return 0
            End If
        End If
    End Function

    ' 提取标题中的版本号
    Private Shared Function ExtractVersion(title As String) As String
        Dim match As Match = Regex.Match(title, "\d+(\.\d+)+")
        If match.Success Then
            Return match.Value
        Else
            Return String.Empty
        End If
    End Function

    ' 计算两个字符串的Levenshtein距离
    Private Shared Function LevenshteinDistance(s As String, t As String) As Integer
        Dim n As Integer = s.Length
        Dim m As Integer = t.Length
        Dim d(,) As Integer = New Integer(n, m) {}

        If n = 0 Then Return m
        If m = 0 Then Return n

        For i As Integer = 0 To n
            d(i, 0) = i
        Next

        For j As Integer = 0 To m
            d(0, j) = j
        Next

        For i As Integer = 1 To n
            For j As Integer = 1 To m
                Dim cost As Integer = If(s(i - 1) = t(j - 1), 0, 1)
                d(i, j) = Math.Min(Math.Min(d(i - 1, j) + 1, d(i, j - 1) + 1), d(i - 1, j - 1) + cost)
            Next
        Next

        Return d(n, m)
    End Function

End Class
