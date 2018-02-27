Public Class Form1
    Private users As New ArrayList
    Public words As Array = Split(My.Resources.words, vbCrLf)
    Public user As String

    'Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
    '    user = "chad"
    '    WelcomeToolStripMenuItem.Text = "Welcome, " + user
    '    WelcomeToolStripMenuItem.Visible = True
    '    ChangeUserToolStripMenuItem.Enabled = True
    '    Button1.Enabled = True
    '    Button2.Enabled = True
    '    Button3.Visible = False
    '    Button4.Visible = False
    'End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        Dim new_user As String = Nothing
        Dim valid As Boolean = False

        While valid = False
            new_user = InputBox("Enter a username: ", "New User", Nothing)
            If users.Contains(new_user) Then
                MsgBox("Username already taken! Please choose another.", MsgBoxStyle.OkOnly, "Username already taken")
            Else
                valid = True
            End If
        End While
        If new_user.Trim() <> "" Or new_user.Trim <> Nothing Then
            user = new_user.Trim()
            users.Add(user)
            WelcomeToolStripMenuItem.Text = "Welcome, " + user
            WelcomeToolStripMenuItem.Visible = True
            ChangeUserToolStripMenuItem.Enabled = True
            Button1.Enabled = True
            Button2.Enabled = True
            Button3.Visible = False
            Button4.Visible = False
        End If
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        Dim user_login As String

        user_login = InputBox("Enter your username: ", "User Login")
        If users.Contains(user_login) Then
            user = user_login
            WelcomeToolStripMenuItem.Text = "Welcome, " + user
            WelcomeToolStripMenuItem.Visible = True
            ChangeUserToolStripMenuItem.Enabled = True
            Button1.Enabled = True
            Button2.Enabled = True
            Button3.Visible = False
            Button4.Visible = False
        Else
            MsgBox("User not found", MsgBoxStyle.OkOnly, "Login Error")
        End If
    End Sub
    Public Sub Logout()
        user = Nothing
        WelcomeToolStripMenuItem.Visible = False
        ChangeUserToolStripMenuItem.Enabled = False
        Button1.Enabled = False
        Button2.Enabled = False
        Button3.Visible = True
        Button4.Visible = True
    End Sub
    Private Sub ChangeUserToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ChangeUserToolStripMenuItem.Click
        Logout()
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Me.Hide()
        texttwist.Show()
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Me.Hide()
        Hangman.Show()
    End Sub

    Private Sub AboutToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles AboutToolStripMenuItem.Click
        MsgBox("An app made by Chad Sarrouf.", MsgBoxStyle.Information, "About")
    End Sub
End Class
