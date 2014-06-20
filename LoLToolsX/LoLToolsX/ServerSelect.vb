Imports System.Threading

Public Class ServerSelect

    Dim thread As System.Threading.Thread

    Private Sub Form1_Close(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.FormClosed
        Application.Exit()
    End Sub

    Private Sub selectTW_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles selectTW.Click
        TwTools.Show()
        Me.Hide()
    End Sub

    Private Sub selectNA_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles selectNA.Click
        NaTools.Show()
        Me.Hide()
    End Sub

    Private Sub ServerSelect_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load


        'Me.Hide()
        'Wait.Show()
        'Wait.pbW1.Value = 50
        Try
            thread.Start()
            'CheckUpdate1.CheckUpdate(True)

        Catch ex As Exception

        End Try
        'Wait.pbW1.Value = 100
        'Wait.Close()
        'Me.Show()
    End Sub

    Public Sub checkupdateThread()
        thread = New System.Threading.Thread(AddressOf CheckUpdate1.CheckUpdate2)
    End Sub
End Class
