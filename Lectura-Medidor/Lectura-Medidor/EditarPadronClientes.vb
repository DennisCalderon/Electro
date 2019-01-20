Public Class EditarPadronClientes
    Private Sub btnCancelar_Click(sender As Object, e As EventArgs) Handles btnCancelar.Click
        Me.Close()
    End Sub

    Private Sub EditarPadronClientes_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim desplegarContenidoEditar() As String = MVariables.EditarContenidoPadron.Split(";")

        txt1.Text = desplegarContenidoEditar(0)
        txt2.Text = desplegarContenidoEditar(1)
        txt3.Text = desplegarContenidoEditar(2)
        txt4.Text = desplegarContenidoEditar(3)
        txt5.Text = desplegarContenidoEditar(4)
        txt6.Text = desplegarContenidoEditar(5)
        txt7.Text = desplegarContenidoEditar(6)
        txt8.Text = desplegarContenidoEditar(7)
        txt9.Text = desplegarContenidoEditar(8)
        txt10.Text = desplegarContenidoEditar(9)
        txt11.Text = desplegarContenidoEditar(10)
        txt12.Text = desplegarContenidoEditar(11)
        txt13.Text = desplegarContenidoEditar(12)
        txt14.Text = desplegarContenidoEditar(13)
        txt15.Text = desplegarContenidoEditar(14)
        txt16.Text = desplegarContenidoEditar(15)
        txt17.Text = desplegarContenidoEditar(16)
    End Sub

    Private Sub btnGuardar_Click(sender As Object, e As EventArgs) Handles btnGuardar.Click
        MConsultasDB.ActualizarPadronCliente(txt1.Text, txt2.Text, txt3.Text, txt4.Text, txt5.Text, txt6.Text, txt7.Text, txt8.Text, txt9.Text, txt10.Text, txt11.Text, txt12.Text, txt13.Text, txt14.Text, txt15.Text, txt16.Text, txt17.Text)
        MsgBox("Datos actualizados.", MsgBoxStyle.Information, "Exito")
        Me.Close()
    End Sub
End Class