Imports System.IO
Imports Sunny.UI
Imports Windows.System
Imports System.Text.Json

Public Class 模组检查更新管理器

    Public Shared Sub 初始化()
        Form1.UiComboBox10.SelectedIndex = 0
        AddHandler 管理模组的菜单.菜单项_加入整个分类到检查更新表.Click, AddressOf 添加选中分类包含的模组项到检查更新表
        AddHandler 管理模组的菜单.菜单项_加入检查更新表.Click, AddressOf 添加选中模组项到检查更新表
        AddHandler Form1.UiButton81.Click, Sub() Form1.ListView8.Items.Clear()
        AddHandler Form1.UiButton82.Click, AddressOf 移除选中_发送列表
        AddHandler Form1.UiButton83.Click, AddressOf 编辑更新键
        AddHandler Form1.UiButton84.Click, AddressOf 编辑版本
        AddHandler Form1.UiButton80.Click, AddressOf 发送并显示返回的数据
        AddHandler Form1.ListView11.SelectedIndexChanged, AddressOf 选中条目时显示信息
        AddHandler Form1.UiButton85.Click, AddressOf 打开建议更新版本地址
        AddHandler Form1.LinkLabel2.LinkClicked, AddressOf 打开NEXUS地址
        AddHandler Form1.LinkLabel3.LinkClicked, AddressOf 打开ModDrop地址
        AddHandler Form1.LinkLabel4.LinkClicked, AddressOf 打开gtihub地址
        AddHandler Form1.UiButton86.Click, AddressOf 显示选中项的原始数据
        AddHandler Form1.RichTextBox2.LinkClicked, Async Sub(sender, e) Await Launcher.LaunchUriAsync(New Uri(e.LinkText))
        AddHandler Form1.UiButton90.Click, AddressOf 清空并返回步骤一
        AddHandler Form1.UiButton89.Click, AddressOf 选中所有更新可用
        AddHandler Form1.UiButton88.Click, AddressOf 添加选中到步骤三
        AddHandler Form1.UiButton87.Click, AddressOf 添加全部到步骤三
        AddHandler Form1.UiButton94.Click, AddressOf 清空并返回步骤二
        AddHandler Form1.UiButton93.Click, AddressOf 移除步骤三选中条目
        AddHandler Form1.UiButton92.Click, AddressOf 扫描子库来找到项
        AddHandler 管理模组的菜单.菜单项_检查更新_通过NEXUS更新.Click, Sub() 发起更新("nexus")
        AddHandler 管理模组的菜单.菜单项_检查更新_通过ModDrop更新.Click, Sub() 发起更新("moddrop")
        AddHandler 管理模组的菜单.菜单项_检查更新_通过Gtihub更新.Click, Sub() 发起更新("github")
        AddHandler 管理模组的菜单.菜单项_检查更新_输入NEXUS更新.Click, Sub() 自由发起更新("nexus")
        AddHandler 管理模组的菜单.菜单项_检查更新_输入ModDrop更新.Click, Sub() 自由发起更新("moddrop")
        AddHandler 管理模组的菜单.菜单项_检查更新_输入Gtihub更新.Click, Sub() 自由发起更新("github")

        If DLC.DLC解锁标记.UpdateModItemExtension Then
            AddHandler Form1.ListView12.KeyDown, Sub(sender, e)
                                                     e.SuppressKeyPress = True
                                                     Select Case e.KeyCode
                                                         Case Keys.W, Keys.Up
                                                             If Form1.ListView12.SelectedItems.Count = 0 Then Exit Sub
                                                             Dim a = Form1.ListView12.SelectedIndices(0)
                                                             If a > 0 Then
                                                                 For Each item In Form1.ListView12.Items
                                                                     item.Selected = False
                                                                 Next
                                                                 Form1.ListView12.Items(a - 1).Selected = True
                                                                 Form1.ListView12.Items(a - 1).EnsureVisible()
                                                             End If
                                                         Case Keys.S, Keys.Down
                                                             If Form1.ListView12.SelectedItems.Count = 0 Then Exit Sub
                                                             Dim a = Form1.ListView12.SelectedIndices(0)
                                                             If a <> Form1.ListView12.Items.Count - 1 Then
                                                                 For Each item In Form1.ListView12.Items
                                                                     item.Selected = False
                                                                 Next
                                                                 Form1.ListView12.Items(a + 1).Selected = True
                                                                 Form1.ListView12.Items(a + 1).EnsureVisible()
                                                             End If
                                                         Case Keys.N
                                                             发起更新("nexus")
                                                         Case Keys.M
                                                             发起更新("moddrop")
                                                         Case Keys.G
                                                             发起更新("github")
                                                     End Select
                                                 End Sub
        End If


    End Sub


    Public Shared Sub 添加选中分类包含的模组项到检查更新表()
        If Form1.ListView1.SelectedItems.Count = 0 Then Exit Sub
        For i = 0 To Form1.ListView1.SelectedItems.Count - 1
            Dim 模组项列表 As New List(Of String)(共享方法.SearchFolderWithoutSub(Path.Combine(管理模组2.检查并返回当前所选子库路径(False), Form1.ListView1.SelectedItems(i).Text)))
            For i2 = 0 To 模组项列表.Count - 1
                Dim str1 As String = Path.Combine(管理模组2.检查并返回当前所选子库路径(False), Form1.ListView1.SelectedItems(i).Text, 模组项列表(i2))
                Dim a As New 项信息读取类
                a.读取项信息(str1, New 项信息读取类.项数据计算类型结构 With {.UniqueID = True, .版本 = True, .更新键 = True})
                For i3 = 0 To a.UniqueID.Count - 1
                    Form1.ListView8.Items.Add(a.UniqueID(i3))
                    Dim key As String = ""
                    If a.NexusID.FirstOrDefault <> "" Then
                        If key = "" Then
                            key = "nexus:" & a.NexusID.FirstOrDefault
                        Else
                            key &= "|nexus:" & a.NexusID.FirstOrDefault
                        End If
                    End If
                    If a.ModDrop.FirstOrDefault <> "" Then
                        If key = "" Then
                            key = "moddrop:" & a.ModDrop.FirstOrDefault
                        Else
                            key &= "|moddrop:" & a.ModDrop.FirstOrDefault
                        End If
                    End If
                    If a.GitHub.FirstOrDefault <> "" Then
                        If key = "" Then
                            key = "github:" & a.GitHub.FirstOrDefault
                        Else
                            key &= "|github:" & a.GitHub.FirstOrDefault
                        End If
                    End If
                    Form1.ListView8.Items(Form1.ListView8.Items.Count - 1).SubItems.Add(key)
                    Form1.ListView8.Items(Form1.ListView8.Items.Count - 1).SubItems.Add(a.版本.FirstOrDefault)
                Next
            Next
        Next
        UIMessageTip.Show("已添加到检查更新表中",, 2500)
    End Sub

    Public Shared Sub 添加选中模组项到检查更新表()
        If Form1.ListView2.SelectedItems.Count = 0 Then Exit Sub
        For i = 0 To Form1.ListView2.SelectedItems.Count - 1
            Dim str1 As String = Path.Combine(管理模组2.检查并返回当前所选子库路径(False), Form1.ListView2.SelectedItems(i).SubItems(3).Text, Form1.ListView2.SelectedItems(i).Text)
            Dim a As New 项信息读取类
            a.读取项信息(str1, New 项信息读取类.项数据计算类型结构 With {.UniqueID = True, .版本 = True, .更新键 = True})
            For i2 = 0 To a.UniqueID.Count - 1
                Form1.ListView8.Items.Add(a.UniqueID(i2))
                Dim key As String = ""
                If a.NexusID.FirstOrDefault <> "" Then
                    If key = "" Then
                        key = "nexus:" & a.NexusID.FirstOrDefault
                    Else
                        key &= "|nexus:" & a.NexusID.FirstOrDefault
                    End If
                End If
                If a.ModDrop.FirstOrDefault <> "" Then
                    If key = "" Then
                        key = "moddrop:" & a.ModDrop.FirstOrDefault
                    Else
                        key &= "|moddrop:" & a.ModDrop.FirstOrDefault
                    End If
                End If
                If a.GitHub.FirstOrDefault <> "" Then
                    If key = "" Then
                        key = "github:" & a.GitHub.FirstOrDefault
                    Else
                        key &= "|github:" & a.GitHub.FirstOrDefault
                    End If
                End If
                Form1.ListView8.Items(Form1.ListView8.Items.Count - 1).SubItems.Add(key)
                Form1.ListView8.Items(Form1.ListView8.Items.Count - 1).SubItems.Add(a.版本.FirstOrDefault)
            Next
        Next
        UIMessageTip.Show("已添加到检查更新表中",, 2500)
    End Sub

    Public Shared Sub 移除选中_发送列表()
        Dim i As Integer = 0
        Do Until i = Form1.ListView8.Items.Count
            If Form1.ListView8.Items(i).Selected Then
                Form1.ListView8.Items(i).Remove()
                i -= 1
            End If
            i += 1
        Loop
    End Sub

    Public Shared Sub 编辑更新键()
        If Form1.ListView8.SelectedItems.Count = 0 Then Exit Sub
        Dim a As New 输入对话框("", "选中多个条目即可批量编辑更新键，多个更新键用竖线隔开", Form1.ListView8.SelectedItems(0).SubItems(1).Text)
        a.TranslateButtonText("确定", "取消")
        Dim s = a.ShowDialog(Form1)
        If s = "" Then Exit Sub
        For i = 0 To Form1.ListView8.SelectedItems.Count - 1
            Form1.ListView8.SelectedItems(i).SubItems(1).Text = s
        Next
    End Sub

    Public Shared Sub 编辑版本()
        If Form1.ListView8.SelectedItems.Count = 0 Then Exit Sub
        Dim a As New 输入对话框("", "选中多个条目即可批量编辑版本号", Form1.ListView8.SelectedItems(0).SubItems(2).Text)
        a.TranslateButtonText("确定", "取消")
        Dim s = a.ShowDialog(Form1)
        If s = "" Then Exit Sub
        For i = 0 To Form1.ListView8.SelectedItems.Count - 1
            Form1.ListView8.SelectedItems(i).SubItems(2).Text = s
        Next
    End Sub

    Public Shared Property 获取到的数据 As New SMAPI云服务.用于接收的数据对象

    Public Shared Async Sub 发送并显示返回的数据()
        If Form1.ListView8.Items.Count = 0 Then Exit Sub
        获取到的数据 = New SMAPI云服务.用于接收的数据对象
        Dim a As New SMAPI云服务.用于发送的数据对象 With {
            .apiVersion = Form1.暗黑文本框11.Text,
            .gameVersion = Form1.暗黑文本框12.Text,
            .platform = Form1.UiComboBox10.Text,
            .includeExtendedMetadata = True,
            .mods = New List(Of SMAPI云服务.用于发送的数据对象.mod_single)
        }
        For i = 0 To Form1.ListView8.Items.Count - 1
            Dim b As New SMAPI云服务.用于发送的数据对象.mod_single With {
                .id = Form1.ListView8.Items(i).Text,
                .updatekeys = Form1.ListView8.Items(i).SubItems(1).Text.Split("|"c).ToList,
                .installedversion = Form1.ListView8.Items(i).SubItems(2).Text
            }
            a.mods.Add(b)
        Next
        Form1.UiButton80.Enabled = False
        UIMessageTip.Show("开始连接 SMAPI 服务器",, 2500)
        Dim x As New SMAPI云服务
        Dim s1 As String = Await x.发送并接收Async(a)
        If s1 <> "" Then
            DebugPrint(s1, Color1.红色)
            Dim m1 As New 多项单选对话框("", {"OK"}, s1, 100, 500)
            m1.ShowDialog(Form1)
            Form1.UiButton80.Enabled = True
            Exit Sub
        End If
        Form1.UiButton80.Enabled = True
        获取到的数据 = x.接收到并已转换的对象
        Form1.UiTabControl2.SelectedTab = Form1.TabPage26
        Form1.ListView11.Items.Clear()
        For i = 0 To 获取到的数据.Data.Count - 1
            Form1.ListView11.Items.Add(获取到的数据.Data(i).metadata.name)
            Form1.ListView11.Items(Form1.ListView11.Items.Count - 1).SubItems.Add(获取到的数据.Data(i).id)
            Form1.ListView11.Items(Form1.ListView11.Items.Count - 1).SubItems.Add(If(获取到的数据.Data(i).metadata.nexusID = 0, "-", 获取到的数据.Data(i).metadata.nexusID))
            If 获取到的数据.Data(i).suggestedUpdate.version = "" Then
                Form1.ListView11.Items(Form1.ListView11.Items.Count - 1).SubItems.Add("已是最新")
            Else
                Form1.ListView11.Items(Form1.ListView11.Items.Count - 1).SubItems.Add(获取到的数据.Data(i).suggestedUpdate.version)
                Form1.ListView11.Items(Form1.ListView11.Items.Count - 1).ForeColor = Color1.蓝色
            End If
            Form1.ListView11.Items(Form1.ListView11.Items.Count - 1).SubItems.Add(获取到的数据.Data(i).metadata.compatibilitySummary)
        Next
    End Sub

    Public Shared Sub 重置显示信息()
        Form1.LinkLabel2.Text = "NEXUS"
        Form1.LinkLabel3.Text = "ModDrop"
        Form1.LinkLabel4.Text = "GitHub"
        Form1.RichTextBox2.Clear()
    End Sub

    Public Shared Sub 选中条目时显示信息()
        If Form1.ListView11.SelectedItems.Count <> 1 Then
            重置显示信息()
            Exit Sub
        End If
        Form1.LinkLabel2.Text = If(获取到的数据.Data(Form1.ListView11.SelectedIndices(0)).metadata.nexusID = 0, "No NEXUS", "NEXUS：" & 获取到的数据.Data(Form1.ListView11.SelectedIndices(0)).metadata.nexusID)
        Form1.LinkLabel3.Text = If(获取到的数据.Data(Form1.ListView11.SelectedIndices(0)).metadata.modDropID = 0, "No ModDrop", "ModDrop：" & 获取到的数据.Data(Form1.ListView11.SelectedIndices(0)).metadata.modDropID)
        Form1.LinkLabel4.Text = If(获取到的数据.Data(Form1.ListView11.SelectedIndices(0)).metadata.gitHubRepo = "", "No GitHub", 获取到的数据.Data(Form1.ListView11.SelectedIndices(0)).metadata.gitHubRepo)
        Form1.RichTextBox2.Text = 获取到的数据.Data(Form1.ListView11.SelectedIndices(0)).metadata.compatibilitySummary
    End Sub

    Public Shared Async Sub 打开建议更新版本地址()
        If Form1.ListView11.SelectedItems.Count <> 1 Then Exit Sub
        If 获取到的数据.Data(Form1.ListView11.SelectedIndices(0)).suggestedUpdate.url <> "" Then
            Await Launcher.LaunchUriAsync(New Uri(获取到的数据.Data(Form1.ListView11.SelectedIndices(0)).suggestedUpdate.url))
        End If
    End Sub

    Public Shared Async Sub 打开NEXUS地址()
        If Form1.ListView11.SelectedItems.Count <> 1 Then Exit Sub
        If 获取到的数据.Data(Form1.ListView11.SelectedIndices(0)).metadata.nexusID <> 0 Then
            Await Launcher.LaunchUriAsync(New Uri("https://www.nexusmods.com/stardewvalley/mods/" & 获取到的数据.Data(Form1.ListView11.SelectedIndices(0)).metadata.nexusID))
        End If
    End Sub

    Public Shared Async Sub 打开ModDrop地址()
        If Form1.ListView11.SelectedItems.Count <> 1 Then Exit Sub
        If 获取到的数据.Data(Form1.ListView11.SelectedIndices(0)).metadata.modDropID <> 0 Then
            Await Launcher.LaunchUriAsync(New Uri("https://www.moddrop.com/stardew-valley/mods/" & 获取到的数据.Data(Form1.ListView11.SelectedIndices(0)).metadata.modDropID))
        End If
    End Sub

    Public Shared Async Sub 打开gtihub地址()
        If Form1.ListView11.SelectedItems.Count <> 1 Then Exit Sub
        If 获取到的数据.Data(Form1.ListView11.SelectedIndices(0)).metadata.gitHubRepo <> "" Then
            Await Launcher.LaunchUriAsync(New Uri("https://github.com/" & 获取到的数据.Data(Form1.ListView11.SelectedIndices(0)).metadata.gitHubRepo))
        End If
    End Sub

    Public Shared Sub 显示选中项的原始数据()
        If Form1.ListView11.SelectedItems.Count <> 1 Then Exit Sub
        Form1.RichTextBox2.Text = JsonSerializer.Serialize(获取到的数据.Data(Form1.ListView11.SelectedIndices(0)))
    End Sub

    Public Shared Sub 清空并返回步骤一()
        重置显示信息()
        Form1.ListView11.Items.Clear()
        Form1.UiTabControl2.SelectedTab = Form1.TabPage25
    End Sub

    Public Shared Sub 选中所有更新可用()
        For i = 0 To Form1.ListView11.Items.Count - 1
            If Form1.ListView11.Items(i).SubItems(3).Text <> "已是最新" Then
                Form1.ListView11.Items(i).Selected = True
            Else
                Form1.ListView11.Items(i).Selected = False
            End If
        Next
    End Sub

    Public Shared Sub 添加选中到步骤三()
        For i = 0 To Form1.ListView11.SelectedItems.Count - 1
            If Form1.ListView11.SelectedItems(i).SubItems(1).Text = "" Then Continue For
            Form1.ListView12.Items.Add(Form1.ListView11.SelectedItems(i).Text)
            Form1.ListView12.Items(Form1.ListView12.Items.Count - 1).SubItems.Add(获取到的数据.Data(Form1.ListView11.SelectedIndices(i)).id)
            Dim key As String = ""
            If 获取到的数据.Data(Form1.ListView11.SelectedIndices(i)).metadata.nexusID <> 0 Then
                If key = "" Then
                    key = "nexus:" & 获取到的数据.Data(Form1.ListView11.SelectedIndices(i)).metadata.nexusID
                Else
                    key &= "|nexus:" & 获取到的数据.Data(Form1.ListView11.SelectedIndices(i)).metadata.nexusID
                End If
            End If
            If 获取到的数据.Data(Form1.ListView11.SelectedIndices(i)).metadata.modDropID <> 0 Then
                If key = "" Then
                    key = "moddrop:" & 获取到的数据.Data(Form1.ListView11.SelectedIndices(i)).metadata.modDropID
                Else
                    key &= "|moddrop:" & 获取到的数据.Data(Form1.ListView11.SelectedIndices(i)).metadata.modDropID
                End If
            End If
            If 获取到的数据.Data(Form1.ListView11.SelectedIndices(i)).metadata.gitHubRepo <> "" Then
                If key = "" Then
                    key = "github:" & 获取到的数据.Data(Form1.ListView11.SelectedIndices(i)).metadata.gitHubRepo
                Else
                    key &= "|github:" & 获取到的数据.Data(Form1.ListView11.SelectedIndices(i)).metadata.gitHubRepo
                End If
            End If
            Form1.ListView12.Items(Form1.ListView12.Items.Count - 1).SubItems.Add(key)
            Form1.ListView12.Items(Form1.ListView12.Items.Count - 1).SubItems.Add("")
            Form1.ListView12.Items(Form1.ListView12.Items.Count - 1).SubItems.Add("")
        Next
        UIMessageTip.Show("已添加",, 2500)
        If Not DLC.DLC解锁标记.CheckUpdatesExtension Then
            UIMessageTip.Show("DLC 4 未解锁，每次启动只能使用一次添加到步骤三",, 3000)
            Form1.UiButton87.Enabled = False
            Form1.UiButton88.Enabled = False
        End If
    End Sub

    Public Shared Sub 添加全部到步骤三()
        For i = 0 To Form1.ListView11.Items.Count - 1
            If Form1.ListView11.Items(i).SubItems(1).Text = "" Then Continue For
            Form1.ListView12.Items.Add(Form1.ListView11.Items(i).Text)
            Form1.ListView12.Items(Form1.ListView12.Items.Count - 1).SubItems.Add(获取到的数据.Data(i).id)
            Dim key As String = ""
            If 获取到的数据.Data(i).metadata.nexusID <> 0 Then
                If key = "" Then
                    key = "nexus:" & 获取到的数据.Data(i).metadata.nexusID
                Else
                    key &= "|nexus:" & 获取到的数据.Data(i).metadata.nexusID
                End If
            End If
            If 获取到的数据.Data(i).metadata.modDropID <> 0 Then
                If key = "" Then
                    key = "moddrop:" & 获取到的数据.Data(i).metadata.modDropID
                Else
                    key &= "|moddrop:" & 获取到的数据.Data(i).metadata.modDropID
                End If
            End If
            If 获取到的数据.Data(i).metadata.gitHubRepo <> "" Then
                If key = "" Then
                    key = "github:" & 获取到的数据.Data(i).metadata.gitHubRepo
                Else
                    key &= "|github:" & 获取到的数据.Data(i).metadata.gitHubRepo
                End If
            End If
            Form1.ListView12.Items(Form1.ListView12.Items.Count - 1).SubItems.Add(key)
            Form1.ListView12.Items(Form1.ListView12.Items.Count - 1).SubItems.Add("")
            Form1.ListView12.Items(Form1.ListView12.Items.Count - 1).SubItems.Add("")
        Next
        UIMessageTip.Show("已添加",, 2500)
        If Not DLC.DLC解锁标记.CheckUpdatesExtension Then
            UIMessageTip.Show("DLC 4 未解锁，每次启动只能使用一次添加到步骤三",, 3000)
            Form1.UiButton87.Enabled = False
            Form1.UiButton88.Enabled = False
        End If
    End Sub

    Public Shared Sub 清空并返回步骤二()
        Form1.ListView12.Items.Clear()
        Form1.UiTabControl2.SelectedTab = Form1.TabPage26
    End Sub

    Public Shared Sub 移除步骤三选中条目()
        Dim i As Integer = 0
        Do Until i = Form1.ListView12.Items.Count
            If Form1.ListView12.Items(i).Selected Then
                Form1.ListView12.Items(i).Remove()
                i -= 1
            End If
            i += 1
        Loop
    End Sub

    Public Shared Sub 扫描子库来找到项()
        If Form1.ListView12.Items.Count = 0 Then Exit Sub
        Try
            Form1.UiButton92.Enabled = False
            For i = 0 To Form1.ListView12.Items.Count - 1
                Form1.ListView12.Items(i).SubItems(3).Text = ""
                Form1.ListView12.Items(i).SubItems(4).Text = ""
            Next
            Dim mDir As DirectoryInfo
            Dim mDirInfo As New DirectoryInfo(管理模组2.检查并返回当前所选子库路径(False))
            For Each mDir In mDirInfo.GetDirectories
                Dim mDir2 As IO.DirectoryInfo
                Dim mDirInfo2 As New IO.DirectoryInfo(mDir.FullName)
                For Each mDir2 In mDirInfo2.GetDirectories
                    Dim a As New 项信息读取类
                    a.读取项信息(mDir2.FullName, New 项信息读取类.项数据计算类型结构 With {.UniqueID = True})
                    If a.UniqueID.Count = 0 Then Continue For
                    For Each item As ListViewItem In Form1.ListView12.Items
                        If a.UniqueID.Contains(item.SubItems(1).Text) Then
                            If item.SubItems(3).Text <> "" Or item.SubItems(4).Text <> "" Then
                                item.ForeColor = Color1.橙色
                                Exit For
                            End If
                            item.SubItems(3).Text = Path.GetFileName(Path.GetDirectoryName(mDir2.FullName))
                            item.SubItems(4).Text = Path.GetFileName(mDir2.FullName)
                            item.ForeColor = Color1.白色
                            Exit For
                        End If
                    Next
                Next
            Next
            For Each item As ListViewItem In Form1.ListView12.Items
                If item.SubItems(3).Text = "" Or item.SubItems(4).Text = "" Then
                    item.ForeColor = Color1.黄色
                End If
            Next
            Form1.UiButton92.Enabled = True
        Catch ex As Exception
            DebugPrint(ex.Message, Color1.红色)
            UIMessageTip.Show(ex.Message,, 2500)
            Form1.UiButton92.Enabled = True
        End Try
    End Sub

    Public Shared Sub 发起更新(更新平台 As String)
        If Form1.ListView12.SelectedItems.Count <> 1 Then Exit Sub
        If Form1.ListView12.SelectedItems(0).SubItems(2).Text = "" Then Exit Sub
        If Form1.ListView12.SelectedItems(0).SubItems(3).Text = "" Then Exit Sub
        If Form1.ListView12.SelectedItems(0).SubItems(4).Text = "" Then Exit Sub
        Dim 更新键列表 As New List(Of String)(Form1.ListView12.SelectedItems(0).SubItems(2).Text.Split("|"c).ToList)
        Dim 获取到的更新键 As String = ""
        For i = 0 To 更新键列表.Count - 1
            Select Case 更新平台
                Case "nexus"
                    If 更新键列表(i).Contains("nexus") Then
                        获取到的更新键 = 更新键列表(i).Replace("nexus:", "").Trim
                        Exit For
                    End If
                Case "moddrop"
                    If 更新键列表(i).Contains("moddrop") Then
                        获取到的更新键 = 更新键列表(i).Replace("moddrop:", "").Trim
                        Exit For
                    End If
                Case "github"
                    If 更新键列表(i).Contains("github") Then
                        获取到的更新键 = 更新键列表(i).Replace("github:", "").Trim
                        Exit For
                    End If
            End Select
        Next
        If 获取到的更新键 = "" Then Exit Sub
        Select Case 更新平台
            Case "nexus"
                Dim a As New 项信息读取类
                Dim str = Path.Combine(管理模组2.检查并返回当前所选子库路径(False), Form1.ListView12.SelectedItems(0).SubItems(3).Text, Form1.ListView12.SelectedItems(0).SubItems(4).Text)
                a.读取项信息(str, New 项信息读取类.项数据计算类型结构 With {.版本 = True})
                更新模组.获取NEXUS文件列表(获取到的更新键, str, a.版本.FirstOrDefault, "checkupdate")
            Case "moddrop"
                更新模组.转到浏览器等待ModDrop下载链接(获取到的更新键, Path.Combine(管理模组2.检查并返回当前所选子库路径(False), Form1.ListView12.SelectedItems(0).SubItems(3).Text, Form1.ListView12.SelectedItems(0).SubItems(4).Text), "checkupdate")
            Case "github"
                更新模组.获取Github文件列表(获取到的更新键, Path.Combine(管理模组2.检查并返回当前所选子库路径(False), Form1.ListView12.SelectedItems(0).SubItems(3).Text, Form1.ListView12.SelectedItems(0).SubItems(4).Text), "checkupdate")
        End Select
    End Sub

    Public Shared Sub 自由发起更新(更新平台 As String)
        If Form1.ListView12.SelectedItems.Count <> 1 Then Exit Sub
        If Form1.ListView12.SelectedItems(0).SubItems(3).Text = "" Then Exit Sub
        If Form1.ListView12.SelectedItems(0).SubItems(4).Text = "" Then Exit Sub
        Select Case 更新平台
            Case "nexus"
                Dim a As New 输入对话框("DLC 1", "输入要访问的 NEXUS ID")
                Dim b = a.ShowDialog(Form1)
                If b = "" Then Exit Sub

                Dim a1 As New 项信息读取类
                Dim str = Path.Combine(管理模组2.检查并返回当前所选子库路径(False), Form1.ListView12.SelectedItems(0).SubItems(3).Text, Form1.ListView12.SelectedItems(0).SubItems(4).Text)

                a1.读取项信息(str, New 项信息读取类.项数据计算类型结构 With {.版本 = True})

                更新模组.获取NEXUS文件列表(b, str, a1.版本.FirstOrDefault, "checkupdate")

            Case "moddrop"
                Dim a As New 输入对话框("DLC 1", "输入要访问的 ModDrop ID")
                Dim b = a.ShowDialog(Form1)
                If b = "" Then Exit Sub
                更新模组.转到浏览器等待ModDrop下载链接(b, Path.Combine(管理模组2.检查并返回当前所选子库路径(False), Form1.ListView12.SelectedItems(0).SubItems(3).Text, Form1.ListView12.SelectedItems(0).SubItems(4).Text), "checkupdate")
            Case "github"
                Dim a As New 输入对话框("DLC 1", "输入要访问的 GitHub 信息")
                Dim b = a.ShowDialog(Form1)
                If b = "" Then Exit Sub
                更新模组.获取Github文件列表(b, Path.Combine(管理模组2.检查并返回当前所选子库路径(False), Form1.ListView12.SelectedItems(0).SubItems(3).Text, Form1.ListView12.SelectedItems(0).SubItems(4).Text), "checkupdate")
        End Select
    End Sub


End Class
