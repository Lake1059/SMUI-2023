
Imports System.IO

Public Class 管理模组3

    Public Shared Sub 更新选中分类_从安装命令到安装规划()
        If FileIO.FileSystem.DirectoryExists(管理模组2.检查并返回当前所选子库路径(True)) = False Then
            Exit Sub
        End If
        Dim 数据子库路径 As String = 管理模组2.检查并返回当前所选子库路径(False)
        For i = 0 To Form1.ListView1.SelectedIndices.Count - 1
            Dim 分类名称 As String = Form1.ListView1.Items(Form1.ListView1.SelectedIndices(i)).Text
            Dim 模组项列表 As List(Of String) = 共享方法.扫描文件夹不包含子目录(Path.Combine(数据子库路径, 分类名称))
            For x = 0 To 模组项列表.Count - 1
                Dim 模组项路径 As String = Path.Combine(数据子库路径, 分类名称, 模组项列表(x))
                Try
                    If FileIO.FileSystem.FileExists(Path.Combine(模组项路径, "Code")) Then
                        FileIO.FileSystem.WriteAllText(Path.Combine(模组项路径, "Code2"), 命令规划转换.将安装命令转换到安装规划(FileIO.FileSystem.ReadAllText(Path.Combine(模组项路径, "Code"))), False)
                    End If
                Catch ex As Exception
                    DebugPrint(ex.Message, Color1.红色, True)
                End Try
            Next
        Next
        Dim d1 As New 多项单选对话框("更新配置数据", {"OK"}, "从五代安装命令升级到六代安装规划复写完成",, 500)
        d1.ShowDialog(Form1)
    End Sub

    Public Shared Sub 更新选中分类_从安装规划到安装命令()
        Dim d2 As New 多项单选对话框("更新配置数据", {"OK"}, "降级命令功能还未制作",, 500)
        d2.ShowDialog(Form1)
        Exit Sub
        If FileIO.FileSystem.DirectoryExists(管理模组2.检查并返回当前所选子库路径(True)) = False Then
            Exit Sub
        End If
        Dim 数据子库路径 As String = 管理模组2.检查并返回当前所选子库路径(False)
        For i = 0 To Form1.ListView1.SelectedIndices.Count - 1
            Dim 分类名称 As String = Form1.ListView1.Items(Form1.ListView1.SelectedIndices(i)).Text
            Dim 模组项列表 As List(Of String) = 共享方法.扫描文件夹不包含子目录(Path.Combine(数据子库路径, 分类名称))
            For x = 0 To 模组项列表.Count - 1
                Dim 模组项路径 As String = Path.Combine(数据子库路径, 分类名称, 模组项列表(x))
                Try
                    If FileIO.FileSystem.FileExists(Path.Combine(模组项路径, "Code2")) Then
                        FileIO.FileSystem.WriteAllText(Path.Combine(模组项路径, "Code"), 命令规划转换.将安装规划转换到安装命令(FileIO.FileSystem.ReadAllText(Path.Combine(模组项路径, "Code2"))), False)
                    End If
                Catch ex As Exception
                    DebugPrint(ex.Message, Color1.红色, True)
                End Try
            Next
        Next
        Dim d1 As New 多项单选对话框("更新配置数据", {"OK"}, "从六代安装规划降级到五代安装命令复写完成",, 500)
        d1.ShowDialog(Form1)
    End Sub


End Class
