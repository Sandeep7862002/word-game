Imports System.Text

Public Class Hangman
    Dim word As String
    Dim mistakes As Integer = 0
    Dim letters As New ArrayList
    Private Sub Wordhang_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        WelcomeToolStripMenuItem.Text = "Welcome, " + Form1.user
        Dim random_index As Integer = CInt(Math.Ceiling(Rnd() * Form1.words.Length))
        word = Form1.words(random_index)
        Label1.Text = Nothing
        For i As Integer = 1 To word.Length
            Label1.Text += "_ "
        Next
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim letter As String = TextBox2.Text.ToLower
        If letter.Length > 1 Then
            MsgBox("One letter at a time!", MsgBoxStyle.OkOnly, "Input Error")
        ElseIf letters.Contains(letter) Then
            MsgBox("Already used that letter", MsgBoxStyle.OkOnly, "Input Error")
        ElseIf letter.Length = 1 And Char.IsLetter(letter) Then
            If word.Contains(letter) Then
                Dim spaces_removed As String = Label1.Text.Replace(" ", String.Empty)
                Dim builder As New StringBuilder
                builder.Append(spaces_removed)
                For i As Integer = 0 To word.Length - 1
                    If word(i) = letter Then
                        builder(i) = letter
                    End If
                Next
                spaces_removed = builder.ToString
                Label1.Text = Nothing
                For i = 0 To spaces_removed.Length - 1
                    Label1.Text += spaces_removed(i) + " "
                Next
            Else
                mistakes += 1
            End If
            Label4.Text += vbCrLf + letter
            letters.Add(letter)
        End If
        Select Case mistakes
            Case 1
                PictureBox1.Image = My.Resources.hangman_string
            Case 2
                PictureBox1.Image = My.Resources.hangman_head
            Case 3
                PictureBox1.Image = My.Resources.hangman_body
            Case 4
                PictureBox1.Image = My.Resources.hangman_1_arm
            Case 5
                PictureBox1.Image = My.Resources.hangman_2_arms
            Case 6
                PictureBox1.Image = My.Resources.hangman_1_leg
            Case 7
                PictureBox1.Image = My.Resources.hangman_whole
            Case 8
                PictureBox1.Image = My.Resources.hangman_over
                MsgBox("Oh no, you lose! The word was '" + word + "'.", MsgBoxStyle.OkOnly, "Loser!")
                ResetGame()
        End Select
        If Label1.Text.Contains("_") = False Then
            MsgBox("You got it! The word was '" + word + "'.", MsgBoxStyle.OkOnly, "Winner!")
            ResetGame()
        End If

        TextBox2.Text = Nothing
        TextBox2.Select()

    End Sub

    Private Sub ResetGame()
        Dim random_index As Integer = CInt(Math.Ceiling(Rnd() * Form1.words.Length))
        word = Form1.words(random_index)
        mistakes = 0
        PictureBox1.Image = My.Resources.hangman_empty
        Label1.Text = Nothing
        For i As Integer = 1 To word.Length
            Label1.Text += "_ "
        Next
        Label4.Text = "Used Letters"
    End Sub

    Private Sub NewWordToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles NewWordToolStripMenuItem.Click
        ResetGame()
    End Sub

    Private Sub ChangeUserToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ChangeUserToolStripMenuItem.Click
        Form1.Logout()
        Form1.Show()
        Me.Close()
    End Sub

    Private Sub ChooseAnotherGameToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ChooseAnotherGameToolStripMenuItem.Click
        Form1.Show()
        Me.Close()

    End Sub

    Private Sub ExitToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ExitToolStripMenuItem.Click
        Me.Close()
    End Sub

    Private Sub AboutToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles AboutToolStripMenuItem.Click
        MsgBox("An app made by Chad Sarrouf.", MsgBoxStyle.Information, "About")
    End Sub
End Class