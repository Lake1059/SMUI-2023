

Imports System.IO
Imports System.Net.Http

Public Class 下载文件

    Public Shared Function DownloadFileFromNexus(URL As String, ByRef FileName As String, ByRef 已下载字节量 As Long, ByRef 总字节量 As Long, ByRef 是否终止下载 As Boolean, ByRef 服务器返回的标头信息 As Headers.HttpResponseHeaders) As String
        Dim httpClient As New HttpClient With {.Timeout = TimeSpan.FromSeconds(10)}
        Dim errorMessage As String = ""

        Try
            Dim response As HttpResponseMessage = httpClient.GetAsync(URL).Result
            response.EnsureSuccessStatusCode()

            Dim totalBytes As Long = response.Content.Headers.ContentLength
            总字节量 = totalBytes
            服务器返回的标头信息 = response.Headers

            Dim xBzFileName = response.Headers.FirstOrDefault(Function(h) h.Key = "x-bz-file-name").Value?.FirstOrDefault()
            If xBzFileName IsNot Nothing Then
                FileName = Path.Combine(Path.GetDirectoryName(FileName), Path.GetFileName(xBzFileName))
            End If

            Using webStream As Stream = response.Content.ReadAsStreamAsync().Result,
                  fileStream As New FileStream(FileName, FileMode.Create)
                Dim buffer As Byte() = New Byte(1023) {}
                Dim bytesRead As Integer = 0

                While (bytesRead > 0 OrElse bytesRead = 0) AndAlso Not 是否终止下载
                    bytesRead = webStream.Read(buffer, 0, buffer.Length)
                    If bytesRead > 0 Then
                        fileStream.Write(buffer, 0, bytesRead)
                        已下载字节量 += bytesRead
                    End If
                End While
            End Using

        Catch ex As Exception
            errorMessage = ex.Message
        End Try

        Return errorMessage
    End Function

    Public Shared Function DownloadFile(URL As String, ByRef FileName As String, ByRef 已下载字节量 As Long, ByRef 总字节量 As Long, ByRef 是否终止下载 As Boolean) As String
        Dim httpClient As New HttpClient With {.Timeout = TimeSpan.FromSeconds(10)}
        Dim errorMessage As String = ""

        Try
            Dim response As HttpResponseMessage = httpClient.GetAsync(URL).Result
            response.EnsureSuccessStatusCode()

            Dim totalBytes As Long = response.Content.Headers.ContentLength
            总字节量 = totalBytes

            Using webStream As Stream = response.Content.ReadAsStreamAsync().Result,
                  fileStream As New FileStream(FileName, FileMode.Create)
                Dim buffer As Byte() = New Byte(1023) {}
                Dim bytesRead As Integer = 0

                While (bytesRead > 0 OrElse bytesRead = 0) AndAlso Not 是否终止下载
                    bytesRead = webStream.Read(buffer, 0, buffer.Length)
                    If bytesRead > 0 Then
                        fileStream.Write(buffer, 0, bytesRead)
                        已下载字节量 += bytesRead
                    End If
                End While
            End Using

        Catch ex As Exception
            errorMessage = ex.Message
        End Try

        Return errorMessage
    End Function

End Class
