Imports System.IO
Imports SMUI6.NEXUS.GetModFileList
Imports Windows.System

Public Class 更新模组

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
            AddHandler a.Items.Add("从 NEXUS API 更新", My.Resources.NEXUS).Click, Sub(s, e) 获取NEXUS文件列表(s1, Path.Combine(管理模组2.检查并返回当前所选子库路径(False), Form1.ListView2.SelectedItems(0).SubItems(3).Text, Form1.ListView2.SelectedItems(0).Text))
        Next
        If DLC.DLC解锁标记.CustomInputExtension Then
            If a.Items.Count <> 0 Then a.Items.Add(New ToolStripSeparator)
            AddHandler a.Items.Add("自由输入 NEXUS ID", My.Resources.NEXUS).Click, Sub(s, e)
                                                                                   Dim d1 As New 输入对话框("DLC1", "输入你要访问的 NEXUS 模组 ID")
                                                                                   d1.TranslateButtonText("确定", "取消")
                                                                                   Dim d1r As String = d1.ShowDialog(Form1)
                                                                                   If d1r <> "" Then 获取NEXUS文件列表(d1r, Path.Combine(管理模组2.检查并返回当前所选子库路径(False), Form1.ListView2.SelectedItems(0).SubItems(3).Text, Form1.ListView2.SelectedItems(0).Text))
                                                                               End Sub
        End If

        If a.Items.Count <> 0 And 管理模组.当前项信息_ModDropID列表.Count > 0 Then a.Items.Add(New ToolStripSeparator)
        For i = 0 To 管理模组.当前项信息_ModDropID列表.Count - 1
            AddHandler a.Items.Add("ModDrop: " & 管理模组.当前项信息_ModDropID列表(i), My.Resources.ModDrop_White32).Click, Async Sub(s, e) Await Launcher.LaunchUriAsync(New Uri("https://www.moddrop.com/stardew-valley/mods/" & Mid(s.Text, 10)))
            Dim s2 As String = 管理模组.当前项信息_ModDropID列表(i)
            AddHandler a.Items.Add("复制链接").Click, Sub(s, e) Clipboard.SetText("https://www.moddrop.com/stardew-valley/mods/" & s2)
            AddHandler a.Items.Add("从 ModDrop 更新", My.Resources.ModDrop_White32).Click, Sub(s, e) Return
        Next
        If DLC.DLC解锁标记.CustomInputExtension Then
            If a.Items.Count <> 0 Then a.Items.Add(New ToolStripSeparator)
            AddHandler a.Items.Add("自由输入 ModDrop ID", My.Resources.ModDrop_White32).Click, Sub(s, e) Return
        End If

        If a.Items.Count <> 0 And 管理模组.当前项信息_Github仓库列表.Count > 0 Then a.Items.Add(New ToolStripSeparator)
        For i = 0 To 管理模组.当前项信息_Github仓库列表.Count - 1
            AddHandler a.Items.Add(管理模组.当前项信息_Github仓库列表(i), My.Resources.Github).Click, Async Sub(s, e) Await Launcher.LaunchUriAsync(New Uri("https://github.com/" & s.Text))
            Dim s2 As String = 管理模组.当前项信息_Github仓库列表(i)
            AddHandler a.Items.Add("复制链接").Click, Sub(s, e) Clipboard.SetText("https://github.com/" & s2)
            AddHandler a.Items.Add("从 GitHub 更新", My.Resources.Github).Click, Sub(s, e) Return
        Next
        If DLC.DLC解锁标记.CustomInputExtension Then
            If a.Items.Count <> 0 Then a.Items.Add(New ToolStripSeparator)
            AddHandler a.Items.Add("自由输入 GitHub 仓库名", My.Resources.Github).Click, Sub(s, e) Return
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


    Public Shared Async Sub 获取NEXUS文件列表(模组ID As String, 模组项绝对路径 As String)
        If 设置.全局设置数据("NexusAPI") = "" Then
            Dim d1 As New 多项单选对话框("", {"前往设置", "确定"}, "要访问 NEXUS API 进行更新模组，需要填写个人密钥")
            If d1.ShowDialog() = 0 Then
                Form1.UiTabControl1.SelectedTab = Form1.TabPage起始页面
                Form1.UiTabControlMenu1.SelectedTab = Form1.TabPage设置
                Form1.UiTabControlMenu2.SelectedTab = Form1.TabPage16
            End If
            Exit Sub
        End If
        转到下载文件页面()
        Form1.Label34.Text = "   正在连接到 NEXUS API 获取文件列表 ..."
        Form1.Panel34.Controls.Clear()
        Dim a As New NEXUS.GetModFileList With {.ST_ApiKey = 设置.全局设置数据("NexusAPI")}
        Dim str1 As String = Await Task.Run(Function() a.StartGet("stardewvalley", 模组ID, NEXUS.FileType.main_optional_updateFile_miscellaneous))
        Form1.Label34.Text = "   当前操作接下来要更新到项：" & Path.GetFileName(模组项绝对路径)
        If str1 <> "" Then
            Dim L1 As New Label With {.AutoSize = False, .Padding = New Padding(10), .Dock = DockStyle.Fill, .Text = str1}
            Form1.Panel34.Controls.Add(L1)
            Form1.Label34.Text = "   获取失败"
            Exit Sub
        End If

        For i = a.FileListData.Count - 1 To 0 Step -1
            If a.FileListData(i).category_name.Equals("main", StringComparison.CurrentCultureIgnoreCase) Then
                生成单个文件信息(a.FileListData(i))
            End If
        Next
        For i = a.FileListData.Count - 1 To 0 Step -1
            If a.FileListData(i).category_name.Equals("optional", StringComparison.CurrentCultureIgnoreCase) Then
                生成单个文件信息(a.FileListData(i))
            End If
        Next
        For i = a.FileListData.Count - 1 To 0 Step -1
            If a.FileListData(i).category_name.Equals("miscellaneous", StringComparison.CurrentCultureIgnoreCase) Then
                生成单个文件信息(a.FileListData(i))
            End If
        Next
        For i = a.FileListData.Count - 1 To 0 Step -1
            If a.FileListData(i).category_name.Equals("updateFile", StringComparison.CurrentCultureIgnoreCase) Then
                生成单个文件信息(a.FileListData(i))
            End If
        Next


    End Sub

    Public Shared Sub 生成单个文件信息(Data As FileListDataOne)
        Dim 独立容器 As New Panel With {.Dock = DockStyle.Top, .Padding = New Padding(30, 5, 30, 5), .Height = 100}
        Dim 标题文字 As New LinkLabel With {.AutoSize = False, .Dock = DockStyle.Top, .Height = 26, .TextAlign = ContentAlignment.TopLeft, .Font = New Font(Form1.Font.Name, 12), .LinkColor = Color1.蓝色, .LinkBehavior = LinkBehavior.HoverUnderline, .Text = Data.name}
        Select Case Data.category_name.ToLower.Trim
            Case "main"
                标题文字.Text = "主要文件：" & 标题文字.Text
            Case "optional"
                标题文字.Text = "可选文件：" & 标题文字.Text
            Case "miscellaneous"
                标题文字.Text = "附加文件：" & 标题文字.Text
            Case "updateFile"
                标题文字.Text = "更新文件：" & 标题文字.Text
        End Select
        Dim 状态文字 As New Label With {.AutoSize = False, .Dock = DockStyle.Top, .Height = 21, .TextAlign = ContentAlignment.TopLeft, .Font = New Font(Form1.Font.Name, 10), .ForeColor = Color1.绿色}
        Dim 简介文字 As New Label With {.AutoSize = False, .Dock = DockStyle.Fill, .Font = New Font(Form1.Font.Name, 10), .TextAlign = ContentAlignment.TopLeft, .ForeColor = Color.Gray, .AutoEllipsis = True, .Text = Data.description.Replace("<br/>", vbCrLf)}

        If Data.size_kb < 1024 Then
            状态文字.Text = "Ver " & Data.version & " | " & Data.size_kb & " KB | " & Data.uploaded_time & " | ID " & Data.file_id
        Else
            状态文字.Text = "Ver " & Data.version & " | " & Format(Data.size_kb / 1024, "0.0") & " MB | " & Data.uploaded_time & " | ID " & Data.file_id
        End If

        'Dim 分隔间距 As New Label With {.AutoSize = False, .Dock = DockStyle.Left, .Width = 5}
        '独立容器.Controls.Add(分隔间距)
        独立容器.Controls.Add(标题文字)
        独立容器.Controls.Add(状态文字)
        独立容器.Controls.Add(简介文字)
        '分隔间距.SendToBack()
        状态文字.BringToFront()
        简介文字.BringToFront()
        Form1.Panel34.Controls.Add(独立容器)
        独立容器.BringToFront()
        AddHandler 标题文字.LinkClicked, Sub(sender, e) Return




    End Sub







End Class
