<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class 数据表检索结果单片控件本体
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
        Panel3 = New Panel()
        Label14 = New Label()
        Label15 = New Label()
        Label4 = New Label()
        Label12 = New Label()
        Label2 = New Label()
        Label5 = New Label()
        Label6 = New Label()
        Label7 = New Label()
        Label8 = New Label()
        Label9 = New Label()
        Label10 = New Label()
        Label11 = New Label()
        Label13 = New Label()
        Label3 = New Label()
        Label1 = New Label()
        Panel3.SuspendLayout()
        SuspendLayout()
        ' 
        ' Panel3
        ' 
        Panel3.Controls.Add(Label14)
        Panel3.Controls.Add(Label15)
        Panel3.Controls.Add(Label4)
        Panel3.Controls.Add(Label12)
        Panel3.Controls.Add(Label2)
        Panel3.Controls.Add(Label5)
        Panel3.Controls.Add(Label6)
        Panel3.Controls.Add(Label7)
        Panel3.Controls.Add(Label8)
        Panel3.Controls.Add(Label9)
        Panel3.Controls.Add(Label10)
        Panel3.Controls.Add(Label11)
        Panel3.Controls.Add(Label13)
        Panel3.Dock = DockStyle.Top
        Panel3.Font = New Font("微软雅黑", 9F, FontStyle.Regular, GraphicsUnit.Point, CByte(134))
        Panel3.Location = New Point(10, 10)
        Panel3.Name = "Panel3"
        Panel3.Padding = New Padding(3, 0, 0, 0)
        Panel3.Size = New Size(480, 20)
        Panel3.TabIndex = 7
        ' 
        ' Label14
        ' 
        Label14.BackColor = Color.DimGray
        Label14.Dock = DockStyle.Left
        Label14.Location = New Point(333, 0)
        Label14.Name = "Label14"
        Label14.Size = New Size(50, 20)
        Label14.TabIndex = 13
        Label14.Text = "组合"
        Label14.TextAlign = ContentAlignment.MiddleCenter
        ' 
        ' Label15
        ' 
        Label15.Dock = DockStyle.Left
        Label15.Location = New Point(328, 0)
        Label15.Name = "Label15"
        Label15.Size = New Size(5, 20)
        Label15.TabIndex = 12
        ' 
        ' Label4
        ' 
        Label4.BackColor = Color.RoyalBlue
        Label4.Dock = DockStyle.Left
        Label4.Location = New Point(278, 0)
        Label4.Name = "Label4"
        Label4.Size = New Size(50, 20)
        Label4.TabIndex = 11
        Label4.Text = "非官方"
        Label4.TextAlign = ContentAlignment.MiddleCenter
        ' 
        ' Label12
        ' 
        Label12.Dock = DockStyle.Left
        Label12.Location = New Point(273, 0)
        Label12.Name = "Label12"
        Label12.Size = New Size(5, 20)
        Label12.TabIndex = 10
        ' 
        ' Label2
        ' 
        Label2.BackColor = Color.DarkGreen
        Label2.Dock = DockStyle.Left
        Label2.Location = New Point(223, 0)
        Label2.Name = "Label2"
        Label2.Size = New Size(50, 20)
        Label2.TabIndex = 9
        Label2.Text = "下载"
        Label2.TextAlign = ContentAlignment.MiddleCenter
        ' 
        ' Label5
        ' 
        Label5.Dock = DockStyle.Left
        Label5.Location = New Point(218, 0)
        Label5.Name = "Label5"
        Label5.Size = New Size(5, 20)
        Label5.TabIndex = 7
        ' 
        ' Label6
        ' 
        Label6.BackColor = Color.Maroon
        Label6.Dock = DockStyle.Left
        Label6.Location = New Point(168, 0)
        Label6.Name = "Label6"
        Label6.Size = New Size(50, 20)
        Label6.TabIndex = 6
        Label6.Text = "热度"
        Label6.TextAlign = ContentAlignment.MiddleCenter
        ' 
        ' Label7
        ' 
        Label7.Dock = DockStyle.Left
        Label7.Location = New Point(163, 0)
        Label7.Name = "Label7"
        Label7.Size = New Size(5, 20)
        Label7.TabIndex = 5
        ' 
        ' Label8
        ' 
        Label8.BackColor = Color.DarkGreen
        Label8.Dock = DockStyle.Left
        Label8.Location = New Point(113, 0)
        Label8.Name = "Label8"
        Label8.Size = New Size(50, 20)
        Label8.TabIndex = 4
        Label8.Text = "安全"
        Label8.TextAlign = ContentAlignment.MiddleCenter
        ' 
        ' Label9
        ' 
        Label9.Dock = DockStyle.Left
        Label9.Location = New Point(108, 0)
        Label9.Name = "Label9"
        Label9.Size = New Size(5, 20)
        Label9.TabIndex = 3
        ' 
        ' Label10
        ' 
        Label10.BackColor = Color.BlueViolet
        Label10.Dock = DockStyle.Left
        Label10.Location = New Point(58, 0)
        Label10.Name = "Label10"
        Label10.Size = New Size(50, 20)
        Label10.TabIndex = 2
        Label10.Text = "分类"
        Label10.TextAlign = ContentAlignment.MiddleCenter
        ' 
        ' Label11
        ' 
        Label11.Dock = DockStyle.Left
        Label11.Location = New Point(53, 0)
        Label11.Name = "Label11"
        Label11.Size = New Size(5, 20)
        Label11.TabIndex = 1
        ' 
        ' Label13
        ' 
        Label13.BackColor = Color.DarkGreen
        Label13.Dock = DockStyle.Left
        Label13.Location = New Point(3, 0)
        Label13.Name = "Label13"
        Label13.Size = New Size(50, 20)
        Label13.TabIndex = 0
        Label13.Text = "全自动"
        Label13.TextAlign = ContentAlignment.MiddleCenter
        ' 
        ' Label3
        ' 
        Label3.AutoSize = True
        Label3.Dock = DockStyle.Top
        Label3.Location = New Point(10, 54)
        Label3.Name = "Label3"
        Label3.Padding = New Padding(0, 5, 0, 0)
        Label3.Size = New Size(48, 24)
        Label3.TabIndex = 9
        Label3.Text = "描述词"
        ' 
        ' Label1
        ' 
        Label1.AutoSize = True
        Label1.Dock = DockStyle.Top
        Label1.Location = New Point(10, 30)
        Label1.Name = "Label1"
        Label1.Padding = New Padding(0, 5, 0, 0)
        Label1.Size = New Size(101, 24)
        Label1.TabIndex = 8
        Label1.Text = "模组名称 - 作者"
        ' 
        ' 数据表检索结果单片控件本体
        ' 
        AutoScaleDimensions = New SizeF(96F, 96F)
        AutoScaleMode = AutoScaleMode.Dpi
        AutoSize = True
        BackColor = Color.FromArgb(CByte(32), CByte(32), CByte(32))
        Controls.Add(Label3)
        Controls.Add(Label1)
        Controls.Add(Panel3)
        Font = New Font("微软雅黑", 9.75F, FontStyle.Regular, GraphicsUnit.Point, CByte(134))
        ForeColor = Color.FromArgb(CByte(224), CByte(224), CByte(224))
        Name = "数据表检索结果单片控件本体"
        Padding = New Padding(10)
        Size = New Size(500, 88)
        Panel3.ResumeLayout(False)
        ResumeLayout(False)
        PerformLayout()
    End Sub
    Friend WithEvents Panel3 As Panel
    Friend WithEvents Label6 As Label
    Friend WithEvents Label7 As Label
    Friend WithEvents Label8 As Label
    Friend WithEvents Label9 As Label
    Friend WithEvents Label10 As Label
    Friend WithEvents Label11 As Label
    Friend WithEvents Label13 As Label
    Friend WithEvents Label5 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents Label1 As Label
    Friend WithEvents Label14 As Label
    Friend WithEvents Label15 As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents Label12 As Label
    Friend WithEvents Label2 As Label

End Class
