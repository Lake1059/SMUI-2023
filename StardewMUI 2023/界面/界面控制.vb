Imports System.Runtime.InteropServices
Imports CefSharp.WinForms
Imports Microsoft.Web.WebView2.WinForms
Imports Sunny.UI

Public Class 界面控制
    Public Shared Property A As Graphics = Form1.CreateGraphics
    Public Shared Property X轴DPI比率 As Single = A.DpiX / 96
    Public Shared Property Y轴DPI比率 As Single = A.DpiY / 96
    Public Shared Property 程序DPI_垂直滚动条宽度 As Integer = GetScrollBarWidth()
    Public Shared Property CEF浏览器控件 As ChromiumWebBrowser
    Public Shared Property WebView2浏览器控件 As WebView2


    Public Shared Sub 初始化界面()
        If 设置.全局设置数据("UseWhichBrowser") = "Edge" Then
            浏览器WebView2控制.初始化功能()
        Else
            浏览器CEF控制.初始化功能()
        End If
        Form1.UiRichTextBox4.Rtf = My.Resources.用户许可协议
        Form1.UiRichTextBox3.Rtf = My.Resources.更新记录

        设置富文本框行高(Form1.UiRichTextBox1, 35)
        Form1.UiRichTextBox1.AutoWordSelection = False
        Form1.UiRichTextBox1.LanguageOption = RichTextBoxLanguageOptions.UIFonts
        Form1.UiRichTextBox1.RightMargin = Form1.UiRichTextBox1.Width - 程序DPI_垂直滚动条宽度


        暗黑主题资源.初始化关于选项卡列表视图()

        Form1.ListView1.DoubleBuffered(True)
        Form1.ListView2.DoubleBuffered(True)
        Form1.ListView3.DoubleBuffered(True)
        Form1.ListView4.DoubleBuffered(True)
        Form1.ListView5.DoubleBuffered(True)
        Form1.ListView6.DoubleBuffered(True)
        Form1.ListView7.DoubleBuffered(True)
        Form1.ListView8.DoubleBuffered(True)
        Form1.ListView9.DoubleBuffered(True)
        Form1.ListView10.DoubleBuffered(True)
        Form1.ListView11.DoubleBuffered(True)

        AddHandler Form1.ListView1.DrawSubItem, Sub(sender, e) 暗黑列表视图自绘制.绘制子项(sender, e, 暗黑主题资源.分类列包含的图标字典)
        AddHandler Form1.ListView1.SelectedIndexChanged, Sub(sender, e) sender.Invalidate(sender.ClientRectangle)
        AddHandler Form1.ListView1.ItemMouseHover, Sub(sender, e) sender.Invalidate(sender.ClientRectangle)
        AddHandler Form1.ListView2.DrawSubItem, Sub(sender, e) 暗黑列表视图自绘制.绘制子项(sender, e, New Dictionary(Of String, Image))
        AddHandler Form1.ListView2.SelectedIndexChanged, Sub(sender, e) sender.Invalidate(sender.ClientRectangle)
        AddHandler Form1.ListView2.ItemMouseHover, Sub(sender, e) sender.Invalidate(sender.ClientRectangle)
        AddHandler Form1.ListView3.DrawSubItem, Sub(sender, e) 暗黑列表视图自绘制.绘制子项(sender, e, New Dictionary(Of String, Image))
        AddHandler Form1.ListView3.SelectedIndexChanged, Sub(sender, e) sender.Invalidate(sender.ClientRectangle)
        AddHandler Form1.ListView3.ItemMouseHover, Sub(sender, e) sender.Invalidate(sender.ClientRectangle)
        AddHandler Form1.ListView4.DrawSubItem, Sub(sender, e) 暗黑列表视图自绘制.绘制子项(sender, e, New Dictionary(Of String, Image))
        AddHandler Form1.ListView4.SelectedIndexChanged, Sub(sender, e) sender.Invalidate(sender.ClientRectangle)
        AddHandler Form1.ListView4.ItemMouseHover, Sub(sender, e) sender.Invalidate(sender.ClientRectangle)
        AddHandler Form1.ListView5.DrawSubItem, Sub(sender, e) 暗黑列表视图自绘制.绘制子项(sender, e, New Dictionary(Of String, Image))
        AddHandler Form1.ListView5.SelectedIndexChanged, Sub(sender, e) sender.Invalidate(sender.ClientRectangle)
        AddHandler Form1.ListView5.ItemMouseHover, Sub(sender, e) sender.Invalidate(sender.ClientRectangle)
        AddHandler Form1.ListView6.DrawSubItem, Sub(sender, e) 暗黑列表视图自绘制.绘制子项(sender, e, New Dictionary(Of String, Image))
        AddHandler Form1.ListView6.SelectedIndexChanged, Sub(sender, e) sender.Invalidate(sender.ClientRectangle)
        AddHandler Form1.ListView6.ItemMouseHover, Sub(sender, e) sender.Invalidate(sender.ClientRectangle)
        AddHandler Form1.ListView7.DrawSubItem, Sub(sender, e) 暗黑列表视图自绘制.绘制子项(sender, e, New Dictionary(Of String, Image))
        AddHandler Form1.ListView7.SelectedIndexChanged, Sub(sender, e) sender.Invalidate(sender.ClientRectangle)
        AddHandler Form1.ListView7.ItemMouseHover, Sub(sender, e) sender.Invalidate(sender.ClientRectangle)
        AddHandler Form1.ListView8.DrawSubItem, Sub(sender, e) 暗黑列表视图自绘制.绘制子项(sender, e, New Dictionary(Of String, Image))
        AddHandler Form1.ListView8.SelectedIndexChanged, Sub(sender, e) sender.Invalidate(sender.ClientRectangle)
        AddHandler Form1.ListView8.ItemMouseHover, Sub(sender, e) sender.Invalidate(sender.ClientRectangle)
        AddHandler Form1.ListView9.DrawSubItem, Sub(sender, e) 暗黑列表视图自绘制.绘制子项(sender, e, New Dictionary(Of String, Image))
        AddHandler Form1.ListView9.SelectedIndexChanged, Sub(sender, e) sender.Invalidate(sender.ClientRectangle)
        AddHandler Form1.ListView9.ItemMouseHover, Sub(sender, e) sender.Invalidate(sender.ClientRectangle)
        AddHandler Form1.ListView10.DrawSubItem, Sub(sender, e) 暗黑列表视图自绘制.绘制子项(sender, e, New Dictionary(Of String, Image))
        AddHandler Form1.ListView10.SelectedIndexChanged, Sub(sender, e) sender.Invalidate(sender.ClientRectangle)
        AddHandler Form1.ListView10.ItemMouseHover, Sub(sender, e) sender.Invalidate(sender.ClientRectangle)
        AddHandler Form1.ListView11.DrawSubItem, Sub(sender, e) 暗黑列表视图自绘制.绘制子项(sender, e, 暗黑主题资源.关于选项卡列表视图所使用的图片字典, 36)
        AddHandler Form1.ListView11.SelectedIndexChanged, Sub(sender, e) sender.Invalidate(sender.ClientRectangle)
        AddHandler Form1.ListView11.ItemMouseHover, Sub(sender, e) sender.Invalidate(sender.ClientRectangle)




        多项单选对话框.GlobalDpixRatio = X轴DPI比率
        Form1.ImageList1.ImageSize = New Size(1, Form1.ImageList1.ImageSize.Height * Y轴DPI比率)

        主界面高DPI兼容()
        管理模组的菜单.添加菜单的触发()
        新闻列表.绑定新闻列表操作()

        AddHandler Form1.UiRichTextBox4.LinkClicked, AddressOf 许可协议签署执行
    End Sub

    Public Shared Sub 初始化依赖项窗口()
        Form依赖项表.ListView1.DoubleBuffered(True)
        AddHandler Form依赖项表.ListView1.DrawSubItem, Sub(sender, e) 暗黑列表视图自绘制.绘制子项(sender, e, New Dictionary(Of String, Image))
        AddHandler Form依赖项表.ListView1.SelectedIndexChanged, Sub(sender, e) sender.Invalidate(sender.ClientRectangle)
        AddHandler Form依赖项表.ListView1.ItemMouseHover, Sub(sender, e) sender.Invalidate(sender.ClientRectangle)
    End Sub
    Public Shared Sub 初始化依赖项窗口(哪个依赖项窗口 As Form依赖项表)
        哪个依赖项窗口.ListView1.DoubleBuffered(True)
        AddHandler 哪个依赖项窗口.ListView1.DrawSubItem, Sub(sender, e) 暗黑列表视图自绘制.绘制子项(sender, e, New Dictionary(Of String, Image))
        AddHandler 哪个依赖项窗口.ListView1.SelectedIndexChanged, Sub(sender, e) sender.Invalidate(sender.ClientRectangle)
        AddHandler 哪个依赖项窗口.ListView1.ItemMouseHover, Sub(sender, e) sender.Invalidate(sender.ClientRectangle)
    End Sub

    Public Shared Sub 设置富文本框行高(RichTextBoxObject As Control, LineHeight As Integer)
        Dim fmt As New PARAFORMAT2()
        fmt.cbSize = Marshal.SizeOf(fmt)
        fmt.bLineSpacingRule = 4
        fmt.dyLineSpacing = LineHeight
        fmt.dwMask = PFM_LINESPACING
        SendMessage(New HandleRef(RichTextBoxObject, RichTextBoxObject.Handle), EM_SETPARAFORMAT, 4, fmt)
    End Sub

    Public Shared Sub 主界面元素尺寸动态调整()
        Form1.Panel13.Width = Form1.Panel13.Parent.Width * 0.5

        Form1.ListView1.Width = Form1.ListView1.Parent.Width - Form1.ListView1.Parent.Padding.Left + 程序DPI_垂直滚动条宽度
        Form1.ColumnHeader1.Width = Form1.ListView1.Parent.Width - Form1.ListView1.Parent.Padding.Left * 2
        Form1.ColumnHeader2.Width = (Form1.ListView2.Width - 程序DPI_垂直滚动条宽度 * 2) * 0.65
        Form1.ColumnHeader3.Width = (Form1.ListView2.Width - 程序DPI_垂直滚动条宽度 * 2) * 0.15
        Form1.ColumnHeader4.Width = (Form1.ListView2.Width - 程序DPI_垂直滚动条宽度 * 2) * 0.2

        Form1.Panel16.Width = Form1.Panel16.Parent.Width * 0.475

        Form1.ColumnHeader5.Width = (Form1.ListView3.Width - 程序DPI_垂直滚动条宽度 * 2) * 0.7
        Form1.ColumnHeader10.Width = (Form1.ListView3.Width - 程序DPI_垂直滚动条宽度 * 2) * 0.3

        Form1.ColumnHeader6.Width = (Form1.ListView6.Width - 程序DPI_垂直滚动条宽度 * 2) * 0.8
        Form1.ColumnHeader12.Width = (Form1.ListView6.Width - 程序DPI_垂直滚动条宽度 * 2) * 0.2

        Form1.ColumnHeader7.Width = (Form1.ListView7.Width - 程序DPI_垂直滚动条宽度 * 2) * 0.3
        Form1.ColumnHeader8.Width = (Form1.ListView7.Width - 程序DPI_垂直滚动条宽度 * 2) * 0.7


    End Sub

    Public Shared Sub 主界面高DPI兼容()
        If X轴DPI比率 = 1 And Y轴DPI比率 = 1 Then Exit Sub
        DebugPrint("X DPI：" & A.DpiX & " - " & X轴DPI比率 * 100 & "%" & "   Y DPI：" & A.DpiY & " - " & Y轴DPI比率 * 100 & "%", Form1.ForeColor)
        Form1.MinimumSize = New Size(1280 * X轴DPI比率, 720 * Y轴DPI比率)
        Form1.Size = Form1.MinimumSize

        Form1.UiTabControl1.ItemSize = New Size((Form1.UiTabControl1.ItemSize.Width - 1) * X轴DPI比率, (Form1.UiTabControl1.ItemSize.Height - 1) * Y轴DPI比率)

        Form1.UiButton45.Height = Form1.UiTabControl1.ItemSize.Height : Form1.UiButton45.Width -= Form1.UiTabControl1.TabCount * 0.5
        Form1.UiButton45.Left = Form1.UiTabControl1.Width - Form1.UiButton45.Width
        Form1.UiTabControlMenu1.ItemSize = New Size(Form1.UiTabControl1.ItemSize.Width - 1, (Form1.UiTabControlMenu1.ItemSize.Height - 1) * Y轴DPI比率)
        Form1.UiTabControlMenu2.ItemSize = New Size(Form1.UiTabControlMenu2.ItemSize.Width - 1 * X轴DPI比率 - X轴DPI比率, (Form1.UiTabControlMenu2.ItemSize.Height - 1) * Y轴DPI比率)
        Form1.UiTabControlMenu3.ItemSize = New Size(Form1.UiTabControlMenu3.ItemSize.Width - 1 * X轴DPI比率, (Form1.UiTabControlMenu3.ItemSize.Height - 1) * Y轴DPI比率)
        Form1.UiTabControlMenu4.ItemSize = New Size(Form1.UiTabControlMenu4.ItemSize.Width - 1 * X轴DPI比率, (Form1.UiTabControlMenu4.ItemSize.Height - 1) * Y轴DPI比率)

        Form1.UiTabControl2.ItemSize = New Size((Form1.UiTabControl2.ItemSize.Width - 1) * X轴DPI比率, (Form1.UiTabControl2.ItemSize.Height - 1) * Y轴DPI比率)

        Form1.UiListBox1.ItemHeight = (Form1.UiListBox1.Height - Form1.UiListBox1.Padding.Top - Form1.UiListBox1.Padding.Bottom) / Form1.UiListBox1.Items.Count
        Form1.UiListBox2.ItemHeight = Form1.UiListBox1.ItemHeight
        Form1.UiListBox3.ItemHeight = Form1.UiListBox1.ItemHeight
        Form1.UiListBox4.ItemHeight = Form1.UiListBox1.ItemHeight

        Form1.UiComboBox1.ItemHeight = 30 * Y轴DPI比率
        Form1.UiComboBox2.ItemHeight = 30 * Y轴DPI比率
        Form1.UiComboBox3.ItemHeight = 30 * Y轴DPI比率
        Form1.UiComboBox4.ItemHeight = 30 * Y轴DPI比率
        Form1.UiComboBox5.ItemHeight = 30 * Y轴DPI比率
        Form1.UiComboBox6.ItemHeight = 30 * Y轴DPI比率
        Form1.UiComboBox7.ItemHeight = 30 * Y轴DPI比率
    End Sub

    Public Shared Sub 许可协议签署执行()
        设置.全局设置数据("AgreementSigned") = "True"
        Dim a As New 多项单选对话框("已签署", {"OK"}, "签署已保存到设置，正常退出软件时才会将设置写入文件，现在可以正常使用了。", 100, 500)
        a.ShowDialog(Form1)
        设置.恢复选项卡显示()
    End Sub

End Class
