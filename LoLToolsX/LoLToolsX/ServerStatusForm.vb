Public Class ServerStatusForm

    Dim normal As String = "正常"
    Dim timeout As String = "查詢逾時"

    Private Sub ServerStatusForm_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

    End Sub

    Sub Check1(ByVal StrMsg As String)


        Try
            If My.Computer.Network.Ping(StrMsg) Then
                Label001.Text = normal
                Label001.ForeColor = Color.Green
            Else
                Label001.Text = timeout
                Label001.ForeColor = Color.Red
            End If
        Catch ex As Exception

        End Try
    End Sub

    Sub Check2(ByVal StrMsg As String)


        Try
            If My.Computer.Network.Ping(StrMsg) Then
                Label002.Text = normal
                Label002.ForeColor = Color.Green
            Else
                Label002.Text = timeout
                Label002.ForeColor = Color.Red
            End If
        Catch ex As Exception

        End Try
    End Sub

    Sub Check3(ByVal StrMsg As String)


        Try
            If My.Computer.Network.Ping(StrMsg) Then
                Label003.Text = normal
                Label003.ForeColor = Color.Green
            Else
                Label003.Text = timeout
                Label003.ForeColor = Color.Red
            End If
        Catch ex As Exception

        End Try
    End Sub

    Sub Check4(ByVal StrMsg As String)


        Try
            If My.Computer.Network.Ping(StrMsg) Then
                Label004.Text = normal
                Label004.ForeColor = Color.Green
            Else
                Label004.Text = timeout
                Label004.ForeColor = Color.Red
            End If
        Catch ex As Exception

        End Try
    End Sub

    Sub Check5(ByVal StrMsg As String)


        Try
            If My.Computer.Network.Ping(StrMsg) Then
                Label005.Text = normal
                Label005.ForeColor = Color.Green
            Else
                Label005.Text = timeout
                Label005.ForeColor = Color.Red
            End If
        Catch ex As Exception

        End Try
    End Sub

    Sub Check6(ByVal StrMsg As String)


        Try
            If My.Computer.Network.Ping(StrMsg) Then
                Label006.Text = normal
                Label006.ForeColor = Color.Green
            Else
                Label006.Text = timeout
                Label006.ForeColor = Color.Red
            End If
        Catch ex As Exception

        End Try
    End Sub

    Sub Check7(ByVal StrMsg As String)


        Try

            If My.Computer.Network.Ping(StrMsg) Then
                Label007.ForeColor = Color.Green
                Label007.Text = normal
            Else
                Label007.ForeColor = Color.Red
                Label007.Text = timeout
            End If
        Catch ex As Exception

        End Try
    End Sub

    Sub Check8(ByVal StrMsg As String)


        Try
            If My.Computer.Network.Ping(StrMsg) Then
                Label008.ForeColor = Color.Green
                Label008.Text = normal
            Else
                Label008.ForeColor = Color.Red
                Label008.Text = timeout
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Check1("lol.garena.com")
        Check2("landing.leagueoflegends.com")
        Check3("lol.garena.com")
        Check4("www.leagueoflegends.co.kr")
        Check5("lq.eu.lol.riotgames.com")
        Check6("lq.eun1.lol.riotgames.com")
        Check7("lq.oc1.lol.riotgames.com")
        Check8("d2q6fdmnncz9b0.cloudfront.net")
    End Sub



End Class