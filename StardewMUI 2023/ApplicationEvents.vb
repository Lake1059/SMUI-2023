
Imports System.Text.RegularExpressions
Imports Microsoft.VisualBasic.ApplicationServices
Imports Sunny.UI

Namespace My
    ' The following events are available for MyApplication:
    ' Startup: Raised when the application starts, before the startup form is created.
    ' Shutdown: Raised after all application forms are closed.  This event is not raised if the application terminates abnormally.
    ' UnhandledException: Raised if the application encounters an unhandled exception.
    ' StartupNextInstance: Raised when launching a single-instance application and the application is already active. 
    ' NetworkAvailabilityChanged: Raised when the network connection is connected or disconnected.

    ' **NEW** ApplyApplicationDefaults: Raised when the application queries default values to be set for the application.

    ' Example:
    ' Private Sub MyApplication_ApplyApplicationDefaults(sender As Object, e As ApplyApplicationDefaultsEventArgs) Handles Me.ApplyApplicationDefaults
    '
    '   ' Setting the application-wide default Font:
    '   e.Font = New Font(FontFamily.GenericSansSerif, 12, FontStyle.Regular)
    '
    '   ' Setting the HighDpiMode for the Application:
    '   e.HighDpiMode = HighDpiMode.PerMonitorV2
    '
    '   ' If a splash dialog is used, this sets the minimum display time:
    '   e.MinimumSplashScreenDisplayTime = 4000
    ' End Sub

    Partial Friend Class MyApplication
        Private Sub MyApplication_Startup(sender As Object, e As StartupEventArgs) Handles Me.Startup
            If e.CommandLine.Count > 0 Then
                If e.CommandLine(0).Contains("nxm") Then
                    UIMessageTip.Show("请在 SMUI 启动完成后再调用此功能",, 2500)
                End If
            End If
        End Sub

        Private Sub MyApplication_StartupNextInstance(sender As Object, e As StartupNextInstanceEventArgs) Handles Me.StartupNextInstance
            If e.CommandLine.Count > 0 Then
                If e.CommandLine(0).Contains("nxm") Then
                    Dim regex As New Regex("mods\/(\d+)\/files\/(\d+)\?key=([^&]+)&expires=(\d+)")
                    Dim match As Match = regex.Match(e.CommandLine(0))
                    If match.Success Then
                        Dim modId As String = match.Groups(1).Value
                        Dim fileId As String = match.Groups(2).Value
                        Dim key As String = match.Groups(3).Value
                        Dim expires As String = match.Groups(4).Value
                        Dim a As New Form从管理器下载触发下载 With {.模组ID = modId, .文件ID = fileId, .Key = key, .Expires = expires}
                        显示模式窗体(a, Form1)
                    End If
                End If
            End If
        End Sub

        Private Sub MyApplication_Shutdown(sender As Object, e As EventArgs) Handles Me.Shutdown

        End Sub
    End Class
End Namespace
