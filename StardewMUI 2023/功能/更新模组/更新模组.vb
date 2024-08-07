﻿Imports System.IO
Imports System.Text.RegularExpressions
Imports SMUI6.NEXUS.GetModFileList
Imports Windows.System

Public Class 更新模组

    Public Shared Sub 初始化()
        Form1.Panel37.Padding = New Padding(30)
        If 设置.全局设置数据("NexusPremium") = "True" Then
            Form1.UiRadioButton10.Checked = False
            Form1.UiRadioButton9.Checked = True
            Form1.TabPageNEXUS下载模式.Text = "NEXUS 下载模式：Premium"
        Else
            Form1.UiRadioButton10.Checked = True
            Form1.UiRadioButton9.Checked = False
            Form1.TabPageNEXUS下载模式.Text = "NEXUS 下载模式：FREE"
        End If
        AddHandler Form1.UiRadioButton10.Click, Sub()
                                                    设置.全局设置数据("NexusPremium") = "False"
                                                    Form1.TabPageNEXUS下载模式.Text = "NEXUS 下载模式：FREE"
                                                End Sub
        AddHandler Form1.UiRadioButton9.Click, Sub()
                                                   设置.全局设置数据("NexusPremium") = "True"
                                                   Form1.TabPageNEXUS下载模式.Text = "NEXUS 下载模式：Premium"
                                               End Sub

        If DLC.DLC解锁标记.UpdateModItemExtension Then
            AddHandler 全局键盘钩子.自定义全局键盘事件, Sub(e)
                                             If Form1.UiTabControl1.SelectedTab IsNot Form1.TabPage下载更新 Then Exit Sub
                                             If Form1.UiTabControlMenu3.SelectedTab IsNot Form1.TabPage选择要下载的文件 Then Exit Sub
                                             If DLC6全局快捷键要触发的下载项 Is Nothing Then Exit Sub
                                             If e = Keys.N Then DLC6全局快捷键要触发的下载项.PerformClick()
                                         End Sub
        End If

    End Sub

    Public Shared Property DLC6全局快捷键要触发的下载项 As Button = Nothing

    Public Shared Function 生成更新地址表菜单() As 暗黑菜单条控件本体
        Dim a As New 暗黑菜单条控件本体
        If Form1.ListView2.SelectedItems.Count <> 1 Then
            Return a
            Exit Function
        End If
        a.ImageScalingSize = New Size(25, 25)
        a.DropShadowEnabled = False
        a.ShowCheckMargin = False
        a.Font = Form1.Font

        For i = 0 To 管理模组.当前项信息_N网ID列表.Count - 1
            If Len(管理模组.当前项信息_N网ID列表(i)) <= 0 Then Continue For
            AddHandler a.Items.Add("NEXUS: " & 管理模组.当前项信息_N网ID列表(i), My.Resources.NEXUS).Click, Async Sub(s, e) Await Launcher.LaunchUriAsync(New Uri("https://www.nexusmods.com/stardewvalley/mods/" & Mid(s.Text, 8)))
            Dim s1 As String = 管理模组.当前项信息_N网ID列表(i)
            AddHandler a.Items.Add("复制链接").Click, Sub(s, e) Clipboard.SetText("https://www.nexusmods.com/stardewvalley/mods/" & s1)
            AddHandler a.Items.Add("从 NEXUS API 更新", My.Resources.NEXUS).Click, Sub(s, e) 获取NEXUS文件列表(s1, Path.Combine(管理模组2.检查并返回当前所选子库路径(False), Form1.ListView2.SelectedItems(0).SubItems(3).Text, Form1.ListView2.SelectedItems(0).Text), Form1.ListView2.SelectedItems(0).SubItems(1).Text.Split({" → ", " ← "}, StringSplitOptions.None)(0))
        Next
        If DLC.DLC解锁标记.CustomInputExtension Then
            If a.Items.Count <> 0 Then a.Items.Add(New ToolStripSeparator)
            AddHandler a.Items.Add("自由输入 NEXUS ID", My.Resources.NEXUS).Click, Sub(s, e)
                                                                                   Dim d1 As New 输入对话框("DLC1", "输入你要访问的 NEXUS 模组 ID")
                                                                                   d1.TranslateButtonText("确定", "取消")
                                                                                   Dim d1r As String = d1.ShowDialog(Form1)
                                                                                   If a.Items.Count <> 0 And 管理模组.当前项信息_ModDropID列表.Count > 0 Then a.Items.Add(New ToolStripSeparator)
                                                                                   If d1r <> "" Then 获取NEXUS文件列表(d1r, Path.Combine(管理模组2.检查并返回当前所选子库路径(False), Form1.ListView2.SelectedItems(0).SubItems(3).Text, Form1.ListView2.SelectedItems(0).Text))
                                                                               End Sub
        End If

        If a.Items.Count <> 0 And 管理模组.当前项信息_ModDropID列表.Count > 0 Then a.Items.Add(New ToolStripSeparator)
        For i = 0 To 管理模组.当前项信息_ModDropID列表.Count - 1
            AddHandler a.Items.Add("ModDrop: " & 管理模组.当前项信息_ModDropID列表(i), My.Resources.ModDrop_White32).Click, Async Sub(s, e) Await Launcher.LaunchUriAsync(New Uri("https://www.moddrop.com/stardew-valley/mods/" & Mid(s.Text, 10)))
            Dim s2 As String = 管理模组.当前项信息_ModDropID列表(i)
            AddHandler a.Items.Add("复制链接").Click, Sub(s, e) Clipboard.SetText("https://www.moddrop.com/stardew-valley/mods/" & s2)
            AddHandler a.Items.Add("从 ModDrop 更新", My.Resources.ModDrop_White32).Click, Sub(s, e) 转到浏览器等待ModDrop下载链接(s2, Path.Combine(管理模组2.检查并返回当前所选子库路径(False), Form1.ListView2.SelectedItems(0).SubItems(3).Text, Form1.ListView2.SelectedItems(0).Text))
        Next
        If DLC.DLC解锁标记.CustomInputExtension Then
            If a.Items.Count <> 0 Then a.Items.Add(New ToolStripSeparator)
            AddHandler a.Items.Add("自由输入 ModDrop ID", My.Resources.ModDrop_White32).Click, Sub(s, e)
                                                                                               Dim d1 As New 输入对话框("DLC1", "输入你要访问的 ModDrop 模组 ID")
                                                                                               d1.TranslateButtonText("确定", "取消")
                                                                                               Dim d1r As String = d1.ShowDialog(Form1)
                                                                                               If d1r <> "" Then 转到浏览器等待ModDrop下载链接(d1r, Path.Combine(管理模组2.检查并返回当前所选子库路径(False), Form1.ListView2.SelectedItems(0).SubItems(3).Text, Form1.ListView2.SelectedItems(0).Text))
                                                                                           End Sub
        End If

        If a.Items.Count <> 0 And 管理模组.当前项信息_Github仓库列表.Count > 0 Then a.Items.Add(New ToolStripSeparator)
        For i = 0 To 管理模组.当前项信息_Github仓库列表.Count - 1
            AddHandler a.Items.Add(管理模组.当前项信息_Github仓库列表(i), My.Resources.Github).Click, Async Sub(s, e) Await Launcher.LaunchUriAsync(New Uri("https://github.com/" & s.Text))
            Dim s2 As String = 管理模组.当前项信息_Github仓库列表(i)
            AddHandler a.Items.Add("复制链接").Click, Sub(s, e) Clipboard.SetText("https://github.com/" & s2)
            AddHandler a.Items.Add("从 GitHub 更新", My.Resources.Github).Click, Sub(s, e) 获取Github文件列表(s2, Path.Combine(管理模组2.检查并返回当前所选子库路径(False), Form1.ListView2.SelectedItems(0).SubItems(3).Text, Form1.ListView2.SelectedItems(0).Text))
        Next
        If DLC.DLC解锁标记.CustomInputExtension Then
            If a.Items.Count <> 0 Then a.Items.Add(New ToolStripSeparator)
            AddHandler a.Items.Add("自由输入 GitHub 仓库名", My.Resources.Github).Click, Sub(s, e)
                                                                                      Dim d1 As New 输入对话框("DLC1", "输入你要访问的 GitHub 仓库名，格式：用户名/仓库名")
                                                                                      d1.TranslateButtonText("确定", "取消")
                                                                                      Dim d1r As String = d1.ShowDialog(Form1)
                                                                                      If d1r <> "" Then 获取Github文件列表(d1r, Path.Combine(管理模组2.检查并返回当前所选子库路径(False), Form1.ListView2.SelectedItems(0).SubItems(3).Text, Form1.ListView2.SelectedItems(0).Text))
                                                                                  End Sub
        End If

        If a.Items.Count = 0 Then
            AddHandler a.Items.Add("没有可用的选项", My.Resources.模块).Click, Sub(s, e) Return
        End If

        Return a
    End Function


    Private Shared Sub 转到下载文件页面()
        Form1.UiTabControl1.SelectedTab = Form1.TabPage下载更新
        Form1.UiTabControlMenu3.SelectedTab = Form1.TabPage选择要下载的文件
    End Sub

    Public Shared Property 正在处理的NEXUSID As String
    Public Shared Property 选择的NEXUS文件ID As String
    Public Shared Property 是否取消操作 As Boolean = False


    Public Shared Async Sub 获取NEXUS文件列表(模组ID As String, 模组项绝对路径 As String, Optional 用于自动选择的旧版本号 As String = "", Optional 结束后切换到选项卡 As String = "")
        If 设置.全局设置数据("NexusAPI") = "" Then
            Dim d1 As New 多项单选对话框("", {"前往设置", "确定"}, "访问 NEXUS API 需要填写个人密钥")
            If d1.ShowDialog() = 0 Then
                Form1.UiTabControl1.SelectedTab = Form1.TabPage起始页面
                Form1.UiTabControlMenu1.SelectedTab = Form1.TabPage设置
                Form1.UiTabControlMenu2.SelectedTab = Form1.TabPage16
            End If
            Exit Sub
        End If
        转到下载文件页面()
        正在处理的NEXUSID = 模组ID
        是否取消操作 = False
        DLC6全局快捷键要触发的下载项 = Nothing
        Form1.Label34.Text = "   正在连接到 NEXUS API 获取文件列表 ..."
        Form1.Panel34.Controls.Clear()
        Form1.Panel34.Enabled = True
        Dim a As New NEXUS.GetModFileList With {.ST_ApiKey = 设置.全局设置数据("NexusAPI")}
        Dim str1 As String = Await Task.Run(Function() a.StartGet("stardewvalley", 模组ID, NEXUS.FileType.main_optional_updateFile_miscellaneous))
        Form1.Label34.Text = "   " & If(FileIO.FileSystem.FileExists(Path.Combine(模组项绝对路径, "Code2")), "更新到模组项：", "创建新模组项：") & Path.GetFileName(模组项绝对路径)
        If str1 <> "" Then
            Dim L1 As New Label With {.AutoSize = False, .Padding = New Padding(10), .Dock = DockStyle.Fill, .Text = str1}
            Form1.Panel34.Controls.Add(L1)
            Form1.Label34.Text = "   获取失败"
            Exit Sub
        End If

        Dim 自动判断最合适的 As Long = 0

        If DLC.DLC解锁标记.UpdateModItemExtension And 用于自动选择的旧版本号 <> "" Then
            If FileIO.FileSystem.FileExists(Path.Combine(模组项绝对路径, "NexusFileName")) Then
                Dim str2 = FileIO.FileSystem.ReadAllText(Path.Combine(模组项绝对路径, "NexusFileName"))
                Dim fa1 = NEXUS判断合适的文件标题.尝试判断(str2, 用于自动选择的旧版本号, a.FileListData)
                If fa1.HasValue Then 自动判断最合适的 = fa1.Value.file_id
            End If
        End If

        Dim 分类文字 As New Label With {.AutoSize = True, .Dock = DockStyle.Top, .Padding = New Padding(0, 0, 0, 10), .Font = New Font(Form1.Font.Name, 12), .ForeColor = Color1.青色, .AutoEllipsis = True, .Text = "主要文件"}
        Form1.Panel34.Controls.Add(分类文字)
        分类文字.BringToFront()
        For i = a.FileListData.Count - 1 To 0 Step -1
            If a.FileListData(i).category_name.Equals("main", StringComparison.CurrentCultureIgnoreCase) Then
                生成NEXUS单个文件信息(a.FileListData(i), 模组项绝对路径, a.FileListData(i).file_id = 自动判断最合适的, 结束后切换到选项卡)
            End If
        Next

        Dim 分类文字2 As New Label With {.AutoSize = True, .Dock = DockStyle.Top, .Padding = New Padding(0, 10, 0, 10), .Font = New Font(Form1.Font.Name, 12), .ForeColor = Color1.青色, .AutoEllipsis = True, .Text = "可选文件"}
        Form1.Panel34.Controls.Add(分类文字2)
        分类文字2.BringToFront()
        For i = a.FileListData.Count - 1 To 0 Step -1
            If a.FileListData(i).category_name.Equals("optional", StringComparison.CurrentCultureIgnoreCase) Then
                生成NEXUS单个文件信息(a.FileListData(i), 模组项绝对路径, a.FileListData(i).file_id = 自动判断最合适的, 结束后切换到选项卡)
            End If
        Next

        Dim 分类文字3 As New Label With {.AutoSize = True, .Dock = DockStyle.Top, .Padding = New Padding(0, 10, 0, 10), .Font = New Font(Form1.Font.Name, 12), .ForeColor = Color1.青色, .AutoEllipsis = True, .Text = "附加文件"}
        Form1.Panel34.Controls.Add(分类文字3)
        分类文字3.BringToFront()
        For i = a.FileListData.Count - 1 To 0 Step -1
            If a.FileListData(i).category_name.Equals("miscellaneous", StringComparison.CurrentCultureIgnoreCase) Then
                生成NEXUS单个文件信息(a.FileListData(i), 模组项绝对路径, a.FileListData(i).file_id = 自动判断最合适的, 结束后切换到选项卡)
            End If
        Next

        Dim 分类文字4 As New Label With {.AutoSize = True, .Dock = DockStyle.Top, .Padding = New Padding(0, 10, 0, 10), .Font = New Font(Form1.Font.Name, 12), .ForeColor = Color1.青色, .AutoEllipsis = True, .Text = "更新文件"}
        Form1.Panel34.Controls.Add(分类文字4)
        分类文字4.BringToFront()
        For i = a.FileListData.Count - 1 To 0 Step -1
            If a.FileListData(i).category_name.Equals("update", StringComparison.CurrentCultureIgnoreCase) Then
                生成NEXUS单个文件信息(a.FileListData(i), 模组项绝对路径, a.FileListData(i).file_id = 自动判断最合适的, 结束后切换到选项卡)
            End If
        Next
    End Sub


    Public Shared Sub 生成NEXUS单个文件信息(Data As FileListDataOne, 模组项绝对路径 As String, Optional 是自动判断最合适的 As Boolean = False, Optional 结束后切换到选项卡 As String = "")
        Dim 独立容器 As New Panel With {.Dock = DockStyle.Top, .Padding = New Padding(30, 10, 30, 7), .Height = 107 * 界面控制.DPI}
        Dim 标题文字 As New LinkLabel With {.AutoSize = False, .Dock = DockStyle.Top, .Height = 26 * 界面控制.DPI, .TextAlign = ContentAlignment.TopLeft, .Font = New Font(Form1.Font.Name, 12), .LinkColor = If(设置.全局设置数据("DownloadFileUseSMUI5Color") = True, Color1.绿色, Color1.蓝色), .LinkBehavior = LinkBehavior.HoverUnderline, .Text = Data.name}

        If DLC.DLC解锁标记.UpdateModItemExtension Then
            If 是自动判断最合适的 And DLC6全局快捷键要触发的下载项 Is Nothing Then
                独立容器.BackColor = ColorTranslator.FromWin32(RGB(48, 48, 48))
                DLC6全局快捷键要触发的下载项 = New Button
                AddHandler DLC6全局快捷键要触发的下载项.Click, Sub() 标题文字点击事件(Data.name, Data.file_id, 模组项绝对路径, 结束后切换到选项卡)
            End If
        End If

        Dim 状态文字 As New Label With {.AutoSize = False, .Dock = DockStyle.Top, .Height = 21 * 界面控制.DPI, .TextAlign = ContentAlignment.TopLeft, .Font = New Font(Form1.Font.Name, 10), .ForeColor = If(设置.全局设置数据("DownloadFileUseSMUI5Color") = True, Color1.橙色, Color1.绿色)}
        Dim 简介文字 As New Label With {.AutoSize = False, .Dock = DockStyle.Fill, .Font = New Font(Form1.Font.Name, 10), .TextAlign = ContentAlignment.TopLeft, .ForeColor = Color.Gray, .AutoEllipsis = True, .Text = Data.description.Replace("<br />", vbCrLf)}

        If Data.size_kb < 1024 Then
            状态文字.Text = "Ver " & Data.version & " | " & Data.size_kb & " KB | " & Data.uploaded_time & " | ID " & Data.file_id
        Else
            状态文字.Text = "Ver " & Data.version & " | " & Format(Data.size_kb / 1024, "0.0") & " MB | " & Data.uploaded_time & " | ID " & Data.file_id
        End If

        独立容器.Controls.Add(标题文字)
        独立容器.Controls.Add(状态文字)
        独立容器.Controls.Add(简介文字)
        状态文字.BringToFront()
        简介文字.BringToFront()
        Form1.Panel34.Controls.Add(独立容器)
        独立容器.BringToFront()
        AddHandler 标题文字.LinkClicked, Sub(sender, e) 标题文字点击事件(Data.name, Data.file_id, 模组项绝对路径, 结束后切换到选项卡)
    End Sub

    Public Shared Sub 标题文字点击事件(文件标题 As String, 文件ID As String, 模组项绝对路径 As String, Optional 结束后切换到选项卡 As String = "")
        FileIO.FileSystem.WriteAllText(Path.Combine(模组项绝对路径, "NexusFileName"), 文件标题, False)
        If 设置.全局设置数据("NexusPremium") = "False" Then
            转到浏览器获取额外参数(正在处理的NEXUSID, 文件ID, 模组项绝对路径, 结束后切换到选项卡)
        Else
            获取服务器列表(正在处理的NEXUSID, 文件ID, 模组项绝对路径,,, 结束后切换到选项卡)
        End If
    End Sub

    Public Shared Sub 转到浏览器获取额外参数(模组ID As String, 文件ID As String, 模组项绝对路径 As String, Optional 结束后切换到选项卡 As String = "")
        浏览器WebView2控制.是否要获取HTML来进行NEXUSAPI更新 = True
        浏览器同步数据.用于更新模组项的模组项绝对路径 = 模组项绝对路径
        浏览器同步数据.用于更新模组项的NEXUS模组ID = 模组ID
        浏览器同步数据.用于更新模组项的NEXUS文件ID = 文件ID
        浏览器同步数据.结束后切换到选项卡 = 结束后切换到选项卡
        Form1.UiButton70.Visible = True
        Form1.Label42.Visible = True
        Form1.Label42.ForeColor = Color1.橙色
        Form1.Label42.Text = "正在进行 NEXUS 非会员获取额外参数流程
请勿点击下载按钮！不要点下载！！！并确保打开的网页中是已登录状态
参数获取程序会一直运行，直到成功拿到参数或者手动点击右上角的取消"
        Form1.UiTextBox5.Text = "https://www.nexusmods.com/stardewvalley/mods/" & 模组ID & "?tab=files&file_id=" & 文件ID & "&nmm=1"
        If 界面控制.WebView2浏览器控件 Is Nothing Then
            浏览器WebView2控制.初始化浏览器控件()
        Else
            界面控制.WebView2浏览器控件.CoreWebView2.Navigate(Form1.UiTextBox5.Text)
        End If
        Form1.UiTabControl1.SelectedTab = Form1.TabPage浏览器

    End Sub

    Public Shared Async Sub 获取服务器列表(模组ID As String, 文件ID As String, 模组项绝对路径 As String, Optional key As String = "", Optional expires As String = "", Optional 结束后切换到选项卡 As String = "")
        Form1.Label34.Text = "   正在连接到 NEXUS API 获取服务器列表 ..."
        Form1.Panel34.Enabled = False
        Dim a As New NEXUS.GetModFileDownloadURL With {.ST_ApiKey = 设置.全局设置数据("NexusAPI")}
        Dim str1 As String = Await Task.Run(Function() a.StartGet("stardewvalley", 模组ID, 文件ID, key, expires))
        If str1 <> "" Then
            DebugPrint(str1, Color1.红色)
            Form1.Label34.Text = "   获取失败，到调试选项卡查看详情"
            Form1.Panel34.Enabled = True
            Exit Sub
        End If
        If a.name.Length = 0 Then
            Form1.Label34.Text = "   获取成功但 NEXUS API 没有返回任何可用的服务器"
            Form1.Panel34.Enabled = True
            Exit Sub
        End If
        Form1.Panel34.Enabled = True
        If 设置.全局设置数据("AutoSelectFirstNexusDownloadSever") = "True" Then
            添加到下载队列(a.URI(0), 模组项绝对路径, "nexus",, 结束后切换到选项卡)
        Else
            Dim m1 As New 多项单选对话框("选择要从哪个服务器下载文件", a.name, "如果你无法高速下载，请自行使用代理，记得添加域名规则：cf-files.nexusmods.com" & vbCrLf & vbCrLf & "可以在设置中打开自动选择首个，首位是什么取决于账户设置", 100, 500)
            Dim int1 = m1.ShowDialog(Form1)
            Select Case int1
                Case -1
                    Form1.Label34.Text = "   当前操作接下来要更新到项：" & Path.GetFileName(模组项绝对路径)
                Case Else
                    添加到下载队列(a.URI(int1), 模组项绝对路径, "nexus",, 结束后切换到选项卡)
            End Select
        End If
    End Sub

    Public Shared Async Function 获取服务器列表(模组ID As String, 文件ID As String, 模组项绝对路径 As String, 向哪一个标签控件输出状态 As Label, Optional key As String = "", Optional expires As String = "", Optional 结束后切换到选项卡 As String = "") As Task(Of Boolean)
        向哪一个标签控件输出状态.Text = "正在连接到 NEXUS API 获取服务器列表 ..."
        Dim a As New NEXUS.GetModFileDownloadURL With {.ST_ApiKey = 设置.全局设置数据("NexusAPI")}
        Dim str1 As String = Await Task.Run(Function() a.StartGet("stardewvalley", 模组ID, 文件ID, key, expires))
        If str1 <> "" Then
            DebugPrint(str1, Color1.红色)
            向哪一个标签控件输出状态.Text = "获取失败，到调试选项卡查看详情"
            Return False
        End If
        If a.name.Length = 0 Then
            向哪一个标签控件输出状态.Text = "获取成功但 NEXUS API 没有返回任何可用的服务器"
            Return False
        End If
        添加到下载队列(a.URI(0), 模组项绝对路径, "nexus",, 结束后切换到选项卡)
        Return True
    End Function

    Public Shared Sub 添加到下载队列(下载地址 As String, 模组项绝对路径 As String, Optional 来源 As String = "nexus", Optional 自定义文件名 As String = "", Optional 结束后切换到选项卡 As String = "")
        Form1.UiTabControl1.SelectedTab = Form1.TabPage下载更新
        Form1.UiTabControlMenu3.SelectedTab = Form1.TabPage下载和更新队列

        Dim DW As New 下载进度界面块控件本体 With {.设置_下载来源 = 来源, .设置_下载地址 = 下载地址, .设置_模组项绝对路径 = 模组项绝对路径, .设置_N网模组ID = 正在处理的NEXUSID, .设置_其他来源指定文件名 = 自定义文件名, .Dock = DockStyle.Top, .设置_结束后切换到选项卡 = 结束后切换到选项卡}
        Dim L1 As New Label With {.AutoSize = False, .Dock = DockStyle.Top, .Height = 20 * 界面控制.DPI}
        Form1.Panel37.Controls.Add(DW)
        DW.BringToFront()
        Form1.Panel37.Controls.Add(L1)
        L1.BringToFront()
        DW.设置_结束后自动释放的控件.Add(L1)
        DW.开始下载()

        Form1.Label34.Text = "   在管理模组选项卡中发起更新来获取文件列表"
        Form1.Panel34.Controls.Clear()
    End Sub

    Public Shared Sub 转到浏览器等待ModDrop下载链接(模组ID As String, 模组项绝对路径 As String, Optional 结束后切换到选项卡 As String = "")
        浏览器WebView2控制.是否要等待ModDrop发起下载文件 = True
        浏览器同步数据.用于更新模组项的模组项绝对路径 = 模组项绝对路径
        浏览器同步数据.用于更新模组项的NEXUS模组ID = 模组ID
        浏览器同步数据.结束后切换到选项卡 = 结束后切换到选项卡
        Form1.UiButton70.Visible = True
        Form1.Label42.Visible = True
        Form1.Label42.ForeColor = Color1.蓝色
        Form1.Label42.Text = "正在进行从 ModDrop 下载更新流程，下载操作由 Edge 浏览器处理
请在网页上发起下载并等待下载完成，然后把文件从浏览器下载 UI 拖到这个区域来继续下一步
此状态会一直保持，直到文件被拖入或者手动点击右上角的取消"
        Form1.UiTextBox5.Text = "https://www.moddrop.com/stardew-valley/mods/" & 模组ID
        If 界面控制.WebView2浏览器控件 Is Nothing Then
            浏览器WebView2控制.初始化浏览器控件()
        Else
            界面控制.WebView2浏览器控件.CoreWebView2.Navigate(Form1.UiTextBox5.Text)
        End If
        Form1.UiTabControl1.SelectedTab = Form1.TabPage浏览器
    End Sub

    Public Shared Sub 添加ModDrop解压环节到下载队列(模组项绝对路径 As String, 下载的文件 As String, Optional 结束后切换到选项卡 As String = "")
        Form1.UiTabControlMenu3.SelectedTab = Form1.TabPage下载和更新队列
        Dim DW As New 下载进度界面块控件本体 With {.设置_模组项绝对路径 = 模组项绝对路径, .保存位置 = 下载的文件, .Dock = DockStyle.Top, .设置_结束后切换到选项卡 = 结束后切换到选项卡}
        Dim L1 As New Label With {.AutoSize = False, .Dock = DockStyle.Top, .Height = 20 * 界面控制.DPI}
        Form1.Panel37.Controls.Add(DW)
        DW.BringToFront()
        Form1.Panel37.Controls.Add(L1)
        L1.BringToFront()
        DW.设置_结束后自动释放的控件.Add(L1)
        DW.开始下载()
    End Sub

    Public Shared Async Sub 获取Github文件列表(仓库作者和名称 As String, 模组项绝对路径 As String, Optional 结束后切换到选项卡 As String = "")
        转到下载文件页面()
        是否取消操作 = False
        Form1.Label34.Text = "   正在连接到 GitHub 获取发行版 ..."
        Form1.Panel34.Controls.Clear()
        Form1.Panel34.Enabled = True
        Dim a As New GitAPI.GitHubAllReleaseFile
        Dim str1 As String = Await Task.Run(Function() a.获取(仓库作者和名称))
        Form1.Label34.Text = "   " & If(FileIO.FileSystem.FileExists(Path.Combine(模组项绝对路径, "Code2")), "更新到模组项：", "创建新模组项：") & Path.GetFileName(模组项绝对路径)
        If str1 <> "" Then
            Dim L1 As New Label With {.AutoSize = False, .Padding = New Padding(10), .Dock = DockStyle.Fill, .Text = str1}
            Form1.Panel34.Controls.Add(L1)
            Form1.Label34.Text = "   获取失败"
            Exit Sub
        End If

        For i = 0 To a.发行版数据集合.Count - 1
            If i >= 10 Then Exit For
            Dim 标题文字 As New LinkLabel With {.AutoSize = False, .Dock = DockStyle.Top, .Height = 40 * 界面控制.DPI, .TextAlign = ContentAlignment.MiddleLeft, .Font = New Font(Form1.Font.Name, 12), .LinkColor = Form1.ForeColor, .LinkBehavior = LinkBehavior.HoverUnderline, .Text = a.发行版数据集合(i).标签 & " - " & a.发行版数据集合(i).标题, .BackColor = Color.DarkGreen, .Padding = New Padding(5, 0, 0, 0)}
            Dim ix = i
            AddHandler 标题文字.LinkClicked, Async Sub() Await Launcher.LaunchUriAsync(New Uri("https://github.com/" & 仓库作者和名称 & "/releases/tag/" & a.发行版数据集合(ix).标签))
            If a.发行版数据集合(i).是否是草稿 Then 标题文字.BackColor = ColorTranslator.FromWin32(RGB(48, 48, 48))
            If a.发行版数据集合(i).是否预览版 Then 标题文字.BackColor = Color.Sienna
            Form1.Panel34.Controls.Add(标题文字)
            标题文字.BringToFront()

            If a.发行版数据集合(i).描述 <> "" Then
                Dim 描述文字 As New Label With {.AutoSize = False, .Dock = DockStyle.Top, .Height = 100 * 界面控制.DPI, .AutoEllipsis = True, .TextAlign = ContentAlignment.TopLeft, .Padding = New Padding(0, 10, 0, 10), .Font = New Font(Form1.Font.Name, 10), .ForeColor = Color.Gray, .Text = a.发行版数据集合(i).描述.Replace("\r\n", vbCrLf)}
                Form1.Panel34.Controls.Add(描述文字)
                描述文字.BringToFront()
            End If

            For i2 = 0 To a.发行版数据集合(i).可供下载的文件.Count - 1
                Dim 发行版文件文字 As New LinkLabel With {.AutoSize = False, .Dock = DockStyle.Top, .Height = 35 * 界面控制.DPI, .TextAlign = ContentAlignment.TopLeft, .Font = New Font(Form1.Font.Name, 12), .LinkColor = If(设置.全局设置数据("DownloadFileUseSMUI5Color") = True, Color1.橙色, Color1.绿色), .LinkBehavior = LinkBehavior.HoverUnderline, .Text = a.发行版数据集合(i).可供下载的文件(i2).Key}
                Form1.Panel34.Controls.Add(发行版文件文字)
                发行版文件文字.BringToFront()
                Dim b As String = a.发行版数据集合(i).可供下载的文件(i2).Value
                AddHandler 发行版文件文字.LinkClicked, Sub(sender, e)
                                                    Form1.Panel34.Controls.Clear()
                                                    添加到下载队列(b, 模组项绝对路径, "github", 发行版文件文字.Text, 结束后切换到选项卡)
                                                End Sub
            Next

        Next
    End Sub

End Class
