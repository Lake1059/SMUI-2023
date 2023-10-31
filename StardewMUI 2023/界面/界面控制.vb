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
    End Sub

    Public Shared Sub 设置富文本框行高(RichTextBoxObject As Control, LineHeight As Integer)
        Dim fmt As New PARAFORMAT2()
        fmt.cbSize = Marshal.SizeOf(fmt)
        fmt.bLineSpacingRule = 4
        fmt.dyLineSpacing = LineHeight
        fmt.dwMask = PFM_LINESPACING
        SendMessage(New HandleRef(RichTextBoxObject, RichTextBoxObject.Handle), EM_SETPARAFORMAT, 4, fmt)
    End Sub


End Class
