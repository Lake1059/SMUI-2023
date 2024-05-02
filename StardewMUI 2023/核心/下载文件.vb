Imports System.IO
Imports System.Net
Imports System.Net.Http
Imports System.Net.Http.Headers
Public Class 下载文件


	''' <summary>
	''' 这是给 NEXUSMODS 网站专门配置的。请使用异步调用此方法，程序能够自动修改保存文件名
	''' </summary>
	Public Shared Function DownloadFileFromNexus(URL As String, ByRef FileName As String, ByRef 已下载字节量 As Long, ByRef 总字节量 As Long, ByRef 是否终止下载 As Boolean, ByRef 服务器返回的标头信息 As WebHeaderCollection) As String
		Try
			Dim Myrq As HttpWebRequest = DirectCast(WebRequest.Create(URL), HttpWebRequest)
			Myrq.ContinueTimeout = 10000
			Myrq.Timeout = 10000
			Dim myrp As HttpWebResponse = DirectCast(Myrq.GetResponse(), HttpWebResponse)
			Dim totalBytes As Long = myrp.ContentLength
			Dim st As Stream = myrp.GetResponseStream()
			服务器返回的标头信息 = myrp.Headers
			Dim 最终使用的保存位置 As String = ""
			If myrp.Headers.Item("x-bz-file-name") Is Nothing Then
				最终使用的保存位置 = FileName
			Else
				最终使用的保存位置 = Path.GetDirectoryName(FileName) & "\" & Path.GetFileName(myrp.Headers.Item("x-bz-file-name"))
				FileName = Path.GetDirectoryName(FileName) & "\" & Path.GetFileName(myrp.Headers.Item("x-bz-file-name"))
			End If
			Dim so As Stream = New FileStream(最终使用的保存位置, FileMode.Create)
			Dim totalDownloadedByte As Long = 0
			Dim by As Byte() = New Byte(1023) {}
			Dim osize As Integer = st.Read(by, 0, by.Length)
			While osize > 0
				If 是否终止下载 = True Then
					Exit While
				End If
				totalDownloadedByte = osize + totalDownloadedByte
				so.Write(by, 0, osize)
				osize = st.Read(by, 0, by.Length)
				已下载字节量 = totalDownloadedByte
				总字节量 = totalBytes
			End While
			so.Close()
			st.Close()
			Return ""
		Catch ex As Exception
			Return ex.Message
		End Try
	End Function


	Public Shared Function DownloadFile(URL As String, FileName As String, ByRef 已下载字节量 As Long, ByRef 总字节量 As Long, ByRef 是否终止下载 As Boolean) As String
		Try
			Dim Myrq As HttpWebRequest = DirectCast(WebRequest.Create(URL), HttpWebRequest)
			Myrq.ContinueTimeout = 10000
			Dim myrp As HttpWebResponse = DirectCast(Myrq.GetResponse(), HttpWebResponse)
			Dim totalBytes As Long = myrp.ContentLength
			Dim st As Stream = myrp.GetResponseStream()
			Dim so As Stream = New FileStream(FileName, FileMode.Create)
			Dim totalDownloadedByte As Long = 0
			Dim by As Byte() = New Byte(1023) {}
			Dim osize As Integer = st.Read(by, 0, by.Length)
			While osize > 0
				If 是否终止下载 = True Then
					Exit While
				End If
				totalDownloadedByte = osize + totalDownloadedByte
				so.Write(by, 0, osize)
				osize = st.Read(by, 0, by.Length)
				已下载字节量 = totalDownloadedByte
				总字节量 = totalBytes
			End While
			so.Close()
			st.Close()
			Return ""
		Catch ex As Exception
			Return ex.Message
		End Try
	End Function

End Class
