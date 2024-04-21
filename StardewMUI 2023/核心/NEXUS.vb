Imports Newtonsoft.Json
Imports Newtonsoft.Json.Linq
Imports System.IO
Imports System.Net

Public Class NEXUS

    Public Shared Property GlobalUserAgent As String = "NEXUS API (Windows NT; WOW64) from SMUI 6 by 1059 Studio"

    Public Enum FileType
        mainFile = 1
        optionalFile = 2
        updateFile = 3
        old_versionFile = 4
        miscellaneousFile = 5
        ALL = 0
        main_optional = 11
        main_optional_miscellaneous = 12
        main_optional_updateFile_miscellaneous = 13
    End Enum

    Public Enum ListModType
        TheLatest10ModsReleased = 1
        TheLatest10ModsUpdated = 2
        The10EveryTimeHotMods = 3
    End Enum

    Public Enum ListIDType
        The10UpdatedOnToday = 1
        The10UpdatedThisWeek = 2
        The10UpdatedThisMonth = 3
    End Enum


    Public Class GetUserInfo


        Public ST_ApiKey As String = ""
        Public ErrorString As String = ""

        Public user_id As String
        Public key As String
        Public name As String
        Public is_premium As String
        Public is_supporter As String
        Public email As String
        ''' <summary>
        ''' User Image URL
        ''' </summary>
        Public profile_url As String

        Public daily_limit As Integer
        Public daily_remaining As Integer
        Public hourly_limit As Integer
        Public hourly_remaining As Integer


        Public Function StartGet() As String
            Try
                Dim uri As New Uri("https://api.nexusmods.com/v1/users/validate.json")
                System.Net.ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12
                Dim myReq As HttpWebRequest = DirectCast(WebRequest.Create(uri), HttpWebRequest)
                myReq.ContinueTimeout = 1000
                myReq.UserAgent = GlobalUserAgent
                'myReq.Accept = "text/html"
                myReq.Method = "GET"
                myReq.KeepAlive = False
                myReq.Headers.Add("apikey", ST_ApiKey)
                Dim result As HttpWebResponse = DirectCast(myReq.GetResponse(), HttpWebResponse)
                Dim receviceStream As Stream = result.GetResponseStream()
                daily_limit = result.GetResponseHeader("x-rl-daily-limit")
                daily_remaining = result.GetResponseHeader("x-rl-daily-remaining")
                hourly_limit = result.GetResponseHeader("x-rl-hourly-limit")
                hourly_remaining = result.GetResponseHeader("x-rl-hourly-remaining")
                Dim readerOfStream As New StreamReader(receviceStream, System.Text.Encoding.GetEncoding("utf-8"))
                Dim strHTML As String = readerOfStream.ReadToEnd()
                readerOfStream.Close()
                receviceStream.Close()
                result.Close()

                Dim JsonData As Object = CType(JsonConvert.DeserializeObject(strHTML), JObject)
                If JsonData.item("message") IsNot Nothing Then
                    ErrorString = JsonData.item("message").ToString
                    Return ErrorString
                    Exit Try
                End If

                user_id = JsonData.item("user_id").ToString
                key = JsonData.item("key").ToString
                name = JsonData.item("name").ToString
                is_premium = JsonData.item("is_premium").ToString
                is_supporter = JsonData.item("is_supporter").ToString
                email = JsonData.item("email").ToString
                profile_url = JsonData.item("profile_url").ToString

                Return ""
            Catch ex As Exception
                ErrorString = ex.Message
                Return ex.Message
            End Try
        End Function
    End Class

    Public Class GetModList


        Public ST_ApiKey As String = ""
        Public ErrorString As String = ""

        Public name As String()
        Public summary As String()
        Public description As String()
        Public picture_url As String()
        Public uid As Long()
        Public mod_id As Long()
        Public game_id As String()
        Public allow_rating As Boolean()
        Public domain_name As String()
        Public category_id As Integer()
        Public version As String()
        Public endorsement_count As Long()
        Public created_timestamp As String()
        Public created_time As String()
        Public updated_timestamp As String()
        Public updated_time As String()
        Public author As String()
        Public uploaded_by As String()
        Public uploaded_users_profile_url As String()
        Public contains_adult_content As Boolean()
        Public status As String()
        Public available As Boolean()

        Public daily_limit As Integer
        Public daily_remaining As Integer
        Public hourly_limit As Integer
        Public hourly_remaining As Integer

        Public Function StartGet(ByVal gameName As String, ByVal yourListType As ListModType) As String
            Try
                Dim str1 As String = ""
                ErrorString = ""
                Select Case yourListType
                    Case ListModType.TheLatest10ModsReleased
                        str1 = "https://api.nexusmods.com/v1/games/" & gameName & "/mods/latest_added.json"
                    Case ListModType.TheLatest10ModsUpdated
                        str1 = "https://api.nexusmods.com/v1/games/" & gameName & "/mods/latest_updated.json"
                    Case ListModType.The10EveryTimeHotMods
                        str1 = "https://api.nexusmods.com/v1/games/" & gameName & "/mods/trending.json"
                End Select

                Dim uri As New Uri(str1)
                System.Net.ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12
                Dim myReq As HttpWebRequest = DirectCast(WebRequest.Create(uri), HttpWebRequest)
                myReq.ContinueTimeout = 1000
                myReq.UserAgent = GlobalUserAgent
                myReq.Method = "GET"
                myReq.KeepAlive = False
                myReq.Headers.Add("apikey", ST_ApiKey)
                Dim result As HttpWebResponse = DirectCast(myReq.GetResponse(), HttpWebResponse)
                Dim receviceStream As Stream = result.GetResponseStream()
                daily_limit = result.GetResponseHeader("x-rl-daily-limit")
                daily_remaining = result.GetResponseHeader("x-rl-daily-remaining")
                hourly_limit = result.GetResponseHeader("x-rl-hourly-limit")
                hourly_remaining = result.GetResponseHeader("x-rl-hourly-remaining")
                Dim readerOfStream As New StreamReader(receviceStream, System.Text.Encoding.GetEncoding("utf-8"))
                Dim strHTML As String = readerOfStream.ReadToEnd()
                readerOfStream.Close()
                receviceStream.Close()
                result.Close()
                strHTML = "{" & """" & "Data" & """" & ":" & strHTML
                strHTML &= "}"

                Dim JsonData As Object = CType(JsonConvert.DeserializeObject(strHTML), JObject)

                If JsonData.item("Data").Count Is Nothing Then
                    If JsonData.item("Data").item("message") IsNot Nothing Then
                        ErrorString = JsonData.item("Data").item("message").ToString
                        Return ErrorString
                        Exit Try
                    End If
                End If

                Dim i3 As Integer = JsonData.item("Data").Count - 1
                ReDim name(i3)
                ReDim summary(i3)
                ReDim description(i3)
                ReDim picture_url(i3)
                ReDim uid(i3)
                ReDim mod_id(i3)
                ReDim game_id(i3)
                ReDim allow_rating(i3)
                ReDim domain_name(i3)
                ReDim category_id(i3)
                ReDim version(i3)
                ReDim endorsement_count(i3)
                ReDim created_timestamp(i3)
                ReDim created_time(i3)
                ReDim updated_timestamp(i3)
                ReDim updated_time(i3)
                ReDim author(i3)
                ReDim uploaded_by(i3)
                ReDim uploaded_users_profile_url(i3)
                ReDim contains_adult_content(i3)
                ReDim status(i3)
                ReDim available(i3)

                For i = 0 To i3
                    If JsonData.item("Data").item(i)("name") Is Nothing Then
                        name(i) = ""
                    Else
                        name(i) = JsonData.item("Data").item(i)("name").ToString
                    End If
                    If JsonData.item("Data").item(i)("summary") Is Nothing Then
                        summary(i) = ""
                    Else
                        summary(i) = JsonData.item("Data").item(i)("summary").ToString
                    End If
                    If JsonData.item("Data").item(i)("description") Is Nothing Then
                        description(i) = ""
                    Else
                        description(i) = JsonData.item("Data").item(i)("description").ToString
                    End If
                    If JsonData.item("Data").item(i)("picture_url") Is Nothing Then
                        picture_url(i) = ""
                    Else
                        picture_url(i) = JsonData.item("Data").item(i)("picture_url").ToString
                    End If
jx1:
                    uid(i) = JsonData.item("Data").item(i)("uid").ToString
                    mod_id(i) = JsonData.item("Data").item(i)("mod_id").ToString
                    game_id(i) = JsonData.item("Data").item(i)("game_id").ToString
                    allow_rating(i) = JsonData.item("Data").item(i)("allow_rating").ToString
                    domain_name(i) = JsonData.item("Data").item(i)("domain_name").ToString
                    category_id(i) = JsonData.item("Data").item(i)("category_id").ToString
                    version(i) = JsonData.item("Data").item(i)("version").ToString
                    endorsement_count(i) = JsonData.item("Data").item(i)("endorsement_count").ToString
                    created_timestamp(i) = JsonData.item("Data").item(i)("created_timestamp").ToString
                    created_time(i) = JsonData.item("Data").item(i)("created_time").ToString
                    updated_timestamp(i) = JsonData.item("Data").item(i)("updated_timestamp").ToString
                    updated_time(i) = JsonData.item("Data").item(i)("updated_time").ToString
                    author(i) = JsonData.item("Data").item(i)("author").ToString
                    uploaded_by(i) = JsonData.item("Data").item(i)("uploaded_by").ToString
                    uploaded_users_profile_url(i) = JsonData.item("Data").item(i)("uploaded_users_profile_url").ToString
                    contains_adult_content(i) = JsonData.item("Data").item(i)("contains_adult_content").ToString
                    status(i) = JsonData.item("Data").item(i)("status").ToString
                    available(i) = JsonData.item("Data").item(i)("available").ToString

                Next

                Return ""
            Catch ex As Exception
                ErrorString = ex.Message
                Return ex.Message
            End Try
        End Function


    End Class


    Public Class GetModFileList

        Public ST_ApiKey As String = ""
        Public ErrorString As String = ""

        Public Structure FileListDataOne
            Public uid As Long
            Public file_id As Long
            Public name As String
            Public version As String
            Public category_id As Integer
            Public category_name As String
            Public is_primary As String
            Public size As Long
            Public file_name As String
            Public uploaded_timestamp As Long
            Public uploaded_time As String
            Public mod_version As String
            Public external_virus_scan_url As String
            Public description As String
            Public size_kb As Long
            Public changelog_html As String
            Public content_preview_link As String
        End Structure

        Public Property FileListData As New List(Of FileListDataOne)

        Public daily_limit As Integer
        Public daily_remaining As Integer
        Public hourly_limit As Integer
        Public hourly_remaining As Integer

        Public Function StartGet(GameName As String, ModID As Integer, ListFileType As FileType) As String
            Try
                Dim str1 As String = ""
                ErrorString = ""
                Select Case ListFileType
                    Case FileType.mainFile
                        str1 = "https://api.nexusmods.com/v1/games/" & GameName & "/mods/" & ModID & "/files.json?category=main"
                    Case FileType.optionalFile
                        str1 = "https://api.nexusmods.com/v1/games/" & GameName & "/mods/" & ModID & "/files.json?category=optional"
                    Case FileType.updateFile
                        str1 = "https://api.nexusmods.com/v1/games/" & GameName & "/mods/" & ModID & "/files.json?category=update"
                    Case FileType.old_versionFile
                        str1 = "https://api.nexusmods.com/v1/games/" & GameName & "/mods/" & ModID & "/files.json?category=old_version"
                    Case FileType.miscellaneousFile
                        str1 = "https://api.nexusmods.com/v1/games/" & GameName & "/mods/" & ModID & "/files.json?category=miscellaneous"
                    Case FileType.ALL
                        str1 = "https://api.nexusmods.com/v1/games/" & GameName & "/mods/" & ModID & "/files.json"
                    Case FileType.main_optional_miscellaneous
                        str1 = "https://api.nexusmods.com/v1/games/" & GameName & "/mods/" & ModID & "/files.json?category=main,optional,miscellaneous"
                    Case FileType.main_optional
                        str1 = "https://api.nexusmods.com/v1/games/" & GameName & "/mods/" & ModID & "/files.json?category=main,optional"
                    Case FileType.main_optional_updateFile_miscellaneous
                        str1 = "https://api.nexusmods.com/v1/games/" & GameName & "/mods/" & ModID & "/files.json?category=main,optional,update,miscellaneous"
                End Select

                Dim uri As New Uri(str1)
                System.Net.ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12
                Dim myReq As HttpWebRequest = DirectCast(WebRequest.Create(uri), HttpWebRequest)
                myReq.ContinueTimeout = 1000
                myReq.UserAgent = GlobalUserAgent
                myReq.Method = "GET"
                myReq.KeepAlive = False
                myReq.Headers.Add("apikey", ST_ApiKey)
                Dim result As HttpWebResponse = DirectCast(myReq.GetResponse(), HttpWebResponse)
                Dim receviceStream As Stream = result.GetResponseStream()
                daily_limit = result.GetResponseHeader("x-rl-daily-limit")
                daily_remaining = result.GetResponseHeader("x-rl-daily-remaining")
                hourly_limit = result.GetResponseHeader("x-rl-hourly-limit")
                hourly_remaining = result.GetResponseHeader("x-rl-hourly-remaining")
                Dim readerOfStream As New StreamReader(receviceStream, System.Text.Encoding.GetEncoding("utf-8"))
                Dim strHTML As String = readerOfStream.ReadToEnd()
                readerOfStream.Close()
                receviceStream.Close()
                result.Close()

                Dim JsonData As Object = CType(JsonConvert.DeserializeObject(strHTML), JObject)
                If JsonData.item("message") IsNot Nothing Then
                    ErrorString = JsonData.item("message").ToString
                    Return ErrorString
                    Exit Try
                End If

                For i = 0 To JsonData.item("files").Count - 1
                    Dim a As New FileListDataOne With {
                        .uid = JsonData.item("files").item(i)("uid").ToString,
                        .file_id = JsonData.item("files").item(i)("file_id").ToString,
                        .name = JsonData.item("files").item(i)("name").ToString,
                        .version = JsonData.item("files").item(i)("version").ToString,
                        .category_id = JsonData.item("files").item(i)("category_id").ToString,
                        .category_name = JsonData.item("files").item(i)("category_name").ToString,
                        .is_primary = JsonData.item("files").item(i)("is_primary").ToString,
                        .size = JsonData.item("files").item(i)("size").ToString,
                        .file_name = JsonData.item("files").item(i)("file_name").ToString,
                        .uploaded_timestamp = JsonData.item("files").item(i)("uploaded_timestamp").ToString,
                        .uploaded_time = JsonData.item("files").item(i)("uploaded_time").ToString,
                        .mod_version = JsonData.item("files").item(i)("mod_version").ToString,
                        .external_virus_scan_url = JsonData.item("files").item(i)("external_virus_scan_url").ToString,
                        .description = JsonData.item("files").item(i)("description").ToString,
                        .size_kb = JsonData.item("files").item(i)("size_kb").ToString,
                        .changelog_html = JsonData.item("files").item(i)("changelog_html").ToString,
                        .content_preview_link = JsonData.item("files").item(i)("content_preview_link").ToString
                    }
                    FileListData.Add(a)
                Next

                Return ""
            Catch ex As Exception
                ErrorString = ex.Message
                Return ex.Message
            End Try
        End Function



    End Class


    Public Class GetModFileDownloadURL

        Public ST_ApiKey As String = ""
        Public ErrorString As String = ""

        Public name As String()
        Public short_name As String()
        Public URI As String()

        Public daily_limit As Integer
        Public daily_remaining As Integer
        Public hourly_limit As Integer
        Public hourly_remaining As Integer

        Public Function StartGet(GameName As String, ModID As Integer, FileID As Integer, Optional key As String = "", Optional expires As String = "") As String
            Try
                ErrorString = ""
                Dim u1 As String
                If key <> "" And expires <> "" Then
                    u1 = "https://api.nexusmods.com/v1/games/" & GameName & "/mods/" & ModID & "/files/" & FileID & "/download_link.json?key=" & key & "&expires=" & expires
                Else
                    u1 = "https://api.nexusmods.com/v1/games/" & GameName & "/mods/" & ModID & "/files/" & FileID & "/download_link.json"
                End If
                Dim myURL As New Uri(u1)
                System.Net.ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12
                Dim myReq As HttpWebRequest = DirectCast(WebRequest.Create(myURL), HttpWebRequest)
                myReq.ContinueTimeout = 1000
                myReq.UserAgent = GlobalUserAgent
                'myReq.Accept = "html/text"
                myReq.Method = "GET"
                myReq.KeepAlive = False
                myReq.Headers.Add("apikey", ST_ApiKey)
                Dim result As HttpWebResponse = DirectCast(myReq.GetResponse(), HttpWebResponse)
                Dim receviceStream As Stream = result.GetResponseStream()
                daily_limit = result.GetResponseHeader("x-rl-daily-limit")
                daily_remaining = result.GetResponseHeader("x-rl-daily-remaining")
                hourly_limit = result.GetResponseHeader("x-rl-hourly-limit")
                hourly_remaining = result.GetResponseHeader("x-rl-hourly-remaining")
                Dim readerOfStream As New StreamReader(receviceStream, System.Text.Encoding.GetEncoding("utf-8"))
                Dim strHTML As String = readerOfStream.ReadToEnd()
                readerOfStream.Close()
                receviceStream.Close()
                result.Close()

                strHTML = "{" & """" & "Data" & """" & ":" & strHTML
                strHTML &= "}"

                Dim JsonData As Object = CType(JsonConvert.DeserializeObject(strHTML), JObject)

                If JsonData.item("Data").Count Is Nothing Then
                    If JsonData.item("Data").item("message") IsNot Nothing Then
                        ErrorString = JsonData.item("Data").item("message").ToString
                        Return ErrorString
                        Exit Try
                    End If
                End If

                Dim i3 As Integer = JsonData.item("Data").Count - 1
                ReDim name(i3)
                ReDim short_name(i3)
                ReDim URI(i3)

                For i = 0 To i3
                    name(i) = JsonData.item("Data").item(i)("name").ToString
                    short_name(i) = JsonData.item("Data").item(i)("short_name").ToString
                    URI(i) = JsonData.item("Data").item(i)("URI").ToString
                Next

                Return ""

            Catch ex As Exception
                ErrorString = ex.Message
                Return ex.Message
            End Try
        End Function

    End Class

End Class
