Imports System.IO
Imports System.Reflection
Imports Microsoft.WindowsAPICodePack.Shell

Public Class DLC
    Public Class DLC解锁标记
        Public Shared Property CustomInputExtension As Boolean = False
        Public Shared Property SkinLoader As Boolean = False
        Public Shared Property NewItemExtension As Boolean = False
        Public Shared Property CheckUpdatesExtension As Boolean = False
        Public Shared Property DistributionExtension As Boolean = False
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
        If DLC解锁标记.CustomInputExtension Then Form1.ListView9.Items(0).SubItems(1).Text = "已激活"


    End Sub

    Public Shared Sub 加载单个DLC(文件名 As String)
        Try
            If Not FileIO.FileSystem.FileExists(Path.Combine(设置.DLC文件夹路径, 文件名)) Then
                DebugPrint($"指定的 DLC 文件不存在：{文件名}", Color1.白色)
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
