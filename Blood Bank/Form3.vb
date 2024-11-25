Imports System.Data.SqlClient
Public Class Form3
    Dim Con As New SqlConnection("Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\shrad\OneDrive\Documents\BloodVbDb.mdf;Integrated Security=True;Connect Timeout=30")
    Private Sub DisplayForm3()
        Con.Open()
        Dim query = "Select * from DonorTbl"
        Dim adapter As SqlDataAdapter
        adapter = New SqlDataAdapter(query, Con)
        Dim bulider = New SqlCommandBuilder(adapter)
        Dim ds As DataSet
        ds = New DataSet()
        adapter.Fill(ds)
        DonorsDGV.DataSource = ds.Tables(0)
        Con.Close()
    End Sub
    Private Sub AddBtn_Click(sender As Object, e As EventArgs) Handles AddBtn.Click
        Try
            If Con.State = ConnectionState.Closed Then
                Con.Open()
                Dim query = "insert into DonorTbl(Donor_Name,Donor_age,Donor_gender,Donor_phone,Donor_bloodgroup,Donor_address,Donor_disease) values (@DonName,@DonAge,@DonGen,@DonPhone,@DonBGroup,@DonAdd,@DonDis)"
                Dim cmd As New SqlCommand(query, Con)
                cmd.Parameters.AddWithValue("@DonName", DNameTb.Text)
                cmd.Parameters.AddWithValue("@DonAge", DAgeTb.Text)
                cmd.Parameters.AddWithValue("@DonGen", DGenCb.SelectedItem.ToString())
                cmd.Parameters.AddWithValue("@DonPhone", DPhoneTb.Text)
                cmd.Parameters.AddWithValue("@DonBGroup", DBGroupCb.SelectedItem.ToString())
                cmd.Parameters.AddWithValue("@DonAdd", DAddressTb.Text)
                cmd.Parameters.AddWithValue("@DonDis", DDiseaseCb.SelectedItem.ToString())
                cmd.ExecuteNonQuery()
                MsgBox("Donor Saved")
            End If
            Con.Close()
            DisplayForm3()
        Catch ex As Exception
            MsgBox(ex.Message)

        End Try
    End Sub
    Private Sub PictureBox2_Click(sender As Object, e As EventArgs) Handles PictureBox2.Click
        Application.Exit()
    End Sub
    Private Sub Form3_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        DisplayForm3()
    End Sub
    Private Sub DeleteBtn_Click(sender As Object, e As EventArgs) Handles DeleteBtn.Click
        If key = 0 Then
            MsgBox("Select The Donor To Be Deleted")
        Else
            Con.Open()
            Dim cmd As SqlCommand
            Dim query = "delete from DonorTbl where Donor_id = " & key & ""
            cmd = New SqlCommand(query, Con)
            cmd.ExecuteNonQuery()
            MsgBox("Donor Deleted Successfully")
            Con.Close()
            DisplayForm3()
        End If
    End Sub

    Dim key As Integer



    Private Sub EditBtn_Click(sender As Object, e As EventArgs) Handles EditBtn.Click
        If key = 0 Or DNameTb.Text = "" Or DAgeTb.Text = "" Or DPhoneTb.Text = "" Or DAddressTb.Text = "" Then
            MsgBox("Incomplete Inforrmation")
        Else
            Con.Open()
            Dim query = "update DonorTBl set Donor_name = '" & DNameTb.Text & "',Donor_age = " & DAgeTb.Text & ",Donor_gender='" & DGenCb.SelectedItem.ToString & "',Donor_phone='" & DPhoneTb.Text & "',Donor_bloodgroup='" & DBGroupCb.SelectedItem.ToString() & "',Donor_address='" & DAddressTb.Text & "',Donor_disease='" & DDiseaseCb.SelectedItem.ToString() & "' where Donor_id= " & key & ""
            Dim cmd As New SqlCommand(query, Con)
            cmd.ExecuteNonQuery()
            MsgBox("Donor Update Successfully")
            Con.Close()
            DisplayForm3()
        End If
    End Sub




    Private Sub DonorsDGV_CellMouseClick_1(sender As Object, e As DataGridViewCellMouseEventArgs) Handles DonorsDGV.CellMouseClick
        Dim row As DataGridViewRow = DonorsDGV.Rows(e.RowIndex)
        DNameTb.Text = row.Cells(1).Value.ToString
        DAgeTb.Text = row.Cells(2).Value.ToString
        DGenCb.SelectedItem = row.Cells(3).Value.ToString
        DPhoneTb.Text = row.Cells(4).Value.ToString
        DBGroupCb.SelectedItem = row.Cells(5).Value.ToString
        DAddressTb.Text = row.Cells(6).Value.ToString
        DDiseaseCb.SelectedItem = row.Cells(7).Value.ToString
        If DNameTb.Text = "Donor Name" Or DNameTb.Text = "" Then
            key = 0
        Else
            key = row.Cells(0).Value.ToString
        End If
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