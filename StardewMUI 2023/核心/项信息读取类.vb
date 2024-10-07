
Imports System.IO
Imports System.Text
Imports System.Text.RegularExpressions
Imports Microsoft.VisualBasic.FileIO.FileSystem
Imports Newtonsoft.Json.Linq

Public Class 项信息读取类

    Public Shared Property 安装状态字典 As New Dictionary(Of String, String)

    Public Shared Sub 初始化安装状态字典()
        安装状态字典.Add("UnKnow", "未知")
        安装状态字典.Add("NoConfigured", "未配置")
        安装状态字典.Add("Installed", "已安装")
        安装状态字典.Add("UnInstalled", "未安装")
        安装状态字典.Add("Incomplete", "安装不完整")
        安装状态字典.Add("FolderCopied", "文件夹已复制")
        安装状态字典.Add("FolderNoCopied", "文件夹未复制")
        安装状态字典.Add("IncompleteFolderCopied", "文件夹部分复制")
        安装状态字典.Add("Additional", "附加内容")
        安装状态字典.Add("FileInstalled", "文件已安装")
        安装状态字典.Add("FileUnInstalled", "文件未安装")
        安装状态字典.Add("FileIncomplete", "文件部分安装")
        安装状态字典.Add("FileInstalledVerified", "文件已安装 (验证)")
        安装状态字典.Add("FileInstalledVerifyfailed", "文件未安装 (验证)")
        安装状态字典.Add("FolderMissing", "源文件夹丢失")
        安装状态字典.Add("FileMissing", "源文件丢失")
        安装状态字典.Add("File", "不带判断的文件")
        安装状态字典.Add("CoverContent", "覆盖 Content")
        安装状态字典.Add("MissingCalculationProgram", "缺少判断程序")
    End Sub

    Public Structure 项数据计算类型结构
        Dim 全部 As Boolean
        Dim 安装状态 As Boolean
        Dim 名称 As Boolean
        Dim 作者 As Boolean
        Dim 版本 As Boolean
        Dim 已安装版本 As Boolean
        Dim 最低SMAPI版本 As Boolean
        Dim 描述 As Boolean
        Dim UniqueID As Boolean
        Dim 更新键 As Boolean
        Dim 内容包依赖 As Boolean
        Dim 其他依赖项 As Boolean
    End Structure

    Public 安装状态 As String = ""

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
    Public CurseForge As New List(Of String)

    Public 内容包依赖 As New Dictionary(Of String, 内容包依赖类型单片结构)
    Public 其他依赖项 As New Dictionary(Of String, 其他依赖项类型单片结构)

    Public 未安装的文件夹 As New List(Of String)
    Public 未复制的文件夹 As New List(Of String)
    Public 未安装的文件 As New List(Of String)

    Public 错误信息 As String = ""

    Public Structure 其他依赖项类型单片结构
        Public 依赖项必须性 As Boolean
        Public 依赖项最低版本号 As String
    End Structure

    Public Structure 内容包依赖类型单片结构
        Public 最低版本号 As String
    End Structure

    Public Sub 重置()
        安装状态 = "UnKnow"
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
        CurseForge.Clear()
        内容包依赖.Clear()
        其他依赖项.Clear()
        未安装的文件夹.Clear()
        未复制的文件夹.Clear()
        未安装的文件.Clear()
        错误信息 = ""
    End Sub

    Public Sub 读取项信息(项路径 As String, 计算类型 As 项数据计算类型结构, Optional 游戏路径 As String = "")
        重置()
        错误信息 = ""
        If DirectoryExists(项路径) = False Then 错误信息 = "项不存在：" & 项路径 : Exit Sub
        If FileExists(CombinePath(项路径, "Code2")) = False Then
            错误信息 = "项未配置：" & 项路径
            Exit Sub
        End If
        If 计算类型.安装状态 = True Or 计算类型.已安装版本 = True Or 计算类型.全部 = True Then
            If 游戏路径 = "" Then 错误信息 = "此计算类型需要提供游戏路径" : Exit Sub
            If DirectoryExists(项路径) = False Then 错误信息 = "给定的游戏路径不存在：" & 游戏路径 : Exit Sub
        End If

        Try
            Dim 安装规划数据 As New List(Of KeyValuePair(Of String, String))
            键值对IO操作.读取键值对文件到列表(安装规划数据, Path.Combine(项路径, "Code2"))
            For i = 0 To 安装规划数据.Count - 1
                Select Case 安装规划数据(i).Key.Trim
                    Case "CD-D-MODS"

                        If 安装状态 = "MissingCalculationProgram" Then GoTo jx1
                        If 计算类型.安装状态 = True Then
                            If DirectoryExists(Path.Combine(游戏路径, "Mods", 安装规划数据(i).Value)) Then
                                Select Case 安装状态
                                    Case "UnInstalled"
                                        安装状态 = "Incomplete"
                                    Case Else
                                        安装状态 = "Installed"
                                End Select
                            Else
                                Select Case 安装状态
                                    Case "Installed"
                                        安装状态 = "Incomplete"
                                    Case Else
                                        安装状态 = "UnInstalled"
                                End Select
                                未安装的文件夹.Add(安装规划数据(i).Value)
                            End If
                        End If
jx1:
                        Dim 清单文件对象 As New 搜索文件类
                        清单文件对象.搜索清单文件(CombinePath(项路径, 安装规划数据(i).Value))
                        If 清单文件对象.错误信息 <> "" Then
                            错误信息 = 清单文件对象.错误信息 : Exit Sub
                        End If

                        For 清单文件集合索引 = 0 To 清单文件对象.文件绝对路径集合.Count - 1
                            Dim a As String = ReadAllText(Path.Combine(项路径, 安装规划数据(i).Value, 清单文件对象.文件绝对路径集合(清单文件集合索引)))
                            Dim JsonData As JObject = JObject.Parse(a)

                            If 计算类型.名称 Or 计算类型.全部 Then
                                Dim str1 As String = JsonData.GetValue("Name", StringComparison.OrdinalIgnoreCase)?.ToString
                                If str1 <> "" Then
                                    If 名称.Contains(str1) = False Then 名称.Add(str1)
                                Else
                                    Continue For
                                End If
                            End If

                            If 计算类型.作者 Or 计算类型.全部 Then
                                Dim str1 As String = JsonData.GetValue("Author", StringComparison.OrdinalIgnoreCase)?.ToString
                                If str1 <> "" Then If 作者.Contains(str1) = False Then 作者.Add(str1)
                            End If

                            If 计算类型.版本 Or 计算类型.全部 Then
                                Dim str1 As String = JsonData.GetValue("Version", StringComparison.OrdinalIgnoreCase)?.ToString
                                If InStr(str1, "MajorVersion") > 0 Then str1 = 从JSON读取语义版本号(str1)
                                If str1 <> "" Then If 版本.Contains(str1) = False Then 版本.Add(str1)
                            End If

                            If 计算类型.已安装版本 Or 计算类型.全部 Then
                                Dim p1 As String = Path.Combine(游戏路径, "Mods")
                                Dim p2 As String = 项路径.Replace("\\", "\")
                                Dim p3 As String = 清单文件对象.文件绝对路径集合(清单文件集合索引).Replace("\\", "\")
                                Dim p4 As String = p1 & "\" & p3.Replace(p2, "")
                                If FileExists(p4) Then
                                    Dim b As String = ReadAllText(p4)
                                    Dim JsonData2 As JObject = JObject.Parse(b)
                                    Dim str1 As String = JsonData2.GetValue("Version", StringComparison.OrdinalIgnoreCase)?.ToString
                                    If str1 <> "" Then If 已安装版本.Contains(str1) = False Then 已安装版本.Add(str1)
                                End If
                            End If

                            If 计算类型.最低SMAPI版本 Or 计算类型.全部 Then
                                Dim str1 As String = JsonData.GetValue("MinimumApiVersion", StringComparison.OrdinalIgnoreCase)?.ToString
                                If str1 <> "" Then If 最低SMAPI版本.Contains(str1) = False Then 最低SMAPI版本.Add(str1)
                            End If

                            If 计算类型.描述 Or 计算类型.全部 Then
                                Dim str1 As String = JsonData.GetValue("Description", StringComparison.OrdinalIgnoreCase)?.ToString
                                If str1 <> "" Then If 描述.Contains(str1) = False Then 描述.Add(str1)
                            End If

                            If 计算类型.UniqueID Or 计算类型.全部 Then
                                Dim str1 As String = JsonData.GetValue("UniqueID", StringComparison.OrdinalIgnoreCase)?.ToString
                                If str1 <> "" Then If UniqueID.Contains(str1) = False Then UniqueID.Add(str1)
                            End If

                            If (计算类型.更新键 Or 计算类型.全部) And JsonData.GetValue("UpdateKeys", StringComparison.OrdinalIgnoreCase) IsNot Nothing Then
                                Dim UpdateKeys As JArray = JsonData.GetValue("UpdateKeys", StringComparison.OrdinalIgnoreCase)
                                For Each uk As JValue In UpdateKeys
                                    If InStr(uk.ToString.ToLower, "nexus") > 0 Then
                                        Dim match As Match = Regex.Match(uk.ToString, ":\s*(\w+)")
                                        If match.Success AndAlso Not NexusID.Contains(match.Groups(1).Value) Then NexusID.Add(match.Groups(1).Value)
                                    ElseIf InStr(uk.ToString.ToLower, "moddrop") > 0 Then
                                        Dim match As Match = Regex.Match(uk.ToString, ":\s*(\w+)")
                                        If match.Success AndAlso Not ModDrop.Contains(match.Groups(1).Value) Then ModDrop.Add(match.Groups(1).Value)
                                    ElseIf InStr(uk.ToString.ToLower, "github") > 0 Then
                                        Dim str1 As String = 共享方法.获取模组更新平台地址(uk.ToString, "github")
                                        If Right(str1, 1) = "}" Then str1 = str1.Substring(0, str1.Length - 1)
                                        If str1 <> "" Then If Not GitHub.Contains(str1) Then GitHub.Add(str1)
                                    ElseIf InStr(uk.ToString.ToLower, "curseforge") > 0 Then
                                        Dim match As Match = Regex.Match(uk.ToString, ":\s*(\w+)")
                                        If match.Success AndAlso Not CurseForge.Contains(match.Groups(1).Value) Then CurseForge.Add(match.Groups(1).Value)
                                    ElseIf InStr(uk.ToString.ToLower, "chucklefish") > 0 Then
                                        Dim match As Match = Regex.Match(uk.ToString, ":\s*(\w+)")
                                        If match.Success AndAlso Not ChuckleFishID.Contains(match.Groups(1).Value) Then ChuckleFishID.Add(match.Groups(1).Value)
                                    End If
                                Next
                            End If

                            If 计算类型.内容包依赖 Or 计算类型.全部 Then
                                Dim ContentPackFor As JObject = JsonData.GetValue("ContentPackFor", StringComparison.OrdinalIgnoreCase)
                                If ContentPackFor IsNot Nothing Then
                                    Dim str1 As String = ContentPackFor.GetValue("UniqueID", StringComparison.OrdinalIgnoreCase)?.ToString
                                    Dim str2 As String = ContentPackFor.GetValue("MinimumVersion", StringComparison.OrdinalIgnoreCase)?.ToString
                                    If Not String.IsNullOrEmpty(str1) AndAlso Not 内容包依赖.ContainsKey(str1) Then
                                        内容包依赖.Add(str1, New 内容包依赖类型单片结构 With {.最低版本号 = str2})
                                    End If
                                End If
                            End If


                            If 计算类型.其他依赖项 Or 计算类型.全部 Then
                                Dim Dependencies As JArray = JsonData.GetValue("Dependencies", StringComparison.OrdinalIgnoreCase)
                                If Dependencies IsNot Nothing Then
                                    For Each dependency As JObject In Dependencies
                                        Dim str1 As String = dependency.GetValue("UniqueID", StringComparison.OrdinalIgnoreCase)?.ToString
                                        If str1 = "" Then Continue For
                                        Dim str2 As String = If(str1 <> "", dependency.GetValue("IsRequired", StringComparison.OrdinalIgnoreCase)?.ToString.ToLower, "true")
                                        Dim value As 其他依赖项类型单片结构 = Nothing
                                        If Not 其他依赖项.TryGetValue(str1, value) Then
                                            其他依赖项.Add(str1, New 其他依赖项类型单片结构 With {.依赖项必须性 = str2 = "true", .依赖项最低版本号 = dependency.GetValue("MinimumVersion", StringComparison.OrdinalIgnoreCase)?.ToString})
                                        Else
                                            Dim 现有最低版本号 As String = value.依赖项最低版本号
                                            Dim 新的最低版本号 As String = dependency.GetValue("MinimumVersion", StringComparison.OrdinalIgnoreCase)?.ToString
                                            If value.依赖项必须性 = False And str2 = "true" Then
                                                If 共享方法.CompareVersion(现有最低版本号, 新的最低版本号) > 0 Then
                                                    其他依赖项(str1) = New 其他依赖项类型单片结构 With {.依赖项必须性 = True, .依赖项最低版本号 = 新的最低版本号}
                                                Else
                                                    其他依赖项(str1) = New 其他依赖项类型单片结构 With {.依赖项必须性 = True, .依赖项最低版本号 = 现有最低版本号}
                                                End If
                                            End If
                                        End If
                                    Next
                                End If

                            End If
                        Next

                    Case "CD-D-MODS-COVER"

                        If 计算类型.安装状态 = False Then Continue For
                        If 安装状态 = "UnKnow" Then 安装状态 = "Additional"

                    Case "CD-D-CONTENT"

                        If 计算类型.安装状态 = False Then Continue For
                        If 安装状态 = "UnKnow" Then 安装状态 = "CoverContent"

                    Case "CD-D-ROOT"

                        If 计算类型.安装状态 = False Then Continue For

                        Dim x1, x2 As String
                        Dim x3 As String() = 安装规划数据(i).Value.Split("|")
                        x1 = x3(0) : x2 = x3(1)
                        Select Case 安装状态
                            Case "UnKnow"
                                If DirectoryExists(CombinePath(游戏路径, x2)) Then
                                    安装状态 = "FolderCopied"
                                Else
                                    安装状态 = "FolderNoCopied"
                                    未复制的文件夹.Add(x2)
                                End If
                            Case "FolderCopied"
                                If Not DirectoryExists(CombinePath(游戏路径, x2)) Then
                                    安装状态 = "IncompleteFolderCopied"
                                    未复制的文件夹.Add(x2)
                                End If
                        End Select

                    Case "CD-F"

                        If 计算类型.安装状态 = False Then Continue For
                        Dim 是否需要判断, 是否需要验证, 文件, 目标位置 As String
                        Dim x3 As String() = 安装规划数据(i).Value.Split("|")
                        是否需要判断 = x3(1) : 是否需要验证 = x3(2) : 文件 = x3(3) : 目标位置 = x3(4)
                        If 是否需要判断.Trim.Equals("False", StringComparison.CurrentCultureIgnoreCase) Then
                            If 安装状态 = "UnKnow" Then 安装状态 = "File"
                            Continue For
                        End If
                        If Not FileExists(Path.Combine(项路径, 文件)) Then
                            安装状态 = "FileMissing"
                            Continue For
                        End If
                        If Not FileExists(Path.Combine(游戏路径, 目标位置)) Then
                            Select Case 安装状态
                                Case "UnKnow"
                                    安装状态 = "FileUnInstalled"
                                Case "FileInstalled"
                                    安装状态 = "FileIncomplete"
                            End Select
                            未安装的文件.Add(目标位置)
                        Else
                            Select Case 安装状态
                                Case "UnKnow"
                                    安装状态 = "FileInstalled"
                            End Select
                        End If
                        If 是否需要验证.Trim.Equals("true", StringComparison.CurrentCultureIgnoreCase) And (安装状态 = "FileInstalled" Or 安装状态 = "FileInstalledVerified") Then
                            Dim a1 As String = 共享方法.CalculateSHA256(Path.Combine(项路径, 文件))
                            Dim a2 As String = 共享方法.CalculateSHA256(Path.Combine(游戏路径, 目标位置))
                            If a1 = a2 Then
                                If 安装状态 = "FileInstalled" Then 安装状态 = "FileInstalledVerified"
                            Else
                                If 安装状态 = "FileInstalled" Then 安装状态 = "FileInstalledVerifyfailed"
                                未安装的文件.Add(目标位置)
                            End If
                        End If

                    Case "CR-Check-EXIST", "CR-IN-MODS-VER", "CR-UN", "CR-SHELL", "CR-MSGBOX", "CORE-CLASS"
                    Case Else
                        Dim value As DE1 = Nothing
                        If 第三方安装判断执行字典.TryGetValue(安装规划数据(i).Key, value) Then
                            Dim operation As DE1 = value
                            Dim ba1 = operation.Invoke(项路径, 游戏路径, 安装规划数据(i).Value.Split("|"), 计算类型, 安装状态)
                            If ba1 <> "" Then
                                安装状态 = ba1
                            End If
                        Else
                            安装状态 = "MissingCalculationProgram"
                            DebugPrint(安装规划数据(i).Key & " 的第三方安装判断程序未找到，是否缺失相关插件？", Color1.红色)
                        End If
                End Select

            Next

            For i = 0 To UniqueID.Count - 1
                其他依赖项.Remove(UniqueID(i))
            Next

            错误信息 = ""
        Catch ex As Exception
            错误信息 = ex.Message
        End Try

    End Sub

    Public Shared Property 第三方安装判断执行字典 As New Dictionary(Of String, DE1)
    ''' <summary>
    ''' 你需要创建一个与此委托的参数完全相同的 Function，这个方法只有一个规划的数据
    ''' <para></para>
    ''' 程序会将对应的值传递到参数上，以便你可以编写自己的安装判断程序
    ''' <para></para>
    ''' 注意不要与其他类文件中的 DE1 委托混淆
    ''' </summary>
    ''' <param name="项路径"></param>
    ''' <param name="游戏路径"></param>
    ''' <param name="参数列表"></param>
    ''' <param name="计算类型"></param>
    ''' <returns>你需要返回一个 安装状态Key 让程序知道要把模组项的安装状态显示成什么</returns>
    Delegate Function DE1(项路径 As String, 游戏路径 As String, 参数列表 As String(), 计算类型 As 项数据计算类型结构, 当前的安装状态 As String) As String

    Public Shared Function 从JSON读取语义版本号(JsonTextInVersion As String, Optional ByRef ErrorString As String = "") As String
        Try
            Dim JsonData As JObject = JObject.Parse(JsonTextInVersion)
            Dim MajorVersion As String = JsonData.GetValue("MajorVersion", StringComparison.OrdinalIgnoreCase).ToString
            Dim MinorVersion As String = JsonData.GetValue("MinorVersion", StringComparison.OrdinalIgnoreCase).ToString
            Dim PatchVersion As String = JsonData.GetValue("PatchVersion", StringComparison.OrdinalIgnoreCase).ToString
            Dim Build As String = JsonData.GetValue("Build", StringComparison.OrdinalIgnoreCase).ToString

            If String.IsNullOrEmpty(MajorVersion) Then Return ""

            Dim str2 As New StringBuilder(MajorVersion)
            If Not String.IsNullOrEmpty(MinorVersion) Then str2.Append("."c).Append(MinorVersion)
            If Not String.IsNullOrEmpty(PatchVersion) Then str2.Append("."c).Append(PatchVersion)
            If Not String.IsNullOrEmpty(Build) Then str2.Append("."c).Append(Build)

            Return str2.ToString()
        Catch ex As Exception
            ErrorString = ex.Message
            Return ""
        End Try
    End Function







End Class
