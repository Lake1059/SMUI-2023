Imports System.Net
Imports System.Net.Http
Imports System.Text
Imports System.Text.Json

<CodeAnalysis.SuppressMessage("Style", "IDE1006:命名样式", Justification:="<挂起>")>
Public Class SMAPI云服务

    Public Property 接收到并已转换的对象 As 用于接收的数据对象

    Public Async Function 发送并接收Async(发送的JSON As 用于发送的数据对象) As Task(Of String)
        Try
            Using httpClient As New HttpClient()
                Dim baseAddress As New Uri("https://smapi.io/api/v3.0/mods")
                httpClient.Timeout = TimeSpan.FromSeconds(10)
                httpClient.BaseAddress = baseAddress
                httpClient.DefaultRequestHeaders.UserAgent.ParseAdd("WEB API")
                ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12
                Dim content As New StringContent(JsonSerializer.Serialize(发送的JSON), Encoding.UTF8, "application/json")
                Dim response As HttpResponseMessage = Await httpClient.PostAsync(baseAddress, content)
                If response.IsSuccessStatusCode Then
                    Dim strHTML As String = Await response.Content.ReadAsStringAsync()
                    strHTML = "{" & """" & "Data" & """" & ": " & strHTML & "}"
                    接收到并已转换的对象 = JsonSerializer.Deserialize(Of 用于接收的数据对象)(strHTML, Json序列化器全局选项实例)
                Else
                    Return $"Error: {response.StatusCode}"
                    Exit Function
                End If
            End Using
            Return ""
        Catch ex As Exception
            Return ex.Message
        End Try
    End Function


    <Serializable>
    Public Class 用于发送的数据对象
        Public Property apiVersion As String
        Public Property gameVersion As String
        ''' <summary>
        ''' Android,Linux,Mac,Windows
        ''' </summary>
        Public Property platform As String
        Public Property includeExtendedMetadata As Boolean
        Public Property mods As List(Of mod_single)

        Public Structure mod_single
            ''' <summary>
            ''' UniqueID
            ''' </summary>
            Public Property id As String
            ''' <summary>
            ''' Nexus,Moddrop,Github,CurseForge,Chucklefish
            ''' </summary>
            Public Property updatekeys As List(Of String)
            Public Property installedversion As String
            'Public Property isBroken As Boolean
        End Structure
    End Class

    <Serializable>
    Public Class 用于接收的数据对象

        Public Property Data As List(Of 接收模组信息单片)

        Public Structure 接收模组信息单片
            ''' <summary>
            ''' UniqueID
            ''' </summary>
            Public Property id As String
            Public Property metadata As metadata
            Public Property suggestedUpdate As suggestedUpdate
            Public Property errors As List(Of String)
        End Structure

        Public Structure metadata
            ''' <summary>
            ''' UniqueID
            ''' </summary>
            Public Property id As List(Of String)
            Public Property name As String
            Public Property nexusID As Integer
            Public Property chucklefishID As Integer
            Public Property curseForgeID As Integer
            Public Property curseForgeKey As String
            Public Property modDropID As Integer
            Public Property gitHubRepo As String
            Public Property customSourseUrl As String
            Public Property customUrl As String
            Public Property main As main
            Public Property [optional] As [optional]
            Public Property unofficial As unofficial
            Public Property unofficialForBeta As unofficialForBeta
            Public Property compatibilityStatus As String
            Public Property compatibilitySummary As String
            Public Property brokeIn As String
            Public Property betaCompatibilityStatus As String
            Public Property betaCompatibilitySummary As String
            Public Property betaBrokeIn As String
        End Structure

        Public Structure suggestedUpdate
            Public Property version As String
            Public Property url As String
        End Structure

        Public Structure main
            Public Property version As String
            Public Property url As String
        End Structure

        Public Structure [optional]
            Public Property version As String
            Public Property url As String
        End Structure

        Public Structure unofficial
            Public Property version As String
            Public Property url As String
        End Structure

        Public Structure unofficialForBeta
            Public Property version As String
            Public Property url As String
        End Structure
    End Class


End Class
