Public Class InstallUI

    ''' <summary>
    ''' UI安裝
    ''' </summary>

    Public Shared Sub InstallGameUI(ByVal hudPath As String, ByVal targetPath As String)


        Try
            My.Computer.FileSystem.CopyFile(hudPath, targetPath + "\Game\DATA\Menu\Textures\HUDAtlas.tga", True)
            MsgBox("安裝完成!", MsgBoxStyle.OkOnly + MsgBoxStyle.Information, "提示")
        Catch ex As Exception
            MsgBox("安裝失敗... " & vbCrLf & "錯誤信息: " & ex.Message, MsgBoxStyle.Critical + MsgBoxStyle.OkOnly, "錯誤")
        End Try


    End Sub
End Class
