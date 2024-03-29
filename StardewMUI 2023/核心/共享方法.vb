﻿Imports System.IO
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

    Public Shared Function CompareVersion(Version1 As String, Version2 As String) As Long
        Dim i As Long, iUbound As Long, iCha As Long
        Dim arrVer1() As String, arrVer2() As String
        arrVer1 = Split(Version1, ".")
        arrVer2 = Split(Version2, ".")
        If UBound(arrVer1) > UBound(arrVer2) Then
            iUbound = UBound(arrVer2)
        Else
            iUbound = UBound(arrVer1)
        End If
        For i = LBound(arrVer1) To iUbound
            If InStr(arrVer1(i), "beta") > 0 And InStr(arrVer2(i), "beta") <= 0 Then
                Return -1
                Exit Function
            End If
            If InStr(arrVer1(i), "beta") <= 0 And InStr(arrVer2(i), "beta") > 0 Then
                Return 1
                Exit Function
            End If
            iCha = Val(arrVer1(i)) - Val(arrVer2(i))
            If iCha > 0 Then
                Return 1
                Exit Function
            ElseIf iCha < 0 Then
                Return -1
                Exit Function
            End If
        Next
        Return UBound(arrVer1) - UBound(arrVer2)
        Exit Function
    End Function

    Public Shared Function SearchFolderWithoutSub(Path As String) As String()
        Dim mDir As System.IO.DirectoryInfo
        Dim mDirInfo As New System.IO.DirectoryInfo(Path)
        Dim a As String() = Array.Empty(Of String)()
        For Each mDir In mDirInfo.GetDirectories
            ReDim Preserve a(a.Length)
            a(a.Length - 1) = mDir.Name
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
