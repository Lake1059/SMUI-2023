
Imports System.Drawing.Text
Imports System.IO
Imports System.Reflection
Imports System.Text
Imports System.Xml
Imports Sunny.UI
Imports Windows.System

Public Class 设置

    Public Shared Property 全局设置数据 As New Dictionary(Of String, String)

    Public Shared Sub 初始化设置相关操作()
        AddHandler Form1.UiTabControlMenu2.SelectedIndexChanged,
           Sub(sender, e)
               If Form1.UiTabControlMenu2.SelectedTab Is Form1.TabPage19 Then
                   If Form1.UiComboBox8.Items.Count < 2 Then
                       Dim installedFonts As New InstalledFontCollection()
                       Dim fontsArray() As FontFamily = installedFonts.Families
                       For Each font As FontFamily In fontsArray
                           Form1.UiComboBox8.Items.Add(font.Name)
                       Next
                   End If
               End If
           End Sub
        AddHandler Form1.UiComboBox8.SelectedIndexChanged,
            Sub(sender, e)
                Form1.Label5.Font = New Font(Form1.UiComboBox8.Text, Form1.Label5.Font.Size)
                Form1.Label27.Font = New Font(Form1.UiComboBox8.Text, Form1.Label27.Font.Size)
                Form1.Label29.Font = New Font(Form1.UiComboBox8.Text, Form1.Label29.Font.Size)
                Form1.Label28.Font = New Font(Form1.UiComboBox8.Text, Form1.Label28.Font.Size)
                Form1.Label31.Font = New Font(Form1.UiComboBox8.Text, Form1.Label31.Font.Size)
                Form1.Label30.Font = New Font(Form1.UiComboBox8.Text, Form1.Label30.Font.Size)
            End Sub
        AddHandler Form1.UiButton34.Click, AddressOf 保存路径设置
        AddHandler Form1.UiButton28.Click, AddressOf 保存语言和服务器设置
        AddHandler Form1.UiButton32.Click, AddressOf 保存网络API设置
        AddHandler Form1.UiButton31.Click, AddressOf 保存启动项设置
        AddHandler Form1.UiButton35.Click, AddressOf 保存数值和开关设置
        AddHandler Form1.UiButton37.Click, AddressOf 保存字体设置
        AddHandler Form1.UiButton38.Click, AddressOf 保存隐私设置
        AddHandler Form1.UiButton25.Click, AddressOf 选择游戏文件夹路径
        AddHandler Form1.UiButton26.Click, AddressOf 选择数据库路径
        AddHandler Form1.UiButton27.Click, AddressOf 选择游戏备份路径
        AddHandler Form1.UiButton29.Click, AddressOf 选择VSC路径
        AddHandler Form1.UiButton30.Click, AddressOf 选择VS路径

        AddHandler Form1.UiButton33.Click, AddressOf 检测NEXUS密钥是否可用
        AddHandler Form1.UiButton39.Click, AddressOf 切换密钥密文显示
        AddHandler Form1.UiButton58.Click, Async Sub(s, e) Await Launcher.LaunchUriAsync(New Uri("https://www.nexusmods.com/users/myaccount?tab=api"))
        AddHandler Form1.UiButton59.Click, AddressOf 去内置浏览器管理密钥
        AddHandler Form1.UiButton55.Click, AddressOf 让非N网会员去内置浏览器登录
        AddHandler Form1.UiButton56.Click, Async Sub(s, e) Await Launcher.LaunchUriAsync(New Uri("https://gitee.com/profile/personal_access_tokens"))
        AddHandler Form1.UiButton57.Click, Async Sub(s, e) Await Launcher.LaunchUriAsync(New Uri("https://github.com/settings/tokens"))

        AddHandler Form1.UiButton60.Click, AddressOf 清理空间.刷新存储信息
        AddHandler Form1.UiButton62.Click, AddressOf 清理空间.清理选中项
        AddHandler Form1.UiButton67.Click, AddressOf 清理空间.计算模组数据库总数据大小


        AddHandler Form1.UiSwitch2.ActiveChanged, AddressOf 控制进程监控功能开关
        AddHandler Form1.UiSwitch3.ActiveChanged, AddressOf 控制性能监控功能开关

        AddHandler Form1.UiButton72.Click, Async Sub(s, e) Await Launcher.LaunchUriAsync(New Uri("https://developer.microsoft.com/zh-cn/microsoft-edge/webview2"))

        AddHandler Form1.UiButton61.Click, AddressOf 保存WebView2设置
        AddHandler Form1.UiButton71.Click, AddressOf 选择WebView2独立运行时路径

        AddHandler Form1.UiButton95.Click, Sub()
                                               If DLC.DLC解锁标记.CustomSkinExtension Then
                                                   If Form自定义背景.Visible = False Then 显示窗体(Form自定义背景, Form1)
                                               Else
                                                   UIMessageTip.Show("DLC 2 未激活",, 2500)
                                               End If
                                           End Sub

    End Sub

    Public Shared Sub 启动时加载设置()
        初始化设置相关操作()
        启动时检查用户文件夹()
        键值对IO操作.读取键值对文本到字典(全局设置数据, My.Resources.默认设置文件)
        If FileIO.FileSystem.FileExists(设置文件存储路径) Then
            Dim a As New Dictionary(Of String, String)
            Dim e1 As String = 键值对IO操作.读取键值对文件到字典(a, 设置文件存储路径)
            If e1 <> "" Then
                DebugPrint("读取本地设置文件时故障：" & e1, Color.OrangeRed, True)
            Else
                For Each kvp As KeyValuePair(Of String, String) In a
                    全局设置数据(kvp.Key) = kvp.Value
                Next
                DebugPrint("已加载设置文件", Form1.ForeColor)
            End If
        Else
            DebugPrint("全新启动，创建设置文件", Form1.ForeColor)
            键值对IO操作.读取键值对文本到字典(全局设置数据, My.Resources.默认设置文件)
            Select Case System.Globalization.CultureInfo.CurrentCulture.Name
                Case "zh-CN"
                    If 全局设置数据.ContainsKey("DisplayLanguage") Then 全局设置数据("DisplayLanguage") = "Default"
                    If 全局设置数据.ContainsKey("NewsLanguage") Then 全局设置数据("NewsLanguage") = "简体中文"
                    If 全局设置数据.ContainsKey("NewsSever") Then 全局设置数据("NewsSever") = "Gitee"
                    If 全局设置数据.ContainsKey("UpdateSever") Then 全局设置数据("UpdateSever") = "Gitee"
                Case Else
                    If 全局设置数据.ContainsKey("DisplayLanguage") Then 全局设置数据("DisplayLanguage") = "Default"
                    If 全局设置数据.ContainsKey("NewsLanguage") Then 全局设置数据("NewsLanguage") = "English"
                    If 全局设置数据.ContainsKey("NewsSever") Then 全局设置数据("NewsSever") = "GitHub"
                    If 全局设置数据.ContainsKey("UpdateSever") Then 全局设置数据("UpdateSever") = "GitHub"
            End Select
            键值对IO操作.从字典键值对写入文件(全局设置数据, 设置文件存储路径)
        End If
        If 全局设置数据("SaveUserWindowSize") = "True" Then
            Form1.Width = 全局设置数据("MainWindowWidth")
            Form1.Height = 全局设置数据("MainWindowHeight")
        End If
        刷新字体显示(Form1)
        刷新设置显示()
        UIMessageTip.DefaultStyle = New TipStyle With {.TextFont = New Font(Form1.Font.Name, 10), .BackColor = ColorTranslator.FromWin32(RGB(24, 24, 24)), .TextColor = Form1.ForeColor, .Padding = New Padding(15)}
        数据上传.发送用户统计()
        If 设置.全局设置数据("AgreementSigned") <> "True" Then
            Form1.TabPage管理模组.Parent = Nothing
            Form1.TabPage配置队列.Parent = Nothing
            Form1.TabPage下载更新.Parent = Nothing
            Form1.TabPage检查更新.Parent = Nothing
            Form1.TabPage浏览器.Parent = Nothing
            Form1.TabPage调试输出.Parent = Nothing
            Form1.UiTabControlMenu1.SelectedTab = Form1.TabPage许可协议
            Form1.TabPage扩展内容.Parent = Nothing
            Form1.TabPage最新模组.Parent = Nothing
            Form1.TabPage集成工具.Parent = Nothing
            Form1.TabPage创作者面板.Parent = Nothing
        End If
    End Sub

    Public Shared Sub 恢复选项卡显示()
        Form1.TabPage管理模组.Parent = Form1.UiTabControl1
        Form1.TabPage配置队列.Parent = Form1.UiTabControl1
        Form1.TabPage下载更新.Parent = Form1.UiTabControl1
        Form1.TabPage检查更新.Parent = Form1.UiTabControl1
        Form1.TabPage浏览器.Parent = Form1.UiTabControl1
        Form1.TabPage调试输出.Parent = Form1.UiTabControl1
        Form1.TabPage扩展内容.Parent = Form1.UiTabControlMenu1
        Form1.TabPage最新模组.Parent = Form1.UiTabControlMenu1
        Form1.TabPage集成工具.Parent = Form1.UiTabControlMenu1
        Form1.TabPage创作者面板.Parent = Form1.UiTabControlMenu1
        Form1.UiTabControlMenu1.SelectedIndex = 0
    End Sub


    Public Shared Sub 启动时检查用户文件夹()
        If FileIO.FileSystem.DirectoryExists(用户数据文件夹路径) = False Then FileIO.FileSystem.CreateDirectory(用户数据文件夹路径)
        If FileIO.FileSystem.DirectoryExists(DLC文件夹路径) = False Then FileIO.FileSystem.CreateDirectory(DLC文件夹路径)
        If FileIO.FileSystem.DirectoryExists(插件文件夹路径) = False Then FileIO.FileSystem.CreateDirectory(插件文件夹路径)
        If FileIO.FileSystem.DirectoryExists(浏览器缓存路径) = False Then FileIO.FileSystem.CreateDirectory(浏览器缓存路径)
        If FileIO.FileSystem.DirectoryExists(自定义语言包路径) = False Then FileIO.FileSystem.CreateDirectory(自定义语言包路径)
        If FileIO.FileSystem.DirectoryExists(SMAPI下载路径) = False Then FileIO.FileSystem.CreateDirectory(SMAPI下载路径)
        If FileIO.FileSystem.DirectoryExists(SMAPI解压路径) = False Then FileIO.FileSystem.CreateDirectory(SMAPI解压路径)
    End Sub

    Public Shared ReadOnly 用户数据文件夹路径 As String = Path.Combine(Application.StartupPath, "UserData")

    Public Shared ReadOnly 设置文件存储路径 As String = Path.Combine(Application.StartupPath, "UserData\Settings")
    Public Shared ReadOnly 安装程序更新下载文件路径 As String = Path.Combine(Application.StartupPath, "UserData\SMUI 6 Installer.exe")
    Public Shared ReadOnly 当日新闻列表文件路径 As String = Path.Combine(Application.StartupPath, "UserData\TodayNews")

    Public Shared ReadOnly DLC文件夹路径 As String = Path.Combine(Application.StartupPath, "UserData\DLC")
    Public Shared ReadOnly 插件文件夹路径 As String = Path.Combine(Application.StartupPath, "UserData\Plugin")
    Public Shared ReadOnly 浏览器缓存路径 As String = Path.Combine(Application.StartupPath, "UserData\WebView2Cache")
    Public Shared ReadOnly 自定义语言包路径 As String = Path.Combine(Application.StartupPath, "UserData\Language")
    Public Shared ReadOnly SMAPI下载路径 As String = Path.Combine(Application.StartupPath, "UserData\SmapiDownload")
    Public Shared ReadOnly SMAPI解压路径 As String = Path.Combine(Application.StartupPath, "UserData\SmapiDecompress")

    Public Shared Function 检查并返回数据库下载文件夹路径() As String
        If Not FileIO.FileSystem.DirectoryExists(Path.Combine(全局设置数据("LocalRepositoryPath"), ".Download")) Then
            FileIO.FileSystem.CreateDirectory(Path.Combine(全局设置数据("LocalRepositoryPath"), ".Download"))
        End If
        Return Path.Combine(全局设置数据("LocalRepositoryPath"), ".Download")
    End Function

    Public Shared Function 检查并返回数据库解压文件夹路径() As String
        If Not FileIO.FileSystem.DirectoryExists(Path.Combine(全局设置数据("LocalRepositoryPath"), ".Decompress")) Then
            FileIO.FileSystem.CreateDirectory(Path.Combine(全局设置数据("LocalRepositoryPath"), ".Decompress"))
        End If
        Return Path.Combine(全局设置数据("LocalRepositoryPath"), ".Decompress")
    End Function



    Public Shared Sub 刷新设置显示()
        Form1.暗黑文本框1.Text = 全局设置数据("StardewValleyGamePath")
        Form1.暗黑文本框2.Text = 全局设置数据("LocalRepositoryPath")
        Form1.暗黑文本框3.Text = 全局设置数据("StardewValleyGameBackupPath")
        Form1.暗黑文本框4.Text = 全局设置数据("VisualStudioCodeEXE")
        Form1.暗黑文本框5.Text = 全局设置数据("VisualStudioEXE")

        Form1.UiComboBox4.Text = 全局设置数据("DisplayLanguage")
        Form1.UiComboBox1.Text = 全局设置数据("NewsLanguage")
        Form1.UiComboBox2.Text = 全局设置数据("NewsSever")
        Form1.UiComboBox3.Text = 全局设置数据("UpdateSever")
        Form1.UiComboBox5.Text = 全局设置数据("AlternativeUpdateSever")

        Form1.TextBox1.Text = 全局设置数据("NexusAPI")
        Form1.暗黑文本框6.Text = 全局设置数据("GiteeToken")
        Form1.暗黑文本框7.Text = 全局设置数据("GithubToken")

        Select Case 全局设置数据("LaunchSelection")
            Case "1"
                Form1.UiRadioButton1.Checked = True
                Form1.UiRadioButton2.Checked = False
            Case "2"
                Form1.UiRadioButton1.Checked = False
                Form1.UiRadioButton2.Checked = True
        End Select
        Form1.暗黑文本框8.Text = 全局设置数据("LaunchParameters")
        Form1.暗黑文本框9.Text = 全局设置数据("CustomLaunchCMD")

        Form1.UiCheckBox1.Checked = 全局设置数据("SaveUserWindowSize")
        Form1.UiCheckBox7.Checked = 全局设置数据("AutoGetNews")
        Form1.UiCheckBox10.Checked = 全局设置数据("SaveNewsInTodayUse")
        Form1.UiCheckBox9.Checked = 全局设置数据("AutoCheckUpdate")
        Form1.UiCheckBox8.Checked = 全局设置数据("AutoStartDownloadUpdate")
        Form1.UiCheckBox4.Checked = 全局设置数据("AutoSelectFirstNexusDownloadSever")
        Form1.UiCheckBox5.Checked = 全局设置数据("AutoConvertWebpToPng")
        Form1.UiCheckBox16.Checked = 全局设置数据("DownloadFileUseSMUI5Color")
        Form1.UiCheckBox17.Checked = 全局设置数据("DownloadFileUseBigBuffer")

        Form1.UiComboBox8.Text = 全局设置数据("FontName")

        Select Case 全局设置数据("UploadUserInfo")
            Case "True"
                Form1.UiRadioButton3.Checked = True
                Form1.UiRadioButton4.Checked = False
            Case "False"
                Form1.UiRadioButton3.Checked = False
                Form1.UiRadioButton4.Checked = True
        End Select
        Form1.UiCheckBox3.Checked = 全局设置数据("UploadWindowsVer")
        Form1.UiCheckBox11.Checked = 全局设置数据("UploadCPU0")
        Form1.UiCheckBox14.Checked = 全局设置数据("UploadRAM")
        Form1.UiCheckBox15.Checked = 全局设置数据("UploadCDiskCapacity")
        Form1.UiCheckBox12.Checked = 全局设置数据("UploadGPU")
        Form1.UiCheckBox13.Checked = 全局设置数据("UploadScreen")

        Form1.UiSwitch2.Active = 全局设置数据("ProcessMonitor")
        Form1.UiSwitch3.Active = 全局设置数据("PerformanceMonitor")
        Select Case 全局设置数据("UseStandaloneWebView2")
            Case "False"
                Form1.UiRadioButton7.Checked = True
                Form1.UiRadioButton8.Checked = False
            Case Else
                Form1.UiRadioButton7.Checked = False
                Form1.UiRadioButton8.Checked = True
        End Select
        Form1.暗黑文本框10.Text = 全局设置数据("WebView2StandalonePath")
        Form1.UiCheckBox18.Checked = 全局设置数据("AdditionalBuiltinParameters")

    End Sub

    Public Shared Sub 保存路径设置()
        全局设置数据("StardewValleyGamePath") = Form1.暗黑文本框1.Text
        全局设置数据("LocalRepositoryPath") = Form1.暗黑文本框2.Text
        全局设置数据("StardewValleyGameBackupPath") = Form1.暗黑文本框3.Text
        全局设置数据("VisualStudioCodeEXE") = Form1.暗黑文本框4.Text
        全局设置数据("VisualStudioEXE") = Form1.暗黑文本框5.Text
        UIMessageTip.Show("更改已写入内存，正常退出时写入文件",, 2500)
        状态信息.刷新起始页面状态信息()
    End Sub

    Public Shared Sub 保存语言和服务器设置()
        全局设置数据("DisplayLanguage") = Form1.UiComboBox4.Text
        全局设置数据("NewsLanguage") = Form1.UiComboBox1.Text
        全局设置数据("NewsSever") = Form1.UiComboBox2.Text
        全局设置数据("UpdateSever") = Form1.UiComboBox3.Text
        全局设置数据("AlternativeUpdateSever") = Form1.UiComboBox5.Text
        UIMessageTip.Show("更改已写入内存，正常退出时写入文件",, 2500)
    End Sub

    Public Shared Sub 保存网络API设置()
        全局设置数据("NexusAPI") = Form1.TextBox1.Text
        全局设置数据("GiteeToken") = Form1.暗黑文本框6.Text
        全局设置数据("GithubToken") = Form1.暗黑文本框7.Text
        UIMessageTip.Show("更改已写入内存，正常退出时写入文件",, 2500)
    End Sub

    Public Shared Sub 保存启动项设置()
        If Form1.UiRadioButton1.Checked Then
            全局设置数据("LaunchSelection") = "1"
        Else
            全局设置数据("LaunchSelection") = "2"
        End If
        UIMessageTip.Show("更改已写入内存，正常退出时写入文件",, 2500)
    End Sub

    Public Shared Sub 保存数值和开关设置()
        全局设置数据("SaveUserWindowSize") = Form1.UiCheckBox1.Checked
        全局设置数据("AutoGetNews") = Form1.UiCheckBox7.Checked
        全局设置数据("SaveNewsInTodayUse") = Form1.UiCheckBox10.Checked
        全局设置数据("AutoCheckUpdate") = Form1.UiCheckBox9.Checked
        全局设置数据("AutoStartDownloadUpdate") = Form1.UiCheckBox8.Checked
        全局设置数据("AutoSelectFirstNexusDownloadSever") = Form1.UiCheckBox4.Checked
        全局设置数据("AutoConvertWebpToPng") = Form1.UiCheckBox5.Checked
        全局设置数据("DownloadFileUseSMUI5Color") = Form1.UiCheckBox16.Checked
        全局设置数据("DownloadFileUseBigBuffer") = Form1.UiCheckBox17.Checked
        UIMessageTip.Show("更改已写入内存，正常退出时写入文件",, 2500)
    End Sub

    Public Shared Sub 保存字体设置()
        全局设置数据("FontName") = Form1.UiComboBox8.Text
        刷新字体显示(Form1)
        UIMessageTip.Show("更改已写入内存，正常退出时写入文件",, 2500)
    End Sub

    Private Shared Sub 刷新字体显示(parentControl As Control)
        For Each ctrl As Control In parentControl.Controls
            If ctrl Is Form1.UiRichTextBox4 Then Continue For
            If ctrl Is Form1.UiRichTextBox3 Then Continue For
            刷新字体显示_检查属性(ctrl)
            If ctrl.HasChildren Then 刷新字体显示(ctrl)
        Next
        管理模组的菜单.设置字体()
        内容中心.设置字体()
    End Sub

    Private Shared Sub 刷新字体显示_检查属性(control As Control)
        Dim controlType As Type = control.GetType()
        Dim propInfo As PropertyInfo = controlType.GetProperty("Font")
        If propInfo IsNot Nothing Then control.Font = New Font(全局设置数据("FontName"), control.Font.Size)
    End Sub

    Public Shared Sub 保存隐私设置()
        If Form1.UiRadioButton3.Checked Then
            全局设置数据("UploadUserInfo") = "True"
        Else
            全局设置数据("UploadUserInfo") = "False"
        End If
        全局设置数据("UploadWindowsVer") = Form1.UiCheckBox3.Checked
        全局设置数据("UploadCPU0") = Form1.UiCheckBox11.Checked
        全局设置数据("UploadRAM") = Form1.UiCheckBox14.Checked
        全局设置数据("UploadCDiskCapacity") = Form1.UiCheckBox15.Checked
        全局设置数据("UploadGPU") = Form1.UiCheckBox12.Checked
        全局设置数据("UploadScreen") = Form1.UiCheckBox13.Checked
        UIMessageTip.Show("更改已写入内存，正常退出时写入文件",, 2500)
    End Sub

    Public Shared Sub 保存WebView2设置()
        If Form1.UiRadioButton7.Checked Then
            全局设置数据("UseStandaloneWebView2") = "False"
        Else
            全局设置数据("UseStandaloneWebView2") = "True"
        End If
        If Right(Form1.暗黑文本框10.Text, 1) <> "\" Then Form1.暗黑文本框10.Text &= "\"
        全局设置数据("WebView2StandalonePath") = Form1.暗黑文本框10.Text
        全局设置数据("AdditionalBuiltinParameters") = Form1.UiCheckBox17.Checked
        UIMessageTip.Show("更改已写入内存，正常退出时写入文件",, 2500)
    End Sub

    Public Shared Sub 选择游戏文件夹路径()
        Dim p1 As New List(Of String) From {"这里没有列出，手动选择游戏文件夹"}
        Dim MyReg As Microsoft.Win32.RegistryKey = Microsoft.Win32.Registry.LocalMachine.OpenSubKey("SOFTWARE\Microsoft\Windows\CurrentVersion\Uninstall\Steam App 413150")
        If MyReg IsNot Nothing Then p1.Add(MyReg.GetValue("InstallLocation").ToString())
        Dim MyReg2 As Microsoft.Win32.RegistryKey = Microsoft.Win32.Registry.LocalMachine.OpenSubKey("SOFTWARE\GOG.com\Games\1453375253")
        If MyReg2 IsNot Nothing Then p1.Add(MyReg2.GetValue("PATH").ToString())
        '这届的小白真是日了狗了，连个游戏文件夹都找不到，就TM这技术还玩单机游戏
        Dim AllDrives() As DriveInfo = DriveInfo.GetDrives()
        For Each D1 As DriveInfo In AllDrives
            If FileIO.FileSystem.FileExists(Path.Combine(D1.Name, "Program Files\Steam\steamapps\common\Stardew Valley\Stardew Valley.exe")) = True Then
                If Not p1.Contains(Path.Combine(D1.Name, "Program Files\Steam\steamapps\common\Stardew Valley\Stardew Valley.exe")) Then
                    p1.Add(Path.Combine(D1.Name, "Program Files\Steam\steamapps\common\Stardew Valley"))
                End If
            End If
            If FileIO.FileSystem.FileExists(Path.Combine(D1.Name, "Program Files (x86)\Steam\steamapps\common\Stardew Valley\Stardew Valley.exe")) = True Then
                If Not p1.Contains(Path.Combine(D1.Name, "Program Files (x86)\Steam\steamapps\common\Stardew Valley\Stardew Valley.exe")) Then
                    p1.Add(Path.Combine(D1.Name, "Program Files (x86)\Steam\steamapps\common\Stardew Valley"))
                End If
            End If
            If FileIO.FileSystem.FileExists(Path.Combine(D1.Name, "SteamLibrary\steamapps\common\Stardew Valley\Stardew Valley.exe")) = True Then
                If Not p1.Contains(Path.Combine(D1.Name, "SteamLibrary\steamapps\common\Stardew Valley\Stardew Valley.exe")) Then
                    p1.Add(Path.Combine(D1.Name, "SteamLibrary\steamapps\common\Stardew Valley"))
                End If
            End If
            If FileIO.FileSystem.FileExists(Path.Combine(D1.Name, "Program Files\ModifiableWindowsApps\Stardew Valley\Stardew Valley.exe")) = True Then
                If Not p1.Contains(Path.Combine(D1.Name, "Program Files\ModifiableWindowsApps\Stardew Valley\Stardew Valley.exe")) Then
                    p1.Add(Path.Combine(D1.Name, "Program Files\ModifiableWindowsApps\Stardew Valley"))
                End If
            End If
        Next
R1:
        Dim a As New 多项单选对话框("选择星露谷游戏文件夹", p1, "选择程序自动找到的或者你可以自己浏览文件夹", 100, 600)
        Dim b As Integer = a.ShowDialog(Form1)
        Select Case b
            Case -1
                Exit Sub
            Case 0
                UIMessageTip.Show("如要取消选择，直接关闭选择器窗口即可返回上一步",, 5000)
                Dim str1 As String = ""
                If DirEx.SelectDirEx("选择你的星露谷游戏文件夹", str1) Then
                    If FileIO.FileSystem.FileExists(str1 & "\Stardew Valley.exe") = True Or FileIO.FileSystem.FileExists(str1 & "\StardewValley.exe") = True Then
                        Form1.暗黑文本框1.Text = str1
                    Else
                        Dim c As New 多项单选对话框("选择错误", {"返回"}, "此文件夹路径下不包含星露谷的可执行文件：Stardew Valley.exe", 100, 500)
                        c.ShowDialog(Form1)
                        GoTo R1
                    End If
                Else
                    GoTo R1
                End If
            Case Else
                Form1.暗黑文本框1.Text = p1(b)
        End Select
    End Sub

    Public Shared Sub 选择数据库路径()
        Dim a1 As New List(Of String) From {"创建新的模组数据仓库，使用现有也可以"}
        If FileIO.FileSystem.FileExists("C:\Users\Public\1059 Studio\SMUI Client 4\Settings\UserSettings.xml") Then
            Dim x As New XmlDocument
            x.Load("C:\Users\Public\1059 Studio\SMUI Client 4\Settings\UserSettings.xml")
            If FileIO.FileSystem.DirectoryExists(x.SelectSingleNode("Data/LibraryPath").InnerText) Then a1.Add(x.SelectSingleNode("Data/LibraryPath").InnerText)
        End If
        If FileIO.FileSystem.FileExists($"C:\Users\{Environment.UserName}\AppData\Roaming\1059 Studio\SMUI Client 5 Cache\Settings.xml") Then
            Dim x As New XmlDocument
            x.Load($"C:\Users\{Environment.UserName}\AppData\Roaming\1059 Studio\SMUI Client 5 Cache\Settings.xml")

            If FileIO.FileSystem.DirectoryExists(x.SelectSingleNode("data/ModRepositoryPath")?.InnerText) Then a1.Add(x.SelectSingleNode("data/ModRepositoryPath")?.InnerText)
        End If
R1:
        Dim a As New 多项单选对话框("选择模组数据仓库", a1, $"你可以选择现有的模组数据仓库文件夹，如果你正在使用旧代产品则可以直接在下面选择，四代和五代的数据库都可以直接使用，新版本的配置文件将在使用中自动生成。如果你还没有本产品定义的模组数据仓库，请选择第一项然后选择一个空文件夹来创建新的数据仓库。{vbCrLf & vbCrLf}请确保你的数据仓库应该放在固态硬盘，而不是机械硬盘，SMUI 非常需要瞬间读取速度，否则 SMUI 的性能将大幅下降。同时建议将数据仓库和游戏文件夹置于同一硬盘上。", 200, 600)
        Dim b As Integer = a.ShowDialog(Form1)
        Select Case b
            Case -1
                Exit Sub
            Case 0
                UIMessageTip.Show("如要取消选择，直接关闭选择器窗口即可返回上一步",, 5000)
                Dim str1 As String = ""
                If DirEx.SelectDirEx("选择一个空文件夹，它将作为你的新数据仓库", str1) Then
                    Dim c As New 多项单选对话框("确认使用此文件夹作为你的模组数据仓库？", {"确定", "取消"}, str1, 100, 500)
                    Dim d As Integer = c.ShowDialog(Form1)
                    Select Case d
                        Case -1
                            Exit Sub
                        Case 0
                            If FileIO.FileSystem.DirectoryExists(str1 & "\Default Sub Library") = False Then
                                FileIO.FileSystem.CreateDirectory(str1 & "\Default Sub Library")
                            End If
                            If FileIO.FileSystem.DirectoryExists(str1 & "\.Download") = False Then
                                FileIO.FileSystem.CreateDirectory(str1 & "\.Download")
                            End If
                            If FileIO.FileSystem.DirectoryExists(str1 & "\.Decompress") = False Then
                                FileIO.FileSystem.CreateDirectory(str1 & "\.Decompress")
                            End If
                            If FileIO.FileSystem.FileExists(str1 & "\MANIFEST") = False Then
                                FileIO.FileSystem.WriteAllText(str1 & "\MANIFEST", "This is your Mod Repository root path.", False, Encoding.UTF8)
                            End If
                            Form1.暗黑文本框2.Text = str1
                        Case 1
                            GoTo R1
                    End Select
                Else
                    GoTo R1
                End If
            Case Else
                If FileIO.FileSystem.DirectoryExists(a1(b) & "\.Download") = False Then
                    FileIO.FileSystem.CreateDirectory(a1(b) & "\.Download")
                End If
                Form1.暗黑文本框2.Text = a1(b)
        End Select
    End Sub

    Public Shared Sub 选择游戏备份路径()
        UIMessageTip.Show("要实现文件替换的卸载自动还原，需要手动备份对应文件",, 5000)
        Dim str1 As String = ""
        If DirEx.SelectDirEx("选择游戏文件备份路径（如果要使用文件替换类命令，则是必须的，否则程序会删除游戏文件）", str1) Then
            Form1.暗黑文本框3.Text = str1
        End If
    End Sub

    Public Shared Sub 选择VSC路径()
        Dim a As New OpenFileDialog With {.Filter = "Code.exe|Code.exe"}
        If FileIO.FileSystem.DirectoryExists($"C:\Users\{Environment.UserName}\AppData\Local\Programs\Microsoft VS Code") = True Then
            a.InitialDirectory = $"C:\Users\{Environment.UserName}\AppData\Local\Programs\Microsoft VS Code"
        End If
        a.ShowDialog(Form1)
        If a.FileName = "" Then Exit Sub
        Form1.暗黑文本框4.Text = a.FileName
    End Sub

    Public Shared Sub 选择VS路径()
        Dim a As New OpenFileDialog With {.Filter = "devenv.exe|devenv.exe"}
        If FileIO.FileSystem.DirectoryExists("C:\Program Files\Microsoft Visual Studio\2022\Community\Common7\IDE") = True Then
            a.InitialDirectory = "C:\Program Files\Microsoft Visual Studio\2022\Community\Common7\IDE"
        End If
        a.ShowDialog(Form1)
        If a.FileName = "" Then Exit Sub
        Form1.暗黑文本框5.Text = a.FileName
    End Sub

    Public Shared Sub 检测NEXUS密钥是否可用()
        Dim a As New NEXUS.GetUserInfo With {.ST_ApiKey = Form1.TextBox1.Text}
        Dim x As String = a.StartGet()
        If x <> "" Then
            'Form1.Label7.Text = 获取动态多语言文本("data/DynamicText/LogInFailed")
            MsgBox(x, MsgBoxStyle.Critical)
        Else
            Dim c As String = ""
            c &= "用户名：" & a.name & vbCrLf
            c &= "用户ID：" & a.user_id & vbCrLf
            c &= "邮箱：" & a.email & vbCrLf
            c &= "是否是会员：" & a.is_premium & vbCrLf
            c &= "是否是支持者：" & a.is_supporter & vbCrLf
            c &= "当前小时请求剩余量：" & a.hourly_remaining & "/" & a.hourly_limit & vbCrLf
            c &= "今天内请求剩余量：" & a.daily_remaining & "/" & a.daily_limit
            'Form1.Label7.Text = 获取动态多语言文本("data/DynamicText/LoggedNexusWebApi") & vbCrLf & 获取动态多语言文本("data/DynamicText/UserName") & a.name
            Dim m As New 多项单选对话框("NEXUS WEB API", {"OK"}, c, 200)
            m.ShowDialog(Form1)
        End If
    End Sub

    Public Shared Sub 切换密钥密文显示()
        Select Case Form1.TextBox1.PasswordChar
            Case "●"
                Form1.TextBox1.PasswordChar = ""
            Case ""
                Form1.TextBox1.PasswordChar = "●"
        End Select
    End Sub

    Public Shared Sub 让非N网会员去内置浏览器登录()
        If 全局设置数据("AgreementSigned") = "False" Then Exit Sub
        Form1.UiTabControl1.SelectedTab = Form1.TabPage浏览器
        Form1.UiButton49.PerformClick()
    End Sub

    Public Shared Sub 去内置浏览器管理密钥()
        If 全局设置数据("AgreementSigned") = "False" Then Exit Sub
        Form1.UiTextBox5.Text = "https://www.nexusmods.com/users/myaccount?tab=api"
        Form1.UiTabControl1.SelectedTab = Form1.TabPage浏览器
        Form1.UiButton53.PerformClick()
    End Sub

    Public Shared Sub 控制进程监控功能开关()
        If Form1.UiSwitch2.Active Then
            状态信息.SMAPI运行态定时器.Enabled = True
        Else
            状态信息.SMAPI运行态定时器.Enabled = False
            Form1.UiButton45.Text = "RUN SMAPI"
        End If
        全局设置数据("ProcessMonitor") = Form1.UiSwitch2.Active
    End Sub

    Public Shared Sub 控制性能监控功能开关()
        If Form1.UiSwitch3.Active Then
            If 状态信息.CPU性能计数器 Is Nothing Then
                Form1.UiListBox1.Items(4) = "正在初始化性能计数器，这需要几秒钟时间"
                状态信息.等待初始化性能计数器()
            End If
            状态信息.性能计数定时器.Enabled = True
        Else
            状态信息.性能计数定时器.Enabled = False
            Form1.UiListBox1.Items(4) = "启用性能监控功能以统计性能信息"
        End If
        全局设置数据("PerformanceMonitor") = Form1.UiSwitch3.Active
    End Sub

    Public Shared Sub 选择WebView2独立运行时路径()
        Dim str1 As String = ""
        If DirEx.SelectDirEx("包含 msedgewebview2.exe 的文件夹", str1) Then
            If Right(str1, 1) <> "\" Then str1 &= "\"
            Form1.暗黑文本框10.Text = str1
        End If
    End Sub

    Public Shared Sub 加载自定义背景()
        If Not DLC.DLC解锁标记.CustomSkinExtension Then Exit Sub
        If FileIO.FileSystem.FileExists(全局设置数据("BGP_News")) Then
            Using fs As New IO.FileStream(全局设置数据("BGP_News"), IO.FileMode.Open, IO.FileAccess.Read)
                Form1.Panel35.BackgroundImage = Image.FromStream(fs)
                Form1.Panel35.BackgroundImageLayout = ImageLayout.Stretch
            End Using
        End If
        If FileIO.FileSystem.FileExists(全局设置数据("BGP_Category")) Then
            Using fs As New IO.FileStream(全局设置数据("BGP_Category"), IO.FileMode.Open, IO.FileAccess.Read)
                Form1.ListView1.BackgroundImage = Image.FromStream(fs)
                Form1.ListView1.BackgroundImageLayout = ImageLayout.Stretch
            End Using
        End If
        If FileIO.FileSystem.FileExists(全局设置数据("BGP_ModItem")) Then
            Using fs As New IO.FileStream(全局设置数据("BGP_ModItem"), IO.FileMode.Open, IO.FileAccess.Read)
                Form1.ListView2.BackgroundImage = Image.FromStream(fs)
                Form1.ListView2.BackgroundImageLayout = ImageLayout.Stretch
            End Using
        End If



    End Sub



End Class
