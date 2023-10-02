
Public Class 暗黑菜单项绘制类
    Inherits ToolStripRenderer

    Protected Overrides Sub Initialize(toolStrip As ToolStrip)
        MyBase.Initialize(toolStrip)

        toolStrip.BackColor = ColorTranslator.FromWin32(RGB(48, 48, 48))
        toolStrip.ForeColor = ColorTranslator.FromWin32(RGB(220, 220, 220))
    End Sub

    Protected Overrides Sub InitializeItem(item As ToolStripItem)
        MyBase.InitializeItem(item)

        item.ForeColor = ColorTranslator.FromWin32(RGB(220, 220, 220))

        If item.GetType() = GetType(ToolStripSeparator) Then
            item.Margin = New Padding(0, 0, 0, 1)
        End If
    End Sub


    Protected Overrides Sub OnRenderToolStripBackground(e As ToolStripRenderEventArgs)
        Dim g = e.Graphics
        Using b As New SolidBrush(ColorTranslator.FromWin32(RGB(48, 48, 48)))
            g.FillRectangle(b, e.AffectedBounds)
        End Using
    End Sub

    Protected Overrides Sub OnRenderImageMargin(e As ToolStripRenderEventArgs)
        Dim g = e.Graphics
        Dim rect As New Rectangle(0, 0, e.ToolStrip.Width - 1, e.ToolStrip.Height - 1)
        Using p As New Pen(ColorTranslator.FromWin32(RGB(48, 48, 48)))
            g.DrawRectangle(p, rect)
        End Using
    End Sub

    Protected Overrides Sub OnRenderItemCheck(e As ToolStripItemImageRenderEventArgs)
        Dim g = e.Graphics
        Dim rect As New Rectangle(e.ImageRectangle.Left - 2, e.ImageRectangle.Top - 2, e.ImageRectangle.Width + 4, e.ImageRectangle.Height + 4)

        Using b As New SolidBrush(ColorTranslator.FromWin32(RGB(48, 48, 48)))
            g.FillRectangle(b, rect)
        End Using

        Using p As New Pen(SystemColors.Highlight)
            Dim modRect As New Rectangle(rect.Left, rect.Top, rect.Width - 1, rect.Height - 1)
            g.DrawRectangle(p, modRect)
        End Using

        If e.Item.ImageIndex = -1 AndAlso String.IsNullOrEmpty(e.Item.ImageKey) AndAlso e.Item.Image Is Nothing Then
            g.DrawImageUnscaled(暗黑主题资源.菜单项选中的勾号图标, New Point(e.ImageRectangle.Left, e.ImageRectangle.Top))
        End If
    End Sub

    Protected Overrides Sub OnRenderSeparator(e As ToolStripSeparatorRenderEventArgs)
        Dim g = e.Graphics
        Dim rect As New Rectangle(1, 3, e.Item.Width, 1)
        Using b As New SolidBrush(ColorTranslator.FromWin32(RGB(64, 64, 64)))
            g.FillRectangle(b, rect)
        End Using
    End Sub

    Protected Overrides Sub OnRenderArrow(e As ToolStripArrowRenderEventArgs)
        e.ArrowColor = ColorTranslator.FromWin32(RGB(220, 220, 220))
        e.ArrowRectangle = New Rectangle(New Point(e.ArrowRectangle.Left, e.ArrowRectangle.Top - 1), e.ArrowRectangle.Size)
        MyBase.OnRenderArrow(e)
    End Sub

    Protected Overrides Sub OnRenderMenuItemBackground(e As ToolStripItemRenderEventArgs)
        Dim g = e.Graphics

        e.Item.ForeColor = If(e.Item.Enabled, ColorTranslator.FromWin32(RGB(220, 220, 220)), ColorTranslator.FromWin32(RGB(160, 160, 160)))

        If e.Item.Enabled Then
            ' Normal item
            If e.Item.Selected Then
                Dim rect As New Rectangle(2, 0, e.Item.Width - 3, e.Item.Height)
                Using b As New SolidBrush(ColorTranslator.FromWin32(RGB(64, 64, 64)))
                    g.FillRectangle(b, rect)
                End Using
            End If

            ' Header item on open menu
            If e.Item.GetType() Is GetType(ToolStripMenuItem) Then
                Dim toolStripItem = CType(e.Item, ToolStripMenuItem)
                If toolStripItem.DropDown.Visible AndAlso Not e.Item.IsOnDropDown Then
                    Dim rect As New Rectangle(2, 0, e.Item.Width - 3, e.Item.Height)
                    Using b As New SolidBrush(ColorTranslator.FromWin32(RGB(48, 48, 48)))
                        g.FillRectangle(b, rect)
                    End Using
                End If
            End If
        End If
    End Sub




End Class
