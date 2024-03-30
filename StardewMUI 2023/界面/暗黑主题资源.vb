Public Class 暗黑主题资源

    Public Shared Property 菜单项选中的勾号图标 As Image = Nothing
    Public Shared Property 分类列包含的图标字典 As New Dictionary(Of String, Image)


    Public Shared Property 关于选项卡列表视图所使用的图片列表 As New ImageList With {.ColorDepth = ColorDepth.Depth32Bit, .ImageSize = New Size(42 * 界面控制.X轴DPI比率, 42 * 界面控制.Y轴DPI比率)}
    Public Shared Property 关于选项卡列表视图所使用的图片字典 As New Dictionary(Of String, Image)
    Public Shared Sub 初始化关于选项卡列表视图()
        Form1.TabPage关于.Padding = New Padding(40)
        Form1.ListView11.SmallImageList = 关于选项卡列表视图所使用的图片列表
        关于选项卡列表视图所使用的图片字典(Form1.ListView11.Items(0).Text) = My.Resources._me
        关于选项卡列表视图所使用的图片字典(Form1.ListView11.Items(1).Text) = My.Resources.ChatGPT
        关于选项卡列表视图所使用的图片字典(Form1.ListView11.Items(2).Text) = My.Resources.dropbox1
        关于选项卡列表视图所使用的图片字典(Form1.ListView11.Items(3).Text) = My.Resources.SunnyUI
        关于选项卡列表视图所使用的图片字典(Form1.ListView11.Items(4).Text) = My.Resources.DarkUI
        关于选项卡列表视图所使用的图片字典(Form1.ListView11.Items(5).Text) = My.Resources.WebView2
        关于选项卡列表视图所使用的图片字典(Form1.ListView11.Items(6).Text) = My.Resources.CEF
        关于选项卡列表视图所使用的图片字典(Form1.ListView11.Items(7).Text) = My.Resources.Jsonnet
        关于选项卡列表视图所使用的图片字典(Form1.ListView11.Items(8).Text) = My.Resources.BetterFolderBrowser
        关于选项卡列表视图所使用的图片字典(Form1.ListView11.Items(9).Text) = My.Resources._7zip
        关于选项卡列表视图所使用的图片字典(Form1.ListView11.Items(10).Text) = My.Resources._7zip
        关于选项卡列表视图所使用的图片字典(Form1.ListView11.Items(11).Text) = My.Resources._7zip
        关于选项卡列表视图所使用的图片字典(Form1.ListView11.Items(12).Text) = My.Resources.default_package_icon1
        关于选项卡列表视图所使用的图片字典(Form1.ListView11.Items(13).Text) = My.Resources.default_package_icon1
    End Sub



End Class
