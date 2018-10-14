Public Class F_RightMenu
    Private Sub F_RightMenu_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        M_Menu.Show(Cursor.Position)
        Me.Width = 1
        Me.Height = 1
    End Sub

    Private Sub F_RightMenu_Deactivate(sender As Object, e As EventArgs) Handles MyBase.Deactivate
        M_Menu.Close()
        Me.Close()
    End Sub
End Class
