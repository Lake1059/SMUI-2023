

Public Class 暗黑列表视图自绘制

    Public Shared Sub 绑定绘制项事件(哪个列表视图控件 As ListView, e As DrawListViewItemEventArgs, 项文字颜色表 As Color(), 项图标集合 As Image(), 图标大小 As SIZE)
        e.DrawDefault = False
        If Not e.Bounds.IntersectsWith(哪个列表视图控件.ClientRectangle) Then Exit Sub
        Dim 项背景色 As Color = If(哪个列表视图控件.SelectedIndices.Contains(e.ItemIndex), ColorTranslator.FromWin32(RGB(48, 48, 48)), 哪个列表视图控件.BackColor)
        e.Graphics.FillRectangle(New SolidBrush(项背景色), e.Bounds)
        Dim 文本高度修正 As Integer = (e.Bounds.Height - TextRenderer.MeasureText(e.Item.Text, e.Item.Font).Height) \ 2
        Dim 文本实际绘制颜色 As Color = If(项文字颜色表 IsNot Nothing, 项文字颜色表(e.ItemIndex), Form1.ForeColor)
        Dim 文本绘制区 As New Rectangle(e.Bounds.X + 8, e.Bounds.Y + 文本高度修正, e.Bounds.Width - 5, e.Bounds.Height)
        Dim 图标是否有效 As Boolean = 项图标集合 IsNot Nothing AndAlso 项图标集合(e.ItemIndex) IsNot Nothing
        If 图标是否有效 Then
            文本绘制区.X += 图标大小.Width : 文本绘制区.Width -= 图标大小.Width
            Dim 图标绘制区 As New Rectangle(e.Bounds.X + 5, e.Bounds.Y + (e.Bounds.Height - 图标大小.Height) \ 2, 图标大小.Width, 图标大小.Height)
            e.Graphics.DrawImage(项图标集合(e.ItemIndex), 图标绘制区)
        End If
        TextRenderer.DrawText(e.Graphics, e.Item.Text, e.Item.Font, 文本绘制区, 文本实际绘制颜色, 项背景色, TextFormatFlags.Default)
    End Sub

    Public Shared Sub 绑定绘制项事件(哪个列表视图控件 As ListView, e As DrawListViewItemEventArgs, 项图标 As Image, 图标大小 As Size)
        e.DrawDefault = False
        If Not e.Bounds.IntersectsWith(哪个列表视图控件.ClientRectangle) Then Exit Sub
        Dim 项背景色 As Color = If(哪个列表视图控件.SelectedIndices.Contains(e.ItemIndex), ColorTranslator.FromWin32(RGB(48, 48, 48)), 哪个列表视图控件.BackColor)
        e.Graphics.FillRectangle(New SolidBrush(项背景色), e.Bounds)
        Dim 文本高度修正 As Integer = (e.Bounds.Height - TextRenderer.MeasureText(e.Item.Text, e.Item.Font).Height) \ 2
        Dim 文本绘制区 As New Rectangle(e.Bounds.X + 8, e.Bounds.Y + 文本高度修正, e.Bounds.Width - 5, e.Bounds.Height)
        Dim 图标是否有效 As Boolean = 项图标 IsNot Nothing
        If 图标是否有效 Then
            文本绘制区.X += 图标大小.Width : 文本绘制区.Width -= 图标大小.Width
            Dim 图标绘制区 As New Rectangle(e.Bounds.X + 5, e.Bounds.Y + (e.Bounds.Height - 图标大小.Height) \ 2, 图标大小.Width, 图标大小.Height)
            e.Graphics.DrawImage(项图标, 图标绘制区)
        End If
        TextRenderer.DrawText(e.Graphics, e.Item.Text, e.Item.Font, 文本绘制区, 哪个列表视图控件.Items(e.ItemIndex).ForeColor, 项背景色, TextFormatFlags.Default)
    End Sub

    Public Shared Sub 绑定绘制项事件(哪个列表视图控件 As ListView, e As DrawListViewItemEventArgs)
        e.DrawDefault = False
        If Not e.Bounds.IntersectsWith(哪个列表视图控件.ClientRectangle) Then Exit Sub
        Dim 项背景色 As Color = If(哪个列表视图控件.SelectedIndices.Contains(e.ItemIndex), ColorTranslator.FromWin32(RGB(48, 48, 48)), 哪个列表视图控件.BackColor)
        e.Graphics.FillRectangle(New SolidBrush(项背景色), e.Bounds)
        Dim 文本高度修正 As Integer = (e.Bounds.Height - TextRenderer.MeasureText(e.Item.Text, e.Item.Font).Height) \ 2
        Dim 文本绘制区 As New Rectangle(e.Bounds.X + 5, e.Bounds.Y + 文本高度修正, e.Bounds.Width - 5, e.Bounds.Height)
        TextRenderer.DrawText(e.Graphics, e.Item.Text, e.Item.Font, 文本绘制区, 哪个列表视图控件.Items(e.ItemIndex).ForeColor, 项背景色, TextFormatFlags.Default)
    End Sub


End Class
