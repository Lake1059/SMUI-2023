

Imports Sunny.UI.Win32

Public Class 暗黑列表视图自绘制

    Public Shared Property 项被选中时的背景颜色 As Color = ColorTranslator.FromWin32(RGB(64, 64, 64))

    ''' <summary>
    ''' 绑定此事件时不要绑定 DrawListViewItemEvent 事件，本事件直接绘制主项和图标
    ''' </summary>
    ''' <param name="哪个列表视图控件"></param>
    ''' <param name="e"></param>
    ''' <param name="项图标集合"></param>
    Public Shared Sub 绑定绘制子项事件(哪个列表视图控件 As ListView, e As DrawListViewSubItemEventArgs, 项图标集合 As Dictionary(Of String, Image))
        e.DrawDefault = False
        If Not e.Bounds.IntersectsWith(哪个列表视图控件.ClientRectangle) Then Exit Sub
        Dim 项背景色 As Color = If(哪个列表视图控件.SelectedIndices.Contains(e.ItemIndex), 项被选中时的背景颜色, 哪个列表视图控件.BackColor)
        e.Graphics.FillRectangle(New SolidBrush(项背景色), e.Bounds)
        Dim 文本高度修正 As Integer = (e.Bounds.Height - TextRenderer.MeasureText(e.SubItem.Text, e.SubItem.Font).Height) \ 2
        Dim 文本绘制区 As New Rectangle(e.Bounds.X + 5, e.Bounds.Y + 文本高度修正, e.Bounds.Width - 5, e.Bounds.Height)
        If e.ColumnIndex = 0 Then
            Dim 图标是否有效 As Boolean = 项图标集合.ContainsKey(e.Item.Name)
            If 图标是否有效 Then
                文本绘制区.X += 5 : 文本绘制区.Width -= 5
                If e.ColumnIndex = 0 Then 文本绘制区.X += 16 * 界面控制.X轴DPI比率 : 文本绘制区.Width -= 16 * 界面控制.X轴DPI比率
                Dim 图标绘制区 As New Rectangle(e.Bounds.X + 5, e.Bounds.Y + (e.Bounds.Height - 16 * 界面控制.Y轴DPI比率) \ 2, 16 * 界面控制.X轴DPI比率, 16 * 界面控制.Y轴DPI比率)
                e.Graphics.DrawImage(项图标集合(e.ItemIndex), 图标绘制区)
            End If
        End If
jx1:    TextRenderer.DrawText(e.Graphics, e.SubItem.Text, e.SubItem.Font, 文本绘制区, e.Item.ForeColor, 项背景色, TextFormatFlags.Default)
    End Sub

End Class
