Imports System.Net.Http
Imports SMUI6.DLC
Imports System.IO
Imports ImageMagick
Imports Sunny.UI

Public Class 在线模组列表
    Public Shared Sub 初始化()
        初始化模组分类数组()
        Form1.UiComboBox6.SelectedIndex = 0
        AddHandler Form1.UiButton96.Click, Sub()
                                               Form1.Panel40.Controls.Clear()
                                               GC.Collect()
                                               GC.WaitForPendingFinalizers()
                                           End Sub
        AddHandler Form1.UiButton97.Click, Sub()
                                               Select Case Form1.UiComboBox6.SelectedIndex
                                                   Case 0
                                                       获取模组列表并显示(Form1.Panel40, NEXUS.ListModType.TheLatest10ModsReleased)
                                                   Case 1
                                                       获取模组列表并显示(Form1.Panel40, NEXUS.ListModType.TheLatest10ModsUpdated)
                                                   Case 2
                                                       获取模组列表并显示(Form1.Panel40, NEXUS.ListModType.The10EveryTimeHotMods)
                                               End Select
                                           End Sub
    End Sub

    Public Shared Property 模组分类数组 As New Dictionary(Of Integer, String)

    Public Shared Sub 初始化模组分类数组()
        模组分类数组(12) = "Audio"
        模组分类数组(17) = "Buildings"
        模组分类数组(5) = "Characters"
        模组分类数组(24) = "New Characters"
        模组分类数组(11) = "Cheats"
        模组分类数组(13) = "Clothing"
        模组分类数组(22) = "Crafting"
        模组分类数组(14) = "Crops"
        模组分类数组(20) = "Dialogue"
        模组分类数组(18) = "Events"
        模组分类数组(27) = "Expansions"
        模组分类数组(26) = "Fishing"
        模组分类数组(23) = "Furniture"
        模组分类数组(3) = "Gameplay Mechanics"
        模组分类数组(19) = "Interiors"
        模组分类数组(15) = "Items"
        模组分类数组(7) = "Livestock and Animals"
        模组分类数组(16) = "Locations"
        模组分类数组(21) = "Maps"
        模组分类数组(2) = "Miscellaneous"
        模组分类数组(9) = "Modding Tools"
        模组分类数组(8) = "Pets / Horses"
        模组分类数组(4) = "Player"
        模组分类数组(6) = "Portraits"
        模组分类数组(10) = "User Interface"
        模组分类数组(25) = "Visuals and Graphics"
    End Sub

    Public Shared Async Function 下载图片(url As String) As Task(Of Stream)
        Using client As New HttpClient()
            Dim response As HttpResponseMessage = Await client.GetAsync(url)
            response.EnsureSuccessStatusCode()
            Dim stream As Stream = Await response.Content.ReadAsStreamAsync()
            Return stream
        End Using
    End Function

    Public Shared Async Sub 获取模组列表并显示(基于面板 As Panel, 类型 As NEXUS.ListModType)
        基于面板.Controls.Clear()
        GC.Collect()

        Form1.UiButton97.Enabled = False

        Dim a As New NEXUS.GetModList With {
            .ST_ApiKey = 设置.全局设置数据("NexusAPI")
        }
        If Await Task.Run(Function() a.StartGet("stardewvalley", 类型)) <> "" Then
            MsgBox(a.ErrorString, MsgBoxStyle.Critical)
            Exit Sub
        End If

        'Me.Label8.Text = a.当前小时剩余可请求次数 & "/" & a.当前小时可请求次数总量 & "   " & a.今日剩余可请求次数 & "/" & a.今日可请求次数总量 & "   "
        For i = 0 To a.name.Length - 1
            Dim 独立容器 As New Panel With {.Dock = DockStyle.Top, .Padding = New Padding(10), .Height = 127 * 界面控制.DPI + 20 * 界面控制.DPI}

            Dim 图片框 As New PictureBox With {.SizeMode = PictureBoxSizeMode.Zoom, .Width = 224 * 界面控制.DPI, .Dock = DockStyle.Left, .BorderStyle = BorderStyle.FixedSingle}
            Dim 标题文字 As New LinkLabel With {.AutoSize = False, .Dock = DockStyle.Top, .Height = 25 * 界面控制.DPI, .Font = New Font(Form1.Font.Name, 12), .LinkColor = ColorTranslator.FromWin32(RGB(225, 225, 225)), .LinkBehavior = LinkBehavior.HoverUnderline, .TabStop = False}
            Dim 作者文字 As New LinkLabel With {.AutoSize = False, .Dock = DockStyle.Top, .Height = 20 * 界面控制.DPI, .Font = New Font(Form1.Font.Name, 9.75), .TextAlign = ContentAlignment.TopLeft, .LinkColor = Color.Silver, .LinkBehavior = LinkBehavior.HoverUnderline, .TabStop = False}
            Dim 状态文字 As New Label With {.AutoSize = False, .Dock = DockStyle.Top, .Height = 20 * 界面控制.DPI, .TextAlign = ContentAlignment.MiddleLeft, .Font = New Font(Form1.Font.Name, 9.75, FontStyle.Bold), .ForeColor = ColorTranslator.FromWin32(RGB(218, 142, 53))}
            Dim 简介文字 As New Label With {.AutoSize = False, .Dock = DockStyle.Fill, .Font = New Font(Form1.Font.Name, 9.75), .TextAlign = ContentAlignment.BottomLeft, .ForeColor = Color.Gray, .AutoEllipsis = True}

            DebugPrint(a.picture_url(i), Color1.白色)
            If a.picture_url(i).StartsWith("http") Then
                Dim webp数据 As Stream = Await 下载图片(a.picture_url(i))
                If webp数据 IsNot Nothing Then
                    Using images As New MagickImageCollection(webp数据)
                        If images.Count = 1 Then
                            Using ms As New MemoryStream()
                                images(0).Write(ms, MagickFormat.Png)
                                图片框.Image = Image.FromStream(ms)
                            End Using
                        Else
                            Using ms As New MemoryStream()
                                images(0).Write(ms, MagickFormat.Gif)
                                图片框.Image = Image.FromStream(ms)
                            End Using
                        End If
                    End Using
                End If
            End If


            Select Case a.status(i)
                Case "not_published"
                    标题文字.Text = "未发布"
                Case "removed"
                    标题文字.Text = "已被移除"
                Case "hidden"
                    标题文字.Text = "已被隐藏"
                Case "published"
                    标题文字.Text = a.name(i)
                Case Else
                    标题文字.Text = a.status(i)
            End Select
            作者文字.Text = a.author(i) & " (" & a.uploaded_by(i) & ")"
            状态文字.Text = "Ver " & a.version(i) & " | " & a.updated_time(i) & " | ID " & a.mod_id(i) & " | E " & a.endorsement_count(i)
            If a.category_id(i) <> 0 Then 状态文字.Text &= " | " & 模组分类数组(a.category_id(i))
            简介文字.Text = a.summary(i).Replace("<br />", vbCrLf)

            Dim 分隔间距 As New Label With {.AutoSize = False, .Dock = DockStyle.Left, .Width = 5}
            独立容器.Controls.Add(图片框)
            独立容器.Controls.Add(分隔间距)
            独立容器.Controls.Add(标题文字)
            独立容器.Controls.Add(作者文字)
            独立容器.Controls.Add(状态文字)
            独立容器.Controls.Add(简介文字)

            Dim str1 As String = "https://www.nexusmods.com/stardewvalley/mods/" & a.mod_id(i)
            AddHandler 标题文字.LinkClicked,
                Sub(s1, e1)
                    Process.Start(str1)
                End Sub
            Dim str2 As String = a.uploaded_users_profile_url(i)
            AddHandler 作者文字.LinkClicked,
                Sub(s1, e1)
                    Process.Start(str2)
                End Sub

            分隔间距.SendToBack()
            图片框.SendToBack()
            作者文字.BringToFront()
            状态文字.BringToFront()
            简介文字.BringToFront()
            基于面板.Controls.Add(独立容器)
            独立容器.BringToFront()

            If DLC解锁标记.NewItemExtension = True Then
                If a.status(i) = "not_published" Or a.status(i) = "removed" Or a.status(i) = "hidden" Then Continue For
                Dim 直接创建按钮 As New UIButton With {.Text = "+", .Font = New Font(Form1.Font.Name, 18), .Style = UIStyle.Purple}
                独立容器.Controls.Add(直接创建按钮)
                直接创建按钮.BringToFront()
                直接创建按钮.Height = 35 * 界面控制.DPI
                直接创建按钮.Width = 40 * 界面控制.DPI
                直接创建按钮.Top = 标题文字.Top
                直接创建按钮.Left = 独立容器.Width - 直接创建按钮.Width - 直接创建按钮.Top
                直接创建按钮.Anchor = AnchorStyles.Right
                Dim strtit1 As String = a.name(i)
                Dim strid1 As String = a.mod_id(i)
                AddHandler 直接创建按钮.Click,
                    Sub(s1, e1)
                        Form下载并新建项.上一次填写的模组项名称 = strtit1
                        Form下载并新建项.暗黑文本框2.Text = strid1
                        显示模式窗体(Form下载并新建项, Form1)
                    End Sub
            End If
        Next
        Dim c1 As New Label With {.AutoSize = False, .Dock = DockStyle.Top, .Height = 5}
        基于面板.Controls.Add(c1)
        c1.BringToFront()

        Form1.UiButton97.Enabled = True

    End Sub




End Class
