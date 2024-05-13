Imports System.IO
Imports System.Reflection

Public Class DLC
    Public Class DLC解锁标记
        Public Shared Property CustomInputExtension As Boolean = False
        Public Shared Property SkinLoader As Boolean = False
        Public Shared Property NewItemExtension As Boolean = False
        Public Shared Property CheckUpdatesExtension As Boolean = False
        Public Shared Property DistributionExtension As Boolean = False
        Public Shared Property SeasonPass2023 As Boolean = False
        Public Shared Property UpdateModItemExtension As Boolean = False

    End Class

    Public Shared Property 插件数据 As List(Of 插件数据单片结构)

    Public Structure 插件数据单片结构
        Public 插件文件路径 As String
        Public 插件程序集名称 As String
        Public 插件处理器架构 As String
        Public 插件作者名称 As String
        Public 插件版本号 As String
        Public 插件Entry加载状态 As String
    End Structure

    Public Shared Sub 初始化()
        加载单个DLC("SMUI6.DLC1.CustomInputExtension.dll")
        加载单个DLC("SMUI6.DLC3.NewItemExtension.dll")
        加载单个DLC("SMUI6.DLC6.UpdateModItemExtension.dll")
        加载单个DLC("SMUI6.SeasonPass2023.dll")
        If DLC解锁标记.CustomInputExtension Then
            Form1.ListView9.Items(0).SubItems(1).Text = "已激活"
            Form1.ListView9.Items(0).ForeColor = Color1.绿色
        End If
        If DLC解锁标记.NewItemExtension Then
            Form1.ListView9.Items(2).SubItems(1).Text = "已激活"
            Form1.ListView9.Items(2).ForeColor = Color1.绿色
        End If
        If DLC解锁标记.UpdateModItemExtension Then
            Form1.ListView9.Items(6).SubItems(1).Text = "已激活"
            Form1.ListView9.Items(6).ForeColor = Color1.绿色
        End If
        If DLC解锁标记.SeasonPass2023 Then
            DLC解锁标记.CustomInputExtension = True
            DLC解锁标记.SkinLoader = True
            DLC解锁标记.NewItemExtension = True
            DLC解锁标记.CheckUpdatesExtension = True
            Form1.ListView9.Items(0).SubItems(1).Text = "已激活"
            Form1.ListView9.Items(0).ForeColor = Color1.绿色
            Form1.ListView9.Items(1).SubItems(1).Text = "已激活"
            Form1.ListView9.Items(1).ForeColor = Color1.绿色
            Form1.ListView9.Items(2).SubItems(1).Text = "已激活"
            Form1.ListView9.Items(2).ForeColor = Color1.绿色
            Form1.ListView9.Items(3).SubItems(1).Text = "已激活"
            Form1.ListView9.Items(3).ForeColor = Color1.绿色
            Form1.ListView9.Items(4).SubItems(1).Text = "已激活"
        End If

    End Sub

    Public Shared Sub 加载单个DLC(文件名 As String)
        Try
            If Not FileIO.FileSystem.FileExists(Path.Combine(设置.DLC文件夹路径, 文件名)) Then
                Exit Sub
            End If
            Dim 程序集 As Assembly = Assembly.LoadFile(Path.Combine(设置.DLC文件夹路径, 文件名))
            'Dim 系统接口程序 As ShellFile = ShellFile.FromFilePath(Path.Combine(设置.DLC文件夹路径, 文件名))
            Dim 获取类型 As Type = 程序集.GetType(程序集.GetName.Name & ".Entry")
            Dim 创建实例 As Object = Activator.CreateInstance(获取类型)
            Dim 实现方法 As MethodInfo = 获取类型.GetMethod("Entry")
            实现方法.Invoke(创建实例, Array.Empty(Of Object)())
            DebugPrint($"已加载 DLC：{文件名}", Color1.绿色)
        Catch ex As Exception
            DebugPrint($"加载 DLC 错误，对象：{ex.Source} 错误信息：{ex.Message} TargetSite：{ex.TargetSite.Name}", Color1.红色)
        End Try
    End Sub








End Class
