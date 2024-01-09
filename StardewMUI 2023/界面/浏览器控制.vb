Imports System.IO
Imports CefSharp


Public Class 浏览器控制

    Public Shared Property 当前是否在更新或下载模组 As Boolean = False
    Public Shared Property 获取到的HTML数据 As String = ""
    Public Shared Property 获取到的key As String = ""
    Public Shared Property 获取到的expires As String = ""
    Public Shared Property 当前地址 As String = ""
    Public Shared Property 上一次获取到的地址 As String = ""
    Public Shared Property 界面刷新计时器 As New Timer With {.Interval = 500, .Enabled = False}
    Public Shared Property 计算额外参数计时器 As New Timer With {.Interval = 500, .Enabled = False}
    Public Shared Sub 初始化功能()
        AddHandler Form1.UiTabControl1.SelectedIndexChanged,
            Sub(sender, e)
                If Form1.UiTabControl1.SelectedIndex = 5 Then
                    If Form1.UiTextBox5.Text = "" Then
                        界面控制.CEF浏览器控件.LoadUrl("https://users.nexusmods.com/auth/sign_in")
                    End If
                End If
            End Sub
        AddHandler Form1.UiButton49.Click,
            Sub()
                界面控制.CEF浏览器控件.LoadUrl("https://users.nexusmods.com/auth/sign_in")
                获取到的HTML数据 = ""
            End Sub
        AddHandler Form1.UiButton40.Click,
            Sub()
                界面控制.CEF浏览器控件.Reload()
            End Sub
        AddHandler Form1.UiButton50.Click,
            Sub()
                界面控制.CEF浏览器控件.Back()
            End Sub
        AddHandler Form1.UiButton51.Click,
            Sub()
                界面控制.CEF浏览器控件.Forward()
            End Sub
        AddHandler Form1.UiButton52.Click,
            Sub()
                界面控制.CEF浏览器控件.Stop()
            End Sub
        AddHandler Form1.UiButton53.Click,
            Sub()
                界面控制.CEF浏览器控件.LoadUrl(Form1.UiTextBox5.Text)
            End Sub
        AddHandler Form1.UiTextBox5.KeyDown,
            Sub(sender, e)
                If e.KeyCode = Keys.Enter Then 界面控制.CEF浏览器控件.LoadUrl(Form1.UiTextBox5.Text)
            End Sub
        AddHandler Form1.UiButton54.Click,
            Sub()
                Dim processes() As Process = Process.GetProcessesByName("CefSharp.BrowserSubprocess")
                If processes.Length > 0 Then
                    For Each proc As Process In processes
                        'DebugPrint(proc.MainModule.FileName, Form1.ForeColor)
                        If proc.MainModule.FileName = Path.Combine(Application.StartupPath, "CefSharp.BrowserSubprocess.exe") Then proc.Kill(True)
                    Next
                End If
            End Sub
        AddHandler 界面刷新计时器.Tick,
            Sub()
                If Form1.UiTabControl1.SelectedIndex <> 5 Then Exit Sub
                If 当前地址 <> 上一次获取到的地址 Then
                    Form1.UiTextBox5.Text = 当前地址
                End If
                上一次获取到的地址 = 当前地址
            End Sub
        界面刷新计时器.Enabled = True

        AddHandler 界面控制.CEF浏览器控件.LoadingStateChanged, AddressOf CEF_LoadingStateChanged
        AddHandler 界面控制.CEF浏览器控件.AddressChanged, AddressOf CEF_AddressChanged
        AddHandler 计算额外参数计时器.Tick, AddressOf 计算额外参数

    End Sub

    Public Shared Property HideAdsScript As String = "
            var ads = document.querySelectorAll('.ad');
            ads.forEach(function(ad) {
                ad.style.display = 'none';
            });
        "

    Public Shared Sub CEF_LoadingStateChanged(sender As Object, e As CefSharp.LoadingStateChangedEventArgs)
        当前地址 = 界面控制.CEF浏览器控件.Address
        If Not e.IsLoading Then
            界面控制.CEF浏览器控件.ExecuteScriptAsync("document.documentElement.setAttribute('data-theme', 'dark');")
            界面控制.CEF浏览器控件.ExecuteScriptAsync(HideAdsScript)
        End If
        If e.IsLoading = False And 当前是否在更新或下载模组 = True Then
            Dim task02 = e.Browser.GetSourceAsync()
            task02.ContinueWith(
                Function(t)
                    If Not t.IsFaulted Then
                        获取到的HTML数据 = t.Result
                        启动计算("")
                    End If
                    Return Nothing
                End Function)
        End If
    End Sub

    Public Shared Sub CEF_AddressChanged(sender As Object, e As CefSharp.AddressChangedEventArgs)

    End Sub

    Public Delegate Sub str_Delegate(str As String)
    Public Shared Sub 更新地址栏(str As String)
        If Form1.InvokeRequired Then
            Form1.Invoke(New str_Delegate(AddressOf 更新地址栏), str)
            Return
        End If
        Form1.UiTextBox5.Text = str
    End Sub

    Public Shared Sub 启动计算(str As String)
        If Form1.InvokeRequired Then
            Form1.Invoke(New str_Delegate(AddressOf 启动计算), str)
            Return
        End If
        'Me.Timer1.Enabled = True
    End Sub

    Public Shared Sub 计算额外参数()
        Dim dataStartString As String = "data-download-url=" & """"
        Dim dataStartIndex As Integer = InStr(获取到的HTML数据, dataStartString) + Len(dataStartString)

        Dim keyStartIndex As Integer = InStr(dataStartIndex, 获取到的HTML数据, "?key=") + Len("?key=")
        Dim keyEndIndex As Integer = InStr(keyStartIndex, 获取到的HTML数据, "&")
        Dim extractedKey As String = Mid(获取到的HTML数据, keyStartIndex, keyEndIndex - keyStartIndex)
        DebugPrint("key=" & extractedKey, Color.SkyBlue)
        获取到的key = extractedKey

        Dim expiresStartIndex As Integer = InStr(dataStartIndex, 获取到的HTML数据, "expires=") + Len("expires=")
        Dim expiresEndIndex As Integer = InStr(expiresStartIndex, 获取到的HTML数据, "&")
        Dim extractedExpires As String = Mid(获取到的HTML数据, expiresStartIndex, expiresEndIndex - expiresStartIndex)
        DebugPrint("expires=" & extractedExpires, Color.SkyBlue)
        获取到的expires = extractedExpires

    End Sub


End Class
