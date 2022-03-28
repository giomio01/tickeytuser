Imports MySql.Data.MySqlClient

Public Class WebForm1
    Inherits System.Web.UI.Page
    Dim connection As MySqlConnection
    Dim command As MySqlCommand
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        connection = New MySqlConnection
        connection.ConnectionString = ("server='localhost';port='3306';username='root';password='gieRHAAA9iSi3ULZ';database='tspi_db'")
        Dim query2 As String
        query2 = ("select max(idticket) from `ticket`")
        command = New MySqlCommand(query2, connection)
        Dim reader As MySqlDataReader
        connection.Open()
        reader = command.ExecuteReader()
        If reader.Read() Then
            Label1.Text = reader(0)
        Else
        End If
        connection.Close()
    End Sub

    Protected Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Response.Redirect("Ticket.aspx")
    End Sub
End Class