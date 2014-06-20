Imports System.IO

Public Class SwitchSound

    ''' <summary>
    ''' 語音切換
    ''' </summary>

    Public Shared Sub SwitchSound(ByVal type As String, ByVal soundPath As String, ByVal targetPath As String)

        Dim soundlobbyPath As String = soundPath + "\champions"
        Dim lobbyPath1 As String = targetPath + "\Air\assets\sounds\en_US\champions"
        Dim lobbyPath2 As String = targetPath + "\Air\assets\sounds\zh_TW\champions"

        Dim gamePath As String = targetPath + "\Game"

        Try
            If type = "lobby" Then
                TwTools.pbLobby.Value = 30
                My.Computer.FileSystem.CopyDirectory(soundlobbyPath, lobbyPath1, True)
                TwTools.pbLobby.Value = 70
                My.Computer.FileSystem.CopyDirectory(soundlobbyPath, lobbyPath2, True)
                TwTools.pbLobby.Value = 100
                MsgBox("安裝完成!", MsgBoxStyle.OkOnly + MsgBoxStyle.Information, "提示")
                TwTools.pbLobby.Value = 0
            End If
        Catch ex As Exception
            TwTools.pbLobby.Value = 0
            MsgBox("安裝失敗!", MsgBoxStyle.Critical + MsgBoxStyle.OkOnly, "錯誤")
        End Try
        

        If type = "game" Then
                Try
                    TwTools.pbGame.Value = 0
                    'My.Computer.FileSystem.CopyDirectory(soundgamePath, gamePath, True)
                    My.Computer.FileSystem.CopyFile(soundPath + "\VOBank_ko_KR.fsb", gamePath + "\DATA\Sounds\FMOD\VOBank_ko_KR.fsb", True)
                    TwTools.pbGame.Value = 35
                    My.Computer.FileSystem.CopyFile(soundPath + "\VOBank_ko_KR.fsb", gamePath + "\DATA\Sounds\FMOD\VOBank_zh_TW.fsb", True)
                    My.Computer.FileSystem.CopyFile(soundPath + "\VOBank_ko_KR.fsb", gamePath + "\DATA\Sounds\FMOD\VOBank_zh_CN.fsb", True)
                    TwTools.pbGame.Value = 65
                    My.Computer.FileSystem.CopyFile(soundPath + "\VOBank_ko_KR.fsb", gamePath + "\DATA\Sounds\FMOD\VOBank_en_US.fsb", True)
                    TwTools.pbGame.Value = 100
                    MsgBox("安裝完成!", MsgBoxStyle.OkOnly + MsgBoxStyle.Information, "提示")
                    TwTools.pbGame.Value = 0
                Catch ex As Exception
                End Try

                Try
                    TwTools.pbGame.Value = 0
                    'My.Computer.FileSystem.CopyDirectory(soundgamePath, gamePath, True)
                    My.Computer.FileSystem.CopyFile(soundPath + "\VOBank_zh_CN.fsb", gamePath + "\DATA\Sounds\FMOD\VOBank_zh_CN.fsb", True)
                    TwTools.pbGame.Value = 35
                    My.Computer.FileSystem.CopyFile(soundPath + "\VOBank_zh_CN.fsb", gamePath + "\DATA\Sounds\FMOD\VOBank_zh_TW.fsb", True)
                    My.Computer.FileSystem.CopyFile(soundPath + "\VOBank_zh_CN.fsb", gamePath + "\DATA\Sounds\FMOD\VOBank_ko_KR.fsb", True)
                    TwTools.pbGame.Value = 65
                    My.Computer.FileSystem.CopyFile(soundPath + "\VOBank_zh_CN.fsb", gamePath + "\DATA\Sounds\FMOD\VOBank_en_US.fsb", True)
                    TwTools.pbGame.Value = 100
                    MsgBox("安裝完成!", MsgBoxStyle.OkOnly + MsgBoxStyle.Information, "提示")
                    TwTools.pbGame.Value = 0
                Catch ex As Exception

                End Try

                Try
                    TwTools.pbGame.Value = 0
                    'My.Computer.FileSystem.CopyDirectory(soundgamePath, gamePath, True)
                    My.Computer.FileSystem.CopyFile(soundPath + "\VOBank_zh_TW.fsb", gamePath + "\DATA\Sounds\FMOD\VOBank_zh_CN.fsb", True)
                    TwTools.pbGame.Value = 35
                    My.Computer.FileSystem.CopyFile(soundPath + "\VOBank_zh_TW.fsb", gamePath + "\DATA\Sounds\FMOD\VOBank_zh_TW.fsb", True)
                    My.Computer.FileSystem.CopyFile(soundPath + "\VOBank_zh_TW.fsb", gamePath + "\DATA\Sounds\FMOD\VOBank_ko_KR.fsb", True)
                    TwTools.pbGame.Value = 65
                    My.Computer.FileSystem.CopyFile(soundPath + "\VOBank_zh_TW.fsb", gamePath + "\DATA\Sounds\FMOD\VOBank_en_US.fsb", True)
                    TwTools.pbGame.Value = 100
                    MsgBox("安裝完成!", MsgBoxStyle.OkOnly + MsgBoxStyle.Information, "提示")
                    TwTools.pbGame.Value = 0
                Catch ex As Exception

                End Try

        End If

    End Sub
End Class
