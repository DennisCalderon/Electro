Public Class PadronClientesExcel
    Private Sub btnExportar_Click(sender As Object, e As EventArgs) Handles btnExportar.Click
        dgvpadron.Rows.Clear()
        Dim lista As New List(Of String)
        If chkTacna.Checked = True Then
            lista.Add("Tacna")
        End If
        If chkMoquegua.Checked = True Then
            lista.Add("Moquegua")
        End If
        If chkIlo.Checked = True Then
            lista.Add("Ilo")
        End If
        If chkLibres.Checked = True Then
            lista.Add("Libres")
        End If
        MExportExcel.ExportPadron(lista, dgvpadron)

    End Sub

    Private Sub btnCancela_Click(sender As Object, e As EventArgs) Handles btnCancela.Click
        Me.Close()
    End Sub

    Private Sub PadronClientesExcel_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        dgvpadron.Name = "Hoja"
    End Sub
End Class