Public Class RegistrosVacios
    Private Sub btnSeguirProcesando_Click(sender As Object, e As EventArgs) Handles btnSeguirProcesando.Click
        MVariables.verificarProceso = 2
        Me.Close()
    End Sub

    Private Sub btnabortar_Click(sender As Object, e As EventArgs) Handles btnabortar.Click
        MVariables.verificarProceso = 3
        Me.Close()
    End Sub

    Private Sub RegistrosVacios_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim cadena As String
        cadena = MVariables.cadena
        Dim ii As Integer
        txtLista.Text = ""
        'MsgBox(cadena)
        Dim arreglo() As String = cadena.Split(";")
        For ii = 0 To arreglo.Length - 1
            txtLista.Text = txtLista.Text & arreglo(ii) & vbNewLine
        Next ii
        btnabortar.Select()
    End Sub
End Class