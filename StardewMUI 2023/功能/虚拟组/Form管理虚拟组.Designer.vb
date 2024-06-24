<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Form管理虚拟组
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
        UiButton1 = New Sunny.UI.UIButton()
        UiButton2 = New Sunny.UI.UIButton()
        Panel12 = New Panel()
        ListView1 = New ListView()
        ColumnHeader1 = New ColumnHeader()
        ImageList1 = New ImageList(components)
        UiButton3 = New Sunny.UI.UIButton()
        Label3 = New Label()
        UiButton4 = New Sunny.UI.UIButton()
        UiButton5 = New Sunny.UI.UIButton()
        UiButton8 = New Sunny.UI.UIButton()
        UiButton9 = New Sunny.UI.UIButton()
        Label4 = New Label()
        Label61 = New Label()
        Panel1 = New Panel()
        Label7 = New Label()
        Label6 = New Label()
        Label5 = New Label()
        Panel2 = New Panel()
        Panel3 = New Panel()
        Label2 = New Label()
        Panel12.SuspendLayout()
        Panel1.SuspendLayout()
        Panel2.SuspendLayout()
        Panel3.SuspendLayout()
        SuspendLayout()
        ' 
        ' Label1
        ' 
        Label1.AutoSize = True
        Label1.Dock = DockStyle.Top
        Label1.Font = New Font("微软雅黑", 12F)
        Label1.Location = New Point(20, 20)
        Label1.Margin = New Padding(20, 20, 20, 0)
        Label1.Name = "Label1"
        Label1.Padding = New Padding(0, 0, 0, 20)
        Label1.Size = New Size(74, 41)
        Label1.TabIndex = 1
        Label1.Text = "全局操作"
        ' 
        ' UiButton1
        ' 
        UiButton1.Dock = DockStyle.Top
        UiButton1.FillColor = Color.FromArgb(CByte(0), CByte(64), CByte(0))
        UiButton1.FillColor2 = Color.FromArgb(CByte(48), CByte(48), CByte(48))
        UiButton1.FillDisableColor = Color.FromArgb(CByte(48), CByte(48), CByte(48))
        UiButton1.FillHoverColor = Color.FromArgb(CByte(0), CByte(80), CByte(0))
        UiButton1.FillPressColor = Color.DarkGreen
        UiButton1.FillSelectedColor = Color.FromArgb(CByte(48), CByte(48), CByte(48))
        UiButton1.Font = New Font("微软雅黑", 9.75F)
        UiButton1.ForeColor = Color.FromArgb(CByte(224), CByte(224), CByte(224))
        UiButton1.ForeDisableColor = Color.Gray
        UiButton1.ForeHoverColor = Color.FromArgb(CByte(244), CByte(244), CByte(244))
        UiButton1.ForePressColor = Color.FromArgb(CByte(244), CByte(244), CByte(244))
        UiButton1.ForeSelectedColor = Color.FromArgb(CByte(244), CByte(244), CByte(244))
        UiButton1.Location = New Point(20, 61)
        UiButton1.Margin = New Padding(20, 20, 0, 0)
        UiButton1.MinimumSize = New Size(1, 1)
        UiButton1.Name = "UiButton1"
        UiButton1.Radius = 10
        UiButton1.RadiusSides = Sunny.UI.UICornerRadiusSides.None
        UiButton1.RectColor = Color.FromArgb(CByte(48), CByte(48), CByte(48))
        UiButton1.RectDisableColor = Color.FromArgb(CByte(48), CByte(48), CByte(48))
        UiButton1.RectHoverColor = Color.FromArgb(CByte(64), CByte(64), CByte(64))
        UiButton1.RectPressColor = Color.FromArgb(CByte(80), CByte(80), CByte(80))
        UiButton1.RectSelectedColor = Color.FromArgb(CByte(48), CByte(48), CByte(48))
        UiButton1.Size = New Size(200, 35)
        UiButton1.Style = Sunny.UI.UIStyle.Custom
        UiButton1.TabIndex = 43
        UiButton1.TabStop = False
        UiButton1.Text = "重新扫描组名"
        UiButton1.TipsColor = Color.Gray
        UiButton1.TipsFont = New Font("微软雅黑", 9F)
        ' 
        ' UiButton2
        ' 
        UiButton2.Dock = DockStyle.Top
        UiButton2.FillColor = Color.FromArgb(CByte(64), CByte(0), CByte(0))
        UiButton2.FillColor2 = Color.FromArgb(CByte(48), CByte(48), CByte(48))
        UiButton2.FillDisableColor = Color.FromArgb(CByte(48), CByte(48), CByte(48))
        UiButton2.FillHoverColor = Color.FromArgb(CByte(80), CByte(0), CByte(0))
        UiButton2.FillPressColor = Color.FromArgb(CByte(100), CByte(0), CByte(0))
        UiButton2.FillSelectedColor = Color.FromArgb(CByte(48), CByte(48), CByte(48))
        UiButton2.Font = New Font("微软雅黑", 9.75F)
        UiButton2.ForeColor = Color.FromArgb(CByte(224), CByte(224), CByte(224))
        UiButton2.ForeDisableColor = Color.Gray
        UiButton2.ForeHoverColor = Color.FromArgb(CByte(244), CByte(244), CByte(244))
        UiButton2.ForePressColor = Color.FromArgb(CByte(244), CByte(244), CByte(244))
        UiButton2.ForeSelectedColor = Color.FromArgb(CByte(244), CByte(244), CByte(244))
        UiButton2.Location = New Point(20, 106)
        UiButton2.Margin = New Padding(20, 10, 0, 0)
        UiButton2.MinimumSize = New Size(1, 1)
        UiButton2.Name = "UiButton2"
        UiButton2.Radius = 10
        UiButton2.RadiusSides = Sunny.UI.UICornerRadiusSides.None
        UiButton2.RectColor = Color.FromArgb(CByte(48), CByte(48), CByte(48))
        UiButton2.RectDisableColor = Color.FromArgb(CByte(48), CByte(48), CByte(48))
        UiButton2.RectHoverColor = Color.FromArgb(CByte(64), CByte(64), CByte(64))
        UiButton2.RectPressColor = Color.FromArgb(CByte(80), CByte(80), CByte(80))
        UiButton2.RectSelectedColor = Color.FromArgb(CByte(48), CByte(48), CByte(48))
        UiButton2.Size = New Size(200, 35)
        UiButton2.Style = Sunny.UI.UIStyle.Custom
        UiButton2.TabIndex = 44
        UiButton2.TabStop = False
        UiButton2.Text = "删除选中组"
        UiButton2.TipsColor = Color.Gray
        UiButton2.TipsFont = New Font("微软雅黑", 9F)
        ' 
        ' Panel12
        ' 
        Panel12.BackColor = Color.FromArgb(CByte(32), CByte(32), CByte(32))
        Panel12.Controls.Add(ListView1)
        Panel12.Dock = DockStyle.Fill
        Panel12.Location = New Point(20, 61)
        Panel12.Margin = New Padding(15, 20, 0, 0)
        Panel12.Name = "Panel12"
        Panel12.Padding = New Padding(10)
        Panel12.Size = New Size(304, 430)
        Panel12.TabIndex = 46
        ' 
        ' ListView1
        ' 
        ListView1.AllowDrop = True
        ListView1.BackColor = Color.FromArgb(CByte(32), CByte(32), CByte(32))
        ListView1.BorderStyle = BorderStyle.None
        ListView1.Columns.AddRange(New ColumnHeader() {ColumnHeader1})
        ListView1.Dock = DockStyle.Left
        ListView1.ForeColor = Color.FromArgb(CByte(224), CByte(224), CByte(224))
        ListView1.FullRowSelect = True
        ListView1.HeaderStyle = ColumnHeaderStyle.None
        ListView1.Location = New Point(10, 10)
        ListView1.Name = "ListView1"
        ListView1.OwnerDraw = True
        ListView1.ShowItemToolTips = True
        ListView1.Size = New Size(284, 410)
        ListView1.StateImageList = ImageList1
        ListView1.TabIndex = 2
        ListView1.UseCompatibleStateImageBehavior = False
        ListView1.View = View.Details
        ' 
        ' ImageList1
        ' 
        ImageList1.ColorDepth = ColorDepth.Depth8Bit
        ImageList1.ImageSize = New Size(1, 29)
        ImageList1.TransparentColor = Color.Transparent
        ' 
        ' UiButton3
        ' 
        UiButton3.Dock = DockStyle.Top
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
        UiButton3.Location = New Point(20, 202)
        UiButton3.Margin = New Padding(20, 20, 0, 0)
        UiButton3.MinimumSize = New Size(1, 1)
        UiButton3.Name = "UiButton3"
        UiButton3.Radius = 10
        UiButton3.RadiusSides = Sunny.UI.UICornerRadiusSides.None
        UiButton3.RectColor = Color.FromArgb(CByte(48), CByte(48), CByte(48))
        UiButton3.RectDisableColor = Color.FromArgb(CByte(48), CByte(48), CByte(48))
        UiButton3.RectHoverColor = Color.FromArgb(CByte(64), CByte(64), CByte(64))
        UiButton3.RectPressColor = Color.FromArgb(CByte(80), CByte(80), CByte(80))
        UiButton3.RectSelectedColor = Color.FromArgb(CByte(48), CByte(48), CByte(48))
        UiButton3.Size = New Size(200, 35)
        UiButton3.Style = Sunny.UI.UIStyle.Custom
        UiButton3.TabIndex = 48
        UiButton3.TabStop = False
        UiButton3.Text = "与选择的组相等"
        UiButton3.TipsColor = Color.Gray
        UiButton3.TipsFont = New Font("微软雅黑", 9F)
        ' 
        ' Label3
        ' 
        Label3.AutoSize = True
        Label3.Dock = DockStyle.Top
        Label3.Font = New Font("微软雅黑", 12F)
        Label3.Location = New Point(20, 141)
        Label3.Margin = New Padding(20, 20, 20, 0)
        Label3.Name = "Label3"
        Label3.Padding = New Padding(0, 20, 0, 20)
        Label3.Size = New Size(90, 61)
        Label3.TabIndex = 47
        Label3.Text = "查找选中组"
        ' 
        ' UiButton4
        ' 
        UiButton4.Dock = DockStyle.Top
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
        UiButton4.Location = New Point(20, 247)
        UiButton4.Margin = New Padding(20, 15, 0, 0)
        UiButton4.MinimumSize = New Size(1, 1)
        UiButton4.Name = "UiButton4"
        UiButton4.Radius = 10
        UiButton4.RadiusSides = Sunny.UI.UICornerRadiusSides.None
        UiButton4.RectColor = Color.FromArgb(CByte(48), CByte(48), CByte(48))
        UiButton4.RectDisableColor = Color.FromArgb(CByte(48), CByte(48), CByte(48))
        UiButton4.RectHoverColor = Color.FromArgb(CByte(64), CByte(64), CByte(64))
        UiButton4.RectPressColor = Color.FromArgb(CByte(80), CByte(80), CByte(80))
        UiButton4.RectSelectedColor = Color.FromArgb(CByte(48), CByte(48), CByte(48))
        UiButton4.Size = New Size(200, 35)
        UiButton4.Style = Sunny.UI.UIStyle.Custom
        UiButton4.TabIndex = 49
        UiButton4.TabStop = False
        UiButton4.Text = "包含选择的组"
        UiButton4.TipsColor = Color.Gray
        UiButton4.TipsFont = New Font("微软雅黑", 9F)
        ' 
        ' UiButton5
        ' 
        UiButton5.Dock = DockStyle.Top
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
        UiButton5.Location = New Point(20, 292)
        UiButton5.Margin = New Padding(20, 15, 0, 0)
        UiButton5.MinimumSize = New Size(1, 1)
        UiButton5.Name = "UiButton5"
        UiButton5.Radius = 10
        UiButton5.RadiusSides = Sunny.UI.UICornerRadiusSides.None
        UiButton5.RectColor = Color.FromArgb(CByte(48), CByte(48), CByte(48))
        UiButton5.RectDisableColor = Color.FromArgb(CByte(48), CByte(48), CByte(48))
        UiButton5.RectHoverColor = Color.FromArgb(CByte(64), CByte(64), CByte(64))
        UiButton5.RectPressColor = Color.FromArgb(CByte(80), CByte(80), CByte(80))
        UiButton5.RectSelectedColor = Color.FromArgb(CByte(48), CByte(48), CByte(48))
        UiButton5.Size = New Size(200, 35)
        UiButton5.Style = Sunny.UI.UIStyle.Custom
        UiButton5.TabIndex = 50
        UiButton5.TabStop = False
        UiButton5.Text = "不包含选择的组"
        UiButton5.TipsColor = Color.Gray
        UiButton5.TipsFont = New Font("微软雅黑", 9F)
        ' 
        ' UiButton8
        ' 
        UiButton8.Anchor = AnchorStyles.Top Or AnchorStyles.Right
        UiButton8.FillColor = Color.FromArgb(CByte(102), CByte(58), CByte(183))
        UiButton8.FillColor2 = Color.FromArgb(CByte(102), CByte(58), CByte(183))
        UiButton8.FillHoverColor = Color.FromArgb(CByte(133), CByte(97), CByte(198))
        UiButton8.FillPressColor = Color.FromArgb(CByte(82), CByte(46), CByte(147))
        UiButton8.FillSelectedColor = Color.FromArgb(CByte(82), CByte(46), CByte(147))
        UiButton8.Font = New Font("微软雅黑", 9.75F, FontStyle.Regular, GraphicsUnit.Point, CByte(134))
        UiButton8.LightColor = Color.FromArgb(CByte(244), CByte(242), CByte(251))
        UiButton8.Location = New Point(229, 20)
        UiButton8.Margin = New Padding(20, 20, 0, 0)
        UiButton8.MinimumSize = New Size(1, 1)
        UiButton8.Name = "UiButton8"
        UiButton8.Radius = 10
        UiButton8.RadiusSides = Sunny.UI.UICornerRadiusSides.None
        UiButton8.RectColor = Color.FromArgb(CByte(102), CByte(58), CByte(183))
        UiButton8.RectHoverColor = Color.FromArgb(CByte(133), CByte(97), CByte(198))
        UiButton8.RectPressColor = Color.FromArgb(CByte(82), CByte(46), CByte(147))
        UiButton8.RectSelectedColor = Color.FromArgb(CByte(82), CByte(46), CByte(147))
        UiButton8.Size = New Size(35, 30)
        UiButton8.Style = Sunny.UI.UIStyle.Custom
        UiButton8.TabIndex = 54
        UiButton8.TabStop = False
        UiButton8.Text = "▲"
        UiButton8.TipsColor = Color.Gray
        UiButton8.TipsFont = New Font("微软雅黑", 9F)
        ' 
        ' UiButton9
        ' 
        UiButton9.Anchor = AnchorStyles.Top Or AnchorStyles.Right
        UiButton9.FillColor = Color.FromArgb(CByte(102), CByte(58), CByte(183))
        UiButton9.FillColor2 = Color.FromArgb(CByte(102), CByte(58), CByte(183))
        UiButton9.FillHoverColor = Color.FromArgb(CByte(133), CByte(97), CByte(198))
        UiButton9.FillPressColor = Color.FromArgb(CByte(82), CByte(46), CByte(147))
        UiButton9.FillSelectedColor = Color.FromArgb(CByte(82), CByte(46), CByte(147))
        UiButton9.Font = New Font("微软雅黑", 9.75F, FontStyle.Regular, GraphicsUnit.Point, CByte(134))
        UiButton9.LightColor = Color.FromArgb(CByte(244), CByte(242), CByte(251))
        UiButton9.Location = New Point(269, 20)
        UiButton9.Margin = New Padding(5, 0, 0, 0)
        UiButton9.MinimumSize = New Size(1, 1)
        UiButton9.Name = "UiButton9"
        UiButton9.Radius = 10
        UiButton9.RadiusSides = Sunny.UI.UICornerRadiusSides.None
        UiButton9.RectColor = Color.FromArgb(CByte(102), CByte(58), CByte(183))
        UiButton9.RectHoverColor = Color.FromArgb(CByte(133), CByte(97), CByte(198))
        UiButton9.RectPressColor = Color.FromArgb(CByte(82), CByte(46), CByte(147))
        UiButton9.RectSelectedColor = Color.FromArgb(CByte(82), CByte(46), CByte(147))
        UiButton9.Size = New Size(35, 30)
        UiButton9.Style = Sunny.UI.UIStyle.Custom
        UiButton9.TabIndex = 55
        UiButton9.TabStop = False
        UiButton9.Text = "▼"
        UiButton9.TipsColor = Color.Gray
        UiButton9.TipsFont = New Font("微软雅黑", 9F)
        ' 
        ' Label4
        ' 
        Label4.AutoSize = True
        Label4.Dock = DockStyle.Top
        Label4.Font = New Font("微软雅黑", 12F)
        Label4.Location = New Point(20, 327)
        Label4.Margin = New Padding(20, 20, 20, 0)
        Label4.Name = "Label4"
        Label4.Padding = New Padding(0, 20, 0, 20)
        Label4.Size = New Size(74, 61)
        Label4.TabIndex = 56
        Label4.Text = "操作说明"
        ' 
        ' Label61
        ' 
        Label61.Dock = DockStyle.Fill
        Label61.Font = New Font("微软雅黑", 9.75F, FontStyle.Regular, GraphicsUnit.Point, CByte(134))
        Label61.Location = New Point(20, 388)
        Label61.Margin = New Padding(20)
        Label61.Name = "Label61"
        Label61.Size = New Size(200, 103)
        Label61.TabIndex = 57
        Label61.Text = "在模组项右键菜单里编辑组" & vbCrLf & vbCrLf & "然后在此管理面板中进行查找" & vbCrLf & vbCrLf & "用途广泛，细心安排"
        ' 
        ' Panel1
        ' 
        Panel1.BackColor = Color.FromArgb(CByte(32), CByte(32), CByte(32))
        Panel1.Controls.Add(Label61)
        Panel1.Controls.Add(Label4)
        Panel1.Controls.Add(UiButton5)
        Panel1.Controls.Add(Label7)
        Panel1.Controls.Add(UiButton4)
        Panel1.Controls.Add(Label6)
        Panel1.Controls.Add(UiButton3)
        Panel1.Controls.Add(Label3)
        Panel1.Controls.Add(UiButton2)
        Panel1.Controls.Add(Label5)
        Panel1.Controls.Add(UiButton1)
        Panel1.Controls.Add(Label1)
        Panel1.Dock = DockStyle.Left
        Panel1.Location = New Point(0, 0)
        Panel1.Name = "Panel1"
        Panel1.Padding = New Padding(20)
        Panel1.Size = New Size(240, 511)
        Panel1.TabIndex = 58
        ' 
        ' Label7
        ' 
        Label7.Dock = DockStyle.Top
        Label7.Location = New Point(20, 282)
        Label7.Name = "Label7"
        Label7.Size = New Size(200, 10)
        Label7.TabIndex = 60
        ' 
        ' Label6
        ' 
        Label6.Dock = DockStyle.Top
        Label6.Location = New Point(20, 237)
        Label6.Name = "Label6"
        Label6.Size = New Size(200, 10)
        Label6.TabIndex = 59
        ' 
        ' Label5
        ' 
        Label5.Dock = DockStyle.Top
        Label5.Location = New Point(20, 96)
        Label5.Name = "Label5"
        Label5.Size = New Size(200, 10)
        Label5.TabIndex = 58
        ' 
        ' Panel2
        ' 
        Panel2.Controls.Add(Panel12)
        Panel2.Controls.Add(Panel3)
        Panel2.Dock = DockStyle.Fill
        Panel2.Location = New Point(240, 0)
        Panel2.Name = "Panel2"
        Panel2.Padding = New Padding(20, 0, 20, 20)
        Panel2.Size = New Size(344, 511)
        Panel2.TabIndex = 59
        ' 
        ' Panel3
        ' 
        Panel3.AutoSize = True
        Panel3.Controls.Add(UiButton9)
        Panel3.Controls.Add(UiButton8)
        Panel3.Controls.Add(Label2)
        Panel3.Dock = DockStyle.Top
        Panel3.Location = New Point(20, 0)
        Panel3.Name = "Panel3"
        Panel3.Size = New Size(304, 61)
        Panel3.TabIndex = 47
        ' 
        ' Label2
        ' 
        Label2.AutoSize = True
        Label2.Dock = DockStyle.Fill
        Label2.Font = New Font("微软雅黑", 12F)
        Label2.Location = New Point(0, 0)
        Label2.Margin = New Padding(20, 20, 20, 0)
        Label2.Name = "Label2"
        Label2.Padding = New Padding(0, 20, 0, 20)
        Label2.Size = New Size(90, 61)
        Label2.TabIndex = 46
        Label2.Text = "虚拟组列表"
        ' 
        ' Form管理虚拟组
        ' 
        AutoScaleDimensions = New SizeF(96F, 96F)
        AutoScaleMode = AutoScaleMode.Dpi
        BackColor = Color.FromArgb(CByte(24), CByte(24), CByte(24))
        ClientSize = New Size(584, 511)
        Controls.Add(Panel2)
        Controls.Add(Panel1)
        Font = New Font("微软雅黑", 9.75F, FontStyle.Regular, GraphicsUnit.Point, CByte(134))
        ForeColor = Color.FromArgb(CByte(224), CByte(224), CByte(224))
        MaximizeBox = False
        MinimizeBox = False
        MinimumSize = New Size(600, 550)
        Name = "Form管理虚拟组"
        ShowIcon = False
        ShowInTaskbar = False
        StartPosition = FormStartPosition.Manual
        Text = "管理虚拟组"
        Panel12.ResumeLayout(False)
        Panel1.ResumeLayout(False)
        Panel1.PerformLayout()
        Panel2.ResumeLayout(False)
        Panel2.PerformLayout()
        Panel3.ResumeLayout(False)
        Panel3.PerformLayout()
        ResumeLayout(False)
    End Sub

    Friend WithEvents Label1 As Label
    Friend WithEvents UiButton1 As Sunny.UI.UIButton
    Friend WithEvents UiButton2 As Sunny.UI.UIButton
    Friend WithEvents Panel12 As Panel
    Friend WithEvents ListView1 As ListView
    Friend WithEvents ColumnHeader1 As ColumnHeader
    Friend WithEvents UiButton3 As Sunny.UI.UIButton
    Friend WithEvents Label3 As Label
    Friend WithEvents UiButton4 As Sunny.UI.UIButton
    Friend WithEvents UiButton5 As Sunny.UI.UIButton
    Friend WithEvents UiButton8 As Sunny.UI.UIButton
    Friend WithEvents UiButton9 As Sunny.UI.UIButton
    Friend WithEvents Label4 As Label
    Friend WithEvents Label61 As Label
    Friend WithEvents Panel1 As Panel
    Friend WithEvents Label7 As Label
    Friend WithEvents Label6 As Label
    Friend WithEvents Label5 As Label
    Friend WithEvents Panel2 As Panel
    Friend WithEvents Panel3 As Panel
    Friend WithEvents Label2 As Label
    Friend WithEvents ImageList1 As ImageList
End Class
