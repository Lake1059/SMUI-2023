Imports System.IO
Imports Windows.System

Public Class 内容中心

    Public Shared Sub 初始化()
        内容中心主菜单.Items.Add(菜单项_游戏文件夹菜单)
        内容中心主菜单.Items.Add(菜单项_链接菜单)
        内容中心主菜单.Items.Add(New ToolStripSeparator)
        内容中心主菜单.Items.Add(菜单项_打开软件安装目录)
        内容中心主菜单.Items.Add(菜单项_打开用户数据文件夹)
        内容中心主菜单.Items.Add(菜单项_打开DLC文件夹)
        内容中心主菜单.Items.Add(菜单项_打开插件文件夹)

        菜单项_游戏文件夹菜单.DropDown = 游戏文件夹菜单
        游戏文件夹菜单.Items.Add(菜单项_游戏文件夹)
        游戏文件夹菜单.Items.Add(菜单项_游戏Mods文件夹)
        游戏文件夹菜单.Items.Add(菜单项_游戏存档文件夹)
        游戏文件夹菜单.Items.Add(菜单项_SMAPI日志文件夹)

        菜单项_链接菜单.DropDown = 链接菜单
        链接菜单.Items.Add(菜单项_SMAPI官网)
        链接菜单.Items.Add(菜单项_SMAPI模组兼容表)
        链接菜单.Items.Add(菜单项_SMAPI日志分析器)
        链接菜单.Items.Add(New ToolStripSeparator)
        链接菜单.Items.Add(菜单项_星露谷官方维基)
        链接菜单.Items.Add(菜单项_星露谷官方社区)
        链接菜单.Items.Add(New ToolStripSeparator)
        链接菜单.Items.Add(菜单项_星露谷NEXUS)
        链接菜单.Items.Add(菜单项_星露谷ModDrop)
        链接菜单.Items.Add(New ToolStripSeparator)
        链接菜单.Items.Add(菜单项_农场布局规划器)
        链接菜单.Items.Add(菜单项_存档预测器)
        链接菜单.Items.Add(菜单项_存档进度检测器)

        AddHandler Form1.UiButton36.MouseDown, Sub(sender, e) 内容中心主菜单.Show(sender, New Point(0, sender.height))
        AddHandler Form1.UiButton44.MouseDown, Sub(sender, e) 内容中心主菜单.Show(sender, New Point(sender.Width - 内容中心主菜单.Width, sender.height))

        AddHandler 菜单项_打开软件安装目录.Click, Sub() Process.Start("explorer.exe", Application.StartupPath)
        AddHandler 菜单项_打开用户数据文件夹.Click, Sub() Process.Start("explorer.exe", 设置.用户数据文件夹路径)
        AddHandler 菜单项_打开DLC文件夹.Click, Sub() Process.Start("explorer.exe", 设置.DLC文件夹路径)
        AddHandler 菜单项_打开插件文件夹.Click, Sub() Process.Start("explorer.exe", 设置.插件文件夹路径)

        AddHandler 菜单项_游戏文件夹.Click, Sub() Process.Start("explorer.exe", 设置.全局设置数据("StardewValleyGamePath"))
        AddHandler 菜单项_游戏Mods文件夹.Click, Sub() Process.Start("explorer.exe", Path.Combine(设置.全局设置数据("StardewValleyGamePath"), "Mods"))
        AddHandler 菜单项_游戏存档文件夹.Click, Sub()
                                          Dim wsh As New IWshRuntimeLibrary.IWshShell_Class
                                          Process.Start("explorer.exe", wsh.SpecialFolders.Item("AppData") & "\StardewValley\Saves")
                                      End Sub
        AddHandler 菜单项_SMAPI日志文件夹.Click, Sub()
                                             Dim wsh As New IWshRuntimeLibrary.IWshShell_Class
                                             Process.Start("explorer.exe", wsh.SpecialFolders.Item("AppData") & "\StardewValley\ErrorLogs")
                                         End Sub

        AddHandler 菜单项_SMAPI官网.Click, Async Sub() Await Launcher.LaunchUriAsync(New Uri("https://smapi.io"))
        AddHandler 菜单项_SMAPI模组兼容表.Click, Async Sub() Await Launcher.LaunchUriAsync(New Uri("https://smapi.io/mods"))
        AddHandler 菜单项_SMAPI日志分析器.Click, Async Sub() Await Launcher.LaunchUriAsync(New Uri("https://smapi.io/log"))
        AddHandler 菜单项_星露谷官方维基.Click, Async Sub() Await Launcher.LaunchUriAsync(New Uri("https://stardewvalleywiki.com"))
        AddHandler 菜单项_星露谷官方社区.Click, Async Sub() Await Launcher.LaunchUriAsync(New Uri("https://forums.stardewvalley.net"))
        AddHandler 菜单项_星露谷NEXUS.Click, Async Sub() Await Launcher.LaunchUriAsync(New Uri("https://www.nexusmods.com/stardewvalley"))
        AddHandler 菜单项_星露谷ModDrop.Click, Async Sub() Await Launcher.LaunchUriAsync(New Uri("https://www.moddrop.com/stardew-valley"))
        AddHandler 菜单项_农场布局规划器.Click, Async Sub() Await Launcher.LaunchUriAsync(New Uri("https://stardew.info/"))
        AddHandler 菜单项_存档预测器.Click, Async Sub() Await Launcher.LaunchUriAsync(New Uri("https://mouseypounds.github.io/stardew-predictor"))
        AddHandler 菜单项_存档进度检测器.Click, Async Sub() Await Launcher.LaunchUriAsync(New Uri("https://mouseypounds.github.io/stardew-checkup"))
    End Sub


    Public Shared Property 内容中心主菜单 As New 暗黑菜单条控件本体 With {.ImageScalingSize = New Size(25 * 界面控制.DPI, 25 * 界面控制.DPI)}
    Public Shared Property 菜单项_打开软件安装目录 As New ToolStripMenuItem With {.Text = "打开安装目录", .Image = My.Resources.代码文件夹}
    Public Shared Property 菜单项_打开用户数据文件夹 As New ToolStripMenuItem With {.Text = "打开用户数据文件夹", .Image = My.Resources.代码文件夹}
    Public Shared Property 菜单项_打开DLC文件夹 As New ToolStripMenuItem With {.Text = "打开 DLC 文件夹", .Image = My.Resources.代码文件夹}
    Public Shared Property 菜单项_打开插件文件夹 As New ToolStripMenuItem With {.Text = "打开插件文件夹", .Image = My.Resources.代码文件夹}
    Public Shared Property 菜单项_游戏文件夹菜单 As New ToolStripMenuItem With {.Text = "游戏文件夹集", .Image = My.Resources.Stardew_Valley}
    Public Shared Property 菜单项_链接菜单 As New ToolStripMenuItem With {.Text = "链接菜单集"}



    Public Shared Property 游戏文件夹菜单 As New 暗黑菜单条控件本体 With {.ImageScalingSize = New Size(25 * 界面控制.DPI, 25 * 界面控制.DPI)}
    Public Shared Property 菜单项_游戏文件夹 As New ToolStripMenuItem With {.Text = "游戏文件夹", .Image = My.Resources.文件夹}
    Public Shared Property 菜单项_游戏Mods文件夹 As New ToolStripMenuItem With {.Text = "游戏 Mods 文件夹", .Image = My.Resources.文件夹}
    Public Shared Property 菜单项_游戏存档文件夹 As New ToolStripMenuItem With {.Text = "游戏存档文件夹", .Image = My.Resources.文件夹}
    Public Shared Property 菜单项_SMAPI日志文件夹 As New ToolStripMenuItem With {.Text = "SMAPI 日志文件夹", .Image = My.Resources.文件夹}


    Public Shared Property 链接菜单 As New 暗黑菜单条控件本体 With {.ImageScalingSize = New Size(25 * 界面控制.DPI, 25 * 界面控制.DPI)}
    Public Shared Property 菜单项_SMAPI官网 As New ToolStripMenuItem With {.Text = "SMAPI 官网", .Image = My.Resources.SMAPI}
    Public Shared Property 菜单项_SMAPI模组兼容表 As New ToolStripMenuItem With {.Text = "SMAPI 模组兼容表", .Image = My.Resources.SMAPI}
    Public Shared Property 菜单项_SMAPI日志分析器 As New ToolStripMenuItem With {.Text = "SMAPI 日志分析器", .Image = My.Resources.SMAPI}
    Public Shared Property 菜单项_星露谷官方维基 As New ToolStripMenuItem With {.Text = "星露谷官方维基", .Image = My.Resources.Stardew_Valley}
    Public Shared Property 菜单项_星露谷官方社区 As New ToolStripMenuItem With {.Text = "星露谷官方社区", .Image = My.Resources.Stardew_Valley}
    Public Shared Property 菜单项_星露谷NEXUS As New ToolStripMenuItem With {.Text = "星露谷 NEXUS", .Image = My.Resources.NEXUS}
    Public Shared Property 菜单项_星露谷ModDrop As New ToolStripMenuItem With {.Text = "星露谷 ModDrop", .Image = My.Resources.ModDrop_White32}

    Public Shared Property 菜单项_农场布局规划器 As New ToolStripMenuItem With {.Text = "农场布局规划器"}
    Public Shared Property 菜单项_存档预测器 As New ToolStripMenuItem With {.Text = "存档预测器"}
    Public Shared Property 菜单项_存档进度检测器 As New ToolStripMenuItem With {.Text = "存档进度检测器"}


    Public Shared Sub 设置字体()
        内容中心主菜单.Font = New Font(设置.全局设置数据("FontName"), Form1.Font.Size)
        游戏文件夹菜单.Font = New Font(设置.全局设置数据("FontName"), Form1.Font.Size)
        链接菜单.Font = New Font(设置.全局设置数据("FontName"), Form1.Font.Size)
    End Sub

    Public Shared Sub 调整DPI()
        内容中心主菜单.ImageScalingSize = New Size(25 * 界面控制.DPI, 25 * 界面控制.DPI)
        游戏文件夹菜单.ImageScalingSize = New Size(25 * 界面控制.DPI, 25 * 界面控制.DPI)
        链接菜单.ImageScalingSize = New Size(25 * 界面控制.DPI, 25 * 界面控制.DPI)
    End Sub




End Class
