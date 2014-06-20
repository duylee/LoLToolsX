Public Class ChatColour




    Public Function ReadFriendlyColour(ByVal installPath As String)

        Dim ini As New INIFile.INIFile(installPath + "\Game\DATA\Menu\HUD\defaults\Chat.ini")
        Dim currentFC As String = ini.GetString("Output", "FriendlyColorDefault", Nothing)

        Return currentFC

    End Function

    Public Function WriteFriendlyColour(ByVal installPath As String, ByVal R As String, ByVal G As String, ByVal B As String)
        '隊友聊天顏色

        Try
            Dim ini As New INIFile.INIFile(installPath + "\Game\DATA\Menu\HUD\defaults\Chat.ini")
            Dim targetColour As String = " " + R + " " + G + " " + B
            ini.WriteString("Output", "FriendlyColorDefault", targetColour)

        Catch ex As Exception
            MsgBox("修改失敗", MsgBoxStyle.Critical + MsgBoxStyle.OkOnly, "錯誤")
        End Try


    End Function


    Public Function ReadAllChatColour(ByVal installPath As String)

        Dim ini As New INIFile.INIFile(installPath + "\Game\DATA\Menu\HUD\defaults\Chat.ini")
        Dim currentACC As String = ini.GetString("Output", "FriendlyColorDefault", Nothing)

        Return currentACC
    End Function

    Public Function WriteAllChatColor(ByVal installPath As String, ByVal R As String, ByVal G As String, ByVal B As String)

        Try
            Dim ini As New INIFile.INIFile(installPath + "\Game\DATA\Menu\HUD\defaults\Chat.ini")
            Dim targetColour As String = " " + R + " " + G + " " + B
            ini.WriteString("Output", "AllChatColorDefault", targetColour)

        Catch ex As Exception
            MsgBox("修改失敗", MsgBoxStyle.Critical + MsgBoxStyle.OkOnly, "錯誤")
        End Try


    End Function

    Public Function ReadEnemyColor(ByVal installPath As String)

        Dim ini As New INIFile.INIFile(installPath + "\Game\DATA\Menu\HUD\defaults\Chat.ini")
        Dim currentEC As String = ini.GetString("Output", "EnemyColorDefault", Nothing)

        Return currentEC
    End Function

    Public Function WriteEnemyColor(ByVal installPath As String, ByVal R As String, ByVal G As String, ByVal B As String)

        Try
            Dim ini As New INIFile.INIFile(installPath + "\Game\DATA\Menu\HUD\defaults\Chat.ini")
            Dim targetColour As String = " " + R + " " + G + " " + B
            ini.WriteString("Output", "EnemyColorDefault", targetColour)

        Catch ex As Exception
            MsgBox("修改失敗", MsgBoxStyle.Critical + MsgBoxStyle.OkOnly, "錯誤")
        End Try


    End Function

    Public Function ReadTimestampColor(ByVal installPath As String)

        Dim ini As New INIFile.INIFile(installPath + "\Game\DATA\Menu\HUD\defaults\Chat.ini")
        Dim currentTC As String = ini.GetString("Output", "TimestampColorDefault", Nothing)

        Return currentTC
    End Function

    Public Function WriteTimestampColor(ByVal installPath As String, ByVal R As String, ByVal G As String, ByVal B As String)

        Try
            Dim ini As New INIFile.INIFile(installPath + "\Game\DATA\Menu\HUD\defaults\Chat.ini")
            Dim targetColour As String = " " + R + " " + G + " " + B
            ini.WriteString("Output", "TimestampColorDefault", targetColour)

        Catch ex As Exception
            MsgBox("修改失敗", MsgBoxStyle.Critical + MsgBoxStyle.OkOnly, "錯誤")
        End Try


    End Function

    Public Function ReadWhisperColor(ByVal installPath As String)

        Dim ini As New INIFile.INIFile(installPath + "\Game\DATA\Menu\HUD\defaults\Chat.ini")
        Dim currentWC As String = ini.GetString("Output", "WhisperColorDefault", Nothing)

        Return currentWC
    End Function

    Public Function WriteWhisperColor(ByVal installPath As String, ByVal R As String, ByVal G As String, ByVal B As String)

        Try
            Dim ini As New INIFile.INIFile(installPath + "\Game\DATA\Menu\HUD\defaults\Chat.ini")
            Dim targetColour As String = " " + R + " " + G + " " + B
            ini.WriteString("Output", "WhisperColorDefault", targetColour)

        Catch ex As Exception
            MsgBox("修改失敗", MsgBoxStyle.Critical + MsgBoxStyle.OkOnly, "錯誤")
        End Try


    End Function


    Public Function ReadFontSize(ByVal installPath As String)

        Dim ini As New INIFile.INIFile(installPath + "\Game\DATA\Menu\HUD\defaults\Chat.ini")
        Dim currentFS As String = ini.GetString("Input", "NormalSizeFont", Nothing)

        Return currentFS
    End Function

    Public Function WriteFontSize(ByVal installPath As String, ByVal FontSize As Integer)

        Try
            Dim ini As New INIFile.INIFile(installPath + "\Game\DATA\Menu\HUD\defaults\Chat.ini")
            Dim targetFontSize As Integer = FontSize
            ini.WriteString("Input", "NormalSizeFont", targetFontSize)
            ini.WriteString("Input", "EasternSizeFont", targetFontSize)
        Catch ex As Exception
            MsgBox("修改失敗", MsgBoxStyle.Critical + MsgBoxStyle.OkOnly, "錯誤")
        End Try


    End Function


    Public Function WriteTeamChatColour(ByVal installPath As String, ByVal R As String, ByVal G As String, ByVal B As String)

        Try
            Dim ini As New INIFile.INIFile(installPath + "\Game\DATA\Menu\HUD\defaults\Chat.ini")
            Dim targetColour As String = " " + R + " " + G + " " + B
            ini.WriteString("Output", "TeamChatColorDefault", targetColour)

        Catch ex As Exception
            MsgBox("修改失敗", MsgBoxStyle.Critical + MsgBoxStyle.OkOnly, "錯誤")
        End Try
    End Function
End Class
