Imports System.Net
Imports System.IO
Imports System.Threading

'Imports StartGame
'Imports SwitchLang
'Imports INIFile
'Imports Update


Public Class TwTools

    Public Shared installPath As String = ""
    Public Shared lolVersion As String
    Public Shared lolprop As String
    Public Shared targetsite As String
    Public Shared hudPath As String
    ' Public Shared folderPath As String = ""             'SwitchSound






    Public Sub TwTools_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load







        NotifyIcon1.Visible = False

        Wait.Close()

        '讀取 config.ini 
        Dim ini As New INIFile.INIFile(My.Application.Info.DirectoryPath + "\config.ini")

        If installPath = "" Then
            installPath = ini.GetString("LoLPath", "TwPath", Nothing)
        End If



        '從登錄碼尋找LOL安裝路徑 2
        If installPath = "" Then
            If My.Computer.Registry.GetValue("HKEY_LOCAL_MACHINE\SOFTWARE\Garena\LoLTW", "Path", Nothing) Is Nothing Then

            Else

                If My.Computer.Registry.GetValue("HKEY_LOCAL_MACHINE\SOFTWARE\Garena\LoLTW", "Path", Nothing).Contains("LoLTW") Then
                    installPath = My.Computer.Registry.GetValue("HKEY_LOCAL_MACHINE\SOFTWARE\Garena\LoLTW", "Path", Nothing)
                End If
            End If
        End If

        If installPath = "" Then
            If My.Computer.Registry.GetValue("HKEY_CURRENT_USER\SOFTWARE\Garena\LoLTW", "Path", Nothing) Is Nothing Then

            Else
                If My.Computer.Registry.GetValue("HKEY_CURRENT_USER\SOFTWARE\Garena\LoLTW", "Path", Nothing).Contains("LoLTW") Then
                    installPath = My.Computer.Registry.GetValue("HKEY_CURRENT_USER\SOFTWARE\Garena\LoLTW", "Path", Nothing)
                End If
            End If
        End If

        If installPath = "" Then
            MsgBox(" 找不到LoL安裝路徑，請手動選擇 GemeData\Apps\LoLTW 目錄", MsgBoxStyle.Information + MsgBoxStyle.OkOnly, "提示")
            Me.FolderBrowserDialog1.ShowDialog()
            installPath = Me.FolderBrowserDialog1.SelectedPath
        End If


        If installPath.Contains("LoLTW") <> True Then


            MsgBox("LoL安裝目錄選擇錯誤，按'確定'重新選擇", MsgBoxStyle.OkCancel + MsgBoxStyle.Information, Nothing)

            '如果按下確定的話'
            FolderBrowserDialog1.ShowDialog()
            installPath = FolderBrowserDialog1.SelectedPath


        End If


        If installPath = "" Then


            MsgBox("LoL安裝目錄選擇錯誤，按'確定'重新選擇", MsgBoxStyle.OkCancel + MsgBoxStyle.Information, Nothing)

            If MsgBoxResult.Ok = True Then                       '如果按下確定的話'
                FolderBrowserDialog1.ShowDialog()
                installPath = FolderBrowserDialog1.SelectedPath
            ElseIf MsgBoxResult.Cancel = True Then
                Application.Exit()
            End If


        End If




        '把 installPath 存入 config.ini
        If ini.GetString("LoLPath", "TwPath", Nothing) = "" Then

            If installPath.Contains("LoLTW") Then
                ini.WriteString("LoLPath", "TwPath", installPath)

            End If
        End If







        'LOL安裝目錄
        If installPath <> "" Then
            PathLabel.Visible = True
            PathLabel.Text = installPath
        Else
            PathLabel.Text = "未知"
        End If

        '版本資訊
        ini.WriteString("LoLToolsX", "version", Format("版本 {0}", My.Application.Info.Version.ToString))
        toolsVersion.Text = Format("版本 {0}", My.Application.Info.Version.ToString)       'LoLToolsX版本

        Dim airVersion As String


        Try
            lolVersion = My.Computer.FileSystem.ReadAllText(installPath + "\Game\client.ver")  'LOL遊戲版本
            lolVersion.Replace(" ", "")
            lolVersion.Replace(vbCrLf, "")

            airVersion = My.Computer.FileSystem.ReadAllText(installPath + "\lol.version")  'Air版本
            airVersion.Replace(" ", "")
            lolVersion.Replace(vbCrLf, "")

            LoLVersionLabel.Text = lolVersion + " - " + airVersion
        Catch ex As Exception
            LoLVersionLabel.Text = "未知版本"
        End Try


        '重要!! 取得目前伺服器地區 SUB
        CheckPropFirstLine()

        Try
            WebBrowser1.Navigate("http://lolnx.pixub.com/loltoolsx/stat.html")
        Catch ex As Exception

        End Try




        websiteIn.Text = ""

    End Sub



    Public Sub CheckPropFirstLine()

        Try
            '取得目前伺服器地區
            If installPath.Contains("LoLTW") Then
                lolprop = installPath + "\Air\lol.properties"
                Dim fileReader As System.IO.StreamReader
                fileReader =
                My.Computer.FileSystem.OpenTextFileReader(lolprop)
                Dim stringReader As String
                stringReader = fileReader.ReadLine()
                serverLocation.Text = stringReader

                If stringReader = "host=prodtw.lol.garenanow.com" Then
                    'lolLocation = "台服"
                    serverLocation.Text = "台服"
                ElseIf stringReader = "host=prod.na1.lol.riotgames.com" Then
                    'lolLocation = "美服"
                    serverLocation.Text = "美服"
                ElseIf stringReader = "host=prod.eu.lol.riotgames.com" Then
                    'lolLocation = "EUW服"
                    serverLocation.Text = "EUW服"
                ElseIf stringReader = "regionTag=eune" Then
                    'lolLocation = "EUNE服"
                    serverLocation.Text = "EUNE服"
                ElseIf stringReader = "host=prod.oc1.lol.riotgames.com" Then
                    'lolLocation = "大洋洲服"
                    serverLocation.Text = "大洋洲服"
                ElseIf stringReader = "host=prod.lol.garenanow.com" Then
                    'lolLocation = "SEA服"
                    serverLocation.Text = "SEA服"
                ElseIf stringReader = "host=prod.pbe1.lol.riotgames.com" Then
                    'lolLocation = "PBE服"
                    serverLocation.Text = "PBE服"
                ElseIf stringReader = "host=prod.kr.lol.riotgames.com" Then
                    'lolLocation = "韓服"
                    serverLocation.Text = "韓服"
                Else
                    'lolLocation = "未知"
                    serverLocation.Text = "未知"
                End If

                '關閉 fileReader 以免無法存取 lol.properties
                fileReader.Close()


            End If

        Catch ex As Exception
            MessageBox.Show("發生錯誤 按確定關閉程式")
            Application.Exit()
        End Try

    End Sub



    Private Sub TwTools_Close(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.FormClosing
        Application.Exit()
    End Sub

    Private Sub PictureBox1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PictureBox1.Click

    End Sub

    Private Sub serverStatus_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles serverStatus.Click
        ServerStatusForm.Show()
    End Sub







    Private Sub Button10_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles updateButton.Click

        Wait.Show()
        '檢查更新
        CheckUpdate1.CheckUpdate()
        Wait.Close()


    End Sub

    Public Shared Sub startLOL_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles startLoL.Click
        Try
            If TwTools.serverLocation.Text = "台服" Then
                StartGame.StartLoLTW()
            ElseIf TwTools.serverLocation.Text = "SEA服" Then


                StartGame.StartLoLTW()
            Else


                StartGame.StartLoL(installPath + "\lol.exe")


            End If

            TwTools.Hide()
            TwTools.ShowInTaskbar = False

            TwTools.NotifyIcon1.Visible = True
            TwTools.NotifyIcon1.ShowBalloonTip(500, "", "遊戲啟動成功", ToolTipIcon.None)

        Catch ex As Exception
            MsgBox("遊戲啟動失敗", MsgBoxStyle.Critical + MsgBoxStyle.OkOnly, "錯誤")
        End Try




    End Sub


    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        serverLocation.Text = "台服"
        SwitchServer.SwitchServer(lolprop, "台服")
    End Sub

    Private Sub Button6_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button6.Click
        serverLocation.Text = "SEA服"
        SwitchServer.SwitchServer(lolprop, "SEA服")
    End Sub

    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
        serverLocation.Text = "大洋洲服"
        SwitchServer.SwitchServer(lolprop, "大洋洲服")
    End Sub

    Private Sub Button8_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button8.Click
        serverLocation.Text = "美服"
        SwitchServer.SwitchServer(lolprop, "美服")
    End Sub

    Private Sub Button5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button5.Click
        serverLocation.Text = "EUW服"
        SwitchServer.SwitchServer(lolprop, "EUW服")
    End Sub


    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        serverLocation.Text = "PBE服"
        SwitchServer.SwitchServer(lolprop, "PBE服")
    End Sub

    Private Sub Button7_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button7.Click
        serverLocation.Text = "韓服"
        SwitchServer.SwitchServer(lolprop, "韓服")
    End Sub

    Private Sub Button4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button4.Click
        serverLocation.Text = "EUNE服"
        SwitchServer.SwitchServer(lolprop, "EUNE服")
    End Sub

    Public Shared Sub backProp_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles backProp.Click
        BakResProp.BakResProp(1, lolprop)
    End Sub

    Public Shared Sub restoneProp_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles restoneProp.Click
        BakResProp.BakResProp(2, lolprop)
    End Sub

    Private Sub delBakProp_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles delBakProp.Click
        BakResProp.BakResProp(3, lolprop)
    End Sub

    Private Sub lChin_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lChin.Click

        SwitchLang.SwitchLang(1, installPath)

    End Sub

    Private Sub lEng_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lEng.Click

        SwitchLang.SwitchLang(2, installPath)

    End Sub

    Private Sub gChin_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles gChin.Click

        SwitchLang.SwitchLang(3, installPath)

    End Sub

    Private Sub gEng_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles gEng.Click

        SwitchLang.SwitchLang(4, installPath)

    End Sub

    Private Sub BakLang_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BakLang.Click
        BakResLang.BakResLang(1, installPath)
    End Sub

    Private Sub ResLang_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ResLang.Click
        BakResLang.BakResLang(2, installPath)
    End Sub

    Private Sub delLangBak_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles delLangBak.Click
        BakResLang.BakResLang(3, installPath)
    End Sub

    Private Sub Button10_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button10.Click
        Try


            FolderBrowserDialog2.ShowDialog()

            If FolderBrowserDialog2.SelectedPath().Contains("Sound") Then
                tbPath.Text = FolderBrowserDialog2.SelectedPath()
            Else
                MsgBox("請選擇正確的Sound資料夾", MsgBoxStyle.Critical + MsgBoxStyle.OkOnly, "錯誤")
            End If
        Catch ex As Exception

        End Try

    End Sub

    Private Sub installSound_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles installSound.Click


        If FolderBrowserDialog2.SelectedPath().Contains("Sound") Then
            SwitchSound.SwitchSound("lobby", FolderBrowserDialog2.SelectedPath(), installPath)
        Else
            MsgBox("路徑選擇錯誤 ", MsgBoxStyle.Critical + MsgBoxStyle.OkOnly, "提示")
        End If



    End Sub

    Private Sub Button11_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button11.Click
        If FolderBrowserDialog2.SelectedPath().Contains("Sound") Then
            SwitchSound.SwitchSound("game", FolderBrowserDialog2.SelectedPath(), installPath)
        Else
            MsgBox("路徑選擇錯誤 ", MsgBoxStyle.Critical + MsgBoxStyle.OkOnly, "提示")
        End If
    End Sub

    Private Sub Button12_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button12.Click
        Wait.Show()
        Wait.pbW1.Value = 0

        Try
            My.Computer.FileSystem.CopyDirectory(installPath + "\Air\assets\sounds", "bak\sound\sound", True)
            Wait.pbW1.Value = 25
            FileCopy(installPath + "\Game\DATA\Sounds\FMOD\VOBank_zh_TW.fsb", "bak\sound\VOBank_zh_TW.fsb")
            Wait.pbW1.Value = 50
            FileCopy(installPath + "\Game\DATA\Sounds\FMOD\VOBank_en_US.fsb", "bak\sound\VOBank_en_US.fsb")
            Wait.pbW1.Value = 75
            Try
                FileCopy(installPath + "\Game\DATA\Sounds\FMOD\VOBank_ko_KR.fsb", "bak\sound")
            Catch ex As Exception

            End Try

            Try
                FileCopy(installPath + "\Game\DATA\Sounds\FMOD\VOBank_zh_CN.fsb", "bak\sound\VOBank_zh_CN.fsb")

            Catch ex As Exception

            End Try

            Wait.pbW1.Value = 100
            Wait.Close()
            MsgBox("備份成功 ", MsgBoxStyle.Information + MsgBoxStyle.OkOnly, "提示")
            Wait.Close()
        Catch ex As Exception
            Wait.Close()
            MsgBox("備份失敗... " & vbCrLf & "錯誤信息: " & ex.Message, MsgBoxStyle.Critical + MsgBoxStyle.OkOnly, "錯誤")
        End Try


    End Sub

    Private Sub Button13_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button13.Click
        Try
            Wait.Show()
            Wait.pbW1.Value = 0

            My.Computer.FileSystem.CopyDirectory("bak\sound\sound", installPath + "\Air\assets\sounds", True)
            Wait.pbW1.Value = 25
            FileCopy("bak\sound\VOBank_zh_TW.fsb", installPath + "\Game\DATA\Sounds\FMOD\VOBank_zh_TW.fsb")
            Wait.pbW1.Value = 50
            FileCopy("bak\sound\VOBank_en_US.fsb", installPath + "\Game\DATA\Sounds\FMOD\VOBank_en_US.fsb")
            Wait.pbW1.Value = 75
            Try
                FileCopy("bak\sound\VOBank_ko_KR.fsb", installPath + "\Game\DATA\Sounds\FMOD\VOBank_ko_KR.fsb")
            Catch ex As Exception

            End Try

            Try
                FileCopy("bak\sound\VOBank_zh_CN.fsb", installPath + "\Game\DATA\Sounds\FMOD\VOBank_zh_CN.fsb")
            Catch ex As Exception



            End Try

            Wait.pbW1.Value = 100
            Wait.Close()
            MsgBox("還原成功 ", MsgBoxStyle.Information + MsgBoxStyle.OkOnly, "提示")
        Catch ex As Exception
            Wait.Close()
            MsgBox("沒有備份 還原失敗 ", MsgBoxStyle.Critical + MsgBoxStyle.OkOnly, "提示")
        End Try

    End Sub

    Private Sub Button14_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button14.Click
        Try
            Wait.Show()
            Wait.pbW1.Value = 0
            My.Computer.FileSystem.DeleteDirectory("bak\sound\sound", FileIO.DeleteDirectoryOption.DeleteAllContents)
            Wait.pbW1.Value = 25
            My.Computer.FileSystem.DeleteFile("bak\sound\VOBank_zh_TW.fsb")
            Wait.pbW1.Value = 50
            My.Computer.FileSystem.DeleteFile("bak\sound\VOBank_en_US.fsb")
            Wait.pbW1.Value = 75
            Try
                My.Computer.FileSystem.DeleteFile("bak\sound\VOBank_ko_KR.fsb")
            Catch ex As Exception

            End Try
            Wait.pbW1.Value = 100
            Wait.Close()
            MsgBox("刪除備份成功 ", MsgBoxStyle.Information + MsgBoxStyle.OkOnly, "提示")
        Catch ex As Exception
            Wait.Close()
            MsgBox("沒有備份 刪除備份失敗 ", MsgBoxStyle.Critical + MsgBoxStyle.OkOnly, "提示")
        End Try


    End Sub

    Private Sub LinkLabel2_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles LinkLabel2.LinkClicked
        Process.Start("http://lolnx.pixub.com/sound-pack")
    End Sub

    Private Sub LinkLabel1_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles LinkLabel1.LinkClicked
        Process.Start("http://lolnx.pixub.com/")
    End Sub

    Private Sub Button15_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button15.Click

        targetsite = websiteIn.Text
        targetsite.Replace("http://", "")
        targetsite.Replace("https://", "")

        If targetsite = "" Then
            MsgBox("請輸入正確的網址", MsgBoxStyle.Information + MsgBoxStyle.OkOnly, "提示")
        ElseIf targetsite.Contains("http://") Then
            MsgBox("請不要輸入 'http://' ", MsgBoxStyle.Information + MsgBoxStyle.OkOnly, "提示")
        ElseIf targetsite.Contains("https://") Then
            MsgBox("請不要輸入 'https://' ", MsgBoxStyle.Information + MsgBoxStyle.OkOnly, "提示")
        Else
            LobbyLandingEdit.LobbyLandingEdit(installPath, targetsite)
        End If







    End Sub

    Private Sub Button17_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button17.Click
        BakResProp.BakResProp(1, lolprop)
    End Sub

    Private Sub Button18_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button18.Click
        BakResProp.BakResProp(2, lolprop)
    End Sub

    Private Sub Button16_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button16.Click
        BakResProp.BakResProp(3, lolprop)
    End Sub

    Private Sub LinkLabel3_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles LinkLabel3.LinkClicked
        Process.Start("http://lolnx.pixub.com/lol-tools-tw/lol-lobby-theme/")
    End Sub

    Public Shared Sub chooseHUD_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chooseHUD.Click
        TwTools.OpenFileDialog1.ShowDialog()

        hudPath = TwTools.OpenFileDialog1.FileName()

        If hudPath.Contains("HUDAtlas") Then

        Else
            MsgBox("請選擇正確的遊戲UI檔案", MsgBoxStyle.Critical + MsgBoxStyle.OkOnly, "錯誤")
        End If

    End Sub

    Private Sub Button20_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button20.Click
        Try
            FileCopy(installPath + "\Game\DATA\Menu\Textures\HUDAtlas.tga", "bak\UI\game\HUDAtlas.tga")
            MsgBox("備份成功 ", MsgBoxStyle.Information + MsgBoxStyle.OkOnly, "提示")
        Catch ex As Exception
            MsgBox("備份失敗... " & vbCrLf & "錯誤信息: " & ex.Message, MsgBoxStyle.Critical + MsgBoxStyle.OkOnly, "錯誤")
        End Try
    End Sub

    Private Sub Button21_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button21.Click
        Try
            FileCopy("bak\UI\game\HUDAtlas.tga", installPath + "\Game\DATA\Menu\Textures\HUDAtlas.tga")
            MsgBox("還原成功 ", MsgBoxStyle.Information + MsgBoxStyle.OkOnly, "提示")
        Catch ex As Exception
            MsgBox("還原失敗... " & vbCrLf & "錯誤信息: " & ex.Message, MsgBoxStyle.Critical + MsgBoxStyle.OkOnly, "錯誤")
        End Try
    End Sub

    Private Sub Button19_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button19.Click
        Try
            My.Computer.FileSystem.DeleteFile("bak\UI\game\HUDAtlas.tga")
            MsgBox("刪除備份成功 ", MsgBoxStyle.Information + MsgBoxStyle.OkOnly, "提示")
        Catch ex As Exception
            MsgBox("刪除備份失敗: 沒有備份" & vbCrLf & "錯誤信息: " & ex.Message, MsgBoxStyle.Critical + MsgBoxStyle.OkOnly, "錯誤")
        End Try
    End Sub



    Private Sub installHUD_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles installHUD.Click

        Try
            InstallUI.InstallGameUI(hudPath, installPath)
        Catch ex As Exception
            MsgBox("安裝UI失敗" & vbCrLf & "錯誤信息: " & ex.Message, MsgBoxStyle.Critical + MsgBoxStyle.OkOnly, "錯誤")
        End Try

    End Sub


    Private Sub NotifyIcon1_MouseDoubleClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles NotifyIcon1.MouseDoubleClick
        Me.Show()

        Me.ShowInTaskbar = True

        Me.NotifyIcon1.Visible = False
    End Sub



    Private Sub Button22_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button22.Click
        ChatEdit.Show()
    End Sub


End Class

