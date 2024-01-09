Imports Newtonsoft.Json
Imports Newtonsoft.Json.Linq
Imports System.IO
Imports System.Net
Imports System.Reflection
Imports System.Runtime.InteropServices

Public Class 数据上传
    Public Shared Sub 发送用户统计()
        If 设置.全局设置数据("UploadUserInfo") = "False" Then Exit Sub
        If 设置.全局设置数据("AgreementSigned") = "False" Then Exit Sub
        If My.Settings.上次发送用户统计的日期 = Now.Year & "/" & Now.Month & "/" & Now.Day Then Exit Sub
        If My.Computer.Network.IsAvailable = False Then Exit Sub
        DebugPrint("正在连接到用户统计服务器", Form1.ForeColor)
        Dim 服务器发送 As New ComponentModel.BackgroundWorker With {.WorkerReportsProgress = True}
        AddHandler 服务器发送.DoWork,
           Sub(sender As Object, e As ComponentModel.DoWorkEventArgs)
               Try
                   Dim version As Version = Assembly.GetEntryAssembly().GetName().Version
                   Dim 软件版本 As String = "appver=" & $"{version.Major}.{version.Minor}.{version.Build}"
                   Dim 系统名称 As String = "&sysname=" & My.Computer.Info.OSFullName
                   Dim MyReg As Microsoft.Win32.RegistryKey = Microsoft.Win32.Registry.LocalMachine.OpenSubKey("HARDWARE\DESCRIPTION\SYSTEM\CentralProcessor\0")
                   Dim 处理器名称 As String = "&cpuname=" & MyReg.GetValue("ProcessorNameString").ToString()
                   Dim 内存大小 As String = "&ram=" & Math.Round(My.Computer.Info.TotalPhysicalMemory / 1024 / 1024 / 1024) & " GB"

                   Dim 显卡列表 As String = ""
                   Dim 显卡列表防止重复 As New List(Of String)
                   Dim i As UInteger = 0
                   Dim displayDevice As New DISPLAY_DEVICE()
                   displayDevice.cb = Marshal.SizeOf(displayDevice)
                   Do While EnumDisplayDevices(Nothing, i, displayDevice, 0)
                       If displayDevice.DeviceString.Length > 0 Then
                           If displayDevice.DeviceString.ToLower.Contains("intel") Or displayDevice.DeviceString.ToLower.Contains("nvidia") Or displayDevice.DeviceString.ToLower.Contains("amd") Then
                               If 显卡列表防止重复.Contains(displayDevice.DeviceString) Then
                                   i += 1
                                   Continue Do
                               End If
                               If 显卡列表 = "" Then
                                   显卡列表 = $"&gpulist={displayDevice.DeviceString}"
                               Else
                                   显卡列表 &= $" | {displayDevice.DeviceString}"
                               End If
                               显卡列表防止重复.Add(displayDevice.DeviceString)
                           End If
                       End If
                       i += 1
                       displayDevice.cb = Marshal.SizeOf(displayDevice)
                   Loop


                   Dim 显示器分辨率 As String = Screen.PrimaryScreen.Bounds.Size.Width & "x" & Screen.PrimaryScreen.Bounds.Size.Height
                   Dim g1 As Graphics = Form1.CreateGraphics
                   Dim 屏幕DPI As String = g1.DpiX & "x" & g1.DpiY
                   Dim 显示器信息 As String = "&screen=" & 显示器分辨率 & " " & 屏幕DPI & "DPI"
                   Dim 用户语言 As String = "&lang=" & System.Globalization.CultureInfo.CurrentCulture.Name

                   Dim cDrive As New DriveInfo("C")
                   Dim C盘大小 As String = "&cdc=" & Math.Round(cDrive.TotalSize / (1024 ^ 3)) & " GB"

                   Dim 输出1 As String = "report"

                   If 设置.全局设置数据("UploadWindowsVer") = "True" Then 输出1 &= vbCrLf & "SYSTEM: " & 系统名称.Replace("&sysname=", "")
                   If 设置.全局设置数据("UploadCPU0") = "True" Then 输出1 &= vbCrLf & "CPU: " & 处理器名称.Replace("&cpuname=", "")
                   If 设置.全局设置数据("UploadRAM") = "True" Then 输出1 &= vbCrLf & "RAM: " & 内存大小.Replace("&ram=", "")
                   If 设置.全局设置数据("UploadCDiskCapacity") = "True" Then 输出1 &= vbCrLf & "C Disk: " & C盘大小.Replace("&cdc=", "")
                   If 设置.全局设置数据("UploadGPU") = "True" Then 输出1 &= vbCrLf & "GPU: " & 显卡列表.Replace("&gpulist=", "")
                   If 设置.全局设置数据("UploadScreen") = "True" Then 输出1 &= vbCrLf & "SCREEN: " & 显示器信息.Replace("&screen=", "")
                   服务器发送.ReportProgress(1, 输出1)

                   '服务器好玩吗，玩累了就直接睡，我的房子还蛮大的，欢迎来我家VAN
                   Dim 地址传递 As String = "http://47.94.89.191:30003/user?" & 软件版本 & 用户语言
                   If 设置.全局设置数据("UploadWindowsVer") = "True" Then 地址传递 &= 系统名称
                   If 设置.全局设置数据("UploadCPU0") = "True" Then 地址传递 &= 处理器名称
                   If 设置.全局设置数据("UploadRAM") = "True" Then 地址传递 &= 内存大小
                   If 设置.全局设置数据("UploadCDiskCapacity") = "True" Then 地址传递 &= C盘大小
                   If 设置.全局设置数据("UploadGPU") = "True" Then 地址传递 &= 显卡列表
                   If 设置.全局设置数据("UploadScreen") = "True" Then 地址传递 &= $"&sbs={显示器分辨率}&dpi={屏幕DPI}"
jx1:
                   Dim uri As New Uri(地址传递)
                   Dim myReq As HttpWebRequest = DirectCast(WebRequest.Create(uri), HttpWebRequest)
                   myReq.ContinueTimeout = 5000
                   myReq.UserAgent = "SMUI 6"
                   myReq.Accept = "application/text"
                   myReq.MediaType = "text"
                   myReq.Method = "GET"
                   myReq.KeepAlive = False
                   'myReq.Headers.Add("content-type", "application/text")
                   Dim result As HttpWebResponse = DirectCast(myReq.GetResponse, HttpWebResponse)
                   Dim receviceStream As Stream = result.GetResponseStream()
                   Dim readerOfStream As New StreamReader(receviceStream, Text.Encoding.GetEncoding("utf-8"))
                   Dim strHTML As String = readerOfStream.ReadToEnd()
                   readerOfStream.Close()
                   receviceStream.Close()
                   result.Close()
                   e.Result = strHTML
               Catch ex As Exception
                   e.Result = ex.Message
               End Try
           End Sub
        AddHandler 服务器发送.ProgressChanged,
           Sub(sender As Object, e As System.ComponentModel.ProgressChangedEventArgs)
               Select Case e.ProgressPercentage
                   Case 1
                       DebugPrint(e.UserState, Form1.ForeColor)
               End Select

           End Sub

        AddHandler 服务器发送.RunWorkerCompleted,
           Sub(sender As Object, e As System.ComponentModel.RunWorkerCompletedEventArgs)
               If InStr(e.Result, "{") > 0 Then
                   Dim JsonData As Object = CType(JsonConvert.DeserializeObject(e.Result), JObject)
                   If JsonData.item("code") IsNot Nothing Then
                       If JsonData.item("code").ToString = "100" Then
                           DebugPrint("成功发送了用户统计", Form1.ForeColor)
                           My.Settings.上次发送用户统计的日期 = Now.Year & "/" & Now.Month & "/" & Now.Day
                           My.Settings.Save()
                       Else
                           DebugPrint("Error " & JsonData.item("code").ToString & "：" & JsonData.item("msg").ToString, Color.OrangeRed)
                       End If
                   Else
                       DebugPrint(e.Result, Color.OrangeRed)
                   End If
               Else
                   DebugPrint(e.Result, Color.OrangeRed)
               End If
           End Sub
        服务器发送.RunWorkerAsync()
    End Sub




End Class
