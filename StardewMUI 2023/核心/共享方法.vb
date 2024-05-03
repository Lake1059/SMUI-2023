Imports System.IO
Imports System.Security.Cryptography
Imports System.Text

Public Class 共享方法

    Public Shared Function CalculateSHA256(filePath As String) As String
        Using sha256 As SHA256 = SHA256.Create()
            Using fileStream As IO.FileStream = IO.File.OpenRead(filePath)
                Dim hashBytes() As Byte = sha256.ComputeHash(fileStream)
                Dim stringBuilder As New StringBuilder()
                For Each hashByte As Byte In hashBytes
                    stringBuilder.Append(hashByte.ToString("x2"))
                Next
                Return stringBuilder.ToString()
            End Using
        End Using
    End Function

    Public Shared Function 获取模组更新ID(ByVal OneLineText As String, ByVal FindID As String) As String
        Dim x0, x1, x2, x3
        If InStr(OneLineText, "@") > 0 Then
            x0 = Mid(OneLineText, 1, InStr(OneLineText, "@") - 1)
        Else
            x0 = OneLineText
        End If
        x1 = InStr(x0.ToLower, FindID.ToLower) + Len(FindID.ToLower)
        x2 = Mid(x0.ToLower, x1)
        x3 = Replace(x2, " ", "")
        x3 = Replace(x3, ":", "")
        Return x3
    End Function

    Public Shared Function 获取模组更新平台地址(ByVal OneLineText As String, ByVal PlatformName As String) As String
        Dim a As String = OneLineText.ToLower
        Dim b As Integer = InStr(a, PlatformName.ToLower)
        If b > 0 Then
            Dim c As Integer = InStr(b + Len(PlatformName), a, ":")
            If c <= 0 Then Return "" : Exit Function
            Return Mid(OneLineText, c + 1)
        Else
            Return ""
        End If
    End Function

    Public Shared Function CompareVersion(Version1 As String, Version2 As String) As Int128
        Dim cleanVersion1 As String = System.Text.RegularExpressions.Regex.Replace(Version1, "[^\d\.]", "")
        Dim cleanVersion2 As String = System.Text.RegularExpressions.Regex.Replace(Version2, "[^\d\.]", "")
        ' 将版本号拆分成数字数组
        Dim arrVersion1() As String = cleanVersion1.Split("."c)
        Dim arrVersion2() As String = cleanVersion2.Split("."c)
        ' 获取较长的版本号的长度
        Dim maxLength As Int128 = Math.Max(arrVersion1.Length, arrVersion2.Length)
        ' 逐位比较版本号
        For i As Integer = 0 To maxLength - 1
            Dim num1 As Int128 = If(i < arrVersion1.Length, Int128.Parse(arrVersion1(i)), 0)
            Dim num2 As Int128 = If(i < arrVersion2.Length, Int128.Parse(arrVersion2(i)), 0)
            If num1 < num2 Then
                Return -1
            ElseIf num1 > num2 Then
                Return 1
            End If
        Next
        ' 如果所有位都相等，则版本号相等
        Return 0
    End Function

    Public Shared Function SearchFolderWithoutSub(Path As String) As List(Of String)
        Dim mDir As System.IO.DirectoryInfo
        Dim mDirInfo As New System.IO.DirectoryInfo(Path)
        Dim a As New List(Of String)
        For Each mDir In mDirInfo.GetDirectories
            a.Add(mDir.Name)
        Next
        Return a
    End Function

    Public Shared Function 扫描文件夹不包含子目录(路径 As String) As List(Of String)
        Dim mDir As System.IO.DirectoryInfo
        Dim mDirInfo As New System.IO.DirectoryInfo(路径)
        Dim a As New List(Of String)
        For Each mDir In mDirInfo.GetDirectories
            a.Add(mDir.Name)
        Next
        Return a
    End Function


    Public Shared Function 扫描子库(路径 As String) As List(Of String)
        Dim mDir As System.IO.DirectoryInfo
        Dim mDirInfo As New System.IO.DirectoryInfo(路径)
        Dim a As New List(Of String)
        For Each mDir In mDirInfo.GetDirectories
            If InStrRev(mDir.Name, ".") = 1 Then Continue For
            a.Add(mDir.Name)
        Next
        Return a
    End Function

    Public Shared Function GetDirectorySizeWithSub(folderPath As String) As Long
        Dim size As Long = 0
        Try
            Dim di As New DirectoryInfo(folderPath)
            Dim files As FileInfo() = di.GetFiles()
            For Each file As FileInfo In files
                size += file.Length
            Next
            Dim subDirectories As DirectoryInfo() = di.GetDirectories()
            For Each subDirectory As DirectoryInfo In subDirectories
                size += GetDirectorySizeWithSub(subDirectory.FullName)
            Next
        Catch ex As Exception
            Return -1
        End Try
        Return size
    End Function

    Public Shared Function GetDirectorySizeWithSub(folderPath As String, EX_FolderName As String()) As Long
        Dim size As Long = 0
        Try
            Dim di As New DirectoryInfo(folderPath)
            Dim files As FileInfo() = di.GetFiles()
            For Each file As FileInfo In files
                size += file.Length
            Next
            Dim subDirectories As DirectoryInfo() = di.GetDirectories()
            For Each subDirectory As DirectoryInfo In subDirectories
                If EX_FolderName.Contains(subDirectory.Name) Then Continue For
                size += GetDirectorySizeWithSub(subDirectory.FullName)
            Next
        Catch ex As Exception
            Return -1
        End Try
        Return size
    End Function


End Class
