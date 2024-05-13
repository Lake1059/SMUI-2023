<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Form编辑规划_卸载时取消操作
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
        UiRadioButton1 = New Sunny.UI.UIRadioButton()
        UiRadioButton2 = New Sunny.UI.UIRadioButton()
        SuspendLayout()
        ' 
        ' Label1
        ' 
        Label1.AutoSize = True
        Label1.Location = New Point(19, 19)
        Label1.Margin = New Padding(10)
        Label1.Name = "Label1"
        Label1.Size = New Size(138, 21)
        Label1.TabIndex = 47
        Label1.Text = "选择如何进行取消"
        ' 
        ' UiRadioButton1
        ' 
        UiRadioButton1.Font = New Font("微软雅黑", 12F)
        UiRadioButton1.ForeColor = Color.FromArgb(CByte(224), CByte(224), CByte(224))
        UiRadioButton1.Location = New Point(19, 65)
        UiRadioButton1.Margin = New Padding(20, 15, 20, 0)
        UiRadioButton1.MinimumSize = New Size(1, 1)
        UiRadioButton1.Name = "UiRadioButton1"
        UiRadioButton1.RadioButtonSize = 20
        UiRadioButton1.Size = New Size(129, 23)
        UiRadioButton1.Style = Sunny.UI.UIStyle.Custom
        UiRadioButton1.TabIndex = 48
        UiRadioButton1.Text = "取消后续执行"
        ' 
        ' UiRadioButton2
        ' 
        UiRadioButton2.Font = New Font("微软雅黑", 12F)
        UiRadioButton2.ForeColor = Color.FromArgb(CByte(224), CByte(224), CByte(224))
        UiRadioButton2.Location = New Point(19, 103)
        UiRadioButton2.Margin = New Padding(20, 15, 20, 0)
        UiRadioButton2.MinimumSize = New Size(1, 1)
        UiRadioButton2.Name = "UiRadioButton2"
        UiRadioButton2.RadioButtonSize = 20
        UiRadioButton2.Size = New Size(97, 23)
        UiRadioButton2.Style = Sunny.UI.UIStyle.Custom
        UiRadioButton2.TabIndex = 49
        UiRadioButton2.Text = "生成错误"
        ' 
        ' Form编辑规划_卸载时取消操作
        ' 
        AutoScaleDimensions = New SizeF(96F, 96F)
        AutoScaleMode = AutoScaleMode.Dpi
        BackColor = Color.FromArgb(CByte(24), CByte(24), CByte(24))
        ClientSize = New Size(334, 161)
        Controls.Add(UiRadioButton2)
        Controls.Add(UiRadioButton1)
        Controls.Add(Label1)
        Font = New Font("微软雅黑", 12F, FontStyle.Regular, GraphicsUnit.Point, CByte(134))
        ForeColor = Color.FromArgb(CByte(224), CByte(224), CByte(224))
        MaximizeBox = False
        MinimizeBox = False
        MinimumSize = New Size(350, 200)
        Name = "Form编辑规划_卸载时取消操作"
        ShowIcon = False
        ShowInTaskbar = False
        StartPosition = FormStartPosition.Manual
        Text = "卸载时取消操作"
        ResumeLayout(False)
        PerformLayout()
    End Sub

    Friend WithEvents Label1 As Label
    Friend WithEvents UiRadioButton1 As Sunny.UI.UIRadioButton
    Friend WithEvents UiRadioButton2 As Sunny.UI.UIRadioButton
End Class
