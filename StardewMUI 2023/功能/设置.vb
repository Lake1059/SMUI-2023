Public Class 设置

    Public Shared Property 全局设置数据 As New Dictionary(Of String, String)

    Public Shared Sub 启动时加载设置()
        启动时检查用户文件夹()
        键值对IO操作.读取键值对文本到字典(全局设置数据, My.Resources.默认设置文件)

        If FileIO.FileSystem.FileExists(设置文件存储路径) Then




        Else


        End If



    End Sub

    Public Shared Sub 启动时检查用户文件夹()
        If FileIO.FileSystem.DirectoryExists(用户数据文件夹路径) Then FileIO.FileSystem.CreateDirectory(用户数据文件夹路径)
        If FileIO.FileSystem.DirectoryExists(DLC文件夹路径) Then FileIO.FileSystem.CreateDirectory(用户数据文件夹路径)
        If FileIO.FileSystem.DirectoryExists(插件文件夹路径) Then FileIO.FileSystem.CreateDirectory(用户数据文件夹路径)
        If FileIO.FileSystem.DirectoryExists(浏览器缓存路径) Then FileIO.FileSystem.CreateDirectory(用户数据文件夹路径)
    End Sub

    Public Shared ReadOnly 用户数据文件夹路径 As String = Application.StartupPath & "\UserData"

    Public Shared ReadOnly 设置文件存储路径 As String = Application.StartupPath & "\UserData\Settings"
    Public Shared ReadOnly 安装程序更新下载文件路径 As String = Application.StartupPath & "\UserData\SMUI 6 Installer.exe"

    Public Shared ReadOnly DLC文件夹路径 As String = Application.StartupPath & "\UserData\DLC"
    Public Shared ReadOnly 插件文件夹路径 As String = Application.StartupPath & "\UserData\Plugin"
    Public Shared ReadOnly 浏览器缓存路径 As String = Application.StartupPath & "\UserData\WebCache"



End Class
