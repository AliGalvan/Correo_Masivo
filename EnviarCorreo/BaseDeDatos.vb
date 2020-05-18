Imports System.Data.Sql
Imports System.Data.SqlClient

Public Class BaseDeDatos

    Public cn As SqlConnection
    Public cmd As SqlCommand
    Public dr As SqlDataReader

    Sub New()
        Try
            cn = New SqlConnection("Data Source=.;Initial Catalog=Empresa;Integrated Security=True")
            cn.Open()
        Catch ex As Exception
            MessageBox.Show("Error en la conexion debido a: " + ex.ToString)
        End Try
    End Sub

    Sub enviarCorreoMasivo(ByVal emisor As String, ByVal password As String, ByVal mensaje As String, ByVal asunto As String, ByVal ruta As String)
        Try
            cmd = New SqlCommand("Select Correo_Electronico from Cliente", cn)
            dr = cmd.ExecuteReader
            While dr.Read
                enviarCorreo(emisor, password, mensaje, asunto, dr.Item("Correo_Electronico"), ruta)
            End While
            dr.Close()
        Catch ex As Exception
            MessageBox.Show("Error en la consulta: " + ex.ToString)
        End Try
    End Sub


End Class
