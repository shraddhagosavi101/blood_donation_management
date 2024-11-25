Imports System.Data.SqlClient

Public Class Form4
    Dim Con As New SqlConnection("Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\shrad\OneDrive\Documents\BloodVbDb.mdf;Integrated Security=True;Connect Timeout=30")
    Private Sub DisplayForm4()
        Con.Open()
        Dim query = "Select * from PatientTbl"
        Dim adapter As SqlDataAdapter
        adapter = New SqlDataAdapter(query, Con)
        Dim bulider = New SqlCommandBuilder(adapter)
        Dim ds As DataSet
        ds = New DataSet()
        adapter.Fill(ds)
        PatientsDGV.DataSource = ds.Tables(0)
        Con.Close()
    End Sub
    Private Sub AddBtn_Click(sender As Object, e As EventArgs) Handles AddBtn.Click
        Try
            If Con.State = ConnectionState.Closed Then
                Con.Open()
                Dim query = "insert into PatientTbl(Patient_Name,Patient_age,Patient_phone,Patient_Gen,Patient_BGroup,Patient_address) values (@PonName,@PonAge,@PonPhone,@PonGen,@PonBGroup,@PonAdd)"
                Dim cmd As New SqlCommand(query, Con)
                cmd.Parameters.AddWithValue("@PonName", PnameTb.Text)
                cmd.Parameters.AddWithValue("@PonAge", PAgeTb.Text)
                cmd.Parameters.AddWithValue("@PonPhone", PPhoneTb.Text)
                cmd.Parameters.AddWithValue("@PonGen", PGenCb.SelectedItem.ToString())
                cmd.Parameters.AddWithValue("@PonBGroup", PBGroupCb.SelectedItem.ToString())
                cmd.Parameters.AddWithValue("@PonAdd", PAddressTb.Text)

                cmd.ExecuteNonQuery()
                MsgBox("Patient Saved")
            End If
            Con.Close()
            DisplayForm4()
        Catch ex As Exception
            MsgBox(ex.Message)

        End Try
    End Sub

    Private Sub PictureBox2_Click(sender As Object, e As EventArgs) Handles PictureBox2.Click
        Application.Exit()
    End Sub

    Private Sub DeleteBtn_Click(sender As Object, e As EventArgs) Handles DeleteBtn.Click
        If key = 0 Then
            MsgBox("Select The Patient To Be Deleted")
        Else
            Con.Open()
            Dim cmd As SqlCommand
            Dim query = "delete from PatientTbl where Patient_id = " & key & ""
            cmd = New SqlCommand(query, Con)
            cmd.ExecuteNonQuery()
            MsgBox("Patient Deleted Successfully")
            Con.Close()
            DisplayForm4()
        End If
    End Sub


    Dim key As Integer
    Private Sub PatientsDGV_CellMouseClick(sender As Object, e As DataGridViewCellMouseEventArgs) Handles PatientsDGV.CellMouseClick
        Dim row As DataGridViewRow = PatientsDGV.Rows(e.RowIndex)
        PnameTb.Text = row.Cells(1).Value.ToString
        PAgeTb.Text = row.Cells(2).Value.ToString
        PGenCb.SelectedItem = row.Cells(4).Value.ToString
        PPhoneTb.Text = row.Cells(3).Value.ToString
        PBGroupCb.SelectedItem = row.Cells(5).Value.ToString
        PAddressTb.Text = row.Cells(6).Value.ToString

        If PnameTb.Text = "Patient Name" Or PnameTb.Text = "" Then
            key = 0
        Else
            key = row.Cells(0).Value.ToString
        End If
    End Sub

    Private Sub Form4_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        DisplayForm4()
    End Sub

    Private Sub EditBtn_Click(sender As Object, e As EventArgs) Handles EditBtn.Click
        If key = 0 Or PnameTb.Text = "" Or PAgeTb.Text = "" Or PPhoneTb.Text = "" Or PAddressTb.Text = "" Then
            MsgBox("Incomplete Information")
        Else
            Con.Open()
            Dim query = "update PatientTBl set Patient_name = '" & PnameTb.Text & "',Patient_age = " & PAgeTb.Text & " ,Patient_Gen='" & PGenCb.SelectedItem.ToString & "',Patient_phone='" & PPhoneTb.Text & "',Patient_BGroup='" & PBGroupCb.SelectedItem.ToString() & "',Patient_address='" & PAddressTb.Text & "' where Patient_id= " & key & ""
            Dim cmd As New SqlCommand(query, Con)
            cmd.ExecuteNonQuery()
            MsgBox("Patient Update Successfully")
            Con.Close()
            DisplayForm4()
        End If
    End Sub

    Private Sub Label1_Click(sender As Object, e As EventArgs) Handles Label1.Click
        Dim Obj As New Form3
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

    Private Sub Label8_Click(sender As Object, e As EventArgs) Handles Label8.Click

    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim Obj = New Form2
        Obj.Show()
        Me.Hide()
    End Sub
End Class