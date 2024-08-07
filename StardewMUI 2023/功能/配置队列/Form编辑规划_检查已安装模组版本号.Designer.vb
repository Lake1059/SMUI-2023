<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Form编辑规划_检查已安装模组版本号
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
        UiButton3 = New Sunny.UI.UIButton()
        暗黑文本框1 = New 暗黑文本框()
        UiButton2 = New Sunny.UI.UIButton()
        UiButton1 = New Sunny.UI.UIButton()
        Label2 = New Label()
        UiComboBox1 = New Sunny.UI.UIComboBox()
        暗黑文本框2 = New 暗黑文本框()
        Label3 = New Label()
        SuspendLayout()
        ' 
        ' Label1
        ' 
        Label1.AutoSize = True
        Label1.Location = New Point(19, 19)
        Label1.Margin = New Padding(10)
        Label1.Name = "Label1"
        Label1.Size = New Size(266, 21)
        Label1.TabIndex = 81
        Label1.Text = "要判断的模组（Mods 中的文件夹）"
        ' 
        ' UiButton3
        ' 
        UiButton3.Anchor = AnchorStyles.Top Or AnchorStyles.Right
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
        UiButton3.Location = New Point(340, 20)
        UiButton3.Margin = New Padding(10, 10, 10, 0)
        UiButton3.MinimumSize = New Size(1, 1)
        UiButton3.Name = "UiButton3"
        UiButton3.Radius = 10
        UiButton3.RadiusSides = Sunny.UI.UICornerRadiusSides.None
        UiButton3.RectColor = Color.FromArgb(CByte(48), CByte(48), CByte(48))
        UiButton3.RectDisableColor = Color.FromArgb(CByte(48), CByte(48), CByte(48))
        UiButton3.RectHoverColor = Color.FromArgb(CByte(64), CByte(64), CByte(64))
        UiButton3.RectPressColor = Color.FromArgb(CByte(80), CByte(80), CByte(80))
        UiButton3.RectSelectedColor = Color.FromArgb(CByte(48), CByte(48), CByte(48))
        UiButton3.Size = New Size(125, 30)
        UiButton3.Style = Sunny.UI.UIStyle.Custom
        UiButton3.TabIndex = 83
        UiButton3.TabStop = False
        UiButton3.Text = "快捷插入"
        UiButton3.TipsColor = Color.Gray
        UiButton3.TipsFont = New Font("微软雅黑", 9F)
        ' 
        ' 暗黑文本框1
        ' 
        暗黑文本框1.Anchor = AnchorStyles.Top Or AnchorStyles.Left Or AnchorStyles.Right
        暗黑文本框1.BackColor = Color.FromArgb(CByte(48), CByte(48), CByte(48))
        暗黑文本框1.ForeColor = Color.FromArgb(CByte(224), CByte(224), CByte(224))
        暗黑文本框1.Location = New Point(19, 55)
        暗黑文本框1.Margin = New Padding(5)
        暗黑文本框1.Name = "暗黑文本框1"
        暗黑文本框1.Padding = New Padding(5, 6, 5, 0)
        暗黑文本框1.PasswordChar = vbNullChar
        暗黑文本框1.PlaceholderText = ""
        暗黑文本框1.Size = New Size(446, 30)
        暗黑文本框1.TabIndex = 82
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
        UiButton2.Location = New Point(19, 207)
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
        UiButton1.Location = New Point(340, 207)
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
        ' Label2
        ' 
        Label2.AutoSize = True
        Label2.Location = New Point(19, 100)
        Label2.Margin = New Padding(10)
        Label2.Name = "Label2"
        Label2.Size = New Size(74, 21)
        Label2.TabIndex = 86
        Label2.Text = "比较符号"
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
        UiComboBox1.Items.AddRange(New Object() {"<", ">", "=", "<=", ">=", "<>"})
        UiComboBox1.ItemSelectBackColor = Color.DimGray
        UiComboBox1.ItemSelectForeColor = Color.FromArgb(CByte(224), CByte(224), CByte(224))
        UiComboBox1.Location = New Point(19, 136)
        UiComboBox1.Margin = New Padding(5)
        UiComboBox1.MaxDropDownItems = 10
        UiComboBox1.MinimumSize = New Size(63, 0)
        UiComboBox1.Name = "UiComboBox1"
        UiComboBox1.Padding = New Padding(0, 0, 30, 2)
        UiComboBox1.Radius = 0
        UiComboBox1.RadiusSides = Sunny.UI.UICornerRadiusSides.None
        UiComboBox1.RectColor = Color.Silver
        UiComboBox1.RectDisableColor = Color.Silver
        UiComboBox1.RectSides = ToolStripStatusLabelBorderSides.None
        UiComboBox1.Size = New Size(200, 30)
        UiComboBox1.Style = Sunny.UI.UIStyle.Custom
        UiComboBox1.SymbolSize = 24
        UiComboBox1.TabIndex = 87
        UiComboBox1.TabStop = False
        UiComboBox1.TextAlignment = ContentAlignment.MiddleLeft
        UiComboBox1.TrimFilter = True
        UiComboBox1.Watermark = ""
        ' 
        ' 暗黑文本框2
        ' 
        暗黑文本框2.Anchor = AnchorStyles.Top Or AnchorStyles.Left Or AnchorStyles.Right
        暗黑文本框2.BackColor = Color.FromArgb(CByte(48), CByte(48), CByte(48))
        暗黑文本框2.ForeColor = Color.FromArgb(CByte(224), CByte(224), CByte(224))
        暗黑文本框2.Location = New Point(229, 136)
        暗黑文本框2.Margin = New Padding(5)
        暗黑文本框2.Name = "暗黑文本框2"
        暗黑文本框2.Padding = New Padding(5, 6, 5, 0)
        暗黑文本框2.PasswordChar = vbNullChar
        暗黑文本框2.PlaceholderText = ""
        暗黑文本框2.Size = New Size(236, 30)
        暗黑文本框2.TabIndex = 88
        ' 
        ' Label3
        ' 
        Label3.AutoSize = True
        Label3.Location = New Point(229, 100)
        Label3.Margin = New Padding(10)
        Label3.Name = "Label3"
        Label3.Size = New Size(58, 21)
        Label3.TabIndex = 89
        Label3.Text = "版本号"
        ' 
        ' Form编辑规划_检查已安装模组版本号
        ' 
        AutoScaleDimensions = New SizeF(96F, 96F)
        AutoScaleMode = AutoScaleMode.Dpi
        BackColor = Color.FromArgb(CByte(24), CByte(24), CByte(24))
        CancelButton = UiButton2
        ClientSize = New Size(484, 261)
        Controls.Add(Label3)
        Controls.Add(暗黑文本框2)
        Controls.Add(UiComboBox1)
        Controls.Add(Label2)
        Controls.Add(UiButton2)
        Controls.Add(UiButton1)
        Controls.Add(UiButton3)
        Controls.Add(暗黑文本框1)
        Controls.Add(Label1)
        Font = New Font("微软雅黑", 12F)
        ForeColor = Color.Silver
        MaximizeBox = False
        MinimizeBox = False
        MinimumSize = New Size(500, 300)
        Name = "Form编辑规划_检查已安装模组版本号"
        ShowIcon = False
        ShowInTaskbar = False
        StartPosition = FormStartPosition.Manual
        Text = "检查 Mods 中已安装模组的版本号"
        ResumeLayout(False)
        PerformLayout()
    End Sub

    Friend WithEvents Label1 As Label
    Friend WithEvents UiButton3 As Sunny.UI.UIButton
    Friend WithEvents 暗黑文本框1 As 暗黑文本框
    Friend WithEvents UiButton2 As Sunny.UI.UIButton
    Friend WithEvents UiButton1 As Sunny.UI.UIButton
    Friend WithEvents Label2 As Label
    Friend WithEvents UiComboBox1 As Sunny.UI.UIComboBox
    Friend WithEvents 暗黑文本框2 As 暗黑文本框
    Friend WithEvents Label3 As Label
End Class
