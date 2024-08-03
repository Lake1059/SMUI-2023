<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Form数据表
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
        Panel1 = New Panel()
        Panel8 = New Panel()
        LinkLabel1 = New LinkLabel()
        Label61 = New Label()
        UiButton3 = New Sunny.UI.UIButton()
        UiButton2 = New Sunny.UI.UIButton()
        UiButton1 = New Sunny.UI.UIButton()
        UiButton34 = New Sunny.UI.UIButton()
        Label2 = New Label()
        Panel7 = New Panel()
        UiComboBox1 = New Sunny.UI.UIComboBox()
        UiCheckBox6 = New Sunny.UI.UICheckBox()
        Panel6 = New Panel()
        暗黑文本框5 = New 暗黑文本框()
        UiComboBox4 = New Sunny.UI.UIComboBox()
        UiCheckBox5 = New Sunny.UI.UICheckBox()
        Panel5 = New Panel()
        暗黑文本框4 = New 暗黑文本框()
        UiCheckBox4 = New Sunny.UI.UICheckBox()
        Panel4 = New Panel()
        暗黑文本框3 = New 暗黑文本框()
        UiCheckBox3 = New Sunny.UI.UICheckBox()
        Panel3 = New Panel()
        暗黑文本框2 = New 暗黑文本框()
        UiCheckBox2 = New Sunny.UI.UICheckBox()
        Panel2 = New Panel()
        暗黑文本框1 = New 暗黑文本框()
        UiCheckBox1 = New Sunny.UI.UICheckBox()
        Label1 = New Label()
        Panel9 = New Panel()
        Panel1.SuspendLayout()
        Panel8.SuspendLayout()
        Panel7.SuspendLayout()
        Panel6.SuspendLayout()
        Panel5.SuspendLayout()
        Panel4.SuspendLayout()
        Panel3.SuspendLayout()
        Panel2.SuspendLayout()
        SuspendLayout()
        ' 
        ' Panel1
        ' 
        Panel1.BackColor = Color.FromArgb(CByte(32), CByte(32), CByte(32))
        Panel1.Controls.Add(Panel8)
        Panel1.Controls.Add(Label2)
        Panel1.Controls.Add(Panel7)
        Panel1.Controls.Add(Panel6)
        Panel1.Controls.Add(Panel5)
        Panel1.Controls.Add(Panel4)
        Panel1.Controls.Add(Panel3)
        Panel1.Controls.Add(Panel2)
        Panel1.Controls.Add(Label1)
        Panel1.Dock = DockStyle.Left
        Panel1.Location = New Point(0, 0)
        Panel1.Name = "Panel1"
        Panel1.Padding = New Padding(20)
        Panel1.Size = New Size(450, 561)
        Panel1.TabIndex = 0
        ' 
        ' Panel8
        ' 
        Panel8.Controls.Add(LinkLabel1)
        Panel8.Controls.Add(Label61)
        Panel8.Controls.Add(UiButton3)
        Panel8.Controls.Add(UiButton2)
        Panel8.Controls.Add(UiButton1)
        Panel8.Controls.Add(UiButton34)
        Panel8.Dock = DockStyle.Fill
        Panel8.Location = New Point(20, 357)
        Panel8.Name = "Panel8"
        Panel8.Size = New Size(410, 184)
        Panel8.TabIndex = 44
        ' 
        ' LinkLabel1
        ' 
        LinkLabel1.ActiveLinkColor = Color.Lime
        LinkLabel1.AutoSize = True
        LinkLabel1.Dock = DockStyle.Bottom
        LinkLabel1.LinkBehavior = LinkBehavior.HoverUnderline
        LinkLabel1.LinkColor = Color.FromArgb(CByte(255), CByte(128), CByte(0))
        LinkLabel1.Location = New Point(0, 165)
        LinkLabel1.Name = "LinkLabel1"
        LinkLabel1.Size = New Size(61, 19)
        LinkLabel1.TabIndex = 45
        LinkLabel1.TabStop = True
        LinkLabel1.Text = "立即支持"
        ' 
        ' Label61
        ' 
        Label61.Anchor = AnchorStyles.Top Or AnchorStyles.Bottom Or AnchorStyles.Left Or AnchorStyles.Right
        Label61.Font = New Font("微软雅黑", 9.75F, FontStyle.Regular, GraphicsUnit.Point, CByte(134))
        Label61.Location = New Point(0, 85)
        Label61.Margin = New Padding(0, 10, 0, 0)
        Label61.Name = "Label61"
        Label61.Size = New Size(410, 99)
        Label61.TabIndex = 58
        Label61.Text = "数据表由开发者和用户们维护，请考虑支持他们的工作" & vbCrLf & "如果你也想出一份力，在欢迎页上查看协作项目"
        Label61.TextAlign = ContentAlignment.MiddleCenter
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
        UiButton3.Location = New Point(280, 45)
        UiButton3.Margin = New Padding(10, 10, 0, 0)
        UiButton3.MinimumSize = New Size(1, 1)
        UiButton3.Name = "UiButton3"
        UiButton3.Radius = 10
        UiButton3.RadiusSides = Sunny.UI.UICornerRadiusSides.None
        UiButton3.RectColor = Color.FromArgb(CByte(48), CByte(48), CByte(48))
        UiButton3.RectDisableColor = Color.FromArgb(CByte(48), CByte(48), CByte(48))
        UiButton3.RectHoverColor = Color.FromArgb(CByte(64), CByte(64), CByte(64))
        UiButton3.RectPressColor = Color.FromArgb(CByte(80), CByte(80), CByte(80))
        UiButton3.RectSelectedColor = Color.FromArgb(CByte(48), CByte(48), CByte(48))
        UiButton3.Size = New Size(130, 30)
        UiButton3.Style = Sunny.UI.UIStyle.Custom
        UiButton3.TabIndex = 40
        UiButton3.TabStop = False
        UiButton3.Text = "查看所有数据"
        UiButton3.TipsColor = Color.Gray
        UiButton3.TipsFont = New Font("微软雅黑", 9F)
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
        UiButton2.Location = New Point(140, 45)
        UiButton2.Margin = New Padding(10, 10, 0, 0)
        UiButton2.MinimumSize = New Size(1, 1)
        UiButton2.Name = "UiButton2"
        UiButton2.Radius = 10
        UiButton2.RadiusSides = Sunny.UI.UICornerRadiusSides.None
        UiButton2.RectColor = Color.FromArgb(CByte(48), CByte(48), CByte(48))
        UiButton2.RectDisableColor = Color.FromArgb(CByte(48), CByte(48), CByte(48))
        UiButton2.RectHoverColor = Color.FromArgb(CByte(64), CByte(64), CByte(64))
        UiButton2.RectPressColor = Color.FromArgb(CByte(80), CByte(80), CByte(80))
        UiButton2.RectSelectedColor = Color.FromArgb(CByte(48), CByte(48), CByte(48))
        UiButton2.Size = New Size(130, 30)
        UiButton2.Style = Sunny.UI.UIStyle.Custom
        UiButton2.TabIndex = 39
        UiButton2.TabStop = False
        UiButton2.Text = "清空设定"
        UiButton2.TipsColor = Color.Gray
        UiButton2.TipsFont = New Font("微软雅黑", 9F)
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
        UiButton1.Location = New Point(0, 45)
        UiButton1.Margin = New Padding(10, 10, 0, 0)
        UiButton1.MinimumSize = New Size(1, 1)
        UiButton1.Name = "UiButton1"
        UiButton1.Radius = 10
        UiButton1.RadiusSides = Sunny.UI.UICornerRadiusSides.None
        UiButton1.RectColor = Color.FromArgb(CByte(48), CByte(48), CByte(48))
        UiButton1.RectDisableColor = Color.FromArgb(CByte(48), CByte(48), CByte(48))
        UiButton1.RectHoverColor = Color.FromArgb(CByte(64), CByte(64), CByte(64))
        UiButton1.RectPressColor = Color.FromArgb(CByte(80), CByte(80), CByte(80))
        UiButton1.RectSelectedColor = Color.FromArgb(CByte(48), CByte(48), CByte(48))
        UiButton1.Size = New Size(130, 30)
        UiButton1.Style = Sunny.UI.UIStyle.Custom
        UiButton1.TabIndex = 38
        UiButton1.TabStop = False
        UiButton1.Text = "更新数据表"
        UiButton1.TipsColor = Color.Gray
        UiButton1.TipsFont = New Font("微软雅黑", 9F)
        ' 
        ' UiButton34
        ' 
        UiButton34.Dock = DockStyle.Top
        UiButton34.FillColor = Color.FromArgb(CByte(48), CByte(48), CByte(48))
        UiButton34.FillColor2 = Color.FromArgb(CByte(48), CByte(48), CByte(48))
        UiButton34.FillDisableColor = Color.FromArgb(CByte(48), CByte(48), CByte(48))
        UiButton34.FillHoverColor = Color.FromArgb(CByte(64), CByte(64), CByte(64))
        UiButton34.FillPressColor = Color.FromArgb(CByte(80), CByte(80), CByte(80))
        UiButton34.FillSelectedColor = Color.FromArgb(CByte(48), CByte(48), CByte(48))
        UiButton34.Font = New Font("微软雅黑", 9.75F)
        UiButton34.ForeColor = Color.FromArgb(CByte(224), CByte(224), CByte(224))
        UiButton34.ForeDisableColor = Color.Gray
        UiButton34.ForeHoverColor = Color.FromArgb(CByte(244), CByte(244), CByte(244))
        UiButton34.ForePressColor = Color.FromArgb(CByte(244), CByte(244), CByte(244))
        UiButton34.ForeSelectedColor = Color.FromArgb(CByte(244), CByte(244), CByte(244))
        UiButton34.Location = New Point(0, 0)
        UiButton34.Margin = New Padding(0)
        UiButton34.MinimumSize = New Size(1, 1)
        UiButton34.Name = "UiButton34"
        UiButton34.Radius = 10
        UiButton34.RadiusSides = Sunny.UI.UICornerRadiusSides.None
        UiButton34.RectColor = Color.FromArgb(CByte(48), CByte(48), CByte(48))
        UiButton34.RectDisableColor = Color.FromArgb(CByte(48), CByte(48), CByte(48))
        UiButton34.RectHoverColor = Color.FromArgb(CByte(64), CByte(64), CByte(64))
        UiButton34.RectPressColor = Color.FromArgb(CByte(80), CByte(80), CByte(80))
        UiButton34.RectSelectedColor = Color.FromArgb(CByte(48), CByte(48), CByte(48))
        UiButton34.Size = New Size(410, 35)
        UiButton34.Style = Sunny.UI.UIStyle.Custom
        UiButton34.TabIndex = 37
        UiButton34.TabStop = False
        UiButton34.Text = "开始搜索数据表"
        UiButton34.TipsColor = Color.Gray
        UiButton34.TipsFont = New Font("微软雅黑", 9F)
        ' 
        ' Label2
        ' 
        Label2.AutoSize = True
        Label2.Dock = DockStyle.Top
        Label2.Font = New Font("微软雅黑", 12F)
        Label2.Location = New Point(20, 301)
        Label2.Margin = New Padding(20, 20, 20, 0)
        Label2.Name = "Label2"
        Label2.Padding = New Padding(0, 15, 0, 20)
        Label2.Size = New Size(74, 56)
        Label2.TabIndex = 43
        Label2.Text = "操作选项"
        ' 
        ' Panel7
        ' 
        Panel7.Controls.Add(UiComboBox1)
        Panel7.Controls.Add(UiCheckBox6)
        Panel7.Dock = DockStyle.Top
        Panel7.Location = New Point(20, 261)
        Panel7.Name = "Panel7"
        Panel7.Padding = New Padding(0, 5, 0, 5)
        Panel7.Size = New Size(410, 40)
        Panel7.TabIndex = 40
        ' 
        ' UiComboBox1
        ' 
        UiComboBox1.DataSource = Nothing
        UiComboBox1.Dock = DockStyle.Fill
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
        UiComboBox1.Items.AddRange(New Object() {"框架", "扩展", "事件", "功能", "汉化", "材质", "视觉", "地图", "农场", "人物", "物品", "商店", "动物"})
        UiComboBox1.ItemSelectBackColor = Color.DimGray
        UiComboBox1.ItemSelectForeColor = Color.FromArgb(CByte(224), CByte(224), CByte(224))
        UiComboBox1.Location = New Point(150, 5)
        UiComboBox1.Margin = New Padding(20, 0, 0, 0)
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
        UiComboBox1.ScrollBarColor = Color.DimGray
        UiComboBox1.ScrollBarStyleInherited = False
        UiComboBox1.Size = New Size(260, 30)
        UiComboBox1.Style = Sunny.UI.UIStyle.Custom
        UiComboBox1.SymbolSize = 24
        UiComboBox1.TabIndex = 24
        UiComboBox1.TabStop = False
        UiComboBox1.TextAlignment = ContentAlignment.MiddleLeft
        UiComboBox1.TrimFilter = True
        UiComboBox1.Watermark = ""
        ' 
        ' UiCheckBox6
        ' 
        UiCheckBox6.CheckBoxSize = 20
        UiCheckBox6.Dock = DockStyle.Left
        UiCheckBox6.Font = New Font("微软雅黑", 9.75F, FontStyle.Regular, GraphicsUnit.Point, CByte(134))
        UiCheckBox6.ForeColor = SystemColors.ScrollBar
        UiCheckBox6.Location = New Point(0, 5)
        UiCheckBox6.Margin = New Padding(20, 20, 20, 0)
        UiCheckBox6.MinimumSize = New Size(1, 1)
        UiCheckBox6.Name = "UiCheckBox6"
        UiCheckBox6.Size = New Size(150, 30)
        UiCheckBox6.Style = Sunny.UI.UIStyle.Custom
        UiCheckBox6.TabIndex = 1
        UiCheckBox6.Text = "指定类别"
        ' 
        ' Panel6
        ' 
        Panel6.Controls.Add(暗黑文本框5)
        Panel6.Controls.Add(UiComboBox4)
        Panel6.Controls.Add(UiCheckBox5)
        Panel6.Dock = DockStyle.Top
        Panel6.Location = New Point(20, 221)
        Panel6.Name = "Panel6"
        Panel6.Padding = New Padding(0, 5, 0, 5)
        Panel6.Size = New Size(410, 40)
        Panel6.TabIndex = 39
        ' 
        ' 暗黑文本框5
        ' 
        暗黑文本框5.BackColor = Color.FromArgb(CByte(48), CByte(48), CByte(48))
        暗黑文本框5.Dock = DockStyle.Fill
        暗黑文本框5.ForeColor = Color.FromArgb(CByte(224), CByte(224), CByte(224))
        暗黑文本框5.Location = New Point(264, 5)
        暗黑文本框5.Name = "暗黑文本框5"
        暗黑文本框5.Padding = New Padding(5, 6, 5, 0)
        暗黑文本框5.PasswordChar = vbNullChar
        暗黑文本框5.PlaceholderText = "先选类型"
        暗黑文本框5.Size = New Size(146, 30)
        暗黑文本框5.TabIndex = 25
        ' 
        ' UiComboBox4
        ' 
        UiComboBox4.DataSource = Nothing
        UiComboBox4.Dock = DockStyle.Left
        UiComboBox4.DropDownStyle = Sunny.UI.UIDropDownStyle.DropDownList
        UiComboBox4.FillColor = Color.FromArgb(CByte(48), CByte(48), CByte(48))
        UiComboBox4.FillColor2 = Color.FromArgb(CByte(48), CByte(48), CByte(48))
        UiComboBox4.FillDisableColor = Color.FromArgb(CByte(48), CByte(48), CByte(48))
        UiComboBox4.Font = New Font("微软雅黑", 9.75F)
        UiComboBox4.ForeColor = Color.FromArgb(CByte(224), CByte(224), CByte(224))
        UiComboBox4.ForeDisableColor = Color.Gray
        UiComboBox4.ItemFillColor = Color.FromArgb(CByte(48), CByte(48), CByte(48))
        UiComboBox4.ItemForeColor = Color.FromArgb(CByte(224), CByte(224), CByte(224))
        UiComboBox4.ItemHeight = 30
        UiComboBox4.ItemHoverColor = Color.FromArgb(CByte(64), CByte(64), CByte(64))
        UiComboBox4.ItemRectColor = Color.FromArgb(CByte(48), CByte(48), CByte(48))
        UiComboBox4.Items.AddRange(New Object() {"NEXUS", "ModDrop", "GitHub"})
        UiComboBox4.ItemSelectBackColor = Color.DimGray
        UiComboBox4.ItemSelectForeColor = Color.FromArgb(CByte(224), CByte(224), CByte(224))
        UiComboBox4.Location = New Point(150, 5)
        UiComboBox4.Margin = New Padding(20, 0, 0, 0)
        UiComboBox4.MaxDropDownItems = 10
        UiComboBox4.MinimumSize = New Size(63, 0)
        UiComboBox4.Name = "UiComboBox4"
        UiComboBox4.Padding = New Padding(0, 0, 30, 2)
        UiComboBox4.Radius = 0
        UiComboBox4.RadiusSides = Sunny.UI.UICornerRadiusSides.None
        UiComboBox4.RectColor = Color.Silver
        UiComboBox4.RectDisableColor = Color.Silver
        UiComboBox4.RectSides = ToolStripStatusLabelBorderSides.None
        UiComboBox4.Size = New Size(114, 30)
        UiComboBox4.Style = Sunny.UI.UIStyle.Custom
        UiComboBox4.SymbolSize = 24
        UiComboBox4.TabIndex = 24
        UiComboBox4.TabStop = False
        UiComboBox4.TextAlignment = ContentAlignment.MiddleLeft
        UiComboBox4.TrimFilter = True
        UiComboBox4.Watermark = ""
        ' 
        ' UiCheckBox5
        ' 
        UiCheckBox5.CheckBoxSize = 20
        UiCheckBox5.Dock = DockStyle.Left
        UiCheckBox5.Font = New Font("微软雅黑", 9.75F, FontStyle.Regular, GraphicsUnit.Point, CByte(134))
        UiCheckBox5.ForeColor = SystemColors.ScrollBar
        UiCheckBox5.Location = New Point(0, 5)
        UiCheckBox5.Margin = New Padding(20, 20, 20, 0)
        UiCheckBox5.MinimumSize = New Size(1, 1)
        UiCheckBox5.Name = "UiCheckBox5"
        UiCheckBox5.Size = New Size(150, 30)
        UiCheckBox5.Style = Sunny.UI.UIStyle.Custom
        UiCheckBox5.TabIndex = 1
        UiCheckBox5.Text = "查找更新键"
        ' 
        ' Panel5
        ' 
        Panel5.Controls.Add(暗黑文本框4)
        Panel5.Controls.Add(UiCheckBox4)
        Panel5.Dock = DockStyle.Top
        Panel5.Location = New Point(20, 181)
        Panel5.Name = "Panel5"
        Panel5.Padding = New Padding(0, 5, 0, 5)
        Panel5.Size = New Size(410, 40)
        Panel5.TabIndex = 38
        ' 
        ' 暗黑文本框4
        ' 
        暗黑文本框4.BackColor = Color.FromArgb(CByte(48), CByte(48), CByte(48))
        暗黑文本框4.Dock = DockStyle.Fill
        暗黑文本框4.ForeColor = Color.FromArgb(CByte(224), CByte(224), CByte(224))
        暗黑文本框4.Location = New Point(150, 5)
        暗黑文本框4.Name = "暗黑文本框4"
        暗黑文本框4.Padding = New Padding(5, 6, 5, 0)
        暗黑文本框4.PasswordChar = vbNullChar
        暗黑文本框4.PlaceholderText = "保持简短，越长越难搜到"
        暗黑文本框4.Size = New Size(260, 30)
        暗黑文本框4.TabIndex = 3
        ' 
        ' UiCheckBox4
        ' 
        UiCheckBox4.CheckBoxSize = 20
        UiCheckBox4.Dock = DockStyle.Left
        UiCheckBox4.Font = New Font("微软雅黑", 9.75F, FontStyle.Regular, GraphicsUnit.Point, CByte(134))
        UiCheckBox4.ForeColor = SystemColors.ScrollBar
        UiCheckBox4.Location = New Point(0, 5)
        UiCheckBox4.Margin = New Padding(20, 20, 20, 0)
        UiCheckBox4.MinimumSize = New Size(1, 1)
        UiCheckBox4.Name = "UiCheckBox4"
        UiCheckBox4.Size = New Size(150, 30)
        UiCheckBox4.Style = Sunny.UI.UIStyle.Custom
        UiCheckBox4.TabIndex = 1
        UiCheckBox4.Text = "查找描述词"
        ' 
        ' Panel4
        ' 
        Panel4.Controls.Add(暗黑文本框3)
        Panel4.Controls.Add(UiCheckBox3)
        Panel4.Dock = DockStyle.Top
        Panel4.Location = New Point(20, 141)
        Panel4.Name = "Panel4"
        Panel4.Padding = New Padding(0, 5, 0, 5)
        Panel4.Size = New Size(410, 40)
        Panel4.TabIndex = 5
        ' 
        ' 暗黑文本框3
        ' 
        暗黑文本框3.BackColor = Color.FromArgb(CByte(48), CByte(48), CByte(48))
        暗黑文本框3.Dock = DockStyle.Fill
        暗黑文本框3.ForeColor = Color.FromArgb(CByte(224), CByte(224), CByte(224))
        暗黑文本框3.Location = New Point(150, 5)
        暗黑文本框3.Name = "暗黑文本框3"
        暗黑文本框3.Padding = New Padding(5, 6, 5, 0)
        暗黑文本框3.PasswordChar = vbNullChar
        暗黑文本框3.PlaceholderText = "仅限一个"
        暗黑文本框3.Size = New Size(260, 30)
        暗黑文本框3.TabIndex = 3
        ' 
        ' UiCheckBox3
        ' 
        UiCheckBox3.CheckBoxSize = 20
        UiCheckBox3.Dock = DockStyle.Left
        UiCheckBox3.Font = New Font("微软雅黑", 9.75F, FontStyle.Regular, GraphicsUnit.Point, CByte(134))
        UiCheckBox3.ForeColor = SystemColors.ScrollBar
        UiCheckBox3.Location = New Point(0, 5)
        UiCheckBox3.Margin = New Padding(20, 20, 20, 0)
        UiCheckBox3.MinimumSize = New Size(1, 1)
        UiCheckBox3.Name = "UiCheckBox3"
        UiCheckBox3.Size = New Size(150, 30)
        UiCheckBox3.Style = Sunny.UI.UIStyle.Custom
        UiCheckBox3.TabIndex = 1
        UiCheckBox3.Text = "查找 UniqueID"
        ' 
        ' Panel3
        ' 
        Panel3.Controls.Add(暗黑文本框2)
        Panel3.Controls.Add(UiCheckBox2)
        Panel3.Dock = DockStyle.Top
        Panel3.Location = New Point(20, 101)
        Panel3.Name = "Panel3"
        Panel3.Padding = New Padding(0, 5, 0, 5)
        Panel3.Size = New Size(410, 40)
        Panel3.TabIndex = 4
        ' 
        ' 暗黑文本框2
        ' 
        暗黑文本框2.BackColor = Color.FromArgb(CByte(48), CByte(48), CByte(48))
        暗黑文本框2.Dock = DockStyle.Fill
        暗黑文本框2.ForeColor = Color.FromArgb(CByte(224), CByte(224), CByte(224))
        暗黑文本框2.Location = New Point(150, 5)
        暗黑文本框2.Name = "暗黑文本框2"
        暗黑文本框2.Padding = New Padding(5, 6, 5, 0)
        暗黑文本框2.PasswordChar = vbNullChar
        暗黑文本框2.PlaceholderText = "作者"
        暗黑文本框2.Size = New Size(260, 30)
        暗黑文本框2.TabIndex = 3
        ' 
        ' UiCheckBox2
        ' 
        UiCheckBox2.CheckBoxSize = 20
        UiCheckBox2.Dock = DockStyle.Left
        UiCheckBox2.Font = New Font("微软雅黑", 9.75F, FontStyle.Regular, GraphicsUnit.Point, CByte(134))
        UiCheckBox2.ForeColor = SystemColors.ScrollBar
        UiCheckBox2.Location = New Point(0, 5)
        UiCheckBox2.Margin = New Padding(20, 20, 20, 0)
        UiCheckBox2.MinimumSize = New Size(1, 1)
        UiCheckBox2.Name = "UiCheckBox2"
        UiCheckBox2.Size = New Size(150, 30)
        UiCheckBox2.Style = Sunny.UI.UIStyle.Custom
        UiCheckBox2.TabIndex = 1
        UiCheckBox2.Text = "查找作者"
        ' 
        ' Panel2
        ' 
        Panel2.Controls.Add(暗黑文本框1)
        Panel2.Controls.Add(UiCheckBox1)
        Panel2.Dock = DockStyle.Top
        Panel2.Location = New Point(20, 61)
        Panel2.Name = "Panel2"
        Panel2.Padding = New Padding(0, 5, 0, 5)
        Panel2.Size = New Size(410, 40)
        Panel2.TabIndex = 3
        ' 
        ' 暗黑文本框1
        ' 
        暗黑文本框1.BackColor = Color.FromArgb(CByte(48), CByte(48), CByte(48))
        暗黑文本框1.Dock = DockStyle.Fill
        暗黑文本框1.ForeColor = Color.FromArgb(CByte(224), CByte(224), CByte(224))
        暗黑文本框1.Location = New Point(150, 5)
        暗黑文本框1.Name = "暗黑文本框1"
        暗黑文本框1.Padding = New Padding(5, 6, 5, 0)
        暗黑文本框1.PasswordChar = vbNullChar
        暗黑文本框1.PlaceholderText = "英文名称"
        暗黑文本框1.Size = New Size(260, 30)
        暗黑文本框1.TabIndex = 2
        ' 
        ' UiCheckBox1
        ' 
        UiCheckBox1.CheckBoxSize = 20
        UiCheckBox1.Dock = DockStyle.Left
        UiCheckBox1.Font = New Font("微软雅黑", 9.75F, FontStyle.Regular, GraphicsUnit.Point, CByte(134))
        UiCheckBox1.ForeColor = SystemColors.ScrollBar
        UiCheckBox1.Location = New Point(0, 5)
        UiCheckBox1.Margin = New Padding(20, 20, 20, 0)
        UiCheckBox1.MinimumSize = New Size(1, 1)
        UiCheckBox1.Name = "UiCheckBox1"
        UiCheckBox1.Size = New Size(150, 30)
        UiCheckBox1.Style = Sunny.UI.UIStyle.Custom
        UiCheckBox1.TabIndex = 1
        UiCheckBox1.Text = "查找模组名称"
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
        Label1.Size = New Size(218, 41)
        Label1.TabIndex = 2
        Label1.Text = "检索由用户群体建立的数据集"
        ' 
        ' Panel9
        ' 
        Panel9.AutoScroll = True
        Panel9.Dock = DockStyle.Fill
        Panel9.Location = New Point(450, 0)
        Panel9.Name = "Panel9"
        Panel9.Padding = New Padding(20)
        Panel9.Size = New Size(534, 561)
        Panel9.TabIndex = 1
        ' 
        ' Form数据表
        ' 
        AutoScaleDimensions = New SizeF(96F, 96F)
        AutoScaleMode = AutoScaleMode.Dpi
        BackColor = Color.FromArgb(CByte(24), CByte(24), CByte(24))
        ClientSize = New Size(984, 561)
        Controls.Add(Panel9)
        Controls.Add(Panel1)
        Font = New Font("微软雅黑", 9.75F, FontStyle.Regular, GraphicsUnit.Point, CByte(134))
        ForeColor = Color.FromArgb(CByte(224), CByte(224), CByte(224))
        MaximizeBox = False
        MinimizeBox = False
        MinimumSize = New Size(1000, 600)
        Name = "Form数据表"
        ShowIcon = False
        ShowInTaskbar = False
        StartPosition = FormStartPosition.Manual
        Text = "数据表"
        Panel1.ResumeLayout(False)
        Panel1.PerformLayout()
        Panel8.ResumeLayout(False)
        Panel8.PerformLayout()
        Panel7.ResumeLayout(False)
        Panel6.ResumeLayout(False)
        Panel5.ResumeLayout(False)
        Panel4.ResumeLayout(False)
        Panel3.ResumeLayout(False)
        Panel2.ResumeLayout(False)
        ResumeLayout(False)
    End Sub

    Friend WithEvents Panel1 As Panel
    Friend WithEvents Label1 As Label
    Friend WithEvents Panel2 As Panel
    Friend WithEvents UiCheckBox1 As Sunny.UI.UICheckBox
    Friend WithEvents Panel4 As Panel
    Friend WithEvents UiCheckBox3 As Sunny.UI.UICheckBox
    Friend WithEvents Panel3 As Panel
    Friend WithEvents UiCheckBox2 As Sunny.UI.UICheckBox
    Friend WithEvents Panel5 As Panel
    Friend WithEvents UiCheckBox4 As Sunny.UI.UICheckBox
    Friend WithEvents UiButton34 As Sunny.UI.UIButton
    Friend WithEvents Panel6 As Panel
    Friend WithEvents UiCheckBox5 As Sunny.UI.UICheckBox
    Friend WithEvents Panel7 As Panel
    Friend WithEvents UiComboBox1 As Sunny.UI.UIComboBox
    Friend WithEvents UiCheckBox6 As Sunny.UI.UICheckBox
    Friend WithEvents Label2 As Label
    Friend WithEvents Panel8 As Panel
    Friend WithEvents UiButton3 As Sunny.UI.UIButton
    Friend WithEvents UiButton2 As Sunny.UI.UIButton
    Friend WithEvents UiButton1 As Sunny.UI.UIButton
    Friend WithEvents Label61 As Label
    Friend WithEvents Panel9 As Panel
    Friend WithEvents UiComboBox4 As Sunny.UI.UIComboBox
    Friend WithEvents 暗黑文本框5 As 暗黑文本框
    Friend WithEvents 暗黑文本框4 As 暗黑文本框
    Friend WithEvents 暗黑文本框3 As 暗黑文本框
    Friend WithEvents 暗黑文本框2 As 暗黑文本框
    Friend WithEvents 暗黑文本框1 As 暗黑文本框
    Friend WithEvents LinkLabel1 As LinkLabel
End Class
