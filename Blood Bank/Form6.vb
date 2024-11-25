Imports System.Data.SqlClient

Public Class Form6
    Dim Con As New SqlConnection("Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\shrad\OneDrive\Documents\BloodVbDb.mdf;Integrated Security=True;Connect Timeout=30")
    Private Sub DisplayForm3()
        Con.Open()
        Dim query = "select Donor_name,Donor_bloodgroup from DonorTbl"
        Dim adapter As SqlDataAdapter
        adapter = New SqlDataAdapter(query, Con)
        Dim bulider = New SqlCommandBuilder(adapter)
        Dim ds As DataSet
        ds = New DataSet()
        adapter.Fill(ds)
        DonorsDGV.DataSource = ds.Tables(0)
        Con.Close()
    End Sub
    Private Sub DisplayBlood()
        Con.Open()
        Dim query = "select * from BstockTbl"
        Dim adapter As SqlDataAdapter
        adapter = New SqlDataAdapter(query, Con)
        Dim bulider = New SqlCommandBuilder(adapter)
        Dim ds As DataSet
        ds = New DataSet()
        adapter.Fill(ds)
        BloodDGV.DataSource = ds.Tables(0)
        Con.Close()
    End Sub
    Private Sub Form6_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        DisplayForm3()
        DisplayBlood()
    End Sub

    Dim key As Integer

    Private Sub DonorsDGV_CellMouseClick(sender As Object, e As DataGridViewCellMouseEventArgs) Handles DonorsDGV.CellMouseClick
        Dim row As DataGridViewRow = DonorsDGV.Rows(e.RowIndex)
        DNameTb.Text = row.Cells(0).Value.ToString
        DBGroupTb.Text = row.Cells(1).Value.ToString


    End Sub

    Private Sub PictureBox2_Click(sender As Object, e As EventArgs) Handles PictureBox2.Click
        Application.Exit()
    End Sub

    Dim OldStock
    Private Sub FetchQty()
        Con.Open()
        Dim query = "Select * from BStockTbl where Blood_group ='" & DBGroupTb.Text & "'"
        Dim cmd As New SqlCommand(query, Con)
        Dim dt As New DataTable

        Dim reader As SqlDataReader
        reader = cmd.ExecuteReader()
        While reader.Read
            OldStock = Convert.ToInt32(reader(2))
        End While
        Con.Close()
    End Sub

    Private Sub DonateBtn_Click(sender As Object, e As EventArgs) Handles DonateBtn.Click
        If DNameTb.Text = "" Or DBGroupTb.Text = "" Then
            MsgBox("Select a Donor")
        Else
            FetchQty()
            Dim NewStock As Integer

            NewStock = OldStock + 1
            Con.Open()
            Dim query = "update BStockTbl set Blood_Stock = " & NewStock & " where Blood_Group = '" & DBGroupTb.Text & "'"
            Dim cmd As New SqlCommand(query, Con)
            cmd.ExecuteNonQuery()
            MsgBox("Blood Updated Successfully")
            Con.Close()
            DisplayBlood()

        End If
    End Sub

    Private Sub Label1_Click(sender As Object, e As EventArgs) Handles Label1.Click
        Dim Obj As New Form3
        Obj.Show()
    End Sub

    Private Sub Label2_Click(sender As Object, e As EventArgs) Handles Label2.Click
        Dim Obj As New Form4
        Obj.Show()
    End Sub

    Private Sub Label4_Click(sender As Object, e As EventArgs) Handles Label4.Click
        Dim Obj As New BloodTransfer
        Obj.Show()
    End Sub

    Private Sub Label5_Click(sender As Object, e As EventArgs) Handles Label5.Click
        Dim Obj As New form7
        Obj.Show()
    End Sub

    Private Sub DBGroupTb_TextChanged(sender As Object, e As EventArgs) Handles DBGroupTb.TextChanged

    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim Obj = New Form2
        Obj.Show()
        Me.Hide()
    End Sub
End Class