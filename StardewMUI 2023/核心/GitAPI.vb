﻿Imports Newtonsoft.Json
Imports Newtonsoft.Json.Linq
Imports SMUI6.GitAPI.GitApiObject
Imports System.Net
Imports System.Net.Http

Public Class GitAPI

    Public Class GitApiObject

        Public Enum 开源代码平台
            Gitee = 1
            GitHub = 2
        End Enum

        Public Shared Property 自定义UserAgent As String = "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/117.0.0.0 Safari/537.36 Edg/117.0.2045.47"

    End Class

    Public Class Release

        Public 发布标题 As String = ""
        Public 版本标签 As String = ""
        Public 预览版 As Boolean = False
        Public 发布描述 As String = ""
        Public 发布时间 As String = ""

        Public 发布者用户名 As String = ""
        ''' <summary>
        ''' 注意 GitHub 没有发布者昵称这个东西，Gitee 才有
        ''' </summary>
        Public 发布者昵称 As String = ""


        Public 可供下载的文件 As New List(Of KeyValuePair(Of String, String))
        ''' <summary>
        ''' 如果发生错误会将错误描述返回至此字符串
        ''' </summary>
        Public ErrorString As String = ""

        ''' <summary>
        ''' 访问开源代码平台的网页API，并分析返回的 Json 以获取各项信息
        ''' </summary>
        ''' <returns>如果一切顺利会返回空字符串，否则返回错误描述，你也可以选择判断 ErrorString 字符串</returns>
        Public Function 获取仓库发布版信息(目标平台 As 开源代码平台, 存储库 As String, Optional 指定标签 As String = "") As String
            Try
                Dim str1 As String = ""
                ErrorString = ""
                Select Case 目标平台
                    Case 开源代码平台.Gitee
                        str1 = "https://gitee.com/api/v5/repos/" & 存储库 & "/releases/?direction=desc"
                    Case 开源代码平台.GitHub
                        str1 = "https://api.github.com/repos/" & 存储库 & "/releases"
                End Select

                Dim content As String

                Using client As New HttpClient()
                    client.DefaultRequestHeaders.Add("User-Agent", GitApiObject.自定义UserAgent)
                    client.Timeout = TimeSpan.FromSeconds(10)
                    System.Net.ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12
                    Dim response As HttpResponseMessage = client.GetAsync(str1).Result
                    If response.IsSuccessStatusCode Then
                        content = response.Content.ReadAsStringAsync().Result
                    Else
                        MsgBox("请求失败: " & response.Content.ReadAsStringAsync().Result)
                        ErrorString = response.Content.ReadAsStringAsync().Result
                        Return ErrorString
                        Exit Function
                    End If
                End Using

                Dim 数据 As String = "{" & """" & "Data" & """" & ": " & content & "}"

                Dim JsonData As Object = CType(JsonConvert.DeserializeObject(数据), JObject)
                If JsonData.item("Data").Count Is Nothing Then
                    If JsonData.item("Data").item("message") IsNot Nothing Then
                        ErrorString = JsonData.item("Data").item("message").ToString
                        Exit Try
                    End If
                End If

                If JsonData.item("Data").Count >= 1 Then
                    发布标题 = JsonData.item("Data")(0).item("name").ToString
                    版本标签 = JsonData.item("Data")(0).item("tag_name").ToString
                    预览版 = JsonData.item("Data")(0).item("prerelease").ToString
                    发布描述 = JsonData.item("Data")(0).item("body").ToString
                    发布时间 = JsonData.item("Data")(0).item("created_at").ToString

                    发布者用户名 = JsonData.item("Data")(0).item("author").item("login").ToString
                    If 目标平台 = 开源代码平台.Gitee Then
                        发布者昵称 = JsonData.item("Data")(0).item("author").item("name").ToString
                    End If

                    For i = 0 To JsonData.item("Data")(0).item("assets").Count - 1
                        If JsonData.item("Data")(0).item("assets").item(i)("name") IsNot Nothing Then
                            可供下载的文件.Add(New KeyValuePair(Of String, String)(JsonData.item("Data")(0).item("assets").item(i)("name").ToString, JsonData.item("Data")(0).item("assets").item(i)("browser_download_url").ToString))
                        End If
                    Next
                Else
                    ErrorString = "Server failed to return valid data."
                    Return ErrorString
                    Exit Try
                End If
                Return ""
            Catch ex As Exception
                ErrorString = ex.Message
            End Try
            Return ErrorString

        End Function

    End Class

    Public Class TextFileString

        Public 网页返回字符串 As String = ""
        ''' <summary>
        ''' 如果发生错误会将错误描述返回至此字符串
        ''' </summary>
        Public ErrorString As String = ""

        ''' <summary>
        ''' 获取纯文本文件内容
        ''' </summary>
        ''' <param name="目标平台"></param>
        ''' <param name="用户名和仓库名"></param>
        ''' <param name="分支"></param>
        ''' <param name="路径"></param>
        ''' <returns>如果一切顺利会返回空字符串，否则返回错误描述，你也可以选择判断 ErrorString 字符串</returns>
        Public Function 获取文本文件数据(ByVal 目标平台 As 开源代码平台, ByVal 用户名和仓库名 As String, ByVal 分支 As String, ByVal 路径 As String, Optional ByVal 令牌 As String = "", Optional ByVal 是否需要进行Json错误消息识别 As Boolean = False) As String
            Try
                Dim str1 As String = ""
                ErrorString = ""
                Select Case 目标平台
                    Case 开源代码平台.Gitee
                        str1 = "https://gitee.com/" & 用户名和仓库名 & "/raw/" & 分支 & "/" & 路径
                    Case 开源代码平台.GitHub
                        str1 = "https://raw.githubusercontent.com/" & 用户名和仓库名 & "/" & 分支 & "/" & 路径
                End Select
                If 令牌 <> "" Then
                    Select Case 目标平台
                        Case 开源代码平台.Gitee
                            str1 &= "?access_token=" & 令牌
                        Case 开源代码平台.GitHub
                            str1 &= "?token=" & 令牌
                    End Select
                End If

                Dim content As String

                Using client As New HttpClient()
                    client.DefaultRequestHeaders.Add("User-Agent", GitApiObject.自定义UserAgent)
                    client.Timeout = TimeSpan.FromSeconds(10)
                    System.Net.ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12
                    Dim response As HttpResponseMessage = client.GetAsync(str1).Result
                    If response.IsSuccessStatusCode Then
                        content = response.Content.ReadAsStringAsync().Result
                    Else
                        MsgBox("请求失败: " & response.Content.ReadAsStringAsync().Result)
                        ErrorString = response.Content.ReadAsStringAsync().Result
                        Return ErrorString
                        Exit Function
                    End If
                End Using
                Dim 数据 As String = content

                If 是否需要进行Json错误消息识别 = True Then
                    Dim JsonData As Object = CType(JsonConvert.DeserializeObject(数据), JObject)
                    If JsonData.item("message") IsNot Nothing Then
                        ErrorString = JsonData.item("message").ToString
                        Return ErrorString
                    Else
                        网页返回字符串 = 数据
                    End If
                Else
                    网页返回字符串 = 数据
                End If

            Catch ex As Exception
                ErrorString = ex.Message
            End Try
            Return ErrorString

        End Function

    End Class


    Public Class Tag

        Public Tag数据 As New List(Of Tag单片数据)

        Structure Tag单片数据
            Public name As String
        End Structure

        Public ErrorString As String = ""

        Public Function 获取仓库Tag信息(目标平台 As 开源代码平台, 存储库 As String) As String
            Try
                Tag数据.Clear()
                Dim str1 As String = ""
                ErrorString = ""
                Select Case 目标平台
                    Case 开源代码平台.Gitee
                        str1 = "https://gitee.com/api/v5/repos/" & 存储库 & "/tags"
                    Case 开源代码平台.GitHub
                        str1 = "https://api.github.com/repos/" & 存储库 & "/tags"
                End Select
                Dim content As String
                Using client As New HttpClient()
                    client.DefaultRequestHeaders.Add("User-Agent", GitApiObject.自定义UserAgent)
                    client.Timeout = TimeSpan.FromSeconds(10)
                    System.Net.ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12
                    Dim response As HttpResponseMessage = client.GetAsync(str1).Result
                    If response.IsSuccessStatusCode Then
                        content = response.Content.ReadAsStringAsync().Result
                    Else
                        ErrorString = response.Content.ReadAsStringAsync().Result
                        Return ErrorString
                        Exit Function
                    End If
                End Using
                Dim 数据 As String = "{" & """" & "Data" & """" & ": " & content & "}"
                Dim JsonData As Object = CType(JsonConvert.DeserializeObject(数据), JObject)
                If JsonData.item("Data").Count Is Nothing Then
                    If JsonData.item("Data").item("message") IsNot Nothing Then
                        ErrorString = JsonData.item("Data").item("message").ToString
                        Return ErrorString
                        Exit Try
                    End If
                End If
                For i = 0 To JsonData.item("Data").Count - 1
                    Dim s As New Tag单片数据
                    If JsonData.item("Data")(i).item("name") IsNot Nothing Then
                        s.name = JsonData.item("Data")(i).item("name").ToString
                    End If
                    Tag数据.Add(s)
                Next
                Return ""
            Catch ex As Exception
                ErrorString = ex.Message
                Return ex.Message
            End Try
        End Function

    End Class

    Public Class GitHubAllReleaseFile

        Public 发行版数据集合 As New List(Of 发行版数据单片)

        Public Structure 发行版数据单片
            Public 可供下载的文件 As List(Of KeyValuePair(Of String, String))
            Public 标题 As String
            Public 描述 As String
            Public 标签 As String
            Public 是否是草稿 As Boolean
            Public 是否预览版 As Boolean
        End Structure

        Public Function 获取(存储库 As String) As String
            Try
                Dim str1 As String = "https://api.github.com/repos/" & 存储库 & "/releases"
                Dim content As String
                Using client As New HttpClient()
                    client.DefaultRequestHeaders.Add("User-Agent", GitApiObject.自定义UserAgent)
                    client.Timeout = TimeSpan.FromSeconds(10)
                    System.Net.ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12
                    Dim response As HttpResponseMessage = client.GetAsync(str1).Result
                    If response.IsSuccessStatusCode Then
                        content = response.Content.ReadAsStringAsync().Result
                    Else
                        Return response.Content.ReadAsStringAsync().Result
                    End If
                End Using
                Dim 数据 As String = "{" & """" & "Data" & """" & ": " & content & "}"
                Dim JsonData As Object = CType(JsonConvert.DeserializeObject(数据), JObject)
                If JsonData.item("Data").Count Is Nothing Then
                    If JsonData.item("Data").item("message") IsNot Nothing Then
                        Return JsonData.item("Data").item("message").ToString
                    End If
                End If
                发行版数据集合.Clear()
                For i = 0 To JsonData.item("Data").Count - 1
                    Dim a1 As New 发行版数据单片
                    If JsonData.item("Data")(i).item("name") IsNot Nothing Then
                        a1.标题 = JsonData.item("Data")(i).item("name").ToString
                    End If
                    If JsonData.item("Data")(i).item("body") IsNot Nothing Then
                        a1.描述 = JsonData.item("Data")(i).item("body").ToString
                    End If
                    If JsonData.item("Data")(i).item("tag_name") IsNot Nothing Then
                        a1.标签 = JsonData.item("Data")(i).item("tag_name").ToString
                    End If
                    If JsonData.item("Data")(i).item("draft") IsNot Nothing Then
                        a1.是否是草稿 = JsonData.item("Data")(i).item("draft").ToString
                    End If
                    If JsonData.item("Data")(i).item("prerelease") IsNot Nothing Then
                        a1.是否预览版 = JsonData.item("Data")(i).item("prerelease").ToString
                    End If
                    a1.可供下载的文件 = New List(Of KeyValuePair(Of String, String))
                    For i2 = 0 To JsonData.item("Data")(i).item("assets").Count - 1
                        If JsonData.item("Data")(i).item("assets").item(i2)("name") IsNot Nothing Then
                            a1.可供下载的文件.Add(New KeyValuePair(Of String, String)(JsonData.item("Data")(i).item("assets").item(i2)("name").ToString, JsonData.item("Data")(i).item("assets").item(i2)("browser_download_url").ToString))
                        End If
                    Next
                    发行版数据集合.Add(a1)
                Next

                Return ""
            Catch ex As Exception
                Return ex.Message
            End Try
        End Function

    End Class

End Class
