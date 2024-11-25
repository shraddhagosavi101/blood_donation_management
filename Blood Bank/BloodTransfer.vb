Imports System.Data.SqlClient

Public Class BloodTransfer
    Dim Con As New SqlConnection("Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\shrad\OneDrive\Documents\BloodVbDb.mdf;Integrated Security=True;Connect Timeout=30")
    Private Sub GetPatients()
        Con.Open()
        Dim Sql = "select * from PatientTbl"
        Dim cmd As New SqlCommand(Sql, Con)
        Dim adpater As New SqlDataAdapter(cmd)
        Dim Tbl As New DataTable()
        adpater.Fill(Tbl)
        PatIdCb.DataSource = Tbl
        PatIdCb.DisplayMember = "Patient_id"
        PatIdCb.ValueMember = "Patient_id"

        Con.Close()
    End Sub
    Private Sub BloodTransfer_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        GetPatients()
    End Sub

    Private Sub GetData()
        Con.Open()
        Dim query = "Select * from PatientTbl where Patient_id = " & PatIdCb.SelectedValue.ToString() & ""
        Dim cmd As New SqlCommand(query, Con)

        Dim dt As New DataTable
        Dim reader As SqlDataReader
        reader = cmd.ExecuteReader()

        While reader.Read
            PatNameTb.Text = reader(1).ToString()
            BGroupTb.Text = reader(5).ToString()
        End While
        Con.Close()
    End Sub



    Private Sub PatIdCb_SelectionChangeCommitted(sender As Object, e As EventArgs) Handles PatIdCb.SelectionChangeCommitted
        GetData()
        FetchQty()
        If AvailableStock = 0 Then
            AvailableLbl.Text = "No Blood Available"
            AvailableLbl.Visible = True
        Else
            AvailableLbl.Text = AvailableStock
            AvailableLbl.Visible = True
            TransferBtn.Visible = True

        End If
    End Sub

    Dim AvailableStock As Integer
    Private Sub FetchQty()
        Con.Open()
        Dim query = "Select * from BStockTbl where Blood_group ='" & BGroupTb.Text & "'"
        Dim cmd As New SqlCommand(query, Con)
        Dim dt As New DataTable

        Dim reader As SqlDataReader
        reader = cmd.ExecuteReader()
        While reader.Read
            AvailableStock = Convert.ToInt32(reader(2))
        End While
        Con.Close()
    End Sub
    Private Sub UpdateBlood()
        FetchQty()
        Dim NewStock As Integer

        NewStock = AvailableStock - 1
        Con.Open()
        Dim query = "update BStockTbl set Blood_Stock = " & NewStock & " where Blood_Group = '" & BGroupTb.Text & "'"
        Dim cmd As New SqlCommand(query, Con)
        cmd.ExecuteNonQuery()

        'AvailableLbl.Text = AvailableStock
        'MsgBox("Blood Updated Successfully")
        Con.Close()
        If NewStock = 0 Then
            TransferBtn.Visible = False
        Else
            TransferBtn.Visible = True
        End If
    End Sub


    Private Sub TransferBtn_Click(sender As Object, e As EventArgs) Handles TransferBtn.Click
        Try

            Con.Open()
            Dim query = "insert into TransferTbl(Tpat,TBGroup) values (@TrPat,@TrBGroup)"
            Dim cmd As New SqlCommand(query, Con)
            cmd.Parameters.AddWithValue("@TrPat", PatNameTb.Text)
            cmd.Parameters.AddWithValue("@TrBGroup", BGroupTb.Text)


            cmd.ExecuteNonQuery()
            MsgBox("Blood Transfer")

            Con.Close()
            FetchQty()
            UpdateBlood()

        Catch ex As Exception
            MsgBox(ex.Message)

        End Try
    End Sub

    Private Sub PictureBox4_Click(sender As Object, e As EventArgs) Handles PictureBox4.Click
        Application.Exit()
    End Sub

    Private Sub AvailableLbl_Click(sender As Object, e As EventArgs) Handles AvailableLbl.Click

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

    Private Sub Label5_Click(sender As Object, e As EventArgs) Handles Label5.Click
        Dim Obj As New form7
        Obj.Show()
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim Obj = New Form2
        Obj.Show()
        Me.Hide()
    End Sub
End Class