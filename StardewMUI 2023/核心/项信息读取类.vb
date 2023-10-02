
Imports System.IO
Imports Microsoft.VisualBasic.FileIO.FileSystem

Public Class 项信息读取类
    Public 安装状态 As 公共对象.安装状态枚举 = 公共对象.安装状态枚举.未知

    Public 名称 As New List(Of String)
    Public 作者 As New List(Of String)
    Public 版本 As New List(Of String)

    Public 已安装版本 As New List(Of String)
    Public 最低SMAPI版本 As New List(Of String)
    Public 描述 As New List(Of String)
    Public UniqueID As New List(Of String)
    Public NexusID As New List(Of String)
    Public ChuckleFishID As New List(Of String)
    Public GitHub As New List(Of String)
    Public ModDrop As New List(Of String)

    Public 内容包依赖 As New Dictionary(Of String, String)
    Public 其他依赖项 As New Dictionary(Of String, 其他依赖项类型单片结构)

    Public 未安装的文件夹 As New List(Of String)
    Public 未复制的文件夹 As New List(Of String)
    Public 未替换的文件 As New List(Of String)
    Public 未复制的文件 As New List(Of String)

    Public 错误信息 As String = ""


    Public Structure 其他依赖项类型单片结构
        Public 依赖项必须性 As Boolean
        Public 依赖项最低版本号 As String
    End Structure

    Public Sub Reset()
        安装状态 = 公共对象.安装状态枚举.未知
        名称.Clear()
        作者.Clear()
        版本.Clear()
        已安装版本.Clear()
        最低SMAPI版本.Clear()
        描述.Clear()
        UniqueID.Clear()
        NexusID.Clear()
        ChuckleFishID.Clear()
        GitHub.Clear()
        ModDrop.Clear()
        内容包依赖.Clear()
        其他依赖项.Clear()
        未安装的文件夹.Clear()
        未复制的文件夹.Clear()
        未替换的文件.Clear()
        未复制的文件.Clear()
        错误信息 = ""
    End Sub

    Public Sub 读取项信息(项路径 As String, 计算类型 As 公共对象.项数据计算类型枚举, Optional 游戏路径 As String = "")
        错误信息 = ""
        If DirectoryExists(项路径) = False Then 错误信息 = "项不存在：" & 项路径 : Exit Sub
        If FileExists(CombinePath(项路径, "Code")) = False Then 错误信息 = "项未配置：" & 项路径 : Exit Sub
        If 计算类型.InstallStatus = True Or 计算类型.InstalledVersion = True Or 计算类型.All = True Then
            If 游戏路径 = "" Then 错误信息 = "此计算类型需要提供游戏路径" : Exit Sub
            If DirectoryExists(项路径) = False Then 错误信息 = "给定的游戏路径不存在：" & 游戏路径 : Exit Sub
        End If

        Try
            Dim 安装命令数据 As New List(Of String)
            Using reader As New StringReader(ReadAllText(CombinePath(项路径, "Code")))
                Dim L1 As String
                Do
                    L1 = reader.ReadLine()
                    If L1 IsNot Nothing Then 安装命令数据.Add(L1)
                Loop While L1 IsNot Nothing
            End Using

            For i = 0 To 安装命令数据.Count - 1
                If Replace(安装命令数据(i), " ", "") Is Nothing Then Continue For
                Dim 当前行数据 As String = Replace(安装命令数据(i), " ", "").ToUpper
                Select Case 当前行数据
                    Case "CDCD", "CDCP"
                        If i = 当前行数据.Length - 1 Then Continue For
                        i += 1
                        If 计算类型.InstallStatus = True Then 处理CDCD命令的安装判断(安装状态, 当前行数据(i + 1), 游戏路径)







                End Select

            Next

            错误信息 = ""
        Catch ex As Exception
            错误信息 = ex.Message
        End Try

    End Sub

    Sub 处理CDCD命令的安装判断(ByRef 要写入的安装状态 As 公共对象.安装状态枚举, 参数 As String, 游戏路径 As String)
        If DirectoryExists(CombinePath(CombinePath(游戏路径, "Mods"), 参数)) = True Then
            Select Case 要写入的安装状态
                Case 公共对象.安装状态枚举.安装不完整

                Case 公共对象.安装状态枚举.未安装
                    要写入的安装状态 = 公共对象.安装状态枚举.安装不完整
                Case Else
                    要写入的安装状态 = 公共对象.安装状态枚举.已安装
            End Select
        Else
            Select Case 要写入的安装状态
                Case 公共对象.安装状态枚举.安装不完整
                    Exit Select
                Case 公共对象.安装状态枚举.已安装
                    要写入的安装状态 = 公共对象.安装状态枚举.安装不完整
                Case Else
                    要写入的安装状态 = 公共对象.安装状态枚举.未安装
            End Select
            未安装的文件夹.Add(参数)
        End If
    End Sub





End Class
