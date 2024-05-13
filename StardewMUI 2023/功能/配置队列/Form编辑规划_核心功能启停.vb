Public Class Form编辑规划_核心功能启停
    Private Sub Form编辑规划_核心功能启停_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Private Sub Form编辑规划_核心功能启停_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing

    End Sub

    Private Sub Form编辑规划_核心功能启停_KeyDown(sender As Object, e As KeyEventArgs) Handles Me.KeyDown
        If e.KeyData = Keys.Escape Then Me.Close()
    End Sub




End Class