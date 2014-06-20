<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ServerSelect
    Inherits System.Windows.Forms.Form

    'Form 覆寫 Dispose 以清除元件清單。
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

    '為 Windows Form 設計工具的必要項
    Private components As System.ComponentModel.IContainer

    '注意: 以下為 Windows Form 設計工具所需的程序
    '可以使用 Windows Form 設計工具進行修改。
    '請不要使用程式碼編輯器進行修改。
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(ServerSelect))
        Me.selectTW = New System.Windows.Forms.Button()
        Me.selectNA = New System.Windows.Forms.Button()
        Me.selectKR = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'selectTW
        '
        Me.selectTW.Location = New System.Drawing.Point(62, 32)
        Me.selectTW.Name = "selectTW"
        Me.selectTW.Size = New System.Drawing.Size(118, 45)
        Me.selectTW.TabIndex = 0
        Me.selectTW.Text = "台服"
        Me.selectTW.UseVisualStyleBackColor = True
        '
        'selectNA
        '
        Me.selectNA.Location = New System.Drawing.Point(62, 122)
        Me.selectNA.Name = "selectNA"
        Me.selectNA.Size = New System.Drawing.Size(118, 45)
        Me.selectNA.TabIndex = 1
        Me.selectNA.Text = "美服"
        Me.selectNA.UseVisualStyleBackColor = True
        '
        'selectKR
        '
        Me.selectKR.Enabled = False
        Me.selectKR.Location = New System.Drawing.Point(62, 219)
        Me.selectKR.Name = "selectKR"
        Me.selectKR.Size = New System.Drawing.Size(118, 45)
        Me.selectKR.TabIndex = 2
        Me.selectKR.Text = "韓服"
        Me.selectKR.UseVisualStyleBackColor = True
        '
        'ServerSelect
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(245, 306)
        Me.Controls.Add(Me.selectKR)
        Me.Controls.Add(Me.selectNA)
        Me.Controls.Add(Me.selectTW)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "ServerSelect"
        Me.ShowIcon = False
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "請選擇客戶端"
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents selectTW As System.Windows.Forms.Button
    Friend WithEvents selectNA As System.Windows.Forms.Button
    Friend WithEvents selectKR As System.Windows.Forms.Button

End Class
