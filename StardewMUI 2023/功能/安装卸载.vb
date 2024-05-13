Imports System.IO

Public Class 安装卸载

    Public Shared Property 正在工作的线程ID As String

    Public Shared Property 后台线程对象 As New ComponentModel.BackgroundWorker
    Public Shared Property 模组项路径列表 As New List(Of String)
    Public Shared Property 当前在模组项列表中的索引列表 As New List(Of Integer)
    Public Shared Property 线程ID As String

    Enum 操作类型
        安装 = 1
        卸载 = 2
        更新项_直接覆盖 = 3
        更新项_完全替换 = 4
    End Enum

    Public Shared Sub 执行操作(操作类型 As 操作类型)
        If Form1.ListView2.SelectedItems.Count = 0 Then Exit Sub
        If 任务队列.项路径 <> "" Then Exit Sub

        模组项路径列表.Clear()
        当前在模组项列表中的索引列表.Clear()

        For i = 0 To Form1.ListView2.SelectedItems.Count - 1
            模组项路径列表.Add(Path.Combine(管理模组2.检查并返回当前所选子库路径(False), Form1.ListView2.SelectedItems(i).SubItems(3).Text, Form1.ListView2.SelectedItems(i).Text))
            当前在模组项列表中的索引列表.Add(Form1.ListView2.SelectedItems(i).Index)
            Select Case 操作类型
                Case 操作类型.安装
                    Form1.ListView2.SelectedItems(i).SubItems(2).Text = "正在安装"
                Case 操作类型.卸载
                    Form1.ListView2.SelectedItems(i).SubItems(2).Text = "正在卸载"
            End Select
        Next
        线程ID = Now.Second & Now.Millisecond
        正在工作的线程ID = 线程ID
        DebugPrint($"{线程ID} 已将所选的 {Form1.ListView2.SelectedItems.Count} 个项中的 {模组项路径列表.Count} 个项载入任务列表", Color1.蓝色)

        后台线程对象 = New ComponentModel.BackgroundWorker With {.WorkerReportsProgress = True}
        AddHandler 后台线程对象.DoWork,
            Sub(sender, e)
                For i = 0 To 模组项路径列表.Count - 1
                    后台线程对象.ReportProgress(2, $"加载规划数据：{Path.GetFileName(模组项路径列表(i))}")
                    任务队列.全部数据初始化()
                    任务队列.项路径 = 模组项路径列表(i)
                    Dim s1 As String = 任务队列.加载安装规划数据()
                    If s1 <> "" Then
                        后台线程对象.ReportProgress(3, $"加载规划数据错误： {s1}")
                        Continue For
                    End If
                    后台线程对象.ReportProgress(2, $"规划步骤总数：{任务队列.任务列表.Count}")

                    Select Case 操作类型
                        Case 操作类型.安装
                            For i2 = 0 To 任务队列.任务列表.Count - 1
                                Dim s2 As String = 任务队列.执行安装(i2)
                                If s2 <> "" Then
                                    后台线程对象.ReportProgress(3, $"{s2}")
                                    后台线程对象.ReportProgress(3, $"正在回滚操作")
                                    For i3 = i2 To 0 Step -1
                                        任务队列.执行卸载(i3)
                                    Next
                                    Exit For
                                End If
                            Next
                            后台线程对象.ReportProgress(50, i)
                        Case 操作类型.卸载
                            For i2 = 任务队列.任务列表.Count - 1 To 0 Step -1
                                Dim s2 As String = 任务队列.执行卸载(i2)
                                If 任务队列.是否取消了操作 Then Exit For
                                If s2 <> "" Then
                                    后台线程对象.ReportProgress(3, $"{s2}")
                                    后台线程对象.ReportProgress(3, $"卸载操作不能通过反向执行来回滚操作，这可能已经导致了预期外的问题")
                                    Exit For
                                End If
                            Next
                            后台线程对象.ReportProgress(50, i)
                        Case 操作类型.更新项_直接覆盖
                            后台线程对象.ReportProgress(2, $"规划数据已载入")

                            For i2 = 0 To 任务队列.任务列表.Count - 1
                                Select Case 任务队列.任务列表(i2).操作类型
                                    Case 公共对象.任务队列操作类型枚举.复制文件夹到Mods
                                        If FileIO.FileSystem.DirectoryExists(Path.Combine(设置.全局设置数据("StardewValleyGamePath"), "Mods", 任务队列.任务列表(i2).参数行)) Then
                                            后台线程对象.ReportProgress(1, $"已找到游戏内的 {任务队列.任务列表(i2).参数行} 文件夹，正在覆盖到数据库")
                                            FileIO.FileSystem.CopyDirectory(Path.Combine(设置.全局设置数据("StardewValleyGamePath"), "Mods", 任务队列.任务列表(i2).参数行), Path.Combine(模组项路径列表(i), 任务队列.任务列表(i2).参数行), True)
                                        Else
                                            后台线程对象.ReportProgress(1, $"未找到游戏内的 {任务队列.任务列表(i2).参数行} 文件夹，跳过")
                                        End If
                                End Select
                            Next
                        Case 操作类型.更新项_完全替换
                            后台线程对象.ReportProgress(2, $"规划数据已载入")
                            For i2 = 0 To 任务队列.任务列表.Count - 1
                                Select Case 任务队列.任务列表(i2).操作类型
                                    Case 公共对象.任务队列操作类型枚举.复制文件夹到Mods
                                        If FileIO.FileSystem.DirectoryExists(Path.Combine(设置.全局设置数据("StardewValleyGamePath"), "Mods", 任务队列.任务列表(i2).参数行)) Then
                                            后台线程对象.ReportProgress(1, $"已找到游戏内的 {任务队列.任务列表(i2).参数行} 文件夹")
                                            If FileIO.FileSystem.DirectoryExists(Path.Combine(模组项路径列表(i), 任务队列.任务列表(i2).参数行)) Then
                                                后台线程对象.ReportProgress(1, $"正在删除数据库内已有内容")
                                                FileIO.FileSystem.DeleteDirectory(Path.Combine(模组项路径列表(i), 任务队列.任务列表(i2).参数行), FileIO.DeleteDirectoryOption.DeleteAllContents)
                                                后台线程对象.ReportProgress(1, $"正在复制到数据库")
                                                FileIO.FileSystem.CopyDirectory(Path.Combine(设置.全局设置数据("StardewValleyGamePath"), "Mods", 任务队列.任务列表(i2).参数行), Path.Combine(模组项路径列表(i), 任务队列.任务列表(i2).参数行), True)
                                            Else
                                                后台线程对象.ReportProgress(1, $"数据库中不存在 {任务队列.任务列表(i2).参数行} 文件夹，为避免意外，跳过")
                                            End If
                                        Else
                                            后台线程对象.ReportProgress(1, $"未找到游戏内的 {任务队列.任务列表(i2).参数行} 文件夹，跳过")
                                        End If
                                End Select
                            Next
                    End Select
                Next
            End Sub

        AddHandler 后台线程对象.ProgressChanged,
            Sub(sender, e)
                Select Case e.ProgressPercentage
                    Case 1 '白色
                        DebugPrint($"{线程ID} {e.UserState}", Color1.白色)
                    Case 2 '蓝色
                        DebugPrint($"{线程ID} {e.UserState}", Color1.蓝色)
                    Case 3 '红色
                        DebugPrint($"{线程ID} {e.UserState}", Color1.红色, True)
                    Case 50
                        Dim i As Integer = e.UserState
                        If Form1.ListView2.Items(当前在模组项列表中的索引列表(i)).Text = Path.GetFileName(模组项路径列表(i)) Then
                            Dim x As New 项信息读取类
                            x.读取项信息(Path.Combine(管理模组2.检查并返回当前所选子库路径(False), Form1.ListView2.Items(当前在模组项列表中的索引列表(i)).SubItems(3).Text, Form1.ListView2.Items(当前在模组项列表中的索引列表(i)).Text), New 公共对象.项数据计算类型结构 With {.安装状态 = True}, 设置.全局设置数据("StardewValleyGamePath"))
                            If x.错误信息 = "" Then
                                Form1.ListView2.SelectedItems(i).SubItems(2).Text = 管理模组.安装状态显示词字典(x.安装状态)
                                管理模组.根据安装状态设置项的颜色标记(x.安装状态, Form1.ListView2.SelectedItems(i))
                            Else
                                DebugPrint($"{线程ID} 刷新项信息时故障：{x.错误信息}", Color1.红色)
                                Form1.ListView2.SelectedItems(i).SubItems(2).Text = "x.错误信息"
                                Form1.ListView2.SelectedItems(i).ForeColor = Color1.红色
                            End If
                        End If
                End Select
            End Sub

        AddHandler 后台线程对象.RunWorkerCompleted,
            Sub(sender, e)
                DebugPrint($"{线程ID} 线程结束", Color1.白色)
                正在工作的线程ID = ""
                模组项路径列表.Clear()
                当前在模组项列表中的索引列表.Clear()
                线程ID = ""
                任务队列.全部数据初始化()
                后台线程对象.Dispose()
            End Sub

        DebugPrint($"{线程ID} 后台线程启动", Color1.蓝色)
        后台线程对象.RunWorkerAsync()

    End Sub

End Class
