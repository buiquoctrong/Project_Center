Public Class Settings
    Private notifyIcon As NotifyIcon
    Private appActive As Boolean
    Private Const BOOK_BLUE As String = "Dictionary learning realdy for learn."
    Private Const BOOK_RED As String = "Dictionary learning is busy.Can't exit."
    Private Const SETTINGS_HIDE As Boolean = False
    Private Const SETTINGS_SHOW As Boolean = True
    Private Const NOTYFY_SHOW As Boolean = True
    Private Const NOTYFY_HIDE As Boolean = False

#Region "FROM EVENT"
    Private Sub Settings_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Call SetSettingsFormInfomation()
        Call CreateNotifyIcon()
        Call CreateEventNotifyIcon()
        Call FormSettingsShow()
    End Sub

    Private Sub Settings_FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing
        Call FormSettingsHide()
        e.Cancel = True
    End Sub

    Private Sub Settings_FormExit(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        If Me.notifyIcon IsNot Nothing Then
            Me.notifyIcon.Dispose()
        End If
    End Sub

    Private Sub SetSettingsFormInfomation()
        Me.Icon = My.Resources.dictionary
    End Sub
    Private Sub FormSettingsShow()
        Me.Visible = SETTINGS_SHOW
        Me.appActive = SETTINGS_SHOW
        Me.notifyIcon.Visible = NOTYFY_HIDE
    End Sub

    Private Sub FormSettingsHide()
        Me.Visible = SETTINGS_HIDE
        Me.appActive = SETTINGS_HIDE
        Me.notifyIcon.Visible = NOTYFY_SHOW
    End Sub
#End Region

#Region "Notify Icon"
    Private Sub CreateNotifyIcon()
        Me.notifyIcon = New NotifyIcon()
        Me.notifyIcon.Icon = My.Resources.book_blue
        Me.notifyIcon.Text = BOOK_BLUE
    End Sub

    Private Sub CreateEventNotifyIcon()
        AddHandler Me.notifyIcon.MouseClick, AddressOf OnIconMouseClick
        AddHandler Me.notifyIcon.MouseDoubleClick, AddressOf OnIconMouseDoubleClick
    End Sub

    Private Sub OnIconMouseClick(ByVal sender As Object, ByVal e As MouseEventArgs)

        If e.Button = MouseButtons.Right AndAlso notifyIcon.Text = BOOK_BLUE Then
            Call ShowRightMenu()
        End If
    End Sub
    Private Sub OnIconMouseDoubleClick(ByVal sender As Object, ByVal e As MouseEventArgs)
        If e.Button = MouseButtons.Left Then
            Me.Visible = True
            Me.notifyIcon.Visible = False
        End If
    End Sub
#End Region

#Region "Other functions"
    Private Sub ShowRightMenu()
        Dim RightMenu As F_RightMenu = New F_RightMenu()
        RightMenu.Show()
    End Sub
#End Region


End Class