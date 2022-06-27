﻿Imports MySql.Data.MySqlClient
Imports System.Net.Mail
Public Class _Default
    Inherits Page
    Dim connection As MySqlConnection
    Dim command As MySqlCommand
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As EventArgs) Handles Me.Load
        connection = New MySqlConnection
        connection.ConnectionString = ("server='localhost';port='3306';username='root';password='gieRHAAA9iSi3ULZ';database='tspi_db'")

        Dim query As String
        query = ("select count(*) from `ticket` where `tick_status`='ACTIVE'  or `tick_status`='CONTINUING' ")
        command = New MySqlCommand(query, connection)

        Dim reader As MySqlDataReader
        connection.Open()
        reader = command.ExecuteReader()
        If reader.Read() Then
            If reader.IsDBNull(0) Then
                Label7.Text = String.Empty
                Label7.Text = "No Pending Request"
                connection.Close()
            Else
                Label7.Text = reader(0)
                connection.Close()
            End If
        End If
        reader.Close()

        Dim query1 As String
        query1 = ("select min(idticket) from `ticket` where `tick_status`='ACTIVE'")
        command = New MySqlCommand(query1, connection)

        Dim reader1 As MySqlDataReader
        connection.Open()
        reader1 = command.ExecuteReader()
        If reader1.Read() Then
            If reader1.IsDBNull(0) Then
                Label8.Text = String.Empty
                Label8.Text = "Next in Line"
                connection.Close()
            Else
                Label8.Text = reader1(0)
                connection.Close()
            End If
        End If
        reader1.Close()
    End Sub

    Protected Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim reader1 As MySqlDataReader
        Dim query As String
        query = "SELECT * from ticket where BINARY tick_name ='" & TextBox3.Text & "' and BINARY tick_info = '" & TextBox2.Text & "' "
        command = New MySqlCommand(query, connection)
        connection.Open()
        reader1 = command.ExecuteReader
            Dim count As Integer
            count = 0
            While reader1.Read
                count = count + 1

            End While

        If count > 0 Then
            Label9.Text = "DUPLICATED REQUEST!"
            TextBox1.Text = ""
            TextBox2.Text = ""
            TextBox3.Text = ""
            TextBox4.Text = ""
            TextBox5.Text = ""
            reader1.Close()
            connection.Close()
        Else
            Label9.Text = ".."
            If TextBox1.Text = "" Then
                MsgBox("Please input employee number")
            ElseIf TextBox2.Text = "" Then
                MsgBox("Please explain initial action taken and nature of the concern")
            Else
                connection = New MySqlConnection
                connection.ConnectionString = ("server='localhost';port='3306';username='root';password='gieRHAAA9iSi3ULZ';database='tspi_db'")

                Dim query1 As String
                query1 = ("Insert into `ticket`(`tick_emp` , `tick_name` , `tick_dept` , `tick_station` , `tick_request` , `tick_info` , `tick_status` , `tick_action`) 
                                        VALUES ('" & TextBox1.Text & "', '" & TextBox3.Text & "', '" & TextBox4.Text & "', '" & TextBox5.Text & "', '" & DropDownList1.Text & "', '" & TextBox2.Text & "' , 'ACTIVE' , 'NOT AVAILABLE')")
                command = New MySqlCommand(query1, connection)
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

                    Try
                        Dim Smtp_Server As New SmtpClient
                        Dim email As New MailMessage
                        Smtp_Server.UseDefaultCredentials = False
                        Smtp_Server.Credentials = New Net.NetworkCredential("telfordticketemailer@yahoo.com", "lgngjczqskgrqxcl")
                        Smtp_Server.Port = 587
                        Smtp_Server.EnableSsl = True
                        Smtp_Server.Host = "smtp.mail.yahoo.com"
                        email = New MailMessage
                        email.From = New MailAddress("telfordticketemailer@yahoo.com")
                        email.To.Add("telford_mis_helpdesk_ph@astigp.com")
                        email.Subject = "TICKET NUMBER: #" + Label5.Text + "   " + DropDownList1.Text
                        email.IsBodyHtml = False
                        email.Body = "Name: " + TextBox3.Text & vbNewLine & "Department: " + TextBox4.Text & vbNewLine & "Station: " + TextBox5.Text & vbNewLine & "Type of Request: " + DropDownList1.Text & vbNewLine & "" & vbNewLine & "" & vbNewLine & "Description:" & vbNewLine & TextBox2.Text
                        Smtp_Server.Send(email)
                    Catch ex As Exception
                    End Try
                    TextBox1.Text = ""
                    TextBox2.Text = ""
                    TextBox3.Text = ""
                    TextBox4.Text = ""
                    TextBox5.Text = ""
                    Response.Redirect("confirm.aspx")
                    connection.Close()
                Else
                End If
                reader.Close()
                reader1.Close()
            End If
        End If

    End Sub

    Protected Sub TextBox1_TextChanged(sender As Object, e As EventArgs) Handles TextBox1.TextChanged
        connection = New MySqlConnection
        connection.ConnectionString = ("server='localhost';port='3306';username='root';password='gieRHAAA9iSi3ULZ';database='tspi_db'")
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
        reader.Close()
    End Sub
End Class