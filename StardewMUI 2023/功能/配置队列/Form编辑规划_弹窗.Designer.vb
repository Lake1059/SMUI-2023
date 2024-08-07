<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Form编辑规划_弹窗
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
        UiGroupBox1 = New Sunny.UI.UIGroupBox()
        UiRadioButton7 = New Sunny.UI.UIRadioButton()
        UiRadioButton2 = New Sunny.UI.UIRadioButton()
        UiRadioButton1 = New Sunny.UI.UIRadioButton()
        UiTextBox1 = New Sunny.UI.UITextBox()
        Label1 = New Label()
        UiButton2 = New Sunny.UI.UIButton()
        UiButton1 = New Sunny.UI.UIButton()
        暗黑文本框1 = New 暗黑文本框()
        Label2 = New Label()
        暗黑文本框2 = New 暗黑文本框()
        Label3 = New Label()
        UiCheckBox1 = New Sunny.UI.UICheckBox()
        UiNumPadTextBox1 = New Sunny.UI.UINumPadTextBox()
        UiGroupBox1.SuspendLayout()
        SuspendLayout()
        ' 
        ' UiGroupBox1
        ' 
        UiGroupBox1.Anchor = AnchorStyles.Top Or AnchorStyles.Left Or AnchorStyles.Right
        UiGroupBox1.Controls.Add(UiRadioButton7)
        UiGroupBox1.Controls.Add(UiRadioButton2)
        UiGroupBox1.Controls.Add(UiRadioButton1)
        UiGroupBox1.FillColor = Color.FromArgb(CByte(24), CByte(24), CByte(24))
        UiGroupBox1.FillColor2 = Color.FromArgb(CByte(24), CByte(24), CByte(24))
        UiGroupBox1.Font = New Font("微软雅黑", 9.75F, FontStyle.Regular, GraphicsUnit.Point, CByte(134))
        UiGroupBox1.ForeColor = Color.Silver
        UiGroupBox1.ForeDisableColor = Color.Silver
        UiGroupBox1.Location = New Point(19, 9)
        UiGroupBox1.Margin = New Padding(10, 0, 10, 0)
        UiGroupBox1.MinimumSize = New Size(1, 1)
        UiGroupBox1.Name = "UiGroupBox1"
        UiGroupBox1.Padding = New Padding(10, 32, 0, 10)
        UiGroupBox1.RectColor = Color.DimGray
        UiGroupBox1.RectDisableColor = Color.DimGray
        UiGroupBox1.Size = New Size(446, 72)
        UiGroupBox1.TabIndex = 77
        UiGroupBox1.Text = "在什么时候弹窗"
        UiGroupBox1.TextAlignment = ContentAlignment.MiddleLeft
        ' 
        ' UiRadioButton7
        ' 
        UiRadioButton7.Dock = DockStyle.Left
        UiRadioButton7.Font = New Font("微软雅黑", 12F)
        UiRadioButton7.ForeColor = Color.Silver
        UiRadioButton7.Location = New Point(270, 32)
        UiRadioButton7.Margin = New Padding(0, 0, 5, 5)
        UiRadioButton7.MinimumSize = New Size(1, 1)
        UiRadioButton7.Name = "UiRadioButton7"
        UiRadioButton7.RadioButtonSize = 20
        UiRadioButton7.Size = New Size(130, 30)
        UiRadioButton7.Style = Sunny.UI.UIStyle.Custom
        UiRadioButton7.TabIndex = 69
        UiRadioButton7.Text = "全部"
        ' 
        ' UiRadioButton2
        ' 
        UiRadioButton2.Dock = DockStyle.Left
        UiRadioButton2.Font = New Font("微软雅黑", 12F)
        UiRadioButton2.ForeColor = Color.Silver
        UiRadioButton2.Location = New Point(140, 32)
        UiRadioButton2.Margin = New Padding(0, 0, 5, 5)
        UiRadioButton2.MinimumSize = New Size(1, 1)
        UiRadioButton2.Name = "UiRadioButton2"
        UiRadioButton2.RadioButtonSize = 20
        UiRadioButton2.Size = New Size(130, 30)
        UiRadioButton2.Style = Sunny.UI.UIStyle.Custom
        UiRadioButton2.TabIndex = 68
        UiRadioButton2.Text = "卸载时"
        ' 
        ' UiRadioButton1
        ' 
        UiRadioButton1.Dock = DockStyle.Left
        UiRadioButton1.Font = New Font("微软雅黑", 12F)
        UiRadioButton1.ForeColor = Color.Silver
        UiRadioButton1.Location = New Point(10, 32)
        UiRadioButton1.Margin = New Padding(5, 5, 0, 5)
        UiRadioButton1.MinimumSize = New Size(1, 1)
        UiRadioButton1.Name = "UiRadioButton1"
        UiRadioButton1.RadioButtonSize = 20
        UiRadioButton1.Size = New Size(130, 30)
        UiRadioButton1.Style = Sunny.UI.UIStyle.Custom
        UiRadioButton1.TabIndex = 67
        UiRadioButton1.Text = "安装时"
        ' 
        ' UiTextBox1
        ' 
        UiTextBox1.Anchor = AnchorStyles.Top Or AnchorStyles.Bottom Or AnchorStyles.Left Or AnchorStyles.Right
        UiTextBox1.FillColor = Color.FromArgb(CByte(24), CByte(24), CByte(24))
        UiTextBox1.FillColor2 = Color.FromArgb(CByte(24), CByte(24), CByte(24))
        UiTextBox1.FillDisableColor = Color.FromArgb(CByte(24), CByte(24), CByte(24))
        UiTextBox1.FillReadOnlyColor = Color.FromArgb(CByte(24), CByte(24), CByte(24))
        UiTextBox1.Font = New Font("微软雅黑", 9.75F, FontStyle.Regular, GraphicsUnit.Point, CByte(134))
        UiTextBox1.ForeColor = Color.Silver
        UiTextBox1.ForeDisableColor = Color.Silver
        UiTextBox1.ForeReadOnlyColor = Color.Silver
        UiTextBox1.Location = New Point(19, 332)
        UiTextBox1.Margin = New Padding(4, 5, 4, 5)
        UiTextBox1.MinimumSize = New Size(1, 16)
        UiTextBox1.Multiline = True
        UiTextBox1.Name = "UiTextBox1"
        UiTextBox1.Padding = New Padding(5)
        UiTextBox1.RectColor = Color.DimGray
        UiTextBox1.RectDisableColor = Color.DimGray
        UiTextBox1.RectReadOnlyColor = Color.DimGray
        UiTextBox1.ScrollBarBackColor = Color.DimGray
        UiTextBox1.ScrollBarColor = Color.Gray
        UiTextBox1.ScrollBarStyleInherited = False
        UiTextBox1.ShowText = False
        UiTextBox1.Size = New Size(446, 110)
        UiTextBox1.TabIndex = 83
        UiTextBox1.TextAlignment = ContentAlignment.TopLeft
        UiTextBox1.Watermark = ""
        ' 
        ' Label1
        ' 
        Label1.AutoSize = True
        Label1.Location = New Point(19, 296)
        Label1.Margin = New Padding(10)
        Label1.Name = "Label1"
        Label1.Size = New Size(138, 21)
        Label1.TabIndex = 82
        Label1.Text = "选项（每行一个）"
        ' 
        ' UiButton2
        ' 
        UiButton2.Anchor = AnchorStyles.Bottom Or AnchorStyles.Left
        UiButton2.FillColor = Color.FromArgb(CByte(48), CByte(48), CByte(48))
        UiButton2.FillColor2 = Color.FromArgb(CByte(48), CByte(48), CByte(48))
        UiButton2.FillDisableColor = Color.FromArgb(CByte(48), CByte(48), CByte(48))
        UiButton2.FillHoverColor = Color.FromArgb(CByte(64), CByte(64), CByte(64))
        UiButton2.FillPressColor = Color.FromArgb(CByte(80), CByte(80), CByte(80))
        UiButton2.FillSelectedColor = Color.FromArgb(CByte(48), CByte(48), CByte(48))
        UiButton2.Font = New Font("微软雅黑", 9.75F)
        UiButton2.ForeColor = Color.FromArgb(CByte(224), CByte(224), CByte(224))
        UiButton2.ForeDisableColor = Color.Gray
        UiButton2.ForeHoverColor = Color.FromArgb(CByte(244), CByte(244), CByte(244))
        UiButton2.ForePressColor = Color.FromArgb(CByte(244), CByte(244), CByte(244))
        UiButton2.ForeSelectedColor = Color.FromArgb(CByte(244), CByte(244), CByte(244))
        UiButton2.Location = New Point(19, 457)
        UiButton2.Margin = New Padding(10)
        UiButton2.MinimumSize = New Size(1, 1)
        UiButton2.Name = "UiButton2"
        UiButton2.Radius = 10
        UiButton2.RadiusSides = Sunny.UI.UICornerRadiusSides.None
        UiButton2.RectColor = Color.FromArgb(CByte(48), CByte(48), CByte(48))
        UiButton2.RectDisableColor = Color.FromArgb(CByte(48), CByte(48), CByte(48))
        UiButton2.RectHoverColor = Color.FromArgb(CByte(64), CByte(64), CByte(64))
        UiButton2.RectPressColor = Color.FromArgb(CByte(80), CByte(80), CByte(80))
        UiButton2.RectSelectedColor = Color.FromArgb(CByte(48), CByte(48), CByte(48))
        UiButton2.Size = New Size(125, 35)
        UiButton2.Style = Sunny.UI.UIStyle.Custom
        UiButton2.TabIndex = 85
        UiButton2.TabStop = False
        UiButton2.Text = "取消"
        UiButton2.TipsColor = Color.Gray
        UiButton2.TipsFont = New Font("微软雅黑", 9F)
        ' 
        ' UiButton1
        ' 
        UiButton1.Anchor = AnchorStyles.Bottom Or AnchorStyles.Right
        UiButton1.FillColor = Color.FromArgb(CByte(48), CByte(48), CByte(48))
        UiButton1.FillColor2 = Color.FromArgb(CByte(48), CByte(48), CByte(48))
        UiButton1.FillDisableColor = Color.FromArgb(CByte(48), CByte(48), CByte(48))
        UiButton1.FillHoverColor = Color.FromArgb(CByte(64), CByte(64), CByte(64))
        UiButton1.FillPressColor = Color.FromArgb(CByte(80), CByte(80), CByte(80))
        UiButton1.FillSelectedColor = Color.FromArgb(CByte(48), CByte(48), CByte(48))
        UiButton1.Font = New Font("微软雅黑", 9.75F)
        UiButton1.ForeColor = Color.FromArgb(CByte(224), CByte(224), CByte(224))
        UiButton1.ForeDisableColor = Color.Gray
        UiButton1.ForeHoverColor = Color.FromArgb(CByte(244), CByte(244), CByte(244))
        UiButton1.ForePressColor = Color.FromArgb(CByte(244), CByte(244), CByte(244))
        UiButton1.ForeSelectedColor = Color.FromArgb(CByte(244), CByte(244), CByte(244))
        UiButton1.Location = New Point(340, 457)
        UiButton1.Margin = New Padding(10)
        UiButton1.MinimumSize = New Size(1, 1)
        UiButton1.Name = "UiButton1"
        UiButton1.Radius = 10
        UiButton1.RadiusSides = Sunny.UI.UICornerRadiusSides.None
        UiButton1.RectColor = Color.FromArgb(CByte(48), CByte(48), CByte(48))
        UiButton1.RectDisableColor = Color.FromArgb(CByte(48), CByte(48), CByte(48))
        UiButton1.RectHoverColor = Color.FromArgb(CByte(64), CByte(64), CByte(64))
        UiButton1.RectPressColor = Color.FromArgb(CByte(80), CByte(80), CByte(80))
        UiButton1.RectSelectedColor = Color.FromArgb(CByte(48), CByte(48), CByte(48))
        UiButton1.Size = New Size(125, 35)
        UiButton1.Style = Sunny.UI.UIStyle.Custom
        UiButton1.TabIndex = 84
        UiButton1.TabStop = False
        UiButton1.Text = "确认"
        UiButton1.TipsColor = Color.Gray
        UiButton1.TipsFont = New Font("微软雅黑", 9F)
        ' 
        ' 暗黑文本框1
        ' 
        暗黑文本框1.Anchor = AnchorStyles.Top Or AnchorStyles.Left Or AnchorStyles.Right
        暗黑文本框1.BackColor = Color.FromArgb(CByte(48), CByte(48), CByte(48))
        暗黑文本框1.ForeColor = Color.FromArgb(CByte(224), CByte(224), CByte(224))
        暗黑文本框1.Location = New Point(19, 127)
        暗黑文本框1.Margin = New Padding(5)
        暗黑文本框1.Name = "暗黑文本框1"
        暗黑文本框1.Padding = New Padding(5, 6, 5, 0)
        暗黑文本框1.PasswordChar = vbNullChar
        暗黑文本框1.PlaceholderText = ""
        暗黑文本框1.Size = New Size(446, 30)
        暗黑文本框1.TabIndex = 87
        ' 
        ' Label2
        ' 
        Label2.AutoSize = True
        Label2.Location = New Point(19, 91)
        Label2.Margin = New Padding(10)
        Label2.Name = "Label2"
        Label2.Size = New Size(58, 21)
        Label2.TabIndex = 86
        Label2.Text = "标题栏"
        ' 
        ' 暗黑文本框2
        ' 
        暗黑文本框2.Anchor = AnchorStyles.Top Or AnchorStyles.Left Or AnchorStyles.Right
        暗黑文本框2.BackColor = Color.FromArgb(CByte(48), CByte(48), CByte(48))
        暗黑文本框2.ForeColor = Color.FromArgb(CByte(224), CByte(224), CByte(224))
        暗黑文本框2.Location = New Point(19, 208)
        暗黑文本框2.Margin = New Padding(5)
        暗黑文本框2.Name = "暗黑文本框2"
        暗黑文本框2.Padding = New Padding(5, 6, 5, 0)
        暗黑文本框2.PasswordChar = vbNullChar
        暗黑文本框2.PlaceholderText = ""
        暗黑文本框2.Size = New Size(446, 30)
        暗黑文本框2.TabIndex = 89
        ' 
        ' Label3
        ' 
        Label3.AutoSize = True
        Label3.Location = New Point(19, 172)
        Label3.Margin = New Padding(10)
        Label3.Name = "Label3"
        Label3.Size = New Size(204, 21)
        Label3.TabIndex = 88
        Label3.Text = "描述（用 <br> 表示换行）"
        ' 
        ' UiCheckBox1
        ' 
        UiCheckBox1.CheckBoxSize = 20
        UiCheckBox1.Font = New Font("微软雅黑", 12F)
        UiCheckBox1.ForeColor = SystemColors.ScrollBar
        UiCheckBox1.Location = New Point(19, 253)
        UiCheckBox1.Margin = New Padding(10)
        UiCheckBox1.MinimumSize = New Size(1, 1)
        UiCheckBox1.Name = "UiCheckBox1"
        UiCheckBox1.Size = New Size(321, 23)
        UiCheckBox1.Style = Sunny.UI.UIStyle.Custom
        UiCheckBox1.TabIndex = 90
        UiCheckBox1.Text = "要选择正确的选项，正确选项的序号是："
        ' 
        ' UiNumPadTextBox1
        ' 
        UiNumPadTextBox1.Anchor = AnchorStyles.Top Or AnchorStyles.Right
        UiNumPadTextBox1.FillColor = Color.FromArgb(CByte(24), CByte(24), CByte(24))
        UiNumPadTextBox1.FillColor2 = Color.FromArgb(CByte(24), CByte(24), CByte(24))
        UiNumPadTextBox1.FillDisableColor = Color.FromArgb(CByte(24), CByte(24), CByte(24))
        UiNumPadTextBox1.Font = New Font("微软雅黑", 12F)
        UiNumPadTextBox1.ForeColor = Color.Silver
        UiNumPadTextBox1.ForeDisableColor = Color.Silver
        UiNumPadTextBox1.Location = New Point(365, 251)
        UiNumPadTextBox1.Margin = New Padding(5, 8, 5, 5)
        UiNumPadTextBox1.Maximum = 10R
        UiNumPadTextBox1.Minimum = 1R
        UiNumPadTextBox1.MinimumSize = New Size(63, 0)
        UiNumPadTextBox1.Name = "UiNumPadTextBox1"
        UiNumPadTextBox1.Padding = New Padding(0, 0, 30, 2)
        UiNumPadTextBox1.Size = New Size(100, 30)
        UiNumPadTextBox1.SymbolSize = 24
        UiNumPadTextBox1.TabIndex = 91
        UiNumPadTextBox1.TextAlignment = ContentAlignment.MiddleLeft
        UiNumPadTextBox1.Watermark = ""
        ' 
        ' Form编辑规划_弹窗
        ' 
        AutoScaleDimensions = New SizeF(96F, 96F)
        AutoScaleMode = AutoScaleMode.Dpi
        BackColor = Color.FromArgb(CByte(24), CByte(24), CByte(24))
        CancelButton = UiButton2
        ClientSize = New Size(484, 511)
        Controls.Add(UiNumPadTextBox1)
        Controls.Add(UiCheckBox1)
        Controls.Add(暗黑文本框2)
        Controls.Add(Label3)
        Controls.Add(暗黑文本框1)
        Controls.Add(Label2)
        Controls.Add(UiButton2)
        Controls.Add(UiButton1)
        Controls.Add(UiTextBox1)
        Controls.Add(Label1)
        Controls.Add(UiGroupBox1)
        Font = New Font("微软雅黑", 12F)
        ForeColor = Color.FromArgb(CByte(224), CByte(224), CByte(224))
        MaximizeBox = False
        MinimizeBox = False
        MinimumSize = New Size(500, 550)
        Name = "Form编辑规划_弹窗"
        ShowIcon = False
        ShowInTaskbar = False
        StartPosition = FormStartPosition.Manual
        Text = "弹窗"
        UiGroupBox1.ResumeLayout(False)
        ResumeLayout(False)
        PerformLayout()
    End Sub

    Friend WithEvents UiGroupBox1 As Sunny.UI.UIGroupBox
    Friend WithEvents UiRadioButton7 As Sunny.UI.UIRadioButton
    Friend WithEvents UiRadioButton2 As Sunny.UI.UIRadioButton
    Friend WithEvents UiRadioButton1 As Sunny.UI.UIRadioButton
    Friend WithEvents UiTextBox1 As Sunny.UI.UITextBox
    Friend WithEvents Label1 As Label
    Friend WithEvents UiButton2 As Sunny.UI.UIButton
    Friend WithEvents UiButton1 As Sunny.UI.UIButton
    Friend WithEvents 暗黑文本框1 As 暗黑文本框
    Friend WithEvents Label2 As Label
    Friend WithEvents 暗黑文本框2 As 暗黑文本框
    Friend WithEvents Label3 As Label
    Friend WithEvents UiCheckBox1 As Sunny.UI.UICheckBox
    Friend WithEvents UiNumPadTextBox1 As Sunny.UI.UINumPadTextBox
End Class
