Imports System.Web.UI.WebControls

Public Class Form1
    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Label1.Parent = PictureBox1
        Label2.Parent = PictureBox1
        Label3.Parent = PictureBox1
        Label4.Parent = PictureBox1
        Label5.Parent = PictureBox1
        Label6.Parent = PictureBox1
        Label7.Parent = PictureBox1
        PercentageLbl.Parent = PictureBox1
        MyProgressBar.Parent = PictureBox1
        Timer1.Start()
    End Sub



    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        MyProgressBar.Increment(1)
        Dim Percentage
        Percentage = MyProgressBar.Value.ToString()
        Dim Per As String
        Per = Percentage + "%"
        PercentageLbl.Text = Per

        If MyProgressBar.Value = 100 Then
            Me.Hide()
            Dim obj As New Form2
            obj.Show()
            Timer1.Enabled = False
        End If
    End Sub

End Class


