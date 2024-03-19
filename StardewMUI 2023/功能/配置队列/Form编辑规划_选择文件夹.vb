Imports System.ComponentModel

Public Class Form编辑规划_选择文件夹

    Private Sub Form编辑规划_选择文件夹_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Private Sub Form编辑规划_选择文件夹_Closing(sender As Object, e As CancelEventArgs) Handles Me.Closing
        选择的文件夹 = ""
    End Sub

    Private Sub UiButton1_Click(sender As Object, e As EventArgs) Handles UiButton1.Click
        选择的文件夹 = Me.UiListBox1.SelectedValue.ToString
    End Sub

    Private Sub UiButton2_Click(sender As Object, e As EventArgs) Handles UiButton2.Click
        选择的文件夹 = ""
    End Sub

    Public Property 选择的文件夹 As String

End Class