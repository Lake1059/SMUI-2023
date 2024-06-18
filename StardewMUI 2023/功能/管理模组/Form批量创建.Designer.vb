<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Form批量创建
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
        UiRadioButton2 = New Sunny.UI.UIRadioButton()
        UiRadioButton1 = New Sunny.UI.UIRadioButton()
        UiButton1 = New Sunny.UI.UIButton()
        暗黑文本框1 = New 暗黑文本框()
        UiComboBox1 = New Sunny.UI.UIComboBox()
        ListView1 = New ListView()
        ColumnHeader1 = New ColumnHeader()
        ColumnHeader2 = New ColumnHeader()
        ColumnHeader3 = New ColumnHeader()
        ImageList1 = New ImageList(components)
        Label2 = New Label()
        Label3 = New Label()
        Label1 = New Label()
        Panel1 = New Panel()
        Panel1.SuspendLayout()
        SuspendLayout()
        ' 
        ' UiRadioButton2
        ' 
        UiRadioButton2.Font = New Font("微软雅黑", 9.75F)
        UiRadioButton2.ForeColor = Color.FromArgb(CByte(224), CByte(224), CByte(224))
        UiRadioButton2.Location = New Point(20, 83)
        UiRadioButton2.Margin = New Padding(20, 10, 20, 0)
        UiRadioButton2.MinimumSize = New Size(1, 1)
        UiRadioButton2.Name = "UiRadioButton2"
        UiRadioButton2.RadioButtonSize = 20
        UiRadioButton2.Size = New Size(253, 22)
        UiRadioButton2.Style = Sunny.UI.UIStyle.Custom
        UiRadioButton2.TabIndex = 2
        UiRadioButton2.Text = "选择的多个文件夹作为单独一个模组项"
        ' 
        ' UiRadioButton1
        ' 
        UiRadioButton1.Checked = True
        UiRadioButton1.Font = New Font("微软雅黑", 9.75F)
        UiRadioButton1.ForeColor = Color.FromArgb(CByte(224), CByte(224), CByte(224))
        UiRadioButton1.Location = New Point(20, 51)
        UiRadioButton1.Margin = New Padding(20, 10, 20, 0)
        UiRadioButton1.MinimumSize = New Size(1, 1)
        UiRadioButton1.Name = "UiRadioButton1"
        UiRadioButton1.RadioButtonSize = 20
        UiRadioButton1.Size = New Size(266, 22)
        UiRadioButton1.Style = Sunny.UI.UIStyle.Custom
        UiRadioButton1.TabIndex = 1
        UiRadioButton1.Text = "选择的每个文件夹作为一个独立的模组项"
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
        UiButton1.Location = New Point(479, 20)
        UiButton1.Margin = New Padding(20, 20, 20, 0)
        UiButton1.MinimumSize = New Size(1, 1)
        UiButton1.Name = "UiButton1"
        UiButton1.Radius = 1
        UiButton1.RadiusSides = Sunny.UI.UICornerRadiusSides.None
        UiButton1.RectColor = Color.FromArgb(CByte(48), CByte(48), CByte(48))
        UiButton1.RectDisableColor = Color.FromArgb(CByte(48), CByte(48), CByte(48))
        UiButton1.RectHoverColor = Color.FromArgb(CByte(64), CByte(64), CByte(64))
        UiButton1.RectPressColor = Color.FromArgb(CByte(80), CByte(80), CByte(80))
        UiButton1.RectSelectedColor = Color.FromArgb(CByte(48), CByte(48), CByte(48))
        UiButton1.Size = New Size(135, 53)
        UiButton1.Style = Sunny.UI.UIStyle.Custom
        UiButton1.TabIndex = 39
        UiButton1.TabStop = False
        UiButton1.Text = "开始批量创建"
        UiButton1.TipsColor = Color.Gray
        UiButton1.TipsFont = New Font("微软雅黑", 9F)
        ' 
        ' 暗黑文本框1
        ' 
        暗黑文本框1.Anchor = AnchorStyles.Top Or AnchorStyles.Left Or AnchorStyles.Right
        暗黑文本框1.BackColor = Color.FromArgb(CByte(48), CByte(48), CByte(48))
        暗黑文本框1.ForeColor = Color.FromArgb(CByte(224), CByte(224), CByte(224))
        暗黑文本框1.Location = New Point(260, 154)
        暗黑文本框1.Margin = New Padding(10, 0, 0, 0)
        暗黑文本框1.Name = "暗黑文本框1"
        暗黑文本框1.Padding = New Padding(7, 6, 7, 0)
        暗黑文本框1.PasswordChar = vbNullChar
        暗黑文本框1.PlaceholderText = ""
        暗黑文本框1.Size = New Size(354, 30)
        暗黑文本框1.TabIndex = 38
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
        UiComboBox1.Location = New Point(20, 154)
        UiComboBox1.Margin = New Padding(20, 10, 0, 0)
        UiComboBox1.MaxDropDownItems = 10
        UiComboBox1.MinimumSize = New Size(63, 0)
        UiComboBox1.Name = "UiComboBox1"
        UiComboBox1.Padding = New Padding(0, 0, 30, 2)
        UiComboBox1.Radius = 0
        UiComboBox1.RadiusSides = Sunny.UI.UICornerRadiusSides.None
        UiComboBox1.RectColor = Color.Silver
        UiComboBox1.RectDisableColor = Color.Silver
        UiComboBox1.RectSides = ToolStripStatusLabelBorderSides.None
        UiComboBox1.Size = New Size(230, 30)
        UiComboBox1.Style = Sunny.UI.UIStyle.Custom
        UiComboBox1.SymbolSize = 24
        UiComboBox1.TabIndex = 24
        UiComboBox1.TabStop = False
        UiComboBox1.TextAlignment = ContentAlignment.MiddleLeft
        UiComboBox1.TrimFilter = True
        UiComboBox1.Watermark = ""
        ' 
        ' ListView1
        ' 
        ListView1.AllowDrop = True
        ListView1.BackColor = Color.FromArgb(CByte(32), CByte(32), CByte(32))
        ListView1.BorderStyle = BorderStyle.None
        ListView1.Columns.AddRange(New ColumnHeader() {ColumnHeader1, ColumnHeader2, ColumnHeader3})
        ListView1.Dock = DockStyle.Fill
        ListView1.ForeColor = Color.FromArgb(CByte(224), CByte(224), CByte(224))
        ListView1.FullRowSelect = True
        ListView1.HeaderStyle = ColumnHeaderStyle.None
        ListView1.Location = New Point(10, 10)
        ListView1.Margin = New Padding(20, 20, 20, 10)
        ListView1.Name = "ListView1"
        ListView1.OwnerDraw = True
        ListView1.ShowItemToolTips = True
        ListView1.Size = New Size(575, 328)
        ListView1.StateImageList = ImageList1
        ListView1.TabIndex = 3
        ListView1.UseCompatibleStateImageBehavior = False
        ListView1.View = View.Details
        ' 
        ' ImageList1
        ' 
        ImageList1.ColorDepth = ColorDepth.Depth32Bit
        ImageList1.ImageSize = New Size(1, 25)
        ImageList1.TransparentColor = Color.Transparent
        ' 
        ' Label2
        ' 
        Label2.AutoSize = True
        Label2.Font = New Font("微软雅黑", 12F)
        Label2.Location = New Point(20, 20)
        Label2.Margin = New Padding(20, 20, 0, 0)
        Label2.Name = "Label2"
        Label2.Size = New Size(186, 21)
        Label2.TabIndex = 40
        Label2.Text = "选择批量创建的操作类型"
        ' 
        ' Label3
        ' 
        Label3.AutoSize = True
        Label3.Location = New Point(20, 125)
        Label3.Margin = New Padding(20, 20, 0, 0)
        Label3.Name = "Label3"
        Label3.Size = New Size(61, 19)
        Label3.TabIndex = 41
        Label3.Text = "目标分类"
        ' 
        ' Label1
        ' 
        Label1.AutoSize = True
        Label1.Location = New Point(260, 125)
        Label1.Margin = New Padding(20, 20, 0, 0)
        Label1.Name = "Label1"
        Label1.Size = New Size(204, 19)
        Label1.TabIndex = 42
        Label1.Text = "多个文件夹作为一个模组项的名称"
        ' 
        ' Panel1
        ' 
        Panel1.Anchor = AnchorStyles.Top Or AnchorStyles.Bottom Or AnchorStyles.Left Or AnchorStyles.Right
        Panel1.BackColor = Color.FromArgb(CByte(32), CByte(32), CByte(32))
        Panel1.Controls.Add(ListView1)
        Panel1.Location = New Point(20, 194)
        Panel1.Margin = New Padding(10)
        Panel1.Name = "Panel1"
        Panel1.Padding = New Padding(10)
        Panel1.Size = New Size(595, 348)
        Panel1.TabIndex = 43
        ' 
        ' Form批量创建
        ' 
        AutoScaleDimensions = New SizeF(96F, 96F)
        AutoScaleMode = AutoScaleMode.Dpi
        BackColor = Color.FromArgb(CByte(24), CByte(24), CByte(24))
        ClientSize = New Size(634, 561)
        Controls.Add(Panel1)
        Controls.Add(Label1)
        Controls.Add(暗黑文本框1)
        Controls.Add(Label3)
        Controls.Add(UiComboBox1)
        Controls.Add(Label2)
        Controls.Add(UiButton1)
        Controls.Add(UiRadioButton2)
        Controls.Add(UiRadioButton1)
        Font = New Font("微软雅黑", 9.75F)
        ForeColor = Color.FromArgb(CByte(224), CByte(224), CByte(224))
        MaximizeBox = False
        MinimizeBox = False
        MinimumSize = New Size(650, 600)
        Name = "Form批量创建"
        ShowIcon = False
        ShowInTaskbar = False
        StartPosition = FormStartPosition.Manual
        Text = "批量创建"
        Panel1.ResumeLayout(False)
        ResumeLayout(False)
        PerformLayout()
    End Sub
    Friend WithEvents UiRadioButton1 As Sunny.UI.UIRadioButton
    Friend WithEvents UiRadioButton2 As Sunny.UI.UIRadioButton
    Friend WithEvents ListView1 As ListView
    Friend WithEvents ColumnHeader1 As ColumnHeader
    Friend WithEvents ColumnHeader2 As ColumnHeader
    Friend WithEvents UiButton1 As Sunny.UI.UIButton
    Friend WithEvents UiComboBox1 As Sunny.UI.UIComboBox
    Friend WithEvents 暗黑文本框1 As 暗黑文本框
    Friend WithEvents Label2 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents Label1 As Label
    Friend WithEvents Panel1 As Panel
    Friend WithEvents ColumnHeader3 As ColumnHeader
    Friend WithEvents ImageList1 As ImageList
End Class
