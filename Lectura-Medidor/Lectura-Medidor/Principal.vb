Imports System.IO
Public Class Principal
    Dim ruta_general As String
    Sub leerTiposMedidores(ByRef tipos_archivo As String)
        If chkS1440.Checked = True Then tipos_archivo = "S-1440|*.LP"
        If chkA1800.Checked = True Then tipos_archivo = "A-1800|*.prn"
        If chkMHTAB.Checked = True Then tipos_archivo = "MH-TAB|*.tab"
        If chkS1440.Checked = True And chkA1800.Checked = True Then tipos_archivo = "S-1440 y A-1800|*.LP;*.prn" '"S-1440|*.LP" & "|A-1800|*.prn"
        If chkS1440.Checked = True And chkMHTAB.Checked = True Then tipos_archivo = "S-1440 y MH-TAB|*.LP;*.tab" '"S-1440|*.LP" & "|MH-TAB|*.tab"
        If chkA1800.Checked = True And chkMHTAB.Checked = True Then tipos_archivo = "A-1800 y MH-TAB|*.prn;*.tab" ' "A-1800|*.prn" & "|MH-TAB|*.tab"
        If chkS1440.Checked = True And chkA1800.Checked = True And chkMHTAB.Checked = True Then tipos_archivo = "S-1440 y A-1800 y MH-TAB|*.LP;*.prn;*.tab" '"S-1440|*.LP" & "|A-1800|*.prn" & "|MH-TAB|*.tab"
    End Sub
    Sub checkedMedidor(ByVal X As Boolean)
        chkS1440.Enabled = X
        chkA1800.Enabled = X
        chkMHTAB.Enabled = X
    End Sub
    Sub checkedPadron(ByVal X As Boolean)
        chkTacna.Enabled = X
        chkMoquegua.Enabled = X
        chkIlo.Enabled = X
        chkLibres.Enabled = X
    End Sub
    Private Sub btnBuscar_Click(sender As Object, e As EventArgs) Handles btnBuscar.Click
        'buscar la ruta de los archivos
        Dim tipos_archivo As String = "Ejecutables|*.exe" ' por si el usuario no elije ningún checked se le colocara esto por defecto

        leerTiposMedidores(tipos_archivo)
        'MsgBox(tipos_archivo)

        OpenFileDialog1.Title = "Buscando la ubicación de los Archivos"
        OpenFileDialog1.FileName = "Archivos"

        OpenFileDialog1.Filter = tipos_archivo
        'OpenFileDialog1.Filter = "S-1440|*.LP" + "|A-1800|*.prn" + "|MH-TAB|*.tab"

        If OpenFileDialog1.ShowDialog() = Windows.Forms.DialogResult.OK Then
            Dim ruta As String '= "C:\Users\sing_\source\repos\Electrosur\Recursos"
            ruta = OpenFileDialog1.FileName
            txtruta.Text = OpenFileDialog1.FileName

            lbArchivos.Items.Clear()
            'MsgBox(tipos_archivo.Remove(0, 7))
            ruta = ruta.Substring(0, (ruta.LastIndexOf("\") + 1))
            ruta_general = ruta ' colocando la RUTA en la variable Global "RUTA"
            Dim folder As New DirectoryInfo(ruta)
            Dim cant_archivos As Integer = 0

            'llenar el ListBox con las lecturas
            If tipos_archivo.Contains("*.LP") = True Then
                'MsgBox(tipos_archivo)
                For Each file As FileInfo In folder.GetFiles("*.LP")
                    lbArchivos.Items.Add(file.Name)
                    cant_archivos = cant_archivos + 1
                Next
            End If
            If tipos_archivo.Contains("*.prn") = True Then
                For Each file As FileInfo In folder.GetFiles("*.prn")
                    lbArchivos.Items.Add(file.Name)
                    cant_archivos = cant_archivos + 1
                Next
            End If
            If tipos_archivo.Contains("*.tab") = True Then
                For Each file As FileInfo In folder.GetFiles("*.tab")
                    lbArchivos.Items.Add(file.Name)
                    cant_archivos = cant_archivos + 1
                Next
            End If

            lblarchivos.Text = cant_archivos

            btnBuscar.Enabled = False
            btnExportMasivo.Enabled = True
            lbArchivos.Enabled = True
            btnNuevo.Enabled = True
            checkedMedidor(False)
            checkedPadron(True)
            btnNuevo.Select()
        Else
            MsgBox("No seleccionaste nada", MsgBoxStyle.Critical, "Error")
        End If
    End Sub

    Private Sub Principal_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        btnNuevo.Enabled = False
        btnExportUnit.Enabled = False
        btnExportMasivo.Enabled = False
        lbArchivos.Enabled = False
        dgvcontenido.Enabled = False
        checkedPadron(False)

        btnBuscar.Select()
    End Sub

    Private Sub btnNuevo_Click(sender As Object, e As EventArgs) Handles btnNuevo.Click
        btnBuscar.Enabled = True
        checkedMedidor(True)
        lblregistros.Text = "0"
        lblarchivos.Text = "0"
        btnNuevo.Enabled = False
        btnExportUnit.Enabled = False
        btnExportMasivo.Enabled = False
        checkedPadron(False)

        lbArchivos.Items.Clear()
        dgvcontenido.Rows.Clear()

        btnBuscar.Select()
    End Sub
End Class
