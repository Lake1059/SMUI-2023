﻿<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Form_CD_D_MODS
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
        UiListBox1 = New Sunny.UI.UIListBox()
        UiButton1 = New Sunny.UI.UIButton()
        SuspendLayout()
        ' 
        ' Label1
        ' 
        Label1.AutoSize = True
        Label1.Location = New Point(29, 29)
        Label1.Margin = New Padding(20, 20, 20, 0)
        Label1.Name = "Label1"
        Label1.Size = New Size(263, 21)
        Label1.TabIndex = 0
        Label1.Text = "选择可用的标准 SMAPI 模组文件夹"
        ' 
        ' UiListBox1
        ' 
        UiListBox1.Anchor = AnchorStyles.Top Or AnchorStyles.Bottom Or AnchorStyles.Left Or AnchorStyles.Right
        UiListBox1.BackColor = Color.FromArgb(CByte(32), CByte(32), CByte(32))
        UiListBox1.FillColor = Color.FromArgb(CByte(36), CByte(36), CByte(36))
        UiListBox1.FillColor2 = Color.FromArgb(CByte(36), CByte(36), CByte(36))
        UiListBox1.FillDisableColor = Color.FromArgb(CByte(32), CByte(32), CByte(32))
        UiListBox1.Font = New Font("微软雅黑", 9.75F)
        UiListBox1.ForeColor = Color.FromArgb(CByte(224), CByte(224), CByte(224))
        UiListBox1.ForeDisableColor = Color.FromArgb(CByte(224), CByte(224), CByte(224))
        UiListBox1.HoverColor = Color.FromArgb(CByte(56), CByte(56), CByte(56))
        UiListBox1.ItemHeight = 30
        UiListBox1.Items.AddRange(New Object() {"字体样式"})
        UiListBox1.ItemSelectBackColor = Color.FromArgb(CByte(64), CByte(64), CByte(64))
        UiListBox1.ItemSelectForeColor = Color.FromArgb(CByte(224), CByte(224), CByte(224))
        UiListBox1.Location = New Point(29, 70)
        UiListBox1.Margin = New Padding(20, 20, 20, 0)
        UiListBox1.MinimumSize = New Size(1, 1)
        UiListBox1.Name = "UiListBox1"
        UiListBox1.Padding = New Padding(10, 10, 1, 10)
        UiListBox1.RadiusSides = Sunny.UI.UICornerRadiusSides.None
        UiListBox1.RectSides = ToolStripStatusLabelBorderSides.None
        UiListBox1.ScrollBarBackColor = Color.FromArgb(CByte(48), CByte(48), CByte(48))
        UiListBox1.ScrollBarColor = Color.DimGray
        UiListBox1.ScrollBarStyleInherited = False
        UiListBox1.ShowText = False
        UiListBox1.Size = New Size(426, 207)
        UiListBox1.Style = Sunny.UI.UIStyle.Custom
        UiListBox1.TabIndex = 40
        UiListBox1.Text = "UiListBox3"
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
        UiButton1.Location = New Point(330, 297)
        UiButton1.Margin = New Padding(20)
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
        UiButton1.TabIndex = 43
        UiButton1.TabStop = False
        UiButton1.Text = "确认"
        UiButton1.TipsColor = Color.Gray
        UiButton1.TipsFont = New Font("微软雅黑", 9F)
        ' 
        ' Form_CD_D_MODS
        ' 
        AutoScaleDimensions = New SizeF(96F, 96F)
        AutoScaleMode = AutoScaleMode.Dpi
        BackColor = Color.FromArgb(CByte(24), CByte(24), CByte(24))
        ClientSize = New Size(484, 361)
        Controls.Add(UiButton1)
        Controls.Add(UiListBox1)
        Controls.Add(Label1)
        Font = New Font("微软雅黑", 12F, FontStyle.Regular, GraphicsUnit.Point, CByte(134))
        ForeColor = Color.FromArgb(CByte(224), CByte(224), CByte(224))
        MaximizeBox = False
        MinimizeBox = False
        MinimumSize = New Size(500, 400)
        Name = "Form_CD_D_MODS"
        ShowIcon = False
        ShowInTaskbar = False
        StartPosition = FormStartPosition.Manual
        Text = "编辑规划"
        ResumeLayout(False)
        PerformLayout()
    End Sub

    Friend WithEvents Label1 As Label
    Friend WithEvents UiListBox1 As Sunny.UI.UIListBox
    Friend WithEvents UiButton1 As Sunny.UI.UIButton
End Class
