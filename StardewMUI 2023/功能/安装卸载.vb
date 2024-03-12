Imports System.IO

Public Class 安装卸载


    Enum 操作类型
        安装 = 1
        卸载 = 2
    End Enum

    Public Shared Sub 执行安装或卸载模组(操作类型 As 操作类型)
        If Form1.ListView2.SelectedItems.Count = 0 Then Exit Sub
        If 任务队列.项路径 <> "" Then Exit Sub
        Dim 模组项路径列表 As New List(Of String)
        Dim 当前在模组项列表中的索引列表 As New List(Of Integer)
        For i = 0 To Form1.ListView2.SelectedItems.Count - 1
            模组项路径列表.Add(Path.Combine(管理模组2.检查并返回当前所选子库路径(False), Form1.ListView2.SelectedItems(i).SubItems(3).Text, Form1.ListView2.SelectedItems(i).Text))
            当前在模组项列表中的索引列表.Add(Form1.ListView2.SelectedItems(i).Index)
        Next
        Dim 线程ID As String = Now.Second & Now.Millisecond
        DebugPrint($"{线程ID} 已将所选的 {Form1.ListView2.SelectedItems.Count} 个项中的 {模组项路径列表.Count} 个项载入任务列表", Color1.蓝色)

        Dim a As New ComponentModel.BackgroundWorker With {.WorkerReportsProgress = True}
        AddHandler a.DoWork,
            Sub(sender, e)

                For i = 0 To 模组项路径列表.Count - 1
                    DebugPrint($"{线程ID} 开始安装：{IO.Path.GetFileName(模组项路径列表(i))}", Color1.蓝色)
                    任务队列.全部数据初始化()
                    任务队列.项路径 = 模组项路径列表(i)
                    任务队列.加载安装规划数据()
                    Select Case 操作类型
                        Case 操作类型.安装
                            For i2 = 0 To 任务队列.任务列表.Count - 1
                                任务队列.执行安装(i2)
                            Next
                        Case 操作类型.卸载
                            For i2 = 任务队列.任务列表.Count - 1 To 0 Step -1
                                任务队列.执行卸载(i2)
                            Next
                    End Select
                Next

            End Sub

        AddHandler a.ProgressChanged,
            Sub(s, e)
                Select Case e.ProgressPercentage
                    Case 1 '白色
                        DebugPrint($"{线程ID} {e.UserState}", Color1.白色)
                    Case 2 '蓝色
                        DebugPrint($"{线程ID} {e.UserState}", Color1.蓝色)
                    Case 3 '红色
                        DebugPrint($"{线程ID} {e.UserState}", Color1.红色)
                    Case 50
                        Dim i As Integer = e.UserState
                        If Form1.ListView2.Items(当前在模组项列表中的索引列表(i)).Text = 模组项路径列表(i) Then
                            Dim x As New 项信息读取类
                            x.读取项信息(Path.Combine(管理模组2.检查并返回当前所选子库路径(False), Form1.ListView2.SelectedItems(i).SubItems(3).Text, Form1.ListView2.SelectedItems(i).Text), New 公共对象.项数据计算类型结构 With {.安装状态 = True}, 设置.全局设置数据("StardewValleyGamePath"))
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

        DebugPrint($"{线程ID} 后台线程启动", Color1.蓝色)
        a.RunWorkerAsync()

    End Sub

End Class
