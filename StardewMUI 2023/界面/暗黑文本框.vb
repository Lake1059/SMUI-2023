Imports System.ComponentModel

Public Class 暗黑文本框

    Public Sub New()
        ' 此调用是设计器所必需的。
        InitializeComponent()

        ' 在 InitializeComponent() 调用之后添加任何初始化。
        调整()
        Me.TextBox1.PasswordChar = PasswordChar
    End Sub

    <Browsable(True)>
    Public Overrides Property Text As String
        Get
            Return Me.TextBox1.Text
        End Get
        Set(value As String)
            Me.TextBox1.Text = value
        End Set
    End Property

    <Browsable(True)>
    Public Overrides Property Font As Font
        Get
            Return Me.TextBox1.Font
        End Get
        Set(value As Font)
            Me.TextBox1.Font = value
            调整()
        End Set
    End Property

    ''' <summary>
    '''  密码字符
    ''' </summary>
    ''' <returns></returns>
    <Browsable(True)>
    Public Property PasswordChar As String
        Get
            Return Me.TextBox1.PasswordChar
        End Get
        Set(value As String)
            Me.TextBox1.PasswordChar = value
        End Set
    End Property

    ''' <summary>
    ''' 当文本框为空时显示的提示文本
    ''' </summary>
    ''' <returns></returns>
    <Browsable(True)>
    Public Property PlaceholderText As String
        Get
            Return Me.TextBox1.PlaceholderText
        End Get
        Set(value As String)
            Me.TextBox1.PlaceholderText = value
        End Set
    End Property

    Sub 调整()
        Me.Padding = New Padding(Me.Padding.Left, (Me.Height - Me.TextBox1.Height) * 0.5, Me.Padding.Right, 0)
    End Sub

    Private Sub 暗黑文本框控件本体_SizeChanged(sender As Object, e As EventArgs) Handles Me.SizeChanged
        调整()
    End Sub

    Private Sub 暗黑文本框控件本体_DpiChangedAfterParent(sender As Object, e As EventArgs) Handles Me.DpiChangedAfterParent
    End Sub

    Private Sub TextBox1_TextChanged(sender As Object, e As EventArgs) Handles TextBox1.TextChanged

    End Sub

    Private Sub TextBox1_KeyDown(sender As Object, e As KeyEventArgs) Handles TextBox1.KeyDown
        RaiseEvent KeyDown(sender, e)
    End Sub

    Public Shadows Event KeyDown(sender As Object, e As KeyEventArgs)

End Class
