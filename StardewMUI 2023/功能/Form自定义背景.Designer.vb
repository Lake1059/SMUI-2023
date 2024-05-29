<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Form自定义背景
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
        LinkLabel1 = New LinkLabel()
        LinkLabel2 = New LinkLabel()
        LinkLabel3 = New LinkLabel()
        Label3 = New Label()
        UiButton1 = New Sunny.UI.UIButton()
        LinkLabel4 = New LinkLabel()
        LinkLabel5 = New LinkLabel()
        LinkLabel6 = New LinkLabel()
        SuspendLayout()
        ' 
        ' Label1
        ' 
        Label1.AutoSize = True
        Label1.Font = New Font("微软雅黑", 9.75F, FontStyle.Regular, GraphicsUnit.Point, CByte(134))
        Label1.Location = New Point(20, 101)
        Label1.Margin = New Padding(20, 10, 20, 0)
        Label1.Name = "Label1"
        Label1.Size = New Size(112, 19)
        Label1.TabIndex = 65
        Label1.Text = "背景 RGB 和 尺寸"
        ' 
        ' Label2
        ' 
        Label2.AutoSize = True
        Label2.Font = New Font("微软雅黑", 9.75F, FontStyle.Regular, GraphicsUnit.Point, CByte(134))
        Label2.Location = New Point(20, 171)
        Label2.Margin = New Padding(20, 10, 20, 0)
        Label2.Name = "Label2"
        Label2.Size = New Size(112, 19)
        Label2.TabIndex = 68
        Label2.Text = "背景 RGB 和 尺寸"
        ' 
        ' LinkLabel1
        ' 
        LinkLabel1.AutoSize = True
        LinkLabel1.Font = New Font("微软雅黑", 12F)
        LinkLabel1.LinkBehavior = LinkBehavior.HoverUnderline
        LinkLabel1.LinkColor = Color.Chocolate
        LinkLabel1.Location = New Point(20, 70)
        LinkLabel1.Margin = New Padding(20, 20, 20, 0)
        LinkLabel1.Name = "LinkLabel1"
        LinkLabel1.Size = New Size(122, 21)
        LinkLabel1.TabIndex = 69
        LinkLabel1.TabStop = True
        LinkLabel1.Text = "新闻公告背景图"
        ' 
        ' LinkLabel2
        ' 
        LinkLabel2.AutoSize = True
        LinkLabel2.Font = New Font("微软雅黑", 12F)
        LinkLabel2.LinkBehavior = LinkBehavior.HoverUnderline
        LinkLabel2.LinkColor = Color.Chocolate
        LinkLabel2.Location = New Point(20, 140)
        LinkLabel2.Margin = New Padding(20, 20, 20, 0)
        LinkLabel2.Name = "LinkLabel2"
        LinkLabel2.Size = New Size(106, 21)
        LinkLabel2.TabIndex = 70
        LinkLabel2.TabStop = True
        LinkLabel2.Text = "分类列表视图"
        ' 
        ' LinkLabel3
        ' 
        LinkLabel3.AutoSize = True
        LinkLabel3.Font = New Font("微软雅黑", 12F)
        LinkLabel3.LinkBehavior = LinkBehavior.HoverUnderline
        LinkLabel3.LinkColor = Color.Chocolate
        LinkLabel3.Location = New Point(20, 210)
        LinkLabel3.Margin = New Padding(20, 20, 20, 0)
        LinkLabel3.Name = "LinkLabel3"
        LinkLabel3.Size = New Size(122, 21)
        LinkLabel3.TabIndex = 72
        LinkLabel3.TabStop = True
        LinkLabel3.Text = "模组项列表视图"
        ' 
        ' Label3
        ' 
        Label3.AutoSize = True
        Label3.Font = New Font("微软雅黑", 9.75F, FontStyle.Regular, GraphicsUnit.Point, CByte(134))
        Label3.Location = New Point(20, 241)
        Label3.Margin = New Padding(20, 10, 20, 0)
        Label3.Name = "Label3"
        Label3.Size = New Size(112, 19)
        Label3.TabIndex = 71
        Label3.Text = "背景 RGB 和 尺寸"
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
        UiButton1.Location = New Point(20, 20)
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
        UiButton1.Size = New Size(150, 30)
        UiButton1.Style = Sunny.UI.UIStyle.Custom
        UiButton1.TabIndex = 79
        UiButton1.TabStop = False
        UiButton1.Text = "刷新所有信息"
        UiButton1.TipsColor = Color.Gray
        UiButton1.TipsFont = New Font("微软雅黑", 9F)
        ' 
        ' LinkLabel4
        ' 
        LinkLabel4.AutoSize = True
        LinkLabel4.Font = New Font("微软雅黑", 12F)
        LinkLabel4.LinkBehavior = LinkBehavior.HoverUnderline
        LinkLabel4.LinkColor = Color.Chocolate
        LinkLabel4.Location = New Point(413, 70)
        LinkLabel4.Margin = New Padding(20, 20, 20, 0)
        LinkLabel4.Name = "LinkLabel4"
        LinkLabel4.Size = New Size(42, 21)
        LinkLabel4.TabIndex = 80
        LinkLabel4.TabStop = True
        LinkLabel4.Text = "删除"
        ' 
        ' LinkLabel5
        ' 
        LinkLabel5.AutoSize = True
        LinkLabel5.Font = New Font("微软雅黑", 12F)
        LinkLabel5.LinkBehavior = LinkBehavior.HoverUnderline
        LinkLabel5.LinkColor = Color.Chocolate
        LinkLabel5.Location = New Point(413, 140)
        LinkLabel5.Margin = New Padding(20, 20, 20, 0)
        LinkLabel5.Name = "LinkLabel5"
        LinkLabel5.Size = New Size(42, 21)
        LinkLabel5.TabIndex = 81
        LinkLabel5.TabStop = True
        LinkLabel5.Text = "删除"
        ' 
        ' LinkLabel6
        ' 
        LinkLabel6.AutoSize = True
        LinkLabel6.Font = New Font("微软雅黑", 12F)
        LinkLabel6.LinkBehavior = LinkBehavior.HoverUnderline
        LinkLabel6.LinkColor = Color.Chocolate
        LinkLabel6.Location = New Point(413, 210)
        LinkLabel6.Margin = New Padding(20, 20, 20, 0)
        LinkLabel6.Name = "LinkLabel6"
        LinkLabel6.Size = New Size(42, 21)
        LinkLabel6.TabIndex = 82
        LinkLabel6.TabStop = True
        LinkLabel6.Text = "删除"
        ' 
        ' Form自定义背景
        ' 
        AutoScaleDimensions = New SizeF(96F, 96F)
        AutoScaleMode = AutoScaleMode.Dpi
        AutoScroll = True
        BackColor = Color.FromArgb(CByte(24), CByte(24), CByte(24))
        ClientSize = New Size(484, 561)
        Controls.Add(LinkLabel6)
        Controls.Add(LinkLabel5)
        Controls.Add(LinkLabel4)
        Controls.Add(UiButton1)
        Controls.Add(LinkLabel3)
        Controls.Add(Label3)
        Controls.Add(LinkLabel2)
        Controls.Add(LinkLabel1)
        Controls.Add(Label2)
        Controls.Add(Label1)
        Font = New Font("微软雅黑", 9.75F, FontStyle.Regular, GraphicsUnit.Point, CByte(134))
        ForeColor = Color.FromArgb(CByte(224), CByte(224), CByte(224))
        MaximizeBox = False
        MinimizeBox = False
        MinimumSize = New Size(500, 600)
        Name = "Form自定义背景"
        ShowIcon = False
        ShowInTaskbar = False
        StartPosition = FormStartPosition.Manual
        Text = "自定义背景"
        ResumeLayout(False)
        PerformLayout()
    End Sub
    Friend WithEvents Label1 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents LinkLabel1 As LinkLabel
    Friend WithEvents LinkLabel2 As LinkLabel
    Friend WithEvents LinkLabel3 As LinkLabel
    Friend WithEvents Label3 As Label
    Friend WithEvents UiButton1 As Sunny.UI.UIButton
    Friend WithEvents LinkLabel4 As LinkLabel
    Friend WithEvents LinkLabel5 As LinkLabel
    Friend WithEvents LinkLabel6 As LinkLabel
End Class
