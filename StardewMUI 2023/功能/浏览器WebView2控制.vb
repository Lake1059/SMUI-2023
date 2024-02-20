Imports Microsoft.Web.WebView2.WinForms
Imports Microsoft.Web.WebView2.Core

Public Class 浏览器WebView2控制

    Public Shared Property 获取到的HTML数据 As String = ""
    Public Shared Property 获取到的key As String = ""
    Public Shared Property 获取到的expires As String = ""
    Public Shared Property 当前地址 As String = ""
    Public Shared Property 上一次获取到的地址 As String = ""
    Public Shared Property 界面刷新计时器 As New Timer With {.Interval = 500, .Enabled = False}
    Public Shared Property 计算额外参数计时器 As New Timer With {.Interval = 500, .Enabled = False}

    Public Shared Sub 初始化浏览器控件()
        Form1.Label15.Dispose()
        界面控制.WebView2浏览器控件 = New WebView2 With {.Dock = DockStyle.Fill}
        Form1.TabPage浏览器.Controls.Add(界面控制.WebView2浏览器控件)
        界面控制.WebView2浏览器控件.BringToFront()

        界面控制.WebView2浏览器控件.EnsureCoreWebView2Async()

        AddHandler 界面控制.WebView2浏览器控件.NavigationCompleted, AddressOf Edge_NavigationCompleted
        AddHandler 界面控制.WebView2浏览器控件.SourceChanged, AddressOf Edge_SourceChanged
        AddHandler 界面控制.WebView2浏览器控件.CoreWebView2InitializationCompleted, AddressOf Edge_CoreWebView2InitializationCompleted
        'AddHandler 界面控制.WebView2浏览器控件.CoreWebView2.NewWindowRequested, AddressOf Edge_CoreWebView2_NewWindowRequested
        AddHandler 计算额外参数计时器.Tick, AddressOf 计算额外参数
        '界面刷新计时器.Enabled = True

    End Sub

    Public Shared Sub 初始化功能()
        AddHandler Form1.UiButton49.Click,
            Sub()
                If 界面控制.WebView2浏览器控件 Is Nothing Then 初始化浏览器控件()
                Form1.UiTextBox5.Text = "https://users.nexusmods.com/auth/sign_in"
                '界面控制.WebView2浏览器控件.CoreWebView2.Navigate("https://users.nexusmods.com/auth/sign_in")
                获取到的HTML数据 = ""
                '界面刷新计时器.Enabled = True
            End Sub
        AddHandler Form1.UiButton40.Click,
            Sub()
                If 界面控制.WebView2浏览器控件 Is Nothing Then Exit Sub
                界面控制.WebView2浏览器控件.CoreWebView2.Reload()
            End Sub
        AddHandler Form1.UiButton50.Click,
            Sub()
                If 界面控制.WebView2浏览器控件 Is Nothing Then Exit Sub
                界面控制.WebView2浏览器控件.CoreWebView2.GoBack()
            End Sub
        AddHandler Form1.UiButton51.Click,
            Sub()
                If 界面控制.WebView2浏览器控件 Is Nothing Then Exit Sub
                界面控制.WebView2浏览器控件.CoreWebView2.GoForward()
            End Sub
        AddHandler Form1.UiButton52.Click,
            Sub()
                If 界面控制.WebView2浏览器控件 Is Nothing Then Exit Sub
                界面控制.WebView2浏览器控件.Stop()
            End Sub
        AddHandler Form1.UiButton53.Click,
            Sub()
                If 界面控制.WebView2浏览器控件 Is Nothing Then
                    初始化浏览器控件()
                Else
                    界面控制.WebView2浏览器控件.CoreWebView2.Navigate(Form1.UiTextBox5.Text)
                End If

                '界面刷新计时器.Enabled = True
            End Sub
        AddHandler Form1.UiTextBox5.KeyDown,
            Sub(sender, e)
                If e.KeyCode = Keys.Enter Then
                    If 界面控制.WebView2浏览器控件 Is Nothing Then
                        初始化浏览器控件()
                    Else
                        界面控制.WebView2浏览器控件.CoreWebView2.Navigate(Form1.UiTextBox5.Text)
                    End If

                    '界面刷新计时器.Enabled = True
                End If
            End Sub
        AddHandler Form1.UiButton54.Click,
            Sub()
                界面控制.WebView2浏览器控件.Dispose()
                界面控制.WebView2浏览器控件 = Nothing
                'Dim processes() As Process = Process.GetProcessesByName("CefSharp.BrowserSubprocess")
                'If processes.Length > 0 Then
                '    For Each proc As Process In processes
                '        If proc.MainModule.FileName = Path.Combine(Application.StartupPath, "CefSharp.BrowserSubprocess.exe") Then
                '            proc.Kill(True)
                '        End If
                '    Next
                'End If
                '界面刷新计时器.Enabled = False
                'Form1.UiTextBox5.Text = "地址刷新定时器已停止运行，打开新的网页以继续运行"
            End Sub
        AddHandler 界面刷新计时器.Tick,
            Sub()
                If 界面控制.WebView2浏览器控件 Is Nothing Then Exit Sub
                If Form1.UiTabControl1.SelectedIndex <> 5 Then Exit Sub
                If 当前地址 <> 上一次获取到的地址 Then
                    Form1.UiTextBox5.Text = 当前地址
                End If
                上一次获取到的地址 = 当前地址
            End Sub

    End Sub

    Public Shared Sub Edge_CoreWebView2InitializationCompleted(sender As Object, e As CoreWebView2InitializationCompletedEventArgs)
        AddHandler 界面控制.WebView2浏览器控件.CoreWebView2.NewWindowRequested, AddressOf Edge_CoreWebView2_NewWindowRequested
        界面控制.WebView2浏览器控件.CoreWebView2.Navigate(Form1.UiTextBox5.Text)
    End Sub

    Public Shared Sub Edge_NavigationCompleted(sender As Object, e As CoreWebView2NavigationCompletedEventArgs)

    End Sub

    Public Shared Sub Edge_SourceChanged(sender As Object, e As CoreWebView2SourceChangedEventArgs)
        当前地址 = 界面控制.WebView2浏览器控件.CoreWebView2.Source
        Form1.UiTextBox5.Text = 当前地址
    End Sub

    Public Shared Sub Edge_CoreWebView2_NewWindowRequested(sender As Object, e As CoreWebView2NewWindowRequestedEventArgs)
        e.Handled = True
        Dim newUrl As String = e.Uri
        界面控制.WebView2浏览器控件.Source = New Uri(newUrl)
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
