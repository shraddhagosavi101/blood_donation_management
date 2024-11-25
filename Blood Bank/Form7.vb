Imports System.Data.SqlClient
Public Class form7
    Dim Con As New SqlConnection("Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\shrad\OneDrive\Documents\BloodVbDb.mdf;Integrated Security=True;Connect Timeout=30")
    Private Sub PictureBox6_Click(sender As Object, e As EventArgs) Handles PictureBox6.Click
        Application.Exit()
    End Sub
    Private Sub CountPatients()
        Dim PatNum As Integer
        Con.Open()
        Dim sql = "select COUNT(*) from PatientTbl"
        Dim cmd As SqlCommand
        cmd = New SqlCommand(sql, Con)
        PatNum = cmd.ExecuteScalar
        PatNumLbl.Text = PatNum
        Con.Close()
    End Sub
    Private Sub CountDonors()
        Dim DonNum As Integer
        Con.Open()
        Dim sql = "select COUNT(*) from DonorTbl"
        Dim cmd As SqlCommand
        cmd = New SqlCommand(sql, Con)
        DonNum = cmd.ExecuteScalar
        DonNumLbl.Text = DonNum
        Con.Close()

    End Sub
    Private Sub CountTransfers()
        Dim TrNum As Integer
        Con.Open()
        Dim sql = "select COUNT(*) from TransferTbl"
        Dim cmd As SqlCommand
        cmd = New SqlCommand(sql, Con)
        TrNum = cmd.ExecuteScalar
        TrNumLbl.Text = TrNum
        Con.Close()

    End Sub
    Private Sub form7_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        CountPatients()
        CountDonors()
        CountTransfers()
    End Sub

    Private Sub Label1_Click(sender As Object, e As EventArgs) Handles Label1.Click
        Dim Obj As New Form3
        Obj.Show()
    End Sub

    Private Sub Label2_Click(sender As Object, e As EventArgs) Handles Label2.Click
        Dim Obj As New Form4
        Obj.Show()
    End Sub

    Private Sub Label3_Click(sender As Object, e As EventArgs) Handles Label3.Click
        Dim Obj As New Form6
        Obj.Show()
    End Sub

    Private Sub Label4_Click(sender As Object, e As EventArgs) Handles Label4.Click
        Dim Obj As New BloodTransfer
        Obj.Show()
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim Obj = New Form2
        Obj.Show()
        Me.Hide()
    End Sub

    Private Sub TrNameLbl_Click(sender As Object, e As EventArgs) Handles TrNameLbl.Click

    End Sub

    Private Sub DonNameLbl_Click(sender As Object, e As EventArgs) Handles DonNameLbl.Click

    End Sub
End Class