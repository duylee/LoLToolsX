Public Class ChatEdit

    Dim ini As New INIFile.INIFile(My.Application.Info.DirectoryPath + "\config.ini")
    Private Sub ChatEdit_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        R.Text = ini.GetInteger("ChatColour", "R", Nothing)
        B.Text = ini.GetInteger("ChatColour", "B", Nothing)
        G.Text = ini.GetInteger("ChatColour", "G", Nothing)

        R2.Text = ini.GetInteger("ChatColour", "R2", Nothing)
        B2.Text = ini.GetInteger("ChatColour", "B2", Nothing)
        G2.Text = ini.GetInteger("ChatColour", "G2", Nothing)

        R3.Text = ini.GetInteger("ChatColour", "R3", Nothing)
        B3.Text = ini.GetInteger("ChatColour", "B3", Nothing)
        G3.Text = ini.GetInteger("ChatColour", "G3", Nothing)

        R4.Text = ini.GetInteger("ChatColour", "R4", Nothing)
        B4.Text = ini.GetInteger("ChatColour", "B4", Nothing)
        G4.Text = ini.GetInteger("ChatColour", "G4", Nothing)

        R5.Text = ini.GetInteger("ChatColour", "R5", Nothing)
        B5.Text = ini.GetInteger("ChatColour", "B5", Nothing)
        G5.Text = ini.GetInteger("ChatColour", "G5", Nothing)

        RS.Text = ini.GetInteger("ChatColour", "RS", Nothing)
        BS.Text = ini.GetInteger("ChatColour", "BS", Nothing)
        GS.Text = ini.GetInteger("ChatColour", "GS", Nothing)

        FontSize1.Text = ini.GetInteger("ChatFontSize", "FontSize", Nothing)

    End Sub

    Private Sub Button22_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button22.Click
        Try
                Dim cc As New ChatColour.ChatColour
                cc.WriteFriendlyColour(installPath, R.Text, G.Text, B.Text)
                ini.WriteInteger("ChatColour", "R", R.Text)
                ini.WriteInteger("ChatColour", "G", G.Text)
                ini.WriteInteger("ChatColour", "B", B.Text)
                MsgBox("修改成功!", MsgBoxStyle.Information + MsgBoxStyle.OkOnly, "提示")
        Catch ex As Exception
            MsgBox("修改失敗", MsgBoxStyle.Critical + MsgBoxStyle.OkOnly, "錯誤")
        End Try

    End Sub


    Private Sub Button23_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button23.Click
        Try
            Dim cc As New ChatColour.ChatColour
            ini.WriteInteger("ChatColour", "R", 0)
            ini.WriteInteger("ChatColour", "G", 255)
            ini.WriteInteger("ChatColour", "B", 0)
            cc.WriteFriendlyColour(installPath, 0, 255, 0)
            R.Text = 0
            G.Text = 255
            B.Text = 0
            MsgBox("恢復成功!", MsgBoxStyle.Information + MsgBoxStyle.OkOnly, "提示")
        Catch ex As Exception
            MsgBox("恢復失敗", MsgBoxStyle.Critical + MsgBoxStyle.OkOnly, "錯誤")
        End Try

    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        Try
            Dim cc As New ChatColour.ChatColour
            ini.WriteInteger("ChatColour", "R2", R2.Text)
            ini.WriteInteger("ChatColour", "G2", G2.Text)
            ini.WriteInteger("ChatColour", "B2", B2.Text)
            cc.WriteAllChatColor(installPath, R2.Text, G2.Text, B2.Text)
            MsgBox("修改成功!", MsgBoxStyle.Information + MsgBoxStyle.OkOnly, "提示")
        Catch ex As Exception
            MsgBox("修改失敗", MsgBoxStyle.Critical + MsgBoxStyle.OkOnly, "錯誤")
        End Try

    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Try
            Dim cc As New ChatColour.ChatColour
            ini.WriteInteger("ChatColour", "R2", 255)
            ini.WriteInteger("ChatColour", "G2", 255)
            ini.WriteInteger("ChatColour", "B2", 255)
            cc.WriteAllChatColor(installPath, 255, 255, 255)
            R2.Text = 255
            G2.Text = 255
            B2.Text = 255
            MsgBox("恢復成功!", MsgBoxStyle.Information + MsgBoxStyle.OkOnly, "提示")
        Catch ex As Exception
            MsgBox("恢復失敗", MsgBoxStyle.Critical + MsgBoxStyle.OkOnly, "錯誤")
        End Try

    End Sub

    Private Sub Button4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button4.Click
        Try
            Dim cc As New ChatColour.ChatColour
            ini.WriteInteger("ChatColour", "R3", R3.Text)
            ini.WriteInteger("ChatColour", "G3", G3.Text)
            ini.WriteInteger("ChatColour", "B3", B3.Text)
            cc.WriteEnemyColor(installPath, R3.Text, G3.Text, B3.Text)
            MsgBox("修改成功!", MsgBoxStyle.Information + MsgBoxStyle.OkOnly, "提示")
        Catch ex As Exception
            MsgBox("修改失敗", MsgBoxStyle.Critical + MsgBoxStyle.OkOnly, "錯誤")
        End Try

    End Sub

    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
        Try
            Dim cc As New ChatColour.ChatColour
            ini.WriteInteger("ChatColour", "R3", 255)
            ini.WriteInteger("ChatColour", "G3", 51)
            ini.WriteInteger("ChatColour", "B3", 51)
            cc.WriteEnemyColor(installPath, 255, 51, 51)
            R3.Text = 255
            G3.Text = 51
            B3.Text = 51
            MsgBox("恢復成功!", MsgBoxStyle.Information + MsgBoxStyle.OkOnly, "提示")
        Catch ex As Exception
            MsgBox("恢復失敗", MsgBoxStyle.Critical + MsgBoxStyle.OkOnly, "錯誤")
        End Try

    End Sub

    Private Sub Button6_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button6.Click
        Try
            Dim cc As New ChatColour.ChatColour
            ini.WriteInteger("ChatColour", "R4", R4.Text)
            ini.WriteInteger("ChatColour", "G4", G4.Text)
            ini.WriteInteger("ChatColour", "B4", B4.Text)
            cc.WriteWhisperColor(installPath, R4.Text, G4.Text, B4.Text)
            MsgBox("修改成功!", MsgBoxStyle.Information + MsgBoxStyle.OkOnly, "提示")
        Catch ex As Exception
            MsgBox("修改失敗", MsgBoxStyle.Critical + MsgBoxStyle.OkOnly, "錯誤")
        End Try

    End Sub

    Private Sub Button5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button5.Click
        Try
            Dim cc As New ChatColour.ChatColour
            ini.WriteInteger("ChatColour", "R4", 241)
            ini.WriteInteger("ChatColour", "G4", 231)
            ini.WriteInteger("ChatColour", "B4", 22)
            cc.WriteWhisperColor(installPath, 241, 231, 22)
            R4.Text = 241
            G4.Text = 231
            B4.Text = 22
            MsgBox("恢復成功!", MsgBoxStyle.Information + MsgBoxStyle.OkOnly, "提示")
        Catch ex As Exception
            MsgBox("恢復失敗", MsgBoxStyle.Critical + MsgBoxStyle.OkOnly, "錯誤")
        End Try

    End Sub

    Private Sub Button8_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button8.Click
        Try
            Dim cc As New ChatColour.ChatColour
            ini.WriteInteger("ChatColour", "R5", R5.Text)
            ini.WriteInteger("ChatColour", "G5", G5.Text)
            ini.WriteInteger("ChatColour", "B5", B5.Text)
            cc.WriteTimestampColor(installPath, R5.Text, G5.Text, B5.Text)
            MsgBox("修改成功!", MsgBoxStyle.Information + MsgBoxStyle.OkOnly, "提示")
        Catch ex As Exception
            MsgBox("修改失敗", MsgBoxStyle.Critical + MsgBoxStyle.OkOnly, "錯誤")
        End Try

    End Sub

    Private Sub Button7_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button7.Click
        Try
            Dim cc As New ChatColour.ChatColour
            ini.WriteInteger("ChatColour", "R5", 220)
            ini.WriteInteger("ChatColour", "G5", 220)
            ini.WriteInteger("ChatColour", "B5", 220)
            cc.WriteTimestampColor(installPath, 220, 220, 220)
            R5.Text = 220
            G5.Text = 220
            B5.Text = 220
            MsgBox("恢復成功!", MsgBoxStyle.Information + MsgBoxStyle.OkOnly, "提示")
        Catch ex As Exception
            MsgBox("恢復失敗", MsgBoxStyle.Critical + MsgBoxStyle.OkOnly, "錯誤")
        End Try

    End Sub

    Private Sub Button10_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button10.Click
        Try
            Dim cc As New ChatColour.ChatColour
            ini.WriteInteger("ChatFontSize", "FontSize", FontSize1.Text)
            cc.WriteFontSize(installPath, FontSize1.Text)
            MsgBox("修改成功!", MsgBoxStyle.Information + MsgBoxStyle.OkOnly, "提示")
        Catch ex As Exception
            MsgBox("修改失敗", MsgBoxStyle.Critical + MsgBoxStyle.OkOnly, "錯誤")
        End Try
    End Sub

    Private Sub Button9_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button9.Click
        Try
            Dim cc As New ChatColour.ChatColour
            ini.WriteInteger("ChatFontSize", "FontSize", 20)
            cc.WriteFontSize(installPath, 20)
            FontSize1.Text = 20
            MsgBox("恢復成功!", MsgBoxStyle.Information + MsgBoxStyle.OkOnly, "提示")
        Catch ex As Exception
            MsgBox("恢復失敗", MsgBoxStyle.Critical + MsgBoxStyle.OkOnly, "錯誤")
        End Try
    End Sub

    Private Sub Button11_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button11.Click
        Try
            FileCopy(installPath + "\Game\DATA\Menu\HUD\defaults\Chat.ini", "bak\Chat\Chat.ini")
            MsgBox("備份成功!", MsgBoxStyle.Information + MsgBoxStyle.OkOnly, "提示")
        Catch ex As Exception
            MsgBox("備份失敗", MsgBoxStyle.Critical + MsgBoxStyle.OkOnly, "錯誤")
        End Try
    End Sub

    Private Sub Button12_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button12.Click
        Try
            FileCopy("bak\Chat\Chat.ini", installPath + "\Game\DATA\Menu\HUD\defaults\Chat.ini")
            MsgBox("還原成功!", MsgBoxStyle.Information + MsgBoxStyle.OkOnly, "提示")
        Catch ex As Exception
            MsgBox("還原失敗", MsgBoxStyle.Critical + MsgBoxStyle.OkOnly, "錯誤")
        End Try
    End Sub

    Private Sub Button13_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button13.Click
        Try
            Dim cc As New ChatColour.ChatColour
            ini.WriteInteger("ChatColour", "R", 0)
            ini.WriteInteger("ChatColour", "G", 255)
            ini.WriteInteger("ChatColour", "B", 0)
            cc.WriteFriendlyColour(installPath, 0, 255, 0)
            R.Text = 0
            G.Text = 255
            B.Text = 0

            ini.WriteInteger("ChatColour", "R2", 255)
            ini.WriteInteger("ChatColour", "G2", 255)
            ini.WriteInteger("ChatColour", "B2", 255)
            cc.WriteAllChatColor(installPath, 255, 255, 255)
            R2.Text = 255
            G2.Text = 255
            B2.Text = 255

            ini.WriteInteger("ChatColour", "R3", 255)
            ini.WriteInteger("ChatColour", "G3", 51)
            ini.WriteInteger("ChatColour", "B3", 51)
            cc.WriteEnemyColor(installPath, 255, 51, 51)
            R3.Text = 255
            G3.Text = 51
            B3.Text = 51

            ini.WriteInteger("ChatColour", "R4", 241)
            ini.WriteInteger("ChatColour", "G4", 231)
            ini.WriteInteger("ChatColour", "B4", 22)
            cc.WriteWhisperColor(installPath, 241, 231, 22)
            R4.Text = 241
            G4.Text = 231
            B4.Text = 22

            ini.WriteInteger("ChatColour", "R5", 220)
            ini.WriteInteger("ChatColour", "G5", 220)
            ini.WriteInteger("ChatColour", "B5", 220)
            cc.WriteTimestampColor(installPath, 220, 220, 220)
            R5.Text = 220
            G5.Text = 220
            B5.Text = 220

            ini.WriteInteger("ChatColour", "RS", 255)
            ini.WriteInteger("ChatColour", "GS", 255)
            ini.WriteInteger("ChatColour", "BS", 255)
            cc.WriteTeamChatColour(installPath, 255, 255, 255)
            RS.Text = 255
            GS.Text = 255
            BS.Text = 255

            ini.WriteInteger("ChatFontSize", "FontSize", 20)
            cc.WriteFontSize(installPath, 20)
            FontSize1.Text = 20

            MsgBox("一鍵恢復成功!", MsgBoxStyle.Information + MsgBoxStyle.OkOnly, "提示")
        Catch ex As Exception
            MsgBox("一鍵恢復失敗", MsgBoxStyle.Critical + MsgBoxStyle.OkOnly, "錯誤")
        End Try
    End Sub



    Private Sub Button15_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button15.Click
        'ColorDialog1.ShowDialog()
        If ColorDialog1.ShowDialog = Windows.Forms.DialogResult.OK Then
            R.Text = ColorDialog1.Color.R
            G.Text = ColorDialog1.Color.G
            B.Text = ColorDialog1.Color.B
        End If

    End Sub

    Private Sub Button19_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button19.Click
        'ColorDialog1.ShowDialog()
        If ColorDialog1.ShowDialog = Windows.Forms.DialogResult.OK Then

            R2.Text = ColorDialog1.Color.R
            G2.Text = ColorDialog1.Color.G
            B2.Text = ColorDialog1.Color.B
        End If

    End Sub

    Private Sub Button18_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button18.Click
        'ColorDialog1.ShowDialog()
        If ColorDialog1.ShowDialog = Windows.Forms.DialogResult.OK Then

            R3.Text = ColorDialog1.Color.R
            G3.Text = ColorDialog1.Color.G
            B3.Text = ColorDialog1.Color.B
        End If

    End Sub

    Private Sub Button16_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button16.Click
        'ColorDialog1.ShowDialog()
        If ColorDialog1.ShowDialog = Windows.Forms.DialogResult.OK Then

            R4.Text = ColorDialog1.Color.R
            G4.Text = ColorDialog1.Color.G
            B4.Text = ColorDialog1.Color.B
        End If

    End Sub

    Private Sub Button17_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button17.Click
        'ColorDialog1.ShowDialog()
        If ColorDialog1.ShowDialog = Windows.Forms.DialogResult.OK Then

            R5.Text = ColorDialog1.Color.R
            G5.Text = ColorDialog1.Color.G
            B5.Text = ColorDialog1.Color.B
        End If

    End Sub

    Private Sub ChatEdit_Close(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.FormClosed
        Me.Dispose()
        Me.Close()
    End Sub

    Private Sub Button14_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button14.Click
        'ColorDialog1.ShowDialog()
        If ColorDialog1.ShowDialog = Windows.Forms.DialogResult.OK Then

            RS.Text = ColorDialog1.Color.R
            GS.Text = ColorDialog1.Color.G
            BS.Text = ColorDialog1.Color.B
        End If


    End Sub

    Private Sub Button21_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button21.Click
        Try
            Dim cc As New ChatColour.ChatColour
            cc.WriteTeamChatColour(installPath, RS.Text, GS.Text, BS.Text)
            ini.WriteInteger("ChatColour", "RS", RS.Text)
            ini.WriteInteger("ChatColour", "GS", GS.Text)
            ini.WriteInteger("ChatColour", "BS", BS.Text)
            MsgBox("修改成功!", MsgBoxStyle.Information + MsgBoxStyle.OkOnly, "提示")
        Catch ex As Exception
            MsgBox("修改失敗", MsgBoxStyle.Critical + MsgBoxStyle.OkOnly, "錯誤")
        End Try
    End Sub

    Private Sub Button20_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button20.Click
        Try
            Dim cc As New ChatColour.ChatColour
            ini.WriteInteger("ChatColour", "RS", 255)
            ini.WriteInteger("ChatColour", "GS", 255)
            ini.WriteInteger("ChatColour", "BS", 255)
            cc.WriteTeamChatColour(installPath, 255, 255, 255)
            RS.Text = 255
            GS.Text = 255
            BS.Text = 255
            MsgBox("恢復成功!", MsgBoxStyle.Information + MsgBoxStyle.OkOnly, "提示")
        Catch ex As Exception
            MsgBox("恢復失敗", MsgBoxStyle.Critical + MsgBoxStyle.OkOnly, "錯誤")
        End Try
    End Sub
End Class