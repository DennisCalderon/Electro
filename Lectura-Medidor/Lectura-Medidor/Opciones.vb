Public Class Opciones

    Private Sub Opciones_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        MConsultasDB.ConsultaOpcionesDB(MVariables.GuardarDB)
        'MsgBox(GuardarDB)
        btnCancelar.Select()
        If (MVariables.GuardarDB = "1") Then
            rbnSi.Checked = True
            rbnNo.Checked = False
        End If
        If (MVariables.GuardarDB = "0") Then
            rbnSi.Checked = False
            rbnNo.Checked = True
        End If
    End Sub

    Private Sub btnCancelar_Click(sender As Object, e As EventArgs) Handles btnCancelar.Click
        Me.Close()
    End Sub

    Private Sub btnGuardar_Click(sender As Object, e As EventArgs) Handles btnGuardar.Click
        If (rbnSi.Checked = True) Then
            MVariables.GuardarDB = "1"
        Else
            MVariables.GuardarDB = "0"
        End If
        MConsultasDB.ActualizarOpcionesDB(MVariables.GuardarDB)
        MsgBox("Cambios realizados", MsgBoxStyle.Information, "Atención!!!")
        Me.Close()
    End Sub
End Class