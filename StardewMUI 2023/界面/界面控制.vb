Imports System.IO
Imports System.Runtime.InteropServices
Imports Microsoft.Web.WebView2.WinForms
Imports Sunny.UI

Public Class 界面控制
    Public Shared Property DPI As Single = 1
    Public Shared Property 程序DPI_垂直滚动条宽度 As Integer = GetScrollBarWidth()
    'Public Shared Property CEF浏览器控件 As ChromiumWebBrowser
    Public Shared Property WebView2浏览器控件 As WebView2

    Public Shared Sub 初始化界面()
        'If 设置.全局设置数据("UseWhichBrowser") = "Edge" Then
        浏览器WebView2控制.初始化功能()
        AddHandler Form1.Label42.DragEnter, Sub(s, e) 浏览器WebView2控制.ModDrop文本DragEnter(s, e)
        AddHandler Form1.Label42.DragDrop, Sub(s, e) 浏览器WebView2控制.ModDrop文本DragDrop(s, e)
        'Else
        '    浏览器CEF控制.初始化功能()
        'End If

        Form1.TabPage更新记录.Padding = New Padding(20)
        Form1.TabPage许可协议.Padding = New Padding(20)
        Form1.UiRichTextBox4.Rtf = My.Resources.用户许可协议
        Form1.UiRichTextBox3.LoadFile(Path.Combine(Application.StartupPath, "UpdateLog.rtf"))

        设置富文本框行高(Form1.RichTextBox1, 300)
        Form1.RichTextBox1.AutoWordSelection = False
        Form1.RichTextBox1.LanguageOption = RichTextBoxLanguageOptions.UIFonts
        设置富文本框行高(Form1.UiRichTextBox2, 30)
        Form1.UiRichTextBox2.AutoWordSelection = False
        Form1.UiRichTextBox2.LanguageOption = RichTextBoxLanguageOptions.UIFonts
        设置富文本框行高(Form1.RichTextBox2, 300)
        Form1.RichTextBox2.AutoWordSelection = False
        Form1.RichTextBox2.LanguageOption = RichTextBoxLanguageOptions.UIFonts
        设置富文本框行高(Form1.RichTextBox3, 300)
        Form1.RichTextBox3.AutoWordSelection = False
        Form1.RichTextBox3.LanguageOption = RichTextBoxLanguageOptions.UIFonts

        AddHandler Form1.UiRichTextBox2.KeyDown, Sub(sender, e) If e.KeyData = Keys.Delete Then Form1.UiRichTextBox2.Clear()

        暗黑列表视图自绘制.绑定列表视图事件(Form1.ListView1)
        暗黑列表视图自绘制.绑定列表视图事件(Form1.ListView2)
        暗黑列表视图自绘制.绑定列表视图事件(Form1.ListView3)
        暗黑列表视图自绘制.绑定列表视图事件(Form1.ListView4)
        暗黑列表视图自绘制.绑定列表视图事件(Form1.ListView5)
        暗黑列表视图自绘制.绑定列表视图事件(Form1.ListView6)
        暗黑列表视图自绘制.绑定列表视图事件(Form1.ListView7)
        暗黑列表视图自绘制.绑定列表视图事件(Form1.ListView8)
        暗黑列表视图自绘制.绑定列表视图事件(Form1.ListView9)
        暗黑列表视图自绘制.绑定列表视图事件(Form1.ListView10)
        暗黑列表视图自绘制.绑定列表视图事件(Form1.ListView11)
        暗黑列表视图自绘制.绑定列表视图事件(Form1.ListView12)
        暗黑列表视图自绘制.绑定列表视图事件(Form1.ListView13)
        暗黑列表视图自绘制.绑定列表视图事件(Form1.ListView14)
        暗黑列表视图自绘制.绑定列表视图事件(Form1.ListView15)

        Form1.ImageList1.ImageSize = New Size(1, Form1.ImageList1.ImageSize.Height * DPI)

        内容中心.初始化()
        管理模组的菜单.添加菜单的触发()
        配置队列的菜单.添加菜单的触发()
        AddHandler Form1.UiButton45.Click, AddressOf 状态信息.启动SMAPI
        AddHandler Form1.UiButton48.Click, Sub() 新闻列表.获取新闻(True)
        AddHandler Form1.UiButton46.Click, Sub() 检查更新.运行后台服务器检查更新()
        AddHandler Form1.UiRichTextBox4.LinkClicked, AddressOf 许可协议签署执行
        主界面高DPI兼容()




    End Sub

    Public Shared Sub 初始化依赖项窗口()
        Form依赖项表.ListView1.DoubleBuffered(True)
        AddHandler Form依赖项表.ListView1.DrawSubItem, Sub(sender, e) 暗黑列表视图自绘制.绘制子项(sender, e)
        AddHandler Form依赖项表.ListView1.SelectedIndexChanged, Sub(sender, e) sender.Invalidate(sender.ClientRectangle)
        AddHandler Form依赖项表.ListView1.ItemMouseHover, Sub(sender, e) sender.Invalidate(sender.ClientRectangle)
    End Sub
    Public Shared Sub 初始化依赖项窗口(哪个依赖项窗口 As Form依赖项表)
        哪个依赖项窗口.ListView1.DoubleBuffered(True)
        AddHandler 哪个依赖项窗口.ListView1.DrawSubItem, Sub(sender, e) 暗黑列表视图自绘制.绘制子项(sender, e)
        AddHandler 哪个依赖项窗口.ListView1.SelectedIndexChanged, Sub(sender, e) sender.Invalidate(sender.ClientRectangle)
        AddHandler 哪个依赖项窗口.ListView1.ItemMouseHover, Sub(sender, e) sender.Invalidate(sender.ClientRectangle)
    End Sub
    Public Shared Sub 初始化其他列表视图(哪个列表视图 As ListView)
        哪个列表视图.DoubleBuffered(True)
        AddHandler 哪个列表视图.DrawSubItem, Sub(sender, e) 暗黑列表视图自绘制.绘制子项(sender, e)
        AddHandler 哪个列表视图.SelectedIndexChanged, Sub(sender, e) sender.Invalidate(sender.ClientRectangle)
        AddHandler 哪个列表视图.ItemMouseHover, Sub(sender, e) sender.Invalidate(sender.ClientRectangle)
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
        Dim 垂直滚动条实际预留宽度 As Integer = 程序DPI_垂直滚动条宽度 * 2

        Form1.Panel13.Width = Form1.Panel13.Parent.Width * 0.5

        Form1.RichTextBox1.Width = Form1.RichTextBox1.Parent.Width + 程序DPI_垂直滚动条宽度 - Form1.RichTextBox1.Parent.Padding.Left
        Form1.RichTextBox1.RightMargin = Form1.RichTextBox1.Width - 垂直滚动条实际预留宽度
        Form1.RichTextBox2.Width = Form1.RichTextBox2.Parent.Width + 程序DPI_垂直滚动条宽度
        Form1.RichTextBox2.RightMargin = Form1.RichTextBox2.Width - 垂直滚动条实际预留宽度

        Form1.ListView1.Width = Form1.ListView1.Parent.Width - Form1.ListView1.Parent.Padding.Left + 程序DPI_垂直滚动条宽度
        Form1.ColumnHeader1.Width = Form1.ListView1.Parent.Width - Form1.ListView1.Parent.Padding.Left * 2
        Form1.ColumnHeader2.Width = (Form1.ListView2.Width - 垂直滚动条实际预留宽度) * 0.65
        Form1.ColumnHeader3.Width = (Form1.ListView2.Width - 垂直滚动条实际预留宽度) * 0.15
        Form1.ColumnHeader4.Width = (Form1.ListView2.Width - 垂直滚动条实际预留宽度) * 0.2

        Form1.Panel16.Width = Form1.Panel16.Parent.Width * 0.475

        Form1.ColumnHeader5.Width = (Form1.ListView3.Width - 垂直滚动条实际预留宽度) * 0.7
        Form1.ColumnHeader10.Width = (Form1.ListView3.Width - 垂直滚动条实际预留宽度) * 0.3

        Form1.ColumnHeader6.Width = (Form1.ListView6.Width - 垂直滚动条实际预留宽度) * 0.8
        Form1.ColumnHeader12.Width = (Form1.ListView6.Width - 垂直滚动条实际预留宽度) * 0.2

        Form1.ColumnHeader7.Width = (Form1.ListView7.Width - 垂直滚动条实际预留宽度) * 0.3
        Form1.ColumnHeader8.Width = (Form1.ListView7.Width - 垂直滚动条实际预留宽度) * 0.7

        Form1.UiButton45.Height = Form1.UiTabControl1.ItemSize.Height : Form1.UiButton45.Width = Form1.UiTabControl1.Width - Form1.UiTabControl1.ItemSize.Width * 7
        Form1.UiButton45.Left = Form1.UiTabControl1.Width - Form1.UiButton45.Width : Form1.UiButton45.Top = 0

        Form1.ColumnHeader14.Width = (Form1.ListView10.Width - 垂直滚动条实际预留宽度) * 0.6
        Form1.ColumnHeader15.Width = (Form1.ListView10.Width - 垂直滚动条实际预留宽度) * 0.2
        Form1.ColumnHeader16.Width = (Form1.ListView10.Width - 垂直滚动条实际预留宽度) * 0.2

        Form1.ColumnHeader9.Width = Form1.ListView9.Width * 0.7
        Form1.ColumnHeader13.Width = Form1.ListView9.Width * 0.3
        Form1.ColumnHeader11.Width = Form1.ListView4.Width - 垂直滚动条实际预留宽度

        Form1.ColumnHeader21.Width = (Form1.ListView8.Width - 垂直滚动条实际预留宽度) * 0.5
        Form1.ColumnHeader22.Width = (Form1.ListView8.Width - 垂直滚动条实际预留宽度) * 0.25
        Form1.ColumnHeader23.Width = (Form1.ListView8.Width - 垂直滚动条实际预留宽度) * 0.25

        Form1.ColumnHeader20.Width = (Form1.ListView11.Width - 垂直滚动条实际预留宽度) * 0.3
        Form1.ColumnHeader24.Width = (Form1.ListView11.Width - 垂直滚动条实际预留宽度) * 0.3
        Form1.ColumnHeader25.Width = (Form1.ListView11.Width - 垂直滚动条实际预留宽度) * 0.1
        Form1.ColumnHeader26.Width = (Form1.ListView11.Width - 垂直滚动条实际预留宽度) * 0.1
        Form1.ColumnHeader27.Width = (Form1.ListView11.Width - 垂直滚动条实际预留宽度) * 0.2

        Form1.ColumnHeader30.Width = (Form1.ListView12.Width - 垂直滚动条实际预留宽度) * 0.2
        Form1.ColumnHeader31.Width = (Form1.ListView12.Width - 垂直滚动条实际预留宽度) * 0.2
        Form1.ColumnHeader32.Width = (Form1.ListView12.Width - 垂直滚动条实际预留宽度) * 0.15
        Form1.ColumnHeader33.Width = (Form1.ListView12.Width - 垂直滚动条实际预留宽度) * 0.15
        Form1.ColumnHeader34.Width = (Form1.ListView12.Width - 垂直滚动条实际预留宽度) * 0.3

        Form1.ColumnHeader18.Width = (Form1.ListView5.Width - 垂直滚动条实际预留宽度) * 0.3
        Form1.ColumnHeader19.Width = (Form1.ListView5.Width - 垂直滚动条实际预留宽度) * 0.15
        Form1.ColumnHeader28.Width = (Form1.ListView5.Width - 垂直滚动条实际预留宽度) * 0.35
        Form1.ColumnHeader29.Width = (Form1.ListView5.Width - 垂直滚动条实际预留宽度) * 0.2

        Form1.ColumnHeader35.Width = Form1.ListView13.Width - 垂直滚动条实际预留宽度
        Form1.ColumnHeader36.Width = Form1.ListView14.Width - 垂直滚动条实际预留宽度
        Form1.ColumnHeader37.Width = Form1.ListView15.Width - 垂直滚动条实际预留宽度

    End Sub

    Public Shared Sub 主界面高DPI兼容()
        DebugPrint("DPI：" & DPI & " - " & DPI * 100 & "%", Form1.ForeColor)
        Form1.MinimumSize = New Size(1280 * DPI, 789 * DPI)
        Form1.Size = Form1.MinimumSize
        DebugPrint(Form1.Size.ToString, Form1.ForeColor)

        Form1.UiTabControl1.ItemSize = New Size(151 * DPI, 50 * DPI)

        Form1.UiTabControlMenu1.ItemSize = New Size(150 * DPI, 40 * DPI)
        Form1.UiTabControlMenu2.ItemSize = New Size(200 * DPI, 40 * DPI)
        Form1.UiTabControlMenu3.ItemSize = New Size(300 * DPI, 50 * DPI)
        Form1.UiTabControlMenu4.ItemSize = New Size(200 * DPI, 40 * DPI)
        Form1.UiTabControl2.ItemSize = New Size(302 * DPI, 40 * DPI)

        Form1.UiListBox1.Left = 23 * DPI : Form1.UiListBox1.Top = 61 * DPI : Form1.UiListBox1.Width = 470 * DPI : Form1.UiListBox1.Height = 171 * DPI
        Form1.UiListBox1.ItemHeight = 30 * DPI
        Form1.UiListBox1.Padding = New Padding(10 * DPI)

        Form1.UiListBox3.Left = 20 * DPI : Form1.UiListBox3.Top = 570 * DPI : Form1.UiListBox3.Width = 560 * DPI : Form1.UiListBox3.Height = 110 * DPI
        Form1.UiListBox3.ItemHeight = 30 * DPI
        Form1.UiListBox3.Padding = New Padding(10 * DPI)

        Form1.UiComboBox1.ItemHeight = 30 * DPI
        Form1.UiComboBox2.ItemHeight = 30 * DPI
        Form1.UiComboBox3.ItemHeight = 30 * DPI
        Form1.UiComboBox4.ItemHeight = 30 * DPI
        Form1.UiComboBox8.ItemHeight = 30 * DPI
        Form1.UiComboBox6.ItemHeight = 30 * DPI
        Form1.UiComboBox5.ItemHeight = 30 * DPI
        Form1.UiComboBox8.ItemHeight = 30 * DPI
        Form1.UiComboBox7.ItemHeight = 30 * DPI
        Form1.UiComboBox9.ItemHeight = 30 * DPI
        Form1.UiComboBox10.ItemHeight = 30 * DPI

        Form1.UiComboBox4.Left = 20 * DPI : Form1.UiComboBox4.Top = 111 * DPI : Form1.UiComboBox4.Width = 300 * DPI : Form1.UiComboBox4.Height = 30 * DPI
        Form1.UiComboBox1.Left = 20 * DPI : Form1.UiComboBox1.Top = 202 * DPI : Form1.UiComboBox1.Width = 300 * DPI : Form1.UiComboBox1.Height = 30 * DPI
        Form1.UiComboBox2.Left = 20 * DPI : Form1.UiComboBox2.Top = 293 * DPI : Form1.UiComboBox2.Width = 300 * DPI : Form1.UiComboBox2.Height = 30 * DPI
        Form1.UiComboBox3.Left = 20 * DPI : Form1.UiComboBox3.Top = 384 * DPI : Form1.UiComboBox3.Width = 300 * DPI : Form1.UiComboBox3.Height = 30 * DPI
        Form1.UiComboBox5.Left = 20 * DPI : Form1.UiComboBox5.Top = 475 * DPI : Form1.UiComboBox5.Width = 300 * DPI : Form1.UiComboBox5.Height = 30 * DPI
        Form1.UiComboBox8.Left = 20 * DPI : Form1.UiComboBox8.Top = 61 * DPI : Form1.UiComboBox8.Width = 300 * DPI : Form1.UiComboBox8.Height = 30 * DPI
        Form1.UiComboBox7.Left = 40 * DPI : Form1.UiComboBox7.Top = 61 * DPI : Form1.UiComboBox7.Width = 470 * DPI : Form1.UiComboBox7.Height = 35 * DPI
        Form1.UiComboBox9.Left = 40 * DPI : Form1.UiComboBox9.Top = 261 * DPI : Form1.UiComboBox9.Width = 470 * DPI : Form1.UiComboBox9.Height = 35 * DPI
        Form1.UiComboBox10.Left = 20 * DPI : Form1.UiComboBox10.Top = 283 * DPI : Form1.UiComboBox10.Width = 263 * DPI : Form1.UiComboBox10.Height = 30 * DPI

        Form1.UiRadioButton1.RadioButtonSize = 20 * DPI
        Form1.UiRadioButton2.RadioButtonSize = 20 * DPI
        Form1.UiRadioButton3.RadioButtonSize = 20 * DPI
        Form1.UiRadioButton4.RadioButtonSize = 20 * DPI
        'Form1.UiRadioButton5.RadioButtonSize = 20 * DPI
        'Form1.UiRadioButton6.RadioButtonSize = 20 * DPI
        Form1.UiRadioButton7.RadioButtonSize = 20 * DPI
        Form1.UiRadioButton8.RadioButtonSize = 20 * DPI
        Form1.UiRadioButton9.RadioButtonSize = 20 * DPI
        Form1.UiRadioButton10.RadioButtonSize = 20 * DPI

        'Form1.UiCheckBox1.CheckBoxSize = 20 * DPI
        Form1.UiCheckBox2.CheckBoxSize = 20 * DPI
        Form1.UiCheckBox3.CheckBoxSize = 20 * DPI
        Form1.UiCheckBox4.CheckBoxSize = 20 * DPI
        Form1.UiCheckBox5.CheckBoxSize = 20 * DPI
        'Form1.UiCheckBox6.CheckBoxSize = 20 * DPI
        Form1.UiCheckBox7.CheckBoxSize = 20 * DPI
        Form1.UiCheckBox8.CheckBoxSize = 20 * DPI
        Form1.UiCheckBox9.CheckBoxSize = 20 * DPI
        Form1.UiCheckBox10.CheckBoxSize = 20 * DPI
        Form1.UiCheckBox11.CheckBoxSize = 20 * DPI
        Form1.UiCheckBox12.CheckBoxSize = 20 * DPI
        Form1.UiCheckBox13.CheckBoxSize = 20 * DPI
        Form1.UiCheckBox14.CheckBoxSize = 20 * DPI
        Form1.UiCheckBox15.CheckBoxSize = 20 * DPI
        Form1.UiCheckBox16.CheckBoxSize = 20 * DPI
        Form1.UiCheckBox17.CheckBoxSize = 20 * DPI
        Form1.UiCheckBox18.CheckBoxSize = 20 * DPI

        Form1.ImageList1.ImageSize = New Size(1, 29 * DPI)
        管理模组的菜单.调整DPI()
        内容中心.调整DPI()
    End Sub



    Public Shared Sub 许可协议签署执行()
        If 设置.全局设置数据("AgreementSigned") = "True" Then Exit Sub
        设置.全局设置数据("AgreementSigned") = "True"
        Dim a As New 多项单选对话框("已签署", {"OK"}, "签署已保存到设置，正常退出软件时才会将设置写入文件，现在可以正常使用了。", 100, 500)
        a.ShowDialog(Form1)
        设置.恢复选项卡显示()
    End Sub

End Class
