
Imports System.IO
Imports Microsoft.VisualBasic.FileIO.FileSystem
Imports Newtonsoft.Json
Imports Newtonsoft.Json.Linq

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

    Public 内容包依赖 As New Dictionary(Of String, 内容包依赖类型单片结构)
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

    Public Structure 内容包依赖类型单片结构
        Public 最低版本号 As String
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
        If 计算类型.安装状态 = True Or 计算类型.已安装版本 = True Or 计算类型.全部 = True Then
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

                        If 计算类型.安装状态 = True Then 处理CDCD命令的安装判断(安装状态, 安装命令数据(i + 1), 游戏路径)

                        Dim 清单文件对象 As New 搜索文件类
                        清单文件对象.搜索清单文件(CombinePath(项路径, 安装命令数据(i + 1)))
                        If 清单文件对象.错误信息 <> "" Then
                            错误信息 = 清单文件对象.错误信息 : Exit Sub
                        End If

                        For 清单文件集合索引 = 0 To 清单文件对象.文件绝对路径集合.Count - 1
                            Dim a As String = ReadAllText(Path.Combine(项路径, 安装命令数据(i + 1), 清单文件对象.文件绝对路径集合(清单文件集合索引)))
                            Dim JsonData As Object = CType(JsonConvert.DeserializeObject(a), JObject)

                            If 计算类型.名称 Or 计算类型.全部 Then
                                If JsonData.item("Name") IsNot Nothing Then
                                    Dim str1 As String = JsonData.item("Name").ToString
                                    If 名称.Contains(str1) = False Then 名称.Add(str1)
                                Else Continue For
                                End If
                            End If

                            If 计算类型.作者 Or 计算类型.全部 Then
                                If JsonData.item("Author") IsNot Nothing Then
                                    Dim str1 As String = JsonData.item("Author").ToString
                                    If str1 <> "" Then If 作者.Contains(str1) = False Then 作者.Add(str1)
                                End If
                            End If

                            If 计算类型.版本 Or 计算类型.全部 Then
                                If JsonData.item("Version") IsNot Nothing Then
                                    Dim str1 As String = JsonData.item("Version").ToString
                                    If InStr(str1, "MajorVersion") > 0 Then str1 = 从JSON读取语义版本号(str1)
                                    If str1 <> "" Then If 版本.Contains(str1) = False Then 版本.Add(str1)
                                End If
                            End If

                            If 计算类型.已安装版本 Or 计算类型.全部 Then
                                Dim p1 As String = Path.Combine(游戏路径, "Mods")
                                Dim p2 As String = Path.Combine(p1, 安装命令数据(i + 1))
                                Dim p3 As String = Path.Combine(p2, 清单文件对象.文件绝对路径集合(清单文件集合索引))
                                If FileExists(p3) Then
                                    Dim b As String = ReadAllText(p3)
                                    Dim JsonData2 As Object = CType(JsonConvert.DeserializeObject(b), JObject)
                                    Dim str1 As String = If(JsonData2.item("Version") IsNot Nothing, JsonData2.item("Version").ToString, "")
                                    If str1 <> "" Then If 已安装版本.Contains(str1) = False Then 已安装版本.Add(str1)
                                End If
                            End If

                            If 计算类型.最低SMAPI版本 Or 计算类型.全部 Then
                                If JsonData.item("MinimumApiVersion") IsNot Nothing Then
                                    Dim str1 As String = JsonData.item("MinimumApiVersion").ToString
                                    If str1 <> "" Then If 最低SMAPI版本.Contains(str1) = False Then 最低SMAPI版本.Add(str1)
                                End If
                            End If

                            If 计算类型.描述 Or 计算类型.全部 Then
                                If JsonData.item("Description") IsNot Nothing Then
                                    Dim str1 As String = JsonData.item("Description").ToString
                                    If str1 <> "" Then If 描述.Contains(str1) = False Then 描述.Add(str1)
                                End If
                            End If

                            If 计算类型.UniqueID Or 计算类型.全部 Then
                                If JsonData.item("UniqueID") IsNot Nothing Then
                                    Dim str1 As String = JsonData.item("UniqueID").ToString
                                    If str1 <> "" Then If UniqueID.Contains(str1) = False Then UniqueID.Add(str1)
                                End If
                            End If

                            If (计算类型.更新键 Or 计算类型.全部) And JsonData.item("UpdateKeys") IsNot Nothing Then
                                For k = 0 To JsonData.item("UpdateKeys").Count - 1
                                    If InStr(JsonData.item("UpdateKeys").item(k).ToString.ToLower, "nexus") > 0 Then
                                        Dim str1 = 共享方法.获取模组更新ID(JsonData.item("UpdateKeys").item(k).ToString.ToLower, "nexus")
                                        If IsNumeric(str1) Then If str1 > 0 Then If NexusID.Contains(str1) = False Then NexusID.Add(str1) : Continue For
                                    ElseIf InStr(JsonData.item("UpdateKeys").item(k).ToString.ToLower, "moddrop") > 0 Then
                                        Dim str1 = 共享方法.获取模组更新平台地址(JsonData.item("UpdateKeys").item(k).ToString, "moddrop")
                                        If str1 <> "" Then If ModDrop.Contains(str1) = False Then ModDrop.Add(str1) : Continue For
                                    ElseIf InStr(JsonData.item("UpdateKeys").item(k).ToString.ToLower, "github") > 0 Then
                                        Dim str1 = 共享方法.获取模组更新平台地址(JsonData.item("UpdateKeys").item(k).ToString, "github")
                                        If str1 <> "" Then If GitHub.Contains(str1) = False Then GitHub.Add(str1) : Continue For
                                    ElseIf InStr(JsonData.item("UpdateKeys").item(k).ToString.ToLower, "chucklefish") > 0 Then
                                        Dim str1 = 共享方法.获取模组更新ID(JsonData.item("UpdateKeys").item(k).ToString.ToLower, "chucklefish")
                                        If IsNumeric(str1) Then If str1 > 0 Then If ChuckleFishID.Contains(str1) = False Then ChuckleFishID.Add(str1)
                                    End If
                                Next
                            End If

                            If 计算类型.内容包依赖 Or 计算类型.全部 Then
                                If JsonData.item("ContentPackFor") IsNot Nothing Then
                                    Dim ContentPackString As String = JsonData("ContentPackFor").Item("UniqueID")?.ToString()
                                    If Not String.IsNullOrEmpty(ContentPackString) AndAlso Not 内容包依赖.ContainsKey(ContentPackString) Then
                                        内容包依赖.Add(ContentPackString, New 内容包依赖类型单片结构 With {.最低版本号 = ""})
                                    End If
                                    Dim minimumVersion As String = JsonData("ContentPackFor").Item("MinimumVersion")?.ToString()
                                    If Not String.IsNullOrEmpty(ContentPackString) Then 内容包依赖(ContentPackString) = New 内容包依赖类型单片结构 With {.最低版本号 = minimumVersion}
                                End If
                            End If

                            If 计算类型.其他依赖项 Or 计算类型.全部 Then
                                If JsonData.item("Dependencies") IsNot Nothing Then
                                    For int2 = 0 To JsonData.item("Dependencies").Count - 1
                                        Dim dependency = JsonData.item("Dependencies")(int2)
                                        If dependency("UniqueID") IsNot Nothing Then
                                            Dim DependenciesString As String = dependency("UniqueID").ToString
                                            If Not 其他依赖项.ContainsKey(DependenciesString) Then
                                                Dim isRequiredValue = If(dependency("IsRequired") IsNot Nothing, dependency("IsRequired").ToString.ToLower.Replace(" ", ""), "true")
                                                其他依赖项(DependenciesString) = New 其他依赖项类型单片结构 With {.依赖项必须性 = (isRequiredValue = "true"), .依赖项最低版本号 = If(dependency("MinimumVersion") IsNot Nothing, dependency("MinimumVersion").ToString, Nothing)}
                                            End If
                                        End If
                                    Next
                                End If
                            End If

                        Next
                        i += 1

                    Case "CDGCD"



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
                Case 公共对象.安装状态枚举.未安装
                    要写入的安装状态 = 公共对象.安装状态枚举.安装不完整
                Case Else
                    要写入的安装状态 = 公共对象.安装状态枚举.已安装
            End Select
        Else
            Select Case 要写入的安装状态
                Case 公共对象.安装状态枚举.已安装
                    要写入的安装状态 = 公共对象.安装状态枚举.安装不完整
                Case Else
                    要写入的安装状态 = 公共对象.安装状态枚举.未安装
            End Select
            未安装的文件夹.Add(参数)
        End If
    End Sub





    Public Shared Function 从JSON读取语义版本号(ByVal JsonTextInVersion As String, Optional ByRef ErrorString As String = "") As String
        Try
            Dim JsonData As Object = CType(JsonConvert.DeserializeObject(JsonTextInVersion), JObject)
            If JsonData.item("MajorVersion") IsNot Nothing Then
                Dim MajorVersion As String = JsonData.item("MajorVersion").ToString
                Dim MinorVersion As String = ""
                Dim PatchVersion As String = ""
                Dim Build As String = ""
                If JsonData.item("MinorVersion") IsNot Nothing Then
                    MinorVersion = JsonData.item("MinorVersion").ToString
                End If
                If JsonData.item("PatchVersion") IsNot Nothing Then
                    PatchVersion = JsonData.item("PatchVersion").ToString
                End If
                If JsonData.item("Build") IsNot Nothing Then
                    Build = JsonData.item("Build").ToString
                End If
                Dim str2 As String = MajorVersion
                If MinorVersion <> "" Then
                    str2 &= "." & MinorVersion
                Else
                    Return str2 : Exit Function
                End If
                If PatchVersion <> "" Then
                    str2 &= "." & PatchVersion
                Else
                    Return str2 : Exit Function
                End If
                If Build <> "" Then
                    str2 &= "." & Build
                End If
                Return str2
            Else
                Return ""
            End If
        Catch ex As Exception
            ErrorString = ex.Message
            Return ""
        End Try
    End Function


End Class
