<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class F_RightMenu
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Me.M_Menu = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.AddNewWordToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.SettingsToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ChoseWordToLearnToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.AboutToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ExitToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.M_Menu.SuspendLayout()
        Me.SuspendLayout()
        '
        'M_Menu
        '
        Me.M_Menu.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.AddNewWordToolStripMenuItem, Me.SettingsToolStripMenuItem, Me.ChoseWordToLearnToolStripMenuItem, Me.AboutToolStripMenuItem, Me.ExitToolStripMenuItem})
        Me.M_Menu.Name = "M_Menu"
        Me.M_Menu.Size = New System.Drawing.Size(188, 114)
        '
        'AddNewWordToolStripMenuItem
        '
        Me.AddNewWordToolStripMenuItem.Name = "AddNewWordToolStripMenuItem"
        Me.AddNewWordToolStripMenuItem.Size = New System.Drawing.Size(187, 22)
        Me.AddNewWordToolStripMenuItem.Text = "Add New Word"
        '
        'SettingsToolStripMenuItem
        '
        Me.SettingsToolStripMenuItem.Name = "SettingsToolStripMenuItem"
        Me.SettingsToolStripMenuItem.Size = New System.Drawing.Size(187, 22)
        Me.SettingsToolStripMenuItem.Text = "Settings"
        '
        'ChoseWordToLearnToolStripMenuItem
        '
        Me.ChoseWordToLearnToolStripMenuItem.Name = "ChoseWordToLearnToolStripMenuItem"
        Me.ChoseWordToLearnToolStripMenuItem.Size = New System.Drawing.Size(187, 22)
        Me.ChoseWordToLearnToolStripMenuItem.Text = "Chose Word To Learn"
        '
        'AboutToolStripMenuItem
        '
        Me.AboutToolStripMenuItem.Name = "AboutToolStripMenuItem"
        Me.AboutToolStripMenuItem.Size = New System.Drawing.Size(187, 22)
        Me.AboutToolStripMenuItem.Text = "About"
        '
        'ExitToolStripMenuItem
        '
        Me.ExitToolStripMenuItem.Name = "ExitToolStripMenuItem"
        Me.ExitToolStripMenuItem.Size = New System.Drawing.Size(187, 22)
        Me.ExitToolStripMenuItem.Text = "Exit"
        '
        'F_RightMenu
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(32, 37)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Name = "F_RightMenu"
        Me.ShowIcon = False
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.Manual
        Me.Text = "RightMenu"
        Me.TopMost = True
        Me.M_Menu.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents M_Menu As ContextMenuStrip
    Friend WithEvents AddNewWordToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents SettingsToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ChoseWordToLearnToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents AboutToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ExitToolStripMenuItem As ToolStripMenuItem
End Class
