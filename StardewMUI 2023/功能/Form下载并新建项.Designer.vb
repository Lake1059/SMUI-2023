<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Form下载并新建项
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
        UiComboBox1 = New Sunny.UI.UIComboBox()
        暗黑文本框1 = New 暗黑文本框()
        Label2 = New Label()
        暗黑文本框2 = New 暗黑文本框()
        Label3 = New Label()
        UiButton28 = New Sunny.UI.UIButton()
        UiButton1 = New Sunny.UI.UIButton()
        UiButton2 = New Sunny.UI.UIButton()
        UiButton3 = New Sunny.UI.UIButton()
        SuspendLayout()
        ' 
        ' Label1
        ' 
        Label1.AutoSize = True
        Label1.Font = New Font("微软雅黑", 12F)
        Label1.Location = New Point(20, 20)
        Label1.Margin = New Padding(20, 20, 0, 0)
        Label1.Name = "Label1"
        Label1.Size = New Size(122, 21)
        Label1.TabIndex = 1
        Label1.Text = "新建模组项名称"
        ' 
        ' UiComboBox1
        ' 
        UiComboBox1.DataSource = Nothing
        UiComboBox1.DropDownStyle = Sunny.UI.UIDropDownStyle.DropDownList
        UiComboBox1.FillColor = Color.FromArgb(CByte(48), CByte(48), CByte(48))
        UiComboBox1.FillColor2 = Color.FromArgb(CByte(48), CByte(48), CByte(48))
        UiComboBox1.FillDisableColor = Color.FromArgb(CByte(48), CByte(48), CByte(48))
        UiComboBox1.Font = New Font("微软雅黑", 9.75F)
        UiComboBox1.ForeColor = Color.FromArgb(CByte(224), CByte(224), CByte(224))
        UiComboBox1.ForeDisableColor = Color.Gray
        UiComboBox1.ItemFillColor = Color.FromArgb(CByte(48), CByte(48), CByte(48))
        UiComboBox1.ItemForeColor = Color.FromArgb(CByte(224), CByte(224), CByte(224))
        UiComboBox1.ItemHeight = 30
        UiComboBox1.ItemHoverColor = Color.FromArgb(CByte(64), CByte(64), CByte(64))
        UiComboBox1.ItemRectColor = Color.FromArgb(CByte(48), CByte(48), CByte(48))
        UiComboBox1.ItemSelectBackColor = Color.DimGray
        UiComboBox1.ItemSelectForeColor = Color.FromArgb(CByte(224), CByte(224), CByte(224))
        UiComboBox1.Location = New Point(20, 142)
        UiComboBox1.Margin = New Padding(20, 15, 0, 0)
        UiComboBox1.MaxDropDownItems = 10
        UiComboBox1.MinimumSize = New Size(63, 0)
        UiComboBox1.Name = "UiComboBox1"
        UiComboBox1.Padding = New Padding(0, 0, 30, 2)
        UiComboBox1.Radius = 0
        UiComboBox1.RadiusSides = Sunny.UI.UICornerRadiusSides.None
        UiComboBox1.RectColor = Color.Silver
        UiComboBox1.RectDisableColor = Color.Silver
        UiComboBox1.RectSides = ToolStripStatusLabelBorderSides.None
        UiComboBox1.ScrollBarBackColor = Color.FromArgb(CByte(64), CByte(64), CByte(64))
        UiComboBox1.ScrollBarColor = Color.Gray
        UiComboBox1.ScrollBarStyleInherited = False
        UiComboBox1.Size = New Size(344, 30)
        UiComboBox1.Style = Sunny.UI.UIStyle.Custom
        UiComboBox1.SymbolSize = 24
        UiComboBox1.TabIndex = 24
        UiComboBox1.TabStop = False
        UiComboBox1.TextAlignment = ContentAlignment.MiddleLeft
        UiComboBox1.TrimFilter = True
        UiComboBox1.Watermark = ""
        ' 
        ' 暗黑文本框1
        ' 
        暗黑文本框1.AllowDrop = True
        暗黑文本框1.BackColor = Color.FromArgb(CByte(48), CByte(48), CByte(48))
        暗黑文本框1.ForeColor = Color.FromArgb(CByte(224), CByte(224), CByte(224))
        暗黑文本框1.Location = New Point(20, 56)
        暗黑文本框1.Margin = New Padding(11, 15, 11, 0)
        暗黑文本框1.Name = "暗黑文本框1"
        暗黑文本框1.Padding = New Padding(5, 6, 5, 0)
        暗黑文本框1.PasswordChar = vbNullChar
        暗黑文本框1.Size = New Size(344, 30)
        暗黑文本框1.TabIndex = 25
        ' 
        ' Label2
        ' 
        Label2.AutoSize = True
        Label2.Font = New Font("微软雅黑", 12F)
        Label2.Location = New Point(20, 106)
        Label2.Margin = New Padding(20, 20, 0, 0)
        Label2.Name = "Label2"
        Label2.Size = New Size(74, 21)
        Label2.TabIndex = 26
        Label2.Text = "目标分类"
        ' 
        ' 暗黑文本框2
        ' 
        暗黑文本框2.AllowDrop = True
        暗黑文本框2.BackColor = Color.FromArgb(CByte(48), CByte(48), CByte(48))
        暗黑文本框2.ForeColor = Color.FromArgb(CByte(224), CByte(224), CByte(224))
        暗黑文本框2.Location = New Point(20, 228)
        暗黑文本框2.Margin = New Padding(20, 15, 0, 0)
        暗黑文本框2.Name = "暗黑文本框2"
        暗黑文本框2.Padding = New Padding(5, 6, 5, 0)
        暗黑文本框2.PasswordChar = vbNullChar
        暗黑文本框2.Size = New Size(344, 30)
        暗黑文本框2.TabIndex = 28
        ' 
        ' Label3
        ' 
        Label3.AutoSize = True
        Label3.Font = New Font("微软雅黑", 12F)
        Label3.Location = New Point(20, 192)
        Label3.Margin = New Padding(20, 20, 0, 0)
        Label3.Name = "Label3"
        Label3.Size = New Size(193, 21)
        Label3.TabIndex = 27
        Label3.Text = "NEXUS \ ModDrop \ Git"
        ' 
        ' UiButton28
        ' 
        UiButton28.FillColor = Color.FromArgb(CByte(48), CByte(48), CByte(48))
        UiButton28.FillColor2 = Color.FromArgb(CByte(48), CByte(48), CByte(48))
        UiButton28.FillDisableColor = Color.FromArgb(CByte(48), CByte(48), CByte(48))
        UiButton28.FillHoverColor = Color.FromArgb(CByte(64), CByte(64), CByte(64))
        UiButton28.FillPressColor = Color.FromArgb(CByte(80), CByte(80), CByte(80))
        UiButton28.FillSelectedColor = Color.FromArgb(CByte(48), CByte(48), CByte(48))
        UiButton28.Font = New Font("微软雅黑", 9.75F)
        UiButton28.ForeColor = Color.FromArgb(CByte(224), CByte(224), CByte(224))
        UiButton28.ForeDisableColor = Color.Gray
        UiButton28.ForeHoverColor = Color.FromArgb(CByte(244), CByte(244), CByte(244))
        UiButton28.ForePressColor = Color.FromArgb(CByte(244), CByte(244), CByte(244))
        UiButton28.ForeSelectedColor = Color.FromArgb(CByte(244), CByte(244), CByte(244))
        UiButton28.Location = New Point(20, 278)
        UiButton28.Margin = New Padding(20, 20, 0, 0)
        UiButton28.MinimumSize = New Size(1, 1)
        UiButton28.Name = "UiButton28"
        UiButton28.Radius = 10
        UiButton28.RadiusSides = Sunny.UI.UICornerRadiusSides.None
        UiButton28.RectColor = Color.FromArgb(CByte(48), CByte(48), CByte(48))
        UiButton28.RectDisableColor = Color.FromArgb(CByte(48), CByte(48), CByte(48))
        UiButton28.RectHoverColor = Color.FromArgb(CByte(64), CByte(64), CByte(64))
        UiButton28.RectPressColor = Color.FromArgb(CByte(80), CByte(80), CByte(80))
        UiButton28.RectSelectedColor = Color.FromArgb(CByte(48), CByte(48), CByte(48))
        UiButton28.Size = New Size(165, 35)
        UiButton28.Style = Sunny.UI.UIStyle.Custom
        UiButton28.TabIndex = 38
        UiButton28.TabStop = False
        UiButton28.Text = "从 NEXUS 下载"
        UiButton28.TipsColor = Color.Gray
        UiButton28.TipsFont = New Font("微软雅黑", 9F)
        ' 
        ' UiButton1
        ' 
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
        UiButton1.Location = New Point(199, 278)
        UiButton1.Margin = New Padding(20, 15, 0, 0)
        UiButton1.MinimumSize = New Size(1, 1)
        UiButton1.Name = "UiButton1"
        UiButton1.Radius = 10
        UiButton1.RadiusSides = Sunny.UI.UICornerRadiusSides.None
        UiButton1.RectColor = Color.FromArgb(CByte(48), CByte(48), CByte(48))
        UiButton1.RectDisableColor = Color.FromArgb(CByte(48), CByte(48), CByte(48))
        UiButton1.RectHoverColor = Color.FromArgb(CByte(64), CByte(64), CByte(64))
        UiButton1.RectPressColor = Color.FromArgb(CByte(80), CByte(80), CByte(80))
        UiButton1.RectSelectedColor = Color.FromArgb(CByte(48), CByte(48), CByte(48))
        UiButton1.Size = New Size(165, 35)
        UiButton1.Style = Sunny.UI.UIStyle.Custom
        UiButton1.TabIndex = 39
        UiButton1.TabStop = False
        UiButton1.Text = "从 ModDrop 下载"
        UiButton1.TipsColor = Color.Gray
        UiButton1.TipsFont = New Font("微软雅黑", 9F)
        ' 
        ' UiButton2
        ' 
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
        UiButton2.Location = New Point(20, 328)
        UiButton2.Margin = New Padding(20, 15, 0, 15)
        UiButton2.MinimumSize = New Size(1, 1)
        UiButton2.Name = "UiButton2"
        UiButton2.Radius = 10
        UiButton2.RadiusSides = Sunny.UI.UICornerRadiusSides.None
        UiButton2.RectColor = Color.FromArgb(CByte(48), CByte(48), CByte(48))
        UiButton2.RectDisableColor = Color.FromArgb(CByte(48), CByte(48), CByte(48))
        UiButton2.RectHoverColor = Color.FromArgb(CByte(64), CByte(64), CByte(64))
        UiButton2.RectPressColor = Color.FromArgb(CByte(80), CByte(80), CByte(80))
        UiButton2.RectSelectedColor = Color.FromArgb(CByte(48), CByte(48), CByte(48))
        UiButton2.Size = New Size(165, 35)
        UiButton2.Style = Sunny.UI.UIStyle.Custom
        UiButton2.TabIndex = 40
        UiButton2.TabStop = False
        UiButton2.Text = "从 GitHub 下载"
        UiButton2.TipsColor = Color.Gray
        UiButton2.TipsFont = New Font("微软雅黑", 9F)
        ' 
        ' UiButton3
        ' 
        UiButton3.Enabled = False
        UiButton3.FillColor = Color.FromArgb(CByte(48), CByte(48), CByte(48))
        UiButton3.FillColor2 = Color.FromArgb(CByte(48), CByte(48), CByte(48))
        UiButton3.FillDisableColor = Color.FromArgb(CByte(48), CByte(48), CByte(48))
        UiButton3.FillHoverColor = Color.FromArgb(CByte(64), CByte(64), CByte(64))
        UiButton3.FillPressColor = Color.FromArgb(CByte(80), CByte(80), CByte(80))
        UiButton3.FillSelectedColor = Color.FromArgb(CByte(48), CByte(48), CByte(48))
        UiButton3.Font = New Font("微软雅黑", 9.75F)
        UiButton3.ForeColor = Color.FromArgb(CByte(224), CByte(224), CByte(224))
        UiButton3.ForeDisableColor = Color.Gray
        UiButton3.ForeHoverColor = Color.FromArgb(CByte(244), CByte(244), CByte(244))
        UiButton3.ForePressColor = Color.FromArgb(CByte(244), CByte(244), CByte(244))
        UiButton3.ForeSelectedColor = Color.FromArgb(CByte(244), CByte(244), CByte(244))
        UiButton3.Location = New Point(199, 328)
        UiButton3.Margin = New Padding(20, 15, 0, 15)
        UiButton3.MinimumSize = New Size(1, 1)
        UiButton3.Name = "UiButton3"
        UiButton3.Radius = 10
        UiButton3.RadiusSides = Sunny.UI.UICornerRadiusSides.None
        UiButton3.RectColor = Color.FromArgb(CByte(48), CByte(48), CByte(48))
        UiButton3.RectDisableColor = Color.FromArgb(CByte(48), CByte(48), CByte(48))
        UiButton3.RectHoverColor = Color.FromArgb(CByte(64), CByte(64), CByte(64))
        UiButton3.RectPressColor = Color.FromArgb(CByte(80), CByte(80), CByte(80))
        UiButton3.RectSelectedColor = Color.FromArgb(CByte(48), CByte(48), CByte(48))
        UiButton3.Size = New Size(165, 35)
        UiButton3.Style = Sunny.UI.UIStyle.Custom
        UiButton3.TabIndex = 41
        UiButton3.TabStop = False
        UiButton3.Text = "从 Gitee 下载"
        UiButton3.TipsColor = Color.Gray
        UiButton3.TipsFont = New Font("微软雅黑", 9F)
        ' 
        ' Form下载并新建项
        ' 
        AutoScaleDimensions = New SizeF(96F, 96F)
        AutoScaleMode = AutoScaleMode.Dpi
        BackColor = Color.FromArgb(CByte(24), CByte(24), CByte(24))
        ClientSize = New Size(384, 386)
        Controls.Add(UiButton3)
        Controls.Add(UiButton2)
        Controls.Add(UiButton1)
        Controls.Add(UiButton28)
        Controls.Add(暗黑文本框2)
        Controls.Add(Label3)
        Controls.Add(Label2)
        Controls.Add(暗黑文本框1)
        Controls.Add(UiComboBox1)
        Controls.Add(Label1)
        Font = New Font("微软雅黑", 9.75F, FontStyle.Regular, GraphicsUnit.Point, CByte(134))
        ForeColor = Color.FromArgb(CByte(224), CByte(224), CByte(224))
        MaximizeBox = False
        MinimizeBox = False
        MinimumSize = New Size(400, 425)
        Name = "Form下载并新建项"
        ShowIcon = False
        ShowInTaskbar = False
        SizeGripStyle = SizeGripStyle.Hide
        StartPosition = FormStartPosition.Manual
        Text = "下载并新建项"
        ResumeLayout(False)
        PerformLayout()
    End Sub

    Friend WithEvents Label1 As Label
    Friend WithEvents UiComboBox1 As Sunny.UI.UIComboBox
    Friend WithEvents 暗黑文本框1 As 暗黑文本框
    Friend WithEvents Label2 As Label
    Friend WithEvents 暗黑文本框2 As 暗黑文本框
    Friend WithEvents Label3 As Label
    Friend WithEvents UiButton28 As Sunny.UI.UIButton
    Friend WithEvents UiButton1 As Sunny.UI.UIButton
    Friend WithEvents UiButton2 As Sunny.UI.UIButton
    Friend WithEvents UiButton3 As Sunny.UI.UIButton
End Class
