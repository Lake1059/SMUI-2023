
Public Class 暗黑列表视图自绘制

    Public Shared Sub 绑定列表视图事件(哪个列表视图控件 As ListView)
        哪个列表视图控件.DoubleBuffer
        AddHandler 哪个列表视图控件.DrawSubItem, Sub(sender, e) 绘制子项(sender, e)
        AddHandler 哪个列表视图控件.SelectedIndexChanged, Sub(sender, e) sender.Invalidate(sender.ClientRectangle)
        AddHandler 哪个列表视图控件.ItemMouseHover, Sub(sender, e) sender.Invalidate(sender.ClientRectangle)
        哪个列表视图控件.BackgroundImageLayout = ImageLayout.None
        'AddHandler 哪个列表视图控件.Paint, Sub(sender, e) Paint(sender, e)
    End Sub

    Public Shared Sub 绑定列表视图事件(哪个列表视图控件 As ListView, 项图标字典 As Dictionary(Of String, Image))
        哪个列表视图控件.DoubleBuffer
        AddHandler 哪个列表视图控件.DrawSubItem, Sub(sender, e) 绘制子项(sender, e, 项图标字典)
        AddHandler 哪个列表视图控件.SelectedIndexChanged, Sub(sender, e) sender.Invalidate(sender.ClientRectangle)
        AddHandler 哪个列表视图控件.ItemMouseHover, Sub(sender, e) sender.Invalidate(sender.ClientRectangle)
        哪个列表视图控件.BackgroundImageLayout = ImageLayout.None
    End Sub


    Public Shared Sub Paint(哪个列表视图控件 As ListView, e As PaintEventArgs)
        If 哪个列表视图控件.BackgroundImage Is Nothing Then Exit Sub
        If 哪个列表视图控件.Items.Count = 0 Then Exit Sub

        Dim startIdx As Integer = 哪个列表视图控件.TopItem.Index
        Dim endIdx As Integer = Math.Min(startIdx + 哪个列表视图控件.DisplayRectangle.Height \ 哪个列表视图控件.Items(0).Bounds.Height, 哪个列表视图控件.Items.Count - 1)
        Dim lastItemBounds As Rectangle = 哪个列表视图控件.Items(endIdx).Bounds
        Dim remainingBounds As New Rectangle(0, lastItemBounds.Bottom, 哪个列表视图控件.ClientSize.Width, 哪个列表视图控件.ClientSize.Height - lastItemBounds.Bottom)
        e.Graphics.SetClip(remainingBounds)
        e.Graphics.DrawImage(哪个列表视图控件.BackgroundImage, remainingBounds, remainingBounds, GraphicsUnit.Pixel)
    End Sub

    Public Shared Property 项被选中时的背景颜色 As Color = ColorTranslator.FromWin32(RGB(64, 64, 64))
    Public Shared Property 项被选中时的高亮遮罩颜色 As Color = Color.FromArgb(60, 200, 200, 200)
    Public Shared Property 项图像边长 As Integer = 16

    ''' <summary>
    ''' 绑定此事件时不要绑定 DrawListViewItemEvent 事件，本事件直接绘制主项和图标
    ''' </summary>
    ''' <param name="哪个列表视图控件"></param>
    ''' <param name="e"></param>
    ''' <param name="项图标字典">键是主项文本，值是 Image，如果有对应的图片不要忘记在变动主项文本的同时修改字典里的键名称</param>
    Public Shared Sub 绘制子项(哪个列表视图控件 As ListView, e As DrawListViewSubItemEventArgs, 项图标字典 As Dictionary(Of String, Image))
        If Not e.Bounds.IntersectsWith(哪个列表视图控件.ClientRectangle) OrElse e.Bounds.Width = 0 Then Exit Sub
        Dim 项背景色 As Color = If(哪个列表视图控件.SelectedIndices.Contains(e.ItemIndex), 项被选中时的背景颜色, 哪个列表视图控件.BackColor)
        Dim 文本高度修正 As Integer = (e.Bounds.Height - TextRenderer.MeasureText(e.SubItem.Text, e.SubItem.Font).Height) \ 2
        Dim 文本绘制区 As New Rectangle(e.Bounds.X + 5, e.Bounds.Y + 文本高度修正, e.Bounds.Width - 5, e.Bounds.Height)
        If e.ColumnIndex = 0 Then
            Dim value As Image = Nothing
            If 项图标字典.TryGetValue(e.Item.Text, value) Then
                文本绘制区.X += 5 + 项图像边长 * 界面控制.DPI
                文本绘制区.Width -= 5 + 项图像边长 * 界面控制.DPI
                Dim 图标绘制区 As New Rectangle(e.Bounds.X + 5, e.Bounds.Y + (e.Bounds.Height - 项图像边长 * 界面控制.DPI) \ 2, 项图像边长 * 界面控制.DPI, 项图像边长 * 界面控制.DPI)
                e.Graphics.DrawImage(value, 图标绘制区)
            End If
        End If
        Dim 文字显示所需尺寸 As Size = TextRenderer.MeasureText(e.SubItem.Text, e.SubItem.Font)
        Dim 实际要绘制的文本 As String = e.SubItem.Text
        If 文字显示所需尺寸.Width > (e.Bounds.Width - 5 * 界面控制.DPI) Then
            Dim 点号所占用的宽度 As Integer = TextRenderer.MeasureText("...", e.SubItem.Font).Width
            Dim 实际文本可用宽度 As Integer = e.Bounds.Width - 点号所占用的宽度
            While TextRenderer.MeasureText(实际要绘制的文本, e.SubItem.Font).Width > 实际文本可用宽度 AndAlso 实际要绘制的文本.Length > 0
                实际要绘制的文本 = 实际要绘制的文本.Substring(0, 实际要绘制的文本.Length - 1)
            End While
            实际要绘制的文本 &= "..."
        End If
        If 哪个列表视图控件.BackgroundImage Is Nothing Then
            Using brush As New SolidBrush(项背景色)
                e.Graphics.FillRectangle(brush, e.Bounds)
            End Using
            TextRenderer.DrawText(e.Graphics, 实际要绘制的文本.Replace("&", "&&"), e.SubItem.Font, 文本绘制区, e.Item.ForeColor, 项背景色, TextFormatFlags.Default)
        Else
            Dim destRect As New Rectangle(e.Bounds.X, e.Bounds.Y, e.Bounds.Width, e.Bounds.Height)
            e.Graphics.DrawImage(哪个列表视图控件.BackgroundImage, destRect, e.Bounds, GraphicsUnit.Pixel)
            Dim 文本背景图 As New Bitmap(文本绘制区.Width, 文本绘制区.Height)
            Using g As Graphics = Graphics.FromImage(文本背景图)
                g.TextRenderingHint = Drawing.Text.TextRenderingHint.ClearTypeGridFit
                g.DrawImage(哪个列表视图控件.BackgroundImage, New Rectangle(0, 0, 文本绘制区.Width, 文本绘制区.Height), 文本绘制区, GraphicsUnit.Pixel)
                TextRenderer.DrawText(g, 实际要绘制的文本.Replace("&", "&&"), e.SubItem.Font, New Rectangle(Point.Empty, 文本绘制区.Size), e.Item.ForeColor, TextFormatFlags.Default)
            End Using
            e.Graphics.DrawImage(文本背景图, 文本绘制区)
            文本背景图.Dispose()
            If 哪个列表视图控件.SelectedIndices.Contains(e.ItemIndex) Then
                Dim semiTransparentBrush As New SolidBrush(项被选中时的高亮遮罩颜色)
                Using semiTransparentBrush
                    e.Graphics.FillRectangle(semiTransparentBrush, e.Bounds)
                End Using
            End If
        End If
    End Sub

    ''' <summary>
    ''' 绑定此事件时不要绑定 DrawListViewItemEvent 事件，本事件直接绘制主项
    ''' </summary>
    ''' <param name="哪个列表视图控件"></param>
    ''' <param name="e"></param>
    Public Shared Sub 绘制子项(哪个列表视图控件 As ListView, e As DrawListViewSubItemEventArgs)
        If Not e.Bounds.IntersectsWith(哪个列表视图控件.ClientRectangle) OrElse e.Bounds.Width = 0 Then Exit Sub
        Dim 项背景色 As Color = If(哪个列表视图控件.SelectedIndices.Contains(e.ItemIndex), 项被选中时的背景颜色, 哪个列表视图控件.BackColor)
        Dim 文本高度修正 As Integer = (e.Bounds.Height - TextRenderer.MeasureText(e.SubItem.Text, e.SubItem.Font).Height) \ 2
        Dim 文本绘制区 As New Rectangle(e.Bounds.X + 5, e.Bounds.Y + 文本高度修正, e.Bounds.Width - 5, e.Bounds.Height)
        Dim 文字显示所需尺寸 As Size = TextRenderer.MeasureText(e.SubItem.Text, e.SubItem.Font)
        Dim 实际要绘制的文本 As String = e.SubItem.Text
        If 文字显示所需尺寸.Width > (e.Bounds.Width - 5 * 界面控制.DPI) Then
            Dim 点号所占用的宽度 As Integer = TextRenderer.MeasureText("...", e.SubItem.Font).Width
            Dim 实际文本可用宽度 As Integer = e.Bounds.Width - 点号所占用的宽度
            While TextRenderer.MeasureText(实际要绘制的文本, e.SubItem.Font).Width > 实际文本可用宽度 AndAlso 实际要绘制的文本.Length > 0
                实际要绘制的文本 = 实际要绘制的文本.Substring(0, 实际要绘制的文本.Length - 1)
            End While
            实际要绘制的文本 &= "..."
        End If
        If 哪个列表视图控件.BackgroundImage Is Nothing Then
            Using brush As New SolidBrush(项背景色)
                e.Graphics.FillRectangle(brush, e.Bounds)
            End Using
            TextRenderer.DrawText(e.Graphics, 实际要绘制的文本.Replace("&", "&&"), e.SubItem.Font, 文本绘制区, e.Item.ForeColor, 项背景色, TextFormatFlags.Default)
        Else
            Dim destRect As New Rectangle(e.Bounds.X, e.Bounds.Y, e.Bounds.Width, e.Bounds.Height)
            e.Graphics.DrawImage(哪个列表视图控件.BackgroundImage, destRect, e.Bounds, GraphicsUnit.Pixel)
            Dim 文本背景图 As New Bitmap(文本绘制区.Width, 文本绘制区.Height)
            Using g As Graphics = Graphics.FromImage(文本背景图)
                g.TextRenderingHint = Drawing.Text.TextRenderingHint.ClearTypeGridFit
                g.DrawImage(哪个列表视图控件.BackgroundImage, New Rectangle(0, 0, 文本绘制区.Width, 文本绘制区.Height), 文本绘制区, GraphicsUnit.Pixel)
                TextRenderer.DrawText(g, 实际要绘制的文本.Replace("&", "&&"), e.SubItem.Font, New Rectangle(Point.Empty, 文本绘制区.Size), e.Item.ForeColor, TextFormatFlags.Default)
            End Using
            e.Graphics.DrawImage(文本背景图, 文本绘制区)
            文本背景图.Dispose()
            If 哪个列表视图控件.SelectedIndices.Contains(e.ItemIndex) Then
                Dim semiTransparentBrush As New SolidBrush(项被选中时的高亮遮罩颜色)
                Using semiTransparentBrush
                    e.Graphics.FillRectangle(semiTransparentBrush, e.Bounds)
                End Using
            End If
        End If
    End Sub

End Class
