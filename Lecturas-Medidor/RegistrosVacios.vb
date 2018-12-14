Public Class RegistrosVacios
    Private Sub RegistrosVacios_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim cadena As String
        cadena = Module1.cadena
        Dim ii As Integer
        TextBox1.Text = ""
        'MsgBox(cadena)
        Dim arreglo() As String = cadena.Split(";")
        For ii = 0 To arreglo.Length - 1
            TextBox1.Text = TextBox1.Text & arreglo(ii) & vbNewLine
        Next ii

    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Module1.verificarProceso = 2
        Me.Close()
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Module1.verificarProceso = 3
        Me.Close()
    End Sub
End Class