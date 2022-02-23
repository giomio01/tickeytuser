﻿Imports MySql.Data.MySqlClient
Imports System.Net.Mail
Public Class _Default
    Inherits Page
    Dim connection As MySqlConnection
    Dim command As MySqlCommand
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As EventArgs) Handles Me.Load

    End Sub

    Protected Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        If TextBox1.Text = "" Then
            MsgBox("Please input employee number")
        ElseIf TextBox2.Text = "" Then
            MsgBox("Please explain initial action taken and nature of the concern")
        Else
            connection = New MySqlConnection
            connection.ConnectionString = ("server='localhost';port='3306';username='root';password='';database='tspi_db'")

            Dim query As String
            query = ("Insert into `ticket`(`tick_emp` , `tick_name` , `tick_dept` , `tick_station` , `tick_request` , `tick_info` , `tick_status` , `tick_action`) 
                                        VALUES ('" & TextBox1.Text & "', '" & TextBox3.Text & "', '" & TextBox4.Text & "', '" & TextBox5.Text & "', '" & DropDownList1.Text & "', '" & TextBox2.Text & "' , 'ACTIVE' , 'NOT AVAILABLE')")
            command = New MySqlCommand(query, connection)
            connection.Open()
            command.ExecuteReader()
            connection.Close()
            Dim query2 As String
            query2 = ("select max(idticket) from `ticket`")
            command = New MySqlCommand(query2, connection)

            Dim reader As MySqlDataReader
            connection.Open()
            reader = command.ExecuteReader()
            If reader.Read() Then
                Label5.Text = reader(0)
                MsgBox("GENERATING TICKET...")
                Try
                    Dim Smtp_Server As New SmtpClient
                    Dim email As New MailMessage
                    Smtp_Server.UseDefaultCredentials = False
                    Smtp_Server.Credentials = New Net.NetworkCredential("TspiTicketEmailer@gmail.com", "Tspi123456.")
                    Smtp_Server.Port = 587
                    Smtp_Server.EnableSsl = True
                    Smtp_Server.Host = "smtp.gmail.com"
                    email = New MailMessage
                    email.From = New MailAddress("TspiTicketEmailer@gmail.com")
                    email.To.Add("abillera_g@yahoo.com")
                    email.Subject = "TICKET NUMBER: # " + Label5.Text + "   " + DropDownList1.Text
                    email.IsBodyHtml = False
                    email.Body = TextBox3.Text & vbNewLine & TextBox4.Text & vbNewLine & TextBox5.Text & vbNewLine & "" & vbNewLine & "" & vbNewLine & "Description:" & vbNewLine & TextBox2.Text
                    Smtp_Server.Send(email)
                Catch ex As Exception
                    MsgBox(ex.Message)
                End Try
                TextBox1.Text = ""
                TextBox2.Text = ""
                TextBox3.Text = ""
                TextBox4.Text = ""
                TextBox5.Text = ""
                MsgBox("YOUR TICKET NUMBER IS: " + Label5.Text)
            Else
            End If
        End If

    End Sub

    Protected Sub TextBox1_TextChanged(sender As Object, e As EventArgs) Handles TextBox1.TextChanged
        connection = New MySqlConnection
        connection.ConnectionString = ("server='localhost';port='3306';username='root';password='';database='tspi_db'")
        Dim query As String
        query = ("select * from `emp_masterlist` where `EMP_NO` = '" & TextBox1.Text & "'")
        command = New MySqlCommand(query, connection)
        Dim reader As MySqlDataReader
        connection.Open()
        reader = command.ExecuteReader()
        If reader.Read() Then
            TextBox3.Text = reader(1)
            TextBox4.Text = reader(4)
            TextBox5.Text = reader(5)
            connection.Close()
        Else

        End If
    End Sub
End Class