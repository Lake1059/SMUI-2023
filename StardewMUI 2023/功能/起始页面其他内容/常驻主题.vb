Imports System.IO
Imports Microsoft.Win32
Imports Sunny.UI
Imports Windows.System

Public Class 常驻主题

    Public Shared Sub 初始化()

        AddHandler Form1.UiButton43.MouseClick, Sub(s, e)
                                                    Select Case e.Button
                                                        Case MouseButtons.Left
                                                            Process.Start("explorer.exe", Path.Combine(Application.StartupPath, "SMUI6.pdf"))
                                                        Case MouseButtons.Right
                                                            If 设置.全局设置数据("AgreementSigned") = "False" Then Exit Sub
                                                            Form1.UiTextBox5.Text = Path.Combine(Application.StartupPath, "SMUI6.pdf")
                                                            Form1.UiTabControl1.SelectedTab = Form1.TabPage浏览器
                                                            Form1.UiButton53.PerformClick()
                                                    End Select
                                                End Sub
        AddHandler Form1.UiButton68.Click, Async Sub(s, e) Await Launcher.LaunchUriAsync(New Uri("https://space.bilibili.com/319785096/channel/collectiondetail?sid=2903558"))
        AddHandler Form1.UiButton42.Click, Sub(s, e) Return

        AddHandler Form1.UiButton64.Click, Sub(s, e)
                                               Dim a As New Form With {.ShowIcon = False, .ShowInTaskbar = False, .Text = "", .MaximizeBox = False, .MinimizeBox = False, .StartPosition = FormStartPosition.Manual, .AutoScaleMode = AutoScaleMode.Dpi}
                                               Dim b As New PictureBox With {.Image = My.Resources.QQQ, .SizeMode = PictureBoxSizeMode.Zoom, .Dock = DockStyle.Fill}
                                               a.ClientSize = New Size(384, 384)
                                               a.Controls.Add(b)
                                               显示模式窗体(a, Form1)
                                               a.Dispose()
                                           End Sub
        AddHandler Form1.UiButton65.Click, Async Sub(s, e) Await Launcher.LaunchUriAsync(New Uri("https://kook.top/yW15HU"))

        AddHandler Form1.UiButton66.Click, Async Sub(s, e) Await Launcher.LaunchUriAsync(New Uri("https://afdian.com/a/1059Studio?tab=shop"))
        AddHandler Form1.UiButton69.Click, Async Sub(s, e) Await Launcher.LaunchUriAsync(New Uri("https://payhip.com/1059Studio"))


        注册表菜单.Items.Add(菜单项_修改nxm下载协议)
        注册表菜单.Items.Add(菜单项_移除nxm下载协议)
        AddHandler Form1.UiButton63.MouseClick, Sub(sender, e) 注册表菜单.Show(sender, 0, sender.Height)

        AddHandler 菜单项_修改nxm下载协议.Click, Sub() CheckOrCreateURLProtocol("nxm", Application.ExecutablePath)
        AddHandler 菜单项_移除nxm下载协议.Click, Sub() RemoveURLProtocol("nxm")


    End Sub


    Public Shared Property 注册表菜单 As New 暗黑菜单条控件本体 With {.ImageScalingSize = New Size(25 * 界面控制.DPI, 25 * 界面控制.DPI)}
    Public Shared Property 菜单项_修改nxm下载协议 As New ToolStripMenuItem With {.Text = "修改 nxm 下载协议转接到下载并新建项", .Image = My.Resources.NEXUS}
    Public Shared Property 菜单项_移除nxm下载协议 As New ToolStripMenuItem With {.Text = "移除 nxm 协议"}


    Shared Sub CheckOrCreateURLProtocol(protocol As String, applicationPath As String)
        Try
            Dim key As RegistryKey = Registry.ClassesRoot.OpenSubKey(protocol, True)
            If key Is Nothing Then
                key = Registry.ClassesRoot.CreateSubKey(protocol)
                If key IsNot Nothing Then
                    key.SetValue(String.Empty, "URL:MyApp Protocol")
                    key.SetValue("URL Protocol", String.Empty)
                    Dim commandKey As RegistryKey = key.CreateSubKey("shell\Open\command")
                    commandKey.SetValue(String.Empty, $"{applicationPath} ""%1""")
                End If
            Else
                Dim commandKey As RegistryKey = key.OpenSubKey("shell\Open\command", True)
                commandKey?.SetValue(String.Empty, $"{applicationPath} ""%1""")
            End If
            UIMessageTip.Show("已修改",, 2500)
            key?.Close()
        Catch ex As Exception
            Dim a As New 多项单选对话框("错误", {"OK"}, ex.Message & vbCrLf & vbCrLf & "如果遇到权限问题，请暂时以管理员身份运行 SMUI，在修改成功后再以普通权限运行 SMUI", 200, 500)
            a.ShowDialog(Form1)
        End Try
    End Sub

    Shared Sub RemoveURLProtocol(protocol As String)
        Try
            Dim protocolKey As RegistryKey = Registry.ClassesRoot.OpenSubKey(protocol, True)
            If protocolKey IsNot Nothing Then
                Registry.ClassesRoot.DeleteSubKeyTree(protocol)
                UIMessageTip.Show("协议已移除",, 2500)
            Else
                UIMessageTip.Show("协议不存在",, 2500)
            End If
        Catch ex As Exception
            Dim a As New 多项单选对话框("错误", {"OK"}, ex.Message & vbCrLf & vbCrLf & "如果遇到权限问题，请暂时以管理员身份运行 SMUI，在修改成功后再以普通权限运行 SMUI", 200, 500)
            a.ShowDialog(Form1)
        End Try
    End Sub



End Class
