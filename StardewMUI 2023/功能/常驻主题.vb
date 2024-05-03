Imports Windows.System

Public Class 常驻主题

    Public Shared Sub 初始化()
        AddHandler Form1.UiButton43.Click, Async Sub(s, e) Await Launcher.LaunchUriAsync(New Uri("https://stardewmui.fandom.com/zh/wiki/StardewMUI_Wiki"))
        AddHandler Form1.UiButton68.Click, Async Sub(s, e) Await Launcher.LaunchUriAsync(New Uri("https://space.bilibili.com/319785096/channel/collectiondetail?sid=2903558"))


        AddHandler Form1.UiButton66.Click, Async Sub(s, e) Await Launcher.LaunchUriAsync(New Uri("https://afdian.net/a/1059Studio?tab=shop"))
        AddHandler Form1.UiButton69.Click, Async Sub(s, e) Await Launcher.LaunchUriAsync(New Uri("https://payhip.com/1059Studio"))



    End Sub






End Class
