<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Wait
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
        Me.pbW1 = New System.Windows.Forms.ProgressBar()
        Me.SuspendLayout()
        '
        'pbW1
        '
        Me.pbW1.Location = New System.Drawing.Point(47, 29)
        Me.pbW1.Name = "pbW1"
        Me.pbW1.Size = New System.Drawing.Size(118, 26)
        Me.pbW1.TabIndex = 0
        '
        'Wait
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(212, 82)
        Me.Controls.Add(Me.pbW1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Name = "Wait"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "請稍候..."
        Me.TopMost = True
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents pbW1 As System.Windows.Forms.ProgressBar
End Class
