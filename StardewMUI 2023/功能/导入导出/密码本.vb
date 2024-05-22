Imports System.IO

Public Class 密码本

    Public Shared Property 导入导出密码本 As New List(Of String)

    Public Shared Sub 添加导入导出密码到密码本中(key As String)
        If Not 导入导出密码本.Contains(key) Then
            导入导出密码本.Add(key)
        End If
    End Sub

    Public Shared Sub 保存导入导出密码本()
        Dim a As String = ""
        For i = 0 To 导入导出密码本.Count - 1
            If a = "" Then
                a = 导入导出密码本(i)
            Else
                a &= vbCrLf & 导入导出密码本(i)
            End If
        Next
        FileIO.FileSystem.WriteAllText(Path.Combine(设置.用户数据文件夹路径, "Keys"), a, False)
    End Sub

    Public Shared Sub 读取导入导出密码本()
        If FileIO.FileSystem.FileExists(Path.Combine(设置.用户数据文件夹路径, "Keys")) Then
            导入导出密码本 = FileIO.FileSystem.ReadAllText(Path.Combine(设置.用户数据文件夹路径, "Keys")).Split(vbCrLf).ToList
        End If
    End Sub

End Class
