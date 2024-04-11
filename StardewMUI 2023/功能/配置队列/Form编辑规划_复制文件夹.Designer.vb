<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Form编辑规划_复制文件夹
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
        Panel1 = New Panel()
        ListView1 = New ListView()
        ColumnHeader1 = New ColumnHeader()
        ImageList1 = New ImageList(components)
        UiButton2 = New Sunny.UI.UIButton()
        UiButton1 = New Sunny.UI.UIButton()
        Label1 = New Label()
        Label2 = New Label()
        UiButton3 = New Sunny.UI.UIButton()
        暗黑文本框1 = New 暗黑文本框()
        Panel1.SuspendLayout()
        SuspendLayout()
        ' 
        ' Panel1
        ' 
        Panel1.Anchor = AnchorStyles.Top Or AnchorStyles.Left Or AnchorStyles.Right
        Panel1.BackColor = Color.FromArgb(CByte(32), CByte(32), CByte(32))
        Panel1.Controls.Add(ListView1)
        Panel1.Location = New Point(19, 60)
        Panel1.Margin = New Padding(10)
        Panel1.Name = "Panel1"
        Panel1.Padding = New Padding(10)
        Panel1.Size = New Size(446, 241)
        Panel1.TabIndex = 49
        ' 
        ' ListView1
        ' 
        ListView1.BackColor = Color.FromArgb(CByte(32), CByte(32), CByte(32))
        ListView1.BorderStyle = BorderStyle.None
        ListView1.Columns.AddRange(New ColumnHeader() {ColumnHeader1})
        ListView1.Dock = DockStyle.Left
        ListView1.Font = New Font("微软雅黑", 9.75F, FontStyle.Regular, GraphicsUnit.Point, CByte(134))
        ListView1.ForeColor = Color.FromArgb(CByte(224), CByte(224), CByte(224))
        ListView1.FullRowSelect = True
        ListView1.HeaderStyle = ColumnHeaderStyle.None
        ListView1.Location = New Point(10, 10)
        ListView1.MultiSelect = False
        ListView1.Name = "ListView1"
        ListView1.OwnerDraw = True
        ListView1.ShowItemToolTips = True
        ListView1.Size = New Size(368, 221)
        ListView1.StateImageList = ImageList1
        ListView1.TabIndex = 1
        ListView1.UseCompatibleStateImageBehavior = False
        ListView1.View = View.Details
        ' 
        ' ImageList1
        ' 
        ImageList1.ColorDepth = ColorDepth.Depth32Bit
        ImageList1.ImageSize = New Size(1, 29)
        ImageList1.TransparentColor = Color.Transparent
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
        UiButton2.Location = New Point(19, 407)
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
        UiButton2.TabIndex = 48
        UiButton2.TabStop = False
        UiButton2.Text = "取消"
        UiButton2.TipsColor = Color.Gray
        UiButton2.TipsFont = New Font("微软雅黑", 9F)
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
        UiButton1.Location = New Point(340, 407)
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
        UiButton1.TabIndex = 47
        UiButton1.TabStop = False
        UiButton1.Text = "确认"
        UiButton1.TipsColor = Color.Gray
        UiButton1.TipsFont = New Font("微软雅黑", 9F)
        ' 
        ' Label1
        ' 
        Label1.AutoSize = True
        Label1.Location = New Point(19, 19)
        Label1.Margin = New Padding(10)
        Label1.Name = "Label1"
        Label1.Size = New Size(90, 21)
        Label1.TabIndex = 46
        Label1.Text = "选择文件夹"
        ' 
        ' Label2
        ' 
        Label2.AutoSize = True
        Label2.Location = New Point(19, 321)
        Label2.Margin = New Padding(10)
        Label2.Name = "Label2"
        Label2.Size = New Size(282, 21)
        Label2.TabIndex = 50
        Label2.Text = "复制到目标位置（从游戏根目录算起）"
        ' 
        ' UiButton3
        ' 
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
        UiButton3.Location = New Point(164, 407)
        UiButton3.Margin = New Padding(10)
        UiButton3.MinimumSize = New Size(1, 1)
        UiButton3.Name = "UiButton3"
        UiButton3.Radius = 10
        UiButton3.RadiusSides = Sunny.UI.UICornerRadiusSides.None
        UiButton3.RectColor = Color.FromArgb(CByte(48), CByte(48), CByte(48))
        UiButton3.RectDisableColor = Color.FromArgb(CByte(48), CByte(48), CByte(48))
        UiButton3.RectHoverColor = Color.FromArgb(CByte(64), CByte(64), CByte(64))
        UiButton3.RectPressColor = Color.FromArgb(CByte(80), CByte(80), CByte(80))
        UiButton3.RectSelectedColor = Color.FromArgb(CByte(48), CByte(48), CByte(48))
        UiButton3.Size = New Size(156, 35)
        UiButton3.Style = Sunny.UI.UIStyle.Custom
        UiButton3.TabIndex = 52
        UiButton3.TabStop = False
        UiButton3.Text = "插入选中"
        UiButton3.TipsColor = Color.Gray
        UiButton3.TipsFont = New Font("微软雅黑", 9F)
        ' 
        ' 暗黑文本框1
        ' 
        暗黑文本框1.Anchor = AnchorStyles.Top Or AnchorStyles.Left Or AnchorStyles.Right
        暗黑文本框1.BackColor = Color.FromArgb(CByte(48), CByte(48), CByte(48))
        暗黑文本框1.ForeColor = Color.FromArgb(CByte(224), CByte(224), CByte(224))
        暗黑文本框1.Location = New Point(19, 357)
        暗黑文本框1.Margin = New Padding(5)
        暗黑文本框1.Name = "暗黑文本框1"
        暗黑文本框1.Padding = New Padding(5, 6, 5, 0)
        暗黑文本框1.PasswordChar = vbNullChar
        暗黑文本框1.Size = New Size(446, 30)
        暗黑文本框1.TabIndex = 53
        ' 
        ' Form编辑规划_复制文件夹
        ' 
        AutoScaleDimensions = New SizeF(96F, 96F)
        AutoScaleMode = AutoScaleMode.Dpi
        BackColor = Color.FromArgb(CByte(24), CByte(24), CByte(24))
        CancelButton = UiButton2
        ClientSize = New Size(484, 461)
        Controls.Add(暗黑文本框1)
        Controls.Add(UiButton3)
        Controls.Add(Label2)
        Controls.Add(Panel1)
        Controls.Add(UiButton2)
        Controls.Add(UiButton1)
        Controls.Add(Label1)
        Font = New Font("微软雅黑", 12F, FontStyle.Regular, GraphicsUnit.Point, CByte(134))
        ForeColor = Color.FromArgb(CByte(224), CByte(224), CByte(224))
        MaximizeBox = False
        MinimizeBox = False
        MinimumSize = New Size(500, 500)
        Name = "Form编辑规划_复制文件夹"
        ShowIcon = False
        ShowInTaskbar = False
        StartPosition = FormStartPosition.Manual
        Text = "编辑规划"
        Panel1.ResumeLayout(False)
        ResumeLayout(False)
        PerformLayout()
    End Sub

    Friend WithEvents Panel1 As Panel
    Friend WithEvents ListView1 As ListView
    Friend WithEvents ColumnHeader1 As ColumnHeader
    Friend WithEvents UiButton2 As Sunny.UI.UIButton
    Friend WithEvents UiButton1 As Sunny.UI.UIButton
    Friend WithEvents Label1 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents UiButton3 As Sunny.UI.UIButton
    Friend WithEvents ImageList1 As ImageList
    Friend WithEvents 暗黑文本框1 As 暗黑文本框
End Class
