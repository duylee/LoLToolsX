Public Class BakResLang

    ''' <summary>
    ''' 備份/還原 語言
    ''' </summary>

    Public Shared Sub BakResLang(ByVal bor As Integer, ByVal path As String)

        '備份
        If bor = 1 Then
            Try
                FileCopy(path + "\Air\locale.properties", "bak\lang\locale.properties")
                FileCopy(path + "\Air\css\fonts.swf", "bak\lang\fonts.swf")
                FileCopy(path + "\Air\css\fonts_zh_TW.swf", "bak\lang\fonts_zh_TW.swf")
                FileCopy(path + "\Game\DATA\Menu\fontconfig_en_US.txt", "bak\lang\fontconfig_en_US.txt")
                FileCopy(path + "\Game\DATA\Menu\fontconfig_zh_TW.txt", "bak\lang\fontconfig_zh_TW.txt")
                FileCopy(path + "\Game\DATA\CFG\Locale.cfg", "bak\lang\Locale.cfg")
                MsgBox("備份成功 ", MsgBoxStyle.Information + MsgBoxStyle.OkOnly, "提示")
            Catch ex As Exception
                MsgBox("備份失敗... " & vbCrLf & "錯誤信息: " & ex.Message, MsgBoxStyle.Critical + MsgBoxStyle.OkOnly, "錯誤")
            End Try
        End If

        '還原
        If bor = 2 Then
            Try
                FileCopy("bak\lang\locale.properties", path + "\Air\locale.properties")
                FileCopy("bak\lang\fonts.swf", path + "\Air\css\fonts.swf")
                FileCopy("bak\lang\fonts_zh_TW.swf", path + "\Air\css\fonts_zh_TW.swf")
                FileCopy("bak\lang\fontconfig_en_US.txt", path + "\Game\DATA\Menu\fontconfig_en_US.txt")
                FileCopy("bak\lang\fontconfig_zh_TW.txt", path + "\Game\DATA\Menu\fontconfig_zh_TW.txt")
                FileCopy("bak\lang\Locale.cfg", path + "\Game\DATA\CFG\Locale.cfg")
                MsgBox("還原成功 ", MsgBoxStyle.Information + MsgBoxStyle.OkOnly, "提示")
            Catch ex As Exception
                MsgBox("還原失敗... " & vbCrLf & "錯誤信息: " & ex.Message, MsgBoxStyle.Critical + MsgBoxStyle.OkOnly, "錯誤")
            End Try
        End If

        '刪除備份
        If bor = 3 Then
            Try
                My.Computer.FileSystem.DeleteFile("bak\lang\locale.properties")
                My.Computer.FileSystem.DeleteFile("bak\lang\fonts.swf")
                My.Computer.FileSystem.DeleteFile("bak\lang\fonts_zh_TW.swf")
                My.Computer.FileSystem.DeleteFile("bak\lang\fontconfig_en_US.txt")
                My.Computer.FileSystem.DeleteFile("bak\lang\fontconfig_zh_TW.txt")
                My.Computer.FileSystem.DeleteFile("bak\lang\Locale.cfg")
                MsgBox("刪除備份成功 ", MsgBoxStyle.Information + MsgBoxStyle.OkOnly, "提示")
            Catch ex As Exception
                MsgBox("刪除備份失敗: 沒有備份" & vbCrLf & "錯誤信息: " & ex.Message, MsgBoxStyle.Critical + MsgBoxStyle.OkOnly, "錯誤")
            End Try

        End If
    End Sub
End Class
