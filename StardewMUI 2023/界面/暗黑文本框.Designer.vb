<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class 暗黑文本框
    Inherits System.Windows.Forms.UserControl

    'UserControl 重写释放以清理组件列表。
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
        SuspendLayout()
        ' 
        ' TextBox1
        ' 
        TextBox1.BackColor = Color.FromArgb(CByte(48), CByte(48), CByte(48))
        TextBox1.BorderStyle = BorderStyle.None
        TextBox1.Dock = DockStyle.Top
        TextBox1.Font = New Font("微软雅黑", 9.75F, FontStyle.Regular, GraphicsUnit.Point, CByte(134))
        TextBox1.ForeColor = Color.FromArgb(CByte(224), CByte(224), CByte(224))
        TextBox1.Location = New Point(5, 5)
        TextBox1.Name = "TextBox1"
        TextBox1.Size = New Size(192, 18)
        TextBox1.TabIndex = 0
        ' 
        ' 暗黑文本框
        ' 
        AutoScaleDimensions = New SizeF(96F, 96F)
        AutoScaleMode = AutoScaleMode.Dpi
        BackColor = Color.FromArgb(CByte(48), CByte(48), CByte(48))
        Controls.Add(TextBox1)
        ForeColor = Color.FromArgb(CByte(224), CByte(224), CByte(224))
        Name = "暗黑文本框"
        Padding = New Padding(5, 5, 5, 0)
        Size = New Size(202, 30)
        ResumeLayout(False)
        PerformLayout()
    End Sub

    Friend WithEvents TextBox1 As TextBox

End Class
