Public Class LobbyLandingEdit

    ''' <summary>
    ''' 大廳網頁修改
    ''' </summary>

    Public Shared Sub LobbyLandingEdit(ByVal lolpath As String, ByVal website As String)
       
        Try
            Dim sr As New System.IO.StreamReader(lolpath + "\Air\lol.properties")
            Dim filecontent As String = sr.ReadToEnd().Replace("lobbyLandingURL", "#lobbyLandingURL")
            sr.Close()
            Dim sw As New System.IO.StreamWriter(lolpath + "\Air\lol.properties", False)
            sw.Write(filecontent)
            sw.Flush()
            sw.Close()
            My.Computer.FileSystem.WriteAllText(lolpath + "\Air\lol.properties", vbCrLf + "lobbyLandingURL=" + "http://" + website, True)
            MsgBox("修改成功!" + vbCrLf + website, MsgBoxStyle.Information + MsgBoxStyle.OkOnly, "提示")
        Catch ex As Exception
            MsgBox("修改失敗...", MsgBoxStyle.Critical + MsgBoxStyle.OkOnly, "提示")
        End Try


    End Sub

    Public Shared Sub LobbyLandingEditNA(ByVal lolpath As String, ByVal website As String, ByVal naairVer As String)
       
        Try
            Dim sr As New System.IO.StreamReader(lolpath + "\RADS\projects\lol_air_client\releases\" + naairVer + "\deploy\lol.properties")
            Dim filecontent As String = sr.ReadToEnd().Replace("lobbyLandingURL", "#lobbyLandingURL")
            sr.Close()
            Dim sw As New System.IO.StreamWriter(lolpath + "\RADS\projects\lol_air_client\releases\" + naairVer + "\deploy\lol.properties", False)
            sw.Write(filecontent)
            sw.Flush()
            sw.Close()
            My.Computer.FileSystem.WriteAllText(lolpath + "\RADS\projects\lol_air_client\releases\" + naairVer + "\deploy\lol.properties", vbCrLf + "lobbyLandingURL=" + "http://" + website, True)
            MsgBox("修改成功!" + vbCrLf + website, MsgBoxStyle.Information + MsgBoxStyle.OkOnly, "提示")
        Catch ex As Exception
            MsgBox("修改失敗...", MsgBoxStyle.Critical + MsgBoxStyle.OkOnly, "提示")
        End Try


    End Sub
End Class
