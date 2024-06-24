<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Form编辑虚拟组
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
        Panel3 = New Panel()
        ListView1 = New ListView()
        ColumnHeader1 = New ColumnHeader()
        ImageList1 = New ImageList(components)
        UiButton7 = New Sunny.UI.UIButton()
        UiButton6 = New Sunny.UI.UIButton()
        UiButton5 = New Sunny.UI.UIButton()
        UiButton9 = New Sunny.UI.UIButton()
        Label5 = New Label()
        Label1 = New Label()
        Panel4 = New Panel()
        UiButton1 = New Sunny.UI.UIButton()
        Label4 = New Label()
        UiButton2 = New Sunny.UI.UIButton()
        Label7 = New Label()
        UiButton8 = New Sunny.UI.UIButton()
        Panel2 = New Panel()
        Panel12 = New Panel()
        ListView2 = New ListView()
        ColumnHeader2 = New ColumnHeader()
        Label6 = New Label()
        UiButton3 = New Sunny.UI.UIButton()
        Label3 = New Label()
        UiButton4 = New Sunny.UI.UIButton()
        Label2 = New Label()
        Panel1.SuspendLayout()
        Panel3.SuspendLayout()
        Panel4.SuspendLayout()
        Panel2.SuspendLayout()
        Panel12.SuspendLayout()
        SuspendLayout()
        ' 
        ' Panel1
        ' 
        Panel1.BackColor = Color.FromArgb(CByte(32), CByte(32), CByte(32))
        Panel1.Controls.Add(Panel3)
        Panel1.Controls.Add(UiButton7)
        Panel1.Controls.Add(UiButton6)
        Panel1.Controls.Add(UiButton5)
        Panel1.Controls.Add(UiButton9)
        Panel1.Controls.Add(Label5)
        Panel1.Controls.Add(Label1)
        Panel1.Controls.Add(Panel4)
        Panel1.Dock = DockStyle.Left
        Panel1.Location = New Point(0, 0)
        Panel1.Name = "Panel1"
        Panel1.Padding = New Padding(15)
        Panel1.Size = New Size(292, 461)
        Panel1.TabIndex = 3
        ' 
        ' Panel3
        ' 
        Panel3.BackColor = Color.FromArgb(CByte(24), CByte(24), CByte(24))
        Panel3.Controls.Add(ListView1)
        Panel3.Dock = DockStyle.Fill
        Panel3.Location = New Point(15, 56)
        Panel3.Margin = New Padding(15, 20, 0, 0)
        Panel3.Name = "Panel3"
        Panel3.Padding = New Padding(10)
        Panel3.Size = New Size(262, 300)
        Panel3.TabIndex = 69
        ' 
        ' ListView1
        ' 
        ListView1.AllowDrop = True
        ListView1.BackColor = Color.FromArgb(CByte(24), CByte(24), CByte(24))
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
        ListView1.Size = New Size(242, 280)
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
        ' UiButton7
        ' 
        UiButton7.Anchor = AnchorStyles.Top Or AnchorStyles.Right
        UiButton7.FillColor = Color.FromArgb(CByte(110), CByte(190), CByte(40))
        UiButton7.FillColor2 = Color.FromArgb(CByte(110), CByte(190), CByte(40))
        UiButton7.FillHoverColor = Color.FromArgb(CByte(139), CByte(203), CByte(83))
        UiButton7.FillPressColor = Color.FromArgb(CByte(88), CByte(152), CByte(32))
        UiButton7.FillSelectedColor = Color.FromArgb(CByte(88), CByte(152), CByte(32))
        UiButton7.Font = New Font("微软雅黑", 18F, FontStyle.Regular, GraphicsUnit.Point, CByte(134))
        UiButton7.LightColor = Color.FromArgb(CByte(245), CByte(251), CByte(241))
        UiButton7.Location = New Point(122, 15)
        UiButton7.Margin = New Padding(5, 0, 0, 0)
        UiButton7.MinimumSize = New Size(1, 1)
        UiButton7.Name = "UiButton7"
        UiButton7.Radius = 10
        UiButton7.RadiusSides = Sunny.UI.UICornerRadiusSides.None
        UiButton7.RectColor = Color.FromArgb(CByte(110), CByte(190), CByte(40))
        UiButton7.RectHoverColor = Color.FromArgb(CByte(139), CByte(203), CByte(83))
        UiButton7.RectPressColor = Color.FromArgb(CByte(88), CByte(152), CByte(32))
        UiButton7.RectSelectedColor = Color.FromArgb(CByte(88), CByte(152), CByte(32))
        UiButton7.Size = New Size(35, 30)
        UiButton7.Style = Sunny.UI.UIStyle.Custom
        UiButton7.TabIndex = 73
        UiButton7.TabStop = False
        UiButton7.Text = "＋"
        UiButton7.TextAlign = ContentAlignment.BottomCenter
        UiButton7.TipsColor = Color.Gray
        UiButton7.TipsFont = New Font("微软雅黑", 9F)
        ' 
        ' UiButton6
        ' 
        UiButton6.Anchor = AnchorStyles.Top Or AnchorStyles.Right
        UiButton6.Font = New Font("微软雅黑", 12F, FontStyle.Bold)
        UiButton6.Location = New Point(162, 15)
        UiButton6.Margin = New Padding(5, 0, 0, 0)
        UiButton6.MinimumSize = New Size(1, 1)
        UiButton6.Name = "UiButton6"
        UiButton6.Radius = 10
        UiButton6.RadiusSides = Sunny.UI.UICornerRadiusSides.None
        UiButton6.Size = New Size(35, 30)
        UiButton6.Style = Sunny.UI.UIStyle.Custom
        UiButton6.TabIndex = 72
        UiButton6.TabStop = False
        UiButton6.Text = "▲"
        UiButton6.TipsColor = Color.Gray
        UiButton6.TipsFont = New Font("微软雅黑", 9F)
        ' 
        ' UiButton5
        ' 
        UiButton5.Anchor = AnchorStyles.Top Or AnchorStyles.Right
        UiButton5.Font = New Font("微软雅黑", 12F, FontStyle.Bold)
        UiButton5.Location = New Point(202, 15)
        UiButton5.Margin = New Padding(5, 0, 0, 0)
        UiButton5.MinimumSize = New Size(1, 1)
        UiButton5.Name = "UiButton5"
        UiButton5.Radius = 10
        UiButton5.RadiusSides = Sunny.UI.UICornerRadiusSides.None
        UiButton5.Size = New Size(35, 30)
        UiButton5.Style = Sunny.UI.UIStyle.Custom
        UiButton5.TabIndex = 71
        UiButton5.TabStop = False
        UiButton5.Text = "▼"
        UiButton5.TipsColor = Color.Gray
        UiButton5.TipsFont = New Font("微软雅黑", 9F)
        ' 
        ' UiButton9
        ' 
        UiButton9.Anchor = AnchorStyles.Top Or AnchorStyles.Right
        UiButton9.FillColor = Color.FromArgb(CByte(230), CByte(80), CByte(80))
        UiButton9.FillColor2 = Color.FromArgb(CByte(230), CByte(80), CByte(80))
        UiButton9.FillHoverColor = Color.FromArgb(CByte(235), CByte(115), CByte(115))
        UiButton9.FillPressColor = Color.FromArgb(CByte(184), CByte(64), CByte(64))
        UiButton9.FillSelectedColor = Color.FromArgb(CByte(184), CByte(64), CByte(64))
        UiButton9.Font = New Font("微软雅黑", 14.25F, FontStyle.Regular, GraphicsUnit.Point, CByte(134))
        UiButton9.LightColor = Color.FromArgb(CByte(253), CByte(243), CByte(243))
        UiButton9.Location = New Point(242, 15)
        UiButton9.Margin = New Padding(5, 0, 0, 0)
        UiButton9.MinimumSize = New Size(1, 1)
        UiButton9.Name = "UiButton9"
        UiButton9.Radius = 10
        UiButton9.RadiusSides = Sunny.UI.UICornerRadiusSides.None
        UiButton9.RectColor = Color.FromArgb(CByte(230), CByte(80), CByte(80))
        UiButton9.RectHoverColor = Color.FromArgb(CByte(235), CByte(115), CByte(115))
        UiButton9.RectPressColor = Color.FromArgb(CByte(184), CByte(64), CByte(64))
        UiButton9.RectSelectedColor = Color.FromArgb(CByte(184), CByte(64), CByte(64))
        UiButton9.Size = New Size(35, 30)
        UiButton9.Style = Sunny.UI.UIStyle.Custom
        UiButton9.TabIndex = 70
        UiButton9.TabStop = False
        UiButton9.Text = "╳"
        UiButton9.TipsColor = Color.Gray
        UiButton9.TipsFont = New Font("微软雅黑", 9F)
        ' 
        ' Label5
        ' 
        Label5.Dock = DockStyle.Bottom
        Label5.Location = New Point(15, 356)
        Label5.Name = "Label5"
        Label5.Size = New Size(262, 10)
        Label5.TabIndex = 64
        ' 
        ' Label1
        ' 
        Label1.AutoSize = True
        Label1.Dock = DockStyle.Top
        Label1.Font = New Font("微软雅黑", 12F)
        Label1.Location = New Point(15, 15)
        Label1.Margin = New Padding(20, 20, 20, 0)
        Label1.Name = "Label1"
        Label1.Padding = New Padding(0, 0, 0, 20)
        Label1.Size = New Size(42, 41)
        Label1.TabIndex = 3
        Label1.Text = "编辑"
        ' 
        ' Panel4
        ' 
        Panel4.AutoSize = True
        Panel4.Controls.Add(UiButton1)
        Panel4.Controls.Add(Label4)
        Panel4.Controls.Add(UiButton2)
        Panel4.Controls.Add(Label7)
        Panel4.Controls.Add(UiButton8)
        Panel4.Dock = DockStyle.Bottom
        Panel4.Location = New Point(15, 366)
        Panel4.Name = "Panel4"
        Panel4.Size = New Size(262, 80)
        Panel4.TabIndex = 74
        ' 
        ' UiButton1
        ' 
        UiButton1.Dock = DockStyle.Bottom
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
        UiButton1.Location = New Point(0, 0)
        UiButton1.MinimumSize = New Size(1, 1)
        UiButton1.Name = "UiButton1"
        UiButton1.Radius = 1
        UiButton1.RadiusSides = Sunny.UI.UICornerRadiusSides.None
        UiButton1.RectColor = Color.FromArgb(CByte(48), CByte(48), CByte(48))
        UiButton1.RectDisableColor = Color.FromArgb(CByte(48), CByte(48), CByte(48))
        UiButton1.RectHoverColor = Color.FromArgb(CByte(64), CByte(64), CByte(64))
        UiButton1.RectPressColor = Color.FromArgb(CByte(80), CByte(80), CByte(80))
        UiButton1.RectSelectedColor = Color.FromArgb(CByte(48), CByte(48), CByte(48))
        UiButton1.Size = New Size(192, 35)
        UiButton1.Style = Sunny.UI.UIStyle.Custom
        UiButton1.TabIndex = 68
        UiButton1.TabStop = False
        UiButton1.Text = "新增（保留已有）"
        UiButton1.TipsColor = Color.Gray
        UiButton1.TipsFont = New Font("微软雅黑", 9F)
        ' 
        ' Label4
        ' 
        Label4.Dock = DockStyle.Bottom
        Label4.Location = New Point(0, 35)
        Label4.Name = "Label4"
        Label4.Size = New Size(192, 10)
        Label4.TabIndex = 69
        ' 
        ' UiButton2
        ' 
        UiButton2.Dock = DockStyle.Bottom
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
        UiButton2.Location = New Point(0, 45)
        UiButton2.MinimumSize = New Size(1, 1)
        UiButton2.Name = "UiButton2"
        UiButton2.Radius = 1
        UiButton2.RadiusSides = Sunny.UI.UICornerRadiusSides.None
        UiButton2.RectColor = Color.FromArgb(CByte(48), CByte(48), CByte(48))
        UiButton2.RectDisableColor = Color.FromArgb(CByte(48), CByte(48), CByte(48))
        UiButton2.RectHoverColor = Color.FromArgb(CByte(64), CByte(64), CByte(64))
        UiButton2.RectPressColor = Color.FromArgb(CByte(80), CByte(80), CByte(80))
        UiButton2.RectSelectedColor = Color.FromArgb(CByte(48), CByte(48), CByte(48))
        UiButton2.Size = New Size(192, 35)
        UiButton2.Style = Sunny.UI.UIStyle.Custom
        UiButton2.TabIndex = 67
        UiButton2.TabStop = False
        UiButton2.Text = "重写（丢弃其他）"
        UiButton2.TipsColor = Color.Gray
        UiButton2.TipsFont = New Font("微软雅黑", 9F)
        ' 
        ' Label7
        ' 
        Label7.Dock = DockStyle.Right
        Label7.Location = New Point(192, 0)
        Label7.Name = "Label7"
        Label7.Size = New Size(10, 80)
        Label7.TabIndex = 71
        ' 
        ' UiButton8
        ' 
        UiButton8.Dock = DockStyle.Right
        UiButton8.FillColor = Color.FromArgb(CByte(48), CByte(48), CByte(48))
        UiButton8.FillColor2 = Color.FromArgb(CByte(48), CByte(48), CByte(48))
        UiButton8.FillDisableColor = Color.FromArgb(CByte(48), CByte(48), CByte(48))
        UiButton8.FillHoverColor = Color.FromArgb(CByte(64), CByte(64), CByte(64))
        UiButton8.FillPressColor = Color.FromArgb(CByte(80), CByte(80), CByte(80))
        UiButton8.FillSelectedColor = Color.FromArgb(CByte(48), CByte(48), CByte(48))
        UiButton8.Font = New Font("微软雅黑", 9.75F)
        UiButton8.ForeColor = Color.FromArgb(CByte(224), CByte(224), CByte(224))
        UiButton8.ForeDisableColor = Color.Gray
        UiButton8.ForeHoverColor = Color.FromArgb(CByte(244), CByte(244), CByte(244))
        UiButton8.ForePressColor = Color.FromArgb(CByte(244), CByte(244), CByte(244))
        UiButton8.ForeSelectedColor = Color.FromArgb(CByte(244), CByte(244), CByte(244))
        UiButton8.Location = New Point(202, 0)
        UiButton8.MinimumSize = New Size(1, 1)
        UiButton8.Name = "UiButton8"
        UiButton8.Radius = 1
        UiButton8.RadiusSides = Sunny.UI.UICornerRadiusSides.None
        UiButton8.RectColor = Color.FromArgb(CByte(48), CByte(48), CByte(48))
        UiButton8.RectDisableColor = Color.FromArgb(CByte(48), CByte(48), CByte(48))
        UiButton8.RectHoverColor = Color.FromArgb(CByte(64), CByte(64), CByte(64))
        UiButton8.RectPressColor = Color.FromArgb(CByte(80), CByte(80), CByte(80))
        UiButton8.RectSelectedColor = Color.FromArgb(CByte(48), CByte(48), CByte(48))
        UiButton8.Size = New Size(60, 80)
        UiButton8.Style = Sunny.UI.UIStyle.Custom
        UiButton8.TabIndex = 70
        UiButton8.TabStop = False
        UiButton8.Text = "剔除" & vbCrLf & "这些"
        UiButton8.TipsColor = Color.Gray
        UiButton8.TipsFont = New Font("微软雅黑", 9F)
        ' 
        ' Panel2
        ' 
        Panel2.Controls.Add(Panel12)
        Panel2.Controls.Add(Label6)
        Panel2.Controls.Add(UiButton3)
        Panel2.Controls.Add(Label3)
        Panel2.Controls.Add(UiButton4)
        Panel2.Controls.Add(Label2)
        Panel2.Dock = DockStyle.Fill
        Panel2.Location = New Point(292, 0)
        Panel2.Name = "Panel2"
        Panel2.Padding = New Padding(15)
        Panel2.Size = New Size(292, 461)
        Panel2.TabIndex = 4
        ' 
        ' Panel12
        ' 
        Panel12.BackColor = Color.FromArgb(CByte(32), CByte(32), CByte(32))
        Panel12.Controls.Add(ListView2)
        Panel12.Dock = DockStyle.Fill
        Panel12.Location = New Point(15, 56)
        Panel12.Margin = New Padding(15, 20, 0, 0)
        Panel12.Name = "Panel12"
        Panel12.Padding = New Padding(10)
        Panel12.Size = New Size(262, 300)
        Panel12.TabIndex = 68
        ' 
        ' ListView2
        ' 
        ListView2.AllowDrop = True
        ListView2.BackColor = Color.FromArgb(CByte(32), CByte(32), CByte(32))
        ListView2.BorderStyle = BorderStyle.None
        ListView2.Columns.AddRange(New ColumnHeader() {ColumnHeader2})
        ListView2.Dock = DockStyle.Left
        ListView2.ForeColor = Color.FromArgb(CByte(224), CByte(224), CByte(224))
        ListView2.FullRowSelect = True
        ListView2.HeaderStyle = ColumnHeaderStyle.None
        ListView2.Location = New Point(10, 10)
        ListView2.Name = "ListView2"
        ListView2.OwnerDraw = True
        ListView2.ShowItemToolTips = True
        ListView2.Size = New Size(242, 280)
        ListView2.StateImageList = ImageList1
        ListView2.TabIndex = 2
        ListView2.UseCompatibleStateImageBehavior = False
        ListView2.View = View.Details
        ' 
        ' Label6
        ' 
        Label6.Dock = DockStyle.Bottom
        Label6.Location = New Point(15, 356)
        Label6.Name = "Label6"
        Label6.Size = New Size(262, 10)
        Label6.TabIndex = 69
        ' 
        ' UiButton3
        ' 
        UiButton3.Dock = DockStyle.Bottom
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
        UiButton3.Location = New Point(15, 366)
        UiButton3.MinimumSize = New Size(1, 1)
        UiButton3.Name = "UiButton3"
        UiButton3.Radius = 10
        UiButton3.RadiusSides = Sunny.UI.UICornerRadiusSides.None
        UiButton3.RectColor = Color.FromArgb(CByte(48), CByte(48), CByte(48))
        UiButton3.RectDisableColor = Color.FromArgb(CByte(48), CByte(48), CByte(48))
        UiButton3.RectHoverColor = Color.FromArgb(CByte(64), CByte(64), CByte(64))
        UiButton3.RectPressColor = Color.FromArgb(CByte(80), CByte(80), CByte(80))
        UiButton3.RectSelectedColor = Color.FromArgb(CByte(48), CByte(48), CByte(48))
        UiButton3.Size = New Size(262, 35)
        UiButton3.Style = Sunny.UI.UIStyle.Custom
        UiButton3.TabIndex = 66
        UiButton3.TabStop = False
        UiButton3.Text = "添加选中（或者双击条目）"
        UiButton3.TipsColor = Color.Gray
        UiButton3.TipsFont = New Font("微软雅黑", 9F)
        ' 
        ' Label3
        ' 
        Label3.Dock = DockStyle.Bottom
        Label3.Location = New Point(15, 401)
        Label3.Name = "Label3"
        Label3.Size = New Size(262, 10)
        Label3.TabIndex = 67
        ' 
        ' UiButton4
        ' 
        UiButton4.Dock = DockStyle.Bottom
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
        UiButton4.Location = New Point(15, 411)
        UiButton4.MinimumSize = New Size(1, 1)
        UiButton4.Name = "UiButton4"
        UiButton4.Radius = 10
        UiButton4.RadiusSides = Sunny.UI.UICornerRadiusSides.None
        UiButton4.RectColor = Color.FromArgb(CByte(48), CByte(48), CByte(48))
        UiButton4.RectDisableColor = Color.FromArgb(CByte(48), CByte(48), CByte(48))
        UiButton4.RectHoverColor = Color.FromArgb(CByte(64), CByte(64), CByte(64))
        UiButton4.RectPressColor = Color.FromArgb(CByte(80), CByte(80), CByte(80))
        UiButton4.RectSelectedColor = Color.FromArgb(CByte(48), CByte(48), CByte(48))
        UiButton4.Size = New Size(262, 35)
        UiButton4.Style = Sunny.UI.UIStyle.Custom
        UiButton4.TabIndex = 65
        UiButton4.TabStop = False
        UiButton4.Text = "添加全部"
        UiButton4.TipsColor = Color.Gray
        UiButton4.TipsFont = New Font("微软雅黑", 9F)
        ' 
        ' Label2
        ' 
        Label2.AutoSize = True
        Label2.Dock = DockStyle.Top
        Label2.Font = New Font("微软雅黑", 12F)
        Label2.Location = New Point(15, 15)
        Label2.Margin = New Padding(20, 20, 20, 0)
        Label2.Name = "Label2"
        Label2.Padding = New Padding(0, 0, 0, 20)
        Label2.Size = New Size(122, 41)
        Label2.TabIndex = 3
        Label2.Text = "添加已有虚拟组"
        ' 
        ' Form编辑虚拟组
        ' 
        AutoScaleDimensions = New SizeF(96F, 96F)
        AutoScaleMode = AutoScaleMode.Dpi
        BackColor = Color.FromArgb(CByte(24), CByte(24), CByte(24))
        ClientSize = New Size(584, 461)
        Controls.Add(Panel2)
        Controls.Add(Panel1)
        Font = New Font("微软雅黑", 9.75F, FontStyle.Regular, GraphicsUnit.Point, CByte(134))
        ForeColor = Color.FromArgb(CByte(224), CByte(224), CByte(224))
        MaximizeBox = False
        MinimizeBox = False
        Name = "Form编辑虚拟组"
        ShowIcon = False
        ShowInTaskbar = False
        StartPosition = FormStartPosition.Manual
        Text = "编辑虚拟组"
        Panel1.ResumeLayout(False)
        Panel1.PerformLayout()
        Panel3.ResumeLayout(False)
        Panel4.ResumeLayout(False)
        Panel2.ResumeLayout(False)
        Panel2.PerformLayout()
        Panel12.ResumeLayout(False)
        ResumeLayout(False)
    End Sub

    Friend WithEvents Panel1 As Panel
    Friend WithEvents Label1 As Label
    Friend WithEvents Panel2 As Panel
    Friend WithEvents Label2 As Label
    Friend WithEvents Label5 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents UiButton3 As Sunny.UI.UIButton
    Friend WithEvents UiButton4 As Sunny.UI.UIButton
    Friend WithEvents Panel12 As Panel
    Friend WithEvents ListView2 As ListView
    Friend WithEvents Label6 As Label
    Friend WithEvents Panel3 As Panel
    Friend WithEvents ListView1 As ListView
    Friend WithEvents ImageList1 As ImageList
    Friend WithEvents UiButton5 As Sunny.UI.UIButton
    Friend WithEvents UiButton9 As Sunny.UI.UIButton
    Friend WithEvents UiButton7 As Sunny.UI.UIButton
    Friend WithEvents UiButton6 As Sunny.UI.UIButton
    Friend WithEvents ColumnHeader1 As ColumnHeader
    Friend WithEvents ColumnHeader2 As ColumnHeader
    Friend WithEvents Panel4 As Panel
    Friend WithEvents UiButton1 As Sunny.UI.UIButton
    Friend WithEvents Label4 As Label
    Friend WithEvents UiButton2 As Sunny.UI.UIButton
    Friend WithEvents Label7 As Label
    Friend WithEvents UiButton8 As Sunny.UI.UIButton
End Class
