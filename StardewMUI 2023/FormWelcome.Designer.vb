<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormWelcome
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FormWelcome))
        Label4 = New Label()
        Label1 = New Label()
        Label2 = New Label()
        SuspendLayout()
        ' 
        ' Label4
        ' 
        Label4.AutoSize = True
        Label4.Dock = DockStyle.Top
        Label4.Font = New Font("微软雅黑", 14.25F, FontStyle.Bold, GraphicsUnit.Point, CByte(134))
        Label4.Location = New Point(30, 30)
        Label4.Name = "Label4"
        Label4.Padding = New Padding(0, 0, 0, 20)
        Label4.Size = New Size(126, 46)
        Label4.TabIndex = 1
        Label4.Text = "致全体用户："
        ' 
        ' Label1
        ' 
        Label1.Dock = DockStyle.Fill
        Label1.Font = New Font("微软雅黑", 12F)
        Label1.ForeColor = Color.DarkGray
        Label1.Location = New Point(30, 76)
        Label1.Margin = New Padding(20, 20, 20, 0)
        Label1.Name = "Label1"
        Label1.Size = New Size(674, 505)
        Label1.TabIndex = 2
        Label1.Text = resources.GetString("Label1.Text")
        ' 
        ' Label2
        ' 
        Label2.Dock = DockStyle.Bottom
        Label2.Font = New Font("微软雅黑", 12F)
        Label2.Location = New Point(30, 581)
        Label2.Name = "Label2"
        Label2.Padding = New Padding(0, 20, 0, 0)
        Label2.Size = New Size(674, 100)
        Label2.TabIndex = 3
        Label2.Text = "————   SMUI 模组管理方案设计者 和 SMUI 系列模组管理器开发者" & vbCrLf & "1059 Studio（B站：湖边的稻草）"
        Label2.TextAlign = ContentAlignment.BottomRight
        ' 
        ' FormWelcome
        ' 
        AutoScaleDimensions = New SizeF(96F, 96F)
        AutoScaleMode = AutoScaleMode.Dpi
        BackColor = Color.FromArgb(CByte(24), CByte(24), CByte(24))
        ClientSize = New Size(734, 711)
        Controls.Add(Label1)
        Controls.Add(Label4)
        Controls.Add(Label2)
        Font = New Font("微软雅黑", 9.75F)
        ForeColor = Color.FromArgb(CByte(224), CByte(224), CByte(224))
        MaximizeBox = False
        MinimizeBox = False
        Name = "FormWelcome"
        Padding = New Padding(30)
        ShowIcon = False
        ShowInTaskbar = False
        StartPosition = FormStartPosition.Manual
        Text = "欢迎"
        ResumeLayout(False)
        PerformLayout()
    End Sub

    Friend WithEvents Label4 As Label
    Friend WithEvents Label1 As Label
    Friend WithEvents Label2 As Label
End Class
