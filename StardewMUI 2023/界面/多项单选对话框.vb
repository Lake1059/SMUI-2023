Public Class 多项单选对话框
    Private ReadOnly newDialog As New Form多项单选对话框
    Public Shared Property GlobalDpixRatio As Single = 1

    Public Sub New(Title As String, SelectionGroup As String(), Optional Description As String = "", Optional DescriptionPanelHeight As Integer = 77, Optional WindowWidth As Integer = 300)
        If SelectionGroup Is Nothing Then Err.Raise(10001,, "SelectionGroup is nothing")
        If SelectionGroup.Length = 0 Then Err.Raise(10002,, "SelectionGroup have no item")
        newDialog.Text = Title
        newDialog.Width = WindowWidth
        If Description = "" Then
            newDialog.Panel1.Visible = False
            newDialog.Panel1.Height = 0
        Else
            newDialog.Label1.Text = Description
            newDialog.Panel1.Height = DescriptionPanelHeight * GlobalDpixRatio
        End If
        For i = 0 To SelectionGroup.Length - 1
            Dim a As New Label With {
                .Dock = DockStyle.Bottom,
                .Height = 40 * GlobalDpixRatio,
                .BackColor = ColorTranslator.FromWin32(RGB(50, 50, 50)),
                .ForeColor = SystemColors.Control,
                .TextAlign = ContentAlignment.MiddleLeft,
                .Text = "  " & SelectionGroup(i)}
            AddHandler a.MouseEnter,
                Sub(sender As Object, e As EventArgs)
                    sender.BackColor = ColorTranslator.FromWin32(RGB(64, 64, 64))
                End Sub
            AddHandler a.MouseLeave,
                Sub(sender As Object, e As EventArgs)
                    sender.BackColor = ColorTranslator.FromWin32(RGB(50, 50, 50))
                End Sub
            Dim x As Integer = i
            AddHandler a.Click,
                Sub()
                    newDialog.选择了哪个项 = x
                    newDialog.Close()
                End Sub
            If i <> 0 Then
                Dim b As New Label With {.AutoSize = False, .Text = "", .Dock = DockStyle.Bottom, .Height = 10}
                newDialog.Panel2.Controls.Add(b)
                b.SendToBack()
            End If
            newDialog.Panel2.Controls.Add(a)
            a.SendToBack()
        Next
        newDialog.Panel2.Height = SelectionGroup.Length * (40 * GlobalDpixRatio + 10) + newDialog.Panel2.Padding.Bottom
        newDialog.MinimumSize = New Size(WindowWidth, 40 + DescriptionPanelHeight * GlobalDpixRatio + newDialog.Panel2.Height)
        newDialog.Height = newDialog.MinimumSize.Height

    End Sub

    Public Sub New(Title As String, SelectionGroup As List(Of String), Optional Description As String = "", Optional DescriptionPanelHeight As Integer = 77, Optional WindowWidth As Integer = 300)
        If SelectionGroup Is Nothing Then Err.Raise(10001,, "SelectionGroup is nothing")
        If SelectionGroup.Count = 0 Then Err.Raise(10002,, "SelectionGroup have no item")
        newDialog.Text = Title
        newDialog.Width = WindowWidth
        If Description = "" Then
            newDialog.Panel1.Visible = False
            newDialog.Panel1.Height = 0
        Else
            newDialog.Label1.Text = Description
            newDialog.Panel1.Height = DescriptionPanelHeight * GlobalDpixRatio
        End If
        For i = 0 To SelectionGroup.Count - 1
            Dim a As New Label With {
                .Dock = DockStyle.Bottom,
                .Height = 40 * GlobalDpixRatio,
                .BackColor = ColorTranslator.FromWin32(RGB(50, 50, 50)),
                .ForeColor = SystemColors.Control,
                .TextAlign = ContentAlignment.MiddleLeft,
                .Text = "  " & SelectionGroup(i)}
            AddHandler a.MouseEnter,
                Sub(sender As Object, e As EventArgs)
                    sender.BackColor = ColorTranslator.FromWin32(RGB(64, 64, 64))
                End Sub
            AddHandler a.MouseLeave,
                Sub(sender As Object, e As EventArgs)
                    sender.BackColor = ColorTranslator.FromWin32(RGB(50, 50, 50))
                End Sub
            Dim x As Integer = i
            AddHandler a.Click,
                Sub()
                    newDialog.选择了哪个项 = x
                    newDialog.Close()
                End Sub
            If i <> 0 Then
                Dim b As New Label With {.AutoSize = False, .Text = "", .Dock = DockStyle.Bottom, .Height = 10}
                newDialog.Panel2.Controls.Add(b)
                b.SendToBack()
            End If
            newDialog.Panel2.Controls.Add(a)
            a.SendToBack()
        Next
        newDialog.Panel2.Height = SelectionGroup.Count * (40 * GlobalDpixRatio + 10) + newDialog.Panel2.Padding.Bottom
        newDialog.MinimumSize = New Size(WindowWidth, 40 + DescriptionPanelHeight * GlobalDpixRatio + newDialog.Panel2.Height)
        newDialog.Height = newDialog.MinimumSize.Height

    End Sub

    ''' <summary>
    ''' 
    ''' </summary>
    ''' <param name="owner"></param>
    ''' <returns>-1 = no choose, 0+ = your group index</returns>
    Public Function ShowDialog(owner As Form) As Integer
        显示模式窗体(newDialog, owner)
        Return newDialog.选择了哪个项
    End Function

    ''' <summary>
    ''' 
    ''' </summary>
    ''' <returns>-1 = no choose, 0+ = your group index</returns>
    Public Function ShowDialog() As Integer
        newDialog.StartPosition = FormStartPosition.CenterScreen
        newDialog.ShowDialog()
        Return newDialog.选择了哪个项
    End Function

    Public Sub SetOwner(owner As Form)
        newDialog.Owner = owner
    End Sub

    Public Sub SetTopWindow()
        newDialog.TopMost = True
    End Sub


End Class
