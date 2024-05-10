Imports System.IO
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

        AddHandler Form1.UiButton66.Click, Async Sub(s, e) Await Launcher.LaunchUriAsync(New Uri("https://afdian.net/a/1059Studio?tab=shop"))
        AddHandler Form1.UiButton69.Click, Async Sub(s, e) Await Launcher.LaunchUriAsync(New Uri("https:/payhip.com/1059Studio"))

    End Sub






End Class
