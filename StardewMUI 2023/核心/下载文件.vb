

Imports System.IO
Imports System.Net.Http

Public Class 下载文件


	''' <summary>
	''' 这是给 NEXUSMODS 网站专门配置的。请使用异步调用此方法，程序能够自动修改保存文件名
	''' </summary>
	Public Shared Function DownloadFileFromNexus(URL As String, ByRef FileName As String, ByRef 已下载字节量 As Long, ByRef 总字节量 As Long, ByRef 是否终止下载 As Boolean, ByRef 服务器返回的标头信息 As Net.WebHeaderCollection) As String
		Try
			Dim Myrq As System.Net.HttpWebRequest = DirectCast(System.Net.HttpWebRequest.Create(URL), System.Net.HttpWebRequest)
			Myrq.ContinueTimeout = 10000
			Dim myrp As System.Net.HttpWebResponse = DirectCast(Myrq.GetResponse(), System.Net.HttpWebResponse)
			Dim totalBytes As Long = myrp.ContentLength

			Dim st As System.IO.Stream = myrp.GetResponseStream()
			服务器返回的标头信息 = myrp.Headers
			Dim 最终使用的保存位置 As String = ""
			If myrp.Headers.Item("x-bz-file-name") Is Nothing Then
				最终使用的保存位置 = FileName
			Else
				最终使用的保存位置 = IO.Path.GetDirectoryName(FileName) & "\" & IO.Path.GetFileName(myrp.Headers.Item("x-bz-file-name"))
				FileName = IO.Path.GetDirectoryName(FileName) & "\" & IO.Path.GetFileName(myrp.Headers.Item("x-bz-file-name"))
			End If
			Dim so As System.IO.Stream = New System.IO.FileStream(最终使用的保存位置, System.IO.FileMode.Create)
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
		Catch ex As System.Exception
			Return ex.Message
		End Try
	End Function

	Public Shared Function DownloadFile(URL As String, FileName As String, ByRef 已下载字节量 As Long, ByRef 总字节量 As Long, ByRef 是否终止下载 As Boolean) As String
		Try
			Dim Myrq As System.Net.HttpWebRequest = DirectCast(System.Net.HttpWebRequest.Create(URL), System.Net.HttpWebRequest)
			Myrq.ContinueTimeout = 10000
			Dim myrp As System.Net.HttpWebResponse = DirectCast(Myrq.GetResponse(), System.Net.HttpWebResponse)
			Dim totalBytes As Long = myrp.ContentLength

			Dim st As System.IO.Stream = myrp.GetResponseStream()
			Dim so As System.IO.Stream = New System.IO.FileStream(FileName, System.IO.FileMode.Create)
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
		Catch ex As System.Exception
			Return ex.Message
		End Try
	End Function

End Class
