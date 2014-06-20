Imports System.IO

Public Class StartGame

    ''' <summary>
    ''' 開啟遊戲
    ''' </summary>

    Public Shared Sub StartLoLTW()

        Dim imPath As String = ""
        Dim imExe As String = ""



        Try
            If My.Computer.Registry.GetValue("HKEY_LOCAL_MACHINE\SOFTWARE\Garena\im", "Path", Nothing) <> Nothing Then
                imPath = My.Computer.Registry.GetValue("HKEY_LOCAL_MACHINE\SOFTWARE\Garena\im", "Path", Nothing)
                imExe = imPath + "\GarenaMessenger.exe"
                Process.Start(imExe)
            End If
        Catch ex As Exception
            MsgBox(" 找不到競時通 無法開啟遊戲 ", MsgBoxStyle.Critical + MsgBoxStyle.OkOnly, "提示")
        End Try




    End Sub




    Public Shared Sub StartLoL(ByVal lolexePath As String)
        Try
            Process.Start(lolexePath)
        Catch ex As Exception
            MsgBox("遊戲開啟失敗...", MsgBoxStyle.Critical + MsgBoxStyle.OkOnly, "錯誤")
        End Try


    End Sub

End Class
