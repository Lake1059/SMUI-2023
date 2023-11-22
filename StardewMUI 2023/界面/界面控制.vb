Imports System.Runtime.InteropServices
Imports CefSharp.WinForms

Public Class 界面控制

    Public Shared Property CEF浏览器控件 As New ChromiumWebBrowser With {.Dock = DockStyle.Fill}


    Public Shared Sub 初始化界面()
        Form1.TabPage6.Controls.Add(CEF浏览器控件)
        Form1.UiRichTextBox4.Rtf = My.Resources.用户许可协议

        '设置富文本框行高(Form1.UiRichTextBox4, 30)
        Form1.UiRichTextBox4.AutoWordSelection = False
        Form1.UiRichTextBox4.LanguageOption = RichTextBoxLanguageOptions.UIFonts

        主界面高DPI兼容()
    End Sub

    Public Shared Sub 设置富文本框行高(RichTextBoxObject As Control, LineHeight As Integer)
        Dim fmt As New PARAFORMAT2()
        fmt.cbSize = Marshal.SizeOf(fmt)
        fmt.bLineSpacingRule = 4
        fmt.dyLineSpacing = LineHeight
        fmt.dwMask = PFM_LINESPACING
        SendMessage(New HandleRef(RichTextBoxObject, RichTextBoxObject.Handle), EM_SETPARAFORMAT, 4, fmt)
    End Sub

    Public Shared Sub 主界面高DPI兼容()
        Dim a As Graphics = Form1.CreateGraphics
        Dim X轴DPI比率 As Single = a.DpiX / 96
        Dim Y轴DPI比率 As Single = a.DpiY / 96
        If X轴DPI比率 = 1 And Y轴DPI比率 = 1 Then Exit Sub
        DebugPrint("X DPI：" & a.DpiX & " - " & X轴DPI比率 * 100 & "%" & "   Y DPI：" & a.DpiY & " - " & Y轴DPI比率 * 100 & "%", Form1.ForeColor)
        Form1.Width = Form1.MinimumSize.Width : Form1.Height = Form1.MinimumSize.Height
        Form1.UiTabControl1.ItemSize = New Size((Form1.UiTabControl1.ItemSize.Width - 1) * X轴DPI比率, (Form1.UiTabControl1.ItemSize.Height - 1) * Y轴DPI比率)
        Form1.UiButton45.Height = Form1.UiTabControl1.ItemSize.Height : Form1.UiButton45.Width -= Form1.UiTabControl1.TabCount * 0.5
        Form1.UiButton45.Left = Form1.UiTabControl1.Width - Form1.UiButton45.Width
        Form1.UiTabControlMenu1.ItemSize = New Size((Form1.UiTabControlMenu1.ItemSize.Width - 1) * X轴DPI比率, (Form1.UiTabControlMenu1.ItemSize.Height - 1) * Y轴DPI比率)
        Form1.UiTabControlMenu2.ItemSize = New Size((Form1.UiTabControlMenu2.ItemSize.Width - 1) * X轴DPI比率, (Form1.UiTabControlMenu2.ItemSize.Height - 1) * Y轴DPI比率)

        Form1.UiListBox1.ItemHeight = (Form1.UiListBox1.Height - Form1.UiListBox1.Padding.Top - Form1.UiListBox1.Padding.Bottom) / Form1.UiListBox1.Items.Count
        Form1.UiListBox2.ItemHeight = Form1.UiListBox1.ItemHeight
        Form1.UiListBox3.ItemHeight = (Form1.UiListBox3.Height - Form1.UiListBox3.Padding.Top - Form1.UiListBox3.Padding.Bottom) / Form1.UiListBox3.Items.Count



    End Sub


End Class
