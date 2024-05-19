<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class 下载进度界面块控件本体
    Inherits System.Windows.Forms.UserControl

    'UserControl 重写释放以清理组件列表。
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
        暗黑菜单条控件本体1 = New 暗黑菜单条控件本体()
        取消下载ToolStripMenuItem = New ToolStripMenuItem()
        开始下载ToolStripMenuItem = New ToolStripMenuItem()
        ToolStripSeparator1 = New ToolStripSeparator()
        取消操作ToolStripMenuItem = New ToolStripMenuItem()
        Label2 = New Label()
        Panel1 = New Panel()
        Panel2 = New Panel()
        Panel3 = New Panel()
        Timer1 = New Timer(components)
        暗黑菜单条控件本体1.SuspendLayout()
        Panel1.SuspendLayout()
        Panel2.SuspendLayout()
        SuspendLayout()
        ' 
        ' Label1
        ' 
        Label1.ContextMenuStrip = 暗黑菜单条控件本体1
        Label1.Dock = DockStyle.Top
        Label1.Font = New Font("微软雅黑", 12F, FontStyle.Regular, GraphicsUnit.Point, CByte(134))
        Label1.Location = New Point(10, 10)
        Label1.Name = "Label1"
        Label1.Padding = New Padding(0, 0, 0, 10)
        Label1.Size = New Size(480, 31)
        Label1.TabIndex = 0
        Label1.Text = "正在对模组项操作下载的文件"
        ' 
        ' 暗黑菜单条控件本体1
        ' 
        暗黑菜单条控件本体1.BackColor = Color.FromArgb(CByte(48), CByte(48), CByte(48))
        暗黑菜单条控件本体1.ForeColor = Color.Gainsboro
        暗黑菜单条控件本体1.ImageScalingSize = New Size(25, 25)
        暗黑菜单条控件本体1.Items.AddRange(New ToolStripItem() {取消下载ToolStripMenuItem, 开始下载ToolStripMenuItem, ToolStripSeparator1, 取消操作ToolStripMenuItem})
        暗黑菜单条控件本体1.Name = "暗黑菜单条控件本体1"
        暗黑菜单条控件本体1.Size = New Size(134, 107)
        ' 
        ' 取消下载ToolStripMenuItem
        ' 
        取消下载ToolStripMenuItem.ForeColor = Color.Gainsboro
        取消下载ToolStripMenuItem.Image = My.Resources.Resources.叉号
        取消下载ToolStripMenuItem.Name = "取消下载ToolStripMenuItem"
        取消下载ToolStripMenuItem.Size = New Size(133, 32)
        取消下载ToolStripMenuItem.Text = "取消下载"
        ' 
        ' 开始下载ToolStripMenuItem
        ' 
        开始下载ToolStripMenuItem.ForeColor = Color.Gainsboro
        开始下载ToolStripMenuItem.Image = My.Resources.Resources.下载
        开始下载ToolStripMenuItem.Name = "开始下载ToolStripMenuItem"
        开始下载ToolStripMenuItem.Size = New Size(133, 32)
        开始下载ToolStripMenuItem.Text = "开始下载"
        ' 
        ' ToolStripSeparator1
        ' 
        ToolStripSeparator1.ForeColor = Color.Gainsboro
        ToolStripSeparator1.Margin = New Padding(0, 0, 0, 1)
        ToolStripSeparator1.Name = "ToolStripSeparator1"
        ToolStripSeparator1.Size = New Size(130, 6)
        ' 
        ' 取消操作ToolStripMenuItem
        ' 
        取消操作ToolStripMenuItem.ForeColor = Color.Gainsboro
        取消操作ToolStripMenuItem.Image = My.Resources.Resources.删除
        取消操作ToolStripMenuItem.Name = "取消操作ToolStripMenuItem"
        取消操作ToolStripMenuItem.Size = New Size(133, 32)
        取消操作ToolStripMenuItem.Text = "取消操作"
        ' 
        ' Label2
        ' 
        Label2.ContextMenuStrip = 暗黑菜单条控件本体1
        Label2.Dock = DockStyle.Top
        Label2.Location = New Point(10, 41)
        Label2.Name = "Label2"
        Label2.Padding = New Padding(0, 0, 0, 10)
        Label2.Size = New Size(480, 29)
        Label2.TabIndex = 1
        Label2.Text = "容量速度和状态"
        ' 
        ' Panel1
        ' 
        Panel1.ContextMenuStrip = 暗黑菜单条控件本体1
        Panel1.Controls.Add(Panel2)
        Panel1.Dock = DockStyle.Fill
        Panel1.Location = New Point(10, 70)
        Panel1.Name = "Panel1"
        Panel1.Padding = New Padding(5, 0, 5, 2)
        Panel1.Size = New Size(480, 15)
        Panel1.TabIndex = 2
        ' 
        ' Panel2
        ' 
        Panel2.BackColor = Color.FromArgb(CByte(64), CByte(64), CByte(64))
        Panel2.ContextMenuStrip = 暗黑菜单条控件本体1
        Panel2.Controls.Add(Panel3)
        Panel2.Dock = DockStyle.Fill
        Panel2.Location = New Point(5, 0)
        Panel2.Name = "Panel2"
        Panel2.Size = New Size(470, 13)
        Panel2.TabIndex = 0
        ' 
        ' Panel3
        ' 
        Panel3.BackColor = Color.DarkGreen
        Panel3.ContextMenuStrip = 暗黑菜单条控件本体1
        Panel3.Dock = DockStyle.Left
        Panel3.Location = New Point(0, 0)
        Panel3.Name = "Panel3"
        Panel3.Size = New Size(187, 13)
        Panel3.TabIndex = 0
        ' 
        ' Timer1
        ' 
        Timer1.Interval = 1000
        ' 
        ' 下载进度界面块控件本体
        ' 
        AutoScaleDimensions = New SizeF(96F, 96F)
        AutoScaleMode = AutoScaleMode.Dpi
        BackColor = Color.FromArgb(CByte(36), CByte(36), CByte(36))
        ContextMenuStrip = 暗黑菜单条控件本体1
        Controls.Add(Panel1)
        Controls.Add(Label2)
        Controls.Add(Label1)
        Font = New Font("微软雅黑", 9.75F, FontStyle.Regular, GraphicsUnit.Point, CByte(134))
        ForeColor = Color.FromArgb(CByte(224), CByte(224), CByte(224))
        Margin = New Padding(0)
        Name = "下载进度界面块控件本体"
        Padding = New Padding(10)
        Size = New Size(500, 95)
        暗黑菜单条控件本体1.ResumeLayout(False)
        Panel1.ResumeLayout(False)
        Panel2.ResumeLayout(False)
        ResumeLayout(False)
    End Sub

    Friend WithEvents Label1 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents Panel1 As Panel
    Friend WithEvents Panel2 As Panel
    Friend WithEvents Panel3 As Panel
    Friend WithEvents 暗黑菜单条控件本体1 As 暗黑菜单条控件本体
    Friend WithEvents Timer1 As Timer
    Friend WithEvents 取消下载ToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents 开始下载ToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ToolStripSeparator1 As ToolStripSeparator
    Friend WithEvents 取消操作ToolStripMenuItem As ToolStripMenuItem

End Class
