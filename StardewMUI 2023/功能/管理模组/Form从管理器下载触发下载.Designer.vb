<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Form从管理器下载触发下载
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
        Label2 = New Label()
        暗黑文本框1 = New 暗黑文本框()
        Label3 = New Label()
        Label4 = New Label()
        UiComboBox1 = New Sunny.UI.UIComboBox()
        UiButton1 = New Sunny.UI.UIButton()
        Label5 = New Label()
        SuspendLayout()
        ' 
        ' Label1
        ' 
        Label1.AutoSize = True
        Label1.Font = New Font("微软雅黑", 12F)
        Label1.Location = New Point(20, 20)
        Label1.Margin = New Padding(20, 20, 20, 0)
        Label1.Name = "Label1"
        Label1.Size = New Size(144, 21)
        Label1.TabIndex = 1
        Label1.Text = "模组 ID 和 文件 ID"
        ' 
        ' Label2
        ' 
        Label2.AutoSize = True
        Label2.Font = New Font("微软雅黑", 12F)
        Label2.Location = New Point(20, 56)
        Label2.Margin = New Padding(20, 15, 20, 0)
        Label2.Name = "Label2"
        Label2.Size = New Size(74, 21)
        Label2.TabIndex = 2
        Label2.Text = "额外参数"
        ' 
        ' 暗黑文本框1
        ' 
        暗黑文本框1.Anchor = AnchorStyles.Top Or AnchorStyles.Left Or AnchorStyles.Right
        暗黑文本框1.BackColor = Color.FromArgb(CByte(48), CByte(48), CByte(48))
        暗黑文本框1.ForeColor = Color.FromArgb(CByte(224), CByte(224), CByte(224))
        暗黑文本框1.Location = New Point(20, 128)
        暗黑文本框1.Margin = New Padding(20, 15, 10, 0)
        暗黑文本框1.Name = "暗黑文本框1"
        暗黑文本框1.Padding = New Padding(7, 6, 7, 0)
        暗黑文本框1.PasswordChar = vbNullChar
        暗黑文本框1.Size = New Size(395, 30)
        暗黑文本框1.TabIndex = 38
        ' 
        ' Label3
        ' 
        Label3.AutoSize = True
        Label3.Font = New Font("微软雅黑", 12F)
        Label3.Location = New Point(20, 92)
        Label3.Margin = New Padding(20, 15, 20, 0)
        Label3.Name = "Label3"
        Label3.Size = New Size(90, 21)
        Label3.TabIndex = 39
        Label3.Text = "新建项名称"
        ' 
        ' Label4
        ' 
        Label4.AutoSize = True
        Label4.Font = New Font("微软雅黑", 12F)
        Label4.Location = New Point(20, 173)
        Label4.Margin = New Padding(20, 15, 20, 0)
        Label4.Name = "Label4"
        Label4.Size = New Size(74, 21)
        Label4.TabIndex = 40
        Label4.Text = "目标分类"
        ' 
        ' UiComboBox1
        ' 
        UiComboBox1.Anchor = AnchorStyles.Top Or AnchorStyles.Left Or AnchorStyles.Right
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
        UiComboBox1.Location = New Point(20, 209)
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
        UiComboBox1.Size = New Size(395, 30)
        UiComboBox1.Style = Sunny.UI.UIStyle.Custom
        UiComboBox1.SymbolSize = 24
        UiComboBox1.TabIndex = 41
        UiComboBox1.TabStop = False
        UiComboBox1.TextAlignment = ContentAlignment.MiddleLeft
        UiComboBox1.TrimFilter = True
        UiComboBox1.Watermark = ""
        ' 
        ' UiButton1
        ' 
        UiButton1.Anchor = AnchorStyles.Top Or AnchorStyles.Left Or AnchorStyles.Right
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
        UiButton1.Location = New Point(20, 259)
        UiButton1.Margin = New Padding(20, 20, 20, 0)
        UiButton1.MinimumSize = New Size(1, 1)
        UiButton1.Name = "UiButton1"
        UiButton1.Radius = 10
        UiButton1.RadiusSides = Sunny.UI.UICornerRadiusSides.None
        UiButton1.RectColor = Color.FromArgb(CByte(48), CByte(48), CByte(48))
        UiButton1.RectDisableColor = Color.FromArgb(CByte(48), CByte(48), CByte(48))
        UiButton1.RectHoverColor = Color.FromArgb(CByte(64), CByte(64), CByte(64))
        UiButton1.RectPressColor = Color.FromArgb(CByte(80), CByte(80), CByte(80))
        UiButton1.RectSelectedColor = Color.FromArgb(CByte(48), CByte(48), CByte(48))
        UiButton1.Size = New Size(395, 35)
        UiButton1.Style = Sunny.UI.UIStyle.Custom
        UiButton1.TabIndex = 42
        UiButton1.TabStop = False
        UiButton1.Text = "开始下载"
        UiButton1.TipsColor = Color.Gray
        UiButton1.TipsFont = New Font("微软雅黑", 9F)
        ' 
        ' Label5
        ' 
        Label5.AutoSize = True
        Label5.Font = New Font("微软雅黑", 12F)
        Label5.Location = New Point(20, 309)
        Label5.Margin = New Padding(20, 15, 20, 10)
        Label5.Name = "Label5"
        Label5.Size = New Size(74, 21)
        Label5.TabIndex = 43
        Label5.Text = "连接状态"
        ' 
        ' Form从管理器下载触发下载
        ' 
        AutoScaleDimensions = New SizeF(96F, 96F)
        AutoScaleMode = AutoScaleMode.Dpi
        BackColor = Color.FromArgb(CByte(24), CByte(24), CByte(24))
        ClientSize = New Size(434, 349)
        Controls.Add(Label5)
        Controls.Add(UiButton1)
        Controls.Add(UiComboBox1)
        Controls.Add(Label4)
        Controls.Add(Label3)
        Controls.Add(暗黑文本框1)
        Controls.Add(Label2)
        Controls.Add(Label1)
        Font = New Font("微软雅黑", 12F, FontStyle.Regular, GraphicsUnit.Point, CByte(134))
        ForeColor = Color.FromArgb(CByte(224), CByte(224), CByte(224))
        Margin = New Padding(4)
        MaximizeBox = False
        MinimizeBox = False
        MinimumSize = New Size(450, 388)
        Name = "Form从管理器下载触发下载"
        ShowIcon = False
        ShowInTaskbar = False
        SizeGripStyle = SizeGripStyle.Hide
        StartPosition = FormStartPosition.Manual
        Text = "MOD MANAGER DOWNLOAD"
        ResumeLayout(False)
        PerformLayout()
    End Sub

    Friend WithEvents Label1 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents 暗黑文本框1 As 暗黑文本框
    Friend WithEvents Label3 As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents UiComboBox1 As Sunny.UI.UIComboBox
    Friend WithEvents UiButton1 As Sunny.UI.UIButton
    Friend WithEvents Label5 As Label
End Class
