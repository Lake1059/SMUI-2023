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
        TextBox1 = New TextBox()
        Label确定 = New Label()
        Label取消 = New Label()
        Label1 = New Label()
        SuspendLayout()
        ' 
        ' TextBox1
        ' 
        TextBox1.Anchor = AnchorStyles.Bottom Or AnchorStyles.Left Or AnchorStyles.Right
        TextBox1.BackColor = Color.FromArgb(CByte(32), CByte(34), CByte(37))
        TextBox1.BorderStyle = BorderStyle.FixedSingle
        TextBox1.Font = New Font("Microsoft YaHei UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point)
        TextBox1.ForeColor = Color.LimeGreen
        TextBox1.Location = New Point(19, 118)
        TextBox1.Margin = New Padding(10)
        TextBox1.Name = "TextBox1"
        TextBox1.Size = New Size(396, 24)
        TextBox1.TabIndex = 0
        TextBox1.Text = "字体样式 1234567890 qwertyuiopasdfghjklzxcvbnm"
        ' 
        ' Label确定
        ' 
        Label确定.Anchor = AnchorStyles.Top Or AnchorStyles.Right
        Label确定.AutoEllipsis = True
        Label确定.BackColor = Color.FromArgb(CByte(50), CByte(50), CByte(50))
        Label确定.Font = New Font("Microsoft YaHei UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point)
        Label确定.ForeColor = SystemColors.Control
        Label确定.Location = New Point(340, 19)
        Label确定.Margin = New Padding(10, 10, 10, 0)
        Label确定.Name = "Label确定"
        Label确定.Size = New Size(75, 30)
        Label确定.TabIndex = 9
        Label确定.Text = "OK"
        Label确定.TextAlign = ContentAlignment.MiddleCenter
        ' 
        ' Label取消
        ' 
        Label取消.Anchor = AnchorStyles.Top Or AnchorStyles.Right
        Label取消.AutoEllipsis = True
        Label取消.BackColor = Color.FromArgb(CByte(50), CByte(50), CByte(50))
        Label取消.Font = New Font("Microsoft YaHei UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point)
        Label取消.ForeColor = SystemColors.Control
        Label取消.Location = New Point(340, 59)
        Label取消.Margin = New Padding(10, 10, 10, 0)
        Label取消.Name = "Label取消"
        Label取消.Size = New Size(75, 30)
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
        Label1.Size = New Size(314, 89)
        Label1.TabIndex = 11
        Label1.Text = "Label1"
        ' 
        ' Form输入对话框
        ' 
        AutoScaleDimensions = New SizeF(96F, 96F)
        AutoScaleMode = AutoScaleMode.Dpi
        BackColor = Color.FromArgb(CByte(32), CByte(34), CByte(37))
        ClientSize = New Size(434, 161)
        Controls.Add(Label1)
        Controls.Add(Label取消)
        Controls.Add(Label确定)
        Controls.Add(TextBox1)
        Font = New Font("Microsoft YaHei UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point)
        ForeColor = SystemColors.Control
        MaximizeBox = False
        MinimizeBox = False
        MinimumSize = New Size(450, 200)
        Name = "Form输入对话框"
        ShowIcon = False
        ShowInTaskbar = False
        StartPosition = FormStartPosition.Manual
        Text = "Form输入对话框"
        ResumeLayout(False)
        PerformLayout()

    End Sub

    Friend WithEvents TextBox1 As System.Windows.Forms.TextBox
    Friend WithEvents Label确定 As System.Windows.Forms.Label
    Friend WithEvents Label取消 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
End Class
