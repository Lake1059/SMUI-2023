Public Class 暗黑列表视图自绘制

    Public Shared Property 项被选中时的背景颜色 As Color = ColorTranslator.FromWin32(RGB(64, 64, 64))

    ''' <summary>
    ''' 绑定此事件时不要绑定 DrawListViewItemEvent 事件，本事件直接绘制主项和图标
    ''' </summary>
    ''' <param name="哪个列表视图控件"></param>
    ''' <param name="e"></param>
    ''' <param name="项图标字典">键是主项文本，值是 Image，如果有对应的图片不要忘记在变动主项文本的同时修改字典里的键名称</param>
    Public Shared Sub 绘制子项(哪个列表视图控件 As ListView, e As DrawListViewSubItemEventArgs, 项图标字典 As Dictionary(Of String, Image))
        e.DrawDefault = False
        If Not e.Bounds.IntersectsWith(哪个列表视图控件.ClientRectangle) Then Exit Sub
        Dim 项背景色 As Color = If(哪个列表视图控件.SelectedIndices.Contains(e.ItemIndex), 项被选中时的背景颜色, 哪个列表视图控件.BackColor)
        e.Graphics.FillRectangle(New SolidBrush(项背景色), e.Bounds)
        Dim 文本高度修正 As Integer = (e.Bounds.Height - TextRenderer.MeasureText(e.SubItem.Text, e.SubItem.Font).Height) \ 2
        Dim 文本绘制区 As New Rectangle(e.Bounds.X + 5, e.Bounds.Y + 文本高度修正, e.Bounds.Width - 5, e.Bounds.Height)
        If e.ColumnIndex = 0 Then
            If 项图标字典.ContainsKey(e.Item.Name) Then
                文本绘制区.X += 5 : 文本绘制区.Width -= 5
                If e.ColumnIndex = 0 Then 文本绘制区.X += 16 * 界面控制.X轴DPI比率 : 文本绘制区.Width -= 16 * 界面控制.X轴DPI比率
                Dim 图标绘制区 As New Rectangle(e.Bounds.X + 5, e.Bounds.Y + (e.Bounds.Height - 16 * 界面控制.Y轴DPI比率) \ 2, 16 * 界面控制.X轴DPI比率, 16 * 界面控制.Y轴DPI比率)
                e.Graphics.DrawImage(项图标字典(e.ItemIndex), 图标绘制区)
            End If
        End If
        Dim 文字显示所需尺寸 As Size = TextRenderer.MeasureText(e.SubItem.Text, e.SubItem.Font)
        If 文字显示所需尺寸.Width > (e.Bounds.Width - 5 * 界面控制.X轴DPI比率) Then
            Dim 点号所占用的宽度 As Integer = TextRenderer.MeasureText("...", e.SubItem.Font).Width
            Dim 实际文本可用宽度 As Integer = e.Bounds.Width - 点号所占用的宽度
            Dim 实际要绘制的文本 As String = e.SubItem.Text
            While TextRenderer.MeasureText(实际要绘制的文本, e.SubItem.Font).Width > 实际文本可用宽度 AndAlso 实际要绘制的文本.Length > 0
                实际要绘制的文本 = 实际要绘制的文本.Substring(0, 实际要绘制的文本.Length - 1)
            End While
            实际要绘制的文本 &= "..."
            TextRenderer.DrawText(e.Graphics, 实际要绘制的文本.Replace("&", "&&"), e.SubItem.Font, 文本绘制区, e.Item.ForeColor, 项背景色, TextFormatFlags.Default)
        Else
            TextRenderer.DrawText(e.Graphics, e.SubItem.Text.Replace("&", "&&"), e.SubItem.Font, 文本绘制区, e.Item.ForeColor, 项背景色, TextFormatFlags.Default)
        End If
    End Sub

    ''' <summary>
    ''' 绑定此事件时不要绑定 DrawListViewItemEvent 事件，本事件直接绘制主项和图标
    ''' </summary>
    ''' <param name="哪个列表视图控件"></param>
    ''' <param name="e"></param>
    Public Shared Sub 绘制子项(哪个列表视图控件 As ListView, e As DrawListViewSubItemEventArgs)
        e.DrawDefault = False
        If Not e.Bounds.IntersectsWith(哪个列表视图控件.ClientRectangle) Then Exit Sub
        Dim 项背景色 As Color = If(哪个列表视图控件.SelectedIndices.Contains(e.ItemIndex), 项被选中时的背景颜色, 哪个列表视图控件.BackColor)
        e.Graphics.FillRectangle(New SolidBrush(项背景色), e.Bounds)
        Dim 文本高度修正 As Integer = (e.Bounds.Height - TextRenderer.MeasureText(e.SubItem.Text, e.SubItem.Font).Height) \ 2
        Dim 文本绘制区 As New Rectangle(e.Bounds.X + 5, e.Bounds.Y + 文本高度修正, e.Bounds.Width - 5, e.Bounds.Height)
        Dim 文字显示所需尺寸 As Size = TextRenderer.MeasureText(e.SubItem.Text, e.SubItem.Font)
        If 文字显示所需尺寸.Width > (e.Bounds.Width - 5 * 界面控制.X轴DPI比率) Then
            Dim 点号所占用的宽度 As Integer = TextRenderer.MeasureText("...", e.SubItem.Font).Width
            Dim 实际文本可用宽度 As Integer = e.Bounds.Width - 点号所占用的宽度
            Dim 实际要绘制的文本 As String = e.SubItem.Text
            While TextRenderer.MeasureText(实际要绘制的文本, e.SubItem.Font).Width > 实际文本可用宽度 AndAlso 实际要绘制的文本.Length > 0
                实际要绘制的文本 = 实际要绘制的文本.Substring(0, 实际要绘制的文本.Length - 1)
            End While
            实际要绘制的文本 &= "..."
            TextRenderer.DrawText(e.Graphics, 实际要绘制的文本.Replace("&", "&&"), e.SubItem.Font, 文本绘制区, e.Item.ForeColor, 项背景色, TextFormatFlags.Default)
        Else
            TextRenderer.DrawText(e.Graphics, e.SubItem.Text.Replace("&", "&&"), e.SubItem.Font, 文本绘制区, e.Item.ForeColor, 项背景色, TextFormatFlags.Default)
        End If
    End Sub

End Class
