Imports System.IO
Imports System.Data.SQLite
Public Class Form1
    Private Sub Button1_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        cbotipomedidor.Items.Add("S-1440")
        cbotipomedidor.Items.Add("A-1800")
        cbotipomedidor.Items.Add("MH-TAB")
        cbotipomedidor.SelectedIndex = 0 ' colocar el focus en el item 0
        dgvcontenido.AllowUserToAddRows = False ' denegar la acción de registros al usuario

        'btnBuscar.Enabled = False
        btnNuevo.Enabled = False
        btnExportUnit.Enabled = False
        btnExportMasivo.Enabled = False

    End Sub

    Private Sub btnBuscar_Click(sender As Object, e As EventArgs) Handles btnBuscar.Click
        'buscar la ruta de los archivos
        Dim tipo_archivo As Integer
        Dim tipos_archivo As String = String.Empty

        tipo_archivo = cbotipomedidor.SelectedIndex
        Select Case tipo_archivo
            Case 0 : tipos_archivo = "S-1440|*.LP"
            Case 1 : tipos_archivo = "A-1800|*.prn"
            Case 2 : tipos_archivo = "MH-TAB|*.tab"
        End Select

        OpenFileDialog1.Title = "Buscando la ubicación de los Archivos"
        OpenFileDialog1.FileName = "Archivos"

        OpenFileDialog1.Filter = tipos_archivo

        'OpenFileDialog1.Filter = "S-1440|*.LP" +
        '                        "|A-1800|*.prn" +
        '                       "|MH-TAB|*.tab"
        If OpenFileDialog1.ShowDialog() = Windows.Forms.DialogResult.OK Then
            txtruta.Text = OpenFileDialog1.FileName

            lbArchivos.Items.Clear()
            'MsgBox(tipos_archivo.Remove(0, 7))
            Dim ruta As String '= "C:\Users\sing_\source\repos\Electrosur\Recursos"
            ruta = txtruta.Text.Substring(0, (txtruta.Text.LastIndexOf("\") + 1))
            Dim folder As New DirectoryInfo(ruta)
            Dim cant_archivos As Integer = 0

            For Each file As FileInfo In folder.GetFiles(tipos_archivo.Remove(0, 7))
                lbArchivos.Items.Add(file.Name)
                cant_archivos = cant_archivos + 1
            Next
            lblarchivos.Text = cant_archivos

            btnBuscar.Enabled = False
            btnNuevo.Enabled = True
            btnNuevo.Select()
        Else
            MsgBox("No seleccionaste nada", MsgBoxStyle.Critical, "Error")
        End If
    End Sub

    Private Sub btnNuevo_Click(sender As Object, e As EventArgs) Handles btnNuevo.Click
        btnBuscar.Enabled = True
        btnNuevo.Enabled = False
        'btnExportUnit.Enabled = False
        'btnExportMasivo.Enabled = False
        lbArchivos.Items.Clear()
        btnBuscar.Select()
    End Sub
End Class
