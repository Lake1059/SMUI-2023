Imports System.IO

Public Class 状态信息

    Enum 应用程序启动模式枚举
        安装程序部署 = 1
        便携式离线 = 2
        Steam = 3
    End Enum
    Public Shared Property 启动模式 As 应用程序启动模式枚举

    Public Shared Sub 判断应用程序启动模式()
        If FileIO.FileSystem.FileExists(Path.Combine(Application.StartupPath, "steam_appid.txt")) Then
            启动模式 = 应用程序启动模式枚举.Steam
            Exit Sub
        End If
        Using key As Microsoft.Win32.RegistryKey = Microsoft.Win32.Registry.CurrentUser.OpenSubKey("SOFTWARE\1059 Studio\SMUI 2023")
            If key Is Nothing Then
                启动模式 = 应用程序启动模式枚举.便携式离线
                Exit Sub
            Else
                Dim value As Object = key.GetValue("Path")
                If value IsNot Nothing AndAlso TypeOf value Is String Then
                    If value.ToString <> Application.StartupPath Then
                        启动模式 = 应用程序启动模式枚举.便携式离线
                        Exit Sub
                    Else
                        启动模式 = 应用程序启动模式枚举.安装程序部署
                        Exit Sub
                    End If
                Else
                    启动模式 = 应用程序启动模式枚举.便携式离线
                    Exit Sub
                End If
            End If
        End Using
    End Sub

    Public Shared Sub 刷新起始页面状态信息()
        If FileIO.FileSystem.DirectoryExists(设置.全局设置数据("StardewValleyGamePath")) Then
            If FileIO.FileSystem.FileExists(Path.Combine(设置.全局设置数据("StardewValleyGamePath"), "Stardew Valley.exe")) Then
                Dim fileVersionInfo As FileVersionInfo = FileVersionInfo.GetVersionInfo(Path.Combine(设置.全局设置数据("StardewValleyGamePath"), "Stardew Valley.exe"))
                Form1.UiListBox1.Items(0) = $"Stardew Valley {fileVersionInfo.FileMajorPart}.{fileVersionInfo.FileMinorPart}.{fileVersionInfo.FileBuildPart}.{fileVersionInfo.FilePrivatePart}"
            ElseIf FileIO.FileSystem.FileExists(Path.Combine(设置.全局设置数据("StardewValleyGamePath"), "StardewValley.exe")) Then
                Dim fileVersionInfo As FileVersionInfo = FileVersionInfo.GetVersionInfo(Path.Combine(设置.全局设置数据("StardewValleyGamePath"), "StardewValley.exe"))
                Form1.UiListBox1.Items(0) = $"StardewValley {fileVersionInfo.FileMajorPart}.{fileVersionInfo.FileMinorPart}.{fileVersionInfo.FileBuildPart}.{fileVersionInfo.FilePrivatePart}"
            End If
            If FileIO.FileSystem.FileExists(Path.Combine(设置.全局设置数据("StardewValleyGamePath"), "StardewModdingAPI.exe")) Then
                Dim fileVersionInfo As FileVersionInfo = FileVersionInfo.GetVersionInfo(Path.Combine(设置.全局设置数据("StardewValleyGamePath"), "StardewModdingAPI.exe"))
                Form1.UiListBox1.Items(0) &= $" - SMAPI {fileVersionInfo.FileMajorPart}.{fileVersionInfo.FileMinorPart}.{fileVersionInfo.FileBuildPart}"
            Else
                Form1.UiListBox1.Items(0) &= "未安装 SMAPI"
            End If
            Form1.UiListBox1.Items(1) = 设置.全局设置数据("StardewValleyGamePath")
        Else
            Form1.UiListBox1.Items(0) = "当前游戏文件夹不可用，无法读取版本信息"
            Form1.UiListBox1.Items(1) = "当前游戏文件夹不可用"
        End If

        Dim F2 As FileVersionInfo = FileVersionInfo.GetVersionInfo(Application.ExecutablePath)
        Form1.UiListBox1.Items(2) = $"SMUI {F2.FileMajorPart}.{F2.FileMinorPart}.{F2.FileBuildPart}"
        Select Case 启动模式
            Case 应用程序启动模式枚举.安装程序部署
                Form1.UiListBox1.Items(2) &= " - 安装程序部署"
            Case 应用程序启动模式枚举.便携式离线
                Form1.UiListBox1.Items(2) &= " - 便携式离线"
            Case 应用程序启动模式枚举.Steam
                Form1.UiListBox1.Items(2) &= " - Steam Version"
        End Select

        If FileIO.FileSystem.DirectoryExists(设置.全局设置数据("LocalRepositoryPath")) Then
            Form1.UiListBox1.Items(3) = 设置.全局设置数据("LocalRepositoryPath")
        Else
            Form1.UiListBox1.Items(3) = "当前模组数据仓库不可用，请重新设置"
        End If

    End Sub


    Public Shared Property CPU性能计数器 As PerformanceCounter
    Public Shared ReadOnly 性能计数定时器 As New Timer With {.Enabled = False, .Interval = 2000}

    Public Shared Sub 初始化性能计数定时器()
        AddHandler 性能计数定时器.Tick,
            Sub()
                If CPU性能计数器 Is Nothing Then Exit Sub
                Try
                    Form1.UiListBox1.Items(4) = $"CPU {Format(CPU性能计数器.NextValue, "0.0")}%"
                Catch ex As Exception
                    Form1.UiListBox1.Items(4) = "无数据"
                End Try
                Dim b1 = Process.GetCurrentProcess().WorkingSet64 / 1024 / 1024
                Dim b2 = Process.GetCurrentProcess().PrivateMemorySize64 / 1024 / 1024
                Dim processes() As Process = Process.GetProcessesByName("CefSharp.BrowserSubprocess")
                If processes.Length > 0 Then
                    For Each proc As Process In processes
                        If proc.MainModule.FileName = Path.Combine(Application.StartupPath, "CefSharp.BrowserSubprocess.exe") Then
                            b1 += proc.WorkingSet64 / 1024 / 1024
                            b2 += proc.PrivateMemorySize64 / 1024 / 1024

                        End If
                    Next
                End If
                Form1.UiListBox1.Items(4) &= $" - 总物理 {Format(b1, "0.0")} MB"
                Form1.UiListBox1.Items(4) &= $" - 专用 {Format(b2, "0.0")} MB"
            End Sub
    End Sub

    Public Shared Sub 等待初始化性能计数器()
        Dim longRunningTask As New Threading.Thread(AddressOf 执行初始化性能计数器)
        longRunningTask.Start()
        longRunningTask.Join()
    End Sub

    Public Shared Sub 执行初始化性能计数器()
        CPU性能计数器 = New PerformanceCounter("Process", "% Processor Time", Process.GetCurrentProcess().ProcessName, True)
    End Sub



    Public Shared ReadOnly SMAPI运行态定时器 As New Timer With {.Enabled = False, .Interval = 1500}

    Public Shared Sub 初始化SMAPI运行态定时器()
        AddHandler SMAPI运行态定时器.Tick,
            Sub()
                Dim processes() As Process = Process.GetProcessesByName("StardewModdingAPI")
                Select Case processes.Length
                    Case 0
                        Form1.UiButton45.Text = "RUN SMAPI"
                    Case 1
                        Form1.UiButton45.Text = "SMAPI Is Running"
                    Case > 1
                        Form1.UiButton45.Text = $"{processes.Length} SMAPIs Are Running"
                End Select
            End Sub
    End Sub

End Class
