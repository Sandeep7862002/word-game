Public Class Texttwist
    Dim word As String
    Dim lives As Integer = 6

    Private Sub Texttwist_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        WelcomeToolStripMenuItem.Text = "Welcome, " + Form1.user
        Dim random_index As Integer = CInt(Math.Ceiling(Rnd() * Form1.words.Length))
        word = Form1.words(random_index)
        Label1.Text = ShuffleWord(word)
    End Sub

    Private Function ShuffleWord(Word As String) As String
        Dim rand As New Random
        Dim j As Integer
        Dim chars() As Char = Word.ToCharArray
        For i As Integer = 0 To chars.Length - 1
            j = rand.Next(Word.Length)
            Dim t As Char = chars(i)
            chars(i) = chars(j)
            chars(j) = t
        Next
        Return New String(chars)
    End Function

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        If IsNumeric(TextBox2.Text) Then
            MsgBox("Use letters dummy!", MsgBoxStyle.OkOnly, "Input Error")
            TextBox2.Text = Nothing
        ElseIf TextBox2.Text.Length > 0 Then
            If TextBox2.Text.ToLower = word.ToLower Then
                MsgBox("You guessed correctly! The word was '" + word + "'.", MsgBoxStyle.OkOnly, "Winner!")
                ResetGame()
            Else
                Label4.Text += vbCrLf + TextBox2.Text
                TextBox2.Text = Nothing
                lives -= 1
                Label3.Text = lives.ToString
                TextBox2.Select()
            End If
        End If
        If lives = 0 Then
            MsgBox("You ran out of tries! The word was '" + word + "'.", MsgBoxStyle.OkOnly, "Loser!")
            ResetGame()
        End If

    End Sub

    Private Sub ResetGame()
        Dim random_index As Integer = CInt(Math.Ceiling(Rnd() * Form1.words.Length))
        word = Form1.words(random_index)
        Label1.Text = ShuffleWord(word)
        Label4.Text = Nothing
        TextBox2.Text = Nothing
        lives = 6
        Label3.Text = lives.ToString
    End Sub

    Private Sub ToolStripMenuItem5_Click(sender As Object, e As EventArgs) Handles ToolStripMenuItem5.Click
        ResetGame()
    End Sub

    Private Sub ToolStripMenuItem2_Click(sender As Object, e As EventArgs) Handles ToolStripMenuItem2.Click
        Form1.Logout()
        Form1.Show()
        Me.Close()
    End Sub

    Private Sub ToolStripMenuItem3_Click(sender As Object, e As EventArgs) Handles ToolStripMenuItem3.Click
        Form1.Show()
        Me.Close()
    End Sub

    Private Sub ToolStripMenuItem4_Click(sender As Object, e As EventArgs) Handles ToolStripMenuItem4.Click
        Me.Close()
    End Sub

    Private Sub ToolStripMenuItem6_Click(sender As Object, e As EventArgs) Handles ToolStripMenuItem6.Click
        MsgBox("An app made by Chad Sarrouf.", MsgBoxStyle.Information, "About")
    End Sub
End Class