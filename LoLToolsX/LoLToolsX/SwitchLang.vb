Imports System.IO

Public Class SwitchLang


    Public Shared Sub SwitchLang(ByVal type As Integer, ByVal path As String)


        '大廳
        If type = 1 Then
            Try
                FileCopy("files\lang\cht\lobby\locale.properties", path + "\Air\locale.properties")
                FileCopy("files\lang\cht\lobby\fonts.swf", path + "\Air\css\fonts.swf")
                FileCopy("files\lang\cht\lobby\fonts_zh_TW.swf", path + "\Air\css\fonts_zh_TW.swf")
                MsgBox("大廳語言切換完成: 中文 ", MsgBoxStyle.OkOnly + MsgBoxStyle.Information, "提示")
            Catch ex As Exception
                MsgBox("切換失敗，請先關閉 LoL 再進行切換。" & vbCrLf & "錯誤信息: " & ex.Message, MsgBoxStyle.Critical + MsgBoxStyle.OkOnly, "錯誤")
            End Try
        End If

        If type = 2 Then
            Try
                FileCopy("files\lang\eng\lobby\locale.properties", path + "\Air\locale.properties")
                FileCopy("files\lang\eng\lobby\fonts.swf", path + "\Air\css\fonts.swf")
                MsgBox("大廳語言切換完成: 英文 ", MsgBoxStyle.OkOnly + MsgBoxStyle.Information, "提示")
            Catch ex As Exception
                MsgBox("切換失敗，請先關閉 LoL 再進行切換。" & vbCrLf & "錯誤信息: " & ex.Message, MsgBoxStyle.Critical + MsgBoxStyle.OkOnly, "錯誤")
            End Try


        End If


        '遊戲
        If type = 3 Then
            Try
                FileCopy("files\lang\cht\game\fontconfig_en_US.txt", path + "\Game\DATA\Menu\fontconfig_en_US.txt")
                FileCopy("files\lang\cht\game\fontconfig_zh_TW.txt", path + "\Game\DATA\Menu\fontconfig_zh_TW.txt")
                FileCopy("files\lang\cht\game\Locale.cfg", path + "\Game\DATA\CFG\Locale.cfg")
                MsgBox("遊戲語言切換完成: 中文 ", MsgBoxStyle.OkOnly + MsgBoxStyle.Information, "提示")
            Catch ex As Exception
                MsgBox("切換失敗，請先關閉 LoL 再進行切換。" & vbCrLf & "錯誤信息: " & ex.Message, MsgBoxStyle.Critical + MsgBoxStyle.OkOnly, "錯誤")
            End Try
        End If

        If type = 4 Then
            Try
                FileCopy("files\lang\eng\game\fontconfig_en_US.txt", path + "\Game\DATA\Menu\fontconfig_en_US.txt")
                FileCopy("files\lang\eng\game\fontconfig_zh_TW.txt", path + "\Game\DATA\Menu\fontconfig_zh_TW.txt")
                FileCopy("files\lang\eng\game\Locale.cfg", path + "\Game\DATA\CFG\Locale.cfg")
                MsgBox("遊戲語言切換完成: 英文 ", MsgBoxStyle.OkOnly + MsgBoxStyle.Information, "提示")
            Catch ex As Exception
                MsgBox("切換失敗，請先關閉 LoL 再進行切換。" & vbCrLf & "錯誤信息: " & ex.Message, MsgBoxStyle.Critical + MsgBoxStyle.OkOnly, "錯誤")
            End Try
        End If

    End Sub
End Class
