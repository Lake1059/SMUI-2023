<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Form多项单选对话框
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
        Panel1 = New Panel()
        Label1 = New Label()
        LabelLine = New Label()
        Panel2 = New Panel()
        Panel1.SuspendLayout()
        SuspendLayout()
        ' 
        ' Panel1
        ' 
        Panel1.Controls.Add(Label1)
        Panel1.Controls.Add(LabelLine)
        Panel1.Dock = DockStyle.Fill
        Panel1.Location = New Point(0, 0)
        Panel1.Name = "Panel1"
        Panel1.Size = New Size(284, 85)
        Panel1.TabIndex = 0
        ' 
        ' Label1
        ' 
        Label1.Anchor = AnchorStyles.Top Or AnchorStyles.Bottom Or AnchorStyles.Left Or AnchorStyles.Right
        Label1.AutoEllipsis = True
        Label1.Location = New Point(20, 20)
        Label1.Margin = New Padding(20)
        Label1.Name = "Label1"
        Label1.Size = New Size(244, 45)
        Label1.TabIndex = 18
        Label1.Text = "Label1" & vbCrLf & "Label1"
        ' 
        ' LabelLine
        ' 
        LabelLine.AutoEllipsis = True
        LabelLine.BackColor = Color.FromArgb(CByte(80), CByte(80), CByte(80))
        LabelLine.Dock = DockStyle.Bottom
        LabelLine.Font = New Font("Microsoft YaHei UI", 9F, FontStyle.Regular, GraphicsUnit.Point)
        LabelLine.Location = New Point(0, 84)
        LabelLine.Name = "LabelLine"
        LabelLine.Size = New Size(284, 1)
        LabelLine.TabIndex = 17
        LabelLine.Visible = False
        ' 
        ' Panel2
        ' 
        Panel2.Dock = DockStyle.Bottom
        Panel2.Location = New Point(0, 85)
        Panel2.Name = "Panel2"
        Panel2.Padding = New Padding(20)
        Panel2.Size = New Size(284, 76)
        Panel2.TabIndex = 1
        ' 
        ' Form多项单选对话框
        ' 
        AutoScaleDimensions = New SizeF(96F, 96F)
        AutoScaleMode = AutoScaleMode.Dpi
        AutoSize = True
        BackColor = Color.FromArgb(CByte(32), CByte(34), CByte(37))
        ClientSize = New Size(284, 161)
        Controls.Add(Panel1)
        Controls.Add(Panel2)
        Font = New Font("Microsoft YaHei UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point)
        ForeColor = SystemColors.Control
        MaximizeBox = False
        MinimizeBox = False
        MinimumSize = New Size(300, 200)
        Name = "Form多项单选对话框"
        ShowIcon = False
        ShowInTaskbar = False
        StartPosition = FormStartPosition.Manual
        Text = "多项单选对话框"
        Panel1.ResumeLayout(False)
        ResumeLayout(False)

    End Sub

    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents LabelLine As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
End Class
