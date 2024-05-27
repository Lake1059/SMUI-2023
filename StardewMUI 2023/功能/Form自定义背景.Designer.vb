<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Form自定义背景
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
        Label63 = New Label()
        Label1 = New Label()
        SuspendLayout()
        ' 
        ' Label63
        ' 
        Label63.AutoSize = True
        Label63.Font = New Font("微软雅黑", 12F)
        Label63.Location = New Point(20, 20)
        Label63.Margin = New Padding(20, 20, 20, 0)
        Label63.Name = "Label63"
        Label63.Size = New Size(122, 21)
        Label63.TabIndex = 64
        Label63.Text = "新闻列表背景图"
        ' 
        ' Label1
        ' 
        Label1.AutoSize = True
        Label1.Font = New Font("微软雅黑", 12F)
        Label1.Location = New Point(20, 61)
        Label1.Margin = New Padding(20, 20, 20, 0)
        Label1.Name = "Label1"
        Label1.Size = New Size(122, 21)
        Label1.TabIndex = 65
        Label1.Text = "新闻列表背景图"
        ' 
        ' Form自定义背景
        ' 
        AutoScaleDimensions = New SizeF(96F, 96F)
        AutoScaleMode = AutoScaleMode.Dpi
        BackColor = Color.FromArgb(CByte(24), CByte(24), CByte(24))
        ClientSize = New Size(590, 496)
        Controls.Add(Label1)
        Controls.Add(Label63)
        Font = New Font("微软雅黑", 9.75F, FontStyle.Regular, GraphicsUnit.Point, CByte(134))
        ForeColor = Color.FromArgb(CByte(224), CByte(224), CByte(224))
        MaximizeBox = False
        MinimizeBox = False
        Name = "Form自定义背景"
        ShowIcon = False
        ShowInTaskbar = False
        StartPosition = FormStartPosition.Manual
        Text = "自定义背景"
        ResumeLayout(False)
        PerformLayout()
    End Sub

    Friend WithEvents Label63 As Label
    Friend WithEvents Label1 As Label
End Class
