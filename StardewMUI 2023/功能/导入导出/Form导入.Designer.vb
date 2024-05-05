<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Form导入
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
        components = New ComponentModel.Container()
        Label1 = New Label()
        Panel1 = New Panel()
        ListView1 = New ListView()
        ColumnHeader1 = New ColumnHeader()
        ImageList1 = New ImageList(components)
        UiButton1 = New Sunny.UI.UIButton()
        UiButton2 = New Sunny.UI.UIButton()
        UiCheckBox1 = New Sunny.UI.UICheckBox()
        暗黑文本框1 = New 暗黑文本框()
        UiButton3 = New Sunny.UI.UIButton()
        UiButton4 = New Sunny.UI.UIButton()
        UiButton5 = New Sunny.UI.UIButton()
        UiButton6 = New Sunny.UI.UIButton()
        UiCheckBox2 = New Sunny.UI.UICheckBox()
        UiButton7 = New Sunny.UI.UIButton()
        Panel1.SuspendLayout()
        SuspendLayout()
        ' 
        ' Label1
        ' 
        Label1.AutoSize = True
        Label1.Font = New Font("微软雅黑", 12F)
        Label1.Location = New Point(20, 20)
        Label1.Margin = New Padding(20, 20, 20, 0)
        Label1.Name = "Label1"
        Label1.Size = New Size(106, 21)
        Label1.TabIndex = 1
        Label1.Text = "添加打包文件"
        ' 
        ' Panel1
        ' 
        Panel1.Anchor = AnchorStyles.Top Or AnchorStyles.Bottom Or AnchorStyles.Left Or AnchorStyles.Right
        Panel1.BackColor = Color.FromArgb(CByte(36), CByte(36), CByte(36))
        Panel1.Controls.Add(ListView1)
        Panel1.Location = New Point(20, 56)
        Panel1.Margin = New Padding(11, 15, 11, 0)
        Panel1.Name = "Panel1"
        Panel1.Padding = New Padding(10)
        Panel1.Size = New Size(444, 214)
        Panel1.TabIndex = 62
        ' 
        ' ListView1
        ' 
        ListView1.AllowDrop = True
        ListView1.BackColor = Color.FromArgb(CByte(36), CByte(36), CByte(36))
        ListView1.BorderStyle = BorderStyle.None
        ListView1.Columns.AddRange(New ColumnHeader() {ColumnHeader1})
        ListView1.Dock = DockStyle.Fill
        ListView1.ForeColor = Color.FromArgb(CByte(224), CByte(224), CByte(224))
        ListView1.FullRowSelect = True
        ListView1.HeaderStyle = ColumnHeaderStyle.None
        ListView1.Location = New Point(10, 10)
        ListView1.Name = "ListView1"
        ListView1.OwnerDraw = True
        ListView1.Size = New Size(424, 194)
        ListView1.StateImageList = ImageList1
        ListView1.TabIndex = 1
        ListView1.UseCompatibleStateImageBehavior = False
        ListView1.View = View.Details
        ' 
        ' ColumnHeader1
        ' 
        ColumnHeader1.Width = 300
        ' 
        ' ImageList1
        ' 
        ImageList1.ColorDepth = ColorDepth.Depth32Bit
        ImageList1.ImageSize = New Size(16, 16)
        ImageList1.TransparentColor = Color.Transparent
        ' 
        ' UiButton1
        ' 
        UiButton1.Anchor = AnchorStyles.Top Or AnchorStyles.Right
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
        UiButton1.Location = New Point(364, 16)
        UiButton1.Margin = New Padding(0, 7, 0, 0)
        UiButton1.MinimumSize = New Size(1, 1)
        UiButton1.Name = "UiButton1"
        UiButton1.Radius = 10
        UiButton1.RadiusSides = Sunny.UI.UICornerRadiusSides.None
        UiButton1.RectColor = Color.FromArgb(CByte(48), CByte(48), CByte(48))
        UiButton1.RectDisableColor = Color.FromArgb(CByte(48), CByte(48), CByte(48))
        UiButton1.RectHoverColor = Color.FromArgb(CByte(64), CByte(64), CByte(64))
        UiButton1.RectPressColor = Color.FromArgb(CByte(80), CByte(80), CByte(80))
        UiButton1.RectSelectedColor = Color.FromArgb(CByte(48), CByte(48), CByte(48))
        UiButton1.Size = New Size(100, 30)
        UiButton1.Style = Sunny.UI.UIStyle.Custom
        UiButton1.TabIndex = 63
        UiButton1.TabStop = False
        UiButton1.Text = "添加"
        UiButton1.TipsColor = Color.Gray
        UiButton1.TipsFont = New Font("微软雅黑", 9F)
        ' 
        ' UiButton2
        ' 
        UiButton2.Anchor = AnchorStyles.Top Or AnchorStyles.Right
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
        UiButton2.Location = New Point(254, 16)
        UiButton2.Margin = New Padding(0, 7, 10, 0)
        UiButton2.MinimumSize = New Size(1, 1)
        UiButton2.Name = "UiButton2"
        UiButton2.Radius = 10
        UiButton2.RadiusSides = Sunny.UI.UICornerRadiusSides.None
        UiButton2.RectColor = Color.FromArgb(CByte(48), CByte(48), CByte(48))
        UiButton2.RectDisableColor = Color.FromArgb(CByte(48), CByte(48), CByte(48))
        UiButton2.RectHoverColor = Color.FromArgb(CByte(64), CByte(64), CByte(64))
        UiButton2.RectPressColor = Color.FromArgb(CByte(80), CByte(80), CByte(80))
        UiButton2.RectSelectedColor = Color.FromArgb(CByte(48), CByte(48), CByte(48))
        UiButton2.Size = New Size(100, 30)
        UiButton2.Style = Sunny.UI.UIStyle.Custom
        UiButton2.TabIndex = 64
        UiButton2.TabStop = False
        UiButton2.Text = "移除"
        UiButton2.TipsColor = Color.Gray
        UiButton2.TipsFont = New Font("微软雅黑", 9F)
        ' 
        ' UiCheckBox1
        ' 
        UiCheckBox1.Anchor = AnchorStyles.Bottom Or AnchorStyles.Left
        UiCheckBox1.CheckBoxSize = 19
        UiCheckBox1.Font = New Font("微软雅黑", 12F)
        UiCheckBox1.ForeColor = SystemColors.ScrollBar
        UiCheckBox1.Location = New Point(20, 285)
        UiCheckBox1.Margin = New Padding(20, 15, 20, 0)
        UiCheckBox1.MinimumSize = New Size(1, 1)
        UiCheckBox1.Name = "UiCheckBox1"
        UiCheckBox1.Size = New Size(96, 23)
        UiCheckBox1.Style = Sunny.UI.UIStyle.Custom
        UiCheckBox1.TabIndex = 65
        UiCheckBox1.Text = "使用密码"
        ' 
        ' 暗黑文本框1
        ' 
        暗黑文本框1.Anchor = AnchorStyles.Bottom Or AnchorStyles.Left Or AnchorStyles.Right
        暗黑文本框1.BackColor = Color.FromArgb(CByte(48), CByte(48), CByte(48))
        暗黑文本框1.ForeColor = Color.FromArgb(CByte(224), CByte(224), CByte(224))
        暗黑文本框1.Location = New Point(20, 323)
        暗黑文本框1.Margin = New Padding(11, 15, 10, 0)
        暗黑文本框1.Name = "暗黑文本框1"
        暗黑文本框1.Padding = New Padding(5, 6, 5, 0)
        暗黑文本框1.PasswordChar = "●"
        暗黑文本框1.Size = New Size(394, 30)
        暗黑文本框1.TabIndex = 66
        ' 
        ' UiButton3
        ' 
        UiButton3.Anchor = AnchorStyles.Bottom Or AnchorStyles.Right
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
        UiButton3.Location = New Point(364, 282)
        UiButton3.Margin = New Padding(0, 12, 0, 0)
        UiButton3.MinimumSize = New Size(1, 1)
        UiButton3.Name = "UiButton3"
        UiButton3.Radius = 10
        UiButton3.RadiusSides = Sunny.UI.UICornerRadiusSides.None
        UiButton3.RectColor = Color.FromArgb(CByte(48), CByte(48), CByte(48))
        UiButton3.RectDisableColor = Color.FromArgb(CByte(48), CByte(48), CByte(48))
        UiButton3.RectHoverColor = Color.FromArgb(CByte(64), CByte(64), CByte(64))
        UiButton3.RectPressColor = Color.FromArgb(CByte(80), CByte(80), CByte(80))
        UiButton3.RectSelectedColor = Color.FromArgb(CByte(48), CByte(48), CByte(48))
        UiButton3.Size = New Size(100, 30)
        UiButton3.Style = Sunny.UI.UIStyle.Custom
        UiButton3.TabIndex = 67
        UiButton3.TabStop = False
        UiButton3.Text = "密码本"
        UiButton3.TipsColor = Color.Gray
        UiButton3.TipsFont = New Font("微软雅黑", 9F)
        ' 
        ' UiButton4
        ' 
        UiButton4.Anchor = AnchorStyles.Bottom Or AnchorStyles.Left Or AnchorStyles.Right
        UiButton4.FillColor = Color.FromArgb(CByte(48), CByte(48), CByte(48))
        UiButton4.FillColor2 = Color.FromArgb(CByte(48), CByte(48), CByte(48))
        UiButton4.FillDisableColor = Color.FromArgb(CByte(48), CByte(48), CByte(48))
        UiButton4.FillHoverColor = Color.FromArgb(CByte(64), CByte(64), CByte(64))
        UiButton4.FillPressColor = Color.FromArgb(CByte(80), CByte(80), CByte(80))
        UiButton4.FillSelectedColor = Color.FromArgb(CByte(48), CByte(48), CByte(48))
        UiButton4.Font = New Font("微软雅黑", 9.75F)
        UiButton4.ForeColor = Color.FromArgb(CByte(224), CByte(224), CByte(224))
        UiButton4.ForeDisableColor = Color.Gray
        UiButton4.ForeHoverColor = Color.FromArgb(CByte(244), CByte(244), CByte(244))
        UiButton4.ForePressColor = Color.FromArgb(CByte(244), CByte(244), CByte(244))
        UiButton4.ForeSelectedColor = Color.FromArgb(CByte(244), CByte(244), CByte(244))
        UiButton4.Location = New Point(20, 406)
        UiButton4.Margin = New Padding(11, 15, 11, 11)
        UiButton4.MinimumSize = New Size(1, 1)
        UiButton4.Name = "UiButton4"
        UiButton4.Radius = 10
        UiButton4.RadiusSides = Sunny.UI.UICornerRadiusSides.None
        UiButton4.RectColor = Color.FromArgb(CByte(48), CByte(48), CByte(48))
        UiButton4.RectDisableColor = Color.FromArgb(CByte(48), CByte(48), CByte(48))
        UiButton4.RectHoverColor = Color.FromArgb(CByte(64), CByte(64), CByte(64))
        UiButton4.RectPressColor = Color.FromArgb(CByte(80), CByte(80), CByte(80))
        UiButton4.RectSelectedColor = Color.FromArgb(CByte(48), CByte(48), CByte(48))
        UiButton4.Size = New Size(334, 35)
        UiButton4.Style = Sunny.UI.UIStyle.Custom
        UiButton4.TabIndex = 68
        UiButton4.TabStop = False
        UiButton4.Text = "开始导入"
        UiButton4.TipsColor = Color.Gray
        UiButton4.TipsFont = New Font("微软雅黑", 9F)
        ' 
        ' UiButton5
        ' 
        UiButton5.Anchor = AnchorStyles.Bottom Or AnchorStyles.Right
        UiButton5.FillColor = Color.FromArgb(CByte(48), CByte(48), CByte(48))
        UiButton5.FillColor2 = Color.FromArgb(CByte(48), CByte(48), CByte(48))
        UiButton5.FillDisableColor = Color.FromArgb(CByte(48), CByte(48), CByte(48))
        UiButton5.FillHoverColor = Color.FromArgb(CByte(64), CByte(64), CByte(64))
        UiButton5.FillPressColor = Color.FromArgb(CByte(80), CByte(80), CByte(80))
        UiButton5.FillSelectedColor = Color.FromArgb(CByte(48), CByte(48), CByte(48))
        UiButton5.Font = New Font("微软雅黑", 9.75F)
        UiButton5.ForeColor = Color.FromArgb(CByte(224), CByte(224), CByte(224))
        UiButton5.ForeDisableColor = Color.Gray
        UiButton5.ForeHoverColor = Color.FromArgb(CByte(244), CByte(244), CByte(244))
        UiButton5.ForePressColor = Color.FromArgb(CByte(244), CByte(244), CByte(244))
        UiButton5.ForeSelectedColor = Color.FromArgb(CByte(244), CByte(244), CByte(244))
        UiButton5.Location = New Point(254, 282)
        UiButton5.Margin = New Padding(0, 12, 0, 0)
        UiButton5.MinimumSize = New Size(1, 1)
        UiButton5.Name = "UiButton5"
        UiButton5.Radius = 10
        UiButton5.RadiusSides = Sunny.UI.UICornerRadiusSides.None
        UiButton5.RectColor = Color.FromArgb(CByte(48), CByte(48), CByte(48))
        UiButton5.RectDisableColor = Color.FromArgb(CByte(48), CByte(48), CByte(48))
        UiButton5.RectHoverColor = Color.FromArgb(CByte(64), CByte(64), CByte(64))
        UiButton5.RectPressColor = Color.FromArgb(CByte(80), CByte(80), CByte(80))
        UiButton5.RectSelectedColor = Color.FromArgb(CByte(48), CByte(48), CByte(48))
        UiButton5.Size = New Size(100, 30)
        UiButton5.Style = Sunny.UI.UIStyle.Custom
        UiButton5.TabIndex = 69
        UiButton5.TabStop = False
        UiButton5.Text = "删除本"
        UiButton5.TipsColor = Color.Gray
        UiButton5.TipsFont = New Font("微软雅黑", 9F)
        ' 
        ' UiButton6
        ' 
        UiButton6.Anchor = AnchorStyles.Bottom Or AnchorStyles.Right
        UiButton6.FillColor = Color.FromArgb(CByte(48), CByte(48), CByte(48))
        UiButton6.FillColor2 = Color.FromArgb(CByte(48), CByte(48), CByte(48))
        UiButton6.FillDisableColor = Color.FromArgb(CByte(48), CByte(48), CByte(48))
        UiButton6.FillHoverColor = Color.FromArgb(CByte(64), CByte(64), CByte(64))
        UiButton6.FillPressColor = Color.FromArgb(CByte(80), CByte(80), CByte(80))
        UiButton6.FillSelectedColor = Color.FromArgb(CByte(48), CByte(48), CByte(48))
        UiButton6.Font = New Font("微软雅黑", 9.75F)
        UiButton6.ForeColor = Color.FromArgb(CByte(224), CByte(224), CByte(224))
        UiButton6.ForeDisableColor = Color.Gray
        UiButton6.ForeHoverColor = Color.FromArgb(CByte(244), CByte(244), CByte(244))
        UiButton6.ForePressColor = Color.FromArgb(CByte(244), CByte(244), CByte(244))
        UiButton6.ForeSelectedColor = Color.FromArgb(CByte(244), CByte(244), CByte(244))
        UiButton6.Location = New Point(424, 323)
        UiButton6.Margin = New Padding(0, 12, 0, 0)
        UiButton6.MinimumSize = New Size(1, 1)
        UiButton6.Name = "UiButton6"
        UiButton6.Radius = 10
        UiButton6.RadiusSides = Sunny.UI.UICornerRadiusSides.None
        UiButton6.RectColor = Color.FromArgb(CByte(48), CByte(48), CByte(48))
        UiButton6.RectDisableColor = Color.FromArgb(CByte(48), CByte(48), CByte(48))
        UiButton6.RectHoverColor = Color.FromArgb(CByte(64), CByte(64), CByte(64))
        UiButton6.RectPressColor = Color.FromArgb(CByte(80), CByte(80), CByte(80))
        UiButton6.RectSelectedColor = Color.FromArgb(CByte(48), CByte(48), CByte(48))
        UiButton6.Size = New Size(40, 30)
        UiButton6.Style = Sunny.UI.UIStyle.Custom
        UiButton6.TabIndex = 70
        UiButton6.TabStop = False
        UiButton6.Text = "●"
        UiButton6.TipsColor = Color.Gray
        UiButton6.TipsFont = New Font("微软雅黑", 9F)
        ' 
        ' UiCheckBox2
        ' 
        UiCheckBox2.Anchor = AnchorStyles.Bottom Or AnchorStyles.Left
        UiCheckBox2.CheckBoxSize = 19
        UiCheckBox2.Font = New Font("微软雅黑", 12F)
        UiCheckBox2.ForeColor = SystemColors.ScrollBar
        UiCheckBox2.Location = New Point(20, 368)
        UiCheckBox2.Margin = New Padding(20, 15, 20, 0)
        UiCheckBox2.MinimumSize = New Size(1, 1)
        UiCheckBox2.Name = "UiCheckBox2"
        UiCheckBox2.Size = New Size(192, 23)
        UiCheckBox2.Style = Sunny.UI.UIStyle.Custom
        UiCheckBox2.TabIndex = 71
        UiCheckBox2.Text = "完成后自动关闭控制台"
        ' 
        ' UiButton7
        ' 
        UiButton7.Anchor = AnchorStyles.Bottom Or AnchorStyles.Right
        UiButton7.FillColor = Color.FromArgb(CByte(48), CByte(48), CByte(48))
        UiButton7.FillColor2 = Color.FromArgb(CByte(48), CByte(48), CByte(48))
        UiButton7.FillDisableColor = Color.FromArgb(CByte(48), CByte(48), CByte(48))
        UiButton7.FillHoverColor = Color.FromArgb(CByte(64), CByte(64), CByte(64))
        UiButton7.FillPressColor = Color.FromArgb(CByte(80), CByte(80), CByte(80))
        UiButton7.FillSelectedColor = Color.FromArgb(CByte(48), CByte(48), CByte(48))
        UiButton7.Font = New Font("微软雅黑", 9.75F)
        UiButton7.ForeColor = Color.FromArgb(CByte(224), CByte(224), CByte(224))
        UiButton7.ForeDisableColor = Color.Gray
        UiButton7.ForeHoverColor = Color.FromArgb(CByte(244), CByte(244), CByte(244))
        UiButton7.ForePressColor = Color.FromArgb(CByte(244), CByte(244), CByte(244))
        UiButton7.ForeSelectedColor = Color.FromArgb(CByte(244), CByte(244), CByte(244))
        UiButton7.Location = New Point(364, 406)
        UiButton7.Margin = New Padding(0, 12, 0, 0)
        UiButton7.MinimumSize = New Size(1, 1)
        UiButton7.Name = "UiButton7"
        UiButton7.Radius = 10
        UiButton7.RadiusSides = Sunny.UI.UICornerRadiusSides.None
        UiButton7.RectColor = Color.FromArgb(CByte(48), CByte(48), CByte(48))
        UiButton7.RectDisableColor = Color.FromArgb(CByte(48), CByte(48), CByte(48))
        UiButton7.RectHoverColor = Color.FromArgb(CByte(64), CByte(64), CByte(64))
        UiButton7.RectPressColor = Color.FromArgb(CByte(80), CByte(80), CByte(80))
        UiButton7.RectSelectedColor = Color.FromArgb(CByte(48), CByte(48), CByte(48))
        UiButton7.Size = New Size(100, 35)
        UiButton7.Style = Sunny.UI.UIStyle.Custom
        UiButton7.TabIndex = 72
        UiButton7.TabStop = False
        UiButton7.Text = "注意"
        UiButton7.TipsColor = Color.Gray
        UiButton7.TipsFont = New Font("微软雅黑", 9F)
        ' 
        ' Form导入
        ' 
        AutoScaleDimensions = New SizeF(96F, 96F)
        AutoScaleMode = AutoScaleMode.Dpi
        BackColor = Color.FromArgb(CByte(24), CByte(24), CByte(24))
        ClientSize = New Size(484, 461)
        Controls.Add(UiButton7)
        Controls.Add(UiCheckBox2)
        Controls.Add(UiButton6)
        Controls.Add(UiButton5)
        Controls.Add(UiButton4)
        Controls.Add(UiButton3)
        Controls.Add(暗黑文本框1)
        Controls.Add(UiCheckBox1)
        Controls.Add(UiButton2)
        Controls.Add(UiButton1)
        Controls.Add(Panel1)
        Controls.Add(Label1)
        Font = New Font("微软雅黑", 9.75F, FontStyle.Regular, GraphicsUnit.Point, CByte(134))
        ForeColor = Color.FromArgb(CByte(224), CByte(224), CByte(224))
        MaximizeBox = False
        MinimizeBox = False
        MinimumSize = New Size(500, 500)
        Name = "Form导入"
        ShowIcon = False
        ShowInTaskbar = False
        StartPosition = FormStartPosition.Manual
        Text = "导入"
        Panel1.ResumeLayout(False)
        ResumeLayout(False)
        PerformLayout()
    End Sub

    Friend WithEvents Label1 As Label
    Friend WithEvents Panel1 As Panel
    Friend WithEvents ListView1 As ListView
    Friend WithEvents ColumnHeader1 As ColumnHeader
    Friend WithEvents UiButton1 As Sunny.UI.UIButton
    Friend WithEvents UiButton2 As Sunny.UI.UIButton
    Friend WithEvents UiCheckBox1 As Sunny.UI.UICheckBox
    Friend WithEvents 暗黑文本框1 As 暗黑文本框
    Friend WithEvents UiButton3 As Sunny.UI.UIButton
    Friend WithEvents UiButton4 As Sunny.UI.UIButton
    Friend WithEvents UiButton5 As Sunny.UI.UIButton
    Friend WithEvents UiButton6 As Sunny.UI.UIButton
    Friend WithEvents UiCheckBox2 As Sunny.UI.UICheckBox
    Friend WithEvents ImageList1 As ImageList
    Friend WithEvents UiButton7 As Sunny.UI.UIButton
End Class
