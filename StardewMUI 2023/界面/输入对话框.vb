Public Class 输入对话框
    Private ReadOnly newDialog As New Form输入对话框
    Public Shared Property UserInputString As String = ""

    Public Sub New(Title As String, Message As String, Optional defaultText As String = "", Optional WindowWidth As Integer = 450, Optional WindowHeight As Integer = 200)
        newDialog.Text = Title
        newDialog.Label1.Text = Message
        newDialog.暗黑文本框1.Text = defaultText
        newDialog.Width = WindowWidth
        newDialog.Height = WindowHeight
    End Sub

    Public Sub TranslateButtonText(OK As String, Cancel As String)
        newDialog.Label确定.Text = OK
        newDialog.Label取消.Text = Cancel
    End Sub

    Public Sub SetTextBoxForeColor(yourColor As Color)
        newDialog.暗黑文本框1.ForeColor = yourColor
    End Sub

    Public Function ShowDialog(owner As Form) As String
        显示模式窗体(newDialog, owner)
        Return newDialog.输入的内容
    End Function

    Public Function ShowDialog() As String
        newDialog.StartPosition = FormStartPosition.CenterScreen
        newDialog.ShowDialog()
        Return newDialog.输入的内容
    End Function


End Class
