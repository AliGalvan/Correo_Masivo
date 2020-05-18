Imports System
Imports System.IO
Imports System.Collections
Public Class FrmCorreo
    'Dim objReader As New StreamReader("c:\test.txt")
    Dim sLine As String = ""
    Dim arrText As New ArrayList()
    Private Sub BtnEnviar_Click(sender As Object, e As EventArgs) Handles BtnEnviar.Click
        Try
            Dim objReader As New StreamReader(TextBox1.Text)
            Dim sLine As String = ""
            Dim arrText As New ArrayList()

            ProgressBar1.Visible = True

            Do
                sLine = objReader.ReadLine()
                If Not sLine Is Nothing Then
                    arrText.Add(sLine)
                End If
            Loop Until sLine Is Nothing
            objReader.Close()

            ProgressBar1.Maximum = arrText.Count
            ProgressBar1.Minimum = 0

            For Each sLine In arrText
                Correo.enviarCorreo(txtEmisor.Text, txtPassword.Text, rtbMensaje.Text, txtAsunto.Text, sLine, txtRutaArchivo.Text)
                ProgressBar1.Value = ProgressBar1.Value + 1
                'Console.WriteLine(sLine)
            Next
            MsgBox("Los mensajes furon enviados correctamente. ", MsgBoxStyle.Information, "Mensaje")
            ProgressBar1.Visible = False
            'Console.ReadLine()
        Catch ex As Exception
            MsgBox("Error en datos de formulario", MsgBoxStyle.Information, "Mensaje")
        End Try

        'Dim obj As New BaseDeDatos
        'obj.enviarCorreoMasivo(txtEmisor.Text, txtPassword.Text, rtbMensaje.Text, txtAsunto.Text, txtRutaArchivo.Text)
    End Sub

    Private Sub FrmCorreo_Load(sender As Object, e As EventArgs)

    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Try
            Me.OpenFileDialog1.ShowDialog()
            If Me.OpenFileDialog1.FileName <> "" Then
                txtRutaArchivo.Text = Me.OpenFileDialog1.FileName
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Me.OpenFileDialog1.InitialDirectory = ".\"
        Me.OpenFileDialog1.Filter = "Archivo de Texto (*.txt)|*.txt|Todos los Archivos (*.*)|*.*"
        Me.OpenFileDialog1.FileName = ""
        Try
            Me.OpenFileDialog1.ShowDialog()
            If Me.OpenFileDialog1.FileName <> "" Then
                TextBox1.Text = Me.OpenFileDialog1.FileName
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub PictureBox2_Click(sender As Object, e As EventArgs) Handles PictureBox2.Click
        BtnEnviar_Click(sender, e)
    End Sub

End Class
