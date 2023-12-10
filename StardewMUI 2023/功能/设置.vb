Public Class 设置

    Public Shared Property 全局设置数据 As New Dictionary(Of String, String)

    Public Shared Sub 启动时加载设置()
        启动时检查用户文件夹()
        键值对IO操作.读取键值对文本到字典(全局设置数据, My.Resources.默认设置文件)
        If FileIO.FileSystem.FileExists(设置文件存储路径) Then
            Dim a As New Dictionary(Of String, String)
            Dim e1 As String = 键值对IO操作.读取键值对文件到字典(a, 设置文件存储路径)
            If e1 <> "" Then
                DebugPrint("读取本地设置文件时故障：" & e1, Color.OrangeRed, True)
            Else
                全局设置数据 = a
            End If
        Else
            DebugPrint("全新启动，创建设置文件", Form1.ForeColor)
            键值对IO操作.读取键值对文本到字典(全局设置数据, My.Resources.默认设置文件)
            Select Case System.Globalization.CultureInfo.CurrentCulture.Name
                Case "zh-CN"
                    If 全局设置数据.ContainsKey("DisplayLanguage") Then 全局设置数据("DisplayLanguage") = "Default"
                    If 全局设置数据.ContainsKey("NewsLanguage") Then 全局设置数据("NewsLanguage") = "Default"
                    If 全局设置数据.ContainsKey("UpdateSever") Then 全局设置数据("UpdateSever") = "Gitee"
                Case Else
                    If 全局设置数据.ContainsKey("DisplayLanguage") Then 全局设置数据("DisplayLanguage") = "Default"
                    If 全局设置数据.ContainsKey("NewsLanguage") Then 全局设置数据("NewsLanguage") = "Default"
                    If 全局设置数据.ContainsKey("UpdateSever") Then 全局设置数据("UpdateSever") = "GitHub"
            End Select
        End If
    End Sub

    Public Shared Sub 启动时检查用户文件夹()
        If FileIO.FileSystem.DirectoryExists(用户数据文件夹路径) Then FileIO.FileSystem.CreateDirectory(用户数据文件夹路径)
        If FileIO.FileSystem.DirectoryExists(DLC文件夹路径) Then FileIO.FileSystem.CreateDirectory(用户数据文件夹路径)
        If FileIO.FileSystem.DirectoryExists(插件文件夹路径) Then FileIO.FileSystem.CreateDirectory(用户数据文件夹路径)
        If FileIO.FileSystem.DirectoryExists(浏览器缓存路径) Then FileIO.FileSystem.CreateDirectory(用户数据文件夹路径)
        If FileIO.FileSystem.DirectoryExists(自定义语言包路径) Then FileIO.FileSystem.CreateDirectory(自定义语言包路径)
    End Sub

    Public Shared ReadOnly 用户数据文件夹路径 As String = Application.StartupPath & "\UserData"

    Public Shared ReadOnly 设置文件存储路径 As String = Application.StartupPath & "\UserData\Settings"
    Public Shared ReadOnly 安装程序更新下载文件路径 As String = Application.StartupPath & "\UserData\SMUI 6 Installer.exe"

    Public Shared ReadOnly DLC文件夹路径 As String = Application.StartupPath & "\UserData\DLC"
    Public Shared ReadOnly 插件文件夹路径 As String = Application.StartupPath & "\UserData\Plugin"
    Public Shared ReadOnly 浏览器缓存路径 As String = Application.StartupPath & "\UserData\WebCache"
    Public Shared ReadOnly 自定义语言包路径 As String = Application.StartupPath & "\UserData\Language"


End Class
