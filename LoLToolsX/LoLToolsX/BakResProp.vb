Public Class BakResProp

    ''' <summary>
    ''' 備份/還原 lol.properties
    ''' </summary>

    Public Shared Sub BakResProp(ByVal borr As Integer, ByVal path As String)

        '備份
        If borr = 1 Then
            Try
                FileCopy(path, "bak\server_prop\lol.properties")
                MsgBox("備份成功 ", MsgBoxStyle.Information + MsgBoxStyle.OkOnly, "提示")
            Catch ex As Exception
                MsgBox("備份失敗... " & vbCrLf & "錯誤信息: " & ex.Message, MsgBoxStyle.Critical + MsgBoxStyle.OkOnly, "錯誤")
            End Try

        End If

        '還原
        If borr = 2 Then
            Try
                FileCopy("bak\server_prop\lol.properties", path)
                MsgBox("還原成功 ", MsgBoxStyle.Information + MsgBoxStyle.OkOnly, "提示")
            Catch ex As Exception
                MsgBox("還原失敗... " & vbCrLf & "錯誤信息: " & ex.Message, MsgBoxStyle.Critical + MsgBoxStyle.OkOnly, "錯誤")
            End Try
        End If

        '刪除備份
        If borr = 3 Then
            Try
                My.Computer.FileSystem.DeleteFile("bak\server_prop\lol.properties")
                MsgBox("刪除備份成功 ", MsgBoxStyle.Information + MsgBoxStyle.OkOnly, "提示")
            Catch ex As Exception
                MsgBox("刪除備份失敗: 沒有備份" & vbCrLf & "錯誤信息: " & ex.Message, MsgBoxStyle.Critical + MsgBoxStyle.OkOnly, "錯誤")
            End Try

        End If
    End Sub
End Class
