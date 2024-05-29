Public Class Form自定义背景
    Private Sub Form自定义背景_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.UiButton1.PerformClick()
    End Sub

    Private Sub UiButton1_Click(sender As Object, e As EventArgs) Handles UiButton1.Click
        Me.Label1.Text = "Size " & Form1.Panel35.Size.ToString & " " & Form1.Panel35.BackColor.ToString
        Me.Label2.Text = "Size " & Form1.ListView1.Size.ToString & " " & Form1.ListView1.BackColor.ToString
        Me.Label3.Text = "Size " & Form1.ListView2.Size.ToString & " " & Form1.ListView2.BackColor.ToString
    End Sub

    Private Sub LinkLabel1_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles LinkLabel1.LinkClicked
        Dim a As New OpenFileDialog With {.Multiselect = False}
        If a.ShowDialog = DialogResult.OK Then
            Using fs As New IO.FileStream(a.FileName, IO.FileMode.Open, IO.FileAccess.Read)
                Form1.Panel35.BackgroundImage = Image.FromStream(fs)
                Form1.Panel35.BackgroundImageLayout = ImageLayout.Stretch
                设置.全局设置数据("BGP_News") = a.FileName
            End Using
        End If
    End Sub

    Private Sub LinkLabel2_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles LinkLabel2.LinkClicked
        Dim a As New OpenFileDialog With {.Multiselect = False}
        If a.ShowDialog = DialogResult.OK Then
            Using fs As New IO.FileStream(a.FileName, IO.FileMode.Open, IO.FileAccess.Read)
                Form1.ListView1.BackgroundImage = Image.FromStream(fs)
                Form1.ListView1.BackgroundImageLayout = ImageLayout.Stretch
                设置.全局设置数据("BGP_Category") = a.FileName
            End Using
        End If
    End Sub

    Private Sub LinkLabel3_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles LinkLabel3.LinkClicked
        Dim a As New OpenFileDialog With {.Multiselect = False}
        If a.ShowDialog = DialogResult.OK Then
            Using fs As New IO.FileStream(a.FileName, IO.FileMode.Open, IO.FileAccess.Read)
                Form1.ListView2.BackgroundImage = Image.FromStream(fs)
                Form1.ListView2.BackgroundImageLayout = ImageLayout.Stretch
                设置.全局设置数据("BGP_ModItem") = a.FileName
            End Using
        End If
    End Sub

    Private Sub LinkLabel4_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles LinkLabel4.LinkClicked
        Form1.Panel35.BackgroundImage = Nothing
        设置.全局设置数据("BGP_News") = ""
    End Sub

    Private Sub LinkLabel5_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles LinkLabel5.LinkClicked
        Form1.ListView1.BackgroundImage = Nothing
        设置.全局设置数据("BGP_Category") = ""
    End Sub

    Private Sub LinkLabel6_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles LinkLabel6.LinkClicked
        Form1.ListView2.BackgroundImage = Nothing
        设置.全局设置数据("BGP_ModItem") = ""
    End Sub
End Class