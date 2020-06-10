Imports System.Text
Imports System.IO

Public Class Form1

    Dim dd As Integer = My.Settings.dd.ToString
    Dim mm As Integer = My.Settings.mm.ToString
    Dim yy As Integer = My.Settings.yy.ToString

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click

        dd = dd + 1
        mm = mm + 1
        yy = yy + 1

        If dd = 30 Then
            dd = 2

        End If
        If mm = 13 Then
            mm = 1

        End If
        If yy = 2003 Then
            yy = 1985

        End If
        Dim firstnames() As String = {"john", "peter", "Andrew", "Richard", "james", "henny", "loop", "merry", "bond", "lichal", "lemaon"}
        Dim lastnames() As String = {"lannister", "Targaryen", "Snow", "mormont", "tarly", "gender", "lenny", "zenlic", "rocker"}
        Dim rand As Random = New Random()





        Dim indexfirstname As Integer = rand.Next(firstnames.Length)
        Dim indexlastname As Integer = rand.Next(lastnames.Length)


        Me.TextBox1.Text = firstnames(indexfirstname)
        Me.TextBox2.Text = lastnames(indexlastname)


        TextBox3.Text = dd & "/" & mm & "/" & yy

        My.Settings.dd = dd
        My.Settings.mm = mm
        My.Settings.yy = yy

        My.Settings.Save()

        'setting for password generator
        TextBox4.Text = TextBox1.Text & TextBox2.Text & yy.ToString

        TextBox5.Text = TextBox1.Text & TextBox2.Text & yy.ToString & ComboBox1.Text


        'setting for save datagrid

        Dim row As String() = New String() {TextBox1.Text, TextBox2.Text, TextBox3.Text, TextBox4.Text, TextBox5.Text}

        DataGridView1.Rows.Add(row)
        Timer1.Enabled = True




    End Sub

    Private Sub DataGridView1_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView1.CellContentClick

    End Sub

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ComboBox1.SelectedIndex = 1

    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        ' setting for save  datagrid to textfiles
        ProgressBar1.Value = 0

        Dim saveFileDialog1 As New SaveFileDialog()
        saveFileDialog1.InitialDirectory = Application.StartupPath

        saveFileDialog1.Filter = "Text files (*.txt)|*.txt|All files (*.*)|*.*"
        saveFileDialog1.ShowDialog()

        Dim numCols As Integer = DataGridView1.ColumnCount

        Dim numRows As Integer = DataGridView1.RowCount - 1

        Dim strDestinationFile As String = saveFileDialog1.FileName


        Dim tw As TextWriter = New StreamWriter(strDestinationFile)

        'writing the header

        For count As Integer = 0 To numCols - 1

            tw.Write(DataGridView1.Columns(count).HeaderText)

            If (count <> numCols - 1) Then

                tw.Write(", ")

            End If

        Next

        tw.WriteLine()
        ProgressBar1.Value = 50


        For count As Integer = 0 To numRows - 1

            For count2 As Integer = 0 To numCols - 1

                tw.Write(DataGridView1.Rows(count).Cells(count2).Value)

                If (count2 <> numCols) Then

                    tw.Write(", ")

                End If

            Next

            tw.WriteLine()
            ProgressBar1.Value = 70


        Next

        tw.Close()
        ProgressBar1.Value = 99

        MsgBox("data exported to the textfile succsessfully")
        ProgressBar1.Value = 0



    End Sub

    Private Sub GroupBox2_Enter(sender As Object, e As EventArgs) Handles GroupBox2.Enter

    End Sub

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        SendKeys.Send(TextBox1.Text)
        SendKeys.Send("{Enter}")
        SendKeys.Send("{TAB}")

        SendKeys.Send(TextBox2.Text)
        SendKeys.Send("{Enter}")
        SendKeys.Send("{TAB}")

        SendKeys.Send(TextBox3.Text)
        SendKeys.Send("{Enter}")
        SendKeys.Send("{TAB}")
        SendKeys.Send("{TAB}")


        SendKeys.Send(TextBox5.Text)
        SendKeys.Send("{TAB}")




        SendKeys.Send(TextBox4.Text)

       
        Timer1.Enabled = False

    End Sub
End Class
