Public Class SwitchServer


    ''' <summary>
    ''' 伺服器切換
    ''' </summary>


    Public Shared Sub SwitchServer(ByVal lolproppath, ByVal server)
        If server = "台服" Then
            Try
                FileCopy("files\server_prop\lolt.properties", lolproppath)
                MsgBox("切換完成: " & server, MsgBoxStyle.OkOnly + MsgBoxStyle.Information, "提示")
            Catch ex As Exception
                MsgBox("切換失敗，請先關閉 LoL 再進行切換。" & vbCrLf & "錯誤信息: " & ex.Message, MsgBoxStyle.Critical + MsgBoxStyle.OkOnly, "錯誤")
            End Try
        End If

        If server = "SEA服" Then
            Try
                FileCopy("files\server_prop\lols.properties", lolproppath)
                MsgBox("切換完成: " & server, MsgBoxStyle.OkOnly + MsgBoxStyle.Information, "提示")
            Catch ex As Exception
                MsgBox("切換失敗，請先關閉 LoL 再進行切換。" & vbCrLf & "錯誤信息: " & ex.Message, MsgBoxStyle.Critical + MsgBoxStyle.OkOnly, "錯誤")
            End Try
        End If

        If server = "美服" Then
            Try
                FileCopy("files\server_prop\loln.properties", lolproppath)
                MsgBox("切換完成: " & server, MsgBoxStyle.OkOnly + MsgBoxStyle.Information, "提示")
            Catch ex As Exception
                MsgBox("切換失敗，請先關閉 LoL 再進行切換。" & vbCrLf & "錯誤信息: " & ex.Message, MsgBoxStyle.Critical + MsgBoxStyle.OkOnly, "錯誤")
            End Try
        End If

        If server = "EUW服" Then
            Try
                FileCopy("files\server_prop\lole.properties", lolproppath)
                MsgBox("切換完成: " & server, MsgBoxStyle.OkOnly + MsgBoxStyle.Information, "提示")
            Catch ex As Exception
                MsgBox("切換失敗，請先關閉 LoL 再進行切換。" & vbCrLf & "錯誤信息: " & ex.Message, MsgBoxStyle.Critical + MsgBoxStyle.OkOnly, "錯誤")
            End Try
        End If

        If server = "EUNE服" Then
            Try
                FileCopy("files\server_prop\loleune.properties", lolproppath)
                MsgBox("切換完成: " & server, MsgBoxStyle.OkOnly + MsgBoxStyle.Information, "提示")
            Catch ex As Exception
                MsgBox("切換失敗，請先關閉 LoL 再進行切換。" & vbCrLf & "錯誤信息: " & ex.Message, MsgBoxStyle.Critical + MsgBoxStyle.OkOnly, "錯誤")
            End Try
        End If

        If server = "韓服" Then
            Try
                FileCopy("files\server_prop\lolk.properties", lolproppath)
                MsgBox("切換完成: " & server, MsgBoxStyle.OkOnly + MsgBoxStyle.Information, "提示")
            Catch ex As Exception
                MsgBox("切換失敗，請先關閉 LoL 再進行切換。" & vbCrLf & "錯誤信息: " & ex.Message, MsgBoxStyle.Critical + MsgBoxStyle.OkOnly, "錯誤")
            End Try
        End If

        If server = "大洋洲服" Then
            Try
                FileCopy("files\server_prop\loloce.properties", lolproppath)
                MsgBox("切換完成: " & server, MsgBoxStyle.OkOnly + MsgBoxStyle.Information, "提示")
            Catch ex As Exception
                MsgBox("切換失敗，請先關閉 LoL 再進行切換。" & vbCrLf & "錯誤信息: " & ex.Message, MsgBoxStyle.Critical + MsgBoxStyle.OkOnly, "錯誤")
            End Try
        End If

        If server = "PBE服" Then
            Try
                FileCopy("files\server_prop\lolp.properties", lolproppath)
                MsgBox("切換完成: " & server, MsgBoxStyle.OkOnly + MsgBoxStyle.Information, "提示")
            Catch ex As Exception
                MsgBox("切換失敗，請先關閉 LoL 再進行切換。" & vbCrLf & "錯誤信息: " & ex.Message, MsgBoxStyle.Critical + MsgBoxStyle.OkOnly, "錯誤")
            End Try
        End If

    End Sub
End Class
