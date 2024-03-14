
Imports Microsoft.VisualBasic.FileIO.FileSystem
Imports SMUI6.公共对象

Public Class 任务队列

    Public Shared Property 项路径 As String
    Public Shared Property 游戏路径 As String
    Public Shared Property 游戏备份路径 As String

    Public Shared Property 任务列表 As New List(Of 任务列表结构)
    Public Shared Property 当前正在处理的索引 As Integer
    Public Shared Property 是否关闭config自动保留机制 As Boolean = False
    Public Shared Property 是否允许标准SMAPI模组文件夹套娃放置 As Boolean = False
    Public Shared Property 是否取消了操作 As Boolean = False

    Public Shared Sub 全部数据初始化()
        项路径 = ""
        游戏路径 = 设置.全局设置数据("StardewValleyGamePath")
        游戏备份路径 = 设置.全局设置数据("StardewValleyGameBackupPath")
        任务列表.Clear()
        当前正在处理的索引 = Nothing
        是否关闭config自动保留机制 = False
        是否允许标准SMAPI模组文件夹套娃放置 = False
        是否取消了操作 = False
    End Sub

    Public Shared Sub 全部字典初始化()
        初始化队列键值匹配字典()
        初始化安装操作匹配字典()
        初始化卸载操作匹配字典()
    End Sub

    Public Structure 任务列表结构
        Public 操作类型 As 公共对象.任务队列操作类型枚举
        Public 参数行 As String
    End Structure

    Public Shared Property 队列键值匹配字典 As New Dictionary(Of String, DE1)()
    Delegate Sub DE1()

    Public Shared Sub 初始化队列键值匹配字典()
        队列键值匹配字典.Clear()
        队列键值匹配字典.Add("CD-D-MODS", AddressOf CD1.匹配到_复制文件夹到Mods)
        队列键值匹配字典.Add("CD-D-MODS-COVER", AddressOf CD1.匹配到_覆盖文件夹到Mods)
        队列键值匹配字典.Add("CD-D-ROOT", AddressOf CD1.匹配到_复制文件夹)
        队列键值匹配字典.Add("CD-D-CONTENT", AddressOf CD1.匹配到_覆盖Content)
        队列键值匹配字典.Add("CD-F-ADD", AddressOf CD1.匹配到_新增文件)
        队列键值匹配字典.Add("CD-F-ADD-SHA", AddressOf CD1.匹配到_新增文件并验证)
        队列键值匹配字典.Add("CD-F-REP", AddressOf CD1.匹配到_替换文件)
        队列键值匹配字典.Add("CD-F-NULL", AddressOf CD1.匹配到_替换文件且无检测)
        队列键值匹配字典.Add("CR-IN-D-CHECK", AddressOf CD1.匹配到_安装时检查文件夹的存在)
        队列键值匹配字典.Add("CR-UN-D-CHECK", AddressOf CD1.匹配到_卸载时检查文件夹的存在)
        队列键值匹配字典.Add("CR-IN-F-CHECK", AddressOf CD1.匹配到_安装时检查文件的存在)
        队列键值匹配字典.Add("CR-UN-F-CHECK", AddressOf CD1.匹配到_卸载时检查文件的存在)
        队列键值匹配字典.Add("CR-IN-MODS-VER", AddressOf CD1.匹配到_安装时检查Mods中已安装模组的版本)
        队列键值匹配字典.Add("CR-UN", AddressOf CD1.匹配到_卸载时取消操作)
        队列键值匹配字典.Add("CR-IN-SHELL", AddressOf CD1.匹配到_安装时运行可执行文件)
        队列键值匹配字典.Add("CR-UN-SHELL", AddressOf CD1.匹配到_卸载时运行可执行文件)
        队列键值匹配字典.Add("CR-IN-MSGBOX", AddressOf CD1.匹配到_安装时弹窗)
        队列键值匹配字典.Add("CR-UN-MSGBOX", AddressOf CD1.匹配到_卸载时弹窗)
        队列键值匹配字典.Add("CORE-CLASS", AddressOf CD1.匹配到_声明各种核心功能的启停)
    End Sub

    Public Shared Property 安装规划原文本列表对象 As New List(Of KeyValuePair(Of String, String))

    Public Shared Function 加载安装规划数据() As String
        Try
            If DirectoryExists(项路径) = False Then Return "项不存在：" & 项路径 : Exit Function
            If FileExists(CombinePath(项路径, "Code2")) = False Then Return "项未配置：" & 项路径 : Exit Function
            If 队列键值匹配字典.Count = 0 Then 初始化队列键值匹配字典()
            任务列表.Clear()
            安装规划原文本列表对象.Clear()
            当前正在处理的索引 = 0
            是否关闭config自动保留机制 = False
            是否允许标准SMAPI模组文件夹套娃放置 = False
            键值对IO操作.读取键值对文件到列表(安装规划原文本列表对象, CombinePath(项路径, "Code2"))
            For i = 0 To 安装规划原文本列表对象.Count - 1
                Dim value As DE1 = Nothing
                If 队列键值匹配字典.TryGetValue(安装规划原文本列表对象(i).Key, value) Then
                    当前正在处理的索引 = i
                    Dim operation As DE1 = value
                    operation.Invoke()
                Else
                    DebugPrint(安装规划原文本列表对象(i).Key & " 不是受支持的规划代码，请不要擅自修改 Code2 文件", Color.OrangeRed, True)
                End If
            Next
            Return ""
        Catch ex As Exception
            Return ex.Message
        End Try
    End Function

    Public Shared Property 安装操作匹配字典 As New Dictionary(Of 任务队列操作类型枚举, DE2)()
    Delegate Sub DE2()

    Public Shared Sub 初始化安装操作匹配字典()
        安装操作匹配字典.Add(任务队列操作类型枚举.复制文件夹到Mods, AddressOf CD2.匹配到_复制文件夹到Mods)
        安装操作匹配字典.Add(任务队列操作类型枚举.覆盖文件夹到Mods, AddressOf CD2.匹配到_覆盖文件夹到Mods)
        安装操作匹配字典.Add(任务队列操作类型枚举.复制文件夹, AddressOf CD2.匹配到_复制文件夹)
        安装操作匹配字典.Add(任务队列操作类型枚举.覆盖Content, AddressOf CD2.匹配到_覆盖Content)
        安装操作匹配字典.Add(任务队列操作类型枚举.新增文件, AddressOf CD2.匹配到_新增文件)
        安装操作匹配字典.Add(任务队列操作类型枚举.新增文件并验证, AddressOf CD2.匹配到_新增文件)
        安装操作匹配字典.Add(任务队列操作类型枚举.替换文件, AddressOf CD2.匹配到_替换文件)
        安装操作匹配字典.Add(任务队列操作类型枚举.替换文件且无检测, AddressOf CD2.匹配到_替换文件)
        安装操作匹配字典.Add(任务队列操作类型枚举.安装时检查文件夹的存在, AddressOf CD2.匹配到_安装时检查文件夹的存在)
        安装操作匹配字典.Add(任务队列操作类型枚举.安装时检查文件的存在, AddressOf CD2.匹配到_安装时检查文件的存在)
        安装操作匹配字典.Add(任务队列操作类型枚举.安装时检查Mods中已安装模组的版本, AddressOf CD2.匹配到_安装时检查Mods中已安装模组的版本)
        安装操作匹配字典.Add(任务队列操作类型枚举.安装时运行可执行文件, AddressOf CD2.匹配到_安装时运行可执行文件)
        安装操作匹配字典.Add(任务队列操作类型枚举.安装时弹窗, AddressOf CD2.匹配到_安装时弹窗)
        安装操作匹配字典.Add(任务队列操作类型枚举.声明各种核心功能的启停, AddressOf CD2.匹配到_声明各种核心功能的启停)
    End Sub

    Public Shared Function 执行安装(任务索引 As Integer) As String
        Try
            Dim value As DE2 = Nothing
            If 安装操作匹配字典.TryGetValue(任务列表(任务索引).操作类型, value) Then
                当前正在处理的索引 = 任务索引
                Dim operation As DE2 = value
                operation.Invoke()
            End If
            Return ""
        Catch ex As Exception
            Return ex.Message
        End Try
    End Function

    Public Shared Property 卸载操作匹配字典 As New Dictionary(Of 任务队列操作类型枚举, DE3)()
    Delegate Sub DE3()

    Public Shared Sub 初始化卸载操作匹配字典()
        卸载操作匹配字典.Add(任务队列操作类型枚举.复制文件夹到Mods, AddressOf CD3.匹配到_复制文件夹到Mods)
        卸载操作匹配字典.Add(任务队列操作类型枚举.复制文件夹, AddressOf CD3.匹配到_复制文件夹)
        卸载操作匹配字典.Add(任务队列操作类型枚举.覆盖Content, AddressOf CD3.匹配到_覆盖Content)
        卸载操作匹配字典.Add(任务队列操作类型枚举.新增文件, AddressOf CD3.匹配到_新增文件)
        卸载操作匹配字典.Add(任务队列操作类型枚举.新增文件并验证, AddressOf CD3.匹配到_新增文件)
        卸载操作匹配字典.Add(任务队列操作类型枚举.替换文件, AddressOf CD3.匹配到_替换文件)
        卸载操作匹配字典.Add(任务队列操作类型枚举.替换文件且无检测, AddressOf CD3.匹配到_替换文件)
        卸载操作匹配字典.Add(任务队列操作类型枚举.卸载时检查文件夹的存在, AddressOf CD3.匹配到_卸载时检查文件夹的存在)
        卸载操作匹配字典.Add(任务队列操作类型枚举.卸载时检查文件的存在, AddressOf CD3.匹配到_卸载时检查文件的存在)
        卸载操作匹配字典.Add(任务队列操作类型枚举.卸载时取消操作, AddressOf CD3.匹配到_卸载时取消操作)
        卸载操作匹配字典.Add(任务队列操作类型枚举.卸载时运行可执行文件, AddressOf CD3.匹配到_卸载时运行可执行文件)
        卸载操作匹配字典.Add(任务队列操作类型枚举.卸载时弹窗, AddressOf CD3.匹配到_卸载时弹窗)
    End Sub

    Public Shared Function 执行卸载(任务索引 As Integer) As String
        Try
            Dim value As DE3 = Nothing
            If 卸载操作匹配字典.TryGetValue(任务列表(任务索引).操作类型, value) Then
                当前正在处理的索引 = 任务索引
                Dim operation As DE3 = value
                operation.Invoke()
            End If
            Return ""
        Catch ex As Exception
            Return ex.Message
        End Try
    End Function

    Public Shared Sub 规划检查器运行()
        Dim 参数列表 As New List(Of String)(任务队列.任务列表(任务队列.当前正在处理的索引).参数行.Split("|").ToList)
        For i = 0 To 参数列表.Count - 1
            Select Case 参数列表(i)
                Case "CG-DB"

                Case "Mods-AMD"

            End Select
        Next
    End Sub


End Class
