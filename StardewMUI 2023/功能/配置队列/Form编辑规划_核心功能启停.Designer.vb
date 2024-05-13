<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Form编辑规划_核心功能启停
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
        Label1 = New Label()
        UiCheckBox1 = New Sunny.UI.UICheckBox()
        UiCheckBox2 = New Sunny.UI.UICheckBox()
        UiCheckBox3 = New Sunny.UI.UICheckBox()
        SuspendLayout()
        ' 
        ' Label1
        ' 
        Label1.AutoSize = True
        Label1.Location = New Point(19, 19)
        Label1.Margin = New Padding(10)
        Label1.Name = "Label1"
        Label1.Size = New Size(138, 21)
        Label1.TabIndex = 1
        Label1.Text = "选择可配置的功能"
        ' 
        ' UiCheckBox1
        ' 
        UiCheckBox1.Font = New Font("微软雅黑", 12F)
        UiCheckBox1.ForeColor = SystemColors.ScrollBar
        UiCheckBox1.Location = New Point(29, 70)
        UiCheckBox1.Margin = New Padding(20, 20, 20, 0)
        UiCheckBox1.MinimumSize = New Size(1, 1)
        UiCheckBox1.Name = "UiCheckBox1"
        UiCheckBox1.Size = New Size(218, 23)
        UiCheckBox1.Style = Sunny.UI.UIStyle.Custom
        UiCheckBox1.TabIndex = 2
        UiCheckBox1.Text = "允许标准 SMAPI 模组套娃"
        ' 
        ' UiCheckBox2
        ' 
        UiCheckBox2.Font = New Font("微软雅黑", 12F)
        UiCheckBox2.ForeColor = SystemColors.ScrollBar
        UiCheckBox2.Location = New Point(29, 108)
        UiCheckBox2.Margin = New Padding(20, 15, 20, 0)
        UiCheckBox2.MinimumSize = New Size(1, 1)
        UiCheckBox2.Name = "UiCheckBox2"
        UiCheckBox2.Size = New Size(250, 23)
        UiCheckBox2.Style = Sunny.UI.UIStyle.Custom
        UiCheckBox2.TabIndex = 3
        UiCheckBox2.Text = "关闭 config.json 自动保留机制"
        ' 
        ' UiCheckBox3
        ' 
        UiCheckBox3.Font = New Font("微软雅黑", 12F)
        UiCheckBox3.ForeColor = SystemColors.ScrollBar
        UiCheckBox3.Location = New Point(29, 146)
        UiCheckBox3.Margin = New Padding(20, 15, 20, 0)
        UiCheckBox3.MinimumSize = New Size(1, 1)
        UiCheckBox3.Name = "UiCheckBox3"
        UiCheckBox3.Size = New Size(157, 23)
        UiCheckBox3.Style = Sunny.UI.UIStyle.Custom
        UiCheckBox3.TabIndex = 4
        UiCheckBox3.Text = "允许添加任何文件"
        ' 
        ' Form编辑规划_核心功能启停
        ' 
        AutoScaleDimensions = New SizeF(96F, 96F)
        AutoScaleMode = AutoScaleMode.Dpi
        BackColor = Color.FromArgb(CByte(24), CByte(24), CByte(24))
        ClientSize = New Size(484, 261)
        Controls.Add(UiCheckBox3)
        Controls.Add(UiCheckBox2)
        Controls.Add(UiCheckBox1)
        Controls.Add(Label1)
        Font = New Font("微软雅黑", 12F, FontStyle.Regular, GraphicsUnit.Point, CByte(134))
        ForeColor = Color.FromArgb(CByte(224), CByte(224), CByte(224))
        MaximizeBox = False
        MinimizeBox = False
        MinimumSize = New Size(500, 300)
        Name = "Form编辑规划_核心功能启停"
        ShowIcon = False
        ShowInTaskbar = False
        StartPosition = FormStartPosition.Manual
        Text = "核心功能启停"
        ResumeLayout(False)
        PerformLayout()
    End Sub

    Friend WithEvents Label1 As Label
    Friend WithEvents UiCheckBox1 As Sunny.UI.UICheckBox
    Friend WithEvents UiCheckBox2 As Sunny.UI.UICheckBox
    Friend WithEvents UiCheckBox3 As Sunny.UI.UICheckBox
End Class
