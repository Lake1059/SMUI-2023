<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Form输入对话框
    Inherits System.Windows.Forms.Form

    'Form 重写 Dispose，以清理组件列表。
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Windows 窗体设计器所必需的
    Private components As System.ComponentModel.IContainer

    '注意: 以下过程是 Windows 窗体设计器所必需的
    '可以使用 Windows 窗体设计器修改它。  
    '不要使用代码编辑器修改它。
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Label确定 = New Label()
        Label取消 = New Label()
        Label1 = New Label()
        暗黑文本框1 = New 暗黑文本框()
        SuspendLayout()
        ' 
        ' Label确定
        ' 
        Label确定.Anchor = AnchorStyles.Top Or AnchorStyles.Right
        Label确定.AutoEllipsis = True
        Label确定.BackColor = Color.FromArgb(CByte(50), CByte(50), CByte(50))
        Label确定.Font = New Font("Microsoft YaHei UI", 9.75F)
        Label确定.ForeColor = SystemColors.Control
        Label确定.Location = New Point(325, 19)
        Label确定.Margin = New Padding(10, 10, 10, 0)
        Label确定.Name = "Label确定"
        Label确定.Size = New Size(90, 35)
        Label确定.TabIndex = 9
        Label确定.Text = "OK"
        Label确定.TextAlign = ContentAlignment.MiddleCenter
        ' 
        ' Label取消
        ' 
        Label取消.Anchor = AnchorStyles.Top Or AnchorStyles.Right
        Label取消.AutoEllipsis = True
        Label取消.BackColor = Color.FromArgb(CByte(50), CByte(50), CByte(50))
        Label取消.Font = New Font("Microsoft YaHei UI", 9.75F)
        Label取消.ForeColor = SystemColors.Control
        Label取消.Location = New Point(325, 64)
        Label取消.Margin = New Padding(10, 10, 10, 0)
        Label取消.Name = "Label取消"
        Label取消.Size = New Size(90, 35)
        Label取消.TabIndex = 10
        Label取消.Text = "Cancel"
        Label取消.TextAlign = ContentAlignment.MiddleCenter
        ' 
        ' Label1
        ' 
        Label1.Anchor = AnchorStyles.Top Or AnchorStyles.Bottom Or AnchorStyles.Left Or AnchorStyles.Right
        Label1.AutoEllipsis = True
        Label1.Location = New Point(16, 19)
        Label1.Margin = New Padding(10, 10, 0, 0)
        Label1.Name = "Label1"
        Label1.Size = New Size(299, 113)
        Label1.TabIndex = 11
        Label1.Text = "Label1"
        ' 
        ' 暗黑文本框1
        ' 
        暗黑文本框1.Anchor = AnchorStyles.Bottom Or AnchorStyles.Left Or AnchorStyles.Right
        暗黑文本框1.BackColor = Color.FromArgb(CByte(48), CByte(48), CByte(48))
        暗黑文本框1.ForeColor = Color.FromArgb(CByte(224), CByte(224), CByte(224))
        暗黑文本框1.Location = New Point(19, 142)
        暗黑文本框1.Margin = New Padding(10)
        暗黑文本框1.Name = "暗黑文本框1"
        暗黑文本框1.Padding = New Padding(5, 6, 5, 0)
        暗黑文本框1.PasswordChar = vbNullChar
        暗黑文本框1.Size = New Size(396, 30)
        暗黑文本框1.TabIndex = 12
        ' 
        ' Form输入对话框
        ' 
        AutoScaleDimensions = New SizeF(96F, 96F)
        AutoScaleMode = AutoScaleMode.Dpi
        BackColor = Color.FromArgb(CByte(24), CByte(24), CByte(24))
        ClientSize = New Size(434, 191)
        Controls.Add(暗黑文本框1)
        Controls.Add(Label1)
        Controls.Add(Label取消)
        Controls.Add(Label确定)
        Font = New Font("Microsoft YaHei UI", 9.75F)
        ForeColor = SystemColors.Control
        MaximizeBox = False
        MinimizeBox = False
        MinimumSize = New Size(450, 230)
        Name = "Form输入对话框"
        ShowIcon = False
        ShowInTaskbar = False
        StartPosition = FormStartPosition.Manual
        Text = "Form输入对话框"
        ResumeLayout(False)

    End Sub
    Friend WithEvents Label确定 As System.Windows.Forms.Label
    Friend WithEvents Label取消 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents 暗黑文本框1 As 暗黑文本框
End Class
