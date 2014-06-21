Imports System.Net
Imports System.IO
Imports System.IO.StreamReader
Imports System.Threading

Public Class NaTools

    Public Shared installPath As String = ""
    Public Shared lolexePath As String
    Public Shared lolprop As String
    Public Shared targetsite As String
    Public Shared naairVer As String
    Public Shared nagameVer As String

    Dim folderPath As String = ""             'SwitchSound



    Public Sub NaTools_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        Wait.Close()

        '讀取 config.ini 
        Dim ini As New INIFile.INIFile(My.Application.Info.DirectoryPath + "\config.ini")

        If installPath = "" Then
            installPath = ini.GetString("LoLPath", "NaPath", Nothing)
        End If


        '從登錄碼尋找LOL安裝路徑 2
        If installPath = "" Then
            If My.Computer.Registry.GetValue("HKEY_LOCAL_MACHINE\SOFTWARE\Riot Games\League of Legends", "Path", Nothing) Is Nothing Then

            Else

                If My.Computer.Registry.GetValue("HKEY_LOCAL_MACHINE\SOFTWARE\Riot Games\League of Legends", "Path", Nothing).Contains("League of Legends") Then
                    installPath = My.Computer.Registry.GetValue("HKEY_LOCAL_MACHINE\SOFTWARE\Riot Games\League of Legends", "Path", Nothing)
                End If
            End If
        End If

        If installPath = "" Then
            If My.Computer.Registry.GetValue("HKEY_CURRENT_USER\SOFTWARE\Riot Games\League of Legends", "Path", Nothing) Is Nothing Then

            Else
                If My.Computer.Registry.GetValue("HKEY_CURRENT_USER\SOFTWARE\Riot Games\League of Legends", "Path", Nothing).Contains("League of Legends") Then
                    installPath = My.Computer.Registry.GetValue("HKEY_CURRENT_USER\SOFTWARE\Riot Games\League of Legends", "Path", Nothing)
                End If
            End If
        End If

        If installPath = "" Then
            MsgBox(" 找不到LoL安裝路徑，請手動選擇 \Riot Games\League of Legends\ 目錄", MsgBoxStyle.Information + MsgBoxStyle.OkOnly, "提示")
            Me.FolderBrowserDialog1.ShowDialog()
            installPath = Me.FolderBrowserDialog1.SelectedPath
        End If


        If installPath.Contains("League of Legends") <> True Then


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
        If ini.GetString("LoLPath", "NaPath", Nothing) = "" Then

            If installPath.Contains("LoLTW") Then
                ini.WriteString("LoLPath", "NaPath", installPath)

            End If
        End If

        ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
        '從登錄碼尋找LOL安裝路徑 1
        'If My.Computer.Registry.GetValue("HKEY_LOCAL_MACHINE\SOFTWARE\Garena\LoLTW", "Path", Nothing) Is Nothing Then
        'MsgBox(" 找不到LoL安裝路徑，請手動選擇 GemeData\Apps\LoLTW 目錄", MsgBoxStyle.Information + MsgBoxStyle.OkOnly, "提示")
        'Me.FolderBrowserDialog1.ShowDialog()
        'installPath = Me.FolderBrowserDialog1.SelectedPath
        'End If
        'If installPath = "" Then
        'If My.Computer.Registry.GetValue("HKEY_CURRENT_USER\Software\Garena\LoLTW", "Path", Nothing) <> Nothing Then
        'installPath = My.Computer.Registry.GetValue("HKEY_CURRENT_USER\Software\Garena\LoLTW", "Path", Nothing)

        'Else
        'installPath = My.Computer.Registry.GetValue("HKEY_LOCAL_MACHINE\SOFTWARE\Garena\LoLTW", "Path", Nothing)
        'End If
        'End If
        ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''



        Try
            lolexePath = installPath + "\lol.launcher.exe"   'LOL.EXE 路徑
        Catch ex As Exception
            MessageBox.Show("找不到 lol.launcher.exe ")
        End Try






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



        '重要!! 取得目前伺服器地區 SUB
        CheckPropFirstLine()


        websiteIn.Text = ""

        '綫上取得LOL版本
        Try
            If My.Computer.FileSystem.FileExists("naair.ver") Then
                My.Computer.FileSystem.DeleteFile("naair.ver")
            End If
            If My.Computer.FileSystem.FileExists("nagame.ver") Then
                My.Computer.FileSystem.DeleteFile("nagame.ver")
            End If
            Wait.Show()
            Wait.pbW1.Value = 0
            My.Computer.Network.DownloadFile("http://lolnx.pixub.com/loltoolsx/na/air.ver", "naair.ver")
            Wait.pbW1.Value = 25
            My.Computer.Network.DownloadFile("http://lolnx.pixub.com/loltoolsx/na/game.ver", "nagame.ver")
            Wait.pbW1.Value = 50
            naairVer = My.Computer.FileSystem.ReadAllText("naair.ver")
            Wait.pbW1.Value = 75
            nagameVer = My.Computer.FileSystem.ReadAllText("nagame.ver")
            Wait.pbW1.Value = 100
            Wait.Hide()
        Catch ex As Exception
            MsgBox("無法從綫上取得客戶端版本，按確定關閉程式。", MsgBoxStyle.Critical + MsgBoxStyle.OkOnly, "錯誤")
            Application.Exit()
        End Try
        

        Try
            WebBrowser1.Navigate("http://lolnx.pixub.com/loltoolsx/stat.html")
        Catch ex As Exception

        End Try

    End Sub

    Public Sub CheckPropFirstLine()


        '取得目前伺服器地區
        Try


            If installPath.Contains("League of Legends") Then
                lolprop = installPath + "\RADS\projects\lol_air_client\releases\" + naairVer + "\deploy\lol.properties"
                Dim fileReader As System.IO.StreamReader
                fileReader =
                My.Computer.FileSystem.OpenTextFileReader(lolprop)
                Dim stringReader As String
                stringReader = fileReader.ReadLine()
                serverLocation.Text = stringReader

                If stringReader = "host=prodtw.lol.garenanow.com" Then
                    serverLocation.Text = "台服"
                ElseIf stringReader = "host=prod.na1.lol.riotgames.com" Then
                    serverLocation.Text = "美服"
                ElseIf stringReader = "host=prod.eu.lol.riotgames.com" Then
                    serverLocation.Text = "EUW服"
                ElseIf stringReader = "regionTag=eune" Then
                    serverLocation.Text = "EUNE服"
                ElseIf stringReader = "host=prod.oc1.lol.riotgames.com" Then
                    serverLocation.Text = "大洋洲服"
                ElseIf stringReader = "host=prod.lol.garenanow.com" Then
                    serverLocation.Text = "SEA服"
                ElseIf stringReader = "host=prod.pbe1.lol.riotgames.com" Then
                    serverLocation.Text = "PBE服"
                ElseIf stringReader = "host=prod.kr.lol.riotgames.com" Then
                    serverLocation.Text = "韓服"
                Else
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



    Private Sub NaTools_Close(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.FormClosing
        Application.Exit()
    End Sub



    Private Sub serverStatus_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles serverStatus.Click
        ServerStatusForm.Show()
    End Sub







    Private Sub Button10_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles updateButton.Click

        Wait.Show()
        '檢查更新
        LoLToolsX.CheckUpdate1.CheckUpdate()
        Wait.Close()


    End Sub

    Public Shared Sub startLOL_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles startLoL.Click
        Try
            If NaTools.serverLocation.Text = "台服" Then
                StartGame.StartLoLTW()
            ElseIf NaTools.serverLocation.Text = "SEA服" Then


                StartGame.StartLoLTW()
            Else


                StartGame.StartLoL(lolexePath)



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

    Private Sub lChin_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

        SwitchLang.SwitchLang(1, installPath)

    End Sub

    Private Sub lEng_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

        SwitchLang.SwitchLang(2, installPath)

    End Sub

    Private Sub gChin_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

        SwitchLang.SwitchLang(3, installPath)

    End Sub

    Private Sub gEng_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

        SwitchLang.SwitchLang(4, installPath)

    End Sub

    Private Sub BakLang_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        BakResLang.BakResLang(1, installPath)
    End Sub

    Private Sub ResLang_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        BakResLang.BakResLang(2, installPath)
    End Sub

    Private Sub delLangBak_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        BakResLang.BakResLang(3, installPath)
    End Sub

    Private Sub Button10_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs)

        'FolderBrowserDialog2.ShowDialog()
        'folderPath = FolderBrowserDialog2.SelectedPath()
        'tbPath.Text = folderPath


    End Sub

    Private Sub installSound_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        If folderPath.Contains("Sound") Then
            SwitchSound.SwitchSound("lobby", folderPath, installPath)
        Else
            MsgBox("路徑選擇錯誤 ", MsgBoxStyle.Critical + MsgBoxStyle.OkOnly, "提示")
        End If



    End Sub

    Private Sub Button11_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        If folderPath.Contains("Sound") Then
            SwitchSound.SwitchSound("game", folderPath, installPath)
        Else
            MsgBox("路徑選擇錯誤 ", MsgBoxStyle.Critical + MsgBoxStyle.OkOnly, "提示")
        End If
    End Sub

    Private Sub Button12_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Wait.Show()

        My.Computer.FileSystem.CopyDirectory(installPath + "\Air\assets\sounds", "bak\sound\sound", True)
        FileCopy(installPath + "\Game\DATA\Sounds\FMOD\VOBank_zh_TW.fsb", "bak\sound\VOBank_zh_TW.fsb")
        FileCopy(installPath + "\Game\DATA\Sounds\FMOD\VOBank_en_US.fsb", "bak\sound\VOBank_en_US.fsb")
        Try
            FileCopy(installPath + "\Game\DATA\Sounds\FMOD\VOBank_ko_KR.fsb", "bak\sound")
        Catch ex As Exception

        End Try

        Wait.Close()
        MsgBox("備份成功 ", MsgBoxStyle.Information + MsgBoxStyle.OkOnly, "提示")

    End Sub

    Private Sub Button13_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Try
            Wait.Show()

            My.Computer.FileSystem.CopyDirectory("bak\sound\sound", installPath + "\Air\assets\sounds", True)
            FileCopy("bak\sound\VOBank_zh_TW.fsb", installPath + "\Game\DATA\Sounds\FMOD\VOBank_zh_TW.fsb")
            FileCopy("bak\sound\VOBank_en_US.fsb", installPath + "\Game\DATA\Sounds\FMOD\VOBank_en_US.fsb")
            Try
                FileCopy("bak\sound\VOBank_ko_KR.fsb", installPath + "\Game\DATA\Sounds\FMOD\VOBank_ko_KR.fsb")
            Catch ex As Exception

            End Try

            Wait.Close()
            MsgBox("還原成功 ", MsgBoxStyle.Information + MsgBoxStyle.OkOnly, "提示")
        Catch ex As Exception
            Wait.Close()
            MsgBox("沒有備份 還原失敗 ", MsgBoxStyle.Critical + MsgBoxStyle.OkOnly, "提示")
        End Try

    End Sub

    Private Sub Button14_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Try
            Wait.Show()

            My.Computer.FileSystem.DeleteDirectory("bak\sound\sound", FileIO.DeleteDirectoryOption.DeleteAllContents)
            My.Computer.FileSystem.DeleteFile("bak\sound\VOBank_zh_TW.fsb")
            My.Computer.FileSystem.DeleteFile("bak\sound\VOBank_en_US.fsb")
            Try
                My.Computer.FileSystem.DeleteFile("bak\sound\VOBank_ko_KR.fsb")
            Catch ex As Exception

            End Try

            Wait.Close()
            MsgBox("刪除備份成功 ", MsgBoxStyle.Information + MsgBoxStyle.OkOnly, "提示")
        Catch ex As Exception
            Wait.Close()
            MsgBox("沒有備份 刪除備份失敗 ", MsgBoxStyle.Critical + MsgBoxStyle.OkOnly, "提示")
        End Try


    End Sub

    Private Sub LinkLabel2_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs)
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
            LobbyLandingEdit.LobbyLandingEditNA(installPath, targetsite, naairVer)
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

    Public Shared Sub chooseHUD_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        NaTools.OpenFileDialog1.ShowDialog()

        hudPath = NaTools.OpenFileDialog1.FileName()
        If hudPath.Contains("HUDAtlas") Then
            InstallUI.InstallGameUI(hudPath, installPath)
        Else
            MsgBox("請選擇正確的遊戲UI檔案", MsgBoxStyle.Critical + MsgBoxStyle.OkOnly, "錯誤")
        End If
    End Sub

    Private Sub Button20_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Try
            FileCopy(installPath + "\Game\DATA\Menu\Textures\HUDAtlas.tga", "bak\UI\game\HUDAtlas.tga")
            MsgBox("備份成功 ", MsgBoxStyle.Information + MsgBoxStyle.OkOnly, "提示")
        Catch ex As Exception
            MsgBox("備份失敗... " & vbCrLf & "錯誤信息: " & ex.Message, MsgBoxStyle.Critical + MsgBoxStyle.OkOnly, "錯誤")
        End Try
    End Sub

    Private Sub Button21_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Try
            FileCopy("bak\UI\game\HUDAtlas.tga", installPath + "\Game\DATA\Menu\Textures\HUDAtlas.tga")
            MsgBox("還原成功 ", MsgBoxStyle.Information + MsgBoxStyle.OkOnly, "提示")
        Catch ex As Exception
            MsgBox("還原失敗... " & vbCrLf & "錯誤信息: " & ex.Message, MsgBoxStyle.Critical + MsgBoxStyle.OkOnly, "錯誤")
        End Try
    End Sub

    Private Sub Button19_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Try
            My.Computer.FileSystem.DeleteFile("bak\UI\game\HUDAtlas.tga")
            MsgBox("刪除備份成功 ", MsgBoxStyle.Information + MsgBoxStyle.OkOnly, "提示")
        Catch ex As Exception
            MsgBox("刪除備份失敗: 沒有備份" & vbCrLf & "錯誤信息: " & ex.Message, MsgBoxStyle.Critical + MsgBoxStyle.OkOnly, "錯誤")
        End Try
    End Sub


    Private Sub NotifyIcon1_MouseDoubleClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles NotifyIcon1.MouseDoubleClick
        Me.Show()

        Me.ShowInTaskbar = True

        Me.NotifyIcon1.Visible = False
    End Sub
End Class

