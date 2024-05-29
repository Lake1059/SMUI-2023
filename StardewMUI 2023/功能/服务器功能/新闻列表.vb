
Public Class 新闻列表

    Public Shared Property 列表数据 As New List(Of KeyValuePair(Of String, String))

    Public Shared Sub 显示新闻列表()
        Form1.Panel35.Controls.Clear()
        GC.Collect(1, GCCollectionMode.Forced, False, True)

        For i = 0 To 列表数据.Count - 1
            Dim c1 As New Label With {.AutoSize = False, .Dock = DockStyle.Top, .Height = 30 * 界面控制.DPI, .TextAlign = ContentAlignment.MiddleLeft, .Padding = New Padding(5, 0, 0, 0), .Text = 列表数据(i).Key, .Tag = i}
            AddHandler c1.MouseEnter, Sub(sender, e) sender.BackColor = ColorTranslator.FromWin32(RGB(56, 56, 56))
            AddHandler c1.MouseDown, Sub(sender, e) sender.BackColor = ColorTranslator.FromWin32(RGB(64, 64, 64))
            AddHandler c1.MouseLeave, Sub(sender, e) sender.BackColor = Color.Transparent
            AddHandler c1.Click, Sub(sender, e)
                                     Select Case 列表数据(sender.Tag).Value.Split("|")(0)
                                         Case "msgbox"
                                             Dim c As New 多项单选对话框("新闻公告", {"OK"}, 列表数据(sender.Tag).Value.Split("|")(1).Replace("{vbCrLf}", vbCrLf), 200, 500)
                                             c.ShowDialog(Form1)
                                         Case "link"
                                             ShellExecute(IntPtr.Zero, "open", 列表数据(sender.Tag).Value.Split("|")(1), Nothing, Nothing, 1)
                                     End Select
                                 End Sub
            If 列表数据(i).Value.Split("|").Length >= 3 Then
                Select Case 列表数据(i).Value.Split("|")(2)
                    Case "red"
                        c1.ForeColor = Color1.红色
                    Case "orange"
                        c1.ForeColor = Color1.橙色
                    Case "yellow"
                        c1.ForeColor = Color1.黄色
                    Case "green"
                        c1.ForeColor = Color1.绿色
                    Case "blue"
                        c1.ForeColor = Color1.蓝色
                    Case "aqua"
                        c1.ForeColor = Color1.青色
                    Case "purple"
                        c1.ForeColor = Color1.紫色
                End Select
            End If

            Form1.Panel35.Controls.Add(c1)
            c1.BringToFront()
        Next
    End Sub

    Public Shared Sub 获取新闻(Optional 强制重新获取 As Boolean = False)
        If 设置.全局设置数据("AgreementSigned") = "False" Then Exit Sub
        If My.Computer.Network.IsAvailable = False Then
            DebugPrint("操作系统返回网络不可用，取消获取新闻", Form1.ForeColor)
            Exit Sub
        End If
        DebugPrint("检查新闻设置", Form1.ForeColor)
        If 强制重新获取 Then GoTo jx1
        If 设置.全局设置数据("SaveNewsInTodayUse") = "True" And 设置.全局设置数据("DateOfGetNews") = Now.Year & Now.Month & Now.Day Then
            If FileIO.FileSystem.FileExists(设置.当日新闻列表文件路径) Then
                DebugPrint("读取本地新闻文件", Form1.ForeColor)
                键值对IO操作.读取键值对文件到列表(列表数据, 设置.当日新闻列表文件路径)
                显示新闻列表()
                Exit Sub
            End If
        End If
jx1:
        DebugPrint("开始联网获取新闻", Form1.ForeColor)
        Dim 服务器获取_新闻 As New ComponentModel.BackgroundWorker
        AddHandler 服务器获取_新闻.DoWork,
            Sub(sender As Object, e As ComponentModel.DoWorkEventArgs)
                Dim a As New GitAPI.TextFileString
                Dim x1 As String = ""
                Select Case 设置.全局设置数据("NewsLanguage")
                    Case "简体中文"
                        x1 = "news_Chinese.ini"
                    Case Else
                        x1 = "news_English.ini"
                End Select
                Select Case 设置.全局设置数据("NewsSever")
                    Case "Gitee"
                        a.获取文本文件数据(GitAPI.GitApiObject.开源代码平台.Gitee, "Lake1059/SMUI-2023", "master", x1, 设置.全局设置数据("GiteeToken"), False)
                    Case Else
                        a.获取文本文件数据(GitAPI.GitApiObject.开源代码平台.GitHub, "Lake1059/SMUI-2023", "master", x1, 设置.全局设置数据("GithubToken"), False)
                End Select

                If a.ErrorString <> "" Then
                    e.Result = a.ErrorString
                    Exit Sub
                Else
                    e.Result = ""
                End If
                列表数据.Clear()
                键值对IO操作.读取键值对文本到列表(列表数据, a.网页返回字符串)
            End Sub
        AddHandler 服务器获取_新闻.RunWorkerCompleted,
            Sub(sender As Object, e As ComponentModel.RunWorkerCompletedEventArgs)
                If e.Result = "" Then
                    DebugPrint("成功获取新闻列表", Form1.ForeColor)
                    显示新闻列表()
                    设置.全局设置数据("DateOfGetNews") = Now.Year & Now.Month & Now.Day
                    If 设置.全局设置数据("SaveNewsInTodayUse") = "True" Then
                        键值对IO操作.从列表键值对写入文件(列表数据, 设置.当日新闻列表文件路径)
                    End If
                Else
                    DebugPrint($"获取新闻失败：{e.Result}", Color.OrangeRed)
                End If
            End Sub
        服务器获取_新闻.RunWorkerAsync()

    End Sub

End Class
