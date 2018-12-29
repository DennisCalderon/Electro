Public Class IntegridadLecturas
    Private Sub IntegridadLecturas_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim cadena As New List(Of String)
        cadena = Module1.integridadLecturas
        Dim ii As Integer

        For ii = 0 To cadena.Count - 1
            txtLecturas.Text = txtLecturas.Text & cadena.Item(ii) & vbNewLine
        Next ii
    End Sub
End Class