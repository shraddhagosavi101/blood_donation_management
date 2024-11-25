Public Class Form2
    Private Sub PictureBox3_Click(sender As Object, e As EventArgs) Handles PictureBox3.Click
        Application.Exit()
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        If UnameTb.Text = "" Or PasswordTb.Text = "" Then
            MsgBox("Enter both Username and Password")
        ElseIf UnameTb.Text = "Shank" And PasswordTb.Text = "@2161" Then
            Dim Obj As New Form4()
            Obj.Show()
            Me.Hide()
        Else
            MsgBox("Wrong Username or Password")
        End If
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        UnameTb.Text = ""
        PasswordTb.Text = ""
    End Sub
End Class