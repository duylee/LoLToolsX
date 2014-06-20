Imports System.IO
Imports System.Net
Imports System.Threading

Public Class CheckUpdate1

    ''' <summary>
    ''' 檢查 LoLToolsX 更新
    ''' </summary>

    Dim thread As System.Threading.Thread

    Public Shared Sub CheckUpdate()

        Dim file As String = "version.txt"

        Dim MyVer As String = My.Application.Info.Version.ToString


        Try
            If My.Computer.FileSystem.FileExists(file) Then
                My.Computer.FileSystem.DeleteFile(file)
            End If

            My.Computer.Network.DownloadFile("http://lolnx.pixub.com/loltoolsx/version.txt", file)

            Dim lastver As String = My.Computer.FileSystem.ReadAllText(file)




            If Not MyVer = lastver Then

                'DialogResult
                Dim dlr As DialogResult = MsgBox("有可用更新 按確定下載更新", MsgBoxStyle.OkCancel + MsgBoxStyle.Information, "更新")
                If dlr = DialogResult.OK Then

                    'Wait.Show()
                    'Wait.pbW1.Value = 50
                    Update1.Update1()
                    'Wait.pbW1.Value = 100
                    'Wait.Close()

                End If

            Else
                MessageBox.Show("已經是最新版本 沒有可用更新")
            End If
        Catch ex As Exception
            MessageBox.Show("無法下載更新資訊")
        End Try



    End Sub

    Public Shared Sub CheckUpdate2()

        Dim file As String = "version.txt"

        Dim MyVer As String = My.Application.Info.Version.ToString




        Try
            If My.Computer.FileSystem.FileExists(file) Then
                My.Computer.FileSystem.DeleteFile(file)
            End If

            My.Computer.Network.DownloadFile("http://lolnx.pixub.com/loltoolsx/version.txt", file)

            Dim lastver As String = My.Computer.FileSystem.ReadAllText(file)




            If Not MyVer = lastver Then

                'DialogResult
                Dim dlr As DialogResult = MsgBox("有可用更新 按確定下載更新", MsgBoxStyle.OkCancel + MsgBoxStyle.Information, "更新")
                If dlr = DialogResult.OK Then

                    'Wait.Show()
                    'Wait.pbW1.Value = 50
                    Update1.Update1()
                    'Wait.pbW1.Value = 100
                    'Wait.Close()

                End If

            Else

            End If
        Catch ex As Exception
            MessageBox.Show("無法下載更新資訊")
        End Try



    End Sub

    Public Sub checkupdateThread()
        thread = New System.Threading.Thread(AddressOf CheckUpdate2)
    End Sub
End Class
